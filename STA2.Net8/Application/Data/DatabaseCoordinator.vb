Imports Microsoft.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Threading.Tasks

Public Module DatabaseCoordinator

    Private _evaluationInProgress As Boolean = False

    ' ============================================================
    ' SIMPLE CONNECTION TEST
    ' ============================================================
    Public Function TestConnection(connectionString As String, Optional timeoutSeconds As Integer = 3) As Boolean
        Try
            Using cn As New SqlConnection(connectionString)
                cn.Open()
                Return True
            End Using
        Catch ex As Exception
            Debug.WriteLine("DB connection failed: " & ex.Message)
            Return False
        End Try
    End Function


    ' ============================================================
    ' CLEAN DATABASE DETECTION
    ' ============================================================
    Public Sub EvaluateDatabaseAvailability(
        form As FormMain,
        connectionString As String,
        Optional configuredContainerName As String = Nothing
    )

        Debug.WriteLine("=== DATABASE DETECTION START ===")

        ' ✅ Try Docker (port 1433)
        If TestConnection(ConfigValues.DockerConnectionString(), 3) Then
            Debug.WriteLine("✅ Docker DB detected")
            GoOnlineWithSource(form, "Docker")
            Return
        End If

        ' ✅ Try Local SQL
        If TestConnection(ConfigValues.LocalSqlConnectionString(), 3) Then
            Debug.WriteLine("✅ Local SQL detected")
            GoOnlineWithSource(form, "Local SQL")
            Return
        End If

        ' ❌ Offline
        Debug.WriteLine("❌ No database available")
        GoOffline(form, "No SQL Server available")

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

        form.tbPcDbSize.Text = ""
        form.tbPcDbInfo.Text = ""

    End Sub


    Public Sub DisableDatabaseSections(form As FormMain)

        form.tbPcDbSize.Text = "Offline"
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

    '    Public Sub ExecuteStoredProcedure(
    '    connectionString As String,
    '    procedureName As String,
    '    Optional parameters As Dictionary(Of String, Object) = Nothing
    ')

    '        Try
    '            Using cn As New SqlConnection(connectionString)
    '                cn.Open()

    '                Using cmd As New SqlCommand(procedureName, cn)
    '                    cmd.CommandType = CommandType.StoredProcedure

    '                    ' ✅ Add parameters if provided
    '                    If parameters IsNot Nothing Then
    '                        For Each kvp In parameters
    '                            cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
    '                        Next
    '                    End If

    '                    cmd.ExecuteNonQuery()
    '                End Using
    '            End Using

    '        Catch ex As Exception
    '            ' ✅ Log it using your existing global handler
    '            GlobalErrorHandler.HandleUnhandledException(
    '            Nothing,
    '            New UnhandledExceptionEventArgs(ex, False)
    '        )

    '            Throw ' rethrow so UI can react if needed
    '        End Try

    '    End Sub
    Public Sub ExecuteStoredProcedure(
    connectionString As String,
    procedureName As String,
    Optional parameters As Dictionary(Of String, Object) = Nothing
)

        Try
            Using cn As New SqlConnection(connectionString)
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
End Module