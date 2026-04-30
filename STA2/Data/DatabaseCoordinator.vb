Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Drawing


Public Module DatabaseCoordinator
    Private _evaluationInProgress As Boolean = False

    ' Timeouts / cache
    Private ReadOnly ProcessDefaultTimeoutMs As Integer = 3000
    Private ReadOnly DockerCacheTTL As TimeSpan = TimeSpan.FromSeconds(5)
    Private DockerInstalledCached As Boolean? = Nothing
    Private DockerInstalledCachedAt As DateTime = DateTime.MinValue
    Private DockerRunningCached As Boolean? = Nothing
    Private DockerRunningCachedAt As DateTime = DateTime.MinValue
    Private ReadOnly DockerCacheLock As New Object()

    ' ============================================================
    ' Connectivity
    ' ============================================================
    Public Function TestConnection(connectionString As String) As Boolean
        Return TestConnection(connectionString, timeoutSeconds:=5)
    End Function

    Public Function TestConnection(connectionString As String, Optional timeoutSeconds As Integer = 5) As Boolean
        Try
            ' Ensure a short connect timeout (don't block long on network issues)
            Dim csb As New SqlConnectionStringBuilder(connectionString)
            If csb.ConnectTimeout <= 0 OrElse csb.ConnectTimeout > timeoutSeconds Then
                csb.ConnectTimeout = timeoutSeconds
            End If

            Using cn As New SqlConnection(csb.ConnectionString)
                cn.Open()
                Return (cn.State = ConnectionState.Open)
            End Using
        Catch
            Return False
        End Try
    End Function

    ' ============================================================
    ' State transitions
    ' ============================================================
    Public Sub GoOffline(form As FormMain, reason As String)

        Variables.OfflineMode = True
        PCInfo.ValidDatabase = False

        InvokeOnUI(form,
        Sub()
            DisableDatabaseSections(form)

            If form.tslblDbState IsNot Nothing Then
                form.tslblDbState.Text = "OFFLINE"
                form.tslblDbState.ForeColor = Color.White
                form.tslblDbState.BackColor = Color.Firebrick
            End If

            If form.tslblExecutionStatus IsNot Nothing Then
                form.tslblExecutionStatus.Text = reason
                form.tslblExecutionStatus.Visible = True
            End If
        End Sub)

    End Sub
    Public Sub GoOnline(form As FormMain)

        Variables.OfflineMode = False
        PCInfo.ValidDatabase = True

        InvokeOnUI(form,
        Sub()
            EnableDatabaseSections(form)

            CodeHelper.GetPcInfo()
            CodeHelper.FirstLoad()
            CodeHelper.Refresher()

            If form.tslblDbState IsNot Nothing Then
                form.tslblDbState.Text = "ONLINE"
                form.tslblDbState.ForeColor = Color.WhiteSmoke
                form.tslblDbState.BackColor = Color.DarkGreen
            End If

            If form.tslblExecutionStatus IsNot Nothing Then
                form.tslblExecutionStatus.Text = ""
                form.tslblExecutionStatus.Visible = False
            End If
        End Sub)

    End Sub

    ' ============================================================
    ' UI helpers (FormMain‑aware by design)
    ' ============================================================
    Public Sub DisableDatabaseSections(form As FormMain)

        form.tbPcDbSize.Text = "Offline"
        form.tbPcSqlVersion.Text = "Offline"
        form.dgvAppOptions.DataSource = Nothing

        form.tpAdvData.Enabled = False
        form.tpDbLogs.Enabled = False
        form.pnlDbData.Enabled = False
        form.pnlDbInfoButtons.Enabled = False

    End Sub


    Public Sub EnableDatabaseSections(form As FormMain)

        form.tpAdvData.Enabled = True
        form.tpDbLogs.Enabled = True
        form.pnlDbData.Enabled = True
        form.pnlDbInfoButtons.Enabled = True

        form.tbPcDbSize.Text = ""
        form.tbPcSqlVersion.Text = ""

    End Sub


    Public Sub RefreshAdvantageData(form As FormMain)

        Try
            LoadAppOptions(form)
            LoadWebOptions(form)
            LoadApplicationInfo(form)

        Catch ex As SafeDb.DatabaseOfflineException
            GoOffline(form, "Lost DB connection during AdvantageDataRefresh")
        Catch ex As Exception
            GoOffline(form, "Database error during AdvantageDataRefresh: " & ex.Message)
        End Try

    End Sub


    ' ============================================================
    ' Section loaders (small, focused)
    ' ============================================================
    Private Sub LoadAppOptions(form As FormMain)

        form.dgvAppOptions.Rows.Clear()

        Dim dsApp As DataSet =
            SafeDb.TryQuery("SELECT OptionName, OptionValue FROM AppOptions")

        If dsApp Is Nothing OrElse dsApp.Tables.Count = 0 Then
            AppData.dbAppOptions = New DataSet()
            Exit Sub
        End If

        AppData.dbAppOptions = dsApp

        For Each row As DataRow In dsApp.Tables(0).Rows
            form.dgvAppOptions.Rows.Add(row.ItemArray)

            If String.Equals(row("OptionName").ToString(),
                             "UpgradePath",
                             StringComparison.OrdinalIgnoreCase) Then
                AppData.UpgradePath = row("OptionValue").ToString()
            End If
        Next

    End Sub


    Private Sub LoadWebOptions(form As FormMain)

        form.dgvWebOptions.Rows.Clear()

        Dim dsWeb As DataSet =
            SafeDb.TryQuery("SELECT OptionName, OptionValue FROM WebOptions")

        If dsWeb Is Nothing OrElse dsWeb.Tables.Count = 0 Then
            AppData.dbWebOptions = New DataSet()
            Exit Sub
        End If

        AppData.dbWebOptions = dsWeb

        For Each row As DataRow In dsWeb.Tables(0).Rows
            form.dgvWebOptions.Rows.Add(row.ItemArray)
        Next

    End Sub


    Private Sub LoadApplicationInfo(form As FormMain)

        form.dgvApplicationInfo.Rows.Clear()

        Dim dsInfo As DataSet =
            SafeDb.TryQuery("SELECT * FROM ApplicationInfo")

        If dsInfo Is Nothing OrElse dsInfo.Tables.Count = 0 Then
            AppData.dbApplicationInfo = New DataSet()
            Exit Sub
        End If

        AppData.dbApplicationInfo = dsInfo

        Dim t As DataTable = dsInfo.Tables(0)

        If t.Rows.Count = 0 Then Exit Sub

        Dim firstRow As DataRow = t.Rows(0)

        For i = 0 To t.Columns.Count - 1
            form.dgvApplicationInfo.Rows.Add(
                t.Columns(i).ColumnName,
                firstRow(i).ToString())
        Next

    End Sub

    ' ============================================================
    ' Process runner (safe, with timeout)
    ' ============================================================
    Private Class ProcessResult
        Public Property ExitCode As Integer
        Public Property StdOut As String
        Public Property StdErr As String
    End Class

    Private Function RunProcess(fileName As String, arguments As String, Optional timeoutMs As Integer = -1) As ProcessResult
        Dim psi As New ProcessStartInfo(fileName, arguments) With {
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }

        Dim outSb As New StringBuilder()
        Dim errSb As New StringBuilder()

        Using p As New Process()
            p.StartInfo = psi
            AddHandler p.OutputDataReceived, Sub(s, e)
                                                 If e.Data IsNot Nothing Then outSb.AppendLine(e.Data)
                                             End Sub
            AddHandler p.ErrorDataReceived, Sub(s, e)
                                                If e.Data IsNot Nothing Then errSb.AppendLine(e.Data)
                                            End Sub
            Try
                If Not p.Start() Then
                    Return New ProcessResult With {.ExitCode = -1, .StdOut = String.Empty, .StdErr = String.Empty}
                End If

                p.BeginOutputReadLine()
                p.BeginErrorReadLine()

                If timeoutMs <= 0 Then
                    p.WaitForExit()
                Else
                    If Not p.WaitForExit(timeoutMs) Then
                        Try
                            p.Kill()
                        Catch
                        End Try
                    End If
                    ' ensure asynchronous readers flush
                    p.WaitForExit()
                End If

            Catch ex As Exception
                Return New ProcessResult With {.ExitCode = -1, .StdOut = outSb.ToString().Trim(), .StdErr = errSb.ToString().Trim()}
            End Try

            Return New ProcessResult With {
                .ExitCode = p.ExitCode,
                .StdOut = outSb.ToString().Trim(),
                .StdErr = errSb.ToString().Trim()
            }
        End Using
    End Function

    ' ============================================================
    ' Docker helpers (use short timeouts + caching where helpful)
    ' ============================================================
    Private Function IsDockerInstalled() As Boolean
        SyncLock DockerCacheLock
            If DockerInstalledCached.HasValue AndAlso DateTime.UtcNow - DockerInstalledCachedAt < DockerCacheTTL Then
                Return DockerInstalledCached.Value
            End If
        End SyncLock

        Dim r = RunProcess("docker", "--version", ProcessDefaultTimeoutMs)
        Dim ok = (r.ExitCode = 0)

        SyncLock DockerCacheLock
            DockerInstalledCached = ok
            DockerInstalledCachedAt = DateTime.UtcNow
        End SyncLock

        Return ok
    End Function

    Private Function IsDockerRunning() As Boolean
        SyncLock DockerCacheLock
            If DockerRunningCached.HasValue AndAlso DateTime.UtcNow - DockerRunningCachedAt < DockerCacheTTL Then
                Return DockerRunningCached.Value
            End If
        End SyncLock

        Dim r = RunProcess("docker", "info", ProcessDefaultTimeoutMs)
        Dim ok = (r.ExitCode = 0)

        SyncLock DockerCacheLock
            DockerRunningCached = ok
            DockerRunningCachedAt = DateTime.UtcNow
        End SyncLock

        Return ok
    End Function

    Private Function SqlContainerExists(containerName As String) As Boolean
        If String.IsNullOrWhiteSpace(containerName) Then Return False
        Dim r = RunProcess("docker", $"inspect --format '{{{{.Id}}}}' {containerName}", ProcessDefaultTimeoutMs)
        Return r.ExitCode = 0
    End Function

    Private Function IsSqlContainerRunning(containerName As String) As Boolean
        If String.IsNullOrWhiteSpace(containerName) Then Return False
        Dim r = RunProcess("docker", $"inspect -f ""{{{{.State.Running}}}}"" {containerName}", ProcessDefaultTimeoutMs)
        If r.ExitCode <> 0 Then Return False
        Return String.Equals(r.StdOut.Trim(), "true", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function RunDockerCommand(arguments As String, Optional timeoutMs As Integer = -1) As String
        Dim r = RunProcess("docker", arguments, If(timeoutMs <= 0, ProcessDefaultTimeoutMs, timeoutMs))
        If r.ExitCode <> 0 Then
            Return String.Empty
        End If
        Return r.StdOut
    End Function

    Private Function FindSqlContainerByLabel() As String
        Dim output As String =
            RunDockerCommand(
                "ps -a --filter ""label=role=database"" --format ""{{.Names}}|{{.Status}}|{{.Ports}}""")

        If String.IsNullOrWhiteSpace(output) Then Return Nothing

        Dim lines = output.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        ' Prefer a running container (Status contains "Up") else return first name
        For Each line In lines
            Dim parts = line.Split("|"c)
            If parts.Length >= 2 Then
                Dim name = parts(0).Trim()
                Dim statusPart = parts(1)
                If statusPart.IndexOf("Up", StringComparison.OrdinalIgnoreCase) >= 0 Then
                    Return name
                End If
            End If
        Next

        ' fallback to first name
        Return lines.Select(Function(l) l.Split("|"c)(0).Trim()).FirstOrDefault()
    End Function

    Private Function FindSqlContainerByPublishedPort() As String
        ' get running containers with published ports
        Dim output As String =
            RunDockerCommand(
                "ps --filter ""status=running"" --format ""{{.Names}}|{{.Ports}}""")

        If String.IsNullOrWhiteSpace(output) Then Return Nothing

        Dim lines = output.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        ' Look for published host port 1433 in the Ports column.
        Dim portRegex As New Regex("(?:(?:0\.0\.0\.0|::|127\.0\.0\.1|::1|\S+):)?1433\b", RegexOptions.IgnoreCase)

        For Each line In lines
            Dim parts = line.Split("|"c)
            If parts.Length >= 2 Then
                Dim name = parts(0).Trim()
                Dim ports = parts(1)
                If String.IsNullOrWhiteSpace(ports) Then Continue For
                If portRegex.IsMatch(ports) OrElse ports.IndexOf("->1433", StringComparison.OrdinalIgnoreCase) >= 0 Then
                    Return name
                End If
            End If
        Next

        Return Nothing
    End Function

    Public Function DiscoverSqlContainerName(
    Optional configuredName As String = Nothing
) As String

        ' 1️⃣ Explicit configuration
        If Not String.IsNullOrWhiteSpace(configuredName) Then
            If SqlContainerExists(configuredName) Then
                Return configuredName
            End If
        End If

        ' 2️⃣ Label-based discovery
        Dim byLabel = FindSqlContainerByLabel()
        If Not String.IsNullOrWhiteSpace(byLabel) Then
            Return byLabel
        End If

        ' 3️⃣ SQL port-based discovery
        Dim byPort = FindSqlContainerByPublishedPort()
        If Not String.IsNullOrWhiteSpace(byPort) Then
            Return byPort
        End If

        Return Nothing
    End Function

    ' ============================================================
    ' Availability evaluation (keeps existing sync Public API,
    ' but uses the safer helpers above)
    ' ============================================================
    Public Sub EvaluateDatabaseAvailability(
        form As FormMain,
        connectionString As String,
        Optional configuredContainerName As String = Nothing
    )

        ' 1️⃣ Docker installed?
        If Not IsDockerInstalled() Then
            GoOffline(form, "Docker is not installed")
            Exit Sub
        End If

        ' 2️⃣ Docker running?
        If Not IsDockerRunning() Then
            GoOffline(form, "Docker is installed but not running")
            Exit Sub
        End If

        ' 3️⃣ Find SQL container
        Dim containerName As String =
            DiscoverSqlContainerName(configuredContainerName)

        If String.IsNullOrWhiteSpace(containerName) Then
            GoOffline(form, "SQL Docker container not found")
            Exit Sub
        End If

        ' 4️⃣ SQL container running?
        If Not IsSqlContainerRunning(containerName) Then
            GoOffline(form, $"SQL container ({containerName}) is not running")
            Exit Sub
        End If

        ' 5️⃣ Test SQL connectivity (short timeout)
        If Not TestConnection(connectionString, 5) Then
            GoOffline(form, "Unable to connect to SQL Server")
            Exit Sub
        End If

        ' ✅ Everything OK
        GoOnline(form)

    End Sub

    Public Async Function EvaluateDatabaseAvailabilityAsync(
    form As FormMain,
    connectionString As String,
    Optional configuredContainerName As String = Nothing
) As Task

        If _evaluationInProgress Then Return
        _evaluationInProgress = True

        Try
            ' Run synchronous evaluation on a background thread (safe because helper uses short timeouts)
            Await Task.Run(
            Sub()
                EvaluateDatabaseAvailability(
                    form,
                    connectionString,
                    configuredContainerName)
            End Sub)

        Finally
            _evaluationInProgress = False
        End Try

    End Function

    Private Sub InvokeOnUI(
    form As FormMain,
    action As Action
)
        If form Is Nothing OrElse form.IsDisposed Then Return

        If form.InvokeRequired Then
            form.BeginInvoke(action)
        Else
            action()
        End If
    End Sub

End Module
