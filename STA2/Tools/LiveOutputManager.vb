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
                     _output.SuspendLayout()
                     _output.Clear()
                     _output.ResumeLayout()
                 End Sub)

        _stopwatch = Stopwatch.StartNew()

        _timer = New Timer With {.Interval = 500}
        AddHandler _timer.Tick, AddressOf UpdateRunningHeader
        _timer.Start()

        UpdateRunningHeader(Nothing, EventArgs.Empty)
    End Sub

    Public Sub AppendLine(text As String)

        BeginInvokeUi(Sub()

                          _output.SuspendLayout()

                          Dim start = _output.TextLength
                          _output.AppendText(text & Environment.NewLine)
                          _output.SelectionStart = _output.TextLength
                          _output.SelectionLength = 0

                          ' Do NOT rely on normal repaint logic
                          _output.ScrollToCaret()

                          _output.ResumeLayout()

                      End Sub)
    End Sub

    Public Sub CompleteExecution(exitCode As Integer)

        If _timer IsNot Nothing Then
            _timer.Stop()
            RemoveHandler _timer.Tick, AddressOf UpdateRunningHeader
            _timer.Dispose()
            _timer = Nothing
        End If

        _stopwatch?.Stop()

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
        _owner.BeginInvoke(Sub()
                               _output.SelectionStart = _output.TextLength
                               _output.ScrollToCaret()

                               ' ✅ If output tab is currently visible, repaint immediately
                               If TypeOf _output.Parent Is Control AndAlso _output.Visible Then
                                   _output.Hide()
                                   _output.Show()
                                   _output.Refresh()
                               End If
                           End Sub)

    End Sub

    Public Sub ResetHeader()
        InvokeUi(Sub()
                     _groupBox.Text = "Script Output Window"
                 End Sub)
    End Sub

    ' ----------------------------
    ' 🔴 CRITICAL: Call when tab becomes visible
    ' ----------------------------
    Public Sub ForceRedraw()

        InvokeUi(Sub()

                     If _output.IsDisposed Then Return

                     _output.SuspendLayout()

                     ' ✅ Force WinForms to rebuild control layout & handle
                     _output.Visible = False
                     _output.Visible = True

                     _output.PerformLayout()
                     _output.Refresh()

                     ' ✅ Restore sane scroll/caret
                     _output.SelectionStart = _output.TextLength
                     _output.ScrollToCaret()

                     _output.ResumeLayout()

                 End Sub)
    End Sub

    ' ----------------------------
    ' Helpers
    ' ----------------------------

    Private Sub UpdateRunningHeader(sender As Object, e As EventArgs)

        If _stopwatch Is Nothing OrElse Not _stopwatch.IsRunning Then Return

        Dim scriptName = IO.Path.GetFileName(_scriptPath)
        Dim elapsed = FormatDuration(_stopwatch.Elapsed)

        BeginInvokeUi(Sub()
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
        If _owner.IsDisposed Then Return
        If _owner.InvokeRequired Then
            _owner.Invoke(action)
        Else
            action()
        End If
    End Sub

    Private Sub BeginInvokeUi(action As Action)
        If _owner.IsDisposed Then Return
        _owner.BeginInvoke(action)
    End Sub

End Class