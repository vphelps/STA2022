<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormError
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
        Me.tbErrMessage = New System.Windows.Forms.TextBox()
        Me.tbErrStack = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblErrMessage = New System.Windows.Forms.Label()
        Me.lblErrStack = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbErrMessage
        '
        Me.tbErrMessage.Location = New System.Drawing.Point(99, 6)
        Me.tbErrMessage.Name = "tbErrMessage"
        Me.tbErrMessage.ReadOnly = True
        Me.tbErrMessage.Size = New System.Drawing.Size(622, 20)
        Me.tbErrMessage.TabIndex = 0
        '
        'tbErrStack
        '
        Me.tbErrStack.Location = New System.Drawing.Point(99, 52)
        Me.tbErrStack.Multiline = True
        Me.tbErrStack.Name = "tbErrStack"
        Me.tbErrStack.ReadOnly = True
        Me.tbErrStack.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbErrStack.Size = New System.Drawing.Size(622, 208)
        Me.tbErrStack.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(646, 266)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblErrMessage
        '
        Me.lblErrMessage.AutoSize = True
        Me.lblErrMessage.Location = New System.Drawing.Point(12, 9)
        Me.lblErrMessage.Name = "lblErrMessage"
        Me.lblErrMessage.Size = New System.Drawing.Size(75, 13)
        Me.lblErrMessage.TabIndex = 4
        Me.lblErrMessage.Text = "Error Message"
        '
        'lblErrStack
        '
        Me.lblErrStack.AutoSize = True
        Me.lblErrStack.Location = New System.Drawing.Point(12, 55)
        Me.lblErrStack.Name = "lblErrStack"
        Me.lblErrStack.Size = New System.Drawing.Size(66, 13)
        Me.lblErrStack.TabIndex = 5
        Me.lblErrStack.Text = "Stack Trace"
        '
        'FormError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(727, 299)
        Me.Controls.Add(Me.lblErrStack)
        Me.Controls.Add(Me.lblErrMessage)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tbErrStack)
        Me.Controls.Add(Me.tbErrMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormError"
        Me.Text = "Application Error"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbErrMessage As TextBox
    Friend WithEvents tbErrStack As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents lblErrMessage As Label
    Friend WithEvents lblErrStack As Label
End Class
