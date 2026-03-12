Imports System.CodeDom
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Security.Policy
Imports System.ServiceProcess
Imports System.Web
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports System.Xml
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports STA2.AppData

Public Class FormMain

    Private _options As AppOptions

    Private _launcherConfig As LauncherConfig

    Public Sub New(options As AppOptions, launcher As LauncherConfig)
        InitializeComponent()     ' Designer-required

        ' Apply the window title from options.
        ' Falls back to the existing Form.Text if WindowTitle is empty.

        _options = options
        _launcherConfig = launcher

        ' Your existing setup...
        RefreshProgramsList()
        FillComboFromListBox()

        InitializeProgramsContextMenu()
        RefreshQuickLaunchButtons()    ' 4) Render buttons AFTER both _options and 

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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Variables.OfflineMode Then
            ' Disable DB buttons, timers, etc.
            DisableDatabaseSections()
            Return
        End If

        CodeHelper.GetPcInfo()

        If (My.Application.CommandLineArgs.Contains("-test")) Then
            For i As Integer = tcSTA.TabPages.Count - 1 To 0 Step -1
                Dim page As TabPage = tcSTA.TabPages(i)
                If Not page.Equals(tpGeneral) Then tcSTA.TabPages.Remove(page)
            Next
        End If

        Connections.IniFileHandler(False)

        CodeHelper.FirstLoad()

        Dim strTemp As String = ""
        ServiceControlList = Services.ServicesExistCheck()

        If Not IsRunningAsAdmin() Then
            For Each svc In ServiceControlList
                If svc.GroupBox IsNot Nothing Then svc.GroupBox.Enabled = False
                If svc.SSButton IsNot Nothing Then svc.SSButton.Enabled = False
                If svc.RSButton IsNot Nothing Then svc.RSButton.Enabled = False
            Next
        End If

        CodeHelper.Refresher()
        rbDbTableSize.Checked = True
        rbMessageLog.Checked = True
        btnDbInfoRefresh.PerformClick()
        gpMessageLogFilters.Enabled = rbMessageLog.Checked
        btnDbLogRefresh.PerformClick()

        If PCInfo.ValidDatabase Then
            AdvantageDataRefresh("Form Load")

        End If

        Try
            Dim regKey = My.Computer.Registry.ClassesRoot.OpenSubKey("Excel.Application", False).OpenSubKey("CurVer", False)
            PCInfo.ExcelInstalled = True



        Catch ex As Exception
            PCInfo.ExcelInstalled = False
        End Try

#If DEBUG Then

#Else
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

        _options = OptionsManager.LoadOrCreate()
        _launcherConfig = OptionsManager.LoadLauncherConfig()
        RefreshProgramsList()
        FillComboFromListBox()
        RefreshQuickLaunchButtons()

        tbWindowTitle.Text = _options.WindowTitle
        If IsRunningAsAdmin() Then
            btnAdminRestart.Enabled = False
            btnAdminRestart.Text = "Running as Admin"
        Else
            btnAdminRestart.Enabled = True
            btnAdminRestart.Text = "Restart as Administrator"
        End If
    End Sub

    Private Sub RefreshProgramsList(Optional preserveSelection As Boolean = False)
        Dim selected As ProgramEntry = Nothing

        If preserveSelection AndAlso lstPrograms.SelectedItem IsNot Nothing Then
            selected = DirectCast(lstPrograms.SelectedItem, ProgramEntry)
        End If

        lstPrograms.BeginUpdate()
        lstPrograms.Items.Clear()

        If _launcherConfig IsNot Nothing AndAlso _launcherConfig.Programs IsNot Nothing Then
            For Each p As ProgramEntry In _launcherConfig.Programs.Where(Function(x) x.Enabled)
                lstPrograms.Items.Add(p)
            Next
        End If

        lstPrograms.EndUpdate()

        ' IMPORTANT: display only the Name property
        lstPrograms.DisplayMember = "Name"

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
        'tcSTA.SelectedTab = tpQATools

#End If

    End Sub

    Private Sub tbLocName_GotFocus(sender As Object, e As EventArgs) Handles tbLocName.GotFocus, tbLicSvr.GotFocus, tbCoreSvr.GotFocus, tbDbVer.GotFocus, tbWebEnabled.GotFocus, tbShiftDate.GotFocus
        gpLicInfo.Select()

    End Sub

    Private Sub tmr10Seconds_Tick(sender As Object, e As EventArgs) Handles tmr10Seconds.Tick

        Dim info = ServiceIntrospection.GetServiceFileInfo("AdvCoreService") ' Advantage Core Service
        tslblCeVersion.Text = "Version:  " + info.Version


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

        If Variables.OfflineMode Then
            'MessageBox.Show("Database is offline.")
            Return
        End If
        ' Only run if one of the choices is selected
        If Not (rbDbTableSize.Checked Or rbDbFragmentation.Checked Or rbDbSizeByDay.Checked Or rbDbDeadlocks.Checked) Then
            Return
        End If

        ' Optional: prevent double clicks during refresh
        btnDbInfoRefresh.Enabled = False
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim query As String = String.Empty

            If rbDbTableSize.Checked Then
                query = DbInfo.DbSizeByTable
            ElseIf rbDbFragmentation.Checked Then
                query = DbInfo.DbFragmentation
            ElseIf rbDbSizeByDay.Checked Then
                query = String.Format(DbInfo.DbSizeByDay, ConfigValues.Database)
            ElseIf rbDbDeadlocks.Checked Then
                query = DbInfo.DbDeadlocks
            End If

            ' Execute via ReliableSql (shows Retry/Cancel on connection loss and retries)
            Dim q As Object = ReliableSql.Query(query)
            Dim ds As DataSet = TryCast(q, DataSet)

            ' Bind safely
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                dgvDbTableSize.DataSource = ds.Tables(0)
            Else
                ' If nothing came back, clear the grid so old data isn't shown
                dgvDbTableSize.DataSource = Nothing
            End If

            dgvDbTableSize.Refresh()

        Catch oce As OperationCanceledException
            ' User canceled after connection-lost prompt — keep app responsive
            MessageBox.Show(
            "Operation canceled by user due to lost database connection.",
            "Database",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
            ' Optionally clear the grid to reflect no data
            dgvDbTableSize.DataSource = Nothing

        Catch ex As Exception
            ' Non-transient issue (bad SQL, unexpected shape, etc.)
            MessageBox.Show(
            $"Failed to refresh database info:{Environment.NewLine}{ex.Message}",
            "Database Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )
            ' Optionally clear the grid on failure
            dgvDbTableSize.DataSource = Nothing

        Finally
            ' Restore UI state
            Cursor.Current = Cursors.Default
            btnDbInfoRefresh.Enabled = True
        End Try
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

        If Variables.OfflineMode Then
            'MessageBox.Show("Database is offline.")
            Return
        End If

        Dim dbResultCount As DataSet = Nothing
        Dim dbResultData As DataSet = Nothing

        Dim queryData As String = ""
        Dim queryCount As String = ""

        Try
            If rbWebCloudUpdates.Checked Then

                gpDbLogCount.Text = "Count per table"
                gpDbLogData.Text = "All WebCloudUpdates Entries"

                ' --------------------------
                ' Query COUNT
                ' --------------------------
                queryCount = LogQueries.WebCloudTotalCount
                Dim qCount As Object = ReliableSql.Query(queryCount)
                dbResultCount = TryCast(qCount, DataSet)

                If dbResultCount IsNot Nothing AndAlso dbResultCount.Tables.Count > 0 Then
                    dgvDbLogCount.DataSource = dbResultCount.Tables(0)
                    dgvDbLogCount.Columns(0).Visible = False
                    dgvDbLogCount.Columns(1).HeaderText = "Table"
                    dgvDbLogCount.Columns(2).HeaderText = "Count"
                Else
                    dgvDbLogCount.DataSource = Nothing
                End If

                ' --------------------------
                ' Query DATA
                ' --------------------------
                queryData = LogQueries.WebCloudUpdates
                Dim qData As Object = ReliableSql.Query(queryData)
                dbResultData = TryCast(qData, DataSet)

                If dbResultData IsNot Nothing AndAlso dbResultData.Tables.Count > 0 Then
                    dgvDbLogData.DataSource = dbResultData.Tables(0)
                Else
                    dgvDbLogData.DataSource = Nothing
                End If


            ElseIf rbMessageLog.Checked Then

                ' Build the MessageLog queries based on filters
                CodeHelper.MsgLogBuilder(MessageLogFilters.Errors, MessageLogFilters.Limit, MessageLogFilters.DateRange)

                gpDbLogCount.Text = "Errors per day"
                gpDbLogData.Text = "MessageLog"

                ' --------------------------
                ' Query ERROR COUNT
                ' --------------------------
                queryCount = LogQueries.MessageLogErrorCount
                Dim qCount As Object = ReliableSql.Query(queryCount)
                dbResultCount = TryCast(qCount, DataSet)

                If dbResultCount IsNot Nothing AndAlso dbResultCount.Tables.Count > 0 Then
                    dgvDbLogCount.DataSource = dbResultCount.Tables(0)
                    dgvDbLogCount.Columns(0).Visible = True
                    dgvDbLogCount.Columns(0).HeaderText = "Date"
                    dgvDbLogCount.Columns(1).HeaderText = "Program"
                    dgvDbLogCount.Columns(2).HeaderText = "Count"
                Else
                    dgvDbLogCount.DataSource = Nothing
                End If

                ' --------------------------
                ' Query LOG DATA
                ' --------------------------
                queryData = LogQueries.MessageLog
                Dim qData As Object = ReliableSql.Query(queryData)
                dbResultData = TryCast(qData, DataSet)

                If dbResultData IsNot Nothing AndAlso dbResultData.Tables.Count > 0 Then
                    dgvDbLogData.DataSource = dbResultData.Tables(0)
                    ' Sort by first column (date)
                    dgvDbLogData.Sort(dgvDbLogData.Columns(0), ComponentModel.ListSortDirection.Descending)
                Else
                    dgvDbLogData.DataSource = Nothing
                End If

            Else
                gpDbLogData.Text = ""
                gpDbLogCount.Text = ""
                Exit Sub
            End If

            dgvDbLogData.Refresh()

        Catch oce As OperationCanceledException
            ' User clicked Cancel on the ReliableSql Retry/Cancel prompt
            MessageBox.Show(
            "Operation canceled by user due to lost database connection.",
            "Database Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        )

        Catch ex As Exception
            MessageBox.Show(
            $"Database log refresh failed:{Environment.NewLine}{ex.Message}",
            "Database Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )
        End Try

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

    End Sub

    Private Sub btnAdvManager_Click(sender As Object, e As EventArgs) Handles btnAdvManager.Click, btnPos.Click, btnAdvGroups.Click, btnAdvReportEditor.Click, btnAdvRedeem.Click, btnAdvCardTech.Click

        Dim caller As System.Windows.Forms.Button = DirectCast(sender, System.Windows.Forms.Button)
        Dim Executable As String = caller.Name.Replace("btn", "")
        Dim Version As Integer = CodeHelper.AdvExeCheck(Executable)

        If Version = AppInstallState.InstalledX86 Then Executable = String.Format("{0}{1}.exe", AppData.CEPath86, Executable)
        If Version = AppInstallState.InstalledX64 Then Executable = String.Format("{0}{1}.exe", AppData.CEPath64, Executable)


        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(Executable)
        Diagnostics.Process.Start(Executable)
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

        If Variables.OfflineMode Then
            MessageBox.Show("Database is offline.")
            Return
        End If


        If tcSTA.SelectedTab.Equals(tpAdvData) Then

            If PCInfo.ValidDatabase Then
                AdvantageDataRefresh("Refresh Button")
            End If
        ElseIf tcSTA.SelectedTab.Equals(tpGeneral) Then
            CodeHelper.Refresher()

        Else
            TabName = tcSTA.SelectedTab.Name
        End If


    End Sub
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
            .Id = entry.Id, ' <--- keep the same Id
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
                ' Apply changes back to the selected entry
                entry.Name = clone.Name
                entry.Path = clone.Path
                entry.Arguments = clone.Arguments
                entry.WorkingDirectory = clone.WorkingDirectory
                entry.RunAsAdmin = clone.RunAsAdmin
                entry.IconPath = clone.IconPath
                entry.Enabled = clone.Enabled
                entry.IncludeInBatch = clone.IncludeInBatch

                ' Persist via OptionsManager
                SaveLauncher()

                ' Refresh UI (preserve selection) & keep combo in sync
                RefreshProgramsList(preserveSelection:=True)
                FillComboFromListBox()
            End If
        End Using
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Using dlg As New EditProgramForm()
            dlg.Entry = New ProgramEntry() With {.Enabled = True}

            If dlg.ShowDialog(Me) = DialogResult.OK Then

                ' Ensure config object exists
                If _launcherConfig Is Nothing Then
                    _launcherConfig = New LauncherConfig()
                End If

                ' Ensure Programs list exists
                If _launcherConfig.Programs Is Nothing Then
                    _launcherConfig.Programs = New List(Of ProgramEntry)()
                End If

                ' Add the new entry to the underlying config list
                _launcherConfig.Programs.Add(dlg.Entry)

                ' Persist using new OptionsManager
                SaveLauncher()
                ' Reload UI controls
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

            If _launcherConfig IsNot Nothing AndAlso _launcherConfig.Programs IsNot Nothing Then
                _launcherConfig.Programs.Remove(entry)
            End If

            ' Persist via OptionsManager
            SaveLauncher()

            ' Refresh UI & combo
            RefreshProgramsList()
            FillComboFromListBox()
        End If
    End Sub
    Private Sub btnBatchLaunch_Click(sender As Object, e As EventArgs) Handles btnBatchLaunch.Click

        btnBatchLaunch.Enabled = False
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim result = BatchLauncher.RunBatch(_launcherConfig,
                                            caller:="UI:FormMain.btnBatchLaunch",
                                            silent:=False)
            ' You can inspect result here if needed
        Finally
            Cursor.Current = Cursors.Default
            btnBatchLaunch.Enabled = True
        End Try

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

    Private Sub tbWindowTitle_TextChanged(sender As Object, e As EventArgs) Handles tbWindowTitle.TextChanged
        _options.WindowTitle = tbWindowTitle.Text

    End Sub

    Private Sub SaveLauncher(Optional syncFromList As Boolean = False)
        If syncFromList Then
            _launcherConfig.Programs = lstPrograms.Items.Cast(Of ProgramEntry)().ToList()
        End If
        OptionsManager.SaveLauncherConfig(_launcherConfig)
    End Sub

    Private Sub btnAdminRestart_Click(sender As Object, e As EventArgs) Handles btnAdminRestart.Click
        If IsRunningAsAdmin() Then
            MessageBox.Show("Already running as Administrator.")
            Return
        End If

        Try
            Dim exePath As String = Application.ExecutablePath

            Dim psi As New ProcessStartInfo(exePath)
            psi.Verb = "runas"   ' <-- This triggers UAC elevation
            psi.UseShellExecute = True

            Process.Start(psi)

            Application.Exit()   ' <-- Cleanly close the current non-admin instance
        Catch ex As Exception
            MessageBox.Show("Elevation canceled or failed: " & ex.Message)
        End Try
        If IsRunningAsAdmin() Then
            btnAdminRestart.Enabled = False
            btnAdminRestart.Text = "Running as Admin"
        Else
            btnAdminRestart.Enabled = True
            btnAdminRestart.Text = "Restart as Administrator"
        End If
    End Sub

    Private Sub FormMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing


        Try
            ' If you made edits directly to lstPrograms.Items and not to _launcherConfig.Programs,
            ' you can sync the UI back into the model here. If not necessary, skip this.
            ' _launcherConfig.Programs = lstPrograms.Items.Cast(Of ProgramEntry)().ToList()

            OptionsManager.SaveLauncherConfig(_launcherConfig)
        Catch ex As Exception
            ' Log or show; don’t rethrow to avoid blocking shutdown
            Debug.WriteLine("Error saving launcher config on exit: " & ex.Message)
        End Try

        ' Also persist options if you want:
        Try
            If _options IsNot Nothing Then OptionsManager.Save(_options)
        Catch
        End Try

    End Sub

    ' Rebuilds the quick launch buttons inside the FlowLayoutPanel flpQuickLaunch,
    ' showing ONLY buttons for assigned apps (no placeholders).
    Private Sub RefreshQuickLaunchButtons()
        If flpQuickLaunch Is Nothing Then Return

        ' Build lookup for fast Id -> ProgramEntry resolution (enabled only)
        Dim byId As New Dictionary(Of String, ProgramEntry)(StringComparer.OrdinalIgnoreCase)
        If _launcherConfig IsNot Nothing AndAlso _launcherConfig.Programs IsNot Nothing Then
            For Each p In _launcherConfig.Programs
                If p IsNot Nothing AndAlso p.Enabled AndAlso Not String.IsNullOrWhiteSpace(p.Id) Then
                    If Not byId.ContainsKey(p.Id) Then byId.Add(p.Id, p)
                End If
            Next
        End If

        flpQuickLaunch.SuspendLayout()
        Try
            flpQuickLaunch.Controls.Clear()

            If _options Is Nothing OrElse _options.QuickLaunchIds Is Nothing Then Exit Sub

            For slot = 0 To _options.QuickLaunchIds.Count - 1

                Dim id As String = _options.QuickLaunchIds(slot)
                If String.IsNullOrWhiteSpace(id) Then Continue For

                Dim entry As ProgramEntry = Nothing
                If Not byId.TryGetValue(id, entry) Then Continue For

                ' 💡 SNAPSHOT VARIABLES HERE
                Dim slotLocal As Integer = slot
                Dim entryLocal As ProgramEntry = entry

                Dim btn As New Button()
                btn.Name = $"btnQuickSlot{slotLocal + 1}"
                btn.Width = 120
                btn.Height = 32
                btn.AutoSize = False
                btn.Tag = entryLocal
                btn.Text = entryLocal.Name
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.Margin = New Padding(3)
                btn.UseVisualStyleBackColor = True

                ' Tooltip
                Dim tipText As String = entryLocal.Name
                If Not String.IsNullOrWhiteSpace(entryLocal.Path) Then
                    tipText &= Environment.NewLine & entryLocal.Path
                End If
                If Not String.IsNullOrWhiteSpace(entryLocal.Arguments) Then
                    tipText &= Environment.NewLine & entryLocal.Arguments
                End If
                ToolTipForQuickButtons.SetToolTip(btn, tipText)

                ' Click handler using snapshot version of entry
                AddHandler btn.Click,
                Sub(s, e)
                    LaunchProgram(entryLocal)
                End Sub

                ' Right‑click reassign using snapshot version of slot
                AddHandler btn.MouseUp,
                Sub(s, e)
                    If e.Button = MouseButtons.Right Then
                        AssignSelectedListItemToQuickSlot(slotLocal)
                    End If
                End Sub

                flpQuickLaunch.Controls.Add(btn)
            Next

        Finally
            flpQuickLaunch.ResumeLayout()
        End Try
    End Sub

    ' Assign the currently-selected program in lstPrograms to the specified quick-launch slot (0-based).
    Private Sub AssignSelectedListItemToQuickSlot(slot As Integer)
        Dim entry As ProgramEntry = TryCast(lstPrograms.SelectedItem, ProgramEntry)
        If entry Is Nothing Then
            MessageBox.Show("Select a program to assign.", "Quick Launch", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Ensure QuickLaunchIds exists and is large enough
        If _options.QuickLaunchIds Is Nothing Then
            _options.QuickLaunchIds = New List(Of String)(New String() {"", "", "", "", ""})
        End If
        While _options.QuickLaunchIds.Count <= slot
            _options.QuickLaunchIds.Add("")
        End While

        _options.QuickLaunchIds(slot) = entry.Id

        ' Save and refresh quick buttons
        OptionsManager.Save(_options)
        RefreshQuickLaunchButtons()
    End Sub

    Private Sub ClearQuickSlot(slot As Integer)
        If _options.QuickLaunchIds Is Nothing Then Exit Sub
        If slot < 0 OrElse slot >= _options.QuickLaunchIds.Count Then Exit Sub

        _options.QuickLaunchIds(slot) = ""
        OptionsManager.Save(_options)
        RefreshQuickLaunchButtons()
    End Sub
    Private _ctxPrograms As ContextMenuStrip

    Private Sub InitializeProgramsContextMenu()
        _ctxPrograms = New ContextMenuStrip()

        ' --- Build the “Assign to Quick Slot” submenu ---
        Dim miAssignRoot = New ToolStripMenuItem("Assign to Quick Slot")

        ' How many slots? Use options count if present; default to 5.
        Dim slotCount As Integer = If(_options?.QuickLaunchIds?.Count, 5)
        If slotCount <= 0 Then slotCount = 5

        For slot = 0 To slotCount - 1
            Dim slotIndex As Integer = slot ' capture for closure
            Dim mi = New ToolStripMenuItem($"Slot {slotIndex + 1}")
            AddHandler mi.Click, Sub(sender, e)
                                     AssignSelectedListItemToQuickSlot(slotIndex)
                                 End Sub
            miAssignRoot.DropDownItems.Add(mi)
        Next

        ' --- Build “Clear Slot” submenu (optional but handy) ---
        Dim miClearRoot = New ToolStripMenuItem("Clear Quick Slot")
        For slot = 0 To slotCount - 1
            Dim slotIndex As Integer = slot
            Dim mi = New ToolStripMenuItem($"Slot {slotIndex + 1}")
            AddHandler mi.Click, Sub(sender, e)
                                     ClearQuickSlot(slotIndex)
                                 End Sub
            miClearRoot.DropDownItems.Add(mi)
        Next

        ' Optional: a separator and a refresh action
        Dim miRefreshQuick = New ToolStripMenuItem("Refresh Quick Buttons")
        AddHandler miRefreshQuick.Click, Sub(sender, e) RefreshQuickLaunchButtons()

        _ctxPrograms.Items.Add(miAssignRoot)
        _ctxPrograms.Items.Add(miClearRoot)
        _ctxPrograms.Items.Add(New ToolStripSeparator())
        _ctxPrograms.Items.Add(miRefreshQuick)

        ' Attach to the listbox
        lstPrograms.ContextMenuStrip = _ctxPrograms

        ' Optional: show the context menu on right-click even if an item wasn’t selected yet
        AddHandler lstPrograms.MouseUp, AddressOf lstPrograms_MouseUp_SelectOnRightClick
    End Sub

    Private Sub lstPrograms_MouseUp_SelectOnRightClick(sender As Object, e As MouseEventArgs)
        If e.Button <> MouseButtons.Right Then Return

        Dim index As Integer = lstPrograms.IndexFromPoint(e.Location)
        If index >= 0 AndAlso index < lstPrograms.Items.Count Then
            lstPrograms.SelectedIndex = index
        End If
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        tbTest1.Text = ReliableSql.Query("SELECT TOP 1 Version FROM VersionInfo ORDER BY KeyID DESC;")
    End Sub

    Private Sub AdvantageDataRefresh(FiredBy As String)
        tbTest1.Text = FiredBy


        Try
            ' ================================
            ' 1) APP OPTIONS
            ' ================================
            dgvAppOptions.Rows.Clear()

            Dim qApp As Object = ReliableSql.Query("SELECT OptionName, OptionValue FROM AppOptions")
            Dim dsApp As DataSet = TryCast(qApp, DataSet)

            If dsApp IsNot Nothing AndAlso dsApp.Tables.Count > 0 AndAlso dsApp.Tables(0).Rows.Count > 0 Then
                dbAppOptions = dsApp
                For Each row As DataRow In dsApp.Tables(0).Rows
                    dgvAppOptions.Rows.Add(row.ItemArray)
                Next
            Else
                dbAppOptions = New DataSet() ' keep variable safe
            End If



            ' ================================
            ' 2) WEB OPTIONS
            ' ================================
            dgvWebOptions.Rows.Clear()

            Dim qWeb As Object = ReliableSql.Query("SELECT OptionName, OptionValue FROM WebOptions")
            Dim dsWeb As DataSet = TryCast(qWeb, DataSet)

            If dsWeb IsNot Nothing AndAlso dsWeb.Tables.Count > 0 AndAlso dsWeb.Tables(0).Rows.Count > 0 Then
                dbWebOptions = dsWeb
                For Each row As DataRow In dsWeb.Tables(0).Rows
                    dgvWebOptions.Rows.Add(row.ItemArray)
                Next
            Else
                dbWebOptions = New DataSet()
            End If



            ' ================================
            ' 3) APPLICATION INFO
            ' ================================
            dgvApplicationInfo.Rows.Clear()

            Dim qInfo As Object = ReliableSql.Query("SELECT * FROM ApplicationInfo")
            Dim dsInfo As DataSet = TryCast(qInfo, DataSet)

            If dsInfo IsNot Nothing AndAlso dsInfo.Tables.Count > 0 AndAlso dsInfo.Tables(0).Rows.Count > 0 Then
                dbApplicationInfo = dsInfo
                Dim t As DataTable = dsInfo.Tables(0)
                Dim firstRow As DataRow = t.Rows(0)

                ' Add rows: ColName | Value
                For i = 0 To t.Columns.Count - 1
                    dgvApplicationInfo.Rows.Add(t.Columns(i).ColumnName, firstRow(i).ToString())
                Next
            Else
                dbApplicationInfo = New DataSet()
            End If


        Catch oce As OperationCanceledException
            MessageBox.Show("Database operation canceled by user.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ErrorHandler.ErrorHandler("Error refreshing option grids: " & ex.Message, ex.StackTrace)
        End Try

    End Sub

    Private Sub DisableDatabaseSections()
        tbPcDbSize.Text = "Offline"
        tbPcSqlVersion.Text = "Offline"
        dgvAppOptions.DataSource = Nothing
        ' disable refresh buttons etc.
        tpAdvData.Enabled = False
        tpDbLogs.Enabled = False
        pnlDbData.Enabled = False
        pnlDbInfoButtons.Enabled = False

    End Sub


End Class