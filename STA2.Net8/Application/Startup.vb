Imports Microsoft.Data.SqlClient
Imports System.Linq
Imports System.Security.Principal
Imports System.Threading
Imports System.Windows.Forms

Module Startup

    Public Property MainFormInstance As FormMain

    <STAThread()>
    Sub Main()

        ' =====================================================
        ' GLOBAL ERROR HANDLING
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

            Dim result = BatchLauncher.RunBatch(
                launcher,
                caller:="Startup:-BatchLaunch",
                silent:=True)

            Environment.Exit(If(result.Failed > 0, 1, 0))
            Return
        End If

        ' =====================================================
        ' ✅ DATABASE AVAILABILITY CHECK (UPDATED LOGIC)
        ' Supports Docker OR Local SQL Server
        ' =====================================================
        Dim dbAvailable As Boolean =
            DatabaseCoordinator.TestConnection(ConfigValues.ConnectionString, 5)

        If Not dbAvailable Then

            Dim decision As DialogResult =
                UIHelpers.TimedYesNoPrompt(
                    owner:=Nothing,
                    message:=
                        "The database cannot be reached." & Environment.NewLine & Environment.NewLine &
                        "This may be because:" & Environment.NewLine &
                        "• Docker is not running" & Environment.NewLine &
                        "• SQL Server is not running" & Environment.NewLine &
                        "• Connection settings are incorrect" & Environment.NewLine & Environment.NewLine &
                        "Do you want to start the application in OFFLINE mode?",
                    title:="Database Unavailable",
                    timeoutSeconds:=10,
                    defaultChoice:=DialogResult.Yes,
                    icon:=SystemIcons.Error)

            If decision = DialogResult.No Then
                Application.Exit()
                Environment.Exit(0)
                Return
            End If

            ' ✅ Offline mode
            Variables.OfflineMode = True
            PCInfo.ValidDatabase = False

        End If

        ' =====================================================
        ' CREATE MAIN FORM
        ' =====================================================
        MainFormInstance = New FormMain(options, launcher)

        ' =====================================================
        ' INITIALIZE DATABASE INFRASTRUCTURE
        ' =====================================================
        ReliableSql.Initialize(ConfigValues.ConnectionString)

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