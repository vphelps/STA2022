<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QaHostingConfigForm
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
        cmbQaHostingMode = New ComboBox()
        chkQaStartServiceWithApp = New CheckBox()
        pnlScriptOptions = New Panel()
        pnlServiceOptions = New Panel()
        gbQaService.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCancel.Location = New Point(808, 300)
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
        gbQaService.Visible = False
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
        btnOk.Location = New Point(727, 300)
        btnOk.Name = "btnOk"
        btnOk.Size = New Size(75, 23)
        btnOk.TabIndex = 5
        btnOk.Text = "Ok"
        btnOk.UseVisualStyleBackColor = True
        ' 
        ' cmbQaHostingMode
        ' 
        cmbQaHostingMode.FormattingEnabled = True
        cmbQaHostingMode.Items.AddRange(New Object() {"None", "Script", "Service"})
        cmbQaHostingMode.Location = New Point(50, 241)
        cmbQaHostingMode.Name = "cmbQaHostingMode"
        cmbQaHostingMode.Size = New Size(233, 23)
        cmbQaHostingMode.TabIndex = 6
        ' 
        ' chkQaStartServiceWithApp
        ' 
        chkQaStartServiceWithApp.AutoSize = True
        chkQaStartServiceWithApp.Location = New Point(50, 202)
        chkQaStartServiceWithApp.Name = "chkQaStartServiceWithApp"
        chkQaStartServiceWithApp.Size = New Size(279, 19)
        chkQaStartServiceWithApp.TabIndex = 7
        chkQaStartServiceWithApp.Text = "Automatically start QA Service with applications"
        chkQaStartServiceWithApp.UseVisualStyleBackColor = True
        ' 
        ' pnlScriptOptions
        ' 
        pnlScriptOptions.Location = New Point(573, 12)
        pnlScriptOptions.Name = "pnlScriptOptions"
        pnlScriptOptions.Size = New Size(200, 100)
        pnlScriptOptions.TabIndex = 8
        ' 
        ' pnlServiceOptions
        ' 
        pnlServiceOptions.Location = New Point(573, 121)
        pnlServiceOptions.Name = "pnlServiceOptions"
        pnlServiceOptions.Size = New Size(200, 100)
        pnlServiceOptions.TabIndex = 9
        ' 
        ' QaHostingConfigForm
        ' 
        AcceptButton = btnOk
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(904, 335)
        ControlBox = False
        Controls.Add(pnlServiceOptions)
        Controls.Add(pnlScriptOptions)
        Controls.Add(chkQaStartServiceWithApp)
        Controls.Add(cmbQaHostingMode)
        Controls.Add(btnOk)
        Controls.Add(cbQaScriptStartWithApp)
        Controls.Add(gbQaService)
        Controls.Add(btnCancel)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximizeBox = False
        MinimizeBox = False
        Name = "QaHostingConfigForm"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "QA Hosting Configuration"
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
    Friend WithEvents cmbQaHostingMode As ComboBox
    Friend WithEvents chkQaStartServiceWithApp As CheckBox
    Friend WithEvents pnlScriptOptions As Panel
    Friend WithEvents pnlServiceOptions As Panel
End Class
