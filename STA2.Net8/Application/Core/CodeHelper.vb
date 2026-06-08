Imports System.IO
Imports System.Windows.Forms

Public Module CodeHelper

    Public Enum AppInstallState
        NotInstalled = 0
        InstalledX86 = 1
        InstalledX64 = 2
    End Enum

    Public Sub FirstLoad()
        Dim form = Startup.MainFormInstance
        Dim strTemp As String = ""


        If Variables.OfflineMode Then
            PCInfo.ValidDatabase = False
            form.tbPcDbInfo.Text = "Offline"
            Return
        End If

        ' Populate PC info
        GetPcInfo()
        'PCInfo.FrameworkVersion = DotNetInfo.Get45PlusFromRegistry
        PCInfo.FrameworkVersion = DotNetInfo.GetInstalledDotNetVersion()
        PCInfo.AdvantageVersion = CodeHelper.CeInfo

        Refresher()


    End Sub



    ' =======================================================================
    '  Refresher() updated to use SafeDb (prevents runtime crashes)
    ' =======================================================================
    Public Sub Refresher()

        ' Always update the Advantage version
        PCInfo.AdvantageVersion = CodeHelper.CeInfo

        ' If the system is already offline, stop here.
        If Variables.OfflineMode Then Exit Sub

        Dim frm As FormMain =
        TryCast(Application.OpenForms.Cast(Of Form)().
                FirstOrDefault(Function(f) TypeOf f Is FormMain),
                FormMain)

        If frm Is Nothing OrElse frm.IsDisposed Then Return

        ' Ensure UI thread
        If frm.InvokeRequired Then
            frm.BeginInvoke(CType(Sub() Refresher(), MethodInvoker))
            Return
        End If


        ' ============================================================
        ' 1) LicenseData (SafeDb)
        ' ============================================================
        If PCInfo.ValidDatabase Then
            Try
                Dim dsLic As DataSet = SafeDb.TryQuery(GeneralQueries.LicenseData)

                If dsLic IsNot Nothing AndAlso
               dsLic.Tables.Count > 0 AndAlso
               dsLic.Tables(0).Rows.Count > 0 Then

                    AppData.dbLicData = dsLic
                    Dim r = dsLic.Tables(0).Rows(0)

                    frm.tbLocName.Text = r("LocName").ToString()
                    frm.tbLicSvr.Text = r("LicenseServer").ToString()
                    frm.tbCoreSvr.Text = r("CoreServiceServerName").ToString()
                    frm.tbDbVer.Text = r("Version").ToString()
                    frm.tbWebEnabled.Text = r("EnableWeb").ToString()
                    frm.tbShiftDate.Text = r("ShiftDate").ToString()
                    PCInfo.DatabaseVersion = r("Version").ToString()

                Else
                    Throw New Exception("LicenseData returned no rows.")
                End If


            Catch ex As SafeDb.DatabaseOfflineException
                ' ---- HARD OFFLINE TRIGGER ----
                DatabaseCoordinator.GoOffline(frm, "Lost DB connection during LicenseData refresh")
                Exit Sub

            Catch ex As Exception
                ' Only a non-connectivity error
                frm.tbLocName.Text = "Database Error"
                frm.tbLicSvr.Text = "Database Error"
                frm.tbCoreSvr.Text = "Database Error"
                frm.tbDbVer.Text = "Database Error"
                frm.tbWebEnabled.Text = "Database Error"
                frm.tbShiftDate.Text = "Database Error"
            End Try
        End If


        ' ============================================================
        ' 2) Timers / UI updates
        ' ============================================================
        frm.tmr10Seconds.Start()

        frm.dtpMsgLogDateFrom.Enabled = frm.cbMsgLogDateRange.Checked
        frm.dtpMsgLogTimeFrom.Enabled = frm.cbMsgLogDateRange.Checked
        frm.dtpMsgLogDateTo.Enabled = frm.cbMsgLogDateRange.Checked
        frm.dtpMsgLogTimeTo.Enabled = frm.cbMsgLogDateRange.Checked

        Dim info = ServiceIntrospection.GetServiceFileInfo("AdvCoreService")

        ' ============================================================
        ' 3) DbStats (SafeDb)
        ' ============================================================

        Dim PcDbSize As String = ""
        Dim PcSqlVersion As String = ""

        Try
            Dim dsStats As DataSet = SafeDb.TryQuery(GeneralQueries.DbStats)

            If dsStats Is Nothing OrElse
           dsStats.Tables.Count = 0 OrElse
           dsStats.Tables(0).Rows.Count = 0 Then

                Throw New Exception("DbStats returned no rows.")
            End If

            Dim row0 = dsStats.Tables(0).Rows(0)
            PCInfo.DbSize = Convert.ToString(row0.Item(0))
            PCInfo.SqlVersion = Convert.ToString(row0.Item(1))
            PCInfo.ValidDatabase = True


        Catch ex As SafeDb.DatabaseOfflineException
            ' ---- HARD OFFLINE TRIGGER ----
            DatabaseCoordinator.GoOffline(frm, "Lost DB connection during DbStats refresh")
            Exit Sub

        Catch ex As Exception
            PCInfo.ValidDatabase = False
            PcDbSize = "Invalid Database"
            PcSqlVersion = "Invalid Database"
        End Try


        ' ============================================================
        ' 4) Reflect DB summary
        ' ============================================================
        If PCInfo.IsSQLInstalled Then

            ' Size display
            If Not String.IsNullOrWhiteSpace(PCInfo.DbSize) AndAlso
           IsNumericLike(PCInfo.DbSize) Then

                If PCInfo.DbSize.Length < 4 Then
                    PcDbSize = $"{PCInfo.DbSize} MB"
                Else
                    PcDbSize = $"{PCInfo.DbSize} GB"
                End If

            Else
                PcDbSize = PCInfo.DbSize
            End If


            ' Edition display
            Dim edition As String = ""
            If PCInfo.SqlVersion.IndexOf("Developer", StringComparison.OrdinalIgnoreCase) >= 0 Then edition = "Developer"
            If PCInfo.SqlVersion.IndexOf("Express", StringComparison.OrdinalIgnoreCase) >= 0 Then edition = "Express"
            If PCInfo.SqlVersion.IndexOf("Evaluation", StringComparison.OrdinalIgnoreCase) >= 0 Then edition = "Evaluation"
            If PCInfo.SqlVersion.IndexOf("Standard", StringComparison.OrdinalIgnoreCase) >= 0 Then edition = "Standard"

            If PCInfo.SqlVersion.Length > 0 AndAlso edition.Length > 0 Then
                Dim yearText As String = ExtractYearFromVersion(PCInfo.SqlVersion)
                PcSqlVersion = $"SQL Server {yearText} {edition} Edition"
            Else
                PcSqlVersion = PCInfo.SqlVersion
            End If
        End If
        frm.tbPcDbInfo.Text = String.Join("/", PcSqlVersion, PcDbSize)

        If frm._options IsNot Nothing Then
            Dim uiState = New UIStateController(frm, frm._options)
            uiState.Refresh()
        End If

    End Sub

    Private Function IsNumericLike(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return False
        Dim dummy As Double
        Return Double.TryParse(value, Globalization.NumberStyles.Any,
                               Globalization.CultureInfo.InvariantCulture, dummy)
    End Function

    Private Function ExtractYearFromVersion(versionText As String) As String
        If String.IsNullOrWhiteSpace(versionText) Then Return ""
        Dim idx As Integer = versionText.IndexOf("20", StringComparison.Ordinal)
        If idx >= 0 AndAlso versionText.Length >= idx + 4 Then
            Dim yearCandidate = versionText.Substring(idx, 4)
            If yearCandidate.All(AddressOf Char.IsDigit) Then Return yearCandidate
        End If
        Return versionText
    End Function

    Public Sub GetPcInfo()
        PCInfo.Name = Environment.MachineName
        PCInfo.OpSys = System.Runtime.InteropServices.RuntimeInformation.OSDescription

        Dim ramBytes = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes
        Dim Ram As Integer = CInt(ramBytes \ (1024 * 1024 * 1024))
        PCInfo.Ram = $"{Ram} GB"

        Dim drive = New DriveInfo("C:\")
        Dim freeSpace = drive.TotalFreeSpace \ (1024 * 1024 * 1024)
        Dim totalSpace = drive.TotalSize \ (1024 * 1024 * 1024)
        Dim pct = (freeSpace / totalSpace) * 100

        PCInfo.FreeSpace = $"{freeSpace} GB free of {totalSpace} GB ({pct:F2}% free)"
        PCInfo.Architecture = If(Environment.Is64BitOperatingSystem, "x64", "x86")
    End Sub

    Public Function CeInfo() As String

        Dim Path As String = ""
        AppData.InstalledVersion = AdvExeCheck("AdvManager")

        If AppData.InstalledVersion = AppInstallState.InstalledX86 Then
            Path = "C:\Program Files (x86)\CenterEdge Software\AdvCommon.dll"
        ElseIf AppData.InstalledVersion = AppInstallState.InstalledX64 Then
            Path = "C:\Program Files\CenterEdge Software\AdvCommon.dll"
        End If
        Try
            Dim vi = FileVersionInfo.GetVersionInfo(Path)
            Return $"{vi.FileMajorPart}.{vi.FileMinorPart}.{vi.FileBuildPart}"

        Catch
            PCInfo.IsAdvantageInstalled = False

            Return "Advantage Not Installed"
        End Try

    End Function

    Public Sub MsgLogBuilder(Optional errValue As String = "0",
                                    Optional limit As String = "100",
                                    Optional daterange As String = "")
        LogQueries.MessageLog =
            String.Format(MessageLogFilters.MessageLog, errValue, limit, daterange)

        LogQueries.MessageLogErrorCount =
            String.Format(MessageLogFilters.MessageLogErrorCount, limit, daterange)
    End Sub
    Public Function AdvExeCheck(Executable As String)

        Dim fileExistsx86 As Boolean =
        File.Exists($"{AppData.CEPath86}{Executable}.exe")

        Dim fileExistsx64 As Boolean =
        File.Exists($"{AppData.CEPath64}{Executable}.exe")

        If fileExistsx64 Then Return AppInstallState.InstalledX64
        If fileExistsx86 Then Return AppInstallState.InstalledX86
        Return AppInstallState.NotInstalled

    End Function


    ' ===========================================
    ' Flavor argument builder
    ' ===========================================
    Public Function BuildFlavorsArgument(
        flavorNames As IEnumerable(Of String)
    ) As String

        If flavorNames Is Nothing Then Return ""

        Dim list =
            flavorNames.
                Where(Function(f) Not String.IsNullOrWhiteSpace(f)).
                ToList()

        If list.Count = 0 Then
            Throw New InvalidOperationException("No flavors provided.")
        End If

        ' IMPORTANT:
        ' - Comma-separated
        ' - NO spaces
        ' - Parsed by PowerShell
        Dim flavorCsv As String = String.Join(",", list)

        Return $"-Flavors {flavorCsv}"
    End Function


    ' ===========================================
    ' Execution status helper (UI-safe)
    ' ===========================================
    Public Sub SetExecutionStatus(
        owner As Control,
        statusLabel As ToolStripLabel,
        text As String
    )

        If statusLabel Is Nothing Then Return

        ' Marshal to UI thread safely
        If owner IsNot Nothing AndAlso owner.InvokeRequired Then
            owner.Invoke(Sub()
                             SetExecutionStatus(owner, statusLabel, text)
                         End Sub)
            Return
        End If

        If String.IsNullOrWhiteSpace(text) Then
            statusLabel.Text = String.Empty
            statusLabel.Visible = False
        Else
            statusLabel.Text = text
            statusLabel.Visible = True
        End If

    End Sub

End Module