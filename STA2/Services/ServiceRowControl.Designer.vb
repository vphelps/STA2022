<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ServiceRowControl
    Inherits System.Windows.Forms.UserControl

    ' Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    ' ==============================
    ' Designer fields (DECLARE ONCE)
    ' ==============================
    Friend WithEvents tblLayout As TableLayoutPanel
    Friend WithEvents picStatus As PictureBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents pnlButtons As FlowLayoutPanel
    Friend WithEvents btnStart As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents btnRestart As Button

    ' ==============================
    ' Clean up any resources being used
    ' ==============================
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ' ==============================
    ' InitializeComponent (ONLY COPY)
    ' ==============================
    <System.Diagnostics.DebuggerNonUserCode()>
    Private Sub InitializeComponent()
        Me.tblLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.picStatus = New System.Windows.Forms.PictureBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pnlButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.tblLayout.SuspendLayout()
        CType(Me.picStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblLayout
        '
        Me.tblLayout.AutoSize = True
        Me.tblLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tblLayout.ColumnCount = 3
        Me.tblLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tblLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblLayout.Controls.Add(Me.picStatus, 0, 0)
        Me.tblLayout.Controls.Add(Me.lblName, 1, 0)
        Me.tblLayout.Controls.Add(Me.lblStatus, 1, 1)
        Me.tblLayout.Controls.Add(Me.pnlButtons, 2, 0)
        Me.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblLayout.Location = New System.Drawing.Point(0, 0)
        Me.tblLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.tblLayout.Name = "tblLayout"
        Me.tblLayout.Padding = New System.Windows.Forms.Padding(2, 4, 6, 4)
        Me.tblLayout.RowCount = 2
        Me.tblLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblLayout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblLayout.Size = New System.Drawing.Size(298, 46)
        Me.tblLayout.TabIndex = 0
        '
        'picStatus
        '
        Me.picStatus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picStatus.Location = New System.Drawing.Point(13, 6)
        Me.picStatus.Margin = New System.Windows.Forms.Padding(4, 2, 6, 2)
        Me.picStatus.Name = "picStatus"
        Me.tblLayout.SetRowSpan(Me.picStatus, 2)
        Me.picStatus.Size = New System.Drawing.Size(36, 36)
        Me.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picStatus.TabIndex = 0
        Me.picStatus.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblName.Location = New System.Drawing.Point(62, 4)
        Me.lblName.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(122, 13)
        Me.lblName.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.Location = New System.Drawing.Point(62, 18)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(122, 26)
        Me.lblStatus.TabIndex = 2
        '
        'pnlButtons
        '
        Me.pnlButtons.AutoSize = True
        Me.pnlButtons.Controls.Add(Me.btnStart)
        Me.pnlButtons.Controls.Add(Me.btnStop)
        Me.pnlButtons.Controls.Add(Me.btnRestart)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlButtons.Location = New System.Drawing.Point(184, 6)
        Me.pnlButtons.Margin = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.pnlButtons.Name = "pnlButtons"
        Me.tblLayout.SetRowSpan(Me.pnlButtons, 2)
        Me.pnlButtons.Size = New System.Drawing.Size(108, 38)
        Me.pnlButtons.TabIndex = 3
        Me.pnlButtons.WrapContents = False
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(0, 0)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(0)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(36, 36)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(36, 0)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(0)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(36, 36)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        '
        'btnRestart
        '
        Me.btnRestart.Location = New System.Drawing.Point(72, 0)
        Me.btnRestart.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(36, 36)
        Me.btnRestart.TabIndex = 2
        Me.btnRestart.Text = "Restart"
        '
        'ServiceRowControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.tblLayout)
        Me.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.MinimumSize = New System.Drawing.Size(300, 48)
        Me.Name = "ServiceRowControl"
        Me.Size = New System.Drawing.Size(298, 46)
        Me.tblLayout.ResumeLayout(False)
        Me.tblLayout.PerformLayout()
        CType(Me.picStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
