<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageInstallerVersionsForm
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
        Me.components = New System.ComponentModel.Container()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.lblExplanation = New System.Windows.Forms.Label()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.clbVersions = New System.Windows.Forms.CheckedListBox()
        Me.btnCleanup = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.managefrmToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSelectAllDeletable = New System.Windows.Forms.Button()
        Me.btnUnselectAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(12, 19)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(39, 13)
        Me.lblPath.TabIndex = 0
        Me.lblPath.Text = "lblPath"
        '
        'lblExplanation
        '
        Me.lblExplanation.AutoSize = True
        Me.lblExplanation.Location = New System.Drawing.Point(12, 63)
        Me.lblExplanation.Name = "lblExplanation"
        Me.lblExplanation.Size = New System.Drawing.Size(72, 13)
        Me.lblExplanation.TabIndex = 1
        Me.lblExplanation.Text = "lblExplanation"
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Location = New System.Drawing.Point(12, 369)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(60, 13)
        Me.lblSummary.TabIndex = 2
        Me.lblSummary.Text = "lblSummary"
        '
        'clbVersions
        '
        Me.clbVersions.CheckOnClick = True
        Me.clbVersions.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbVersions.FormattingEnabled = True
        Me.clbVersions.Location = New System.Drawing.Point(12, 116)
        Me.clbVersions.Name = "clbVersions"
        Me.clbVersions.Size = New System.Drawing.Size(498, 242)
        Me.clbVersions.TabIndex = 3
        '
        'btnCleanup
        '
        Me.btnCleanup.Location = New System.Drawing.Point(516, 251)
        Me.btnCleanup.Name = "btnCleanup"
        Me.btnCleanup.Size = New System.Drawing.Size(80, 50)
        Me.btnCleanup.TabIndex = 4
        Me.btnCleanup.Text = "Clean"
        Me.btnCleanup.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(516, 308)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 50)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSelectAllDeletable
        '
        Me.btnSelectAllDeletable.Location = New System.Drawing.Point(516, 116)
        Me.btnSelectAllDeletable.Name = "btnSelectAllDeletable"
        Me.btnSelectAllDeletable.Size = New System.Drawing.Size(80, 50)
        Me.btnSelectAllDeletable.TabIndex = 6
        Me.btnSelectAllDeletable.Text = "Select All Removable Items"
        Me.btnSelectAllDeletable.UseVisualStyleBackColor = True
        '
        'btnUnselectAll
        '
        Me.btnUnselectAll.Location = New System.Drawing.Point(518, 172)
        Me.btnUnselectAll.Name = "btnUnselectAll"
        Me.btnUnselectAll.Size = New System.Drawing.Size(80, 50)
        Me.btnUnselectAll.TabIndex = 7
        Me.btnUnselectAll.Text = "Unselect All"
        Me.btnUnselectAll.UseVisualStyleBackColor = True
        '
        'ManageInstallerVersionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 450)
        Me.Controls.Add(Me.btnUnselectAll)
        Me.Controls.Add(Me.btnSelectAllDeletable)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCleanup)
        Me.Controls.Add(Me.clbVersions)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.lblExplanation)
        Me.Controls.Add(Me.lblPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ManageInstallerVersionsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Advantage Installer Versions Management"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPath As Label
    Friend WithEvents lblExplanation As Label
    Friend WithEvents lblSummary As Label
    Friend WithEvents clbVersions As CheckedListBox
    Friend WithEvents btnCleanup As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents managefrmToolTip As ToolTip
    Friend WithEvents btnSelectAllDeletable As Button
    Friend WithEvents btnUnselectAll As Button
End Class
