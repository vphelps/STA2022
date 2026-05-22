Imports System.Threading.Tasks
Imports System.Windows.Forms

''' <summary>
''' Provides a reusable, non-blocking progress overlay for long-running operations.
''' </summary>
''' <remarks>
''' This service is intended for WinForms applications where expensive or blocking work
''' must be performed without freezing the UI. It displays a temporary overlay form
''' over the specified owner while the supplied asynchronous operation runs.
'''
''' Usage guidance:
''' • If the work is already asynchronous (returns Task), pass it directly.
''' • If the work is synchronous or CPU-bound, wrap it in Task.Run.
''' • Do NOT wrap already-async methods in Task.Run.
''' </remarks>
Public NotInheritable Class ProgressOverlayService

    Private Shared _overlay As ProgressOverlayForm

    Private Sub New()
        ' Static-only service
    End Sub

    ''' <summary>
    ''' Runs an asynchronous operation while displaying a progress overlay over the owner form.
    ''' </summary>
    ''' <param name="owner">
    ''' The form that owns the overlay. The overlay will be sized and positioned to match it.
    ''' </param>
    ''' <param name="message">
    ''' The message displayed to the user while the operation is in progress.
    ''' </param>
    ''' <param name="work">
    ''' A function that returns a Task representing the operation to perform.
    ''' If the operation is synchronous or CPU-bound, it should be wrapped in Task.Run.
    ''' </param>
    ''' <returns>
    ''' A Task that completes when the supplied operation has finished and the overlay is closed.
    ''' </returns>
    ''' <example>
    ''' Await ProgressOverlayService.RunWithOverlayAsync(
    '''     Me,
    '''     "Scanning installed versions...",
    '''     Async Function()
    '''         Await SomeAsyncMethod()
    '''     End Function)
    '''
    ''' Await ProgressOverlayService.RunWithOverlayAsync(
    '''     Me,
    '''     "Performing blocking work...",
    '''     Function()
    '''         Return Task.Run(Sub() DoBlockingWork())
    '''     End Function)
    ''' </example>
    Public Shared Async Function RunWithOverlayAsync(
        owner As Form,
        message As String,
        work As Func(Of Task)
    ) As Task

        If owner Is Nothing Then Throw New ArgumentNullException(NameOf(owner))
        If work Is Nothing Then Throw New ArgumentNullException(NameOf(work))

        Show(owner, message)

        Try
            Await work().ConfigureAwait(True)
        Finally
            Hide()
        End Try

    End Function

    ''' <summary>
    ''' Displays the overlay on top of the specified form.
    ''' </summary>
    Private Shared Sub Show(owner As Form, message As String)

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
    ''' Closes and disposes the overlay if it is currently displayed.
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