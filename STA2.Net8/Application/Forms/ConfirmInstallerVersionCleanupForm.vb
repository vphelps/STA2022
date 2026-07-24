Public Class ConfirmInstallerVersionCleanupForm

    Private ReadOnly _versionsToDelete As List(Of InstallerVersionInfo)

    Public ReadOnly Property Confirmed As Boolean
        Get
            Return DialogResult = DialogResult.OK
        End Get
    End Property

    Public Sub New(versionsToDelete As List(Of InstallerVersionInfo))
        InitializeComponent()

        If versionsToDelete Is Nothing OrElse versionsToDelete.Count = 0 Then
            Throw New ArgumentException("No versions to confirm cleanup for.")
        End If

        _versionsToDelete = versionsToDelete

        PopulateUI()
    End Sub

    ' -------------------------
    ' UI population
    ' -------------------------
    Private Sub PopulateUI()

        lblMessage.Text =
        "You are about to permanently delete the following installer versions:" &
        Environment.NewLine & Environment.NewLine &
        "This action cannot be undone."

        lbVersions.Items.Clear()

        For Each v In _versionsToDelete
            lbVersions.Items.Add(v.VersionString)
        Next

        Dim totalBytes As Long =
        _versionsToDelete.Sum(
            Function(v)
                Return InstallerTools.GetDirectorySizeBytesRecursive(v.FolderPath)
            End Function)

        Dim totalGb As Double =
        totalBytes / (1024.0 * 1024.0 * 1024.0)

        If totalGb >= 1 Then

            lblSpaceSummary.Text = $"Selected cleanup will free approximately {totalGb:F2} GB of disk space."
        Else
            Dim totalMb As Long = totalBytes \ (1024 * 1024)
            lblSpaceSummary.Text = $"Selected cleanup will free approximately {totalMb:N0} MB of disk space."
        End If

        btnConfirmDelete.Enabled = True

    End Sub

    ' -------------------------
    ' Buttons
    ' -------------------------
    Private Sub btnConfirmDelete_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnConfirmDelete.Click

        DialogResult = DialogResult.OK
        Close()

    End Sub

    Private Sub btnCancel_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
        Close()

    End Sub


End Class