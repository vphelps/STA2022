<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDataPump
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tbDataPumpId = New System.Windows.Forms.TextBox()
        Me.tbDescription = New System.Windows.Forms.TextBox()
        Me.lblDataPumpId = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblDestinationId = New System.Windows.Forms.Label()
        Me.lblQuery = New System.Windows.Forms.Label()
        Me.tbQuery = New System.Windows.Forms.TextBox()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.tbFileName = New System.Windows.Forms.TextBox()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.btnDpSave = New System.Windows.Forms.Button()
        Me.btnDpCancel = New System.Windows.Forms.Button()
        Me.dgvDataPumpDestinations = New System.Windows.Forms.DataGridView()
        Me.cbIsStandard = New System.Windows.Forms.CheckBox()
        Me.cbEnabled = New System.Windows.Forms.CheckBox()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.nudInterval = New System.Windows.Forms.NumericUpDown()
        CType(Me.dgvDataPumpDestinations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudInterval, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblDataPumpId.TabIndex = 10
        Me.lblDataPumpId.Text = "DataPumpId"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(33, 76)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 11
        Me.lblDescription.Text = "Description"
        '
        'lblDestinationId
        '
        Me.lblDestinationId.AutoSize = True
        Me.lblDestinationId.Location = New System.Drawing.Point(289, 113)
        Me.lblDestinationId.Name = "lblDestinationId"
        Me.lblDestinationId.Size = New System.Drawing.Size(69, 13)
        Me.lblDestinationId.TabIndex = 13
        Me.lblDestinationId.Text = "DestinationId"
        '
        'lblQuery
        '
        Me.lblQuery.AutoSize = True
        Me.lblQuery.Location = New System.Drawing.Point(31, 250)
        Me.lblQuery.Name = "lblQuery"
        Me.lblQuery.Size = New System.Drawing.Size(35, 13)
        Me.lblQuery.TabIndex = 14
        Me.lblQuery.Text = "Query"
        '
        'tbQuery
        '
        Me.tbQuery.Location = New System.Drawing.Point(87, 247)
        Me.tbQuery.Multiline = True
        Me.tbQuery.Name = "tbQuery"
        Me.tbQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbQuery.Size = New System.Drawing.Size(647, 110)
        Me.tbQuery.TabIndex = 4
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(31, 370)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(51, 13)
        Me.lblFileName.TabIndex = 15
        Me.lblFileName.Text = "FileName"
        '
        'tbFileName
        '
        Me.tbFileName.Location = New System.Drawing.Point(87, 367)
        Me.tbFileName.Name = "tbFileName"
        Me.tbFileName.Size = New System.Drawing.Size(271, 20)
        Me.tbFileName.TabIndex = 5
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(31, 406)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(52, 13)
        Me.lblStartTime.TabIndex = 16
        Me.lblStartTime.Text = "StartTime"
        '
        'lblInterval
        '
        Me.lblInterval.AutoSize = True
        Me.lblInterval.Location = New System.Drawing.Point(31, 442)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(42, 13)
        Me.lblInterval.TabIndex = 17
        Me.lblInterval.Text = "Interval"
        '
        'btnDpSave
        '
        Me.btnDpSave.Location = New System.Drawing.Point(569, 466)
        Me.btnDpSave.Name = "btnDpSave"
        Me.btnDpSave.Size = New System.Drawing.Size(75, 23)
        Me.btnDpSave.TabIndex = 9
        Me.btnDpSave.Text = "Save"
        Me.btnDpSave.UseVisualStyleBackColor = True
        '
        'btnDpCancel
        '
        Me.btnDpCancel.Location = New System.Drawing.Point(674, 466)
        Me.btnDpCancel.Name = "btnDpCancel"
        Me.btnDpCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnDpCancel.TabIndex = 10
        Me.btnDpCancel.Text = "Cancel"
        Me.btnDpCancel.UseVisualStyleBackColor = True
        '
        'dgvDataPumpDestinations
        '
        Me.dgvDataPumpDestinations.AllowUserToAddRows = False
        Me.dgvDataPumpDestinations.AllowUserToDeleteRows = False
        Me.dgvDataPumpDestinations.AllowUserToOrderColumns = True
        Me.dgvDataPumpDestinations.AllowUserToResizeColumns = False
        Me.dgvDataPumpDestinations.AllowUserToResizeRows = False
        Me.dgvDataPumpDestinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDataPumpDestinations.ColumnHeadersVisible = False
        Me.dgvDataPumpDestinations.Location = New System.Drawing.Point(381, 99)
        Me.dgvDataPumpDestinations.MultiSelect = False
        Me.dgvDataPumpDestinations.Name = "dgvDataPumpDestinations"
        Me.dgvDataPumpDestinations.ReadOnly = True
        Me.dgvDataPumpDestinations.RowHeadersVisible = False
        Me.dgvDataPumpDestinations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDataPumpDestinations.Size = New System.Drawing.Size(302, 142)
        Me.dgvDataPumpDestinations.TabIndex = 19
        '
        'cbIsStandard
        '
        Me.cbIsStandard.AutoSize = True
        Me.cbIsStandard.Location = New System.Drawing.Point(36, 113)
        Me.cbIsStandard.Name = "cbIsStandard"
        Me.cbIsStandard.Size = New System.Drawing.Size(77, 17)
        Me.cbIsStandard.TabIndex = 22
        Me.cbIsStandard.Text = "IsStandard"
        Me.cbIsStandard.UseVisualStyleBackColor = True
        '
        'cbEnabled
        '
        Me.cbEnabled.AutoSize = True
        Me.cbEnabled.Location = New System.Drawing.Point(34, 478)
        Me.cbEnabled.Name = "cbEnabled"
        Me.cbEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cbEnabled.TabIndex = 23
        Me.cbEnabled.Text = "Enabled"
        Me.cbEnabled.UseVisualStyleBackColor = True
        '
        'dtpStartTime
        '
        Me.dtpStartTime.Location = New System.Drawing.Point(89, 400)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.ShowUpDown = True
        Me.dtpStartTime.Size = New System.Drawing.Size(200, 20)
        Me.dtpStartTime.TabIndex = 24
        '
        'nudInterval
        '
        Me.nudInterval.Location = New System.Drawing.Point(79, 440)
        Me.nudInterval.Maximum = New Decimal(New Integer() {7200, 0, 0, 0})
        Me.nudInterval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudInterval.Name = "nudInterval"
        Me.nudInterval.Size = New System.Drawing.Size(76, 20)
        Me.nudInterval.TabIndex = 25
        Me.nudInterval.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'FormDataPump
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 534)
        Me.Controls.Add(Me.nudInterval)
        Me.Controls.Add(Me.dtpStartTime)
        Me.Controls.Add(Me.cbEnabled)
        Me.Controls.Add(Me.cbIsStandard)
        Me.Controls.Add(Me.dgvDataPumpDestinations)
        Me.Controls.Add(Me.btnDpCancel)
        Me.Controls.Add(Me.btnDpSave)
        Me.Controls.Add(Me.lblInterval)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.tbFileName)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.tbQuery)
        Me.Controls.Add(Me.lblQuery)
        Me.Controls.Add(Me.lblDestinationId)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblDataPumpId)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.tbDataPumpId)
        Me.Name = "FormDataPump"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvDataPumpDestinations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbDataPumpId As TextBox
    Friend WithEvents tbDescription As TextBox
    Friend WithEvents lblDataPumpId As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblDestinationId As Label
    Friend WithEvents lblQuery As Label
    Friend WithEvents tbQuery As TextBox
    Friend WithEvents lblFileName As Label
    Friend WithEvents tbFileName As TextBox
    Friend WithEvents lblStartTime As Label
    Friend WithEvents lblInterval As Label
    Friend WithEvents btnDpSave As Button
    Friend WithEvents btnDpCancel As Button
    Friend WithEvents dgvDataPumpDestinations As DataGridView
    Friend WithEvents cbIsStandard As CheckBox
    Friend WithEvents cbEnabled As CheckBox
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents nudInterval As NumericUpDown
End Class
