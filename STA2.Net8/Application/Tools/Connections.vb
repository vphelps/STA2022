
Imports Microsoft.Data.SqlClient
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
    Public Shared ErrorMessage As String
    Public Shared DBError As Boolean = False
    Public Shared Property _Password As String
    Public Shared Sub IniFileHandler(Write As Boolean)

        Try
            Dim Ini As New IniFile("C:\PFSCommon\PFSConnect.ini")

            ' -------------------------
            ' ✅ Read INI values ONLY
            ' -------------------------
            ConfigValues.Server = Ini.ReadString("SQL2000", "DataSource")
            ConfigValues.Database = Ini.ReadString("SQL2000", "Catalog")
            Dim rawPassword As String = Ini.ReadString("SQL2000", "Password")

            ConfigValues.UserID = Ini.ReadString("SQL2000", "UserID")
            ConfigValues.StationNo = Ini.ReadInteger("Info", "StationNo")
            ConfigValues.IntegratedSecurity = Ini.ReadInteger("SQL2000", "IntegratedSecurity")
            ConfigValues.PasswordEncryption = Ini.ReadInteger("SQL2000", "PasswordEncryption")

            ' -------------------------
            ' ✅ Resolve password
            ' -------------------------
            If ConfigValues.PasswordEncryption = 1 Then
                ConfigValues.Password = Encoding.UTF8.GetString(
                ProtectedData.Unprotect(
                    Convert.FromBase64String(rawPassword),
                    PasswordEntropy,
                    DataProtectionScope.LocalMachine))
            ElseIf ConfigValues.PasswordEncryption = 0 Then
                ConfigValues.Password = rawPassword
            Else
                ConfigValues.Password = String.Empty
            End If

            ' ✅ DO NOT build or assign ConnectionString here anymore

        Catch ex As Exception
            MessageBox.Show("PFSConnect.ini Error: " & ex.Message)
        End Try

    End Sub
End Class
