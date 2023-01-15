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
        Me.flpServices = New System.Windows.Forms.FlowLayoutPanel()
        Me.gpApiService = New System.Windows.Forms.GroupBox()
        Me.btnApiServiceRS = New System.Windows.Forms.Button()
        Me.tbApiService = New System.Windows.Forms.TextBox()
        Me.btnApiServiceSS = New System.Windows.Forms.Button()
        Me.gpCoreService = New System.Windows.Forms.GroupBox()
        Me.btnCoreServiceRS = New System.Windows.Forms.Button()
        Me.tbCoreService = New System.Windows.Forms.TextBox()
        Me.btnCoreServiceSS = New System.Windows.Forms.Button()
        Me.gpCloudService = New System.Windows.Forms.GroupBox()
        Me.btnCloudServiceRS = New System.Windows.Forms.Button()
        Me.tbCloudService = New System.Windows.Forms.TextBox()
        Me.btnCloudServiceSS = New System.Windows.Forms.Button()
        Me.gpAdvCreditService = New System.Windows.Forms.GroupBox()
        Me.btnAdvCreditServiceRS = New System.Windows.Forms.Button()
        Me.tbAdvCreditService = New System.Windows.Forms.TextBox()
        Me.btnAdvCreditServiceSS = New System.Windows.Forms.Button()
        Me.gpAdvSignageService = New System.Windows.Forms.GroupBox()
        Me.btnAdvSignageServiceRS = New System.Windows.Forms.Button()
        Me.tbAdvSignageService = New System.Windows.Forms.TextBox()
        Me.btnAdvSignageServiceSS = New System.Windows.Forms.Button()
        Me.gpAdvLicService = New System.Windows.Forms.GroupBox()
        Me.btnAdvLicServiceRS = New System.Windows.Forms.Button()
        Me.tbAdvLicService = New System.Windows.Forms.TextBox()
        Me.btnAdvLicServiceSS = New System.Windows.Forms.Button()
        Me.gpAdvNotifyService = New System.Windows.Forms.GroupBox()
        Me.btnAdvNotifyServiceRS = New System.Windows.Forms.Button()
        Me.tbAdvNotifyService = New System.Windows.Forms.TextBox()
        Me.btnAdvNotifyServiceSS = New System.Windows.Forms.Button()
        Me.gpAdvTurnstileEngine = New System.Windows.Forms.GroupBox()
        Me.btnAdvTurnstileEngineRS = New System.Windows.Forms.Button()
        Me.tbAdvTurnstileEngine = New System.Windows.Forms.TextBox()
        Me.btnAdvTurnstileEngineSS = New System.Windows.Forms.Button()
        Me.gpAdvantageUpgradeService = New System.Windows.Forms.GroupBox()
        Me.btnAdvantageUpgradeServiceRS = New System.Windows.Forms.Button()
        Me.tbAdvantageUpgradeService = New System.Windows.Forms.TextBox()
        Me.btnAdvantageUpgradeServiceSS = New System.Windows.Forms.Button()
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
        Me.gpPfsConnect = New System.Windows.Forms.GroupBox()
        Me.dgvPFSConnect = New System.Windows.Forms.DataGridView()
        Me.Setting = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpAdvData = New System.Windows.Forms.TabPage()
        Me.lblWebOptions = New System.Windows.Forms.Label()
        Me.lblAppOptions = New System.Windows.Forms.Label()
        Me.dgvWebOptions = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsEditMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmCopy = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.btnCloudRestart = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
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
        Me.tpPlayerCardDeferredRevenue = New System.Windows.Forms.TabPage()
        Me.gpPcDrCommit = New System.Windows.Forms.GroupBox()
        Me.lblPcDrInstr3 = New System.Windows.Forms.Label()
        Me.lblPcDrInstr2b = New System.Windows.Forms.Label()
        Me.lblPcDrInstr2a = New System.Windows.Forms.Label()
        Me.lblPcDrInstr2 = New System.Windows.Forms.Label()
        Me.lblPcDrInstr1 = New System.Windows.Forms.Label()
        Me.btnPcDrCommit = New System.Windows.Forms.Button()
        Me.tbMLDRTest = New System.Windows.Forms.TextBox()
        Me.gpOutstandingPCDR = New System.Windows.Forms.GroupBox()
        Me.lblOutstandingPCDR = New System.Windows.Forms.Label()
        Me.tbOutstandingPCDR = New System.Windows.Forms.TextBox()
        Me.gpInvItem = New System.Windows.Forms.GroupBox()
        Me.lblDRInvNo = New System.Windows.Forms.Label()
        Me.nudDRInvNo = New System.Windows.Forms.NumericUpDown()
        Me.dgvInvItem = New System.Windows.Forms.DataGridView()
        Me.InvItemData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvItemValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDRInvNo = New System.Windows.Forms.Button()
        Me.tpNetwork = New System.Windows.Forms.TabPage()
        Me.tbPortScan = New System.Windows.Forms.TextBox()
        Me.gpCloudComm = New System.Windows.Forms.GroupBox()
        Me.btnRelayRefresh = New System.Windows.Forms.Button()
        Me.tbStageRelayConn = New System.Windows.Forms.TextBox()
        Me.lblStageRelayConn = New System.Windows.Forms.Label()
        Me.btnPortCheck = New System.Windows.Forms.Button()
        Me.dgvPorts = New System.Windows.Forms.DataGridView()
        Me.PortNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AppName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PortStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpOptions = New System.Windows.Forms.TabPage()
        Me.gpAdvUpgrade = New System.Windows.Forms.GroupBox()
        Me.cbAdvUpgradeNoBackup = New System.Windows.Forms.CheckBox()
        Me.cbAdvUpgradeNoSetup = New System.Windows.Forms.CheckBox()
        Me.cbAdvUpgradeQuiet = New System.Windows.Forms.CheckBox()
        Me.tpEODB = New System.Windows.Forms.TabPage()
        Me.dtpTest = New System.Windows.Forms.DateTimePicker()
        Me.tbEodbProgress = New System.Windows.Forms.TextBox()
        Me.btnXmltoWorkbook = New System.Windows.Forms.Button()
        Me.btnSaveToXml = New System.Windows.Forms.Button()
        Me.dtpEODB = New System.Windows.Forms.DateTimePicker()
        Me.btnEODBFolder = New System.Windows.Forms.Button()
        Me.btnEODBSave = New System.Windows.Forms.Button()
        Me.lblEODBFolder = New System.Windows.Forms.Label()
        Me.tbEODBFolder = New System.Windows.Forms.TextBox()
        Me.btnAdvUpgrade = New System.Windows.Forms.Button()
        Me.btnAdvReportEditor = New System.Windows.Forms.Button()
        Me.tbMLTest1 = New System.Windows.Forms.TextBox()
        Me.btnAdvGroups = New System.Windows.Forms.Button()
        Me.btnPos = New System.Windows.Forms.Button()
        Me.btnAdvManager = New System.Windows.Forms.Button()
        Me.tbTest3 = New System.Windows.Forms.TextBox()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.tbTest2 = New System.Windows.Forms.TextBox()
        Me.btnCenterEdgeConfig = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTest1 = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslblCeVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblNetVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmr10Seconds = New System.Windows.Forms.Timer(Me.components)
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.tmr1Sec = New System.Windows.Forms.Timer(Me.components)
        Me.ttSTA2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fbdEODB = New System.Windows.Forms.FolderBrowserDialog()
        Me.gnAdvApps = New System.Windows.Forms.GroupBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tcSTA.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.gpPcInfo.SuspendLayout()
        Me.tlpPcInfo.SuspendLayout()
        Me.flpServices.SuspendLayout()
        Me.gpApiService.SuspendLayout()
        Me.gpCoreService.SuspendLayout()
        Me.gpCloudService.SuspendLayout()
        Me.gpAdvCreditService.SuspendLayout()
        Me.gpAdvSignageService.SuspendLayout()
        Me.gpAdvLicService.SuspendLayout()
        Me.gpAdvNotifyService.SuspendLayout()
        Me.gpAdvTurnstileEngine.SuspendLayout()
        Me.gpAdvantageUpgradeService.SuspendLayout()
        Me.gpLicInfo.SuspendLayout()
        Me.gpPfsConnect.SuspendLayout()
        CType(Me.dgvPFSConnect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAdvData.SuspendLayout()
        CType(Me.dgvWebOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsEditMenu.SuspendLayout()
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
        Me.tpPlayerCardDeferredRevenue.SuspendLayout()
        Me.gpPcDrCommit.SuspendLayout()
        Me.gpOutstandingPCDR.SuspendLayout()
        Me.gpInvItem.SuspendLayout()
        CType(Me.nudDRInvNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNetwork.SuspendLayout()
        Me.gpCloudComm.SuspendLayout()
        CType(Me.dgvPorts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpOptions.SuspendLayout()
        Me.gpAdvUpgrade.SuspendLayout()
        Me.tpEODB.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.gnAdvApps.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(990, 101)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 20)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.gnAdvApps)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnAdvUpgrade)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbMLTest1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbTest3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnTest)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbTest2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCenterEdgeConfig)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbTest1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnLogin)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnExit)
        Me.SplitContainer1.Size = New System.Drawing.Size(1068, 710)
        Me.SplitContainer1.SplitterDistance = 540
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
        Me.tcSTA.Controls.Add(Me.tpPlayerCardDeferredRevenue)
        Me.tcSTA.Controls.Add(Me.tpNetwork)
        Me.tcSTA.Controls.Add(Me.tpOptions)
        Me.tcSTA.Controls.Add(Me.tpEODB)
        Me.tcSTA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcSTA.Location = New System.Drawing.Point(0, 0)
        Me.tcSTA.Name = "tcSTA"
        Me.tcSTA.SelectedIndex = 0
        Me.tcSTA.Size = New System.Drawing.Size(1064, 536)
        Me.tcSTA.TabIndex = 11
        '
        'tpGeneral
        '
        Me.tpGeneral.BackColor = System.Drawing.Color.Gray
        Me.tpGeneral.Controls.Add(Me.gpPcInfo)
        Me.tpGeneral.Controls.Add(Me.flpServices)
        Me.tpGeneral.Controls.Add(Me.gpLicInfo)
        Me.tpGeneral.Controls.Add(Me.gpPfsConnect)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(1056, 510)
        Me.tpGeneral.TabIndex = 0
        Me.tpGeneral.Text = "General"
        '
        'gpPcInfo
        '
        Me.gpPcInfo.BackColor = System.Drawing.Color.LightGray
        Me.gpPcInfo.Controls.Add(Me.tlpPcInfo)
        Me.gpPcInfo.Location = New System.Drawing.Point(3, 163)
        Me.gpPcInfo.Name = "gpPcInfo"
        Me.gpPcInfo.Size = New System.Drawing.Size(406, 254)
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
        'flpServices
        '
        Me.flpServices.Controls.Add(Me.gpApiService)
        Me.flpServices.Controls.Add(Me.gpCoreService)
        Me.flpServices.Controls.Add(Me.gpCloudService)
        Me.flpServices.Controls.Add(Me.gpAdvCreditService)
        Me.flpServices.Controls.Add(Me.gpAdvSignageService)
        Me.flpServices.Controls.Add(Me.gpAdvLicService)
        Me.flpServices.Controls.Add(Me.gpAdvNotifyService)
        Me.flpServices.Controls.Add(Me.gpAdvTurnstileEngine)
        Me.flpServices.Controls.Add(Me.gpAdvantageUpgradeService)
        Me.flpServices.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpServices.Location = New System.Drawing.Point(415, 6)
        Me.flpServices.Name = "flpServices"
        Me.flpServices.Size = New System.Drawing.Size(377, 508)
        Me.flpServices.TabIndex = 12
        '
        'gpApiService
        '
        Me.gpApiService.BackColor = System.Drawing.Color.LightGray
        Me.gpApiService.Controls.Add(Me.btnApiServiceRS)
        Me.gpApiService.Controls.Add(Me.tbApiService)
        Me.gpApiService.Controls.Add(Me.btnApiServiceSS)
        Me.gpApiService.Location = New System.Drawing.Point(3, 3)
        Me.gpApiService.Name = "gpApiService"
        Me.gpApiService.Size = New System.Drawing.Size(362, 49)
        Me.gpApiService.TabIndex = 15
        Me.gpApiService.TabStop = False
        Me.gpApiService.Tag = ""
        Me.gpApiService.Text = "Api Service"
        '
        'btnApiServiceRS
        '
        Me.btnApiServiceRS.Location = New System.Drawing.Point(278, 16)
        Me.btnApiServiceRS.Name = "btnApiServiceRS"
        Me.btnApiServiceRS.Size = New System.Drawing.Size(75, 23)
        Me.btnApiServiceRS.TabIndex = 15
        Me.btnApiServiceRS.Tag = "Api Service"
        Me.btnApiServiceRS.Text = "Restart"
        Me.ttSTA2.SetToolTip(Me.btnApiServiceRS, "Restart the Advantage API Service")
        Me.btnApiServiceRS.UseVisualStyleBackColor = True
        '
        'tbApiService
        '
        Me.tbApiService.Location = New System.Drawing.Point(6, 19)
        Me.tbApiService.Name = "tbApiService"
        Me.tbApiService.ReadOnly = True
        Me.tbApiService.Size = New System.Drawing.Size(185, 20)
        Me.tbApiService.TabIndex = 13
        Me.tbApiService.Tag = "Api Service"
        '
        'btnApiServiceSS
        '
        Me.btnApiServiceSS.Location = New System.Drawing.Point(197, 16)
        Me.btnApiServiceSS.Name = "btnApiServiceSS"
        Me.btnApiServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnApiServiceSS.TabIndex = 14
        Me.btnApiServiceSS.Tag = "Api Service"
        Me.btnApiServiceSS.Text = "Start"
        Me.ttSTA2.SetToolTip(Me.btnApiServiceSS, "Start/Stop  the Advantage API Service" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.btnApiServiceSS.UseVisualStyleBackColor = True
        '
        'gpCoreService
        '
        Me.gpCoreService.BackColor = System.Drawing.Color.LightGray
        Me.gpCoreService.Controls.Add(Me.btnCoreServiceRS)
        Me.gpCoreService.Controls.Add(Me.tbCoreService)
        Me.gpCoreService.Controls.Add(Me.btnCoreServiceSS)
        Me.gpCoreService.Location = New System.Drawing.Point(3, 58)
        Me.gpCoreService.Name = "gpCoreService"
        Me.gpCoreService.Size = New System.Drawing.Size(362, 49)
        Me.gpCoreService.TabIndex = 13
        Me.gpCoreService.TabStop = False
        Me.gpCoreService.Tag = ""
        Me.gpCoreService.Text = "Core Service"
        '
        'btnCoreServiceRS
        '
        Me.btnCoreServiceRS.Location = New System.Drawing.Point(278, 16)
        Me.btnCoreServiceRS.Name = "btnCoreServiceRS"
        Me.btnCoreServiceRS.Size = New System.Drawing.Size(75, 23)
        Me.btnCoreServiceRS.TabIndex = 15
        Me.btnCoreServiceRS.Tag = "Core Service"
        Me.btnCoreServiceRS.Text = "Restart"
        Me.ttSTA2.SetToolTip(Me.btnCoreServiceRS, "Restart the Advantage Core Service")
        Me.btnCoreServiceRS.UseVisualStyleBackColor = True
        '
        'tbCoreService
        '
        Me.tbCoreService.Location = New System.Drawing.Point(6, 19)
        Me.tbCoreService.Name = "tbCoreService"
        Me.tbCoreService.ReadOnly = True
        Me.tbCoreService.Size = New System.Drawing.Size(185, 20)
        Me.tbCoreService.TabIndex = 13
        Me.tbCoreService.Tag = "Core Service"
        '
        'btnCoreServiceSS
        '
        Me.btnCoreServiceSS.Location = New System.Drawing.Point(197, 16)
        Me.btnCoreServiceSS.Name = "btnCoreServiceSS"
        Me.btnCoreServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnCoreServiceSS.TabIndex = 14
        Me.btnCoreServiceSS.Tag = "Core Service"
        Me.btnCoreServiceSS.Text = "Start"
        Me.ttSTA2.SetToolTip(Me.btnCoreServiceSS, "Start/Stop the Advantage Core Service")
        Me.btnCoreServiceSS.UseVisualStyleBackColor = True
        '
        'gpCloudService
        '
        Me.gpCloudService.BackColor = System.Drawing.Color.LightGray
        Me.gpCloudService.Controls.Add(Me.btnCloudServiceRS)
        Me.gpCloudService.Controls.Add(Me.tbCloudService)
        Me.gpCloudService.Controls.Add(Me.btnCloudServiceSS)
        Me.gpCloudService.Location = New System.Drawing.Point(3, 113)
        Me.gpCloudService.Name = "gpCloudService"
        Me.gpCloudService.Size = New System.Drawing.Size(362, 49)
        Me.gpCloudService.TabIndex = 14
        Me.gpCloudService.TabStop = False
        Me.gpCloudService.Tag = ""
        Me.gpCloudService.Text = "Cloud Service"
        '
        'btnCloudServiceRS
        '
        Me.btnCloudServiceRS.Location = New System.Drawing.Point(278, 14)
        Me.btnCloudServiceRS.Name = "btnCloudServiceRS"
        Me.btnCloudServiceRS.Size = New System.Drawing.Size(75, 23)
        Me.btnCloudServiceRS.TabIndex = 18
        Me.btnCloudServiceRS.Tag = "Cloud Service"
        Me.btnCloudServiceRS.Text = "Restart"
        Me.ttSTA2.SetToolTip(Me.btnCloudServiceRS, "Restart the Advantage Cloud Service")
        Me.btnCloudServiceRS.UseVisualStyleBackColor = True
        '
        'tbCloudService
        '
        Me.tbCloudService.Location = New System.Drawing.Point(6, 17)
        Me.tbCloudService.Name = "tbCloudService"
        Me.tbCloudService.ReadOnly = True
        Me.tbCloudService.Size = New System.Drawing.Size(185, 20)
        Me.tbCloudService.TabIndex = 16
        Me.tbCloudService.Tag = "Cloud Service"
        '
        'btnCloudServiceSS
        '
        Me.btnCloudServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnCloudServiceSS.Name = "btnCloudServiceSS"
        Me.btnCloudServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnCloudServiceSS.TabIndex = 17
        Me.btnCloudServiceSS.Tag = "Cloud Service"
        Me.btnCloudServiceSS.Text = "Start"
        Me.ttSTA2.SetToolTip(Me.btnCloudServiceSS, "Start/Stop the Advantage Cloud Service")
        Me.btnCloudServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvCreditService
        '
        Me.gpAdvCreditService.BackColor = System.Drawing.Color.LightGray
        Me.gpAdvCreditService.Controls.Add(Me.btnAdvCreditServiceRS)
        Me.gpAdvCreditService.Controls.Add(Me.tbAdvCreditService)
        Me.gpAdvCreditService.Controls.Add(Me.btnAdvCreditServiceSS)
        Me.gpAdvCreditService.Location = New System.Drawing.Point(3, 168)
        Me.gpAdvCreditService.Name = "gpAdvCreditService"
        Me.gpAdvCreditService.Size = New System.Drawing.Size(362, 49)
        Me.gpAdvCreditService.TabIndex = 16
        Me.gpAdvCreditService.TabStop = False
        Me.gpAdvCreditService.Tag = ""
        Me.gpAdvCreditService.Text = "Credit Service"
        '
        'btnAdvCreditServiceRS
        '
        Me.btnAdvCreditServiceRS.Location = New System.Drawing.Point(278, 14)
        Me.btnAdvCreditServiceRS.Name = "btnAdvCreditServiceRS"
        Me.btnAdvCreditServiceRS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvCreditServiceRS.TabIndex = 18
        Me.btnAdvCreditServiceRS.Tag = "Credit Service"
        Me.btnAdvCreditServiceRS.Text = "Restart"
        Me.ttSTA2.SetToolTip(Me.btnAdvCreditServiceRS, "Restart the Advantage Credit Service")
        Me.btnAdvCreditServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvCreditService
        '
        Me.tbAdvCreditService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvCreditService.Name = "tbAdvCreditService"
        Me.tbAdvCreditService.ReadOnly = True
        Me.tbAdvCreditService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvCreditService.TabIndex = 16
        Me.tbAdvCreditService.Tag = "Credit Service"
        '
        'btnAdvCreditServiceSS
        '
        Me.btnAdvCreditServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvCreditServiceSS.Name = "btnAdvCreditServiceSS"
        Me.btnAdvCreditServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvCreditServiceSS.TabIndex = 17
        Me.btnAdvCreditServiceSS.Tag = "Credit Service"
        Me.btnAdvCreditServiceSS.Text = "Start"
        Me.ttSTA2.SetToolTip(Me.btnAdvCreditServiceSS, "Start/Stop the Advantage Credit Service")
        Me.btnAdvCreditServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvSignageService
        '
        Me.gpAdvSignageService.BackColor = System.Drawing.Color.LightGray
        Me.gpAdvSignageService.Controls.Add(Me.btnAdvSignageServiceRS)
        Me.gpAdvSignageService.Controls.Add(Me.tbAdvSignageService)
        Me.gpAdvSignageService.Controls.Add(Me.btnAdvSignageServiceSS)
        Me.gpAdvSignageService.Location = New System.Drawing.Point(3, 223)
        Me.gpAdvSignageService.Name = "gpAdvSignageService"
        Me.gpAdvSignageService.Size = New System.Drawing.Size(362, 49)
        Me.gpAdvSignageService.TabIndex = 17
        Me.gpAdvSignageService.TabStop = False
        Me.gpAdvSignageService.Tag = ""
        Me.gpAdvSignageService.Text = "Signage Service"
        '
        'btnAdvSignageServiceRS
        '
        Me.btnAdvSignageServiceRS.Location = New System.Drawing.Point(278, 14)
        Me.btnAdvSignageServiceRS.Name = "btnAdvSignageServiceRS"
        Me.btnAdvSignageServiceRS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvSignageServiceRS.TabIndex = 18
        Me.btnAdvSignageServiceRS.Tag = "Signage Service"
        Me.btnAdvSignageServiceRS.Text = "Restart"
        Me.ttSTA2.SetToolTip(Me.btnAdvSignageServiceRS, "Restart the Advantage Signage Service")
        Me.btnAdvSignageServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvSignageService
        '
        Me.tbAdvSignageService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvSignageService.Name = "tbAdvSignageService"
        Me.tbAdvSignageService.ReadOnly = True
        Me.tbAdvSignageService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvSignageService.TabIndex = 16
        Me.tbAdvSignageService.Tag = "Signage Service"
        '
        'btnAdvSignageServiceSS
        '
        Me.btnAdvSignageServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvSignageServiceSS.Name = "btnAdvSignageServiceSS"
        Me.btnAdvSignageServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvSignageServiceSS.TabIndex = 17
        Me.btnAdvSignageServiceSS.Tag = "Signage Service"
        Me.btnAdvSignageServiceSS.Text = "Start"
        Me.ttSTA2.SetToolTip(Me.btnAdvSignageServiceSS, "Start/Stop the Advantage Signage Service")
        Me.btnAdvSignageServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvLicService
        '
        Me.gpAdvLicService.BackColor = System.Drawing.Color.LightGray
        Me.gpAdvLicService.Controls.Add(Me.btnAdvLicServiceRS)
        Me.gpAdvLicService.Controls.Add(Me.tbAdvLicService)
        Me.gpAdvLicService.Controls.Add(Me.btnAdvLicServiceSS)
        Me.gpAdvLicService.Location = New System.Drawing.Point(3, 278)
        Me.gpAdvLicService.Name = "gpAdvLicService"
        Me.gpAdvLicService.Size = New System.Drawing.Size(362, 49)
        Me.gpAdvLicService.TabIndex = 19
        Me.gpAdvLicService.TabStop = False
        Me.gpAdvLicService.Tag = ""
        Me.gpAdvLicService.Text = "License Service"
        '
        'btnAdvLicServiceRS
        '
        Me.btnAdvLicServiceRS.Location = New System.Drawing.Point(278, 14)
        Me.btnAdvLicServiceRS.Name = "btnAdvLicServiceRS"
        Me.btnAdvLicServiceRS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvLicServiceRS.TabIndex = 18
        Me.btnAdvLicServiceRS.Tag = "License Service"
        Me.btnAdvLicServiceRS.Text = "Restart"
        Me.ttSTA2.SetToolTip(Me.btnAdvLicServiceRS, "Restart the Advantage License Service")
        Me.btnAdvLicServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvLicService
        '
        Me.tbAdvLicService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvLicService.Name = "tbAdvLicService"
        Me.tbAdvLicService.ReadOnly = True
        Me.tbAdvLicService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvLicService.TabIndex = 16
        Me.tbAdvLicService.Tag = "License Service"
        '
        'btnAdvLicServiceSS
        '
        Me.btnAdvLicServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvLicServiceSS.Name = "btnAdvLicServiceSS"
        Me.btnAdvLicServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvLicServiceSS.TabIndex = 17
        Me.btnAdvLicServiceSS.Tag = "License Service"
        Me.btnAdvLicServiceSS.Text = "Start"
        Me.ttSTA2.SetToolTip(Me.btnAdvLicServiceSS, "Start/Stop the Advantage License Service")
        Me.btnAdvLicServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvNotifyService
        '
        Me.gpAdvNotifyService.BackColor = System.Drawing.Color.LightGray
        Me.gpAdvNotifyService.Controls.Add(Me.btnAdvNotifyServiceRS)
        Me.gpAdvNotifyService.Controls.Add(Me.tbAdvNotifyService)
        Me.gpAdvNotifyService.Controls.Add(Me.btnAdvNotifyServiceSS)
        Me.gpAdvNotifyService.Location = New System.Drawing.Point(3, 333)
        Me.gpAdvNotifyService.Name = "gpAdvNotifyService"
        Me.gpAdvNotifyService.Size = New System.Drawing.Size(362, 49)
        Me.gpAdvNotifyService.TabIndex = 21
        Me.gpAdvNotifyService.TabStop = False
        Me.gpAdvNotifyService.Tag = ""
        Me.gpAdvNotifyService.Text = "Notification Service"
        '
        'btnAdvNotifyServiceRS
        '
        Me.btnAdvNotifyServiceRS.Location = New System.Drawing.Point(278, 14)
        Me.btnAdvNotifyServiceRS.Name = "btnAdvNotifyServiceRS"
        Me.btnAdvNotifyServiceRS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvNotifyServiceRS.TabIndex = 18
        Me.btnAdvNotifyServiceRS.Tag = "Notification Service"
        Me.btnAdvNotifyServiceRS.Text = "Restart"
        Me.ttSTA2.SetToolTip(Me.btnAdvNotifyServiceRS, "Restart the Advantage Notification Service")
        Me.btnAdvNotifyServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvNotifyService
        '
        Me.tbAdvNotifyService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvNotifyService.Name = "tbAdvNotifyService"
        Me.tbAdvNotifyService.ReadOnly = True
        Me.tbAdvNotifyService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvNotifyService.TabIndex = 16
        Me.tbAdvNotifyService.Tag = "Notification Service"
        '
        'btnAdvNotifyServiceSS
        '
        Me.btnAdvNotifyServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvNotifyServiceSS.Name = "btnAdvNotifyServiceSS"
        Me.btnAdvNotifyServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvNotifyServiceSS.TabIndex = 17
        Me.btnAdvNotifyServiceSS.Tag = "Notification Service"
        Me.btnAdvNotifyServiceSS.Text = "Start"
        Me.ttSTA2.SetToolTip(Me.btnAdvNotifyServiceSS, "Start/Stop the Advantage Notification Service")
        Me.btnAdvNotifyServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvTurnstileEngine
        '
        Me.gpAdvTurnstileEngine.BackColor = System.Drawing.Color.LightGray
        Me.gpAdvTurnstileEngine.Controls.Add(Me.btnAdvTurnstileEngineRS)
        Me.gpAdvTurnstileEngine.Controls.Add(Me.tbAdvTurnstileEngine)
        Me.gpAdvTurnstileEngine.Controls.Add(Me.btnAdvTurnstileEngineSS)
        Me.gpAdvTurnstileEngine.Location = New System.Drawing.Point(3, 388)
        Me.gpAdvTurnstileEngine.Name = "gpAdvTurnstileEngine"
        Me.gpAdvTurnstileEngine.Size = New System.Drawing.Size(362, 49)
        Me.gpAdvTurnstileEngine.TabIndex = 20
        Me.gpAdvTurnstileEngine.TabStop = False
        Me.gpAdvTurnstileEngine.Tag = ""
        Me.gpAdvTurnstileEngine.Text = "Turnstile Service"
        '
        'btnAdvTurnstileEngineRS
        '
        Me.btnAdvTurnstileEngineRS.Location = New System.Drawing.Point(278, 14)
        Me.btnAdvTurnstileEngineRS.Name = "btnAdvTurnstileEngineRS"
        Me.btnAdvTurnstileEngineRS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvTurnstileEngineRS.TabIndex = 18
        Me.btnAdvTurnstileEngineRS.Tag = "Turnstile Service"
        Me.btnAdvTurnstileEngineRS.Text = "Restart"
        Me.ttSTA2.SetToolTip(Me.btnAdvTurnstileEngineRS, "Restart the Advantage Turnstile Service")
        Me.btnAdvTurnstileEngineRS.UseVisualStyleBackColor = True
        '
        'tbAdvTurnstileEngine
        '
        Me.tbAdvTurnstileEngine.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvTurnstileEngine.Name = "tbAdvTurnstileEngine"
        Me.tbAdvTurnstileEngine.ReadOnly = True
        Me.tbAdvTurnstileEngine.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvTurnstileEngine.TabIndex = 16
        Me.tbAdvTurnstileEngine.Tag = "Turnstile Service"
        '
        'btnAdvTurnstileEngineSS
        '
        Me.btnAdvTurnstileEngineSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvTurnstileEngineSS.Name = "btnAdvTurnstileEngineSS"
        Me.btnAdvTurnstileEngineSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvTurnstileEngineSS.TabIndex = 17
        Me.btnAdvTurnstileEngineSS.Tag = "Turnstile Service"
        Me.btnAdvTurnstileEngineSS.Text = "Start"
        Me.ttSTA2.SetToolTip(Me.btnAdvTurnstileEngineSS, "Start/Stop the Advantage Turnstile Service")
        Me.btnAdvTurnstileEngineSS.UseVisualStyleBackColor = True
        '
        'gpAdvantageUpgradeService
        '
        Me.gpAdvantageUpgradeService.BackColor = System.Drawing.Color.LightGray
        Me.gpAdvantageUpgradeService.Controls.Add(Me.btnAdvantageUpgradeServiceRS)
        Me.gpAdvantageUpgradeService.Controls.Add(Me.tbAdvantageUpgradeService)
        Me.gpAdvantageUpgradeService.Controls.Add(Me.btnAdvantageUpgradeServiceSS)
        Me.gpAdvantageUpgradeService.Location = New System.Drawing.Point(3, 443)
        Me.gpAdvantageUpgradeService.Name = "gpAdvantageUpgradeService"
        Me.gpAdvantageUpgradeService.Size = New System.Drawing.Size(362, 49)
        Me.gpAdvantageUpgradeService.TabIndex = 21
        Me.gpAdvantageUpgradeService.TabStop = False
        Me.gpAdvantageUpgradeService.Tag = ""
        Me.gpAdvantageUpgradeService.Text = "Upgrade Service"
        '
        'btnAdvantageUpgradeServiceRS
        '
        Me.btnAdvantageUpgradeServiceRS.Location = New System.Drawing.Point(278, 14)
        Me.btnAdvantageUpgradeServiceRS.Name = "btnAdvantageUpgradeServiceRS"
        Me.btnAdvantageUpgradeServiceRS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvantageUpgradeServiceRS.TabIndex = 18
        Me.btnAdvantageUpgradeServiceRS.Tag = "Upgrade Service"
        Me.btnAdvantageUpgradeServiceRS.Text = "Restart"
        Me.ttSTA2.SetToolTip(Me.btnAdvantageUpgradeServiceRS, "Restart the Advantage Upgrade Service")
        Me.btnAdvantageUpgradeServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvantageUpgradeService
        '
        Me.tbAdvantageUpgradeService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvantageUpgradeService.Name = "tbAdvantageUpgradeService"
        Me.tbAdvantageUpgradeService.ReadOnly = True
        Me.tbAdvantageUpgradeService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvantageUpgradeService.TabIndex = 16
        Me.tbAdvantageUpgradeService.Tag = "Upgrade Service"
        '
        'btnAdvantageUpgradeServiceSS
        '
        Me.btnAdvantageUpgradeServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvantageUpgradeServiceSS.Name = "btnAdvantageUpgradeServiceSS"
        Me.btnAdvantageUpgradeServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvantageUpgradeServiceSS.TabIndex = 17
        Me.btnAdvantageUpgradeServiceSS.Tag = "Upgrade Service"
        Me.btnAdvantageUpgradeServiceSS.Text = "Start"
        Me.ttSTA2.SetToolTip(Me.btnAdvantageUpgradeServiceSS, "Start/Stop the Advantage Upgrade Service")
        Me.btnAdvantageUpgradeServiceSS.UseVisualStyleBackColor = True
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
        Me.gpLicInfo.Size = New System.Drawing.Size(406, 155)
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
        'gpPfsConnect
        '
        Me.gpPfsConnect.BackColor = System.Drawing.Color.LightGray
        Me.gpPfsConnect.Controls.Add(Me.dgvPFSConnect)
        Me.gpPfsConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPfsConnect.Location = New System.Drawing.Point(796, 3)
        Me.gpPfsConnect.Name = "gpPfsConnect"
        Me.gpPfsConnect.Size = New System.Drawing.Size(260, 135)
        Me.gpPfsConnect.TabIndex = 11
        Me.gpPfsConnect.TabStop = False
        Me.gpPfsConnect.Text = "PFSConnect.ini data"
        '
        'dgvPFSConnect
        '
        Me.dgvPFSConnect.AllowUserToAddRows = False
        Me.dgvPFSConnect.AllowUserToDeleteRows = False
        Me.dgvPFSConnect.AllowUserToResizeColumns = False
        Me.dgvPFSConnect.AllowUserToResizeRows = False
        Me.dgvPFSConnect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPFSConnect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPFSConnect.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvPFSConnect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPFSConnect.ColumnHeadersVisible = False
        Me.dgvPFSConnect.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Setting, Me.Value})
        Me.dgvPFSConnect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPFSConnect.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPFSConnect.Location = New System.Drawing.Point(3, 16)
        Me.dgvPFSConnect.MultiSelect = False
        Me.dgvPFSConnect.Name = "dgvPFSConnect"
        Me.dgvPFSConnect.ReadOnly = True
        Me.dgvPFSConnect.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPFSConnect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPFSConnect.ShowCellErrors = False
        Me.dgvPFSConnect.ShowEditingIcon = False
        Me.dgvPFSConnect.ShowRowErrors = False
        Me.dgvPFSConnect.Size = New System.Drawing.Size(254, 116)
        Me.dgvPFSConnect.TabIndex = 9
        '
        'Setting
        '
        Me.Setting.HeaderText = "Setting"
        Me.Setting.Name = "Setting"
        Me.Setting.ReadOnly = True
        Me.Setting.Width = 5
        '
        'Value
        '
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        Me.Value.ReadOnly = True
        Me.Value.Width = 5
        '
        'tpAdvData
        '
        Me.tpAdvData.Controls.Add(Me.lblWebOptions)
        Me.tpAdvData.Controls.Add(Me.lblAppOptions)
        Me.tpAdvData.Controls.Add(Me.dgvWebOptions)
        Me.tpAdvData.Controls.Add(Me.dgvAppOptions)
        Me.tpAdvData.Location = New System.Drawing.Point(4, 22)
        Me.tpAdvData.Name = "tpAdvData"
        Me.tpAdvData.Size = New System.Drawing.Size(1056, 510)
        Me.tpAdvData.TabIndex = 4
        Me.tpAdvData.Text = "Advantage Data"
        Me.tpAdvData.ToolTipText = "Information from the Database Tables"
        Me.tpAdvData.UseVisualStyleBackColor = True
        '
        'lblWebOptions
        '
        Me.lblWebOptions.AutoSize = True
        Me.lblWebOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebOptions.Location = New System.Drawing.Point(529, 10)
        Me.lblWebOptions.Name = "lblWebOptions"
        Me.lblWebOptions.Size = New System.Drawing.Size(83, 16)
        Me.lblWebOptions.TabIndex = 3
        Me.lblWebOptions.Text = "WebOptions"
        '
        'lblAppOptions
        '
        Me.lblAppOptions.AutoSize = True
        Me.lblAppOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppOptions.Location = New System.Drawing.Point(6, 10)
        Me.lblAppOptions.Name = "lblAppOptions"
        Me.lblAppOptions.Size = New System.Drawing.Size(79, 16)
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
        Me.dgvWebOptions.ContextMenuStrip = Me.cmsEditMenu
        Me.dgvWebOptions.Location = New System.Drawing.Point(532, 29)
        Me.dgvWebOptions.Name = "dgvWebOptions"
        Me.dgvWebOptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvWebOptions.ShowEditingIcon = False
        Me.dgvWebOptions.Size = New System.Drawing.Size(514, 479)
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
        'cmsEditMenu
        '
        Me.cmsEditMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCopy})
        Me.cmsEditMenu.Name = "cmsEditMenu"
        Me.cmsEditMenu.ShowImageMargin = False
        Me.cmsEditMenu.Size = New System.Drawing.Size(120, 26)
        '
        'tsmCopy
        '
        Me.tsmCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsmCopy.Name = "tsmCopy"
        Me.tsmCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.tsmCopy.Size = New System.Drawing.Size(119, 22)
        Me.tsmCopy.Text = "&Copy"
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
        Me.dgvAppOptions.ContextMenuStrip = Me.cmsEditMenu
        Me.dgvAppOptions.Location = New System.Drawing.Point(9, 29)
        Me.dgvAppOptions.Name = "dgvAppOptions"
        Me.dgvAppOptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAppOptions.ShowEditingIcon = False
        Me.dgvAppOptions.Size = New System.Drawing.Size(514, 479)
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
        Me.tpDbInfo.Size = New System.Drawing.Size(1056, 510)
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
        Me.pnlDbInfoButtons.Location = New System.Drawing.Point(3, 479)
        Me.pnlDbInfoButtons.Name = "pnlDbInfoButtons"
        Me.pnlDbInfoButtons.Size = New System.Drawing.Size(1050, 28)
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
        Me.btnDbInfoRefresh.Location = New System.Drawing.Point(969, 2)
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
        Me.pnlDbData.Size = New System.Drawing.Size(1053, 454)
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
        Me.dgvDbTableSize.Size = New System.Drawing.Size(1053, 454)
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
        Me.tpDbLogs.Size = New System.Drawing.Size(1056, 510)
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
        Me.tlpLogData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 371.0!))
        Me.tlpLogData.Size = New System.Drawing.Size(1039, 353)
        Me.tlpLogData.TabIndex = 5
        '
        'gpDbLogCount
        '
        Me.gpDbLogCount.BackColor = System.Drawing.Color.LightGray
        Me.gpDbLogCount.Controls.Add(Me.dgvDbLogCount)
        Me.gpDbLogCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpDbLogCount.Location = New System.Drawing.Point(3, 3)
        Me.gpDbLogCount.Name = "gpDbLogCount"
        Me.gpDbLogCount.Size = New System.Drawing.Size(245, 365)
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
        Me.dgvDbLogCount.Size = New System.Drawing.Size(239, 346)
        Me.dgvDbLogCount.TabIndex = 1
        '
        'gpDbLogData
        '
        Me.gpDbLogData.BackColor = System.Drawing.Color.LightGray
        Me.gpDbLogData.Controls.Add(Me.dgvDbLogData)
        Me.gpDbLogData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpDbLogData.Location = New System.Drawing.Point(254, 3)
        Me.gpDbLogData.Name = "gpDbLogData"
        Me.gpDbLogData.Size = New System.Drawing.Size(782, 365)
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
        Me.dgvDbLogData.Size = New System.Drawing.Size(776, 346)
        Me.dgvDbLogData.TabIndex = 2
        '
        'pnlDbLogs
        '
        Me.pnlDbLogs.BackColor = System.Drawing.Color.LightGray
        Me.pnlDbLogs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDbLogs.Controls.Add(Me.btnCloudRestart)
        Me.pnlDbLogs.Controls.Add(Me.gpMessageLogFilters)
        Me.pnlDbLogs.Controls.Add(Me.btnDbLogRefresh)
        Me.pnlDbLogs.Controls.Add(Me.rbMessageLog)
        Me.pnlDbLogs.Controls.Add(Me.rbWebCloudUpdates)
        Me.pnlDbLogs.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDbLogs.Location = New System.Drawing.Point(3, 380)
        Me.pnlDbLogs.Name = "pnlDbLogs"
        Me.pnlDbLogs.Size = New System.Drawing.Size(1050, 127)
        Me.pnlDbLogs.TabIndex = 0
        '
        'btnCloudRestart
        '
        Me.btnCloudRestart.ImageIndex = 0
        Me.btnCloudRestart.ImageList = Me.ImageList1
        Me.btnCloudRestart.Location = New System.Drawing.Point(788, 44)
        Me.btnCloudRestart.Name = "btnCloudRestart"
        Me.btnCloudRestart.Size = New System.Drawing.Size(56, 58)
        Me.btnCloudRestart.TabIndex = 5
        Me.btnCloudRestart.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "RestartCloud2.bmp")
        Me.ImageList1.Images.SetKeyName(1, "reload-icon-8.jpg")
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
        Me.btnDbLogRefresh.Location = New System.Drawing.Point(837, 3)
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
        Me.tpStParse.Size = New System.Drawing.Size(1056, 510)
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
        'tpPlayerCardDeferredRevenue
        '
        Me.tpPlayerCardDeferredRevenue.BackColor = System.Drawing.Color.DarkGray
        Me.tpPlayerCardDeferredRevenue.Controls.Add(Me.gpPcDrCommit)
        Me.tpPlayerCardDeferredRevenue.Controls.Add(Me.btnPcDrCommit)
        Me.tpPlayerCardDeferredRevenue.Controls.Add(Me.tbMLDRTest)
        Me.tpPlayerCardDeferredRevenue.Controls.Add(Me.gpOutstandingPCDR)
        Me.tpPlayerCardDeferredRevenue.Controls.Add(Me.gpInvItem)
        Me.tpPlayerCardDeferredRevenue.Location = New System.Drawing.Point(4, 22)
        Me.tpPlayerCardDeferredRevenue.Name = "tpPlayerCardDeferredRevenue"
        Me.tpPlayerCardDeferredRevenue.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPlayerCardDeferredRevenue.Size = New System.Drawing.Size(1056, 510)
        Me.tpPlayerCardDeferredRevenue.TabIndex = 5
        Me.tpPlayerCardDeferredRevenue.Text = "PlayerCard Def Rev"
        '
        'gpPcDrCommit
        '
        Me.gpPcDrCommit.BackColor = System.Drawing.Color.LightGray
        Me.gpPcDrCommit.Controls.Add(Me.lblPcDrInstr3)
        Me.gpPcDrCommit.Controls.Add(Me.lblPcDrInstr2b)
        Me.gpPcDrCommit.Controls.Add(Me.lblPcDrInstr2a)
        Me.gpPcDrCommit.Controls.Add(Me.lblPcDrInstr2)
        Me.gpPcDrCommit.Controls.Add(Me.lblPcDrInstr1)
        Me.gpPcDrCommit.Location = New System.Drawing.Point(23, 280)
        Me.gpPcDrCommit.Name = "gpPcDrCommit"
        Me.gpPcDrCommit.Size = New System.Drawing.Size(479, 143)
        Me.gpPcDrCommit.TabIndex = 25
        Me.gpPcDrCommit.TabStop = False
        Me.gpPcDrCommit.Text = "Instructions"
        '
        'lblPcDrInstr3
        '
        Me.lblPcDrInstr3.AutoSize = True
        Me.lblPcDrInstr3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPcDrInstr3.Location = New System.Drawing.Point(9, 84)
        Me.lblPcDrInstr3.Name = "lblPcDrInstr3"
        Me.lblPcDrInstr3.Size = New System.Drawing.Size(357, 13)
        Me.lblPcDrInstr3.TabIndex = 4
        Me.lblPcDrInstr3.Text = "3.  By pressing commit changes will be made to the database."
        '
        'lblPcDrInstr2b
        '
        Me.lblPcDrInstr2b.AutoSize = True
        Me.lblPcDrInstr2b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPcDrInstr2b.Location = New System.Drawing.Point(34, 66)
        Me.lblPcDrInstr2b.Name = "lblPcDrInstr2b"
        Me.lblPcDrInstr2b.Size = New System.Drawing.Size(363, 13)
        Me.lblPcDrInstr2b.TabIndex = 3
        Me.lblPcDrInstr2b.Text = "b.  a warning will be displayed or will enable the Commit button"
        '
        'lblPcDrInstr2a
        '
        Me.lblPcDrInstr2a.AutoSize = True
        Me.lblPcDrInstr2a.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPcDrInstr2a.Location = New System.Drawing.Point(34, 50)
        Me.lblPcDrInstr2a.Name = "lblPcDrInstr2a"
        Me.lblPcDrInstr2a.Size = New System.Drawing.Size(434, 13)
        Me.lblPcDrInstr2a.TabIndex = 2
        Me.lblPcDrInstr2a.Text = "a.  System will display Inventory Item information and Player Card DR Value"
        '
        'lblPcDrInstr2
        '
        Me.lblPcDrInstr2.AutoSize = True
        Me.lblPcDrInstr2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPcDrInstr2.Location = New System.Drawing.Point(9, 33)
        Me.lblPcDrInstr2.Name = "lblPcDrInstr2"
        Me.lblPcDrInstr2.Size = New System.Drawing.Size(403, 13)
        Me.lblPcDrInstr2.TabIndex = 1
        Me.lblPcDrInstr2.Text = "2.  Enter Inventory Detail No into Inventory Item box and press Select"
        '
        'lblPcDrInstr1
        '
        Me.lblPcDrInstr1.AutoSize = True
        Me.lblPcDrInstr1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPcDrInstr1.Location = New System.Drawing.Point(9, 16)
        Me.lblPcDrInstr1.Name = "lblPcDrInstr1"
        Me.lblPcDrInstr1.Size = New System.Drawing.Size(337, 13)
        Me.lblPcDrInstr1.TabIndex = 0
        Me.lblPcDrInstr1.Text = "1.  Determine Inventory Number from Advantage Inventory"
        '
        'btnPcDrCommit
        '
        Me.btnPcDrCommit.Location = New System.Drawing.Point(427, 429)
        Me.btnPcDrCommit.Name = "btnPcDrCommit"
        Me.btnPcDrCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnPcDrCommit.TabIndex = 24
        Me.btnPcDrCommit.Text = "Commit"
        Me.btnPcDrCommit.UseVisualStyleBackColor = True
        '
        'tbMLDRTest
        '
        Me.tbMLDRTest.Location = New System.Drawing.Point(508, 82)
        Me.tbMLDRTest.Multiline = True
        Me.tbMLDRTest.Name = "tbMLDRTest"
        Me.tbMLDRTest.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbMLDRTest.Size = New System.Drawing.Size(455, 318)
        Me.tbMLDRTest.TabIndex = 22
        '
        'gpOutstandingPCDR
        '
        Me.gpOutstandingPCDR.BackColor = System.Drawing.Color.LightGray
        Me.gpOutstandingPCDR.Controls.Add(Me.lblOutstandingPCDR)
        Me.gpOutstandingPCDR.Controls.Add(Me.tbOutstandingPCDR)
        Me.gpOutstandingPCDR.Location = New System.Drawing.Point(508, 17)
        Me.gpOutstandingPCDR.Name = "gpOutstandingPCDR"
        Me.gpOutstandingPCDR.Size = New System.Drawing.Size(223, 59)
        Me.gpOutstandingPCDR.TabIndex = 21
        Me.gpOutstandingPCDR.TabStop = False
        Me.gpOutstandingPCDR.Text = "Outstanding Deferred Revenue"
        '
        'lblOutstandingPCDR
        '
        Me.lblOutstandingPCDR.AutoSize = True
        Me.lblOutstandingPCDR.Location = New System.Drawing.Point(6, 26)
        Me.lblOutstandingPCDR.Name = "lblOutstandingPCDR"
        Me.lblOutstandingPCDR.Size = New System.Drawing.Size(75, 13)
        Me.lblOutstandingPCDR.TabIndex = 18
        Me.lblOutstandingPCDR.Text = "Player Cards:  "
        '
        'tbOutstandingPCDR
        '
        Me.tbOutstandingPCDR.Location = New System.Drawing.Point(81, 23)
        Me.tbOutstandingPCDR.Name = "tbOutstandingPCDR"
        Me.tbOutstandingPCDR.Size = New System.Drawing.Size(100, 20)
        Me.tbOutstandingPCDR.TabIndex = 19
        '
        'gpInvItem
        '
        Me.gpInvItem.BackColor = System.Drawing.Color.LightGray
        Me.gpInvItem.Controls.Add(Me.lblDRInvNo)
        Me.gpInvItem.Controls.Add(Me.nudDRInvNo)
        Me.gpInvItem.Controls.Add(Me.dgvInvItem)
        Me.gpInvItem.Controls.Add(Me.btnDRInvNo)
        Me.gpInvItem.Location = New System.Drawing.Point(23, 17)
        Me.gpInvItem.Name = "gpInvItem"
        Me.gpInvItem.Size = New System.Drawing.Size(479, 257)
        Me.gpInvItem.TabIndex = 20
        Me.gpInvItem.TabStop = False
        Me.gpInvItem.Text = "Inventory Item"
        '
        'lblDRInvNo
        '
        Me.lblDRInvNo.AutoSize = True
        Me.lblDRInvNo.Location = New System.Drawing.Point(6, 16)
        Me.lblDRInvNo.Name = "lblDRInvNo"
        Me.lblDRInvNo.Size = New System.Drawing.Size(253, 13)
        Me.lblDRInvNo.TabIndex = 16
        Me.lblDRInvNo.Text = "Enter Detail Item Number (Inventory.InvNo) to select"
        '
        'nudDRInvNo
        '
        Me.nudDRInvNo.Location = New System.Drawing.Point(266, 14)
        Me.nudDRInvNo.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.nudDRInvNo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDRInvNo.Name = "nudDRInvNo"
        Me.nudDRInvNo.Size = New System.Drawing.Size(80, 20)
        Me.nudDRInvNo.TabIndex = 0
        Me.nudDRInvNo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dgvInvItem
        '
        Me.dgvInvItem.AllowUserToAddRows = False
        Me.dgvInvItem.AllowUserToDeleteRows = False
        Me.dgvInvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInvItem.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvInvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvItemData, Me.InvItemValue})
        Me.dgvInvItem.Location = New System.Drawing.Point(9, 46)
        Me.dgvInvItem.MultiSelect = False
        Me.dgvInvItem.Name = "dgvInvItem"
        Me.dgvInvItem.ReadOnly = True
        Me.dgvInvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvInvItem.Size = New System.Drawing.Size(455, 195)
        Me.dgvInvItem.TabIndex = 15
        '
        'InvItemData
        '
        Me.InvItemData.HeaderText = "Setting"
        Me.InvItemData.Name = "InvItemData"
        Me.InvItemData.ReadOnly = True
        '
        'InvItemValue
        '
        Me.InvItemValue.HeaderText = "Value"
        Me.InvItemValue.Name = "InvItemValue"
        Me.InvItemValue.ReadOnly = True
        '
        'btnDRInvNo
        '
        Me.btnDRInvNo.Location = New System.Drawing.Point(352, 14)
        Me.btnDRInvNo.Name = "btnDRInvNo"
        Me.btnDRInvNo.Size = New System.Drawing.Size(75, 23)
        Me.btnDRInvNo.TabIndex = 17
        Me.btnDRInvNo.Text = "Select"
        Me.btnDRInvNo.UseVisualStyleBackColor = True
        '
        'tpNetwork
        '
        Me.tpNetwork.Controls.Add(Me.tbPortScan)
        Me.tpNetwork.Controls.Add(Me.gpCloudComm)
        Me.tpNetwork.Controls.Add(Me.btnPortCheck)
        Me.tpNetwork.Controls.Add(Me.dgvPorts)
        Me.tpNetwork.Location = New System.Drawing.Point(4, 22)
        Me.tpNetwork.Name = "tpNetwork"
        Me.tpNetwork.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNetwork.Size = New System.Drawing.Size(1056, 510)
        Me.tpNetwork.TabIndex = 6
        Me.tpNetwork.Text = "Network Info"
        Me.tpNetwork.UseVisualStyleBackColor = True
        '
        'tbPortScan
        '
        Me.tbPortScan.Location = New System.Drawing.Point(524, 438)
        Me.tbPortScan.Name = "tbPortScan"
        Me.tbPortScan.Size = New System.Drawing.Size(382, 20)
        Me.tbPortScan.TabIndex = 6
        '
        'gpCloudComm
        '
        Me.gpCloudComm.Controls.Add(Me.btnRelayRefresh)
        Me.gpCloudComm.Controls.Add(Me.tbStageRelayConn)
        Me.gpCloudComm.Controls.Add(Me.lblStageRelayConn)
        Me.gpCloudComm.Location = New System.Drawing.Point(524, 6)
        Me.gpCloudComm.Name = "gpCloudComm"
        Me.gpCloudComm.Size = New System.Drawing.Size(456, 394)
        Me.gpCloudComm.TabIndex = 5
        Me.gpCloudComm.TabStop = False
        Me.gpCloudComm.Text = "Cloud Communication"
        '
        'btnRelayRefresh
        '
        Me.btnRelayRefresh.ImageIndex = 1
        Me.btnRelayRefresh.ImageList = Me.ImageList1
        Me.btnRelayRefresh.Location = New System.Drawing.Point(265, 27)
        Me.btnRelayRefresh.Name = "btnRelayRefresh"
        Me.btnRelayRefresh.Size = New System.Drawing.Size(25, 25)
        Me.btnRelayRefresh.TabIndex = 2
        Me.btnRelayRefresh.UseVisualStyleBackColor = True
        '
        'tbStageRelayConn
        '
        Me.tbStageRelayConn.Location = New System.Drawing.Point(159, 28)
        Me.tbStageRelayConn.Name = "tbStageRelayConn"
        Me.tbStageRelayConn.Size = New System.Drawing.Size(100, 20)
        Me.tbStageRelayConn.TabIndex = 1
        '
        'lblStageRelayConn
        '
        Me.lblStageRelayConn.AutoSize = True
        Me.lblStageRelayConn.Location = New System.Drawing.Point(19, 35)
        Me.lblStageRelayConn.Name = "lblStageRelayConn"
        Me.lblStageRelayConn.Size = New System.Drawing.Size(122, 13)
        Me.lblStageRelayConn.TabIndex = 0
        Me.lblStageRelayConn.Text = "Stage Relay Connection"
        '
        'btnPortCheck
        '
        Me.btnPortCheck.Location = New System.Drawing.Point(388, 435)
        Me.btnPortCheck.Name = "btnPortCheck"
        Me.btnPortCheck.Size = New System.Drawing.Size(75, 23)
        Me.btnPortCheck.TabIndex = 4
        Me.btnPortCheck.Text = "Check Ports"
        Me.btnPortCheck.UseVisualStyleBackColor = True
        '
        'dgvPorts
        '
        Me.dgvPorts.AllowUserToAddRows = False
        Me.dgvPorts.AllowUserToDeleteRows = False
        Me.dgvPorts.AllowUserToResizeColumns = False
        Me.dgvPorts.AllowUserToResizeRows = False
        Me.dgvPorts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPorts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PortNo, Me.AppName, Me.PortStatus})
        Me.dgvPorts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPorts.Location = New System.Drawing.Point(6, 6)
        Me.dgvPorts.Name = "dgvPorts"
        Me.dgvPorts.ReadOnly = True
        Me.dgvPorts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPorts.Size = New System.Drawing.Size(494, 394)
        Me.dgvPorts.TabIndex = 3
        '
        'PortNo
        '
        Me.PortNo.HeaderText = "Port"
        Me.PortNo.Name = "PortNo"
        Me.PortNo.ReadOnly = True
        Me.PortNo.Width = 51
        '
        'AppName
        '
        Me.AppName.HeaderText = "Application"
        Me.AppName.Name = "AppName"
        Me.AppName.ReadOnly = True
        Me.AppName.Width = 84
        '
        'PortStatus
        '
        Me.PortStatus.HeaderText = "Status"
        Me.PortStatus.Name = "PortStatus"
        Me.PortStatus.ReadOnly = True
        Me.PortStatus.Width = 62
        '
        'tpOptions
        '
        Me.tpOptions.Controls.Add(Me.gpAdvUpgrade)
        Me.tpOptions.Location = New System.Drawing.Point(4, 22)
        Me.tpOptions.Name = "tpOptions"
        Me.tpOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOptions.Size = New System.Drawing.Size(1056, 510)
        Me.tpOptions.TabIndex = 7
        Me.tpOptions.Text = "Options"
        Me.tpOptions.UseVisualStyleBackColor = True
        '
        'gpAdvUpgrade
        '
        Me.gpAdvUpgrade.Controls.Add(Me.cbAdvUpgradeNoBackup)
        Me.gpAdvUpgrade.Controls.Add(Me.cbAdvUpgradeNoSetup)
        Me.gpAdvUpgrade.Controls.Add(Me.cbAdvUpgradeQuiet)
        Me.gpAdvUpgrade.Location = New System.Drawing.Point(568, 26)
        Me.gpAdvUpgrade.Name = "gpAdvUpgrade"
        Me.gpAdvUpgrade.Size = New System.Drawing.Size(274, 127)
        Me.gpAdvUpgrade.TabIndex = 0
        Me.gpAdvUpgrade.TabStop = False
        Me.gpAdvUpgrade.Text = "Advantage Upgrade"
        '
        'cbAdvUpgradeNoBackup
        '
        Me.cbAdvUpgradeNoBackup.AutoSize = True
        Me.cbAdvUpgradeNoBackup.Location = New System.Drawing.Point(17, 77)
        Me.cbAdvUpgradeNoBackup.Name = "cbAdvUpgradeNoBackup"
        Me.cbAdvUpgradeNoBackup.Size = New System.Drawing.Size(135, 17)
        Me.cbAdvUpgradeNoBackup.TabIndex = 2
        Me.cbAdvUpgradeNoBackup.Text = "Do not make a backup"
        Me.cbAdvUpgradeNoBackup.UseVisualStyleBackColor = True
        '
        'cbAdvUpgradeNoSetup
        '
        Me.cbAdvUpgradeNoSetup.AutoSize = True
        Me.cbAdvUpgradeNoSetup.Location = New System.Drawing.Point(17, 54)
        Me.cbAdvUpgradeNoSetup.Name = "cbAdvUpgradeNoSetup"
        Me.cbAdvUpgradeNoSetup.Size = New System.Drawing.Size(162, 17)
        Me.cbAdvUpgradeNoSetup.TabIndex = 1
        Me.cbAdvUpgradeNoSetup.Text = "Do not run Advantage Setup"
        Me.cbAdvUpgradeNoSetup.UseVisualStyleBackColor = True
        '
        'cbAdvUpgradeQuiet
        '
        Me.cbAdvUpgradeQuiet.AutoSize = True
        Me.cbAdvUpgradeQuiet.Location = New System.Drawing.Point(17, 31)
        Me.cbAdvUpgradeQuiet.Name = "cbAdvUpgradeQuiet"
        Me.cbAdvUpgradeQuiet.Size = New System.Drawing.Size(228, 17)
        Me.cbAdvUpgradeQuiet.TabIndex = 0
        Me.cbAdvUpgradeQuiet.Text = "Quiet Mode (Runs in Cmd Prompt Window)"
        Me.cbAdvUpgradeQuiet.UseVisualStyleBackColor = True
        '
        'tpEODB
        '
        Me.tpEODB.Controls.Add(Me.dtpTest)
        Me.tpEODB.Controls.Add(Me.tbEodbProgress)
        Me.tpEODB.Controls.Add(Me.btnXmltoWorkbook)
        Me.tpEODB.Controls.Add(Me.btnSaveToXml)
        Me.tpEODB.Controls.Add(Me.dtpEODB)
        Me.tpEODB.Controls.Add(Me.btnEODBFolder)
        Me.tpEODB.Controls.Add(Me.btnEODBSave)
        Me.tpEODB.Controls.Add(Me.lblEODBFolder)
        Me.tpEODB.Controls.Add(Me.tbEODBFolder)
        Me.tpEODB.Location = New System.Drawing.Point(4, 22)
        Me.tpEODB.Name = "tpEODB"
        Me.tpEODB.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEODB.Size = New System.Drawing.Size(1056, 510)
        Me.tpEODB.TabIndex = 8
        Me.tpEODB.Text = "EODB Troubleshooting"
        Me.tpEODB.UseVisualStyleBackColor = True
        '
        'dtpTest
        '
        Me.dtpTest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTest.Location = New System.Drawing.Point(728, 293)
        Me.dtpTest.Name = "dtpTest"
        Me.dtpTest.Size = New System.Drawing.Size(200, 20)
        Me.dtpTest.TabIndex = 7
        Me.dtpTest.Value = New Date(2022, 11, 1, 0, 0, 0, 0)
        '
        'tbEodbProgress
        '
        Me.tbEodbProgress.Location = New System.Drawing.Point(137, 255)
        Me.tbEodbProgress.Multiline = True
        Me.tbEodbProgress.Name = "tbEodbProgress"
        Me.tbEodbProgress.Size = New System.Drawing.Size(292, 107)
        Me.tbEodbProgress.TabIndex = 6
        '
        'btnXmltoWorkbook
        '
        Me.btnXmltoWorkbook.Location = New System.Drawing.Point(888, 448)
        Me.btnXmltoWorkbook.Name = "btnXmltoWorkbook"
        Me.btnXmltoWorkbook.Size = New System.Drawing.Size(75, 23)
        Me.btnXmltoWorkbook.TabIndex = 5
        Me.btnXmltoWorkbook.Text = "Read XML"
        Me.btnXmltoWorkbook.UseVisualStyleBackColor = True
        '
        'btnSaveToXml
        '
        Me.btnSaveToXml.Location = New System.Drawing.Point(703, 413)
        Me.btnSaveToXml.Name = "btnSaveToXml"
        Me.btnSaveToXml.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveToXml.TabIndex = 5
        Me.btnSaveToXml.Text = "Save XML"
        Me.btnSaveToXml.UseVisualStyleBackColor = True
        '
        'dtpEODB
        '
        Me.dtpEODB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEODB.Location = New System.Drawing.Point(660, 152)
        Me.dtpEODB.Name = "dtpEODB"
        Me.dtpEODB.Size = New System.Drawing.Size(200, 20)
        Me.dtpEODB.TabIndex = 3
        Me.dtpEODB.Value = New Date(2022, 7, 7, 0, 0, 0, 0)
        '
        'btnEODBFolder
        '
        Me.btnEODBFolder.Location = New System.Drawing.Point(762, 26)
        Me.btnEODBFolder.Name = "btnEODBFolder"
        Me.btnEODBFolder.Size = New System.Drawing.Size(79, 23)
        Me.btnEODBFolder.TabIndex = 2
        Me.btnEODBFolder.Text = "Select Folder"
        Me.btnEODBFolder.UseVisualStyleBackColor = True
        '
        'btnEODBSave
        '
        Me.btnEODBSave.Location = New System.Drawing.Point(703, 366)
        Me.btnEODBSave.Name = "btnEODBSave"
        Me.btnEODBSave.Size = New System.Drawing.Size(75, 23)
        Me.btnEODBSave.TabIndex = 4
        Me.btnEODBSave.Text = "Save"
        Me.btnEODBSave.UseVisualStyleBackColor = True
        '
        'lblEODBFolder
        '
        Me.lblEODBFolder.AutoSize = True
        Me.lblEODBFolder.Location = New System.Drawing.Point(26, 35)
        Me.lblEODBFolder.Name = "lblEODBFolder"
        Me.lblEODBFolder.Size = New System.Drawing.Size(39, 13)
        Me.lblEODBFolder.TabIndex = 1
        Me.lblEODBFolder.Text = "Folder:"
        '
        'tbEODBFolder
        '
        Me.tbEODBFolder.Location = New System.Drawing.Point(71, 28)
        Me.tbEODBFolder.Name = "tbEODBFolder"
        Me.tbEODBFolder.Size = New System.Drawing.Size(664, 20)
        Me.tbEODBFolder.TabIndex = 0
        '
        'btnAdvUpgrade
        '
        Me.btnAdvUpgrade.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdvUpgrade.Location = New System.Drawing.Point(833, 80)
        Me.btnAdvUpgrade.Name = "btnAdvUpgrade"
        Me.btnAdvUpgrade.Size = New System.Drawing.Size(80, 44)
        Me.btnAdvUpgrade.TabIndex = 18
        Me.btnAdvUpgrade.Text = "Advantage Upgrade"
        Me.btnAdvUpgrade.UseVisualStyleBackColor = True
        '
        'btnAdvReportEditor
        '
        Me.btnAdvReportEditor.Location = New System.Drawing.Point(182, 94)
        Me.btnAdvReportEditor.Name = "btnAdvReportEditor"
        Me.btnAdvReportEditor.Size = New System.Drawing.Size(75, 38)
        Me.btnAdvReportEditor.TabIndex = 17
        Me.btnAdvReportEditor.Text = "Report Editor"
        Me.btnAdvReportEditor.UseVisualStyleBackColor = True
        '
        'tbMLTest1
        '
        Me.tbMLTest1.Location = New System.Drawing.Point(488, 10)
        Me.tbMLTest1.Multiline = True
        Me.tbMLTest1.Name = "tbMLTest1"
        Me.tbMLTest1.Size = New System.Drawing.Size(194, 125)
        Me.tbMLTest1.TabIndex = 16
        '
        'btnAdvGroups
        '
        Me.btnAdvGroups.Location = New System.Drawing.Point(7, 94)
        Me.btnAdvGroups.Name = "btnAdvGroups"
        Me.btnAdvGroups.Size = New System.Drawing.Size(75, 38)
        Me.btnAdvGroups.TabIndex = 16
        Me.btnAdvGroups.Text = "Groups"
        Me.btnAdvGroups.UseVisualStyleBackColor = True
        '
        'btnPos
        '
        Me.btnPos.Location = New System.Drawing.Point(7, 57)
        Me.btnPos.Name = "btnPos"
        Me.btnPos.Size = New System.Drawing.Size(75, 38)
        Me.btnPos.TabIndex = 15
        Me.btnPos.Text = "POS"
        Me.btnPos.UseVisualStyleBackColor = True
        '
        'btnAdvManager
        '
        Me.btnAdvManager.Location = New System.Drawing.Point(7, 20)
        Me.btnAdvManager.Name = "btnAdvManager"
        Me.btnAdvManager.Size = New System.Drawing.Size(75, 38)
        Me.btnAdvManager.TabIndex = 15
        Me.btnAdvManager.Text = "Manager " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Console"
        Me.btnAdvManager.UseVisualStyleBackColor = True
        '
        'tbTest3
        '
        Me.tbTest3.Location = New System.Drawing.Point(276, 51)
        Me.tbTest3.Name = "tbTest3"
        Me.tbTest3.Size = New System.Drawing.Size(206, 20)
        Me.tbTest3.TabIndex = 14
        Me.tbTest3.Text = "tbTest3"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(279, 77)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 1
        Me.btnTest.Text = "Test Button"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'tbTest2
        '
        Me.tbTest2.Location = New System.Drawing.Point(276, 30)
        Me.tbTest2.Name = "tbTest2"
        Me.tbTest2.Size = New System.Drawing.Size(206, 20)
        Me.tbTest2.TabIndex = 13
        Me.tbTest2.Text = "tbTest2"
        '
        'btnCenterEdgeConfig
        '
        Me.btnCenterEdgeConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCenterEdgeConfig.Location = New System.Drawing.Point(833, 30)
        Me.btnCenterEdgeConfig.Name = "btnCenterEdgeConfig"
        Me.btnCenterEdgeConfig.Size = New System.Drawing.Size(80, 44)
        Me.btnCenterEdgeConfig.TabIndex = 12
        Me.btnCenterEdgeConfig.Text = "CenterEdge Configuration"
        Me.btnCenterEdgeConfig.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(830, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Login using SQL Credentials"
        '
        'tbTest1
        '
        Me.tbTest1.Location = New System.Drawing.Point(276, 10)
        Me.tbTest1.Name = "tbTest1"
        Me.tbTest1.Size = New System.Drawing.Size(206, 20)
        Me.tbTest1.TabIndex = 3
        Me.tbTest1.Text = "tbTest1"
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Location = New System.Drawing.Point(976, 5)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 10
        Me.btnLogin.Text = "Login"
        Me.ttSTA2.SetToolTip(Me.btnLogin, "Use this button to unlock higher level functions by logging in with the SA Userna" &
        "me and Password")
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblCeVersion, Me.tslblTime, Me.tslblNetVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 686)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1068, 24)
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
        Me.tslblCeVersion.Size = New System.Drawing.Size(123, 19)
        Me.tslblCeVersion.Text = "ToolStripStatusLabel1"
        '
        'tslblTime
        '
        Me.tslblTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblTime.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.tslblTime.Name = "tslblTime"
        Me.tslblTime.Size = New System.Drawing.Size(123, 19)
        Me.tslblTime.Text = "ToolStripStatusLabel1"
        '
        'tslblNetVersion
        '
        Me.tslblNetVersion.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblNetVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.tslblNetVersion.Name = "tslblNetVersion"
        Me.tslblNetVersion.Size = New System.Drawing.Size(123, 19)
        Me.tslblNetVersion.Text = "ToolStripStatusLabel1"
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
        Me.tmr1Sec.Interval = 1000
        '
        'ttSTA2
        '
        Me.ttSTA2.IsBalloon = True
        Me.ttSTA2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ttSTA2.ToolTipTitle = "Support Tech Assistant 2022"
        '
        'fbdEODB
        '
        Me.fbdEODB.Description = "EODB Troubleshooting"
        '
        'gnAdvApps
        '
        Me.gnAdvApps.Controls.Add(Me.btnAdvManager)
        Me.gnAdvApps.Controls.Add(Me.btnPos)
        Me.gnAdvApps.Controls.Add(Me.btnAdvReportEditor)
        Me.gnAdvApps.Controls.Add(Me.btnAdvGroups)
        Me.gnAdvApps.Location = New System.Drawing.Point(3, 3)
        Me.gnAdvApps.Name = "gnAdvApps"
        Me.gnAdvApps.Size = New System.Drawing.Size(267, 135)
        Me.gnAdvApps.TabIndex = 19
        Me.gnAdvApps.TabStop = False
        Me.gnAdvApps.Text = "Advantage Applications"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1068, 710)
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
        Me.gpPcInfo.ResumeLayout(False)
        Me.tlpPcInfo.ResumeLayout(False)
        Me.tlpPcInfo.PerformLayout()
        Me.flpServices.ResumeLayout(False)
        Me.gpApiService.ResumeLayout(False)
        Me.gpApiService.PerformLayout()
        Me.gpCoreService.ResumeLayout(False)
        Me.gpCoreService.PerformLayout()
        Me.gpCloudService.ResumeLayout(False)
        Me.gpCloudService.PerformLayout()
        Me.gpAdvCreditService.ResumeLayout(False)
        Me.gpAdvCreditService.PerformLayout()
        Me.gpAdvSignageService.ResumeLayout(False)
        Me.gpAdvSignageService.PerformLayout()
        Me.gpAdvLicService.ResumeLayout(False)
        Me.gpAdvLicService.PerformLayout()
        Me.gpAdvNotifyService.ResumeLayout(False)
        Me.gpAdvNotifyService.PerformLayout()
        Me.gpAdvTurnstileEngine.ResumeLayout(False)
        Me.gpAdvTurnstileEngine.PerformLayout()
        Me.gpAdvantageUpgradeService.ResumeLayout(False)
        Me.gpAdvantageUpgradeService.PerformLayout()
        Me.gpLicInfo.ResumeLayout(False)
        Me.gpLicInfo.PerformLayout()
        Me.gpPfsConnect.ResumeLayout(False)
        CType(Me.dgvPFSConnect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAdvData.ResumeLayout(False)
        Me.tpAdvData.PerformLayout()
        CType(Me.dgvWebOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsEditMenu.ResumeLayout(False)
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
        Me.tpPlayerCardDeferredRevenue.ResumeLayout(False)
        Me.tpPlayerCardDeferredRevenue.PerformLayout()
        Me.gpPcDrCommit.ResumeLayout(False)
        Me.gpPcDrCommit.PerformLayout()
        Me.gpOutstandingPCDR.ResumeLayout(False)
        Me.gpOutstandingPCDR.PerformLayout()
        Me.gpInvItem.ResumeLayout(False)
        Me.gpInvItem.PerformLayout()
        CType(Me.nudDRInvNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNetwork.ResumeLayout(False)
        Me.tpNetwork.PerformLayout()
        Me.gpCloudComm.ResumeLayout(False)
        Me.gpCloudComm.PerformLayout()
        CType(Me.dgvPorts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpOptions.ResumeLayout(False)
        Me.gpAdvUpgrade.ResumeLayout(False)
        Me.gpAdvUpgrade.PerformLayout()
        Me.tpEODB.ResumeLayout(False)
        Me.tpEODB.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gnAdvApps.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tcSTA As TabControl
    Friend WithEvents tpGeneral As TabPage
    Friend WithEvents tpDbInfo As TabPage
    Friend WithEvents dgvPFSConnect As DataGridView
    Friend WithEvents Setting As DataGridViewTextBoxColumn
    Friend WithEvents Value As DataGridViewTextBoxColumn
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
    Friend WithEvents gpPfsConnect As GroupBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tslblCeVersion As ToolStripStatusLabel
    Friend WithEvents tslblTime As ToolStripStatusLabel
    Friend WithEvents tmr10Seconds As Timer
    Friend WithEvents tslblNetVersion As ToolStripStatusLabel
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDbInfoRefresh As Button
    Friend WithEvents pnlDbData As Panel
    Friend WithEvents dgvDbTableSize As DataGridView
    Friend WithEvents tbTest1 As TextBox
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
    Friend WithEvents btnTest As Button
    Friend WithEvents pnlDbLogs As Panel
    Friend WithEvents tbTest2 As TextBox
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
    Friend WithEvents flpServices As FlowLayoutPanel
    Friend WithEvents btnCoreServiceRS As Button
    Friend WithEvents tbCoreService As TextBox
    Friend WithEvents btnCoreServiceSS As Button
    Friend WithEvents btnCloudServiceRS As Button
    Friend WithEvents tbCloudService As TextBox
    Friend WithEvents btnCloudServiceSS As Button
    Friend WithEvents gpCoreService As GroupBox
    Friend WithEvents gpCloudService As GroupBox
    Friend WithEvents tmr1Sec As Timer
    Friend WithEvents gpApiService As GroupBox
    Friend WithEvents btnApiServiceRS As Button
    Friend WithEvents tbApiService As TextBox
    Friend WithEvents btnApiServiceSS As Button
    Friend WithEvents gpAdvCreditService As GroupBox
    Friend WithEvents btnAdvCreditServiceRS As Button
    Friend WithEvents tbAdvCreditService As TextBox
    Friend WithEvents btnAdvCreditServiceSS As Button
    Friend WithEvents gpAdvSignageService As GroupBox
    Friend WithEvents btnAdvSignageServiceRS As Button
    Friend WithEvents tbAdvSignageService As TextBox
    Friend WithEvents btnAdvSignageServiceSS As Button
    Friend WithEvents tbTest3 As TextBox
    Friend WithEvents gpAdvLicService As GroupBox
    Friend WithEvents btnAdvLicServiceRS As Button
    Friend WithEvents tbAdvLicService As TextBox
    Friend WithEvents btnAdvLicServiceSS As Button
    Friend WithEvents gpAdvTurnstileEngine As GroupBox
    Friend WithEvents btnAdvTurnstileEngineRS As Button
    Friend WithEvents tbAdvTurnstileEngine As TextBox
    Friend WithEvents btnAdvTurnstileEngineSS As Button
    Friend WithEvents gpAdvNotifyService As GroupBox
    Friend WithEvents btnAdvNotifyServiceRS As Button
    Friend WithEvents tbAdvNotifyService As TextBox
    Friend WithEvents btnAdvNotifyServiceSS As Button
    Friend WithEvents gpAdvantageUpgradeService As GroupBox
    Friend WithEvents btnAdvantageUpgradeServiceRS As Button
    Friend WithEvents tbAdvantageUpgradeService As TextBox
    Friend WithEvents btnAdvantageUpgradeServiceSS As Button
    Friend WithEvents tpAdvData As TabPage
    Friend WithEvents dgvAppOptions As DataGridView
    Friend WithEvents OptionName As DataGridViewTextBoxColumn
    Friend WithEvents OptionValue As DataGridViewTextBoxColumn
    Friend WithEvents dgvWebOptions As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents lblAppOptions As Label
    Friend WithEvents lblWebOptions As Label
    Friend WithEvents cmsEditMenu As ContextMenuStrip
    Friend WithEvents tsmCopy As ToolStripMenuItem
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
    Friend WithEvents tpPlayerCardDeferredRevenue As TabPage
    Friend WithEvents nudDRInvNo As NumericUpDown
    Friend WithEvents dgvInvItem As DataGridView
    Friend WithEvents InvItemData As DataGridViewTextBoxColumn
    Friend WithEvents InvItemValue As DataGridViewTextBoxColumn
    Friend WithEvents btnDRInvNo As Button
    Friend WithEvents lblDRInvNo As Label
    Friend WithEvents tbOutstandingPCDR As TextBox
    Friend WithEvents lblOutstandingPCDR As Label
    Friend WithEvents tbMLTest1 As TextBox
    Friend WithEvents gpOutstandingPCDR As GroupBox
    Friend WithEvents gpInvItem As GroupBox
    Friend WithEvents tbMLDRTest As TextBox
    Friend WithEvents btnPcDrCommit As Button
    Friend WithEvents gpPcDrCommit As GroupBox
    Friend WithEvents lblPcDrInstr1 As Label
    Friend WithEvents lblPcDrInstr3 As Label
    Friend WithEvents lblPcDrInstr2b As Label
    Friend WithEvents lblPcDrInstr2a As Label
    Friend WithEvents lblPcDrInstr2 As Label
    Friend WithEvents btnCloudRestart As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnAdvManager As Button
    Friend WithEvents btnAdvGroups As Button
    Friend WithEvents btnPos As Button
    Friend WithEvents tlpLogData As TableLayoutPanel
    Friend WithEvents tpNetwork As TabPage
    Friend WithEvents dgvPorts As DataGridView
    Friend WithEvents PortNo As DataGridViewTextBoxColumn
    Friend WithEvents AppName As DataGridViewTextBoxColumn
    Friend WithEvents PortStatus As DataGridViewTextBoxColumn
    Friend WithEvents btnPortCheck As Button
    Friend WithEvents gpCloudComm As GroupBox
    Friend WithEvents tbStageRelayConn As TextBox
    Friend WithEvents lblStageRelayConn As Label
    Friend WithEvents btnRelayRefresh As Button
    Friend WithEvents tbPortScan As TextBox
    Friend WithEvents btnAdvReportEditor As Button
    Friend WithEvents btnAdvUpgrade As Button
    Friend WithEvents tpOptions As TabPage
    Friend WithEvents gpAdvUpgrade As GroupBox
    Friend WithEvents cbAdvUpgradeQuiet As CheckBox
    Friend WithEvents cbAdvUpgradeNoBackup As CheckBox
    Friend WithEvents cbAdvUpgradeNoSetup As CheckBox
    Friend WithEvents tpEODB As TabPage
    Friend WithEvents btnEODBFolder As Button
    Friend WithEvents lblEODBFolder As Label
    Friend WithEvents tbEODBFolder As TextBox
    Friend WithEvents fbdEODB As FolderBrowserDialog
    Friend WithEvents dtpEODB As DateTimePicker
    Friend WithEvents btnEODBSave As Button
    Friend WithEvents btnSaveToXml As Button
    Friend WithEvents btnXmltoWorkbook As Button
    Friend WithEvents tbEodbProgress As TextBox
    Friend WithEvents dtpTest As DateTimePicker
    Friend WithEvents gnAdvApps As GroupBox
End Class
