Imports System.IO

Public Module BatchLauncher

    ' Launch all IncludeInBatch apps without needing FormMain or UI
    Public Sub RunBatch(launcherConfig As LauncherConfig)
        If launcherConfig Is Nothing OrElse launcherConfig.Programs Is Nothing Then
            Return
        End If

        Dim batch = launcherConfig.Programs.
                    Where(Function(x) x IsNot Nothing AndAlso x.Enabled AndAlso x.IncludeInBatch).
                    ToList()

        For Each p In batch
            Try
                If String.IsNullOrWhiteSpace(p.Path) OrElse Not File.Exists(p.Path) Then
                    Continue For
                End If

                Dim psi As New ProcessStartInfo() With {
                    .FileName = p.Path,
                    .Arguments = If(p.Arguments, ""),
                    .WorkingDirectory = If(String.IsNullOrWhiteSpace(p.WorkingDirectory),
                                           Path.GetDirectoryName(p.Path),
                                           p.WorkingDirectory),
                    .UseShellExecute = True
                }

                If p.RunAsAdmin Then psi.Verb = "runas"

                Process.Start(psi)

            Catch
                ' Silent mode: ignore failures
            End Try
        Next
    End Sub

End Module