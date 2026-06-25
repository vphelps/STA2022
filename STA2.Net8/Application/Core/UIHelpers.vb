
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

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
    ' TIMED YES / NO PROMPT (PUBLIC OVERLOADS)
    ' =======================================================

    ' No owner, no timeout
    Public Function TimedYesNoPrompt(
        message As String,
        title As String,
        Optional defaultChoice As DialogResult = DialogResult.No,
        Optional icon As Icon = Nothing
    ) As DialogResult
        Return TimedYesNoPrompt(Nothing, message, title, 0, defaultChoice, icon)
    End Function

    ' With owner, no timeout
    Public Function TimedYesNoPrompt(
        owner As IWin32Window,
        message As String,
        title As String,
        Optional defaultChoice As DialogResult = DialogResult.No,
        Optional icon As Icon = Nothing
    ) As DialogResult
        Return TimedYesNoPrompt(owner, message, title, 0, defaultChoice, icon)
    End Function

    ' No owner, with timeout
    Public Function TimedYesNoPrompt(
        message As String,
        title As String,
        timeoutSeconds As Integer,
        Optional defaultChoice As DialogResult = DialogResult.No,
        Optional icon As Icon = Nothing
    ) As DialogResult
        Return TimedYesNoPrompt(Nothing, message, title, timeoutSeconds, defaultChoice, icon)
    End Function

    ' =======================================================
    ' CANONICAL IMPLEMENTATION
    ' =======================================================
    Public Function TimedYesNoPrompt(
        owner As IWin32Window,
        message As String,
        title As String,
        timeoutSeconds As Integer,
        Optional defaultChoice As DialogResult = DialogResult.No,
        Optional icon As Icon = Nothing
    ) As DialogResult

        If defaultChoice <> DialogResult.Yes AndAlso defaultChoice <> DialogResult.No Then
            defaultChoice = DialogResult.No
        End If

        Dim result As DialogResult = defaultChoice
        Dim useTimeout As Boolean = timeoutSeconds > 0
        Dim hasIcon As Boolean = (icon IsNot Nothing)

        Using dlg As New Form()
            ConfigureBaseDialog(dlg, title, If(hasIcon, 520, 440))

            Dim leftMargin As Integer = If(hasIcon, 64, 20)
            Dim textWidth As Integer = If(hasIcon, 420, 380)

            ' Optional icon
            If hasIcon Then
                Dim picIcon As New PictureBox() With {
                    .Image = icon.ToBitmap(),
                    .Left = 20,
                    .Top = 20,
                    .SizeMode = PictureBoxSizeMode.AutoSize
                }
                dlg.Controls.Add(picIcon)
            End If

            Dim lblMessage = CreateMessageLabel(message, leftMargin, 20, textWidth)
            dlg.Controls.Add(lblMessage)

            Dim lblCountdown = CreateCountdownLabel(lblMessage.Bottom + 10, useTimeout)
            lblCountdown.Left = leftMargin
            lblCountdown.Width = textWidth
            dlg.Controls.Add(lblCountdown)

            Dim buttonTop = If(useTimeout, lblCountdown.Bottom, lblMessage.Bottom) + 15

            Dim btnYes = CreateButton("&Yes", If(hasIcon, 170, 120), buttonTop)
            Dim btnNo = CreateButton("&No", If(hasIcon, 290, 230), buttonTop)

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
    ' INFO / WARNING / ERROR PROMPTS (UNCHANGED)
    ' =======================================================

    Public Sub TimedInfoPrompt(message As String, title As String, Optional timeoutSeconds As Integer = 0)
        TimedInfoPrompt(Nothing, message, title, timeoutSeconds)
    End Sub

    Public Sub TimedInfoPrompt(owner As IWin32Window, message As String, title As String, Optional timeoutSeconds As Integer = 0)
        ShowSingleButtonPrompt(ResolveOwner(owner), message, title, timeoutSeconds, SystemIcons.Information)
    End Sub

    Public Sub TimedWarningPrompt(message As String, title As String, Optional timeoutSeconds As Integer = 0)
        TimedWarningPrompt(Nothing, message, title, timeoutSeconds)
    End Sub

    Public Sub TimedWarningPrompt(owner As IWin32Window, message As String, title As String, Optional timeoutSeconds As Integer = 0)
        ShowSingleButtonPrompt(ResolveOwner(owner), message, title, timeoutSeconds, SystemIcons.Warning)
    End Sub


    ' =======================================================
    ' ERROR PROMPTS (UPDATED - NO ICON SUPPORT)
    ' =======================================================

    ' ✅ Legacy overload (no return value)
    Public Sub TimedErrorPrompt(message As String, title As String, Optional timeoutSeconds As Integer = 0)

        TimedErrorPrompt(
        owner:=Nothing,
        message:=message,
        title:=title,
        timeoutSeconds:=timeoutSeconds,
        button1Text:="OK",
        button1Result:=DialogResult.OK)

    End Sub

    Public Sub TimedErrorPrompt(owner As IWin32Window, message As String, title As String, Optional timeoutSeconds As Integer = 0)

        TimedErrorPrompt(
        owner:=owner,
        message:=message,
        title:=title,
        timeoutSeconds:=timeoutSeconds,
        button1Text:="OK",
        button1Result:=DialogResult.OK)

    End Sub


    ' ✅ Overload with configurable buttons (no icons)
    Public Function TimedErrorPrompt(
    message As String,
    title As String,
    timeoutSeconds As Integer,
    button1Text As String,
    button1Result As DialogResult,
    Optional button2Text As String = Nothing,
    Optional button2Result As DialogResult = DialogResult.None,
    Optional button3Text As String = Nothing,
    Optional button3Result As DialogResult = DialogResult.None,
    Optional defaultButtonIndex As Integer = 1,
    Optional cancelButtonIndex As Integer = 2
) As DialogResult

        Return TimedErrorPrompt(
        Nothing,
        message,
        title,
        timeoutSeconds,
        button1Text,
        button1Result,
        button2Text,
        button2Result,
        button3Text,
        button3Result,
        defaultButtonIndex,
        cancelButtonIndex)

    End Function


    ' ✅ CORE IMPLEMENTATION (NO ICON SUPPORT)
    Public Function TimedErrorPrompt(
    owner As IWin32Window,
    message As String,
    title As String,
    timeoutSeconds As Integer,
    button1Text As String,
    button1Result As DialogResult,
    Optional button2Text As String = Nothing,
    Optional button2Result As DialogResult = DialogResult.None,
    Optional button3Text As String = Nothing,
    Optional button3Result As DialogResult = DialogResult.None,
    Optional defaultButtonIndex As Integer = 1,
    Optional cancelButtonIndex As Integer = 2
) As DialogResult

        Dim result As DialogResult = button1Result
        Dim useTimeout As Boolean = (timeoutSeconds > 0)

        Using dlg As New Form()

            ConfigureBaseDialog(dlg, title, 420)

            ' ✅ Icon (dialog icon only)
            Dim picIcon As New PictureBox() With {
            .Image = SystemIcons.Error.ToBitmap(),
            .Left = 20,
            .Top = 20,
            .SizeMode = PictureBoxSizeMode.AutoSize
        }
            dlg.Controls.Add(picIcon)

            ' ✅ Message
            Dim lblMessage = CreateMessageLabel(message, 60, 20, 340)
            dlg.Controls.Add(lblMessage)

            ' ✅ Countdown
            Dim lblCountdown = CreateCountdownLabel(lblMessage.Bottom + 10, useTimeout)
            lblCountdown.Left = 60
            lblCountdown.Width = 340
            dlg.Controls.Add(lblCountdown)

            Dim btnTop = If(useTimeout, lblCountdown.Bottom, lblMessage.Bottom) + 15

            ' ✅ Build buttons
            Dim buttons As New List(Of Button)

            If Not String.IsNullOrWhiteSpace(button1Text) Then
                Dim btn1 = CreateButton(button1Text, 0, btnTop)
                AddHandler btn1.Click, Sub()
                                           result = button1Result
                                           dlg.Close()
                                       End Sub
                buttons.Add(btn1)
            End If

            If Not String.IsNullOrWhiteSpace(button2Text) Then
                Dim btn2 = CreateButton(button2Text, 0, btnTop)
                AddHandler btn2.Click, Sub()
                                           result = button2Result
                                           dlg.Close()
                                       End Sub
                buttons.Add(btn2)
            End If

            If Not String.IsNullOrWhiteSpace(button3Text) Then
                Dim btn3 = CreateButton(button3Text, 0, btnTop)
                AddHandler btn3.Click, Sub()
                                           result = button3Result
                                           dlg.Close()
                                       End Sub
                buttons.Add(btn3)
            End If

            ' ✅ Layout buttons centered
            Dim totalWidth As Integer = (buttons.Count * 100) + ((buttons.Count - 1) * 10)
            Dim startLeft As Integer = (dlg.ClientSize.Width - totalWidth) \ 2

            For i = 0 To buttons.Count - 1
                buttons(i).Left = startLeft + (i * 110)
                dlg.Controls.Add(buttons(i))
            Next

            ' ✅ DEFAULT BUTTON (highlight)
            If defaultButtonIndex >= 1 AndAlso defaultButtonIndex <= buttons.Count Then

                Dim defaultBtn = buttons(defaultButtonIndex - 1)

                dlg.AcceptButton = defaultBtn
                defaultBtn.Select()

                defaultBtn.Font = New Font(defaultBtn.Font, FontStyle.Bold)
                defaultBtn.BackColor = Color.FromArgb(0, 120, 215)
                defaultBtn.ForeColor = Color.White

            End If

            ' ✅ CANCEL BUTTON (Esc)
            If cancelButtonIndex >= 1 AndAlso cancelButtonIndex <= buttons.Count Then
                dlg.CancelButton = buttons(cancelButtonIndex - 1)
            End If

            ' ✅ Normalize other buttons
            For Each btn In buttons
                If btn IsNot dlg.AcceptButton Then
                    btn.BackColor = SystemColors.Control
                    btn.ForeColor = SystemColors.ControlText
                    btn.FlatStyle = FlatStyle.System
                End If
            Next

            ' ✅ Timer
            Dim timer As Timer = Nothing

            If useTimeout Then
                timer = CreateCountdownTimer(
                timeoutSeconds,
                Function(sec) $"Closing in {sec} seconds...",
                Sub()
                    result = button1Result
                    dlg.Close()
                End Sub,
                lblCountdown)
            End If

            AutoSizeDialog(dlg, buttons.Last(), 20)
            dlg.ShowDialog(ResolveOwner(owner))
            DisposeTimer(timer)

        End Using

        Return result

    End Function



    ' =======================================================
    ' INTERNAL SINGLE-BUTTON PROMPT (UNCHANGED)
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
            Dim btnOk = CreateButton("&OK", 160, btnTop)
            dlg.AcceptButton = btnOk

            AddHandler btnOk.Click, Sub() dlg.Close()
            dlg.Controls.Add(btnOk)

            Dim timer As Timer = Nothing
            If useTimeout Then
                timer = CreateCountdownTimer(
                    timeoutSeconds,
                    Function(sec) $"Message closing automatically in {sec} seconds...",
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
    Public Function LoadImageFromAppFolder(fileName As String) As Image
        Try
            Dim base = AppDomain.CurrentDomain.BaseDirectory
            Dim imagesDir = Path.Combine(base, "Application", "Images")
            Dim full = Path.Combine(imagesDir, fileName)

            If Not File.Exists(full) Then
                Return Nothing
            End If

            ' Read into MemoryStream and clone to avoid locking source file
            Using fs As New FileStream(full, FileMode.Open, FileAccess.Read, FileShare.Read)
                Using img = Image.FromStream(fs)
                    Return New Bitmap(img) ' clone
                End Using
            End Using
        Catch
            Return Nothing
        End Try
    End Function


End Module