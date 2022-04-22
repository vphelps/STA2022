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

    Public Shared Function GetServiceStatus(serviceName As String)
        Dim controller As New ServiceController(serviceName)
        Dim serviceControllerStatus As String = controller.Status.ToString
        Return controller

    End Function
End Class
