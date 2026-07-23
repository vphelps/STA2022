Imports System.Threading.Tasks
Imports System.Windows.Forms

''' <summary>
''' Provides a reusable, non-blocking progress overlay for long-running operations.
''' </summary>
Public NotInheritable Class ProgressOverlayService

    Private Shared _overlay As ProgressOverlayForm

    Private Sub New()
        ' Static-only service
    End Sub

    ''' <summary>
    ''' Runs an asynchronous operation while displaying a progress overlay.
    ''' </summary>
    Public Shared Async Function RunWithOverlayAsync(
        owner As Form,
        message As String,
        work As Func(Of Task)
    ) As Task

        If owner Is Nothing Then
            Throw New ArgumentNullException(NameOf(owner))
        End If

        If work Is Nothing Then
            Throw New ArgumentNullException(NameOf(work))
        End If

        Show(owner, message)

        Try

            Await work().ConfigureAwait(True)

        Finally

            Hide()

        End Try

    End Function

    ''' <summary>
    ''' Updates the overlay message while work is running.
    ''' Safe to call from background threads.
    ''' </summary>
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

    ''' <summary>
    ''' Displays the overlay on top of the specified form.
    ''' </summary>
    Private Shared Sub Show(
        owner As Form,
        message As String
    )

        If _overlay IsNot Nothing Then Return

        _overlay = New ProgressOverlayForm(message) With {
            .Size = owner.ClientSize,
            .Location = owner.PointToScreen(Point.Empty)
        }

        _overlay.Show(owner)
        _overlay.BringToFront()
        _overlay.Refresh()

    End Sub

    ''' <summary>
    ''' Closes and disposes the overlay.
    ''' </summary>
    Private Shared Sub Hide()

        If _overlay Is Nothing Then Return

        Try

            _overlay.Close()
            _overlay.Dispose()

        Catch

            ' Overlay cleanup failures are non-fatal

        Finally

            _overlay = Nothing

        End Try

    End Sub

End Class