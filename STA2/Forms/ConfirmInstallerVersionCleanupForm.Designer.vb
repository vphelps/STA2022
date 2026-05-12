<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmInstallerVersionCleanupForm
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirmDelete = New System.Windows.Forms.Button()
        Me.lblSpaceSummary = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lbVersions = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(699, 373)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 50)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnConfirmDelete
        '
        Me.btnConfirmDelete.Location = New System.Drawing.Point(699, 315)
        Me.btnConfirmDelete.Name = "btnConfirmDelete"
        Me.btnConfirmDelete.Size = New System.Drawing.Size(80, 50)
        Me.btnConfirmDelete.TabIndex = 10
        Me.btnConfirmDelete.Text = "Confirm"
        Me.btnConfirmDelete.UseVisualStyleBackColor = True
        '
        'lblSpaceSummary
        '
        Me.lblSpaceSummary.AutoSize = True
        Me.lblSpaceSummary.Location = New System.Drawing.Point(12, 179)
        Me.lblSpaceSummary.Name = "lblSpaceSummary"
        Me.lblSpaceSummary.Size = New System.Drawing.Size(91, 13)
        Me.lblSpaceSummary.TabIndex = 7
        Me.lblSpaceSummary.Text = "lblSpaceSummary"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(12, 12)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(60, 13)
        Me.lblMessage.TabIndex = 6
        Me.lblMessage.Text = "lblMessage"
        '
        'lbVersions
        '
        Me.lbVersions.FormattingEnabled = True
        Me.lbVersions.Location = New System.Drawing.Point(425, 6)
        Me.lbVersions.Name = "lbVersions"
        Me.lbVersions.Size = New System.Drawing.Size(354, 303)
        Me.lbVersions.TabIndex = 12
        '
        'ConfirmInstallerVersionCleanupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lbVersions)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirmDelete)
        Me.Controls.Add(Me.lblSpaceSummary)
        Me.Controls.Add(Me.lblMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfirmInstallerVersionCleanupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Confirm Advantage Installer Cleanup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnConfirmDelete As Button
    Friend WithEvents lblSpaceSummary As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents lbVersions As ListBox
End Class
