Imports System.Data.SqlClient
Imports System.ServiceProcess
Imports STA2.AppData

Public Class MainForm
    Public Shared IndexNumber As Integer = 0
    Public Shared Rows As Integer
    Public Shared Columns As Integer
    Private LastServiceButton As Button


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connections.IniFileHandler(False)
        CodeHelper.Refresher()
        Me.Text = Me.Text & " " & My.Application.Info.Version.Major

        dbAppOptions = DBConnector.dbQuery("SELECT OptionName, OptionValue FROM AppOptions")

        dbLicData = DBConnector.dbQuery(GeneralQueries.LicenseData)
        tbLocName.Text = dbLicData.Tables.Item(0).Rows.Item(0).Item("LocName").ToString
        tbLicSvr.Text = dbLicData.Tables.Item(0).Rows.Item(0).Item("LicenseServer").ToString
        tbCoreSvr.Text = dbLicData.Tables.Item(0).Rows.Item(0).Item("CoreServiceServerName").ToString
        tbDbVer.Text = dbLicData.Tables.Item(0).Rows.Item(0).Item("Version").ToString
        tbWebEnabled.Text = dbLicData.Tables.Item(0).Rows.Item(0).Item("EnableWeb").ToString
        tbShiftDate.Text = dbLicData.Tables.Item(0).Rows.Item(0).Item("ShiftDate").ToString
        tmr10Seconds_Tick(sender, e)
        tslblNetVersion.Text = DotNetInfo.Get45PlusFromRegistry
        dtpMsgLogDateFrom.Enabled = cbMsgLogDateRange.Checked
        dtpMsgLogTimeFrom.Enabled = cbMsgLogDateRange.Checked

        dtpMsgLogDateTo.Enabled = cbMsgLogDateRange.Checked
        dtpMsgLogTimeTo.Enabled = cbMsgLogDateRange.Checked
        Dim userName = My.User.Name
        If userName <> "PFASOFT\vphelps" Then
            tbTest1.Visible = False
            tbTest2.Visible = False
            btnTest.Visible = False
        End If


    End Sub

    Private Sub btnUnlockAdminAccount_Click(sender As Object, e As EventArgs) Handles btnUnlockAdminAccount.Click
        DBConnector.CreateCommand(GeneralQueries.UnlockAdminAccount)

    End Sub

    Private Sub tbLocName_GotFocus(sender As Object, e As EventArgs) Handles tbLocName.GotFocus, tbLicSvr.GotFocus, tbCoreSvr.GotFocus, tbDbVer.GotFocus, tbWebEnabled.GotFocus, tbShiftDate.GotFocus
        gpLicInfo.Select()

    End Sub

    Private Sub tmr10Seconds_Tick(sender As Object, e As EventArgs) Handles tmr10Seconds.Tick
        tslblCeVersion.Text = "Installed Software Version:  " + CodeHelper.CeInfo
        tslblTime.Text = My.Computer.Clock.LocalTime.ToShortDateString & " " & My.Computer.Clock.LocalTime.ToShortTimeString
        btnUnlockAdminAccount.Enabled = Variables.LoggedIn
        dgvPFSConnect.Visible = Variables.LoggedIn


    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        LoginForm1.ShowDialog()
        tmr10Seconds_Tick(sender, e)

    End Sub

    Private Sub btnDbInfoRefresh_Click(sender As Object, e As EventArgs) Handles btnDbInfoRefresh.Click
        If rbDbTableSize.Checked Or rbDbFragmentation.Checked Or rbDbSizeByDay.Checked Or rbDbDeadlocks.Checked Then

            Dim dbResult As DataSet
            Dim query As String = ""
            If rbDbTableSize.Checked Then query = DbInfo.DbSizeByTable
            If rbDbFragmentation.Checked Then query = DbInfo.DbFragmentation
            If rbDbSizeByDay.Checked Then query = String.Format(DbInfo.DbSizeByDay, My.Settings.Database)
            If rbDbDeadlocks.Checked Then query = DbInfo.DbDeadlocks

            dbResult = DBConnector.dbQuery(query)
            dgvDbTableSize.DataSource = dbResult.Tables(0)
            dgvDbTableSize.Refresh()
            Rows = dbResult.Tables(0).Rows.Count
            Columns = dbResult.Tables(0).Columns.Count

        End If

    End Sub

    Private Sub rbDbTableSize_CheckedChanged(sender As Object, e As EventArgs) Handles rbDbTableSize.CheckedChanged, rbDbFragmentation.CheckedChanged, rbDbSizeByDay.CheckedChanged, rbDbDeadlocks.CheckedChanged

        btnDbInfoRefresh.PerformClick()
    End Sub

    Private Sub btnCenterEdgeConfig_Click(sender As Object, e As EventArgs) Handles btnCenterEdgeConfig.Click
        Dim Path As String = "C:\Program Files (x86)\CenterEdge Software\AdvConfig.exe"
        Process.Start(Path)
    End Sub

    Private Sub rbWebCloudUpdates_CheckedChanged(sender As Object, e As EventArgs) Handles rbWebCloudUpdates.CheckedChanged, rbMessageLog.CheckedChanged
        gpMessageLogFilters.Enabled = rbMessageLog.Checked
        btnDbLogRefresh.PerformClick()

    End Sub

    Private Sub btnDbLogRefresh_Click(sender As Object, e As EventArgs) Handles btnDbLogRefresh.Click, rbWebCloudUpdates.Click, rbMessageLog.Click
        Dim dbResultCount As DataSet
        Dim dbResultData As DataSet

        Dim queryData As String = ""
        Dim queryCount As String = ""

        If rbWebCloudUpdates.Checked Then
            gpDbLogCount.Text = "Count per table"
            gpDbLogData.Text = "All WebCloudUpdates Entries"
            queryCount = LogQueries.WebCloudTotalCount
            dbResultCount = DBConnector.dbQuery(queryCount)
            dgvDbLogCount.DataSource = dbResultCount.Tables(0)

            queryData = LogQueries.WebCloudUpdates
            dbResultData = DBConnector.dbQuery(queryData)
            dgvDbLogData.DataSource = dbResultData.Tables(0)
            dgvDbLogCount.Columns(0).Visible = False
            dgvDbLogCount.Columns(1).HeaderText = "Table"
            dgvDbLogCount.Columns(2).HeaderText = "Count"

            dbResultData = DBConnector.dbQuery(queryData)
            dgvDbLogData.DataSource = dbResultData.Tables(0)
        ElseIf rbMessageLog.Checked Then
            CodeHelper.MsgLogBuilder(MessageLogFilters.Errors, MessageLogFilters.Limit, MessageLogFilters.DateRange)

            gpDbLogCount.Text = "Errors per day"
            gpDbLogData.Text = "MessageLog"
            queryCount = LogQueries.MessageLogErrorCount
            dbResultCount = DBConnector.dbQuery(queryCount)
            dgvDbLogCount.DataSource = dbResultCount.Tables(0)
            dgvDbLogCount.Columns(0).Visible = True
            dgvDbLogCount.Columns(0).HeaderText = "Date"
            dgvDbLogCount.Columns(1).HeaderText = "Program"
            dgvDbLogCount.Columns(2).HeaderText = "Count"

            queryData = LogQueries.MessageLog
            dbResultData = DBConnector.dbQuery(queryData)

            dgvDbLogData.DataSource = dbResultData.Tables(0)
            dgvDbLogData.Sort(dgvDbLogData.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        Else
            gpDbLogData.Text = ""
            gpDbLogCount.Text = ""

            Exit Sub
        End If
        dgvDbLogData.Refresh()

    End Sub

    Private Sub btnSTParse_Click(sender As Object, e As EventArgs) Handles btnStParse.Click, btnSTClear.Click
        If sender.Equals(btnSTClear) Then
            tbSTParse.Text = ""
        ElseIf sender.Equals(btnStParse) Then
            Dim strTemp As String = tbSTParse.Text
            tbSTParse.Text = strTemp.Replace("at ", vbCrLf & " at ")
        End If

    End Sub

    Private Sub btnStPaste_Click(sender As Object, e As EventArgs) Handles btnStPaste.Click
        tbSTParse.Paste()

    End Sub

    Private Sub btnStCopy_Click(sender As Object, e As EventArgs) Handles btnStCopy.Click
        tbSTParse.Copy()
    End Sub

    Private Sub dtpMsgLogDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpMsgLogDateFrom.ValueChanged, dtpMsgLogDateTo.ValueChanged, dtpMsgLogTimeFrom.ValueChanged, dtpMsgLogTimeTo.ValueChanged
        Dim DateFrom As String
        Dim DateTo As String

        DateFrom = "AND MsgDateTime >= '" & dtpMsgLogDateFrom.Value.ToString("yyyy-MM-dd") & " " & dtpMsgLogTimeFrom.Value.ToString("hh:mm:ss") & "'"
        DateTo = "AND MsgDateTime <= '" & dtpMsgLogDateTo.Value.ToString("yyyy-MM-dd") & " " & dtpMsgLogTimeTo.Value.ToString("hh:mm:ss") & "'"
        MessageLogFilters.DateRange = DateFrom & " " & DateTo

    End Sub

    Private Sub cbMsgLogShowErrorsOnly_CheckedChanged(sender As Object, e As EventArgs) Handles cbMsgLogShowErrorsOnly.CheckedChanged
        If cbMsgLogShowErrorsOnly.Checked Then MessageLogFilters.Errors = 1 Else MessageLogFilters.Errors = 0

    End Sub

    Private Sub nudMsgLog_ValueChanged(sender As Object, e As EventArgs) Handles nudMsgLog.ValueChanged
        MessageLogFilters.Limit = nudMsgLog.Value
    End Sub

    Private Sub cbMsgLogDateFrom_CheckedChanged(sender As Object, e As EventArgs) Handles cbMsgLogDateRange.CheckedChanged
        dtpMsgLogDateFrom.Enabled = cbMsgLogDateRange.Checked
        dtpMsgLogTimeFrom.Enabled = cbMsgLogDateRange.Checked

        dtpMsgLogDateTo.Enabled = cbMsgLogDateRange.Checked
        dtpMsgLogTimeTo.Enabled = cbMsgLogDateRange.Checked


    End Sub

    Private Sub tbCoreService_TextChanged(sender As Object, e As EventArgs) Handles tbCoreService.TextChanged, tbCloudService.TextChanged, tbApiService.TextChanged
        Dim txtbox As TextBox = DirectCast(sender, TextBox)
        If txtbox.Text = "Running" Then
            tmr1Sec.Enabled = False
            LastServiceButton.Enabled = True
            LastServiceButton.Text = "Stop"
        ElseIf txtbox.Text = "Stopped" Then
            tmr1Sec.Enabled = False
            LastServiceButton.Enabled = True
            LastServiceButton.Text = "Start"
        Else
            tmr1Sec.Enabled = True
            LastServiceButton.Enabled = False

        End If


    End Sub

    Private Sub btnCoreServiceSS_Click(sender As Object, e As EventArgs) Handles btnCoreServiceSS.Click, btnCloudServiceSS.Click, btnApiServiceSS.Click

        LastServiceButton = DirectCast(sender, Button)

        Services.StopStart(LastServiceButton.Tag)
        tmr1Sec.Enabled = True
    End Sub

    Private Sub tmr1Sec_Tick(sender As Object, e As EventArgs) Handles tmr1Sec.Tick
        Dim service As ServiceController

        LastServiceButton = btnApiServiceSS
        service = Services.GetServiceStatus(tbApiService.Tag)
        tbApiService.Text = service.Status.ToString
        LastServiceButton = btnCoreServiceSS
        service = Services.GetServiceStatus(tbCoreService.Tag)
        tbCoreService.Text = service.Status.ToString
        LastServiceButton = btnCloudServiceSS
        service = Services.GetServiceStatus(tbCloudService.Tag)
        tbCloudService.Text = service.Status.ToString

    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        tbTest1.Text = scAdvCoreService.Status.ToString

    End Sub
End Class