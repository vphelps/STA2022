Imports System.IO

Public Class FlavorSelectionManager

    Private ReadOnly _options As AppOptions
    Private ReadOnly _clbSqlFiles As CheckedListBox
    'Private ReadOnly _applyCommandTextBox As TextBox
    'Private ReadOnly _startCommandTextBox As TextBox

    Private _defaultsApplied As Boolean = False

    Public Sub New(
        options As AppOptions,
        sqlFilesList As CheckedListBox
    )
        'applyCommandTextBox As TextBox,
        'startCommandTextBox As TextBox

        _options = options
        _clbSqlFiles = sqlFilesList
        '_applyCommandTextBox = applyCommandTextBox
        '_startCommandTextBox = startCommandTextBox
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

            If defaultSet.Contains(item.FlavorName) Then
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

            If checkedPaths.Contains(filePath) OrElse
               (Not _defaultsApplied AndAlso defaultSet.Contains(item.FlavorName)) Then
                _clbSqlFiles.SetItemChecked(index, True)
            End If
        Next

        _defaultsApplied = True
        _clbSqlFiles.EndUpdate()
    End Sub

    Public Function GetSelectedFlavorNames() As List(Of String)

        Return _clbSqlFiles.CheckedItems _
            .OfType(Of SqlFileItem)() _
            .Select(Function(item) item.FlavorName) _
            .ToList()

    End Function

    Public Sub SaveDefaults()

        Dim defaults As List(Of String) =
            _clbSqlFiles.CheckedItems _
                .OfType(Of SqlFileItem)() _
                .Select(Function(item) item.FlavorName) _
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

            _clbSqlFiles.SetItemChecked(i, defaultSet.Contains(item.FlavorName))
        Next

        _clbSqlFiles.EndUpdate()
    End Sub

    Public Sub ApplySavedDefaults(defaultFlavors As List(Of String))

        If defaultFlavors Is Nothing OrElse defaultFlavors.Count = 0 Then Return

        Dim defaultSet As New HashSet(Of String)(
            defaultFlavors,
            StringComparer.OrdinalIgnoreCase)

        _clbSqlFiles.BeginUpdate()

        For i As Integer = 0 To _clbSqlFiles.Items.Count - 1
            Dim item = TryCast(_clbSqlFiles.Items(i), SqlFileItem)
            If item Is Nothing Then Continue For

            _clbSqlFiles.SetItemChecked(i, defaultSet.Contains(item.FlavorName))
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

        ' ✅ Single authoritative flavor name (NO extension)
        Public ReadOnly Property FlavorName As String
            Get
                Return Path.GetFileNameWithoutExtension(FilePath)
            End Get
        End Property

        Public Overrides Function ToString() As String
            ' UI display only
            Return FileName
        End Function
    End Class

End Class