Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.Intrinsics
Imports System.ServiceProcess
Imports System.Threading.Tasks
Imports Microsoft.Data.SqlClient
'Imports STA2.AppData

Public Class FormMain
    Public _options As AppOptions
    Private _launcherConfig As LauncherConfig
    Private _liveOutputManager As LiveOutputManager
    Private _quickLaunchManager As QuickLaunchManager
    Private _flavorManager As FlavorSelectionManager
    Private _executionStatusLocked As Boolean = False
    Private _runExistingVersionPath As String
    Private _tabHintLabel As Label
    Private _tabHintTimer As Timer
    Private _uiStateController As UIStateController
    Private _scriptController As ScriptExecutionController
    Private _databaseController As DatabaseViewController
    Private _isLoadingOptions As Boolean = False
    Private ReadOnly _serviceNames As String() =
    {
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
    }.OrderBy(Function(s) s).ToArray()

    Private ReadOnly _serviceRows As New List(Of ServiceRowControl)
    Private _serviceManager As ServiceManager
    Public Enum AppInstallState
        NotInstalled = 0
        InstalledX86 = 1
        InstalledX64 = 2
    End Enum
    Public Function IsScriptRunning() As Boolean
        Return _scriptController IsNot Nothing AndAlso _scriptController.IsRunning()
    End Function
    Public Sub RefreshUIProxy()
        _uiStateController.Refresh()
    End Sub

    Public Sub SetExecutionStatusProxy(text As String, Optional force As Boolean = False)
        SetExecutionStatus(text, force)
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
        If _options IsNot Nothing AndAlso
   Not String.IsNullOrWhiteSpace(_options.WindowTitle) Then
            Me.Text = _options.WindowTitle
        End If

    End Sub
    Private Sub InitializeUIEnhancements()
        Dim strTemp As String


        ' ✅ Button images
        SetButtonIcon(btnCopyScriptOutput, "imgCopy16.png")
        SetButtonIcon(btnRepoFolder, "imgOpenFolder16.png")
        SetButtonIcon(btnBrowseStartScript, "imgOpenFolder16.png")
        SetButtonIcon(btnBrowseApplyScript, "imgOpenFolder16.png")
        SetButtonIcon(btnBackupPathOverride, "imgOpenFolder16.png")
        SetButtonIcon(btnBackupScriptPath, "imgOpenFolder16.png")
        SetButtonIcon(btnFlavorsListRefresh, "imgRefresh16.png")

        ' ✅ Hover hints for buttons
        ToolTip1.SetToolTip(btnRunApplyFlavorLive, "Applies your configured Default flavors")
        ToolTip1.SetToolTip(btnOpenLogFile, "Browse And open any log file")
        ToolTip1.SetToolTip(btnDbUseAdvVersion, "Sets the 'Start DB on specific version' text box value to match your installed Advantage version")
        ToolTip1.SetToolTip(btnBatchLaunch, "Launches all programs in the Application list that have been included in the Batch Launch list")
        ToolTip1.SetToolTip(btnAdminRestart, "Relaunches the application in Admin Mode to enable elevated options like Services controls")
        ToolTip1.SetToolTip(btnSetupInstall, "Extract downloaded ZIP file in UpgradePath location and then run the Advantage Installer")
        ToolTip1.SetToolTip(btnLaunchLatestInstaller, "Run the installer with the highest version number that is found in the UpgradePath contained in the database AppOptions setting")
        ToolTip1.SetToolTip(btnRepoDiscardChanges, "Discard changes that were made to the Advantage Repo locally")
        ToolTip1.SetToolTip(btnRepoMain, "Discard Advantage repo changes and switch the branch back to 'main'")
        ToolTip1.SetToolTip(btnManageInstallerVersions, "Open the Advantage Installer Versions Management window where Installers in the UpgradePath location can be managed and run if needed")
        ToolTip1.SetToolTip(btnExit, "Exit the Assistant")
        ToolTip1.SetToolTip(btnComboAppLaunch, "Launch the selected application showing on the drop down list")

        strTemp =
            "Starts the database with default flavors and optionally the value from Start DB Version box." & Environment.NewLine &
            "Right Click for other Start Database options:" & Environment.NewLine &
            " - Start with no flavors (raw)" & Environment.NewLine &
            " - Start with an existing 00Pathfinder backup" & Environment.NewLine &
            " - Backup the database to 00Pathfinder"

        ToolTip1.SetToolTip(btnRunDatabaseStartLive, strTemp)

        ' System tools
        ToolTip1.SetToolTip(btnCalc, "Open the Calculator included with Windows")
        ToolTip1.SetToolTip(btnTaskmgr, "Open the Windows Task Manager")
        ToolTip1.SetToolTip(btnAppWiz, "Open the Control Panel > Programs and Features window")
        ToolTip1.SetToolTip(btnEventViewer, "Open the Windows Event Viewer")
        ToolTip1.SetToolTip(btnDevices, "Open the Control Panel > Devices and Printers window")
        ToolTip1.SetToolTip(btnServices, "Open the Windows Services window")

        ' Advantage apps
        ToolTip1.SetToolTip(btnAdvManager, "Run Advantage Manager Console")
        ToolTip1.SetToolTip(btnPos, "Run Advantage POS")
        ToolTip1.SetToolTip(btnAdvGroups, "Run Advantage Groups")
        ToolTip1.SetToolTip(btnAdvKioskSetup, "Run Advantage Legacy Kiosk Setup")
        ToolTip1.SetToolTip(btnAdvConfig, "Run CenterEdge Configuration")
        ToolTip1.SetToolTip(btnAdvReportEditor, "Run Advantage Report Editor")
        ToolTip1.SetToolTip(btnAdvRedeem, "Run Advantage Redemption")
        ToolTip1.SetToolTip(btnAdvCardTech, "DESCRIPTION")
        ToolTip1.SetToolTip(btnAdvKiosk, "Run Advantage Legacy Kiosk")
        ToolTip1.SetToolTip(btnAdvUpgrade, "Run Advantage Upgrade (AdvUpgrade.exe)")

        ' ✅ Hover hints
        ToolTip1.SetToolTip(
            lbFlavorsList,
            "🖱 Right-click → Apply selected flavors" & vbCrLf &
            "⚡ Double-click → Apply highlighted"
        )

        ToolTip1.SetToolTip(tbDbUseVersion, "Enter a database version to use with Start-Database to set the database version.  Example:  26.1.1")
        ToolTip1.SetToolTip(cbDbUseVersion, "Enable the Use Database version option for Start-Database")
        ToolTip1.SetToolTip(cmbboxAppLaunch, "Click to drop down applications that can be opened with the Launch button.  Applications in the list are set on the Options tab but are not assigned to a Quick Launch button")

        ' ✅ Hover hints for Options Tab
        ToolTip1.SetToolTip(tbWindowTitle, "You can set a name for the application here that will display in the title bar.  Example:  My Assistant")
        ToolTip1.SetToolTip(tbRepoFolder, "Select your repository root folder")
        ToolTip1.SetToolTip(tbSetupSwitches, "Specify the command line switches to use when running the Advantage Installer")
        ToolTip1.SetToolTip(cbShowHiddenServices, "Check this box to show all Advantage services in the Services List even if they are not installed.  Unchecked only the installed services will show")
        ToolTip1.SetToolTip(tbDatabaseStartDefault, "This is the path to the script to start the docker database (Start-Database.ps1)")
        ToolTip1.SetToolTip(tbApplyFlavorDefault, "This is the path to the script to apply flavors to the running docker database (Apply-Flavors.ps1)")
        ToolTip1.SetToolTip(lstPrograms, "List of applications configured to be used from Assistant App for the Quick Launch buttons, the launch list, and the Batch Launch button")
        ToolTip1.SetToolTip(clbSqlFiles, "This is the list of flavors detected in the Repo's flavor folder.  You can check the flavors' checkbox to add it to the list of defaults used by the Apply Default Flavors and Start Database buttons")

        ToolTip1.SetToolTip(btnAdd, "Add a new application to the Application Launcher Settings")
        ToolTip1.SetToolTip(btnEdit, "Edit the program selected in the Application Launcher Settings")
        ToolTip1.SetToolTip(btnDelete, "Delete the program selected in the Application Launcher Settings")
        ToolTip1.SetToolTip(btnLaunch, "Launch the program selected in the Application Launcher Settings")
        ToolTip1.SetToolTip(btnResetFlavorDefaults, "Resets the list of Default Flavors Selections to the defaults that were previously saved")
        ToolTip1.SetToolTip(btnSaveFlavorDefaults, "Save the currently selected flavors in the Default Flavors Selection list as the new default selections")

        ToolTip1.SetToolTip(cbAdvUpgradeNoBackup, "Run the Advantage Upgrade without creating a database backup file during the process")
        ToolTip1.SetToolTip(cbAdvUpgradeNoSetup, "Run the Advantage Upgrade without running the Advantage Setup when the database upgrade has finished")
        ToolTip1.SetToolTip(cbAdvUpgradeQuiet, "Run the Advantage Upgrade in a command prompt without a window")
        ToolTip1.SetToolTip(tbAdvupgrade, "Example of the command line that will be used with the selected switches")

        ToolTip1.SetToolTip(btnOpenLogFile, "Opens the folder containing the log files in a Open File box to select a log file")
        ToolTip1.SetToolTip(btnViewLatestLog, "Opens the log file for today to see the latest log entries")
        ToolTip1.SetToolTip(btnLastLogBlock, "Displays the very last script execution log in a message box")
        ToolTip1.SetToolTip(btnLastFailed, "Displays the last error encountered in a message box")
        ToolTip1.SetToolTip(btnUpdateShiftDate, "Run database stored procedure to update the Advantage shift date to today's date (exec ChangeShiftDate)")

    End Sub
    Private Async Function RunScriptAsync(
    scriptPath As String,
    trigger As Button,
    statusText As String,
    Optional flavors As List(Of String) = Nothing,
    Optional useVersion As Boolean = False,
    Optional versionText As String = Nothing,
    Optional overrideArgs As String = Nothing
) As Task

        Dim cmdOptions As New ScriptCommandOptions With {
        .ScriptPath = scriptPath,
        .FlavorNames = flavors,
        .UseVersion = useVersion,
        .VersionText = If(useVersion, versionText, Nothing),
        .OverrideArgs = overrideArgs
    }

        Await _scriptController.RunAsync(
        options:=cmdOptions,
        triggerButton:=trigger,
        runningStatusText:=statusText
    )

    End Function
    Private Sub ShowErrorPopup(ex As Exception, source As String)
        If ex Is Nothing Then Return

        Dim sb As New Text.StringBuilder()
        sb.AppendLine("Message:")
        sb.AppendLine(ex.Message)
        sb.AppendLine()
        sb.AppendLine("Source:")
        sb.AppendLine(source)
        sb.AppendLine()
        sb.AppendLine("Time:")
        sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))

        Dim summary As String = sb.ToString()


        Dim result = UIHelpers.TimedErrorPrompt(
    owner:=Me,
    message:=summary,
    title:="Application Error",
    timeoutSeconds:=15,
    button1Text:="Dismiss",
    button1Result:=DialogResult.No,
    button2Text:="View Logs",
    button2Result:=DialogResult.Yes
)

        If result = DialogResult.Yes Then
            ShowLatestLogInUI()
        End If


    End Sub
    Private Function GetLastFailedLogBlock(content As String) As String

        If String.IsNullOrWhiteSpace(content) Then Return Nothing

        Dim separator As String = "===================================================="

        ' ✅ Split based on your REAL separator
        Dim parts As String() =
        content.Split(New String() {separator}, StringSplitOptions.None)

        Dim failedBlock As String = Nothing

        For Each part As String In parts

            If String.IsNullOrWhiteSpace(part) Then Continue For

            ' ✅ Detect failure via exception presence
            If part.Contains("Exception Type:", StringComparison.OrdinalIgnoreCase) OrElse
   part.Contains("StackTrace:", StringComparison.OrdinalIgnoreCase) Then
                failedBlock = part.Trim()
            End If

        Next

        If String.IsNullOrWhiteSpace(failedBlock) Then
            Return Nothing
        End If

        Return separator & Environment.NewLine &
           failedBlock & Environment.NewLine &
           separator

    End Function

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GlobalErrorHandler.OnErrorLogged, AddressOf ShowErrorPopup
        InitializeUIEnhancements()
        _uiStateController = New UIStateController(Me, _options)
        _databaseController = New DatabaseViewController(Me)
        lblPersonalFlavorFile.Text = "Personal Flavor Filename:  " & _options.PersonalFlavorFileName

        rtbLiveOutput.CreateControl()
        flpQuickLaunch.AllowDrop = True

        ' Live output manager
        _liveOutputManager = New LiveOutputManager(Me, rtbLiveOutput, gbLiveOutput, tbOutputScript)

        _scriptController = New ScriptExecutionController(
    form:=Me,
    options:=_options,
    liveOutputManager:=_liveOutputManager
)
        _isLoadingOptions = True

        If _options IsNot Nothing Then
            cbAdvUpgradeQuiet.Checked = _options.AdvUpgradeQuiet
            cbAdvUpgradeNoBackup.Checked = _options.AdvUpgradeNoBackup
            cbAdvUpgradeNoSetup.Checked = _options.AdvUpgradeNoSetup
        End If

        _isLoadingOptions = False

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
        sqlFilesList:=clbSqlFiles
    )

        ' Render Quick Launch buttons
        _quickLaunchManager.Refresh()

        ' Restore persisted "Show hidden services" option
        If _options IsNot Nothing Then
            cbShowHiddenServices.Checked = _options.ShowHiddenServices
        End If
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
        '_databaseController.RefreshInfo()
        gpMessageLogFilters.Enabled = rbMessageLog.Checked
        '_databaseController.RefreshLogs()
        UpdateDbVersionState()

        DatabaseCoordinator.EvaluateDatabaseAvailability(
        form:=Me,
        connectionString:=ConfigValues.ConnectionString,
        configuredContainerName:=_options?.SqlContainerName
    )


#If Not DEBUG Then
        tbTest1.Visible = False
        tbTest2.Visible = False
        tbTest3.Visible = False
        tbMLTest1.Visible = False
        btnTest1.Visible = False
        btnTest2.Visible = False


#End If
#If DEBUG Then
        Me.Text += " - DEBUG BUILD"
#End If

        _uiStateController.Refresh()

        If _options IsNot Nothing Then tbWindowTitle.Text = _options.WindowTitle

        If _options IsNot Nothing Then
            tbRepoFolder.Text = _options.RepoFolderPath
            tbSetupSwitches.Text = _options.SetupSwitches
            tbDatabaseStartDefault.Text = Trim(_options.StartDatabaseDefault)
            tbApplyFlavorDefault.Text = Trim(_options.ApplyFlavorDefault)
            tbBackupPathOverride.Text = Trim(_options.BackupPathOverride)
            tbBackupScriptPath.Text = Trim(_options.BackupScriptPath)
        End If

        If IsRunningAsAdmin() Then
            btnAdminRestart.Enabled = False
            btnAdminRestart.Text = "Running as Admin"
        Else
            btnAdminRestart.Enabled = True
            btnAdminRestart.Text = "Restart as Administrator"
        End If

        SetExecutionStatus(String.Empty)
        InitializeTabSwitchHint()

        DatabaseCoordinator.RefreshAdvantageData(Me)
        EnableDoubleBuffering(tblServices)


        ' Load saved personal flavor if it exists
        tbFlavor.Text = OptionsManager.LoadPersonalFlavor()

    End Sub

    Private Sub FormMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
#If DEBUG Then
        'tcSTA.SelectedTab = tpOptions
#End If

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

                               Dim row = RequireServiceRow(serviceName)


                               row.IsBusy = isBusy
                           End Sub)
        End Sub

        ' Status changes (authoritative "installed" signal)
        AddHandler _serviceManager.ServiceStatusChanged,
        Sub(serviceName, status)
            Me.BeginInvoke(Sub()

                               Dim row = RequireServiceRow(serviceName)


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

                               Dim row = RequireServiceRow(serviceName)


                               row.Installed = False
                               row.IsHidden = True

                               ' Respect persisted toggle
                               row.Visible = cbShowHiddenServices.Checked

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
                UpdateOption(Sub() _options.FlavorFolderPath = inferredFlavorPath)

            End If
        End If

        ' -------------------------------------------------
        ' ✅ Initialize flavors now that path is valid
        ' -------------------------------------------------
        InitializeFlavors()
        SyncFlavorsListMirror()
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

                UpdateOption(Sub()
                                 _options.SetupSwitches = tbSetupSwitches.Text
                                 _options.ApplyFlavorDefault = Trim(tbApplyFlavorDefault.Text)
                                 _options.StartDatabaseDefault = Trim(tbDatabaseStartDefault.Text)
                                 _options.BackupPathOverride = Trim(tbBackupPathOverride.Text)
                             End Sub)
            End If
        Catch
        End Try
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

    Private Sub BuildServicesUI()

        ' ✅ Suspend layout and painting while building rows
        tblServices.SuspendLayout()

        tblServices.Controls.Clear()
        tblServices.RowStyles.Clear()
        tblServices.RowCount = 0
        _serviceRows.Clear()

        ' ✅ Step 3: Resolve display names and sort by DisplayName
        Dim services =
        _serviceNames.
            Select(Function(sn)
                       Dim display = GetServiceDisplayName(sn)
                       Return New With {
                           .ServiceName = sn,
                           .DisplayName = display
                       }
                   End Function).
            OrderBy(Function(x) x.DisplayName, StringComparer.CurrentCultureIgnoreCase).
            ToList()

        ' ✅ Step 4: Build rows in sorted order
        For Each item In services

            Dim row As New ServiceRowControl() With {
            .ServiceName = item.ServiceName,
            .DisplayName = item.DisplayName
        }

            ' Layout (keep as you had before)
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

    Private Sub InitializeTabSwitchHint()

        _tabHintLabel = New Label With {
            .Visible = False,
            .AutoSize = True,
            .BackColor = Color.FromArgb(220, Color.Black),
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Padding = New Padding(10),
            .BorderStyle = BorderStyle.FixedSingle
        }

        Me.Controls.Add(_tabHintLabel)
        _tabHintLabel.BringToFront()

        _tabHintTimer = New Timer With {
            .Interval = 700
        }

        AddHandler _tabHintTimer.Tick,
            Sub()
                _tabHintTimer.Stop()
                _tabHintLabel.Visible = False
            End Sub

    End Sub
    Private Sub SetButtonIcon(btn As Button, imageName As String)
        btn.Image = ResourceHelper.LoadImage(imageName)
        btn.ImageAlign = ContentAlignment.MiddleCenter
    End Sub

    Private Function GetServiceRow(serviceName As String) As ServiceRowControl
        Return _serviceRows.
        FirstOrDefault(Function(r) r.ServiceName = serviceName)
    End Function
    Private Function RequireServiceRow(serviceName As String) As ServiceRowControl
        Dim row = GetServiceRow(serviceName)

        If row Is Nothing Then
            Throw New InvalidOperationException($"Service row not found: {serviceName}")
        End If

        Return row
    End Function
    Private Function GetServiceDisplayName(serviceName As String) As String
        Try
            Using sc As New ServiceController(serviceName)
                Return sc.DisplayName
            End Using
        Catch
            ' Fallback if service is missing or inaccessible
            Return serviceName
        End Try
    End Function
    Private Sub EnableDoubleBuffering(ctrl As Control)
        Dim prop = ctrl.GetType().GetProperty(
        "DoubleBuffered",
        Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance
    )
        prop?.SetValue(ctrl, True, Nothing)
    End Sub
    Private Sub UpdateOption(setter As Action)
        If _options Is Nothing Then Return

        setter()
        OptionsManager.Save(_options)
    End Sub
    Private Sub SetExecutionStatus(text As String, Optional force As Boolean = False)

        If Not _executionStatusLocked OrElse force Then
            tslblExecutionStatus.Text = text
        End If

    End Sub
    Private Async Sub OnStartServiceRequested(serviceName As String)

        Dim row = RequireServiceRow(serviceName)


        ' ✅ Immediate visual update
        row.IsBusy = True
        row.Status = ServiceControllerStatus.StartPending

        Await _serviceManager.StartServiceAsync(serviceName)

    End Sub

    Private Async Sub OnStopServiceRequested(serviceName As String)

        Dim row = RequireServiceRow(serviceName)


        row.IsBusy = True
        row.Status = ServiceControllerStatus.StopPending

        Await _serviceManager.StopServiceAsync(serviceName)

    End Sub

    Private Async Sub OnRestartServiceRequested(serviceName As String)

        Dim row = RequireServiceRow(serviceName)


        row.IsBusy = True
        row.Status = ServiceControllerStatus.StopPending

        Await _serviceManager.RestartServiceAsync(serviceName)

    End Sub
    Private Async Function ApplySelectedFlavorsAsync() As Task

        If lbFlavorsList.SelectedItems.Count = 0 Then Return

        Dim selectedFlavors As New List(Of String)

        For Each item As FlavorSelectionManager.SqlFileItem In
        lbFlavorsList.SelectedItems.OfType(Of FlavorSelectionManager.SqlFileItem)()

            selectedFlavors.Add(item.FlavorName)
        Next

        If selectedFlavors.Count = 0 Then Return

        Dim description As String =
        If(selectedFlavors.Count = 1,
           $"Applying flavor '{selectedFlavors(0)}'",
           $"Applying {selectedFlavors.Count} flavors")

        Dim cmdOptions As New ScriptCommandOptions With {
        .ScriptPath = tbApplyFlavorDefault.Text,
        .FlavorNames = selectedFlavors,
        .UseVersion = cbDbUseVersion.Checked,
        .VersionText = tbDbUseVersion.Text
    }

        Await _scriptController.RunAsync(
        options:=cmdOptions,
        triggerButton:=btnRunApplyFlavorLive,
        runningStatusText:=description & " (live output)…"
    )

    End Function
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

    Private Sub ForceLiveOutputRedraw()

        If rtbLiveOutput.IsDisposed Then Return

        rtbLiveOutput.SuspendLayout()

        ' Force WinForms to fully re-sync layout + paint
        rtbLiveOutput.Hide()
        rtbLiveOutput.Show()

        rtbLiveOutput.PerformLayout()
        rtbLiveOutput.Refresh()

        ' Restore scroll state
        rtbLiveOutput.SelectionStart = rtbLiveOutput.TextLength
        rtbLiveOutput.ScrollToCaret()

        rtbLiveOutput.ResumeLayout()

    End Sub
    Private Sub SyncFlavorsListMirror()

        lbFlavorsList.BeginUpdate()
        lbFlavorsList.Items.Clear()

        For Each item As FlavorSelectionManager.SqlFileItem In
            clbSqlFiles.Items.OfType(Of FlavorSelectionManager.SqlFileItem)()

            lbFlavorsList.Items.Add(item)

        Next

        lbFlavorsList.DisplayMember = NameOf(FlavorSelectionManager.SqlFileItem.FlavorName)

        lbFlavorsList.EndUpdate()

    End Sub

    Private Sub ShowCleanupSummary(result As InstallerCleanupResult)

        Dim sb As New Text.StringBuilder()

        sb.AppendLine("Cleanup complete.")
        sb.AppendLine()

        If result.Deleted.Any() Then
            sb.AppendLine($"✔ Deleted {result.Deleted.Count} version(s):")
            For Each v In result.Deleted
                sb.AppendLine($"  • {v.VersionString}")
            Next
            sb.AppendLine()
        End If

        If result.Skipped.Any() Then
            sb.AppendLine($"⚠ Skipped {result.Skipped.Count} version(s):")
            For Each v In result.Skipped
                sb.AppendLine($"  • {v.VersionString}")
            Next
            sb.AppendLine()
        End If

        If result.Failed.Any() Then
            sb.AppendLine($"✖ Failed to delete {result.Failed.Count} version(s):")
            For Each kvp In result.Failed
                sb.AppendLine($"  • {kvp.Key.VersionString}: {kvp.Value.Message}")
            Next
            sb.AppendLine()
        End If

        Dim freedMb = result.FreedBytes \ (1024 * 1024)
        sb.AppendLine($"Total disk space freed: {freedMb} MB")

        MessageBox.Show(
        sb.ToString(),
        "Installer Version Cleanup",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information)

    End Sub

    ' =============================
    ' Progress overlay helper
    ' =============================
    Private Function ShowProgressOverlay(message As String) As ProgressOverlayForm

        Dim overlay As New ProgressOverlayForm(message)

        ' Match FormMain client area
        overlay.Size = Me.ClientSize
        overlay.Location = Me.PointToScreen(Point.Empty)

        overlay.Show(Me)
        overlay.BringToFront()
        overlay.Refresh()

        Return overlay

    End Function
    Protected Overrides Function ProcessCmdKey(
    ByRef msg As Message,
    keyData As Keys
) As Boolean

        ' Ctrl + Tab → next tab
        If keyData = (Keys.Control Or Keys.Tab) Then
            SelectNextSTATab(forward:=True)
            Return True
        End If

        ' Ctrl + Shift + Tab → previous tab
        If keyData = (Keys.Control Or Keys.Shift Or Keys.Tab) Then
            SelectNextSTATab(forward:=False)
            Return True
        End If

        ' Let all other keys behave normally
        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function
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
    Private Sub chkShowHiddenServices_CheckedChanged(
       sender As Object,
    e As EventArgs
) Handles cbShowHiddenServices.CheckedChanged

        UpdateOption(Sub() _options.ShowHiddenServices = cbShowHiddenServices.Checked)

        tblServices.SuspendLayout()

        ' Toggle visibility
        For Each row In _serviceRows
            If row.IsHidden Then
                row.Visible = cbShowHiddenServices.Checked
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

    Private Sub tcSTA_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
) Handles tcSTA.SelectedIndexChanged

        If tcSTA.SelectedTab Is tpGeneral Then

            ' ✅ Defer until WinForms finishes showing the tab
            BeginInvoke(Sub()
                            ForceLiveOutputRedraw()
                        End Sub)

        End If

    End Sub

    Private Sub tcSTA_Click(sender As Object, e As EventArgs) Handles tcSTA.Click
        If _databaseController Is Nothing Then Return
        _databaseController.RefreshLogs()
        _databaseController.RefreshInfo()
    End Sub
    Private Sub SelectNextSTATab(forward As Boolean)

        If tcSTA Is Nothing OrElse
       tcSTA.TabPages.Count = 0 Then Return

        Dim count As Integer = tcSTA.TabPages.Count
        Dim index As Integer = tcSTA.SelectedIndex

        If forward Then
            index = (index + 1) Mod count
        Else
            index = (index - 1 + count) Mod count
        End If

        tcSTA.SelectedIndex = index

        ' ✅ Show visual hint
        ShowTabSwitchHint(forward)

    End Sub
    Private Sub ShowTabSwitchHint(forward As Boolean)

        If tcSTA.SelectedTab Is Nothing Then Return

        Dim arrow As String =
            If(forward, "▶ ", "◀ ")

        _tabHintLabel.Text =
            arrow & tcSTA.SelectedTab.Text

        ' Position centered near top
        _tabHintLabel.Location =
            New Point(
                (Me.ClientSize.Width - _tabHintLabel.Width) \ 2,
                20)

        _tabHintLabel.Visible = True
        _tabHintLabel.BringToFront()

        _tabHintTimer.Stop()
        _tabHintTimer.Start()

    End Sub
    Private Sub tmr10Seconds_Tick(
    sender As Object,
    e As EventArgs
) Handles tmr10Seconds.Tick

        CodeHelper.Refresher()
        _uiStateController.Refresh()

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

        _uiStateController.Refresh()

    End Sub

    Private Sub btnDbInfoRefresh_Click(sender As Object, e As EventArgs) Handles btnDbInfoRefresh.Click
        If _databaseController Is Nothing Then Return
        _databaseController.RefreshInfo()
    End Sub
    Private Sub btnDbLogRefresh_Click(sender As Object, e As EventArgs) Handles btnDbLogRefresh.Click, rbWebCloudUpdates.Click, rbMessageLog.Click
        If _databaseController Is Nothing Then Return
        _databaseController.RefreshLogs()
    End Sub
    Private Sub rbDbTableSize_CheckedChanged(sender As Object, e As EventArgs) Handles rbDbTableSize.CheckedChanged, rbDbFragmentation.CheckedChanged, rbDbSizeByDay.CheckedChanged, rbDbDeadlocks.CheckedChanged
        If _databaseController Is Nothing Then Return
        _databaseController.RefreshInfo()
    End Sub
    Private Sub rbWebCloudUpdates_CheckedChanged(sender As Object, e As EventArgs) Handles rbWebCloudUpdates.CheckedChanged, rbMessageLog.CheckedChanged
        gpMessageLogFilters.Enabled = rbMessageLog.Checked
        If _databaseController Is Nothing Then Return
        _databaseController.RefreshLogs()
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
                UIHelpers.TimedInfoPrompt(message:="Reconnected to the database.", timeoutSeconds:=30, title:="Database")

            End If

        Catch ex As Exception

            UIHelpers.TimedErrorPrompt(message:=$"Reconnect failed: {ex.Message}", timeoutSeconds:=0, title:="Database")
        Finally
            btnReconnect.Enabled = True
            Cursor.Current = Cursors.Default
        End Try

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
    Private Sub btnBrowseStartScript_Click(sender As Object, e As EventArgs) Handles btnBrowseStartScript.Click



        With ofdStartScript
            .Title = "Select Start Database Script"
            .Filter = "PowerShell Scripts (*.ps1)|*.ps1"
            .InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
        End With

        If ofdStartScript.ShowDialog() = DialogResult.OK Then

            ' ✅ Store selected script path
            tbDatabaseStartDefault.Text = ofdStartScript.FileName

            ' ✅ Persist to options
            UpdateOption(Sub() _options.StartDatabaseDefault = ofdStartScript.FileName)
        End If

    End Sub

    Private Sub btnBrowseApplyScript_Click(sender As Object, e As EventArgs) Handles btnBrowseApplyScript.Click


        With ofdStartScript   ' ✅ reuse same dialog (or change name if separate)
            .Title = "Select Apply Flavors Script"
            .Filter = "PowerShell Scripts (*.ps1)|*.ps1"
            .InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
        End With

        If ofdStartScript.ShowDialog() = DialogResult.OK Then

            ' ✅ Set textbox
            tbApplyFlavorDefault.Text = ofdStartScript.FileName

            ' ✅ Persist option
            UpdateOption(Sub() _options.ApplyFlavorDefault = ofdStartScript.FileName)

        End If

    End Sub

    Private Sub btnBackupPathOverride_Click(
    sender As Object,
    e As EventArgs
) Handles btnBackupPathOverride.Click

        ' ✅ Determine current effective backup path
        Dim currentPath = ResolveBackupPath()

        With staFolderBrowserDialog

            .Description = "Select Backup Folder"
            .UseDescriptionForTitle = True

            ' ✅ Default to current backup path if valid
            If Not String.IsNullOrWhiteSpace(currentPath) AndAlso
           IO.Directory.Exists(currentPath) Then

                .SelectedPath = currentPath

            Else
                ' ✅ Fallback if nothing valid
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            End If

        End With

        If staFolderBrowserDialog.ShowDialog() = DialogResult.OK Then

            ' ✅ Set textbox (UI reflection of option)
            tbBackupPathOverride.Text = staFolderBrowserDialog.SelectedPath

            ' ✅ Persist option
            UpdateOption(Sub()
                             _options.BackupPathOverride = staFolderBrowserDialog.SelectedPath
                         End Sub)

        End If

    End Sub

    Private Sub clbSqlFiles_Enter(sender As Object, e As EventArgs) _
    Handles clbSqlFiles.Enter

        _flavorManager.RefreshPreservingSelection()
        SyncFlavorsListMirror()

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
                UpdateOption(Sub() _options.RepoFolderPath = RepoFolderPath)

                ' Optional: show in UI
                tbRepoFolder.Text = RepoFolderPath

                _flavorManager.LoadFilesWithDefaults(_options.FlavorFolderPath)
            End If
        End Using
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

        _uiStateController.Refresh()


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

            ' If user chose Run Existing, this path already existed
            If Directory.Exists(extractDir) AndAlso
   extractDir.EndsWith("Version " & AppData.InstalledVersion, StringComparison.OrdinalIgnoreCase) Then

                _runExistingVersionPath = extractDir
            End If

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
        _uiStateController.Refresh()

    End Sub
    Private Async Sub btnManageInstallerVersions_Click(
    sender As Object,
    e As EventArgs
) Handles btnManageInstallerVersions.Click

        btnManageInstallerVersions.Enabled = False
        Try
            Dim versions =
            InstallerTools.DiscoverInstalledInstallerVersions(AppData.UpgradePath)

            Await ProgressOverlayService.RunWithOverlayAsync(
            Me,
            "Scanning installed installer versions…" & Environment.NewLine &
            "Please wait.",
            Function()
                Return Task.Run(Sub()
                                    InstallerTools.ApplyCleanupSafetyRules(
                        versions,
                        runExistingVersionPath:=_runExistingVersionPath)
                                End Sub)
            End Function
        )

#If DEBUG Then
            For Each v In versions
                Debug.WriteLine(
                $"{v.VersionString} | CanDelete={v.CanDelete} | Reason={v.LockReason}")
            Next
#End If

            Using dlg As New ManageInstallerVersionsForm(versions, AppData.UpgradePath)

                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    ' ✅ Confirmation has ALREADY occurred in ManageInstallerVersionsForm
                    Dim result =
                    InstallerTools.ExecuteInstallerVersionCleanup(
                        dlg.SelectedForCleanup)

                    ShowCleanupSummary(result)
                End If

            End Using

        Finally
            btnManageInstallerVersions.Enabled = True
        End Try

    End Sub


    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click, btnTaskmgr.Click, btnEventViewer.Click, btnDevices.Click, btnAppWiz.Click, btnServices.Click

        Dim caller = DirectCast(sender, Button)
        Dim Executable = caller.Name.Replace("btn", "")
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
            Process.Start(Executable)
        End If
    End Sub
    Private Sub btnAdvManager_Click(sender As Object, e As EventArgs) Handles btnAdvManager.Click, btnPos.Click, btnAdvGroups.Click, btnAdvReportEditor.Click, btnAdvRedeem.Click, btnAdvCardTech.Click, btnAdvKiosk.Click, btnAdvKioskSetup.Click, btnAdvConfig.Click
        Dim caller As System.Windows.Forms.Button = DirectCast(sender, System.Windows.Forms.Button)
        Dim Executable As String = caller.Name.Replace("btn", "")
        Dim Version As Integer = CodeHelper.AdvExeCheck(Executable)

        If Version = AppInstallState.InstalledX86 Then Executable = String.Format("{0}{1}.exe", AppData.CEPath86, Executable)
        If Version = AppInstallState.InstalledX64 Then Executable = String.Format("{0}{1}.exe", AppData.CEPath64, Executable)

        System.Diagnostics.Process.Start(Executable)
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
        Dim sfd As SaveFileDialog = New SaveFileDialog()

        Select Case caller.Name.ToString
            Case btnSaveApplicationInfoCSV.Name.ToString
                sfd.FileName = "ApplicationInfo.csv"
                dgvSource = dgvApplicationInfo

            Case btnSaveAppotionsCSV.Name.ToString
                sfd.FileName = "AppOptions.csv"
                dgvSource = dgvAppOptions

            Case btnSaveWebOptionsCSV.Name.ToString
                sfd.FileName = "WebOptions.csv"
                dgvSource = dgvWebOptions

            Case Else
                Exit Sub
        End Select

        sfd.InitialDirectory = "C:\CenterEdge"
        sfd.DefaultExt = "csv"
        sfd.CheckPathExists = True
        sfd.CreatePrompt = True
        sfd.AddExtension = True
        sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
        sfd.ShowDialog()

        Using writer As StreamWriter = New StreamWriter(sfd.FileName)
            writer.WriteLine("OptionName,OptionValue")
            For Each row As DataGridViewRow In dgvSource.Rows
                writer.WriteLine(row.Cells(0).Value + "," + row.Cells(1).Value)
            Next
        End Using
    End Sub
    Private Sub cbAdvUpgradeQuiet_CheckedChanged(
    sender As Object,
    e As EventArgs
) Handles cbAdvUpgradeQuiet.CheckedChanged,
          cbAdvUpgradeNoBackup.CheckedChanged,
          cbAdvUpgradeNoSetup.CheckedChanged

        ' ✅ Ignore events during initial load
        If _isLoadingOptions Then Return

        Dim quiet As String = If(cbAdvUpgradeQuiet.Checked, "/q ", "")
        Dim nobackup As String = If(cbAdvUpgradeNoBackup.Checked, "/nobackup ", "")
        Dim nosetup As String = If(cbAdvUpgradeNoSetup.Checked, "/nosetup ", "")

        tbAdvupgrade.Text = "AdvUpgrade.exe " & quiet & nobackup & nosetup

        UpdateOption(Sub()
                         _options.AdvUpgradeQuiet = cbAdvUpgradeQuiet.Checked
                         _options.AdvUpgradeNoBackup = cbAdvUpgradeNoBackup.Checked
                         _options.AdvUpgradeNoSetup = cbAdvUpgradeNoSetup.Checked
                     End Sub)

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

    Private Sub tbWindowTitle_TextChanged(sender As Object, e As EventArgs) Handles tbWindowTitle.TextChanged
        UpdateOption(Sub() _options.WindowTitle = tbWindowTitle.Text)
    End Sub
    Private Sub tbSetupSwitches_TextChanged(sender As Object, e As EventArgs) Handles tbSetupSwitches.TextChanged

        UpdateOption(Sub() _options.SetupSwitches = tbSetupSwitches.Text)
    End Sub

    Private Sub lbFlavorsList_MouseDown(
    sender As Object,
    e As MouseEventArgs
) Handles lbFlavorsList.MouseDown
        ' ✅ Preserve your right-click logic
        If e.Button <> MouseButtons.Right Then Return

        Dim index = lbFlavorsList.IndexFromPoint(e.Location)
        If index < 0 Then Return

        If Not lbFlavorsList.SelectedIndices.Contains(index) Then
            lbFlavorsList.SelectedIndex = index
        End If

    End Sub
    Private Sub cmsApplySingleFlavor_Opening(
sender As Object,
e As System.ComponentModel.CancelEventArgs
) Handles cmsApplySingleFlavor.Opening

        Dim count = lbFlavorsList.SelectedItems.Count

        ' ✅ Cancel menu entirely if nothing selected
        If count = 0 Then
            e.Cancel = True
            Return
        End If

        ' ✅ Update Apply Single Flavor text
        If count = 1 Then
            miApplySingleFlavor.Text = "Apply selected flavor"
        Else
            miApplySingleFlavor.Text = $"Apply {count} selected flavors"
        End If

        ' ✅ Enable/disable Default Flavors option
        tsmiApplyDefaultFlavors.Enabled =
        _options.DefaultFlavorNames IsNot Nothing AndAlso
        _options.DefaultFlavorNames.Count > 0

    End Sub

    Private Sub clbSqlFiles_MouseDown(
    sender As Object,
    e As MouseEventArgs
) Handles clbSqlFiles.MouseDown

        If e.Button = MouseButtons.Right Then
            Dim index = clbSqlFiles.IndexFromPoint(e.Location)
            If index >= 0 Then
                clbSqlFiles.SelectedIndex = index
            End If
        End If

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

    Private Sub btnCopyScriptOutput_Click(sender As Object, e As EventArgs) Handles btnCopyScriptOutput.Click

        Dim textToCopy = tbOutputScript.Text

        If String.IsNullOrWhiteSpace(textToCopy) Then
            Return
        End If

        ' ✅ Select all text
        tbOutputScript.SelectAll()

        ' ✅ Copy to clipboard
        Clipboard.SetText(textToCopy)

        ' ✅ Remove selection (put caret at end, no highlight)
        tbOutputScript.SelectionStart = tbOutputScript.TextLength
        tbOutputScript.SelectionLength = 0

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
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

    Private Sub tbLocName_GotFocus(sender As Object, e As EventArgs) Handles tbLocName.GotFocus, tbLicSvr.GotFocus, tbCoreSvr.GotFocus, tbDbVer.GotFocus, tbWebEnabled.GotFocus, tbShiftDate.GotFocus
        gpLicInfo.Select()
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

    Private Sub tbDatabaseStartDefault_TextChanged(sender As Object, e As EventArgs) Handles tbDatabaseStartDefault.TextChanged
        UpdateOption(Sub() _options.StartDatabaseDefault = Trim(tbDatabaseStartDefault.Text))
    End Sub


    Private Sub tbApplyFlavorDefault_TextChanged(sender As Object, e As EventArgs) Handles tbApplyFlavorDefault.TextChanged
        UpdateOption(Sub() _options.ApplyFlavorDefault = Trim(tbApplyFlavorDefault.Text))
    End Sub

    Private Sub tbBackupPathOverride_TextChanged(sender As Object, e As EventArgs) Handles tbBackupPathOverride.TextChanged
        UpdateOption(Sub() _options.BackupPathOverride = Trim(tbBackupPathOverride.Text))
    End Sub
    Private Sub tslblExecutionStatus_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles tslblExecutionStatus.TextChanged

        ' If there is text, show it; otherwise hide it
        tslblExecutionStatus.Visible =
            Not String.IsNullOrWhiteSpace(tslblExecutionStatus.Text)
    End Sub

    Private Sub btnDbUseAdvVersion_Click(sender As Object, e As EventArgs) Handles btnDbUseAdvVersion.Click
        cbDbUseVersion.Checked = True
        tbDbUseVersion.Text = PCInfo.AdvantageVersion.ToString
    End Sub

    Private Sub btnDbTest_Click(sender As Object, e As EventArgs)

        Dim defaultFlavors = _options?.DefaultFlavorNames

        Dim cmdOptions As New ScriptCommandOptions With {
            .ScriptPath = tbDatabaseStartDefault.Text,
            .FlavorNames = defaultFlavors,
            .UseVersion = cbDbUseVersion.Checked,
            .VersionText = tbDbUseVersion.Text
        }

        ' ✅ NEW: get structured args
        Dim args = _scriptController.BuildScriptArgs(cmdOptions)

        ' ✅ Show BOTH for clarity
        Dim output =
            "Args:" & Environment.NewLine &
            args

        TimedInfoPrompt(
            output,
            "Start Database Command Line Test",
            timeoutSeconds:=10)

    End Sub

    Private Sub ShowSelectedLogFileInUI()

        Dim logFolder As String =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")

        Using ofd As New OpenFileDialog()

            With ofd
                .Title = "Select a log file"
                .Filter = "Log Files (*.log)|*.log|All Files (*.*)|*.*"
                .InitialDirectory =
                If(Directory.Exists(logFolder),
                   logFolder,
                   AppDomain.CurrentDomain.BaseDirectory)
                .Multiselect = False
            End With

            If ofd.ShowDialog() <> DialogResult.OK Then Return

            ' ✅ Use shared method
            LoadLogFileIntoUI(ofd.FileName)

        End Using

    End Sub

    Private Sub ShowLatestLogInUI()

        Dim logFolder As String =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")

        If Not Directory.Exists(logFolder) Then
            MessageBox.Show("Log folder does not exist yet.")
            Return
        End If

        Try
            Dim latestFile =
            Directory.GetFiles(logFolder, "*.log") _
            .Select(Function(f) New FileInfo(f)) _
            .OrderByDescending(Function(fi) fi.LastWriteTime) _
            .FirstOrDefault()

            If latestFile Is Nothing Then
                MessageBox.Show("No log files found.")
                Return
            End If

            ' ✅ Use shared method
            LoadLogFileIntoUI(latestFile.FullName)

        Catch ex As Exception
            MessageBox.Show("Error finding logs: " & ex.Message)
        End Try

    End Sub
    Private Sub LoadLogFileIntoUI(filePath As String)

        If String.IsNullOrWhiteSpace(filePath) OrElse Not File.Exists(filePath) Then
            MessageBox.Show("Log file not found.")
            Return
        End If

        Try
            Dim content As String = File.ReadAllText(filePath)

            tpLogs.Text = "Logs: " & Path.GetFileName(filePath)

            ' ✅ Switch tab
            tcSTA.SelectedTab = tpLogs

            ' ✅ Fill viewer
            rtbLogs.Clear()
            rtbLogs.Text = content

            rtbLogs.SelectionStart = rtbLogs.Text.Length
            rtbLogs.ScrollToCaret()

        Catch ex As Exception
            MessageBox.Show(
            "Error opening log file: " & ex.Message,
            "Log Viewer",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnViewLatestLog_Click(sender As Object, e As EventArgs) Handles btnViewLatestLog.Click
        ShowLatestLogInUI()
    End Sub

    Private Sub btnOpenLogFile_Click(sender As Object, e As EventArgs) Handles btnOpenLogFile.Click
        ShowSelectedLogFileInUI()
    End Sub

    Private Sub btnLastLogBlock_Click(sender As Object, e As EventArgs) Handles btnLastLogBlock.Click

        Dim logFolder As String =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")

        If Not Directory.Exists(logFolder) Then
            MessageBox.Show("Log folder does not exist yet.")
            Return
        End If

        Try
            Dim latestFile =
            Directory.GetFiles(logFolder, "*.log") _
            .Select(Function(f) New FileInfo(f)) _
            .OrderByDescending(Function(fi) fi.LastWriteTime) _
            .FirstOrDefault()

            If latestFile Is Nothing Then
                MessageBox.Show("No log files found.")
                Return
            End If

            ' ✅ Read file
            Dim content As String = File.ReadAllText(latestFile.FullName)

            ' ✅ Extract last execution block
            Dim lastBlock As String = GetLastLogBlock(content)

            ' ✅ Optional: truncate (important for prompt UI)
            If lastBlock.Length > 2000 Then
                lastBlock = lastBlock.Substring(0, 2000) &
                        Environment.NewLine &
                        "...(truncated)"
            End If

            ' ✅ Optional: dynamic title
            Dim title As String = "Last Execution"

            If lastBlock.Contains("FAILURE") Then
                title &= " (FAILED)"
            ElseIf lastBlock.Contains("SUCCESS") Then
                title &= " (SUCCESS)"
            End If

            ' ✅ Show in prompt
            UIHelpers.TimedInfoPrompt(
            message:=lastBlock,
            title:=title,
            timeoutSeconds:=15)

        Catch ex As Exception
            MessageBox.Show(
            "Error loading log: " & ex.Message,
            "Log Viewer",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function GetLastLogBlock(content As String) As String

        If String.IsNullOrWhiteSpace(content) Then Return String.Empty

        Dim separator As String = "----------------------------------------------------"

        Dim parts = content.Split(
        New String() {separator},
        StringSplitOptions.RemoveEmptyEntries)

        ' ✅ Find last NON-empty block
        Dim lastBlock As String = parts _
        .Select(Function(p) p.Trim()) _
        .Where(Function(p) Not String.IsNullOrWhiteSpace(p)) _
        .LastOrDefault()

        If String.IsNullOrWhiteSpace(lastBlock) Then
            Return content ' fallback
        End If

        Return separator & Environment.NewLine &
           lastBlock & Environment.NewLine &
           separator

    End Function
    Private Sub ShowLastLogBlockPrompt(filePath As String)

        If String.IsNullOrWhiteSpace(filePath) OrElse Not File.Exists(filePath) Then
            MessageBox.Show("Log file not found.")
            Return
        End If

        Try
            Dim content As String = File.ReadAllText(filePath)

            ' ✅ Extract only last execution block
            Dim lastBlock As String = GetLastLogBlock(content)

            ' ✅ Optional: truncate if too long (UI prompt limitation)
            If lastBlock.Length > 2000 Then
                lastBlock = lastBlock.Substring(0, 2000) & Environment.NewLine & "...(truncated)"
            End If

            ' ✅ Show in prompt
            UIHelpers.TimedInfoPrompt(
                message:=lastBlock,
                title:="Last Script Execution",
                timeoutSeconds:=15)

        Catch ex As Exception
            MessageBox.Show(
                "Error reading log file: " & ex.Message,
                "Log Viewer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLastFailed_Click(sender As Object, e As EventArgs) Handles btnLastFailed.Click

        Dim logFolder As String =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")

        If Not Directory.Exists(logFolder) Then
            MessageBox.Show("Log folder does not exist yet.")
            Return
        End If

        Try
            ' ✅ Get latest log file
            Dim latestFile =
    Directory.GetFiles(logFolder, "Error_*.log") _
    .Select(Function(f) New FileInfo(f)) _
    .OrderByDescending(Function(fi) fi.LastWriteTime) _
    .FirstOrDefault()


            If latestFile Is Nothing Then
                MessageBox.Show("No log files found.")
                Return
            End If

            Dim content As String = File.ReadAllText(latestFile.FullName)

            ' ✅ Extract LAST FAILED block
            Dim failedBlock As String = GetLastFailedLogBlock(content)

            ' ✅ FIRST: check if anything was found
            If String.IsNullOrWhiteSpace(failedBlock) Then
                UIHelpers.TimedInfoPrompt(
        Me,
                "No failed executions found in this log.",
        "Last Failed - " & latestFile.Name,
        5)
                Return
            End If

            ' ✅ NOW: prepend your message AFTER the check
            failedBlock = "Open full log file for full details and to copy failure data." &
              Environment.NewLine & Environment.NewLine &
              failedBlock

            ' ✅ Optional: truncate for dialog
            If failedBlock.Length > 1500 Then
                failedBlock = failedBlock.Substring(0, 1500) &
                              Environment.NewLine & "...(truncated)"
            End If

            ' ✅ Show using your new multi-button system
            Dim result = UIHelpers.TimedErrorPrompt(
                owner:=Me,
                message:=failedBlock,
                title:="Last FAILED Execution",
                timeoutSeconds:=20,
                button1Text:="Dismiss",
                button1Result:=DialogResult.No,
                button2Text:="View Full Log",
                button2Result:=DialogResult.Yes,
                defaultButtonIndex:=1,
                cancelButtonIndex:=1
            )

            If result = DialogResult.Yes Then
                ShowLatestLogInUI()
            End If

        Catch ex As Exception
            MessageBox.Show("Error retrieving failed execution: " & ex.Message)
        End Try

    End Sub


    Private Sub cbDbUseVersion_CheckedChanged(sender As Object, e As EventArgs) Handles cbDbUseVersion.CheckedChanged

        UpdateDbVersionState()

    End Sub
    Private Sub UpdateDbVersionState()

        Dim isEnabled = cbDbUseVersion.Checked

        tbDbUseVersion.Enabled = isEnabled
        tbDbUseVersion.BackColor = If(isEnabled, SystemColors.Window, SystemColors.Control)

        If Not isEnabled Then
            tbDbUseVersion.Text = String.Empty
        Else
            tbDbUseVersion.Select()
        End If


    End Sub

    Private Sub btnUpdateShiftDate_Click(sender As Object, e As EventArgs) Handles btnUpdateShiftDate.Click

        Try
            Dim connectionString = ConfigValues.ConnectionString()

            DatabaseCoordinator.ExecuteStoredProcedure(
            connectionString,
            "ChangeShiftDate"
        )

        Catch ex As SqlException

            ' ✅ ONLY handle expected case
            If ex.Number = 2627 OrElse ex.Number = 2601 Then

                If ex.Message.Contains("PK_InvSnapShot") Then
                    MessageBox.Show("Conflict in InvSnapShot Table", "Docker Data")
                Else
                    MessageBox.Show("Shift date already exists.", "Duplicate")
                End If

                Return ' ✅ stop propagation ONLY for this case

            End If

            ' ✅ IMPORTANT: let everything else go to GlobalErrorHandler
            Throw

        End Try

    End Sub

    Private Async Sub btnRunDatabaseStartLive_Click(
    sender As Object,
    e As EventArgs
) Handles btnRunDatabaseStartLive.Click

        Dim flavors = _options?.DefaultFlavorNames

        If flavors Is Nothing OrElse flavors.Count = 0 Then
            MessageBox.Show(
                "No default flavors are configured.",
                "No Defaults",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        Await RunScriptAsync(
            scriptPath:=tbDatabaseStartDefault.Text,
            trigger:=btnRunDatabaseStartLive,
            statusText:="Starting database (live output)…",
            flavors:=flavors,
            useVersion:=cbDbUseVersion.Checked,
            versionText:=tbDbUseVersion.Text
)

        DatabaseCoordinator.EvaluateDatabaseAvailability(
            form:=Me,
            connectionString:=ConfigValues.ConnectionString,
            configuredContainerName:=_options?.SqlContainerName
        )

        _uiStateController.Refresh()

    End Sub
    Private Async Sub btnRunApplyFlavorLive_Click(
    sender As Object,
    e As EventArgs
) Handles btnRunApplyFlavorLive.Click

        Dim defaultFlavors = _options?.DefaultFlavorNames

        If defaultFlavors Is Nothing OrElse defaultFlavors.Count = 0 Then
            MessageBox.Show(
                "No default flavors are configured.",
                "No Defaults",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        Await RunScriptAsync(
            scriptPath:=tbApplyFlavorDefault.Text,
            trigger:=btnRunApplyFlavorLive,
            statusText:="Applying default flavors (live output)…",
            flavors:=defaultFlavors
        )

    End Sub
    Private Async Sub tsmiApplyDefaultFlavors_Click(
    sender As Object,
    e As EventArgs
) Handles tsmiApplyDefaultFlavors.Click

        If String.IsNullOrWhiteSpace(tbApplyFlavorDefault.Text) Then
            MessageBox.Show(
            "Please select an Apply Flavors script first.",
            "Missing Script",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Dim defaultFlavors = _options.DefaultFlavorNames

        If defaultFlavors Is Nothing OrElse defaultFlavors.Count = 0 Then
            MessageBox.Show(
            "No default flavors are configured.",
            "No Defaults",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
            Return
        End If

        Await RunScriptAsync(
        scriptPath:=tbApplyFlavorDefault.Text,
        trigger:=btnRunApplyFlavorLive,
        statusText:="Applying default flavors (live output)…",
        flavors:=defaultFlavors
    )

        lbFlavorsList.ClearSelected()

    End Sub
    Private Async Sub lbFlavorsList_DoubleClick(
    sender As Object,
    e As EventArgs
) Handles lbFlavorsList.DoubleClick

        If lbFlavorsList.SelectedItems.Count = 0 Then Return

        Dim selectedFlavors As New List(Of String)

        For Each item As FlavorSelectionManager.SqlFileItem In
            lbFlavorsList.SelectedItems.OfType(Of FlavorSelectionManager.SqlFileItem)()

            selectedFlavors.Add(item.FlavorName)
        Next

        Dim description As String =
            If(selectedFlavors.Count = 1,
               $"Applying flavor '{selectedFlavors(0)}'",
               $"Applying {selectedFlavors.Count} flavors")

        Await RunScriptAsync(
            scriptPath:=tbApplyFlavorDefault.Text,
            trigger:=btnRunApplyFlavorLive,
            statusText:=description & " (live output)…",
            flavors:=selectedFlavors
        )

    End Sub
    Private Async Sub miApplySingleFlavor_Click(
    sender As Object,
    e As EventArgs
) Handles miApplySingleFlavor.Click

        If lbFlavorsList.SelectedItems.Count = 0 Then Return

        Dim selectedFlavors As New List(Of String)

        For Each item As FlavorSelectionManager.SqlFileItem In
            lbFlavorsList.SelectedItems.OfType(Of FlavorSelectionManager.SqlFileItem)()

            selectedFlavors.Add(item.FlavorName)
        Next

        Await RunScriptAsync(
            scriptPath:=tbApplyFlavorDefault.Text,
            trigger:=btnRunApplyFlavorLive,
            statusText:=$"Applying {selectedFlavors.Count} flavor(s)…",
            flavors:=selectedFlavors
        )

        lbFlavorsList.ClearSelected()

    End Sub
    Private Async Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles tsmiStartDbRaw.Click



        Await RunScriptAsync(
            scriptPath:=tbDatabaseStartDefault.Text,
            trigger:=btnRunDatabaseStartLive,
            statusText:="Starting database (force only)…",
            overrideArgs:=""   ' ✅ produces "-Force" only
        )

        DatabaseCoordinator.EvaluateDatabaseAvailability(
            form:=Me,
            connectionString:=ConfigValues.ConnectionString,
            configuredContainerName:=_options?.SqlContainerName
        )

        _uiStateController.Refresh()



    End Sub


    Private Sub btnBackupScriptPath_Click(sender As Object, e As EventArgs) Handles btnBackupScriptPath.Click

        With ofdStartScript
            .Title = "Select Backup Database Script"
            .Filter = "PowerShell Scripts (*.ps1)|*.ps1"
            .InitialDirectory = _options.RepoFolderPath
        End With

        If ofdStartScript.ShowDialog() = DialogResult.OK Then

            ' ✅ Store selected script path
            tbBackupScriptPath.Text = ofdStartScript.FileName

            ' ✅ Persist to options
            UpdateOption(Sub() _options.BackupScriptPath = ofdStartScript.FileName)
        End If
    End Sub

    Private Async Sub tsmiStartDbBackup_Click(sender As Object, e As EventArgs) Handles tsmiStartDbBackup.Click
        If String.IsNullOrWhiteSpace(tbBackupPathOverride.Text) Then
            MessageBox.Show(
                "Please enter a backup path.",
                "Missing Backup Path",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Dim backupPath As String = tbBackupPathOverride.Text.Trim()
        backupPath = String.Join("\", backupPath, "00Pathfinder.bak")

        ' Build argument string (Backup + Training DB)
        Dim args As String = $"-BackupPath ""{backupPath}"" -IncludeTrainingDB"


        Await RunScriptAsync(
            scriptPath:=tbDatabaseStartDefault.Text,
            trigger:=btnTest1,
            statusText:="Starting database (test with backup + training DB)…",
            overrideArgs:=args
        )

        DatabaseCoordinator.EvaluateDatabaseAvailability(
            form:=Me,
            connectionString:=ConfigValues.ConnectionString,
            configuredContainerName:=_options?.SqlContainerName
        )

        _uiStateController.Refresh()

    End Sub

    Private Async Sub tsmiBackupDb_Click(sender As Object, e As EventArgs) Handles tsmiBackupDb.Click
        Dim script As String = _options.BackupScriptPath


        If String.IsNullOrWhiteSpace(tbBackupPathOverride.Text) Then
            MessageBox.Show(
            "Please enter a backup directory.",
            "Missing Directory",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Dim directoryPath As String = tbBackupPathOverride.Text.Trim()

        ' Build argument string
        Dim args As String = $"-Directory ""{directoryPath}"""

        Await RunScriptAsync(
        scriptPath:=script,  ' or use a textbox if you have one
        trigger:=btnTest2,
        statusText:="Backing up database (force)…",
        flavors:=Nothing,
        overrideArgs:=args
    )

    End Sub

    Private Sub btnFlavorSave_Click(sender As Object, e As EventArgs) Handles btnFlavorSave.Click

        Using sfd As New SaveFileDialog()

            sfd.Filter = "SQL Files (*.sql)|*.sql"
            sfd.InitialDirectory = Path.GetDirectoryName(OptionsManager.GetOptionsPath())
            sfd.FileName = If(String.IsNullOrWhiteSpace(_options?.PersonalFlavorFileName),
                          "PersonalFlavor.sql",
                          _options.PersonalFlavorFileName)

            If sfd.ShowDialog() = DialogResult.OK Then

                Try
                    File.WriteAllText(sfd.FileName, tbFlavor.Text)

                    ' ✅ Save filename into options
                    _options.PersonalFlavorFileName = Path.GetFileName(sfd.FileName)
                    OptionsManager.Save(_options)

                    MessageBox.Show("Personal flavor saved.",
                                "Saved",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show("Failed to save file: " & ex.Message)
                End Try

            End If

        End Using

    End Sub
    Private Sub btnFlavorLoad_Click(sender As Object, e As EventArgs) Handles btnFlavorLoad.Click

        Using ofd As New OpenFileDialog()
            ofd.Filter = "SQL Files (*.sql)|*.sql|All Files (*.*)|*.*"

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    tbFlavor.Text = File.ReadAllText(ofd.FileName)
                Catch ex As Exception
                    MessageBox.Show("Failed to load file: " & ex.Message)
                End Try
            End If
        End Using

    End Sub
    Private Sub btnFlavorPaste_Click(sender As Object, e As EventArgs) Handles btnFlavorPaste.Click

        If Clipboard.ContainsText() Then
            tbFlavor.Text += Clipboard.GetText()
        End If

    End Sub

    Private Sub btnFlavorClear_Click(sender As Object, e As EventArgs) Handles btnFlavorClear.Click
        tbFlavor.Text = ""

    End Sub
    Private Async Sub btnApplyPersonalFlavor_Click(
    sender As Object,
    e As EventArgs
) Handles btnApplyPersonalFlavor.Click

        Try
            ' ✅ Ensure latest text is saved first
            OptionsManager.SavePersonalFlavor(tbFlavor.Text)

            Dim sourcePath = OptionsManager.GetPersonalFlavorPath()

            If Not File.Exists(sourcePath) Then
                MessageBox.Show("Personal flavor file not found.",
                            "Missing File",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Return
            End If

            If _options Is Nothing OrElse String.IsNullOrWhiteSpace(_options.RepoFolderPath) Then
                MessageBox.Show("Flavor folder path is not configured.",
                            "Configuration Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
                Return
            End If

            ' ✅ Use saved file name
            Dim destFileName = If(
            String.IsNullOrWhiteSpace(_options.PersonalFlavorFileName),
            "PersonalFlavor.sql",
            _options.PersonalFlavorFileName
        )

            Dim destPath = Path.Combine(_options.FlavorFolderPath, destFileName)

            Directory.CreateDirectory(_options.RepoFolderPath)

            File.Copy(sourcePath, destPath, True)

            ' ✅ Apply using filename (no extension)
            Dim flavors As New List(Of String) From {
            Path.GetFileNameWithoutExtension(destFileName)
        }

            Await RunScriptAsync(
            scriptPath:=tbApplyFlavorDefault.Text,
            trigger:=btnApplyPersonalFlavor,
            statusText:=$"Applying personal flavor ({destFileName})…",
            flavors:=flavors
        )

        Catch ex As Exception
            MessageBox.Show("Error applying personal flavor: " & ex.Message)
        End Try
        _flavorManager.RefreshPreservingSelection()
        SyncFlavorsListMirror()

    End Sub

    Private Sub btnFlavorsListRefresh_Click(sender As Object, e As EventArgs) Handles btnFlavorsListRefresh.Click
        _flavorManager.RefreshPreservingSelection()
        SyncFlavorsListMirror()

    End Sub
End Class
