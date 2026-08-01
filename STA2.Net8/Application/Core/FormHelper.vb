Imports System.Net.Http
Imports System.ServiceProcess
Imports System.Text
Imports System.Threading

Public Module FormHelper

    Public Async Function StartQaApiAsync(
        commandLine As String,
        log As StringBuilder
    ) As Task(Of Boolean)

        If String.IsNullOrWhiteSpace(commandLine) Then

            log.AppendLine("No QA command line configured")

            Return False

        End If

        Try

            Dim parsed = QaScriptHelper.ParseCommand(commandLine)

            Dim scriptPath = parsed.ScriptPath
            Dim args = parsed.Args

            log.AppendLine($"Script Path: {scriptPath}")
            log.AppendLine($"Arguments: {args}")

            ' Already running?
            If QaScriptHelper.IsScriptRunning(scriptPath) Then

                log.AppendLine("QA API already running")

                Return True

            End If

            Const serviceName As String = "AdvApiServer"

            log.AppendLine($"Stopping service: {serviceName}")

            Await Task.Run(
                Sub()

                    Try

                        Using sc As New ServiceController(serviceName)

                            If sc.Status = ServiceControllerStatus.Running OrElse
                               sc.Status = ServiceControllerStatus.StartPending Then

                                sc.Stop()

                                sc.WaitForStatus(
                                    ServiceControllerStatus.Stopped,
                                    TimeSpan.FromSeconds(15))

                            End If

                        End Using

                    Catch ex As InvalidOperationException

                        log.AppendLine(
                            $"Service not installed: {serviceName}")

                    End Try

                End Sub)

            Dim psCommand As String =
                $"-ExecutionPolicy Bypass -Command ""& {{ $host.UI.RawUI.WindowTitle = 'QA API Server'; & '{scriptPath}' {args} }}"""

            log.AppendLine("Launching PowerShell process")

            Dim psi As New ProcessStartInfo With {
                .FileName = "powershell.exe",
                .Arguments = psCommand,
                .UseShellExecute = True,
                .CreateNoWindow = False
            }

            Process.Start(psi)

            log.AppendLine("QA API launched successfully")

            Return True

        Catch ex As Exception

            log.AppendLine(
                $"ERROR: {ex.GetType().Name}: {ex.Message}")

            Return False

        End Try

    End Function


    Public Async Function WaitForQaApiReadyAsync(
    Optional timeoutSeconds As Integer = 60,
    Optional updateText As Action(Of String) = Nothing,
    Optional cancellationToken As CancellationToken = Nothing
) As Task(Of Boolean)

        Const apiUrl As String =
            "http://localhost:15059/api/v1/version"

        Dim endTime =
            DateTime.UtcNow.AddSeconds(timeoutSeconds)

        Using client As New HttpClient()

            client.Timeout = TimeSpan.FromMilliseconds(500)

            While DateTime.UtcNow < endTime

                If cancellationToken.IsCancellationRequested Then
                    Return False
                End If

                Dim remaining As Integer =
                    CInt(Math.Ceiling(
                        (endTime - DateTime.UtcNow).TotalSeconds))

                updateText?.Invoke(
                    $"Waiting for QA Script ({remaining}s)")

                Try

                    Dim response =
                        Await client.GetAsync(apiUrl)

                    If response.IsSuccessStatusCode Then
                        Return True
                    End If

                Catch
                End Try

                Await Task.Delay(250)

            End While

        End Using

        Return False

    End Function
    Public Async Function IsQaApiReadyAsync() As Task(Of Boolean)

        Try

            Using client As New HttpClient()

                client.Timeout = TimeSpan.FromMilliseconds(500)

                Dim response =
                    Await client.GetAsync(
                        "http://localhost:15059/api/v1/version")

                Return response.IsSuccessStatusCode

            End Using

        Catch

            Return False

        End Try

    End Function
    Public Async Function RestartQaApiAsync(
        commandLine As String,
        log As StringBuilder
    ) As Task(Of Boolean)

        Try

            log.AppendLine(
                "Stopping existing QA API script instances")

            Await CodeHelper.KillQaScriptIfRunningAsync(
                commandLine)

            Const serviceName As String = "AdvApiServer"

            log.AppendLine(
                $"Stopping service: {serviceName}")

            Await Task.Run(
                Sub()

                    Try

                        Using sc As New ServiceController(serviceName)

                            If sc.Status = ServiceControllerStatus.Running OrElse
                               sc.Status = ServiceControllerStatus.StartPending Then

                                sc.Stop()

                                sc.WaitForStatus(
                                    ServiceControllerStatus.Stopped,
                                    TimeSpan.FromSeconds(15))

                            End If

                        End Using

                    Catch
                        ' Service not installed
                    End Try

                End Sub)

            log.AppendLine(
                "Restarting QA API")

            Return Await StartQaApiAsync(
                commandLine,
                log)

        Catch ex As Exception

            log.AppendLine(
                $"Restart failed: {ex.Message}")

            Return False

        End Try

    End Function
    Public Async Function StartQaServiceAsync(
    serviceName As String,
    log As StringBuilder
) As Task(Of Boolean)

        Try

            Using sc As New ServiceController(serviceName)

                If sc.Status =
                    ServiceControllerStatus.Running Then

                    log.AppendLine("QA service already running.")

                    Return True

                End If

                log.AppendLine($"Starting service: {serviceName}")

                sc.Start()

                Await Task.Run(
                    Sub()

                        sc.WaitForStatus(
                            ServiceControllerStatus.Running,
                            TimeSpan.FromSeconds(30))

                    End Sub)

                log.AppendLine("QA service started successfully.")

                Return True

            End Using

        Catch ex As Exception

            log.AppendLine($"Service start failed: {ex.Message}")

            Return False

        End Try

    End Function

End Module