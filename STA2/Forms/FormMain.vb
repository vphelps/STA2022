Imports System.ComponentModel
Imports System.IO
Imports System.ServiceProcess
Imports System.Threading.Tasks
Imports STA2.AppData


Public Class FormMain
    Private _options As AppOptions
    Private _launcherConfig As LauncherConfig
    Private _liveOutputManager As LiveOutputManager
    Private _quickLaunchManager As QuickLaunchManager
    Private _flavorManager As FlavorSelectionManager
    Private _executionStatusLocked As Boolean = False

    Private ReadOnly _serviceNames As String() = {
    "AdvApiServer",
    "AdvCoreService",
    "AdvantageCloudSyncService",
    "AdvCreditService",
    "AdvLicService",
    "AdvSignageService",
    "AdvTurnstileEngine",
    "AdvNotifyService",
    "AdvantageUpgradeService",
    "AdvRelayClient"
}
    Private ReadOnly _serviceRows As New List(Of ServiceRowControl)
    Private _serviceManager As ServiceManager

    Private Sub EnableDoubleBuffering(ctrl As Control)
        Dim prop = ctrl.GetType().GetProperty(
        "DoubleBuffered",
        Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance
    )
        prop?.SetValue(ctrl, True, Nothing)
    End Sub

    Private Sub BuildServicesUI()

        ' ✅ Suspend layout and painting while building rows
        tblServices.SuspendLayout()

        tblServices.Controls.Clear()
        tblServices.RowStyles.Clear()
        tblServices.RowCount = 0
        _serviceRows.Clear()

        For Each serviceName In _serviceNames

            Dim row As New ServiceRowControl() With {
            .ServiceName = serviceName
        }

            ' Fill the table cell so width is granted by the parent
            row.Dock = DockStyle.Fill
            row.Margin = New Padding(0, 0, 0, 4)

            ' Wire button intent events
            AddHandler row.StartRequested, AddressOf OnStartServiceRequested
            AddHandler row.StopRequested, AddressOf OnStopServiceRequested
            AddHandler row.RestartRequested, AddressOf OnRestartServiceRequested

            tblServices.RowCount += 1
            tblServices.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            tblServices.Controls.Add(row, 0, tblServices.RowCount - 1)

            _serviceRows.Add(row)

        Next

        ' ✅ One single layout pass + repaint
        tblServices.ResumeLayout(True)

    End Sub

    Private Sub WireServiceRow(row As ServiceRowControl)

        AddHandler row.StartRequested,
        Sub(svc) OnStartServiceRequested(svc)

        AddHandler row.StopRequested,
        Sub(svc) OnStopServiceRequested(svc)

        AddHandler row.RestartRequested,
        Sub(svc) OnRestartServiceRequested(svc)

    End Sub

    Public Sub New(options As AppOptions, launcher As LauncherConfig)
        InitializeComponent()     ' Designer-required

        ' Use constructor-provided options/config (no reload in Load event).
        _options = options
        _launcherConfig = launcher

        ' Setup UI using the loaded config
        RefreshProgramsList()
        FillComboFromListBox()

        ' Window title from options (if any)
        If Not String.IsNullOrWhiteSpace(_options.WindowTitle) Then
            Me.Text = _options.WindowTitle
        End If
    End Sub
    Public Enum AppInstallState
        NotInstalled = 0
        InstalledX86 = 1
        InstalledX64 = 2
    End Enum
    Private Sub SetExecutionStatus(text As String, Optional force As Boolean = False)

        If Not _executionStatusLocked OrElse force Then
            tslblExecutionStatus.Text = text
        End If

    End Sub
    Private Sub InitializeFlavors()

        If _options Is Nothing Then Return

        Dim path = _options.FlavorFolderPath

        If String.IsNullOrWhiteSpace(path) OrElse
       Not IO.Directory.Exists(path) Then

            clbSqlFiles.Items.Clear()
            Return
        End If

        _flavorManager.LoadFilesWithDefaults(path)
        _flavorManager.ApplySavedDefaults(_options.DefaultFlavorNames)

    End Sub

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

        ' --------------------------------------------------
        ' Flavor selection manager (FIXED AND CORRECT)
        ' --------------------------------------------------
        _flavorManager = New FlavorSelectionManager(
        options:=_options,
        sqlFilesList:=clbSqlFiles,
        applyCommandTextBox:=tbFlavorApplyCommand,
        startCommandTextBox:=tbDatabaseStartCommand
    )

        ' Render Quick Launch buttons
        _quickLaunchManager.Refresh()

        ' Restore persisted "Show hidden services" option
        chkShowHiddenServices.Checked = _options.ShowHiddenServices

        ' Attach Quick Launch context menu
        _quickLaunchManager.EnsureContextMenu(
        lstPrograms:=lstPrograms,
        refreshComboCallback:=AddressOf FillComboFromListBox
    )

        If Variables.OfflineMode Then
            DatabaseCoordinator.DisableDatabaseSections(Me)
        End If

        CodeHelper.GetPcInfo()
        Connections.IniFileHandler(False)
        CodeHelper.FirstLoad()
        CodeHelper.Refresher()

        rbDbTableSize.Checked = True
        rbMessageLog.Checked = True
        btnDbInfoRefresh.PerformClick()
        gpMessageLogFilters.Enabled = rbMessageLog.Checked
        btnDbLogRefresh.PerformClick()

        DatabaseCoordinator.EvaluateDatabaseAvailability(
        form:=Me,
        connectionString:=ConfigValues.ConnectionString,
        configuredContainerName:=_options?.SqlContainerName
    )

        ' Excel detection
        Try
            My.Computer.Registry.ClassesRoot _
            .OpenSubKey("Excel.Application", False) _
            .OpenSubKey("CurVer", False)
            PCInfo.ExcelInstalled = True
        Catch
            PCInfo.ExcelInstalled = False
        End Try

#If Not DEBUG Then
    tbTest1.Visible = False
    tbTest2.Visible = False
    tbTest3.Visible = False
    tbMLTest1.Visible = False
    btnTest1.Visible = False
    btnTest2.Visible = False
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

        If _options IsNot Nothing Then
            tbRepoFolder.Text = _options.RepoFolderPath
            tbSetupSwitches.Text = _options.SetupSwitches
            tbDatabaseStartDefault.Text = Trim(_options.StartDatabaseDefault)
            tbApplyFlavorDefault.Text = Trim(_options.ApplyFlavorDefault)
        End If

        If IsRunningAsAdmin() Then
            btnAdminRestart.Enabled = False
            btnAdminRestart.Text = "Running as Admin"
        Else
            btnAdminRestart.Enabled = True
            btnAdminRestart.Text = "Restart as Administrator"
        End If

        SetExecutionStatus(String.Empty)

        Dim discoveredContainer =
        DatabaseCoordinator.DiscoverSqlContainerName(_options.SqlContainerName)

        tbTest2.Text = If(
        String.IsNullOrWhiteSpace(discoveredContainer),
        "(No SQL container found)",
        discoveredContainer
    )

        DatabaseCoordinator.RefreshAdvantageData(Me)
        EnableDoubleBuffering(tblServices)

    End Sub

    Private Sub FormMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        ' -------------------------------------------------
        ' Select Services tab by default
        ' -------------------------------------------------
        'tcSTA.SelectedTab = tpServices

        ' -------------------------------------------------
        ' Build the Services UI (rows only, no logic)
        ' -------------------------------------------------
        BuildServicesUI()

        ' ✅ STEP 2: Lock label column width based on longest service name
        If _serviceRows.Count > 0 Then

            Dim nameFont As Font =
        _serviceRows(0).lblName.Font

            Dim nameColWidth As Integer =
        ServicesDisplay.MeasureMaxServiceNameWidth(
            _serviceNames,
            nameFont
        )

            For Each row In _serviceRows
                With row.tblLayout.ColumnStyles(1)
                    .SizeType = SizeType.Absolute
                    .Width = nameColWidth
                End With
            Next

        End If
        Dim isAdmin As Boolean = IsRunningAsAdmin()

        For Each row In _serviceRows
            row.IsAdmin = isAdmin
        Next
        ' -------------------------------------------------
        ' Initialize ServiceManager (non-UI logic owner)
        ' -------------------------------------------------
        _serviceManager = New ServiceManager()

        ' -------------------------------------------------
        ' Wire ServiceManager → UI events
        ' -------------------------------------------------

        ' Busy state changes
        AddHandler _serviceManager.ServiceBusyChanged,
        Sub(serviceName, isBusy)
            Me.BeginInvoke(Sub()
                               Dim row = _serviceRows.
                    FirstOrDefault(Function(r) r.ServiceName = serviceName)

                               If row IsNot Nothing Then
                                   row.IsBusy = isBusy
                               End If
                           End Sub)
        End Sub

        ' Status changes (authoritative "installed" signal)
        AddHandler _serviceManager.ServiceStatusChanged,
        Sub(serviceName, status)
            Me.BeginInvoke(Sub()

                               Dim row = _serviceRows.
                    FirstOrDefault(Function(r) r.ServiceName = serviceName)

                               If row Is Nothing Then Return

                               ' Service exists → must be installed & visible
                               row.Installed = True
                               row.IsHidden = False
                               row.Visible = True

                               If Not row.IsBusy Then
                                   row.Status = status
                               End If

                           End Sub)
        End Sub

        ' Operation failures
        AddHandler _serviceManager.ServiceOperationFailed,
        Sub(serviceName, ex)
            Me.BeginInvoke(Sub()
                               MessageBox.Show(
                    $"Service operation failed for '{serviceName}'." &
                    Environment.NewLine & Environment.NewLine &
                    ex.Message,
                    "Service Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
                           End Sub)
        End Sub

        ' Service not installed
        AddHandler _serviceManager.ServiceNotInstalled,
        Sub(serviceName)
            Me.BeginInvoke(Sub()

                               Dim row = _serviceRows.
                    FirstOrDefault(Function(r) r.ServiceName = serviceName)

                               If row Is Nothing Then Return

                               row.Installed = False
                               row.IsHidden = True

                               ' Respect persisted toggle
                               row.Visible = chkShowHiddenServices.Checked

                           End Sub)
        End Sub

        ' -------------------------------------------------
        ' Start background service polling
        ' -------------------------------------------------
        _serviceManager.StartPolling(
            serviceNames:=_serviceNames,
            intervalMilliseconds:=5000
        )

        ' -------------------------------------------------
        ' ✅ OPTION A: Derive FlavorFolderPath from RepoFolderPath
        ' -------------------------------------------------
        If _options IsNot Nothing AndAlso
           String.IsNullOrWhiteSpace(_options.FlavorFolderPath) AndAlso
           Not String.IsNullOrWhiteSpace(_options.RepoFolderPath) Then

            Dim inferredFlavorPath As String =
                IO.Path.Combine(_options.RepoFolderPath, "tests", "flavors")

            If IO.Directory.Exists(inferredFlavorPath) Then
                _options.FlavorFolderPath = inferredFlavorPath
                OptionsManager.Save(_options)
            End If
        End If

        ' -------------------------------------------------
        ' ✅ Initialize flavors now that path is valid
        ' -------------------------------------------------
        InitializeFlavors()
    End Sub

    Private Sub tbLocName_GotFocus(sender As Object, e As EventArgs) Handles tbLocName.GotFocus, tbLicSvr.GotFocus, tbCoreSvr.GotFocus, tbDbVer.GotFocus, tbWebEnabled.GotFocus, tbShiftDate.GotFocus
        gpLicInfo.Select()
    End Sub

    Private Sub tmr10Seconds_Tick(
    sender As Object,
    e As EventArgs
) Handles tmr10Seconds.Tick

        ' Lightweight UI work only
        Dim info = ServiceIntrospection.GetServiceFileInfo("AdvCoreService")
        tslblCeVersion.Text = "Version:  " & info.Version

        CodeHelper.Refresher()

        ' ✅ Fire-and-forget async call (VB style)
#Disable Warning BC42358
        DatabaseCoordinator.EvaluateDatabaseAvailabilityAsync(
    Me,
    ConfigValues.ConnectionString,
    _options?.SqlContainerName
)
#Enable Warning BC42358

        ' ✅ UI enable/disable based on current known DB state
        Dim dbOnline As Boolean = PCInfo.ValidDatabase

        tpAdvData.Enabled = dbOnline
        tpDbInfo.Enabled = dbOnline
        'tpGeneral.Enabled = dbOnline
        tpDbLogs.Enabled = dbOnline

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
        'Services.ServicesExistCheck()

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
            DatabaseCoordinator.GoOffline(Me, "Lost DB connection during DbInfoRefresh")
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
            DatabaseCoordinator.GoOffline(Me, "Lost DB connection during DbLogRefresh")
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

        If Variables.OfflineMode Then
            MessageBox.Show("Database is offline.")
            Return
        End If

        If tcSTA.SelectedTab.Equals(tpAdvData) Then
            If PCInfo.ValidDatabase Then
                DatabaseCoordinator.RefreshAdvantageData(Me)
            End If
        ElseIf tcSTA.SelectedTab.Equals(tpGeneral) Then
            CodeHelper.Refresher()
            'Services.ServicesExistCheck()

        Else
            Dim TabName As String
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
        If _serviceManager IsNot Nothing Then
            _serviceManager.StopPolling()
        End If

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
            DatabaseCoordinator.EvaluateDatabaseAvailability(
            form:=Me,
            connectionString:=ConfigValues.ConnectionString,
            configuredContainerName:=_options?.SqlContainerName
        )

            If Not Variables.OfflineMode Then
                'MessageBox.Show(
                '"Reconnected to the database.",
                '"Database",
                'MessageBoxButtons.OK,
                'MessageBoxIcon.Information)

                UIHelpers.TimedInfoPrompt(message:="Reconnected to the database.", timeoutSeconds:=30, title:="Database")

            End If

        Catch ex As Exception
            '    MessageBox.Show(
            '    $"Reconnect failed: {ex.Message}",
            '    "Database",
            '    MessageBoxButtons.OK,
            '    MessageBoxIcon.Error)

            UIHelpers.TimedErrorPrompt(message:=$"Reconnect failed: {ex.Message}", timeoutSeconds:=0, title:="Database")
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
        If _options Is Nothing Then
            Return
        End If

        _options.StartDatabaseDefault = Trim(tbDatabaseStartDefault.Text)
        OptionsManager.Save(_options)

        _flavorManager.UpdateFlavorCommands(
            tbApplyFlavorDefault.Text,
            tbDatabaseStartDefault.Text
        )
    End Sub


    Private Sub tbApplyFlavorDefault_TextChanged(sender As Object, e As EventArgs) Handles tbApplyFlavorDefault.TextChanged
        If _options Is Nothing Then
            Return
        End If

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
                       SetExecutionStatus(text)
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
                       SetExecutionStatus(text)
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

    Private Sub btnRepoDiscardChanges_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRepoDiscardChanges.Click

        If _options Is Nothing OrElse
           String.IsNullOrWhiteSpace(_options.RepoFolderPath) Then
            MessageBox.Show(
                "Repository path is not configured.",
                "Discard Changes",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Dim repoPath As String = _options.RepoFolderPath

        ' Optional preview
        Dim preview As String = RepoTools.PreviewDiscard(repoPath)

        Dim message As String =
            "This will permanently discard ALL local changes in the repository:" &
            Environment.NewLine & Environment.NewLine &
            repoPath & Environment.NewLine & Environment.NewLine &
            If(String.IsNullOrWhiteSpace(preview),
               "No untracked files will be removed.",
               "The following untracked files will be deleted:" &
               Environment.NewLine & preview) &
            Environment.NewLine & Environment.NewLine &
            "This action CANNOT be undone." &
            Environment.NewLine & Environment.NewLine &
            "Continue?"



        If UIHelpers.TimedYesNoPrompt(
            message:=message,
            title:="Discard All Changes",
            timeoutSeconds:=30) <> DialogResult.Yes Then
            Return
        End If

        Try
            Cursor.Current = Cursors.WaitCursor
            btnRepoDiscardChanges.Enabled = False

            RepoTools.DiscardAllChanges(repoPath)

            UIHelpers.TimedInfoPrompt(
    message:="All local changes were discarded successfully.",
    title:="Discard Complete",
    timeoutSeconds:=10)

        Catch ex As Exception
            UIHelpers.TimedErrorPrompt(
                message:="Git Error",
                title:="Repository")

        Finally
            btnRepoDiscardChanges.Enabled = True
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Async Sub btnSetupInstall_Click(
    sender As Object,
    e As EventArgs
) Handles btnSetupInstall.Click

        btnSetupInstall.Enabled = False

        _executionStatusLocked = True
        SetExecutionStatus("Starting setup installation...", force:=True)

        Dim showTextProgress As Boolean = True

        Dim percentProgress As New Progress(Of Integer)(
        Sub(p)
        End Sub)

        Dim textProgress As New Progress(Of String)(
        Sub(t)
            If showTextProgress Then
                SetExecutionStatus(t)
            End If
        End Sub)

        Try
            ' Resolve setup.zip (with optional browse)
            Dim zipPath As String =
            Await InstallerTools.ResolveSetupZipAsync(
                zipPath:=AppData.UpgradePath,
                promptForZip:=True)

            ' Extract ZIP -> AppData.UpgradePath\Version <InstallerVersion>
            SetExecutionStatus("Preparing extraction...", force:=True)

            Dim extractDir As String =
            Await InstallerTools.ExtractZipToVersionedDirectoryAsync(
                zipPath:=zipPath,
                upgradeBasePath:=AppData.UpgradePath,
                installerName:="AdvantageSetup-x64.exe",
                progressPercent:=percentProgress,
                progressText:=textProgress)

            ' 🔒 stop queued extraction text updates
            showTextProgress = False

            ' Locate installer in the versioned directory
            Dim installerPath As String =
            InstallerTools.FindInstaller(
                baseDir:=extractDir,
                installerName:="AdvantageSetup-x64.exe",
                recursive:=True)

            ' Stable installer-running text
            SetExecutionStatus("Running Installer", force:=True)

            ' Allow UI repaint before UAC / installer steals focus
            Await Task.Yield()

            ' Run installer asynchronously
            Await InstallerTools.RunInstallerAsync(
            installerPath,
            "-skipcoreservicescan -skipcloudsyncservicescan PERFORMDBUPGRADE=1",
            elevate:=True,
            progressText:=textProgress)

            SetExecutionStatus("Installation complete.", force:=True)
            Await Task.Delay(1500)

        Catch ex As FileNotFoundException
            ' User canceled ZIP selection → silent exit

        Catch ex As Exception
            SetExecutionStatus("Installation failed.", force:=True)
            MessageBox.Show(
            ex.Message,
            "Setup Installation Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        Finally
            showTextProgress = False
            _executionStatusLocked = False

            SetExecutionStatus("", force:=True)
            btnSetupInstall.Enabled = True
        End Try

    End Sub
    Private Sub tslblExecutionStatus_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles tslblExecutionStatus.TextChanged

        ' If there is text, show it; otherwise hide it
        tslblExecutionStatus.Visible =
            Not String.IsNullOrWhiteSpace(tslblExecutionStatus.Text)
    End Sub

    Private Sub btnRepoMain_Click(
    sender As Object,
    e As EventArgs
) Handles btnRepoMain.Click

        Try
            If RepoTools.HasUncommittedChanges(_options.RepoFolderPath) Then

                Dim response As DialogResult =
                UIHelpers.TimedYesNoPrompt(
                    message:=
                        "There are uncommitted changes." & Environment.NewLine &
                        "Discard them and switch to main?",
                    title:="Confirm",
                    timeoutSeconds:=10)

                If response <> DialogResult.Yes Then
                    ' User clicked No OR dialog timed out
                    Return
                End If

                RepoTools.DiscardAllChanges(_options.RepoFolderPath)
            End If

            RepoTools.SwitchToMainBranch(_options.RepoFolderPath)

            UIHelpers.TimedInfoPrompt(
    message:="Switched to main branch.",
    title:="Repository",
    timeoutSeconds:=10)

        Catch ex As Exception
            UIHelpers.TimedErrorPrompt(
                message:="Git Error",
                title:="Repository")


        End Try

    End Sub

    Private Sub btnTest1_Click(sender As Object, e As EventArgs) Handles btnTest1.Click
        DebugFormIdentity("ADDING CONTROLS")



    End Sub

    Private Sub btnTest2_Click(sender As Object, e As EventArgs) Handles btnTest2.Click
        DebugFormIdentity("VISIBLE FORM")
    End Sub
    Private Sub DebugFormIdentity(tag As String)
        MessageBox.Show(
        $"[{tag}]{Environment.NewLine}" &
        $"HashCode: {Me.GetHashCode()}{Environment.NewLine}" &
        $"Name: {Me.Name}",
        "FormMain Identity")
    End Sub

    Private Sub DumpParentChain(ctrl As Control)
        Dim sb As New System.Text.StringBuilder()
        Dim c As Control = ctrl

        While c IsNot Nothing
            sb.AppendLine($"{c.Name} ({c.GetType().Name}) Visible={c.Visible}")
            c = c.Parent
        End While

        MessageBox.Show(sb.ToString(), "Parent Chain")
    End Sub

    Private Async Sub OnStartServiceRequested(serviceName As String)

        Dim row = _serviceRows.
              FirstOrDefault(Function(r) r.ServiceName = serviceName)
        If row Is Nothing Then Return

        ' ✅ Immediate visual update
        row.IsBusy = True
        row.Status = ServiceControllerStatus.StartPending

        Await _serviceManager.StartServiceAsync(serviceName)

    End Sub

    Private Async Sub OnStopServiceRequested(serviceName As String)

        Dim row = _serviceRows.
              FirstOrDefault(Function(r) r.ServiceName = serviceName)
        If row Is Nothing Then Return

        row.IsBusy = True
        row.Status = ServiceControllerStatus.StopPending

        Await _serviceManager.StopServiceAsync(serviceName)

    End Sub

    Private Async Sub OnRestartServiceRequested(serviceName As String)

        Dim row = _serviceRows.
              FirstOrDefault(Function(r) r.ServiceName = serviceName)
        If row Is Nothing Then Return

        row.IsBusy = True
        row.Status = ServiceControllerStatus.StopPending

        Await _serviceManager.RestartServiceAsync(serviceName)

    End Sub
    Private Sub chkShowHiddenServices_CheckedChanged(
    sender As Object,
    e As EventArgs
) Handles chkShowHiddenServices.CheckedChanged

        _options.ShowHiddenServices = chkShowHiddenServices.Checked

        tblServices.SuspendLayout()

        ' Toggle visibility
        For Each row In _serviceRows
            If row.IsHidden Then
                row.Visible = chkShowHiddenServices.Checked
            End If
        Next

        ' ✅ FORCE TableLayoutPanel to recalc row heights
        ' Trick: nudge a RowStyle value
        If tblServices.RowStyles.Count > 0 Then
            Dim lastStyle = tblServices.RowStyles(tblServices.RowStyles.Count - 1)
            lastStyle.Height += 0.1F
            lastStyle.Height -= 0.1F
        End If

        tblServices.ResumeLayout(True)

        ' ✅ FORCE scroll height recalculation (WinForms bug workaround)
        tblServices.AutoScroll = False
        tblServices.AutoScroll = True

    End Sub

    Private Sub lblFlavorApplyCommand_Click(sender As Object, e As EventArgs) Handles lblFlavorApplyCommand.Click

    End Sub
End Class