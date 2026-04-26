Imports System.IO

Public Class FlavorSelectionManager

    Private ReadOnly _options As AppOptions
    Private ReadOnly _clbSqlFiles As CheckedListBox
    Private ReadOnly _applyCommandTextBox As TextBox
    Private ReadOnly _startCommandTextBox As TextBox

    Private _defaultsApplied As Boolean = False

    Public Sub New(
        options As AppOptions,
        sqlFilesList As CheckedListBox,
        applyCommandTextBox As TextBox,
        startCommandTextBox As TextBox
    )
        _options = options
        _clbSqlFiles = sqlFilesList
        _applyCommandTextBox = applyCommandTextBox
        _startCommandTextBox = startCommandTextBox
    End Sub

    ' ============================
    ' Public API
    ' ============================

    Public Sub LoadFilesWithDefaults(folderPath As String)

        _clbSqlFiles.BeginUpdate()
        _clbSqlFiles.Items.Clear()

        If String.IsNullOrWhiteSpace(folderPath) OrElse
           Not Directory.Exists(folderPath) Then

            _clbSqlFiles.EndUpdate()
            Return
        End If

        Dim defaultSet As New HashSet(Of String)(
            If(_options?.DefaultFlavorNames, Enumerable.Empty(Of String)()),
            StringComparer.OrdinalIgnoreCase)

        For Each filePath In Directory.GetFiles(folderPath, "*.sql")

            Dim item As New SqlFileItem With {.FilePath = filePath}
            Dim index = _clbSqlFiles.Items.Add(item)

            Dim flavorName =
                Path.GetFileNameWithoutExtension(filePath)

            If defaultSet.Contains(flavorName) Then
                _clbSqlFiles.SetItemChecked(index, True)
            End If
        Next

        _clbSqlFiles.EndUpdate()
    End Sub

    Public Sub RefreshPreservingSelection()

        If _options Is Nothing OrElse
           String.IsNullOrWhiteSpace(_options.FlavorFolderPath) OrElse
           Not Directory.Exists(_options.FlavorFolderPath) Then
            Return
        End If

        Dim checkedPaths As New HashSet(Of String)(
            _clbSqlFiles.CheckedItems _
                .OfType(Of SqlFileItem)() _
                .Select(Function(i) i.FilePath),
            StringComparer.OrdinalIgnoreCase)

        Dim defaultSet As New HashSet(Of String)(
            If(_options.DefaultFlavorNames, Enumerable.Empty(Of String)()),
            StringComparer.OrdinalIgnoreCase)

        _clbSqlFiles.BeginUpdate()
        _clbSqlFiles.Items.Clear()

        For Each filePath In Directory.GetFiles(_options.FlavorFolderPath, "*.sql")

            Dim item As New SqlFileItem With {.FilePath = filePath}
            Dim index = _clbSqlFiles.Items.Add(item)

            Dim flavorName =
                Path.GetFileNameWithoutExtension(filePath)

            If checkedPaths.Contains(filePath) Then
                _clbSqlFiles.SetItemChecked(index, True)
            ElseIf Not _defaultsApplied AndAlso defaultSet.Contains(flavorName) Then
                _clbSqlFiles.SetItemChecked(index, True)
            End If
        Next

        _defaultsApplied = True
        _clbSqlFiles.EndUpdate()
    End Sub

    Public Sub UpdateFlavorCommands(applyPrefix As String, startPrefix As String)

        Dim flavors = GetSelectedFlavorNames()
        Dim flavorString = String.Join(", ", flavors)

        _applyCommandTextBox.Text = $"{applyPrefix} {flavorString}".Trim()
        _startCommandTextBox.Text = $"{startPrefix} {flavorString}".Trim()
    End Sub

    Public Function GetSelectedFlavorNames() As List(Of String)

        Dim result As New List(Of String)

        For Each item In _clbSqlFiles.CheckedItems
            Dim sqlItem = TryCast(item, SqlFileItem)
            If sqlItem IsNot Nothing Then
                result.Add(Path.GetFileNameWithoutExtension(sqlItem.FilePath))
            End If
        Next

        Return result
    End Function

    Public Sub SaveDefaults()
        Dim defaults As List(Of String) =
    _clbSqlFiles.CheckedItems _
        .OfType(Of SqlFileItem)() _
        .Select(Function(item As SqlFileItem) _
                    Path.GetFileNameWithoutExtension(item.FilePath)) _
        .Distinct(StringComparer.OrdinalIgnoreCase) _
        .ToList()

        _options.DefaultFlavorNames = defaults
        OptionsManager.Save(_options)
    End Sub

    Public Sub ResetToDefaults()

        If _options?.DefaultFlavorNames Is Nothing OrElse
           _clbSqlFiles.Items.Count = 0 Then Return

        Dim defaultSet As New HashSet(Of String)(
            _options.DefaultFlavorNames,
            StringComparer.OrdinalIgnoreCase)

        _clbSqlFiles.BeginUpdate()

        For i = 0 To _clbSqlFiles.Items.Count - 1

            Dim item = TryCast(_clbSqlFiles.Items(i), SqlFileItem)
            If item Is Nothing Then Continue For

            Dim flavorName =
                Path.GetFileNameWithoutExtension(item.FilePath)

            _clbSqlFiles.SetItemChecked(i, defaultSet.Contains(flavorName))
        Next

        _clbSqlFiles.EndUpdate()
    End Sub

    ' ============================
    ' Helper class
    ' ============================

    Public Class SqlFileItem
        Public Property FilePath As String

        Public ReadOnly Property FileName As String
            Get
                Return Path.GetFileName(FilePath)
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return FileName
        End Function
    End Class

End Class