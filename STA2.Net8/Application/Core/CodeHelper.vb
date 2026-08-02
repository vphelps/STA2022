Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Windows.Forms
Imports System.Windows.Forms.Design.AxImporter
Imports STA2.Net8.ConfigValues
Imports System.ServiceProcess

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


    ' =======================================================================
    ' Unchanged helper functions
    ' =======================================================================

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
        LoadIpAddresses()
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
    Public Function ParseVersionSafe(text As String) As Version

        If String.IsNullOrWhiteSpace(text) Then
            Return Nothing
        End If

        Dim cleaned As String = text.Trim()

        ' ✅ Normalize common real-world junk formats
        ' Remove leading "v" (e.g. "v26.1")
        If cleaned.StartsWith("v", StringComparison.OrdinalIgnoreCase) Then
            cleaned = cleaned.Substring(1)
        End If

        ' Remove anything after a space (e.g. "26.1 (dev)")
        Dim spaceIndex = cleaned.IndexOf(" "c)
        If spaceIndex > 0 Then
            cleaned = cleaned.Substring(0, spaceIndex)
        End If

        ' ✅ Remove trailing dots like "26.1."
        cleaned = cleaned.TrimEnd("."c)

        ' ✅ Ensure at least Major.Minor format
        ' (Version class doesn't like just "26.")
        Dim dotCount = cleaned.Count(Function(c) c = "."c)

        If dotCount = 0 Then
            cleaned &= ".0"
        End If

        ' ✅ Safe parse
        Try
            Return New Version(cleaned)
        Catch
            Return Nothing
        End Try

    End Function
    Public Function VersionsMatch(v1 As Version, v2 As Version) As Boolean
        If v1 Is Nothing OrElse v2 Is Nothing Then Return False

        Return v1.Major = v2.Major AndAlso
               v1.Minor = v2.Minor AndAlso
               v1.Build = v2.Build
    End Function
    Public Function GetOptionValueFromGrid(
    grid As DataGridView,
    optionName As String
) As String

        If grid Is Nothing OrElse String.IsNullOrWhiteSpace(optionName) Then
            Return Nothing
        End If

        For Each row As DataGridViewRow In grid.Rows

            If row.IsNewRow Then Continue For

            Dim name = row.Cells("OptionName").Value?.ToString()

            If String.Equals(name, optionName, StringComparison.OrdinalIgnoreCase) Then
                Return row.Cells("OptionValue").Value?.ToString()
            End If

        Next

        Return Nothing

    End Function
    Public Function ResolveBackupPath() As String
        Dim Form = Startup.MainFormInstance
        ' ✅ 1. AppOptions override (PRIMARY)
        Dim optValue = Form._options?.BackupPathOverride?.Trim()

        If Not String.IsNullOrWhiteSpace(optValue) Then
            Return optValue
        End If

        ' ✅ 2. DataGridView fallback (database value)
        Dim dbValue = CodeHelper.GetOptionValueFromGrid(
            Form.dgvAppOptions,
            "BackupFolder"
        )?.Trim()

        If Not String.IsNullOrWhiteSpace(dbValue) Then
            Return dbValue
        End If

        ' ✅ Final fallback (optional)
        Return Nothing

    End Function
    Public Async Function KillQaScriptIfRunningAsync(fullCommand As String) As Task

        If String.IsNullOrWhiteSpace(fullCommand) Then
            Return
        End If

        Try
            ' ✅ Parse command
            Dim parsed = QaScriptHelper.ParseCommand(fullCommand)
            Dim scriptPath = parsed.ScriptPath

            ' ✅ Check if running
            If Not QaScriptHelper.IsScriptRunning(scriptPath) Then
                Return
            End If

            ' ✅ Kill script + PowerShell
            Await Task.Run(Sub()
                               QaScriptHelper.KillScriptProcesses(scriptPath)
                           End Sub)

        Catch
            ' ✅ Silent fail (important for installer scenarios)
        End Try

    End Function
    Public Sub AttachPromptDefaultsMenu(
        targetButton As Button,
        ownerForm As Form,
        configureDialog As Action(Of PromptDefaultsForm),
        onSave As Action(Of PromptDefaultsForm)
    )

        Dim cms As New ContextMenuStrip()
        Dim mi As New ToolStripMenuItem("Configure Prompt Defaults...")

        AddHandler mi.Click,
            Sub()

                Using dlg As New PromptDefaultsForm()

                    ' ✅ Let caller configure dialog
                    configureDialog(dlg)

                    ' ✅ Ensure dialog opens on same screen as parent
                    dlg.StartPosition = FormStartPosition.Manual

                    Dim screen As Screen = Screen.FromControl(ownerForm)
                    Dim working = screen.WorkingArea

                    Dim centerX = working.Left + (working.Width - dlg.Width) \ 2
                    Dim centerY = working.Top + (working.Height - dlg.Height) \ 2

                    dlg.Location = New Point(
                        Math.Max(working.Left, centerX),
                        Math.Max(working.Top, centerY)
                    )

                    ' ✅ Show dialog
                    If dlg.ShowDialog(ownerForm) = DialogResult.OK Then
                        onSave(dlg)
                    End If

                End Using

            End Sub

        cms.Items.Add(mi)

        targetButton.ContextMenuStrip = cms

    End Sub


    Public Sub LoadIpAddresses()

        PCInfo.IPv4Addresses.Clear()
        PCInfo.IPv6Addresses.Clear()

        For Each nic As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()

            If nic.OperationalStatus <> OperationalStatus.Up Then
                Continue For
            End If

            If nic.NetworkInterfaceType = NetworkInterfaceType.Loopback Then
                Continue For
            End If

            For Each ua In nic.GetIPProperties().UnicastAddresses

                Select Case ua.Address.AddressFamily

                    Case AddressFamily.InterNetwork

                        Dim ip = ua.Address.ToString()

                        If Not PCInfo.IPv4Addresses.Contains(ip) Then
                            PCInfo.IPv4Addresses.Add(ip)
                        End If

                    Case AddressFamily.InterNetworkV6

                        If Not ua.Address.IsIPv6LinkLocal Then

                            Dim ip = ua.Address.ToString()

                            If Not PCInfo.IPv6Addresses.Contains(ip) Then
                                PCInfo.IPv6Addresses.Add(ip)
                            End If

                        End If

                End Select

            Next

        Next
        PCInfo.IPv4Addresses.Sort()
        PCInfo.IPv6Addresses.Sort()
    End Sub
    Public Function CheckDatabaseServer() As DatabaseServerCheckResult

        Dim result As New DatabaseServerCheckResult()

        Dim serverValue As String = ConfigValues.Server

        If String.IsNullOrWhiteSpace(serverValue) Then
            Return result
        End If

        serverValue = serverValue.Trim()
        serverValue = serverValue.Split(","c)(0).Trim()
        serverValue = serverValue.Split("\"c)(0).Trim()

        result.ServerValue = serverValue

        result.MatchesIpv4 =
        PCInfo.IPv4Addresses.Any(
            Function(ip)
                Return String.Equals(
                    ip,
                    serverValue,
                    StringComparison.OrdinalIgnoreCase)
            End Function)

        result.MatchesIpv6 =
        PCInfo.IPv6Addresses.Any(
            Function(ip)
                Return String.Equals(
                    ip,
                    serverValue,
                    StringComparison.OrdinalIgnoreCase)
            End Function)

        result.MatchesMachineName =
        String.Equals(
            PCInfo.Name,
            serverValue,
            StringComparison.OrdinalIgnoreCase)

        result.MatchesLocalHost =
        String.Equals(
            serverValue,
            "localhost",
            StringComparison.OrdinalIgnoreCase) OrElse
        serverValue = "127.0.0.1" OrElse
        serverValue = "::1"

        result.IsDatabaseServer =
        result.MatchesIpv4 OrElse
        result.MatchesIpv6 OrElse
        result.MatchesMachineName OrElse
        result.MatchesLocalHost

        Return result

    End Function
    Public Async Function GetQaHostStatusAsync(
    qaCommandLine As String,
    hostingMode As QaHostingMode
) As Task(Of QaHostStatus)

        Dim status As New QaHostStatus()

        status.HostingMode = hostingMode
        status.ApiReady = Await FormHelper.IsQaApiReadyAsync()

        status.ScriptRunning = QaScriptHelper.IsQaApiRunning(qaCommandLine)
        Try
            Using sc As New ServiceController("AdvApiServer")
                status.ServiceInstalled = True
                status.ServiceRunning = sc.Status = ServiceControllerStatus.Running

            End Using

        Catch

            status.ServiceInstalled = False
            status.ServiceRunning = False

        End Try

        Return status

    End Function
    Public Function ShouldRunQaChecks(
    hostingMode As QaHostingMode,
    isDatabaseServer As Boolean,
    qaScriptStartWithApp As Boolean,
    qaStartServiceWithApp As Boolean
) As Boolean

        If Not isDatabaseServer Then
            Return False
        End If

        Select Case hostingMode

            Case QaHostingMode.None

                Return False

            Case QaHostingMode.Script

                Return qaScriptStartWithApp

            Case QaHostingMode.Service

                Return qaStartServiceWithApp

            Case Else

                Return False

        End Select

    End Function
    Public Async Function RefreshQaHostStatusAsync(
    status As QaHostStatus,
    qaCommandLine As String
) As Task
        status.ApiReady = Await FormHelper.IsQaApiReadyAsync()

        status.ScriptRunning = QaScriptHelper.IsQaApiRunning(qaCommandLine)

        Try

            Using sc As New ServiceController("AdvApiServer")

                status.ServiceInstalled = True

                status.ServiceRunning =
                    sc.Status = ServiceControllerStatus.Running

            End Using

        Catch

            status.ServiceInstalled = False
            status.ServiceRunning = False

        End Try

    End Function
End Module