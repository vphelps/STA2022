Imports System.IO

Public Class ConnectionInfo

    Public Property DataSource As String
    Public Property Catalog As String

End Class
Public Class ConnectionProfileManager
    Private Const ProfilesFolder As String = "C:\PFSCommon\ConnectionProfiles"
    Private Const ActiveIniPath As String = "C:\PFSCommon\PFSConnect.ini"

    Public Shared Function GetProfiles() As List(Of String)

        If Not Directory.Exists(ProfilesFolder) Then
            Directory.CreateDirectory(ProfilesFolder)
        End If

        Return Directory.
            GetFiles(ProfilesFolder, "*.ini").
            Select(Function(f) Path.GetFileNameWithoutExtension(f)).
            OrderBy(Function(n) n).
            ToList()

    End Function
    Public Shared Function GetActiveConnectionInfo() As ConnectionInfo

        Return ReadConnectionInfo(ActiveIniPath)

    End Function
    Public Shared Function ReadConnectionInfo(
    iniPath As String
) As ConnectionInfo

        Dim result As New ConnectionInfo

        If Not File.Exists(iniPath) Then
            Return result
        End If

        For Each line In File.ReadLines(iniPath)

            If line.StartsWith("DataSource=",
                               StringComparison.OrdinalIgnoreCase) Then

                result.DataSource =
                    line.Substring("DataSource=".Length)

            ElseIf line.StartsWith("Catalog=",
                                   StringComparison.OrdinalIgnoreCase) Then

                result.Catalog =
                    line.Substring("Catalog=".Length)

            End If

        Next

        Return result

    End Function
    Public Shared Sub SaveCurrentProfile(profileName As String)

        If String.IsNullOrWhiteSpace(profileName) Then
            Throw New ArgumentException("Profile name is required.")
        End If

        If Not File.Exists(ActiveIniPath) Then
            Throw New FileNotFoundException(
                "PFSConnect.ini was not found.",
                ActiveIniPath)
        End If

        If Not Directory.Exists(ProfilesFolder) Then
            Directory.CreateDirectory(ProfilesFolder)
        End If

        Dim destinationFile =
            Path.Combine(
                ProfilesFolder,
                $"{profileName.Trim()}.ini")

        File.Copy(
            ActiveIniPath,
            destinationFile,
            overwrite:=False)

    End Sub
    Public Shared Sub ActivateProfile(profileName As String)

        If String.IsNullOrWhiteSpace(profileName) Then
            Throw New ArgumentException("Profile name is required.")
        End If

        Dim sourceFile =
        Path.Combine(
            ProfilesFolder,
            $"{profileName}.ini")

        If Not File.Exists(sourceFile) Then
            Throw New FileNotFoundException(
            $"Profile '{profileName}' was not found.",
            sourceFile)
        End If

        File.Copy(
        sourceFile,
        ActiveIniPath,
        overwrite:=True)

    End Sub

    Public Shared Sub DeleteProfile(profileName As String)

        If String.IsNullOrWhiteSpace(profileName) Then
            Throw New ArgumentException("Profile name is required.")
        End If

        Dim profileFile =
            Path.Combine(
                ProfilesFolder,
                $"{profileName}.ini")

        If Not File.Exists(profileFile) Then
            Throw New FileNotFoundException(
                $"Profile '{profileName}' was not found.",
                profileFile)
        End If

        File.Delete(profileFile)

    End Sub

End Class
