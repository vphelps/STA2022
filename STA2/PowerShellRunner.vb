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

    Private Function Quote(text As String) As String
        Return $"""{text.Replace("""", "\""")}"""
    End Function

End Module
