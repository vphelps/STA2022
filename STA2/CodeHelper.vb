
Public Class CodeHelper
    Public Shared Sub Refresher()
        FormMain.dgvPFSConnect.Rows.Add("Server Name", My.Settings.Server)
        FormMain.dgvPFSConnect.Rows.Add("Database Name", My.Settings.Database)
        FormMain.dgvPFSConnect.Rows.Add("User ID", My.Settings.UserID)
        FormMain.dgvPFSConnect.Rows.Add("Password", My.Settings.Password)
        FormMain.dgvPFSConnect.Rows.Add("Station Number", My.Settings.StationNo)

        AppData.dbLicData = DBConnector.dbQuery(GeneralQueries.LicenseData)
        FormMain.tbLocName.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("LocName").ToString
        FormMain.tbLicSvr.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("LicenseServer").ToString
        FormMain.tbCoreSvr.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("CoreServiceServerName").ToString
        FormMain.tbDbVer.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("Version").ToString
        FormMain.tbWebEnabled.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("EnableWeb").ToString
        FormMain.tbShiftDate.Text = AppData.dbLicData.Tables.Item(0).Rows.Item(0).Item("ShiftDate").ToString
        FormMain.tmr10Seconds.Start()
        FormMain.tslblNetVersion.Text = DotNetInfo.Get45PlusFromRegistry
        FormMain.dtpMsgLogDateFrom.Enabled = FormMain.cbMsgLogDateRange.Checked
        FormMain.dtpMsgLogTimeFrom.Enabled = FormMain.cbMsgLogDateRange.Checked

        FormMain.dtpMsgLogDateTo.Enabled = FormMain.cbMsgLogDateRange.Checked
        FormMain.dtpMsgLogTimeTo.Enabled = FormMain.cbMsgLogDateRange.Checked

        FormMain.tslblCeVersion.Text = "Installed Software Version:  " + CodeHelper.CeInfo
        FormMain.tslblTime.Text = My.Computer.Clock.LocalTime.ToShortDateString & " " & My.Computer.Clock.LocalTime.ToShortTimeString
        FormMain.btnUnlockAdminAccount.Enabled = Variables.LoggedIn
        FormMain.dgvPFSConnect.Visible = Variables.LoggedIn
        Dim list As New List(Of Boolean)

        For index = 0 To FormMain.ServiceControlList.Count - 1
            If FormMain.ServiceControlList.Item(index).GroupBox.Enabled Then
                'ServiceControlList.Item(index).TextBox.Text = Services.GetServiceStatus(ServiceControlList.Item(index))
                list.Add(Services.GetServiceStatus(FormMain.ServiceControlList.Item(index)))

            End If
        Next
        If list.Contains(True) Then FormMain.tmr1Sec.Enabled = True Else FormMain.tmr1Sec.Enabled = False

        GetPcInfo()

        FormMain.tbPcName.Text = PCInfo.Name
        FormMain.tbPcOsInfo.Text = PCInfo.OpSys
        FormMain.tbPcRam.Text = PCInfo.Ram
        FormMain.tbPcHardDrive.Text = PCInfo.FreeSpace
        FormMain.tbPcArch.Text = PCInfo.Architecture

    End Sub

    Public Shared Sub GetPcInfo()
        PCInfo.Name = My.Computer.Name
        PCInfo.OpSys = My.Computer.Info.OSFullName

        Dim Ram As Integer = My.Computer.Info.TotalPhysicalMemory / 1024 / 1024 / 1024
        PCInfo.Ram = String.Format("{0} GB", Ram.ToString)

        Dim freeSpace As Long = My.Computer.FileSystem.GetDriveInfo("C:\").TotalFreeSpace
        PCInfo.FreeSpace = FormatNumber(freeSpace / 1024 / 1024 / 1024, 2, TriState.False, TriState.False, TriState.True).ToString()

        If Environment.Is64BitOperatingSystem Then PCInfo.Architecture = "x64" Else PCInfo.Architecture = "x86"
    End Sub
    Public Shared Function CeInfo() As String
        Dim Path As String = "C:\Program Files (x86)\CenterEdge Software\AdvCoreService.exe"
        Dim temp As String = FileVersionInfo.GetVersionInfo(Path).FileVersion.ToString


        Dim CeVersion As String = FileVersionInfo.GetVersionInfo(Path).FileMajorPart.ToString _
        + "." + FileVersionInfo.GetVersionInfo(Path).FileMinorPart.ToString _
        + "." + FileVersionInfo.GetVersionInfo(Path).FileBuildPart.ToString

        Return CeVersion
    End Function

    Public Shared Sub MsgLogBuilder(Optional errValue As String = "0", Optional limit As String = "100", Optional daterange As String = "")
        LogQueries.MessageLog = String.Format(MessageLogFilters.MessageLog, errValue, limit, daterange)
        LogQueries.MessageLogErrorCount = String.Format(MessageLogFilters.MessageLogErrorCount, limit, daterange)


    End Sub
End Class