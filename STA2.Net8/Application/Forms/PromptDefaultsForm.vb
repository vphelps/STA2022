Public Class PromptDefaultsForm


    Public Property YesText As String
    Public Property NoText As String
    Public Property SelectedChoiceText As String
    Public Property TimeoutSeconds As Integer
    Public Property IsYesSelected As Boolean

    Private Sub PromptDefaultsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbDefaultYes.Text = YesText
        rbDefaultNo.Text = NoText
        nudTimeoutSeconds.Value = TimeoutSeconds

        ' Default selection (optional)
        rbDefaultYes.Checked = IsYesSelected
        rbDefaultNo.Checked = Not IsYesSelected


    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

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