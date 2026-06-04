Public Class UIStateController

    Private ReadOnly _form As FormMain
    Private ReadOnly _options As AppOptions

    Public Sub New(form As FormMain, options As AppOptions)
        _form = form
        _options = options
    End Sub

    Public Sub Refresh()

        Dim scriptRunning As Boolean = _form.IsScriptRunning()

        ' ----------------------------
        ' Executable buttons
        ' ----------------------------
        _form.btnAdvUpgrade.Visible = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvUpgrade"))
        _form.btnAdvRedeem.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvRedeem"))
        _form.btnAdvCardTech.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvCardTech"))
        _form.btnAdvReportEditor.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvReportEditor"))
        _form.btnAdvManager.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvManager"))
        _form.btnPos.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("Pos"))
        _form.btnAdvGroups.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvGroups"))
        _form.btnAdvKioskSetup.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvKioskSetup"))
        _form.btnAdvKiosk.Enabled = Convert.ToBoolean(CodeHelper.AdvExeCheck("AdvKiosk"))

        ' ----------------------------
        ' Repo buttons
        ' ----------------------------
        Dim hasRepo As Boolean =
            _options IsNot Nothing AndAlso
            Not String.IsNullOrWhiteSpace(_options.RepoFolderPath)

        _form.btnRepoMain.Enabled = hasRepo
        _form.btnRepoDiscardChanges.Enabled = hasRepo

        ' ----------------------------
        ' Script buttons
        ' ----------------------------
        Dim canRunDbStart =
            Not scriptRunning AndAlso
            _options IsNot Nothing AndAlso
            Not String.IsNullOrWhiteSpace(_options.StartDatabaseDefault)

        _form.btnRunDatabaseStartLive.Enabled = canRunDbStart

        Dim canApplyFlavors =
            Not scriptRunning AndAlso
            _options IsNot Nothing AndAlso
            Not String.IsNullOrWhiteSpace(_options.ApplyFlavorDefault)

        _form.btnRunApplyFlavorLive.Enabled = canApplyFlavors
        _form.tsmiApplyDefaultFlavors.Enabled = canApplyFlavors
        _form.gbFlavorsList.Enabled = canApplyFlavors

        ' ----------------------------
        ' Text sync (safe)
        ' ----------------------------
        If _options IsNot Nothing AndAlso Not _form.tbSetupSwitches.Focused Then
            _form.tbSetupSwitches.Text = _options.SetupSwitches
        End If

        ' ----------------------------
        ' Version info
        ' ----------------------------
        Dim info = ServiceIntrospection.GetServiceFileInfo("AdvCoreService")

        _form.tslblCeVersion.Text =
            "Software Version:  " & info.Version &
            " | Database Version:  " & PCInfo.DatabaseVersion

        _form.tslblTime.Text =
            DateTime.Now.ToShortDateString() & " " &
            DateTime.Now.ToShortTimeString()

        _form.tslblNetVersion.Text = PCInfo.FrameworkVersion

        ' ----------------------------
        ' Version mismatch coloring
        ' ----------------------------
        If _form.tbDbVer.Text.Equals(_form.tbPcAdvVersion.Text) Then

            _form.tbDbVer.BackColor = TextboxColors.White
            _form.tbDbVer.ForeColor = TextboxColors.Black
            _form.tbPcAdvVersion.BackColor = TextboxColors.White
            _form.tbPcAdvVersion.ForeColor = TextboxColors.Black
            _form.tslblCeVersion.BackColor = TextboxColors.Control

        Else

            _form.tbDbVer.BackColor = TextboxColors.Red
            _form.tbDbVer.ForeColor = TextboxColors.White
            _form.tbPcAdvVersion.BackColor = TextboxColors.Red
            _form.tbPcAdvVersion.ForeColor = TextboxColors.White
            _form.tslblCeVersion.BackColor = TextboxColors.Red

        End If

        Dim now As DateTime = DateTime.Now.Date
        Dim shiftDate As DateTime
        _form.tbTest3.Text = DateTime.TryParse(_form.tbShiftDate.Text, shiftDate).ToString
        ' ✅ Validate input first
        If DateTime.TryParse(_form.tbShiftDate.Text, shiftDate) Then

            _form.tbTest1.Text = now.ToString
            _form.tbTest2.Text = shiftDate.ToString
            If now.Date <> shiftDate.Date Then
                _form.tbShiftDate.BackColor = TextboxColors.Red
                _form.tbShiftDate.ForeColor = TextboxColors.White
            Else
                _form.tbShiftDate.BackColor = TextboxColors.White
                _form.tbShiftDate.ForeColor = TextboxColors.Black
            End If
        End If


    End Sub

End Class