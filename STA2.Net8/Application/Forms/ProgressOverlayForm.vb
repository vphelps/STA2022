Public Class ProgressOverlayForm

    Public Sub New(message As String)
        InitializeComponent()

        lblMessage.Text = message
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        BringToFront()
        Refresh()
    End Sub
    Public Sub SetMessage(message As String)

        lblMessage.Text = message

        lblMessage.Refresh()

    End Sub
End Class