Imports System.Net
Imports System.Net.Sockets

Public Class NetworkData
    Public Shared Async Function ConnectAsync(host As String, port As Integer) As Task(Of Boolean)
        Dim client As New TcpClient
        Try
            Await client.ConnectAsync(host, port)
            Return client.Connected
        Catch ex As ArgumentOutOfRangeException
            ' Handle exception
            Return False
        Catch
            ' Handle exception
            Return False
        End Try
    End Function

End Class
Public Class NetworkDataHelper
    '    Public Shared Sub NetworkPortListGenerate()
    '        Startup.MainFormInstance.dgvPorts.Rows.Clear()
    '        'FormMain.dgvPorts.Rows.Add(80, "HTTP used for signage median", "")
    '        Startup.MainFormInstance.dgvPorts.Rows.Add(1433, "SQL Server (by default, can be changed for named instances)n", "")
    '        Startup.MainFormInstance.dgvPorts.Rows.Add(15050, "License Validation", "")
    '        Startup.MainFormInstance.dgvPorts.Rows.Add(15051, "License File Request", "")
    '        Startup.MainFormInstance.dgvPorts.Rows.Add(15054, "Fingerprint Service And Reporting", "")
    '        Startup.MainFormInstance.dgvPorts.Rows.Add(15055, "Signage Service And Qubica And Alvarado", "")
    '        Startup.MainFormInstance.dgvPorts.Rows.Add(15056, "External Sales Interface (Embed)", "")
    '        Startup.MainFormInstance.dgvPorts.Rows.Add(15059, "Advantage Api Service", "")
    '        Startup.MainFormInstance.dgvPorts.Rows.Add(15060, "Stage/Web 2.0", "")
    '        'FormMain.dgvPorts.Rows.Add(31419, "PCCharge Credit Cards", "")
    '        'FormMain.dgvPorts.Rows.Add(31420, "CenterEdge Credit Cards (if using Advantage Credit Cards service)", "")
    '        'FormMain.dgvPorts.Rows.Add(50510, "Standard listening And transmission port for Web 1.0 services", "")
    '        'FormMain.dgvPorts.Rows.Add(58008, "Embed Interface (if we're sharing the server with Embed)", "")
    '        'FormMain.dgvPorts.Rows.Add(9000, "NetEPay port", "")
    '        'FormMain.dgvPorts.Rows.Add(9100, "Mercury/Vantiv Gift Cards port", "")
    '    End Sub

    'Public Shared Function GetLocalIP() As String
    '        Dim IPList As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)

    '        For Each IPaddress In IPList.AddressList
    '            'Only return IPv4 routable IPs
    '            If (IPaddress.AddressFamily = Sockets.AddressFamily.InterNetwork) Then
    '                Return IPaddress.ToString
    '            End If
    '        Next
    '        Return ""
    '    End Function

    '    Public Shared Function GetIPv4Address() As String
    '        GetIPv4Address = String.Empty
    '        Dim strHostName As String = System.Net.Dns.GetHostName()
    '        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(ConfigValues.Server)
    '        Startup.MainFormInstance.tbMLTest1.Text = ""
    '        For Each ipheal As System.Net.IPAddress In iphe.AddressList
    '            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
    '                GetIPv4Address = ipheal.ToString()
    '                Startup.MainFormInstance.tbMLTest1.Text += GetIPv4Address + "|" + iphe.HostName + vbCrLf
    '            End If
    '        Next

    '    End Function

End Class