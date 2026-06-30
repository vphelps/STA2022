<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        btnExit = New Button()
        SplitContainer1 = New SplitContainer()
        tcSTA = New TabControl()
        tpGeneral = New TabPage()
        gpLicInfo = New GroupBox()
        lblPcDbInfo = New Label()
        tbPcDbInfo = New TextBox()
        tbShiftDate = New TextBox()
        tbLocName = New TextBox()
        lblCoreSvr = New Label()
        lblShiftDate = New Label()
        tbCoreSvr = New TextBox()
        tbLicSvr = New TextBox()
        tbWebEnabled = New TextBox()
        lblDbVer = New Label()
        lblLicSvr = New Label()
        lblWebEnabled = New Label()
        tbDbVer = New TextBox()
        lblLocName = New Label()
        gbLiveOutput = New GroupBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        btnCopyScriptOutput = New Button()
        tbOutputScript = New TextBox()
        rtbLiveOutput = New RichTextBox()
        pnlServicesContainer = New Panel()
        tblServices = New TableLayoutPanel()
        tbServicesButtonsHelpMessage = New TextBox()
        gbFlavorsList = New GroupBox()
        btnFlavorFileCopy = New Button()
        btnFlavorsListRefresh = New Button()
        pnlFlavorsList = New Panel()
        lbFlavorsList = New ListBox()
        cmsApplySingleFlavor = New ContextMenuStrip(components)
        miApplySingleFlavor = New ToolStripMenuItem()
        tsmiApplyDefaultFlavors = New ToolStripMenuItem()
        tpAdvData = New TabPage()
        btnSaveWebOptionsCSV = New Button()
        btnSaveAppotionsCSV = New Button()
        btnSaveApplicationInfoCSV = New Button()
        lblApplicationInfo = New Label()
        dgvApplicationInfo = New DataGridView()
        DataGridViewTextBoxColumn3 = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn4 = New DataGridViewTextBoxColumn()
        lblWebOptions = New Label()
        btnRefreshAdvDataTab = New Button()
        lblAppOptions = New Label()
        dgvWebOptions = New DataGridView()
        DataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
        dgvAppOptions = New DataGridView()
        OptionName = New DataGridViewTextBoxColumn()
        OptionValue = New DataGridViewTextBoxColumn()
        tpDbLogs = New TabPage()
        tlpLogData = New TableLayoutPanel()
        gpDbLogCount = New GroupBox()
        dgvDbLogCount = New DataGridView()
        gpDbLogData = New GroupBox()
        dgvDbLogData = New DataGridView()
        pnlDbLogs = New Panel()
        gpMessageLogFilters = New GroupBox()
        lblMsgLogNumRows = New Label()
        lblMsgLogEndDate = New Label()
        lblMsgLogStartDate = New Label()
        cbMsgLogDateRange = New CheckBox()
        nudMsgLog = New NumericUpDown()
        cbMsgLogShowErrorsOnly = New CheckBox()
        dtpMsgLogTimeTo = New DateTimePicker()
        dtpMsgLogTimeFrom = New DateTimePicker()
        dtpMsgLogDateTo = New DateTimePicker()
        dtpMsgLogDateFrom = New DateTimePicker()
        btnDbLogRefresh = New Button()
        rbMessageLog = New RadioButton()
        rbWebCloudUpdates = New RadioButton()
        tpDbInfo = New TabPage()
        pnlDbInfoButtons = New Panel()
        rbDbDeadlocks = New RadioButton()
        rbDbSizeByDay = New RadioButton()
        btnDbInfoRefresh = New Button()
        rbDbFragmentation = New RadioButton()
        rbDbTableSize = New RadioButton()
        pnlDbData = New Panel()
        dgvDbTableSize = New DataGridView()
        tpStParse = New TabPage()
        Panel1 = New Panel()
        btnStCopy = New Button()
        btnStPaste = New Button()
        btnStParse = New Button()
        btnSTClear = New Button()
        tbSTParse = New TextBox()
        tpLogs = New TabPage()
        tlpApplicationLogs = New TableLayoutPanel()
        rtbLogs = New RichTextBox()
        flpAppLogsButtons = New FlowLayoutPanel()
        btnViewLatestLog = New Button()
        btnOpenLogFile = New Button()
        btnLastLogBlock = New Button()
        btnLastFailed = New Button()
        tpFlavor = New TabPage()
        Panel3 = New Panel()
        tbFlavorHints = New TextBox()
        lblPersonalFlavorFile = New Label()
        flpFlavorButtons = New FlowLayoutPanel()
        btnFlavorLoad = New Button()
        btnFlavorSave = New Button()
        btnFlavorClear = New Button()
        btnFlavorPaste = New Button()
        tbFlavor = New TextBox()
        tpOptions = New TabPage()
        tbMLTest1 = New TextBox()
        gpFlavorsSettings = New GroupBox()
        btnSaveFlavorDefaults = New Button()
        clbSqlFiles = New CheckedListBox()
        btnResetFlavorDefaults = New Button()
        gbAppLaunchSettings = New GroupBox()
        flpAppListButtons = New FlowLayoutPanel()
        btnAdd = New Button()
        btnEdit = New Button()
        btnDelete = New Button()
        btnLaunch = New Button()
        lblPrgListbox = New Label()
        lstPrograms = New ListBox()
        cmsQuickLaunch = New ContextMenuStrip(components)
        cmsQuickLaunchSlot1 = New ToolStripMenuItem()
        cmsQuickLaunchSlot2 = New ToolStripMenuItem()
        gbAppOptions = New GroupBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        btnBackupScriptPath = New Button()
        tbBackupScriptPath = New TextBox()
        lblBackupPathOverride = New Label()
        btnBackupPathOverride = New Button()
        tbBackupPathOverride = New TextBox()
        btnBrowseApplyScript = New Button()
        lblBackupScriptPath = New Label()
        btnBrowseStartScript = New Button()
        tbApplyFlavorDefault = New TextBox()
        tbDatabaseStartDefault = New TextBox()
        tbWindowTitle = New TextBox()
        lblApplyFlavorDefault = New Label()
        tbRepoFolder = New TextBox()
        lblDatabaseStartDefault = New Label()
        btnRepoFolder = New Button()
        lblRepoFolder = New Label()
        lblSetupSwitches = New Label()
        tbSetupSwitches = New TextBox()
        lblWindowTitle = New Label()
        cbShowHiddenServices = New CheckBox()
        lblShowHiddenServices = New Label()
        lblRunQaCmdLine = New Label()
        btnRunQaCmdLine = New Button()
        tbRunQaCmdLine = New TextBox()
        gpAdvUpgrade = New GroupBox()
        lblAdvUpgrade = New Label()
        tbAdvupgrade = New TextBox()
        cbAdvUpgradeNoBackup = New CheckBox()
        cbAdvUpgradeNoSetup = New CheckBox()
        cbAdvUpgradeQuiet = New CheckBox()
        pnlButtonCollection = New Panel()
        btnTest3 = New Button()
        gpDBStartVersion = New GroupBox()
        cbDbUseVersion = New CheckBox()
        tbDbUseVersion = New TextBox()
        btnDbUseAdvVersion = New Button()
        btnTest2 = New Button()
        gbAdvApps = New GroupBox()
        tlpButtons1 = New TableLayoutPanel()
        btnAdvUpgrade = New Button()
        btnAdvKiosk = New Button()
        btnAdvCardTech = New Button()
        btnAdvRedeem = New Button()
        btnAdvReportEditor = New Button()
        btnAdvConfig = New Button()
        btnAdvKioskSetup = New Button()
        btnAdvGroups = New Button()
        btnPos = New Button()
        btnAdvManager = New Button()
        btnTest1 = New Button()
        gpCommonApps = New GroupBox()
        tlpButtons2 = New TableLayoutPanel()
        btnServices = New Button()
        btnCalc = New Button()
        btnEventViewer = New Button()
        btnDevices = New Button()
        btnTaskmgr = New Button()
        btnAppWiz = New Button()
        tbTest1 = New TextBox()
        tbTest2 = New TextBox()
        tbTest3 = New TextBox()
        btnRunDatabaseStartLive = New Button()
        cmsDbStart = New ContextMenuStrip(components)
        tsmiStartDbRaw = New ToolStripMenuItem()
        tsmiStartDbBackup = New ToolStripMenuItem()
        cmsDbStartSeparator1 = New ToolStripSeparator()
        tsmiBackupDb = New ToolStripMenuItem()
        btnRunApplyFlavorLive = New Button()
        cmbboxAppLaunch = New ComboBox()
        btnComboAppLaunch = New Button()
        btnReconnect = New Button()
        flpQuickLaunch = New FlowLayoutPanel()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        Button8 = New Button()
        Button9 = New Button()
        Button10 = New Button()
        Button11 = New Button()
        Button12 = New Button()
        Button13 = New Button()
        Button14 = New Button()
        Button15 = New Button()
        Button16 = New Button()
        Button17 = New Button()
        Button18 = New Button()
        Button19 = New Button()
        Button20 = New Button()
        btnAdminRestart = New Button()
        btnBatchLaunch = New Button()
        StatusStrip1 = New StatusStrip()
        tslblTime = New ToolStripStatusLabel()
        tslblCeVersion = New ToolStripStatusLabel()
        tslblNetVersion = New ToolStripStatusLabel()
        tslblExecutionStatus = New ToolStripStatusLabel()
        tslblDbState = New ToolStripStatusLabel()
        tmr10Seconds = New Timer(components)
        BottomToolStripPanel = New ToolStripPanel()
        TopToolStripPanel = New ToolStripPanel()
        RightToolStripPanel = New ToolStripPanel()
        LeftToolStripPanel = New ToolStripPanel()
        ContentPanel = New ToolStripContentPanel()
        tmr1Sec = New Timer(components)
        ToolTipForQuickButtons = New ToolTip(components)
        SplitContainer2 = New SplitContainer()
        pnlButtonsLabel = New Panel()
        lblButtons = New Label()
        pnlButtons = New Panel()
        tlpButtons3 = New TableLayoutPanel()
        btnRunQaApi = New Button()
        cmsRunQaApi = New ContextMenuStrip(components)
        tsmiRunQaApiRerunScript = New ToolStripMenuItem()
        tsmiQaScriptKill = New ToolStripMenuItem()
        cmsSeparator1 = New ToolStripSeparator()
        tsmiQaMenuPromptDefaults = New ToolStripMenuItem()
        btnUpdateShiftDate = New Button()
        btnRepoMain = New Button()
        btnSetupInstall = New Button()
        btnLaunchLatestInstaller = New Button()
        btnRepoDiscardChanges = New Button()
        btnManageInstallerVersions = New Button()
        btnApplyPersonalFlavor = New Button()
        Panel2 = New Panel()
        ofdStartScript = New OpenFileDialog()
        ToolTip1 = New ToolTip(components)
        staFolderBrowserDialog = New FolderBrowserDialog()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        tcSTA.SuspendLayout()
        tpGeneral.SuspendLayout()
        gpLicInfo.SuspendLayout()
        gbLiveOutput.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        pnlServicesContainer.SuspendLayout()
        gbFlavorsList.SuspendLayout()
        pnlFlavorsList.SuspendLayout()
        cmsApplySingleFlavor.SuspendLayout()
        tpAdvData.SuspendLayout()
        CType(dgvApplicationInfo, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvWebOptions, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvAppOptions, ComponentModel.ISupportInitialize).BeginInit()
        tpDbLogs.SuspendLayout()
        tlpLogData.SuspendLayout()
        gpDbLogCount.SuspendLayout()
        CType(dgvDbLogCount, ComponentModel.ISupportInitialize).BeginInit()
        gpDbLogData.SuspendLayout()
        CType(dgvDbLogData, ComponentModel.ISupportInitialize).BeginInit()
        pnlDbLogs.SuspendLayout()
        gpMessageLogFilters.SuspendLayout()
        CType(nudMsgLog, ComponentModel.ISupportInitialize).BeginInit()
        tpDbInfo.SuspendLayout()
        pnlDbInfoButtons.SuspendLayout()
        pnlDbData.SuspendLayout()
        CType(dgvDbTableSize, ComponentModel.ISupportInitialize).BeginInit()
        tpStParse.SuspendLayout()
        Panel1.SuspendLayout()
        tpLogs.SuspendLayout()
        tlpApplicationLogs.SuspendLayout()
        flpAppLogsButtons.SuspendLayout()
        tpFlavor.SuspendLayout()
        Panel3.SuspendLayout()
        flpFlavorButtons.SuspendLayout()
        tpOptions.SuspendLayout()
        gpFlavorsSettings.SuspendLayout()
        gbAppLaunchSettings.SuspendLayout()
        flpAppListButtons.SuspendLayout()
        cmsQuickLaunch.SuspendLayout()
        gbAppOptions.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        gpAdvUpgrade.SuspendLayout()
        pnlButtonCollection.SuspendLayout()
        gpDBStartVersion.SuspendLayout()
        gbAdvApps.SuspendLayout()
        tlpButtons1.SuspendLayout()
        gpCommonApps.SuspendLayout()
        tlpButtons2.SuspendLayout()
        cmsDbStart.SuspendLayout()
        flpQuickLaunch.SuspendLayout()
        StatusStrip1.SuspendLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.Panel1.SuspendLayout()
        SplitContainer2.Panel2.SuspendLayout()
        SplitContainer2.SuspendLayout()
        pnlButtonsLabel.SuspendLayout()
        pnlButtons.SuspendLayout()
        tlpButtons3.SuspendLayout()
        cmsRunQaApi.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnExit
        ' 
        btnExit.DialogResult = DialogResult.Cancel
        btnExit.Dock = DockStyle.Fill
        btnExit.Location = New Point(290, 173)
        btnExit.Margin = New Padding(0)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(96, 55)
        btnExit.TabIndex = 0
        btnExit.Text = "Exit"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        SplitContainer1.BorderStyle = BorderStyle.Fixed3D
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Margin = New Padding(4, 3, 4, 3)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(tcSTA)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.BackColor = Color.Gray
        SplitContainer1.Panel2.Controls.Add(pnlButtonCollection)
        SplitContainer1.Panel2MinSize = 220
        SplitContainer1.Size = New Size(1194, 884)
        SplitContainer1.SplitterDistance = 661
        SplitContainer1.SplitterWidth = 3
        SplitContainer1.TabIndex = 10
        ' 
        ' tcSTA
        ' 
        tcSTA.Controls.Add(tpGeneral)
        tcSTA.Controls.Add(tpAdvData)
        tcSTA.Controls.Add(tpDbLogs)
        tcSTA.Controls.Add(tpDbInfo)
        tcSTA.Controls.Add(tpStParse)
        tcSTA.Controls.Add(tpLogs)
        tcSTA.Controls.Add(tpFlavor)
        tcSTA.Controls.Add(tpOptions)
        tcSTA.Dock = DockStyle.Fill
        tcSTA.Location = New Point(0, 0)
        tcSTA.Margin = New Padding(4, 3, 4, 3)
        tcSTA.Name = "tcSTA"
        tcSTA.SelectedIndex = 0
        tcSTA.Size = New Size(1190, 657)
        tcSTA.TabIndex = 11
        ' 
        ' tpGeneral
        ' 
        tpGeneral.BackColor = Color.Gray
        tpGeneral.Controls.Add(gpLicInfo)
        tpGeneral.Controls.Add(gbLiveOutput)
        tpGeneral.Controls.Add(pnlServicesContainer)
        tpGeneral.Controls.Add(gbFlavorsList)
        tpGeneral.Location = New Point(4, 24)
        tpGeneral.Margin = New Padding(4, 3, 4, 3)
        tpGeneral.Name = "tpGeneral"
        tpGeneral.Padding = New Padding(4, 3, 4, 3)
        tpGeneral.Size = New Size(1182, 629)
        tpGeneral.TabIndex = 0
        tpGeneral.Text = "General"
        ' 
        ' gpLicInfo
        ' 
        gpLicInfo.BackColor = Color.LightGray
        gpLicInfo.Controls.Add(lblPcDbInfo)
        gpLicInfo.Controls.Add(tbPcDbInfo)
        gpLicInfo.Controls.Add(tbShiftDate)
        gpLicInfo.Controls.Add(tbLocName)
        gpLicInfo.Controls.Add(lblCoreSvr)
        gpLicInfo.Controls.Add(lblShiftDate)
        gpLicInfo.Controls.Add(tbCoreSvr)
        gpLicInfo.Controls.Add(tbLicSvr)
        gpLicInfo.Controls.Add(tbWebEnabled)
        gpLicInfo.Controls.Add(lblDbVer)
        gpLicInfo.Controls.Add(lblLicSvr)
        gpLicInfo.Controls.Add(lblWebEnabled)
        gpLicInfo.Controls.Add(tbDbVer)
        gpLicInfo.Controls.Add(lblLocName)
        gpLicInfo.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        gpLicInfo.Location = New Point(274, 3)
        gpLicInfo.Margin = New Padding(4, 3, 4, 3)
        gpLicInfo.Name = "gpLicInfo"
        gpLicInfo.Padding = New Padding(4, 3, 4, 3)
        gpLicInfo.Size = New Size(467, 224)
        gpLicInfo.TabIndex = 10
        gpLicInfo.TabStop = False
        gpLicInfo.Text = "License Info"
        ' 
        ' lblPcDbInfo
        ' 
        lblPcDbInfo.AutoSize = True
        lblPcDbInfo.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPcDbInfo.Location = New Point(8, 177)
        lblPcDbInfo.Margin = New Padding(4, 0, 4, 0)
        lblPcDbInfo.Name = "lblPcDbInfo"
        lblPcDbInfo.Size = New Size(52, 13)
        lblPcDbInfo.TabIndex = 18
        lblPcDbInfo.Text = "SQL Info:"
        ' 
        ' tbPcDbInfo
        ' 
        tbPcDbInfo.Location = New Point(118, 170)
        tbPcDbInfo.Margin = New Padding(4, 3, 4, 3)
        tbPcDbInfo.Name = "tbPcDbInfo"
        tbPcDbInfo.Size = New Size(300, 20)
        tbPcDbInfo.TabIndex = 17
        ' 
        ' tbShiftDate
        ' 
        tbShiftDate.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbShiftDate.Location = New Point(118, 144)
        tbShiftDate.Margin = New Padding(4, 3, 4, 3)
        tbShiftDate.Name = "tbShiftDate"
        tbShiftDate.Size = New Size(300, 20)
        tbShiftDate.TabIndex = 11
        ' 
        ' tbLocName
        ' 
        tbLocName.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbLocName.Location = New Point(118, 18)
        tbLocName.Margin = New Padding(4, 3, 4, 3)
        tbLocName.Name = "tbLocName"
        tbLocName.Size = New Size(300, 20)
        tbLocName.TabIndex = 1
        ' 
        ' lblCoreSvr
        ' 
        lblCoreSvr.AutoSize = True
        lblCoreSvr.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCoreSvr.Location = New Point(8, 73)
        lblCoreSvr.Margin = New Padding(4, 0, 4, 0)
        lblCoreSvr.Name = "lblCoreSvr"
        lblCoreSvr.Size = New Size(66, 13)
        lblCoreSvr.TabIndex = 4
        lblCoreSvr.Text = "Core Server:"
        ' 
        ' lblShiftDate
        ' 
        lblShiftDate.AutoSize = True
        lblShiftDate.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblShiftDate.Location = New Point(8, 147)
        lblShiftDate.Margin = New Padding(4, 0, 4, 0)
        lblShiftDate.Name = "lblShiftDate"
        lblShiftDate.Size = New Size(57, 13)
        lblShiftDate.TabIndex = 10
        lblShiftDate.Text = "Shift Date:"
        ' 
        ' tbCoreSvr
        ' 
        tbCoreSvr.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbCoreSvr.Location = New Point(118, 68)
        tbCoreSvr.Margin = New Padding(4, 3, 4, 3)
        tbCoreSvr.Name = "tbCoreSvr"
        tbCoreSvr.Size = New Size(300, 20)
        tbCoreSvr.TabIndex = 5
        ' 
        ' tbLicSvr
        ' 
        tbLicSvr.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbLicSvr.Location = New Point(118, 43)
        tbLicSvr.Margin = New Padding(4, 3, 4, 3)
        tbLicSvr.Name = "tbLicSvr"
        tbLicSvr.Size = New Size(300, 20)
        tbLicSvr.TabIndex = 3
        ' 
        ' tbWebEnabled
        ' 
        tbWebEnabled.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbWebEnabled.Location = New Point(118, 119)
        tbWebEnabled.Margin = New Padding(4, 3, 4, 3)
        tbWebEnabled.Name = "tbWebEnabled"
        tbWebEnabled.Size = New Size(300, 20)
        tbWebEnabled.TabIndex = 9
        ' 
        ' lblDbVer
        ' 
        lblDbVer.AutoSize = True
        lblDbVer.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDbVer.Location = New Point(8, 98)
        lblDbVer.Margin = New Padding(4, 0, 4, 0)
        lblDbVer.Name = "lblDbVer"
        lblDbVer.Size = New Size(94, 13)
        lblDbVer.TabIndex = 6
        lblDbVer.Text = "Database Version:"
        ' 
        ' lblLicSvr
        ' 
        lblLicSvr.AutoSize = True
        lblLicSvr.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLicSvr.Location = New Point(8, 47)
        lblLicSvr.Margin = New Padding(4, 0, 4, 0)
        lblLicSvr.Name = "lblLicSvr"
        lblLicSvr.Size = New Size(81, 13)
        lblLicSvr.TabIndex = 2
        lblLicSvr.Text = "License Server:"
        ' 
        ' lblWebEnabled
        ' 
        lblWebEnabled.AutoSize = True
        lblWebEnabled.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWebEnabled.Location = New Point(8, 123)
        lblWebEnabled.Margin = New Padding(4, 0, 4, 0)
        lblWebEnabled.Name = "lblWebEnabled"
        lblWebEnabled.Size = New Size(98, 13)
        lblWebEnabled.TabIndex = 8
        lblWebEnabled.Text = "Webstore Enabled:"
        ' 
        ' tbDbVer
        ' 
        tbDbVer.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbDbVer.Location = New Point(118, 93)
        tbDbVer.Margin = New Padding(4, 3, 4, 3)
        tbDbVer.Name = "tbDbVer"
        tbDbVer.Size = New Size(300, 20)
        tbDbVer.TabIndex = 7
        ' 
        ' lblLocName
        ' 
        lblLocName.AutoSize = True
        lblLocName.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLocName.Location = New Point(8, 23)
        lblLocName.Margin = New Padding(4, 0, 4, 0)
        lblLocName.Name = "lblLocName"
        lblLocName.Size = New Size(88, 13)
        lblLocName.TabIndex = 0
        lblLocName.Text = "Location Name:  "
        ' 
        ' gbLiveOutput
        ' 
        gbLiveOutput.BackColor = Color.LightGray
        gbLiveOutput.Controls.Add(TableLayoutPanel2)
        gbLiveOutput.Location = New Point(11, 357)
        gbLiveOutput.Margin = New Padding(4, 3, 4, 3)
        gbLiveOutput.Name = "gbLiveOutput"
        gbLiveOutput.Padding = New Padding(4, 3, 4, 3)
        gbLiveOutput.Size = New Size(710, 267)
        gbLiveOutput.TabIndex = 34
        gbLiveOutput.TabStop = False
        gbLiveOutput.Text = "Script Output Window"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 35F))
        TableLayoutPanel2.Controls.Add(btnCopyScriptOutput, 1, 1)
        TableLayoutPanel2.Controls.Add(tbOutputScript, 0, 1)
        TableLayoutPanel2.Controls.Add(rtbLiveOutput, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(4, 19)
        TableLayoutPanel2.Margin = New Padding(4, 3, 4, 3)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        TableLayoutPanel2.Size = New Size(702, 245)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' btnCopyScriptOutput
        ' 
        btnCopyScriptOutput.Dock = DockStyle.Right
        btnCopyScriptOutput.Location = New Point(670, 211)
        btnCopyScriptOutput.Margin = New Padding(1)
        btnCopyScriptOutput.Name = "btnCopyScriptOutput"
        btnCopyScriptOutput.Size = New Size(33, 33)
        btnCopyScriptOutput.TabIndex = 38
        btnCopyScriptOutput.UseVisualStyleBackColor = True
        ' 
        ' tbOutputScript
        ' 
        tbOutputScript.Dock = DockStyle.Fill
        tbOutputScript.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbOutputScript.Location = New Point(1, 211)
        tbOutputScript.Margin = New Padding(1)
        tbOutputScript.Name = "tbOutputScript"
        tbOutputScript.Size = New Size(667, 21)
        tbOutputScript.TabIndex = 37
        ' 
        ' rtbLiveOutput
        ' 
        rtbLiveOutput.BackColor = Color.Black
        TableLayoutPanel2.SetColumnSpan(rtbLiveOutput, 2)
        rtbLiveOutput.DetectUrls = False
        rtbLiveOutput.Dock = DockStyle.Fill
        rtbLiveOutput.Font = New Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rtbLiveOutput.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        rtbLiveOutput.Location = New Point(4, 3)
        rtbLiveOutput.Margin = New Padding(4, 3, 4, 3)
        rtbLiveOutput.Name = "rtbLiveOutput"
        rtbLiveOutput.ReadOnly = True
        rtbLiveOutput.Size = New Size(696, 204)
        rtbLiveOutput.TabIndex = 33
        rtbLiveOutput.Text = ""
        rtbLiveOutput.WordWrap = False
        ' 
        ' pnlServicesContainer
        ' 
        pnlServicesContainer.Controls.Add(tblServices)
        pnlServicesContainer.Controls.Add(tbServicesButtonsHelpMessage)
        pnlServicesContainer.Location = New Point(749, 3)
        pnlServicesContainer.Margin = New Padding(4, 3, 4, 3)
        pnlServicesContainer.Name = "pnlServicesContainer"
        pnlServicesContainer.Size = New Size(408, 616)
        pnlServicesContainer.TabIndex = 1
        ' 
        ' tblServices
        ' 
        tblServices.AutoScroll = True
        tblServices.AutoSize = True
        tblServices.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tblServices.BackColor = Color.Transparent
        tblServices.ColumnCount = 1
        tblServices.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tblServices.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tblServices.Dock = DockStyle.Top
        tblServices.Location = New Point(0, 0)
        tblServices.Margin = New Padding(4, 3, 4, 3)
        tblServices.Name = "tblServices"
        tblServices.RowCount = 1
        tblServices.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tblServices.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tblServices.Size = New Size(408, 0)
        tblServices.TabIndex = 1
        ' 
        ' tbServicesButtonsHelpMessage
        ' 
        tbServicesButtonsHelpMessage.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        tbServicesButtonsHelpMessage.Enabled = False
        tbServicesButtonsHelpMessage.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tbServicesButtonsHelpMessage.Location = New Point(115, 511)
        tbServicesButtonsHelpMessage.Margin = New Padding(4, 3, 4, 3)
        tbServicesButtonsHelpMessage.Multiline = True
        tbServicesButtonsHelpMessage.Name = "tbServicesButtonsHelpMessage"
        tbServicesButtonsHelpMessage.Size = New Size(289, 89)
        tbServicesButtonsHelpMessage.TabIndex = 16
        tbServicesButtonsHelpMessage.Text = "To enable Services buttons close and reopen the application in Administrator Mode."
        ' 
        ' gbFlavorsList
        ' 
        gbFlavorsList.BackColor = Color.LightGray
        gbFlavorsList.Controls.Add(btnFlavorFileCopy)
        gbFlavorsList.Controls.Add(btnFlavorsListRefresh)
        gbFlavorsList.Controls.Add(pnlFlavorsList)
        gbFlavorsList.Location = New Point(11, 6)
        gbFlavorsList.Margin = New Padding(4, 3, 4, 3)
        gbFlavorsList.Name = "gbFlavorsList"
        gbFlavorsList.Padding = New Padding(4, 3, 4, 3)
        gbFlavorsList.Size = New Size(233, 345)
        gbFlavorsList.TabIndex = 35
        gbFlavorsList.TabStop = False
        gbFlavorsList.Text = "Flavors List"
        ' 
        ' btnFlavorFileCopy
        ' 
        btnFlavorFileCopy.Location = New Point(156, 318)
        btnFlavorFileCopy.Margin = New Padding(4, 3, 4, 3)
        btnFlavorFileCopy.Name = "btnFlavorFileCopy"
        btnFlavorFileCopy.Size = New Size(35, 27)
        btnFlavorFileCopy.TabIndex = 38
        btnFlavorFileCopy.UseVisualStyleBackColor = True
        ' 
        ' btnFlavorsListRefresh
        ' 
        btnFlavorsListRefresh.Location = New Point(194, 318)
        btnFlavorsListRefresh.Margin = New Padding(4, 3, 4, 3)
        btnFlavorsListRefresh.Name = "btnFlavorsListRefresh"
        btnFlavorsListRefresh.Size = New Size(35, 27)
        btnFlavorsListRefresh.TabIndex = 37
        btnFlavorsListRefresh.UseVisualStyleBackColor = True
        ' 
        ' pnlFlavorsList
        ' 
        pnlFlavorsList.Controls.Add(lbFlavorsList)
        pnlFlavorsList.Dock = DockStyle.Top
        pnlFlavorsList.Location = New Point(4, 19)
        pnlFlavorsList.Name = "pnlFlavorsList"
        pnlFlavorsList.Size = New Size(225, 298)
        pnlFlavorsList.TabIndex = 36
        ' 
        ' lbFlavorsList
        ' 
        lbFlavorsList.ContextMenuStrip = cmsApplySingleFlavor
        lbFlavorsList.Dock = DockStyle.Fill
        lbFlavorsList.FormattingEnabled = True
        lbFlavorsList.IntegralHeight = False
        lbFlavorsList.ItemHeight = 15
        lbFlavorsList.Location = New Point(0, 0)
        lbFlavorsList.Margin = New Padding(4, 3, 4, 3)
        lbFlavorsList.Name = "lbFlavorsList"
        lbFlavorsList.SelectionMode = SelectionMode.MultiExtended
        lbFlavorsList.Size = New Size(225, 298)
        lbFlavorsList.TabIndex = 35
        ' 
        ' cmsApplySingleFlavor
        ' 
        cmsApplySingleFlavor.Items.AddRange(New ToolStripItem() {miApplySingleFlavor, tsmiApplyDefaultFlavors})
        cmsApplySingleFlavor.Name = "cmsApplySingleFlavor"
        cmsApplySingleFlavor.Size = New Size(187, 48)
        ' 
        ' miApplySingleFlavor
        ' 
        miApplySingleFlavor.Name = "miApplySingleFlavor"
        miApplySingleFlavor.Size = New Size(186, 22)
        miApplySingleFlavor.Text = "Apply this flavor"
        ' 
        ' tsmiApplyDefaultFlavors
        ' 
        tsmiApplyDefaultFlavors.Name = "tsmiApplyDefaultFlavors"
        tsmiApplyDefaultFlavors.Size = New Size(186, 22)
        tsmiApplyDefaultFlavors.Text = "Apply Default Flavors"
        ' 
        ' tpAdvData
        ' 
        tpAdvData.Controls.Add(btnSaveWebOptionsCSV)
        tpAdvData.Controls.Add(btnSaveAppotionsCSV)
        tpAdvData.Controls.Add(btnSaveApplicationInfoCSV)
        tpAdvData.Controls.Add(lblApplicationInfo)
        tpAdvData.Controls.Add(dgvApplicationInfo)
        tpAdvData.Controls.Add(lblWebOptions)
        tpAdvData.Controls.Add(btnRefreshAdvDataTab)
        tpAdvData.Controls.Add(lblAppOptions)
        tpAdvData.Controls.Add(dgvWebOptions)
        tpAdvData.Controls.Add(dgvAppOptions)
        tpAdvData.Location = New Point(4, 24)
        tpAdvData.Margin = New Padding(4, 3, 4, 3)
        tpAdvData.Name = "tpAdvData"
        tpAdvData.Size = New Size(1182, 629)
        tpAdvData.TabIndex = 4
        tpAdvData.Text = "Advantage Data"
        tpAdvData.ToolTipText = "Information from the Database Tables"
        tpAdvData.UseVisualStyleBackColor = True
        ' 
        ' btnSaveWebOptionsCSV
        ' 
        btnSaveWebOptionsCSV.Location = New Point(1077, 519)
        btnSaveWebOptionsCSV.Margin = New Padding(4, 3, 4, 3)
        btnSaveWebOptionsCSV.Name = "btnSaveWebOptionsCSV"
        btnSaveWebOptionsCSV.Size = New Size(88, 27)
        btnSaveWebOptionsCSV.TabIndex = 6
        btnSaveWebOptionsCSV.Text = "Save CSV"
        btnSaveWebOptionsCSV.UseVisualStyleBackColor = True
        ' 
        ' btnSaveAppotionsCSV
        ' 
        btnSaveAppotionsCSV.Location = New Point(730, 519)
        btnSaveAppotionsCSV.Margin = New Padding(4, 3, 4, 3)
        btnSaveAppotionsCSV.Name = "btnSaveAppotionsCSV"
        btnSaveAppotionsCSV.Size = New Size(88, 27)
        btnSaveAppotionsCSV.TabIndex = 6
        btnSaveAppotionsCSV.Text = "Save CSV"
        btnSaveAppotionsCSV.UseVisualStyleBackColor = True
        ' 
        ' btnSaveApplicationInfoCSV
        ' 
        btnSaveApplicationInfoCSV.Location = New Point(229, 519)
        btnSaveApplicationInfoCSV.Margin = New Padding(4, 3, 4, 3)
        btnSaveApplicationInfoCSV.Name = "btnSaveApplicationInfoCSV"
        btnSaveApplicationInfoCSV.Size = New Size(88, 27)
        btnSaveApplicationInfoCSV.TabIndex = 6
        btnSaveApplicationInfoCSV.Text = "Save CSV"
        btnSaveApplicationInfoCSV.UseVisualStyleBackColor = True
        ' 
        ' lblApplicationInfo
        ' 
        lblApplicationInfo.AutoSize = True
        lblApplicationInfo.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblApplicationInfo.Location = New Point(7, 16)
        lblApplicationInfo.Margin = New Padding(4, 0, 4, 0)
        lblApplicationInfo.Name = "lblApplicationInfo"
        lblApplicationInfo.Size = New Size(95, 16)
        lblApplicationInfo.TabIndex = 5
        lblApplicationInfo.Text = "ApplicationInfo"
        ' 
        ' dgvApplicationInfo
        ' 
        dgvApplicationInfo.AllowUserToAddRows = False
        dgvApplicationInfo.AllowUserToDeleteRows = False
        dgvApplicationInfo.AllowUserToResizeColumns = False
        dgvApplicationInfo.AllowUserToResizeRows = False
        dgvApplicationInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvApplicationInfo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvApplicationInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvApplicationInfo.Columns.AddRange(New DataGridViewColumn() {DataGridViewTextBoxColumn3, DataGridViewTextBoxColumn4})
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvApplicationInfo.DefaultCellStyle = DataGridViewCellStyle2
        dgvApplicationInfo.Location = New Point(5, 38)
        dgvApplicationInfo.Margin = New Padding(4, 3, 4, 3)
        dgvApplicationInfo.Name = "dgvApplicationInfo"
        dgvApplicationInfo.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvApplicationInfo.ShowEditingIcon = False
        dgvApplicationInfo.Size = New Size(312, 475)
        dgvApplicationInfo.TabIndex = 4
        ' 
        ' DataGridViewTextBoxColumn3
        ' 
        DataGridViewTextBoxColumn3.HeaderText = "OptionName"
        DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        DataGridViewTextBoxColumn3.Width = 101
        ' 
        ' DataGridViewTextBoxColumn4
        ' 
        DataGridViewTextBoxColumn4.HeaderText = "OptionValue"
        DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        DataGridViewTextBoxColumn4.Width = 97
        ' 
        ' lblWebOptions
        ' 
        lblWebOptions.AutoSize = True
        lblWebOptions.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWebOptions.Location = New Point(878, 16)
        lblWebOptions.Margin = New Padding(4, 0, 4, 0)
        lblWebOptions.Name = "lblWebOptions"
        lblWebOptions.Size = New Size(82, 16)
        lblWebOptions.TabIndex = 3
        lblWebOptions.Text = "WebOptions"
        ' 
        ' btnRefreshAdvDataTab
        ' 
        btnRefreshAdvDataTab.Location = New Point(1068, 586)
        btnRefreshAdvDataTab.Margin = New Padding(0)
        btnRefreshAdvDataTab.Name = "btnRefreshAdvDataTab"
        btnRefreshAdvDataTab.Size = New Size(97, 34)
        btnRefreshAdvDataTab.TabIndex = 17
        btnRefreshAdvDataTab.Text = "Refresh Data"
        btnRefreshAdvDataTab.UseVisualStyleBackColor = True
        ' 
        ' lblAppOptions
        ' 
        lblAppOptions.AutoSize = True
        lblAppOptions.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAppOptions.Location = New Point(410, 16)
        lblAppOptions.Margin = New Padding(4, 0, 4, 0)
        lblAppOptions.Name = "lblAppOptions"
        lblAppOptions.Size = New Size(78, 16)
        lblAppOptions.TabIndex = 2
        lblAppOptions.Text = "AppOptions"
        ' 
        ' dgvWebOptions
        ' 
        dgvWebOptions.AllowUserToAddRows = False
        dgvWebOptions.AllowUserToDeleteRows = False
        dgvWebOptions.AllowUserToResizeColumns = False
        dgvWebOptions.AllowUserToResizeRows = False
        dgvWebOptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvWebOptions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgvWebOptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvWebOptions.Columns.AddRange(New DataGridViewColumn() {DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2})
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Window
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle4.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.False
        dgvWebOptions.DefaultCellStyle = DataGridViewCellStyle4
        dgvWebOptions.Location = New Point(825, 38)
        dgvWebOptions.Margin = New Padding(4, 3, 4, 3)
        dgvWebOptions.Name = "dgvWebOptions"
        dgvWebOptions.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvWebOptions.ShowEditingIcon = False
        dgvWebOptions.Size = New Size(340, 475)
        dgvWebOptions.TabIndex = 1
        ' 
        ' DataGridViewTextBoxColumn1
        ' 
        DataGridViewTextBoxColumn1.HeaderText = "OptionName"
        DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        DataGridViewTextBoxColumn1.Width = 101
        ' 
        ' DataGridViewTextBoxColumn2
        ' 
        DataGridViewTextBoxColumn2.HeaderText = "OptionValue"
        DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        DataGridViewTextBoxColumn2.Width = 97
        ' 
        ' dgvAppOptions
        ' 
        dgvAppOptions.AllowUserToAddRows = False
        dgvAppOptions.AllowUserToDeleteRows = False
        dgvAppOptions.AllowUserToResizeColumns = False
        dgvAppOptions.AllowUserToResizeRows = False
        dgvAppOptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = SystemColors.Control
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle5.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        dgvAppOptions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        dgvAppOptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAppOptions.Columns.AddRange(New DataGridViewColumn() {OptionName, OptionValue})
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = SystemColors.Window
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle6.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        dgvAppOptions.DefaultCellStyle = DataGridViewCellStyle6
        dgvAppOptions.Location = New Point(323, 38)
        dgvAppOptions.Margin = New Padding(4, 3, 4, 3)
        dgvAppOptions.Name = "dgvAppOptions"
        dgvAppOptions.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvAppOptions.ShowEditingIcon = False
        dgvAppOptions.Size = New Size(495, 475)
        dgvAppOptions.TabIndex = 0
        ' 
        ' OptionName
        ' 
        OptionName.HeaderText = "OptionName"
        OptionName.Name = "OptionName"
        OptionName.Width = 101
        ' 
        ' OptionValue
        ' 
        OptionValue.HeaderText = "OptionValue"
        OptionValue.Name = "OptionValue"
        OptionValue.Width = 97
        ' 
        ' tpDbLogs
        ' 
        tpDbLogs.BackColor = Color.DarkGray
        tpDbLogs.Controls.Add(tlpLogData)
        tpDbLogs.Controls.Add(pnlDbLogs)
        tpDbLogs.Location = New Point(4, 24)
        tpDbLogs.Margin = New Padding(4, 3, 4, 3)
        tpDbLogs.Name = "tpDbLogs"
        tpDbLogs.Padding = New Padding(4, 3, 4, 3)
        tpDbLogs.Size = New Size(1182, 629)
        tpDbLogs.TabIndex = 2
        tpDbLogs.Text = "CE DB Logs"
        tpDbLogs.ToolTipText = "Access to MessageLog and WebCloudUpdates tables"
        ' 
        ' tlpLogData
        ' 
        tlpLogData.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        tlpLogData.ColumnCount = 2
        tlpLogData.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 24.25409F))
        tlpLogData.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 75.74591F))
        tlpLogData.Controls.Add(gpDbLogCount, 0, 0)
        tlpLogData.Controls.Add(gpDbLogData, 1, 0)
        tlpLogData.Location = New Point(7, 7)
        tlpLogData.Margin = New Padding(4, 3, 4, 3)
        tlpLogData.Name = "tlpLogData"
        tlpLogData.RowCount = 1
        tlpLogData.RowStyles.Add(New RowStyle())
        tlpLogData.RowStyles.Add(New RowStyle(SizeType.Absolute, 511F))
        tlpLogData.Size = New Size(1161, 454)
        tlpLogData.TabIndex = 5
        ' 
        ' gpDbLogCount
        ' 
        gpDbLogCount.BackColor = Color.LightGray
        gpDbLogCount.Controls.Add(dgvDbLogCount)
        gpDbLogCount.Location = New Point(4, 3)
        gpDbLogCount.Margin = New Padding(4, 3, 4, 3)
        gpDbLogCount.Name = "gpDbLogCount"
        gpDbLogCount.Padding = New Padding(4, 3, 4, 3)
        gpDbLogCount.Size = New Size(273, 466)
        gpDbLogCount.TabIndex = 3
        gpDbLogCount.TabStop = False
        gpDbLogCount.Text = "Log Count"
        ' 
        ' dgvDbLogCount
        ' 
        dgvDbLogCount.AllowUserToAddRows = False
        dgvDbLogCount.AllowUserToDeleteRows = False
        dgvDbLogCount.AllowUserToResizeRows = False
        dgvDbLogCount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvDbLogCount.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = SystemColors.Control
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle7.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        dgvDbLogCount.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        dgvDbLogCount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = SystemColors.Window
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle8.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.False
        dgvDbLogCount.DefaultCellStyle = DataGridViewCellStyle8
        dgvDbLogCount.Dock = DockStyle.Fill
        dgvDbLogCount.EditMode = DataGridViewEditMode.EditProgrammatically
        dgvDbLogCount.Location = New Point(4, 19)
        dgvDbLogCount.Margin = New Padding(4, 3, 4, 3)
        dgvDbLogCount.Name = "dgvDbLogCount"
        dgvDbLogCount.Size = New Size(265, 444)
        dgvDbLogCount.TabIndex = 1
        ' 
        ' gpDbLogData
        ' 
        gpDbLogData.BackColor = Color.LightGray
        gpDbLogData.Controls.Add(dgvDbLogData)
        gpDbLogData.Location = New Point(285, 3)
        gpDbLogData.Margin = New Padding(4, 3, 4, 3)
        gpDbLogData.Name = "gpDbLogData"
        gpDbLogData.Padding = New Padding(4, 3, 4, 3)
        gpDbLogData.Size = New Size(872, 466)
        gpDbLogData.TabIndex = 4
        gpDbLogData.TabStop = False
        gpDbLogData.Text = "Log Data"
        ' 
        ' dgvDbLogData
        ' 
        dgvDbLogData.AllowUserToAddRows = False
        dgvDbLogData.AllowUserToDeleteRows = False
        dgvDbLogData.AllowUserToResizeRows = False
        dgvDbLogData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvDbLogData.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = SystemColors.Control
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle9.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        dgvDbLogData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        dgvDbLogData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = SystemColors.Window
        DataGridViewCellStyle10.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle10.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.False
        dgvDbLogData.DefaultCellStyle = DataGridViewCellStyle10
        dgvDbLogData.Dock = DockStyle.Fill
        dgvDbLogData.EditMode = DataGridViewEditMode.EditProgrammatically
        dgvDbLogData.Location = New Point(4, 19)
        dgvDbLogData.Margin = New Padding(4, 3, 4, 3)
        dgvDbLogData.Name = "dgvDbLogData"
        dgvDbLogData.ReadOnly = True
        dgvDbLogData.Size = New Size(864, 444)
        dgvDbLogData.TabIndex = 2
        ' 
        ' pnlDbLogs
        ' 
        pnlDbLogs.BackColor = Color.LightGray
        pnlDbLogs.BorderStyle = BorderStyle.Fixed3D
        pnlDbLogs.Controls.Add(gpMessageLogFilters)
        pnlDbLogs.Controls.Add(btnDbLogRefresh)
        pnlDbLogs.Controls.Add(rbMessageLog)
        pnlDbLogs.Controls.Add(rbWebCloudUpdates)
        pnlDbLogs.Dock = DockStyle.Bottom
        pnlDbLogs.Location = New Point(4, 480)
        pnlDbLogs.Margin = New Padding(4, 3, 4, 3)
        pnlDbLogs.Name = "pnlDbLogs"
        pnlDbLogs.Size = New Size(1174, 146)
        pnlDbLogs.TabIndex = 0
        ' 
        ' gpMessageLogFilters
        ' 
        gpMessageLogFilters.BackColor = Color.Gainsboro
        gpMessageLogFilters.Controls.Add(lblMsgLogNumRows)
        gpMessageLogFilters.Controls.Add(lblMsgLogEndDate)
        gpMessageLogFilters.Controls.Add(lblMsgLogStartDate)
        gpMessageLogFilters.Controls.Add(cbMsgLogDateRange)
        gpMessageLogFilters.Controls.Add(nudMsgLog)
        gpMessageLogFilters.Controls.Add(cbMsgLogShowErrorsOnly)
        gpMessageLogFilters.Controls.Add(dtpMsgLogTimeTo)
        gpMessageLogFilters.Controls.Add(dtpMsgLogTimeFrom)
        gpMessageLogFilters.Controls.Add(dtpMsgLogDateTo)
        gpMessageLogFilters.Controls.Add(dtpMsgLogDateFrom)
        gpMessageLogFilters.Location = New Point(5, 3)
        gpMessageLogFilters.Margin = New Padding(4, 3, 4, 3)
        gpMessageLogFilters.Name = "gpMessageLogFilters"
        gpMessageLogFilters.Padding = New Padding(4, 3, 4, 3)
        gpMessageLogFilters.Size = New Size(596, 111)
        gpMessageLogFilters.TabIndex = 4
        gpMessageLogFilters.TabStop = False
        gpMessageLogFilters.Text = "MessageLog Filters"
        ' 
        ' lblMsgLogNumRows
        ' 
        lblMsgLogNumRows.AutoSize = True
        lblMsgLogNumRows.Location = New Point(346, 47)
        lblMsgLogNumRows.Margin = New Padding(4, 0, 4, 0)
        lblMsgLogNumRows.Name = "lblMsgLogNumRows"
        lblMsgLogNumRows.Size = New Size(104, 15)
        lblMsgLogNumRows.TabIndex = 15
        lblMsgLogNumRows.Text = "# of Rows to show"
        ' 
        ' lblMsgLogEndDate
        ' 
        lblMsgLogEndDate.AutoSize = True
        lblMsgLogEndDate.Location = New Point(15, 84)
        lblMsgLogEndDate.Margin = New Padding(4, 0, 4, 0)
        lblMsgLogEndDate.Name = "lblMsgLogEndDate"
        lblMsgLogEndDate.Size = New Size(27, 15)
        lblMsgLogEndDate.TabIndex = 14
        lblMsgLogEndDate.Text = "End"
        ' 
        ' lblMsgLogStartDate
        ' 
        lblMsgLogStartDate.AutoSize = True
        lblMsgLogStartDate.Location = New Point(14, 54)
        lblMsgLogStartDate.Margin = New Padding(4, 0, 4, 0)
        lblMsgLogStartDate.Name = "lblMsgLogStartDate"
        lblMsgLogStartDate.Size = New Size(31, 15)
        lblMsgLogStartDate.TabIndex = 13
        lblMsgLogStartDate.Text = "Start"
        ' 
        ' cbMsgLogDateRange
        ' 
        cbMsgLogDateRange.AutoSize = True
        cbMsgLogDateRange.Location = New Point(8, 21)
        cbMsgLogDateRange.Margin = New Padding(4, 3, 4, 3)
        cbMsgLogDateRange.Name = "cbMsgLogDateRange"
        cbMsgLogDateRange.Size = New Size(108, 19)
        cbMsgLogDateRange.TabIndex = 12
        cbMsgLogDateRange.Text = "Use Date Range"
        cbMsgLogDateRange.UseVisualStyleBackColor = True
        ' 
        ' nudMsgLog
        ' 
        nudMsgLog.Location = New Point(354, 74)
        nudMsgLog.Margin = New Padding(4, 3, 4, 3)
        nudMsgLog.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        nudMsgLog.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        nudMsgLog.Name = "nudMsgLog"
        nudMsgLog.Size = New Size(77, 23)
        nudMsgLog.TabIndex = 10
        nudMsgLog.TextAlign = HorizontalAlignment.Right
        nudMsgLog.Value = New Decimal(New Integer() {100, 0, 0, 0})
        ' 
        ' cbMsgLogShowErrorsOnly
        ' 
        cbMsgLogShowErrorsOnly.AutoSize = True
        cbMsgLogShowErrorsOnly.Location = New Point(465, 46)
        cbMsgLogShowErrorsOnly.Margin = New Padding(4, 3, 4, 3)
        cbMsgLogShowErrorsOnly.Name = "cbMsgLogShowErrorsOnly"
        cbMsgLogShowErrorsOnly.Size = New Size(115, 19)
        cbMsgLogShowErrorsOnly.TabIndex = 9
        cbMsgLogShowErrorsOnly.Text = "Only show errors"
        cbMsgLogShowErrorsOnly.UseVisualStyleBackColor = True
        ' 
        ' dtpMsgLogTimeTo
        ' 
        dtpMsgLogTimeTo.Format = DateTimePickerFormat.Time
        dtpMsgLogTimeTo.Location = New Point(190, 77)
        dtpMsgLogTimeTo.Margin = New Padding(4, 3, 4, 3)
        dtpMsgLogTimeTo.Name = "dtpMsgLogTimeTo"
        dtpMsgLogTimeTo.ShowUpDown = True
        dtpMsgLogTimeTo.Size = New Size(130, 23)
        dtpMsgLogTimeTo.TabIndex = 8
        ' 
        ' dtpMsgLogTimeFrom
        ' 
        dtpMsgLogTimeFrom.Format = DateTimePickerFormat.Time
        dtpMsgLogTimeFrom.Location = New Point(190, 47)
        dtpMsgLogTimeFrom.Margin = New Padding(4, 3, 4, 3)
        dtpMsgLogTimeFrom.Name = "dtpMsgLogTimeFrom"
        dtpMsgLogTimeFrom.ShowUpDown = True
        dtpMsgLogTimeFrom.Size = New Size(130, 23)
        dtpMsgLogTimeFrom.TabIndex = 7
        ' 
        ' dtpMsgLogDateTo
        ' 
        dtpMsgLogDateTo.Format = DateTimePickerFormat.Short
        dtpMsgLogDateTo.Location = New Point(52, 77)
        dtpMsgLogDateTo.Margin = New Padding(4, 3, 4, 3)
        dtpMsgLogDateTo.Name = "dtpMsgLogDateTo"
        dtpMsgLogDateTo.Size = New Size(130, 23)
        dtpMsgLogDateTo.TabIndex = 6
        ' 
        ' dtpMsgLogDateFrom
        ' 
        dtpMsgLogDateFrom.Format = DateTimePickerFormat.Short
        dtpMsgLogDateFrom.Location = New Point(52, 47)
        dtpMsgLogDateFrom.Margin = New Padding(4, 3, 4, 3)
        dtpMsgLogDateFrom.Name = "dtpMsgLogDateFrom"
        dtpMsgLogDateFrom.Size = New Size(130, 23)
        dtpMsgLogDateFrom.TabIndex = 3
        ' 
        ' btnDbLogRefresh
        ' 
        btnDbLogRefresh.Location = New Point(609, 87)
        btnDbLogRefresh.Margin = New Padding(4, 3, 4, 3)
        btnDbLogRefresh.Name = "btnDbLogRefresh"
        btnDbLogRefresh.Size = New Size(88, 27)
        btnDbLogRefresh.TabIndex = 2
        btnDbLogRefresh.Text = "Refresh"
        btnDbLogRefresh.UseVisualStyleBackColor = True
        ' 
        ' rbMessageLog
        ' 
        rbMessageLog.AutoSize = True
        rbMessageLog.Checked = True
        rbMessageLog.Location = New Point(609, 24)
        rbMessageLog.Margin = New Padding(4, 3, 4, 3)
        rbMessageLog.Name = "rbMessageLog"
        rbMessageLog.Size = New Size(91, 19)
        rbMessageLog.TabIndex = 1
        rbMessageLog.TabStop = True
        rbMessageLog.Text = "MessageLog"
        rbMessageLog.UseVisualStyleBackColor = True
        ' 
        ' rbWebCloudUpdates
        ' 
        rbWebCloudUpdates.AutoSize = True
        rbWebCloudUpdates.Location = New Point(609, 3)
        rbWebCloudUpdates.Margin = New Padding(4, 3, 4, 3)
        rbWebCloudUpdates.Name = "rbWebCloudUpdates"
        rbWebCloudUpdates.Size = New Size(124, 19)
        rbWebCloudUpdates.TabIndex = 0
        rbWebCloudUpdates.Text = "WebCloudUpdates"
        rbWebCloudUpdates.UseVisualStyleBackColor = True
        ' 
        ' tpDbInfo
        ' 
        tpDbInfo.BackColor = Color.DarkGray
        tpDbInfo.Controls.Add(pnlDbInfoButtons)
        tpDbInfo.Controls.Add(pnlDbData)
        tpDbInfo.Location = New Point(4, 24)
        tpDbInfo.Margin = New Padding(4, 3, 4, 3)
        tpDbInfo.Name = "tpDbInfo"
        tpDbInfo.Padding = New Padding(4, 3, 4, 3)
        tpDbInfo.Size = New Size(1182, 629)
        tpDbInfo.TabIndex = 1
        tpDbInfo.Text = "DB Information"
        tpDbInfo.ToolTipText = "Queries for Database Troubleshooting"
        ' 
        ' pnlDbInfoButtons
        ' 
        pnlDbInfoButtons.BackColor = Color.LightGray
        pnlDbInfoButtons.BorderStyle = BorderStyle.Fixed3D
        pnlDbInfoButtons.Controls.Add(rbDbDeadlocks)
        pnlDbInfoButtons.Controls.Add(rbDbSizeByDay)
        pnlDbInfoButtons.Controls.Add(btnDbInfoRefresh)
        pnlDbInfoButtons.Controls.Add(rbDbFragmentation)
        pnlDbInfoButtons.Controls.Add(rbDbTableSize)
        pnlDbInfoButtons.Dock = DockStyle.Bottom
        pnlDbInfoButtons.Location = New Point(4, 594)
        pnlDbInfoButtons.Margin = New Padding(4, 3, 4, 3)
        pnlDbInfoButtons.Name = "pnlDbInfoButtons"
        pnlDbInfoButtons.Size = New Size(1174, 32)
        pnlDbInfoButtons.TabIndex = 1
        ' 
        ' rbDbDeadlocks
        ' 
        rbDbDeadlocks.AutoSize = True
        rbDbDeadlocks.Location = New Point(326, 2)
        rbDbDeadlocks.Margin = New Padding(4, 3, 4, 3)
        rbDbDeadlocks.Name = "rbDbDeadlocks"
        rbDbDeadlocks.Size = New Size(79, 19)
        rbDbDeadlocks.TabIndex = 3
        rbDbDeadlocks.TabStop = True
        rbDbDeadlocks.Text = "Deadlocks"
        rbDbDeadlocks.UseVisualStyleBackColor = True
        ' 
        ' rbDbSizeByDay
        ' 
        rbDbSizeByDay.AutoSize = True
        rbDbSizeByDay.Location = New Point(226, 2)
        rbDbSizeByDay.Margin = New Padding(4, 3, 4, 3)
        rbDbSizeByDay.Name = "rbDbSizeByDay"
        rbDbSizeByDay.Size = New Size(84, 19)
        rbDbSizeByDay.TabIndex = 2
        rbDbSizeByDay.TabStop = True
        rbDbSizeByDay.Text = "Size by Day"
        rbDbSizeByDay.UseVisualStyleBackColor = True
        ' 
        ' btnDbInfoRefresh
        ' 
        btnDbInfoRefresh.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnDbInfoRefresh.Location = New Point(1080, 2)
        btnDbInfoRefresh.Margin = New Padding(4, 3, 4, 3)
        btnDbInfoRefresh.Name = "btnDbInfoRefresh"
        btnDbInfoRefresh.Size = New Size(75, 23)
        btnDbInfoRefresh.TabIndex = 2
        btnDbInfoRefresh.Text = "Refresh"
        btnDbInfoRefresh.UseVisualStyleBackColor = True
        ' 
        ' rbDbFragmentation
        ' 
        rbDbFragmentation.AutoSize = True
        rbDbFragmentation.Location = New Point(113, 2)
        rbDbFragmentation.Margin = New Padding(4, 3, 4, 3)
        rbDbFragmentation.Name = "rbDbFragmentation"
        rbDbFragmentation.Size = New Size(103, 19)
        rbDbFragmentation.TabIndex = 1
        rbDbFragmentation.TabStop = True
        rbDbFragmentation.Text = "Fragmentation"
        rbDbFragmentation.UseVisualStyleBackColor = True
        ' 
        ' rbDbTableSize
        ' 
        rbDbTableSize.AutoSize = True
        rbDbTableSize.Location = New Point(4, 2)
        rbDbTableSize.Margin = New Padding(4, 3, 4, 3)
        rbDbTableSize.Name = "rbDbTableSize"
        rbDbTableSize.Size = New Size(92, 19)
        rbDbTableSize.TabIndex = 0
        rbDbTableSize.TabStop = True
        rbDbTableSize.Text = "Size by Table"
        rbDbTableSize.UseVisualStyleBackColor = True
        ' 
        ' pnlDbData
        ' 
        pnlDbData.Controls.Add(dgvDbTableSize)
        pnlDbData.Location = New Point(4, 3)
        pnlDbData.Margin = New Padding(4, 3, 4, 3)
        pnlDbData.Name = "pnlDbData"
        pnlDbData.Size = New Size(1177, 598)
        pnlDbData.TabIndex = 1
        ' 
        ' dgvDbTableSize
        ' 
        dgvDbTableSize.AllowUserToAddRows = False
        dgvDbTableSize.AllowUserToDeleteRows = False
        dgvDbTableSize.AllowUserToOrderColumns = True
        dgvDbTableSize.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = SystemColors.Control
        DataGridViewCellStyle11.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle11.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        dgvDbTableSize.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        dgvDbTableSize.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = SystemColors.Window
        DataGridViewCellStyle12.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle12.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = DataGridViewTriState.False
        dgvDbTableSize.DefaultCellStyle = DataGridViewCellStyle12
        dgvDbTableSize.Dock = DockStyle.Fill
        dgvDbTableSize.Location = New Point(0, 0)
        dgvDbTableSize.Margin = New Padding(4, 3, 4, 3)
        dgvDbTableSize.Name = "dgvDbTableSize"
        dgvDbTableSize.ReadOnly = True
        dgvDbTableSize.Size = New Size(1177, 598)
        dgvDbTableSize.TabIndex = 0
        ' 
        ' tpStParse
        ' 
        tpStParse.Controls.Add(Panel1)
        tpStParse.Controls.Add(tbSTParse)
        tpStParse.Location = New Point(4, 24)
        tpStParse.Margin = New Padding(4, 3, 4, 3)
        tpStParse.Name = "tpStParse"
        tpStParse.Padding = New Padding(4, 3, 4, 3)
        tpStParse.Size = New Size(1182, 629)
        tpStParse.TabIndex = 3
        tpStParse.Text = "Stack Trace Parser"
        tpStParse.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(btnStCopy)
        Panel1.Controls.Add(btnStPaste)
        Panel1.Controls.Add(btnStParse)
        Panel1.Controls.Add(btnSTClear)
        Panel1.Location = New Point(1010, 6)
        Panel1.Margin = New Padding(4, 3, 4, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(97, 145)
        Panel1.TabIndex = 3
        ' 
        ' btnStCopy
        ' 
        btnStCopy.Location = New Point(6, 9)
        btnStCopy.Margin = New Padding(4, 3, 4, 3)
        btnStCopy.Name = "btnStCopy"
        btnStCopy.Size = New Size(88, 27)
        btnStCopy.TabIndex = 3
        btnStCopy.Text = "Copy"
        btnStCopy.TextAlign = ContentAlignment.BottomCenter
        btnStCopy.UseVisualStyleBackColor = True
        ' 
        ' btnStPaste
        ' 
        btnStPaste.Location = New Point(6, 43)
        btnStPaste.Margin = New Padding(4, 3, 4, 3)
        btnStPaste.Name = "btnStPaste"
        btnStPaste.Size = New Size(88, 27)
        btnStPaste.TabIndex = 2
        btnStPaste.Text = "Paste"
        btnStPaste.TextAlign = ContentAlignment.BottomCenter
        btnStPaste.UseVisualStyleBackColor = True
        ' 
        ' btnStParse
        ' 
        btnStParse.Location = New Point(6, 110)
        btnStParse.Margin = New Padding(4, 3, 4, 3)
        btnStParse.Name = "btnStParse"
        btnStParse.Size = New Size(88, 27)
        btnStParse.TabIndex = 0
        btnStParse.Text = "Parse"
        btnStParse.UseVisualStyleBackColor = True
        ' 
        ' btnSTClear
        ' 
        btnSTClear.Location = New Point(6, 76)
        btnSTClear.Margin = New Padding(4, 3, 4, 3)
        btnSTClear.Name = "btnSTClear"
        btnSTClear.Size = New Size(88, 27)
        btnSTClear.TabIndex = 1
        btnSTClear.Text = "Clear"
        btnSTClear.UseVisualStyleBackColor = True
        ' 
        ' tbSTParse
        ' 
        tbSTParse.Location = New Point(10, 3)
        tbSTParse.Margin = New Padding(4, 3, 4, 3)
        tbSTParse.Multiline = True
        tbSTParse.Name = "tbSTParse"
        tbSTParse.ScrollBars = ScrollBars.Both
        tbSTParse.Size = New Size(975, 501)
        tbSTParse.TabIndex = 2
        ' 
        ' tpLogs
        ' 
        tpLogs.Controls.Add(tlpApplicationLogs)
        tpLogs.Location = New Point(4, 24)
        tpLogs.Name = "tpLogs"
        tpLogs.Size = New Size(1182, 629)
        tpLogs.TabIndex = 9
        tpLogs.Text = "Application Logs"
        tpLogs.UseVisualStyleBackColor = True
        ' 
        ' tlpApplicationLogs
        ' 
        tlpApplicationLogs.ColumnCount = 1
        tlpApplicationLogs.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpApplicationLogs.Controls.Add(rtbLogs, 0, 0)
        tlpApplicationLogs.Controls.Add(flpAppLogsButtons, 0, 1)
        tlpApplicationLogs.Dock = DockStyle.Fill
        tlpApplicationLogs.Location = New Point(0, 0)
        tlpApplicationLogs.Name = "tlpApplicationLogs"
        tlpApplicationLogs.RowCount = 2
        tlpApplicationLogs.RowStyles.Add(New RowStyle(SizeType.Percent, 87.91733F))
        tlpApplicationLogs.RowStyles.Add(New RowStyle(SizeType.Percent, 12.0826712F))
        tlpApplicationLogs.Size = New Size(1182, 629)
        tlpApplicationLogs.TabIndex = 1
        ' 
        ' rtbLogs
        ' 
        rtbLogs.Dock = DockStyle.Fill
        rtbLogs.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rtbLogs.Location = New Point(3, 3)
        rtbLogs.Name = "rtbLogs"
        rtbLogs.ReadOnly = True
        rtbLogs.Size = New Size(1176, 547)
        rtbLogs.TabIndex = 0
        rtbLogs.Text = ""
        ' 
        ' flpAppLogsButtons
        ' 
        flpAppLogsButtons.Controls.Add(btnViewLatestLog)
        flpAppLogsButtons.Controls.Add(btnOpenLogFile)
        flpAppLogsButtons.Controls.Add(btnLastLogBlock)
        flpAppLogsButtons.Controls.Add(btnLastFailed)
        flpAppLogsButtons.Dock = DockStyle.Fill
        flpAppLogsButtons.Location = New Point(3, 556)
        flpAppLogsButtons.Name = "flpAppLogsButtons"
        flpAppLogsButtons.Size = New Size(1176, 70)
        flpAppLogsButtons.TabIndex = 1
        ' 
        ' btnViewLatestLog
        ' 
        btnViewLatestLog.Location = New Point(4, 3)
        btnViewLatestLog.Margin = New Padding(4, 3, 4, 3)
        btnViewLatestLog.Name = "btnViewLatestLog"
        btnViewLatestLog.Size = New Size(97, 59)
        btnViewLatestLog.TabIndex = 34
        btnViewLatestLog.Text = "Open Latest Log"
        btnViewLatestLog.UseVisualStyleBackColor = True
        ' 
        ' btnOpenLogFile
        ' 
        btnOpenLogFile.Location = New Point(109, 3)
        btnOpenLogFile.Margin = New Padding(4, 3, 4, 3)
        btnOpenLogFile.Name = "btnOpenLogFile"
        btnOpenLogFile.Size = New Size(97, 59)
        btnOpenLogFile.TabIndex = 33
        btnOpenLogFile.Text = "Open Log File"
        btnOpenLogFile.UseVisualStyleBackColor = True
        ' 
        ' btnLastLogBlock
        ' 
        btnLastLogBlock.Location = New Point(214, 3)
        btnLastLogBlock.Margin = New Padding(4, 3, 4, 3)
        btnLastLogBlock.Name = "btnLastLogBlock"
        btnLastLogBlock.Size = New Size(97, 59)
        btnLastLogBlock.TabIndex = 35
        btnLastLogBlock.Text = "Last Execution"
        btnLastLogBlock.UseVisualStyleBackColor = True
        ' 
        ' btnLastFailed
        ' 
        btnLastFailed.Location = New Point(319, 3)
        btnLastFailed.Margin = New Padding(4, 3, 4, 3)
        btnLastFailed.Name = "btnLastFailed"
        btnLastFailed.Size = New Size(97, 59)
        btnLastFailed.TabIndex = 36
        btnLastFailed.Text = "Last Failed"
        btnLastFailed.UseVisualStyleBackColor = True
        ' 
        ' tpFlavor
        ' 
        tpFlavor.Controls.Add(Panel3)
        tpFlavor.Controls.Add(lblPersonalFlavorFile)
        tpFlavor.Controls.Add(flpFlavorButtons)
        tpFlavor.Controls.Add(tbFlavor)
        tpFlavor.Location = New Point(4, 24)
        tpFlavor.Name = "tpFlavor"
        tpFlavor.Size = New Size(1182, 629)
        tpFlavor.TabIndex = 10
        tpFlavor.Text = "Personal Flavor"
        tpFlavor.UseVisualStyleBackColor = True
        ' 
        ' Panel3
        ' 
        Panel3.BorderStyle = BorderStyle.Fixed3D
        Panel3.Controls.Add(tbFlavorHints)
        Panel3.Location = New Point(6, 427)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(686, 153)
        Panel3.TabIndex = 5
        ' 
        ' tbFlavorHints
        ' 
        tbFlavorHints.BorderStyle = BorderStyle.None
        tbFlavorHints.Dock = DockStyle.Fill
        tbFlavorHints.Location = New Point(0, 0)
        tbFlavorHints.Multiline = True
        tbFlavorHints.Name = "tbFlavorHints"
        tbFlavorHints.ReadOnly = True
        tbFlavorHints.Size = New Size(682, 149)
        tbFlavorHints.TabIndex = 4
        tbFlavorHints.Text = resources.GetString("tbFlavorHints.Text")
        ' 
        ' lblPersonalFlavorFile
        ' 
        lblPersonalFlavorFile.AutoSize = True
        lblPersonalFlavorFile.Location = New Point(72, 8)
        lblPersonalFlavorFile.Name = "lblPersonalFlavorFile"
        lblPersonalFlavorFile.Size = New Size(115, 15)
        lblPersonalFlavorFile.TabIndex = 3
        lblPersonalFlavorFile.Text = "lblPersonalFlavorFile"
        ' 
        ' flpFlavorButtons
        ' 
        flpFlavorButtons.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        flpFlavorButtons.BorderStyle = BorderStyle.Fixed3D
        flpFlavorButtons.Controls.Add(btnFlavorLoad)
        flpFlavorButtons.Controls.Add(btnFlavorSave)
        flpFlavorButtons.Controls.Add(btnFlavorClear)
        flpFlavorButtons.Controls.Add(btnFlavorPaste)
        flpFlavorButtons.FlowDirection = FlowDirection.TopDown
        flpFlavorButtons.Location = New Point(1068, 4)
        flpFlavorButtons.Name = "flpFlavorButtons"
        flpFlavorButtons.Size = New Size(111, 286)
        flpFlavorButtons.TabIndex = 2
        ' 
        ' btnFlavorLoad
        ' 
        btnFlavorLoad.Location = New Point(3, 3)
        btnFlavorLoad.MinimumSize = New Size(97, 57)
        btnFlavorLoad.Name = "btnFlavorLoad"
        btnFlavorLoad.Size = New Size(97, 57)
        btnFlavorLoad.TabIndex = 1
        btnFlavorLoad.Text = "Load from File"
        btnFlavorLoad.UseVisualStyleBackColor = True
        ' 
        ' btnFlavorSave
        ' 
        btnFlavorSave.Location = New Point(3, 66)
        btnFlavorSave.MinimumSize = New Size(97, 57)
        btnFlavorSave.Name = "btnFlavorSave"
        btnFlavorSave.Size = New Size(97, 57)
        btnFlavorSave.TabIndex = 3
        btnFlavorSave.Text = "Save to file"
        btnFlavorSave.UseVisualStyleBackColor = True
        ' 
        ' btnFlavorClear
        ' 
        btnFlavorClear.Location = New Point(3, 129)
        btnFlavorClear.MinimumSize = New Size(97, 57)
        btnFlavorClear.Name = "btnFlavorClear"
        btnFlavorClear.Size = New Size(97, 57)
        btnFlavorClear.TabIndex = 4
        btnFlavorClear.Text = "Clear Flavor Contents"
        btnFlavorClear.UseVisualStyleBackColor = True
        ' 
        ' btnFlavorPaste
        ' 
        btnFlavorPaste.Location = New Point(3, 192)
        btnFlavorPaste.MinimumSize = New Size(97, 57)
        btnFlavorPaste.Name = "btnFlavorPaste"
        btnFlavorPaste.Size = New Size(97, 57)
        btnFlavorPaste.TabIndex = 5
        btnFlavorPaste.Text = "Paste from Clipboard"
        btnFlavorPaste.UseVisualStyleBackColor = True
        ' 
        ' tbFlavor
        ' 
        tbFlavor.Location = New Point(6, 27)
        tbFlavor.Multiline = True
        tbFlavor.Name = "tbFlavor"
        tbFlavor.ScrollBars = ScrollBars.Both
        tbFlavor.Size = New Size(1045, 386)
        tbFlavor.TabIndex = 0
        ' 
        ' tpOptions
        ' 
        tpOptions.BackColor = Color.Gray
        tpOptions.Controls.Add(tbMLTest1)
        tpOptions.Controls.Add(gpFlavorsSettings)
        tpOptions.Controls.Add(gbAppLaunchSettings)
        tpOptions.Controls.Add(gbAppOptions)
        tpOptions.Controls.Add(gpAdvUpgrade)
        tpOptions.Location = New Point(4, 24)
        tpOptions.Margin = New Padding(4, 3, 4, 3)
        tpOptions.Name = "tpOptions"
        tpOptions.Padding = New Padding(4, 3, 4, 3)
        tpOptions.Size = New Size(1182, 629)
        tpOptions.TabIndex = 7
        tpOptions.Text = "Options"
        ' 
        ' tbMLTest1
        ' 
        tbMLTest1.Location = New Point(967, 511)
        tbMLTest1.Margin = New Padding(4, 3, 4, 3)
        tbMLTest1.Multiline = True
        tbMLTest1.Name = "tbMLTest1"
        tbMLTest1.Size = New Size(207, 59)
        tbMLTest1.TabIndex = 36
        ' 
        ' gpFlavorsSettings
        ' 
        gpFlavorsSettings.BackColor = Color.LightGray
        gpFlavorsSettings.Controls.Add(btnSaveFlavorDefaults)
        gpFlavorsSettings.Controls.Add(clbSqlFiles)
        gpFlavorsSettings.Controls.Add(btnResetFlavorDefaults)
        gpFlavorsSettings.Location = New Point(9, 320)
        gpFlavorsSettings.Margin = New Padding(4, 3, 4, 3)
        gpFlavorsSettings.Name = "gpFlavorsSettings"
        gpFlavorsSettings.Padding = New Padding(4, 3, 4, 3)
        gpFlavorsSettings.Size = New Size(455, 304)
        gpFlavorsSettings.TabIndex = 27
        gpFlavorsSettings.TabStop = False
        gpFlavorsSettings.Text = "Default Flavors Selection"
        ' 
        ' btnSaveFlavorDefaults
        ' 
        btnSaveFlavorDefaults.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSaveFlavorDefaults.Location = New Point(355, 83)
        btnSaveFlavorDefaults.Margin = New Padding(4, 3, 4, 3)
        btnSaveFlavorDefaults.Name = "btnSaveFlavorDefaults"
        btnSaveFlavorDefaults.Size = New Size(93, 58)
        btnSaveFlavorDefaults.TabIndex = 27
        btnSaveFlavorDefaults.Text = "Save Flavor Defaults"
        btnSaveFlavorDefaults.UseVisualStyleBackColor = True
        ' 
        ' clbSqlFiles
        ' 
        clbSqlFiles.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        clbSqlFiles.CheckOnClick = True
        clbSqlFiles.FormattingEnabled = True
        clbSqlFiles.HorizontalScrollbar = True
        clbSqlFiles.Location = New Point(4, 19)
        clbSqlFiles.Margin = New Padding(4, 3, 4, 3)
        clbSqlFiles.Name = "clbSqlFiles"
        clbSqlFiles.Size = New Size(314, 274)
        clbSqlFiles.TabIndex = 0
        ' 
        ' btnResetFlavorDefaults
        ' 
        btnResetFlavorDefaults.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnResetFlavorDefaults.Location = New Point(355, 18)
        btnResetFlavorDefaults.Margin = New Padding(4, 3, 4, 3)
        btnResetFlavorDefaults.Name = "btnResetFlavorDefaults"
        btnResetFlavorDefaults.Size = New Size(93, 58)
        btnResetFlavorDefaults.TabIndex = 28
        btnResetFlavorDefaults.Text = "Reset Flavor Defaults"
        btnResetFlavorDefaults.UseVisualStyleBackColor = True
        ' 
        ' gbAppLaunchSettings
        ' 
        gbAppLaunchSettings.BackColor = Color.LightGray
        gbAppLaunchSettings.Controls.Add(flpAppListButtons)
        gbAppLaunchSettings.Controls.Add(lblPrgListbox)
        gbAppLaunchSettings.Controls.Add(lstPrograms)
        gbAppLaunchSettings.Location = New Point(7, 7)
        gbAppLaunchSettings.Margin = New Padding(4, 3, 4, 3)
        gbAppLaunchSettings.Name = "gbAppLaunchSettings"
        gbAppLaunchSettings.Padding = New Padding(4, 3, 4, 3)
        gbAppLaunchSettings.Size = New Size(457, 307)
        gbAppLaunchSettings.TabIndex = 17
        gbAppLaunchSettings.TabStop = False
        gbAppLaunchSettings.Text = "Application Launcher Settings"
        ' 
        ' flpAppListButtons
        ' 
        flpAppListButtons.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        flpAppListButtons.BorderStyle = BorderStyle.Fixed3D
        flpAppListButtons.Controls.Add(btnAdd)
        flpAppListButtons.Controls.Add(btnEdit)
        flpAppListButtons.Controls.Add(btnDelete)
        flpAppListButtons.Controls.Add(btnLaunch)
        flpAppListButtons.FlowDirection = FlowDirection.TopDown
        flpAppListButtons.Location = New Point(345, 47)
        flpAppListButtons.Margin = New Padding(0)
        flpAppListButtons.Name = "flpAppListButtons"
        flpAppListButtons.Size = New Size(104, 239)
        flpAppListButtons.TabIndex = 16
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(2, 0)
        btnAdd.Margin = New Padding(2, 0, 0, 0)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(93, 58)
        btnAdd.TabIndex = 13
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(2, 58)
        btnEdit.Margin = New Padding(2, 0, 0, 0)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(93, 58)
        btnEdit.TabIndex = 12
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(2, 116)
        btnDelete.Margin = New Padding(2, 0, 0, 0)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(93, 58)
        btnDelete.TabIndex = 14
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnLaunch
        ' 
        btnLaunch.Location = New Point(2, 174)
        btnLaunch.Margin = New Padding(2, 0, 0, 0)
        btnLaunch.Name = "btnLaunch"
        btnLaunch.Size = New Size(93, 58)
        btnLaunch.TabIndex = 16
        btnLaunch.Text = "Launch"
        btnLaunch.UseVisualStyleBackColor = True
        ' 
        ' lblPrgListbox
        ' 
        lblPrgListbox.AutoSize = True
        lblPrgListbox.Location = New Point(10, 29)
        lblPrgListbox.Margin = New Padding(4, 0, 4, 0)
        lblPrgListbox.Name = "lblPrgListbox"
        lblPrgListbox.Size = New Size(89, 15)
        lblPrgListbox.TabIndex = 15
        lblPrgListbox.Text = "Application List"
        ' 
        ' lstPrograms
        ' 
        lstPrograms.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lstPrograms.ContextMenuStrip = cmsQuickLaunch
        lstPrograms.FormattingEnabled = True
        lstPrograms.ItemHeight = 15
        lstPrograms.Location = New Point(15, 47)
        lstPrograms.Margin = New Padding(4, 3, 4, 3)
        lstPrograms.Name = "lstPrograms"
        lstPrograms.Size = New Size(293, 214)
        lstPrograms.Sorted = True
        lstPrograms.TabIndex = 3
        ' 
        ' cmsQuickLaunch
        ' 
        cmsQuickLaunch.Items.AddRange(New ToolStripItem() {cmsQuickLaunchSlot1, cmsQuickLaunchSlot2})
        cmsQuickLaunch.Name = "cmsQuickLaunch"
        cmsQuickLaunch.Size = New Size(104, 48)
        cmsQuickLaunch.Text = "Assign to Quick Launch"
        ' 
        ' cmsQuickLaunchSlot1
        ' 
        cmsQuickLaunchSlot1.Name = "cmsQuickLaunchSlot1"
        cmsQuickLaunchSlot1.Size = New Size(103, 22)
        cmsQuickLaunchSlot1.Text = "Slot 1"
        ' 
        ' cmsQuickLaunchSlot2
        ' 
        cmsQuickLaunchSlot2.Name = "cmsQuickLaunchSlot2"
        cmsQuickLaunchSlot2.Size = New Size(103, 22)
        cmsQuickLaunchSlot2.Text = "Slot 2"
        ' 
        ' gbAppOptions
        ' 
        gbAppOptions.BackColor = Color.LightGray
        gbAppOptions.Controls.Add(TableLayoutPanel1)
        gbAppOptions.Location = New Point(582, 7)
        gbAppOptions.Margin = New Padding(4, 3, 4, 3)
        gbAppOptions.Name = "gbAppOptions"
        gbAppOptions.Padding = New Padding(4, 3, 4, 3)
        gbAppOptions.Size = New Size(581, 300)
        gbAppOptions.TabIndex = 17
        gbAppOptions.TabStop = False
        gbAppOptions.Text = "Application Options"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.Controls.Add(btnBackupScriptPath, 2, 6)
        TableLayoutPanel1.Controls.Add(tbBackupScriptPath, 1, 6)
        TableLayoutPanel1.Controls.Add(lblBackupPathOverride, 0, 7)
        TableLayoutPanel1.Controls.Add(btnBackupPathOverride, 2, 7)
        TableLayoutPanel1.Controls.Add(tbBackupPathOverride, 1, 7)
        TableLayoutPanel1.Controls.Add(btnBrowseApplyScript, 2, 5)
        TableLayoutPanel1.Controls.Add(lblBackupScriptPath, 0, 6)
        TableLayoutPanel1.Controls.Add(btnBrowseStartScript, 2, 4)
        TableLayoutPanel1.Controls.Add(tbApplyFlavorDefault, 1, 5)
        TableLayoutPanel1.Controls.Add(tbDatabaseStartDefault, 1, 4)
        TableLayoutPanel1.Controls.Add(tbWindowTitle, 1, 0)
        TableLayoutPanel1.Controls.Add(lblApplyFlavorDefault, 0, 5)
        TableLayoutPanel1.Controls.Add(tbRepoFolder, 1, 1)
        TableLayoutPanel1.Controls.Add(lblDatabaseStartDefault, 0, 4)
        TableLayoutPanel1.Controls.Add(btnRepoFolder, 2, 1)
        TableLayoutPanel1.Controls.Add(lblRepoFolder, 0, 1)
        TableLayoutPanel1.Controls.Add(lblSetupSwitches, 0, 2)
        TableLayoutPanel1.Controls.Add(tbSetupSwitches, 1, 2)
        TableLayoutPanel1.Controls.Add(lblWindowTitle, 0, 0)
        TableLayoutPanel1.Controls.Add(cbShowHiddenServices, 1, 3)
        TableLayoutPanel1.Controls.Add(lblShowHiddenServices, 0, 3)
        TableLayoutPanel1.Controls.Add(lblRunQaCmdLine, 0, 8)
        TableLayoutPanel1.Controls.Add(btnRunQaCmdLine, 2, 8)
        TableLayoutPanel1.Controls.Add(tbRunQaCmdLine, 1, 8)
        TableLayoutPanel1.Location = New Point(7, 22)
        TableLayoutPanel1.Margin = New Padding(4, 3, 4, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 9
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.RowStyles.Add(New RowStyle())
        TableLayoutPanel1.Size = New Size(568, 268)
        TableLayoutPanel1.TabIndex = 28
        ' 
        ' btnBackupScriptPath
        ' 
        btnBackupScriptPath.Location = New Point(529, 185)
        btnBackupScriptPath.Margin = New Padding(4, 3, 4, 3)
        btnBackupScriptPath.Name = "btnBackupScriptPath"
        btnBackupScriptPath.Size = New Size(35, 22)
        btnBackupScriptPath.TabIndex = 34
        btnBackupScriptPath.UseVisualStyleBackColor = True
        ' 
        ' tbBackupScriptPath
        ' 
        tbBackupScriptPath.Location = New Point(156, 185)
        tbBackupScriptPath.Name = "tbBackupScriptPath"
        tbBackupScriptPath.Size = New Size(366, 23)
        tbBackupScriptPath.TabIndex = 30
        ' 
        ' lblBackupPathOverride
        ' 
        lblBackupPathOverride.AutoSize = True
        lblBackupPathOverride.Dock = DockStyle.Fill
        lblBackupPathOverride.Location = New Point(4, 211)
        lblBackupPathOverride.Margin = New Padding(4, 0, 4, 0)
        lblBackupPathOverride.Name = "lblBackupPathOverride"
        lblBackupPathOverride.Size = New Size(145, 29)
        lblBackupPathOverride.TabIndex = 29
        lblBackupPathOverride.Text = "Override Backup Path:"
        lblBackupPathOverride.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btnBackupPathOverride
        ' 
        btnBackupPathOverride.Location = New Point(529, 214)
        btnBackupPathOverride.Margin = New Padding(4, 3, 4, 3)
        btnBackupPathOverride.Name = "btnBackupPathOverride"
        btnBackupPathOverride.Size = New Size(35, 22)
        btnBackupPathOverride.TabIndex = 29
        btnBackupPathOverride.UseVisualStyleBackColor = True
        ' 
        ' tbBackupPathOverride
        ' 
        tbBackupPathOverride.Dock = DockStyle.Fill
        tbBackupPathOverride.Location = New Point(156, 214)
        tbBackupPathOverride.Name = "tbBackupPathOverride"
        tbBackupPathOverride.PlaceholderText = "Using database value from AppOptions"
        tbBackupPathOverride.Size = New Size(366, 23)
        tbBackupPathOverride.TabIndex = 29
        ' 
        ' btnBrowseApplyScript
        ' 
        btnBrowseApplyScript.Location = New Point(529, 152)
        btnBrowseApplyScript.Margin = New Padding(4, 3, 4, 3)
        btnBrowseApplyScript.Name = "btnBrowseApplyScript"
        btnBrowseApplyScript.Size = New Size(35, 27)
        btnBrowseApplyScript.TabIndex = 32
        btnBrowseApplyScript.UseVisualStyleBackColor = True
        ' 
        ' lblBackupScriptPath
        ' 
        lblBackupScriptPath.AutoSize = True
        lblBackupScriptPath.Dock = DockStyle.Fill
        lblBackupScriptPath.Location = New Point(3, 182)
        lblBackupScriptPath.Name = "lblBackupScriptPath"
        lblBackupScriptPath.Size = New Size(147, 29)
        lblBackupScriptPath.TabIndex = 33
        lblBackupScriptPath.Text = "Backup Script Path:"
        lblBackupScriptPath.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btnBrowseStartScript
        ' 
        btnBrowseStartScript.Location = New Point(529, 119)
        btnBrowseStartScript.Margin = New Padding(4, 3, 4, 3)
        btnBrowseStartScript.Name = "btnBrowseStartScript"
        btnBrowseStartScript.Size = New Size(35, 27)
        btnBrowseStartScript.TabIndex = 31
        btnBrowseStartScript.UseVisualStyleBackColor = True
        ' 
        ' tbApplyFlavorDefault
        ' 
        tbApplyFlavorDefault.Dock = DockStyle.Fill
        tbApplyFlavorDefault.Location = New Point(157, 152)
        tbApplyFlavorDefault.Margin = New Padding(4, 3, 4, 3)
        tbApplyFlavorDefault.Name = "tbApplyFlavorDefault"
        tbApplyFlavorDefault.Size = New Size(364, 23)
        tbApplyFlavorDefault.TabIndex = 29
        ' 
        ' tbDatabaseStartDefault
        ' 
        tbDatabaseStartDefault.Dock = DockStyle.Fill
        tbDatabaseStartDefault.Location = New Point(157, 119)
        tbDatabaseStartDefault.Margin = New Padding(4, 3, 4, 3)
        tbDatabaseStartDefault.Name = "tbDatabaseStartDefault"
        tbDatabaseStartDefault.Size = New Size(364, 23)
        tbDatabaseStartDefault.TabIndex = 28
        ' 
        ' tbWindowTitle
        ' 
        tbWindowTitle.Dock = DockStyle.Fill
        tbWindowTitle.Location = New Point(157, 3)
        tbWindowTitle.Margin = New Padding(4, 3, 4, 3)
        tbWindowTitle.Name = "tbWindowTitle"
        tbWindowTitle.Size = New Size(364, 23)
        tbWindowTitle.TabIndex = 1
        ' 
        ' lblApplyFlavorDefault
        ' 
        lblApplyFlavorDefault.AutoSize = True
        lblApplyFlavorDefault.Dock = DockStyle.Fill
        lblApplyFlavorDefault.Location = New Point(4, 149)
        lblApplyFlavorDefault.Margin = New Padding(4, 0, 4, 0)
        lblApplyFlavorDefault.Name = "lblApplyFlavorDefault"
        lblApplyFlavorDefault.Size = New Size(145, 33)
        lblApplyFlavorDefault.TabIndex = 27
        lblApplyFlavorDefault.Text = "Apply Flavor Default:  "
        lblApplyFlavorDefault.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' tbRepoFolder
        ' 
        tbRepoFolder.Dock = DockStyle.Fill
        tbRepoFolder.Location = New Point(157, 32)
        tbRepoFolder.Margin = New Padding(4, 3, 4, 3)
        tbRepoFolder.Name = "tbRepoFolder"
        tbRepoFolder.Size = New Size(364, 23)
        tbRepoFolder.TabIndex = 3
        ' 
        ' lblDatabaseStartDefault
        ' 
        lblDatabaseStartDefault.AutoSize = True
        lblDatabaseStartDefault.Dock = DockStyle.Fill
        lblDatabaseStartDefault.Location = New Point(4, 116)
        lblDatabaseStartDefault.Margin = New Padding(4, 0, 4, 0)
        lblDatabaseStartDefault.Name = "lblDatabaseStartDefault"
        lblDatabaseStartDefault.Size = New Size(145, 33)
        lblDatabaseStartDefault.TabIndex = 26
        lblDatabaseStartDefault.Text = "Start Database Default:  "
        lblDatabaseStartDefault.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btnRepoFolder
        ' 
        btnRepoFolder.Location = New Point(529, 32)
        btnRepoFolder.Margin = New Padding(4, 3, 4, 3)
        btnRepoFolder.Name = "btnRepoFolder"
        btnRepoFolder.Size = New Size(35, 27)
        btnRepoFolder.TabIndex = 23
        btnRepoFolder.UseVisualStyleBackColor = True
        ' 
        ' lblRepoFolder
        ' 
        lblRepoFolder.AutoSize = True
        lblRepoFolder.Dock = DockStyle.Fill
        lblRepoFolder.Location = New Point(4, 29)
        lblRepoFolder.Margin = New Padding(4, 0, 4, 0)
        lblRepoFolder.Name = "lblRepoFolder"
        lblRepoFolder.Size = New Size(145, 33)
        lblRepoFolder.TabIndex = 4
        lblRepoFolder.Text = "Repo Folder:"
        lblRepoFolder.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblSetupSwitches
        ' 
        lblSetupSwitches.AutoSize = True
        lblSetupSwitches.Dock = DockStyle.Fill
        lblSetupSwitches.Location = New Point(4, 62)
        lblSetupSwitches.Margin = New Padding(4, 0, 4, 0)
        lblSetupSwitches.Name = "lblSetupSwitches"
        lblSetupSwitches.Size = New Size(145, 29)
        lblSetupSwitches.TabIndex = 25
        lblSetupSwitches.Text = "Installer Switches:"
        lblSetupSwitches.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' tbSetupSwitches
        ' 
        tbSetupSwitches.Dock = DockStyle.Fill
        tbSetupSwitches.Location = New Point(157, 65)
        tbSetupSwitches.Margin = New Padding(4, 3, 4, 3)
        tbSetupSwitches.Name = "tbSetupSwitches"
        tbSetupSwitches.Size = New Size(364, 23)
        tbSetupSwitches.TabIndex = 24
        ' 
        ' lblWindowTitle
        ' 
        lblWindowTitle.AutoSize = True
        lblWindowTitle.Dock = DockStyle.Fill
        lblWindowTitle.Location = New Point(4, 0)
        lblWindowTitle.Margin = New Padding(4, 0, 4, 0)
        lblWindowTitle.Name = "lblWindowTitle"
        lblWindowTitle.Size = New Size(145, 29)
        lblWindowTitle.TabIndex = 2
        lblWindowTitle.Text = "Window Title:"
        lblWindowTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' cbShowHiddenServices
        ' 
        cbShowHiddenServices.AutoSize = True
        cbShowHiddenServices.Location = New Point(157, 94)
        cbShowHiddenServices.Margin = New Padding(4, 3, 4, 3)
        cbShowHiddenServices.Name = "cbShowHiddenServices"
        cbShowHiddenServices.Size = New Size(244, 19)
        cbShowHiddenServices.TabIndex = 18
        cbShowHiddenServices.Text = "Shows uninstalled services when checked"
        cbShowHiddenServices.UseVisualStyleBackColor = True
        ' 
        ' lblShowHiddenServices
        ' 
        lblShowHiddenServices.AutoSize = True
        lblShowHiddenServices.Dock = DockStyle.Fill
        lblShowHiddenServices.Location = New Point(4, 91)
        lblShowHiddenServices.Margin = New Padding(4, 0, 4, 0)
        lblShowHiddenServices.Name = "lblShowHiddenServices"
        lblShowHiddenServices.Size = New Size(145, 25)
        lblShowHiddenServices.TabIndex = 30
        lblShowHiddenServices.Text = "Show Hidden Services:"
        lblShowHiddenServices.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblRunQaCmdLine
        ' 
        lblRunQaCmdLine.AutoSize = True
        lblRunQaCmdLine.Dock = DockStyle.Fill
        lblRunQaCmdLine.Location = New Point(3, 240)
        lblRunQaCmdLine.Name = "lblRunQaCmdLine"
        lblRunQaCmdLine.Size = New Size(147, 29)
        lblRunQaCmdLine.TabIndex = 35
        lblRunQaCmdLine.Text = "QA Server Command Line:"
        lblRunQaCmdLine.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btnRunQaCmdLine
        ' 
        btnRunQaCmdLine.Location = New Point(529, 243)
        btnRunQaCmdLine.Margin = New Padding(4, 3, 4, 3)
        btnRunQaCmdLine.Name = "btnRunQaCmdLine"
        btnRunQaCmdLine.Size = New Size(35, 22)
        btnRunQaCmdLine.TabIndex = 36
        btnRunQaCmdLine.UseVisualStyleBackColor = True
        ' 
        ' tbRunQaCmdLine
        ' 
        tbRunQaCmdLine.Dock = DockStyle.Fill
        tbRunQaCmdLine.Location = New Point(156, 243)
        tbRunQaCmdLine.Name = "tbRunQaCmdLine"
        tbRunQaCmdLine.Size = New Size(366, 23)
        tbRunQaCmdLine.TabIndex = 37
        ' 
        ' gpAdvUpgrade
        ' 
        gpAdvUpgrade.BackColor = Color.LightGray
        gpAdvUpgrade.Controls.Add(lblAdvUpgrade)
        gpAdvUpgrade.Controls.Add(tbAdvupgrade)
        gpAdvUpgrade.Controls.Add(cbAdvUpgradeNoBackup)
        gpAdvUpgrade.Controls.Add(cbAdvUpgradeNoSetup)
        gpAdvUpgrade.Controls.Add(cbAdvUpgradeQuiet)
        gpAdvUpgrade.Location = New Point(582, 371)
        gpAdvUpgrade.Margin = New Padding(4, 3, 4, 3)
        gpAdvUpgrade.Name = "gpAdvUpgrade"
        gpAdvUpgrade.Padding = New Padding(4, 3, 4, 3)
        gpAdvUpgrade.Size = New Size(352, 180)
        gpAdvUpgrade.TabIndex = 0
        gpAdvUpgrade.TabStop = False
        gpAdvUpgrade.Text = "Advantage Upgrade"
        ' 
        ' lblAdvUpgrade
        ' 
        lblAdvUpgrade.AutoSize = True
        lblAdvUpgrade.Location = New Point(16, 132)
        lblAdvUpgrade.Margin = New Padding(4, 0, 4, 0)
        lblAdvUpgrade.Name = "lblAdvUpgrade"
        lblAdvUpgrade.Size = New Size(89, 15)
        lblAdvUpgrade.TabIndex = 4
        lblAdvUpgrade.Text = "Command Line"
        ' 
        ' tbAdvupgrade
        ' 
        tbAdvupgrade.Location = New Point(20, 150)
        tbAdvupgrade.Margin = New Padding(4, 3, 4, 3)
        tbAdvupgrade.Name = "tbAdvupgrade"
        tbAdvupgrade.Size = New Size(313, 23)
        tbAdvupgrade.TabIndex = 3
        tbAdvupgrade.Text = "AdvUpgrade.exe"
        ' 
        ' cbAdvUpgradeNoBackup
        ' 
        cbAdvUpgradeNoBackup.AutoSize = True
        cbAdvUpgradeNoBackup.Location = New Point(20, 89)
        cbAdvUpgradeNoBackup.Margin = New Padding(4, 3, 4, 3)
        cbAdvUpgradeNoBackup.Name = "cbAdvUpgradeNoBackup"
        cbAdvUpgradeNoBackup.Size = New Size(214, 19)
        cbAdvUpgradeNoBackup.TabIndex = 2
        cbAdvUpgradeNoBackup.Text = "Do not make a backup [/nobackup]"
        cbAdvUpgradeNoBackup.UseVisualStyleBackColor = True
        ' 
        ' cbAdvUpgradeNoSetup
        ' 
        cbAdvUpgradeNoSetup.AutoSize = True
        cbAdvUpgradeNoSetup.Location = New Point(20, 62)
        cbAdvUpgradeNoSetup.Margin = New Padding(4, 3, 4, 3)
        cbAdvUpgradeNoSetup.Name = "cbAdvUpgradeNoSetup"
        cbAdvUpgradeNoSetup.Size = New Size(235, 19)
        cbAdvUpgradeNoSetup.TabIndex = 1
        cbAdvUpgradeNoSetup.Text = "Do not run Advantage Setup [/nosetup]"
        cbAdvUpgradeNoSetup.UseVisualStyleBackColor = True
        ' 
        ' cbAdvUpgradeQuiet
        ' 
        cbAdvUpgradeQuiet.AutoSize = True
        cbAdvUpgradeQuiet.Location = New Point(20, 36)
        cbAdvUpgradeQuiet.Margin = New Padding(4, 3, 4, 3)
        cbAdvUpgradeQuiet.Name = "cbAdvUpgradeQuiet"
        cbAdvUpgradeQuiet.Size = New Size(281, 19)
        cbAdvUpgradeQuiet.TabIndex = 0
        cbAdvUpgradeQuiet.Text = "Quiet Mode (Runs in Cmd Prompt Window) [/q]"
        cbAdvUpgradeQuiet.UseVisualStyleBackColor = True
        ' 
        ' pnlButtonCollection
        ' 
        pnlButtonCollection.Controls.Add(btnTest3)
        pnlButtonCollection.Controls.Add(gpDBStartVersion)
        pnlButtonCollection.Controls.Add(btnTest2)
        pnlButtonCollection.Controls.Add(gbAdvApps)
        pnlButtonCollection.Controls.Add(btnTest1)
        pnlButtonCollection.Controls.Add(gpCommonApps)
        pnlButtonCollection.Controls.Add(tbTest1)
        pnlButtonCollection.Controls.Add(tbTest2)
        pnlButtonCollection.Controls.Add(tbTest3)
        pnlButtonCollection.Dock = DockStyle.Top
        pnlButtonCollection.Location = New Point(0, 0)
        pnlButtonCollection.Name = "pnlButtonCollection"
        pnlButtonCollection.Size = New Size(1190, 191)
        pnlButtonCollection.TabIndex = 0
        ' 
        ' btnTest3
        ' 
        btnTest3.Location = New Point(1054, 158)
        btnTest3.Margin = New Padding(4, 3, 4, 3)
        btnTest3.Name = "btnTest3"
        btnTest3.Size = New Size(103, 27)
        btnTest3.TabIndex = 37
        btnTest3.Text = "Test Button 3"
        btnTest3.UseVisualStyleBackColor = True
        ' 
        ' gpDBStartVersion
        ' 
        gpDBStartVersion.BackColor = Color.LightGray
        gpDBStartVersion.Controls.Add(cbDbUseVersion)
        gpDBStartVersion.Controls.Add(tbDbUseVersion)
        gpDBStartVersion.Controls.Add(btnDbUseAdvVersion)
        gpDBStartVersion.Location = New Point(834, 0)
        gpDBStartVersion.Margin = New Padding(4, 3, 4, 3)
        gpDBStartVersion.Name = "gpDBStartVersion"
        gpDBStartVersion.Padding = New Padding(4, 3, 4, 3)
        gpDBStartVersion.Size = New Size(316, 87)
        gpDBStartVersion.TabIndex = 36
        gpDBStartVersion.TabStop = False
        gpDBStartVersion.Text = "Start DB Version"
        ' 
        ' cbDbUseVersion
        ' 
        cbDbUseVersion.AutoSize = True
        cbDbUseVersion.Location = New Point(110, 22)
        cbDbUseVersion.Name = "cbDbUseVersion"
        cbDbUseVersion.Size = New Size(169, 19)
        cbDbUseVersion.TabIndex = 2
        cbDbUseVersion.Text = "Start DB on specific version"
        cbDbUseVersion.UseVisualStyleBackColor = True
        ' 
        ' tbDbUseVersion
        ' 
        tbDbUseVersion.Location = New Point(110, 41)
        tbDbUseVersion.Name = "tbDbUseVersion"
        tbDbUseVersion.Size = New Size(111, 23)
        tbDbUseVersion.TabIndex = 1
        ' 
        ' btnDbUseAdvVersion
        ' 
        btnDbUseAdvVersion.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDbUseAdvVersion.Location = New Point(7, 19)
        btnDbUseAdvVersion.Name = "btnDbUseAdvVersion"
        btnDbUseAdvVersion.Size = New Size(97, 59)
        btnDbUseAdvVersion.TabIndex = 0
        btnDbUseAdvVersion.Text = "Use Software Version"
        btnDbUseAdvVersion.UseVisualStyleBackColor = True
        ' 
        ' btnTest2
        ' 
        btnTest2.Location = New Point(944, 158)
        btnTest2.Margin = New Padding(4, 3, 4, 3)
        btnTest2.Name = "btnTest2"
        btnTest2.Size = New Size(103, 27)
        btnTest2.TabIndex = 23
        btnTest2.Text = "Test Button 2"
        btnTest2.UseVisualStyleBackColor = True
        ' 
        ' gbAdvApps
        ' 
        gbAdvApps.BackColor = Color.LightGray
        gbAdvApps.Controls.Add(tlpButtons1)
        gbAdvApps.Location = New Point(4, 0)
        gbAdvApps.Margin = New Padding(4, 3, 4, 3)
        gbAdvApps.Name = "gbAdvApps"
        gbAdvApps.Padding = New Padding(4, 3, 4, 3)
        gbAdvApps.Size = New Size(506, 159)
        gbAdvApps.TabIndex = 19
        gbAdvApps.TabStop = False
        gbAdvApps.Text = "Advantage Applications"
        ' 
        ' tlpButtons1
        ' 
        tlpButtons1.BackColor = Color.LightGray
        tlpButtons1.ColumnCount = 5
        tlpButtons1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tlpButtons1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tlpButtons1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tlpButtons1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tlpButtons1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        tlpButtons1.Controls.Add(btnAdvUpgrade, 4, 1)
        tlpButtons1.Controls.Add(btnAdvKiosk, 3, 1)
        tlpButtons1.Controls.Add(btnAdvCardTech, 2, 1)
        tlpButtons1.Controls.Add(btnAdvRedeem, 1, 1)
        tlpButtons1.Controls.Add(btnAdvReportEditor, 0, 1)
        tlpButtons1.Controls.Add(btnAdvConfig, 4, 0)
        tlpButtons1.Controls.Add(btnAdvKioskSetup, 3, 0)
        tlpButtons1.Controls.Add(btnAdvGroups, 2, 0)
        tlpButtons1.Controls.Add(btnPos, 1, 0)
        tlpButtons1.Controls.Add(btnAdvManager, 0, 0)
        tlpButtons1.Dock = DockStyle.Fill
        tlpButtons1.Location = New Point(4, 19)
        tlpButtons1.Margin = New Padding(4, 3, 4, 3)
        tlpButtons1.Name = "tlpButtons1"
        tlpButtons1.RowCount = 2
        tlpButtons1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        tlpButtons1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        tlpButtons1.Size = New Size(498, 137)
        tlpButtons1.TabIndex = 37
        ' 
        ' btnAdvUpgrade
        ' 
        btnAdvUpgrade.Dock = DockStyle.Fill
        btnAdvUpgrade.Location = New Point(396, 68)
        btnAdvUpgrade.Margin = New Padding(0)
        btnAdvUpgrade.Name = "btnAdvUpgrade"
        btnAdvUpgrade.Size = New Size(102, 69)
        btnAdvUpgrade.TabIndex = 18
        btnAdvUpgrade.Text = "Advantage Upgrade"
        btnAdvUpgrade.UseVisualStyleBackColor = True
        ' 
        ' btnAdvKiosk
        ' 
        btnAdvKiosk.Dock = DockStyle.Fill
        btnAdvKiosk.Enabled = False
        btnAdvKiosk.Location = New Point(297, 68)
        btnAdvKiosk.Margin = New Padding(0)
        btnAdvKiosk.Name = "btnAdvKiosk"
        btnAdvKiosk.Size = New Size(99, 69)
        btnAdvKiosk.TabIndex = 20
        btnAdvKiosk.Text = "Kiosk"
        btnAdvKiosk.UseVisualStyleBackColor = True
        ' 
        ' btnAdvCardTech
        ' 
        btnAdvCardTech.Dock = DockStyle.Fill
        btnAdvCardTech.Enabled = False
        btnAdvCardTech.Location = New Point(198, 68)
        btnAdvCardTech.Margin = New Padding(0)
        btnAdvCardTech.Name = "btnAdvCardTech"
        btnAdvCardTech.Size = New Size(99, 69)
        btnAdvCardTech.TabIndex = 15
        btnAdvCardTech.Text = "Card Tech"
        btnAdvCardTech.UseVisualStyleBackColor = True
        ' 
        ' btnAdvRedeem
        ' 
        btnAdvRedeem.Dock = DockStyle.Fill
        btnAdvRedeem.Enabled = False
        btnAdvRedeem.Location = New Point(99, 68)
        btnAdvRedeem.Margin = New Padding(0)
        btnAdvRedeem.Name = "btnAdvRedeem"
        btnAdvRedeem.Size = New Size(99, 69)
        btnAdvRedeem.TabIndex = 15
        btnAdvRedeem.Text = "Redemption"
        btnAdvRedeem.UseVisualStyleBackColor = True
        ' 
        ' btnAdvReportEditor
        ' 
        btnAdvReportEditor.Dock = DockStyle.Fill
        btnAdvReportEditor.Enabled = False
        btnAdvReportEditor.Location = New Point(0, 68)
        btnAdvReportEditor.Margin = New Padding(0)
        btnAdvReportEditor.Name = "btnAdvReportEditor"
        btnAdvReportEditor.Size = New Size(99, 69)
        btnAdvReportEditor.TabIndex = 17
        btnAdvReportEditor.Text = "Report Editor"
        btnAdvReportEditor.UseVisualStyleBackColor = True
        ' 
        ' btnAdvConfig
        ' 
        btnAdvConfig.Dock = DockStyle.Fill
        btnAdvConfig.Location = New Point(396, 0)
        btnAdvConfig.Margin = New Padding(0)
        btnAdvConfig.Name = "btnAdvConfig"
        btnAdvConfig.Size = New Size(102, 68)
        btnAdvConfig.TabIndex = 12
        btnAdvConfig.Text = "CenterEdge Configuration"
        btnAdvConfig.UseVisualStyleBackColor = True
        ' 
        ' btnAdvKioskSetup
        ' 
        btnAdvKioskSetup.Dock = DockStyle.Fill
        btnAdvKioskSetup.Enabled = False
        btnAdvKioskSetup.Location = New Point(297, 0)
        btnAdvKioskSetup.Margin = New Padding(0)
        btnAdvKioskSetup.Name = "btnAdvKioskSetup"
        btnAdvKioskSetup.Size = New Size(99, 68)
        btnAdvKioskSetup.TabIndex = 19
        btnAdvKioskSetup.Text = "Kiosk Setup"
        btnAdvKioskSetup.UseVisualStyleBackColor = True
        ' 
        ' btnAdvGroups
        ' 
        btnAdvGroups.Dock = DockStyle.Fill
        btnAdvGroups.Enabled = False
        btnAdvGroups.Location = New Point(198, 0)
        btnAdvGroups.Margin = New Padding(0)
        btnAdvGroups.Name = "btnAdvGroups"
        btnAdvGroups.Size = New Size(99, 68)
        btnAdvGroups.TabIndex = 16
        btnAdvGroups.Text = "Groups"
        btnAdvGroups.UseVisualStyleBackColor = True
        ' 
        ' btnPos
        ' 
        btnPos.Dock = DockStyle.Fill
        btnPos.Enabled = False
        btnPos.Location = New Point(99, 0)
        btnPos.Margin = New Padding(0)
        btnPos.Name = "btnPos"
        btnPos.Size = New Size(99, 68)
        btnPos.TabIndex = 15
        btnPos.Text = "POS"
        btnPos.UseVisualStyleBackColor = True
        ' 
        ' btnAdvManager
        ' 
        btnAdvManager.Dock = DockStyle.Fill
        btnAdvManager.Enabled = False
        btnAdvManager.Location = New Point(0, 0)
        btnAdvManager.Margin = New Padding(0)
        btnAdvManager.Name = "btnAdvManager"
        btnAdvManager.Size = New Size(99, 68)
        btnAdvManager.TabIndex = 15
        btnAdvManager.Text = "Manager " & vbCrLf & "Console"
        btnAdvManager.UseVisualStyleBackColor = True
        ' 
        ' btnTest1
        ' 
        btnTest1.Location = New Point(848, 158)
        btnTest1.Margin = New Padding(4, 3, 4, 3)
        btnTest1.Name = "btnTest1"
        btnTest1.Size = New Size(88, 27)
        btnTest1.TabIndex = 18
        btnTest1.Text = "Test Button"
        btnTest1.UseVisualStyleBackColor = True
        ' 
        ' gpCommonApps
        ' 
        gpCommonApps.BackColor = Color.LightGray
        gpCommonApps.Controls.Add(tlpButtons2)
        gpCommonApps.Location = New Point(514, 0)
        gpCommonApps.Margin = New Padding(4, 3, 4, 3)
        gpCommonApps.Name = "gpCommonApps"
        gpCommonApps.Padding = New Padding(4, 3, 4, 3)
        gpCommonApps.Size = New Size(316, 159)
        gpCommonApps.TabIndex = 22
        gpCommonApps.TabStop = False
        gpCommonApps.Text = "Common Apps"
        ' 
        ' tlpButtons2
        ' 
        tlpButtons2.ColumnCount = 3
        tlpButtons2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        tlpButtons2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        tlpButtons2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        tlpButtons2.Controls.Add(btnServices, 2, 1)
        tlpButtons2.Controls.Add(btnCalc, 0, 0)
        tlpButtons2.Controls.Add(btnEventViewer, 1, 1)
        tlpButtons2.Controls.Add(btnDevices, 2, 0)
        tlpButtons2.Controls.Add(btnTaskmgr, 0, 1)
        tlpButtons2.Controls.Add(btnAppWiz, 1, 0)
        tlpButtons2.Dock = DockStyle.Fill
        tlpButtons2.Location = New Point(4, 19)
        tlpButtons2.Margin = New Padding(4, 3, 4, 3)
        tlpButtons2.Name = "tlpButtons2"
        tlpButtons2.RowCount = 2
        tlpButtons2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        tlpButtons2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        tlpButtons2.Size = New Size(308, 137)
        tlpButtons2.TabIndex = 36
        ' 
        ' btnServices
        ' 
        btnServices.Dock = DockStyle.Fill
        btnServices.Location = New Point(204, 68)
        btnServices.Margin = New Padding(0)
        btnServices.Name = "btnServices"
        btnServices.Size = New Size(104, 69)
        btnServices.TabIndex = 25
        btnServices.Text = "Services"
        btnServices.UseVisualStyleBackColor = True
        ' 
        ' btnCalc
        ' 
        btnCalc.Dock = DockStyle.Fill
        btnCalc.Location = New Point(0, 0)
        btnCalc.Margin = New Padding(0)
        btnCalc.Name = "btnCalc"
        btnCalc.Size = New Size(102, 68)
        btnCalc.TabIndex = 20
        btnCalc.Text = "Calculator"
        btnCalc.UseVisualStyleBackColor = True
        ' 
        ' btnEventViewer
        ' 
        btnEventViewer.Dock = DockStyle.Fill
        btnEventViewer.Location = New Point(102, 68)
        btnEventViewer.Margin = New Padding(0)
        btnEventViewer.Name = "btnEventViewer"
        btnEventViewer.Size = New Size(102, 69)
        btnEventViewer.TabIndex = 23
        btnEventViewer.Text = "Event Viewer"
        btnEventViewer.UseVisualStyleBackColor = True
        ' 
        ' btnDevices
        ' 
        btnDevices.Dock = DockStyle.Fill
        btnDevices.Location = New Point(204, 0)
        btnDevices.Margin = New Padding(0)
        btnDevices.Name = "btnDevices"
        btnDevices.Size = New Size(104, 68)
        btnDevices.TabIndex = 24
        btnDevices.Text = "Devices and Printers"
        btnDevices.UseVisualStyleBackColor = True
        ' 
        ' btnTaskmgr
        ' 
        btnTaskmgr.Dock = DockStyle.Fill
        btnTaskmgr.Location = New Point(0, 68)
        btnTaskmgr.Margin = New Padding(0)
        btnTaskmgr.Name = "btnTaskmgr"
        btnTaskmgr.Size = New Size(102, 69)
        btnTaskmgr.TabIndex = 21
        btnTaskmgr.Text = "Task Manager"
        btnTaskmgr.UseVisualStyleBackColor = True
        ' 
        ' btnAppWiz
        ' 
        btnAppWiz.Dock = DockStyle.Fill
        btnAppWiz.Location = New Point(102, 0)
        btnAppWiz.Margin = New Padding(0)
        btnAppWiz.Name = "btnAppWiz"
        btnAppWiz.Size = New Size(102, 68)
        btnAppWiz.TabIndex = 22
        btnAppWiz.Text = "Programs and Features"
        btnAppWiz.UseVisualStyleBackColor = True
        ' 
        ' tbTest1
        ' 
        tbTest1.Location = New Point(834, 84)
        tbTest1.Margin = New Padding(4, 3, 4, 3)
        tbTest1.Name = "tbTest1"
        tbTest1.Size = New Size(271, 23)
        tbTest1.TabIndex = 19
        tbTest1.Text = "tbTest1"
        ' 
        ' tbTest2
        ' 
        tbTest2.Location = New Point(834, 107)
        tbTest2.Margin = New Padding(4, 3, 4, 3)
        tbTest2.Name = "tbTest2"
        tbTest2.Size = New Size(271, 23)
        tbTest2.TabIndex = 20
        tbTest2.Text = "tbTest2"
        ' 
        ' tbTest3
        ' 
        tbTest3.Location = New Point(834, 130)
        tbTest3.Margin = New Padding(4, 3, 4, 3)
        tbTest3.Name = "tbTest3"
        tbTest3.Size = New Size(271, 23)
        tbTest3.TabIndex = 21
        tbTest3.Text = "tbTest3"
        ' 
        ' btnRunDatabaseStartLive
        ' 
        btnRunDatabaseStartLive.ContextMenuStrip = cmsDbStart
        btnRunDatabaseStartLive.Dock = DockStyle.Fill
        btnRunDatabaseStartLive.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnRunDatabaseStartLive.Location = New Point(290, 116)
        btnRunDatabaseStartLive.Margin = New Padding(0)
        btnRunDatabaseStartLive.Name = "btnRunDatabaseStartLive"
        btnRunDatabaseStartLive.Size = New Size(96, 55)
        btnRunDatabaseStartLive.TabIndex = 31
        btnRunDatabaseStartLive.Text = "Start Database"
        btnRunDatabaseStartLive.UseVisualStyleBackColor = True
        ' 
        ' cmsDbStart
        ' 
        cmsDbStart.Items.AddRange(New ToolStripItem() {tsmiStartDbRaw, tsmiStartDbBackup, cmsDbStartSeparator1, tsmiBackupDb})
        cmsDbStart.Name = "ContextMenuStrip1"
        cmsDbStart.Size = New Size(288, 76)
        ' 
        ' tsmiStartDbRaw
        ' 
        tsmiStartDbRaw.Name = "tsmiStartDbRaw"
        tsmiStartDbRaw.Size = New Size(287, 22)
        tsmiStartDbRaw.Text = "Start DB with no options (raw)"
        ' 
        ' tsmiStartDbBackup
        ' 
        tsmiStartDbBackup.Name = "tsmiStartDbBackup"
        tsmiStartDbBackup.Size = New Size(287, 22)
        tsmiStartDbBackup.Text = "Start Database with backup 00Pathfinder"
        ' 
        ' cmsDbStartSeparator1
        ' 
        cmsDbStartSeparator1.Name = "cmsDbStartSeparator1"
        cmsDbStartSeparator1.Size = New Size(284, 6)
        ' 
        ' tsmiBackupDb
        ' 
        tsmiBackupDb.Name = "tsmiBackupDb"
        tsmiBackupDb.Size = New Size(287, 22)
        tsmiBackupDb.Text = "Backup Database to 00Pathfinder"
        ' 
        ' btnRunApplyFlavorLive
        ' 
        btnRunApplyFlavorLive.Dock = DockStyle.Fill
        btnRunApplyFlavorLive.Location = New Point(290, 2)
        btnRunApplyFlavorLive.Margin = New Padding(0)
        btnRunApplyFlavorLive.Name = "btnRunApplyFlavorLive"
        btnRunApplyFlavorLive.Size = New Size(96, 55)
        btnRunApplyFlavorLive.TabIndex = 30
        btnRunApplyFlavorLive.Text = "Apply Default Flavors"
        btnRunApplyFlavorLive.UseVisualStyleBackColor = True
        ' 
        ' cmbboxAppLaunch
        ' 
        cmbboxAppLaunch.DropDownStyle = ComboBoxStyle.DropDownList
        cmbboxAppLaunch.FormattingEnabled = True
        cmbboxAppLaunch.Location = New Point(4, 552)
        cmbboxAppLaunch.Margin = New Padding(4, 3, 4, 3)
        cmbboxAppLaunch.Name = "cmbboxAppLaunch"
        cmbboxAppLaunch.Size = New Size(278, 23)
        cmbboxAppLaunch.Sorted = True
        cmbboxAppLaunch.TabIndex = 18
        ' 
        ' btnComboAppLaunch
        ' 
        btnComboAppLaunch.Location = New Point(290, 552)
        btnComboAppLaunch.Margin = New Padding(4, 3, 4, 3)
        btnComboAppLaunch.Name = "btnComboAppLaunch"
        btnComboAppLaunch.Size = New Size(88, 27)
        btnComboAppLaunch.TabIndex = 19
        btnComboAppLaunch.Text = "Launch"
        btnComboAppLaunch.UseVisualStyleBackColor = True
        ' 
        ' btnReconnect
        ' 
        btnReconnect.Dock = DockStyle.Fill
        btnReconnect.Location = New Point(2, 116)
        btnReconnect.Margin = New Padding(0)
        btnReconnect.Name = "btnReconnect"
        btnReconnect.Size = New Size(94, 55)
        btnReconnect.TabIndex = 22
        btnReconnect.Text = "Reconnect"
        btnReconnect.UseVisualStyleBackColor = True
        ' 
        ' flpQuickLaunch
        ' 
        flpQuickLaunch.AllowDrop = True
        flpQuickLaunch.BackColor = Color.LightGray
        flpQuickLaunch.Controls.Add(Button1)
        flpQuickLaunch.Controls.Add(Button2)
        flpQuickLaunch.Controls.Add(Button3)
        flpQuickLaunch.Controls.Add(Button4)
        flpQuickLaunch.Controls.Add(Button5)
        flpQuickLaunch.Controls.Add(Button6)
        flpQuickLaunch.Controls.Add(Button7)
        flpQuickLaunch.Controls.Add(Button8)
        flpQuickLaunch.Controls.Add(Button9)
        flpQuickLaunch.Controls.Add(Button10)
        flpQuickLaunch.Controls.Add(Button11)
        flpQuickLaunch.Controls.Add(Button12)
        flpQuickLaunch.Controls.Add(Button13)
        flpQuickLaunch.Controls.Add(Button14)
        flpQuickLaunch.Controls.Add(Button15)
        flpQuickLaunch.Controls.Add(Button16)
        flpQuickLaunch.Controls.Add(Button17)
        flpQuickLaunch.Controls.Add(Button18)
        flpQuickLaunch.Controls.Add(Button19)
        flpQuickLaunch.Controls.Add(Button20)
        flpQuickLaunch.FlowDirection = FlowDirection.TopDown
        flpQuickLaunch.ForeColor = SystemColors.ControlText
        flpQuickLaunch.Location = New Point(0, 0)
        flpQuickLaunch.Margin = New Padding(4, 3, 4, 3)
        flpQuickLaunch.Name = "flpQuickLaunch"
        flpQuickLaunch.Size = New Size(387, 546)
        flpQuickLaunch.TabIndex = 21
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(3, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(160, 48)
        Button1.TabIndex = 0
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        Button1.Visible = False
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(3, 57)
        Button2.Name = "Button2"
        Button2.Size = New Size(160, 48)
        Button2.TabIndex = 1
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        Button2.Visible = False
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(3, 111)
        Button3.Name = "Button3"
        Button3.Size = New Size(160, 48)
        Button3.TabIndex = 2
        Button3.Text = "Button3"
        Button3.UseVisualStyleBackColor = True
        Button3.Visible = False
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(3, 165)
        Button4.Name = "Button4"
        Button4.Size = New Size(160, 48)
        Button4.TabIndex = 3
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = True
        Button4.Visible = False
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(3, 219)
        Button5.Name = "Button5"
        Button5.Size = New Size(160, 48)
        Button5.TabIndex = 4
        Button5.Text = "Button5"
        Button5.UseVisualStyleBackColor = True
        Button5.Visible = False
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(3, 273)
        Button6.Name = "Button6"
        Button6.Size = New Size(160, 48)
        Button6.TabIndex = 5
        Button6.Text = "Button6"
        Button6.UseVisualStyleBackColor = True
        Button6.Visible = False
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(3, 327)
        Button7.Name = "Button7"
        Button7.Size = New Size(160, 48)
        Button7.TabIndex = 6
        Button7.Text = "Button7"
        Button7.UseVisualStyleBackColor = True
        Button7.Visible = False
        ' 
        ' Button8
        ' 
        Button8.Location = New Point(3, 381)
        Button8.Name = "Button8"
        Button8.Size = New Size(160, 48)
        Button8.TabIndex = 7
        Button8.Text = "Button8"
        Button8.UseVisualStyleBackColor = True
        Button8.Visible = False
        ' 
        ' Button9
        ' 
        Button9.Location = New Point(3, 435)
        Button9.Name = "Button9"
        Button9.Size = New Size(160, 48)
        Button9.TabIndex = 8
        Button9.Text = "Button9"
        Button9.UseVisualStyleBackColor = True
        Button9.Visible = False
        ' 
        ' Button10
        ' 
        Button10.Location = New Point(3, 489)
        Button10.Name = "Button10"
        Button10.Size = New Size(160, 48)
        Button10.TabIndex = 9
        Button10.Text = "Button10"
        Button10.UseVisualStyleBackColor = True
        Button10.Visible = False
        ' 
        ' Button11
        ' 
        Button11.Location = New Point(169, 3)
        Button11.Name = "Button11"
        Button11.Size = New Size(160, 48)
        Button11.TabIndex = 10
        Button11.Text = "Button11"
        Button11.UseVisualStyleBackColor = True
        Button11.Visible = False
        ' 
        ' Button12
        ' 
        Button12.Location = New Point(169, 57)
        Button12.Name = "Button12"
        Button12.Size = New Size(160, 48)
        Button12.TabIndex = 11
        Button12.Text = "Button12"
        Button12.UseVisualStyleBackColor = True
        Button12.Visible = False
        ' 
        ' Button13
        ' 
        Button13.Location = New Point(169, 111)
        Button13.Name = "Button13"
        Button13.Size = New Size(160, 48)
        Button13.TabIndex = 12
        Button13.Text = "Button13"
        Button13.UseVisualStyleBackColor = True
        Button13.Visible = False
        ' 
        ' Button14
        ' 
        Button14.Location = New Point(169, 165)
        Button14.Name = "Button14"
        Button14.Size = New Size(160, 48)
        Button14.TabIndex = 13
        Button14.Text = "Button14"
        Button14.UseVisualStyleBackColor = True
        Button14.Visible = False
        ' 
        ' Button15
        ' 
        Button15.Location = New Point(169, 219)
        Button15.Name = "Button15"
        Button15.Size = New Size(160, 48)
        Button15.TabIndex = 14
        Button15.Text = "Button15"
        Button15.UseVisualStyleBackColor = True
        Button15.Visible = False
        ' 
        ' Button16
        ' 
        Button16.Location = New Point(169, 273)
        Button16.Name = "Button16"
        Button16.Size = New Size(160, 48)
        Button16.TabIndex = 15
        Button16.Text = "Button16"
        Button16.UseVisualStyleBackColor = True
        Button16.Visible = False
        ' 
        ' Button17
        ' 
        Button17.Location = New Point(169, 327)
        Button17.Name = "Button17"
        Button17.Size = New Size(160, 48)
        Button17.TabIndex = 16
        Button17.Text = "Button17"
        Button17.UseVisualStyleBackColor = True
        Button17.Visible = False
        ' 
        ' Button18
        ' 
        Button18.Location = New Point(169, 381)
        Button18.Name = "Button18"
        Button18.Size = New Size(160, 48)
        Button18.TabIndex = 17
        Button18.Text = "Button18"
        Button18.UseVisualStyleBackColor = True
        Button18.Visible = False
        ' 
        ' Button19
        ' 
        Button19.Location = New Point(169, 435)
        Button19.Name = "Button19"
        Button19.Size = New Size(160, 48)
        Button19.TabIndex = 18
        Button19.Text = "Button19"
        Button19.UseVisualStyleBackColor = True
        Button19.Visible = False
        ' 
        ' Button20
        ' 
        Button20.Location = New Point(169, 489)
        Button20.Name = "Button20"
        Button20.Size = New Size(160, 48)
        Button20.TabIndex = 19
        Button20.Text = "Button20"
        Button20.UseVisualStyleBackColor = True
        Button20.Visible = False
        ' 
        ' btnAdminRestart
        ' 
        btnAdminRestart.Dock = DockStyle.Fill
        btnAdminRestart.Location = New Point(2, 59)
        btnAdminRestart.Margin = New Padding(0)
        btnAdminRestart.Name = "btnAdminRestart"
        btnAdminRestart.Size = New Size(94, 55)
        btnAdminRestart.TabIndex = 20
        btnAdminRestart.Text = "Relaunch as Admin"
        btnAdminRestart.UseVisualStyleBackColor = True
        ' 
        ' btnBatchLaunch
        ' 
        btnBatchLaunch.Dock = DockStyle.Fill
        btnBatchLaunch.Location = New Point(2, 2)
        btnBatchLaunch.Margin = New Padding(0)
        btnBatchLaunch.Name = "btnBatchLaunch"
        btnBatchLaunch.Size = New Size(94, 55)
        btnBatchLaunch.TabIndex = 15
        btnBatchLaunch.Text = "Batch Launch"
        btnBatchLaunch.UseVisualStyleBackColor = True
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {tslblTime, tslblCeVersion, tslblNetVersion, tslblExecutionStatus, tslblDbState})
        StatusStrip1.Location = New Point(0, 860)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 16, 0)
        StatusStrip1.Size = New Size(1600, 24)
        StatusStrip1.TabIndex = 12
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' tslblTime
        ' 
        tslblTime.BorderSides = ToolStripStatusLabelBorderSides.Left Or ToolStripStatusLabelBorderSides.Top Or ToolStripStatusLabelBorderSides.Right Or ToolStripStatusLabelBorderSides.Bottom
        tslblTime.BorderStyle = Border3DStyle.Bump
        tslblTime.Name = "tslblTime"
        tslblTime.Size = New Size(60, 19)
        tslblTime.Text = "tslblTime"
        ' 
        ' tslblCeVersion
        ' 
        tslblCeVersion.BorderSides = ToolStripStatusLabelBorderSides.Left Or ToolStripStatusLabelBorderSides.Top Or ToolStripStatusLabelBorderSides.Right Or ToolStripStatusLabelBorderSides.Bottom
        tslblCeVersion.BorderStyle = Border3DStyle.Bump
        tslblCeVersion.Name = "tslblCeVersion"
        tslblCeVersion.Size = New Size(85, 19)
        tslblCeVersion.Text = "tslblCeVersion"
        ' 
        ' tslblNetVersion
        ' 
        tslblNetVersion.BorderSides = ToolStripStatusLabelBorderSides.Left Or ToolStripStatusLabelBorderSides.Top Or ToolStripStatusLabelBorderSides.Right Or ToolStripStatusLabelBorderSides.Bottom
        tslblNetVersion.BorderStyle = Border3DStyle.Bump
        tslblNetVersion.Name = "tslblNetVersion"
        tslblNetVersion.Size = New Size(90, 19)
        tslblNetVersion.Text = "tslblNetVersion"
        ' 
        ' tslblExecutionStatus
        ' 
        tslblExecutionStatus.BorderSides = ToolStripStatusLabelBorderSides.Left Or ToolStripStatusLabelBorderSides.Top Or ToolStripStatusLabelBorderSides.Right Or ToolStripStatusLabelBorderSides.Bottom
        tslblExecutionStatus.BorderStyle = Border3DStyle.Bump
        tslblExecutionStatus.DisplayStyle = ToolStripItemDisplayStyle.Text
        tslblExecutionStatus.Name = "tslblExecutionStatus"
        tslblExecutionStatus.Size = New Size(116, 19)
        tslblExecutionStatus.Text = "tslblExecutionStatus"
        ' 
        ' tslblDbState
        ' 
        tslblDbState.BackColor = Color.DarkGreen
        tslblDbState.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        tslblDbState.ForeColor = Color.WhiteSmoke
        tslblDbState.Name = "tslblDbState"
        tslblDbState.Size = New Size(50, 19)
        tslblDbState.Text = "ONLINE"
        ' 
        ' tmr10Seconds
        ' 
        tmr10Seconds.Enabled = True
        tmr10Seconds.Interval = 10000
        ' 
        ' BottomToolStripPanel
        ' 
        BottomToolStripPanel.Location = New Point(0, 0)
        BottomToolStripPanel.Name = "BottomToolStripPanel"
        BottomToolStripPanel.Orientation = Orientation.Horizontal
        BottomToolStripPanel.RowMargin = New Padding(3, 0, 0, 0)
        BottomToolStripPanel.Size = New Size(0, 0)
        ' 
        ' TopToolStripPanel
        ' 
        TopToolStripPanel.Location = New Point(0, 0)
        TopToolStripPanel.Name = "TopToolStripPanel"
        TopToolStripPanel.Orientation = Orientation.Horizontal
        TopToolStripPanel.RowMargin = New Padding(3, 0, 0, 0)
        TopToolStripPanel.Size = New Size(0, 0)
        ' 
        ' RightToolStripPanel
        ' 
        RightToolStripPanel.Location = New Point(0, 0)
        RightToolStripPanel.Name = "RightToolStripPanel"
        RightToolStripPanel.Orientation = Orientation.Horizontal
        RightToolStripPanel.RowMargin = New Padding(3, 0, 0, 0)
        RightToolStripPanel.Size = New Size(0, 0)
        ' 
        ' LeftToolStripPanel
        ' 
        LeftToolStripPanel.Location = New Point(0, 0)
        LeftToolStripPanel.Name = "LeftToolStripPanel"
        LeftToolStripPanel.Orientation = Orientation.Horizontal
        LeftToolStripPanel.RowMargin = New Padding(3, 0, 0, 0)
        LeftToolStripPanel.Size = New Size(0, 0)
        ' 
        ' ContentPanel
        ' 
        ContentPanel.Size = New Size(150, 125)
        ' 
        ' tmr1Sec
        ' 
        tmr1Sec.Enabled = True
        tmr1Sec.Interval = 250
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.BorderStyle = BorderStyle.Fixed3D
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer2.Location = New Point(0, 0)
        SplitContainer2.Margin = New Padding(4, 3, 4, 3)
        SplitContainer2.Name = "SplitContainer2"
        SplitContainer2.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer2.Panel1
        ' 
        SplitContainer2.Panel1.Controls.Add(flpQuickLaunch)
        SplitContainer2.Panel1.Controls.Add(cmbboxAppLaunch)
        SplitContainer2.Panel1.Controls.Add(btnComboAppLaunch)
        ' 
        ' SplitContainer2.Panel2
        ' 
        SplitContainer2.Panel2.BackColor = Color.LightGray
        SplitContainer2.Panel2.Controls.Add(pnlButtonsLabel)
        SplitContainer2.Panel2.Controls.Add(pnlButtons)
        SplitContainer2.Size = New Size(392, 853)
        SplitContainer2.SplitterDistance = 587
        SplitContainer2.SplitterWidth = 3
        SplitContainer2.TabIndex = 22
        ' 
        ' pnlButtonsLabel
        ' 
        pnlButtonsLabel.Controls.Add(lblButtons)
        pnlButtonsLabel.Dock = DockStyle.Bottom
        pnlButtonsLabel.Location = New Point(0, 232)
        pnlButtonsLabel.Name = "pnlButtonsLabel"
        pnlButtonsLabel.Size = New Size(388, 27)
        pnlButtonsLabel.TabIndex = 17
        ' 
        ' lblButtons
        ' 
        lblButtons.BorderStyle = BorderStyle.FixedSingle
        lblButtons.Dock = DockStyle.Fill
        lblButtons.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblButtons.Location = New Point(0, 0)
        lblButtons.Name = "lblButtons"
        lblButtons.Size = New Size(388, 27)
        lblButtons.TabIndex = 1
        lblButtons.Text = "Bold buttons have Right Click Menus"
        lblButtons.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlButtons
        ' 
        pnlButtons.Controls.Add(tlpButtons3)
        pnlButtons.Dock = DockStyle.Top
        pnlButtons.Location = New Point(0, 0)
        pnlButtons.Name = "pnlButtons"
        pnlButtons.Size = New Size(388, 230)
        pnlButtons.TabIndex = 0
        ' 
        ' tlpButtons3
        ' 
        tlpButtons3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset
        tlpButtons3.ColumnCount = 4
        tlpButtons3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpButtons3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpButtons3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpButtons3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        tlpButtons3.Controls.Add(btnRunQaApi, 2, 3)
        tlpButtons3.Controls.Add(btnUpdateShiftDate, 2, 1)
        tlpButtons3.Controls.Add(btnExit, 3, 3)
        tlpButtons3.Controls.Add(btnBatchLaunch, 0, 0)
        tlpButtons3.Controls.Add(btnAdminRestart, 0, 1)
        tlpButtons3.Controls.Add(btnReconnect, 0, 2)
        tlpButtons3.Controls.Add(btnRunApplyFlavorLive, 3, 0)
        tlpButtons3.Controls.Add(btnRepoMain, 1, 3)
        tlpButtons3.Controls.Add(btnSetupInstall, 1, 0)
        tlpButtons3.Controls.Add(btnLaunchLatestInstaller, 1, 1)
        tlpButtons3.Controls.Add(btnRepoDiscardChanges, 1, 2)
        tlpButtons3.Controls.Add(btnManageInstallerVersions, 2, 0)
        tlpButtons3.Controls.Add(btnRunDatabaseStartLive, 3, 2)
        tlpButtons3.Controls.Add(btnApplyPersonalFlavor, 3, 1)
        tlpButtons3.Dock = DockStyle.Fill
        tlpButtons3.Location = New Point(0, 0)
        tlpButtons3.Margin = New Padding(4, 3, 4, 3)
        tlpButtons3.Name = "tlpButtons3"
        tlpButtons3.RowCount = 4
        tlpButtons3.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpButtons3.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpButtons3.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpButtons3.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        tlpButtons3.Size = New Size(388, 230)
        tlpButtons3.TabIndex = 0
        ' 
        ' btnRunQaApi
        ' 
        btnRunQaApi.ContextMenuStrip = cmsRunQaApi
        btnRunQaApi.Dock = DockStyle.Fill
        btnRunQaApi.Location = New Point(194, 173)
        btnRunQaApi.Margin = New Padding(0)
        btnRunQaApi.Name = "btnRunQaApi"
        btnRunQaApi.Size = New Size(94, 55)
        btnRunQaApi.TabIndex = 35
        btnRunQaApi.Text = "Run Local QA Server"
        btnRunQaApi.UseVisualStyleBackColor = True
        ' 
        ' cmsRunQaApi
        ' 
        cmsRunQaApi.Items.AddRange(New ToolStripItem() {tsmiRunQaApiRerunScript, tsmiQaScriptKill, cmsSeparator1, tsmiQaMenuPromptDefaults})
        cmsRunQaApi.Name = "cmsRunQaApi"
        cmsRunQaApi.Size = New Size(289, 76)
        ' 
        ' tsmiRunQaApiRerunScript
        ' 
        tsmiRunQaApiRerunScript.Name = "tsmiRunQaApiRerunScript"
        tsmiRunQaApiRerunScript.Size = New Size(288, 22)
        tsmiRunQaApiRerunScript.Text = "Kill running script and start new instance"
        ' 
        ' tsmiQaScriptKill
        ' 
        tsmiQaScriptKill.Name = "tsmiQaScriptKill"
        tsmiQaScriptKill.Size = New Size(288, 22)
        tsmiQaScriptKill.Text = "End the QA Api Server Script"
        ' 
        ' cmsSeparator1
        ' 
        cmsSeparator1.Name = "cmsSeparator1"
        cmsSeparator1.Size = New Size(285, 6)
        ' 
        ' tsmiQaMenuPromptDefaults
        ' 
        tsmiQaMenuPromptDefaults.Name = "tsmiQaMenuPromptDefaults"
        tsmiQaMenuPromptDefaults.Size = New Size(288, 22)
        tsmiQaMenuPromptDefaults.Text = "Set Prompt Defaults"
        ' 
        ' btnUpdateShiftDate
        ' 
        btnUpdateShiftDate.Dock = DockStyle.Fill
        btnUpdateShiftDate.Location = New Point(194, 59)
        btnUpdateShiftDate.Margin = New Padding(0)
        btnUpdateShiftDate.Name = "btnUpdateShiftDate"
        btnUpdateShiftDate.Size = New Size(94, 55)
        btnUpdateShiftDate.TabIndex = 33
        btnUpdateShiftDate.Text = "Update Shift Date"
        btnUpdateShiftDate.UseVisualStyleBackColor = True
        ' 
        ' btnRepoMain
        ' 
        btnRepoMain.Dock = DockStyle.Fill
        btnRepoMain.Location = New Point(98, 173)
        btnRepoMain.Margin = New Padding(0)
        btnRepoMain.Name = "btnRepoMain"
        btnRepoMain.Size = New Size(94, 55)
        btnRepoMain.TabIndex = 26
        btnRepoMain.Text = "Switch Repo to Main"
        btnRepoMain.UseVisualStyleBackColor = True
        ' 
        ' btnSetupInstall
        ' 
        btnSetupInstall.Dock = DockStyle.Fill
        btnSetupInstall.Location = New Point(98, 2)
        btnSetupInstall.Margin = New Padding(0)
        btnSetupInstall.Name = "btnSetupInstall"
        btnSetupInstall.Size = New Size(94, 55)
        btnSetupInstall.TabIndex = 25
        btnSetupInstall.Text = "Extract and Install"
        btnSetupInstall.UseVisualStyleBackColor = True
        ' 
        ' btnLaunchLatestInstaller
        ' 
        btnLaunchLatestInstaller.Dock = DockStyle.Fill
        btnLaunchLatestInstaller.Location = New Point(98, 59)
        btnLaunchLatestInstaller.Margin = New Padding(0)
        btnLaunchLatestInstaller.Name = "btnLaunchLatestInstaller"
        btnLaunchLatestInstaller.Size = New Size(94, 55)
        btnLaunchLatestInstaller.TabIndex = 23
        btnLaunchLatestInstaller.Text = "Latest Installer"
        btnLaunchLatestInstaller.UseVisualStyleBackColor = True
        ' 
        ' btnRepoDiscardChanges
        ' 
        btnRepoDiscardChanges.Dock = DockStyle.Fill
        btnRepoDiscardChanges.Location = New Point(98, 116)
        btnRepoDiscardChanges.Margin = New Padding(0)
        btnRepoDiscardChanges.Name = "btnRepoDiscardChanges"
        btnRepoDiscardChanges.Size = New Size(94, 55)
        btnRepoDiscardChanges.TabIndex = 24
        btnRepoDiscardChanges.Text = "Discard Repo Changes"
        btnRepoDiscardChanges.UseVisualStyleBackColor = True
        ' 
        ' btnManageInstallerVersions
        ' 
        btnManageInstallerVersions.Dock = DockStyle.Fill
        btnManageInstallerVersions.Location = New Point(194, 2)
        btnManageInstallerVersions.Margin = New Padding(0)
        btnManageInstallerVersions.Name = "btnManageInstallerVersions"
        btnManageInstallerVersions.Size = New Size(94, 55)
        btnManageInstallerVersions.TabIndex = 32
        btnManageInstallerVersions.Text = "Manage Installer Versions"
        btnManageInstallerVersions.UseVisualStyleBackColor = True
        ' 
        ' btnApplyPersonalFlavor
        ' 
        btnApplyPersonalFlavor.Location = New Point(290, 59)
        btnApplyPersonalFlavor.Margin = New Padding(0)
        btnApplyPersonalFlavor.Name = "btnApplyPersonalFlavor"
        btnApplyPersonalFlavor.Size = New Size(96, 55)
        btnApplyPersonalFlavor.TabIndex = 34
        btnApplyPersonalFlavor.Text = "Apply Personal Flavor"
        ToolTip1.SetToolTip(btnApplyPersonalFlavor, "Copy the Personal Flavor SQL to the Flavors folder and then apply it.")
        btnApplyPersonalFlavor.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel2.Controls.Add(SplitContainer2)
        Panel2.Location = New Point(1194, 0)
        Panel2.Margin = New Padding(4, 3, 4, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(392, 853)
        Panel2.TabIndex = 13
        ' 
        ' ofdStartScript
        ' 
        ofdStartScript.FileName = "OpenFileDialog1"
        ' 
        ' ToolTip1
        ' 
        ToolTip1.AutoPopDelay = 8000
        ToolTip1.InitialDelay = 200
        ToolTip1.ReshowDelay = 100
        ToolTip1.ShowAlways = True
        ' 
        ' FormMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnExit
        ClientSize = New Size(1600, 884)
        Controls.Add(Panel2)
        Controls.Add(StatusStrip1)
        Controls.Add(SplitContainer1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        Margin = New Padding(4, 3, 4, 3)
        Name = "FormMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Support Tech Assistant"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        tcSTA.ResumeLayout(False)
        tpGeneral.ResumeLayout(False)
        gpLicInfo.ResumeLayout(False)
        gpLicInfo.PerformLayout()
        gbLiveOutput.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        pnlServicesContainer.ResumeLayout(False)
        pnlServicesContainer.PerformLayout()
        gbFlavorsList.ResumeLayout(False)
        pnlFlavorsList.ResumeLayout(False)
        cmsApplySingleFlavor.ResumeLayout(False)
        tpAdvData.ResumeLayout(False)
        tpAdvData.PerformLayout()
        CType(dgvApplicationInfo, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvWebOptions, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvAppOptions, ComponentModel.ISupportInitialize).EndInit()
        tpDbLogs.ResumeLayout(False)
        tlpLogData.ResumeLayout(False)
        gpDbLogCount.ResumeLayout(False)
        CType(dgvDbLogCount, ComponentModel.ISupportInitialize).EndInit()
        gpDbLogData.ResumeLayout(False)
        CType(dgvDbLogData, ComponentModel.ISupportInitialize).EndInit()
        pnlDbLogs.ResumeLayout(False)
        pnlDbLogs.PerformLayout()
        gpMessageLogFilters.ResumeLayout(False)
        gpMessageLogFilters.PerformLayout()
        CType(nudMsgLog, ComponentModel.ISupportInitialize).EndInit()
        tpDbInfo.ResumeLayout(False)
        pnlDbInfoButtons.ResumeLayout(False)
        pnlDbInfoButtons.PerformLayout()
        pnlDbData.ResumeLayout(False)
        CType(dgvDbTableSize, ComponentModel.ISupportInitialize).EndInit()
        tpStParse.ResumeLayout(False)
        tpStParse.PerformLayout()
        Panel1.ResumeLayout(False)
        tpLogs.ResumeLayout(False)
        tlpApplicationLogs.ResumeLayout(False)
        flpAppLogsButtons.ResumeLayout(False)
        tpFlavor.ResumeLayout(False)
        tpFlavor.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        flpFlavorButtons.ResumeLayout(False)
        tpOptions.ResumeLayout(False)
        tpOptions.PerformLayout()
        gpFlavorsSettings.ResumeLayout(False)
        gbAppLaunchSettings.ResumeLayout(False)
        gbAppLaunchSettings.PerformLayout()
        flpAppListButtons.ResumeLayout(False)
        cmsQuickLaunch.ResumeLayout(False)
        gbAppOptions.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        gpAdvUpgrade.ResumeLayout(False)
        gpAdvUpgrade.PerformLayout()
        pnlButtonCollection.ResumeLayout(False)
        pnlButtonCollection.PerformLayout()
        gpDBStartVersion.ResumeLayout(False)
        gpDBStartVersion.PerformLayout()
        gbAdvApps.ResumeLayout(False)
        tlpButtons1.ResumeLayout(False)
        gpCommonApps.ResumeLayout(False)
        tlpButtons2.ResumeLayout(False)
        cmsDbStart.ResumeLayout(False)
        flpQuickLaunch.ResumeLayout(False)
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        SplitContainer2.Panel1.ResumeLayout(False)
        SplitContainer2.Panel2.ResumeLayout(False)
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        pnlButtonsLabel.ResumeLayout(False)
        pnlButtons.ResumeLayout(False)
        tlpButtons3.ResumeLayout(False)
        cmsRunQaApi.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents btnExit As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tcSTA As TabControl
    Friend WithEvents tpGeneral As TabPage
    Friend WithEvents tpDbInfo As TabPage
    Friend WithEvents gpLicInfo As GroupBox
    Friend WithEvents tbShiftDate As TextBox
    Friend WithEvents lblShiftDate As Label
    Friend WithEvents tbWebEnabled As TextBox
    Friend WithEvents lblWebEnabled As Label
    Friend WithEvents tbDbVer As TextBox
    Friend WithEvents lblDbVer As Label
    Friend WithEvents tbCoreSvr As TextBox
    Friend WithEvents lblCoreSvr As Label
    Friend WithEvents tbLicSvr As TextBox
    Friend WithEvents lblLicSvr As Label
    Friend WithEvents tbLocName As TextBox
    Friend WithEvents lblLocName As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tslblCeVersion As ToolStripStatusLabel
    Friend WithEvents tslblTime As ToolStripStatusLabel
    Friend WithEvents tmr10Seconds As Timer
    Friend WithEvents tslblNetVersion As ToolStripStatusLabel
    Friend WithEvents btnDbInfoRefresh As Button
    Friend WithEvents pnlDbData As Panel
    Friend WithEvents dgvDbTableSize As DataGridView
    Friend WithEvents BottomToolStripPanel As ToolStripPanel
    Friend WithEvents TopToolStripPanel As ToolStripPanel
    Friend WithEvents RightToolStripPanel As ToolStripPanel
    Friend WithEvents LeftToolStripPanel As ToolStripPanel
    Friend WithEvents ContentPanel As ToolStripContentPanel
    Friend WithEvents pnlDbInfoButtons As Panel
    Friend WithEvents rbDbFragmentation As RadioButton
    Friend WithEvents rbDbTableSize As RadioButton
    Friend WithEvents rbDbSizeByDay As RadioButton
    Friend WithEvents rbDbDeadlocks As RadioButton
    Friend WithEvents btnAdvConfig As Button
    Friend WithEvents tpDbLogs As TabPage
    Friend WithEvents pnlDbLogs As Panel
    Friend WithEvents dgvDbLogCount As DataGridView
    Friend WithEvents dgvDbLogData As DataGridView
    Friend WithEvents rbMessageLog As RadioButton
    Friend WithEvents rbWebCloudUpdates As RadioButton
    Friend WithEvents btnDbLogRefresh As Button
    Friend WithEvents gpDbLogData As GroupBox
    Friend WithEvents gpDbLogCount As GroupBox
    Friend WithEvents tpStParse As TabPage
    Friend WithEvents btnSTClear As Button
    Friend WithEvents btnStParse As Button
    Friend WithEvents tbSTParse As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnStPaste As Button
    Friend WithEvents btnStCopy As Button
    Friend WithEvents dtpMsgLogDateFrom As DateTimePicker
    Friend WithEvents gpMessageLogFilters As GroupBox
    Friend WithEvents dtpMsgLogTimeTo As DateTimePicker
    Friend WithEvents dtpMsgLogTimeFrom As DateTimePicker
    Friend WithEvents dtpMsgLogDateTo As DateTimePicker
    Friend WithEvents cbMsgLogShowErrorsOnly As CheckBox
    Friend WithEvents nudMsgLog As NumericUpDown
    Friend WithEvents cbMsgLogDateRange As CheckBox
    Friend WithEvents lblMsgLogEndDate As Label
    Friend WithEvents lblMsgLogStartDate As Label
    Friend WithEvents lblMsgLogNumRows As Label
    Friend WithEvents tmr1Sec As Timer
    Friend WithEvents tpAdvData As TabPage
    Friend WithEvents dgvAppOptions As DataGridView
    Friend WithEvents OptionName As DataGridViewTextBoxColumn
    Friend WithEvents OptionValue As DataGridViewTextBoxColumn
    Friend WithEvents dgvWebOptions As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents lblAppOptions As Label
    Friend WithEvents lblWebOptions As Label
    Friend WithEvents btnAdvManager As Button
    Friend WithEvents btnAdvGroups As Button
    Friend WithEvents btnPos As Button
    Friend WithEvents tlpLogData As TableLayoutPanel
    Friend WithEvents btnAdvReportEditor As Button
    Friend WithEvents btnAdvUpgrade As Button
    Friend WithEvents tpOptions As TabPage
    Friend WithEvents gpAdvUpgrade As GroupBox
    Friend WithEvents cbAdvUpgradeQuiet As CheckBox
    Friend WithEvents cbAdvUpgradeNoBackup As CheckBox
    Friend WithEvents cbAdvUpgradeNoSetup As CheckBox
    Friend WithEvents gbAdvApps As GroupBox
    Friend WithEvents tbServicesButtonsHelpMessage As TextBox
    Friend WithEvents lblApplicationInfo As Label
    Friend WithEvents dgvApplicationInfo As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents btnSaveApplicationInfoCSV As Button
    Friend WithEvents btnSaveWebOptionsCSV As Button
    Friend WithEvents btnSaveAppotionsCSV As Button
    Friend WithEvents tbAdvupgrade As TextBox
    Friend WithEvents lblAdvUpgrade As Label
    Friend WithEvents btnAdvRedeem As Button
    Friend WithEvents btnAdvCardTech As Button
    Friend WithEvents btnRefreshAdvDataTab As Button
    Friend WithEvents lstPrograms As ListBox
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnBatchLaunch As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents gbAppLaunchSettings As GroupBox
    Friend WithEvents lblPrgListbox As Label
    Friend WithEvents btnLaunch As Button
    Friend WithEvents cmbboxAppLaunch As ComboBox
    Friend WithEvents btnComboAppLaunch As Button
    Friend WithEvents tbWindowTitle As TextBox
    Friend WithEvents btnAdminRestart As Button
    Friend WithEvents gbAppOptions As GroupBox
    Friend WithEvents flpQuickLaunch As FlowLayoutPanel
    Friend WithEvents cmsQuickLaunch As ContextMenuStrip
    Friend WithEvents cmsQuickLaunchSlot1 As ToolStripMenuItem
    Friend WithEvents cmsQuickLaunchSlot2 As ToolStripMenuItem
    Friend WithEvents ToolTipForQuickButtons As ToolTip
    Friend WithEvents btnTest1 As Button
    Friend WithEvents tbTest1 As TextBox
    Friend WithEvents tbTest3 As TextBox
    Friend WithEvents tbTest2 As TextBox
    Friend WithEvents btnReconnect As Button
    Friend WithEvents tslblDbState As ToolStripStatusLabel
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents btnAdvKiosk As Button
    Friend WithEvents btnAdvKioskSetup As Button
    Friend WithEvents btnCalc As Button
    Friend WithEvents btnTaskmgr As Button
    Friend WithEvents gpCommonApps As GroupBox
    Friend WithEvents btnAppWiz As Button
    Friend WithEvents btnDevices As Button
    Friend WithEvents btnEventViewer As Button
    Friend WithEvents btnServices As Button
    Friend WithEvents btnRepoFolder As Button
    Friend WithEvents tbRepoFolder As TextBox
    Friend WithEvents lblRepoFolder As Label
    Friend WithEvents clbSqlFiles As CheckedListBox
    Friend WithEvents btnLaunchLatestInstaller As Button
    Friend WithEvents tbSetupSwitches As TextBox
    Friend WithEvents lblSetupSwitches As Label
    Friend WithEvents btnSaveFlavorDefaults As Button
    Friend WithEvents btnResetFlavorDefaults As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblApplyFlavorDefault As Label
    Friend WithEvents lblDatabaseStartDefault As Label
    Friend WithEvents tbDatabaseStartDefault As TextBox
    Friend WithEvents tbApplyFlavorDefault As TextBox
    Friend WithEvents btnRunApplyFlavorLive As Button
    Friend WithEvents btnRunDatabaseStartLive As Button
    Friend WithEvents rtbLiveOutput As RichTextBox
    Friend WithEvents gbLiveOutput As GroupBox
    Friend WithEvents tslblExecutionStatus As ToolStripStatusLabel
    Friend WithEvents btnTest2 As Button
    Friend WithEvents btnRepoDiscardChanges As Button
    Friend WithEvents btnSetupInstall As Button
    Friend WithEvents btnRepoMain As Button
    Friend WithEvents cbShowHiddenServices As CheckBox
    Friend WithEvents pnlServicesContainer As Panel
    Friend WithEvents tblServices As TableLayoutPanel
    Friend WithEvents gpFlavorsSettings As GroupBox
    Friend WithEvents flpAppListButtons As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblWindowTitle As Label
    Friend WithEvents lblShowHiddenServices As Label
    Friend WithEvents tlpButtons3 As TableLayoutPanel
    Friend WithEvents cmsApplySingleFlavor As ContextMenuStrip
    Friend WithEvents miApplySingleFlavor As ToolStripMenuItem
    Friend WithEvents lbFlavorsList As ListBox
    Friend WithEvents gbFlavorsList As GroupBox
    Friend WithEvents tlpButtons2 As TableLayoutPanel
    Friend WithEvents tlpButtons1 As TableLayoutPanel
    Friend WithEvents btnManageInstallerVersions As Button
    Friend WithEvents tbMLTest1 As TextBox
    Friend WithEvents btnBrowseApplyScript As Button
    Friend WithEvents btnBrowseStartScript As Button
    Friend WithEvents ofdStartScript As OpenFileDialog
    Friend WithEvents tbOutputScript As TextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnCopyScriptOutput As Button
    Friend WithEvents tsmiApplyDefaultFlavors As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents Button19 As Button
    Friend WithEvents Button20 As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents gpDBStartVersion As GroupBox
    Friend WithEvents tbDbUseVersion As TextBox
    Friend WithEvents btnDbUseAdvVersion As Button
    Friend WithEvents cbDbUseVersion As CheckBox
    Friend WithEvents btnOpenLogFile As Button
    Friend WithEvents tpLogs As TabPage
    Friend WithEvents rtbLogs As RichTextBox
    Friend WithEvents btnViewLatestLog As Button
    Friend WithEvents tlpApplicationLogs As TableLayoutPanel
    Friend WithEvents flpAppLogsButtons As FlowLayoutPanel
    Friend WithEvents btnLastLogBlock As Button
    Friend WithEvents btnLastFailed As Button
    Friend WithEvents pnlButtonCollection As Panel
    Friend WithEvents btnUpdateShiftDate As Button
    Friend WithEvents lblPcDbInfo As Label
    Friend WithEvents tbPcDbInfo As TextBox
    Friend WithEvents cmsDbStart As ContextMenuStrip
    Friend WithEvents tsmiStartDbRaw As ToolStripMenuItem
    Friend WithEvents tbBackupPathOverride As TextBox
    Friend WithEvents lblBackupPathOverride As Label
    Friend WithEvents btnBackupPathOverride As Button
    Friend WithEvents staFolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents tbBackupScriptPath As TextBox
    Friend WithEvents lblBackupScriptPath As Label
    Friend WithEvents btnBackupScriptPath As Button
    Friend WithEvents tsmiStartDbBackup As ToolStripMenuItem
    Friend WithEvents cmsDbStartSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiBackupDb As ToolStripMenuItem
    Friend WithEvents btnApplyPersonalFlavor As Button
    Friend WithEvents tpFlavor As TabPage
    Friend WithEvents tlpFlavor As TableLayoutPanel
    Friend WithEvents tbFlavor As TextBox
    Friend WithEvents btnFlavorLoad As Button
    Friend WithEvents flpFlavorButtons As FlowLayoutPanel
    Friend WithEvents btnFlavorSave As Button
    Friend WithEvents btnFlavorClear As Button
    Friend WithEvents btnFlavorPaste As Button
    Friend WithEvents lblPersonalFlavorFile As Label
    Friend WithEvents pnlFlavorsList As Panel
    Friend WithEvents btnFlavorsListRefresh As Button
    Friend WithEvents btnFlavorFileCopy As Button
    Friend WithEvents tbFlavorHints As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblRunQaCmdLine As Label
    Friend WithEvents btnRunQaCmdLine As Button
    Friend WithEvents tbRunQaCmdLine As TextBox
    Friend WithEvents btnRunQaApi As Button
    Friend WithEvents pnlButtonsLabel As Panel
    Friend WithEvents lblButtons As Label
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents cmsRunQaApi As ContextMenuStrip
    Friend WithEvents tsmiRunQaApiRerunScript As ToolStripMenuItem
    Friend WithEvents tsmiQaScriptKill As ToolStripMenuItem
    Friend WithEvents btnTest3 As Button
    Friend WithEvents cmsSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiQaMenuPromptDefaults As ToolStripMenuItem
End Class
