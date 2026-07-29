<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProgressOverlayForm
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
        lblMessage = New Label()
        pnlCard = New Panel()
        btnCancel = New Button()
        lblPercent = New Label()
        pbProgress = New ProgressBar()
        lblTitle = New Label()
        pnlCard.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblMessage.Location = New Point(11, 89)
        lblMessage.Margin = New Padding(4, 0, 4, 0)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(84, 20)
        lblMessage.TabIndex = 0
        lblMessage.Text = "lblMessage"
        lblMessage.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlCard
        ' 
        pnlCard.BackColor = Color.White
        pnlCard.Controls.Add(btnCancel)
        pnlCard.Controls.Add(lblPercent)
        pnlCard.Controls.Add(pbProgress)
        pnlCard.Controls.Add(lblTitle)
        pnlCard.Controls.Add(lblMessage)
        pnlCard.Location = New Point(146, 59)
        pnlCard.Name = "pnlCard"
        pnlCard.Size = New Size(708, 180)
        pnlCard.TabIndex = 1
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(609, 144)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 5
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' lblPercent
        ' 
        lblPercent.AutoSize = True
        lblPercent.Location = New Point(11, 123)
        lblPercent.Name = "lblPercent"
        lblPercent.Size = New Size(60, 15)
        lblPercent.TabIndex = 4
        lblPercent.Text = "lblPercent"
        ' 
        ' pbProgress
        ' 
        pbProgress.Location = New Point(25, 141)
        pbProgress.MarqueeAnimationSpeed = 30
        pbProgress.Name = "pbProgress"
        pbProgress.Size = New Size(519, 23)
        pbProgress.Style = ProgressBarStyle.Continuous
        pbProgress.TabIndex = 3
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(11, 0)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(133, 32)
        lblTitle.TabIndex = 2
        lblTitle.Text = "Working..."
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ProgressOverlayForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        CancelButton = btnCancel
        ClientSize = New Size(933, 519)
        ControlBox = False
        Controls.Add(pnlCard)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 3, 4, 3)
        Name = "ProgressOverlayForm"
        Opacity = 0.75R
        StartPosition = FormStartPosition.Manual
        Text = "ProgressOverlayForm"
        TopMost = True
        pnlCard.ResumeLayout(False)
        pnlCard.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents lblMessage As Label
    Friend WithEvents pnlCard As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pbProgress As ProgressBar
    Friend WithEvents lblPercent As Label
    Friend WithEvents btnCancel As Button
End Class
