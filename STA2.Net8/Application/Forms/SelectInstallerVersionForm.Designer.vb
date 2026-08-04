<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectInstallerVersionForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblPrompt = New Label()
        lstVersions = New ListBox()
        btnOk = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' lblPrompt
        ' 
        lblPrompt.AutoSize = True
        lblPrompt.Location = New Point(12, 9)
        lblPrompt.Name = "lblPrompt"
        lblPrompt.Size = New Size(199, 15)
        lblPrompt.TabIndex = 0
        lblPrompt.Text = "Select the installer version to launch:"
        ' 
        ' lstVersions
        ' 
        lstVersions.FormattingEnabled = True
        lstVersions.ItemHeight = 15
        lstVersions.Location = New Point(12, 37)
        lstVersions.Name = "lstVersions"
        lstVersions.Size = New Size(440, 229)
        lstVersions.TabIndex = 1
        ' 
        ' btnOk
        ' 
        btnOk.DialogResult = DialogResult.OK
        btnOk.Location = New Point(12, 272)
        btnOk.Name = "btnOk"
        btnOk.Size = New Size(75, 23)
        btnOk.TabIndex = 2
        btnOk.Text = "Ok"
        btnOk.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.Location = New Point(377, 272)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 3
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' SelectInstallerVersionForm
        ' 
        AcceptButton = btnOk
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(475, 304)
        ControlBox = False
        Controls.Add(btnCancel)
        Controls.Add(btnOk)
        Controls.Add(lstVersions)
        Controls.Add(lblPrompt)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "SelectInstallerVersionForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Database Version Matches"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblPrompt As Label
    Friend WithEvents lstVersions As ListBox
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
End Class
