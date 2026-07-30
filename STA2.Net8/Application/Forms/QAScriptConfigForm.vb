Public Class QAScriptConfigForm

    Private ReadOnly _options As AppOptions

    Public Sub New(options As AppOptions)

        InitializeComponent()

        _options = options

    End Sub
    Private Sub QAScriptConfigForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbQaServiceAllow.Checked = _options.QaApiAllowService

    End Sub

    Private Sub rbQaServiceYes_CheckedChanged(sender As Object, e As EventArgs) Handles rbQaServiceAllow.CheckedChanged, rbQaServiceDeny.CheckedChanged
        If _options Is Nothing Then Return ' Constructor hasn't finished; ignore events fired during InitializeComponent


        _options.QaApiAllowService = rbQaServiceAllow.Checked


        lblTest1.Text = $"QA API Allow Service: {_options.QaApiAllowService.ToString}"
        OptionsManager.Save(_options)



    End Sub

End Class