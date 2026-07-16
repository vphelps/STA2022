<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectionProfilesForm
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
        gbProfiles = New GroupBox()
        lstProfiles = New ListBox()
        gbCurrentConnection = New GroupBox()
        lblDatabase = New Label()
        lblDatabaseCaption = New Label()
        lblServer = New Label()
        lblServerCaption = New Label()
        btnActivate = New Button()
        btnSaveCurrentAs = New Button()
        btnDelete = New Button()
        btnRefresh = New Button()
        btnLaunchConfig = New Button()
        btnClose = New Button()
        lblProfileFolder = New Label()
        tbProfileInfo = New TextBox()
        gbProfiles.SuspendLayout()
        gbCurrentConnection.SuspendLayout()
        SuspendLayout()
        ' 
        ' gbProfiles
        ' 
        gbProfiles.Controls.Add(lstProfiles)
        gbProfiles.Location = New Point(45, 24)
        gbProfiles.Name = "gbProfiles"
        gbProfiles.Size = New Size(470, 167)
        gbProfiles.TabIndex = 0
        gbProfiles.TabStop = False
        gbProfiles.Text = "Saved Connection Profiles"
        ' 
        ' lstProfiles
        ' 
        lstProfiles.FormattingEnabled = True
        lstProfiles.ItemHeight = 15
        lstProfiles.Location = New Point(6, 22)
        lstProfiles.Name = "lstProfiles"
        lstProfiles.Size = New Size(263, 139)
        lstProfiles.TabIndex = 0
        ' 
        ' gbCurrentConnection
        ' 
        gbCurrentConnection.Controls.Add(lblDatabase)
        gbCurrentConnection.Controls.Add(lblDatabaseCaption)
        gbCurrentConnection.Controls.Add(lblServer)
        gbCurrentConnection.Controls.Add(lblServerCaption)
        gbCurrentConnection.Location = New Point(45, 197)
        gbCurrentConnection.Name = "gbCurrentConnection"
        gbCurrentConnection.Size = New Size(452, 114)
        gbCurrentConnection.TabIndex = 1
        gbCurrentConnection.TabStop = False
        gbCurrentConnection.Text = "Current Active Connection"
        ' 
        ' lblDatabase
        ' 
        lblDatabase.AutoSize = True
        lblDatabase.Location = New Point(95, 53)
        lblDatabase.Name = "lblDatabase"
        lblDatabase.Size = New Size(68, 15)
        lblDatabase.TabIndex = 5
        lblDatabase.Text = "lblDatabase"
        ' 
        ' lblDatabaseCaption
        ' 
        lblDatabaseCaption.AutoSize = True
        lblDatabaseCaption.Location = New Point(7, 53)
        lblDatabaseCaption.Name = "lblDatabaseCaption"
        lblDatabaseCaption.Size = New Size(58, 15)
        lblDatabaseCaption.TabIndex = 4
        lblDatabaseCaption.Text = "Database:"
        ' 
        ' lblServer
        ' 
        lblServer.AutoSize = True
        lblServer.Location = New Point(95, 29)
        lblServer.Name = "lblServer"
        lblServer.Size = New Size(52, 15)
        lblServer.TabIndex = 3
        lblServer.Text = "lblServer"
        ' 
        ' lblServerCaption
        ' 
        lblServerCaption.AutoSize = True
        lblServerCaption.Location = New Point(6, 29)
        lblServerCaption.Name = "lblServerCaption"
        lblServerCaption.Size = New Size(42, 15)
        lblServerCaption.TabIndex = 2
        lblServerCaption.Text = "Server:"
        ' 
        ' btnActivate
        ' 
        btnActivate.Location = New Point(654, 24)
        btnActivate.Name = "btnActivate"
        btnActivate.Size = New Size(96, 55)
        btnActivate.TabIndex = 2
        btnActivate.Tag = "Copies selected profile to PFSConnect.ini"
        btnActivate.Text = "Activate"
        btnActivate.UseVisualStyleBackColor = True
        ' 
        ' btnSaveCurrentAs
        ' 
        btnSaveCurrentAs.Location = New Point(654, 85)
        btnSaveCurrentAs.Name = "btnSaveCurrentAs"
        btnSaveCurrentAs.Size = New Size(96, 55)
        btnSaveCurrentAs.TabIndex = 3
        btnSaveCurrentAs.Tag = "Creates a new profile from the current PFSConnect.ini"
        btnSaveCurrentAs.Text = "Save Current As..."
        btnSaveCurrentAs.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(654, 146)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(96, 55)
        btnDelete.TabIndex = 4
        btnDelete.Tag = "Deletes selected saved profile"
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(654, 210)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(96, 55)
        btnRefresh.TabIndex = 5
        btnRefresh.Tag = "Reload profile list"
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnLaunchConfig
        ' 
        btnLaunchConfig.Location = New Point(654, 271)
        btnLaunchConfig.Name = "btnLaunchConfig"
        btnLaunchConfig.Size = New Size(96, 55)
        btnLaunchConfig.TabIndex = 6
        btnLaunchConfig.Tag = "Launches AdvConfig.exe" & vbCrLf & "`"
        btnLaunchConfig.Text = "Launch Configuration"
        btnLaunchConfig.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(654, 335)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(96, 55)
        btnClose.TabIndex = 7
        btnClose.Tag = "Cancel"
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblProfileFolder
        ' 
        lblProfileFolder.AutoSize = True
        lblProfileFolder.Location = New Point(43, 335)
        lblProfileFolder.Name = "lblProfileFolder"
        lblProfileFolder.Size = New Size(199, 15)
        lblProfileFolder.TabIndex = 8
        lblProfileFolder.Text = "C:\PFSCommon\ConnectionProfiles"
        ' 
        ' tbProfileInfo
        ' 
        tbProfileInfo.Location = New Point(231, 393)
        tbProfileInfo.Name = "tbProfileInfo"
        tbProfileInfo.ReadOnly = True
        tbProfileInfo.Size = New Size(100, 23)
        tbProfileInfo.TabIndex = 9
        ' 
        ' ConnectionProfilesForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnClose
        ClientSize = New Size(800, 450)
        Controls.Add(tbProfileInfo)
        Controls.Add(lblProfileFolder)
        Controls.Add(btnClose)
        Controls.Add(btnLaunchConfig)
        Controls.Add(btnRefresh)
        Controls.Add(btnDelete)
        Controls.Add(btnSaveCurrentAs)
        Controls.Add(btnActivate)
        Controls.Add(gbCurrentConnection)
        Controls.Add(gbProfiles)
        MaximizeBox = False
        MinimizeBox = False
        Name = "ConnectionProfilesForm"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Connection Profiles"
        gbProfiles.ResumeLayout(False)
        gbCurrentConnection.ResumeLayout(False)
        gbCurrentConnection.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents gbProfiles As GroupBox
    Friend WithEvents lstProfiles As ListBox
    Friend WithEvents gbCurrentConnection As GroupBox
    Friend WithEvents lblDatabase As Label
    Friend WithEvents lblDatabaseCaption As Label
    Friend WithEvents lblServer As Label
    Friend WithEvents lblServerCaption As Label
    Friend WithEvents btnActivate As Button
    Friend WithEvents btnSaveCurrentAs As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnLaunchConfig As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblProfileFolder As Label
    Friend WithEvents tbProfileInfo As TextBox
End Class
