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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConnectionProfilesForm))
        gbProfiles = New GroupBox()
        lstProfiles = New ListBox()
        gbCurrentConnection = New GroupBox()
        lblDatabase = New Label()
        lblDatabaseCaption = New Label()
        lblServer = New Label()
        lblServerCaption = New Label()
        btnApply = New Button()
        btnSaveCurrentAs = New Button()
        btnDelete = New Button()
        btnRefresh = New Button()
        btnLaunchConfig = New Button()
        btnCancel = New Button()
        gbSelectedConnection = New GroupBox()
        lblSelectedDatabase = New Label()
        lblSelectedDatabaseCaption = New Label()
        lblSelectedServer = New Label()
        lblSelectedServerCaption = New Label()
        btnRename = New Button()
        gbInstructions = New GroupBox()
        lblInstructions = New Label()
        ToolTip1 = New ToolTip(components)
        gbProfiles.SuspendLayout()
        gbCurrentConnection.SuspendLayout()
        gbSelectedConnection.SuspendLayout()
        gbInstructions.SuspendLayout()
        SuspendLayout()
        ' 
        ' gbProfiles
        ' 
        gbProfiles.Controls.Add(lstProfiles)
        gbProfiles.Location = New Point(12, 12)
        gbProfiles.Name = "gbProfiles"
        gbProfiles.Size = New Size(283, 167)
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
        gbCurrentConnection.Location = New Point(12, 182)
        gbCurrentConnection.Name = "gbCurrentConnection"
        gbCurrentConnection.Size = New Size(283, 79)
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
        ' btnApply
        ' 
        btnApply.Location = New Point(518, 291)
        btnApply.Name = "btnApply"
        btnApply.Size = New Size(96, 55)
        btnApply.TabIndex = 2
        btnApply.Tag = "Copies selected profile to PFSConnect.ini"
        btnApply.Text = "Apply"
        ToolTip1.SetToolTip(btnApply, "Apply/Save the Selected Profile to PFSConnect.ini to make it the active connection parameters")
        btnApply.UseVisualStyleBackColor = True
        ' 
        ' btnSaveCurrentAs
        ' 
        btnSaveCurrentAs.Location = New Point(318, 134)
        btnSaveCurrentAs.Name = "btnSaveCurrentAs"
        btnSaveCurrentAs.Size = New Size(96, 55)
        btnSaveCurrentAs.TabIndex = 3
        btnSaveCurrentAs.Tag = "Creates a new profile from the current PFSConnect.ini"
        btnSaveCurrentAs.Text = "Save Current As..."
        ToolTip1.SetToolTip(btnSaveCurrentAs, "Saves the Current Active Connection (PFSConnect.ini) to a new profile")
        btnSaveCurrentAs.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(420, 134)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(96, 55)
        btnDelete.TabIndex = 4
        btnDelete.Tag = "Deletes selected saved profile"
        btnDelete.Text = "Delete"
        ToolTip1.SetToolTip(btnDelete, "Deletes the selected profile data completely")
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(522, 134)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(96, 55)
        btnRefresh.TabIndex = 5
        btnRefresh.Tag = "Reload profile list"
        btnRefresh.Text = "Refresh"
        ToolTip1.SetToolTip(btnRefresh, "Refresh the Saved Connection Profiles list")
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnLaunchConfig
        ' 
        btnLaunchConfig.Location = New Point(321, 291)
        btnLaunchConfig.Name = "btnLaunchConfig"
        btnLaunchConfig.Size = New Size(96, 55)
        btnLaunchConfig.TabIndex = 6
        btnLaunchConfig.Tag = "Launches AdvConfig.exe" & vbCrLf & "`"
        btnLaunchConfig.Text = "Launch CenterEdge Configuration"
        ToolTip1.SetToolTip(btnLaunchConfig, "Launches the CenterEdge Configuration utility that is include with Advantage to create or edit database connection settings")
        btnLaunchConfig.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(620, 291)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(96, 55)
        btnCancel.TabIndex = 7
        btnCancel.Tag = "Cancel"
        btnCancel.Text = "Cancel"
        ToolTip1.SetToolTip(btnCancel, "Discard changes and close this window")
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' gbSelectedConnection
        ' 
        gbSelectedConnection.Controls.Add(lblSelectedDatabase)
        gbSelectedConnection.Controls.Add(lblSelectedDatabaseCaption)
        gbSelectedConnection.Controls.Add(lblSelectedServer)
        gbSelectedConnection.Controls.Add(lblSelectedServerCaption)
        gbSelectedConnection.Location = New Point(12, 267)
        gbSelectedConnection.Name = "gbSelectedConnection"
        gbSelectedConnection.Size = New Size(283, 79)
        gbSelectedConnection.TabIndex = 6
        gbSelectedConnection.TabStop = False
        gbSelectedConnection.Text = "Selected Profile"
        ' 
        ' lblSelectedDatabase
        ' 
        lblSelectedDatabase.AutoSize = True
        lblSelectedDatabase.Location = New Point(95, 53)
        lblSelectedDatabase.Name = "lblSelectedDatabase"
        lblSelectedDatabase.Size = New Size(41, 15)
        lblSelectedDatabase.TabIndex = 5
        lblSelectedDatabase.Text = "Label1"
        ' 
        ' lblSelectedDatabaseCaption
        ' 
        lblSelectedDatabaseCaption.AutoSize = True
        lblSelectedDatabaseCaption.Location = New Point(7, 53)
        lblSelectedDatabaseCaption.Name = "lblSelectedDatabaseCaption"
        lblSelectedDatabaseCaption.Size = New Size(58, 15)
        lblSelectedDatabaseCaption.TabIndex = 4
        lblSelectedDatabaseCaption.Text = "Database:"
        ' 
        ' lblSelectedServer
        ' 
        lblSelectedServer.AutoSize = True
        lblSelectedServer.Location = New Point(95, 29)
        lblSelectedServer.Name = "lblSelectedServer"
        lblSelectedServer.Size = New Size(41, 15)
        lblSelectedServer.TabIndex = 3
        lblSelectedServer.Text = "Label3"
        ' 
        ' lblSelectedServerCaption
        ' 
        lblSelectedServerCaption.AutoSize = True
        lblSelectedServerCaption.Location = New Point(6, 29)
        lblSelectedServerCaption.Name = "lblSelectedServerCaption"
        lblSelectedServerCaption.Size = New Size(42, 15)
        lblSelectedServerCaption.TabIndex = 2
        lblSelectedServerCaption.Text = "Server:"
        ' 
        ' btnRename
        ' 
        btnRename.Location = New Point(624, 134)
        btnRename.Name = "btnRename"
        btnRename.Size = New Size(96, 55)
        btnRename.TabIndex = 10
        btnRename.Tag = "Copies selected profile to PFSConnect.ini"
        btnRename.Text = "Rename"
        ToolTip1.SetToolTip(btnRename, "Rename the selected profile in the list")
        btnRename.UseVisualStyleBackColor = True
        ' 
        ' gbInstructions
        ' 
        gbInstructions.Controls.Add(lblInstructions)
        gbInstructions.Location = New Point(318, 12)
        gbInstructions.Name = "gbInstructions"
        gbInstructions.Size = New Size(397, 116)
        gbInstructions.TabIndex = 11
        gbInstructions.TabStop = False
        gbInstructions.Text = "Quick Start"
        ' 
        ' lblInstructions
        ' 
        lblInstructions.Dock = DockStyle.Fill
        lblInstructions.Location = New Point(3, 19)
        lblInstructions.Name = "lblInstructions"
        lblInstructions.Size = New Size(391, 94)
        lblInstructions.TabIndex = 0
        lblInstructions.Text = resources.GetString("lblInstructions.Text")
        ' 
        ' ConnectionProfilesForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(728, 358)
        Controls.Add(gbInstructions)
        Controls.Add(btnRename)
        Controls.Add(gbSelectedConnection)
        Controls.Add(btnCancel)
        Controls.Add(btnLaunchConfig)
        Controls.Add(btnRefresh)
        Controls.Add(btnDelete)
        Controls.Add(btnSaveCurrentAs)
        Controls.Add(btnApply)
        Controls.Add(gbCurrentConnection)
        Controls.Add(gbProfiles)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "ConnectionProfilesForm"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Connection Profiles"
        gbProfiles.ResumeLayout(False)
        gbCurrentConnection.ResumeLayout(False)
        gbCurrentConnection.PerformLayout()
        gbSelectedConnection.ResumeLayout(False)
        gbSelectedConnection.PerformLayout()
        gbInstructions.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents gbProfiles As GroupBox
    Friend WithEvents lstProfiles As ListBox
    Friend WithEvents gbCurrentConnection As GroupBox
    Friend WithEvents lblDatabase As Label
    Friend WithEvents lblDatabaseCaption As Label
    Friend WithEvents lblServer As Label
    Friend WithEvents lblServerCaption As Label
    Friend WithEvents btnApply As Button
    Friend WithEvents btnSaveCurrentAs As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnLaunchConfig As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents gbSelectedConnection As GroupBox
    Friend WithEvents lblSelectedDatabase As Label
    Friend WithEvents lblSelectedDatabaseCaption As Label
    Friend WithEvents lblSelectedServer As Label
    Friend WithEvents lblSelectedServerCaption As Label
    Friend WithEvents btnRename As Button
    Friend WithEvents gbInstructions As GroupBox
    Friend WithEvents lblInstructions As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
