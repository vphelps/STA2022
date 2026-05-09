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

End Class