
Public Class FormError
    Public Shared errMessage As String
    Public Shared errStack As String

    Private Sub FormError_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbErrMessage.Text = errMessage
        tbErrStack.Text = errStack
        btnClose.Select()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub
End Class