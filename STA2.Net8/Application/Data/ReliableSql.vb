Imports System.Data
Imports Microsoft.Data.SqlClient
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

' Central wrapper for resilient SQL calls in a WinForms app.
' - Detects transient/connection failures
' - Shows a single blocking modal ("Retry/Cancel")
' - Attempts reconnect then retries the operation
' - Ensures only ONE prompt at a time even if multiple calls fail simultaneously
Public Module ReliableSql

    ' If you want to force a specific connection string (instead of ConfigValues), set it via Initialize/SetConnectionString.
    Private _connectionString As String = Nothing

    ' Controls whether the modal prompt is shown on connection failure
    Public Property EnablePrompt As Boolean = True

    ' How many reconnect attempts to try after user clicks Retry (in addition to immediate TryReconnect)
    Public Property MaxReconnectAttempts As Integer = 3

    ' Delay (ms) between reconnect attempts after user clicks Retry
    Public Property ReconnectDelayMs As Integer = 1000

    ' Guard so only one prompt is shown at a time
    Private ReadOnly _syncRoot As New Object()
    Private _promptOpen As Boolean = False

    ' Optional: override the prompt (e.g., show a custom form). If Nothing, a default MessageBox is used.
    ' The delegate should return DialogResult.Retry or DialogResult.Cancel
    Public Property PromptHandler As Func(Of DialogResult) = Nothing

    ' --- Initialization ---

    ' Provide a full connection string explicitly (optional; otherwise we build it from ConfigValues).
    Public Sub Initialize(connectionString As String)
        _connectionString = connectionString

    End Sub

    ' Clear any explicitly set connection string (revert to ConfigValues builder)
    Public Sub ClearConnectionString()
        _connectionString = Nothing
    End Sub

    ' --- Public surface mirroring your DBConnector signatures ---

    ' 1) Wrapper for DBConnector.dbQuery (your signature currently returns Object)
    '    NOTE: This returns Object to exactly match your DBConnector.dbQuery behavior.
    Public Function Query(sql As String) As Object
        Return ExecuteWithPauseRetry(Function() DBConnector.dbQuery(sql))
    End Function
    Public Async Function QueryAsync(
    sql As String,
    Optional ct As CancellationToken = Nothing
) As Task(Of Object)

        ct.ThrowIfCancellationRequested()

        Return Await Task.Run(
        Function()

            ct.ThrowIfCancellationRequested()

            Return Query(sql)

        End Function,
        ct)

    End Function


    ' 2) Wrapper for DBConnector.dbExecute (affected rows)
    Public Function Execute(sql As String) As Integer
        Return ExecuteWithPauseRetry(Function() DBConnector.dbExecute(sql))
    End Function
    Public Async Function ExecuteAsync(
    sql As String,
    Optional ct As CancellationToken = Nothing
) As Task(Of Integer)

        ct.ThrowIfCancellationRequested()

        Return Await Task.Run(
        Function()

            ct.ThrowIfCancellationRequested()

            Return Execute(sql)

        End Function,
        ct)

    End Function

    ' 3) Wrapper for DBConnector.getValue (scalar-ish)
    Public Function GetValue(sql As String) As Object
        Return ExecuteWithPauseRetry(Function() DBConnector.getValue(sql))
    End Function
    Public Async Function GetValueAsync(
    sql As String,
    Optional ct As CancellationToken = Nothing
) As Task(Of Object)

        ct.ThrowIfCancellationRequested()

        Return Await Task.Run(
        Function()

            ct.ThrowIfCancellationRequested()

            Return GetValue(sql)

        End Function,
        ct)

    End Function
    ' --- Core retry/pause logic ---

    ' Runs the given operation; if a connection error occurs:
    '  - Show a single modal prompt (Retry/Cancel) on the UI thread
    '  - On Retry: attempt reconnect (with small retry loop), then re-run the operation
    '  - On Cancel: throw OperationCanceledException
    Private Function ExecuteWithPauseRetry(Of T)(operation As Func(Of T)) As T
        While True
            Try
                Return operation()
            Catch ex As Exception
                If Not IsConnectionFailure(ex) Then
                    ' Not a connection/transient error—bubble up
                    Throw
                End If

                ' Connection lost—optionally pause with modal and allow user to Retry/Cancel
                Dim response As DialogResult = DialogResult.Retry
                If EnablePrompt Then
                    response = ShowConnectionLostModalOnce()
                End If

                If response = DialogResult.Retry Then
                    ' Attempt immediate reconnect
                    If Not TryReconnect() Then
                        ' Try a few times with short delays
                        For attempt = 1 To MaxReconnectAttempts
                            Thread.Sleep(ReconnectDelayMs)
                            If TryReconnect() Then Exit For
                            ' If still failing on last attempt, we loop back around—another modal will be shown
                        Next
                    End If

                    ' Loop to retry the original operation
                    Continue While
                Else
                    ' Cancel: stop this operation and let caller handle
                    Throw New OperationCanceledException("Operation canceled by user after connection loss.", ex)
                End If
            End Try
        End While
    End Function

    ' Detect transient/disconnect failures
    Private Function IsConnectionFailure(ex As Exception) As Boolean
        ' ADO.NET timeout flows here too
        If TypeOf ex Is TimeoutException Then Return True

        ' SqlException with common transient/disconnect error numbers
        Dim sqlEx = TryCast(ex, SqlException)
        If sqlEx IsNot Nothing Then
            Dim transientCodes As Integer() = {
                -2,     ' Timeout
                4060,   ' Cannot open database requested by the login
                40197,  ' Azure SQL transient error
                40501,  ' Throttling
                40540,  ' Service event
                10053,  ' Network path dropped
                10054,  ' Connection reset by peer
                10060   ' Network timeout / could not connect
            }
            If sqlEx.Errors.Cast(Of SqlError)().Any(Function(err) transientCodes.Contains(err.Number)) Then
                Return True
            End If
        End If

        ' Check inner exceptions recursively (socket/network)
        If ex.InnerException IsNot Nothing AndAlso IsConnectionFailure(ex.InnerException) Then
            Return True
        End If

        Return False
    End Function

    ' Builds/uses a connection string and attempts to open a short-lived connection
    Private Function TryReconnect() As Boolean
        Dim connStr As String = GetConnectionString()
        If String.IsNullOrWhiteSpace(connStr) Then Return False

        Try
            Using cn As New SqlConnection(connStr)
                cn.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function

    ' If Initialize() set a connection string, use it; otherwise build from ConfigValues (your app’s settings).
    Private Function GetConnectionString() As String
        If Not String.IsNullOrWhiteSpace(_connectionString) Then
            Return _connectionString
        End If

        ' Build from your existing ConfigValues to match DBConnector usage
        Try
            Dim b As New SqlConnectionStringBuilder()
            b.DataSource = ConfigValues.Server
            b.IntegratedSecurity = False
            b.InitialCatalog = ConfigValues.Database
            b.UserID = ConfigValues.UserID
            b.Password = ConfigValues.Password
            b.ApplicationName = "STA2"
            Return b.ConnectionString
        Catch
            Return Nothing
        End Try
    End Function

    ' Ensures only one modal prompt is shown at a time across threads; others wait until it closes.
    Private Function ShowConnectionLostModalOnce() As DialogResult
        SyncLock _syncRoot
            If _promptOpen Then
                ' Another caller already opened the modal—wait until it closes
                While _promptOpen
                    Monitor.Wait(_syncRoot, 200)
                End While
                ' After the other prompt closes, behave as if user pressed Retry (attempt again)
                Return DialogResult.Retry
            End If
            _promptOpen = True
        End SyncLock

        Dim result As DialogResult = DialogResult.Retry

        Try

            result = ShowPrompt()

        Finally
            SyncLock _syncRoot
                _promptOpen = False
                Monitor.PulseAll(_syncRoot)
            End SyncLock
        End Try

        Return result
    End Function

    Private Function ShowPrompt() As DialogResult

        If PromptHandler IsNot Nothing Then
            Return PromptHandler.Invoke()
        End If

        Dim caption = "Database Connection Lost"

        Dim text =
        "The connection to the database was lost." &
        Environment.NewLine &
        "Check your network/server, then click Retry." &
        Environment.NewLine &
        "Click Cancel to stop the current operation."

        Return UIHelpers.TimedErrorPrompt(
        message:=text,
        title:=caption,
        timeoutSeconds:=0,
        button1Text:="Retry",
        button1Result:=DialogResult.Retry,
        button2Text:="Cancel",
        button2Result:=DialogResult.Cancel,
        defaultButtonIndex:=1,
        cancelButtonIndex:=2)

    End Function

End Module