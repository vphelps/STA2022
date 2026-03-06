
Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms

Public Class CodeHelper

    Public Enum AppInstallState
        NotInstalled = 0
        InstalledX86 = 1
        InstalledX64 = 2
    End Enum

    Public Shared Sub FirstLoad()
        Dim strTemp As String = ""
        GetPcInfo()
        PCInfo.FrameworkVersion = DotNetInfo.Get45PlusFromRegistry
        PCInfo.AdvantageVersion = CodeHelper.CeInfo

        Startup.MainFormInstance.tbPcName.Text = PCInfo.Name
        Startup.MainFormInstance.tbPcOsInfo.Text = PCInfo.OpSys
        Startup.MainFormInstance.tbPcRam.Text = PCInfo.Ram
        Startup.MainFormInstance.tbPcHardDrive.Text = PCInfo.FreeSpace
        Startup.MainFormInstance.tbPcArch.Text = PCInfo.Architecture
        Startup.MainFormInstance.tbPcNetVersion.Text = PCInfo.FrameworkVersion
        Startup.MainFormInstance.tbPcAdvVersion.Text = PCInfo.AdvantageVersion

        Try
            Dim SQLStats As DataSet = DBConnector.dbQuery(GeneralQueries.DbStats)
            PCInfo.DbSize = SQLStats.Tables(0).Rows(0).Item(0)
            PCInfo.SqlVersion = SQLStats.Tables(0).Rows(0).Item(1)
        Catch ex As Exception
            PCInfo.ValidDatabase = False
            PCInfo.DbSize = "Invalid Database"
            PCInfo.SqlVersion = "Invalid Database"
        End Try

        If PCInfo.IsSQLInstalled Then
            If PCInfo.DbSize.Length < 4 Then Startup.MainFormInstance.tbPcDbSize.Text = String.Format("{0} MB", PCInfo.DbSize) Else Startup.MainFormInstance.tbPcDbSize.Text = String.Format("{0} GB", PCInfo.DbSize)
            If PCInfo.SqlVersion.Contains("Developer") Then strTemp = "Developer"
            If PCInfo.SqlVersion.Contains("Express") Then strTemp = "Express"
            If PCInfo.SqlVersion.Contains("Evaluation") Then strTemp = "Evaluation"
            If PCInfo.SqlVersion.Contains("Standard") Then strTemp = "Standard"
            If PCInfo.SqlVersion.Length > 0 And strTemp.Length > 0 Then Startup.MainFormInstance.tbPcSqlVersion.Text = String.Format("SQL Server {0} {1} Edition", PCInfo.SqlVersion.Substring(PCInfo.SqlVersion.IndexOf("20"), 4), strTemp)
        End If


    End Sub
    Public Shared Sub Refresher()
        Dim strTemp As String = ""
        ' Find the real running MainForm instance
        Dim frm As FormMain = TryCast(System.Windows.Forms.Application.OpenForms.Cast(Of Form)().
                                  FirstOrDefault(Function(f) TypeOf f Is FormMain), FormMain)
        If frm Is Nothing OrElse frm.IsDisposed Then Return

        If frm.InvokeRequired Then
            frm.BeginInvoke(CType(Sub() Refresher(), MethodInvoker))
            Return
        End If

        If PCInfo.ValidDatabase Then
            Try
                AppData.dbLicData = DBConnector.dbQuery(GeneralQueries.LicenseData)

                frm.tbLocName.Text = AppData.dbLicData.Tables(0).Rows(0)("LocName").ToString()
                frm.tbLicSvr.Text = AppData.dbLicData.Tables(0).Rows(0)("LicenseServer").ToString()
                frm.tbCoreSvr.Text = AppData.dbLicData.Tables(0).Rows(0)("CoreServiceServerName").ToString()
                frm.tbDbVer.Text = AppData.dbLicData.Tables(0).Rows(0)("Version").ToString()
                frm.tbWebEnabled.Text = AppData.dbLicData.Tables(0).Rows(0)("EnableWeb").ToString()
                frm.tbShiftDate.Text = AppData.dbLicData.Tables(0).Rows(0)("ShiftDate").ToString()
            Catch ex As Exception
                frm.tbLocName.Text = "Database Error"
                frm.tbLicSvr.Text = "Database Error"
                frm.tbCoreSvr.Text = "Database Error"
                frm.tbDbVer.Text = "Database Error"
                frm.tbWebEnabled.Text = "Database Error"
                frm.tbShiftDate.Text = "Database Error"
            End Try
        End If

        frm.tmr10Seconds.Start()
        frm.tslblNetVersion.Text = PCInfo.FrameworkVersion

        frm.dtpMsgLogDateFrom.Enabled = frm.cbMsgLogDateRange.Checked
        frm.dtpMsgLogTimeFrom.Enabled = frm.cbMsgLogDateRange.Checked
        frm.dtpMsgLogDateTo.Enabled = frm.cbMsgLogDateRange.Checked
        frm.dtpMsgLogTimeTo.Enabled = frm.cbMsgLogDateRange.Checked

        Dim info = ServiceIntrospection.GetServiceFileInfo("AdvCoreService") ' Advantage Core Service
        frm.tslblCeVersion.Text = "Version:  " + info.Version


        frm.tslblTime.Text = My.Computer.Clock.LocalTime.ToShortDateString() & " " &
                         My.Computer.Clock.LocalTime.ToShortTimeString()

        Dim list As New List(Of Boolean)
        For i = 0 To FormMain.ServiceControlList.Count - 1
            If FormMain.ServiceControlList(i).GroupBox.Enabled Then
                list.Add(Services.GetServiceStatus(FormMain.ServiceControlList(i)))
            End If
        Next

        frm.tbPcName.Text = PCInfo.Name
        frm.tbPcOsInfo.Text = PCInfo.OpSys
        frm.tbPcRam.Text = PCInfo.Ram
        frm.tbPcHardDrive.Text = PCInfo.FreeSpace
        frm.tbPcArch.Text = PCInfo.Architecture
        frm.tbPcNetVersion.Text = PCInfo.FrameworkVersion
        frm.tbPcAdvVersion.Text = PCInfo.AdvantageVersion

        Try
            Dim SQLStats As DataSet = DBConnector.dbQuery(GeneralQueries.DbStats)
            PCInfo.DbSize = SQLStats.Tables(0).Rows(0).Item(0)
            PCInfo.SqlVersion = SQLStats.Tables(0).Rows(0).Item(1)
        Catch ex As Exception
            PCInfo.ValidDatabase = False
            PCInfo.DbSize = "Invalid Database"
            PCInfo.SqlVersion = "Invalid Database"
        End Try

        If PCInfo.IsSQLInstalled Then
            If PCInfo.DbSize.Length < 4 Then frm.tbPcDbSize.Text = String.Format("{0} MB", PCInfo.DbSize) Else frm.tbPcDbSize.Text = String.Format("{0} GB", PCInfo.DbSize)
            If PCInfo.SqlVersion.Contains("Developer") Then strTemp = "Developer"
            If PCInfo.SqlVersion.Contains("Express") Then strTemp = "Express"
            If PCInfo.SqlVersion.Contains("Evaluation") Then strTemp = "Evaluation"
            If PCInfo.SqlVersion.Contains("Standard") Then strTemp = "Standard"
            If PCInfo.SqlVersion.Length > 0 And strTemp.Length > 0 Then frm.tbPcSqlVersion.Text = String.Format("SQL Server {0} {1} Edition", PCInfo.SqlVersion.Substring(PCInfo.SqlVersion.IndexOf("20"), 4), strTemp)
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