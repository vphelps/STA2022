' OptionsManager.vb
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json


' Central manager for reading/writing config files in %APPDATA%\STA2\
Public Module OptionsManager
    Private Const QUICKLAUNCH_SLOT_COUNT As Integer = 9

    ' ---- App Folder & File Names -------------------------------------------------------------
    Private Const AppFolderName As String = "STA2"
    Private Const OptionsFileName As String = "options.json"
    Private Const LauncherFileName As String = "launcher.config.json"

    ' UTF-8 **without** BOM to prevent ï»¿ issues in JSON files
    Private ReadOnly Utf8NoBom As New UTF8Encoding(encoderShouldEmitUTF8Identifier:=False)

    ' Newtonsoft settings for launcher.config.json
    Private ReadOnly _jsonSettings As New JsonSerializerSettings With {
        .Formatting = Newtonsoft.Json.Formatting.Indented,
        .NullValueHandling = NullValueHandling.Ignore
    }

    ' ---- Public Path Helpers -----------------------------------------------------------------
    ''' <summary>
    ''' %APPDATA%\STA2 (ensures directory exists)
    ''' </summary>
    Public Function GetAppDataDirectory() As String
        Dim base As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim dir As String = Path.Combine(base, AppFolderName)
        If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)
        Return dir
    End Function

    ''' <summary>
    ''' %APPDATA%\STA2\options.json
    ''' </summary>
    Public Function GetOptionsPath() As String
        Return Path.Combine(GetAppDataDirectory(), OptionsFileName)
    End Function

    ''' <summary>
    ''' %APPDATA%\STA2\launcher.config.json
    ''' </summary>
    Public Function GetLauncherConfigPath() As String
        Return Path.Combine(GetAppDataDirectory(), LauncherFileName)
    End Function

    ' ---- AppOptions (general options) --------------------------------------------------------
    ' Uses DataContractJsonSerializer, as set up previously.

    Public Function LoadOrCreate() As AppOptions
        Dim path = GetOptionsPath()

        Try
            Dim opts As AppOptions = Nothing

            If File.Exists(path) Then
                Dim json = File.ReadAllText(path)
                opts = JsonConvert.DeserializeObject(Of AppOptions)(json, _jsonSettings)
                If opts Is Nothing Then opts = New AppOptions()
            Else
                opts = New AppOptions()
            End If

            ' --------------------------------------------
            ' ENSURE QuickLaunchIds EXISTS AND HAS N SLOTS
            ' --------------------------------------------
            Dim changed As Boolean = False

            If opts.QuickLaunchIds Is Nothing Then
                opts.QuickLaunchIds = Enumerable.Repeat("", QUICKLAUNCH_SLOT_COUNT).ToList()
                changed = True
            Else
                ' Expand existing lists to the new size, if needed
                While opts.QuickLaunchIds.Count < QUICKLAUNCH_SLOT_COUNT
                    opts.QuickLaunchIds.Add("")
                    changed = True
                End While
                ' (Optional) If you want to shrink when count is larger than desired:
                ' While opts.QuickLaunchIds.Count > QUICKLAUNCH_SLOT_COUNT
                '     opts.QuickLaunchIds.RemoveAt(opts.QuickLaunchIds.Count - 1)
                '     changed = True
                ' End While
            End If

            ' Persist if we changed slot count or created defaults
            If changed Then
                Save(opts)
            End If

            Return opts

        Catch ex As Exception
            ' Fail-soft: return a default object with the right number of slots
            Dim fallback As New AppOptions()
            If fallback.QuickLaunchIds Is Nothing Then
                fallback.QuickLaunchIds = Enumerable.Repeat("", QUICKLAUNCH_SLOT_COUNT).ToList()
            Else
                While fallback.QuickLaunchIds.Count < QUICKLAUNCH_SLOT_COUNT
                    fallback.QuickLaunchIds.Add("")
                End While
            End If
            Return fallback
        End Try
    End Function

    Public Sub Save(options As AppOptions)
        Dim path = GetOptionsPath()
        Dim dir = System.IO.Path.GetDirectoryName(path)
        If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)

        Dim json As String
        Using ms As New MemoryStream()
            Dim ser As New DataContractJsonSerializer(GetType(AppOptions))
            ser.WriteObject(ms, options)
            json = Encoding.UTF8.GetString(ms.ToArray())
        End Using

        Dim tmp = path & ".tmp"
        File.WriteAllText(tmp, json, Utf8NoBom)
        If File.Exists(path) Then
            File.Replace(tmp, path, Nothing)
        Else
            File.Move(tmp, path)
        End If
    End Sub

    Public Function LoadLauncherConfig() As LauncherConfig
        Dim path = GetLauncherConfigPath()

        If Not File.Exists(path) Then
            Return New LauncherConfig()
        End If

        Try
            Dim bytes = File.ReadAllBytes(path)
            bytes = StripUtf8Bom(bytes)
            bytes = TrimLeadingWhitespace(bytes)
            Dim json = Encoding.UTF8.GetString(bytes)

            Dim cfg = JsonConvert.DeserializeObject(Of LauncherConfig)(json, _jsonSettings)
            If cfg Is Nothing Then cfg = New LauncherConfig()
            If cfg.Programs Is Nothing Then cfg.Programs = New List(Of ProgramEntry)()

            ' --- Migration: assign Ids if missing ---
            Dim changed As Boolean = False
            For Each p In cfg.Programs
                If p Is Nothing Then Continue For
                If String.IsNullOrWhiteSpace(p.Id) Then
                    p.Id = Guid.NewGuid().ToString("N")
                    changed = True
                End If
            Next

            ' --- Persist to disk if we added any Ids ---
            If changed Then
                SaveLauncherConfig(cfg)
#If DEBUG Then
                Debug.WriteLine("LoadLauncherConfig: Migrated ProgramEntry Ids and saved launcher.config.json")
#End If
            End If

            Return cfg

        Catch ex As Exception
            MessageBox.Show("Failed to load launcher config. A blank config will be used." &
                        Environment.NewLine & ex.Message,
                        "Launcher Config", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return New LauncherConfig()
        End Try
    End Function

    Public Sub SaveLauncherConfig(cfg As LauncherConfig)
        Dim path = GetLauncherConfigPath()
        Dim dir = System.IO.Path.GetDirectoryName(path)
        If Not System.IO.Directory.Exists(dir) Then System.IO.Directory.CreateDirectory(dir)

        ' Normalize
        If cfg Is Nothing Then cfg = New LauncherConfig()
        If cfg.Programs Is Nothing Then cfg.Programs = New List(Of ProgramEntry)()

        Try
            ' Serialize with your existing Newtonsoft settings (_jsonSettings)
            Dim json As String = JsonConvert.SerializeObject(cfg, _jsonSettings)

            ' Write to temp file in same directory
            Dim tmp = path & ".tmp"

            ' Stronger durability: write with WriteThrough + Flush(True)
            Dim bytes = Encoding.UTF8.GetBytes(json) ' Utf8NoBom is used on WriteAllText, but here we control bytes directly
            Using fs As New FileStream(tmp,
                                   FileMode.Create,
                                   FileAccess.Write,
                                   FileShare.None,
                                   bufferSize:=4096,
                                   options:=FileOptions.WriteThrough)
                fs.Write(bytes, 0, bytes.Length)
                fs.Flush(True) ' flush data + metadata
            End Using

            ' Try atomic replace with backup; fall back if needed
            If File.Exists(path) Then
                Try
                    Dim backup = path & ".bak"
                    File.Replace(tmp, path, backup, ignoreMetadataErrors:=False)
                    ' (Optional) clean backup if you don't want to keep it
                    ' Try : File.Delete(backup) : Catch : End Try
                Catch exReplace As Exception
                    ' Fallback: overwrite target
                    Try
                        File.Copy(tmp, path, overwrite:=True)
                        File.Delete(tmp)
                    Catch exCopy As Exception
                        ' Last resort: delete and move
                        Try
                            File.Delete(path)
                            File.Move(tmp, path)
                        Catch exMove As Exception
                            ' Clean up temp on failure
                            Try : File.Delete(tmp) : Catch : End Try
                            Throw New IOException("Failed to save launcher config (replace/copy/move all failed).", exMove)
                        End Try
                    End Try
                End Try
            Else
                ' First save—just move temp into place
                File.Move(tmp, path)
            End If

        Catch ex As Exception
            MessageBox.Show("Failed to save launcher config:" & Environment.NewLine & ex.Message,
                        "Launcher Config", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---- Utilities --------------------------------------------------------------------------
    ''' <summary>
    ''' Removes a UTF-8 BOM (EF BB BF) if present.
    ''' </summary>
    Private Function StripUtf8Bom(data As Byte()) As Byte()
        If data IsNot Nothing AndAlso data.Length >= 3 AndAlso
           data(0) = &HEF AndAlso data(1) = &HBB AndAlso data(2) = &HBF Then
            Dim withoutBom(data.Length - 4) As Byte
            Buffer.BlockCopy(data, 3, withoutBom, 0, data.Length - 3)
            Return withoutBom
        End If
        Return data
    End Function

    ''' <summary>
    ''' Trims leading whitespace/newlines (space, tab, CR, LF) before JSON starts.
    ''' </summary>
    Private Function TrimLeadingWhitespace(data As Byte()) As Byte()
        If data Is Nothing OrElse data.Length = 0 Then Return data
        Dim i As Integer = 0
        While i < data.Length
            Dim b = data(i)
            If b = &H20 OrElse b = &H9 OrElse b = &HD OrElse b = &HA Then
                i += 1
            Else
                Exit While
            End If
        End While
        If i = 0 Then Return data
        Dim trimmed(data.Length - i - 1) As Byte
        Buffer.BlockCopy(data, i, trimmed, 0, trimmed.Length)
        Return trimmed
    End Function

    ' Convenience: open the STA2 folder in Explorer
    Public Sub OpenAppDataFolder()
        Dim folder = GetAppDataDirectory()
        Try
            Process.Start(New ProcessStartInfo() With {
                .FileName = folder,
                .UseShellExecute = True
            })
        Catch ex As Exception
            MessageBox.Show("Failed to open folder:" & Environment.NewLine & ex.Message,
                            "Options", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' OptionsManager.vb
    Public Function ReloadLauncherConfig() As LauncherConfig
        ' Re-read from disk using the hardened loader (with ID migration + save)
        Return LoadLauncherConfig()
    End Function

End Module