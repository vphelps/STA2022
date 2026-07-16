Imports Microsoft.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Threading.Tasks

Public Module DatabaseCoordinator

    Private _evaluationInProgress As Boolean = False
    Private _lastKnownOnline As Boolean? = Nothing
    Private _lastKnownSource As String = Nothing
    Public Enum DatabaseEnvironment

        Offline = 0
        Docker = 1
        LocalServer = 2
        RemoteServer = 3

    End Enum
    Public Function TestConnection(connectionString As String, Optional timeoutSeconds As Integer = 3) As Boolean

        If Not IsValidConnectionString(connectionString) Then

            Return False
        End If

        Try
            Dim builder As New SqlConnectionStringBuilder(connectionString)
            builder.ConnectTimeout = Math.Max(1, timeoutSeconds)

            Using cn As New SqlConnection(builder.ConnectionString)
                cn.Open()
                Return True
            End Using

        Catch ex As SqlException
            ' ✅ expected (server down, unreachable)

        Catch ex As ArgumentException
            ' ✅ bad connection string


        Catch ex As Exception

        End Try

        Return False

    End Function
    ' ============================================================
    ' CLEAN DATABASE DETECTION
    ' ============================================================
    Public Sub EvaluateDatabaseAvailability(
    form As FormMain,
    connectionString As String,
    Optional configuredContainerName As String = Nothing
)


        Dim builder As SqlConnectionStringBuilder

        Try
            ' ✅ Parse ONCE (validation + builder creation in one step)
            builder = New SqlConnectionStringBuilder(connectionString)

        Catch
            If _lastKnownOnline <> False Then
                GoOffline(form, "Invalid connection string")
                _lastKnownOnline = False
            End If

            Return
        End Try

        Try
            ' ✅ Set timeout AFTER successful parse
            builder.ConnectTimeout = 3


            Using cn As New SqlConnection(builder.ConnectionString)

                cn.Open()

                ' ✅ Step 2: Determine environment (REUSE SAME CONNECTION)
                'Dim isDocker As Boolean = IsConnectedToDockerContainer(cn)

                'Dim source As String = If(isDocker, "Docker", "Local SQL")
                Dim env = DetermineDatabaseEnvironment(cn)

                Dim source As String

                Select Case env

                    Case DatabaseEnvironment.Docker
                        source = "Docker"

                    Case DatabaseEnvironment.LocalServer
                        source = "SQL Server (Local)"

                    Case DatabaseEnvironment.RemoteServer
                        source = "SQL Server (Remote)"

                    Case Else
                        source = "Unknown"

                End Select                ' ✅ Only update UI if ONLINE state OR SOURCE changed
                If _lastKnownOnline <> True OrElse _lastKnownSource <> source Then
                    GoOnlineWithSource(form, source)
                    _lastKnownOnline = True
                    _lastKnownSource = source
                End If
            End Using

        Catch ex As SqlException
            ' ✅ Expected: server down / unreachable

            If _lastKnownOnline <> False Then
                GoOffline(form, "No SQL Server available")
                _lastKnownOnline = False
                _lastKnownSource = Nothing
            End If

        Catch ex As ArgumentException
            ' ✅ Bad connection string – don't retry repeatedly

            If _lastKnownOnline <> False Then
                GoOffline(form, "Invalid connection string")
                _lastKnownOnline = False
                _lastKnownSource = Nothing
            End If

        Catch ex As Exception
            ' ✅ Unexpected issues

            If _lastKnownOnline <> False Then
                GoOffline(form, "Database error")
                _lastKnownOnline = False
                _lastKnownSource = Nothing
            End If

        End Try

    End Sub

    Public Async Function EvaluateDatabaseAvailabilityAsync(
        form As FormMain,
        connectionString As String,
        Optional configuredContainerName As String = Nothing
    ) As Task

        If _evaluationInProgress Then Return
        _evaluationInProgress = True

        Try
            Await Task.Run(
                Sub()
                    EvaluateDatabaseAvailability(form, connectionString, configuredContainerName)
                End Sub)

        Finally
            _evaluationInProgress = False
        End Try

    End Function


    ' ============================================================
    ' ONLINE / OFFLINE TRANSITIONS
    ' ============================================================
    Private Sub GoOnlineWithSource(form As FormMain, source As String)

        Variables.OfflineMode = False
        PCInfo.ValidDatabase = True

        InvokeOnUI(form,
            Sub()

                EnableDatabaseSections(form)

                ' Refresh data
                CodeHelper.GetPcInfo()
                CodeHelper.FirstLoad()
                CodeHelper.Refresher()

                If form.tslblDbState IsNot Nothing Then
                    form.tslblDbState.Text = $"ONLINE ({source})"
                    form.tslblDbState.ForeColor = Color.WhiteSmoke
                    form.tslblDbState.BackColor = Color.DarkGreen
                End If

                If form.tslblExecutionStatus IsNot Nothing Then
                    form.tslblExecutionStatus.Text = ""
                    form.tslblExecutionStatus.Visible = False
                End If

            End Sub)

    End Sub


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


    ' ============================================================
    ' UI HELPERS
    ' ============================================================
    Public Sub EnableDatabaseSections(form As FormMain)

        form.tpAdvData.Enabled = True
        form.tpDbLogs.Enabled = True
        form.pnlDbData.Enabled = True
        form.pnlDbInfoButtons.Enabled = True

        form.tbPcDbInfo.Text = ""

    End Sub


    Public Sub DisableDatabaseSections(form As FormMain)

        form.tbPcDbInfo.Text = "Offline"
        form.dgvAppOptions.DataSource = Nothing

        form.tpAdvData.Enabled = False
        form.tpDbLogs.Enabled = False
        form.pnlDbData.Enabled = False
        form.pnlDbInfoButtons.Enabled = False

    End Sub


    ' ============================================================
    ' DATA REFRESH
    ' ============================================================
    Public Sub RefreshAdvantageData(form As FormMain)

        Try
            LoadAppOptions(form)
            LoadWebOptions(form)
            LoadApplicationInfo(form)

        Catch ex As SafeDb.DatabaseOfflineException
            GoOffline(form, "Lost DB connection")

        Catch ex As Exception
            GoOffline(form, "Database error: " & ex.Message)
        End Try

    End Sub


    ' ============================================================
    ' DATA LOADERS
    ' ============================================================
    Private Sub LoadAppOptions(form As FormMain)

        form.dgvAppOptions.Rows.Clear()

        Dim ds = SafeDb.TryQuery("SELECT OptionName, OptionValue FROM AppOptions")

        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Exit Sub

        For Each row As DataRow In ds.Tables(0).Rows
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

        Dim ds = SafeDb.TryQuery("SELECT OptionName, OptionValue FROM WebOptions")

        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Exit Sub

        For Each row As DataRow In ds.Tables(0).Rows
            form.dgvWebOptions.Rows.Add(row.ItemArray)
        Next

    End Sub


    Private Sub LoadApplicationInfo(form As FormMain)

        form.dgvApplicationInfo.Rows.Clear()

        Dim ds = SafeDb.TryQuery("SELECT * FROM ApplicationInfo")

        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Exit Sub

        Dim table = ds.Tables(0)
        If table.Rows.Count = 0 Then Exit Sub

        Dim firstRow = table.Rows(0)

        For i = 0 To table.Columns.Count - 1
            form.dgvApplicationInfo.Rows.Add(
                table.Columns(i).ColumnName,
                firstRow(i).ToString())
        Next

    End Sub


    ' ============================================================
    ' UI THREAD HELPER
    ' ============================================================
    Private Sub InvokeOnUI(form As FormMain, action As Action)

        If form Is Nothing OrElse form.IsDisposed Then Return

        If form.InvokeRequired Then
            form.BeginInvoke(action)
        Else
            action()
        End If

    End Sub

    Public Sub ExecuteStoredProcedure(
    connectionString As String,
    procedureName As String,
    Optional parameters As Dictionary(Of String, Object) = Nothing
)

        Try
            If Not IsValidConnectionString(connectionString) Then
                Throw New ArgumentException("Invalid connection string")
            End If

            Dim builder As New SqlConnectionStringBuilder(connectionString)

            Using cn As New SqlConnection(builder.ConnectionString)
                cn.Open()

                Using cmd As New SqlCommand(procedureName, cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    If parameters IsNot Nothing Then
                        For Each kvp In parameters
                            cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                        Next
                    End If

                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As SqlException

            ' ✅ ✅ ✅ DO NOT log expected duplicate key errors
            If ex.Number = 2627 OrElse ex.Number = 2601 Then
                Throw   ' send to UI, but DO NOT log
            End If

            ' ✅ Log all other SQL errors
            GlobalErrorHandler.HandleUnhandledException(
                Nothing,
                New UnhandledExceptionEventArgs(ex, False)
            )

            Throw

        Catch ex As Exception

            ' ✅ Log unexpected errors
            GlobalErrorHandler.HandleUnhandledException(
                Nothing,
                New UnhandledExceptionEventArgs(ex, False)
            )

            Throw

        End Try

    End Sub


    ''' <summary>
    ''' Determines if the given SQL connection is pointing to a Docker-hosted SQL Server.
    ''' Uses @@SERVERNAME and matches against running Docker container IDs.
    ''' </summary>
    Public Function IsConnectedToDockerContainer(cn As SqlConnection) As Boolean

        Try
            ' --- Step 1: Get @@SERVERNAME using EXISTING connection ---
            Dim serverName As String = ""

            Using cmd As New SqlCommand("SELECT @@SERVERNAME", cn)
                serverName = cmd.ExecuteScalar()?.ToString()?.Trim()
            End Using

            If String.IsNullOrWhiteSpace(serverName) Then Return False
            serverName = serverName.ToLowerInvariant()

            ' --- Step 2: Check Docker availability ---
            If Not IsDockerAvailable() Then
                Return False
            End If

            ' --- Step 3: Get running container IDs ---
            Dim containerIds = GetRunningContainerIds()

            If containerIds Is Nothing OrElse containerIds.Count = 0 Then
                Return False
            End If

            ' --- Step 4: Match SQL server name to container ID ---
            Return containerIds.Any(Function(id) serverName.StartsWith(id))

        Catch ex As Exception
            Return False
        End Try

    End Function

    ' ============================================================
    ' INTERNAL HELPERS (kept private to keep API clean)
    ' ============================================================

    Private Function IsDockerAvailable() As Boolean

            Try
                Dim psi As New ProcessStartInfo With {
                    .FileName = "docker",
                    .Arguments = "version --format ""{{.Server.Version}}""",
                    .RedirectStandardOutput = True,
                    .UseShellExecute = False,
                    .CreateNoWindow = True
                }

                Using proc As Process = Process.Start(psi)
                    Dim output = proc.StandardOutput.ReadToEnd()
                    proc.WaitForExit()

                    Return proc.ExitCode = 0 AndAlso Not String.IsNullOrWhiteSpace(output)
                End Using

            Catch
                Return False
            End Try

        End Function


        Private Function GetRunningContainerIds() As List(Of String)

            Try
                Dim psi As New ProcessStartInfo With {
                    .FileName = "docker",
                    .Arguments = "ps --format ""{{.ID}}""",
                    .RedirectStandardOutput = True,
                    .UseShellExecute = False,
                    .CreateNoWindow = True
                }

                Using proc As Process = Process.Start(psi)
                    Dim output As String = proc.StandardOutput.ReadToEnd()
                    proc.WaitForExit()

                    If String.IsNullOrWhiteSpace(output) Then
                        Return New List(Of String)
                    End If

                    Return output.
                        Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).
                        Select(Function(id) id.Trim().ToLower()).
                        ToList()
                End Using

            Catch ex As Exception
            Return New List(Of String)
        End Try

        End Function
    Private Function IsValidConnectionString(cs As String) As Boolean
        If String.IsNullOrWhiteSpace(cs) Then Return False

        Try
            Dim builder As New SqlConnectionStringBuilder(cs)
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Function DetermineDatabaseEnvironment(
    cn As SqlConnection
) As DatabaseEnvironment

        If IsConnectedToDockerContainer(cn) Then
            Return DatabaseEnvironment.Docker
        End If

        Dim dataSource As String =
        cn.DataSource.Split("\"c)(0).
                      Split(","c)(0).
                      Trim()

        If dataSource.Equals(
        Environment.MachineName,
        StringComparison.OrdinalIgnoreCase) Then

            Return DatabaseEnvironment.LocalServer
        End If

        Return DatabaseEnvironment.RemoteServer

    End Function
End Module
