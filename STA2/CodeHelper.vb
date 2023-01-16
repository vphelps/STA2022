
Public Class CodeHelper
    Public Shared Sub FirstLoad()
        Dim strTemp As String = ""
        FormMain.dgvPFSConnect.Rows.Clear()
        FormMain.dgvPFSConnect.Rows.Add("Server Name", My.Settings.Server)
        FormMain.dgvPFSConnect.Rows.Add("Database Name", My.Settings.Database)
        FormMain.dgvPFSConnect.Rows.Add("User ID", My.Settings.UserID)
        FormMain.dgvPFSConnect.Rows.Add("Password", My.Settings.Password)
        FormMain.dgvPFSConnect.Rows.Add("Station Number", My.Settings.StationNo)

        GetPcInfo()
        PCInfo.FrameworkVersion = DotNetInfo.Get45PlusFromRegistry
        PCInfo.AdvantageVersion = CodeHelper.CeInfo
        FormMain.tbPcName.Text = PCInfo.Name
        FormMain.tbPcOsInfo.Text = PCInfo.OpSys
        FormMain.tbPcRam.Text = PCInfo.Ram
        FormMain.tbPcHardDrive.Text = PCInfo.FreeSpace
        FormMain.tbPcArch.Text = PCInfo.Architecture
        FormMain.tbPcNetVersion.Text = PCInfo.FrameworkVersion
        FormMain.tbPcAdvVersion.Text = PCInfo.AdvantageVersion

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
            If PCInfo.DbSize.Length < 4 Then FormMain.tbPcDbSize.Text = String.Format("{0} MB", PCInfo.DbSize) Else FormMain.tbPcDbSize.Text = String.Format("{0} GB", PCInfo.DbSize)
            If PCInfo.SqlVersion.Contains("Developer") Then strTemp = "Developer"
            If PCInfo.SqlVersion.Contains("Express") Then strTemp = "Express"
            If PCInfo.SqlVersion.Contains("Evaluation") Then strTemp = "Evaluation"
            If PCInfo.SqlVersion.Contains("Standard") Then strTemp = "Standard"
            If PCInfo.SqlVersion.Length > 0 And strTemp.Length > 0 Then FormMain.tbPcSqlVersion.Text = String.Format("SQL Server {0} {1} Edition", PCInfo.SqlVersion.Substring(PCInfo.SqlVersion.IndexOf("20"), 4), strTemp)
        End If



    End Sub
    Public Shared Sub Refresher()
        If PCInfo.ValidDatabase Then
            Try

                AppData.dbLicData = DBConnector.dbQuery(GeneralQueries.LicenseData)
                FormMain.tbLocName.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("LocName").ToString
                FormMain.tbLicSvr.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("LicenseServer").ToString
                FormMain.tbCoreSvr.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("CoreServiceServerName").ToString
                FormMain.tbDbVer.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("Version").ToString
                FormMain.tbWebEnabled.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("EnableWeb").ToString
                FormMain.tbShiftDate.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("ShiftDate").ToString
            Catch ex As Exception
                FormMain.tbLocName.Text = "Database Error"
                FormMain.tbLicSvr.Text = "Database Error"
                FormMain.tbCoreSvr.Text = "Database Error"
                FormMain.tbDbVer.Text = "Database Error"
                FormMain.tbWebEnabled.Text = "Database Error"
                FormMain.tbShiftDate.Text = "Database Error"

            End Try


        End If
        FormMain.tmr10Seconds.Start()
        FormMain.tslblNetVersion.Text = PCInfo.FrameworkVersion
        FormMain.dtpMsgLogDateFrom.Enabled = FormMain.cbMsgLogDateRange.Checked
        FormMain.dtpMsgLogTimeFrom.Enabled = FormMain.cbMsgLogDateRange.Checked

        FormMain.dtpMsgLogDateTo.Enabled = FormMain.cbMsgLogDateRange.Checked
        FormMain.dtpMsgLogTimeTo.Enabled = FormMain.cbMsgLogDateRange.Checked

        FormMain.tslblCeVersion.Text = PCInfo.AdvantageVersion
        FormMain.tslblTime.Text = My.Computer.Clock.LocalTime.ToShortDateString & " " & My.Computer.Clock.LocalTime.ToShortTimeString

        Dim list As New List(Of Boolean)

        For index = 0 To FormMain.ServiceControlList.Count - 1
            If FormMain.ServiceControlList.Item(index).GroupBox.Enabled Then
                'ServiceControlList.Item(index).TextBox.Text = Services.GetServiceStatus(ServiceControlList.Item(index))
                list.Add(Services.GetServiceStatus(FormMain.ServiceControlList.Item(index)))

            End If
        Next
        If list.Contains(True) Then FormMain.tmr1Sec.Enabled = True Else FormMain.tmr1Sec.Enabled = False

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
        Dim Path As String = "C:\Program Files (x86)\CenterEdge Software\AdvCommon.dll"
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
    Public Shared Sub AdminUser(Admin As Boolean)

        FormMain.flpServices.Enabled = Admin
        FormMain.dgvPFSConnect.Visible = Not (Admin)
        FormMain.tbServicesButtonsHelpMessage.Visible = Not (Admin)



    End Sub
End Class