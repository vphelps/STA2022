Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.ServiceProcess
Imports STA2.AppData


Public Class FormMain
    Private _options As AppOptions
    Private _launcherConfig As LauncherConfig
    Private _defaultsApplied As Boolean = False
    Private _liveOutputManager As LiveOutputManager
    Private _quickLaunchManager As QuickLaunchManager
    Private _flavorManager As FlavorSelectionManager

    Public Sub New(options As AppOptions, launcher As LauncherConfig)
        InitializeComponent()     ' Designer-required

        ' Use constructor-provided options/config (no reload in Load event).
        _options = options
        _launcherConfig = launcher

        ' Setup UI using the loaded config
        RefreshProgramsList()
        FillComboFromListBox()

        ' Render Quick Launch buttons after options/config are available
        FillComboFromListBox()

        ' Window title from options (if any)
        If Not String.IsNullOrWhiteSpace(_options.WindowTitle) Then
            Me.Text = _options.WindowTitle
        End If
    End Sub

    Public Shared ServiceControlList As New List(Of ServiceControlEntry)
    Public Shared LastServiceEntry As ServiceControlEntry

    Public Enum AppInstallState
        NotInstalled = 0
        InstalledX86 = 1
        InstalledX64 = 2
    End Enum

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        flpQuickLaunch.AllowDrop = True

        ' Live output manager
        _liveOutputManager = New LiveOutputManager(Me, rtbLiveOutput, gbLiveOutput)

        ' Quick Launch manager
        _quickLaunchManager = New QuickLaunchManager(
    panel:=flpQuickLaunch,
    options:=_options,
    launcherConfig:=_launcherConfig,
    toolTip:=ToolTipForQuickButtons,
    launchCallback:=AddressOf ProgramLauncher.Launch
)
        _flavorManager = New FlavorSelectionManager(
    options:=_options,
    sqlFilesList:=clbSqlFiles,
    applyCommandTextBox:=tbFlavorApplyCommand,
    startCommandTextBox:=tbDatabaseStartCommand
)

        _flavorManager.LoadFilesWithDefaults(_options.FlavorFolderPath)

        ' Render Quick Launch buttons
        _quickLaunchManager.Refresh()

        ' ✅ STEP 3: attach Quick Launch context menu (assign / clear slots)
        _quickLaunchManager.EnsureContextMenu(
        lstPrograms:=lstPrograms,
        refreshComboCallback:=AddressOf FillComboFromListBox
    )

        ' ---- existing code continues below ----
        If Variables.OfflineMode Then
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
        CodeHelper.Refresher()

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
        'btnTest.Visible = False
#End If

        btnAdvUpgrade.Visible = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvUpgrade"))
        btnAdvRedeem.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvRedeem"))
        btnAdvCardTech.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvCardTech"))
        btnAdvReportEditor.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvReportEditor"))
        btnAdvManager.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvManager"))
        btnPos.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("Pos"))
        btnAdvGroups.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvGroups"))
        btnAdvKioskSetup.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvKioskSetup"))
        btnAdvKiosk.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvKiosk"))

        tbWindowTitle.Text = _options.WindowTitle

        If _options IsNot Nothing AndAlso
   Not String.IsNullOrWhiteSpace(_options.RepoFolderPath) Then

            tbRepoFolder.Text = _options.RepoFolderPath
            _flavorManager.LoadFilesWithDefaults(_options.FlavorFolderPath)
        End If

        If _options IsNot Nothing Then
            tbSetupSwitches.Text = _options.SetupSwitches

            If _options IsNot Nothing Then
                tbDatabaseStartDefault.Text = Trim(_options.StartDatabaseDefault)
                tbApplyFlavorDefault.Text = Trim(_options.ApplyFlavorDefault)
            End If
        End If


        If IsRunningAsAdmin() Then
            btnAdminRestart.Enabled = False
            btnAdminRestart.Text = "Running as Admin"
        Else
            btnAdminRestart.Enabled = True
            btnAdminRestart.Text = "Restart as Administrator"
        End If

        tslblExecutionStatus.Text = ""
        tslblExecutionStatus.Visible = False

    End Sub


    Private Sub FormMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
#If DEBUG Then
        tcSTA.SelectedTab = tpQATools
#End If
    End Sub

    Private Sub tbLocName_GotFocus(sender As Object, e As EventArgs) Handles tbLocName.GotFocus, tbLicSvr.GotFocus, tbCoreSvr.GotFocus, tbDbVer.GotFocus, tbWebEnabled.GotFocus, tbShiftDate.GotFocus
        gpLicInfo.Select()
    End Sub

    Private Sub tmr10Seconds_Tick(sender As Object, e As EventArgs) Handles tmr10Seconds.Tick
        Dim info = ServiceIntrospection.GetServiceFileInfo("AdvCoreService")
        tslblCeVersion.Text = "Version:  " + info.Version

        CodeHelper.Refresher()
        If Not PCInfo.ValidDatabase Then
            tpAdvData.Enabled = False
            tpDbInfo.Enabled = False
            tpGeneral.Enabled = False
            tpDbLogs.Enabled = False
        Else
            tpAdvData.Enabled = True
            tpDbInfo.Enabled = True
            tpGeneral.Enabled = True
            tpDbLogs.Enabled = True
        End If
    End Sub

    Private Sub tmr1Sec_Tick(sender As Object, e As EventArgs) Handles tmr1Sec.Tick

        Dim baseInstallerPath As String = AppData.UpgradePath
        Dim latestFolder = GetLatestVersionFolder(baseInstallerPath)
        Dim installerPath = FindInstallerFile(latestFolder)



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
        Services.ServicesExistCheck()

        If _options IsNot Nothing Then tbSetupSwitches.Text = _options.SetupSwitches


    End Sub

    Private Sub btnDbInfoRefresh_Click(sender As Object, e As EventArgs) Handles btnDbInfoRefresh.Click
        If Variables.OfflineMode Then Return

        If Not (rbDbTableSize.Checked Or rbDbFragmentation.Checked Or rbDbSizeByDay.Checked Or rbDbDeadlocks.Checked) Then
            Return
        End If

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

            ' ---- SafeDb wrapper ----
            Dim ds As DataSet = SafeDb.TryQuery(query)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                dgvDbTableSize.DataSource = ds.Tables(0)
            Else
                dgvDbTableSize.DataSource = Nothing
            End If

            dgvDbTableSize.Refresh()

        Catch ex As SafeDb.DatabaseOfflineException
            GoOffline("Lost DB connection during DbInfoRefresh")
            dgvDbTableSize.DataSource = Nothing

        Catch ex As Exception
            MessageBox.Show(
            $"Failed to refresh database info:{Environment.NewLine}{ex.Message}",
            "Database Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )
            dgvDbTableSize.DataSource = Nothing

        Finally
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
        If Variables.OfflineMode Then Return

        Try
            If rbWebCloudUpdates.Checked Then

                gpDbLogCount.Text = "Count per table"
                gpDbLogData.Text = "All WebCloudUpdates Entries"

                ' ---- SafeDb ----
                Dim dsCount As DataSet = SafeDb.TryQuery(LogQueries.WebCloudTotalCount)

                If dsCount IsNot Nothing AndAlso dsCount.Tables.Count > 0 Then
                    dgvDbLogCount.DataSource = dsCount.Tables(0)
                    dgvDbLogCount.Columns(0).Visible = False
                    dgvDbLogCount.Columns(1).HeaderText = "Table"
                    dgvDbLogCount.Columns(2).HeaderText = "Count"
                Else
                    dgvDbLogCount.DataSource = Nothing
                End If

                Dim dsData As DataSet = SafeDb.TryQuery(LogQueries.WebCloudUpdates)

                If dsData IsNot Nothing AndAlso dsData.Tables.Count > 0 Then
                    dgvDbLogData.DataSource = dsData.Tables(0)
                Else
                    dgvDbLogData.DataSource = Nothing
                End If

            ElseIf rbMessageLog.Checked Then
                CodeHelper.MsgLogBuilder(MessageLogFilters.Errors, MessageLogFilters.Limit, MessageLogFilters.DateRange)

                gpDbLogCount.Text = "Errors per day"
                gpDbLogData.Text = "MessageLog"

                ' ---- SafeDb ----
                Dim dsErrCount As DataSet = SafeDb.TryQuery(LogQueries.MessageLogErrorCount)

                If dsErrCount IsNot Nothing AndAlso dsErrCount.Tables.Count > 0 Then
                    dgvDbLogCount.DataSource = dsErrCount.Tables(0)
                    dgvDbLogCount.Columns(0).Visible = True
                    dgvDbLogCount.Columns(0).HeaderText = "Date"
                    dgvDbLogCount.Columns(1).HeaderText = "Program"
                    dgvDbLogCount.Columns(2).HeaderText = "Count"
                Else
                    dgvDbLogCount.DataSource = Nothing
                End If

                Dim dsLog As DataSet = SafeDb.TryQuery(LogQueries.MessageLog)

                If dsLog IsNot Nothing AndAlso dsLog.Tables.Count > 0 Then
                    dgvDbLogData.DataSource = dsLog.Tables(0)
                    dgvDbLogData.Sort(dgvDbLogData.Columns(0), ListSortDirection.Descending)
                Else
                    dgvDbLogData.DataSource = Nothing
                End If

            Else
                gpDbLogData.Text = ""
                gpDbLogCount.Text = ""
                Return
            End If

            dgvDbLogData.Refresh()

        Catch ex As SafeDb.DatabaseOfflineException
            GoOffline("Lost DB connection during DbLogRefresh")
            dgvDbLogCount.DataSource = Nothing
            dgvDbLogData.DataSource = Nothing

        Catch ex As Exception
            MessageBox.Show($"Database log refresh failed:{Environment.NewLine}{ex.Message}",
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
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

    Private Sub btnCoreServiceSS_Click(sender As Object, e As EventArgs) Handles btnCoreServiceSS.Click, btnCloudServiceSS.Click, btnApiServiceSS.Click, btnAdvCreditServiceSS.Click, btnAdvTurnstileEngineSS.Click, btnAdvSignageServiceSS.Click, btnAdvNotifyServiceSS.Click, btnAdvLicServiceSS.Click, btnAdvantageUpgradeServiceSS.Click, btnRelayServiceSS.Click
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

    Private Sub btnApiServiceRS_Click(sender As Object, e As EventArgs) Handles btnApiServiceRS.Click, btnCoreServiceRS.Click, btnCloudServiceRS.Click, btnAdvTurnstileEngineRS.Click, btnAdvSignageServiceRS.Click, btnAdvNotifyServiceRS.Click, btnAdvLicServiceRS.Click, btnAdvCreditServiceRS.Click, btnAdvantageUpgradeServiceRS.Click, btnRelayServiceRS.Click
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

    Private Sub tbCoreService_GotFocus(sender As Object, e As EventArgs) Handles tbCoreService.GotFocus, tbCoreService.GotFocus, tbCloudService.GotFocus, tbAdvCreditService.GotFocus, tbAdvSignageService.GotFocus, tbAdvLicService.GotFocus, tbAdvNotifyService.GotFocus, tbAdvTurnstileEngine.GotFocus, tbAdvantageUpgradeService.GotFocus, tbRelayService.GotFocus
        Dim caller As TextBox = DirectCast(sender, TextBox)
        caller.SelectionStart = 0
        caller.SelectionLength = 0
    End Sub

    Private Sub tcSTA_Click(sender As Object, e As EventArgs) Handles tcSTA.Click
        btnDbLogRefresh.PerformClick()
        btnDbInfoRefresh.PerformClick()
    End Sub

    Private Sub btnAdvManager_Click(sender As Object, e As EventArgs) Handles btnAdvManager.Click, btnPos.Click, btnAdvGroups.Click, btnAdvReportEditor.Click, btnAdvRedeem.Click, btnAdvCardTech.Click, btnAdvKiosk.Click, btnAdvKioskSetup.Click
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
            writer.WriteLine("OptionName,OptionValue")
            For Each row As DataGridViewRow In dgvSource.Rows
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
            Services.ServicesExistCheck()

        Else
            TabName = tcSTA.SelectedTab.Name
        End If
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click, lstPrograms.DoubleClick
        Dim entry = TryCast(lstPrograms.SelectedItem, ProgramEntry)
        If entry Is Nothing Then
            MessageBox.Show("Select a program to edit.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dlg As New EditProgramForm()
            Dim clone As New ProgramEntry With {
                .Id = entry.Id,
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

                SaveLauncher()
                RefreshProgramsList(preserveSelection:=True)
                FillComboFromListBox()
            End If
        End Using
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Using dlg As New EditProgramForm()
            dlg.Entry = New ProgramEntry() With {.Enabled = True}

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                If _launcherConfig Is Nothing Then
                    _launcherConfig = New LauncherConfig()
                End If

                If _launcherConfig.Programs Is Nothing Then
                    _launcherConfig.Programs = New List(Of ProgramEntry)()
                End If

                _launcherConfig.Programs.Add(dlg.Entry)

                SaveLauncher()
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

            SaveLauncher()
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
        Finally
            Cursor.Current = Cursors.Default
            btnBatchLaunch.Enabled = True
        End Try
    End Sub

    Private Sub tbWindowTitle_TextChanged(sender As Object, e As EventArgs) Handles tbWindowTitle.TextChanged
        _options.WindowTitle = tbWindowTitle.Text
    End Sub


    Private Sub btnAdminRestart_Click(sender As Object, e As EventArgs) Handles btnAdminRestart.Click
        If IsRunningAsAdmin() Then
            MessageBox.Show("Already running as Administrator.")
            Return
        End If

        Try
            Dim exePath As String = Application.ExecutablePath

            Dim psi As New ProcessStartInfo(exePath)
            psi.Verb = "runas"
            psi.UseShellExecute = True

            Process.Start(psi)

            Application.Exit()
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
            OptionsManager.SaveLauncherConfig(_launcherConfig)
        Catch ex As Exception
        End Try

        Try
            If _options IsNot Nothing Then

                _options.SetupSwitches = tbSetupSwitches.Text
                _options.ApplyFlavorDefault = Trim(tbApplyFlavorDefault.Text)
                _options.StartDatabaseDefault = Trim(tbDatabaseStartDefault.Text)
                OptionsManager.Save(_options)
            End If
        Catch
        End Try
    End Sub

    Private Sub btnReconnect_Click(sender As Object, e As EventArgs) Handles btnReconnect.Click
        Cursor.Current = Cursors.WaitCursor
        btnReconnect.Enabled = False

        Try
            ' Test database connection using your existing helper
            If TestConnection(ConfigValues.ConnectionString) Then
                ' Successful reconnect
                GoOnline()
                MessageBox.Show("Reconnected to the database.",
                            "Database",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Else
                ' Still offline
                MessageBox.Show("Still cannot connect to the database.",
                            "Database",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show($"Reconnect failed: {ex.Message}",
                        "Database",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        Finally
            btnReconnect.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click, btnTaskmgr.Click, btnEventViewer.Click, btnDevices.Click, btnAppWiz.Click, btnServices.Click

        Dim caller As System.Windows.Forms.Button = DirectCast(sender, System.Windows.Forms.Button)
        Dim Executable As String = caller.Name.Replace("btn", "")
        If Executable = "AppWiz" Then
            Process.Start("control.exe", "appwiz.cpl")
        ElseIf Executable = "Services" Then
            Dim psi As New ProcessStartInfo("services.msc")
            psi.UseShellExecute = True
            psi.Verb = "runas"
            Process.Start(psi)
        ElseIf Executable = "Devices" Then
            Process.Start("control.exe", "/name Microsoft.DevicesAndPrinters")
        ElseIf Executable = "EventViewer" Then
            Process.Start("eventvwr.msc")
        Else
            Diagnostics.Process.Start(Executable)
        End If





    End Sub

    Private Sub btnRepoFolder_Click(sender As Object, e As EventArgs) Handles btnRepoFolder.Click


        Using dlg As New FolderBrowserDialog()

            dlg.Description = "Select the repository folder"
            dlg.ShowNewFolderButton = False

            ' Optional: start at the previously saved folder
            If _options IsNot Nothing AndAlso
           Not String.IsNullOrWhiteSpace(_options.RepoFolderPath) AndAlso
           IO.Directory.Exists(_options.RepoFolderPath) Then

                dlg.SelectedPath = _options.RepoFolderPath
            End If

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                Dim RepoFolderPath As String = dlg.SelectedPath

                ' Update options object
                _options.RepoFolderPath = RepoFolderPath
                ' Persist to options.json
                OptionsManager.Save(_options)

                ' Optional: show in UI
                tbRepoFolder.Text = RepoFolderPath

                _flavorManager.LoadFilesWithDefaults(_options.FlavorFolderPath)
            End If
        End Using
    End Sub

    Private Sub btnLaunchLatestInstaller_Click(sender As Object, e As EventArgs) Handles btnLaunchLatestInstaller.Click

        Dim baseInstallerPath As String = AppData.UpgradePath

        Dim latestFolder = GetLatestVersionFolder(baseInstallerPath)
        If latestFolder Is Nothing Then
            MessageBox.Show("No valid installer folders found.")
            Return
        End If

        Dim installerPath = FindInstallerFile(latestFolder)
        If String.IsNullOrWhiteSpace(installerPath) OrElse
       Not IO.File.Exists(installerPath) Then

            MessageBox.Show("Installer not found in: " & latestFolder.FullName)
            Return
        End If

        ' Optional: run as admin
        Dim psi As New ProcessStartInfo(installerPath) With {
        .UseShellExecute = True,
        .Arguments = tbSetupSwitches.Text,
        .Verb = "runas"
    }
        Process.Start(psi)


    End Sub

    Private Sub tbSetupSwitches_TextChanged(sender As Object, e As EventArgs) Handles tbSetupSwitches.TextChanged

        If _options Is Nothing Then Return

        _options.SetupSwitches = tbSetupSwitches.Text
        OptionsManager.Save(_options)


    End Sub

    Private Sub clbSqlFiles_Enter(sender As Object, e As EventArgs) _
    Handles clbSqlFiles.Enter

        _flavorManager.RefreshPreservingSelection()
    End Sub


    Private Sub btnSaveFlavorDefaults_Click(sender As Object, e As EventArgs) _
    Handles btnSaveFlavorDefaults.Click

        _flavorManager.SaveDefaults()

        MessageBox.Show(
        "Selected flavors have been saved as defaults.",
        "Defaults Saved",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information)
    End Sub

    Private Sub btnResetFlavorDefaults_Click(sender As Object, e As EventArgs) _
    Handles btnResetFlavorDefaults.Click

        If MessageBox.Show(
        "This will clear your current selections and reapply default flavors." &
        Environment.NewLine & "Continue?",
        "Reset to Defaults",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        _flavorManager.ResetToDefaults()
    End Sub

    Private Sub tbDatabaseStartDefault_TextChanged(sender As Object, e As EventArgs) Handles tbDatabaseStartDefault.TextChanged

        If _options Is Nothing Then Return
        _options.StartDatabaseDefault = Trim(tbDatabaseStartDefault.Text)
        OptionsManager.Save(_options)
        _flavorManager.UpdateFlavorCommands(
            tbApplyFlavorDefault.Text,
            tbDatabaseStartDefault.Text
        )
    End Sub


    Private Sub tbApplyFlavorDefault_TextChanged(sender As Object, e As EventArgs) Handles tbApplyFlavorDefault.TextChanged

        If _options Is Nothing Then Return
        _options.ApplyFlavorDefault = Trim(tbApplyFlavorDefault.Text)

        OptionsManager.Save(_options)
        _flavorManager.UpdateFlavorCommands(
            tbApplyFlavorDefault.Text,
            tbDatabaseStartDefault.Text
        )
    End Sub

    Private Sub clbSqlFiles_ItemCheck(sender As Object, e As ItemCheckEventArgs) _
    Handles clbSqlFiles.ItemCheck

        BeginInvoke(Sub()
                        _flavorManager.UpdateFlavorCommands(
            tbApplyFlavorDefault.Text,
            tbDatabaseStartDefault.Text)
                    End Sub)
    End Sub

    Private Async Sub btnRunApplyFlavorLive_Click(
    sender As Object,
    e As EventArgs
) Handles btnRunApplyFlavorLive.Click

        Dim flavorArgs As String =
        CodeHelper.BuildFlavorsArgument(
            _flavorManager.GetSelectedFlavorNames())

        Await PowerShellRunner.RunLiveScriptAsync(
        options:=_options,
        liveOutputManager:=_liveOutputManager,
        setStatus:=Sub(text)
                       CodeHelper.SetExecutionStatus(
                           owner:=Me,
                           statusLabel:=tslblExecutionStatus,
                           text:=text)
                   End Sub,
        triggerButton:=btnRunApplyFlavorLive,
        scriptRelativePath:="tests\apply-flavors.ps1",
        scriptArgs:=flavorArgs,
        runningStatusText:="Applying flavors (live output)…"
    )
    End Sub

    Private Async Sub btnRunDatabaseStartLive_Click(
    sender As Object,
    e As EventArgs
) Handles btnRunDatabaseStartLive.Click

        Dim flags As String = "-Force"
        Dim flavorArgs As String =
    CodeHelper.BuildFlavorsArgument(
        _flavorManager.GetSelectedFlavorNames())

        Dim scriptArgs As String = $"{flags} {flavorArgs}".Trim()

        Await PowerShellRunner.RunLiveScriptAsync(
            options:=_options,
            liveOutputManager:=_liveOutputManager,
        setStatus:=Sub(text)
                       CodeHelper.SetExecutionStatus(
                           owner:=Me,
                           statusLabel:=tslblExecutionStatus,
                           text:=text)
                   End Sub,
            triggerButton:=btnRunDatabaseStartLive,
            scriptRelativePath:="tests\Start-Database.ps1",
            scriptArgs:=scriptArgs,
            runningStatusText:="Starting database (live output)…"
        )
    End Sub

    Private Sub AppendColoredOutput(text As String, color As Color)
        If rtbLiveOutput.InvokeRequired Then
            rtbLiveOutput.Invoke(Sub() AppendColoredOutput(text, color))
            Return
        End If

        Dim start = rtbLiveOutput.TextLength
        rtbLiveOutput.AppendText(text & Environment.NewLine)
        Dim length = rtbLiveOutput.TextLength - start

        rtbLiveOutput.Select(start, length)
        rtbLiveOutput.SelectionColor = color
        rtbLiveOutput.SelectionLength = 0
        rtbLiveOutput.ScrollToCaret()
    End Sub

    Private Function GetLatestVersionFolder(basePath As String) As DirectoryInfo

        If Not IO.Directory.Exists(basePath) Then
            Return Nothing
        End If

        Dim versionFolders =
            From dir In New IO.DirectoryInfo(basePath).GetDirectories()
            Let versionText = dir.Name.Replace("Version", "").Trim()
            Let parsedVersion = ParseVersionSafe(versionText)
            Where parsedVersion IsNot Nothing
            Order By parsedVersion Descending
            Select dir

        Return versionFolders.FirstOrDefault()

    End Function
    Private Function ParseVersionSafe(versionText As String) As Version
        Try
            Return New Version(versionText)
        Catch
            Return Nothing
        End Try
    End Function
    Private Function FindInstallerFile(versionFolder As IO.DirectoryInfo) As String

        If versionFolder Is Nothing Then Return Nothing

        Dim installers =
            versionFolder.GetFiles("AdvantageSetup-x64.exe").
            Union(versionFolder.GetFiles("*.msi"))

        Return installers.FirstOrDefault()?.FullName

    End Function

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

        ' Safety checks
        If lstPrograms Is Nothing OrElse _options Is Nothing Then Return

        ' Build a lookup of assigned QuickLaunch Ids
        Dim assignedIds As HashSet(Of String)

        If _options.QuickLaunchIds IsNot Nothing Then
            assignedIds = New HashSet(Of String)(
            _options.QuickLaunchIds.
                Where(Function(id) Not String.IsNullOrWhiteSpace(id)),
            StringComparer.OrdinalIgnoreCase
        )
        Else
            assignedIds = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        End If

        ' Add only unassigned programs to ComboBox
        For Each entry As ProgramEntry In lstPrograms.Items
            If entry Is Nothing Then Continue For
            If String.IsNullOrWhiteSpace(entry.Id) Then Continue For

            ' Exclude programs already assigned to Quick Launch
            If assignedIds.Contains(entry.Id) Then Continue For

            cmbboxAppLaunch.Items.Add(entry)
        Next

        cmbboxAppLaunch.DisplayMember = "Name"

    End Sub
    Private Sub LaunchFromUI(sender As Object, e As EventArgs) Handles btnLaunch.Click, btnComboAppLaunch.Click
        Dim entry As ProgramEntry = Nothing

        If sender Is btnLaunch OrElse sender Is lstPrograms Then
            entry = TryCast(lstPrograms.SelectedItem, ProgramEntry)
        ElseIf sender Is btnComboAppLaunch Then
            entry = TryCast(cmbboxAppLaunch.SelectedItem, ProgramEntry)
        End If

        ProgramLauncher.Launch(entry)
    End Sub

    Private Sub SaveLauncher(Optional syncFromList As Boolean = False)
        If syncFromList Then
            _launcherConfig.Programs = lstPrograms.Items.Cast(Of ProgramEntry)().ToList()
        End If
        OptionsManager.SaveLauncherConfig(_launcherConfig)
    End Sub

    Private Sub DisableDatabaseSections()
        tbPcDbSize.Text = "Offline"
        tbPcSqlVersion.Text = "Offline"
        dgvAppOptions.DataSource = Nothing
        tpAdvData.Enabled = False
        tpDbLogs.Enabled = False
        pnlDbData.Enabled = False
        pnlDbInfoButtons.Enabled = False
    End Sub
    Public Sub GoOffline(reason As String)
        Variables.OfflineMode = True
        PCInfo.ValidDatabase = False

        DisableDatabaseSections()

        ' --- Status indicator ---
        If tslblDbState IsNot Nothing Then
            tslblDbState.Text = "OFFLINE"
            tslblDbState.ForeColor = Color.White
            tslblDbState.BackColor = Color.Firebrick   ' for OFFLINE
        End If

    End Sub
    Public Sub GoOnline()
        Variables.OfflineMode = False
        PCInfo.ValidDatabase = True

        EnableDatabaseSections()

        ' Refresh UI
        CodeHelper.GetPcInfo()
        CodeHelper.FirstLoad()
        CodeHelper.Refresher()

        ' --- Status indicator ---
        If tslblDbState IsNot Nothing Then
            tslblDbState.Text = "ONLINE"
            tslblDbState.ForeColor = Color.WhiteSmoke
            tslblDbState.BackColor = Color.DarkGreen   ' for ONLINE
        End If

    End Sub
    Private Sub EnableDatabaseSections()
        tpAdvData.Enabled = True
        tpDbLogs.Enabled = True
        pnlDbData.Enabled = True
        pnlDbInfoButtons.Enabled = True

        ' Clear the offline placeholders
        tbPcDbSize.Text = ""
        tbPcSqlVersion.Text = ""


    End Sub

    Private Function TestConnection(cs As String) As Boolean
        Try
            Using cn As New SqlClient.SqlConnection(cs)
                cn.Open()
                Return (cn.State = ConnectionState.Open)
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Sub AdvantageDataRefresh(FiredBy As String)

        Try
            ' --------------------------
            ' AppOptions
            ' --------------------------
            dgvAppOptions.Rows.Clear()

            Dim dsApp As DataSet = SafeDb.TryQuery("SELECT OptionName, OptionValue FROM AppOptions")
            If dsApp IsNot Nothing AndAlso dsApp.Tables.Count > 0 Then
                dbAppOptions = dsApp

                For Each row As DataRow In dsApp.Tables(0).Rows
                    dgvAppOptions.Rows.Add(row.ItemArray)

                    ' ✅ NEW: Capture UpgradePath
                    If String.Equals(row("OptionName").ToString(),
                         "UpgradePath",
                         StringComparison.OrdinalIgnoreCase) Then

                        AppData.UpgradePath = row("OptionValue").ToString()
                    End If
                Next
            Else
                dbAppOptions = New DataSet()
            End If
            ' --------------------------
            ' WebOptions
            ' --------------------------
            dgvWebOptions.Rows.Clear()

            Dim dsWeb As DataSet = SafeDb.TryQuery("SELECT OptionName, OptionValue FROM WebOptions")
            If dsWeb IsNot Nothing AndAlso dsWeb.Tables.Count > 0 Then
                dbWebOptions = dsWeb
                For Each row As DataRow In dsWeb.Tables(0).Rows
                    dgvWebOptions.Rows.Add(row.ItemArray)
                Next
            Else
                dbWebOptions = New DataSet()
            End If

            ' --------------------------
            ' ApplicationInfo
            ' --------------------------
            dgvApplicationInfo.Rows.Clear()

            Dim dsInfo As DataSet = SafeDb.TryQuery("SELECT * FROM ApplicationInfo")
            If dsInfo IsNot Nothing AndAlso dsInfo.Tables.Count > 0 Then
                dbApplicationInfo = dsInfo
                Dim t As DataTable = dsInfo.Tables(0)
                Dim firstRow As DataRow = t.Rows(0)

                For i = 0 To t.Columns.Count - 1
                    dgvApplicationInfo.Rows.Add(t.Columns(i).ColumnName, firstRow(i).ToString())
                Next
            Else
                dbApplicationInfo = New DataSet()
            End If

        Catch ex As SafeDb.DatabaseOfflineException
            ' ---- SWITCH TO OFFLINE MODE ----
            GoOffline("Lost DB connection during AdvantageDataRefresh")
            Exit Sub

        Catch ex As Exception
            ' ---- No more ErrorHandler ----
            ' Instead we gracefully fall to offline mode.
            GoOffline("Database failure in AdvantageDataRefresh: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Function BuildOptionalFlags(ParamArray flags As String()) As String
        If flags Is Nothing OrElse flags.Length = 0 Then Return ""

        Return String.Join(" ",
                           flags.Where(Function(f) Not String.IsNullOrWhiteSpace(f)))
    End Function

End Class