
Imports System.Windows.Forms

Public Class CodeHelper

    Public Enum AppInstallState
        NotInstalled = 0
        InstalledX86 = 1
        InstalledX64 = 2
    End Enum

    Public Shared Sub FirstLoad()
        Dim form = Startup.MainFormInstance
        Dim strTemp As String = ""
        If Variables.OfflineMode Then
            PCInfo.ValidDatabase = False
            ' Paint UI offline state
            form.tbPcDbSize.Text = "Offline"
            form.tbPcSqlVersion.Text = "Offline"
            Return
        End If

        ' Populate PC info
        GetPcInfo()
        PCInfo.FrameworkVersion = DotNetInfo.Get45PlusFromRegistry
        PCInfo.AdvantageVersion = CodeHelper.CeInfo

        ' --- Safely update UI (handle cross-thread) ---
        If Form IsNot Nothing AndAlso Form.IsHandleCreated Then
            If Form.InvokeRequired Then
                Form.Invoke(Sub() ApplyPcInfoToForm(Form))
            Else
                ApplyPcInfoToForm(Form)
            End If
        End If

        ' --- Query DB stats with ReliableSql (Retry/Cancel aware) ---
        Try
            Dim q As Object = ReliableSql.Query(GeneralQueries.DbStats)
            Dim ds As DataSet = TryCast(q, DataSet)

            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                Throw New Exception("DbStats returned no rows.")
            End If

            ' Expecting: [DbSize, SqlVersion] in the first row
            Dim row0 = ds.Tables(0).Rows(0)
            PCInfo.DbSize = Convert.ToString(row0.Item(0))
            PCInfo.SqlVersion = Convert.ToString(row0.Item(1))
            PCInfo.ValidDatabase = True

        Catch oce As OperationCanceledException
            ' User cancelled the Retry/Cancel prompt
            PCInfo.ValidDatabase = False
            PCInfo.DbSize = "Invalid Database"
            PCInfo.SqlVersion = "Invalid Database"

        Catch ex As Exception
            ' Non-transient error or empty result
            PCInfo.ValidDatabase = False
            PCInfo.DbSize = "Invalid Database"
            PCInfo.SqlVersion = "Invalid Database"
        End Try

        ' --- Reflect DB info to UI if SQL is installed ---
        If PCInfo.IsSQLInstalled Then
            If form IsNot Nothing AndAlso form.IsHandleCreated Then

                Dim updateUi =
        Sub()
            ' Size display
            If Not String.IsNullOrWhiteSpace(PCInfo.DbSize) AndAlso IsNumericLike(PCInfo.DbSize) Then
                If PCInfo.DbSize.Length < 4 Then
                    form.tbPcDbSize.Text = String.Format("{0} MB", PCInfo.DbSize)
                Else
                    form.tbPcDbSize.Text = String.Format("{0} GB", PCInfo.DbSize)
                End If
            Else
                form.tbPcDbSize.Text = PCInfo.DbSize
            End If

            Dim edition As String = ""
            If PCInfo.SqlVersion.IndexOf("Developer", StringComparison.OrdinalIgnoreCase) >= 0 Then edition = "Developer"
            If PCInfo.SqlVersion.IndexOf("Express", StringComparison.OrdinalIgnoreCase) >= 0 Then edition = "Express"
            If PCInfo.SqlVersion.IndexOf("Evaluation", StringComparison.OrdinalIgnoreCase) >= 0 Then edition = "Evaluation"
            If PCInfo.SqlVersion.IndexOf("Standard", StringComparison.OrdinalIgnoreCase) >= 0 Then edition = "Standard"

            If PCInfo.SqlVersion.Length > 0 AndAlso edition.Length > 0 Then
                Dim yearText As String = ExtractYearFromVersion(PCInfo.SqlVersion)
                form.tbPcSqlVersion.Text = $"SQL Server {yearText} {edition} Edition"
            Else
                form.tbPcSqlVersion.Text = PCInfo.SqlVersion
            End If
        End Sub

                If form.InvokeRequired Then
                    form.Invoke(updateUi)
                Else
                    updateUi()
                End If

            End If
        End If
    End Sub

    ' --- Helpers ---

    ' Apply basic PC info fields to the form
    Private Shared Sub ApplyPcInfoToForm(form As FormMain)
        form.tbPcName.Text = PCInfo.Name
        form.tbPcOsInfo.Text = PCInfo.OpSys
        form.tbPcRam.Text = PCInfo.Ram
        form.tbPcHardDrive.Text = PCInfo.FreeSpace
        form.tbPcArch.Text = PCInfo.Architecture
        form.tbPcNetVersion.Text = PCInfo.FrameworkVersion
        form.tbPcAdvVersion.Text = PCInfo.AdvantageVersion
    End Sub

    ' Basic numeric check (string can be parsed to a number)
    Private Shared Function IsNumericLike(value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return False
        Dim dummy As Double
        Return Double.TryParse(value, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, dummy) OrElse
           Double.TryParse(value, Globalization.NumberStyles.Any, Globalization.CultureInfo.CurrentCulture, dummy)
    End Function

    ' Extract a 4-digit year (20xx) from version text; fallback to raw version if none
    Private Shared Function ExtractYearFromVersion(versionText As String) As String
        If String.IsNullOrWhiteSpace(versionText) Then Return ""
        ' Try to find "20xx"
        Dim idx As Integer = versionText.IndexOf("20", StringComparison.Ordinal)
        If idx >= 0 AndAlso versionText.Length >= idx + 4 Then
            Dim yearCandidate = versionText.Substring(idx, 4)
            If yearCandidate.All(AddressOf Char.IsDigit) Then
                Return yearCandidate
            End If
        End If
        ' Fallback: first token or the whole string
        Return versionText
    End Function
    Public Shared Sub Refresher()
        If Variables.OfflineMode Then Exit Sub

        Dim strTemp As String = ""

        ' Find the real running MainForm instance
        Dim frm As FormMain = TryCast(Application.OpenForms.Cast(Of Form)().FirstOrDefault(Function(f) TypeOf f Is FormMain), FormMain)
        If frm Is Nothing OrElse frm.IsDisposed Then Return

        ' Ensure we're on the UI thread
        If frm.InvokeRequired Then
            frm.BeginInvoke(CType(Sub() Refresher(), MethodInvoker))
            Return
        End If

        ' ================================
        ' LicenseData block (ReliableSql)
        ' ================================
        If PCInfo.ValidDatabase Then
            Try
                Dim qLic As Object = ReliableSql.Query(GeneralQueries.LicenseData)
                Dim dsLic As DataSet = TryCast(qLic, DataSet)

                If dsLic IsNot Nothing AndAlso dsLic.Tables.Count > 0 AndAlso dsLic.Tables(0).Rows.Count > 0 Then
                    AppData.dbLicData = dsLic
                    Dim r = dsLic.Tables(0).Rows(0)
                    frm.tbLocName.Text = r("LocName").ToString()
                    frm.tbLicSvr.Text = r("LicenseServer").ToString()
                    frm.tbCoreSvr.Text = r("CoreServiceServerName").ToString()
                    frm.tbDbVer.Text = r("Version").ToString()
                    frm.tbWebEnabled.Text = r("EnableWeb").ToString()
                    frm.tbShiftDate.Text = r("ShiftDate").ToString()
                Else
                    Throw New Exception("LicenseData returned no rows.")
                End If

            Catch oce As OperationCanceledException
                ' User clicked Cancel on Retry/Cancel dialog — show friendly error state
                frm.tbLocName.Text = "Database Error"
                frm.tbLicSvr.Text = "Database Error"
                frm.tbCoreSvr.Text = "Database Error"
                frm.tbDbVer.Text = "Database Error"
                frm.tbWebEnabled.Text = "Database Error"
                frm.tbShiftDate.Text = "Database Error"

            Catch ex As Exception
                ' Non-transient/empty-result error
                frm.tbLocName.Text = "Database Error"
                frm.tbLicSvr.Text = "Database Error"
                frm.tbCoreSvr.Text = "Database Error"
                frm.tbDbVer.Text = "Database Error"
                frm.tbWebEnabled.Text = "Database Error"
                frm.tbShiftDate.Text = "Database Error"
            End Try
        End If

        ' ================================
        ' Timers / status labels / toggles
        ' ================================
        frm.tmr10Seconds.Start()
        frm.tslblNetVersion.Text = PCInfo.FrameworkVersion

        frm.dtpMsgLogDateFrom.Enabled = frm.cbMsgLogDateRange.Checked
        frm.dtpMsgLogTimeFrom.Enabled = frm.cbMsgLogDateRange.Checked
        frm.dtpMsgLogDateTo.Enabled = frm.cbMsgLogDateRange.Checked
        frm.dtpMsgLogTimeTo.Enabled = frm.cbMsgLogDateRange.Checked

        Dim info = ServiceIntrospection.GetServiceFileInfo("AdvCoreService") ' Advantage Core Service
        frm.tslblCeVersion.Text = "Version:  " & info.Version

        frm.tslblTime.Text = My.Computer.Clock.LocalTime.ToShortDateString() & " " &
                         My.Computer.Clock.LocalTime.ToShortTimeString()

        Dim list As New List(Of Boolean)
        For i = 0 To FormMain.ServiceControlList.Count - 1
            If FormMain.ServiceControlList(i).GroupBox.Enabled Then
                list.Add(Services.GetServiceStatus(FormMain.ServiceControlList(i)))
            End If
        Next

        ' ================================
        ' PC info to UI
        ' ================================
        frm.tbPcName.Text = PCInfo.Name
        frm.tbPcOsInfo.Text = PCInfo.OpSys
        frm.tbPcRam.Text = PCInfo.Ram
        frm.tbPcHardDrive.Text = PCInfo.FreeSpace
        frm.tbPcArch.Text = PCInfo.Architecture
        frm.tbPcNetVersion.Text = PCInfo.FrameworkVersion
        frm.tbPcAdvVersion.Text = PCInfo.AdvantageVersion

        ' ================================
        ' DbStats block (ReliableSql)
        ' ================================
        Try
            Dim qStats As Object = ReliableSql.Query(GeneralQueries.DbStats)
            Dim dsStats As DataSet = TryCast(qStats, DataSet)

            If dsStats Is Nothing OrElse dsStats.Tables.Count = 0 OrElse dsStats.Tables(0).Rows.Count = 0 Then
                Throw New Exception("DbStats returned no rows.")
            End If

            Dim row0 = dsStats.Tables(0).Rows(0)
            PCInfo.DbSize = Convert.ToString(row0.Item(0))
            PCInfo.SqlVersion = Convert.ToString(row0.Item(1))
            PCInfo.ValidDatabase = True

        Catch oce As OperationCanceledException
            PCInfo.ValidDatabase = False
            PCInfo.DbSize = "Invalid Database"
            PCInfo.SqlVersion = "Invalid Database"

        Catch ex As Exception
            PCInfo.ValidDatabase = False
            PCInfo.DbSize = "Invalid Database"
            PCInfo.SqlVersion = "Invalid Database"
        End Try

        ' ================================
        ' Reflect DB summary to UI
        ' ================================
        If PCInfo.IsSQLInstalled Then
            If Not String.IsNullOrWhiteSpace(PCInfo.DbSize) AndAlso IsNumericLike(PCInfo.DbSize) Then
                If PCInfo.DbSize.Length < 4 Then
                    frm.tbPcDbSize.Text = String.Format("{0} MB", PCInfo.DbSize)
                Else
                    frm.tbPcDbSize.Text = String.Format("{0} GB", PCInfo.DbSize)
                End If
            Else
                frm.tbPcDbSize.Text = PCInfo.DbSize
            End If

            strTemp = ""
            If Not String.IsNullOrWhiteSpace(PCInfo.SqlVersion) Then
                If PCInfo.SqlVersion.IndexOf("Developer", StringComparison.OrdinalIgnoreCase) >= 0 Then strTemp = "Developer"
                If PCInfo.SqlVersion.IndexOf("Express", StringComparison.OrdinalIgnoreCase) >= 0 Then strTemp = "Express"
                If PCInfo.SqlVersion.IndexOf("Evaluation", StringComparison.OrdinalIgnoreCase) >= 0 Then strTemp = "Evaluation"
                If PCInfo.SqlVersion.IndexOf("Standard", StringComparison.OrdinalIgnoreCase) >= 0 Then strTemp = "Standard"

                If PCInfo.SqlVersion.Length > 0 AndAlso strTemp.Length > 0 Then
                    Dim yearText As String = ExtractYearFromVersion(PCInfo.SqlVersion)
                    frm.tbPcSqlVersion.Text = String.Format("SQL Server {0} {1} Edition", yearText, strTemp)
                Else
                    frm.tbPcSqlVersion.Text = PCInfo.SqlVersion
                End If
            Else
                frm.tbPcSqlVersion.Text = "Invalid Database"
            End If
        End If
    End Sub
    Public Shared Sub GetPcInfo()
        PCInfo.Name = My.Computer.Name
        PCInfo.OpSys = My.Computer.Info.OSFullName

        Dim Ram As Integer = My.Computer.Info.TotalPhysicalMemory / 1024 / 1024 / 1024
        PCInfo.Ram = String.Format("{0} GB", Ram.ToString)

        Dim freeSpace As Long = My.Computer.FileSystem.GetDriveInfo("C:\").TotalFreeSpace / 1024 / 1024 / 1024
        Dim totalSpace As Long = My.Computer.FileSystem.GetDriveInfo("C:\").TotalSize / 1024 / 1024 / 1024
        Dim percentFree As Long = (freeSpace / totalSpace) * 100

        PCInfo.FreeSpace = freeSpace.ToString + " GB free of" + totalSpace.ToString + " GB (" + percentFree.ToString + " % free)"

        If Environment.Is64BitOperatingSystem Then PCInfo.Architecture = "x64" Else PCInfo.Architecture = "x86"
    End Sub
    Public Shared Function CeInfo() As String
        Dim Path As String = ""
        AdvExeCheck("AdvManager")

        If AppData.InstalledVersion = AppInstallState.InstalledX86 Then Path = "C:\Program Files (x86)\CenterEdge Software\AdvCommon.dll"
        If AppData.InstalledVersion = AppInstallState.InstalledX64 Then Path = "C:\Program Files\CenterEdge Software\AdvCommon.dll"

        Dim CeVersion As String = ""
        Try
            Dim temp As String = FileVersionInfo.GetVersionInfo(Path).FileVersion.ToString
            CeVersion = FileVersionInfo.GetVersionInfo(Path).FileMajorPart.ToString _
        + "." + FileVersionInfo.GetVersionInfo(Path).FileMinorPart.ToString _
        + "." + FileVersionInfo.GetVersionInfo(Path).FileBuildPart.ToString

        Catch ex As Exception
            CeVersion = "Advantage Not Installed"
            PCInfo.IsAdvantageInstalled = False
        End Try
        Return CeVersion
    End Function

    Public Shared Sub MsgLogBuilder(Optional errValue As String = "0", Optional limit As String = "100", Optional daterange As String = "")
        LogQueries.MessageLog = String.Format(MessageLogFilters.MessageLog, errValue, limit, daterange)
        LogQueries.MessageLogErrorCount = String.Format(MessageLogFilters.MessageLogErrorCount, limit, daterange)


    End Sub

    Public Shared Function AdvExeCheck(Executable As String)
        Dim fileExistsx86 As Boolean
        Dim fileExistsx64 As Boolean
        Dim Version As Integer = AppInstallState.NotInstalled

        fileExistsx86 = My.Computer.FileSystem.FileExists(String.Format("{0}{1}.exe", AppData.CEPath86, Executable))
        fileExistsx64 = My.Computer.FileSystem.FileExists(String.Format("{0}{1}.exe", AppData.CEPath64, Executable))
        If fileExistsx64 Then
            Version = AppInstallState.InstalledX64
        ElseIf fileExistsx86 Then
            Version = AppInstallState.InstalledX86

        End If
        AppData.InstalledVersion = Version

        Return Version

    End Function


End Class