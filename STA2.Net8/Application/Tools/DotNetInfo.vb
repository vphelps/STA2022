Imports Microsoft.Win32
Imports System.IO

Public Class DotNetInfo

    ' Returns the highest installed .NET version as a simple string
    Public Shared Function GetInstalledDotNetVersion() As String

        Dim modernVersion As String = GetHighestModernDotNetRuntime()
        If modernVersion <> "" Then
            Return modernVersion
        End If

        Dim frameworkVersion As String = GetFrameworkVersion()
        If frameworkVersion <> "" Then
            Return frameworkVersion
        End If

        Return "Not detected"
    End Function

    ' -------------------------------------------------
    ' MODERN .NET (Core / ASP.NET / Desktop) 5+
    ' -------------------------------------------------

    Private Shared Function GetHighestModernDotNetRuntime() As String

        Dim highest As Version = Nothing

        Dim runtimeFolders() As String = {
        "Microsoft.NETCore.App",
        "Microsoft.AspNetCore.App",
        "Microsoft.WindowsDesktop.App"
    }

        ' ✅ Program Files (64‑bit) — critical fix
        Dim programFiles64 As String =
        Environment.GetEnvironmentVariable("ProgramW6432")

        ' Fallback safety
        If String.IsNullOrEmpty(programFiles64) Then
            programFiles64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
        End If

        For Each runtimeFolder As String In runtimeFolders

            Dim fullPath As String =
            IO.Path.Combine(programFiles64, "dotnet\shared", runtimeFolder)

            If Not IO.Directory.Exists(fullPath) Then Continue For

            For Each dir As String In IO.Directory.GetDirectories(fullPath)
                Dim name As String = IO.Path.GetFileName(dir)

                Dim v As Version = Nothing
                If Version.TryParse(name, v) Then
                    If highest Is Nothing OrElse v > highest Then
                        highest = v
                    End If
                End If
            Next
        Next

        If highest Is Nothing Then Return ""

        Return highest.ToString()
    End Function


    Private Shared Sub CollectVersions(path As String, versions As List(Of Version))
        If Not Directory.Exists(path) Then Exit Sub

        For Each dir As String In Directory.GetDirectories(path)
            Dim folderName As String = System.IO.Path.GetFileName(dir)
            Dim v As Version = Nothing

            If Version.TryParse(folderName, v) Then
                versions.Add(v)
            End If
        Next
    End Sub

    ' ---------------------------
    ' .NET FRAMEWORK (4.5 – 4.8.1)
    ' ---------------------------
    Private Shared Function GetFrameworkVersion() As String

        Using baseKey = RegistryKey.OpenBaseKey(
            RegistryHive.LocalMachine,
            RegistryView.Registry32)

            Using key = baseKey.OpenSubKey(
                "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full")

                If key Is Nothing OrElse key.GetValue("Release") Is Nothing Then
                    Return ""
                End If

                Dim release As Integer = CInt(key.GetValue("Release"))
                Return MapReleaseToFrameworkVersion(release)
            End Using
        End Using
    End Function

    Private Shared Function MapReleaseToFrameworkVersion(release As Integer) As String
        Select Case release
            Case >= 533325 : Return "4.8.1"
            Case >= 528040 : Return "4.8"
            Case >= 461808 : Return "4.7.2"
            Case >= 461308 : Return "4.7.1"
            Case >= 460798 : Return "4.7"
            Case >= 394802 : Return "4.6.2"
            Case >= 394254 : Return "4.6.1"
            Case >= 393295 : Return "4.6"
            Case >= 379893 : Return "4.5.2"
            Case >= 378675 : Return "4.5.1"
            Case >= 378389 : Return "4.5"
            Case Else : Return ""
        End Select
    End Function

End Class