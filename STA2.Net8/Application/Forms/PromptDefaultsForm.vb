Public Class PromptDefaultsForm

    Private Const DefaultTitle As String = "Prompt Defaults"

    Public Property YesText As String
    Public Property NoText As String
    Public Property TimeoutSeconds As Integer
    Public Property IsYesSelected As Boolean
    Public Property TitleText As String
    Public Property PromptEnabled As Boolean = True

    Private Sub PromptDefaultsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkEnablePrompt.Checked = PromptEnabled
        rbDefaultYes.Enabled = PromptEnabled
        rbDefaultNo.Enabled = PromptEnabled
        nudTimeoutSeconds.Enabled = PromptEnabled

        gbDefaults1.Text = If(String.IsNullOrWhiteSpace(TitleText), DefaultTitle, TitleText)

        rbDefaultYes.Text = YesText
        rbDefaultNo.Text = NoText

        nudTimeoutSeconds.Minimum = 1
        nudTimeoutSeconds.Maximum = 120

        nudTimeoutSeconds.Value =
        If(TimeoutSeconds > 0, TimeoutSeconds, 10)

        rbDefaultYes.Checked = IsYesSelected
        rbDefaultNo.Checked = Not IsYesSelected

    End Sub

    Private Sub chkEnablePrompt_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnablePrompt.CheckedChanged

        Dim enabled = chkEnablePrompt.Checked

        rbDefaultYes.Enabled = enabled
        rbDefaultNo.Enabled = enabled
        nudTimeoutSeconds.Enabled = enabled
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        PromptEnabled = chkEnablePrompt.Checked
        IsYesSelected = rbDefaultYes.Checked

        TimeoutSeconds = CInt(nudTimeoutSeconds.Value)

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


End Class