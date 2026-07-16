Imports System.ServiceProcess
Imports Microsoft.Data.SqlClient

Public Class AppData
    Public Shared dbAppOptions As New DataSet
    Public Shared dbWebOptions As New DataSet
    Public Shared dbApplicationInfo As New DataSet

    Public Shared dbLicData As New DataSet
    Public Shared CEPath86 As String = "C:\Program Files (x86)\CenterEdge Software\"
    Public Shared CEPath64 As String = "C:\Program Files\CenterEdge Software\"
    Public Shared UpgradePath As String = ""
    Public Shared InstalledVersion As Integer = 0

End Class
Public Class Variables
    Public Shared LoggedIn As Boolean = False
    Public Shared OfflineMode As Boolean = False
    Public Shared Property CurrentDatabaseEnvironment As DatabaseEnvironment

End Class
Public Enum DatabaseEnvironment

    Offline = 0
    Docker = 1
    LocalServer = 2
    RemoteServer = 3

End Enum
Public Structure PCInfo
    Public Shared Name As String = ""
    Public Shared OpSys As String = ""
    Public Shared Ram As String = ""
    Public Shared FreeSpace As String = ""
    Public Shared Architecture As String = ""
    Public Shared DbSize As String = "0"
    Public Shared SqlVersion As String = ""
    Public Shared FrameworkVersion As String = ""
    Public Shared AdvantageVersion As String = ""
    Public Shared IsSQLInstalled As Boolean = True
    Public Shared IsAdvantageInstalled As Boolean = True
    Public Shared AreServicesInstalled As Boolean = True
    Public Shared ValidDatabase As Boolean = True
    Public Shared ExcelInstalled As Boolean = False
    Public Shared DatabaseVersion As String = ""
End Structure

' ProgramEntry.vb
Public Class ProgramEntry
    Public Property Id As String = Guid.NewGuid().ToString("N")
    Public Property Name As String
    Public Property Path As String
    Public Property Arguments As String
    Public Property WorkingDirectory As String
    Public Property RunAsAdmin As Boolean
    Public Property IconPath As String
    Public Property Enabled As Boolean = True
    Public Property IncludeInBatch As Boolean = False

    Public Overrides Function ToString() As String
        Return $"{Name} ({Path})"
    End Function
End Class


Public Class ConfigValues

    Public Shared Server As String
    Public Shared Database As String
    Public Shared UserID As String
    Public Shared StationNo As Integer
    Public Shared IntegratedSecurity As Integer
    Public Shared PasswordEncryption As Integer
    Public Shared Password As String

    ' ❌ Do NOT directly use a raw string anymore
    Private Shared _connectionString As String

    ' ✅ Use this property everywhere instead
    Public Shared ReadOnly Property ConnectionString As String
        Get
            Dim csb As New SqlConnectionStringBuilder()

            ' Server / DB
            csb.DataSource = Server
            csb.InitialCatalog = Database

            ' Auth mode
            If IntegratedSecurity = 1 Then
                csb.IntegratedSecurity = True
            Else
                csb.UserID = UserID
                csb.Password = Password
            End If

            ' ✅ CRITICAL for .NET 8
            csb.Encrypt = False
            csb.TrustServerCertificate = True
            csb.ConnectTimeout = 5

            Return csb.ConnectionString
        End Get
    End Property
    '' ============================================================
    '' Derived connection strings (used for detection)
    '' ============================================================

    'Public Shared ReadOnly Property DockerConnectionString As String
    '    Get
    '        Dim csb As New SqlConnectionStringBuilder(ConnectionString)

    '        ' ✅ Force Docker endpoint (always port 1433)
    '        csb.DataSource = "127.0.0.1,1433"

    '        Return csb.ConnectionString
    '    End Get
    'End Property


    'Public Shared ReadOnly Property LocalSqlConnectionString As String
    '    Get
    '        Dim csb As New SqlConnectionStringBuilder(ConnectionString)

    '        ' ✅ Force local instance
    '        csb.DataSource = "localhost"

    '        Return csb.ConnectionString
    '    End Get
    'End Property
    Public Property CurrentDatabaseEnvironment As DatabaseEnvironment
End Class
