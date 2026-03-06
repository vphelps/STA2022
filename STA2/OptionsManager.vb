' OptionsManager.vb
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json

' Central manager for reading/writing config files in %APPDATA%\STA2\
Public Module OptionsManager

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

        If Not File.Exists(path) Then
            Dim defaults As New AppOptions()
            Save(defaults)
            Return defaults
        End If

        ' Primary read from stream
        Try
            Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim ser As New DataContractJsonSerializer(GetType(AppOptions))
                Dim opts = TryCast(ser.ReadObject(fs), AppOptions)
                If opts Is Nothing Then Return New AppOptions()
                Return opts
            End Using
        Catch
            ' Fallback: strip BOM + leading whitespace and retry
            Try
                Dim bytes = File.ReadAllBytes(path)
                bytes = StripUtf8Bom(bytes)
                bytes = TrimLeadingWhitespace(bytes)
                Using ms As New MemoryStream(bytes)
                    Dim ser As New DataContractJsonSerializer(GetType(AppOptions))
                    Dim opts = TryCast(ser.ReadObject(ms), AppOptions)
                    If opts Is Nothing Then Return New AppOptions()
                    Return opts
                End Using
            Catch ex2 As Exception
                MessageBox.Show("Options file could not be read. Defaults will be used." &
                                Environment.NewLine & ex2.Message,
                                "Options", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return New AppOptions()
            End Try
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

    ' ---- LauncherConfig (programs list) ------------------------------------------------------
    ' Uses Newtonsoft.Json to match your existing JSON formatting & behavior.

    Public Function LoadLauncherConfig() As LauncherConfig
        Dim path = GetLauncherConfigPath()

        If Not File.Exists(path) Then
            ' First run: empty config (no programs yet)
            Return New LauncherConfig()
        End If

        Try
            ' Robust read: bytes -> strip BOM -> trim leading WS -> decode UTF8 -> deserialize
            Dim bytes = File.ReadAllBytes(path)
            bytes = StripUtf8Bom(bytes)
            bytes = TrimLeadingWhitespace(bytes)
            Dim json = Encoding.UTF8.GetString(bytes)

            Dim cfg = JsonConvert.DeserializeObject(Of LauncherConfig)(json, _jsonSettings)
            If cfg Is Nothing Then cfg = New LauncherConfig()
            If cfg.Programs Is Nothing Then cfg.Programs = New List(Of ProgramEntry)()
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
        If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)

        If cfg Is Nothing Then cfg = New LauncherConfig()
        If cfg.Programs Is Nothing Then cfg.Programs = New List(Of ProgramEntry)()

        Try
            Dim json = JsonConvert.SerializeObject(cfg, _jsonSettings)

            ' Atomic-ish save: write temp with UTF-8 (no BOM), then replace
            Dim tmp = path & ".tmp"
            File.WriteAllText(tmp, json, Utf8NoBom)
            If File.Exists(path) Then
                File.Replace(tmp, path, Nothing)
            Else
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

End Module