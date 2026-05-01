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
            Connections.IniFileHandler(False)

            Dim result = BatchLauncher.RunBatch(
                launcher,
                caller:="Startup:-BatchLaunch",
                silent:=True)

            ' Exit code reflects batch success/failure
            Environment.Exit(If(result.Failed > 0, 1, 0))
            Return
        End If

        ' =====================================================
        ' INITIALIZE DATABASE INFRASTRUCTURE
        ' =====================================================
        ReliableSql.Initialize(ConfigValues.ConnectionString)

        ' =====================================================
        ' PROBE DATABASE CONNECTIVITY
        ' =====================================================
        Variables.OfflineMode = Not ProbeDatabaseWithPrompt()

        ' =====================================================
        ' NORMAL UI STARTUP
        ' =====================================================
        CodeHelper.GetPcInfo()

        MainFormInstance = New FormMain(options, launcher)

        AdminUser(IsRunningAsAdmin())

        Application.Run(MainFormInstance)

    End Sub

    ' =====================================================
    ' CONNECTIVITY PROBE (Retry / Offline / Exit)
    ' =====================================================
    Private Function ProbeDatabaseWithPrompt() As Boolean

        ' Fast path
        If TestConnection(ConfigValues.ConnectionString) Then
            Return True
        End If

        While True
            Dim dr = MessageBox.Show(
                "The database is not reachable." & Environment.NewLine &
                "Check your network/server and try again." & Environment.NewLine & Environment.NewLine &
                "Yes = Retry" & Environment.NewLine &
                "No = Work Offline" & Environment.NewLine &
                "Cancel = Exit Application",
                "Database Connection",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1
            )

            Select Case dr
                Case DialogResult.Yes
                    If TestConnection(ConfigValues.ConnectionString) Then
                        Return True
                    End If
                    Thread.Sleep(1000)

                Case DialogResult.No
                    ' Work Offline
                    Return False

                Case DialogResult.Cancel
                    ' Exit gracefully
                    Application.Exit()
                    Environment.Exit(0)
                    Return False ' compiler safety
            End Select
        End While
        Return False

    End Function

    Private Function TestConnection(connStr As String) As Boolean
        If String.IsNullOrWhiteSpace(connStr) Then Return False

        Try
            Using cn As New SqlConnection(connStr)
                cn.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function

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

        MainFormInstance.flpServicesOld.Enabled = isAdmin
        MainFormInstance.tbServicesButtonsHelpMessage.Visible = Not isAdmin

    End Sub

End Module