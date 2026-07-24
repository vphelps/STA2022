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
        btnCancel = New Button()
        btnConfirmDelete = New Button()
        lblSpaceSummary = New Label()
        lblMessage = New Label()
        lbVersions = New ListBox()
        lblVersionCount = New Label()
        lblRange = New Label()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(434, 208)
        btnCancel.Margin = New Padding(4, 3, 4, 3)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(93, 58)
        btnCancel.TabIndex = 11
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnConfirmDelete
        ' 
        btnConfirmDelete.Location = New Point(434, 143)
        btnConfirmDelete.Margin = New Padding(4, 3, 4, 3)
        btnConfirmDelete.Name = "btnConfirmDelete"
        btnConfirmDelete.Size = New Size(93, 58)
        btnConfirmDelete.TabIndex = 10
        btnConfirmDelete.Text = "Confirm"
        btnConfirmDelete.UseVisualStyleBackColor = True
        ' 
        ' lblSpaceSummary
        ' 
        lblSpaceSummary.AutoSize = True
        lblSpaceSummary.Location = New Point(14, 283)
        lblSpaceSummary.Margin = New Padding(4, 0, 4, 0)
        lblSpaceSummary.Name = "lblSpaceSummary"
        lblSpaceSummary.Size = New Size(102, 15)
        lblSpaceSummary.TabIndex = 7
        lblSpaceSummary.Text = "lblSpaceSummary"
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Location = New Point(10, 10)
        lblMessage.Margin = New Padding(4, 0, 4, 0)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(66, 15)
        lblMessage.TabIndex = 6
        lblMessage.Text = "lblMessage"
        ' 
        ' lbVersions
        ' 
        lbVersions.FormattingEnabled = True
        lbVersions.ItemHeight = 15
        lbVersions.Location = New Point(14, 81)
        lbVersions.Margin = New Padding(4, 3, 4, 3)
        lbVersions.Name = "lbVersions"
        lbVersions.Size = New Size(412, 184)
        lbVersions.TabIndex = 12
        ' 
        ' lblVersionCount
        ' 
        lblVersionCount.AutoSize = True
        lblVersionCount.Location = New Point(14, 268)
        lblVersionCount.Margin = New Padding(4, 0, 4, 0)
        lblVersionCount.Name = "lblVersionCount"
        lblVersionCount.Size = New Size(91, 15)
        lblVersionCount.TabIndex = 13
        lblVersionCount.Text = "lblVersionCount"
        ' 
        ' lblRange
        ' 
        lblRange.AutoSize = True
        lblRange.Location = New Point(14, 298)
        lblRange.Margin = New Padding(4, 0, 4, 0)
        lblRange.Name = "lblRange"
        lblRange.Size = New Size(53, 15)
        lblRange.TabIndex = 14
        lblRange.Text = "lblRange"
        ' 
        ' ConfirmInstallerVersionCleanupForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(540, 322)
        Controls.Add(lblRange)
        Controls.Add(lblVersionCount)
        Controls.Add(lbVersions)
        Controls.Add(btnCancel)
        Controls.Add(btnConfirmDelete)
        Controls.Add(lblSpaceSummary)
        Controls.Add(lblMessage)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "ConfirmInstallerVersionCleanupForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Confirm Advantage Installer Cleanup"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnConfirmDelete As Button
    Friend WithEvents lblSpaceSummary As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents lbVersions As ListBox
    Friend WithEvents lblVersionCount As Label
    Friend WithEvents lblRange As Label
End Class
