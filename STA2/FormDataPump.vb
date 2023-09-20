Public Class FormDataPump
    Private Sub FormDataPump_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbDataPumpId.Text = DataPump.DataPumpId.ToString
        tbDescription.Text = DataPump.Description
        tbIsStandard.Text = DataPump.IsStandard.ToString
        tbDestinationId.Text = DataPump.DestinationId
        tbQuery.Text = DataPump.Query
        tbFileName.Text = DataPump.FileName
        tbStartTime.Text = DataPump.StartTime.ToString
        tbInterval.Text = DataPump.Interval
        tbEnabled.Text = DataPump.Enabled.ToString

    End Sub

    Private Sub btnFrmDpCancel_Click(sender As Object, e As EventArgs) Handles btnFrmDpCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnFrmDpSave_Click(sender As Object, e As EventArgs) Handles btnFrmDpSave.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
End Class