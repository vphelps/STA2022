Imports System.Diagnostics
Imports System.Windows.Forms

Public Class LiveOutputManager

    Private ReadOnly _owner As Form
    Private ReadOnly _output As RichTextBox
    Private ReadOnly _groupBox As GroupBox

    Private _stopwatch As Stopwatch
    Private _timer As Timer
    Private _scriptPath As String

    Public Sub New(owner As Form, output As RichTextBox, groupBox As GroupBox)
        _owner = owner
        _output = output
        _groupBox = groupBox
    End Sub

    ' ----------------------------
    ' Execution lifecycle
    ' ----------------------------

    Public Sub StartExecution(scriptPath As String)
        _scriptPath = scriptPath

        InvokeUi(Sub()
                     _output.Clear()
                 End Sub)

        _stopwatch = Stopwatch.StartNew()

        _timer = New Timer With {.Interval = 500}
        AddHandler _timer.Tick, AddressOf UpdateRunningHeader
        _timer.Start()

        UpdateRunningHeader(Nothing, EventArgs.Empty)
    End Sub

    Public Sub AppendLine(text As String)
        InvokeUi(Sub()
                     _output.AppendText(text & Environment.NewLine)
                     _output.SelectionStart = _output.TextLength
                     _output.SelectionLength = 0
                     _output.ScrollToCaret()
                 End Sub)
    End Sub

    Public Sub CompleteExecution(exitCode As Integer)
        _timer.Stop()
        RemoveHandler _timer.Tick, AddressOf UpdateRunningHeader
        _timer.Dispose()
        _timer = Nothing

        _stopwatch.Stop()

        Dim scriptName = IO.Path.GetFileName(_scriptPath)
        Dim duration = FormatDuration(_stopwatch.Elapsed)

        AppendLine(
            If(exitCode = 0,
               $"--- Script {scriptName} completed successfully in {duration} (Exit 0) ---",
               $"--- Script {scriptName} completed with errors in {duration} (Exit {exitCode}) ---"))

        InvokeUi(Sub()
                     _groupBox.Text =
                         $"Script Output Window — {scriptName} (Completed in {duration})"
                 End Sub)

        _scriptPath = Nothing
    End Sub

    Public Sub ResetHeader()
        InvokeUi(Sub()
                     _groupBox.Text = "Script Output Window"
                 End Sub)
    End Sub

    ' ----------------------------
    ' Helpers
    ' ----------------------------

    Private Sub UpdateRunningHeader(sender As Object, e As EventArgs)
        If _stopwatch Is Nothing OrElse Not _stopwatch.IsRunning Then Return

        Dim scriptName = IO.Path.GetFileName(_scriptPath)
        Dim elapsed = FormatDuration(_stopwatch.Elapsed)

        InvokeUi(Sub()
                     _groupBox.Text =
                         $"Script Output Window — {scriptName} (Running {elapsed})"
                 End Sub)
    End Sub

    Private Function FormatDuration(ts As TimeSpan) As String
        If ts.TotalHours >= 1 Then
            Return $"{CInt(ts.TotalHours)}h {ts.Minutes}m {ts.Seconds}s"
        ElseIf ts.TotalMinutes >= 1 Then
            Return $"{ts.Minutes}m {ts.Seconds}s"
        Else
            Return $"{ts.Seconds}.{ts.Milliseconds \ 100}s"
        End If
    End Function

    Private Sub InvokeUi(action As Action)
        If _owner.InvokeRequired Then
            _owner.Invoke(action)
        Else
            action()
        End If
    End Sub

End Class