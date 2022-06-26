Imports System.Data.SqlClient
Imports System.ServiceProcess
Imports STA2.AppData
Imports STA2.NetworkData
Imports System.Net.NetworkInformation
Imports System.Net

Public Class FormMain
    Public Shared ServiceControlList As New List(Of ServiceControlEntry)
    Public Shared LastServiceEntry As ServiceControlEntry

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click


    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connections.IniFileHandler(False)
        CodeHelper.FirstLoad()

        Dim strTemp As String = ""
        ServiceControlList = Services.ServicesExistCheck()
        CodeHelper.Refresher()
        rbDbTableSize.Checked = True
        rbMessageLog.Checked = True
        btnDbInfoRefresh.PerformClick()
        gpMessageLogFilters.Enabled = rbMessageLog.Checked
        btnDbLogRefresh.PerformClick()

        Me.Text = Me.Text & " " & My.Application.Info.Version.Major
        If PCInfo.ValidDatabase Then

            Try
                dbAppOptions = DBConnector.dbQuery("SELECT OptionName, OptionValue FROM AppOptions")
                For index = 0 To dbAppOptions.Tables(0).Rows.Count - 1
                    dgvAppOptions.Rows.Add(dbAppOptions.Tables(0).Rows(index).ItemArray)
                Next
                dbWebOptions = DBConnector.dbQuery("SELECT OptionName, OptionValue FROM WebOptions")
                For index = 0 To dbWebOptions.Tables(0).Rows.Count - 1
                    dgvWebOptions.Rows.Add(dbWebOptions.Tables(0).Rows(index).ItemArray)
                Next

                dgvAppOptions.Refresh()

            Catch ex As Exception

                ErrorHandler.ErrorHandler(ex.Message, ex.StackTrace)
                PCInfo.ValidDatabase = False

            End Try
        End If
        btnPcDrCommit.Enabled = False

#If DEBUG Then
        Variables.LoggedIn = True
        dgvPFSConnect.Visible = Variables.LoggedIn
        nudDRInvNo.Value = 11564
#Else
        tbTest1.Visible = False
        tbTest2.Visible = False
        tbTest3.Visible = False
        tbMLTest1.Visible = False
        btnTest.Visible = False
        tbMLDRTest.visible = false
#End If
    End Sub

    Private Sub btnUnlockAdminAccount_Click(sender As Object, e As EventArgs) Handles btnUnlockAdminAccount.Click
        DBConnector.CreateCommand(GeneralQueries.UnlockAdminAccount)

    End Sub

    Private Sub tbLocName_GotFocus(sender As Object, e As EventArgs) Handles tbLocName.GotFocus, tbLicSvr.GotFocus, tbCoreSvr.GotFocus, tbDbVer.GotFocus, tbWebEnabled.GotFocus, tbShiftDate.GotFocus
        gpLicInfo.Select()

    End Sub

    Private Sub tmr10Seconds_Tick(sender As Object, e As EventArgs) Handles tmr10Seconds.Tick
        If Not PCInfo.AdvantageVersion.Contains("Not") Then tslblCeVersion.Text = "Version:  " + PCInfo.AdvantageVersion

        'Dim list As New List(Of Boolean)

        'For index = 0 To ServiceControlList.Count - 1
        '    If ServiceControlList.Item(index).GroupBox.Enabled Then
        '        'ServiceControlList.Item(index).TextBox.Text = Services.GetServiceStatus(ServiceControlList.Item(index))
        '        list.Add(Services.GetServiceStatus(ServiceControlList.Item(index)))

        '    End If
        'Next
        'If list.Contains(True) Then tmr1Sec.Enabled = True Else tmr1Sec.Enabled = False
        CodeHelper.Refresher()
        If Not PCInfo.ValidDatabase Then
            tpAdvData.Enabled = False
            tpDbInfo.Enabled = False
            tpGeneral.Enabled = False
            tpDbLogs.Enabled = False
        End If
    End Sub

    Private Sub tmr1Sec_Tick(sender As Object, e As EventArgs) Handles tmr1Sec.Tick
        PCInfo.AreServicesInstalled = False
        Try

            If PCInfo.AreServicesInstalled Then
                If IsNothing(LastServiceEntry) Then Exit Sub

                tmr1Sec.Enabled = Services.GetServiceStatus(LastServiceEntry)

                If LastServiceEntry.RSButton.Tag.ToString.Length > 0 Then
                    Services.RestartService(LastServiceEntry)
                Else
                    LastServiceEntry.RSButton.Tag = ""

                End If
            Else

            End If
        Catch ex As Exception



        End Try


    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        FormLogin.ShowDialog()
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

        DateFrom = "And MsgDateTime >= '" & dtpMsgLogDateFrom.Value.ToString("yyyy-MM-dd") & " " & dtpMsgLogTimeFrom.Value.ToString("hh:mm:ss") & "'"
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

    Private Sub btnCoreServiceSS_Click(sender As Object, e As EventArgs) Handles btnCoreServiceSS.Click, btnCloudServiceSS.Click, btnApiServiceSS.Click, btnAdvCreditServiceSS.Click, btnAdvTurnstileEngineSS.Click, btnAdvSignageServiceSS.Click, btnAdvNotifyServiceSS.Click, btnAdvLicServiceSS.Click, btnAdvantageUpgradeServiceSS.Click

        Dim caller As Button = DirectCast(sender, Button)
        Dim temp As Integer

        caller.Enabled = False
        tmr1Sec.Enabled = True
        For index = 0 To ServiceControlList.Count - 1
            If ServiceControlList.Item(index).SSButton.Equals(caller) Then

                temp = index
            End If
        Next

        LastServiceEntry = ServiceControlList.Item(temp)
        tbTest2.Text = LastServiceEntry.Service
        Dim controller As New ServiceController(LastServiceEntry.Service)
        Dim serviceControllerStatus = controller.Status

        If LastServiceEntry.TextBox.Text = "Running" Then
            Services.StopService(LastServiceEntry)
        ElseIf LastServiceEntry.TextBox.Text = "Stopped" Then
            Services.StartService(LastServiceEntry)
        End If




    End Sub

    Private Sub btnApiServiceRS_Click(sender As Object, e As EventArgs) Handles btnApiServiceRS.Click, btnCoreServiceRS.Click, btnCloudServiceRS.Click, btnAdvTurnstileEngineRS.Click, btnAdvSignageServiceRS.Click, btnAdvNotifyServiceRS.Click, btnAdvLicServiceRS.Click, btnAdvCreditServiceRS.Click, btnAdvantageUpgradeServiceRS.Click
        Dim temp As Integer
        Dim caller As Button = DirectCast(sender, Button)
        tmr1Sec.Enabled = True
        caller.Enabled = False

        For index = 0 To ServiceControlList.Count - 1
            If ServiceControlList.Item(index).RSButton.Equals(caller) Then
                temp = index
            End If
        Next
        LastServiceEntry = ServiceControlList.Item(temp)
        LastServiceEntry.RSButton.Tag = "restart"
        Services.RestartService(LastServiceEntry)

        tmr1Sec.Enabled = Not caller.Enabled

    End Sub

    Private Sub tbCoreService_GotFocus(sender As Object, e As EventArgs) Handles tbCoreService.GotFocus, tbCoreService.GotFocus, tbCloudService.GotFocus, tbAdvCreditService.GotFocus, tbAdvSignageService.GotFocus, tbAdvLicService.GotFocus, tbAdvNotifyService.GotFocus, tbAdvTurnstileEngine.GotFocus, tbAdvantageUpgradeService.GotFocus

        Dim caller As TextBox = DirectCast(sender, TextBox)
        caller.SelectionStart = 0
        caller.SelectionLength = 0
    End Sub

    Private Sub btnDRInvNo_Click(sender As Object, e As EventArgs) Handles btnDRInvNo.Click
        Dim dsResult As DataSet
        Dim Today As String = Now.ToShortDateString


        Dim query As String = String.Format(DeferredRevenueQueries.InventoryItem, nudDRInvNo.Value)
        dsResult = DBConnector.dbQuery(query)
        If dsResult.Tables(0).Rows.Count = 0 Then
            MsgBox(String.Format("Invalid Inventory Item Number:  {0}", nudDRInvNo.Value), MsgBoxStyle.Exclamation, "DATA WARNING")
            btnPcDrCommit.Enabled = False
            Exit Sub
        End If
        InventoryItem.InvNo = dsResult.Tables(0).Rows(0).Item(0)
        InventoryItem.MasterInvNo = dsResult.Tables(0).Rows(0).Item(1)
        InventoryItem.InvName = dsResult.Tables(0).Rows(0).Item(2)
        InventoryItem.CatNo = dsResult.Tables(0).Rows(0).Item(3)
        InventoryItem.SubCatNo = dsResult.Tables(0).Rows(0).Item(4)
        InventoryItem.CatName = dsResult.Tables(0).Rows(0).Item(5)
        InventoryItem.SubCatName = dsResult.Tables(0).Rows(0).Item(6)
        dgvInvItem.Rows.Clear()

        dgvInvItem.Rows.Add("InvNo", InventoryItem.InvNo)
        dgvInvItem.Rows.Add("MasterInvNo", InventoryItem.MasterInvNo)
        dgvInvItem.Rows.Add("Description", InventoryItem.InvName)
        dgvInvItem.Rows.Add("CatNo", InventoryItem.CatNo)
        dgvInvItem.Rows.Add("Category", InventoryItem.CatName)
        dgvInvItem.Rows.Add("SubCatNo", InventoryItem.SubCatNo)
        dgvInvItem.Rows.Add("SubCategory", InventoryItem.SubCatName)



        DeferredRevenue.pcDeferred = FormatNumber(DBConnector.dbQuery(DeferredRevenueQueries.pcDRValues), 2)
        tbOutstandingPCDR.Text = String.Format("${0}", DeferredRevenue.pcDeferred.ToString)
        Try
            Dim rowCount As Integer = DBConnector.getValue(String.Format(DeferredRevenueQueries.SalesCount, Today, InventoryItem.InvNo))

            If rowCount = 0 Then
                tbMLDRTest.Text = "Ready to Commit"
                btnPcDrCommit.Enabled = True
            Else
                MsgBox(String.Format("There is already data in the Sales table for {0}", InventoryItem.InvName), MsgBoxStyle.Exclamation, "DATA WARNING")
                btnPcDrCommit.Enabled = False
                Exit Try

            End If

        Catch ex As Exception
            ErrorHandler.ErrorHandler(ex.Message, ex.StackTrace)
        End Try

    End Sub

    Private Sub btnPcDrCommit_Click(sender As Object, e As EventArgs) Handles btnPcDrCommit.Click
        Dim Today As String = Now.ToShortDateString
        Dim result As Integer = 0
        tbMLDRTest.Text = ""
        tbMLDRTest.AppendText("-- UPDATE Command to turn off Deferred Revenue for Player Cards" & vbCrLf)
        tbMLDRTest.AppendText(DeferredRevenueQueries.pcDRswitch & vbCrLf & vbCrLf)
        tbMLDRTest.AppendText("-- UPDATE Command to add Deferred Revenue Value to SubCatSales table" & vbCrLf)
        tbMLDRTest.AppendText(String.Format(DeferredRevenueQueries.SubCatSalesUpdate, DeferredRevenue.pcDeferred, Today, InventoryItem.CatNo, InventoryItem.SubCatNo) & vbCrLf & vbCrLf)
        tbMLDRTest.AppendText("-- INSERT Command to add Deferred Revenue Value to Sales table" & vbCrLf)
        tbMLDRTest.AppendText(String.Format(DeferredRevenueQueries.SaleInsert, Today, InventoryItem.InvNo, DeferredRevenue.pcDeferred, InventoryItem.CatNo, InventoryItem.SubCatNo) & vbCrLf & vbCrLf)
        tbMLDRTest.AppendText("-- UPDATE Command to clear deferred revenue amount from Player Cards" & vbCrLf)
        tbMLDRTest.AppendText(DeferredRevenueQueries.pcCardValues & vbCrLf & vbCrLf)
        tbMLDRTest.AppendText("-- INSERT Command to offset for deferred revenue posting to sales" & vbCrLf)
        tbMLDRTest.AppendText(String.Format(DeferredRevenueQueries.DRUpdate, Today, DeferredRevenue.pcDeferred) & vbCrLf & vbCrLf)

#If DEBUG Then
        MsgBox("Running in Debug Mode, Database not changed", MsgBoxStyle.Information, "DEBUG Mode")

#Else
                result = DBConnector.CreateCommand(DeferredRevenueQueries.pcDRswitch)
        result = DBConnector.CreateCommand((String.Format(DeferredRevenueQueries.SubCatSalesUpdate, DeferredRevenue.pcDeferred, Today, InventoryItem.CatNo, InventoryItem.SubCatNo)))
        result = DBConnector.CreateCommand((String.Format(DeferredRevenueQueries.SaleInsert, Today, InventoryItem.InvNo, DeferredRevenue.pcDeferred, InventoryItem.CatNo, InventoryItem.SubCatNo)))
        result = DBConnector.CreateCommand(DeferredRevenueQueries.pcCardValues)
        result = DBConnector.CreateCommand(String.Format(DeferredRevenueQueries.DRUpdate, Today, DeferredRevenue.pcDeferred))

#End If

        btnPcDrCommit.Enabled = False


    End Sub

    Private Sub tcSTA_Click(sender As Object, e As EventArgs) Handles tcSTA.Click
        btnDbLogRefresh.PerformClick()
        btnDbInfoRefresh.PerformClick()
        btnRelayRefresh.PerformClick()

    End Sub

    Private Sub btnAdvManager_Click(sender As Object, e As EventArgs) Handles btnAdvManager.Click, btnPos.Click, btnAdvGroups.Click
        Dim caller As Button = DirectCast(sender, Button)

        Select Case caller.Name
            Case "btnAdvManager"
                Diagnostics.Process.Start(AppData.CEPath & "AdvManager.exe")
            Case "btnPos"
                Diagnostics.Process.Start(AppData.CEPath & "pos.exe")
            Case "btnAdvGroups"
                Diagnostics.Process.Start(AppData.CEPath & "AdvGroups.exe")
            Case Else

        End Select
    End Sub

    Private Sub btnPortCheck_Click(sender As Object, e As EventArgs) Handles btnPortCheck.Click
        Dim host As String = My.Settings.Server
        Dim tmpBoolean As Boolean
        NetworkDataHelper.NetworkPortListGenerate()

        Dim rows As Integer = dgvPorts.Rows.Count - 1
        For row As Integer = 0 To rows
            tmpBoolean = TCPCheck(host, dgvPorts.Rows(row).Cells(0).Value)
            tbPortScan.Text = String.Format("Scanning Port {0} | {1}", dgvPorts.Rows(row).Cells(0).Value, dgvPorts.Rows(row).Cells(1).Value)

            If tmpBoolean Then
                dgvPorts.Rows(row).Cells(2).Value = "Ready"
            Else
                dgvPorts.Rows(row).Cells(2).Value = "Error"
            End If
        Next

    End Sub

    Private Sub btnRelayRefresh_Click(sender As Object, e As EventArgs) Handles btnRelayRefresh.Click
        Dim tmpBoolean As Boolean = TCPCheck("relay-us-east-1.centeredgeonline.com", 50511)

        If tmpBoolean Then
            tbStageRelayConn.Text = "Ready"
            tbStageRelayConn.BackColor = TextboxColors.Green
        Else
            tbStageRelayConn.Text = "Error"
            tbStageRelayConn.BackColor = TextboxColors.Red
        End If

    End Sub
End Class