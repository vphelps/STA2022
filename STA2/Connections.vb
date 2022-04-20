
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Connections

    Private Shared ReadOnly PasswordEntropy As Byte() = New Byte() {
        &H40, &H89, &H2, &H90, &H16, &H60, &H5A, &H60, &H7E, &H34, &HA4, &H3E, &H61, &H2B, &H35, &H2B, &H36, &HDA, &HAC, &HC3, &H92, &HFF, &H7, &HDF
    }
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    Dim Server As String
    Dim Database As String
    Dim UserID As String
    Dim Password As String
    Dim StationNo As Integer
    Dim OldSettings As New My.MySettings
    Public Shared ErrorMessage As String
    Public Shared DBError As Boolean = False
    Public Shared Property _Password As String

    Public Shared Sub IniFileHandler(Write As Boolean)

        Try
            Dim Ini As New IniFile("C:\PFSCommon\PFSConnect.ini")

            My.Settings.Server = Ini.ReadString("SQL2000", "DataSource")
            My.Settings.Database = Ini.ReadString("SQL2000", "Catalog")
            _Password = Ini.ReadString("SQL2000", "Password")
            My.Settings.UserID = Ini.ReadString("SQL2000", "UserID")
            My.Settings.StationNo = Ini.ReadInteger("Info", "StationNo")
            My.Settings.IntegratedSecurity = Ini.ReadInteger("SQL2000", "IntegratedSecurity")
            My.Settings.PasswordEncryption = Ini.ReadInteger("SQL2000", "PasswordEncryption")

            If My.Settings.PasswordEncryption = 1 Then
                My.Settings.Password = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(_Password), PasswordEntropy, DataProtectionScope.LocalMachine))
            ElseIf My.Settings.PasswordEncryption = 0 Then
                My.Settings.Password = _Password
            End If

        Catch ex As Exception
            'Dim FormError As New FormError
            'FormError.Title = "PFSConnect.ini Error"
            'FormError.Message = "PFSConnect.ini file was not found in C:\PFSCommon"
            'FormError.StackTrace = ex.StackTrace
            'FormError.Settings = "Server = " + My.Settings.Server + vbCrLf
            'FormError.Settings = FormError.Settings + "Database = " + My.Settings.Database + vbCrLf
            'FormError.Settings = FormError.Settings + "UserID = " + My.Settings.UserID + vbCrLf
            'FormError.Settings = FormError.Settings + "StationNo = " + My.Settings.StationNo.ToString + vbCrLf
            'FormError.Settings = FormError.Settings + "IntegratedSecurity = " + My.Settings.IntegratedSecurity.ToString + vbCrLf
            'FormError.Settings = FormError.Settings + "Password = " + My.Settings.Password + vbCrLf
            'FormError.Settings = FormError.Settings + "PasswordEncryption = " + My.Settings.PasswordEncryption.ToString + vbCrLf
            'If FormError.ShowDialog() = DialogResult.Cancel Then
            '    End

            'End If


        End Try
    End Sub
End Class
