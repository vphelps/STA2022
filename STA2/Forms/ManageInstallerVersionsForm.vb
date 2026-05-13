Imports System.IO

Public Class ManageInstallerVersionsForm

    Private ReadOnly _versions As List(Of InstallerVersionInfo)
    Private _suppressSelection As Boolean

    Public ReadOnly Property SelectedForCleanup As List(Of InstallerVersionInfo)
        Get
            Return clbVersions.CheckedItems _
                .OfType(Of InstallerVersionInfo)() _
                .ToList()
        End Get
    End Property

    Public Sub New(
        installedVersions As List(Of InstallerVersionInfo),
        upgradePath As String
    )
        InitializeComponent()
        managefrmToolTip.IsBalloon = True
        managefrmToolTip.ToolTipIcon = ToolTipIcon.Info
        managefrmToolTip.ToolTipTitle = "Installer Version"
        managefrmToolTip.AutoPopDelay = 8000
        managefrmToolTip.InitialDelay = 400
        managefrmToolTip.ReshowDelay = 200

        _versions = installedVersions

        lblPath.Text =
            $"Installer versions found in:{Environment.NewLine}{upgradePath}"

        lblExplanation.Text =
            "• Long Term Support (LTS) versions are always kept." & Environment.NewLine &
            "• The current installer version is always kept."

        PopulateList()
        UpdateSummary()
    End Sub

    ' -------------------------
    ' Populate version list
    ' -------------------------
    Private Sub PopulateList()

        clbVersions.Items.Clear()

        For Each info In _versions.OrderByDescending(Function(v) v.Version)

            Dim index = clbVersions.Items.Add(info)

            clbVersions.SetItemChecked(index, False)

            ' Disable selection if not eligible
            If Not IsEligibleForCleanup(info) Then
                clbVersions.SetItemCheckState(index, CheckState.Unchecked)
                clbVersions.SetItemChecked(index, False)
            End If
        Next

    End Sub

    ' -------------------------
    ' Eligibility rules (UI only)
    ' -------------------------
    Private Function IsEligibleForCleanup(info As InstallerVersionInfo) As Boolean
        Return info.CanDelete
    End Function

    ' -------------------------
    ' Display formatting
    ' -------------------------
    Private Function FormatDisplayText(info As InstallerVersionInfo) As String

        Dim sizeMb = info.SizeBytes \ (1024 * 1024)

        Dim label As String

        ' ✅ Current = INSTALLED version, not highest
        If info.LockReason = VersionLockReason.InstalledVersion Then
            label = "Current (Installed)"

        ElseIf info.Track = ReleaseTrack.LongTermSupport Then
            label = "LTS"

        Else
            label = "Fast Track"
        End If

        ' 🔒 Prefix locked items so users can see they are protected
        'If(info.CanDelete, "", "🔒 ")
        Dim prefix As String =
    If(info.LockReason = VersionLockReason.InstalledVersion,
       "✅ ",
       If(info.CanDelete, "", "🔒 "))

        Return $"{prefix}{info.VersionString,-28} {label,-12} {sizeMb,6} MB"

    End Function    ' -------------------------
    ' CheckedListBox rendering
    ' -------------------------
    Private Sub clbVersions_Format(
        sender As Object,
        e As ListControlConvertEventArgs
    ) Handles clbVersions.Format

        Dim info = TryCast(e.ListItem, InstallerVersionInfo)
        If info Is Nothing Then Return

        e.Value = FormatDisplayText(info)
    End Sub
    Private Sub clbVersions_MouseMove(
    sender As Object,
    e As MouseEventArgs
) Handles clbVersions.MouseMove

        Dim index As Integer = clbVersions.IndexFromPoint(e.Location)

        ' Not over an item → hide tooltip
        If index < 0 Then
            managefrmToolTip.Hide(clbVersions)
            Return
        End If

        Dim info = TryCast(clbVersions.Items(index), InstallerVersionInfo)
        If info Is Nothing Then Return

        ' ✅ Only show tooltip for LOCKED items
        If info.CanDelete Then
            managefrmToolTip.Hide(clbVersions)
            Return
        End If

        managefrmToolTip.SetToolTip(
        clbVersions,
        GetTooltipText(info)
    )

    End Sub
    ' -------------------------
    ' Summary update
    ' -------------------------
    Private Sub clbVersions_ItemCheck(
    sender As Object,
    e As ItemCheckEventArgs
) Handles clbVersions.ItemCheck

        Dim info = TryCast(clbVersions.Items(e.Index), InstallerVersionInfo)
        If info Is Nothing Then Return

        ' 🚫 Prevent checking if this version cannot be deleted
        If Not info.CanDelete Then
            e.NewValue = e.CurrentValue
            Return
        End If

        ' ✅ Update summary only for allowed changes
        BeginInvoke(Sub() UpdateSummary())

    End Sub

    Private Sub clbVersions_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
) Handles clbVersions.SelectedIndexChanged

        If _suppressSelection Then Return

        Dim index = clbVersions.SelectedIndex
        If index < 0 Then Return

        Dim info = TryCast(clbVersions.Items(index), InstallerVersionInfo)
        If info Is Nothing Then Return

        ' 🚫 Prevent selecting locked items
        If Not info.CanDelete Then
            _suppressSelection = True
            clbVersions.ClearSelected()
            _suppressSelection = False
        End If

    End Sub
    Private Sub btnSelectAllDeletable_Click(
    sender As Object,
    e As EventArgs
) Handles btnSelectAllDeletable.Click

        _suppressSelection = True

        Try
            For i As Integer = 0 To clbVersions.Items.Count - 1

                Dim info =
                TryCast(clbVersions.Items(i), InstallerVersionInfo)

                If info Is Nothing Then Continue For

                ' ✅ Only check items that are allowed to be deleted
                If info.CanDelete Then
                    clbVersions.SetItemChecked(i, True)
                Else
                    clbVersions.SetItemChecked(i, False)
                End If

            Next

        Finally
            _suppressSelection = False
        End Try

        ' ✅ Update summary once after changes
        UpdateSummary()

    End Sub

    Private Function GetTooltipText(info As InstallerVersionInfo) As String

        Select Case info.LockReason

            Case VersionLockReason.InstalledVersion
                Return "This is the currently installed installer version." &
                   Environment.NewLine &
                   "It cannot be removed."

            Case VersionLockReason.LatestVersion
                Return "This is the newest available installer version."

            Case VersionLockReason.LongTermSupport
                Return "This Long Term Support (LTS) version is always kept."

            Case VersionLockReason.SelectedAsRunExisting
                Return "This version was selected to run in this session."

            Case VersionLockReason.InstallerRunning
                Return "This installer is currently running and cannot be removed."

            Case VersionLockReason.FileLocked
                Return "One or more files in this version are currently in use."

            Case Else
                ' This should never be shown, because we hide tooltips
                ' for deletable items, but keep it safe.
                Return ""
        End Select

    End Function


    Private Sub UpdateSummary()

        Dim totalBytes As Long =
        SelectedForCleanup.Sum(Function(v) v.SizeBytes)

        Dim totalMb = totalBytes \ (1024 * 1024)

        lblSummary.Text =
        $"Selected cleanup will free: {totalMb} MB"

        ' ✅ Enable Cleanup only if something is selected
        btnCleanup.Enabled = SelectedForCleanup.Count > 0
        btnUnselectAll.Enabled = SelectedForCleanup.Count > 0

        ' ✅ NEW: Enable "Select All Deletable" only if something CAN be deleted
        btnSelectAllDeletable.Enabled =
        _versions.Any(Function(v) v.CanDelete)


    End Sub

    ' -------------------------
    ' Buttons
    ' -------------------------
    Private Sub btnCleanup_Click(
    sender As Object,
    e As EventArgs
) Handles btnCleanup.Click

        Dim selected = SelectedForCleanup

        If selected.Count = 0 Then Return

        Using confirm As New ConfirmInstallerVersionCleanupForm(selected)

            If confirm.ShowDialog(Me) = DialogResult.OK Then
                ' ✅ User explicitly approved deletion
                ' 🔜 Step E will perform the actual cleanup
                DialogResult = DialogResult.OK
                Close()
            End If

        End Using
    End Sub

    Private Sub btnCancel_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
        Close()

    End Sub

    Private Sub btnUnselectAll_Click(sender As Object, e As EventArgs) Handles btnUnselectAll.Click
        clbVersions.ClearSelected()
        For i As Integer = 0 To clbVersions.Items.Count - 1
            clbVersions.SetItemChecked(i, False)
        Next
        UpdateSummary()
    End Sub

End Class