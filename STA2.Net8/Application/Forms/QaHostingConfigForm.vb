Imports System.ComponentModel

Public Class QaHostingConfigForm

    Private ReadOnly _options As AppOptions

    Public Sub New(options As AppOptions)

        InitializeComponent()

        _options = options

    End Sub
    Private Sub UpdateUiForHostingMode()

        Dim mode = CType(cmbQaHostingMode.SelectedItem, QaHostingMode)

        cbQaScriptStartWithApp.Enabled = mode = QaHostingMode.Script
        chkQaStartServiceWithApp.Enabled = mode = QaHostingMode.Service

    End Sub
    Private Sub QaHostingConfigForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbQaScriptStartWithApp.Checked = _options.QaScriptStartWithApp

        cmbQaHostingMode.DataSource = [Enum].GetValues(GetType(QaHostingMode))
        cmbQaHostingMode.SelectedItem = _options.QaHostingMode
        chkQaStartServiceWithApp.Checked = _options.QaStartServiceWithApp
        nudQaScriptStartupTimeoutSeconds.Value = _options.QaScriptStartupTimeoutSeconds

    End Sub

    Private Sub rbQaServiceYes_CheckedChanged(sender As Object, e As EventArgs)
        If _options Is Nothing Then Return ' Constructor hasn't finished; ignore events fired during InitializeComponent

    End Sub

    Private Sub cbQaScriptStartWithApp_CheckedChanged(sender As Object, e As EventArgs) Handles cbQaScriptStartWithApp.CheckedChanged
        _options.QaScriptStartWithApp = cbQaScriptStartWithApp.Checked

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        _options.QaHostingMode = CType(cmbQaHostingMode.SelectedItem, QaHostingMode)
        _options.QaStartServiceWithApp = chkQaStartServiceWithApp.Checked
        _options.QaScriptStartupTimeoutSeconds = CInt(nudQaScriptStartupTimeoutSeconds.Value)

        OptionsManager.Save(_options)

        Me.Close()

    End Sub

    Private Sub cmbQaHostingMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbQaHostingMode.SelectedIndexChanged
        UpdateUiForHostingMode()

    End Sub

End Class