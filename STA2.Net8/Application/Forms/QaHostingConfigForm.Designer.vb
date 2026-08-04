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
        cbQaScriptStartWithApp = New CheckBox()
        btnOk = New Button()
        cmbQaHostingMode = New ComboBox()
        chkQaStartServiceWithApp = New CheckBox()
        lblQaHostingMode = New Label()
        gbQaHostingModeOptions = New GroupBox()
        lblQaScriptStartupTimeoutSeconds = New Label()
        nudQaScriptStartupTimeoutSeconds = New NumericUpDown()
        lblTimeoutRange = New Label()
        gbQaHostingModeOptions.SuspendLayout()
        CType(nudQaScriptStartupTimeoutSeconds, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnCancel.Location = New Point(305, 157)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 0
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' cbQaScriptStartWithApp
        ' 
        cbQaScriptStartWithApp.AutoSize = True
        cbQaScriptStartWithApp.Location = New Point(6, 22)
        cbQaScriptStartWithApp.Name = "cbQaScriptStartWithApp"
        cbQaScriptStartWithApp.Size = New Size(179, 19)
        cbQaScriptStartWithApp.TabIndex = 4
        cbQaScriptStartWithApp.Text = "Start QA Script if not running"
        cbQaScriptStartWithApp.UseVisualStyleBackColor = True
        ' 
        ' btnOk
        ' 
        btnOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOk.Location = New Point(224, 157)
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
        cmbQaHostingMode.Location = New Point(142, 6)
        cmbQaHostingMode.Name = "cmbQaHostingMode"
        cmbQaHostingMode.Size = New Size(233, 23)
        cmbQaHostingMode.TabIndex = 6
        ' 
        ' chkQaStartServiceWithApp
        ' 
        chkQaStartServiceWithApp.AutoSize = True
        chkQaStartServiceWithApp.Location = New Point(6, 47)
        chkQaStartServiceWithApp.Name = "chkQaStartServiceWithApp"
        chkQaStartServiceWithApp.Size = New Size(280, 19)
        chkQaStartServiceWithApp.TabIndex = 7
        chkQaStartServiceWithApp.Text = "Automatically start API Service with applications"
        chkQaStartServiceWithApp.UseVisualStyleBackColor = True
        ' 
        ' lblQaHostingMode
        ' 
        lblQaHostingMode.AutoSize = True
        lblQaHostingMode.Location = New Point(12, 9)
        lblQaHostingMode.Name = "lblQaHostingMode"
        lblQaHostingMode.Size = New Size(124, 15)
        lblQaHostingMode.TabIndex = 8
        lblQaHostingMode.Text = "QA Api Hosting Mode"
        ' 
        ' gbQaHostingModeOptions
        ' 
        gbQaHostingModeOptions.Controls.Add(cbQaScriptStartWithApp)
        gbQaHostingModeOptions.Controls.Add(chkQaStartServiceWithApp)
        gbQaHostingModeOptions.Location = New Point(12, 35)
        gbQaHostingModeOptions.Name = "gbQaHostingModeOptions"
        gbQaHostingModeOptions.Size = New Size(284, 76)
        gbQaHostingModeOptions.TabIndex = 9
        gbQaHostingModeOptions.TabStop = False
        gbQaHostingModeOptions.Text = "Hosting Mode Options"
        ' 
        ' lblQaScriptStartupTimeoutSeconds
        ' 
        lblQaScriptStartupTimeoutSeconds.AutoSize = True
        lblQaScriptStartupTimeoutSeconds.Location = New Point(11, 124)
        lblQaScriptStartupTimeoutSeconds.Name = "lblQaScriptStartupTimeoutSeconds"
        lblQaScriptStartupTimeoutSeconds.Size = New Size(123, 15)
        lblQaScriptStartupTimeoutSeconds.TabIndex = 10
        lblQaScriptStartupTimeoutSeconds.Text = "Timeout (in Seconds):"
        ' 
        ' nudQaScriptStartupTimeoutSeconds
        ' 
        nudQaScriptStartupTimeoutSeconds.Location = New Point(142, 122)
        nudQaScriptStartupTimeoutSeconds.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        nudQaScriptStartupTimeoutSeconds.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudQaScriptStartupTimeoutSeconds.Name = "nudQaScriptStartupTimeoutSeconds"
        nudQaScriptStartupTimeoutSeconds.Size = New Size(91, 23)
        nudQaScriptStartupTimeoutSeconds.TabIndex = 11
        nudQaScriptStartupTimeoutSeconds.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblTimeoutRange
        ' 
        lblTimeoutRange.AutoSize = True
        lblTimeoutRange.Location = New Point(12, 148)
        lblTimeoutRange.Name = "lblTimeoutRange"
        lblTimeoutRange.Size = New Size(141, 15)
        lblTimeoutRange.TabIndex = 12
        lblTimeoutRange.Text = "Range is 1 to 600 seconds"
        ' 
        ' QaHostingConfigForm
        ' 
        AcceptButton = btnOk
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(401, 192)
        ControlBox = False
        Controls.Add(lblTimeoutRange)
        Controls.Add(nudQaScriptStartupTimeoutSeconds)
        Controls.Add(lblQaScriptStartupTimeoutSeconds)
        Controls.Add(gbQaHostingModeOptions)
        Controls.Add(lblQaHostingMode)
        Controls.Add(cmbQaHostingMode)
        Controls.Add(btnOk)
        Controls.Add(btnCancel)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximizeBox = False
        MinimizeBox = False
        Name = "QaHostingConfigForm"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "QA Hosting Configuration"
        TopMost = True
        gbQaHostingModeOptions.ResumeLayout(False)
        gbQaHostingModeOptions.PerformLayout()
        CType(nudQaScriptStartupTimeoutSeconds, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents cbQaScriptStartWithApp As CheckBox
    Friend WithEvents btnOk As Button
    Friend WithEvents cmbQaHostingMode As ComboBox
    Friend WithEvents chkQaStartServiceWithApp As CheckBox
    Friend WithEvents lblQaHostingMode As Label
    Friend WithEvents gbQaHostingModeOptions As GroupBox
    Friend WithEvents lblQaScriptStartupTimeoutSeconds As Label
    Friend WithEvents nudQaScriptStartupTimeoutSeconds As NumericUpDown
    Friend WithEvents lblTimeoutRange As Label
End Class
