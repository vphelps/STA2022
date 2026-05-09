Imports System.Data.SqlClient
Imports System.Linq
Imports System.Security.Principal
Imports System.Threading
Imports System.Windows.Forms

Module Startup

    Public Property MainFormInstance As FormMain

    <STAThread()>
    Sub Main()

        ' =====================================================
        ' GLOBAL ERROR HANDLING (FIRST – BEFORE ANY OTHER CODE)
        ' =====================================================
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)

        AddHandler Application.ThreadException,
            AddressOf GlobalErrorHandler.HandleThreadException

        AddHandler AppDomain.CurrentDomain.UnhandledException,
            AddressOf GlobalErrorHandler.HandleUnhandledException

        ' =====================================================
        ' REQUIRED WINFORMS INITIALIZATION
        ' =====================================================
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        ' =====================================================
        ' LOAD & NORMALIZE APPLICATION OPTIONS
        ' =====================================================
        Dim options = OptionsManager.LoadOrCreate()

        If OptionsManager.TrimTrailingEmptyQuickSlots(options) Then
            OptionsManager.Save(options)
        End If

        If options.QuickLaunchIds Is Nothing Then
            options.QuickLaunchIds =
                Enumerable.Repeat("", GenericConstants.QUICKLAUNCH_SLOT_COUNT).ToList()
        ElseIf options.QuickLaunchIds.Count < GenericConstants.QUICKLAUNCH_SLOT_COUNT Then
            While options.QuickLaunchIds.Count < GenericConstants.QUICKLAUNCH_SLOT_COUNT
                options.QuickLaunchIds.Add("")
            End While
        End If

        ' Persist upgraded layout once
        OptionsManager.Save(options)

        Dim launcher = OptionsManager.LoadLauncherConfig()

        ' =====================================================
        ' LOAD INI / APP SETTINGS
        ' =====================================================
        Connections.IniFileHandler(False)

        ' =====================================================
        ' PROCESS COMMAND-LINE ARGUMENTS
        ' =====================================================
        Dim args = Environment.GetCommandLineArgs().Skip(1).ToList()

        If args.Contains("-BatchLaunch", StringComparer.OrdinalIgnoreCase) Then

            ' Batch mode: no UI, silent execution
            Dim result = BatchLauncher.RunBatch(
                launcher,
                caller:="Startup:-BatchLaunch",
                silent:=True)

            ' Exit code reflects batch success/failure
            Environment.Exit(If(result.Failed > 0, 1, 0))
            Return
        End If

        ' =====================================================
        ' CREATE MAIN FORM EARLY (needed for ownership & state)
        ' =====================================================
        MainFormInstance = New FormMain(options, launcher)

        ' =====================================================
        ' INITIALIZE DATABASE INFRASTRUCTURE
        ' =====================================================
        ReliableSql.Initialize(ConfigValues.ConnectionString)

        ' =====================================================
        ' DOCKER-FIRST STARTUP CHECK
        ' =====================================================
        Dim canAttemptDatabase As Boolean =
    DatabaseCoordinator.CanAttemptDatabaseStartup(
        configuredContainerName:=options.SqlContainerName)

        If canAttemptDatabase Then
            ' Docker & container are available — now test SQL connectivity
            If Not DatabaseCoordinator.TestConnection(ConfigValues.ConnectionString, 5) Then

                Dim decision As DialogResult =
            UIHelpers.TimedYesNoPrompt(
                owner:=Nothing,
                message:=
                    "Docker is running, but the database cannot be reached." &
                    Environment.NewLine & Environment.NewLine &
                    "Do you want to start the application in OFFLINE mode?",
                title:="Database Unavailable",
                timeoutSeconds:=10,
                defaultChoice:=DialogResult.Yes)

                If decision = DialogResult.No Then
                    ' ❌ User chose to quit
                    Application.Exit()
                    Environment.Exit(0)
                    Return
                End If

                ' ✅ Timeout or Yes → Offline mode
                Variables.OfflineMode = True
                PCInfo.ValidDatabase = False

            End If
        Else
            ' Docker itself is not available
            Dim decision As DialogResult =
        UIHelpers.TimedYesNoPrompt(
            owner:=Nothing,
            message:=
                "Docker or the SQL container is not running." &
                Environment.NewLine & Environment.NewLine &
                "Do you want to start the application in OFFLINE mode?",
            title:="Docker Unavailable",
            timeoutSeconds:=10,
            defaultChoice:=DialogResult.Yes)

            If decision = DialogResult.No Then
                Application.Exit()
                Environment.Exit(0)
                Return
            End If

            Variables.OfflineMode = True
            PCInfo.ValidDatabase = False
        End If

        ' =====================================================
        ' NORMAL UI STARTUP
        ' =====================================================
        CodeHelper.GetPcInfo()

        AdminUser(IsRunningAsAdmin())

        Application.Run(MainFormInstance)

    End Sub

    ' =====================================================
    ' ADMIN CHECKS
    ' =====================================================
    Public Function IsRunningAsAdmin() As Boolean
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Public Sub AdminUser(isAdmin As Boolean)

        If MainFormInstance Is Nothing Then Exit Sub

        MainFormInstance.tbServicesButtonsHelpMessage.Visible = Not isAdmin

    End Sub

End Module