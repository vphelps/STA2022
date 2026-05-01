Imports System.Windows.Forms
Imports System.Drawing

' ===========================================================
' UIHelpers
'
' Reusable WinForms UI helper dialogs with:
' - Auto-sizing based on message text
' - Optional timeout (timeoutSeconds <= 0 = no timeout)
' - Owner and no-owner overloads
'
' Helpers:
'   - TimedYesNoPrompt
'   - TimedInfoPrompt
'   - TimedWarningPrompt
'   - TimedErrorPrompt
'
' Keyboard semantics (Yes/No):
'   Enter  -> Yes
'   Escape -> No
'
' Designed for .NET Framework 4.8
' ===========================================================

Public Module UIHelpers

    ' =======================================================
    ' OWNER RESOLUTION
    ' =======================================================
    Private Function ResolveOwner(owner As IWin32Window) As IWin32Window
        If owner IsNot Nothing Then Return owner
        If Form.ActiveForm IsNot Nothing Then Return Form.ActiveForm
        If Application.OpenForms.Count > 0 Then Return Application.OpenForms(0)
        Return Nothing
    End Function

    ' =======================================================
    ' TIMED YES / NO PROMPT
    ' =======================================================

    ' No owner, no timeout
    Public Function TimedYesNoPrompt(
        message As String,
        title As String,
        Optional defaultChoice As DialogResult = DialogResult.No
    ) As DialogResult
        Return TimedYesNoPrompt(Nothing, message, title, 0, defaultChoice)
    End Function

    ' With owner, no timeout
    Public Function TimedYesNoPrompt(
        owner As IWin32Window,
        message As String,
        title As String,
        Optional defaultChoice As DialogResult = DialogResult.No
    ) As DialogResult
        Return TimedYesNoPrompt(owner, message, title, 0, defaultChoice)
    End Function

    ' No owner, with timeout
    Public Function TimedYesNoPrompt(
        message As String,
        title As String,
        timeoutSeconds As Integer,
        Optional defaultChoice As DialogResult = DialogResult.No
    ) As DialogResult
        Return TimedYesNoPrompt(Nothing, message, title, timeoutSeconds, defaultChoice)
    End Function

    ' Canonical implementation
    Public Function TimedYesNoPrompt(
        owner As IWin32Window,
        message As String,
        title As String,
        timeoutSeconds As Integer,
        Optional defaultChoice As DialogResult = DialogResult.No
    ) As DialogResult

        If defaultChoice <> DialogResult.Yes AndAlso defaultChoice <> DialogResult.No Then
            defaultChoice = DialogResult.No
        End If

        Dim result As DialogResult = defaultChoice
        Dim useTimeout As Boolean = timeoutSeconds > 0

        Using dlg As New Form()
            ConfigureBaseDialog(dlg, title, 440)

            Dim lblMessage = CreateMessageLabel(message, 20, 20, 380)
            dlg.Controls.Add(lblMessage)

            Dim lblCountdown = CreateCountdownLabel(lblMessage.Bottom + 10, useTimeout)
            dlg.Controls.Add(lblCountdown)

            Dim buttonTop = If(useTimeout, lblCountdown.Bottom, lblMessage.Bottom) + 15

            Dim btnYes = CreateButton("Yes", 120, buttonTop)
            Dim btnNo = CreateButton("No", 230, buttonTop)

            dlg.AcceptButton = btnYes
            dlg.CancelButton = btnNo

            If defaultChoice = DialogResult.Yes Then btnYes.Select() Else btnNo.Select()

            AddHandler btnYes.Click,
                Sub()
                    result = DialogResult.Yes
                    dlg.Close()
                End Sub

            AddHandler btnNo.Click,
                Sub()
                    result = DialogResult.No
                    dlg.Close()
                End Sub

            dlg.Controls.AddRange({btnYes, btnNo})

            Dim timer As Timer = Nothing
            If useTimeout Then
                timer = CreateCountdownTimer(
                    timeoutSeconds,
                    Function(sec) $"Defaulting to {If(defaultChoice = DialogResult.Yes, "Yes", "No")} in {sec} seconds...",
                    Sub()
                        result = defaultChoice
                        dlg.Close()
                    End Sub,
                    lblCountdown)
            End If

            AutoSizeDialog(dlg, btnYes, 20)
            dlg.ShowDialog(ResolveOwner(owner))
            DisposeTimer(timer)
        End Using

        Return result
    End Function

    ' =======================================================
    ' INFO / WARNING / ERROR PROMPTS
    ' =======================================================

    ' --- INFO ---
    Public Sub TimedInfoPrompt(message As String, title As String, Optional timeoutSeconds As Integer = 0)
        TimedInfoPrompt(Nothing, message, title, timeoutSeconds)
    End Sub

    Public Sub TimedInfoPrompt(owner As IWin32Window, message As String, title As String, Optional timeoutSeconds As Integer = 0)
        ShowSingleButtonPrompt(ResolveOwner(owner), message, title, timeoutSeconds, SystemIcons.Information)
    End Sub

    ' --- WARNING ---
    Public Sub TimedWarningPrompt(message As String, title As String, Optional timeoutSeconds As Integer = 0)
        TimedWarningPrompt(Nothing, message, title, timeoutSeconds)
    End Sub

    Public Sub TimedWarningPrompt(owner As IWin32Window, message As String, title As String, Optional timeoutSeconds As Integer = 0)
        ShowSingleButtonPrompt(ResolveOwner(owner), message, title, timeoutSeconds, SystemIcons.Warning)
    End Sub

    ' --- ERROR ---
    Public Sub TimedErrorPrompt(message As String, title As String, Optional timeoutSeconds As Integer = 0)
        TimedErrorPrompt(Nothing, message, title, timeoutSeconds)
    End Sub

    Public Sub TimedErrorPrompt(owner As IWin32Window, message As String, title As String, Optional timeoutSeconds As Integer = 0)
        ShowSingleButtonPrompt(ResolveOwner(owner), message, title, timeoutSeconds, SystemIcons.Error)
    End Sub

    ' =======================================================
    ' INTERNAL SINGLE-BUTTON PROMPT
    ' =======================================================
    Private Sub ShowSingleButtonPrompt(
        owner As IWin32Window,
        message As String,
        title As String,
        timeoutSeconds As Integer,
        icon As Icon)

        Dim useTimeout As Boolean = timeoutSeconds > 0

        Using dlg As New Form()
            ConfigureBaseDialog(dlg, title, 420)

            Dim picIcon As New PictureBox() With {
                .Image = icon.ToBitmap(),
                .Left = 20,
                .Top = 20,
                .SizeMode = PictureBoxSizeMode.AutoSize
            }
            dlg.Controls.Add(picIcon)

            Dim lblMessage = CreateMessageLabel(message, 60, 20, 340)
            dlg.Controls.Add(lblMessage)

            Dim lblCountdown = CreateCountdownLabel(lblMessage.Bottom + 10, useTimeout)
            lblCountdown.Left = 60
            lblCountdown.Width = 340
            dlg.Controls.Add(lblCountdown)

            Dim btnTop = If(useTimeout, lblCountdown.Bottom, lblMessage.Bottom) + 15
            Dim btnOk = CreateButton("OK", 160, btnTop)
            dlg.AcceptButton = btnOk

            AddHandler btnOk.Click, Sub() dlg.Close()
            dlg.Controls.Add(btnOk)

            Dim timer As Timer = Nothing
            If useTimeout Then
                timer = CreateCountdownTimer(
                    timeoutSeconds,
                    Function(sec) $"Closing automatically in {sec} seconds...",
                    Sub() dlg.Close(),
                    lblCountdown)
            End If

            AutoSizeDialog(dlg, btnOk, 20)
            dlg.ShowDialog(owner)
            DisposeTimer(timer)
        End Using
    End Sub

    ' =======================================================
    ' SHARED UI HELPERS
    ' =======================================================

    Private Sub ConfigureBaseDialog(dlg As Form, title As String, width As Integer)
        dlg.Text = title
        dlg.FormBorderStyle = FormBorderStyle.FixedDialog
        dlg.StartPosition = FormStartPosition.CenterParent
        dlg.MinimizeBox = False
        dlg.MaximizeBox = False
        dlg.ControlBox = False
        dlg.ShowInTaskbar = False
        dlg.ClientSize = New Size(width, 100)
    End Sub

    Private Function CreateMessageLabel(text As String, left As Integer, top As Integer, width As Integer) As Label
        Return New Label() With {
            .Left = left,
            .Top = top,
            .Width = width,
            .AutoSize = True,
            .MaximumSize = New Size(width, 0),
            .Text = text
        }
    End Function

    Private Function CreateCountdownLabel(top As Integer, visible As Boolean) As Label
        Return New Label() With {
            .Left = 20,
            .Top = top,
            .Width = 380,
            .Height = 20,
            .Visible = visible
        }
    End Function

    Private Function CreateButton(text As String, left As Integer, top As Integer) As Button
        Return New Button() With {
            .Text = text,
            .Left = left,
            .Top = top,
            .Width = 100
        }
    End Function

    Private Sub AutoSizeDialog(dlg As Form, bottomControl As Control, padding As Integer)
        dlg.ClientSize = New Size(dlg.ClientSize.Width, bottomControl.Bottom + padding)
    End Sub

    Private Function CreateCountdownTimer(
        seconds As Integer,
        textProvider As Func(Of Integer, String),
        onTimeout As Action,
        label As Label) As Timer

        Dim remaining As Integer = seconds
        Dim t As New Timer() With {.Interval = 1000}

        AddHandler t.Tick,
            Sub()
                remaining -= 1
                label.Text = textProvider(remaining)
                If remaining <= 0 Then
                    t.Stop()
                    onTimeout()
                End If
            End Sub

        label.Text = textProvider(remaining)
        t.Start()
        Return t
    End Function

    Private Sub DisposeTimer(t As Timer)
        If t IsNot Nothing Then
            t.Stop()
            t.Dispose()
        End If
    End Sub

End Module
