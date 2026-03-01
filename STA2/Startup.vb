Imports System.Windows.Forms

Module Startup

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

        CodeHelper.AdminUser(Variables.LoggedIn)
        CodeHelper.FirstLoad()

        ' ============================
        ' Process command‑line switches here
        ' ============================
        Dim args = Environment.GetCommandLineArgs().Skip(1).ToList()

        If args.Contains("-batch", StringComparer.OrdinalIgnoreCase) Then
            'RunBatchAndExit()
            Return
        End If

        ' ============================
        ' Normal UI startup
        ' ============================
        CodeHelper.GetPcInfo()

        Application.Run(New FormMain())
    End Sub

End Module