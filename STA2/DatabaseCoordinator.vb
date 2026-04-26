Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Module DatabaseCoordinator

    ' ============================================================
    ' Connectivity
    ' ============================================================
    Public Function TestConnection(connectionString As String) As Boolean
        Try
            Using cn As New SqlConnection(connectionString)
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

        DisableDatabaseSections(form)

        ' Status indicator
        If form.tslblDbState IsNot Nothing Then
            form.tslblDbState.Text = "OFFLINE"
            form.tslblDbState.ForeColor = Color.White
            form.tslblDbState.BackColor = Color.Firebrick
        End If

    End Sub


    Public Sub GoOnline(form As FormMain)

        Variables.OfflineMode = False
        PCInfo.ValidDatabase = True

        EnableDatabaseSections(form)

        ' Refresh application state
        CodeHelper.GetPcInfo()
        CodeHelper.FirstLoad()
        CodeHelper.Refresher()

        ' Status indicator
        If form.tslblDbState IsNot Nothing Then
            form.tslblDbState.Text = "ONLINE"
            form.tslblDbState.ForeColor = Color.WhiteSmoke
            form.tslblDbState.BackColor = Color.DarkGreen
        End If

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


    Public Sub RefreshAdvantageData(form As FormMain, firedBy As String)

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

End Module
