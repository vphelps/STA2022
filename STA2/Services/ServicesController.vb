Imports System.ServiceProcess
Imports System.Security.Principal
Imports System.Threading.Tasks

' ===========================================================
' ServicesController
'
' Centralized, UI-agnostic controller for Windows Services.
'
' Responsibilities:
'   - Discover whether a service is installed
'   - Query live service status
'   - Start / Stop / Restart services asynchronously
'   - Enforce only one service operation at a time
'   - Raise events for UI coordination
'
' NO WinForms references.
' Designed for .NET Framework 4.8
' ===========================================================

Public Module ServicesController

    ' =======================================================
    ' Events (UI listens to these)
    ' =======================================================
    Public Event OperationStarted(serviceName As String, operation As String)
    Public Event OperationCompleted(serviceName As String, operation As String, success As Boolean)

    ' =======================================================
    ' Internal busy state (single-operation enforcement)
    ' =======================================================
    Private _isBusy As Boolean = False
    Private ReadOnly _busyLock As New Object()

    ' =======================================================
    ' Data model (UI-independent)
    ' =======================================================
    Public Class ServiceInfo
        Public Property ServiceName As String
        Public Property DisplayName As String
        Public Property Installed As Boolean
        Public Property Status As ServiceControllerStatus
    End Class

    ' =======================================================
    ' Discovery / Status
    ' =======================================================

    Public Function GetServiceInfo(serviceName As String) As ServiceInfo
        If String.IsNullOrWhiteSpace(serviceName) Then
            Return New ServiceInfo With {
                .ServiceName = serviceName,
                .Installed = False
            }
        End If

        Try
            Using sc As New ServiceController(serviceName)
                Dim status As ServiceControllerStatus = sc.Status
                Return New ServiceInfo With {
                    .ServiceName = sc.ServiceName,
                    .DisplayName = sc.DisplayName,
                    .Installed = True,
                    .Status = status
                }
            End Using
        Catch
            Return New ServiceInfo With {
                .ServiceName = serviceName,
                .Installed = False
            }
        End Try
    End Function


    Public Function IsInstalled(serviceName As String) As Boolean
        If String.IsNullOrWhiteSpace(serviceName) Then Return False

        Try
            Using sc As New ServiceController(serviceName)
                Dim status As ServiceControllerStatus = sc.Status
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function


    Public Function GetStatus(serviceName As String) As ServiceControllerStatus
        Using sc As New ServiceController(serviceName)
            Return sc.Status
        End Using
    End Function

    ' =======================================================
    ' Privilege check (RENAMED)
    ' =======================================================

    Public Function HasServiceControlPrivileges() As Boolean
        Try
            Dim wi = WindowsIdentity.GetCurrent()
            Dim wp = New WindowsPrincipal(wi)
            Return wp.IsInRole(WindowsBuiltInRole.Administrator)
        Catch
            Return False
        End Try
    End Function

    ' =======================================================
    ' Async Operations
    ' =======================================================

    Public Async Function StartAsync(
        serviceName As String,
        Optional timeoutSeconds As Integer = 30
    ) As Task(Of Boolean)

        Return Await RunExclusiveAsync(
            serviceName,
            "Start",
            Async Function()
                Using sc As New ServiceController(serviceName)
                    sc.Start()
                    Await WaitForStatusAsync(sc, ServiceControllerStatus.Running, timeoutSeconds)
                End Using
            End Function)
    End Function


    Public Async Function StopAsync(
        serviceName As String,
        Optional timeoutSeconds As Integer = 30
    ) As Task(Of Boolean)

        Return Await RunExclusiveAsync(
            serviceName,
            "Stop",
            Async Function()
                Using sc As New ServiceController(serviceName)
                    sc.Stop()
                    Await WaitForStatusAsync(sc, ServiceControllerStatus.Stopped, timeoutSeconds)
                End Using
            End Function)
    End Function


    Public Async Function RestartAsync(
        serviceName As String,
        Optional timeoutSeconds As Integer = 30
    ) As Task(Of Boolean)

        Return Await RunExclusiveAsync(
            serviceName,
            "Restart",
            Async Function()
                Using sc As New ServiceController(serviceName)

                    Try
                        sc.Stop()
                        Await WaitForStatusAsync(sc, ServiceControllerStatus.Stopped, timeoutSeconds)
                    Catch
                        ' best‑effort stop
                    End Try

                    sc.Start()
                    Await WaitForStatusAsync(sc, ServiceControllerStatus.Running, timeoutSeconds)

                End Using
            End Function)
    End Function

    ' =======================================================
    ' Core Execution / Synchronization
    ' =======================================================

    Private Async Function RunExclusiveAsync(
        serviceName As String,
        operation As String,
        action As Func(Of Task)
    ) As Task(Of Boolean)

        SyncLock _busyLock
            If _isBusy Then
                Return False
            End If
            _isBusy = True
        End SyncLock

        RaiseEvent OperationStarted(serviceName, operation)

        Dim success As Boolean

        Try
            Await action.Invoke().ConfigureAwait(False)
            success = True
        Catch
            success = False
        End Try

        SyncLock _busyLock
            _isBusy = False
        End SyncLock

        RaiseEvent OperationCompleted(serviceName, operation, success)
        Return success
    End Function


    Private Async Function WaitForStatusAsync(
        sc As ServiceController,
        targetStatus As ServiceControllerStatus,
        timeoutSeconds As Integer
    ) As Task

        Dim deadline As DateTime = DateTime.UtcNow.AddSeconds(timeoutSeconds)

        While sc.Status <> targetStatus
            Await Task.Delay(500).ConfigureAwait(False)
            sc.Refresh()

            If DateTime.UtcNow > deadline Then
                Throw New TimeoutException(
                    $"Timed out waiting for {sc.ServiceName} to reach {targetStatus}.")
            End If
        End While
    End Function

End Module