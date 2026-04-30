Imports System.ServiceProcess
Imports System.Drawing
Imports System.Security.Principal
Imports System.Linq
Imports System.Threading.Tasks

' ServiceControlEntry is a Class (reference type).
Public Class ServiceControlEntry
    Public Property TextBox As System.Windows.Forms.TextBox
    Public Property SSButton As System.Windows.Forms.Button
    Public Property RSButton As System.Windows.Forms.Button
    Public Property Service As String
    Public Property GroupBox As System.Windows.Forms.GroupBox
    Public Property Status As System.ServiceProcess.ServiceControllerStatus
    Public Property Installed As Boolean = True
    Public Property DisplayName As String

End Class

Public Class Services

    ' ---------------------------
    ' Events for UI progress
    ' ---------------------------
    Public Shared Event ServiceOperationStarted(ByVal entry As ServiceControlEntry, ByVal operation As String)
    Public Shared Event ServiceOperationCompleted(ByVal entry As ServiceControlEntry, ByVal operation As String, ByVal success As Boolean)

    ' ---------------------------
    ' Start/Stop/Restart helpers (synchronous retained for compatibility)
    ' ---------------------------

    Public Shared Sub StopService(ByRef entry As ServiceControlEntry)
        If entry Is Nothing OrElse String.IsNullOrWhiteSpace(entry.Service) Then Return

        Using controller As New ServiceController(entry.Service)
            Try
                controller.Stop()
                controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30))
            Catch
                ' ignore; UI will reflect state via GetServiceStatus
            End Try
        End Using

        GetServiceStatus(entry)
    End Sub

    Public Shared Sub StartService(ByRef entry As ServiceControlEntry)
        If entry Is Nothing OrElse String.IsNullOrWhiteSpace(entry.Service) Then Return

        Using controller As New ServiceController(entry.Service)
            Try
                controller.Start()
                controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30))
            Catch
                ' ignore; UI will reflect state via GetServiceStatus
            End Try
        End Using

        GetServiceStatus(entry)
    End Sub

    Public Shared Sub RestartService(ByRef entry As ServiceControlEntry)
        If entry Is Nothing OrElse String.IsNullOrWhiteSpace(entry.Service) Then Return

        Using controller As New ServiceController(entry.Service)
            Try
                controller.Stop()
                controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30))
                controller.Start()
                controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30))
            Catch
                ' ignore; UI will reflect state via GetServiceStatus
            End Try
        End Using

        GetServiceStatus(entry)
    End Sub

    ' ---------------------------
    ' Async APIs: allow UI to call without blocking
    ' ---------------------------

    Public Shared Async Function StopServiceAsync(ByVal entry As ServiceControlEntry, Optional ByVal timeoutSeconds As Integer = 30) As Task(Of Boolean)
        If entry Is Nothing OrElse String.IsNullOrWhiteSpace(entry.Service) Then Return False

        RaiseEvent ServiceOperationStarted(entry, "Stop")

        Dim result As Boolean = Await Task.Run(Function()
                                                   Try
                                                       Using controller As New ServiceController(entry.Service)
                                                           controller.Stop()
                                                           controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(timeoutSeconds))
                                                       End Using
                                                       Return True
                                                   Catch
                                                       Return False
                                                   End Try
                                               End Function).ConfigureAwait(False)

        Try
            GetServiceStatus(entry)
        Catch
        End Try

        RaiseEvent ServiceOperationCompleted(entry, "Stop", result)
        Return result
    End Function

    Public Shared Async Function StartServiceAsync(ByVal entry As ServiceControlEntry, Optional ByVal timeoutSeconds As Integer = 30) As Task(Of Boolean)
        If entry Is Nothing OrElse String.IsNullOrWhiteSpace(entry.Service) Then Return False

        RaiseEvent ServiceOperationStarted(entry, "Start")

        Dim result As Boolean = Await Task.Run(Function()
                                                   Try
                                                       Using controller As New ServiceController(entry.Service)
                                                           controller.Start()
                                                           controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(timeoutSeconds))
                                                       End Using
                                                       Return True
                                                   Catch
                                                       Return False
                                                   End Try
                                               End Function).ConfigureAwait(False)

        Try
            GetServiceStatus(entry)
        Catch
        End Try

        RaiseEvent ServiceOperationCompleted(entry, "Start", result)
        Return result
    End Function

    Public Shared Async Function RestartServiceAsync(ByVal entry As ServiceControlEntry, Optional ByVal timeoutSeconds As Integer = 30) As Task(Of Boolean)
        If entry Is Nothing OrElse String.IsNullOrWhiteSpace(entry.Service) Then Return False

        RaiseEvent ServiceOperationStarted(entry, "Restart")

        Dim result As Boolean = Await Task.Run(Function()
                                                   Try
                                                       Using controller As New ServiceController(entry.Service)
                                                           Try
                                                               controller.Stop()
                                                               controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(timeoutSeconds))
                                                           Catch
                                                               ' ignore stop failure/timeouts
                                                           End Try

                                                           Try
                                                               controller.Start()
                                                               controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(timeoutSeconds))
                                                           Catch
                                                               ' ignore
                                                           End Try
                                                       End Using
                                                       Return True
                                                   Catch
                                                       Return False
                                                   End Try
                                               End Function).ConfigureAwait(False)

        Try
            GetServiceStatus(entry)
        Catch
        End Try

        RaiseEvent ServiceOperationCompleted(entry, "Restart", result)
        Return result
    End Function

    ' ---------------------------
    ' Discovery / UI population
    ' ---------------------------

    Public Shared Function ServicesExistCheck() As List(Of ServiceControlEntry)
        Dim localServiceList As List(Of ServiceControlEntry)

        ' Build list of UI entries wired to the form's controls
        Try
            localServiceList = BuildServiceControlList()
        Catch
            Return New List(Of ServiceControlEntry)()
        End Try

        If localServiceList Is Nothing OrElse localServiceList.Count = 0 Then
            Return New List(Of ServiceControlEntry)()
        End If

        ' Pre-enumerate installed service names (best-effort)
        Dim installedNames As HashSet(Of String)
        Try
            installedNames = ServiceController.GetServices().
                             Select(Function(s) s.ServiceName).
                             ToHashSet(StringComparer.OrdinalIgnoreCase)
        Catch
            installedNames = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        End Try

        ' Probe each listed service safely (DO NOT hide any controls on failure)
        For Each entry In localServiceList
            If entry Is Nothing Then Continue For

            Dim svcName As String = entry.Service
            If String.IsNullOrWhiteSpace(svcName) Then
                MarkNotInstalled(entry)
                Continue For
            End If

            ' If we could enumerate and the service isn't present → "Not Installed"
            If installedNames.Count > 0 AndAlso Not installedNames.Contains(svcName) Then
                MarkNotInstalled(entry)
                Continue For
            End If

            ' Try querying the service
            Try
                Using controller As New ServiceController(svcName)
                    Dim status As ServiceControllerStatus = controller.Status
                    entry.Status = status
                    SafeSetText(entry.TextBox, status.ToString())

                    entry.DisplayName = controller.DisplayName
                    ' Reflect StartType to GroupBox text (optional, guarded)
                    Try
                        Dim startType As ServiceStartMode = controller.StartType
                        If entry.GroupBox IsNot Nothing AndAlso startType <> ServiceStartMode.Automatic Then
                            entry.GroupBox.Text = entry.DisplayName

                            entry.GroupBox.Text = $"{entry.GroupBox.Text} ({startType})"
                        End If
                    Catch
                        ' ignore StartType failures
                    End Try
                End Using
            Catch
                ' Access denied/missing/etc. → "Not Installed" behavior (but visible!)
                MarkNotInstalled(entry)
            End Try
        Next

        ' Reflect live button states and colors for each entry
        For Each entry In localServiceList
            Try
                GetServiceStatus(entry)
            Catch
                ' keep UI resilient
            End Try
        Next

        ' If not admin, disable all service interaction but keep everything visible
        If Not IsRunningAsAdmin() Then
            For Each entry In localServiceList
                If entry.GroupBox IsNot Nothing Then entry.GroupBox.Enabled = False
                If entry.SSButton IsNot Nothing Then entry.SSButton.Enabled = False
                If entry.RSButton IsNot Nothing Then entry.RSButton.Enabled = False
                ' leave textbox text as provided (status or "Not Installed")
            Next
        End If

        Return localServiceList
    End Function

    ' ---------------------------
    ' UI state helpers
    ' ---------------------------

    ' Ensures "Not Installed" is shown, but NEVER hides controls
    ' CHANGE: Now uses default TextBox colors for Not Installed.
    Private Shared Sub MarkNotInstalled(entry As ServiceControlEntry)
        If entry Is Nothing Then Return
        entry.Installed = False

        ' TextBox -> "Not Installed", disabled, DEFAULT system colors
        If entry.TextBox IsNot Nothing Then
            entry.TextBox.Text = "Not Installed"
            entry.TextBox.Enabled = False
            entry.TextBox.ForeColor = SystemColors.WindowText
            entry.TextBox.BackColor = SystemColors.Window
        End If

        ' GroupBox stays visible but disabled
        If entry.GroupBox IsNot Nothing Then
            entry.GroupBox.Enabled = False
            entry.GroupBox.Visible = True
        End If

        ' Buttons: visible but disabled
        If entry.SSButton IsNot Nothing Then
            entry.SSButton.Enabled = False
            entry.SSButton.Visible = True
            entry.SSButton.Text = "Start"
        End If
        If entry.RSButton IsNot Nothing Then
            entry.RSButton.Enabled = False
            entry.RSButton.Visible = True
            entry.RSButton.Text = "Restart"
        End If

        ' Track status (optional)
        entry.Status = ServiceControllerStatus.Stopped
    End Sub

    Private Shared Sub SafeSetText(tb As System.Windows.Forms.TextBox, value As String)
        If tb Is Nothing Then Return
        ' If this is called from a worker thread in the future, add InvokeRequired/Invoke here.
        tb.Text = value
    End Sub

    Private Shared Sub SetTextboxColors(entry As ServiceControlEntry, fore As Color, back As Color)
        If entry Is Nothing OrElse entry.TextBox Is Nothing Then Return
        entry.TextBox.ForeColor = fore
        entry.TextBox.BackColor = back
    End Sub

    Private Shared Sub EnableForRunning(entry As ServiceControlEntry)
        If entry Is Nothing Then Return

        ' Running → standard colors
        SetTextboxColors(entry, Color.Black, Color.White)

        If entry.SSButton IsNot Nothing Then
            entry.SSButton.Enabled = True
            entry.SSButton.Visible = True
            entry.SSButton.Text = "Stop"
        End If
        If entry.RSButton IsNot Nothing Then
            entry.RSButton.Enabled = True
            entry.RSButton.Visible = True
            entry.RSButton.Text = "Restart"
        End If

        If entry.GroupBox IsNot Nothing Then
            entry.GroupBox.Visible = True
            entry.GroupBox.Enabled = True
        End If

        If entry.TextBox IsNot Nothing Then entry.TextBox.Enabled = True
    End Sub

    Private Shared Sub EnableForStopped(entry As ServiceControlEntry)
        If entry Is Nothing Then Return

        ' Stopped → white text on red background
        SetTextboxColors(entry, Color.White, Color.Red)

        If entry.SSButton IsNot Nothing Then
            entry.SSButton.Enabled = True
            entry.SSButton.Visible = True
            entry.SSButton.Text = "Start"
        End If
        If entry.RSButton IsNot Nothing Then
            entry.RSButton.Enabled = False
            entry.RSButton.Visible = True
            entry.RSButton.Text = "Restart"
        End If

        If entry.GroupBox IsNot Nothing Then
            entry.GroupBox.Visible = True
            entry.GroupBox.Enabled = True
        End If

        If entry.TextBox IsNot Nothing Then entry.TextBox.Enabled = True
    End Sub

    ' CHANGE: Only StartPending/StopPending get Yellow background.
    Private Shared Sub EnableForSpecificPending(entry As ServiceControlEntry, pendingStatus As ServiceControllerStatus)
        If entry Is Nothing Then Return

        ' Yellow background for StartPending and StopPending (black text)
        SetTextboxColors(entry, Color.Black, Color.Yellow)

        If entry.SSButton IsNot Nothing Then
            entry.SSButton.Enabled = False
            entry.SSButton.Visible = True
            entry.SSButton.Text = "Working"
        End If
        If entry.RSButton IsNot Nothing Then
            entry.RSButton.Enabled = False
            entry.RSButton.Visible = True
            entry.RSButton.Text = "Restart"
        End If

        If entry.GroupBox IsNot Nothing Then
            entry.GroupBox.Visible = True
            entry.GroupBox.Enabled = True
        End If

        If entry.TextBox IsNot Nothing Then entry.TextBox.Enabled = True
    End Sub

    ' For other pending/paused states (not StartPending/StopPending), use standard colors.
    Private Shared Sub EnableForOtherPending(entry As ServiceControlEntry)
        If entry Is Nothing Then Return

        ' Default back to standard text on white background
        SetTextboxColors(entry, Color.Black, Color.White)

        If entry.SSButton IsNot Nothing Then
            entry.SSButton.Enabled = False
            entry.SSButton.Visible = True
            entry.SSButton.Text = "Working"
        End If
        If entry.RSButton IsNot Nothing Then
            entry.RSButton.Enabled = False
            entry.RSButton.Visible = True
            entry.RSButton.Text = "Restart"
        End If

        If entry.GroupBox IsNot Nothing Then
            entry.GroupBox.Visible = True
            entry.GroupBox.Enabled = True
        End If

        If entry.TextBox IsNot Nothing Then entry.TextBox.Enabled = True
    End Sub

    Private Shared Sub SetUiOffline(entry As ServiceControlEntry)
        If entry Is Nothing Then Return

        If entry.TextBox IsNot Nothing Then
            entry.TextBox.Text = "Offline"
            entry.TextBox.Enabled = False
            ' keep default colors
            entry.TextBox.ForeColor = SystemColors.WindowText
            entry.TextBox.BackColor = SystemColors.Window
        End If
        If entry.SSButton IsNot Nothing Then entry.SSButton.Enabled = False
        If entry.RSButton IsNot Nothing Then entry.RSButton.Enabled = False
        If entry.GroupBox IsNot Nothing Then entry.GroupBox.Enabled = False
    End Sub

    ' ---------------------------
    ' Status reflection
    ' ---------------------------

    Public Shared Function GetServiceStatus(ByVal caller As ServiceControlEntry) As Boolean
        If caller Is Nothing Then Return True
        If Not caller.Installed Then Return False

        ' Missing name -> treat as not installed (visible but disabled, default colors)
        If String.IsNullOrWhiteSpace(caller.Service) Then
            MarkNotInstalled(caller)
            Return False
        End If

        Try
            Using svc As New ServiceController(caller.Service)
                Dim status As ServiceControllerStatus = svc.Status
                caller.Status = status

                If caller.TextBox IsNot Nothing Then caller.TextBox.Text = status.ToString()

                Select Case status
                    Case ServiceControllerStatus.Running
                        EnableForRunning(caller)

                    Case ServiceControllerStatus.Stopped
                        EnableForStopped(caller)

                    Case ServiceControllerStatus.StartPending, ServiceControllerStatus.StopPending
                        ' CHANGE: Yellow background for these two pending states
                        EnableForSpecificPending(caller, status)

                    Case ServiceControllerStatus.PausePending, ServiceControllerStatus.ContinuePending, ServiceControllerStatus.Paused
                        ' Other pending/paused states → default (black on white)
                        EnableForOtherPending(caller)
                End Select

            End Using
        Catch
            ' Not installed or inaccessible → keep visible but disabled, default colors
            MarkNotInstalled(caller)
            Return False
        End Try

        Return True
    End Function

    ' ---------------------------
    ' UI wiring to form controls
    ' ---------------------------

    Public Shared Function BuildServiceControlList() As List(Of ServiceControlEntry)
        Dim frm As FormMain = TryCast(System.Windows.Forms.Application.OpenForms.Cast(Of System.Windows.Forms.Form)().
                                      FirstOrDefault(Function(f) TypeOf f Is FormMain), FormMain)
        If frm Is Nothing OrElse frm.IsDisposed Then
            Return New List(Of ServiceControlEntry)()
        End If

        Dim mylist As New List(Of ServiceControlEntry)()

        ' --- API Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbApiService,
            .SSButton = frm.btnApiServiceSS,
            .RSButton = frm.btnApiServiceRS,
            .Service = "AdvApiServer",
            .GroupBox = frm.gpApiService
        })

        ' --- Core Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbCoreService,
            .SSButton = frm.btnCoreServiceSS,
            .RSButton = frm.btnCoreServiceRS,
            .Service = "AdvCoreService",
            .GroupBox = frm.gpCoreService
        })

        ' --- Cloud Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbCloudService,
            .SSButton = frm.btnCloudServiceSS,
            .RSButton = frm.btnCloudServiceRS,
            .Service = "AdvantageCloudSyncService",
            .GroupBox = frm.gpCloudService
        })

        ' --- Credit Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbAdvCreditService,
            .SSButton = frm.btnAdvCreditServiceSS,
            .RSButton = frm.btnAdvCreditServiceRS,
            .Service = "AdvCreditService",
            .GroupBox = frm.gpAdvCreditService
        })

        ' --- License Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbAdvLicService,
            .SSButton = frm.btnAdvLicServiceSS,
            .RSButton = frm.btnAdvLicServiceRS,
            .Service = "AdvLicService",
            .GroupBox = frm.gpAdvLicService
        })

        ' --- Signage Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbAdvSignageService,
            .SSButton = frm.btnAdvSignageServiceSS,
            .RSButton = frm.btnAdvSignageServiceRS,
            .Service = "AdvSignageService",
            .GroupBox = frm.gpAdvSignageService
        })

        ' --- Turnstile Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbAdvTurnstileEngine,
            .SSButton = frm.btnAdvTurnstileEngineSS,
            .RSButton = frm.btnAdvTurnstileEngineRS,
            .Service = "AdvTurnstileEngine",
            .GroupBox = frm.gpAdvTurnstileEngine
        })

        ' --- Notification Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbAdvNotifyService,
            .SSButton = frm.btnAdvNotifyServiceSS,
            .RSButton = frm.btnAdvNotifyServiceRS,
            .Service = "AdvNotifyService",
            .GroupBox = frm.gpAdvNotifyService
        })

        ' --- Upgrade Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbAdvantageUpgradeService,
            .SSButton = frm.btnAdvantageUpgradeServiceSS,
            .RSButton = frm.btnAdvantageUpgradeServiceRS,
            .Service = "AdvantageUpgradeService",
            .GroupBox = frm.gpAdvantageUpgradeService
        })

        ' --- Relay Service ---
        mylist.Add(New ServiceControlEntry With {
            .TextBox = frm.tbRelayService,
            .SSButton = frm.btnRelayServiceSS,
            .RSButton = frm.btnRelayServiceRS,
            .Service = "AdvRelayClient",
            .GroupBox = frm.gpRelayService
        })

        Return mylist
    End Function

    ' ---------------------------
    ' Admin detection
    ' ---------------------------

    Private Shared Function IsRunningAsAdmin() As Boolean
        Try
            Dim wi = WindowsIdentity.GetCurrent()
            Dim wp = New WindowsPrincipal(wi)
            Return wp.IsInRole(WindowsBuiltInRole.Administrator)
        Catch
            Return False
        End Try
    End Function

End Class