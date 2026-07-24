Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Imports System.Windows.Forms
Imports System.Windows.Forms.Design.AxImporter

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

Public Enum ExistingVersionAction
    Overwrite
    RunExisting
End Enum


Public Module InstallerTools

    Private Function PromptForExistingVersion(
    versionPath As String,
    timeoutSeconds As Integer,
    options As AppOptions
) As ExistingVersionAction

        If options Is Nothing Then
            Return ExistingVersionAction.Overwrite
        End If

        If options.SetupExistingVersionPromptTimeoutSeconds < 0 Then
            timeoutSeconds = 10
        End If
        Dim message As String =
        "The following version already exists:" & Environment.NewLine &
        versionPath & Environment.NewLine & Environment.NewLine &
        "What would you like to do?"




        Dim result As DialogResult

        If options IsNot Nothing AndAlso options.SetupExistingVersionPromptEnabled Then

            result = UIHelpers.TimedErrorPrompt(
        owner:=Nothing,
        message:=message,
        title:="Existing Version Detected",
        timeoutSeconds:=If(options.SetupExistingVersionPromptTimeoutSeconds > 0,
                           options.SetupExistingVersionPromptTimeoutSeconds,
                           timeoutSeconds),
        button1Text:="Overwrite",
        button1Result:=DialogResult.Yes,
        button2Text:="Run Existing",
        button2Result:=DialogResult.No,
        defaultButtonIndex:=1,
        defaultActionText:="Default action: Overwrite")

        Else
            result = DialogResult.Yes
        End If


        Return If(result = DialogResult.Yes,
              ExistingVersionAction.Overwrite,
              ExistingVersionAction.RunExisting)

    End Function


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
    progressText As IProgress(Of String),
    options As AppOptions
) As Task(Of String)

        If String.IsNullOrWhiteSpace(upgradeBasePath) Then
            Throw New ArgumentException("Upgrade base path is required.")
        End If

        ' ✅ Use TEMP for staging, not upgrade path
        Dim stagingRoot As String =
        Path.Combine(Path.GetTempPath(), "STA2_InstallerStaging")

        Directory.CreateDirectory(stagingRoot)

        Dim stagingDir As String =
        Path.Combine(stagingRoot, "__staging_" & Guid.NewGuid().ToString("N"))

        Directory.CreateDirectory(stagingDir)

        Try
            ' 1️⃣ Extract ZIP to staging
            Await ExtractZipMergeAsync(
            zipPath,
            stagingDir,
            progressPercent,
            progressText)

            ' 2️⃣ Locate installer
            Dim installerPath As String =
            FindInstaller(stagingDir, installerName, recursive:=True)

            ' 3️⃣ Read installer version
            Dim version As String =
            GetInstallerVersion(installerPath)

            If String.IsNullOrWhiteSpace(version) Then
                Throw New InvalidOperationException(
                "Unable to determine installer version.")
            End If

            ' 4️⃣ Final version directory
            Dim finalDir As String =
            Path.Combine(upgradeBasePath, "Version " & version)

            ' 5️⃣ Existing version handling
            If Directory.Exists(finalDir) Then

                Dim action As ExistingVersionAction =
                PromptForExistingVersion(finalDir, timeoutSeconds:=10, options)

                If action = ExistingVersionAction.RunExisting Then
                    progressText?.Report("Using existing installation.")
                    Return finalDir
                End If

                Directory.Delete(finalDir, recursive:=True)
            End If

            Directory.CreateDirectory(finalDir)

            progressText?.Report($"Finalizing extraction to {finalDir}...")

            ' 6️⃣ Copy staging → final
            For Each item In System.IO.Directory.GetFileSystemEntries(stagingDir)

                Dim dest = System.IO.Path.Combine(finalDir, System.IO.Path.GetFileName(item))

                If System.IO.Directory.Exists(item) Then
                    CopyDirectory(item, dest)
                Else
                    System.IO.File.Copy(item, dest, True)
                End If

            Next
            Return finalDir

        Finally
            ' ✅ ALWAYS clean up staging
            Try
                If Directory.Exists(stagingDir) Then
                    Directory.Delete(stagingDir, recursive:=True)
                End If
            Catch
                ' Non-fatal cleanup failure
            End Try
        End Try

    End Function
    Private Sub CopyDirectory(sourceDir As String, destDir As String)

        Directory.CreateDirectory(destDir)

        ' Copy files
        For Each filePath In Directory.GetFiles(sourceDir)
            Dim destFile = Path.Combine(destDir, Path.GetFileName(filePath))
            System.IO.File.Copy(filePath, destFile, True)
        Next

        ' Copy subdirectories recursively
        For Each dirPath In Directory.GetDirectories(sourceDir)
            Dim destSubDir = Path.Combine(destDir, Path.GetFileName(dirPath))
            CopyDirectory(dirPath, destSubDir)
        Next

    End Sub

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
    Public Sub CleanupOrphanedStagingDirectories(
    Optional maxAgeHours As Integer = 24
)

        Dim stagingRoot As String =
        Path.Combine(Path.GetTempPath(), "STA2_InstallerStaging")

        If Not Directory.Exists(stagingRoot) Then Return

        Dim cutoff As DateTime =
        DateTime.Now.AddHours(-Math.Abs(maxAgeHours))

        For Each stagingDirPath As String In
        Directory.GetDirectories(stagingRoot, "__staging_*")

            Try
                Dim info As New DirectoryInfo(stagingDirPath)

                If info.CreationTime < cutoff Then
                    info.Delete(recursive:=True)
                End If

            Catch
                ' Ignore cleanup failures (non-fatal)
            End Try

        Next

    End Sub

    Public Function GetReleaseTrack(version As Version) As ReleaseTrack
        If version Is Nothing Then
            Throw New ArgumentNullException(NameOf(version))
        End If

        ' ✅ Clarified rule:
        ' LTS → Minor = 1
        ' Fast Track → Minor ≥ 2
        If version.Minor = 1 Then
            Return ReleaseTrack.LongTermSupport
        Else
            Return ReleaseTrack.FastTrack
        End If
    End Function

    Public Function GetDirectorySizeBytes(path As String) As Long
        Dim total As Long = 0

        'For Each file In Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)
        '    Try
        '        total += New FileInfo(file).Length
        '    Catch
        '        ' Ignore inaccessible files
        '    End Try
        'Next
        For Each file In Directory.EnumerateFiles(path, "*", SearchOption.TopDirectoryOnly)

            total += New FileInfo(file).Length

        Next
        Return total
    End Function

    Public Function DiscoverInstalledInstallerVersions(
    upgradeBasePath As String,
    Optional progress As Action(Of String) = Nothing
) As List(Of InstallerVersionInfo)

        Dim results As New List(Of InstallerVersionInfo)

        If String.IsNullOrWhiteSpace(upgradeBasePath) Then
            Return results
        End If

        If Not Directory.Exists(upgradeBasePath) Then
            Return results
        End If

        Dim directories() As String =
        Directory.GetDirectories(
            upgradeBasePath,
            "Version *")

        Dim total As Integer = directories.Length
        Dim current As Integer = 0

        For Each dirPath As String In directories

            current += 1

            Dim percent As Integer

            If total > 0 Then
                percent = CInt((current / total) * 100)
            Else
                percent = 0
            End If

            If progress IsNot Nothing Then

                progress.Invoke(
                "Scanning installer versions..." &
                Environment.NewLine &
                $"{current} of {total} ({percent}%)" &
                Environment.NewLine &
                Path.GetFileName(dirPath))
            End If

            Dim dirName As String =
            Path.GetFileName(dirPath)

            Dim versionPart As String =
            dirName.Substring("Version ".Length).Trim()

            Dim parsedVersion As Version = Nothing

            If Not Version.TryParse(versionPart, parsedVersion) Then
                Continue For
            End If

            Dim info As New InstallerVersionInfo With {
            .Version = parsedVersion,
            .VersionString = dirName,
            .FolderPath = dirPath,
            .CreationTime = Directory.GetCreationTime(dirPath),
            .SizeBytes = GetDirectorySizeBytes(dirPath),
            .Track = GetReleaseTrack(parsedVersion)
        }

            results.Add(info)

        Next

        Dim latest As InstallerVersionInfo =
        results.
            OrderByDescending(Function(v) v.Version).
            FirstOrDefault()

        If latest IsNot Nothing Then
            latest.IsLatest = True
        End If

        Return results

    End Function

    Public Function ContainsLockedFiles(folderPath As String) As Boolean

        Dim overallSw As Stopwatch = Stopwatch.StartNew()


        Try

            Dim files =
             Directory.EnumerateFiles(
            folderPath,
            "*",
            SearchOption.TopDirectoryOnly)
            'Directory.EnumerateFiles(
            '    folderPath,
            '    "*",
            '    SearchOption.AllDirectories).ToList()


            For Each filePath As String In files

                Dim fileSw As Stopwatch = Stopwatch.StartNew()

                Try

                    Using fs As FileStream =
                    File.Open(
                        filePath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.None)

                    End Using

                    fileSw.Stop()

                    If fileSw.ElapsedMilliseconds > 100 Then

                    End If

                Catch ex As Exception

                    fileSw.Stop()



                    overallSw.Stop()



                    Return True

                End Try

            Next

        Catch ex As Exception



            Return True

        End Try

        overallSw.Stop()


        Return False

    End Function
    Public Function IsInstallerRunningFromVersion(folderPath As String) As Boolean

        For Each proc As Process In Process.GetProcesses()

            ' ✅ Filter aggressively by known installer prefix
            If String.IsNullOrWhiteSpace(proc.ProcessName) OrElse
           Not proc.ProcessName.StartsWith(
               "AdvantageSetup",
               StringComparison.OrdinalIgnoreCase) Then
                Continue For
            End If

            Try
                If proc.MainModule Is Nothing Then Continue For

                Dim exePath = proc.MainModule.FileName

                If exePath IsNot Nothing AndAlso
               exePath.StartsWith(
                   folderPath,
                   StringComparison.OrdinalIgnoreCase) Then
                    Return True
                End If

            Catch ex As System.ComponentModel.Win32Exception
                ' Expected: access denied
                Continue For

            Catch ex As InvalidOperationException
                ' Expected: process exited
                Continue For
            End Try

        Next

        Return False
    End Function

    Public Sub ApplyCleanupSafetyRules(
    versions As List(Of InstallerVersionInfo),
    Optional runExistingVersionPath As String = Nothing,
    Optional progress As Action(Of String) = Nothing
)

        ' --------------------------------------------------------
        ' Resolve installed installer folder ONCE
        ' --------------------------------------------------------
        Dim installedFolder As String =
        InstalledVersionParsing.FindInstalledInstallerFolder(
            AppData.UpgradePath,
            "AdvCoreService"
        )
        ' --------------------------------------------------------
        ' Resolve newest LTS version ONCE
        ' --------------------------------------------------------
        Dim latestLtsVersion As InstallerVersionInfo =
    versions.
        Where(Function(v) v.Track = ReleaseTrack.LongTermSupport).
        OrderByDescending(Function(v) v.Version).
        FirstOrDefault()

        Dim total As Integer = versions.Count
        Dim current As Integer = 0

        For Each v In versions

            current += 1

            Dim percent As Integer

            If total > 0 Then
                percent = CInt((current / total) * 100)
            Else
                percent = 0
            End If

            If progress IsNot Nothing Then

                progress.Invoke(
                "Evaluating installer versions..." &
                Environment.NewLine &
                $"{current} of {total} ({percent}%)" &
                Environment.NewLine &
                v.VersionString)

            End If

            ' ====================================================
            ' RULE 0 — INSTALLED VERSION
            ' ====================================================
            If Not String.IsNullOrEmpty(installedFolder) AndAlso
           v.FolderPath.Equals(
               installedFolder,
               StringComparison.OrdinalIgnoreCase) Then

                v.LockReason = VersionLockReason.InstalledVersion

                Continue For

            End If

            ' ====================================================
            ' RULE 1 — LATEST VERSION
            ' ====================================================
            If v.IsLatest Then

                ' Uncomment if latest version should be protected
                '
                ' v.LockReason = VersionLockReason.LatestVersion
                ' Continue For

            End If

            ' ====================================================
            ' RULE 2 — LATEST LTS ONLY
            ' ====================================================
            If latestLtsVersion IsNot Nothing AndAlso
   Object.ReferenceEquals(v, latestLtsVersion) Then

                v.LockReason = VersionLockReason.LongTermSupport

                Continue For

            End If

            ' ====================================================
            ' RULE 3 — RUN EXISTING
            ' ====================================================
            If Not String.IsNullOrWhiteSpace(runExistingVersionPath) AndAlso
           v.FolderPath.Equals(
               runExistingVersionPath,
               StringComparison.OrdinalIgnoreCase) Then

                v.LockReason = VersionLockReason.SelectedAsRunExisting

                Continue For

            End If

            ' ====================================================
            ' RULE 4 — INSTALLER RUNNING
            ' ====================================================
            If IsInstallerRunningFromVersion(v.FolderPath) Then

                v.LockReason = VersionLockReason.InstallerRunning

                Continue For

            End If

            ' ====================================================
            ' RULE 5 — FILES LOCKED
            ' ====================================================
            If ContainsLockedFiles(v.FolderPath) Then

                v.LockReason = VersionLockReason.FileLocked

                Continue For

            End If

            ' ====================================================
            ' RULE 6 — CLEANUP ELIGIBLE
            ' ====================================================
            v.LockReason = VersionLockReason.None

        Next

    End Sub
    Public Function ExecuteInstallerVersionCleanup(
        versionsToDelete As List(Of InstallerVersionInfo)
    ) As InstallerCleanupResult

        Dim result As New InstallerCleanupResult()

        For Each info In versionsToDelete

            ' ✅ Absolute safety check (never trust UI)
            If Not info.CanDelete Then
                result.Skipped.Add(info)
                Continue For
            End If

            Try
                ' Final sanity check
                If Directory.Exists(info.FolderPath) Then
                    Directory.Delete(info.FolderPath, recursive:=True)
                End If

                result.Deleted.Add(info)

            Catch ex As Exception
                result.Failed.Add(info, ex)
            End Try

        Next

        Return result
    End Function

End Module