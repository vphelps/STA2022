Imports System.ServiceProcess

Public Class Services
    Public Shared Function Test()

        Dim controller As New ServiceController("AdvantageCloudSyncService")
        Dim serviceControllerStatus = controller.Status

        Select Case serviceControllerStatus
            Case ServiceControllerStatus.Running
                controller.Stop()

            Case ServiceControllerStatus.Stopped
                controller.Start()

            Case Else

        End Select



        Return serviceControllerStatus.ToString

    End Function

    Public Shared Function GetServiceStatus(ServiceName As String)
        Dim controller As New ServiceController(ServiceName)
        Dim serviceControllerStatus = controller.Status
        Return serviceControllerStatus.ToString


    End Function

End Class
