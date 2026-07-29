Public Class ProgressOverlayForm

    Public Sub New(title As String, message As String)

        InitializeComponent()

        lblTitle.Text = title
        lblMessage.Text = message

    End Sub

    Public Event CancelRequested As EventHandler

    Private Sub btnCancel_Click(
    sender As Object,
    e As EventArgs
) Handles btnCancel.Click

        btnCancel.Enabled = False
        btnCancel.Text = "Cancelling..."

        RaiseEvent CancelRequested(Me, EventArgs.Empty)

    End Sub
    Private Sub CenterCard()

        pnlCard.Location =
        New Point(
            (ClientSize.Width - pnlCard.Width) \ 2,
            (ClientSize.Height - pnlCard.Height) \ 2)
    End Sub
    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        CenterCard()
        BringToFront()
        Refresh()
    End Sub
    Public Sub SetTitle(title As String)

        lblTitle.Text = title

    End Sub
    Public Sub SetMessage(message As String)

        lblMessage.Text = message

        lblMessage.Refresh()

    End Sub

    Public Sub SetProgress(value As Integer)

        value = Math.Max(0, Math.Min(100, value))

        pbProgress.Value = value

        pbProgress.Refresh()
        lblPercent.Text = $"{value}%"
    End Sub
End Class