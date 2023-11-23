Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip

Public Class FormDataPump
    Private Sub FormDataPump_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbDataPumpId.Text = DataPump.DataPumpId.ToString
        tbDescription.Text = DataPump.Description
        tbIsStandard.Text = DataPump.IsStandard.ToString
        tbDestinationId.Text = DataPump.DestinationId
        tbQuery.Text = DataPump.Query
        tbFileName.Text = DataPump.FileName
        tbStartTime.Text = DataPump.StartTime
        tbInterval.Text = DataPump.Interval
        tbEnabled.Text = DataPump.Enabled.ToString

    End Sub

    Private Sub btnDpCancel_Click(sender As Object, e As EventArgs) Handles btnDpCancel.Click
        Me.Close()
    End Sub

    Private Sub btnDpSave_Click(sender As Object, e As EventArgs) Handles btnDpSave.Click
        DataPump.DataPumpId = Guid.Parse(tbDataPumpId.Text)
        DataPump.Description = tbDescription.Text
        Boolean.TryParse(tbIsStandard.Text, DataPump.IsStandard)
        Integer.TryParse(tbDestinationId.Text, DataPump.DestinationId)
        DataPump.Query = tbQuery.Text
        DataPump.FileName = tbFileName.Text
        DataPump.StartTime = tbStartTime.Text
        Integer.TryParse(tbInterval.Text, DataPump.Interval)
        Boolean.TryParse(tbEnabled.Text, DataPump.Enabled)
        DataPumpHelpers.SaveDataPump(DataPump.DataPumpId, DataPump.Description, DataPump.IsStandard, DataPump.Query, DataPump.FileName, DataPump.StartTime, DataPump.Interval, DataPump.Enabled, DataPump.DestinationId)


        Me.Close()
    End Sub
End Class