Public Class ConnectionProfilesForm
    Private Sub btnLaunchConfig_Click(sender As Object, e As EventArgs) Handles btnLaunchConfig.Click

        Dim executable As String = "AdvConfig"

        Dim version As Integer = CodeHelper.AdvExeCheck(executable)

        If version = FormMain.AppInstallState.InstalledX86 Then
            executable = $"{AppData.CEPath86}{executable}.exe"
        ElseIf version = FormMain.AppInstallState.InstalledX64 Then
            executable = $"{AppData.CEPath64}{executable}.exe"
        End If

        If Not IO.File.Exists(executable) Then
            MessageBox.Show(
            $"Unable to locate:{Environment.NewLine}{executable}",
            "Application Not Found",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Process.Start(executable)

    End Sub
End Class