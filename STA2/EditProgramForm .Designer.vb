<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditProgramForm
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
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.txtArguments = New System.Windows.Forms.TextBox()
        Me.txtWorkingDir = New System.Windows.Forms.TextBox()
        Me.txtIconPath = New System.Windows.Forms.TextBox()
        Me.chkRunAsAdmin = New System.Windows.Forms.CheckBox()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.chkIncludeInBatch = New System.Windows.Forms.CheckBox()
        Me.btnBrowsePath = New System.Windows.Forms.Button()
        Me.btnBrowseWD = New System.Windows.Forms.Button()
        Me.btnBrowseIcon = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(136, 23)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(219, 20)
        Me.txtName.TabIndex = 0
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(136, 49)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(418, 20)
        Me.txtPath.TabIndex = 1
        '
        'txtArguments
        '
        Me.txtArguments.Location = New System.Drawing.Point(136, 75)
        Me.txtArguments.Name = "txtArguments"
        Me.txtArguments.Size = New System.Drawing.Size(418, 20)
        Me.txtArguments.TabIndex = 2
        '
        'txtWorkingDir
        '
        Me.txtWorkingDir.Location = New System.Drawing.Point(136, 101)
        Me.txtWorkingDir.Name = "txtWorkingDir"
        Me.txtWorkingDir.Size = New System.Drawing.Size(418, 20)
        Me.txtWorkingDir.TabIndex = 3
        '
        'txtIconPath
        '
        Me.txtIconPath.Location = New System.Drawing.Point(136, 127)
        Me.txtIconPath.Name = "txtIconPath"
        Me.txtIconPath.Size = New System.Drawing.Size(418, 20)
        Me.txtIconPath.TabIndex = 4
        '
        'chkRunAsAdmin
        '
        Me.chkRunAsAdmin.AutoSize = True
        Me.chkRunAsAdmin.Location = New System.Drawing.Point(136, 154)
        Me.chkRunAsAdmin.Name = "chkRunAsAdmin"
        Me.chkRunAsAdmin.Size = New System.Drawing.Size(93, 17)
        Me.chkRunAsAdmin.TabIndex = 5
        Me.chkRunAsAdmin.Text = "Run As Admin"
        Me.chkRunAsAdmin.UseVisualStyleBackColor = True
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(136, 177)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(65, 17)
        Me.chkEnabled.TabIndex = 6
        Me.chkEnabled.Text = "Enabled"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'chkIncludeInBatch
        '
        Me.chkIncludeInBatch.AutoSize = True
        Me.chkIncludeInBatch.Location = New System.Drawing.Point(136, 200)
        Me.chkIncludeInBatch.Name = "chkIncludeInBatch"
        Me.chkIncludeInBatch.Size = New System.Drawing.Size(103, 17)
        Me.chkIncludeInBatch.TabIndex = 7
        Me.chkIncludeInBatch.Text = "Include in Batch"
        Me.chkIncludeInBatch.UseVisualStyleBackColor = True
        '
        'btnBrowsePath
        '
        Me.btnBrowsePath.Location = New System.Drawing.Point(594, 19)
        Me.btnBrowsePath.Name = "btnBrowsePath"
        Me.btnBrowsePath.Size = New System.Drawing.Size(103, 23)
        Me.btnBrowsePath.TabIndex = 8
        Me.btnBrowsePath.Text = "Browse path"
        Me.btnBrowsePath.UseVisualStyleBackColor = True
        '
        'btnBrowseWD
        '
        Me.btnBrowseWD.Location = New System.Drawing.Point(594, 57)
        Me.btnBrowseWD.Name = "btnBrowseWD"
        Me.btnBrowseWD.Size = New System.Drawing.Size(103, 23)
        Me.btnBrowseWD.TabIndex = 9
        Me.btnBrowseWD.Text = "Browse Folder"
        Me.btnBrowseWD.UseVisualStyleBackColor = True
        '
        'btnBrowseIcon
        '
        Me.btnBrowseIcon.Location = New System.Drawing.Point(594, 86)
        Me.btnBrowseIcon.Name = "btnBrowseIcon"
        Me.btnBrowseIcon.Size = New System.Drawing.Size(103, 23)
        Me.btnBrowseIcon.TabIndex = 10
        Me.btnBrowseIcon.Text = "Browse Icon"
        Me.btnBrowseIcon.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(594, 120)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(103, 23)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(594, 164)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 23)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Path:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Arguments:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Working Directory:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Icon Path:"
        '
        'EditProgramForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 293)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnBrowseIcon)
        Me.Controls.Add(Me.btnBrowseWD)
        Me.Controls.Add(Me.btnBrowsePath)
        Me.Controls.Add(Me.chkIncludeInBatch)
        Me.Controls.Add(Me.chkEnabled)
        Me.Controls.Add(Me.chkRunAsAdmin)
        Me.Controls.Add(Me.txtIconPath)
        Me.Controls.Add(Me.txtWorkingDir)
        Me.Controls.Add(Me.txtArguments)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.txtName)
        Me.Name = "EditProgramForm"
        Me.Text = "EditProgramForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents txtPath As TextBox
    Friend WithEvents txtArguments As TextBox
    Friend WithEvents txtWorkingDir As TextBox
    Friend WithEvents txtIconPath As TextBox
    Friend WithEvents chkRunAsAdmin As CheckBox
    Friend WithEvents chkEnabled As CheckBox
    Friend WithEvents chkIncludeInBatch As CheckBox
    Friend WithEvents btnBrowsePath As Button
    Friend WithEvents btnBrowseWD As Button
    Friend WithEvents btnBrowseIcon As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
