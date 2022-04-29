
Public Class CodeHelper
    Public Shared Sub Refresher()
        FormMain.dgvPFSConnect.Rows.Add("Server Name", My.Settings.Server)
        FormMain.dgvPFSConnect.Rows.Add("Database Name", My.Settings.Database)
        FormMain.dgvPFSConnect.Rows.Add("User ID", My.Settings.UserID)
        FormMain.dgvPFSConnect.Rows.Add("Password", My.Settings.Password)
        FormMain.dgvPFSConnect.Rows.Add("Station Number", My.Settings.StationNo)

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