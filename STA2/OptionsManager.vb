Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

' NOTE: This class is intentionally UI-free and safe to call at startup.
' It initializes QuickLaunchIds only if missing and NORMALIZES/DEDUPES
' so the list cannot grow or drift across runs.

Public NotInheritable Class OptionsManager

    ' ---------------------------------------------------------------------
    ' DEFAULT (first-run) number of quick slots.
    ' Applied ONLY when QuickLaunchIds is Nothing.
    ' ---------------------------------------------------------------------
    Private Const QUICKLAUNCH_SLOT_COUNT As Integer = 9

    ' Shared JSON settings used across options and launcher config
    Private Shared ReadOnly _jsonSettings As New JsonSerializerSettings With {
        .Formatting = Formatting.Indented,
        .NullValueHandling = NullValueHandling.Ignore
    }

    ' ------------------------
    ' Public: Options
    ' ------------------------

    Public Shared Function LoadOrCreate() As AppOptions
        Dim path = GetOptionsPath()

        Try
            Dim opts As AppOptions

            If File.Exists(path) Then
                ' Tolerant read (handles BOM/leading whitespace)
                Dim json = SafeReadAllText(path)
                opts = JsonConvert.DeserializeObject(Of AppOptions)(json, _jsonSettings)
                If opts Is Nothing Then opts = New AppOptions()
            Else
                opts = New AppOptions()
            End If

            Dim changed As Boolean = False

            ' Initialize only if missing
            If opts.QuickLaunchIds Is Nothing Then
                opts.QuickLaunchIds = Enumerable.Repeat("", QUICKLAUNCH_SLOT_COUNT).ToList()
                changed = True
                Debug.WriteLine($"[Options] Init QuickLaunchIds -> {QUICKLAUNCH_SLOT_COUNT}")
            End If

            ' Enforce uniqueness and trim trailing empties (prevents run-to-run growth)
            changed = DedupeQuickLaunchIds(opts) OrElse changed
            changed = TrimTrailingEmptyQuickSlots(opts) OrElse changed

            If changed Then
                Save(opts)
                Debug.WriteLine($"[Options] LoadOrCreate normalized & saved. Count={opts.QuickLaunchIds.Count}")
            Else
                Debug.WriteLine($"[Options] LoadOrCreate loaded. Count={opts.QuickLaunchIds.Count}")
            End If

            Return opts

        Catch ex As Exception
            Debug.WriteLine($"[Options] LoadOrCreate ERROR: {ex.Message}")
            ' Fail-soft: return a default object with a first-run list
            Dim fallback As New AppOptions() With {
                .QuickLaunchIds = Enumerable.Repeat("", QUICKLAUNCH_SLOT_COUNT).ToList()
            }
            Return fallback
        End Try
    End Function

    Public Shared Sub Save(opts As AppOptions)
        Dim path = GetOptionsPath()
        Try
            EnsureParentDirectory(path)

            If opts Is Nothing Then opts = New AppOptions()
            If opts.QuickLaunchIds Is Nothing Then
                opts.QuickLaunchIds = Enumerable.Repeat("", QUICKLAUNCH_SLOT_COUNT).ToList()
                'Debug.WriteLine($"[Options] Save: Init QuickLaunchIds -> {QUICKLAUNCH_SLOT_COUNT}")
            End If

            ' === DIAGNOSTICS: BEFORE ===
            'Debug.WriteLine($"[Options] Save BEFORE normalize: Count={opts.QuickLaunchIds.Count}")
            'Debug.WriteLine($"[Options] Save stack: {Environment.NewLine}{New System.Diagnostics.StackTrace(True)}")

            ' Keep stable: dedupe + trim
            Dim changed As Boolean = False
            changed = DedupeQuickLaunchIds(opts) OrElse changed
            changed = TrimTrailingEmptyQuickSlots(opts) OrElse changed

            ' === DIAGNOSTICS: AFTER ===
            'Debug.WriteLine($"[Options] Save AFTER normalize: Count={opts.QuickLaunchIds.Count}")

            Dim json = JsonConvert.SerializeObject(opts, _jsonSettings)
            File.WriteAllText(path, json, Encoding.UTF8)

        Catch ex As Exception
            Debug.WriteLine($"[Options] Save ERROR: {ex.Message}")
            ' Swallow/log if you have a logger. Never crash the app on options save.
        End Try
    End Sub

    Public Shared Function GetOptionsPath() As String
        Dim dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "STA2")
        Directory.CreateDirectory(dir)
        Return Path.Combine(dir, "options.json")
    End Function

    ' ------------------------
    ' Public: Launcher Config
    ' ------------------------

    Public Shared Function LoadLauncherConfig() As LauncherConfig
        Dim path = GetLauncherConfigPath()

        If Not File.Exists(path) Then
            Return New LauncherConfig()
        End If

        Try
            Dim json = SafeReadAllText(path)
            Dim cfg = JsonConvert.DeserializeObject(Of LauncherConfig)(json, _jsonSettings)
            If cfg Is Nothing Then cfg = New LauncherConfig()
            If cfg.Programs Is Nothing Then cfg.Programs = New List(Of ProgramEntry)()

            ' Migration: ensure each ProgramEntry has a stable Id & persist if any were missing
            Dim changed As Boolean = False
            For Each p In cfg.Programs
                If p IsNot Nothing AndAlso String.IsNullOrWhiteSpace(p.Id) Then
                    p.Id = Guid.NewGuid().ToString("N")
                    changed = True
                End If
            Next

            If changed Then
                SaveLauncherConfig(cfg)
            End If

            Return cfg

        Catch
            ' Fail-soft: blank config
            Return New LauncherConfig()
        End Try
    End Function

    Public Shared Sub SaveLauncherConfig(cfg As LauncherConfig)
        Dim path = GetLauncherConfigPath()
        Try
            EnsureParentDirectory(path)
            If cfg Is Nothing Then cfg = New LauncherConfig()
            If cfg.Programs Is Nothing Then cfg.Programs = New List(Of ProgramEntry)()

            Dim json = JsonConvert.SerializeObject(cfg, _jsonSettings)

            ' Robust save: write temp then replace/move (framework-friendly)
            Dim tmp = path & ".tmp"
            File.WriteAllText(tmp, json, Encoding.UTF8)

            If File.Exists(path) Then
                Try
                    ' Framework-friendly replace:
                    File.Delete(path)
                    File.Move(tmp, path)
                Catch
                    Try
                        File.Copy(tmp, path, overwrite:=True)
                        File.Delete(tmp)
                    Catch
                        ' Last resort: leave tmp if copy failed
                    End Try
                End Try
            Else
                File.Move(tmp, path)
            End If

        Catch
            ' Swallow/log if you have a logger
        End Try
    End Sub

    Public Shared Function ReloadLauncherConfig() As LauncherConfig
        Return LoadLauncherConfig()
    End Function

    Public Shared Function GetLauncherConfigPath() As String
        Dim dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "STA2")
        Directory.CreateDirectory(dir)
        Return Path.Combine(dir, "launcher.config.json")
    End Function

    ' ------------------------
    ' Public helpers (admin / migrations)
    ' ------------------------

    ''' <summary>
    ''' Explicit migration helper if you later decide to change the quick slot count.
    ''' Not called by LoadOrCreate to avoid silent growth across runs.
    ''' Call it once on purpose (e.g., from a settings action) and then remove the call.
    ''' </summary>
    Public Shared Sub EnsureQuickLaunchSlotCount(opts As AppOptions, target As Integer, Optional shrink As Boolean = False)
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

    ''' <summary>
    ''' Ensures each program Id appears at most once across QuickLaunchIds.
    ''' Keeps the first occurrence, clears later duplicates. Returns True if changed.
    ''' </summary>
    Public Shared Function DedupeQuickLaunchIds(opts As AppOptions) As Boolean
        If opts Is Nothing OrElse opts.QuickLaunchIds Is Nothing Then Return False

        Dim seen As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim changed As Boolean = False

        For i = 0 To opts.QuickLaunchIds.Count - 1
            Dim id = opts.QuickLaunchIds(i)
            If String.IsNullOrWhiteSpace(id) Then Continue For
            If Not seen.Add(id) Then
                ' Duplicate — clear this later occurrence
                opts.QuickLaunchIds(i) = ""
                changed = True
            End If
        Next
        Return changed
    End Function

    ''' <summary>
    ''' Trims trailing empty slots while preserving the last assigned slot.
    ''' Keeps at least DEFAULT slots and enough to include last assigned.
    ''' Returns True if changed.
    ''' </summary>
    Public Shared Function TrimTrailingEmptyQuickSlots(opts As AppOptions) As Boolean
        If opts Is Nothing OrElse opts.QuickLaunchIds Is Nothing Then Return False

        Dim originalCount = opts.QuickLaunchIds.Count

        ' Find last non-empty index
        Dim lastAssigned As Integer = -1
        For i = 0 To opts.QuickLaunchIds.Count - 1
            If Not String.IsNullOrWhiteSpace(opts.QuickLaunchIds(i)) Then
                lastAssigned = i
            End If
        Next

        ' Keep at least default and enough to include last assigned slot
        Dim minCount As Integer = Math.Max(QUICKLAUNCH_SLOT_COUNT, lastAssigned + 1)

        If opts.QuickLaunchIds.Count > minCount Then
            ' Trim only if the tail beyond minCount is all empty
            For j = minCount To opts.QuickLaunchIds.Count - 1
                If Not String.IsNullOrWhiteSpace(opts.QuickLaunchIds(j)) Then
                    Return False ' can't trim; there is a non-empty tail
                End If
            Next
            opts.QuickLaunchIds.RemoveRange(minCount, opts.QuickLaunchIds.Count - minCount)
        End If

        Return opts.QuickLaunchIds.Count <> originalCount
    End Function

    ' ------------------------
    ' Private IO helpers
    ' ------------------------

    ' Safe tolerant read: strips UTF-8 BOM and leading whitespace if present, then returns text.
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


End Class