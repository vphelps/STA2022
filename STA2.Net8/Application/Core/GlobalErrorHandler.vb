Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Public Module GlobalErrorHandler

    Public ReadOnly LogFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "STA2", "Logs")
    Public Const LogRetentionDays As Integer = 5

    Public Event OnErrorLogged(ex As Exception, source As String)

    ' ---------------------------------------
    ' UI thread exceptions
    ' ---------------------------------------
    Public Sub HandleThreadException(
        sender As Object,
        e As ThreadExceptionEventArgs)

        LogException("UI Thread Exception", e.Exception)
        RaiseEvent OnErrorLogged(e.Exception, "UI Thread Exception")
    End Sub

    ' ---------------------------------------
    ' Non‑UI / background exceptions
    ' ---------------------------------------
    Public Sub HandleUnhandledException(
        sender As Object,
        e As UnhandledExceptionEventArgs)

        Dim ex As Exception = TryCast(e.ExceptionObject, Exception)

        If ex IsNot Nothing Then
            LogException("Unhandled Domain Exception", ex)
            RaiseEvent OnErrorLogged(ex, "Unhandled Domain Exception")
        Else
            LogText("Unhandled non‑Exception object thrown.")
        End If

    End Sub

    Public Sub LogScriptResult(
        commandLine As String,
        scriptPath As String,
        scriptArgs As String,
        success As Boolean,
        Optional ex As Exception = Nothing)

        Try
            Directory.CreateDirectory(LogFolder)

            ' ✅ Enforce retention
            CleanupLogsOlderThan(LogRetentionDays)

            Dim logFile As String =
                Path.Combine(LogFolder,
                    $"ScriptRun_{DateTime.Now:yyyyMMdd}.log")

            Using sw As New StreamWriter(logFile, True, Encoding.UTF8)
                sw.WriteLine("----------------------------------------------------")
                sw.WriteLine("Time: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                sw.WriteLine("CommandLine: " & If(String.IsNullOrWhiteSpace(commandLine), "(none)", commandLine))
                sw.WriteLine("ScriptPath: " & If(String.IsNullOrWhiteSpace(scriptPath), "(none)", scriptPath))
                sw.WriteLine("ScriptArgs: " & If(String.IsNullOrWhiteSpace(scriptArgs), "(none)", scriptArgs))
                sw.WriteLine("Result: " & If(success, "SUCCESS", "FAILURE"))
                sw.WriteLine()


                If ex IsNot Nothing Then
                    sw.WriteLine()
                    sw.WriteLine("Exception details:")
                    WriteException(sw, ex)
                End If

                sw.WriteLine("----------------------------------------------------")
                sw.WriteLine()
            End Using

        Catch
            ' Never allow logging to throw
        End Try

    End Sub

    ' ---------------------------------------
    ' Main logging routine
    ' ---------------------------------------
    Private Sub LogException(source As String, ex As Exception)

        Directory.CreateDirectory(LogFolder)

        ' ✅ Enforce retention
        CleanupLogsOlderThan(LogRetentionDays)

        Dim logFile As String =
            Path.Combine(LogFolder,
                $"Error_{DateTime.Now:yyyyMMdd}.log")

        Using sw As New StreamWriter(logFile, True, Encoding.UTF8)

            sw.WriteLine("====================================================")
            sw.WriteLine("Time: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            sw.WriteLine("Source: " & source)
            sw.WriteLine("Machine: " & Environment.MachineName)
            sw.WriteLine("User: " & Environment.UserName)
            sw.WriteLine("OS: " & Environment.OSVersion.ToString)
            sw.WriteLine(".NET CLR: " & Environment.Version.ToString)
            sw.WriteLine()

            WriteException(sw, ex)

            sw.WriteLine("====================================================")
            sw.WriteLine()

        End Using

    End Sub

    Private Sub WriteException(
        sw As StreamWriter,
        ex As Exception,
        Optional level As Integer = 0)

        If ex Is Nothing Then Exit Sub

        Dim indent As String = New String(" "c, level * 2)

        sw.WriteLine(indent & "Exception Type: " & ex.GetType().FullName)
        sw.WriteLine(indent & "Message: " & ex.Message)
        sw.WriteLine(indent & "StackTrace:")
        sw.WriteLine(indent & ex.StackTrace)
        sw.WriteLine()

        If ex.InnerException IsNot Nothing Then
            sw.WriteLine(indent & "Inner Exception:")
            WriteException(sw, ex.InnerException, level + 1)
        End If

    End Sub

    ' ---------------------------------------
    ' Fallback logging
    ' ---------------------------------------
    Private Sub LogText(message As String)

        Directory.CreateDirectory(LogFolder)

        Dim logFile As String =
            Path.Combine(LogFolder,
                $"Error_{DateTime.Now:yyyyMMdd}.log")

        File.AppendAllText(logFile,
            $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}{Environment.NewLine}")
    End Sub

    ' ---------------------------------------
    ' Script run logging (used by ScriptExecutionController)
    ' ---------------------------------------

    ' ---------------------------------------
    ' User-facing message
    ' ---------------------------------------
    Private Sub ShowUserMessage()
        MessageBox.Show(
    "An unexpected error occurred." & Environment.NewLine &
    "The error has been logged so it can be reviewed.",
    "Application Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error)
    End Sub
    Public Sub CleanupLogsOlderThan(days As Integer)

        Try
            If Not Directory.Exists(LogFolder) Then Return

            Dim cutoff = DateTime.Now.AddDays(-days)

            For Each file In New DirectoryInfo(LogFolder).GetFiles("*.log")

                If file.LastWriteTime < cutoff Then
                    file.Delete()
                End If

            Next

        Catch
            ' Never allow cleanup failures to break logging
        End Try

    End Sub
    Public Sub LogAction(actionName As String,
                     Optional details As String = Nothing)

        Try
            Directory.CreateDirectory(LogFolder)

            CleanupLogsOlderThan(LogRetentionDays)

            Dim logFile As String =
                Path.Combine(LogFolder,
                    $"Action_{DateTime.Now:yyyyMMdd}.log")

            Using sw As New StreamWriter(logFile, True, Encoding.UTF8)

                sw.WriteLine("----------------------------------------------------")
                sw.WriteLine("Time: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                sw.WriteLine("Action: " & actionName)

                If Not String.IsNullOrWhiteSpace(details) Then
                    sw.WriteLine("Details: " & details)
                End If

                sw.WriteLine("----------------------------------------------------")
                sw.WriteLine()

            End Using

        Catch
            ' Never allow logging to throw
        End Try

    End Sub
End Module
