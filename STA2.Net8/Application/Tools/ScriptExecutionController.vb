Public Class ScriptExecutionController

    Private ReadOnly _form As FormMain
    Private ReadOnly _options As AppOptions
    Private ReadOnly _liveOutputManager As LiveOutputManager

    Private _scriptRunning As Boolean = False
    Private _statusLocked As Boolean = False

    Public Sub New(
        form As FormMain,
        options As AppOptions,
        liveOutputManager As LiveOutputManager
    )
        _form = form
        _options = options
        _liveOutputManager = liveOutputManager
    End Sub

    Public Function IsRunning() As Boolean
        Return _scriptRunning
    End Function

    Public Async Function RunAsync(
        scriptPath As String,
        triggerButton As Button,
        runningStatusText As String,
        Optional overrideArgs As String = Nothing,
        Optional flavorNames As IEnumerable(Of String) = Nothing
    ) As Task

        _scriptRunning = True
        _statusLocked = True

        ' ✅ Set initial running status (FORCED)
        _form.SetExecutionStatusProxy(runningStatusText, force:=True)

        If triggerButton IsNot Nothing Then
            triggerButton.Enabled = False
        End If

        _form.RefreshUIProxy()

        Try
            If String.IsNullOrWhiteSpace(scriptPath) Then
                MessageBox.Show(
                    "Please select a script first.",
                    "Missing Script",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
                Return
            End If

            ' ✅ Always switch to output tab
            _form.tcSTA.SelectedTab = _form.tpGeneral

            ' ✅ Let UI settle
            Await Task.Yield()

            _liveOutputManager.ForceRedraw()

            Dim flags As String = "-Force"
            Dim scriptArgs As String

            If Not String.IsNullOrWhiteSpace(overrideArgs) Then
                scriptArgs = $"{flags} {overrideArgs}".Trim()
            Else
                Dim flavorArgs As String =
                    If(flavorNames IsNot Nothing,
                       CodeHelper.BuildFlavorsArgument(flavorNames),
                       "")

                scriptArgs = $"{flags} {flavorArgs}".Trim()
            End If

            Await PowerShellRunner.RunLiveScriptAsync(
                options:=_options,
                liveOutputManager:=_liveOutputManager,
                setStatus:=Sub(text)
                               ' ✅ ALWAYS force updates during execution
                               _form.SetExecutionStatusProxy(text, force:=True)
                           End Sub,
                scriptRelativePath:=scriptPath,
                scriptArgs:=scriptArgs,
                runningStatusText:=runningStatusText
            )

        Finally

            _scriptRunning = False
            _statusLocked = False

            ' ✅ Re-enable UI trigger
            If triggerButton IsNot Nothing Then
                triggerButton.Enabled = True
            End If

            ' ✅ CLEAR status explicitly (FORCED)
            _form.SetExecutionStatusProxy(String.Empty, force:=True)

            _form.RefreshUIProxy()

        End Try

    End Function

End Class
