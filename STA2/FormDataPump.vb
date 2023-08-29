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
End Class