Imports System.Windows.Forms
Imports System.Drawing

Public Class QuickLaunchManager

    Private ReadOnly _panel As FlowLayoutPanel
    Private ReadOnly _options As AppOptions
    Private ReadOnly _launcherConfig As LauncherConfig
    Private ReadOnly _toolTip As ToolTip
    Private ReadOnly _launchCallback As Action(Of ProgramEntry)

    Private _dragButton As Button
    Private _dragStartPoint As Point
    Private Const DragThreshold As Integer = 6
    Private _isReordering As Boolean = False

    Public Sub New(
        panel As FlowLayoutPanel,
        options As AppOptions,
        launcherConfig As LauncherConfig,
        toolTip As ToolTip,
        launchCallback As Action(Of ProgramEntry)
    )
        _panel = panel
        _options = options
        _launcherConfig = launcherConfig
        _toolTip = toolTip
        _launchCallback = launchCallback

        _panel.AllowDrop = True
        AddHandler _panel.DragOver, AddressOf Panel_DragOver
        AddHandler _panel.DragDrop, AddressOf Panel_DragDrop
    End Sub

    ' ============================
    ' Public API
    ' ============================

    Public Sub Refresh()
        If _panel Is Nothing OrElse _options Is Nothing Then Return

        _panel.SuspendLayout()
        Try
            _panel.Controls.Clear()

            Dim byId As New Dictionary(Of String, ProgramEntry)(StringComparer.OrdinalIgnoreCase)
            If _launcherConfig?.Programs IsNot Nothing Then
                For Each p In _launcherConfig.Programs
                    If p IsNot Nothing AndAlso p.Enabled AndAlso
                       Not String.IsNullOrWhiteSpace(p.Id) AndAlso
                       Not byId.ContainsKey(p.Id) Then

                        byId.Add(p.Id, p)
                    End If
                Next
            End If

            If _options.QuickLaunchIds Is Nothing Then Return

            For slot As Integer = 0 To _options.QuickLaunchIds.Count - 1
                Dim id = _options.QuickLaunchIds(slot)
                If String.IsNullOrWhiteSpace(id) Then Continue For
                If Not byId.TryGetValue(id, Nothing) Then Continue For

                Dim entry = byId(id)
                Dim btn = CreateButton(entry)
                _panel.Controls.Add(btn)
            Next

        Finally
            _panel.ResumeLayout()
        End Try
    End Sub

    ' ============================
    ' Button creation
    ' ============================

    Private Function CreateButton(entry As ProgramEntry) As Button

        Dim btn As New Button With {
            .Width = 160,
            .Height = 48,
            .AutoSize = False,
            .Tag = entry,
            .Text = entry.Name,
            .TextAlign = ContentAlignment.MiddleCenter,
            .TextImageRelation = TextImageRelation.ImageBeforeText,
            .Margin = New Padding(3),
            .UseVisualStyleBackColor = True
        }

        ApplyIcon(btn, entry)
        ApplyToolTip(btn, entry)

        AddHandler btn.Click,
            Sub()
                _launchCallback?.Invoke(entry)
            End Sub

        AddHandler btn.MouseDown, AddressOf Button_MouseDown
        AddHandler btn.MouseMove, AddressOf Button_MouseMove
        AddHandler btn.MouseUp,
            Sub()
                _dragButton = Nothing
            End Sub

        Return btn
    End Function

    ' ============================
    ' Drag & drop
    ' ============================

    Private Sub Button_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button <> MouseButtons.Left Then Return
        _dragButton = DirectCast(sender, Button)
        _dragStartPoint = e.Location
    End Sub

    Private Sub Button_MouseMove(sender As Object, e As MouseEventArgs)
        If _dragButton Is Nothing OrElse e.Button <> MouseButtons.Left Then Return

        If Math.Abs(e.X - _dragStartPoint.X) >= DragThreshold OrElse
           Math.Abs(e.Y - _dragStartPoint.Y) >= DragThreshold Then

            _panel.DoDragDrop(_dragButton, DragDropEffects.Move)
        End If
    End Sub

    Private Sub Panel_DragOver(sender As Object, e As DragEventArgs)
        If _isReordering Then Return
        If Not e.Data.GetDataPresent(GetType(Button)) Then Return

        e.Effect = DragDropEffects.Move

        Dim clientPoint = _panel.PointToClient(New Point(e.X, e.Y))
        Dim target = TryCast(_panel.GetChildAtPoint(clientPoint), Button)
        Dim dragged = TryCast(e.Data.GetData(GetType(Button)), Button)

        If target Is Nothing OrElse dragged Is Nothing OrElse target Is dragged Then Return

        _isReordering = True
        Try
            _panel.Controls.SetChildIndex(dragged, _panel.Controls.GetChildIndex(target))
        Finally
            _isReordering = False
        End Try
    End Sub

    Private Sub Panel_DragDrop(sender As Object, e As DragEventArgs)
        Dim newIds As New List(Of String)

        For Each ctrl As Control In _panel.Controls
            Dim btn = TryCast(ctrl, Button)
            Dim entry = TryCast(btn?.Tag, ProgramEntry)
            If entry IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(entry.Id) Then
                newIds.Add(entry.Id)
            End If
        Next

        _options.QuickLaunchIds = newIds
        OptionsManager.Save(_options)
    End Sub

    ' ============================
    ' UI helpers
    ' ============================

    Private Sub ApplyToolTip(btn As Button, entry As ProgramEntry)
        Dim text = entry.Name
        If Not String.IsNullOrWhiteSpace(entry.Path) Then text &= Environment.NewLine & entry.Path
        If Not String.IsNullOrWhiteSpace(entry.Arguments) Then text &= Environment.NewLine & entry.Arguments
        If entry.RunAsAdmin Then text &= Environment.NewLine & "Runs as Administrator"

        _toolTip.SetToolTip(btn, text)
    End Sub

    Private Sub ApplyIcon(btn As Button, entry As ProgramEntry)
        Dim icon = IconHelpers.GetProgramIcon(entry)
        If icon IsNot Nothing Then
            btn.Image = IconHelpers.GetIconWithAdminShield(icon, entry.RunAsAdmin)
            btn.ImageAlign = ContentAlignment.MiddleLeft
        End If
    End Sub

    ' ============================
    ' Context menu support
    ' ============================

    Private _ctxPrograms As ContextMenuStrip
    Private _miAssignRoot As ToolStripMenuItem
    Private _miClearRoot As ToolStripMenuItem
    Private _ctxBuilt As Boolean

    Public Sub EnsureContextMenu(
        lstPrograms As ListBox,
        refreshComboCallback As Action
    )

        If _ctxBuilt Then Return

        _ctxPrograms = New ContextMenuStrip()
        _miAssignRoot = New ToolStripMenuItem("Assign to Quick Slot")
        _miClearRoot = New ToolStripMenuItem("Clear Quick Slot")

        Dim slotCount As Integer =
            If(_options?.QuickLaunchIds?.Count > 0,
               _options.QuickLaunchIds.Count,
               20)

        For slot As Integer = 0 To slotCount - 1
            Dim slotIndex = slot

            ' Assign
            Dim miAssign As New ToolStripMenuItem(GetSlotDisplay(slotIndex))
            miAssign.ToolTipText = GetSlotTooltip(slotIndex)
            AddHandler miAssign.Click,
                Sub()
                    AssignSelected(lstPrograms, slotIndex)
                    refreshComboCallback?.Invoke()
                End Sub
            _miAssignRoot.DropDownItems.Add(miAssign)

            ' Clear
            Dim miClear As New ToolStripMenuItem(GetSlotClearLabel(slotIndex))
            miClear.ToolTipText = GetSlotTooltip(slotIndex)
            AddHandler miClear.Click,
                Sub()
                    ClearSlot(slotIndex)
                    refreshComboCallback?.Invoke()
                End Sub
            _miClearRoot.DropDownItems.Add(miClear)
        Next

        _ctxPrograms.Items.AddRange({
            _miAssignRoot,
            _miClearRoot
        })

        lstPrograms.ContextMenuStrip = _ctxPrograms
        AddHandler lstPrograms.MouseUp, AddressOf SelectItemOnRightClick
        AddHandler _ctxPrograms.Opening,
            Sub()
                RefreshContextMenuLabels()
            End Sub

        _ctxBuilt = True
    End Sub

    Private Sub AssignSelected(lstPrograms As ListBox, slot As Integer)

        Dim entry = TryCast(lstPrograms.SelectedItem, ProgramEntry)
        If entry Is Nothing Then
            MessageBox.Show("Select a program to assign.", "Quick Launch")
            Return
        End If

        If _options.QuickLaunchIds Is Nothing Then
            _options.QuickLaunchIds = Enumerable.Repeat("", 20).ToList()
        End If

        While _options.QuickLaunchIds.Count <= slot
            _options.QuickLaunchIds.Add("")
        End While

        ' Uniqueness
        For i = 0 To _options.QuickLaunchIds.Count - 1
            If i <> slot AndAlso
               String.Equals(_options.QuickLaunchIds(i), entry.Id,
                             StringComparison.OrdinalIgnoreCase) Then
                _options.QuickLaunchIds(i) = ""
            End If
        Next

        _options.QuickLaunchIds(slot) = entry.Id
        OptionsManager.Save(_options)

        Refresh()
    End Sub

    Private Sub ClearSlot(slot As Integer)

        If _options.QuickLaunchIds Is Nothing OrElse
           slot < 0 OrElse slot >= _options.QuickLaunchIds.Count Then Return

        _options.QuickLaunchIds(slot) = ""
        OptionsManager.Save(_options)

        Refresh()
    End Sub

    Private Function GetSlotDisplay(slot As Integer) As String

        If _options?.QuickLaunchIds Is Nothing OrElse
           slot >= _options.QuickLaunchIds.Count Then
            Return $"Slot {slot + 1} — (empty)"
        End If

        Dim id = _options.QuickLaunchIds(slot)
        If String.IsNullOrWhiteSpace(id) Then
            Return $"Slot {slot + 1} — (empty)"
        End If

        Dim entry =
            _launcherConfig?.Programs?.
            FirstOrDefault(Function(p) p?.Id?.Equals(id,
                StringComparison.OrdinalIgnoreCase) = True)

        If entry Is Nothing Then Return $"Slot {slot + 1} — ⚠ missing"
        If Not entry.Enabled Then Return $"Slot {slot + 1} — ⚠ disabled"

        Return $"Slot {slot + 1} — {entry.Name}"
    End Function

    Private Function GetSlotTooltip(slot As Integer) As String

        If _options?.QuickLaunchIds Is Nothing OrElse
           slot >= _options.QuickLaunchIds.Count Then
            Return "(empty)"
        End If

        Dim id = _options.QuickLaunchIds(slot)
        If String.IsNullOrWhiteSpace(id) Then Return "(empty)"

        Dim entry =
            _launcherConfig?.Programs?.
            FirstOrDefault(Function(p) p?.Id?.Equals(id,
                StringComparison.OrdinalIgnoreCase) = True)

        If entry Is Nothing Then Return "(missing)"

        Dim sb As New System.Text.StringBuilder(entry.Name)
        If entry.Path <> "" Then sb.AppendLine().Append(entry.Path)
        If entry.Arguments <> "" Then sb.AppendLine().Append(entry.Arguments)
        Return sb.ToString()
    End Function

    Private Function GetSlotClearLabel(slot As Integer) As String
        Return "Clear " & GetSlotDisplay(slot)
    End Function

    Private Sub RefreshContextMenuLabels()

        If _miAssignRoot Is Nothing OrElse _miClearRoot Is Nothing Then Return
        If _options Is Nothing OrElse _options.QuickLaunchIds Is Nothing Then Return

        Dim idCount As Integer = _options.QuickLaunchIds.Count
        Dim menuCount As Integer = _miAssignRoot.DropDownItems.Count

        For i As Integer = 0 To menuCount - 1

            Dim assign = DirectCast(_miAssignRoot.DropDownItems(i), ToolStripMenuItem)
            Dim clear = DirectCast(_miClearRoot.DropDownItems(i), ToolStripMenuItem)

            assign.Text = GetSlotDisplay(i)
            assign.ToolTipText = GetSlotTooltip(i)

            clear.Text = GetSlotClearLabel(i)
            clear.ToolTipText = GetSlotTooltip(i)

            ' ✅ SAFE: only enable Clear if the slot exists AND is populated
            If i < idCount Then
                clear.Enabled = Not String.IsNullOrWhiteSpace(_options.QuickLaunchIds(i))
            Else
                clear.Enabled = False
            End If

        Next
    End Sub

    Private Sub SelectItemOnRightClick(sender As Object, e As MouseEventArgs)

        If e.Button <> MouseButtons.Right Then Return

        Dim lst = DirectCast(sender, ListBox)
        Dim index = lst.IndexFromPoint(e.Location)
        If index >= 0 Then lst.SelectedIndex = index
    End Sub



End Class