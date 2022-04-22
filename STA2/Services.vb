Imports System.ServiceProcess

Public Class Services
    Public Shared AdvCoreService As New ServiceController("AdvCoreService")
    Public Shared AdvCloudService As New ServiceController("AdvantageCloudSyncService")

    Public Shared Sub StopStart(ServiceName As String)

        Dim controller As New ServiceController(ServiceName)
        Dim serviceControllerStatus = controller.Status

        Select Case serviceControllerStatus
            Case ServiceControllerStatus.Running
                controller.Stop()

            Case ServiceControllerStatus.Stopped
                controller.Start()

            Case Else

        End Select




    End Sub

    Public Shared Function GetServiceStatus(ByRef button As Button, ByRef textbox As TextBox)
        Dim controller As New ServiceController(button.Tag)
        Dim serviceControllerStatus As String = controller.Status.ToString

        button.Text = "Test"
        textbox.Text = serviceControllerStatus
        If textbox.Text = "Running" Then
            button.Enabled = True
            button.Text = "Stop"
        ElseIf textbox.Text = "Stopped" Then
            button.Enabled = True
            button.Text = "Start"
        Else
            button.Enabled = False
            button.Text = "Working"
        End If
        Return serviceControllerStatus

    End Function
End Class
