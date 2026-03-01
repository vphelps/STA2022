Imports System.ServiceProcess

Public Structure ServiceControlEntry

    Public TextBox As TextBox
    Public SSButton As Button
    Public RSButton As Button
    Public Service As String
    Public GroupBox As GroupBox
    Public Status As ServiceControllerStatus
End Structure

Public Class Services

    Public Shared Sub StopService(ByRef list As ServiceControlEntry)
        Dim controller As New ServiceController(list.Service)
        Dim serviceControllerStatus = controller.Status
        Dim Changing As Boolean = True

        controller.Stop()
        Do
            Changing = GetServiceStatus(list)
            FormMain.tbTest1.Text = serviceControllerStatus.ToString
        Loop Until list.Status = ServiceControllerStatus.Stopped And Changing = False


    End Sub


    Public Shared Sub StartService(ByRef list As ServiceControlEntry)
        Dim controller As New ServiceController(list.Service)
        Dim serviceControllerStatus = controller.Status
        Dim Changing As Boolean = True

        controller.Start()
        Do
            Changing = GetServiceStatus(list)
            serviceControllerStatus = controller.Status
            FormMain.tbTest1.Text = serviceControllerStatus.ToString
        Loop Until list.Status = ServiceControllerStatus.Running And Changing = False



    End Sub

    Public Shared Function GetServiceStatus(ByRef caller As ServiceControlEntry) 'ByRef buttonSS As Button, ByRef textbox As TextBox, ByRef buttonRS As Button)
        Try
            Dim service As New ServiceController(caller.Service)
            Dim serviceControllerStatus As String = ""
            serviceControllerStatus = service.Status.ToString
            caller.Status = service.Status

            caller.TextBox.Text = serviceControllerStatus
            If caller.TextBox.Text = "Running" Then
                caller.SSButton.Enabled = True
                caller.RSButton.Enabled = True
                caller.RSButton.Text = "Restart"
                caller.SSButton.Text = "Stop"
                caller.TextBox.ForeColor = TextboxColors.Black
                caller.TextBox.BackColor = TextboxColors.White
            ElseIf caller.TextBox.Text = "Stopped" Then
                caller.SSButton.Enabled = True
                caller.RSButton.Enabled = False
                caller.RSButton.Text = "Restart"
                caller.SSButton.Text = "Start"
                caller.TextBox.ForeColor = TextboxColors.White
                caller.TextBox.BackColor = TextboxColors.Red
            Else
                caller.SSButton.Enabled = False
                caller.RSButton.Enabled = False
                caller.RSButton.Text = "Restart"
                caller.SSButton.Text = "Working"
                caller.TextBox.ForeColor = TextboxColors.Black
                caller.TextBox.BackColor = TextboxColors.Yellow

            End If
        Catch ex As Exception
            PCInfo.AreServicesInstalled = False
            Return Not caller.SSButton.Enabled

            Exit Function
        End Try

        Return Not caller.SSButton.Enabled

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
            Else
                GetServiceStatus(localServiceList.Item(index))

            End If
        Next
        Return localServiceList

    End Function

    Public Shared Function BuildServiceControlList()
        '"AdvApiServer", "AdvCoreService", "AdvantageCloudSyncService", "AdvCreditService", "AdvLicService", "AdvNotifyService", "AdvantageUpgradeService", "AdvSignageService"
        Dim frm As FormMain = TryCast(System.Windows.Forms.Application.OpenForms.Cast(Of Form)().
                                  FirstOrDefault(Function(f) TypeOf f Is FormMain), FormMain)
        If frm Is Nothing OrElse frm.IsDisposed Then Return (Nothing)

        'If frm.InvokeRequired Then
        '    frm.BeginInvoke(CType(Sub() Refresher(), MethodInvoker))
        '    Return
        'End If

        Dim item As New ServiceControlEntry
        Dim mylist As New List(Of ServiceControlEntry)

#Region "API Service"
        item.TextBox = frm.tbApiService
        item.SSButton = frm.btnApiServiceSS
        item.RSButton = frm.btnApiServiceRS
        item.Service = "AdvApiServer"
        item.GroupBox = frm.gpApiService
        mylist.Add(item)
#End Region
#Region "Core Service"
        item.TextBox = frm.tbCoreService
        item.SSButton = frm.btnCoreServiceSS
        item.RSButton = frm.btnCoreServiceRS
        item.Service = "AdvCoreService"
        item.GroupBox = frm.gpCoreService
        mylist.Add(item)
#End Region
#Region "Cloud Service"
        item.TextBox = frm.tbCloudService
        item.SSButton = frm.btnCloudServiceSS
        item.RSButton = frm.btnCloudServiceRS
        item.Service = "AdvantageCloudSyncService"
        item.GroupBox = frm.gpCloudService
        mylist.Add(item)
#End Region
#Region "Credit Service"
        item.TextBox = frm.tbAdvCreditService
        item.SSButton = frm.btnAdvCreditServiceSS
        item.RSButton = frm.btnAdvCreditServiceRS
        item.Service = "AdvCreditService"
        item.GroupBox = frm.gpAdvCreditService
        mylist.Add(item)
#End Region
#Region "License Service"
        item.TextBox = frm.tbAdvLicService
        item.SSButton = frm.btnAdvLicServiceSS
        item.RSButton = frm.btnAdvLicServiceRS
        item.Service = "AdvLicService"
        item.GroupBox = frm.gpAdvLicService
        mylist.Add(item)
#End Region
#Region "Signage Service"
        item.TextBox = frm.tbAdvSignageService
        item.SSButton = frm.btnAdvSignageServiceSS
        item.RSButton = frm.btnAdvSignageServiceRS
        item.Service = "AdvSignageService"
        item.GroupBox = frm.gpAdvSignageService
        mylist.Add(item)
#End Region
#Region "Turnstile Service"
        item.TextBox = frm.tbAdvTurnstileEngine
        item.SSButton = frm.btnAdvTurnstileEngineSS
        item.RSButton = frm.btnAdvTurnstileEngineRS
        item.Service = "AdvTurnstileEngine"
        item.GroupBox = frm.gpAdvTurnstileEngine
        mylist.Add(item)
#End Region
#Region "Notification Service"
        item.TextBox = frm.tbAdvNotifyService
        item.SSButton = frm.btnAdvNotifyServiceSS
        item.RSButton = frm.btnAdvNotifyServiceRS
        item.Service = "AdvNotifyService"
        item.GroupBox = frm.gpAdvNotifyService
        mylist.Add(item)
#End Region
#Region "Upgrade Service"
        item.TextBox = frm.tbAdvantageUpgradeService
        item.SSButton = frm.btnAdvantageUpgradeServiceSS
        item.RSButton = frm.btnAdvantageUpgradeServiceRS
        item.Service = "AdvantageUpgradeService"
        item.GroupBox = frm.gpAdvantageUpgradeService
        mylist.Add(item)
#End Region

        Return mylist
    End Function
    Public Shared Sub RestartService(ByRef list As ServiceControlEntry)
        Dim controller As New ServiceController(list.Service)
        Dim serviceControllerStatus = controller.Status
        Dim counter As Integer = 0

        controller.Stop()

        controller.WaitForStatus(ServiceControllerStatus.Stopped)

        controller.Start()

    End Sub

End Class
