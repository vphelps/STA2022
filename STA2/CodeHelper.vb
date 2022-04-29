
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
        If List.Contains(True) Then FormMain.tmr1Sec.Enabled = True Else FormMain.tmr1Sec.Enabled = False


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