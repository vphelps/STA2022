
Public Class FormError
    Public Shared errMessage As String
    Public Shared errStack As String

    Private Sub FormError_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Variables.OfflineMode = True
        tbErrMessage.Text = errMessage
        tbErrStack.Text = errStack
        btnClose.Select()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub FormError_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Variables.OfflineMode = False

    End Sub
End Class