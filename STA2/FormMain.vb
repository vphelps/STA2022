Imports System.CodeDom
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mime.MediaTypeNames
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Security.Policy
Imports System.ServiceProcess
Imports System.Web
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports System.Xml
Imports Microsoft.Office.Interop.Excel
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports STA2.AppData
Imports STA2.NetworkData

Public Class FormMain

    Private ReadOnly _options As AppOptions

    Public Sub New(options As AppOptions)
        InitializeComponent()     ' Designer-required

        _options = options

        ' Apply the window title from options.
        ' Falls back to the existing Form.Text if WindowTitle is empty.
        If Not String.IsNullOrWhiteSpace(_options.WindowTitle) Then
            Me.Text = _options.WindowTitle
        End If
    End Sub

    ' Later, if you add an Options dialog, you can update:
    ' _options.WindowTitle = txtTitle.Text
    ' OptionsManager.Save(_options)
    ' Me.Text = _options.WindowTitle

    Const xmlFileNamePattern As String = "\eodbtempxml-({0})-{1}.xml"

    Public Shared ServiceControlList As New List(Of ServiceControlEntry)
    Public Shared LastServiceEntry As ServiceControlEntry

    Private _config As LauncherConfig

    Public Enum AppInstallState
        NotInstalled = 0
        InstalledX86 = 1
        InstalledX64 = 2
    End Enum

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click


        Dim cs As String =
             String.Format("Server={0};Database={1};User ID={2};Password={3};", ConfigValues.Server, ConfigValues.Database, ConfigValues.UserID, ConfigValues.Password)
        '"Server=localhost,1433;Database=master;User ID=sa;Password=YourPassword;TrustServerCertificate=True;"
        tbMLTest1.Text = ""

        Using cn As New SqlConnection(cs),
              cmd As New SqlCommand("
                SELECT
                  SERVERPROPERTY('MachineName')       AS MachineName,
                  SERVERPROPERTY('ServerName')        AS ServerName,
                  SERVERPROPERTY('InstanceName')      AS InstanceName,
                  SERVERPROPERTY('Edition')           AS Edition,
                  SERVERPROPERTY('ProductVersion')    AS ProductVersion,
                  SERVERPROPERTY('ProductLevel')      AS ProductLevel,
                  SERVERPROPERTY('EngineEdition')     AS EngineEdition;", cn)

            cn.Open()
            Using rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    tbMLTest1.Text += ($"MachineName: {rdr("MachineName")}") + Environment.NewLine
                    tbMLTest1.Text += ($"ServerName: {rdr("ServerName")}") + Environment.NewLine
                    tbMLTest1.Text += ($"InstanceName: {rdr("InstanceName")}") + Environment.NewLine
                    tbMLTest1.Text += ($"Edition: {rdr("Edition")}") + Environment.NewLine
                    tbMLTest1.Text += ($"ProductVersion: {rdr("ProductVersion")}") + Environment.NewLine
                    tbMLTest1.Text += ($"ProductLevel: {rdr("ProductLevel")}") + Environment.NewLine
                    tbMLTest1.Text += ($"EngineEdition: {rdr("EngineEdition")}") + Environment.NewLine
                End If
            End Using
        End Using

    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CodeHelper.GetPcInfo()

        If (My.Application.CommandLineArgs.Contains("-test")) Then
            For i As Integer = tcSTA.TabPages.Count - 1 To 0 Step -1
                Dim page As TabPage = tcSTA.TabPages(i)
                If Not page.Equals(tpGeneral) Then tcSTA.TabPages.Remove(page)
            Next
        End If

        Connections.IniFileHandler(False)
        If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then Variables.LoggedIn = True Else Variables.LoggedIn = False

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

        Try
            Dim regKey = My.Computer.Registry.ClassesRoot.OpenSubKey("Excel.Application", False).OpenSubKey("CurVer", False)
            PCInfo.ExcelInstalled = True



        Catch ex As Exception
            PCInfo.ExcelInstalled = False
        End Try

#If DEBUG Then

#Else
                Variables.LoggedIn = False
                tbTest1.Visible = False
                tbTest2.Visible = False
                tbTest3.Visible = False
        tbMLTest1.Visible = False
        btnTest.Visible = False

#End If


        btnAdvUpgrade.Visible = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvUpgrade"))
        btnAdvRedeem.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvRedeem"))
        btnAdvCardTech.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvCardTech"))
        btnAdvReportEditor.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvReportEditor"))
        btnAdvManager.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvManager"))
        btnPos.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("Pos"))
        btnAdvGroups.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvGroups"))

        _config = LoadConfig()
        lstPrograms.DisplayMember = "Name"  ' shows ProgramEntry.Name
        RefreshProgramsList()
        FillComboFromListBox()
        tbWindowTitle.Text = _options.WindowTitle

    End Sub

    Private Sub RefreshProgramsList(Optional preserveSelection As Boolean = False)
        Dim selected As ProgramEntry = Nothing
        If preserveSelection AndAlso lstPrograms.SelectedItem IsNot Nothing Then
            selected = DirectCast(lstPrograms.SelectedItem, ProgramEntry)
        End If

        lstPrograms.BeginUpdate()
        lstPrograms.Items.Clear()
        For Each p In _config.Programs.Where(Function(x) x.Enabled)
            lstPrograms.Items.Add(p)
        Next
        lstPrograms.EndUpdate()

        If preserveSelection AndAlso selected IsNot Nothing Then
            For i = 0 To lstPrograms.Items.Count - 1
                If Object.ReferenceEquals(lstPrograms.Items(i), selected) Then
                    lstPrograms.SelectedIndex = i
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub FillComboFromListBox()
        cmbboxAppLaunch.Items.Clear()

        For Each entry As ProgramEntry In lstPrograms.Items
            cmbboxAppLaunch.Items.Add(entry)
        Next
        cmbboxAppLaunch.DisplayMember = "Name"

    End Sub

    Private Sub FormMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
#If DEBUG Then
        tcSTA.SelectedTab = tpQATools

#End If

    End Sub

    Private Sub btnUnlockAdminAccount_Click(sender As Object, e As EventArgs)
        DBConnector.CreateCommand(GeneralQueries.UnlockAdminAccount)

    End Sub

    Private Sub tbLocName_GotFocus(sender As Object, e As EventArgs) Handles tbLocName.GotFocus, tbLicSvr.GotFocus, tbCoreSvr.GotFocus, tbDbVer.GotFocus, tbWebEnabled.GotFocus, tbShiftDate.GotFocus
        gpLicInfo.Select()

    End Sub

    Private Sub tmr10Seconds_Tick(sender As Object, e As EventArgs) Handles tmr10Seconds.Tick
        'If Not PCInfo.AdvantageVersion.Contains("Not") Then tslblCeVersion.Text = "Version:  " + PCInfo.AdvantageVersion

        Dim info = ServiceIntrospection.GetServiceFileInfo("AdvCoreService") ' Advantage Core Service
        tslblCeVersion.Text = "Version:  " + info.Version

        'If info.Path <> "" Then
        '    Dim kind = If(info.IsDll, "DLL", "EXE")
        '    tbTest1.Text = (info.Version)
        '    tbMLTest1.Text = info.Path
        'Else
        '    tbTest1.Text = ("Could not resolve service binary.")
        'End If


        CodeHelper.Refresher()
        If Not PCInfo.ValidDatabase Then
            tpAdvData.Enabled = False
            tpDbInfo.Enabled = False
            tpGeneral.Enabled = False
            tpDbLogs.Enabled = False
        End If
    End Sub

    Private Sub tmr1Sec_Tick(sender As Object, e As EventArgs) Handles tmr1Sec.Tick
        If tbDbVer.Text.Equals(tbPcAdvVersion.Text) Then
            tbDbVer.BackColor = TextboxColors.White
            tbDbVer.ForeColor = TextboxColors.Black
            tbPcAdvVersion.BackColor = TextboxColors.White
            tbPcAdvVersion.ForeColor = TextboxColors.Black
        Else
            tbDbVer.BackColor = TextboxColors.Red
            tbDbVer.ForeColor = TextboxColors.White
            tbPcAdvVersion.BackColor = TextboxColors.Red
            tbPcAdvVersion.ForeColor = TextboxColors.White
        End If

        PCInfo.AreServicesInstalled = False
        Try

            If PCInfo.AreServicesInstalled Then
                If IsNothing(LastServiceEntry) Then Exit Sub

                Services.GetServiceStatus(LastServiceEntry)

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

    Private Sub btnDbInfoRefresh_Click(sender As Object, e As EventArgs) Handles btnDbInfoRefresh.Click
        If rbDbTableSize.Checked Or rbDbFragmentation.Checked Or rbDbSizeByDay.Checked Or rbDbDeadlocks.Checked Then

            Dim dbResult As DataSet
            Dim query As String = ""
            If rbDbTableSize.Checked Then query = DbInfo.DbSizeByTable
            If rbDbFragmentation.Checked Then query = DbInfo.DbFragmentation
            If rbDbSizeByDay.Checked Then query = String.Format(DbInfo.DbSizeByDay, ConfigValues.Database)
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
        caller.Enabled = False

        For index = 0 To ServiceControlList.Count - 1
            If ServiceControlList.Item(index).RSButton.Equals(caller) Then
                temp = index
            End If
        Next
        LastServiceEntry = ServiceControlList.Item(temp)
        LastServiceEntry.RSButton.Tag = "restart"
        Services.RestartService(LastServiceEntry)


    End Sub

    Private Sub tbCoreService_GotFocus(sender As Object, e As EventArgs) Handles tbCoreService.GotFocus, tbCoreService.GotFocus, tbCloudService.GotFocus, tbAdvCreditService.GotFocus, tbAdvSignageService.GotFocus, tbAdvLicService.GotFocus, tbAdvNotifyService.GotFocus, tbAdvTurnstileEngine.GotFocus, tbAdvantageUpgradeService.GotFocus

        Dim caller As TextBox = DirectCast(sender, TextBox)
        caller.SelectionStart = 0
        caller.SelectionLength = 0
    End Sub


    Private Sub tcSTA_Click(sender As Object, e As EventArgs) Handles tcSTA.Click
        btnDbLogRefresh.PerformClick()
        btnDbInfoRefresh.PerformClick()
        btnRelayRefresh.PerformClick()

    End Sub

    Private Sub btnAdvManager_Click(sender As Object, e As EventArgs) Handles btnAdvManager.Click, btnPos.Click, btnAdvGroups.Click, btnAdvReportEditor.Click, btnAdvRedeem.Click, btnAdvCardTech.Click

        Dim caller As System.Windows.Forms.Button = DirectCast(sender, System.Windows.Forms.Button)
        Dim Executable As String = caller.Name.Replace("btn", "")
        Dim Version As Integer = CodeHelper.AdvExeCheck(Executable)

        tbTest3.Text = CodeHelper.AdvExeCheck(Executable)
        If Version = AppInstallState.InstalledX86 Then Executable = String.Format("{0}{1}.exe", AppData.CEPath86, Executable)
        If Version = AppInstallState.InstalledX64 Then Executable = String.Format("{0}{1}.exe", AppData.CEPath64, Executable)


        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(Executable)
        Diagnostics.Process.Start(Executable)
    End Sub

    Private Async Sub btnPortCheck_Click(sender As Object, e As EventArgs) Handles btnPortCheck.Click
        Dim host As String = ConfigValues.Server
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
        Dim Executable As String = "AdvUpgrade"
        Dim Version As Integer = CodeHelper.AdvExeCheck(Executable)

        If Version = AppInstallState.InstalledX86 Then Executable = String.Format("{0}{1}.exe", AppData.CEPath86, Executable)
        If Version = AppInstallState.InstalledX64 Then Executable = String.Format("{0}{1}.exe", AppData.CEPath64, Executable)

        Dim temp As String = ""
        Dim startinfo As ProcessStartInfo = New ProcessStartInfo(Executable)
        startinfo.Arguments = ""
        startinfo.FileName = Executable

        If cbAdvUpgradeNoBackup.Checked Then temp += AdvUpgradeConstants.NoBackup + " "
        If cbAdvUpgradeQuiet.Checked Then temp += AdvUpgradeConstants.Quiet + " "
        If cbAdvUpgradeNoSetup.Checked Then temp += AdvUpgradeConstants.NoSetup
        startinfo.Arguments = temp

        tbMLTest1.Text = startinfo.FileName + " " + startinfo.Arguments
        Process.Start(startinfo)

    End Sub

    Private Async Sub btnCustomPortCheck_Click(sender As Object, e As EventArgs) Handles btnCustomPortCheck.Click

        Dim host As String = ConfigValues.Server
        tbCustomPortCheck.Text = String.Format("Testing Port...{0}", nudCustomPortCheck.Value)

        Dim result As Boolean = Await ConnectAsync(ConfigValues.Server, nudCustomPortCheck.Value)

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

    Private Sub btnRefreshServices_Click(sender As Object, e As EventArgs) Handles btnRefreshGeneralTab.Click
        Dim TabName As String


        If tcSTA.SelectedTab.Equals(tpAdvData) Then

            If PCInfo.ValidDatabase Then

                Try
                    dbAppOptions.Reset()
                    dgvAppOptions.Rows.Clear()
                    dbAppOptions = DBConnector.dbQuery("SELECT OptionName, OptionValue FROM AppOptions")
                    For index = 0 To dbAppOptions.Tables(0).Rows.Count - 1
                        dgvAppOptions.Rows.Add(dbAppOptions.Tables(0).Rows(index).ItemArray)
                    Next
                    dbWebOptions.Reset()
                    dgvWebOptions.Rows.Clear()
                    dbWebOptions = DBConnector.dbQuery("SELECT OptionName, OptionValue FROM WebOptions")
                    For index = 0 To dbWebOptions.Tables(0).Rows.Count - 1
                        dgvWebOptions.Rows.Add(dbWebOptions.Tables(0).Rows(index).ItemArray)
                    Next
                    dbApplicationInfo.Reset()
                    dgvApplicationInfo.Rows.Clear()
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
        ElseIf tcSTA.SelectedTab.Equals(tpGeneral) Then
            CodeHelper.Refresher()

        Else
            TabName = tcSTA.SelectedTab.Name
            tbTest1.Text = TabName
        End If


    End Sub

    Private ReadOnly _jsonSettings As New JsonSerializerSettings With {
        .Formatting = Newtonsoft.Json.Formatting.Indented.Indented,
        .NullValueHandling = NullValueHandling.Ignore
    }

    Public Function LoadConfig() As LauncherConfig
        Dim path = GetConfigPath()
        If Not File.Exists(path) Then Return New LauncherConfig()

        Try
            Dim json = File.ReadAllText(path)
            Dim cfg = JsonConvert.DeserializeObject(Of LauncherConfig)(json, _jsonSettings)
            If cfg Is Nothing Then cfg = New LauncherConfig()
            Return cfg
        Catch ex As Exception
            MessageBox.Show("Failed to load config: " & ex.Message)
            Return New LauncherConfig()
        End Try
    End Function

    Public Sub SaveConfig(cfg As LauncherConfig)
        Try
            Dim path = GetConfigPath()
            Dim json = JsonConvert.SerializeObject(cfg, _jsonSettings)
            File.WriteAllText(path, json)
        Catch ex As Exception
            MessageBox.Show("Failed to save config: " & ex.Message)
        End Try
    End Sub

    Public Shared Function GetConfigPath() As String
        Dim dir = System.IO.Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "STA2") ' your app folder
        If Not IO.Directory.Exists(dir) Then IO.Directory.CreateDirectory(dir)
        Return IO.Path.Combine(dir, "launcher.config.json")
    End Function


    'Private Sub btnLaunch_Click(sender As Object, e As EventArgs) Handles btnLaunch.Click, lstPrograms.DoubleClick
    '    Dim entry = TryCast(lstPrograms.SelectedItem, ProgramEntry)
    '    If entry Is Nothing Then
    '        MessageBox.Show("Please select a program.", "Launch", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Return
    '    End If
    '    LaunchProgram(entry)
    'End Sub

    Private Sub LaunchProgram(entry As ProgramEntry)
        If entry Is Nothing OrElse String.IsNullOrWhiteSpace(entry.Path) Then
            MessageBox.Show("Invalid program entry.", "Launch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not IO.File.Exists(entry.Path) Then
            MessageBox.Show("File not found: " & entry.Path, "Launch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim psi As New ProcessStartInfo() With {
            .FileName = entry.Path,
            .Arguments = If(entry.Arguments, ""),
            .WorkingDirectory = If(String.IsNullOrWhiteSpace(entry.WorkingDirectory),
                                   IO.Path.GetDirectoryName(entry.Path),
                                   entry.WorkingDirectory),
            .UseShellExecute = True
        }
            If entry.RunAsAdmin Then psi.Verb = "runas"
            Process.Start(psi)
        Catch ex As Exception
            MessageBox.Show("Failed to launch:" & Environment.NewLine & ex.Message,
                        "Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim entry = TryCast(lstPrograms.SelectedItem, ProgramEntry)
        If entry Is Nothing Then
            MessageBox.Show("Select a program to edit.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dlg As New EditProgramForm()
            ' Clone to support Cancel without side effects
            Dim clone As New ProgramEntry With {
                .Name = entry.Name,
                .Path = entry.Path,
                .Arguments = entry.Arguments,
                .WorkingDirectory = entry.WorkingDirectory,
                .RunAsAdmin = entry.RunAsAdmin,
                .IconPath = entry.IconPath,
                .Enabled = entry.Enabled,
                .IncludeInBatch = entry.IncludeInBatch
            }

            dlg.Entry = clone

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                entry.Name = clone.Name
                entry.Path = clone.Path
                entry.Arguments = clone.Arguments
                entry.WorkingDirectory = clone.WorkingDirectory
                entry.RunAsAdmin = clone.RunAsAdmin
                entry.IconPath = clone.IconPath
                entry.Enabled = clone.Enabled
                entry.IncludeInBatch = clone.IncludeInBatch

                SaveConfig(_config)
                RefreshProgramsList(preserveSelection:=True)
                FillComboFromListBox()
            End If
        End Using
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Using dlg As New EditProgramForm()
            dlg.Entry = New ProgramEntry()
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                _config.Programs.Add(dlg.Entry)
                SaveConfig(_config)
                RefreshProgramsList()
                FillComboFromListBox()
            End If
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim entry = TryCast(lstPrograms.SelectedItem, ProgramEntry)
        If entry Is Nothing Then Return

        If MessageBox.Show($"Remove '{entry.Name}'?", "Confirm",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _config.Programs.Remove(entry)
            SaveConfig(_config)
            RefreshProgramsList()
            FillComboFromListBox()
        End If
    End Sub

    Private Sub btnBatchLaunch_Click(sender As Object, e As EventArgs) Handles btnBatchLaunch.Click
        For Each p In _config.Programs.Where(Function(x) x.Enabled AndAlso x.IncludeInBatch)
            LaunchProgram(p) ' reuse your existing launcher method
        Next
    End Sub

    Private Sub cbListSort_CheckedChanged(sender As Object, e As EventArgs) Handles cbListSort.CheckedChanged
        lstPrograms.Sorted = cbListSort.Checked

    End Sub

    Private Sub LaunchFromUI(sender As Object, e As EventArgs) Handles btnLaunch.Click, btnComboAppLaunch.Click, lstPrograms.DoubleClick

        Dim entry As ProgramEntry = Nothing

        If sender Is btnLaunch OrElse sender Is lstPrograms Then
            ' From ListBox button OR double-click on the ListBox
            entry = TryCast(lstPrograms.SelectedItem, ProgramEntry)

        ElseIf sender Is btnComboAppLaunch Then
            ' From ComboBox button
            entry = TryCast(cmbboxAppLaunch.SelectedItem, ProgramEntry)
        End If

        LaunchProgram(entry)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        OptionsManager.Save(_options)

    End Sub

    Private Sub tbWindowTitle_TextChanged(sender As Object, e As EventArgs) Handles tbWindowTitle.TextChanged
        _options.WindowTitle = tbWindowTitle.Text

    End Sub
End Class