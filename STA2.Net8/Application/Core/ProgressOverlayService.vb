Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

''' <summary>
''' Provides a reusable, non-blocking progress overlay for long-running operations.
''' </summary>
Public NotInheritable Class ProgressOverlayService

    Private Shared _overlay As ProgressOverlayForm
    Private Shared _cts As CancellationTokenSource

    Public Shared ReadOnly Property CancellationToken As CancellationToken
        Get
            If _cts Is Nothing Then
                Return Threading.CancellationToken.None
            End If

            Return _cts.Token
        End Get
    End Property

    Private Sub New()
        ' Static-only service
    End Sub

    Private Shared Sub Show(
       owner As Form,
       title As String,
       message As String
   )
        If _overlay IsNot Nothing Then Return
        _cts = New CancellationTokenSource()

        _overlay = New ProgressOverlayForm(
            title, message) With {.Size = owner.ClientSize, .Location = owner.PointToScreen(Point.Empty)}
        AddHandler _overlay.CancelRequested,
            Sub()

                If _cts IsNot Nothing AndAlso
                Not _cts.IsCancellationRequested Then
                    _cts.Cancel()
                End If
            End Sub

        _overlay.SetProgress(0)

        _overlay.Show(owner)
        _overlay.BringToFront()
        _overlay.Refresh()

    End Sub

    Public Shared Async Function RunWithOverlayAsync(
        owner As Form,
        title As String,
        message As String,
        work As Func(Of Task)
    ) As Task

        If owner Is Nothing Then
            Throw New ArgumentNullException(NameOf(owner))
        End If

        If work Is Nothing Then
            Throw New ArgumentNullException(NameOf(work))
        End If

        Show(owner, title, message)

        Try

            Await work().ConfigureAwait(True)

        Finally

            Hide()

        End Try

    End Function

    Public Shared Sub UpdateMessage(message As String)

        If _overlay Is Nothing Then Return

        Try
            If _overlay.IsDisposed Then Return
            If _overlay.InvokeRequired Then
                _overlay.BeginInvoke(
                    New Action(
                        Sub()
                            If _overlay IsNot Nothing AndAlso
                               Not _overlay.IsDisposed Then
                                _overlay.SetMessage(message)
                            End If
                        End Sub))
            Else
                _overlay.SetMessage(message)
            End If
        Catch
            ' Overlay update failures are non-fatal
        End Try

    End Sub
    Public Shared Sub UpdateProgress(value As Integer)

        If _overlay Is Nothing Then Return

        Try
            If _overlay.IsDisposed Then Return
            If _overlay.InvokeRequired Then
                _overlay.BeginInvoke(
                New Action(
                    Sub()
                        If _overlay IsNot Nothing AndAlso
                           Not _overlay.IsDisposed Then
                            _overlay.SetProgress(value)
                        End If
                    End Sub))
            Else
                _overlay.SetProgress(value)
            End If
        Catch
            ' Non-fatal
        End Try

    End Sub
    Public Shared Sub UpdateTitle(title As String)
        If _overlay Is Nothing Then Return

        Try
            If _overlay.IsDisposed Then Return
            If _overlay.InvokeRequired Then
                _overlay.BeginInvoke(
                New Action(
                    Sub()
                        If _overlay IsNot Nothing AndAlso
                           Not _overlay.IsDisposed Then
                            _overlay.SetTitle(title)
                        End If
                    End Sub))
            Else
                _overlay.SetTitle(title)
            End If
        Catch
        End Try

    End Sub

    Private Shared Sub Hide()

        If _overlay Is Nothing Then Return

        Try

            _overlay.Close()
            _overlay.Dispose()

        Catch

            ' Overlay cleanup failures are non-fatal

        Finally

            _cts?.Dispose()
            _cts = Nothing

            _overlay = Nothing

        End Try

    End Sub

End Class