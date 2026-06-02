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
        components = New ComponentModel.Container()
        lblPath = New Label()
        lblExplanation = New Label()
        lblSummary = New Label()
        clbVersions = New CheckedListBox()
        btnCleanup = New Button()
        btnCancel = New Button()
        managefrmToolTip = New ToolTip(components)
        btnSelectAllDeletable = New Button()
        btnUnselectAll = New Button()
        lblDblClickHint = New Label()
        tbCommandPreview = New TextBox()
        SuspendLayout()
        ' 
        ' lblPath
        ' 
        lblPath.AutoSize = True
        lblPath.Location = New Point(14, 22)
        lblPath.Margin = New Padding(4, 0, 4, 0)
        lblPath.Name = "lblPath"
        lblPath.Size = New Size(44, 15)
        lblPath.TabIndex = 0
        lblPath.Text = "lblPath"
        ' 
        ' lblExplanation
        ' 
        lblExplanation.AutoSize = True
        lblExplanation.Location = New Point(14, 73)
        lblExplanation.Margin = New Padding(4, 0, 4, 0)
        lblExplanation.Name = "lblExplanation"
        lblExplanation.Size = New Size(81, 15)
        lblExplanation.TabIndex = 1
        lblExplanation.Text = "lblExplanation"
        ' 
        ' lblSummary
        ' 
        lblSummary.AutoSize = True
        lblSummary.Location = New Point(14, 426)
        lblSummary.Margin = New Padding(4, 0, 4, 0)
        lblSummary.Name = "lblSummary"
        lblSummary.Size = New Size(71, 15)
        lblSummary.TabIndex = 2
        lblSummary.Text = "lblSummary"
        ' 
        ' clbVersions
        ' 
        clbVersions.CheckOnClick = True
        clbVersions.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        clbVersions.FormattingEnabled = True
        clbVersions.Location = New Point(14, 134)
        clbVersions.Margin = New Padding(4, 3, 4, 3)
        clbVersions.Name = "clbVersions"
        clbVersions.Size = New Size(580, 276)
        clbVersions.TabIndex = 3
        ' 
        ' btnCleanup
        ' 
        btnCleanup.Location = New Point(602, 290)
        btnCleanup.Margin = New Padding(4, 3, 4, 3)
        btnCleanup.Name = "btnCleanup"
        btnCleanup.Size = New Size(93, 58)
        btnCleanup.TabIndex = 4
        btnCleanup.Text = "Clean"
        btnCleanup.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(602, 355)
        btnCancel.Margin = New Padding(4, 3, 4, 3)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(93, 58)
        btnCancel.TabIndex = 5
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnSelectAllDeletable
        ' 
        btnSelectAllDeletable.Location = New Point(602, 134)
        btnSelectAllDeletable.Margin = New Padding(4, 3, 4, 3)
        btnSelectAllDeletable.Name = "btnSelectAllDeletable"
        btnSelectAllDeletable.Size = New Size(93, 58)
        btnSelectAllDeletable.TabIndex = 6
        btnSelectAllDeletable.Text = "Select All Removable Items"
        btnSelectAllDeletable.UseVisualStyleBackColor = True
        ' 
        ' btnUnselectAll
        ' 
        btnUnselectAll.Location = New Point(604, 198)
        btnUnselectAll.Margin = New Padding(4, 3, 4, 3)
        btnUnselectAll.Name = "btnUnselectAll"
        btnUnselectAll.Size = New Size(93, 58)
        btnUnselectAll.TabIndex = 7
        btnUnselectAll.Text = "Unselect All"
        btnUnselectAll.UseVisualStyleBackColor = True
        ' 
        ' lblDblClickHint
        ' 
        lblDblClickHint.AutoSize = True
        lblDblClickHint.Location = New Point(411, 495)
        lblDblClickHint.Margin = New Padding(4, 0, 4, 0)
        lblDblClickHint.Name = "lblDblClickHint"
        lblDblClickHint.Size = New Size(288, 15)
        lblDblClickHint.TabIndex = 8
        lblDblClickHint.Text = "Double Click an installer in the list to run that installer"
        ' 
        ' tbCommandPreview
        ' 
        tbCommandPreview.Location = New Point(73, 456)
        tbCommandPreview.Name = "tbCommandPreview"
        tbCommandPreview.Size = New Size(622, 23)
        tbCommandPreview.TabIndex = 9
        tbCommandPreview.Text = "tbCommandPreview"
        ' 
        ' ManageInstallerVersionsForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(712, 519)
        Controls.Add(tbCommandPreview)
        Controls.Add(lblDblClickHint)
        Controls.Add(btnUnselectAll)
        Controls.Add(btnSelectAllDeletable)
        Controls.Add(btnCancel)
        Controls.Add(btnCleanup)
        Controls.Add(clbVersions)
        Controls.Add(lblSummary)
        Controls.Add(lblExplanation)
        Controls.Add(lblPath)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "ManageInstallerVersionsForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Advantage Installer Versions Management"
        ResumeLayout(False)
        PerformLayout()

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
    Friend WithEvents lblDblClickHint As Label
    Friend WithEvents tbCommandPreview As TextBox
End Class
