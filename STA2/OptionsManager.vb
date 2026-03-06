Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Windows.Forms

' Centralized manager for reading/writing general options in %APPDATA%\STA2\options.json
Public Module OptionsManager

    ' ---- App Folder & File Names -------------------------------------------------------------

    Private Const AppFolderName As String = "STA2"               ' matches your GetConfigPath approach
    Private Const OptionsFileName As String = "options.json"     ' general options file
    Private Const LauncherFileName As String = "launcher.config.json" ' your existing launcher config (optional helper below)

    ' UTF-8 **without** BOM to prevent ï»¿ issues when reloading JSON
    Private ReadOnly Utf8NoBom As New UTF8Encoding(encoderShouldEmitUTF8Identifier:=False)

    ' ---- Public Path Helpers ----------------------------------------------------------------

    ''' <summary>
    ''' Returns %APPDATA%\STA2 and ensures the directory exists.
    ''' Example: C:\Users\{User}\AppData\Roaming\STA2
    ''' </summary>
    Public Function GetAppDataDirectory() As String
        Dim base As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim dir As String = Path.Combine(base, AppFolderName)
        If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)
        Return dir
    End Function

    ''' <summary>
    ''' Full path to options.json in %APPDATA%\STA2\options.json
    ''' </summary>
    Public Function GetOptionsPath() As String
        Return Path.Combine(GetAppDataDirectory(), OptionsFileName)
    End Function

    ''' <summary>
    ''' (Optional) Full path to launcher.config.json in %APPDATA%\STA2\launcher.config.json
    ''' Provided for convenience alongside options.json.
    ''' </summary>
    Public Function GetLauncherConfigPath() As String
        Return Path.Combine(GetAppDataDirectory(), LauncherFileName)
    End Function

    ' ---- Load / Save ------------------------------------------------------------------------

    ''' <summary>
    ''' Loads options.json if present; otherwise creates it with defaults and returns defaults.
    ''' Robust to UTF-8 BOM and stray leading bytes.
    ''' </summary>
    Public Function LoadOrCreate() As AppOptions
        Dim path = GetOptionsPath()

        If Not File.Exists(path) Then
            Dim defaults As New AppOptions()
            Save(defaults) ' create with defaults using UTF-8 (no BOM)
            Return defaults
        End If

        ' Primary path: deserialize directly from FileStream.
        Try
            Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim ser As New DataContractJsonSerializer(GetType(AppOptions))
                Dim opts = TryCast(ser.ReadObject(fs), AppOptions)
                If opts Is Nothing Then
                    ' If somehow deserialized to Nothing, return defaults (do not overwrite file)
                    Return New AppOptions()
                End If
                Return opts
            End Using

        Catch
            ' Fallback: strip UTF-8 BOM (and any accidental leading bytes) and retry from memory.
            Try
                Dim bytes = File.ReadAllBytes(path)
                bytes = StripUtf8Bom(bytes)
                ' Also trim any leading whitespace/newlines that some editors may inject
                bytes = TrimLeadingWhitespace(bytes)

                Using ms As New MemoryStream(bytes)
                    Dim ser As New DataContractJsonSerializer(GetType(AppOptions))
                    Dim opts = TryCast(ser.ReadObject(ms), AppOptions)
                    If opts Is Nothing Then
                        Return New AppOptions()
                    End If
                    Return opts
                End Using

            Catch ex2 As Exception
                ' Graceful degradation: notify and return defaults, keeping the on-disk file intact
                MessageBox.Show("Options file could not be read. Defaults will be used." &
                                Environment.NewLine & ex2.Message,
                                "Options", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return New AppOptions()
            End Try
        End Try
    End Function

    ''' <summary>
    ''' Saves options.json to %APPDATA%\STA2 using UTF-8 without BOM (atomic-ish write).
    ''' </summary>
    Public Sub Save(options As AppOptions)
        Dim path = GetOptionsPath()
        'Dim dir = path.GetDirectoryName(path)
        Dim dir = System.IO.Path.GetDirectoryName(path)
        If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)

        ' Serialize to JSON text
        Dim json As String
        Using ms As New MemoryStream()
            Dim ser As New DataContractJsonSerializer(GetType(AppOptions))
            ser.WriteObject(ms, options)
            json = Encoding.UTF8.GetString(ms.ToArray())
        End Using

        ' Write atomically to reduce chance of partial writes: write temp then replace
        Dim tmpPath = path & ".tmp"
        File.WriteAllText(tmpPath, json, Utf8NoBom)
        If File.Exists(path) Then
            File.Replace(tmpPath, path, Nothing) ' replace old with new
        Else
            File.Move(tmpPath, path)
        End If
    End Sub

    ' ---- Utilities --------------------------------------------------------------------------

    ''' <summary>
    ''' Removes a UTF-8 BOM if present: EF BB BF.
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
    ''' Helpful if an editor injected blank lines before the opening '{'.
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

    ' ---- Convenience (optional) -------------------------------------------------------------

    ''' <summary>
    ''' Opens the STA2 AppData folder in Explorer for quick access.
    ''' </summary>
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