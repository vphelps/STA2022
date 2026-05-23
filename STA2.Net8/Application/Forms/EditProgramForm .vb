' EditProgramForm.vb
Public Class EditProgramForm
    Public Property Entry As ProgramEntry ' set by the caller

    Private Sub EditProgramForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Entry Is Nothing Then Entry = New ProgramEntry()

        txtName.Text = Entry.Name
        txtPath.Text = Entry.Path
        txtArguments.Text = Entry.Arguments
        txtWorkingDir.Text = Entry.WorkingDirectory
        txtIconPath.Text = Entry.IconPath
        chkRunAsAdmin.Checked = Entry.RunAsAdmin
        chkEnabled.Checked = Entry.Enabled
        chkIncludeInBatch.Checked = Entry.IncludeInBatch
    End Sub

    Private Sub btnBrowsePath_Click(sender As Object, e As EventArgs) Handles btnBrowsePath.Click
        Using dlg As New OpenFileDialog()
            dlg.Title = "Select an application"
            dlg.Filter = "Programs (*.exe)|*.exe|All Files (*.*)|*.*"
            dlg.FilterIndex = 1
            If dlg.ShowDialog() = DialogResult.OK Then
                txtPath.Text = dlg.FileName
                If String.IsNullOrWhiteSpace(txtName.Text) Then
                    txtName.Text = IO.Path.GetFileNameWithoutExtension(dlg.FileName)
                End If
                If String.IsNullOrWhiteSpace(txtWorkingDir.Text) Then
                    txtWorkingDir.Text = IO.Path.GetDirectoryName(dlg.FileName)
                End If
            End If
        End Using
    End Sub

    Private Sub btnBrowseWD_Click(sender As Object, e As EventArgs) Handles btnBrowseWD.Click
        Using fbd As New FolderBrowserDialog()
            If IO.Directory.Exists(txtWorkingDir.Text) Then
                fbd.SelectedPath = txtWorkingDir.Text
            End If
            If fbd.ShowDialog() = DialogResult.OK Then
                txtWorkingDir.Text = fbd.SelectedPath
            End If
        End Using
    End Sub

    Private Sub btnBrowseIcon_Click(sender As Object, e As EventArgs) Handles btnBrowseIcon.Click
        Using dlg As New OpenFileDialog()
            dlg.Title = "Select an icon"
            dlg.Filter = "Icon Files (*.ico)|*.ico|All Files (*.*)|*.*"
            dlg.FilterIndex = 1
            If dlg.ShowDialog() = DialogResult.OK Then
                txtIconPath.Text = dlg.FileName
            End If
        End Using
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus() : Exit Sub
        End If
        If String.IsNullOrWhiteSpace(txtPath.Text) Then
            MessageBox.Show("Path is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPath.Focus() : Exit Sub
        End If

        ' Push values to Entry
        Entry.Name = txtName.Text.Trim()
        Entry.Path = txtPath.Text.Trim()
        Entry.Arguments = txtArguments.Text
        Entry.WorkingDirectory = txtWorkingDir.Text.Trim()
        Entry.IconPath = txtIconPath.Text.Trim()
        Entry.RunAsAdmin = chkRunAsAdmin.Checked
        Entry.Enabled = chkEnabled.Checked
        Entry.IncludeInBatch = chkIncludeInBatch.Checked

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class