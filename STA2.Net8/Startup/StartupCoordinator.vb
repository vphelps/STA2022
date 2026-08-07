Public Class StartupCoordinator

    Private ReadOnly _form As FormMain

    Public Sub New(form As FormMain)

        _form = form

    End Sub
    Public Sub Initialize()

    End Sub
    Public Sub PerformInitialRefresh()

        CodeHelper.GetPcInfo()

        Connections.IniFileHandler(False)

        CodeHelper.FirstLoad()

        CodeHelper.Refresher()

    End Sub
    Public Sub EvaluateDatabase()

        DatabaseCoordinator.EvaluateDatabaseAvailability(
            form:=_form,
            connectionString:=ConfigValues.ConnectionString,
            configuredContainerName:=_form._options?.SqlContainerName)

    End Sub
    Public Sub RunStartupSequence()

        PerformInitialRefresh()

        EvaluateDatabase()

    End Sub

End Class