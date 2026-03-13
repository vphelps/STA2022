Imports System
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Security.Principal
Imports System.Threading
Imports System.Windows.Forms

Module Startup
    Public Property MainFormInstance As FormMain

    <STAThread()>
    Sub Main()
        ' Always required for WinForms:
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        ' ------------------------------
        ' Global exception handlers (last resort: prevent crash-to-desktop)
        ' ------------------------------
        Dim options = OptionsManager.LoadOrCreate()
        If OptionsManager.TrimTrailingEmptyQuickSlots(options) Then
            OptionsManager.Save(options)
        End If
        Dim launcher = OptionsManager.LoadLauncherConfig()

        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
        AddHandler Application.ThreadException, AddressOf OnThreadException
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf OnUnhandledException

        ' ============================
        ' Load INI / AppSettings here
        ' ============================
        Connections.IniFileHandler(False)

        ' ============================
        ' Process command-line switches here
        ' ============================
        Dim args = Environment.GetCommandLineArgs().Skip(1).ToList()



        If args.Contains("-BatchLaunch", StringComparer.OrdinalIgnoreCase) Then
            ' Load configs (no UI)
            Connections.IniFileHandler(False)

            ' Batch run without loading FormMain
            Dim result = BatchLauncher.RunBatch(launcher,
                                        caller:="Startup:-BatchLaunch",
                                        silent:=True)

            ' Optional: reflect result in exit code
            Environment.Exit(If(result.Failed > 0, 1, 0))
            Return
        End If

        ' ============================
        ' Initialize ReliableSql
        ' ============================
        ' Use the same connection string built in IniFileHandler
        ReliableSql.Initialize(ConfigValues.ConnectionString)

        ' ============================
        ' Probe DB connectivity (Retry / Offline / Exit)
        ' ============================
        ' If the probe returns True => Online
        ' If the probe returns False => Offline mode (no crash, app stays usable)
        Variables.OfflineMode = Not ProbeDatabaseWithPrompt()

        ' ============================
        ' Normal UI startup
        ' ============================
        CodeHelper.GetPcInfo()

        MainFormInstance = New FormMain(options, launcher)

        ' Create the main form and pass options in the constructor.
        MainFormInstance = New FormMain(options, launcher)
        AdminUser(IsRunningAsAdmin())

        Application.Run(MainFormInstance)

        ' If you later add options like StartMinimized, apply here.
        ' Example: If options.StartMinimized Then frm.WindowState = FormWindowState.Minimized
    End Sub

    ' ------------------------------
    ' Global exception handlers
    ' ------------------------------
    Private Sub OnThreadException(sender As Object, e As Threading.ThreadExceptionEventArgs)
        MessageBox.Show(
            "Unexpected error: " & e.Exception.Message,
            "Application Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )
        ' Optional: log it
        ' ErrorHandler.ErrorHandler(e.Exception.Message, e.Exception.StackTrace)
    End Sub

    Private Sub OnUnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex = TryCast(e.ExceptionObject, Exception)
        MessageBox.Show(
            "Unexpected fatal error: " & If(ex IsNot Nothing, ex.Message, "(unknown)"),
            "Application Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )
        ' Optional: log it
        ' ErrorHandler.ErrorHandler(ex?.Message, ex?.StackTrace)
    End Sub

    ' ------------------------------
    ' Connectivity probe (Retry / Offline / Exit)
    ' Returns True if online, False if offline; exits if user chooses Exit.
    ' ------------------------------
    Private Function ProbeDatabaseWithPrompt() As Boolean
        ' Fast path
        If TestConnection(ConfigValues.ConnectionString) Then Return True

        ' Show a clear prompt allowing Retry / Offline / Exit (Yes / No / Cancel)
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
                    ' Retry
                    If TestConnection(ConfigValues.ConnectionString) Then Return True
                    Thread.Sleep(1000) ' small backoff

                Case DialogResult.No
                    ' Work Offline (allow app to start without DB)
                    Return False

                Case DialogResult.Cancel
                    ' Exit gracefully
                    Application.Exit()
                    Environment.Exit(0)

                    Return False ' <-- Satisfy compiler (unreachable at runtime)

            End Select
        End While

        Return False ' <-- Satisfy compiler (unreachable at runtime)
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
    Public Function IsRunningAsAdmin() As Boolean
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Public Sub AdminUser(Admin As Boolean)

        MainFormInstance.flpServices.Enabled = Admin
        MainFormInstance.tbServicesButtonsHelpMessage.Visible = Not (Admin)

    End Sub
End Module