Imports System.IO
Imports System.Text
Imports System.Text.Json
Imports System.Text.Json.Serialization

' NOTE: This class is intentionally UI-free and safe to call at startup.
' It initializes QuickLaunchIds only if missing and NORMALIZES/DEDUPES
' so the list cannot grow or drift across runs.

Public NotInheritable Class OptionsManager

    Private Shared ReadOnly _jsonOptions As New JsonSerializerOptions With {
    .WriteIndented = True,
    .PropertyNameCaseInsensitive = True,
    .DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    .AllowTrailingCommas = True,
    .ReadCommentHandling = JsonCommentHandling.Skip
}

    ' =========================================================
    ' Options
    ' =========================================================

    Public Shared Function LoadOrCreate() As AppOptions
        Dim path = GetOptionsPath()

        Try
            Dim opts As AppOptions

            If File.Exists(path) Then
                ' Tolerant read (handles BOM / leading whitespace)
                Dim json = SafeReadAllText(path)
                opts = JsonSerializer.Deserialize(Of AppOptions)(json, _jsonOptions)
                If opts Is Nothing Then opts = New AppOptions()
            Else
                opts = New AppOptions()
            End If

            Dim changed As Boolean = False

            ' Initialize missing collections only
            If opts.QuickLaunchIds Is Nothing Then
                opts.QuickLaunchIds =
                    Enumerable.Repeat("", GenericConstants.QUICKLAUNCH_SLOT_COUNT).ToList()
                changed = True
            End If

            If opts.DefaultFlavorNames Is Nothing Then
                opts.DefaultFlavorNames = New List(Of String)
                changed = True
            End If

            ' Normalize QuickLaunch only
            changed = DedupeQuickLaunchIds(opts) OrElse changed
            changed = TrimTrailingEmptyQuickSlots(opts) OrElse changed

            If changed Then
                Save(opts)
            End If

            Return opts

        Catch
            ' Fail-soft fallback
            Return New AppOptions() With {
                .QuickLaunchIds =
                    Enumerable.Repeat("", GenericConstants.QUICKLAUNCH_SLOT_COUNT).ToList(),
                .DefaultFlavorNames = New List(Of String)
            }
        End Try
    End Function

    ' =========================================================
    ' Save (FIXED: preserves flavors + UI toggles)
    ' =========================================================

    Public Shared Sub Save(opts As AppOptions)
        Dim path = GetOptionsPath()

        Try
            EnsureParentDirectory(path)

            If opts Is Nothing Then opts = New AppOptions()

            ' Ensure QuickLaunchIds exists
            If opts.QuickLaunchIds Is Nothing Then
                opts.QuickLaunchIds =
                    Enumerable.Repeat("", GenericConstants.QUICKLAUNCH_SLOT_COUNT).ToList()
            End If

            ' -------------------------------------------------
            ' Snapshot properties NOT owned by QuickLaunch
            ' -------------------------------------------------
            Dim repoFolderSnapshot As String = opts.RepoFolderPath
            Dim showHiddenSnapshot As Boolean = opts.ShowHiddenServices

            Dim defaultFlavorsSnapshot As List(Of String) =
                If(opts.DefaultFlavorNames Is Nothing,
                   Nothing,
                   New List(Of String)(opts.DefaultFlavorNames))

            ' -------------------------------------------------
            ' Normalize QuickLaunch ONLY
            ' -------------------------------------------------
            DedupeQuickLaunchIds(opts)
            TrimTrailingEmptyQuickSlots(opts)

            ' -------------------------------------------------
            ' Restore preserved properties
            ' -------------------------------------------------
            opts.RepoFolderPath = repoFolderSnapshot
            opts.ShowHiddenServices = showHiddenSnapshot
            opts.DefaultFlavorNames = defaultFlavorsSnapshot

            ' -------------------------------------------------
            ' Serialize
            ' -------------------------------------------------
            Dim json = JsonSerializer.Serialize(opts, _jsonOptions)

            File.WriteAllText(path, json, Encoding.UTF8)

        Catch ex As Exception
            Debug.WriteLine("Options save failed: " & ex.Message)
        End Try
    End Sub

    Public Shared Function GetOptionsPath() As String
        Dim dir =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "STA2")
        Directory.CreateDirectory(dir)
        Return Path.Combine(dir, "options.json")
    End Function

    ' =========================================================
    ' Launcher Config
    ' =========================================================

    Public Shared Function LoadLauncherConfig() As LauncherConfig
        Dim path = GetLauncherConfigPath()

        If Not File.Exists(path) Then
            Return New LauncherConfig()
        End If

        Try
            Dim json = SafeReadAllText(path)
            Dim cfg = JsonSerializer.Deserialize(Of LauncherConfig)(json, _jsonOptions)
            If cfg Is Nothing Then cfg = New LauncherConfig()
            If cfg.Programs Is Nothing Then cfg.Programs = New List(Of ProgramEntry)()

            ' Ensure stable IDs
            Dim changed As Boolean = False
            For Each p In cfg.Programs
                If p IsNot Nothing AndAlso String.IsNullOrWhiteSpace(p.Id) Then
                    p.Id = Guid.NewGuid().ToString("N")
                    changed = True
                End If
            Next

            If changed Then SaveLauncherConfig(cfg)

            Return cfg

        Catch
            Return New LauncherConfig()
        End Try
    End Function

    Public Shared Sub SaveLauncherConfig(cfg As LauncherConfig)
        Dim path = GetLauncherConfigPath()

        Try
            EnsureParentDirectory(path)

            If cfg Is Nothing Then cfg = New LauncherConfig()
            If cfg.Programs Is Nothing Then cfg.Programs = New List(Of ProgramEntry)()

            Dim json = JsonSerializer.Serialize(cfg, _jsonOptions)


            Dim tmp = path & ".tmp"
            File.WriteAllText(tmp, json, Encoding.UTF8)

            If File.Exists(path) Then
                Try
                    File.Delete(path)
                    File.Move(tmp, path)
                Catch
                    Try
                        File.Copy(tmp, path, overwrite:=True)
                        File.Delete(tmp)
                    Catch
                    End Try
                End Try
            Else
                File.Move(tmp, path)
            End If

        Catch
            ' Fail-soft
        End Try
    End Sub

    Public Shared Function ReloadLauncherConfig() As LauncherConfig
        Return LoadLauncherConfig()
    End Function

    Public Shared Function GetLauncherConfigPath() As String
        Dim dir =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "STA2")
        Directory.CreateDirectory(dir)
        Return Path.Combine(dir, "launcher.config.json")
    End Function

    ' =========================================================
    ' QuickLaunch helpers
    ' =========================================================

    Public Shared Sub EnsureQuickLaunchSlotCount(
        opts As AppOptions,
        target As Integer,
        Optional shrink As Boolean = False)

        If opts Is Nothing Then Exit Sub

        If opts.QuickLaunchIds Is Nothing Then
            opts.QuickLaunchIds = Enumerable.Repeat("", target).ToList()
        Else
            While opts.QuickLaunchIds.Count < target
                opts.QuickLaunchIds.Add("")
            End While
            If shrink Then
                While opts.QuickLaunchIds.Count > target
                    opts.QuickLaunchIds.RemoveAt(opts.QuickLaunchIds.Count - 1)
                End While
            End If
        End If

        Save(opts)
    End Sub

    Public Shared Function DedupeQuickLaunchIds(opts As AppOptions) As Boolean
        If opts Is Nothing OrElse opts.QuickLaunchIds Is Nothing Then Return False

        Dim seen As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim changed As Boolean = False

        For i = 0 To opts.QuickLaunchIds.Count - 1
            Dim id = opts.QuickLaunchIds(i)
            If String.IsNullOrWhiteSpace(id) Then Continue For
            If Not seen.Add(id) Then
                opts.QuickLaunchIds(i) = ""
                changed = True
            End If
        Next

        Return changed
    End Function

    Public Shared Function TrimTrailingEmptyQuickSlots(opts As AppOptions) As Boolean
        If opts Is Nothing OrElse opts.QuickLaunchIds Is Nothing Then Return False

        Dim originalCount = opts.QuickLaunchIds.Count

        Dim lastAssigned As Integer = -1
        For i = 0 To opts.QuickLaunchIds.Count - 1
            If Not String.IsNullOrWhiteSpace(opts.QuickLaunchIds(i)) Then
                lastAssigned = i
            End If
        Next

        Dim minCount =
            Math.Max(GenericConstants.QUICKLAUNCH_SLOT_COUNT, lastAssigned + 1)

        If opts.QuickLaunchIds.Count > minCount Then
            For j = minCount To opts.QuickLaunchIds.Count - 1
                If Not String.IsNullOrWhiteSpace(opts.QuickLaunchIds(j)) Then
                    Return False
                End If
            Next
            opts.QuickLaunchIds.RemoveRange(
                minCount,
                opts.QuickLaunchIds.Count - minCount)
        End If

        Return opts.QuickLaunchIds.Count <> originalCount
    End Function

    ' =========================================================
    ' IO Helpers
    ' =========================================================

    Private Shared Function SafeReadAllText(path As String) As String
        Dim bytes = File.ReadAllBytes(path)
        bytes = StripUtf8Bom(bytes)
        bytes = TrimLeadingWhitespace(bytes)
        Return Encoding.UTF8.GetString(bytes)
    End Function

    Private Shared Sub EnsureParentDirectory(path As String)
        Dim dir = System.IO.Path.GetDirectoryName(path)
        If Not String.IsNullOrWhiteSpace(dir) Then
            Directory.CreateDirectory(dir)
        End If
    End Sub

    Private Shared Function StripUtf8Bom(data As Byte()) As Byte()
        If data IsNot Nothing AndAlso data.Length >= 3 AndAlso
           data(0) = &HEF AndAlso data(1) = &HBB AndAlso data(2) = &HBF Then
            Dim withoutBom(data.Length - 4) As Byte
            Buffer.BlockCopy(data, 3, withoutBom, 0, data.Length - 3)
            Return withoutBom
        End If
        Return data
    End Function

    Private Shared Function TrimLeadingWhitespace(data As Byte()) As Byte()
        If data Is Nothing OrElse data.Length = 0 Then Return data

        Dim i As Integer = 0
        While i < data.Length
            Select Case data(i)
                Case &H20, &H9, &HD, &HA
                    i += 1
                Case Else
                    Exit While
            End Select
        End While

        If i = 0 Then Return data

        Dim trimmed(data.Length - i - 1) As Byte
        Buffer.BlockCopy(data, i, trimmed, 0, trimmed.Length)
        Return trimmed
    End Function

    ' =========================================================
    ' Personal Flavor File Helpers
    ' =========================================================

    Public Shared Function GetPersonalFlavorPath() As String
        Dim optionsDir = Path.GetDirectoryName(GetOptionsPath())
        Return Path.Combine(optionsDir, "PersonalFlavor.sql")
    End Function

    Public Shared Function LoadPersonalFlavor() As String
        Dim path = GetPersonalFlavorPath()

        Try
            If File.Exists(path) Then
                Return File.ReadAllText(path)
            End If
        Catch ex As Exception
            Debug.WriteLine("Failed to load personal flavor: " & ex.Message)
        End Try

        Return ""
    End Function

    Public Shared Sub SavePersonalFlavor(sqlText As String)
        Dim path = GetPersonalFlavorPath()

        Try
            EnsureParentDirectory(path)
            File.WriteAllText(path, sqlText, Encoding.UTF8)
        Catch ex As Exception
            Debug.WriteLine("Failed to save personal flavor: " & ex.Message)
        End Try
    End Sub
End Class