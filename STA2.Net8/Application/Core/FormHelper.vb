Imports System.Net.Http
Imports System.ServiceProcess
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms.Design.AxImporter

Public Module FormHelper

    Public Async Function StartQaApiAsync(
        commandLine As String,
        log As StringBuilder
    ) As Task(Of Boolean)

        If String.IsNullOrWhiteSpace(commandLine) Then

            log.AppendLine("No QA command line configured")

            Return False

        End If

        Try

            Dim parsed = QaScriptHelper.ParseCommand(commandLine)

            Dim scriptPath = parsed.ScriptPath
            Dim args = parsed.Args

            log.AppendLine($"Script Path: {scriptPath}")
            log.AppendLine($"Arguments: {args}")

            ' Already running?
            If QaScriptHelper.IsScriptRunning(scriptPath) Then

                log.AppendLine("QA API already running")

                Return True

            End If

            Const serviceName As String = "AdvApiServer"

            log.AppendLine($"Stopping service: {serviceName}")

            Await Task.Run(
                Sub()

                    Try

                        Using sc As New ServiceController(serviceName)

                            If sc.Status = ServiceControllerStatus.Running OrElse
                               sc.Status = ServiceControllerStatus.StartPending Then

                                sc.Stop()

                                sc.WaitForStatus(
                                    ServiceControllerStatus.Stopped,
                                    TimeSpan.FromSeconds(15))

                            End If

                        End Using

                    Catch ex As InvalidOperationException

                        log.AppendLine(
                            $"Service not installed: {serviceName}")

                    End Try

                End Sub)

            Dim psCommand As String =
                $"-ExecutionPolicy Bypass -Command ""& {{ $host.UI.RawUI.WindowTitle = 'QA API Server'; & '{scriptPath}' {args} }}"""

            log.AppendLine("Launching PowerShell process")

            Dim psi As New ProcessStartInfo With {
                .FileName = "powershell.exe",
                .Arguments = psCommand,
                .UseShellExecute = True,
                .CreateNoWindow = False
            }

            Process.Start(psi)

            log.AppendLine("QA API launched successfully")

            Return True

        Catch ex As Exception

            log.AppendLine(
                $"ERROR: {ex.GetType().Name}: {ex.Message}")

            Return False

        End Try

    End Function


    Public Async Function WaitForQaApiReadyAsync(
    Optional timeoutSeconds As Integer = 120,
    Optional updateText As Action(Of String) = Nothing,
    Optional cancellationToken As CancellationToken = Nothing
) As Task(Of Boolean)

        Const apiUrl As String =
            "http://localhost:15059/api/v1/version"

        Dim endTime =
            DateTime.UtcNow.AddSeconds(timeoutSeconds)

        Using client As New HttpClient()

            client.Timeout = TimeSpan.FromMilliseconds(500)

            While DateTime.UtcNow < endTime

                If cancellationToken.IsCancellationRequested Then
                    Return False
                End If

                Dim remaining As Integer =
                    CInt(Math.Ceiling(
                        (endTime - DateTime.UtcNow).TotalSeconds))

                updateText?.Invoke(
                    $"Waiting for QA Script ({remaining}s)")

                Try

                    Dim response =
                        Await client.GetAsync(apiUrl)

                    If response.IsSuccessStatusCode Then
                        Return True
                    End If

                Catch
                End Try

                Await Task.Delay(250)

            End While

        End Using

        Return False

    End Function
    Public Async Function IsQaApiReadyAsync() As Task(Of Boolean)

        Try

            Using client As New HttpClient()

                client.Timeout = TimeSpan.FromMilliseconds(500)

                Dim response =
                    Await client.GetAsync(
                        "http://localhost:15059/api/v1/version")

                Return response.IsSuccessStatusCode

            End Using

        Catch

            Return False

        End Try

    End Function
    Public Async Function RestartQaApiAsync(
        commandLine As String,
        log As StringBuilder
    ) As Task(Of Boolean)

        Try

            log.AppendLine(
                "Stopping existing QA API script instances")

            Await CodeHelper.KillQaScriptIfRunningAsync(
                commandLine)

            Const serviceName As String = "AdvApiServer"

            log.AppendLine(
                $"Stopping service: {serviceName}")

            Await Task.Run(
                Sub()

                    Try

                        Using sc As New ServiceController(serviceName)

                            If sc.Status = ServiceControllerStatus.Running OrElse
                               sc.Status = ServiceControllerStatus.StartPending Then

                                sc.Stop()

                                sc.WaitForStatus(
                                    ServiceControllerStatus.Stopped,
                                    TimeSpan.FromSeconds(15))

                            End If

                        End Using

                    Catch
                        ' Service not installed
                    End Try

                End Sub)

            log.AppendLine(
                "Restarting QA API")

            Return Await StartQaApiAsync(
                commandLine,
                log)

        Catch ex As Exception

            log.AppendLine(
                $"Restart failed: {ex.Message}")

            Return False

        End Try

    End Function
    Public Async Function StartQaServiceAsync(
    serviceName As String,
    log As StringBuilder
) As Task(Of Boolean)

        Try

            Using sc As New ServiceController(serviceName)

                If sc.Status =
                    ServiceControllerStatus.Running Then

                    log.AppendLine("API Service already running.")

                    Return True

                End If

                log.AppendLine($"Starting service: {serviceName}")

                sc.Start()

                Await Task.Run(
                    Sub()

                        sc.WaitForStatus(
                            ServiceControllerStatus.Running,
                            TimeSpan.FromSeconds(30))

                    End Sub)

                log.AppendLine("API Service started successfully.")

                Return True

            End Using

        Catch ex As Exception

            log.AppendLine($"Service start failed: {ex.Message}")

            Return False

        End Try

    End Function


    Public Function GetLastFailedLogBlock(content As String) As String

            If String.IsNullOrWhiteSpace(content) Then Return Nothing

            Dim separator As String =
                "===================================================="

            Dim parts As String() =
                content.Split(
                    New String() {separator},
                    StringSplitOptions.None)

            Dim failedBlock As String = Nothing

            For Each part As String In parts

                If String.IsNullOrWhiteSpace(part) Then Continue For

                If part.Contains(
                    "Exception Type:",
                    StringComparison.OrdinalIgnoreCase) OrElse
                   part.Contains(
                    "StackTrace:",
                    StringComparison.OrdinalIgnoreCase) Then

                    failedBlock = part.Trim()

                End If

            Next

            If String.IsNullOrWhiteSpace(failedBlock) Then
                Return Nothing
            End If

            Return separator &
                   Environment.NewLine &
                   failedBlock &
                   Environment.NewLine &
                   separator

        End Function
    Public Sub ShowErrorPopup(
    owner As IWin32Window,
    ex As Exception,
    source As String,
    viewLogsAction As Action)

        If ex Is Nothing Then Return

        Dim sb As New Text.StringBuilder()

        sb.AppendLine("Message:")
        sb.AppendLine(ex.Message)
        sb.AppendLine()

        sb.AppendLine("Source:")
        sb.AppendLine(source)
        sb.AppendLine()

        sb.AppendLine("Time:")
        sb.AppendLine(
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))

        Dim summary As String =
            sb.ToString()

        Dim result =
            UIHelpers.TimedErrorPrompt(
                owner:=owner,
                message:=summary,
                title:="Application Error",
                timeoutSeconds:=15,
                button1Text:="Dismiss",
                button1Result:=DialogResult.No,
                button2Text:="View Logs",
                button2Result:=DialogResult.Yes)

        If result = DialogResult.Yes Then

            viewLogsAction?.Invoke()

        End If

    End Sub
    Public Sub SetButtonIcon(btn As Button, imageName As String)
        btn.Image = ResourceHelper.LoadImage(imageName)
        btn.ImageAlign = ContentAlignment.MiddleCenter
    End Sub
    Public Sub InitializeUIEnhancements(
    form As FormMain,
    toolTip As ToolTip)
        Dim strTemp As String

        ' ✅ Button images
        SetButtonIcon(form.btnCopyScriptOutput, "imgCopy16.png")
        SetButtonIcon(form.btnRepoFolder, "imgOpenFolder16.png")
        SetButtonIcon(form.btnBrowseStartScript, "imgOpenFolder16.png")
        SetButtonIcon(form.btnBrowseApplyScript, "imgOpenFolder16.png")
        SetButtonIcon(form.btnBackupPathOverride, "imgOpenFolder16.png")
        SetButtonIcon(form.btnBackupScriptPath, "imgOpenFolder16.png")
        SetButtonIcon(form.btnFlavorsListRefresh, "imgRefresh16.png")
        SetButtonIcon(form.btnFlavorFileCopy, "imgCopyToFolder16.png")
        SetButtonIcon(form.btnRunQaCmdLine, "imgOpenFolder16.png")
        SetButtonIcon(form.btnInstallPathFallback, "imgOpenFolder16.png")
        SetButtonIcon(form.btnRefreshQaStatus, "imgRefresh16.png")

        toolTip.SetToolTip(form.btnRunApplyFlavorLive, "Applies your configured Default flavors")
        toolTip.SetToolTip(form.btnOpenLogFile, "Browse And open any log file")
        toolTip.SetToolTip(form.btnDbUseAdvVersion, "Sets the 'Start DB on specific version' text box value to match your installed Advantage version")
        toolTip.SetToolTip(form.btnBatchLaunch, "Launches all programs in the Application list that have been included in the Batch Launch list")
        toolTip.SetToolTip(form.btnAdminRestart, "Relaunches the application in Admin Mode to enable elevated options like Services controls")
        toolTip.SetToolTip(form.btnSetupInstall, "Extract downloaded ZIP file in UpgradePath location and then run the Advantage Installer")
        toolTip.SetToolTip(form.btnLaunchLatestInstaller, "Run the installer with the highest version number that is found in the UpgradePath contained in the database AppOptions setting")
        toolTip.SetToolTip(form.btnRepoDiscardChanges, "Discard changes that were made to the Advantage Repo locally")
        toolTip.SetToolTip(form.btnRepoMain, "Discard Advantage repo changes and switch the branch back to 'main'")
        toolTip.SetToolTip(form.btnManageInstallerVersions, "Open the Advantage Installer Versions Management window where Installers in the UpgradePath location can be managed and run if needed")
        toolTip.SetToolTip(form.btnExit, "Exit the Assistant")
        toolTip.SetToolTip(form.btnComboAppLaunch, "Launch the selected application showing on the drop down list")
        toolTip.SetToolTip(form.btnConnectionProfiles, "Manage saved PFSConnect.ini connection configurations")
        toolTip.SetToolTip(form.btnUpdateShiftDate, "Run database stored procedure To update the Advantage shift Date To today's date (exec ChangeShiftDate)")

        strTemp =
            "Starts the database with default flavors and optionally the value from Start DB Version box." & Environment.NewLine &
            "Right Click for other Start Database options:" & Environment.NewLine &
            " - Start with no flavors (raw)" & Environment.NewLine &
            " - Start with an existing 00Pathfinder backup" & Environment.NewLine &
            " - Backup the database to 00Pathfinder"

        toolTip.SetToolTip(form.btnRunDatabaseStartLive, strTemp)
        strTemp =
            "Launch the QA API in a separate PowerShell window." & Environment.NewLine &
            "Stops the AdvApiServer service If running, Then starts the configured script." & Environment.NewLine &
            "Prevents duplicate instances if already active."
        toolTip.SetToolTip(form.btnRunQaApi, strTemp)


        ' System tools
        toolTip.SetToolTip(form.btnCalc, "Open the Calculator included With Windows")
        toolTip.SetToolTip(form.btnTaskmgr, "Open the Windows Task Manager")
        toolTip.SetToolTip(form.btnAppWiz, "Open the Control Panel > Programs And Features window")
        toolTip.SetToolTip(form.btnEventViewer, "Open the Windows Event Viewer")
        toolTip.SetToolTip(form.btnDevices, "Open the Control Panel > Devices And Printers window")
        toolTip.SetToolTip(form.btnServices, "Open the Windows Services window")

        ' Advantage apps
        toolTip.SetToolTip(form.btnAdvManager, "Run Advantage Manager Console")
        toolTip.SetToolTip(form.btnPos, "Run Advantage POS")
        toolTip.SetToolTip(form.btnAdvGroups, "Run Advantage Groups")
        toolTip.SetToolTip(form.btnAdvKioskSetup, "Run Advantage Legacy Kiosk Setup")
        toolTip.SetToolTip(form.btnAdvReportEditor, "Run Advantage Report Editor")
        toolTip.SetToolTip(form.btnAdvRedeem, "Run Advantage Redemption")
        toolTip.SetToolTip(form.btnAdvCardTech, "DESCRIPTION")
        toolTip.SetToolTip(form.btnAdvKiosk, "Run Advantage Legacy Kiosk")
        toolTip.SetToolTip(form.btnAdvUpgrade, "Run Advantage Upgrade (AdvUpgrade.exe)")

        ' ✅ Hover hints
        toolTip.SetToolTip(form.
            lbFlavorsList,
            "🖱 Right-click → Apply selected flavors" & vbCrLf &
            "⚡ Double-click → Apply highlighted"
        )
        toolTip.SetToolTip(form.btnFlavorsListRefresh, "Refresh the list Of flavors from the configured flavor folder")
        toolTip.SetToolTip(form.btnFlavorFileCopy, "Copy SQL Files into the Repo's flavor folder (Determined by the Repo Folder on the Options tab")

        toolTip.SetToolTip(form.tbDbUseVersion, "Enter a database version to use with Start-Database to set the database version.  Example:  26.1.1")
        toolTip.SetToolTip(form.cbDbUseVersion, "Enable the Use Database version option for Start-Database")
        toolTip.SetToolTip(form.cmbboxAppLaunch, "Click to drop down applications that can be opened with the Launch button.  Applications in the list are set on the Options tab but are not assigned to a Quick Launch button")

        ' ✅ Hover hints for Options Tab
        toolTip.SetToolTip(form.tbWindowTitle, "You can set a name for the application here that will display in the title bar.  Example:  My Assistant")
        toolTip.SetToolTip(form.tbRepoFolder, "Select your repository root folder")
        toolTip.SetToolTip(form.tbSetupSwitches, "Specify the command line switches to use when running the Advantage Installer")
        toolTip.SetToolTip(form.cbShowHiddenServices, "Check this box to show all Advantage services in the Services List even if they are not installed.  Unchecked only the installed services will show")
        toolTip.SetToolTip(form.tbDatabaseStartDefault, "This is the path to the script to start the docker database (Start-Database.ps1)")
        toolTip.SetToolTip(form.tbApplyFlavorDefault, "This is the path to the script to apply flavors to the running docker database (Apply-Flavors.ps1)")
        toolTip.SetToolTip(form.lstPrograms, "List of applications configured to be used from Assistant App for the Quick Launch buttons, the launch list, and the Batch Launch button")
        toolTip.SetToolTip(form.clbSqlFiles, "This is the list of flavors detected in the Repo's flavor folder.  You can check the flavors' checkbox to add it to the list of defaults used by the Apply Default Flavors and Start Database buttons")
        toolTip.SetToolTip(form.tbBackupPathOverride, "This is the path to the folder that contains backup files like 00Pathfinder.bak")
        toolTip.SetToolTip(form.tbBackupScriptPath, "This is the path to the script to backup the database to the backup folder (Backup-Database.ps1)")

        toolTip.SetToolTip(form.tbRunQaCmdLine, "Enter the QA API script path and any command line switches." & Environment.NewLine & "The script will be launched In a separate PowerShell window.")
        toolTip.SetToolTip(form.btnRunQaCmdLine, "Browse And select a QA API script." & Environment.NewLine & "You will be prompted to enter optional command line switches after selection.")
        toolTip.SetToolTip(form.btnInstallPathFallback, "Select a fallback folder patch that installers are saved to if this is a station and not a server")

        toolTip.SetToolTip(form.btnAdd, "Add a New application To the Application Launcher Settings")
        toolTip.SetToolTip(form.btnEdit, "Edit the program selected In the Application Launcher Settings")
        toolTip.SetToolTip(form.btnDelete, "Delete the program selected In the Application Launcher Settings")
        toolTip.SetToolTip(form.btnLaunch, "Launch the program selected In the Application Launcher Settings")
        toolTip.SetToolTip(form.btnResetFlavorDefaults, "Resets the list Of Default Flavors Selections To the defaults that were previously saved")
        toolTip.SetToolTip(form.btnSaveFlavorDefaults, "Save the currently selected flavors In the Default Flavors Selection list As the New Default selections")

        toolTip.SetToolTip(form.cbAdvUpgradeNoBackup, "Run the Advantage Upgrade without creating a database backup file during the process")
        toolTip.SetToolTip(form.cbAdvUpgradeNoSetup, "Run the Advantage Upgrade without running the Advantage Setup When the database upgrade has finished")
        toolTip.SetToolTip(form.cbAdvUpgradeQuiet, "Run the Advantage Upgrade In a command prompt without a window")
        toolTip.SetToolTip(form.tbAdvupgrade, "Example Of the command line that will be used With the selected switches")
        toolTip.SetToolTip(form.btnRepoFolder, "Select the base folder For the Advantage Repo.  This Is the folder that contains the 'tests' folder and the 'flavors' folder")
        toolTip.SetToolTip(form.btnBrowseApplyScript, "Select the script to apply flavors to the running database (Apply-Flavors.ps1)")
        toolTip.SetToolTip(form.btnBrowseStartScript, "Select the script to start the database (Start-Database.ps1)")
        toolTip.SetToolTip(form.btnBackupScriptPath, "Select the script to start the database (Backup-Database.ps1)")
        toolTip.SetToolTip(form.btnBackupPathOverride, "Select the folder to store database backup files in.  If not set default to the database value from AppOptions")

        ' ✅ Hover hints for Logs Tab
        toolTip.SetToolTip(form.btnOpenLogFile, "Opens the folder containing the log files In a Open File box To Select a log file")
        toolTip.SetToolTip(form.btnViewLatestLog, "Opens the log file For today To see the latest log entries")
        toolTip.SetToolTip(form.btnLastLogBlock, "Displays the very last script execution log In a message box")
        toolTip.SetToolTip(form.btnLastFailed, "Displays the last Error encountered In a message box")
        toolTip.SetToolTip(form.btnClearActivityLog, "Deletes the contents of the log file For today and creates an entry to note it in the log file")

        ' ✅ Hover hints for Personal Flavor Tab
        toolTip.SetToolTip(form.btnFlavorLoad, "Opens a file dialog box to load a set of SQL queries from a selected SQL file ")
        toolTip.SetToolTip(form.btnFlavorSave, "Opens a file dialog box to save the queries in the window to a SQL file for use as a personal flavor")
        toolTip.SetToolTip(form.btnFlavorClear, "Clears the contents of the text entry")
        toolTip.SetToolTip(form.btnFlavorPaste, "Paste queries to the text entry from the Clipboard")
        toolTip.SetToolTip(form.tbFlavor, "One or more SQL queries to be used as a 'Personal Flavor' that can be applied with the Apply Personal Flavor button")




        toolTip.SetToolTip(form.btnRefreshAdvDataTab, "Refresh the Advantage Data shown above from the tables ApplicationInfo, AppOptions, and WebOptions")



    End Sub

End Module
