<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PromptDefaultsForm
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
        gbDefaults1 = New GroupBox()
        rbDefaultNo = New RadioButton()
        rbDefaultYes = New RadioButton()
        nudTimeoutSeconds = New NumericUpDown()
        btnOk = New Button()
        btnCancel = New Button()
        Label1 = New Label()
        gbDefaults1.SuspendLayout()
        CType(nudTimeoutSeconds, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' gbDefaults1
        ' 
        gbDefaults1.Controls.Add(rbDefaultNo)
        gbDefaults1.Controls.Add(rbDefaultYes)
        gbDefaults1.Location = New Point(12, 28)
        gbDefaults1.Name = "gbDefaults1"
        gbDefaults1.Size = New Size(274, 167)
        gbDefaults1.TabIndex = 0
        gbDefaults1.TabStop = False
        gbDefaults1.Text = "gbDefaults1"
        ' 
        ' rbDefaultNo
        ' 
        rbDefaultNo.AutoSize = True
        rbDefaultNo.Location = New Point(40, 50)
        rbDefaultNo.Name = "rbDefaultNo"
        rbDefaultNo.Size = New Size(90, 19)
        rbDefaultNo.TabIndex = 1
        rbDefaultNo.TabStop = True
        rbDefaultNo.Text = "rbDefaultNo"
        rbDefaultNo.UseVisualStyleBackColor = True
        ' 
        ' rbDefaultYes
        ' 
        rbDefaultYes.AutoSize = True
        rbDefaultYes.Location = New Point(40, 25)
        rbDefaultYes.Name = "rbDefaultYes"
        rbDefaultYes.Size = New Size(91, 19)
        rbDefaultYes.TabIndex = 0
        rbDefaultYes.TabStop = True
        rbDefaultYes.Text = "rbDefaultYes"
        rbDefaultYes.UseVisualStyleBackColor = True
        ' 
        ' nudTimeoutSeconds
        ' 
        nudTimeoutSeconds.Location = New Point(67, 211)
        nudTimeoutSeconds.Name = "nudTimeoutSeconds"
        nudTimeoutSeconds.Size = New Size(120, 23)
        nudTimeoutSeconds.TabIndex = 2
        ' 
        ' btnOk
        ' 
        btnOk.Location = New Point(687, 250)
        btnOk.Name = "btnOk"
        btnOk.Size = New Size(75, 23)
        btnOk.TabIndex = 3
        btnOk.Text = "Ok"
        btnOk.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(704, 300)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 4
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(272, 366)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 15)
        Label1.TabIndex = 5
        Label1.Text = "Label1"
        ' 
        ' PromptDefaultsForm
        ' 
        AcceptButton = btnOk
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(867, 494)
        Controls.Add(Label1)
        Controls.Add(btnCancel)
        Controls.Add(btnOk)
        Controls.Add(nudTimeoutSeconds)
        Controls.Add(gbDefaults1)
        Name = "PromptDefaultsForm"
        Text = "PromptDefaultsForm"
        gbDefaults1.ResumeLayout(False)
        gbDefaults1.PerformLayout()
        CType(nudTimeoutSeconds, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents gbDefaults1 As GroupBox
    Friend WithEvents rbDefaultYes As RadioButton
    Friend WithEvents rbDefaultNo As RadioButton
    Friend WithEvents nudTimeoutSeconds As NumericUpDown
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label1 As Label
End Class
