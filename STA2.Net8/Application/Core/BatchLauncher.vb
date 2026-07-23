Imports System.IO
Imports System.Text

Public Module BatchLauncher

    Public Class BatchResult
        Public Property Total As Integer
        Public Property Launched As Integer
        Public Property Skipped As Integer
        Public Property Failed As Integer
        Public Property Failures As New List(Of String)
        Public Overrides Function ToString() As String
            Return $"Total={Total}, Launched={Launched}, Skipped={Skipped}, Failed={Failed}"
        End Function
    End Class

    ' Keep last 5 run logs via rotation:
    '   batch-launch-1.log (newest), ... batch-launch-5.log (oldest)

    ' Thread-safe append (simple lock)
    Private ReadOnly _logSync As New Object()
    Private Sub LogLine(path As String, line As String)
        SyncLock _logSync
            File.AppendAllText(path, $"[{DateTime.Now:HH:mm:ss}] {line}{Environment.NewLine}", Encoding.UTF8)
        End SyncLock
    End Sub

    ' Helper: normalize/shorten caller
    Private Function NormalizeCaller(caller As String) As String
        If String.IsNullOrWhiteSpace(caller) Then Return "(unknown)"
        Return caller.Trim()
    End Function

    ' Entry point: runs the batch without UI.
    ' caller: string describing the invoker e.g. "Startup:-BatchLaunch" or "UI:FormMain.btnBatchLaunch"
    Public Function RunBatch(launcherConfig As LauncherConfig,
                             Optional caller As String = Nothing,
                             Optional includeDisabled As Boolean = False,
                             Optional silent As Boolean = True) As BatchResult

        Dim result As New BatchResult()
        Dim logPath As String = Nothing

        Try
            ' LOG SETUP WITH ROTATION (KEEP LAST 5 RUNS)
            Dim logDir As String = GlobalErrorHandler.LogFolder
            Directory.CreateDirectory(logDir)

            logPath = Path.Combine(logDir, $"BatchLaunch_{DateTime.Now:yyyyMMdd}.log")

            ' Header with caller + environment context
            Dim callerTag = NormalizeCaller(caller)
            LogLine(logPath, "------------------------------------------------------------")
            LogLine(logPath, $"Batch start: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
            LogLine(logPath, $"Caller={callerTag} | User={Environment.UserName} | Machine={Environment.MachineName} | Proc={Path.GetFileName(Environment.GetCommandLineArgs().FirstOrDefault())}")
            LogLine(logPath, $"Silent={silent}, IncludeDisabled={includeDisabled}")

            If launcherConfig Is Nothing Then
                LogLine(logPath, "ERROR: launcherConfig is Nothing.")
                Return result
            End If
            If launcherConfig.Programs Is Nothing Then
                LogLine(logPath, "ERROR: launcherConfig.Programs is Nothing.")
                Return result
            End If

            ' Build candidate list
            Dim batch = launcherConfig.Programs.
                        Where(Function(p) p IsNot Nothing AndAlso
                                         p.IncludeInBatch AndAlso
                                         (includeDisabled OrElse p.Enabled)).
                        ToList()

            result.Total = batch.Count
            LogLine(logPath, $"Programs selected for batch: {result.Total}")

            If batch.Count = 0 Then
                LogLine(logPath, "No programs meet IncludeInBatch + Enabled criteria.")
                LogLine(logPath, $"Batch end: {DateTime.Now:yyyy-MM-dd HH:mm:ss} | {result}")
                Return result
            End If

            ' Launch loop
            For Each p In batch
                Dim nameSafe = If(p.Name, "(unnamed)")
                Try
                    If String.IsNullOrWhiteSpace(p.Path) OrElse Not File.Exists(p.Path) Then
                        Dim msg = $"{nameSafe}: SKIP - File not found [{p.Path}]"
                        LogLine(logPath, msg)
                        result.Skipped += 1
                        result.Failures.Add(msg)
                        Continue For
                    End If

                    Dim wd = If(String.IsNullOrWhiteSpace(p.WorkingDirectory),
                                Path.GetDirectoryName(p.Path),
                                p.WorkingDirectory)

                    Dim psi As New ProcessStartInfo() With {
                        .FileName = p.Path,
                        .Arguments = If(p.Arguments, ""),
                        .WorkingDirectory = If(String.IsNullOrWhiteSpace(wd), "", wd),
                        .UseShellExecute = True
                    }
                    If p.RunAsAdmin Then psi.Verb = "runas"

                    LogLine(logPath, $"{nameSafe}: LAUNCH → Path=""{psi.FileName}"", Args=""{psi.Arguments}"", WD=""{psi.WorkingDirectory}"", Admin={p.RunAsAdmin}")

                    Process.Start(psi)
                    result.Launched += 1

                Catch ex As Exception
                    Dim fail = $"{nameSafe}: FAIL - {ex.Message}"
                    LogLine(logPath, fail)
                    result.Failed += 1
                    result.Failures.Add(fail)
                End Try
            Next

            ' Footer
            LogLine(logPath, $"Batch end: {DateTime.Now:yyyy-MM-dd HH:mm:ss} | {result}")

        Catch ex As Exception
            ' Catastrophic batch errors
            Try
                If Not String.IsNullOrEmpty(logPath) Then
                    LogLine(logPath, $"FATAL: {ex.Message}")
                End If
            Catch
                ' ignore logging errors
            End Try
        End Try

        Return result
    End Function

End Module