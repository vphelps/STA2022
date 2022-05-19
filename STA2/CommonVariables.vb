Imports System.ServiceProcess

Public Class AppData
    Public Shared dbAppOptions As New DataSet
    Public Shared dbWebOptions As New DataSet
    Public Shared dbLicData As New DataSet

End Class
Public Class Variables
    Public Shared LoggedIn As Boolean = False


End Class

Public Structure PCInfo
    Public Shared Name As String
    Public Shared OpSys As String
    Public Shared Ram As String
    Public Shared FreeSpace As String
    Public Shared Architecture As String

End Structure