Imports System.Diagnostics
Imports System.IO
Imports System.Threading.Tasks

Public Module PowerShellRunner

    Public Async Function RunWithLiveOutputAsync(
        scriptPath As String,
        argumentsText As String,
        workingDirectory As String,
        onOutput As Action(Of String),
        onError As Action(Of String)
    ) As Task(Of Integer)

        If String.IsNullOrWhiteSpace(scriptPath) Then
            Throw New ArgumentException("scriptPath is required.")
        End If

        If Not File.Exists(scriptPath) Then
            Throw New FileNotFoundException("Script not found.", scriptPath)
        End If

        Dim psArguments As String =
            $"-ExecutionPolicy Bypass -Command & {Quote(scriptPath)} {argumentsText}"

        Dim psi As New ProcessStartInfo With {
            .FileName = "pwsh.exe",
            .Arguments = psArguments,
            .UseShellExecute = False,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .CreateNoWindow = True,
            .WorkingDirectory = workingDirectory
        }

        Using proc As New Process With {.StartInfo = psi}

            AddHandler proc.OutputDataReceived,
                Sub(sender, e)
                    If e.Data IsNot Nothing Then
                        onOutput?.Invoke(e.Data)
                    End If
                End Sub

            AddHandler proc.ErrorDataReceived,
                Sub(sender, e)
                    If e.Data IsNot Nothing Then
                        onError?.Invoke(e.Data)
                    End If
                End Sub

            proc.Start()
            proc.BeginOutputReadLine()
            proc.BeginErrorReadLine()

            ' Wait for completion asynchronously
            Await Task.Run(Sub() proc.WaitForExit())
            proc.WaitForExit() ' ensure async streams are flushed

            Return proc.ExitCode
        End Using

    End Function


    ' --------------------------------------------
    ' High-level helper used by FormMain
    ' --------------------------------------------
    Public Async Function RunLiveScriptAsync(
        options As AppOptions,
        liveOutputManager As LiveOutputManager,
        setStatus As Action(Of String),
        triggerButton As Button,
        scriptRelativePath As String,
        scriptArgs As String,
        runningStatusText As String
    ) As Task

        triggerButton.Enabled = False

        Try
            If options Is Nothing OrElse
               String.IsNullOrWhiteSpace(options.RepoFolderPath) Then

                setStatus.Invoke("Repo folder path not set")
                Return
            End If

            Dim scriptPath As String =
                Path.Combine(options.RepoFolderPath, scriptRelativePath)

            setStatus.Invoke(runningStatusText)

            Await RunPowerShellFileWithLiveOutputAsync(
                scriptPath,
                scriptArgs,
                liveOutputManager)

            setStatus.Invoke(String.Empty)

        Catch ex As Exception
            setStatus.Invoke(String.Empty)

        Finally
            triggerButton.Enabled = True
        End Try

    End Function

    ' --------------------------------------------
    ' Core execution + live output plumbing
    ' --------------------------------------------
    Public Async Function RunPowerShellFileWithLiveOutputAsync(
        scriptPath As String,
        argumentsText As String,
        liveOutputManager As LiveOutputManager
    ) As Task(Of Integer)

        liveOutputManager.StartExecution(scriptPath)

        Dim workingDir As String =
            Path.GetDirectoryName(scriptPath)

        Dim exitCode As Integer =
            Await RunWithLiveOutputAsync(
                scriptPath:=scriptPath,
                argumentsText:=argumentsText,
                workingDirectory:=workingDir,
                onOutput:=Sub(line)
                              liveOutputManager.AppendLine(line)
                          End Sub,
                onError:=Sub(line)
                             liveOutputManager.AppendLine(line)
                         End Sub)

        liveOutputManager.CompleteExecution(exitCode)

        Return exitCode

    End Function

    Private Function Quote(text As String) As String
        Return $"""{text.Replace("""", "\""")}"""
    End Function

End Module
