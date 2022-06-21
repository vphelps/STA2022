Public Class FormWarn
    Public Shared errMessage As String
    Public Shared errStack As String
    Private Sub FormWarn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rtbErrMessage.Text = errMessage
        btnClose.Select()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub
End Class