Imports System.IO
Imports System.IO.Compression
Imports System.Diagnostics
Imports System.Windows.Forms

' ===========================================================
' InstallerTools (.NET Framework 4.8 compatible)
'
' - Resolves setup.zip
' - Extracts ZIP with merge/overwrite semantics
' - Extracts to: <UpgradePath>\Version <InstallerVersion>
' - Locates installer (EXE / MSI)
' - Runs installer with optional elevation
'
' ===========================================================

Public Module InstallerTools

    ' -------------------------------------------------------
    ' Resolve setup.zip (with optional browse)
    ' -------------------------------------------------------
    Public Function ResolveSetupZip(
        zipPath As String,
        Optional promptForZip As Boolean = False
    ) As String

        If Not String.IsNullOrWhiteSpace(zipPath) Then

            ' Direct ZIP file
            If File.Exists(zipPath) Then
                If Path.GetExtension(zipPath).
                    Equals(".zip", StringComparison.OrdinalIgnoreCase) Then

                    Return Path.GetFullPath(zipPath)
                Else
                    Throw New InvalidOperationException(
                        "The specified file is not a .zip archive.")
                End If
            End If

            ' Directory containing setup.zip
            If Directory.Exists(zipPath) Then
                Dim candidate As String =
                    Path.Combine(zipPath, "setup.zip")

                If File.Exists(candidate) Then
                    Return Path.GetFullPath(candidate)
                End If
            End If
        End If

        ' Optional UI browse
        If promptForZip Then
            Dim response As DialogResult =
                MessageBox.Show(
                    "The setup.zip file could not be found." & Environment.NewLine &
                    "Would you like to locate it manually?",
                    "setup.zip Not Found",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2)

            If response = DialogResult.Yes Then
                Using dlg As New OpenFileDialog()
                    dlg.Title = "Select setup.zip"
                    dlg.Filter = "Zip Files (*.zip)|*.zip"
                    dlg.CheckFileExists = True
                    dlg.Multiselect = False

                    If dlg.ShowDialog() = DialogResult.OK Then
                        Return dlg.FileName
                    End If
                End Using
            End If
        End If

        Throw New FileNotFoundException(
            If(String.IsNullOrWhiteSpace(zipPath),
               "setup.zip was not specified or selected.",
               $"setup.zip could not be found at: {zipPath}"))
    End Function


    Public Async Function ResolveSetupZipAsync(
        zipPath As String,
        Optional promptForZip As Boolean = False
    ) As Task(Of String)

        Await Task.Yield()
        Return ResolveSetupZip(zipPath, promptForZip)

    End Function


    ' -------------------------------------------------------
    ' Async ZIP extract → Versioned directory
    ' -------------------------------------------------------
    Public Async Function ExtractZipToVersionedDirectoryAsync(
        zipPath As String,
        upgradeBasePath As String,
        installerName As String,
        progressPercent As IProgress(Of Integer),
        progressText As IProgress(Of String)
    ) As Task(Of String)

        If String.IsNullOrWhiteSpace(upgradeBasePath) Then
            Throw New ArgumentException("Upgrade base path is required.")
        End If

        ' 1️⃣ Temporary staging folder
        Dim stagingDir As String =
            Path.Combine(
                upgradeBasePath,
                "__staging_" & Guid.NewGuid().ToString("N"))

        Directory.CreateDirectory(stagingDir)

        ' 2️⃣ Extract ZIP to staging
        Await ExtractZipMergeAsync(
            zipPath,
            stagingDir,
            progressPercent,
            progressText)

        ' 3️⃣ Locate installer
        Dim installerPath As String =
            FindInstaller(
                stagingDir,
                installerName,
                recursive:=True)

        ' 4️⃣ Read installer version
        Dim version As String =
            GetInstallerVersion(installerPath)

        If String.IsNullOrWhiteSpace(version) Then
            Throw New InvalidOperationException(
                "Unable to determine installer version.")
        End If

        ' 5️⃣ Final versioned directory
        Dim finalDir As String =
            Path.Combine(
                upgradeBasePath,
                "Version " & version)

        Directory.CreateDirectory(finalDir)

        progressText?.Report($"Finalizing to {finalDir}")

        ' 6️⃣ Merge staging → final
        For Each item In Directory.GetFileSystemEntries(stagingDir)
            Dim dest As String =
                Path.Combine(finalDir, Path.GetFileName(item))

            If Directory.Exists(item) Then
                Directory.Move(item, dest)
            Else
                File.Move(item, dest)
            End If
        Next

        ' 7️⃣ Cleanup staging
        Directory.Delete(stagingDir, recursive:=True)

        Return finalDir
    End Function


    ' -------------------------------------------------------
    ' ZIP extract with overwrite + progress
    ' -------------------------------------------------------
    Public Async Function ExtractZipMergeAsync(
        zipPath As String,
        outputDir As String,
        progressPercent As IProgress(Of Integer),
        progressText As IProgress(Of String)
    ) As Task

        Await Task.Run(
            Sub()
                Using archive As ZipArchive = ZipFile.OpenRead(zipPath)

                    Dim total As Integer = archive.Entries.Count
                    Dim processed As Integer = 0

                    For Each entry As ZipArchiveEntry In archive.Entries
                        Dim targetPath =
                            Path.Combine(outputDir, entry.FullName)

                        If String.IsNullOrEmpty(entry.Name) Then
                            Directory.CreateDirectory(targetPath)
                        Else
                            Dim parent = Path.GetDirectoryName(targetPath)
                            If Not Directory.Exists(parent) Then
                                Directory.CreateDirectory(parent)
                            End If

                            entry.ExtractToFile(targetPath, overwrite:=True)
                        End If

                        processed += 1
                        progressPercent?.Report(
                            CInt((processed / total) * 100))
                        progressText?.Report($"Extracting: {entry.FullName}")
                    Next
                End Using
            End Sub)
    End Function


    ' -------------------------------------------------------
    ' Locate installer
    ' -------------------------------------------------------
    Public Function FindInstaller(
        baseDir As String,
        installerName As String,
        Optional recursive As Boolean = False
    ) As String

        Dim direct = Path.Combine(baseDir, installerName)
        If File.Exists(direct) Then Return direct

        If recursive Then
            Dim matches =
                Directory.GetFiles(
                    baseDir,
                    installerName,
                    SearchOption.AllDirectories)

            If matches.Length > 0 Then
                Return matches(0)
            End If
        End If

        Throw New FileNotFoundException(
            $"Installer not found: {installerName}")
    End Function


    ' -------------------------------------------------------
    ' Get installer version (EXE)
    ' -------------------------------------------------------
    Public Function GetInstallerVersion(installerPath As String) As String

        If Not File.Exists(installerPath) Then Return Nothing
        If installerPath.EndsWith(".msi",
            StringComparison.OrdinalIgnoreCase) Then Return Nothing

        Dim vi = FileVersionInfo.GetVersionInfo(installerPath)

        Return If(
            Not String.IsNullOrWhiteSpace(vi.FileVersion),
            vi.FileVersion,
            vi.ProductVersion)
    End Function


    ' -------------------------------------------------------
    ' Async installer launch
    ' -------------------------------------------------------
    Public Async Function RunInstallerAsync(
        installerPath As String,
        arguments As String,
        elevate As Boolean,
        progressText As IProgress(Of String)
    ) As Task

        Await Task.Yield()

        Dim psi As New ProcessStartInfo With {
            .UseShellExecute = True
        }

        If installerPath.EndsWith(".msi",
            StringComparison.OrdinalIgnoreCase) Then
            psi.FileName = "msiexec.exe"
            psi.Arguments = $"/i ""{installerPath}"" {arguments}"
        Else
            psi.FileName = installerPath
            psi.Arguments = arguments
            psi.WorkingDirectory = Path.GetDirectoryName(installerPath)
        End If

        If elevate Then
            psi.Verb = "runas"
        End If

        Using proc As Process = Process.Start(psi)
            Await Task.Run(Sub() proc.WaitForExit())
        End Using

        progressText?.Report("Installer finished.")
    End Function

End Module