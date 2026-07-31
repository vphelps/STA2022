Imports System.ComponentModel

Public Class QAScriptConfigForm

    Private ReadOnly _options As AppOptions

    Public Sub New(options As AppOptions)

        InitializeComponent()

        _options = options

    End Sub
    Private Sub QAScriptConfigForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbQaServiceAllow.Checked = _options.QaApiAllowService
        cbQaScriptStartWithApp.Checked = _options.QaScriptStartWithApp

    End Sub

    Private Sub rbQaServiceYes_CheckedChanged(sender As Object, e As EventArgs) Handles rbQaServiceAllow.CheckedChanged, rbQaServiceDeny.CheckedChanged
        If _options Is Nothing Then Return ' Constructor hasn't finished; ignore events fired during InitializeComponent

        _options.QaApiAllowService = rbQaServiceAllow.Checked
    End Sub

    Private Sub cbQaScriptStartWithApp_CheckedChanged(sender As Object, e As EventArgs) Handles cbQaScriptStartWithApp.CheckedChanged
        _options.QaScriptStartWithApp = cbQaScriptStartWithApp.Checked

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        OptionsManager.Save(_options)
        Me.Close()

    End Sub
End Class