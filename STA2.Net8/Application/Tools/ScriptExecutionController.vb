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
    options As ScriptCommandOptions,
    triggerButton As Button,
    runningStatusText As String
) As Task

        _scriptRunning = True
        _statusLocked = True

        _form.SetExecutionStatusProxy(runningStatusText, force:=True)

        If triggerButton IsNot Nothing Then
            triggerButton.Enabled = False
        End If

        _form.RefreshUIProxy()

        Try
            If options Is Nothing OrElse
           String.IsNullOrWhiteSpace(options.ScriptPath) Then

                MessageBox.Show(
                "Please select a script first.",
                "Missing Script",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
                Return
            End If

            ' ✅ Switch tab
            _form.tcSTA.SelectedTab = _form.tpGeneral
            Await Task.Yield()
            _liveOutputManager.ForceRedraw()

            ' ✅ Build args via model
            Dim commandLine As String = BuildCommandLine(options)

            ' Extract scriptArgs (temporary for your existing runner)
            Dim scriptArgsStart =
            commandLine.IndexOf("""", commandLine.IndexOf("""") + 1) + 1

            Dim scriptArgs As String =
            commandLine.Substring(scriptArgsStart).Trim()

            Await PowerShellRunner.RunLiveScriptAsync(
            options:=_options,
            liveOutputManager:=_liveOutputManager,
            setStatus:=Sub(text)
                           _form.SetExecutionStatusProxy(text, force:=True)
                       End Sub,
            scriptRelativePath:=options.ScriptPath,
            scriptArgs:=scriptArgs,
            runningStatusText:=runningStatusText
        )

        Finally
            _scriptRunning = False
            _statusLocked = False

            If triggerButton IsNot Nothing Then
                triggerButton.Enabled = True
            End If

            _form.SetExecutionStatusProxy(String.Empty, force:=True)
            _form.RefreshUIProxy()
        End Try

    End Function
    Public Function BuildCommandLine(options As ScriptCommandOptions) As String

        If options Is Nothing OrElse
           String.IsNullOrWhiteSpace(options.ScriptPath) Then
            Return String.Empty
        End If

        Dim scriptArgs As String = "-Force"

        If Not String.IsNullOrWhiteSpace(options.OverrideArgs) Then
            scriptArgs &= " " & options.OverrideArgs

        Else
            If options.FlavorNames IsNot Nothing Then
                Dim flavorArgs = CodeHelper.BuildFlavorsArgument(options.FlavorNames)
                If Not String.IsNullOrWhiteSpace(flavorArgs) Then
                    scriptArgs &= " " & flavorArgs
                End If
            End If
        End If

        If options.UseVersion Then
            Dim versionText = options.VersionText?.Trim()
            If Not String.IsNullOrWhiteSpace(versionText) Then
                scriptArgs &= $" -Version ""{versionText}"""
            End If
        End If

        Dim cmd =
            $"powershell -ExecutionPolicy Bypass -File ""{options.ScriptPath}"" {scriptArgs}"

        Return cmd.Trim()

    End Function
End Class
