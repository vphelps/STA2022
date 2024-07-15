Imports System.Data.SqlClient
Imports System.Net
Imports System.Xml
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.ServiceProcess
Imports STA2.AppData
Imports STA2.NetworkData
Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports System.Web
Imports System.Net.Sockets
Imports System.Security.Policy
Imports System.CodeDom
Imports System.Net.Mime.MediaTypeNames
Imports System.Runtime.CompilerServices

Public Class FormMain
    Const xmlFileNamePattern As String = "\eodbtempxml-({0})-{1}.xml"

    Public Shared ServiceControlList As New List(Of ServiceControlEntry)
    Public Shared LastServiceEntry As ServiceControlEntry

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click

        If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            flpServices.Enabled = True
            MsgBox("Admin")
        Else
            flpServices.Enabled = False
            MsgBox("Standard")
        End If

        Exit Sub

        Dim hostname = NetworkDataHelper.GetLocalIP
        Dim portno = 15050
        Dim ipa = Dns.GetHostAddresses(hostname)(0)
        MessageBox.Show(hostname & " " & ipa.ToString)
        Try
            ' Get active TCP connections - the GetActiveTcpListeners is also useful if you're starting up a server...
            Dim active = IPGlobalProperties.GetIPGlobalProperties.GetActiveTcpConnections
            If (From connection In active Where connection.LocalEndPoint.Address.Equals(ipa) AndAlso connection.LocalEndPoint.Port = portno).Any Then
                ' Port is being used by an active connection
                MessageBox.Show("Port is in use!")

            Else
                ' Proceed with connection
                Using sock As New Sockets.Socket(Sockets.AddressFamily.InterNetwork, Sockets.SocketType.Stream, Sockets.ProtocolType.Tcp)
                    sock.Connect(ipa, portno)
                    ' Do something more interesting with the socket here...
                End Using
            End If

        Catch ex As Sockets.SocketException
            MessageBox.Show(ex.Message)
        End Try
        NetworkDataHelper.GetIPv4Address()

    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not (My.Application.CommandLineArgs.Contains("-engineer")) Then
            tcSTA.TabPages.Remove(tpDatapump)
        End If

        Connections.IniFileHandler(False)
        If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then FormLogin.ShowDialog()
        CodeHelper.AdminUser(Variables.LoggedIn)
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
                dbApplicationInfo = DBConnector.dbQuery("SELECT * FROM ApplicationInfo")
                For index = 0 To dbApplicationInfo.Tables(0).Columns.Count - 1
                    dgvApplicationInfo.Rows.Add(dbApplicationInfo.Tables(0).Columns(index).ColumnName, dbApplicationInfo.Tables(0).Rows(0).ItemArray(index).ToString)
                Next
                dgvAppOptions.Refresh()

            Catch ex As Exception

                ErrorHandler.ErrorHandler(ex.Message, ex.StackTrace)
                PCInfo.ValidDatabase = False

            End Try
        End If
        btnPcDrCommit.Enabled = False

        EODBTroubleshooting.filePath = "C:\CenterEdge"
        fbdEODB.SelectedPath = EODBTroubleshooting.filePath

        tbEODBFolder.Text = EODBTroubleshooting.filePath
        dtpEODB.Value = Now

        Try
            Dim regKey = My.Computer.Registry.ClassesRoot.OpenSubKey("Excel.Application", False).OpenSubKey("CurVer", False)
            PCInfo.ExcelInstalled = True



        Catch ex As Exception
            PCInfo.ExcelInstalled = False
        End Try
        btnEODBSave.Enabled = PCInfo.ExcelInstalled
        btnSaveToXml.Enabled = Not (PCInfo.ExcelInstalled)
        btnXmltoWorkbook.Enabled = PCInfo.ExcelInstalled
        If PCInfo.ExcelInstalled Then
            gbEODBExcel.Text = "Excel is installed"
        Else
            gbEODBExcel.Text = "Excel is not installed"
        End If

#If DEBUG Then

#Else
        Variables.LoggedIn = False
        tbTest1.Visible = False
        tbTest2.Visible = False
        tbTest3.Visible = False
        tbMLTest1.Visible = False
        btnTest.Visible = False
        tbMLDRTest.visible = False

#End If

        tcSTA.TabPages.Remove(tpEODB)
        tcSTA.TabPages.Remove(tpPlayerCardDeferredRevenue)

        btnAdvUpgrade.Visible = My.Computer.FileSystem.FileExists("C:\Program Files (x86)\CenterEdge Software\AdvCoreService.exe")
        btnAdvRedeem.Enabled = CodeHelper.AdvExeCheck("AdvRedeem")
        btnAdvCardTech.Enabled = CodeHelper.AdvExeCheck("AdvCardTech")
        btnAdvReportEditor.Enabled = CodeHelper.AdvExeCheck("AdvReportEditor")
        btnAdvManager.Enabled = CodeHelper.AdvExeCheck("AdvManager")
        btnPos.Enabled = CodeHelper.AdvExeCheck("Pos")
        btnAdvGroups.Enabled = CodeHelper.AdvExeCheck("AdvGroups")

    End Sub

    Private Sub btnUnlockAdminAccount_Click(sender As Object, e As EventArgs)
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


        Try
            DeferredRevenue.pcDeferred = FormatNumber(DBConnector.dbQuery(DeferredRevenueQueries.pcDRValues), 2)

        Catch ex As Exception
            MsgBox("Error reading from PlayerCardExpValues table" & vbCrLf & "Examine data in SQL Management Studio", MsgBoxStyle.Critical, "DATA WARNING")

        End Try
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

    Private Sub btnAdvManager_Click(sender As Object, e As EventArgs) Handles btnAdvManager.Click, btnPos.Click, btnAdvGroups.Click, btnAdvReportEditor.Click, btnAdvRedeem.Click, btnAdvCardTech.Click

        Dim caller As System.Windows.Forms.Button = DirectCast(sender, System.Windows.Forms.Button)

        Dim Executable As String = caller.Name.Replace("btn", "")
        Executable = String.Format("{0}{1}.exe", AppData.CEPath, Executable)


        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(Executable)
        Diagnostics.Process.Start(Executable)

    End Sub

    Private Async Sub btnPortCheck_Click(sender As Object, e As EventArgs) Handles btnPortCheck.Click
        Dim host As String = My.Settings.Server
        NetworkDataHelper.NetworkPortListGenerate()
        For Each row As DataGridViewRow In dgvPorts.Rows
            Dim value As Integer = row.Cells("PortNo").Value

            'tmpBoolean = TCPCheck(host, row.Cells(0).Value)
            Dim result As Boolean = Await ConnectAsync("L-CE1456", value)

            If result Then
                row.Cells(2).Value = "Port Open"
            Else
                row.Cells(2).Value = "Error"
            End If

            ' Access cell value by column name
            ' Do something with the value

        Next
    End Sub

    Private Async Sub btnRelayRefresh_Click(sender As Object, e As EventArgs) Handles btnRelayRefresh.Click
        tbStageRelayConn.Text = "Testing Stage Relay Connection..."
        tbStageRelayConn.BackColor = TextboxColors.White
        Dim result As Boolean = Await ConnectAsync("relay-us-east-1.centeredgeonline.com", 50511)

        If result Then
            tbStageRelayConn.Text = "Connection Good"
            tbStageRelayConn.BackColor = TextboxColors.Green
        Else
            tbStageRelayConn.Text = "Error"
            tbStageRelayConn.BackColor = TextboxColors.Red
        End If

    End Sub

    Private Sub btnAdvUpgrade_Click(sender As Object, e As EventArgs) Handles btnAdvUpgrade.Click

        Dim Path As String = "C:\Program Files (x86)\CenterEdge Software\AdvCoreService.exe"
        Dim temp As String = ""
        temp = DBConnector.getValue("SELECT OptionValue FROM AppOptions WHERE OptionName = 'UpgradePath'").ToString

        temp += "\Version " + FileVersionInfo.GetVersionInfo(Path).FileVersion.ToString
        temp += "\AdvUpgrade.exe "
        Dim startinfo As ProcessStartInfo = New ProcessStartInfo(temp)
        startinfo.Arguments = ""
        startinfo.FileName = temp
        temp = ""

        If cbAdvUpgradeNoBackup.Checked Then temp += AdvUpgradeConstants.NoBackup
        If cbAdvUpgradeQuiet.Checked Then temp += AdvUpgradeConstants.Quiet
        If cbAdvUpgradeNoSetup.Checked Then temp += AdvUpgradeConstants.NoSetup
        startinfo.Arguments = temp

        Process.Start(startinfo)

    End Sub

    Private Sub btnEODBFolder_Click(sender As Object, e As EventArgs) Handles btnEODBFolder.Click
        If My.Computer.FileSystem.DirectoryExists(EODBTroubleshooting.filePath) Then fbdEODB.SelectedPath = EODBTroubleshooting.filePath
        fbdEODB.ShowDialog()

        tbEODBFolder.Text = fbdEODB.SelectedPath
        EODBTroubleshooting.filePath = fbdEODB.SelectedPath
    End Sub

    Private Sub dtpEODB_ValueChanged(sender As Object, e As EventArgs) Handles dtpEODB.ValueChanged
        Dim strTemp As Date = dtpEODB.Value.Date
        EODBTroubleshooting.normDate = strTemp.ToString("MM-dd-yyyy")
        EODBTroubleshooting.sqlDate = strTemp.ToString("yyyy-MM-dd")


    End Sub

    Private Sub btnEODBSave_Click(sender As Object, e As EventArgs) Handles btnEODBSave.Click
        Dim dbResult As DataSet
        Dim strTemp As String
        Try

            EODBTroubleshooting.filePath = fbdEODB.SelectedPath
            Dim dateTemp As Date = dtpEODB.Value.Date
            EODBTroubleshooting.normDate = dateTemp.ToString("MM-dd-yyyy")
            EODBTroubleshooting.sqlDate = dateTemp.ToString("yyyy-MM-dd")

            strTemp = EODBTroubleshooting.filePath + "\EODBTroubleshooting " + EODBTroubleshooting.normDate + ".xlsx"
            EODBTroubleshooting.filePath = strTemp
            Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application()
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlActiveSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlActiveSheet = xlWorkBook.ActiveSheet
            xlActiveSheet.Name = "blank"

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.EODBCurrency, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Note: Generally not worried about Coupon, Discounts, or Player Card")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Verify the currency on the eod balance (remember to add/subtract over/short amounts)")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))


            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.RecLinesByItem, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Sum reclines by item")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Looking for amounts that might match the imbalance.")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.LineItemsByDate, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look at line items sold for target date")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Looking for detail for Sum reclines by item query.")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.SalesAllocationsNonSales, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look for sales allocations and non-sales")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Looking for amounts that might match the imbalance. Also, should match the total for Sum reclines by item query.")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.PlayerCardDiscounts, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look at player cards that were discounted")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Should match Player Card Discounts Used total.")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.PlayerCardsAddUse, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look at the player cards added/used")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Should match Player Card Value Added and Player Card Value Used.")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.Sales, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look at sales")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Total of sales which should match the Sales Total ")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.TotalCategorySubCategory, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Total by Category and Subcategory")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "which should match the sales for Cat and Subcat")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.TotalSalesTax, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, " ")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Total Sales Tax")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.TotalDeposits, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, " ")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Total Deposits Received and Redeemed")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.DepositsReceived, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, " ")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look at deposit received")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.DepositsRedeemed, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, " ")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look at deposit redeemed")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.RefundReceipts, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Looking to see if totals match imbalance.")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look for a receipt return")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.ReceiptsRefunded, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Looking to see if totals match imbalance.")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look for a receipt return")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.RecLinesRefunded, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Looking to see if totals match imbalance.")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look for a receipt return")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.ReturnedItems, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, " ")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look for returned items")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.ReturnedInventory, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, " ")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Info on items FROM returned RecLines")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.TaxablePlayerCards, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Shows Player Card inventory items that get tax applied at sale")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look for taxable player cards")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            dbResult = DBConnector.dbQuery(String.Format(EODBQueries.PackagesEmpty, EODBTroubleshooting.sqlDate))
            xlActiveSheet = EODBTroubleshooting.CreateSheet(dbResult, xlWorkBook)
            EODBTroubleshooting.SheetFormatting(xlActiveSheet)
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "These package items do not have any inventory items assigned to them")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, "Look for package items that are not referencing a inventory item")
            EODBTroubleshooting.InsertHeader(xlActiveSheet, String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))

            xlActiveSheet = xlWorkBook.Worksheets("blank")
            xlActiveSheet.Delete()

            xlWorkBook.SaveAs(EODBTroubleshooting.filePath) ', Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
            xlWorkBook.Close(True, misValue, misValue)
            xlApp.Quit()

            EODBTroubleshooting.releaseObject(xlActiveSheet)

            EODBTroubleshooting.releaseObject(xlWorkBook)

            EODBTroubleshooting.releaseObject(xlApp)
        Catch ex As System.Runtime.InteropServices.COMException
            MsgBox("Error communicating to Excel")
        End Try

    End Sub

    Private Sub btnSaveToXml_Click(sender As Object, e As EventArgs) Handles btnSaveToXml.Click
        Dim dbResult As DataSet
        Dim dateTemp As Date = dtpEODB.Value.Date

        EODBTroubleshooting.normDate = dateTemp.ToString("MM-dd-yyyy")
        EODBTroubleshooting.sqlDate = dateTemp.ToString("yyyy-MM-dd")
        EODBTroubleshooting.filePath = fbdEODB.SelectedPath & xmlFileNamePattern

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.EODBCurrency, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Verify the currency on the eod balance (remember to add/subtract over/short amounts)")
        dbResult.Tables(0).Rows.Add("Note: Generally not worried about Coupon, Discounts, or Player Card")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "01"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.RecLinesByItem, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Sum reclines by item")
        dbResult.Tables(0).Rows.Add("Looking for amounts that might match the imbalance.")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "02"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.LineItemsByDate, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look at line items sold for target date")
        dbResult.Tables(0).Rows.Add("Looking for detail for Sum reclines by item query.")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "03"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.SalesAllocationsNonSales, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look for sales allocations and non-sales")
        dbResult.Tables(0).Rows.Add("Looking for amounts that might match the imbalance. Also, should match the total for Sum reclines by item query.")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "04"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.PlayerCardDiscounts, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look at player cards that were discounted")
        dbResult.Tables(0).Rows.Add("Should match Player Card Discounts Used total.")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "05"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.PlayerCardsAddUse, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look at the player cards added/used")
        dbResult.Tables(0).Rows.Add("Should match Player Card Value Added and Player Card Value Used.")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "06"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.Sales, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look at sales")
        dbResult.Tables(0).Rows.Add("Total of sales which should match the Sales Total ")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "07"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.TotalCategorySubCategory, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Total by Category and Subcategory")
        dbResult.Tables(0).Rows.Add("which should match the sales for Cat and Subcat")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "08"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.TotalSalesTax, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Total Sales Tax")
        dbResult.Tables(0).Rows.Add(" ")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "09"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.TotalDeposits, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Total Deposits Received and Redeemed")
        dbResult.Tables(0).Rows.Add(" ")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "10"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.DepositsReceived, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look at deposit received")
        dbResult.Tables(0).Rows.Add(" ")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "11"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.DepositsRedeemed, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look at deposit redeemed")
        dbResult.Tables(0).Rows.Add(" ")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "12"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.RefundReceipts, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look for a receipt return")
        dbResult.Tables(0).Rows.Add("Looking to see if totals match imbalance.")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "13"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.ReceiptsRefunded, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look for a receipt return")
        dbResult.Tables(0).Rows.Add("Looking to see if totals match imbalance.")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "14"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.RecLinesRefunded, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look for a receipt return")
        dbResult.Tables(0).Rows.Add("Looking to see if totals match imbalance.")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "15"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.ReturnedItems, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look for returned items")
        dbResult.Tables(0).Rows.Add(" ")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "16"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.ReturnedInventory, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Info on items FROM returned RecLines")
        dbResult.Tables(0).Rows.Add(" ")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "17"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.TaxablePlayerCards, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look for taxable player cards")
        dbResult.Tables(0).Rows.Add("Shows Player Card inventory items that get tax applied at sale")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "18"), XmlWriteMode.IgnoreSchema)

        dbResult = DBConnector.dbQuery(String.Format(EODBQueries.PackagesEmpty, EODBTroubleshooting.sqlDate))
        dbResult.Tables(0).Rows.Add(String.Format("End of Day Balance Troubleshooting {0}", EODBTroubleshooting.normDate))
        dbResult.Tables(0).Rows.Add("Look for package items that are not referencing a inventory item")
        dbResult.Tables(0).Rows.Add("These package items do not have any inventory items assigned to them")
        dbResult.WriteXml(String.Format(EODBTroubleshooting.filePath, EODBTroubleshooting.sqlDate, "19"), XmlWriteMode.IgnoreSchema)

    End Sub

    Private Sub btnXmltoWorkbook_Click(sender As Object, e As EventArgs) Handles btnXmltoWorkbook.Click
        Dim dateTemp As Date
        Dim xmlFile As String = ""
        Dim xmlTemp As String = ""
        Dim idxTemp As Integer = 0
        Dim strTemp As String = ""
        Dim xlsFile As String = ""

        Dim fileSelect As New OpenFileDialog
        fileSelect.Title = "Select file with the desired date"
        fileSelect.InitialDirectory = fbdEODB.SelectedPath
        fileSelect.DefaultExt = "xml"
        fileSelect.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
        If fileSelect.ShowDialog() = DialogResult.OK Then
            xmlFile = fileSelect.FileName
        End If
        xmlTemp = xmlFile

        idxTemp = xmlTemp.IndexOf("(")
        xmlTemp = xmlTemp.Substring(idxTemp + 1)
        idxTemp = xmlTemp.IndexOf(")")
        xmlTemp = xmlTemp.Remove(idxTemp)
        MsgBox(xmlTemp & vbCrLf & xmlFile)
        dtpEODB.Value = Convert.ToDateTime(xmlTemp)
        dateTemp = dtpEODB.Value.Date
        EODBTroubleshooting.normDate = dateTemp.ToString("MM-dd-yyyy")
        EODBTroubleshooting.sqlDate = dateTemp.ToString("yyyy-MM-dd")

        EODBTroubleshooting.filePath = fbdEODB.SelectedPath

        xlsFile = EODBTroubleshooting.filePath + "\EODBTroubleshooting Test" + EODBTroubleshooting.normDate + ".xlsx"
        'strTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate)
        'MsgBox(strTemp)




        Dim dbResult As New DataSet
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlActiveSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlActiveSheet = xlWorkBook.ActiveSheet
        xlActiveSheet.Name = "blank"


        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "01")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "02")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "03")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "04")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "05")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "06")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "07")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "08")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "09")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "10")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "11")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "12")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "13")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "14")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "15")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "16")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "17")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "18")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        dbResult.Reset()
        xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "19")
        dbResult.ReadXml(xmlTemp)
        xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        'dbResult.Reset()
        'xmlTemp = String.Format(EODBTroubleshooting.filePath & xmlFileNamePattern, EODBTroubleshooting.sqlDate, "XX")
        'dbResult.ReadXml(xmlTemp)
        'xlActiveSheet = EODBTroubleshooting.CreateSheetFromXml(dbResult, xlWorkBook)

        xlActiveSheet = xlWorkBook.Worksheets("blank")
        xlActiveSheet.Delete()

        xlWorkBook.SaveAs(xlsFile) ', Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
        xlWorkBook.Close(True, misValue, misValue)
        xlApp.Quit()

        EODBTroubleshooting.releaseObject(xlActiveSheet)

        EODBTroubleshooting.releaseObject(xlWorkBook)

        EODBTroubleshooting.releaseObject(xlApp)

    End Sub

    Private Sub btDpEdit_Click(sender As Object, e As EventArgs) Handles btDpEdit.Click, dgvDatapumps.CellDoubleClick
        Dim frmDataPump As New FormDataPump

        frmDataPump.ShowDialog()
        DataPumpHelpers.LoadDataPumpInformation(dgvDatapumps)
        dgvDatapumps.ClearSelection()
    End Sub

    Private Sub tpDatapump_Enter(sender As Object, e As EventArgs) Handles tpDatapump.Enter
        DataPumpHelpers.LoadDataPumpInformation(dgvDatapumps)
    End Sub

    Private Sub dgvDatapumps_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatapumps.CellClick
        Dim time As TimeSpan
        Dim rowIndex As Integer = dgvDatapumps.CurrentCell.RowIndex

        DataPump.DataPumpId = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("DataPumpId").Index).Value
        DataPump.Description = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("Description").Index).Value
        DataPump.IsStandard = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("IsStandard").Index).Value
        DataPump.DestinationId = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("DestinationId").Index).Value
        DataPump.Query = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("Query").Index).Value
        DataPump.FileName = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("FileName").Index).Value
        'DataPump.StartTime = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("StartTime").Index).Value
        time = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("StartTime").Index).Value
        DataPump.StartTime = time.ToString
        DataPump.Interval = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("IntervalMinutes").Index).Value
        DataPump.Enabled = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("Enabled").Index).Value
        tbTest1.Text = DataPump.StartTime

    End Sub

    Private Sub btnDpNew_Click(sender As Object, e As EventArgs) Handles btnDpNew.Click
        Dim frmDataPump As New FormDataPump
        DataPump.DataPumpId = Nothing
        DataPump.Description = ""
        DataPump.IsStandard = 0
        DataPump.DestinationId = 0
        DataPump.Query = ""
        DataPump.FileName = ""
        DataPump.StartTime = "03:00"
        DataPump.Interval = 60
        DataPump.Enabled = 0
        frmDataPump.ShowDialog()
        DataPumpHelpers.LoadDataPumpInformation(dgvDatapumps)

    End Sub

    Private Sub btDpDelete_Click(sender As Object, e As EventArgs) Handles btDpDelete.Click
        Dim MsgBoxAnswer As Object
        Dim strTemp As String = DataPump.Description
        MsgBoxAnswer = MsgBox(String.Format("Warning you are about to delete this DataPump:  {0}", DataPump.Description), MsgBoxStyle.YesNo, "WARNING:  Deleteing Datapump")
        If MsgBoxAnswer = MsgBoxResult.Yes Then
            DataPumpHelpers.DeleteDataPump(DataPump.DataPumpId)
            MsgBox(String.Format("Datapump {0} has been deleted", strTemp), MsgBoxStyle.OkOnly)

        End If
        DataPumpHelpers.LoadDataPumpInformation(dgvDatapumps)
    End Sub

    Private Async Sub btnCustomPortCheck_Click(sender As Object, e As EventArgs) Handles btnCustomPortCheck.Click

        Dim host As String = My.Settings.Server
        tbCustomPortCheck.Text = String.Format("Testing Port...{0}", nudCustomPortCheck.Value)

        Dim result As Boolean = Await ConnectAsync(My.Settings.Server, nudCustomPortCheck.Value)

        If result Then
            tbCustomPortCheck.Text = String.Format("{0} Port Open", nudCustomPortCheck.Value)
        Else
            tbCustomPortCheck.Text = String.Format("Error on port {0}", nudCustomPortCheck.Value)
        End If


    End Sub

    Private Sub btnSaveApplicationInfoCSV_Click(sender As Object, e As EventArgs) Handles btnSaveApplicationInfoCSV.Click, btnSaveWebOptionsCSV.Click, btnSaveAppotionsCSV.Click
        Dim caller As Button = DirectCast(sender, Button)
        Dim dgvSource As DataGridView
        Select Case caller.Name.ToString
            Case btnSaveApplicationInfoCSV.Name.ToString
                SaveFileDialog.FileName = "ApplicationInfo.csv"
                dgvSource = dgvApplicationInfo

            Case btnSaveAppotionsCSV.Name.ToString
                SaveFileDialog.FileName = "AppOptions.csv"
                dgvSource = dgvAppOptions

            Case btnSaveWebOptionsCSV.Name.ToString
                SaveFileDialog.FileName = "WebOptions.csv"
                dgvSource = dgvWebOptions

            Case Else
                Exit Sub

        End Select

        SaveFileDialog.InitialDirectory = "C:\CenterEdge"
        SaveFileDialog.DefaultExt = "csv"
        SaveFileDialog.CheckPathExists = True
        SaveFileDialog.CreatePrompt = True
        SaveFileDialog.AddExtension = True
        SaveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
        SaveFileDialog.ShowDialog()


        Using writer As StreamWriter = New StreamWriter(SaveFileDialog.FileName)
            ' Write the header
            writer.WriteLine("OptionName,OptionValue")
            For Each row As DataGridViewRow In dgvSource.Rows

                ' Write data to the CSV file
                writer.WriteLine(row.Cells(0).Value + "," + row.Cells(1).Value)
            Next
        End Using

    End Sub

    Private Sub cbAdvUpgradeQuiet_CheckedChanged(sender As Object, e As EventArgs) Handles cbAdvUpgradeQuiet.CheckedChanged, cbAdvUpgradeNoBackup.CheckedChanged, cbAdvUpgradeNoSetup.CheckedChanged
        Dim quiet As String
        Dim nobackup As String
        Dim nosetup As String
        If cbAdvUpgradeQuiet.Checked Then
            quiet = "/q "
        Else
            quiet = ""
        End If
        If cbAdvUpgradeNoBackup.Checked Then
            nobackup = "/nobackup "
        Else
            nobackup = ""
        End If
        If cbAdvUpgradeNoSetup.Checked Then
            nosetup = "/nosetup "
        Else
            nosetup = ""
        End If
        tbAdvupgrade.Text = "AdvUpgrade.exe " + quiet + nobackup + nosetup

    End Sub

    Private Sub tbAdvupgrade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbAdvupgrade.KeyPress
        e.KeyChar = Chr(0)

    End Sub
End Class