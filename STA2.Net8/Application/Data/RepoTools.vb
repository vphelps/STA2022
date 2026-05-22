Imports System.Diagnostics
Imports System.IO

' ===========================================================
' RepoTools
'
' Helper functions for interacting with a local Git repository
' in a way that stays fully compatible with GitHub Desktop.
'
' All commands operate directly on the Git repository using
' the Git CLI; GitHub Desktop automatically reflects changes.
' ===========================================================

Public Module RepoTools

    ' -------------------------------------------------------
    ' Core Git command runner
    ' -------------------------------------------------------
    Public Sub RunGitCommand(repoPath As String, arguments As String)

        If String.IsNullOrWhiteSpace(repoPath) OrElse
           Not Directory.Exists(repoPath) Then

            Throw New DirectoryNotFoundException(
                $"Repository path not found: {repoPath}")
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


    ' -------------------------------------------------------
    ' Check for uncommitted changes
    ' -------------------------------------------------------
    Public Function HasUncommittedChanges(repoPath As String) As Boolean

        Dim psi As New ProcessStartInfo("git", "status --porcelain") With {
            .WorkingDirectory = repoPath,
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .RedirectStandardOutput = True
        }

        Using p As Process = Process.Start(psi)
            Dim output As String = p.StandardOutput.ReadToEnd()
            p.WaitForExit()

            Return Not String.IsNullOrWhiteSpace(output)
        End Using
    End Function


    ' -------------------------------------------------------
    ' Discard all local changes
    ' Equivalent to GitHub Desktop: "Discard all changes"
    ' -------------------------------------------------------
    Public Sub DiscardAllChanges(repoPath As String)
        RunGitCommand(repoPath, "reset --hard")
        RunGitCommand(repoPath, "clean -fd")
    End Sub


    ' -------------------------------------------------------
    ' Preview what would be deleted by discard (dry run)
    ' -------------------------------------------------------
    Public Function PreviewDiscard(repoPath As String) As String

        Dim psi As New ProcessStartInfo("git", "clean -fdn") With {
            .WorkingDirectory = repoPath,
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .RedirectStandardOutput = True
        }

        Using p As Process = Process.Start(psi)
            Dim output As String = p.StandardOutput.ReadToEnd()
            p.WaitForExit()
            Return output
        End Using
    End Function


    ' -------------------------------------------------------
    ' Switch to the main branch
    '
    ' Uses modern `git switch` and falls back to
    ' `git checkout` for compatibility.
    ' -------------------------------------------------------
    Public Sub SwitchToMainBranch(repoPath As String)

        Try
            ' Preferred modern syntax
            RunGitCommand(repoPath, "switch main")
        Catch
            ' Fallback for older Git versions
            RunGitCommand(repoPath, "checkout main")
        End Try
    End Sub

End Module
