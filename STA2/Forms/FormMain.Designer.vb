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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tcSTA = New System.Windows.Forms.TabControl()
        Me.tpGeneral = New System.Windows.Forms.TabPage()
        Me.lbFlavorsList = New System.Windows.Forms.ListBox()
        Me.cmsApplySingleFlavor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miApplySingleFlavor = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbLiveOutput = New System.Windows.Forms.GroupBox()
        Me.rtbLiveOutput = New System.Windows.Forms.RichTextBox()
        Me.pnlServicesContainer = New System.Windows.Forms.Panel()
        Me.tblServices = New System.Windows.Forms.TableLayoutPanel()
        Me.tbServicesButtonsHelpMessage = New System.Windows.Forms.TextBox()
        Me.gpPcInfo = New System.Windows.Forms.GroupBox()
        Me.tlpPcInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPcAdvVersion = New System.Windows.Forms.Label()
        Me.lblPcNetVersion = New System.Windows.Forms.Label()
        Me.tbPcSqlVersion = New System.Windows.Forms.TextBox()
        Me.lblPcSqlVersion = New System.Windows.Forms.Label()
        Me.lblPcDbSize = New System.Windows.Forms.Label()
        Me.tbPcDbSize = New System.Windows.Forms.TextBox()
        Me.lblPcArch = New System.Windows.Forms.Label()
        Me.tbPcRam = New System.Windows.Forms.TextBox()
        Me.lblPcHardDrive = New System.Windows.Forms.Label()
        Me.tbPcName = New System.Windows.Forms.TextBox()
        Me.lblPcRam = New System.Windows.Forms.Label()
        Me.tbPcOsInfo = New System.Windows.Forms.TextBox()
        Me.lblPcOsInfo = New System.Windows.Forms.Label()
        Me.tbPcHardDrive = New System.Windows.Forms.TextBox()
        Me.lblPcName = New System.Windows.Forms.Label()
        Me.tbPcArch = New System.Windows.Forms.TextBox()
        Me.tbPcNetVersion = New System.Windows.Forms.TextBox()
        Me.tbPcAdvVersion = New System.Windows.Forms.TextBox()
        Me.gpLicInfo = New System.Windows.Forms.GroupBox()
        Me.tbShiftDate = New System.Windows.Forms.TextBox()
        Me.tbLocName = New System.Windows.Forms.TextBox()
        Me.lblCoreSvr = New System.Windows.Forms.Label()
        Me.lblShiftDate = New System.Windows.Forms.Label()
        Me.tbCoreSvr = New System.Windows.Forms.TextBox()
        Me.tbLicSvr = New System.Windows.Forms.TextBox()
        Me.tbWebEnabled = New System.Windows.Forms.TextBox()
        Me.lblDbVer = New System.Windows.Forms.Label()
        Me.lblLicSvr = New System.Windows.Forms.Label()
        Me.lblWebEnabled = New System.Windows.Forms.Label()
        Me.tbDbVer = New System.Windows.Forms.TextBox()
        Me.lblLocName = New System.Windows.Forms.Label()
        Me.tpAdvData = New System.Windows.Forms.TabPage()
        Me.btnSaveWebOptionsCSV = New System.Windows.Forms.Button()
        Me.btnSaveAppotionsCSV = New System.Windows.Forms.Button()
        Me.btnSaveApplicationInfoCSV = New System.Windows.Forms.Button()
        Me.lblApplicationInfo = New System.Windows.Forms.Label()
        Me.dgvApplicationInfo = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblWebOptions = New System.Windows.Forms.Label()
        Me.lblAppOptions = New System.Windows.Forms.Label()
        Me.dgvWebOptions = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvAppOptions = New System.Windows.Forms.DataGridView()
        Me.OptionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OptionValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpDbInfo = New System.Windows.Forms.TabPage()
        Me.pnlDbInfoButtons = New System.Windows.Forms.Panel()
        Me.rbDbDeadlocks = New System.Windows.Forms.RadioButton()
        Me.rbDbSizeByDay = New System.Windows.Forms.RadioButton()
        Me.btnDbInfoRefresh = New System.Windows.Forms.Button()
        Me.rbDbFragmentation = New System.Windows.Forms.RadioButton()
        Me.rbDbTableSize = New System.Windows.Forms.RadioButton()
        Me.pnlDbData = New System.Windows.Forms.Panel()
        Me.dgvDbTableSize = New System.Windows.Forms.DataGridView()
        Me.tpDbLogs = New System.Windows.Forms.TabPage()
        Me.tlpLogData = New System.Windows.Forms.TableLayoutPanel()
        Me.gpDbLogCount = New System.Windows.Forms.GroupBox()
        Me.dgvDbLogCount = New System.Windows.Forms.DataGridView()
        Me.gpDbLogData = New System.Windows.Forms.GroupBox()
        Me.dgvDbLogData = New System.Windows.Forms.DataGridView()
        Me.pnlDbLogs = New System.Windows.Forms.Panel()
        Me.gpMessageLogFilters = New System.Windows.Forms.GroupBox()
        Me.lblMsgLogNumRows = New System.Windows.Forms.Label()
        Me.lblMsgLogEndDate = New System.Windows.Forms.Label()
        Me.lblMsgLogStartDate = New System.Windows.Forms.Label()
        Me.cbMsgLogDateRange = New System.Windows.Forms.CheckBox()
        Me.nudMsgLog = New System.Windows.Forms.NumericUpDown()
        Me.cbMsgLogShowErrorsOnly = New System.Windows.Forms.CheckBox()
        Me.dtpMsgLogTimeTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpMsgLogTimeFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpMsgLogDateTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpMsgLogDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnDbLogRefresh = New System.Windows.Forms.Button()
        Me.rbMessageLog = New System.Windows.Forms.RadioButton()
        Me.rbWebCloudUpdates = New System.Windows.Forms.RadioButton()
        Me.tpStParse = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnStCopy = New System.Windows.Forms.Button()
        Me.btnStPaste = New System.Windows.Forms.Button()
        Me.btnStParse = New System.Windows.Forms.Button()
        Me.btnSTClear = New System.Windows.Forms.Button()
        Me.tbSTParse = New System.Windows.Forms.TextBox()
        Me.tpOptions = New System.Windows.Forms.TabPage()
        Me.gpFlavorsSettings = New System.Windows.Forms.GroupBox()
        Me.btnSaveFlavorDefaults = New System.Windows.Forms.Button()
        Me.clbSqlFiles = New System.Windows.Forms.CheckedListBox()
        Me.btnResetFlavorDefaults = New System.Windows.Forms.Button()
        Me.gbAppLaunchSettings = New System.Windows.Forms.GroupBox()
        Me.flpAppListButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnLaunch = New System.Windows.Forms.Button()
        Me.lblPrgListbox = New System.Windows.Forms.Label()
        Me.lstPrograms = New System.Windows.Forms.ListBox()
        Me.cmsQuickLaunch = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsQuickLaunchSlot1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsQuickLaunchSlot2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbAppOptions = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tbApplyFlavorDefault = New System.Windows.Forms.TextBox()
        Me.tbDatabaseStartDefault = New System.Windows.Forms.TextBox()
        Me.tbWindowTitle = New System.Windows.Forms.TextBox()
        Me.lblApplyFlavorDefault = New System.Windows.Forms.Label()
        Me.tbRepoFolder = New System.Windows.Forms.TextBox()
        Me.lblDatabaseStartDefault = New System.Windows.Forms.Label()
        Me.btnRepoFolder = New System.Windows.Forms.Button()
        Me.lblRepoFolder = New System.Windows.Forms.Label()
        Me.lblSetupSwitches = New System.Windows.Forms.Label()
        Me.tbSetupSwitches = New System.Windows.Forms.TextBox()
        Me.lblWindowTitle = New System.Windows.Forms.Label()
        Me.chkShowHiddenServices = New System.Windows.Forms.CheckBox()
        Me.lblShowHiddenServices = New System.Windows.Forms.Label()
        Me.tbDatabaseStartCommand = New System.Windows.Forms.TextBox()
        Me.tbFlavorApplyCommand = New System.Windows.Forms.TextBox()
        Me.lblFlavorApplyCommand = New System.Windows.Forms.Label()
        Me.lblDatabaseStartCommand = New System.Windows.Forms.Label()
        Me.gpAdvUpgrade = New System.Windows.Forms.GroupBox()
        Me.lblAdvUpgrade = New System.Windows.Forms.Label()
        Me.tbAdvupgrade = New System.Windows.Forms.TextBox()
        Me.cbAdvUpgradeNoBackup = New System.Windows.Forms.CheckBox()
        Me.cbAdvUpgradeNoSetup = New System.Windows.Forms.CheckBox()
        Me.cbAdvUpgradeQuiet = New System.Windows.Forms.CheckBox()
        Me.tbMLTest1 = New System.Windows.Forms.TextBox()
        Me.btnTest2 = New System.Windows.Forms.Button()
        Me.gpCommonApps = New System.Windows.Forms.GroupBox()
        Me.btnServices = New System.Windows.Forms.Button()
        Me.btnDevices = New System.Windows.Forms.Button()
        Me.btnEventViewer = New System.Windows.Forms.Button()
        Me.btnAppWiz = New System.Windows.Forms.Button()
        Me.btnTaskmgr = New System.Windows.Forms.Button()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.btnTest1 = New System.Windows.Forms.Button()
        Me.tbTest1 = New System.Windows.Forms.TextBox()
        Me.tbTest3 = New System.Windows.Forms.TextBox()
        Me.tbTest2 = New System.Windows.Forms.TextBox()
        Me.gbAdvApps = New System.Windows.Forms.GroupBox()
        Me.btnAdvKiosk = New System.Windows.Forms.Button()
        Me.btnAdvKioskSetup = New System.Windows.Forms.Button()
        Me.lblAdvApps = New System.Windows.Forms.Label()
        Me.btnAdvUpgrade = New System.Windows.Forms.Button()
        Me.btnAdvManager = New System.Windows.Forms.Button()
        Me.btnCenterEdgeConfig = New System.Windows.Forms.Button()
        Me.btnAdvCardTech = New System.Windows.Forms.Button()
        Me.btnAdvRedeem = New System.Windows.Forms.Button()
        Me.btnPos = New System.Windows.Forms.Button()
        Me.btnAdvReportEditor = New System.Windows.Forms.Button()
        Me.btnAdvGroups = New System.Windows.Forms.Button()
        Me.btnRunDatabaseStartLive = New System.Windows.Forms.Button()
        Me.btnRunApplyFlavorLive = New System.Windows.Forms.Button()
        Me.cmbboxAppLaunch = New System.Windows.Forms.ComboBox()
        Me.btnComboAppLaunch = New System.Windows.Forms.Button()
        Me.btnReconnect = New System.Windows.Forms.Button()
        Me.flpQuickLaunch = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAdminRestart = New System.Windows.Forms.Button()
        Me.btnRefreshGeneralTab = New System.Windows.Forms.Button()
        Me.btnBatchLaunch = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslblCeVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblNetVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblExecutionStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblDbState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmr10Seconds = New System.Windows.Forms.Timer(Me.components)
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.tmr1Sec = New System.Windows.Forms.Timer(Me.components)
        Me.ttSTA2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTipForQuickButtons = New System.Windows.Forms.ToolTip(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.tlpButtons3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRepoMain = New System.Windows.Forms.Button()
        Me.btnSetupInstall = New System.Windows.Forms.Button()
        Me.btnLaunchLatestInstaller = New System.Windows.Forms.Button()
        Me.btnRepoDiscardChanges = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gbFlavorsList = New System.Windows.Forms.GroupBox()
        Me.tblFlavorListHints = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFLHints1 = New System.Windows.Forms.Label()
        Me.lblFLHints2 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tcSTA.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.cmsApplySingleFlavor.SuspendLayout()
        Me.gbLiveOutput.SuspendLayout()
        Me.pnlServicesContainer.SuspendLayout()
        Me.gpPcInfo.SuspendLayout()
        Me.tlpPcInfo.SuspendLayout()
        Me.gpLicInfo.SuspendLayout()
        Me.tpAdvData.SuspendLayout()
        CType(Me.dgvApplicationInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWebOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAppOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDbInfo.SuspendLayout()
        Me.pnlDbInfoButtons.SuspendLayout()
        Me.pnlDbData.SuspendLayout()
        CType(Me.dgvDbTableSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDbLogs.SuspendLayout()
        Me.tlpLogData.SuspendLayout()
        Me.gpDbLogCount.SuspendLayout()
        CType(Me.dgvDbLogCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDbLogData.SuspendLayout()
        CType(Me.dgvDbLogData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDbLogs.SuspendLayout()
        Me.gpMessageLogFilters.SuspendLayout()
        CType(Me.nudMsgLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStParse.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tpOptions.SuspendLayout()
        Me.gpFlavorsSettings.SuspendLayout()
        Me.gbAppLaunchSettings.SuspendLayout()
        Me.flpAppListButtons.SuspendLayout()
        Me.cmsQuickLaunch.SuspendLayout()
        Me.gbAppOptions.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gpAdvUpgrade.SuspendLayout()
        Me.gpCommonApps.SuspendLayout()
        Me.gbAdvApps.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.tlpButtons3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gbFlavorsList.SuspendLayout()
        Me.tblFlavorListHints.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(252, 173)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(77, 50)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tcSTA)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Gray
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbMLTest1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnTest2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gpCommonApps)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnTest1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbTest1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbTest3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbTest2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbAdvApps)
        Me.SplitContainer1.Size = New System.Drawing.Size(1023, 854)
        Me.SplitContainer1.SplitterDistance = 668
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 10
        '
        'tcSTA
        '
        Me.tcSTA.Controls.Add(Me.tpGeneral)
        Me.tcSTA.Controls.Add(Me.tpAdvData)
        Me.tcSTA.Controls.Add(Me.tpDbInfo)
        Me.tcSTA.Controls.Add(Me.tpDbLogs)
        Me.tcSTA.Controls.Add(Me.tpStParse)
        Me.tcSTA.Controls.Add(Me.tpOptions)
        Me.tcSTA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcSTA.Location = New System.Drawing.Point(0, 0)
        Me.tcSTA.Name = "tcSTA"
        Me.tcSTA.SelectedIndex = 0
        Me.tcSTA.Size = New System.Drawing.Size(1019, 664)
        Me.tcSTA.TabIndex = 11
        '
        'tpGeneral
        '
        Me.tpGeneral.BackColor = System.Drawing.Color.Gray
        Me.tpGeneral.Controls.Add(Me.tblFlavorListHints)
        Me.tpGeneral.Controls.Add(Me.gbFlavorsList)
        Me.tpGeneral.Controls.Add(Me.gbLiveOutput)
        Me.tpGeneral.Controls.Add(Me.pnlServicesContainer)
        Me.tpGeneral.Controls.Add(Me.gpPcInfo)
        Me.tpGeneral.Controls.Add(Me.gpLicInfo)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(1011, 638)
        Me.tpGeneral.TabIndex = 0
        Me.tpGeneral.Text = "General"
        '
        'lbFlavorsList
        '
        Me.lbFlavorsList.ContextMenuStrip = Me.cmsApplySingleFlavor
        Me.lbFlavorsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbFlavorsList.FormattingEnabled = True
        Me.lbFlavorsList.IntegralHeight = False
        Me.lbFlavorsList.Location = New System.Drawing.Point(3, 16)
        Me.lbFlavorsList.Name = "lbFlavorsList"
        Me.lbFlavorsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbFlavorsList.Size = New System.Drawing.Size(194, 336)
        Me.lbFlavorsList.TabIndex = 35
        '
        'cmsApplySingleFlavor
        '
        Me.cmsApplySingleFlavor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miApplySingleFlavor})
        Me.cmsApplySingleFlavor.Name = "cmsApplySingleFlavor"
        Me.cmsApplySingleFlavor.Size = New System.Drawing.Size(161, 54)
        Me.cmsApplySingleFlavor.Text = "Apply this flavor" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'miApplySingleFlavor
        '
        Me.miApplySingleFlavor.Name = "miApplySingleFlavor"
        Me.miApplySingleFlavor.Size = New System.Drawing.Size(160, 50)
        Me.miApplySingleFlavor.Text = "Apply this flavor" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'gbLiveOutput
        '
        Me.gbLiveOutput.BackColor = System.Drawing.Color.LightGray
        Me.gbLiveOutput.Controls.Add(Me.rtbLiveOutput)
        Me.gbLiveOutput.Location = New System.Drawing.Point(3, 416)
        Me.gbLiveOutput.Name = "gbLiveOutput"
        Me.gbLiveOutput.Size = New System.Drawing.Size(609, 207)
        Me.gbLiveOutput.TabIndex = 34
        Me.gbLiveOutput.TabStop = False
        Me.gbLiveOutput.Text = "Script Output Window"
        '
        'rtbLiveOutput
        '
        Me.rtbLiveOutput.BackColor = System.Drawing.Color.Black
        Me.rtbLiveOutput.DetectUrls = False
        Me.rtbLiveOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbLiveOutput.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbLiveOutput.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rtbLiveOutput.Location = New System.Drawing.Point(3, 16)
        Me.rtbLiveOutput.Name = "rtbLiveOutput"
        Me.rtbLiveOutput.ReadOnly = True
        Me.rtbLiveOutput.Size = New System.Drawing.Size(603, 188)
        Me.rtbLiveOutput.TabIndex = 33
        Me.rtbLiveOutput.Text = ""
        Me.rtbLiveOutput.WordWrap = False
        '
        'pnlServicesContainer
        '
        Me.pnlServicesContainer.Controls.Add(Me.tblServices)
        Me.pnlServicesContainer.Controls.Add(Me.tbServicesButtonsHelpMessage)
        Me.pnlServicesContainer.Location = New System.Drawing.Point(642, 3)
        Me.pnlServicesContainer.Name = "pnlServicesContainer"
        Me.pnlServicesContainer.Size = New System.Drawing.Size(350, 617)
        Me.pnlServicesContainer.TabIndex = 1
        '
        'tblServices
        '
        Me.tblServices.AutoScroll = True
        Me.tblServices.AutoSize = True
        Me.tblServices.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tblServices.BackColor = System.Drawing.Color.Transparent
        Me.tblServices.ColumnCount = 1
        Me.tblServices.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblServices.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblServices.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblServices.Location = New System.Drawing.Point(0, 0)
        Me.tblServices.Name = "tblServices"
        Me.tblServices.RowCount = 1
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblServices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblServices.Size = New System.Drawing.Size(350, 0)
        Me.tblServices.TabIndex = 1
        '
        'tbServicesButtonsHelpMessage
        '
        Me.tbServicesButtonsHelpMessage.Enabled = False
        Me.tbServicesButtonsHelpMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbServicesButtonsHelpMessage.Location = New System.Drawing.Point(89, 536)
        Me.tbServicesButtonsHelpMessage.Multiline = True
        Me.tbServicesButtonsHelpMessage.Name = "tbServicesButtonsHelpMessage"
        Me.tbServicesButtonsHelpMessage.Size = New System.Drawing.Size(248, 78)
        Me.tbServicesButtonsHelpMessage.TabIndex = 16
        Me.tbServicesButtonsHelpMessage.Text = "To enable Services buttons close and reopen the application in Administrator Mode" &
    "."
        '
        'gpPcInfo
        '
        Me.gpPcInfo.BackColor = System.Drawing.Color.LightGray
        Me.gpPcInfo.Controls.Add(Me.tlpPcInfo)
        Me.gpPcInfo.Location = New System.Drawing.Point(3, 157)
        Me.gpPcInfo.Name = "gpPcInfo"
        Me.gpPcInfo.Size = New System.Drawing.Size(406, 259)
        Me.gpPcInfo.TabIndex = 15
        Me.gpPcInfo.TabStop = False
        Me.gpPcInfo.Text = "Computer Info"
        '
        'tlpPcInfo
        '
        Me.tlpPcInfo.ColumnCount = 2
        Me.tlpPcInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPcInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPcInfo.Controls.Add(Me.lblPcAdvVersion, 0, 8)
        Me.tlpPcInfo.Controls.Add(Me.lblPcNetVersion, 0, 7)
        Me.tlpPcInfo.Controls.Add(Me.tbPcSqlVersion, 1, 6)
        Me.tlpPcInfo.Controls.Add(Me.lblPcSqlVersion, 0, 6)
        Me.tlpPcInfo.Controls.Add(Me.lblPcDbSize, 0, 5)
        Me.tlpPcInfo.Controls.Add(Me.tbPcDbSize, 1, 5)
        Me.tlpPcInfo.Controls.Add(Me.lblPcArch, 0, 4)
        Me.tlpPcInfo.Controls.Add(Me.tbPcRam, 1, 2)
        Me.tlpPcInfo.Controls.Add(Me.lblPcHardDrive, 0, 3)
        Me.tlpPcInfo.Controls.Add(Me.tbPcName, 1, 0)
        Me.tlpPcInfo.Controls.Add(Me.lblPcRam, 0, 2)
        Me.tlpPcInfo.Controls.Add(Me.tbPcOsInfo, 1, 1)
        Me.tlpPcInfo.Controls.Add(Me.lblPcOsInfo, 0, 1)
        Me.tlpPcInfo.Controls.Add(Me.tbPcHardDrive, 1, 3)
        Me.tlpPcInfo.Controls.Add(Me.lblPcName, 0, 0)
        Me.tlpPcInfo.Controls.Add(Me.tbPcArch, 1, 4)
        Me.tlpPcInfo.Controls.Add(Me.tbPcNetVersion, 1, 7)
        Me.tlpPcInfo.Controls.Add(Me.tbPcAdvVersion, 1, 8)
        Me.tlpPcInfo.Location = New System.Drawing.Point(6, 12)
        Me.tlpPcInfo.Name = "tlpPcInfo"
        Me.tlpPcInfo.RowCount = 9
        Me.tlpPcInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPcInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPcInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPcInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPcInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPcInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPcInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPcInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPcInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPcInfo.Size = New System.Drawing.Size(388, 236)
        Me.tlpPcInfo.TabIndex = 14
        '
        'lblPcAdvVersion
        '
        Me.lblPcAdvVersion.AutoSize = True
        Me.lblPcAdvVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPcAdvVersion.Location = New System.Drawing.Point(3, 208)
        Me.lblPcAdvVersion.Name = "lblPcAdvVersion"
        Me.lblPcAdvVersion.Size = New System.Drawing.Size(117, 28)
        Me.lblPcAdvVersion.TabIndex = 19
        Me.lblPcAdvVersion.Text = "Advantage Version"
        Me.lblPcAdvVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPcNetVersion
        '
        Me.lblPcNetVersion.AutoSize = True
        Me.lblPcNetVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPcNetVersion.Location = New System.Drawing.Point(3, 182)
        Me.lblPcNetVersion.Name = "lblPcNetVersion"
        Me.lblPcNetVersion.Size = New System.Drawing.Size(117, 26)
        Me.lblPcNetVersion.TabIndex = 17
        Me.lblPcNetVersion.Text = "Net Framework Version"
        Me.lblPcNetVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbPcSqlVersion
        '
        Me.tbPcSqlVersion.Location = New System.Drawing.Point(126, 159)
        Me.tbPcSqlVersion.Name = "tbPcSqlVersion"
        Me.tbPcSqlVersion.Size = New System.Drawing.Size(258, 20)
        Me.tbPcSqlVersion.TabIndex = 16
        '
        'lblPcSqlVersion
        '
        Me.lblPcSqlVersion.AutoSize = True
        Me.lblPcSqlVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPcSqlVersion.Location = New System.Drawing.Point(3, 156)
        Me.lblPcSqlVersion.Name = "lblPcSqlVersion"
        Me.lblPcSqlVersion.Size = New System.Drawing.Size(117, 26)
        Me.lblPcSqlVersion.TabIndex = 15
        Me.lblPcSqlVersion.Text = "SQL Version"
        Me.lblPcSqlVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPcDbSize
        '
        Me.lblPcDbSize.AutoSize = True
        Me.lblPcDbSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPcDbSize.Location = New System.Drawing.Point(3, 130)
        Me.lblPcDbSize.Name = "lblPcDbSize"
        Me.lblPcDbSize.Size = New System.Drawing.Size(117, 26)
        Me.lblPcDbSize.TabIndex = 14
        Me.lblPcDbSize.Text = "Database Size"
        Me.lblPcDbSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbPcDbSize
        '
        Me.tbPcDbSize.Location = New System.Drawing.Point(126, 133)
        Me.tbPcDbSize.Name = "tbPcDbSize"
        Me.tbPcDbSize.Size = New System.Drawing.Size(258, 20)
        Me.tbPcDbSize.TabIndex = 13
        '
        'lblPcArch
        '
        Me.lblPcArch.AutoSize = True
        Me.lblPcArch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPcArch.Location = New System.Drawing.Point(3, 104)
        Me.lblPcArch.Name = "lblPcArch"
        Me.lblPcArch.Size = New System.Drawing.Size(117, 26)
        Me.lblPcArch.TabIndex = 11
        Me.lblPcArch.Text = "System Architecture"
        Me.lblPcArch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbPcRam
        '
        Me.tbPcRam.Location = New System.Drawing.Point(126, 55)
        Me.tbPcRam.Name = "tbPcRam"
        Me.tbPcRam.Size = New System.Drawing.Size(258, 20)
        Me.tbPcRam.TabIndex = 12
        '
        'lblPcHardDrive
        '
        Me.lblPcHardDrive.AutoSize = True
        Me.lblPcHardDrive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPcHardDrive.Location = New System.Drawing.Point(3, 78)
        Me.lblPcHardDrive.Name = "lblPcHardDrive"
        Me.lblPcHardDrive.Size = New System.Drawing.Size(117, 26)
        Me.lblPcHardDrive.TabIndex = 10
        Me.lblPcHardDrive.Text = "HD Free Space"
        Me.lblPcHardDrive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbPcName
        '
        Me.tbPcName.Location = New System.Drawing.Point(126, 3)
        Me.tbPcName.Name = "tbPcName"
        Me.tbPcName.Size = New System.Drawing.Size(258, 20)
        Me.tbPcName.TabIndex = 0
        '
        'lblPcRam
        '
        Me.lblPcRam.AutoSize = True
        Me.lblPcRam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPcRam.Location = New System.Drawing.Point(3, 52)
        Me.lblPcRam.Name = "lblPcRam"
        Me.lblPcRam.Size = New System.Drawing.Size(117, 26)
        Me.lblPcRam.TabIndex = 9
        Me.lblPcRam.Text = "Memory"
        Me.lblPcRam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbPcOsInfo
        '
        Me.tbPcOsInfo.Location = New System.Drawing.Point(126, 29)
        Me.tbPcOsInfo.Name = "tbPcOsInfo"
        Me.tbPcOsInfo.Size = New System.Drawing.Size(258, 20)
        Me.tbPcOsInfo.TabIndex = 1
        '
        'lblPcOsInfo
        '
        Me.lblPcOsInfo.AutoSize = True
        Me.lblPcOsInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPcOsInfo.Location = New System.Drawing.Point(3, 26)
        Me.lblPcOsInfo.Name = "lblPcOsInfo"
        Me.lblPcOsInfo.Size = New System.Drawing.Size(117, 26)
        Me.lblPcOsInfo.TabIndex = 8
        Me.lblPcOsInfo.Text = "Operating System"
        Me.lblPcOsInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbPcHardDrive
        '
        Me.tbPcHardDrive.Location = New System.Drawing.Point(126, 81)
        Me.tbPcHardDrive.Name = "tbPcHardDrive"
        Me.tbPcHardDrive.Size = New System.Drawing.Size(258, 20)
        Me.tbPcHardDrive.TabIndex = 4
        '
        'lblPcName
        '
        Me.lblPcName.AutoSize = True
        Me.lblPcName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPcName.Location = New System.Drawing.Point(3, 0)
        Me.lblPcName.Name = "lblPcName"
        Me.lblPcName.Size = New System.Drawing.Size(117, 26)
        Me.lblPcName.TabIndex = 7
        Me.lblPcName.Text = "Computer Name"
        Me.lblPcName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbPcArch
        '
        Me.tbPcArch.Location = New System.Drawing.Point(126, 107)
        Me.tbPcArch.Name = "tbPcArch"
        Me.tbPcArch.Size = New System.Drawing.Size(258, 20)
        Me.tbPcArch.TabIndex = 5
        '
        'tbPcNetVersion
        '
        Me.tbPcNetVersion.Location = New System.Drawing.Point(126, 185)
        Me.tbPcNetVersion.Name = "tbPcNetVersion"
        Me.tbPcNetVersion.Size = New System.Drawing.Size(258, 20)
        Me.tbPcNetVersion.TabIndex = 18
        '
        'tbPcAdvVersion
        '
        Me.tbPcAdvVersion.Location = New System.Drawing.Point(126, 211)
        Me.tbPcAdvVersion.Name = "tbPcAdvVersion"
        Me.tbPcAdvVersion.Size = New System.Drawing.Size(258, 20)
        Me.tbPcAdvVersion.TabIndex = 20
        '
        'gpLicInfo
        '
        Me.gpLicInfo.BackColor = System.Drawing.Color.LightGray
        Me.gpLicInfo.Controls.Add(Me.tbShiftDate)
        Me.gpLicInfo.Controls.Add(Me.tbLocName)
        Me.gpLicInfo.Controls.Add(Me.lblCoreSvr)
        Me.gpLicInfo.Controls.Add(Me.lblShiftDate)
        Me.gpLicInfo.Controls.Add(Me.tbCoreSvr)
        Me.gpLicInfo.Controls.Add(Me.tbLicSvr)
        Me.gpLicInfo.Controls.Add(Me.tbWebEnabled)
        Me.gpLicInfo.Controls.Add(Me.lblDbVer)
        Me.gpLicInfo.Controls.Add(Me.lblLicSvr)
        Me.gpLicInfo.Controls.Add(Me.lblWebEnabled)
        Me.gpLicInfo.Controls.Add(Me.tbDbVer)
        Me.gpLicInfo.Controls.Add(Me.lblLocName)
        Me.gpLicInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpLicInfo.Location = New System.Drawing.Point(3, 6)
        Me.gpLicInfo.Name = "gpLicInfo"
        Me.gpLicInfo.Size = New System.Drawing.Size(406, 151)
        Me.gpLicInfo.TabIndex = 10
        Me.gpLicInfo.TabStop = False
        Me.gpLicInfo.Text = "License Info"
        '
        'tbShiftDate
        '
        Me.tbShiftDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbShiftDate.Location = New System.Drawing.Point(101, 125)
        Me.tbShiftDate.Name = "tbShiftDate"
        Me.tbShiftDate.Size = New System.Drawing.Size(199, 20)
        Me.tbShiftDate.TabIndex = 11
        '
        'tbLocName
        '
        Me.tbLocName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLocName.Location = New System.Drawing.Point(101, 16)
        Me.tbLocName.Name = "tbLocName"
        Me.tbLocName.Size = New System.Drawing.Size(199, 20)
        Me.tbLocName.TabIndex = 1
        '
        'lblCoreSvr
        '
        Me.lblCoreSvr.AutoSize = True
        Me.lblCoreSvr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoreSvr.Location = New System.Drawing.Point(7, 63)
        Me.lblCoreSvr.Name = "lblCoreSvr"
        Me.lblCoreSvr.Size = New System.Drawing.Size(66, 13)
        Me.lblCoreSvr.TabIndex = 4
        Me.lblCoreSvr.Text = "Core Server:"
        '
        'lblShiftDate
        '
        Me.lblShiftDate.AutoSize = True
        Me.lblShiftDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftDate.Location = New System.Drawing.Point(7, 126)
        Me.lblShiftDate.Name = "lblShiftDate"
        Me.lblShiftDate.Size = New System.Drawing.Size(57, 13)
        Me.lblShiftDate.TabIndex = 10
        Me.lblShiftDate.Text = "Shift Date:"
        '
        'tbCoreSvr
        '
        Me.tbCoreSvr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCoreSvr.Location = New System.Drawing.Point(101, 59)
        Me.tbCoreSvr.Name = "tbCoreSvr"
        Me.tbCoreSvr.Size = New System.Drawing.Size(199, 20)
        Me.tbCoreSvr.TabIndex = 5
        '
        'tbLicSvr
        '
        Me.tbLicSvr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLicSvr.Location = New System.Drawing.Point(101, 37)
        Me.tbLicSvr.Name = "tbLicSvr"
        Me.tbLicSvr.Size = New System.Drawing.Size(199, 20)
        Me.tbLicSvr.TabIndex = 3
        '
        'tbWebEnabled
        '
        Me.tbWebEnabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbWebEnabled.Location = New System.Drawing.Point(101, 103)
        Me.tbWebEnabled.Name = "tbWebEnabled"
        Me.tbWebEnabled.Size = New System.Drawing.Size(199, 20)
        Me.tbWebEnabled.TabIndex = 9
        '
        'lblDbVer
        '
        Me.lblDbVer.AutoSize = True
        Me.lblDbVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDbVer.Location = New System.Drawing.Point(7, 85)
        Me.lblDbVer.Name = "lblDbVer"
        Me.lblDbVer.Size = New System.Drawing.Size(94, 13)
        Me.lblDbVer.TabIndex = 6
        Me.lblDbVer.Text = "Database Version:"
        '
        'lblLicSvr
        '
        Me.lblLicSvr.AutoSize = True
        Me.lblLicSvr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicSvr.Location = New System.Drawing.Point(7, 41)
        Me.lblLicSvr.Name = "lblLicSvr"
        Me.lblLicSvr.Size = New System.Drawing.Size(81, 13)
        Me.lblLicSvr.TabIndex = 2
        Me.lblLicSvr.Text = "License Server:"
        '
        'lblWebEnabled
        '
        Me.lblWebEnabled.AutoSize = True
        Me.lblWebEnabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebEnabled.Location = New System.Drawing.Point(7, 107)
        Me.lblWebEnabled.Name = "lblWebEnabled"
        Me.lblWebEnabled.Size = New System.Drawing.Size(98, 13)
        Me.lblWebEnabled.TabIndex = 8
        Me.lblWebEnabled.Text = "Webstore Enabled:"
        '
        'tbDbVer
        '
        Me.tbDbVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDbVer.Location = New System.Drawing.Point(101, 81)
        Me.tbDbVer.Name = "tbDbVer"
        Me.tbDbVer.Size = New System.Drawing.Size(199, 20)
        Me.tbDbVer.TabIndex = 7
        '
        'lblLocName
        '
        Me.lblLocName.AutoSize = True
        Me.lblLocName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocName.Location = New System.Drawing.Point(7, 20)
        Me.lblLocName.Name = "lblLocName"
        Me.lblLocName.Size = New System.Drawing.Size(88, 13)
        Me.lblLocName.TabIndex = 0
        Me.lblLocName.Text = "Location Name:  "
        '
        'tpAdvData
        '
        Me.tpAdvData.Controls.Add(Me.btnSaveWebOptionsCSV)
        Me.tpAdvData.Controls.Add(Me.btnSaveAppotionsCSV)
        Me.tpAdvData.Controls.Add(Me.btnSaveApplicationInfoCSV)
        Me.tpAdvData.Controls.Add(Me.lblApplicationInfo)
        Me.tpAdvData.Controls.Add(Me.dgvApplicationInfo)
        Me.tpAdvData.Controls.Add(Me.lblWebOptions)
        Me.tpAdvData.Controls.Add(Me.lblAppOptions)
        Me.tpAdvData.Controls.Add(Me.dgvWebOptions)
        Me.tpAdvData.Controls.Add(Me.dgvAppOptions)
        Me.tpAdvData.Location = New System.Drawing.Point(4, 22)
        Me.tpAdvData.Name = "tpAdvData"
        Me.tpAdvData.Size = New System.Drawing.Size(1011, 638)
        Me.tpAdvData.TabIndex = 4
        Me.tpAdvData.Text = "Advantage Data"
        Me.tpAdvData.ToolTipText = "Information from the Database Tables"
        Me.tpAdvData.UseVisualStyleBackColor = True
        '
        'btnSaveWebOptionsCSV
        '
        Me.btnSaveWebOptionsCSV.Location = New System.Drawing.Point(923, 473)
        Me.btnSaveWebOptionsCSV.Name = "btnSaveWebOptionsCSV"
        Me.btnSaveWebOptionsCSV.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveWebOptionsCSV.TabIndex = 6
        Me.btnSaveWebOptionsCSV.Text = "Save CSV"
        Me.btnSaveWebOptionsCSV.UseVisualStyleBackColor = True
        '
        'btnSaveAppotionsCSV
        '
        Me.btnSaveAppotionsCSV.Location = New System.Drawing.Point(626, 473)
        Me.btnSaveAppotionsCSV.Name = "btnSaveAppotionsCSV"
        Me.btnSaveAppotionsCSV.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveAppotionsCSV.TabIndex = 6
        Me.btnSaveAppotionsCSV.Text = "Save CSV"
        Me.btnSaveAppotionsCSV.UseVisualStyleBackColor = True
        '
        'btnSaveApplicationInfoCSV
        '
        Me.btnSaveApplicationInfoCSV.Location = New System.Drawing.Point(196, 473)
        Me.btnSaveApplicationInfoCSV.Name = "btnSaveApplicationInfoCSV"
        Me.btnSaveApplicationInfoCSV.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveApplicationInfoCSV.TabIndex = 6
        Me.btnSaveApplicationInfoCSV.Text = "Save CSV"
        Me.btnSaveApplicationInfoCSV.UseVisualStyleBackColor = True
        '
        'lblApplicationInfo
        '
        Me.lblApplicationInfo.AutoSize = True
        Me.lblApplicationInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApplicationInfo.Location = New System.Drawing.Point(6, 14)
        Me.lblApplicationInfo.Name = "lblApplicationInfo"
        Me.lblApplicationInfo.Size = New System.Drawing.Size(95, 16)
        Me.lblApplicationInfo.TabIndex = 5
        Me.lblApplicationInfo.Text = "ApplicationInfo"
        '
        'dgvApplicationInfo
        '
        Me.dgvApplicationInfo.AllowUserToAddRows = False
        Me.dgvApplicationInfo.AllowUserToDeleteRows = False
        Me.dgvApplicationInfo.AllowUserToResizeColumns = False
        Me.dgvApplicationInfo.AllowUserToResizeRows = False
        Me.dgvApplicationInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvApplicationInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApplicationInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgvApplicationInfo.Location = New System.Drawing.Point(4, 33)
        Me.dgvApplicationInfo.Name = "dgvApplicationInfo"
        Me.dgvApplicationInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvApplicationInfo.ShowEditingIcon = False
        Me.dgvApplicationInfo.Size = New System.Drawing.Size(267, 434)
        Me.dgvApplicationInfo.TabIndex = 4
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "OptionName"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 91
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "OptionValue"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 90
        '
        'lblWebOptions
        '
        Me.lblWebOptions.AutoSize = True
        Me.lblWebOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebOptions.Location = New System.Drawing.Point(753, 14)
        Me.lblWebOptions.Name = "lblWebOptions"
        Me.lblWebOptions.Size = New System.Drawing.Size(82, 16)
        Me.lblWebOptions.TabIndex = 3
        Me.lblWebOptions.Text = "WebOptions"
        '
        'lblAppOptions
        '
        Me.lblAppOptions.AutoSize = True
        Me.lblAppOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppOptions.Location = New System.Drawing.Point(351, 14)
        Me.lblAppOptions.Name = "lblAppOptions"
        Me.lblAppOptions.Size = New System.Drawing.Size(78, 16)
        Me.lblAppOptions.TabIndex = 2
        Me.lblAppOptions.Text = "AppOptions"
        '
        'dgvWebOptions
        '
        Me.dgvWebOptions.AllowUserToAddRows = False
        Me.dgvWebOptions.AllowUserToDeleteRows = False
        Me.dgvWebOptions.AllowUserToResizeColumns = False
        Me.dgvWebOptions.AllowUserToResizeRows = False
        Me.dgvWebOptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvWebOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWebOptions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvWebOptions.Location = New System.Drawing.Point(707, 33)
        Me.dgvWebOptions.Name = "dgvWebOptions"
        Me.dgvWebOptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvWebOptions.ShowEditingIcon = False
        Me.dgvWebOptions.Size = New System.Drawing.Size(291, 434)
        Me.dgvWebOptions.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "OptionName"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 91
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "OptionValue"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'dgvAppOptions
        '
        Me.dgvAppOptions.AllowUserToAddRows = False
        Me.dgvAppOptions.AllowUserToDeleteRows = False
        Me.dgvAppOptions.AllowUserToResizeColumns = False
        Me.dgvAppOptions.AllowUserToResizeRows = False
        Me.dgvAppOptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAppOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAppOptions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OptionName, Me.OptionValue})
        Me.dgvAppOptions.Location = New System.Drawing.Point(277, 33)
        Me.dgvAppOptions.Name = "dgvAppOptions"
        Me.dgvAppOptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAppOptions.ShowEditingIcon = False
        Me.dgvAppOptions.Size = New System.Drawing.Size(424, 434)
        Me.dgvAppOptions.TabIndex = 0
        '
        'OptionName
        '
        Me.OptionName.HeaderText = "OptionName"
        Me.OptionName.Name = "OptionName"
        Me.OptionName.Width = 91
        '
        'OptionValue
        '
        Me.OptionValue.HeaderText = "OptionValue"
        Me.OptionValue.Name = "OptionValue"
        Me.OptionValue.Width = 90
        '
        'tpDbInfo
        '
        Me.tpDbInfo.BackColor = System.Drawing.Color.DarkGray
        Me.tpDbInfo.Controls.Add(Me.pnlDbInfoButtons)
        Me.tpDbInfo.Controls.Add(Me.pnlDbData)
        Me.tpDbInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpDbInfo.Name = "tpDbInfo"
        Me.tpDbInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDbInfo.Size = New System.Drawing.Size(1011, 638)
        Me.tpDbInfo.TabIndex = 1
        Me.tpDbInfo.Text = "DB Information"
        Me.tpDbInfo.ToolTipText = "Queries for Database Troubleshooting"
        '
        'pnlDbInfoButtons
        '
        Me.pnlDbInfoButtons.BackColor = System.Drawing.Color.LightGray
        Me.pnlDbInfoButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDbInfoButtons.Controls.Add(Me.rbDbDeadlocks)
        Me.pnlDbInfoButtons.Controls.Add(Me.rbDbSizeByDay)
        Me.pnlDbInfoButtons.Controls.Add(Me.btnDbInfoRefresh)
        Me.pnlDbInfoButtons.Controls.Add(Me.rbDbFragmentation)
        Me.pnlDbInfoButtons.Controls.Add(Me.rbDbTableSize)
        Me.pnlDbInfoButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDbInfoButtons.Location = New System.Drawing.Point(3, 607)
        Me.pnlDbInfoButtons.Name = "pnlDbInfoButtons"
        Me.pnlDbInfoButtons.Size = New System.Drawing.Size(1005, 28)
        Me.pnlDbInfoButtons.TabIndex = 1
        '
        'rbDbDeadlocks
        '
        Me.rbDbDeadlocks.AutoSize = True
        Me.rbDbDeadlocks.Location = New System.Drawing.Point(279, 2)
        Me.rbDbDeadlocks.Name = "rbDbDeadlocks"
        Me.rbDbDeadlocks.Size = New System.Drawing.Size(76, 17)
        Me.rbDbDeadlocks.TabIndex = 3
        Me.rbDbDeadlocks.TabStop = True
        Me.rbDbDeadlocks.Text = "Deadlocks"
        Me.rbDbDeadlocks.UseVisualStyleBackColor = True
        '
        'rbDbSizeByDay
        '
        Me.rbDbSizeByDay.AutoSize = True
        Me.rbDbSizeByDay.Location = New System.Drawing.Point(194, 2)
        Me.rbDbSizeByDay.Name = "rbDbSizeByDay"
        Me.rbDbSizeByDay.Size = New System.Drawing.Size(81, 17)
        Me.rbDbSizeByDay.TabIndex = 2
        Me.rbDbSizeByDay.TabStop = True
        Me.rbDbSizeByDay.Text = "Size by Day"
        Me.rbDbSizeByDay.UseVisualStyleBackColor = True
        '
        'btnDbInfoRefresh
        '
        Me.btnDbInfoRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDbInfoRefresh.Location = New System.Drawing.Point(924, 2)
        Me.btnDbInfoRefresh.Name = "btnDbInfoRefresh"
        Me.btnDbInfoRefresh.Size = New System.Drawing.Size(64, 20)
        Me.btnDbInfoRefresh.TabIndex = 2
        Me.btnDbInfoRefresh.Text = "Refresh"
        Me.btnDbInfoRefresh.UseVisualStyleBackColor = True
        '
        'rbDbFragmentation
        '
        Me.rbDbFragmentation.AutoSize = True
        Me.rbDbFragmentation.Location = New System.Drawing.Point(97, 2)
        Me.rbDbFragmentation.Name = "rbDbFragmentation"
        Me.rbDbFragmentation.Size = New System.Drawing.Size(92, 17)
        Me.rbDbFragmentation.TabIndex = 1
        Me.rbDbFragmentation.TabStop = True
        Me.rbDbFragmentation.Text = "Fragmentation"
        Me.rbDbFragmentation.UseVisualStyleBackColor = True
        '
        'rbDbTableSize
        '
        Me.rbDbTableSize.AutoSize = True
        Me.rbDbTableSize.Location = New System.Drawing.Point(3, 2)
        Me.rbDbTableSize.Name = "rbDbTableSize"
        Me.rbDbTableSize.Size = New System.Drawing.Size(89, 17)
        Me.rbDbTableSize.TabIndex = 0
        Me.rbDbTableSize.TabStop = True
        Me.rbDbTableSize.Text = "Size by Table"
        Me.rbDbTableSize.UseVisualStyleBackColor = True
        '
        'pnlDbData
        '
        Me.pnlDbData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDbData.Controls.Add(Me.dgvDbTableSize)
        Me.pnlDbData.Location = New System.Drawing.Point(3, 3)
        Me.pnlDbData.Name = "pnlDbData"
        Me.pnlDbData.Size = New System.Drawing.Size(1008, 502)
        Me.pnlDbData.TabIndex = 1
        '
        'dgvDbTableSize
        '
        Me.dgvDbTableSize.AllowUserToAddRows = False
        Me.dgvDbTableSize.AllowUserToDeleteRows = False
        Me.dgvDbTableSize.AllowUserToOrderColumns = True
        Me.dgvDbTableSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDbTableSize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDbTableSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDbTableSize.Location = New System.Drawing.Point(0, 0)
        Me.dgvDbTableSize.Name = "dgvDbTableSize"
        Me.dgvDbTableSize.ReadOnly = True
        Me.dgvDbTableSize.Size = New System.Drawing.Size(1008, 502)
        Me.dgvDbTableSize.TabIndex = 0
        '
        'tpDbLogs
        '
        Me.tpDbLogs.BackColor = System.Drawing.Color.DarkGray
        Me.tpDbLogs.Controls.Add(Me.tlpLogData)
        Me.tpDbLogs.Controls.Add(Me.pnlDbLogs)
        Me.tpDbLogs.Location = New System.Drawing.Point(4, 22)
        Me.tpDbLogs.Name = "tpDbLogs"
        Me.tpDbLogs.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDbLogs.Size = New System.Drawing.Size(1011, 638)
        Me.tpDbLogs.TabIndex = 2
        Me.tpDbLogs.Text = "CE DB Logs"
        Me.tpDbLogs.ToolTipText = "Access to MessageLog and WebCloudUpdates tables"
        '
        'tlpLogData
        '
        Me.tlpLogData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpLogData.ColumnCount = 2
        Me.tlpLogData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.25409!))
        Me.tlpLogData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.74591!))
        Me.tlpLogData.Controls.Add(Me.gpDbLogCount, 0, 0)
        Me.tlpLogData.Controls.Add(Me.gpDbLogData, 1, 0)
        Me.tlpLogData.Location = New System.Drawing.Point(6, 6)
        Me.tlpLogData.Name = "tlpLogData"
        Me.tlpLogData.RowCount = 1
        Me.tlpLogData.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLogData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 443.0!))
        Me.tlpLogData.Size = New System.Drawing.Size(994, 405)
        Me.tlpLogData.TabIndex = 5
        '
        'gpDbLogCount
        '
        Me.gpDbLogCount.BackColor = System.Drawing.Color.LightGray
        Me.gpDbLogCount.Controls.Add(Me.dgvDbLogCount)
        Me.gpDbLogCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpDbLogCount.Location = New System.Drawing.Point(3, 3)
        Me.gpDbLogCount.Name = "gpDbLogCount"
        Me.gpDbLogCount.Size = New System.Drawing.Size(235, 437)
        Me.gpDbLogCount.TabIndex = 3
        Me.gpDbLogCount.TabStop = False
        Me.gpDbLogCount.Text = "Log Count"
        '
        'dgvDbLogCount
        '
        Me.dgvDbLogCount.AllowUserToAddRows = False
        Me.dgvDbLogCount.AllowUserToDeleteRows = False
        Me.dgvDbLogCount.AllowUserToResizeRows = False
        Me.dgvDbLogCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDbLogCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDbLogCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDbLogCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDbLogCount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDbLogCount.Location = New System.Drawing.Point(3, 16)
        Me.dgvDbLogCount.Name = "dgvDbLogCount"
        Me.dgvDbLogCount.Size = New System.Drawing.Size(229, 418)
        Me.dgvDbLogCount.TabIndex = 1
        '
        'gpDbLogData
        '
        Me.gpDbLogData.BackColor = System.Drawing.Color.LightGray
        Me.gpDbLogData.Controls.Add(Me.dgvDbLogData)
        Me.gpDbLogData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpDbLogData.Location = New System.Drawing.Point(244, 3)
        Me.gpDbLogData.Name = "gpDbLogData"
        Me.gpDbLogData.Size = New System.Drawing.Size(747, 437)
        Me.gpDbLogData.TabIndex = 4
        Me.gpDbLogData.TabStop = False
        Me.gpDbLogData.Text = "Log Data"
        '
        'dgvDbLogData
        '
        Me.dgvDbLogData.AllowUserToAddRows = False
        Me.dgvDbLogData.AllowUserToDeleteRows = False
        Me.dgvDbLogData.AllowUserToResizeRows = False
        Me.dgvDbLogData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDbLogData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDbLogData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDbLogData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDbLogData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDbLogData.Location = New System.Drawing.Point(3, 16)
        Me.dgvDbLogData.Name = "dgvDbLogData"
        Me.dgvDbLogData.ReadOnly = True
        Me.dgvDbLogData.Size = New System.Drawing.Size(741, 418)
        Me.dgvDbLogData.TabIndex = 2
        '
        'pnlDbLogs
        '
        Me.pnlDbLogs.BackColor = System.Drawing.Color.LightGray
        Me.pnlDbLogs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDbLogs.Controls.Add(Me.gpMessageLogFilters)
        Me.pnlDbLogs.Controls.Add(Me.btnDbLogRefresh)
        Me.pnlDbLogs.Controls.Add(Me.rbMessageLog)
        Me.pnlDbLogs.Controls.Add(Me.rbWebCloudUpdates)
        Me.pnlDbLogs.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDbLogs.Location = New System.Drawing.Point(3, 508)
        Me.pnlDbLogs.Name = "pnlDbLogs"
        Me.pnlDbLogs.Size = New System.Drawing.Size(1005, 127)
        Me.pnlDbLogs.TabIndex = 0
        '
        'gpMessageLogFilters
        '
        Me.gpMessageLogFilters.BackColor = System.Drawing.Color.Gainsboro
        Me.gpMessageLogFilters.Controls.Add(Me.lblMsgLogNumRows)
        Me.gpMessageLogFilters.Controls.Add(Me.lblMsgLogEndDate)
        Me.gpMessageLogFilters.Controls.Add(Me.lblMsgLogStartDate)
        Me.gpMessageLogFilters.Controls.Add(Me.cbMsgLogDateRange)
        Me.gpMessageLogFilters.Controls.Add(Me.nudMsgLog)
        Me.gpMessageLogFilters.Controls.Add(Me.cbMsgLogShowErrorsOnly)
        Me.gpMessageLogFilters.Controls.Add(Me.dtpMsgLogTimeTo)
        Me.gpMessageLogFilters.Controls.Add(Me.dtpMsgLogTimeFrom)
        Me.gpMessageLogFilters.Controls.Add(Me.dtpMsgLogDateTo)
        Me.gpMessageLogFilters.Controls.Add(Me.dtpMsgLogDateFrom)
        Me.gpMessageLogFilters.Location = New System.Drawing.Point(24, 26)
        Me.gpMessageLogFilters.Name = "gpMessageLogFilters"
        Me.gpMessageLogFilters.Size = New System.Drawing.Size(511, 96)
        Me.gpMessageLogFilters.TabIndex = 4
        Me.gpMessageLogFilters.TabStop = False
        Me.gpMessageLogFilters.Text = "MessageLog Filters"
        '
        'lblMsgLogNumRows
        '
        Me.lblMsgLogNumRows.AutoSize = True
        Me.lblMsgLogNumRows.Location = New System.Drawing.Point(297, 41)
        Me.lblMsgLogNumRows.Name = "lblMsgLogNumRows"
        Me.lblMsgLogNumRows.Size = New System.Drawing.Size(96, 13)
        Me.lblMsgLogNumRows.TabIndex = 15
        Me.lblMsgLogNumRows.Text = "# of Rows to show"
        '
        'lblMsgLogEndDate
        '
        Me.lblMsgLogEndDate.AutoSize = True
        Me.lblMsgLogEndDate.Location = New System.Drawing.Point(13, 73)
        Me.lblMsgLogEndDate.Name = "lblMsgLogEndDate"
        Me.lblMsgLogEndDate.Size = New System.Drawing.Size(26, 13)
        Me.lblMsgLogEndDate.TabIndex = 14
        Me.lblMsgLogEndDate.Text = "End"
        '
        'lblMsgLogStartDate
        '
        Me.lblMsgLogStartDate.AutoSize = True
        Me.lblMsgLogStartDate.Location = New System.Drawing.Point(12, 47)
        Me.lblMsgLogStartDate.Name = "lblMsgLogStartDate"
        Me.lblMsgLogStartDate.Size = New System.Drawing.Size(29, 13)
        Me.lblMsgLogStartDate.TabIndex = 13
        Me.lblMsgLogStartDate.Text = "Start"
        '
        'cbMsgLogDateRange
        '
        Me.cbMsgLogDateRange.AutoSize = True
        Me.cbMsgLogDateRange.Location = New System.Drawing.Point(7, 18)
        Me.cbMsgLogDateRange.Name = "cbMsgLogDateRange"
        Me.cbMsgLogDateRange.Size = New System.Drawing.Size(106, 17)
        Me.cbMsgLogDateRange.TabIndex = 12
        Me.cbMsgLogDateRange.Text = "Use Date Range"
        Me.cbMsgLogDateRange.UseVisualStyleBackColor = True
        '
        'nudMsgLog
        '
        Me.nudMsgLog.Location = New System.Drawing.Point(303, 64)
        Me.nudMsgLog.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.nudMsgLog.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMsgLog.Name = "nudMsgLog"
        Me.nudMsgLog.Size = New System.Drawing.Size(66, 20)
        Me.nudMsgLog.TabIndex = 10
        Me.nudMsgLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMsgLog.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'cbMsgLogShowErrorsOnly
        '
        Me.cbMsgLogShowErrorsOnly.AutoSize = True
        Me.cbMsgLogShowErrorsOnly.Location = New System.Drawing.Point(399, 40)
        Me.cbMsgLogShowErrorsOnly.Name = "cbMsgLogShowErrorsOnly"
        Me.cbMsgLogShowErrorsOnly.Size = New System.Drawing.Size(104, 17)
        Me.cbMsgLogShowErrorsOnly.TabIndex = 9
        Me.cbMsgLogShowErrorsOnly.Text = "Only show errors"
        Me.cbMsgLogShowErrorsOnly.UseVisualStyleBackColor = True
        '
        'dtpMsgLogTimeTo
        '
        Me.dtpMsgLogTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpMsgLogTimeTo.Location = New System.Drawing.Point(163, 67)
        Me.dtpMsgLogTimeTo.Name = "dtpMsgLogTimeTo"
        Me.dtpMsgLogTimeTo.ShowUpDown = True
        Me.dtpMsgLogTimeTo.Size = New System.Drawing.Size(112, 20)
        Me.dtpMsgLogTimeTo.TabIndex = 8
        '
        'dtpMsgLogTimeFrom
        '
        Me.dtpMsgLogTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpMsgLogTimeFrom.Location = New System.Drawing.Point(163, 41)
        Me.dtpMsgLogTimeFrom.Name = "dtpMsgLogTimeFrom"
        Me.dtpMsgLogTimeFrom.ShowUpDown = True
        Me.dtpMsgLogTimeFrom.Size = New System.Drawing.Size(112, 20)
        Me.dtpMsgLogTimeFrom.TabIndex = 7
        '
        'dtpMsgLogDateTo
        '
        Me.dtpMsgLogDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMsgLogDateTo.Location = New System.Drawing.Point(45, 67)
        Me.dtpMsgLogDateTo.Name = "dtpMsgLogDateTo"
        Me.dtpMsgLogDateTo.Size = New System.Drawing.Size(112, 20)
        Me.dtpMsgLogDateTo.TabIndex = 6
        '
        'dtpMsgLogDateFrom
        '
        Me.dtpMsgLogDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMsgLogDateFrom.Location = New System.Drawing.Point(45, 41)
        Me.dtpMsgLogDateFrom.Name = "dtpMsgLogDateFrom"
        Me.dtpMsgLogDateFrom.Size = New System.Drawing.Size(112, 20)
        Me.dtpMsgLogDateFrom.TabIndex = 3
        '
        'btnDbLogRefresh
        '
        Me.btnDbLogRefresh.Location = New System.Drawing.Point(959, 93)
        Me.btnDbLogRefresh.Name = "btnDbLogRefresh"
        Me.btnDbLogRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnDbLogRefresh.TabIndex = 2
        Me.btnDbLogRefresh.Text = "Refresh"
        Me.btnDbLogRefresh.UseVisualStyleBackColor = True
        '
        'rbMessageLog
        '
        Me.rbMessageLog.AutoSize = True
        Me.rbMessageLog.Checked = True
        Me.rbMessageLog.Location = New System.Drawing.Point(124, 3)
        Me.rbMessageLog.Name = "rbMessageLog"
        Me.rbMessageLog.Size = New System.Drawing.Size(86, 17)
        Me.rbMessageLog.TabIndex = 1
        Me.rbMessageLog.TabStop = True
        Me.rbMessageLog.Text = "MessageLog"
        Me.rbMessageLog.UseVisualStyleBackColor = True
        '
        'rbWebCloudUpdates
        '
        Me.rbWebCloudUpdates.AutoSize = True
        Me.rbWebCloudUpdates.Location = New System.Drawing.Point(3, 3)
        Me.rbWebCloudUpdates.Name = "rbWebCloudUpdates"
        Me.rbWebCloudUpdates.Size = New System.Drawing.Size(115, 17)
        Me.rbWebCloudUpdates.TabIndex = 0
        Me.rbWebCloudUpdates.Text = "WebCloudUpdates"
        Me.rbWebCloudUpdates.UseVisualStyleBackColor = True
        '
        'tpStParse
        '
        Me.tpStParse.Controls.Add(Me.Panel1)
        Me.tpStParse.Controls.Add(Me.tbSTParse)
        Me.tpStParse.Location = New System.Drawing.Point(4, 22)
        Me.tpStParse.Name = "tpStParse"
        Me.tpStParse.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStParse.Size = New System.Drawing.Size(1011, 638)
        Me.tpStParse.TabIndex = 3
        Me.tpStParse.Text = "Stack Trace Parser"
        Me.tpStParse.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnStCopy)
        Me.Panel1.Controls.Add(Me.btnStPaste)
        Me.Panel1.Controls.Add(Me.btnStParse)
        Me.Panel1.Controls.Add(Me.btnSTClear)
        Me.Panel1.Location = New System.Drawing.Point(929, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(83, 126)
        Me.Panel1.TabIndex = 3
        '
        'btnStCopy
        '
        Me.btnStCopy.Location = New System.Drawing.Point(5, 8)
        Me.btnStCopy.Name = "btnStCopy"
        Me.btnStCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnStCopy.TabIndex = 3
        Me.btnStCopy.Text = "Copy"
        Me.btnStCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStCopy.UseVisualStyleBackColor = True
        '
        'btnStPaste
        '
        Me.btnStPaste.Location = New System.Drawing.Point(5, 37)
        Me.btnStPaste.Name = "btnStPaste"
        Me.btnStPaste.Size = New System.Drawing.Size(75, 23)
        Me.btnStPaste.TabIndex = 2
        Me.btnStPaste.Text = "Paste"
        Me.btnStPaste.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStPaste.UseVisualStyleBackColor = True
        '
        'btnStParse
        '
        Me.btnStParse.Location = New System.Drawing.Point(5, 95)
        Me.btnStParse.Name = "btnStParse"
        Me.btnStParse.Size = New System.Drawing.Size(75, 23)
        Me.btnStParse.TabIndex = 0
        Me.btnStParse.Text = "Parse"
        Me.btnStParse.UseVisualStyleBackColor = True
        '
        'btnSTClear
        '
        Me.btnSTClear.Location = New System.Drawing.Point(5, 66)
        Me.btnSTClear.Name = "btnSTClear"
        Me.btnSTClear.Size = New System.Drawing.Size(75, 23)
        Me.btnSTClear.TabIndex = 1
        Me.btnSTClear.Text = "Clear"
        Me.btnSTClear.UseVisualStyleBackColor = True
        '
        'tbSTParse
        '
        Me.tbSTParse.Location = New System.Drawing.Point(9, 3)
        Me.tbSTParse.Multiline = True
        Me.tbSTParse.Name = "tbSTParse"
        Me.tbSTParse.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbSTParse.Size = New System.Drawing.Size(836, 435)
        Me.tbSTParse.TabIndex = 2
        '
        'tpOptions
        '
        Me.tpOptions.BackColor = System.Drawing.Color.Gray
        Me.tpOptions.Controls.Add(Me.gpFlavorsSettings)
        Me.tpOptions.Controls.Add(Me.gbAppLaunchSettings)
        Me.tpOptions.Controls.Add(Me.gbAppOptions)
        Me.tpOptions.Controls.Add(Me.gpAdvUpgrade)
        Me.tpOptions.Location = New System.Drawing.Point(4, 22)
        Me.tpOptions.Name = "tpOptions"
        Me.tpOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOptions.Size = New System.Drawing.Size(1011, 638)
        Me.tpOptions.TabIndex = 7
        Me.tpOptions.Text = "Options"
        '
        'gpFlavorsSettings
        '
        Me.gpFlavorsSettings.BackColor = System.Drawing.Color.LightGray
        Me.gpFlavorsSettings.Controls.Add(Me.btnSaveFlavorDefaults)
        Me.gpFlavorsSettings.Controls.Add(Me.clbSqlFiles)
        Me.gpFlavorsSettings.Controls.Add(Me.btnResetFlavorDefaults)
        Me.gpFlavorsSettings.Location = New System.Drawing.Point(7, 316)
        Me.gpFlavorsSettings.Name = "gpFlavorsSettings"
        Me.gpFlavorsSettings.Size = New System.Drawing.Size(474, 293)
        Me.gpFlavorsSettings.TabIndex = 27
        Me.gpFlavorsSettings.TabStop = False
        Me.gpFlavorsSettings.Text = "Default Flavors Selection"
        '
        'btnSaveFlavorDefaults
        '
        Me.btnSaveFlavorDefaults.Location = New System.Drawing.Point(388, 72)
        Me.btnSaveFlavorDefaults.Name = "btnSaveFlavorDefaults"
        Me.btnSaveFlavorDefaults.Size = New System.Drawing.Size(80, 50)
        Me.btnSaveFlavorDefaults.TabIndex = 27
        Me.btnSaveFlavorDefaults.Text = "Save Flavor Defaults"
        Me.btnSaveFlavorDefaults.UseVisualStyleBackColor = True
        '
        'clbSqlFiles
        '
        Me.clbSqlFiles.CheckOnClick = True
        Me.clbSqlFiles.Dock = System.Windows.Forms.DockStyle.Left
        Me.clbSqlFiles.FormattingEnabled = True
        Me.clbSqlFiles.HorizontalScrollbar = True
        Me.clbSqlFiles.Location = New System.Drawing.Point(3, 16)
        Me.clbSqlFiles.Name = "clbSqlFiles"
        Me.clbSqlFiles.Size = New System.Drawing.Size(354, 274)
        Me.clbSqlFiles.TabIndex = 0
        '
        'btnResetFlavorDefaults
        '
        Me.btnResetFlavorDefaults.Location = New System.Drawing.Point(388, 16)
        Me.btnResetFlavorDefaults.Name = "btnResetFlavorDefaults"
        Me.btnResetFlavorDefaults.Size = New System.Drawing.Size(80, 50)
        Me.btnResetFlavorDefaults.TabIndex = 28
        Me.btnResetFlavorDefaults.Text = "Reset Flavor Defaults"
        Me.btnResetFlavorDefaults.UseVisualStyleBackColor = True
        '
        'gbAppLaunchSettings
        '
        Me.gbAppLaunchSettings.BackColor = System.Drawing.Color.LightGray
        Me.gbAppLaunchSettings.Controls.Add(Me.flpAppListButtons)
        Me.gbAppLaunchSettings.Controls.Add(Me.lblPrgListbox)
        Me.gbAppLaunchSettings.Controls.Add(Me.lstPrograms)
        Me.gbAppLaunchSettings.Location = New System.Drawing.Point(6, 6)
        Me.gbAppLaunchSettings.Name = "gbAppLaunchSettings"
        Me.gbAppLaunchSettings.Size = New System.Drawing.Size(475, 304)
        Me.gbAppLaunchSettings.TabIndex = 17
        Me.gbAppLaunchSettings.TabStop = False
        Me.gbAppLaunchSettings.Text = "Application Launcher Settings"
        '
        'flpAppListButtons
        '
        Me.flpAppListButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.flpAppListButtons.Controls.Add(Me.btnAdd)
        Me.flpAppListButtons.Controls.Add(Me.btnEdit)
        Me.flpAppListButtons.Controls.Add(Me.btnDelete)
        Me.flpAppListButtons.Controls.Add(Me.btnLaunch)
        Me.flpAppListButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpAppListButtons.Location = New System.Drawing.Point(379, 41)
        Me.flpAppListButtons.Margin = New System.Windows.Forms.Padding(0)
        Me.flpAppListButtons.Name = "flpAppListButtons"
        Me.flpAppListButtons.Size = New System.Drawing.Size(90, 208)
        Me.flpAppListButtons.TabIndex = 16
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(2, 0)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 50)
        Me.btnAdd.TabIndex = 13
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(2, 50)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(80, 50)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(2, 100)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 50)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnLaunch
        '
        Me.btnLaunch.Location = New System.Drawing.Point(2, 150)
        Me.btnLaunch.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.btnLaunch.Name = "btnLaunch"
        Me.btnLaunch.Size = New System.Drawing.Size(80, 50)
        Me.btnLaunch.TabIndex = 16
        Me.btnLaunch.Text = "Launch"
        Me.btnLaunch.UseVisualStyleBackColor = True
        '
        'lblPrgListbox
        '
        Me.lblPrgListbox.AutoSize = True
        Me.lblPrgListbox.Location = New System.Drawing.Point(9, 25)
        Me.lblPrgListbox.Name = "lblPrgListbox"
        Me.lblPrgListbox.Size = New System.Drawing.Size(78, 13)
        Me.lblPrgListbox.TabIndex = 15
        Me.lblPrgListbox.Text = "Application List"
        '
        'lstPrograms
        '
        Me.lstPrograms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstPrograms.ContextMenuStrip = Me.cmsQuickLaunch
        Me.lstPrograms.FormattingEnabled = True
        Me.lstPrograms.Location = New System.Drawing.Point(13, 41)
        Me.lstPrograms.Name = "lstPrograms"
        Me.lstPrograms.Size = New System.Drawing.Size(335, 225)
        Me.lstPrograms.Sorted = True
        Me.lstPrograms.TabIndex = 3
        '
        'cmsQuickLaunch
        '
        Me.cmsQuickLaunch.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsQuickLaunchSlot1, Me.cmsQuickLaunchSlot2})
        Me.cmsQuickLaunch.Name = "cmsQuickLaunch"
        Me.cmsQuickLaunch.Size = New System.Drawing.Size(104, 48)
        Me.cmsQuickLaunch.Text = "Assign to Quick Launch"
        '
        'cmsQuickLaunchSlot1
        '
        Me.cmsQuickLaunchSlot1.Name = "cmsQuickLaunchSlot1"
        Me.cmsQuickLaunchSlot1.Size = New System.Drawing.Size(103, 22)
        Me.cmsQuickLaunchSlot1.Text = "Slot 1"
        '
        'cmsQuickLaunchSlot2
        '
        Me.cmsQuickLaunchSlot2.Name = "cmsQuickLaunchSlot2"
        Me.cmsQuickLaunchSlot2.Size = New System.Drawing.Size(103, 22)
        Me.cmsQuickLaunchSlot2.Text = "Slot 2"
        '
        'gbAppOptions
        '
        Me.gbAppOptions.BackColor = System.Drawing.Color.LightGray
        Me.gbAppOptions.Controls.Add(Me.TableLayoutPanel1)
        Me.gbAppOptions.Controls.Add(Me.tbDatabaseStartCommand)
        Me.gbAppOptions.Controls.Add(Me.tbFlavorApplyCommand)
        Me.gbAppOptions.Controls.Add(Me.lblFlavorApplyCommand)
        Me.gbAppOptions.Controls.Add(Me.lblDatabaseStartCommand)
        Me.gbAppOptions.Location = New System.Drawing.Point(499, 6)
        Me.gbAppOptions.Name = "gbAppOptions"
        Me.gbAppOptions.Size = New System.Drawing.Size(498, 266)
        Me.gbAppOptions.TabIndex = 17
        Me.gbAppOptions.TabStop = False
        Me.gbAppOptions.Text = "Application Options"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.tbApplyFlavorDefault, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbDatabaseStartDefault, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbWindowTitle, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblApplyFlavorDefault, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbRepoFolder, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDatabaseStartDefault, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRepoFolder, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRepoFolder, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSetupSwitches, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbSetupSwitches, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblWindowTitle, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkShowHiddenServices, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowHiddenServices, 0, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(487, 157)
        Me.TableLayoutPanel1.TabIndex = 28
        '
        'tbApplyFlavorDefault
        '
        Me.tbApplyFlavorDefault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbApplyFlavorDefault.Location = New System.Drawing.Point(133, 133)
        Me.tbApplyFlavorDefault.Name = "tbApplyFlavorDefault"
        Me.tbApplyFlavorDefault.Size = New System.Drawing.Size(315, 20)
        Me.tbApplyFlavorDefault.TabIndex = 29
        '
        'tbDatabaseStartDefault
        '
        Me.tbDatabaseStartDefault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbDatabaseStartDefault.Location = New System.Drawing.Point(133, 107)
        Me.tbDatabaseStartDefault.Name = "tbDatabaseStartDefault"
        Me.tbDatabaseStartDefault.Size = New System.Drawing.Size(315, 20)
        Me.tbDatabaseStartDefault.TabIndex = 28
        '
        'tbWindowTitle
        '
        Me.tbWindowTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbWindowTitle.Location = New System.Drawing.Point(133, 3)
        Me.tbWindowTitle.Name = "tbWindowTitle"
        Me.tbWindowTitle.Size = New System.Drawing.Size(315, 20)
        Me.tbWindowTitle.TabIndex = 1
        '
        'lblApplyFlavorDefault
        '
        Me.lblApplyFlavorDefault.AutoSize = True
        Me.lblApplyFlavorDefault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblApplyFlavorDefault.Location = New System.Drawing.Point(3, 130)
        Me.lblApplyFlavorDefault.Name = "lblApplyFlavorDefault"
        Me.lblApplyFlavorDefault.Size = New System.Drawing.Size(124, 27)
        Me.lblApplyFlavorDefault.TabIndex = 27
        Me.lblApplyFlavorDefault.Text = "Apply Flavor Default:  "
        Me.lblApplyFlavorDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbRepoFolder
        '
        Me.tbRepoFolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbRepoFolder.Location = New System.Drawing.Point(133, 29)
        Me.tbRepoFolder.Name = "tbRepoFolder"
        Me.tbRepoFolder.Size = New System.Drawing.Size(315, 20)
        Me.tbRepoFolder.TabIndex = 3
        '
        'lblDatabaseStartDefault
        '
        Me.lblDatabaseStartDefault.AutoSize = True
        Me.lblDatabaseStartDefault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDatabaseStartDefault.Location = New System.Drawing.Point(3, 104)
        Me.lblDatabaseStartDefault.Name = "lblDatabaseStartDefault"
        Me.lblDatabaseStartDefault.Size = New System.Drawing.Size(124, 26)
        Me.lblDatabaseStartDefault.TabIndex = 26
        Me.lblDatabaseStartDefault.Text = "Start Database Default:  "
        Me.lblDatabaseStartDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRepoFolder
        '
        Me.btnRepoFolder.Image = Global.STA2.My.Resources.Resources.imgOpenFolder16
        Me.btnRepoFolder.Location = New System.Drawing.Point(454, 29)
        Me.btnRepoFolder.Name = "btnRepoFolder"
        Me.btnRepoFolder.Size = New System.Drawing.Size(30, 23)
        Me.btnRepoFolder.TabIndex = 23
        Me.btnRepoFolder.UseVisualStyleBackColor = True
        '
        'lblRepoFolder
        '
        Me.lblRepoFolder.AutoSize = True
        Me.lblRepoFolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRepoFolder.Location = New System.Drawing.Point(3, 26)
        Me.lblRepoFolder.Name = "lblRepoFolder"
        Me.lblRepoFolder.Size = New System.Drawing.Size(124, 29)
        Me.lblRepoFolder.TabIndex = 4
        Me.lblRepoFolder.Text = "Repo Folder:"
        Me.lblRepoFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSetupSwitches
        '
        Me.lblSetupSwitches.AutoSize = True
        Me.lblSetupSwitches.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSetupSwitches.Location = New System.Drawing.Point(3, 55)
        Me.lblSetupSwitches.Name = "lblSetupSwitches"
        Me.lblSetupSwitches.Size = New System.Drawing.Size(124, 26)
        Me.lblSetupSwitches.TabIndex = 25
        Me.lblSetupSwitches.Text = "Installer Switches:"
        Me.lblSetupSwitches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbSetupSwitches
        '
        Me.tbSetupSwitches.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbSetupSwitches.Location = New System.Drawing.Point(133, 58)
        Me.tbSetupSwitches.Name = "tbSetupSwitches"
        Me.tbSetupSwitches.Size = New System.Drawing.Size(315, 20)
        Me.tbSetupSwitches.TabIndex = 24
        '
        'lblWindowTitle
        '
        Me.lblWindowTitle.AutoSize = True
        Me.lblWindowTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWindowTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblWindowTitle.Name = "lblWindowTitle"
        Me.lblWindowTitle.Size = New System.Drawing.Size(124, 26)
        Me.lblWindowTitle.TabIndex = 2
        Me.lblWindowTitle.Text = "Window Title:"
        Me.lblWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkShowHiddenServices
        '
        Me.chkShowHiddenServices.AutoSize = True
        Me.chkShowHiddenServices.Location = New System.Drawing.Point(133, 84)
        Me.chkShowHiddenServices.Name = "chkShowHiddenServices"
        Me.chkShowHiddenServices.Size = New System.Drawing.Size(227, 17)
        Me.chkShowHiddenServices.TabIndex = 18
        Me.chkShowHiddenServices.Text = "Shows uninstalled services when checked"
        Me.chkShowHiddenServices.UseVisualStyleBackColor = True
        '
        'lblShowHiddenServices
        '
        Me.lblShowHiddenServices.AutoSize = True
        Me.lblShowHiddenServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblShowHiddenServices.Location = New System.Drawing.Point(3, 81)
        Me.lblShowHiddenServices.Name = "lblShowHiddenServices"
        Me.lblShowHiddenServices.Size = New System.Drawing.Size(124, 23)
        Me.lblShowHiddenServices.TabIndex = 30
        Me.lblShowHiddenServices.Text = "Show Hidden Services:"
        Me.lblShowHiddenServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbDatabaseStartCommand
        '
        Me.tbDatabaseStartCommand.Location = New System.Drawing.Point(146, 235)
        Me.tbDatabaseStartCommand.Name = "tbDatabaseStartCommand"
        Me.tbDatabaseStartCommand.Size = New System.Drawing.Size(298, 20)
        Me.tbDatabaseStartCommand.TabIndex = 26
        '
        'tbFlavorApplyCommand
        '
        Me.tbFlavorApplyCommand.Location = New System.Drawing.Point(137, 209)
        Me.tbFlavorApplyCommand.Name = "tbFlavorApplyCommand"
        Me.tbFlavorApplyCommand.Size = New System.Drawing.Size(324, 20)
        Me.tbFlavorApplyCommand.TabIndex = 26
        '
        'lblFlavorApplyCommand
        '
        Me.lblFlavorApplyCommand.AutoSize = True
        Me.lblFlavorApplyCommand.Location = New System.Drawing.Point(0, 216)
        Me.lblFlavorApplyCommand.Name = "lblFlavorApplyCommand"
        Me.lblFlavorApplyCommand.Size = New System.Drawing.Size(147, 13)
        Me.lblFlavorApplyCommand.TabIndex = 24
        Me.lblFlavorApplyCommand.Text = "Apply Flavor Command Line:  "
        '
        'lblDatabaseStartCommand
        '
        Me.lblDatabaseStartCommand.AutoSize = True
        Me.lblDatabaseStartCommand.Location = New System.Drawing.Point(-3, 239)
        Me.lblDatabaseStartCommand.Name = "lblDatabaseStartCommand"
        Me.lblDatabaseStartCommand.Size = New System.Drawing.Size(160, 13)
        Me.lblDatabaseStartCommand.TabIndex = 25
        Me.lblDatabaseStartCommand.Text = "Start Database Command Line:  "
        '
        'gpAdvUpgrade
        '
        Me.gpAdvUpgrade.BackColor = System.Drawing.Color.LightGray
        Me.gpAdvUpgrade.Controls.Add(Me.lblAdvUpgrade)
        Me.gpAdvUpgrade.Controls.Add(Me.tbAdvupgrade)
        Me.gpAdvUpgrade.Controls.Add(Me.cbAdvUpgradeNoBackup)
        Me.gpAdvUpgrade.Controls.Add(Me.cbAdvUpgradeNoSetup)
        Me.gpAdvUpgrade.Controls.Add(Me.cbAdvUpgradeQuiet)
        Me.gpAdvUpgrade.Location = New System.Drawing.Point(499, 282)
        Me.gpAdvUpgrade.Name = "gpAdvUpgrade"
        Me.gpAdvUpgrade.Size = New System.Drawing.Size(374, 156)
        Me.gpAdvUpgrade.TabIndex = 0
        Me.gpAdvUpgrade.TabStop = False
        Me.gpAdvUpgrade.Text = "Advantage Upgrade"
        '
        'lblAdvUpgrade
        '
        Me.lblAdvUpgrade.AutoSize = True
        Me.lblAdvUpgrade.Location = New System.Drawing.Point(14, 114)
        Me.lblAdvUpgrade.Name = "lblAdvUpgrade"
        Me.lblAdvUpgrade.Size = New System.Drawing.Size(77, 13)
        Me.lblAdvUpgrade.TabIndex = 4
        Me.lblAdvUpgrade.Text = "Command Line"
        '
        'tbAdvupgrade
        '
        Me.tbAdvupgrade.Location = New System.Drawing.Point(17, 130)
        Me.tbAdvupgrade.Name = "tbAdvupgrade"
        Me.tbAdvupgrade.Size = New System.Drawing.Size(269, 20)
        Me.tbAdvupgrade.TabIndex = 3
        Me.tbAdvupgrade.Text = "AdvUpgrade.exe"
        '
        'cbAdvUpgradeNoBackup
        '
        Me.cbAdvUpgradeNoBackup.AutoSize = True
        Me.cbAdvUpgradeNoBackup.Location = New System.Drawing.Point(17, 77)
        Me.cbAdvUpgradeNoBackup.Name = "cbAdvUpgradeNoBackup"
        Me.cbAdvUpgradeNoBackup.Size = New System.Drawing.Size(197, 17)
        Me.cbAdvUpgradeNoBackup.TabIndex = 2
        Me.cbAdvUpgradeNoBackup.Text = "Do not make a backup [/nobackup]"
        Me.cbAdvUpgradeNoBackup.UseVisualStyleBackColor = True
        '
        'cbAdvUpgradeNoSetup
        '
        Me.cbAdvUpgradeNoSetup.AutoSize = True
        Me.cbAdvUpgradeNoSetup.Location = New System.Drawing.Point(17, 54)
        Me.cbAdvUpgradeNoSetup.Name = "cbAdvUpgradeNoSetup"
        Me.cbAdvUpgradeNoSetup.Size = New System.Drawing.Size(214, 17)
        Me.cbAdvUpgradeNoSetup.TabIndex = 1
        Me.cbAdvUpgradeNoSetup.Text = "Do not run Advantage Setup [/nosetup]"
        Me.cbAdvUpgradeNoSetup.UseVisualStyleBackColor = True
        '
        'cbAdvUpgradeQuiet
        '
        Me.cbAdvUpgradeQuiet.AutoSize = True
        Me.cbAdvUpgradeQuiet.Location = New System.Drawing.Point(17, 31)
        Me.cbAdvUpgradeQuiet.Name = "cbAdvUpgradeQuiet"
        Me.cbAdvUpgradeQuiet.Size = New System.Drawing.Size(248, 17)
        Me.cbAdvUpgradeQuiet.TabIndex = 0
        Me.cbAdvUpgradeQuiet.Text = "Quiet Mode (Runs in Cmd Prompt Window) [/q]"
        Me.cbAdvUpgradeQuiet.UseVisualStyleBackColor = True
        '
        'tbMLTest1
        '
        Me.tbMLTest1.Location = New System.Drawing.Point(444, 9)
        Me.tbMLTest1.Multiline = True
        Me.tbMLTest1.Name = "tbMLTest1"
        Me.tbMLTest1.Size = New System.Drawing.Size(178, 52)
        Me.tbMLTest1.TabIndex = 35
        '
        'btnTest2
        '
        Me.btnTest2.Location = New System.Drawing.Point(549, 132)
        Me.btnTest2.Name = "btnTest2"
        Me.btnTest2.Size = New System.Drawing.Size(88, 23)
        Me.btnTest2.TabIndex = 23
        Me.btnTest2.Text = "Test Button 2"
        Me.btnTest2.UseVisualStyleBackColor = True
        '
        'gpCommonApps
        '
        Me.gpCommonApps.BackColor = System.Drawing.Color.LightGray
        Me.gpCommonApps.Controls.Add(Me.btnServices)
        Me.gpCommonApps.Controls.Add(Me.btnDevices)
        Me.gpCommonApps.Controls.Add(Me.btnEventViewer)
        Me.gpCommonApps.Controls.Add(Me.btnAppWiz)
        Me.gpCommonApps.Controls.Add(Me.btnTaskmgr)
        Me.gpCommonApps.Controls.Add(Me.btnCalc)
        Me.gpCommonApps.Location = New System.Drawing.Point(725, 7)
        Me.gpCommonApps.Name = "gpCommonApps"
        Me.gpCommonApps.Size = New System.Drawing.Size(271, 138)
        Me.gpCommonApps.TabIndex = 22
        Me.gpCommonApps.TabStop = False
        Me.gpCommonApps.Text = "Common Apps"
        '
        'btnServices
        '
        Me.btnServices.Location = New System.Drawing.Point(178, 75)
        Me.btnServices.Name = "btnServices"
        Me.btnServices.Size = New System.Drawing.Size(80, 50)
        Me.btnServices.TabIndex = 25
        Me.btnServices.Text = "Services"
        Me.btnServices.UseVisualStyleBackColor = True
        '
        'btnDevices
        '
        Me.btnDevices.Location = New System.Drawing.Point(178, 20)
        Me.btnDevices.Name = "btnDevices"
        Me.btnDevices.Size = New System.Drawing.Size(80, 50)
        Me.btnDevices.TabIndex = 24
        Me.btnDevices.Text = "Devices and Printers"
        Me.btnDevices.UseVisualStyleBackColor = True
        '
        'btnEventViewer
        '
        Me.btnEventViewer.Location = New System.Drawing.Point(92, 75)
        Me.btnEventViewer.Name = "btnEventViewer"
        Me.btnEventViewer.Size = New System.Drawing.Size(80, 50)
        Me.btnEventViewer.TabIndex = 23
        Me.btnEventViewer.Text = "Event Viewer"
        Me.btnEventViewer.UseVisualStyleBackColor = True
        '
        'btnAppWiz
        '
        Me.btnAppWiz.Location = New System.Drawing.Point(92, 19)
        Me.btnAppWiz.Name = "btnAppWiz"
        Me.btnAppWiz.Size = New System.Drawing.Size(80, 50)
        Me.btnAppWiz.TabIndex = 22
        Me.btnAppWiz.Text = "Programs and Features"
        Me.btnAppWiz.UseVisualStyleBackColor = True
        '
        'btnTaskmgr
        '
        Me.btnTaskmgr.Location = New System.Drawing.Point(6, 75)
        Me.btnTaskmgr.Name = "btnTaskmgr"
        Me.btnTaskmgr.Size = New System.Drawing.Size(80, 50)
        Me.btnTaskmgr.TabIndex = 21
        Me.btnTaskmgr.Text = "Task Manager"
        Me.btnTaskmgr.UseVisualStyleBackColor = True
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(6, 19)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(80, 50)
        Me.btnCalc.TabIndex = 20
        Me.btnCalc.Text = "Calculator"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'btnTest1
        '
        Me.btnTest1.Location = New System.Drawing.Point(447, 132)
        Me.btnTest1.Name = "btnTest1"
        Me.btnTest1.Size = New System.Drawing.Size(75, 23)
        Me.btnTest1.TabIndex = 18
        Me.btnTest1.Text = "Test Button"
        Me.btnTest1.UseVisualStyleBackColor = True
        '
        'tbTest1
        '
        Me.tbTest1.Location = New System.Drawing.Point(444, 65)
        Me.tbTest1.Name = "tbTest1"
        Me.tbTest1.Size = New System.Drawing.Size(233, 20)
        Me.tbTest1.TabIndex = 19
        Me.tbTest1.Text = "tbTest1"
        '
        'tbTest3
        '
        Me.tbTest3.Location = New System.Drawing.Point(444, 106)
        Me.tbTest3.Name = "tbTest3"
        Me.tbTest3.Size = New System.Drawing.Size(233, 20)
        Me.tbTest3.TabIndex = 21
        Me.tbTest3.Text = "tbTest3"
        '
        'tbTest2
        '
        Me.tbTest2.Location = New System.Drawing.Point(444, 85)
        Me.tbTest2.Name = "tbTest2"
        Me.tbTest2.Size = New System.Drawing.Size(233, 20)
        Me.tbTest2.TabIndex = 20
        Me.tbTest2.Text = "tbTest2"
        '
        'gbAdvApps
        '
        Me.gbAdvApps.BackColor = System.Drawing.Color.LightGray
        Me.gbAdvApps.Controls.Add(Me.btnAdvKiosk)
        Me.gbAdvApps.Controls.Add(Me.btnAdvKioskSetup)
        Me.gbAdvApps.Controls.Add(Me.lblAdvApps)
        Me.gbAdvApps.Controls.Add(Me.btnAdvUpgrade)
        Me.gbAdvApps.Controls.Add(Me.btnAdvManager)
        Me.gbAdvApps.Controls.Add(Me.btnCenterEdgeConfig)
        Me.gbAdvApps.Controls.Add(Me.btnAdvCardTech)
        Me.gbAdvApps.Controls.Add(Me.btnAdvRedeem)
        Me.gbAdvApps.Controls.Add(Me.btnPos)
        Me.gbAdvApps.Controls.Add(Me.btnAdvReportEditor)
        Me.gbAdvApps.Controls.Add(Me.btnAdvGroups)
        Me.gbAdvApps.Location = New System.Drawing.Point(4, 4)
        Me.gbAdvApps.Name = "gbAdvApps"
        Me.gbAdvApps.Size = New System.Drawing.Size(434, 155)
        Me.gbAdvApps.TabIndex = 19
        Me.gbAdvApps.TabStop = False
        Me.gbAdvApps.Text = "Advantage Applications"
        '
        'btnAdvKiosk
        '
        Me.btnAdvKiosk.Enabled = False
        Me.btnAdvKiosk.Location = New System.Drawing.Point(265, 77)
        Me.btnAdvKiosk.Name = "btnAdvKiosk"
        Me.btnAdvKiosk.Size = New System.Drawing.Size(80, 50)
        Me.btnAdvKiosk.TabIndex = 20
        Me.btnAdvKiosk.Text = "Kiosk"
        Me.btnAdvKiosk.UseVisualStyleBackColor = True
        '
        'btnAdvKioskSetup
        '
        Me.btnAdvKioskSetup.Enabled = False
        Me.btnAdvKioskSetup.Location = New System.Drawing.Point(265, 20)
        Me.btnAdvKioskSetup.Name = "btnAdvKioskSetup"
        Me.btnAdvKioskSetup.Size = New System.Drawing.Size(80, 50)
        Me.btnAdvKioskSetup.TabIndex = 19
        Me.btnAdvKioskSetup.Text = "Kiosk Setup"
        Me.btnAdvKioskSetup.UseVisualStyleBackColor = True
        '
        'lblAdvApps
        '
        Me.lblAdvApps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAdvApps.AutoSize = True
        Me.lblAdvApps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdvApps.Location = New System.Drawing.Point(25, 137)
        Me.lblAdvApps.Name = "lblAdvApps"
        Me.lblAdvApps.Size = New System.Drawing.Size(205, 13)
        Me.lblAdvApps.TabIndex = 18
        Me.lblAdvApps.Text = "Button disabled if App not installed"
        '
        'btnAdvUpgrade
        '
        Me.btnAdvUpgrade.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdvUpgrade.Location = New System.Drawing.Point(348, 77)
        Me.btnAdvUpgrade.Name = "btnAdvUpgrade"
        Me.btnAdvUpgrade.Size = New System.Drawing.Size(80, 50)
        Me.btnAdvUpgrade.TabIndex = 18
        Me.btnAdvUpgrade.Text = "Advantage Upgrade"
        Me.btnAdvUpgrade.UseVisualStyleBackColor = True
        '
        'btnAdvManager
        '
        Me.btnAdvManager.Enabled = False
        Me.btnAdvManager.Location = New System.Drawing.Point(7, 20)
        Me.btnAdvManager.Name = "btnAdvManager"
        Me.btnAdvManager.Size = New System.Drawing.Size(80, 50)
        Me.btnAdvManager.TabIndex = 15
        Me.btnAdvManager.Text = "Manager " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Console"
        Me.btnAdvManager.UseVisualStyleBackColor = True
        '
        'btnCenterEdgeConfig
        '
        Me.btnCenterEdgeConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCenterEdgeConfig.Location = New System.Drawing.Point(348, 20)
        Me.btnCenterEdgeConfig.Name = "btnCenterEdgeConfig"
        Me.btnCenterEdgeConfig.Size = New System.Drawing.Size(80, 50)
        Me.btnCenterEdgeConfig.TabIndex = 12
        Me.btnCenterEdgeConfig.Text = "CenterEdge Configuration"
        Me.btnCenterEdgeConfig.UseVisualStyleBackColor = True
        '
        'btnAdvCardTech
        '
        Me.btnAdvCardTech.Enabled = False
        Me.btnAdvCardTech.Location = New System.Drawing.Point(179, 76)
        Me.btnAdvCardTech.Name = "btnAdvCardTech"
        Me.btnAdvCardTech.Size = New System.Drawing.Size(80, 50)
        Me.btnAdvCardTech.TabIndex = 15
        Me.btnAdvCardTech.Text = "Card Tech"
        Me.btnAdvCardTech.UseVisualStyleBackColor = True
        '
        'btnAdvRedeem
        '
        Me.btnAdvRedeem.Enabled = False
        Me.btnAdvRedeem.Location = New System.Drawing.Point(93, 76)
        Me.btnAdvRedeem.Name = "btnAdvRedeem"
        Me.btnAdvRedeem.Size = New System.Drawing.Size(80, 50)
        Me.btnAdvRedeem.TabIndex = 15
        Me.btnAdvRedeem.Text = "Redemption"
        Me.btnAdvRedeem.UseVisualStyleBackColor = True
        '
        'btnPos
        '
        Me.btnPos.Enabled = False
        Me.btnPos.Location = New System.Drawing.Point(93, 20)
        Me.btnPos.Name = "btnPos"
        Me.btnPos.Size = New System.Drawing.Size(80, 50)
        Me.btnPos.TabIndex = 15
        Me.btnPos.Text = "POS"
        Me.btnPos.UseVisualStyleBackColor = True
        '
        'btnAdvReportEditor
        '
        Me.btnAdvReportEditor.Enabled = False
        Me.btnAdvReportEditor.Location = New System.Drawing.Point(7, 76)
        Me.btnAdvReportEditor.Name = "btnAdvReportEditor"
        Me.btnAdvReportEditor.Size = New System.Drawing.Size(80, 50)
        Me.btnAdvReportEditor.TabIndex = 17
        Me.btnAdvReportEditor.Text = "Report Editor"
        Me.btnAdvReportEditor.UseVisualStyleBackColor = True
        '
        'btnAdvGroups
        '
        Me.btnAdvGroups.Enabled = False
        Me.btnAdvGroups.Location = New System.Drawing.Point(179, 20)
        Me.btnAdvGroups.Name = "btnAdvGroups"
        Me.btnAdvGroups.Size = New System.Drawing.Size(80, 50)
        Me.btnAdvGroups.TabIndex = 16
        Me.btnAdvGroups.Text = "Groups"
        Me.btnAdvGroups.UseVisualStyleBackColor = True
        '
        'btnRunDatabaseStartLive
        '
        Me.btnRunDatabaseStartLive.Location = New System.Drawing.Point(252, 59)
        Me.btnRunDatabaseStartLive.Name = "btnRunDatabaseStartLive"
        Me.btnRunDatabaseStartLive.Size = New System.Drawing.Size(77, 50)
        Me.btnRunDatabaseStartLive.TabIndex = 31
        Me.btnRunDatabaseStartLive.Text = "Start Database"
        Me.btnRunDatabaseStartLive.UseVisualStyleBackColor = True
        '
        'btnRunApplyFlavorLive
        '
        Me.btnRunApplyFlavorLive.Location = New System.Drawing.Point(252, 3)
        Me.btnRunApplyFlavorLive.Name = "btnRunApplyFlavorLive"
        Me.btnRunApplyFlavorLive.Size = New System.Drawing.Size(77, 50)
        Me.btnRunApplyFlavorLive.TabIndex = 30
        Me.btnRunApplyFlavorLive.Text = "Apply Flavors"
        Me.btnRunApplyFlavorLive.UseVisualStyleBackColor = True
        '
        'cmbboxAppLaunch
        '
        Me.cmbboxAppLaunch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbboxAppLaunch.FormattingEnabled = True
        Me.cmbboxAppLaunch.Location = New System.Drawing.Point(4, 568)
        Me.cmbboxAppLaunch.Name = "cmbboxAppLaunch"
        Me.cmbboxAppLaunch.Size = New System.Drawing.Size(239, 21)
        Me.cmbboxAppLaunch.Sorted = True
        Me.cmbboxAppLaunch.TabIndex = 18
        '
        'btnComboAppLaunch
        '
        Me.btnComboAppLaunch.Location = New System.Drawing.Point(249, 566)
        Me.btnComboAppLaunch.Name = "btnComboAppLaunch"
        Me.btnComboAppLaunch.Size = New System.Drawing.Size(75, 23)
        Me.btnComboAppLaunch.TabIndex = 19
        Me.btnComboAppLaunch.Text = "Launch"
        Me.btnComboAppLaunch.UseVisualStyleBackColor = True
        '
        'btnReconnect
        '
        Me.btnReconnect.Location = New System.Drawing.Point(3, 115)
        Me.btnReconnect.Name = "btnReconnect"
        Me.btnReconnect.Size = New System.Drawing.Size(77, 50)
        Me.btnReconnect.TabIndex = 22
        Me.btnReconnect.Text = "Reconnect"
        Me.btnReconnect.UseVisualStyleBackColor = True
        '
        'flpQuickLaunch
        '
        Me.flpQuickLaunch.AllowDrop = True
        Me.flpQuickLaunch.BackColor = System.Drawing.Color.LightGray
        Me.flpQuickLaunch.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpQuickLaunch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.flpQuickLaunch.Location = New System.Drawing.Point(0, 0)
        Me.flpQuickLaunch.Name = "flpQuickLaunch"
        Me.flpQuickLaunch.Size = New System.Drawing.Size(332, 563)
        Me.flpQuickLaunch.TabIndex = 21
        '
        'btnAdminRestart
        '
        Me.btnAdminRestart.Location = New System.Drawing.Point(3, 59)
        Me.btnAdminRestart.Name = "btnAdminRestart"
        Me.btnAdminRestart.Size = New System.Drawing.Size(77, 50)
        Me.btnAdminRestart.TabIndex = 20
        Me.btnAdminRestart.Text = "Relaunch as Admin"
        Me.btnAdminRestart.UseVisualStyleBackColor = True
        '
        'btnRefreshGeneralTab
        '
        Me.btnRefreshGeneralTab.Location = New System.Drawing.Point(3, 171)
        Me.btnRefreshGeneralTab.Name = "btnRefreshGeneralTab"
        Me.btnRefreshGeneralTab.Size = New System.Drawing.Size(77, 50)
        Me.btnRefreshGeneralTab.TabIndex = 17
        Me.btnRefreshGeneralTab.Text = "Refresh Tab"
        Me.btnRefreshGeneralTab.UseVisualStyleBackColor = True
        '
        'btnBatchLaunch
        '
        Me.btnBatchLaunch.Location = New System.Drawing.Point(3, 3)
        Me.btnBatchLaunch.Name = "btnBatchLaunch"
        Me.btnBatchLaunch.Size = New System.Drawing.Size(77, 50)
        Me.btnBatchLaunch.TabIndex = 15
        Me.btnBatchLaunch.Text = "Batch Launch"
        Me.btnBatchLaunch.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "RestartCloud2.bmp")
        Me.ImageList1.Images.SetKeyName(1, "reload-icon-8.jpg")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblCeVersion, Me.tslblTime, Me.tslblNetVersion, Me.tslblExecutionStatus, Me.tslblDbState})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 830)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1371, 24)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslblCeVersion
        '
        Me.tslblCeVersion.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblCeVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.tslblCeVersion.Name = "tslblCeVersion"
        Me.tslblCeVersion.Size = New System.Drawing.Size(124, 19)
        Me.tslblCeVersion.Text = "ToolStripStatusLabel1"
        '
        'tslblTime
        '
        Me.tslblTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblTime.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.tslblTime.Name = "tslblTime"
        Me.tslblTime.Size = New System.Drawing.Size(124, 19)
        Me.tslblTime.Text = "ToolStripStatusLabel1"
        '
        'tslblNetVersion
        '
        Me.tslblNetVersion.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblNetVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.tslblNetVersion.Name = "tslblNetVersion"
        Me.tslblNetVersion.Size = New System.Drawing.Size(124, 19)
        Me.tslblNetVersion.Text = "ToolStripStatusLabel1"
        '
        'tslblExecutionStatus
        '
        Me.tslblExecutionStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblExecutionStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.tslblExecutionStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tslblExecutionStatus.Name = "tslblExecutionStatus"
        Me.tslblExecutionStatus.Size = New System.Drawing.Size(124, 19)
        Me.tslblExecutionStatus.Text = "ToolStripStatusLabel1"
        '
        'tslblDbState
        '
        Me.tslblDbState.BackColor = System.Drawing.Color.DarkGreen
        Me.tslblDbState.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tslblDbState.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.tslblDbState.Name = "tslblDbState"
        Me.tslblDbState.Size = New System.Drawing.Size(50, 19)
        Me.tslblDbState.Text = "ONLINE"
        '
        'tmr10Seconds
        '
        Me.tmr10Seconds.Enabled = True
        Me.tmr10Seconds.Interval = 10000
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(150, 125)
        '
        'tmr1Sec
        '
        Me.tmr1Sec.Enabled = True
        Me.tmr1Sec.Interval = 250
        '
        'ttSTA2
        '
        Me.ttSTA2.IsBalloon = True
        Me.ttSTA2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ttSTA2.ToolTipTitle = "Support Tech Assistant 2022"
        '
        'FolderBrowserDialog
        '
        Me.FolderBrowserDialog.Description = "folders"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.flpQuickLaunch)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbboxAppLaunch)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnComboAppLaunch)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer2.Panel2.Controls.Add(Me.tlpButtons3)
        Me.SplitContainer2.Size = New System.Drawing.Size(336, 827)
        Me.SplitContainer2.SplitterDistance = 594
        Me.SplitContainer2.SplitterWidth = 3
        Me.SplitContainer2.TabIndex = 22
        '
        'tlpButtons3
        '
        Me.tlpButtons3.ColumnCount = 4
        Me.tlpButtons3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpButtons3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpButtons3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpButtons3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpButtons3.Controls.Add(Me.btnExit, 3, 3)
        Me.tlpButtons3.Controls.Add(Me.btnBatchLaunch, 0, 0)
        Me.tlpButtons3.Controls.Add(Me.btnRunDatabaseStartLive, 3, 1)
        Me.tlpButtons3.Controls.Add(Me.btnAdminRestart, 0, 1)
        Me.tlpButtons3.Controls.Add(Me.btnReconnect, 0, 2)
        Me.tlpButtons3.Controls.Add(Me.btnRunApplyFlavorLive, 3, 0)
        Me.tlpButtons3.Controls.Add(Me.btnRefreshGeneralTab, 0, 3)
        Me.tlpButtons3.Controls.Add(Me.btnRepoMain, 1, 3)
        Me.tlpButtons3.Controls.Add(Me.btnSetupInstall, 1, 0)
        Me.tlpButtons3.Controls.Add(Me.btnLaunchLatestInstaller, 1, 1)
        Me.tlpButtons3.Controls.Add(Me.btnRepoDiscardChanges, 1, 2)
        Me.tlpButtons3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpButtons3.Location = New System.Drawing.Point(0, 0)
        Me.tlpButtons3.Name = "tlpButtons3"
        Me.tlpButtons3.RowCount = 4
        Me.tlpButtons3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpButtons3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpButtons3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpButtons3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpButtons3.Size = New System.Drawing.Size(332, 226)
        Me.tlpButtons3.TabIndex = 0
        '
        'btnRepoMain
        '
        Me.btnRepoMain.Location = New System.Drawing.Point(86, 171)
        Me.btnRepoMain.Name = "btnRepoMain"
        Me.btnRepoMain.Size = New System.Drawing.Size(77, 50)
        Me.btnRepoMain.TabIndex = 26
        Me.btnRepoMain.Text = "Switch Repo to Main"
        Me.btnRepoMain.UseVisualStyleBackColor = True
        '
        'btnSetupInstall
        '
        Me.btnSetupInstall.Location = New System.Drawing.Point(86, 3)
        Me.btnSetupInstall.Name = "btnSetupInstall"
        Me.btnSetupInstall.Size = New System.Drawing.Size(77, 50)
        Me.btnSetupInstall.TabIndex = 25
        Me.btnSetupInstall.Text = "Extract and Install"
        Me.btnSetupInstall.UseVisualStyleBackColor = True
        '
        'btnLaunchLatestInstaller
        '
        Me.btnLaunchLatestInstaller.Location = New System.Drawing.Point(86, 59)
        Me.btnLaunchLatestInstaller.Name = "btnLaunchLatestInstaller"
        Me.btnLaunchLatestInstaller.Size = New System.Drawing.Size(77, 50)
        Me.btnLaunchLatestInstaller.TabIndex = 23
        Me.btnLaunchLatestInstaller.Text = "Latest Installer"
        Me.btnLaunchLatestInstaller.UseVisualStyleBackColor = True
        '
        'btnRepoDiscardChanges
        '
        Me.btnRepoDiscardChanges.Location = New System.Drawing.Point(86, 115)
        Me.btnRepoDiscardChanges.Name = "btnRepoDiscardChanges"
        Me.btnRepoDiscardChanges.Size = New System.Drawing.Size(77, 50)
        Me.btnRepoDiscardChanges.TabIndex = 24
        Me.btnRepoDiscardChanges.Text = "Discard Repo Changes"
        Me.btnRepoDiscardChanges.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.SplitContainer2)
        Me.Panel2.Location = New System.Drawing.Point(1023, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(336, 827)
        Me.Panel2.TabIndex = 13
        '
        'gbFlavorsList
        '
        Me.gbFlavorsList.BackColor = System.Drawing.Color.LightGray
        Me.gbFlavorsList.Controls.Add(Me.lbFlavorsList)
        Me.gbFlavorsList.Location = New System.Drawing.Point(415, 3)
        Me.gbFlavorsList.Name = "gbFlavorsList"
        Me.gbFlavorsList.Size = New System.Drawing.Size(200, 355)
        Me.gbFlavorsList.TabIndex = 35
        Me.gbFlavorsList.TabStop = False
        Me.gbFlavorsList.Text = "Flavors List"
        '
        'tblFlavorListHints
        '
        Me.tblFlavorListHints.BackColor = System.Drawing.Color.LightGray
        Me.tblFlavorListHints.ColumnCount = 1
        Me.tblFlavorListHints.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFlavorListHints.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFlavorListHints.Controls.Add(Me.lblFLHints1, 0, 0)
        Me.tblFlavorListHints.Controls.Add(Me.lblFLHints2, 0, 1)
        Me.tblFlavorListHints.Location = New System.Drawing.Point(415, 361)
        Me.tblFlavorListHints.Name = "tblFlavorListHints"
        Me.tblFlavorListHints.RowCount = 2
        Me.tblFlavorListHints.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFlavorListHints.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFlavorListHints.Size = New System.Drawing.Size(200, 49)
        Me.tblFlavorListHints.TabIndex = 36
        '
        'lblFLHints1
        '
        Me.lblFLHints1.AutoSize = True
        Me.lblFLHints1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFLHints1.Location = New System.Drawing.Point(3, 0)
        Me.lblFLHints1.Name = "lblFLHints1"
        Me.lblFLHints1.Size = New System.Drawing.Size(194, 24)
        Me.lblFLHints1.TabIndex = 0
        Me.lblFLHints1.Text = "Right Click Menu to apply multi select"
        Me.lblFLHints1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFLHints2
        '
        Me.lblFLHints2.AutoSize = True
        Me.lblFLHints2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFLHints2.Location = New System.Drawing.Point(3, 24)
        Me.lblFLHints2.Name = "lblFLHints2"
        Me.lblFLHints2.Size = New System.Drawing.Size(194, 25)
        Me.lblFLHints2.TabIndex = 1
        Me.lblFLHints2.Text = "Double Click to apply highlighted"
        Me.lblFLHints2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1371, 854)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Support Tech Assistant"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tcSTA.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.cmsApplySingleFlavor.ResumeLayout(False)
        Me.gbLiveOutput.ResumeLayout(False)
        Me.pnlServicesContainer.ResumeLayout(False)
        Me.pnlServicesContainer.PerformLayout()
        Me.gpPcInfo.ResumeLayout(False)
        Me.tlpPcInfo.ResumeLayout(False)
        Me.tlpPcInfo.PerformLayout()
        Me.gpLicInfo.ResumeLayout(False)
        Me.gpLicInfo.PerformLayout()
        Me.tpAdvData.ResumeLayout(False)
        Me.tpAdvData.PerformLayout()
        CType(Me.dgvApplicationInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWebOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAppOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDbInfo.ResumeLayout(False)
        Me.pnlDbInfoButtons.ResumeLayout(False)
        Me.pnlDbInfoButtons.PerformLayout()
        Me.pnlDbData.ResumeLayout(False)
        CType(Me.dgvDbTableSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDbLogs.ResumeLayout(False)
        Me.tlpLogData.ResumeLayout(False)
        Me.gpDbLogCount.ResumeLayout(False)
        CType(Me.dgvDbLogCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDbLogData.ResumeLayout(False)
        CType(Me.dgvDbLogData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDbLogs.ResumeLayout(False)
        Me.pnlDbLogs.PerformLayout()
        Me.gpMessageLogFilters.ResumeLayout(False)
        Me.gpMessageLogFilters.PerformLayout()
        CType(Me.nudMsgLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStParse.ResumeLayout(False)
        Me.tpStParse.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.tpOptions.ResumeLayout(False)
        Me.gpFlavorsSettings.ResumeLayout(False)
        Me.gbAppLaunchSettings.ResumeLayout(False)
        Me.gbAppLaunchSettings.PerformLayout()
        Me.flpAppListButtons.ResumeLayout(False)
        Me.cmsQuickLaunch.ResumeLayout(False)
        Me.gbAppOptions.ResumeLayout(False)
        Me.gbAppOptions.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gpAdvUpgrade.ResumeLayout(False)
        Me.gpAdvUpgrade.PerformLayout()
        Me.gpCommonApps.ResumeLayout(False)
        Me.gbAdvApps.ResumeLayout(False)
        Me.gbAdvApps.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.tlpButtons3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.gbFlavorsList.ResumeLayout(False)
        Me.tblFlavorListHints.ResumeLayout(False)
        Me.tblFlavorListHints.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents btnCenterEdgeConfig As Button
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
    Friend WithEvents ttSTA2 As ToolTip
    Friend WithEvents gpPcInfo As GroupBox
    Friend WithEvents tlpPcInfo As TableLayoutPanel
    Friend WithEvents lblPcAdvVersion As Label
    Friend WithEvents lblPcNetVersion As Label
    Friend WithEvents tbPcSqlVersion As TextBox
    Friend WithEvents lblPcSqlVersion As Label
    Friend WithEvents lblPcDbSize As Label
    Friend WithEvents tbPcDbSize As TextBox
    Friend WithEvents lblPcArch As Label
    Friend WithEvents tbPcRam As TextBox
    Friend WithEvents lblPcHardDrive As Label
    Friend WithEvents tbPcName As TextBox
    Friend WithEvents lblPcRam As Label
    Friend WithEvents tbPcOsInfo As TextBox
    Friend WithEvents lblPcOsInfo As Label
    Friend WithEvents tbPcHardDrive As TextBox
    Friend WithEvents lblPcName As Label
    Friend WithEvents tbPcArch As TextBox
    Friend WithEvents tbPcNetVersion As TextBox
    Friend WithEvents tbPcAdvVersion As TextBox
    Friend WithEvents ImageList1 As ImageList
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
    Friend WithEvents FolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents gbAdvApps As GroupBox
    Friend WithEvents tbServicesButtonsHelpMessage As TextBox
    Friend WithEvents lblApplicationInfo As Label
    Friend WithEvents dgvApplicationInfo As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents btnSaveApplicationInfoCSV As Button
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents btnSaveWebOptionsCSV As Button
    Friend WithEvents btnSaveAppotionsCSV As Button
    Friend WithEvents tbAdvupgrade As TextBox
    Friend WithEvents lblAdvUpgrade As Label
    Friend WithEvents btnAdvRedeem As Button
    Friend WithEvents btnAdvCardTech As Button
    Friend WithEvents lblAdvApps As Label
    Friend WithEvents btnRefreshGeneralTab As Button
    Friend WithEvents OpenFileDialog As OpenFileDialog
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
    Friend WithEvents tbFlavorApplyCommand As TextBox
    Friend WithEvents lblDatabaseStartCommand As Label
    Friend WithEvents lblFlavorApplyCommand As Label
    Friend WithEvents tbDatabaseStartCommand As TextBox
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
    Friend WithEvents chkShowHiddenServices As CheckBox
    Friend WithEvents pnlServicesContainer As Panel
    Friend WithEvents tblServices As TableLayoutPanel
    Friend WithEvents gpFlavorsSettings As GroupBox
    Friend WithEvents tbMLTest1 As TextBox
    Friend WithEvents flpAppListButtons As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblWindowTitle As Label
    Friend WithEvents lblShowHiddenServices As Label
    Friend WithEvents tlpButtons3 As TableLayoutPanel
    Friend WithEvents cmsApplySingleFlavor As ContextMenuStrip
    Friend WithEvents miApplySingleFlavor As ToolStripMenuItem
    Friend WithEvents lbFlavorsList As ListBox
    Friend WithEvents gbFlavorsList As GroupBox
    Friend WithEvents tblFlavorListHints As TableLayoutPanel
    Friend WithEvents lblFLHints1 As Label
    Friend WithEvents lblFLHints2 As Label
End Class
