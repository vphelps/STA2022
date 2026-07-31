<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QAScriptConfigForm
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
        gbQaService = New GroupBox()
        rbQaServiceDeny = New RadioButton()
        rbQaServiceAllow = New RadioButton()
        cbQaScriptStartWithApp = New CheckBox()
        btnOk = New Button()
        gbQaService.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCancel.Location = New Point(227, 141)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 0
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' gbQaService
        ' 
        gbQaService.Controls.Add(rbQaServiceDeny)
        gbQaService.Controls.Add(rbQaServiceAllow)
        gbQaService.Location = New Point(12, 12)
        gbQaService.Name = "gbQaService"
        gbQaService.Size = New Size(223, 78)
        gbQaService.TabIndex = 1
        gbQaService.TabStop = False
        gbQaService.Text = "Allow API Server as Service"
        ' 
        ' rbQaServiceDeny
        ' 
        rbQaServiceDeny.AutoSize = True
        rbQaServiceDeny.Checked = True
        rbQaServiceDeny.Location = New Point(22, 47)
        rbQaServiceDeny.Name = "rbQaServiceDeny"
        rbQaServiceDeny.Size = New Size(41, 19)
        rbQaServiceDeny.TabIndex = 1
        rbQaServiceDeny.TabStop = True
        rbQaServiceDeny.Text = "No"
        rbQaServiceDeny.UseVisualStyleBackColor = True
        ' 
        ' rbQaServiceAllow
        ' 
        rbQaServiceAllow.AutoSize = True
        rbQaServiceAllow.Location = New Point(22, 22)
        rbQaServiceAllow.Name = "rbQaServiceAllow"
        rbQaServiceAllow.Size = New Size(42, 19)
        rbQaServiceAllow.TabIndex = 0
        rbQaServiceAllow.Text = "Yes"
        rbQaServiceAllow.UseVisualStyleBackColor = True
        ' 
        ' cbQaScriptStartWithApp
        ' 
        cbQaScriptStartWithApp.AutoSize = True
        cbQaScriptStartWithApp.Location = New Point(34, 96)
        cbQaScriptStartWithApp.Name = "cbQaScriptStartWithApp"
        cbQaScriptStartWithApp.Size = New Size(179, 19)
        cbQaScriptStartWithApp.TabIndex = 4
        cbQaScriptStartWithApp.Text = "Start QA Script if not running"
        cbQaScriptStartWithApp.UseVisualStyleBackColor = True
        ' 
        ' btnOk
        ' 
        btnOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOk.Location = New Point(146, 141)
        btnOk.Name = "btnOk"
        btnOk.Size = New Size(75, 23)
        btnOk.TabIndex = 5
        btnOk.Text = "Ok"
        btnOk.UseVisualStyleBackColor = True
        ' 
        ' QAScriptConfigForm
        ' 
        AcceptButton = btnOk
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(323, 176)
        ControlBox = False
        Controls.Add(btnOk)
        Controls.Add(cbQaScriptStartWithApp)
        Controls.Add(gbQaService)
        Controls.Add(btnCancel)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximizeBox = False
        MinimizeBox = False
        Name = "QAScriptConfigForm"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "QA API Script "
        TopMost = True
        gbQaService.ResumeLayout(False)
        gbQaService.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents gbQaService As GroupBox
    Friend WithEvents rbQaServiceDeny As RadioButton
    Friend WithEvents rbQaServiceAllow As RadioButton
    Friend WithEvents cbQaScriptStartWithApp As CheckBox
    Friend WithEvents btnOk As Button
End Class
