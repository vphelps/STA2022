Imports System.Diagnostics
Imports System.IO

Public Module RepoTools

    Public Sub RunGitCommand(repoPath As String, arguments As String)
        If String.IsNullOrWhiteSpace(repoPath) OrElse Not Directory.Exists(repoPath) Then
            Throw New DirectoryNotFoundException($"Repository path not found: {repoPath}")
        End If

        Dim psi As New ProcessStartInfo("git", arguments) With {
            .WorkingDirectory = repoPath,
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True
        }

        Using p As Process = Process.Start(psi)
            Dim stdout As String = p.StandardOutput.ReadToEnd()
            Dim stderr As String = p.StandardError.ReadToEnd()
            p.WaitForExit()

            If p.ExitCode <> 0 Then
                Throw New InvalidOperationException(
                    $"Git command failed:{Environment.NewLine}{stderr}")
            End If
        End Using
    End Sub

    ' GitHub Desktop equivalent: "Discard all changes"
    Public Sub DiscardAllChanges(repoPath As String)
        RunGitCommand(repoPath, "reset --hard")
        RunGitCommand(repoPath, "clean -fd")
    End Sub

    ' Optional: preview what will be deleted (dry run)
    Public Function PreviewDiscard(repoPath As String) As String
        Dim psi As New ProcessStartInfo("git", "clean -fdn") With {
            .WorkingDirectory = repoPath,
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .RedirectStandardOutput = True
        }

        Using p As Process = Process.Start(psi)
            Dim output = p.StandardOutput.ReadToEnd()
            p.WaitForExit()
            Return output
        End Using
    End Function

End Module
