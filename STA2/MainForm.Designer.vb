<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnUnlockAdminAccount = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tcSTA = New System.Windows.Forms.TabControl()
        Me.tpGeneral = New System.Windows.Forms.TabPage()
        Me.tbMLTest1 = New System.Windows.Forms.TextBox()
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
        Me.tpDbInfo = New System.Windows.Forms.TabPage()
        Me.pnlDbInfoButtons = New System.Windows.Forms.Panel()
        Me.rbDbDeadlocks = New System.Windows.Forms.RadioButton()
        Me.rbDbSizeByDay = New System.Windows.Forms.RadioButton()
        Me.btnDbInfoRefresh = New System.Windows.Forms.Button()
        Me.rbDbFragmentation = New System.Windows.Forms.RadioButton()
        Me.rbDbTableSize = New System.Windows.Forms.RadioButton()
        Me.pnlDbData = New System.Windows.Forms.Panel()
        Me.dgvDbTableSize = New System.Windows.Forms.DataGridView()
        Me.tbDbLogs = New System.Windows.Forms.TabPage()
        Me.gpDbLogData = New System.Windows.Forms.GroupBox()
        Me.dgvDbLogData = New System.Windows.Forms.DataGridView()
        Me.gpDbLogCount = New System.Windows.Forms.GroupBox()
        Me.dgvDbLogCount = New System.Windows.Forms.DataGridView()
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
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tcSTA.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
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
        Me.tpDbInfo.SuspendLayout()
        Me.pnlDbInfoButtons.SuspendLayout()
        Me.pnlDbData.SuspendLayout()
        CType(Me.dgvDbTableSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDbLogs.SuspendLayout()
        Me.gpDbLogData.SuspendLayout()
        CType(Me.dgvDbLogData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDbLogCount.SuspendLayout()
        CType(Me.dgvDbLogCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDbLogs.SuspendLayout()
        Me.gpMessageLogFilters.SuspendLayout()
        CType(Me.nudMsgLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStParse.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(1187, 32)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 20)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnUnlockAdminAccount
        '
        Me.btnUnlockAdminAccount.Location = New System.Drawing.Point(1187, 9)
        Me.btnUnlockAdminAccount.Name = "btnUnlockAdminAccount"
        Me.btnUnlockAdminAccount.Size = New System.Drawing.Size(64, 20)
        Me.btnUnlockAdminAccount.TabIndex = 9
        Me.btnUnlockAdminAccount.Text = "Unlock"
        Me.btnUnlockAdminAccount.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbTest3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnTest)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbTest2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCenterEdgeConfig)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbTest1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnLogin)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnExit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnUnlockAdminAccount)
        Me.SplitContainer1.Size = New System.Drawing.Size(1265, 649)
        Me.SplitContainer1.SplitterDistance = 567
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 10
        '
        'tcSTA
        '
        Me.tcSTA.Controls.Add(Me.tpGeneral)
        Me.tcSTA.Controls.Add(Me.tpDbInfo)
        Me.tcSTA.Controls.Add(Me.tbDbLogs)
        Me.tcSTA.Controls.Add(Me.tpStParse)
        Me.tcSTA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcSTA.Location = New System.Drawing.Point(0, 0)
        Me.tcSTA.Name = "tcSTA"
        Me.tcSTA.SelectedIndex = 0
        Me.tcSTA.Size = New System.Drawing.Size(1261, 563)
        Me.tcSTA.TabIndex = 11
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.tbMLTest1)
        Me.tpGeneral.Controls.Add(Me.flpServices)
        Me.tpGeneral.Controls.Add(Me.gpLicInfo)
        Me.tpGeneral.Controls.Add(Me.gpPfsConnect)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(1253, 537)
        Me.tpGeneral.TabIndex = 0
        Me.tpGeneral.Text = "General"
        Me.tpGeneral.UseVisualStyleBackColor = True
        '
        'tbMLTest1
        '
        Me.tbMLTest1.Location = New System.Drawing.Point(24, 236)
        Me.tbMLTest1.Multiline = True
        Me.tbMLTest1.Name = "tbMLTest1"
        Me.tbMLTest1.Size = New System.Drawing.Size(320, 244)
        Me.tbMLTest1.TabIndex = 13
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
        Me.flpServices.Location = New System.Drawing.Point(511, 204)
        Me.flpServices.Name = "flpServices"
        Me.flpServices.Size = New System.Drawing.Size(742, 276)
        Me.flpServices.TabIndex = 12
        '
        'gpApiService
        '
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
        Me.btnApiServiceRS.Tag = ""
        Me.btnApiServiceRS.Text = "Restart"
        Me.btnApiServiceRS.UseVisualStyleBackColor = True
        '
        'tbApiService
        '
        Me.tbApiService.Location = New System.Drawing.Point(6, 19)
        Me.tbApiService.Name = "tbApiService"
        Me.tbApiService.ReadOnly = True
        Me.tbApiService.Size = New System.Drawing.Size(185, 20)
        Me.tbApiService.TabIndex = 13
        Me.tbApiService.Tag = ""
        '
        'btnApiServiceSS
        '
        Me.btnApiServiceSS.Location = New System.Drawing.Point(197, 16)
        Me.btnApiServiceSS.Name = "btnApiServiceSS"
        Me.btnApiServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnApiServiceSS.TabIndex = 14
        Me.btnApiServiceSS.Tag = ""
        Me.btnApiServiceSS.Text = "Start"
        Me.btnApiServiceSS.UseVisualStyleBackColor = True
        '
        'gpCoreService
        '
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
        Me.btnCoreServiceRS.Tag = ""
        Me.btnCoreServiceRS.Text = "Restart"
        Me.btnCoreServiceRS.UseVisualStyleBackColor = True
        '
        'tbCoreService
        '
        Me.tbCoreService.Location = New System.Drawing.Point(6, 19)
        Me.tbCoreService.Name = "tbCoreService"
        Me.tbCoreService.ReadOnly = True
        Me.tbCoreService.Size = New System.Drawing.Size(185, 20)
        Me.tbCoreService.TabIndex = 13
        Me.tbCoreService.Tag = ""
        '
        'btnCoreServiceSS
        '
        Me.btnCoreServiceSS.Location = New System.Drawing.Point(197, 16)
        Me.btnCoreServiceSS.Name = "btnCoreServiceSS"
        Me.btnCoreServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnCoreServiceSS.TabIndex = 14
        Me.btnCoreServiceSS.Tag = ""
        Me.btnCoreServiceSS.Text = "Start"
        Me.btnCoreServiceSS.UseVisualStyleBackColor = True
        '
        'gpCloudService
        '
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
        Me.btnCloudServiceRS.Tag = ""
        Me.btnCloudServiceRS.Text = "Restart"
        Me.btnCloudServiceRS.UseVisualStyleBackColor = True
        '
        'tbCloudService
        '
        Me.tbCloudService.Location = New System.Drawing.Point(6, 17)
        Me.tbCloudService.Name = "tbCloudService"
        Me.tbCloudService.ReadOnly = True
        Me.tbCloudService.Size = New System.Drawing.Size(185, 20)
        Me.tbCloudService.TabIndex = 16
        Me.tbCloudService.Tag = ""
        '
        'btnCloudServiceSS
        '
        Me.btnCloudServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnCloudServiceSS.Name = "btnCloudServiceSS"
        Me.btnCloudServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnCloudServiceSS.TabIndex = 17
        Me.btnCloudServiceSS.Tag = ""
        Me.btnCloudServiceSS.Text = "Start"
        Me.btnCloudServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvCreditService
        '
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
        Me.btnAdvCreditServiceRS.Tag = ""
        Me.btnAdvCreditServiceRS.Text = "Restart"
        Me.btnAdvCreditServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvCreditService
        '
        Me.tbAdvCreditService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvCreditService.Name = "tbAdvCreditService"
        Me.tbAdvCreditService.ReadOnly = True
        Me.tbAdvCreditService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvCreditService.TabIndex = 16
        Me.tbAdvCreditService.Tag = ""
        '
        'btnAdvCreditServiceSS
        '
        Me.btnAdvCreditServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvCreditServiceSS.Name = "btnAdvCreditServiceSS"
        Me.btnAdvCreditServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvCreditServiceSS.TabIndex = 17
        Me.btnAdvCreditServiceSS.Tag = ""
        Me.btnAdvCreditServiceSS.Text = "Start"
        Me.btnAdvCreditServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvSignageService
        '
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
        Me.btnAdvSignageServiceRS.Tag = ""
        Me.btnAdvSignageServiceRS.Text = "Restart"
        Me.btnAdvSignageServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvSignageService
        '
        Me.tbAdvSignageService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvSignageService.Name = "tbAdvSignageService"
        Me.tbAdvSignageService.ReadOnly = True
        Me.tbAdvSignageService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvSignageService.TabIndex = 16
        Me.tbAdvSignageService.Tag = ""
        '
        'btnAdvSignageServiceSS
        '
        Me.btnAdvSignageServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvSignageServiceSS.Name = "btnAdvSignageServiceSS"
        Me.btnAdvSignageServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvSignageServiceSS.TabIndex = 17
        Me.btnAdvSignageServiceSS.Tag = ""
        Me.btnAdvSignageServiceSS.Text = "Start"
        Me.btnAdvSignageServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvLicService
        '
        Me.gpAdvLicService.Controls.Add(Me.btnAdvLicServiceRS)
        Me.gpAdvLicService.Controls.Add(Me.tbAdvLicService)
        Me.gpAdvLicService.Controls.Add(Me.btnAdvLicServiceSS)
        Me.gpAdvLicService.Location = New System.Drawing.Point(371, 3)
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
        Me.btnAdvLicServiceRS.Tag = ""
        Me.btnAdvLicServiceRS.Text = "Restart"
        Me.btnAdvLicServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvLicService
        '
        Me.tbAdvLicService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvLicService.Name = "tbAdvLicService"
        Me.tbAdvLicService.ReadOnly = True
        Me.tbAdvLicService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvLicService.TabIndex = 16
        Me.tbAdvLicService.Tag = ""
        '
        'btnAdvLicServiceSS
        '
        Me.btnAdvLicServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvLicServiceSS.Name = "btnAdvLicServiceSS"
        Me.btnAdvLicServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvLicServiceSS.TabIndex = 17
        Me.btnAdvLicServiceSS.Tag = ""
        Me.btnAdvLicServiceSS.Text = "Start"
        Me.btnAdvLicServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvNotifyService
        '
        Me.gpAdvNotifyService.Controls.Add(Me.btnAdvNotifyServiceRS)
        Me.gpAdvNotifyService.Controls.Add(Me.tbAdvNotifyService)
        Me.gpAdvNotifyService.Controls.Add(Me.btnAdvNotifyServiceSS)
        Me.gpAdvNotifyService.Location = New System.Drawing.Point(371, 58)
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
        Me.btnAdvNotifyServiceRS.Tag = ""
        Me.btnAdvNotifyServiceRS.Text = "Restart"
        Me.btnAdvNotifyServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvNotifyService
        '
        Me.tbAdvNotifyService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvNotifyService.Name = "tbAdvNotifyService"
        Me.tbAdvNotifyService.ReadOnly = True
        Me.tbAdvNotifyService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvNotifyService.TabIndex = 16
        Me.tbAdvNotifyService.Tag = ""
        '
        'btnAdvNotifyServiceSS
        '
        Me.btnAdvNotifyServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvNotifyServiceSS.Name = "btnAdvNotifyServiceSS"
        Me.btnAdvNotifyServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvNotifyServiceSS.TabIndex = 17
        Me.btnAdvNotifyServiceSS.Tag = ""
        Me.btnAdvNotifyServiceSS.Text = "Start"
        Me.btnAdvNotifyServiceSS.UseVisualStyleBackColor = True
        '
        'gpAdvTurnstileEngine
        '
        Me.gpAdvTurnstileEngine.Controls.Add(Me.btnAdvTurnstileEngineRS)
        Me.gpAdvTurnstileEngine.Controls.Add(Me.tbAdvTurnstileEngine)
        Me.gpAdvTurnstileEngine.Controls.Add(Me.btnAdvTurnstileEngineSS)
        Me.gpAdvTurnstileEngine.Location = New System.Drawing.Point(371, 113)
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
        Me.btnAdvTurnstileEngineRS.Tag = ""
        Me.btnAdvTurnstileEngineRS.Text = "Restart"
        Me.btnAdvTurnstileEngineRS.UseVisualStyleBackColor = True
        '
        'tbAdvTurnstileEngine
        '
        Me.tbAdvTurnstileEngine.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvTurnstileEngine.Name = "tbAdvTurnstileEngine"
        Me.tbAdvTurnstileEngine.ReadOnly = True
        Me.tbAdvTurnstileEngine.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvTurnstileEngine.TabIndex = 16
        Me.tbAdvTurnstileEngine.Tag = ""
        '
        'btnAdvTurnstileEngineSS
        '
        Me.btnAdvTurnstileEngineSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvTurnstileEngineSS.Name = "btnAdvTurnstileEngineSS"
        Me.btnAdvTurnstileEngineSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvTurnstileEngineSS.TabIndex = 17
        Me.btnAdvTurnstileEngineSS.Tag = ""
        Me.btnAdvTurnstileEngineSS.Text = "Start"
        Me.btnAdvTurnstileEngineSS.UseVisualStyleBackColor = True
        '
        'gpAdvantageUpgradeService
        '
        Me.gpAdvantageUpgradeService.Controls.Add(Me.btnAdvantageUpgradeServiceRS)
        Me.gpAdvantageUpgradeService.Controls.Add(Me.tbAdvantageUpgradeService)
        Me.gpAdvantageUpgradeService.Controls.Add(Me.btnAdvantageUpgradeServiceSS)
        Me.gpAdvantageUpgradeService.Location = New System.Drawing.Point(371, 168)
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
        Me.btnAdvantageUpgradeServiceRS.Tag = ""
        Me.btnAdvantageUpgradeServiceRS.Text = "Restart"
        Me.btnAdvantageUpgradeServiceRS.UseVisualStyleBackColor = True
        '
        'tbAdvantageUpgradeService
        '
        Me.tbAdvantageUpgradeService.Location = New System.Drawing.Point(6, 17)
        Me.tbAdvantageUpgradeService.Name = "tbAdvantageUpgradeService"
        Me.tbAdvantageUpgradeService.ReadOnly = True
        Me.tbAdvantageUpgradeService.Size = New System.Drawing.Size(185, 20)
        Me.tbAdvantageUpgradeService.TabIndex = 16
        Me.tbAdvantageUpgradeService.Tag = ""
        '
        'btnAdvantageUpgradeServiceSS
        '
        Me.btnAdvantageUpgradeServiceSS.Location = New System.Drawing.Point(197, 14)
        Me.btnAdvantageUpgradeServiceSS.Name = "btnAdvantageUpgradeServiceSS"
        Me.btnAdvantageUpgradeServiceSS.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvantageUpgradeServiceSS.TabIndex = 17
        Me.btnAdvantageUpgradeServiceSS.Tag = ""
        Me.btnAdvantageUpgradeServiceSS.Text = "Start"
        Me.btnAdvantageUpgradeServiceSS.UseVisualStyleBackColor = True
        '
        'gpLicInfo
        '
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
        Me.gpLicInfo.Location = New System.Drawing.Point(511, 3)
        Me.gpLicInfo.Name = "gpLicInfo"
        Me.gpLicInfo.Size = New System.Drawing.Size(432, 195)
        Me.gpLicInfo.TabIndex = 10
        Me.gpLicInfo.TabStop = False
        Me.gpLicInfo.Text = "License Info"
        '
        'tbShiftDate
        '
        Me.tbShiftDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbShiftDate.Location = New System.Drawing.Point(101, 126)
        Me.tbShiftDate.Name = "tbShiftDate"
        Me.tbShiftDate.Size = New System.Drawing.Size(325, 20)
        Me.tbShiftDate.TabIndex = 11
        '
        'tbLocName
        '
        Me.tbLocName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLocName.Location = New System.Drawing.Point(101, 16)
        Me.tbLocName.Name = "tbLocName"
        Me.tbLocName.Size = New System.Drawing.Size(325, 20)
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
        Me.lblShiftDate.Location = New System.Drawing.Point(7, 130)
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
        Me.tbCoreSvr.Size = New System.Drawing.Size(325, 20)
        Me.tbCoreSvr.TabIndex = 5
        '
        'tbLicSvr
        '
        Me.tbLicSvr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLicSvr.Location = New System.Drawing.Point(101, 37)
        Me.tbLicSvr.Name = "tbLicSvr"
        Me.tbLicSvr.Size = New System.Drawing.Size(325, 20)
        Me.tbLicSvr.TabIndex = 3
        '
        'tbWebEnabled
        '
        Me.tbWebEnabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbWebEnabled.Location = New System.Drawing.Point(101, 103)
        Me.tbWebEnabled.Name = "tbWebEnabled"
        Me.tbWebEnabled.Size = New System.Drawing.Size(325, 20)
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
        Me.tbDbVer.Size = New System.Drawing.Size(325, 20)
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
        Me.gpPfsConnect.Controls.Add(Me.dgvPFSConnect)
        Me.gpPfsConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPfsConnect.Location = New System.Drawing.Point(231, 3)
        Me.gpPfsConnect.Name = "gpPfsConnect"
        Me.gpPfsConnect.Size = New System.Drawing.Size(274, 195)
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
        Me.dgvPFSConnect.Size = New System.Drawing.Size(268, 176)
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
        'tpDbInfo
        '
        Me.tpDbInfo.Controls.Add(Me.pnlDbInfoButtons)
        Me.tpDbInfo.Controls.Add(Me.pnlDbData)
        Me.tpDbInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpDbInfo.Name = "tpDbInfo"
        Me.tpDbInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDbInfo.Size = New System.Drawing.Size(1253, 537)
        Me.tpDbInfo.TabIndex = 1
        Me.tpDbInfo.Text = "DB Information"
        Me.tpDbInfo.UseVisualStyleBackColor = True
        '
        'pnlDbInfoButtons
        '
        Me.pnlDbInfoButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDbInfoButtons.Controls.Add(Me.rbDbDeadlocks)
        Me.pnlDbInfoButtons.Controls.Add(Me.rbDbSizeByDay)
        Me.pnlDbInfoButtons.Controls.Add(Me.btnDbInfoRefresh)
        Me.pnlDbInfoButtons.Controls.Add(Me.rbDbFragmentation)
        Me.pnlDbInfoButtons.Controls.Add(Me.rbDbTableSize)
        Me.pnlDbInfoButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDbInfoButtons.Location = New System.Drawing.Point(3, 506)
        Me.pnlDbInfoButtons.Name = "pnlDbInfoButtons"
        Me.pnlDbInfoButtons.Size = New System.Drawing.Size(1247, 28)
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
        Me.btnDbInfoRefresh.Location = New System.Drawing.Point(1180, 2)
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
        Me.pnlDbData.Size = New System.Drawing.Size(1250, 447)
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
        Me.dgvDbTableSize.Size = New System.Drawing.Size(1250, 447)
        Me.dgvDbTableSize.TabIndex = 0
        '
        'tbDbLogs
        '
        Me.tbDbLogs.Controls.Add(Me.gpDbLogData)
        Me.tbDbLogs.Controls.Add(Me.gpDbLogCount)
        Me.tbDbLogs.Controls.Add(Me.pnlDbLogs)
        Me.tbDbLogs.Location = New System.Drawing.Point(4, 22)
        Me.tbDbLogs.Name = "tbDbLogs"
        Me.tbDbLogs.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDbLogs.Size = New System.Drawing.Size(1253, 537)
        Me.tbDbLogs.TabIndex = 2
        Me.tbDbLogs.Text = "CE DB Logs"
        Me.tbDbLogs.UseVisualStyleBackColor = True
        '
        'gpDbLogData
        '
        Me.gpDbLogData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpDbLogData.Controls.Add(Me.dgvDbLogData)
        Me.gpDbLogData.Location = New System.Drawing.Point(340, 3)
        Me.gpDbLogData.Name = "gpDbLogData"
        Me.gpDbLogData.Size = New System.Drawing.Size(907, 380)
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
        Me.dgvDbLogData.Size = New System.Drawing.Size(901, 361)
        Me.dgvDbLogData.TabIndex = 2
        '
        'gpDbLogCount
        '
        Me.gpDbLogCount.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpDbLogCount.Controls.Add(Me.dgvDbLogCount)
        Me.gpDbLogCount.Location = New System.Drawing.Point(9, 3)
        Me.gpDbLogCount.Name = "gpDbLogCount"
        Me.gpDbLogCount.Size = New System.Drawing.Size(325, 380)
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
        Me.dgvDbLogCount.Size = New System.Drawing.Size(319, 361)
        Me.dgvDbLogCount.TabIndex = 1
        '
        'pnlDbLogs
        '
        Me.pnlDbLogs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDbLogs.Controls.Add(Me.gpMessageLogFilters)
        Me.pnlDbLogs.Controls.Add(Me.btnDbLogRefresh)
        Me.pnlDbLogs.Controls.Add(Me.rbMessageLog)
        Me.pnlDbLogs.Controls.Add(Me.rbWebCloudUpdates)
        Me.pnlDbLogs.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDbLogs.Location = New System.Drawing.Point(3, 407)
        Me.pnlDbLogs.Name = "pnlDbLogs"
        Me.pnlDbLogs.Size = New System.Drawing.Size(1247, 127)
        Me.pnlDbLogs.TabIndex = 0
        '
        'gpMessageLogFilters
        '
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
        Me.btnDbLogRefresh.Location = New System.Drawing.Point(1169, 3)
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
        Me.tpStParse.Size = New System.Drawing.Size(1253, 537)
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
        Me.Panel1.Location = New System.Drawing.Point(1164, 6)
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
        Me.tbSTParse.Size = New System.Drawing.Size(1108, 435)
        Me.tbSTParse.TabIndex = 2
        '
        'tbTest3
        '
        Me.tbTest3.Location = New System.Drawing.Point(345, 32)
        Me.tbTest3.Name = "tbTest3"
        Me.tbTest3.Size = New System.Drawing.Size(275, 20)
        Me.tbTest3.TabIndex = 14
        Me.tbTest3.Text = "tbTest3"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(1028, 29)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 1
        Me.btnTest.Text = "Test Button"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'tbTest2
        '
        Me.tbTest2.Location = New System.Drawing.Point(13, 32)
        Me.tbTest2.Name = "tbTest2"
        Me.tbTest2.Size = New System.Drawing.Size(275, 20)
        Me.tbTest2.TabIndex = 13
        Me.tbTest2.Text = "tbTest2"
        '
        'btnCenterEdgeConfig
        '
        Me.btnCenterEdgeConfig.Location = New System.Drawing.Point(849, 8)
        Me.btnCenterEdgeConfig.Name = "btnCenterEdgeConfig"
        Me.btnCenterEdgeConfig.Size = New System.Drawing.Size(80, 44)
        Me.btnCenterEdgeConfig.TabIndex = 12
        Me.btnCenterEdgeConfig.Text = "CenterEdge Configuration"
        Me.btnCenterEdgeConfig.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(935, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Login using SQL Credentials"
        '
        'tbTest1
        '
        Me.tbTest1.Location = New System.Drawing.Point(13, 6)
        Me.tbTest1.Name = "tbTest1"
        Me.tbTest1.Size = New System.Drawing.Size(830, 20)
        Me.tbTest1.TabIndex = 3
        Me.tbTest1.Text = "tbTest1"
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(1081, 4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 10
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblCeVersion, Me.tslblTime, Me.tslblNetVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 625)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1265, 24)
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
        Me.tmr1Sec.Interval = 1000
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1265, 649)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "MainForm"
        Me.Text = "Support Tech Assistant"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tcSTA.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.tpGeneral.PerformLayout()
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
        Me.tpDbInfo.ResumeLayout(False)
        Me.pnlDbInfoButtons.ResumeLayout(False)
        Me.pnlDbInfoButtons.PerformLayout()
        Me.pnlDbData.ResumeLayout(False)
        CType(Me.dgvDbTableSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDbLogs.ResumeLayout(False)
        Me.gpDbLogData.ResumeLayout(False)
        CType(Me.dgvDbLogData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDbLogCount.ResumeLayout(False)
        CType(Me.dgvDbLogCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDbLogs.ResumeLayout(False)
        Me.pnlDbLogs.PerformLayout()
        Me.gpMessageLogFilters.ResumeLayout(False)
        Me.gpMessageLogFilters.PerformLayout()
        CType(Me.nudMsgLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStParse.ResumeLayout(False)
        Me.tpStParse.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As Button
    Friend WithEvents btnUnlockAdminAccount As Button
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
    Friend WithEvents tbDbLogs As TabPage
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
    Friend WithEvents tbMLTest1 As TextBox
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
End Class
