Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Public Module ProgramLauncher

    Public Sub Launch(entry As ProgramEntry)

        If entry Is Nothing Then
            ShowWarning("Invalid program entry.")
            Return
        End If

        If String.IsNullOrWhiteSpace(entry.Path) Then
            ShowWarning("Program path is empty.")
            Return
        End If

        If Not File.Exists(entry.Path) Then
            ShowWarning($"File not found:{Environment.NewLine}{entry.Path}")
            Return
        End If

        Try
            Dim psi As New ProcessStartInfo With {
                .FileName = entry.Path,
                .Arguments = If(entry.Arguments, ""),
                .WorkingDirectory =
                    If(String.IsNullOrWhiteSpace(entry.WorkingDirectory),
                       Path.GetDirectoryName(entry.Path),
                       entry.WorkingDirectory),
                .UseShellExecute = True
            }

            If entry.RunAsAdmin Then
                psi.Verb = "runas"
            End If

            Process.Start(psi)

        Catch ex As Exception
            MessageBox.Show(
                "Failed to launch program:" &
                Environment.NewLine &
                ex.Message,
                "Launch Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ShowWarning(message As String)
        MessageBox.Show(
            message,
            "Launch",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
    End Sub

End Module