Imports System.ServiceProcess
Imports System.Threading
Imports System.Threading.Tasks

Public Class ServiceManager
    Public Event ServiceNotInstalled(serviceName As String)
    Private ReadOnly _busyServices As New HashSet(Of String)(
    StringComparer.OrdinalIgnoreCase)

    Private ReadOnly _lastStatus As New Dictionary(Of String, ServiceControllerStatus)(
    StringComparer.OrdinalIgnoreCase)

    ' -----------------------------
    ' Events surfaced to the UI
    ' -----------------------------
    Public Event ServiceStatusChanged(
        serviceName As String,
        status As ServiceControllerStatus
    )

    Public Event ServiceBusyChanged(
        serviceName As String,
        isBusy As Boolean
    )
    Public Event ServiceOperationFailed(
    serviceName As String,
    ex As Exception
)
    ' -----------------------------
    ' Polling
    ' -----------------------------
    Private _timer As Timer
    Private _serviceNames As List(Of String)

    Public Sub StartPolling(
    serviceNames As IEnumerable(Of String),
    intervalMilliseconds As Integer
)

        StopPolling()
        _serviceNames = serviceNames.ToList()

        ' ✅ Poll immediately (no UI delay)
        PollServices(Nothing)

        ' ✅ Then poll on interval
        _timer = New Timer(
        AddressOf PollServices,
        Nothing,
        intervalMilliseconds,
        intervalMilliseconds
    )

    End Sub
    Public Sub StopPolling()
        _timer?.Dispose()
        _timer = Nothing
    End Sub

    Private Sub PollServices(state As Object)

        For Each name In _serviceNames

            Try
                Using sc As New ServiceController(name)
                    Dim status = sc.Status
                    RaiseEvent ServiceStatusChanged(name, status)
                End Using

            Catch ex As InvalidOperationException
                ' ✅ Service does not exist / not installed
                RaiseEvent ServiceNotInstalled(name)

            Catch ex As ArgumentException
                ' ✅ Transient or shutdown race – ignore

            Catch ex As Exception
#If DEBUG Then
                Debug.WriteLine(
                $"Unexpected polling error for {name}: {ex.GetType().Name}")
#End If
            End Try

        Next

    End Sub
    ' -----------------------------
    ' Service execution
    ' -----------------------------

    Public Async Function StartServiceAsync(serviceName As String) As Task
        Await ExecuteAsync(
            serviceName,
            ServiceControllerStatus.StartPending,
            Sub(sc)
                If sc.Status = ServiceControllerStatus.Stopped Then
                    sc.Start()
                    sc.WaitForStatus(
                        ServiceControllerStatus.Running,
                        TimeSpan.FromMinutes(2))
                End If
            End Sub,
            ServiceControllerStatus.Running
        )
    End Function

    Public Async Function StopServiceAsync(serviceName As String) As Task
        Await ExecuteAsync(
            serviceName,
            ServiceControllerStatus.StopPending,
            Sub(sc)
                If sc.Status = ServiceControllerStatus.Running Then
                    sc.Stop()
                    sc.WaitForStatus(
                        ServiceControllerStatus.Stopped,
                        TimeSpan.FromMinutes(2))
                End If
            End Sub,
            ServiceControllerStatus.Stopped
        )
    End Function

    Public Async Function RestartServiceAsync(serviceName As String) As Task
        Await ExecuteAsync(
            serviceName,
            ServiceControllerStatus.StopPending,
            Sub(sc)
                If sc.Status = ServiceControllerStatus.Running Then
                    sc.Stop()
                    sc.WaitForStatus(
                        ServiceControllerStatus.Stopped,
                        TimeSpan.FromMinutes(2))
                End If
                sc.Start()
                sc.WaitForStatus(
                    ServiceControllerStatus.Running,
                    TimeSpan.FromMinutes(2))
            End Sub,
            ServiceControllerStatus.Running
        )
    End Function

    Private Async Function ExecuteAsync(
        serviceName As String,
        optimisticStatus As ServiceControllerStatus,
        action As Action(Of ServiceController),
        finalStatus As ServiceControllerStatus
    ) As Task


        If _busyServices.Contains(serviceName) Then
            Return
        End If

        _busyServices.Add(serviceName)
        RaiseEvent ServiceBusyChanged(serviceName, True)
        RaiseEvent ServiceStatusChanged(serviceName, optimisticStatus)

        Try
            Await Task.Run(Sub()
                               Using sc As New ServiceController(serviceName)
                                   action(sc)
                               End Using
                           End Sub)

            RaiseEvent ServiceStatusChanged(serviceName, finalStatus)

        Catch ex As Exception
            RaiseEvent ServiceOperationFailed(serviceName, ex)
        Finally

            _busyServices.Remove(serviceName)
            RaiseEvent ServiceBusyChanged(serviceName, False)
        End Try

    End Function


End Class