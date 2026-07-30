Imports System.Management
Imports System.Diagnostics

Public Class QaScriptHelper

    Public Shared Function IsScriptRunning(scriptPath As String) As Boolean

        Try
            Dim query As String =
                "SELECT CommandLine FROM Win32_Process WHERE Name = 'powershell.exe'"

            Using searcher As New ManagementObjectSearcher(query)

                For Each proc As ManagementObject In searcher.Get()

                    Dim cmd = TryCast(proc("CommandLine"), String)

                    If Not String.IsNullOrWhiteSpace(cmd) AndAlso
                       cmd.IndexOf(scriptPath, StringComparison.OrdinalIgnoreCase) >= 0 Then

                        Return True
                    End If

                Next

            End Using

        Catch
            ' Ignore failures
        End Try

        Return False

    End Function

    Public Shared Sub KillScriptProcesses(scriptPath As String)

        Try
            Dim query As String =
                "SELECT ProcessId, CommandLine FROM Win32_Process WHERE Name = 'powershell.exe'"

            Using searcher As New ManagementObjectSearcher(query)

                For Each proc As ManagementObject In searcher.Get()

                    Dim cmd = TryCast(proc("CommandLine"), String)

                    If Not String.IsNullOrWhiteSpace(cmd) AndAlso
                       cmd.IndexOf(scriptPath, StringComparison.OrdinalIgnoreCase) >= 0 Then

                        Dim pid = Convert.ToInt32(proc("ProcessId"))

                        Try
                            Dim p = Process.GetProcessById(pid)

                            If Not p.HasExited Then
                                p.CloseMainWindow()

                                If Not p.WaitForExit(3000) Then
                                    p.Kill()
                                End If
                            End If

                        Catch
                        End Try

                    End If

                Next

            End Using

        Catch
        End Try

    End Sub
    Public Shared Function ParseCommand(fullCommand As String) As (ScriptPath As String, Args As String)

        Dim scriptPath As String = ""
        Dim args As String = ""

        ' ✅ Reuse existing logic
        ParseCommand(fullCommand, scriptPath, args)

        Return (scriptPath, args)

    End Function
    Public Shared Sub ParseCommand(
    fullCommand As String,
    ByRef scriptPath As String,
    ByRef args As String)

        If String.IsNullOrWhiteSpace(fullCommand) Then
            Throw New ArgumentException("Command is empty.")
        End If

        If fullCommand.StartsWith("""") Then

            Dim endQuote = fullCommand.IndexOf("""", 1)

            If endQuote > 1 Then
                scriptPath = fullCommand.Substring(1, endQuote - 1)
                args = fullCommand.Substring(endQuote + 1).Trim()
            Else
                Throw New Exception("Invalid quoted script path.")
            End If

        Else
            Dim parts = fullCommand.Split(New Char() {" "c}, 2)

            scriptPath = parts(0)
            If parts.Length > 1 Then
                args = parts(1)
            End If
        End If

    End Sub
    Public Shared Function IsQaApiRunning(
    commandLine As String
) As Boolean

        If String.IsNullOrWhiteSpace(commandLine) Then
            Return False
        End If

        Dim parsed = ParseCommand(commandLine)

        Return IsScriptRunning(parsed.ScriptPath)

    End Function
End Class