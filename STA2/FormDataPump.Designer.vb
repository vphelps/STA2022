<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDataPump
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
        Me.tbDataPumpId = New System.Windows.Forms.TextBox()
        Me.tbDescription = New System.Windows.Forms.TextBox()
        Me.lblDataPumpId = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblIsStandard = New System.Windows.Forms.Label()
        Me.tbIsStandard = New System.Windows.Forms.TextBox()
        Me.lblDestinationId = New System.Windows.Forms.Label()
        Me.tbDestinationId = New System.Windows.Forms.TextBox()
        Me.lblQuery = New System.Windows.Forms.Label()
        Me.tbQuery = New System.Windows.Forms.TextBox()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.tbFileName = New System.Windows.Forms.TextBox()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.tbStartTime = New System.Windows.Forms.TextBox()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.tbInterval = New System.Windows.Forms.TextBox()
        Me.lblEnabled = New System.Windows.Forms.Label()
        Me.tbEnabled = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'tbDataPumpId
        '
        Me.tbDataPumpId.Location = New System.Drawing.Point(99, 33)
        Me.tbDataPumpId.Name = "tbDataPumpId"
        Me.tbDataPumpId.Size = New System.Drawing.Size(514, 20)
        Me.tbDataPumpId.TabIndex = 0
        '
        'tbDescription
        '
        Me.tbDescription.Location = New System.Drawing.Point(99, 73)
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Size = New System.Drawing.Size(514, 20)
        Me.tbDescription.TabIndex = 1
        '
        'lblDataPumpId
        '
        Me.lblDataPumpId.AutoSize = True
        Me.lblDataPumpId.Location = New System.Drawing.Point(33, 36)
        Me.lblDataPumpId.Name = "lblDataPumpId"
        Me.lblDataPumpId.Size = New System.Drawing.Size(66, 13)
        Me.lblDataPumpId.TabIndex = 2
        Me.lblDataPumpId.Text = "DataPumpId"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(33, 76)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 3
        Me.lblDescription.Text = "Description"
        '
        'lblIsStandard
        '
        Me.lblIsStandard.AutoSize = True
        Me.lblIsStandard.Location = New System.Drawing.Point(33, 120)
        Me.lblIsStandard.Name = "lblIsStandard"
        Me.lblIsStandard.Size = New System.Drawing.Size(58, 13)
        Me.lblIsStandard.TabIndex = 4
        Me.lblIsStandard.Text = "IsStandard"
        '
        'tbIsStandard
        '
        Me.tbIsStandard.Location = New System.Drawing.Point(99, 113)
        Me.tbIsStandard.Name = "tbIsStandard"
        Me.tbIsStandard.Size = New System.Drawing.Size(62, 20)
        Me.tbIsStandard.TabIndex = 5
        '
        'lblDestinationId
        '
        Me.lblDestinationId.AutoSize = True
        Me.lblDestinationId.Location = New System.Drawing.Point(33, 156)
        Me.lblDestinationId.Name = "lblDestinationId"
        Me.lblDestinationId.Size = New System.Drawing.Size(69, 13)
        Me.lblDestinationId.TabIndex = 4
        Me.lblDestinationId.Text = "DestinationId"
        '
        'tbDestinationId
        '
        Me.tbDestinationId.Location = New System.Drawing.Point(111, 153)
        Me.tbDestinationId.Name = "tbDestinationId"
        Me.tbDestinationId.Size = New System.Drawing.Size(62, 20)
        Me.tbDestinationId.TabIndex = 5
        '
        'lblQuery
        '
        Me.lblQuery.AutoSize = True
        Me.lblQuery.Location = New System.Drawing.Point(33, 191)
        Me.lblQuery.Name = "lblQuery"
        Me.lblQuery.Size = New System.Drawing.Size(35, 13)
        Me.lblQuery.TabIndex = 6
        Me.lblQuery.Text = "Query"
        '
        'tbQuery
        '
        Me.tbQuery.Location = New System.Drawing.Point(89, 188)
        Me.tbQuery.Multiline = True
        Me.tbQuery.Name = "tbQuery"
        Me.tbQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbQuery.Size = New System.Drawing.Size(647, 110)
        Me.tbQuery.TabIndex = 7
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(33, 311)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(51, 13)
        Me.lblFileName.TabIndex = 8
        Me.lblFileName.Text = "FileName"
        '
        'tbFileName
        '
        Me.tbFileName.Location = New System.Drawing.Point(89, 308)
        Me.tbFileName.Name = "tbFileName"
        Me.tbFileName.Size = New System.Drawing.Size(271, 20)
        Me.tbFileName.TabIndex = 9
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(33, 347)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(52, 13)
        Me.lblStartTime.TabIndex = 10
        Me.lblStartTime.Text = "StartTime"
        '
        'tbStartTime
        '
        Me.tbStartTime.Location = New System.Drawing.Point(92, 339)
        Me.tbStartTime.Name = "tbStartTime"
        Me.tbStartTime.Size = New System.Drawing.Size(181, 20)
        Me.tbStartTime.TabIndex = 11
        '
        'lblInterval
        '
        Me.lblInterval.AutoSize = True
        Me.lblInterval.Location = New System.Drawing.Point(33, 383)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(42, 13)
        Me.lblInterval.TabIndex = 12
        Me.lblInterval.Text = "Interval"
        '
        'tbInterval
        '
        Me.tbInterval.Location = New System.Drawing.Point(81, 380)
        Me.tbInterval.Name = "tbInterval"
        Me.tbInterval.Size = New System.Drawing.Size(100, 20)
        Me.tbInterval.TabIndex = 13
        '
        'lblEnabled
        '
        Me.lblEnabled.AutoSize = True
        Me.lblEnabled.Location = New System.Drawing.Point(36, 423)
        Me.lblEnabled.Name = "lblEnabled"
        Me.lblEnabled.Size = New System.Drawing.Size(46, 13)
        Me.lblEnabled.TabIndex = 14
        Me.lblEnabled.Text = "Enabled"
        '
        'tbEnabled
        '
        Me.tbEnabled.Location = New System.Drawing.Point(81, 420)
        Me.tbEnabled.Name = "tbEnabled"
        Me.tbEnabled.Size = New System.Drawing.Size(100, 20)
        Me.tbEnabled.TabIndex = 15
        '
        'FormDataPump
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 534)
        Me.Controls.Add(Me.tbEnabled)
        Me.Controls.Add(Me.lblEnabled)
        Me.Controls.Add(Me.tbInterval)
        Me.Controls.Add(Me.lblInterval)
        Me.Controls.Add(Me.tbStartTime)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.tbFileName)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.tbQuery)
        Me.Controls.Add(Me.lblQuery)
        Me.Controls.Add(Me.tbDestinationId)
        Me.Controls.Add(Me.lblDestinationId)
        Me.Controls.Add(Me.tbIsStandard)
        Me.Controls.Add(Me.lblIsStandard)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblDataPumpId)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.tbDataPumpId)
        Me.Name = "FormDataPump"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DataPump Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbDataPumpId As TextBox
    Friend WithEvents tbDescription As TextBox
    Friend WithEvents lblDataPumpId As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblIsStandard As Label
    Friend WithEvents tbIsStandard As TextBox
    Friend WithEvents lblDestinationId As Label
    Friend WithEvents tbDestinationId As TextBox
    Friend WithEvents lblQuery As Label
    Friend WithEvents tbQuery As TextBox
    Friend WithEvents lblFileName As Label
    Friend WithEvents tbFileName As TextBox
    Friend WithEvents lblStartTime As Label
    Friend WithEvents tbStartTime As TextBox
    Friend WithEvents lblInterval As Label
    Friend WithEvents tbInterval As TextBox
    Friend WithEvents lblEnabled As Label
    Friend WithEvents tbEnabled As TextBox
End Class
