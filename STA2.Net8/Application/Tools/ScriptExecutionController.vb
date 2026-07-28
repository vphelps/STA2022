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
        Dim strTemp As String = ""
        Dim startTime As DateTime = DateTime.Now
        Dim endTime As DateTime

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

            Dim scriptArgs As String
            ' ✅ Build args

            scriptArgs = BuildScriptArgs(options)

            ' ✅ Build full command (for logging)
            Dim fullCommandLine As String = BuildCommandLine(options)

            Try
                ' ✅ Execute script
                startTime = DateTime.Now
                strTemp = $"Script started at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{Environment.NewLine}"

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

                ' ✅ SUCCESS LOG
                endTime = DateTime.Now
                Dim seconds As Double = (endTime - startTime).TotalSeconds
                strTemp &= $"Script completed successfully at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} (Duration: {seconds:F2} seconds)"
                STA2.Net8.GlobalErrorHandler.LogScriptResult(
                commandLine:=fullCommandLine,
                scriptPath:=options.ScriptPath,
                scriptArgs:=scriptArgs,
                success:=True,
                Prefix:=strTemp
            )

            Catch ex As Exception

                ' ✅ FAILURE LOG
                GlobalErrorHandler.LogScriptResult(
                commandLine:=fullCommandLine,
                scriptPath:=options.ScriptPath,
                scriptArgs:=scriptArgs,
                success:=False,
                ex:=ex
            )

                Throw

            End Try

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
    Public Function BuildCommandLine(options As ScriptCommandOptions, Optional useVersion As Boolean = False) As String
        Dim args = BuildScriptArgs(options)
        Return $"powershell -ExecutionPolicy Bypass -File ""{options.ScriptPath}"" {args}".Trim()
    End Function

    Public Function BuildScriptArgs(options As ScriptCommandOptions) As String

        If options Is Nothing Then Return String.Empty

        Dim args As New List(Of ScriptArgument)

        ' ✅ Always include -Force 
        args.Add(New ScriptArgument("-Force"))

        ' ✅ Override takes priority
        If Not String.IsNullOrWhiteSpace(options.OverrideArgs) Then
            ' fallback: raw append if needed
            Return $"{String.Join(" ", args)} {options.OverrideArgs}".Trim()
        End If

        ' ✅ Flavors
        If options.FlavorNames IsNot Nothing Then
            Dim flavorCsv = String.Join(",", options.FlavorNames)

            If Not String.IsNullOrWhiteSpace(flavorCsv) Then
                args.Add(New ScriptArgument("-Flavors", flavorCsv))
            End If
        End If

        ' ✅ Version
        If options.UseVersion Then
            Dim versionText = options.VersionText?.Trim()

            If Not String.IsNullOrWhiteSpace(versionText) Then
                args.Add(New ScriptArgument("-Version", versionText))
            End If
        End If

        ' ✅ Convert to string safely
        Return String.Join(" ", args.Select(Function(a) a.ToString()))

    End Function
End Class
