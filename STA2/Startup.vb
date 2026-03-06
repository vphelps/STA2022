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
        'Dim iniPath = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbconfig.ini")
        'LoadAppSettingsFromIni(iniPath)   ' <-- YOUR loader
        Connections.IniFileHandler(False)
        If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then Variables.LoggedIn = True Else Variables.LoggedIn = False

        'CodeHelper.AdminUser(Variables.LoggedIn)
        'CodeHelper.FirstLoad()

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
        Console.Write(options.WindowTitle)

        ' Create the main form and pass options in the constructor.

        MainFormInstance = New FormMain(options)
        Application.Run(MainFormInstance)

        ' If you later add options like StartMinimized, apply here.
        ' Example: If options.StartMinimized Then frm.WindowState = FormWindowState.Minimized



    End Sub

End Module