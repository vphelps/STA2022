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
        item.TextBox = MainForm.tbApiService
        item.SSButton = MainForm.btnApiServiceSS
        item.RSButton = MainForm.btnApiServiceRS
        item.Service = "AdvApiServer"
        item.GroupBox = MainForm.gpApiService
        mylist.Add(item)
#End Region
#Region "Core Service"
        item.TextBox = MainForm.tbCoreService
        item.SSButton = MainForm.btnCoreServiceSS
        item.RSButton = MainForm.btnCoreServiceRS
        item.Service = "AdvCoreService"
        item.GroupBox = MainForm.gpCoreService
        mylist.Add(item)
#End Region
#Region "Cloud Service"
        item.TextBox = MainForm.tbCloudService
        item.SSButton = MainForm.btnCloudServiceSS
        item.RSButton = MainForm.btnCloudServiceRS
        item.Service = "AdvantageCloudSyncService"
        item.GroupBox = MainForm.gpCloudService
        mylist.Add(item)
#End Region
#Region "Credit Service"
        item.TextBox = MainForm.tbAdvCreditService
        item.SSButton = MainForm.btnAdvCreditServiceSS
        item.RSButton = MainForm.btnAdvCreditServiceRS
        item.Service = "AdvCreditService"
        item.GroupBox = MainForm.gpAdvCreditService
        mylist.Add(item)
#End Region
#Region "License Service"
        item.TextBox = MainForm.tbAdvLicService
        item.SSButton = MainForm.btnAdvLicServiceSS
        item.RSButton = MainForm.btnAdvLicServiceRS
        item.Service = "AdvLicService"
        item.GroupBox = MainForm.gpAdvLicService
        mylist.Add(item)
#End Region
#Region "Signage Service"
        item.TextBox = MainForm.tbAdvSignageService
        item.SSButton = MainForm.btnAdvSignageServiceSS
        item.RSButton = MainForm.btnAdvSignageServiceRS
        item.Service = "AdvSignageService"
        item.GroupBox = MainForm.gpAdvSignageService
        mylist.Add(item)
#End Region
#Region "Turnstile Service"
        item.TextBox = MainForm.tbAdvTurnstileEngine
        item.SSButton = MainForm.btnAdvTurnstileEngineSS
        item.RSButton = MainForm.btnAdvTurnstileEngineRS
        item.Service = "AdvTurnstileEngine"
        item.GroupBox = MainForm.gpAdvTurnstileEngine
        mylist.Add(item)
#End Region
#Region "Notification Service"
        item.TextBox = MainForm.tbAdvNotifyService
        item.SSButton = MainForm.btnAdvNotifyServiceSS
        item.RSButton = MainForm.btnAdvNotifyServiceRS
        item.Service = "AdvNotifyService"
        item.GroupBox = MainForm.gpAdvNotifyService
        mylist.Add(item)
#End Region
#Region "Upgrade Service"
        item.TextBox = MainForm.tbAdvantageUpgradeService
        item.SSButton = MainForm.btnAdvantageUpgradeServiceSS
        item.RSButton = MainForm.btnAdvantageUpgradeServiceRS
        item.Service = "AdvantageUpgradeService"
        item.GroupBox = MainForm.gpAdvantageUpgradeService
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
