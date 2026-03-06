Imports System.Security.Principal
Imports System.Windows.Forms

Module Startup

    Public Property MainFormInstance As FormMain

    <STAThread()>
    Sub Main()
        ' Always required for WinForms:
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        '' ============================
        '' Load your INI / AppSettings here
        '' ============================
        Connections.IniFileHandler(False)

        ' ============================
        ' Process command‑line switches here
        ' ============================
        Dim args = Environment.GetCommandLineArgs().Skip(1).ToList()

        If args.Contains("-BatchLaunch", StringComparer.OrdinalIgnoreCase) Then
            'RunBatchAndExit()
            MsgBox("Batch Load Switch Detected")
            Return
        End If



        ' ============================
        ' Normal UI startup
        ' ============================


        CodeHelper.GetPcInfo()

        Dim options As AppOptions = OptionsManager.LoadOrCreate()
        Dim launcher = OptionsManager.LoadLauncherConfig()

        ' Create the main form and pass options in the constructor.
        MainFormInstance = New FormMain(options, launcher)
        AdminUser(IsRunningAsAdmin())
        Application.Run(MainFormInstance)

        ' If you later add options like StartMinimized, apply here.
        ' Example: If options.StartMinimized Then frm.WindowState = FormWindowState.Minimized



    End Sub
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