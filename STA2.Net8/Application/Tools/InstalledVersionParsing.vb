Imports System.Linq

' ------------------------------------------------------------
' Installed version parsing (isolated, no side effects)
' ------------------------------------------------------------
Public Module InstalledVersionParsing

    Public Structure VersionParts
        Public Major As Integer
        Public Minor As Integer
        Public Patch As Integer
        Public Build As Integer

        Public Overrides Function ToString() As String
            Return $"{Major}.{Minor}.{Patch}.{Build}"
        End Function
    End Structure


    Public Function ParseVersionPartsSafe(versionText As String) As VersionParts?
        If String.IsNullOrWhiteSpace(versionText) Then Return Nothing

        ' Strip anything after whitespace (e.g. " (Release)")
        Dim clean = versionText.Split(" "c)(0)

        ' Keep only digits and dots
        clean = New String(
            clean.Where(Function(c) Char.IsDigit(c) OrElse c = "."c).ToArray())

        Dim tokens = clean.Split("."c)
        If tokens.Length < 2 Then Return Nothing

        Dim result As New VersionParts With {
            .Major = SafeInt(tokens, 0),
            .Minor = SafeInt(tokens, 1),
            .Patch = SafeInt(tokens, 2),
            .Build = SafeInt(tokens, 3)
        }

        Return result
    End Function


    Private Function SafeInt(tokens() As String, index As Integer) As Integer
        If index < tokens.Length Then
            Dim value As Integer
            If Integer.TryParse(tokens(index), value) Then
                Return value
            End If
        End If
        Return 0
    End Function
    Public Function ParseInstallerFolderVersion(folderName As String) As VersionParts?
        If String.IsNullOrWhiteSpace(folderName) Then Return Nothing

        ' Expected format: "Version x.y.z.w"
        If Not folderName.StartsWith("Version ", StringComparison.OrdinalIgnoreCase) Then
            Return Nothing
        End If

        Dim versionText As String =
            folderName.Substring("Version ".Length).Trim()

        Return ParseVersionPartsSafe(versionText)
    End Function

    Public Function CompareVersions(
    a As VersionParts,
    b As VersionParts
) As Integer

        If a.Major <> b.Major Then
            Return a.Major.CompareTo(b.Major)
        End If

        If a.Minor <> b.Minor Then
            Return a.Minor.CompareTo(b.Minor)
        End If

        If a.Patch <> b.Patch Then
            Return a.Patch.CompareTo(b.Patch)
        End If

        Return a.Build.CompareTo(b.Build)

    End Function
    Public Function FindInstalledInstallerFolder(
        upgradePath As String,
        serviceName As String
    ) As String

        ' Get the installed (runtime) version
        Dim installedText = GetInstalledVersionString()
        Dim installed = ParseVersionPartsSafe(installedText)

        If Not installed.HasValue Then
            Return Nothing
        End If

        ' Scan installer folders
        For Each dirPath In IO.Directory.GetDirectories(upgradePath, "Version *")
            Dim folderName = IO.Path.GetFileName(dirPath)
            Dim folderVersion = ParseInstallerFolderVersion(folderName)

            If Not folderVersion.HasValue Then
                Continue For
            End If

            ' Exact match = installed version folder
            If CompareVersions(installed.Value, folderVersion.Value) = 0 Then
                Return dirPath
            End If

        Next

        Return Nothing
    End Function
End Module