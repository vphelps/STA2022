Public Module PromptDefaultsRegistrar

    Public Sub RegisterAll(
        form As FormMain,
        options As AppOptions
    )

        RegisterRepoMain(form, options)
        RegisterRepoDiscardChanges(form, options)

        ' ✅ Add more here later:
        ' RegisterRunQaApi(form, options)
        ' RegisterDatabaseStart(form, options)

    End Sub

    Private Sub RegisterRepoMain(
        form As FormMain,
        options As AppOptions
    )

        Dim configure As Action(Of PromptDefaultsForm) =
            Sub(dlg)

                dlg.Text = "Repository Action Defaults"
                dlg.YesText = "Discard changes automatically"
                dlg.NoText = "Do not discard (ask each time)"

                dlg.PromptEnabled = options.RepoMainPromptEnabled
                dlg.TimeoutSeconds = options.RepoMainPromptTimeoutSeconds
                dlg.IsYesSelected = options.RepoMainPromptAction

            End Sub

        Dim save As Action(Of PromptDefaultsForm) =
            Sub(dlg)

                form.UpdateOption(Sub()
                                      options.RepoMainPromptAction = dlg.IsYesSelected
                                      options.RepoMainPromptTimeoutSeconds = dlg.TimeoutSeconds
                                      options.RepoMainPromptEnabled = dlg.PromptEnabled
                                  End Sub)

            End Sub

        CodeHelper.AttachPromptDefaultsMenu(
            form.btnRepoMain,
            form,
            configure,
            save)

    End Sub
    Private Sub RegisterRepoDiscardChanges(
    form As FormMain,
    options As AppOptions
)

        Dim configure As Action(Of PromptDefaultsForm) =
            Sub(dlg)

                dlg.Text = "Discard Changes Defaults"
                dlg.YesText = "Discard changes automatically"
                dlg.NoText = "Do not discard (prompt each time)"

                dlg.PromptEnabled = options.RepoDiscardPromptEnabled
                dlg.TimeoutSeconds = options.RepoDiscardPromptTimeoutSeconds
                dlg.IsYesSelected = options.RepoDiscardPromptAction

            End Sub

        Dim save As Action(Of PromptDefaultsForm) =
            Sub(dlg)

                form.UpdateOption(Sub()
                                      options.RepoDiscardPromptAction = dlg.IsYesSelected
                                      options.RepoDiscardPromptTimeoutSeconds = dlg.TimeoutSeconds
                                      options.RepoDiscardPromptEnabled = dlg.PromptEnabled
                                  End Sub)

            End Sub

        CodeHelper.AttachPromptDefaultsMenu(
            form.btnRepoDiscardChanges,
            form,
            configure,
            save)

    End Sub
End Module