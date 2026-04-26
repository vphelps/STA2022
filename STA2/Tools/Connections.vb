
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

            ' Read INI
            ConfigValues.Server = Ini.ReadString("SQL2000", "DataSource")
            ConfigValues.Database = Ini.ReadString("SQL2000", "Catalog")
            _Password = Ini.ReadString("SQL2000", "Password")
            ConfigValues.UserID = Ini.ReadString("SQL2000", "UserID")
            ConfigValues.StationNo = Ini.ReadInteger("Info", "StationNo")
            ConfigValues.IntegratedSecurity = Ini.ReadInteger("SQL2000", "IntegratedSecurity")
            ConfigValues.PasswordEncryption = Ini.ReadInteger("SQL2000", "PasswordEncryption")

            ' Resolve password (encrypted or plain)
            If ConfigValues.PasswordEncryption = 1 Then
                ConfigValues.Password = Encoding.UTF8.GetString(
                    ProtectedData.Unprotect(
                        Convert.FromBase64String(_Password),
                        PasswordEntropy,
                        DataProtectionScope.LocalMachine))
            ElseIf ConfigValues.PasswordEncryption = 0 Then
                ConfigValues.Password = _Password
            Else
                ConfigValues.Password = String.Empty
            End If

            ' -------------------------
            ' Build SQL connection string
            ' -------------------------
            Dim csb As New SqlConnectionStringBuilder()

            ' Basic
            csb.DataSource = ConfigValues.Server
            csb.InitialCatalog = ConfigValues.Database

            ' Auth mode
            If Convert.ToInt32(ConfigValues.IntegratedSecurity) = 1 Then
                csb.IntegratedSecurity = True
                ' When using Integrated Security, do NOT include UserID/Password
                csb.Remove("User ID")
                csb.Remove("Password")
            Else
                csb.IntegratedSecurity = False
                csb.UserID = ConfigValues.UserID
                csb.Password = ConfigValues.Password
            End If

            ' Optional: common, sensible defaults (tune as needed)
            csb.ConnectTimeout = 15            ' seconds
            ' If your SQL Server requires encryption, set to True. Otherwise, keep False or read from INI.
            ' csb.Encrypt = True
            ' csb.TrustServerCertificate = True ' only if you must bypass CA validation

            ' Final connection string
            Dim sqlConnectionString As String = csb.ConnectionString

            ' Store for global use
            ConfigValues.ConnectionString = sqlConnectionString

            ' (Optional) Initialize ReliableSql with this connection string if you’re using it:
            ' ReliableSql.Initialize(sqlConnectionString)

        Catch ex As Exception
            ' You can surface a dialog or keep logging only, as you had before.
            'ErrorHandler.ErrorHandler("PFSConnect.ini Error: " & ex.Message, ex.StackTrace)
        End Try


    End Sub
End Class
