Imports System.ServiceProcess

Public Structure ServiceControlEntry

    Public TextBox As TextBox
    Public SSButton As Button
    Public RSButton As Button
    Public Service As String
    Public GroupBox As GroupBox
End Structure

Public Class Services
    Public Shared localServiceList As New ServiceControlEntry

    Public Shared Sub StopStart(ByRef list As ServiceControlEntry, caller As Button)
        Dim controller As New ServiceController(list.Service)
        Dim serviceControllerStatus = controller.Status
        Dim counter As Integer = 0

        Select Case serviceControllerStatus
            Case ServiceControllerStatus.Running
                controller.Stop()

            Case ServiceControllerStatus.Stopped
                controller.Start()

            Case Else

        End Select


    End Sub

    Public Shared Function GetServiceStatus(ByRef caller As ServiceControlEntry) 'ByRef buttonSS As Button, ByRef textbox As TextBox, ByRef buttonRS As Button)
        Dim service As New ServiceController(caller.Service)
        Dim serviceControllerStatus As String = ""
        Try
            serviceControllerStatus = service.Status.ToString

        Catch ex As Exception

        End Try

        caller.TextBox.Text = serviceControllerStatus
        If caller.TextBox.Text = "Running" Then
            caller.SSButton.Enabled = True
            caller.RSButton.Enabled = True
            caller.RSButton.Text = "Restart"
            caller.SSButton.Text = "Stop"
            'MainForm.tmr1Sec.Enabled = False
        ElseIf caller.TextBox.Text = "Stopped" Then
            caller.SSButton.Enabled = True
            caller.RSButton.Enabled = False
            caller.RSButton.Text = "Restart"
            caller.SSButton.Text = "Start"
            'MainForm.tmr1Sec.Enabled = False
        Else
            caller.SSButton.Enabled = False
            caller.RSButton.Enabled = False
            caller.RSButton.Text = "Restart"
            caller.SSButton.Text = "Working"

        End If
        Return Not (caller.SSButton.Enabled)

    End Function

    Public Shared Function ServicesExistCheck()
        Dim Temp As String = Nothing
        Dim controller As New ServiceController
        Dim localServiceList As New List(Of ServiceControlEntry)
        localServiceList = BuildServiceControlList()

        For index As Integer = 0 To localServiceList.Count - 1

            controller.ServiceName = localServiceList.Item(index).Service
            Try     'Check if Service is installed
                Temp = controller.Status.ToString
                If Not controller.StartType.Equals(ServiceStartMode.Automatic) Then localServiceList.Item(index).GroupBox.Text = localServiceList.Item(index).GroupBox.Text & " (" & controller.StartType.ToString & ")"


                localServiceList.Item(index).TextBox.Text = controller.Status.ToString
            Catch ex As Exception
                localServiceList.Item(index).TextBox.Text = "Not Installed"
                localServiceList.Item(index).GroupBox.Enabled = False
                localServiceList.Item(index).SSButton.Visible = False
                localServiceList.Item(index).RSButton.Visible = False
            End Try

        Next
        For index As Integer = localServiceList.Count - 1 To 0
            If localServiceList.Item(index).GroupBox.Enabled = False Then
                localServiceList.Item(index).GroupBox.Visible = False
                localServiceList.Item(index).TextBox.Text = "Not Installed"
                localServiceList.RemoveAt(index)
            End If
        Next
        Return localServiceList

    End Function

    Public Shared Function BuildServiceControlList()
        '"AdvApiServer", "AdvCoreService", "AdvantageCloudSyncService", "AdvCreditService", "AdvLicService", "AdvNotifyService", "AdvantageUpgradeService", "AdvSignageService"
        Dim item As New ServiceControlEntry
        Dim mylist As New List(Of ServiceControlEntry)

#Region "API Service"
        item.TextBox = FormMain.tbApiService
        item.SSButton = FormMain.btnApiServiceSS
        item.RSButton = FormMain.btnApiServiceRS
        item.Service = "AdvApiServer"
        item.GroupBox = FormMain.gpApiService
        mylist.Add(item)
#End Region
#Region "Core Service"
        item.TextBox = FormMain.tbCoreService
        item.SSButton = FormMain.btnCoreServiceSS
        item.RSButton = FormMain.btnCoreServiceRS
        item.Service = "AdvCoreService"
        item.GroupBox = FormMain.gpCoreService
        mylist.Add(item)
#End Region
#Region "Cloud Service"
        item.TextBox = FormMain.tbCloudService
        item.SSButton = FormMain.btnCloudServiceSS
        item.RSButton = FormMain.btnCloudServiceRS
        item.Service = "AdvantageCloudSyncService"
        item.GroupBox = FormMain.gpCloudService
        mylist.Add(item)
#End Region
#Region "Credit Service"
        item.TextBox = FormMain.tbAdvCreditService
        item.SSButton = FormMain.btnAdvCreditServiceSS
        item.RSButton = FormMain.btnAdvCreditServiceRS
        item.Service = "AdvCreditService"
        item.GroupBox = FormMain.gpAdvCreditService
        mylist.Add(item)
#End Region
#Region "License Service"
        item.TextBox = FormMain.tbAdvLicService
        item.SSButton = FormMain.btnAdvLicServiceSS
        item.RSButton = FormMain.btnAdvLicServiceRS
        item.Service = "AdvLicService"
        item.GroupBox = FormMain.gpAdvLicService
        mylist.Add(item)
#End Region
#Region "Signage Service"
        item.TextBox = FormMain.tbAdvSignageService
        item.SSButton = FormMain.btnAdvSignageServiceSS
        item.RSButton = FormMain.btnAdvSignageServiceRS
        item.Service = "AdvSignageService"
        item.GroupBox = FormMain.gpAdvSignageService
        mylist.Add(item)
#End Region
#Region "Turnstile Service"
        item.TextBox = FormMain.tbAdvTurnstileEngine
        item.SSButton = FormMain.btnAdvTurnstileEngineSS
        item.RSButton = FormMain.btnAdvTurnstileEngineRS
        item.Service = "AdvTurnstileEngine"
        item.GroupBox = FormMain.gpAdvTurnstileEngine
        mylist.Add(item)
#End Region
#Region "Notification Service"
        item.TextBox = FormMain.tbAdvNotifyService
        item.SSButton = FormMain.btnAdvNotifyServiceSS
        item.RSButton = FormMain.btnAdvNotifyServiceRS
        item.Service = "AdvNotifyService"
        item.GroupBox = FormMain.gpAdvNotifyService
        mylist.Add(item)
#End Region
#Region "Upgrade Service"
        item.TextBox = FormMain.tbAdvantageUpgradeService
        item.SSButton = FormMain.btnAdvantageUpgradeServiceSS
        item.RSButton = FormMain.btnAdvantageUpgradeServiceRS
        item.Service = "AdvantageUpgradeService"
        item.GroupBox = FormMain.gpAdvantageUpgradeService
        mylist.Add(item)
#End Region

        Return mylist
    End Function
    Public Shared Sub RestartService(ByRef list As ServiceControlEntry)
        Dim controller As New ServiceController(list.Service)
        Dim serviceControllerStatus = controller.Status
        Dim counter As Integer = 0


        'End If
        Select Case serviceControllerStatus
            Case ServiceControllerStatus.Running
                controller.Stop()

            Case ServiceControllerStatus.Stopped
                controller.Start()

            Case Else

        End Select


    End Sub
End Class
