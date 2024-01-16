Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip

Public Class FormDataPump
    Private Sub FormDataPump_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim indexTemp As Integer = DataPump.DestinationId

        tbDataPumpId.Text = DataPump.DataPumpId.ToString
        tbDescription.Text = DataPump.Description
        tbQuery.Text = DataPump.Query
        tbFileName.Text = DataPump.FileName
        dtpStartTime.CustomFormat = "HH:mm"
        dtpStartTime.Format = DateTimePickerFormat.Custom
        dtpStartTime.Value = Convert.ToDateTime(DataPump.StartTime)
        nudInterval.Value = DataPump.Interval
        cbIsStandard.Checked = DataPump.IsStandard
        cbEnabled.Checked = DataPump.Enabled


        If DataPump.DataPumpId = Nothing Then
            tbDataPumpId.Visible = False
            lblDataPumpId.Visible = False

        End If

        dgvDataPumpDestinations.DataSource = DataPumpStorage.DataPumpDestinations.Tables(0)

        For Each row As DataGridViewRow In dgvDataPumpDestinations.Rows
            If row.Cells(0).Value = indexTemp Then
                dgvDataPumpDestinations.ClearSelection()
                row.Selected = True

            Else

            End If
        Next

    End Sub

    Private Sub btnDpCancel_Click(sender As Object, e As EventArgs) Handles btnDpCancel.Click
        Me.Close()
    End Sub

    Private Sub btnDpSave_Click(sender As Object, e As EventArgs) Handles btnDpSave.Click
        DataPump.DataPumpId = Guid.Parse(tbDataPumpId.Text)
        DataPump.Description = tbDescription.Text
        DataPump.Query = tbQuery.Text
        DataPump.FileName = tbFileName.Text
        DataPump.StartTime = dtpStartTime.Value.ToString("HH:mm")
        Integer.TryParse(nudInterval.Value, DataPump.Interval)
        DataPumpHelpers.SaveDataPump(DataPump.DataPumpId, DataPump.Description, DataPump.IsStandard, DataPump.Query, DataPump.FileName, DataPump.StartTime, DataPump.Interval, DataPump.Enabled, DataPump.DestinationId)

        Me.Close()
    End Sub

    Private Sub dgvDataPumpDestinations_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDataPumpDestinations.SelectionChanged
        DataPump.DestinationId = dgvDataPumpDestinations.Rows(dgvDataPumpDestinations.CurrentCell.RowIndex).Cells(0).Value

    End Sub

    Private Sub cbIsStandard_CheckedChanged(sender As Object, e As EventArgs) Handles cbIsStandard.CheckedChanged
        DataPump.IsStandard = cbIsStandard.Checked

    End Sub

    Private Sub cbEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnabled.CheckedChanged
        DataPump.Enabled = cbEnabled.Checked


    End Sub
End Class