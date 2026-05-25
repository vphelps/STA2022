Public Class HoverHintManager

    Private ReadOnly _parent As Control
    Private ReadOnly _hints As New Dictionary(Of Control, HoverHint)

    Public Sub New(parent As Control)
        _parent = parent
    End Sub

    Public Sub Add(target As Control, text As String)

        If _hints.ContainsKey(target) Then
            _hints(target).SetText(text)
            Return
        End If

        Dim hint As New HoverHint(_parent, target, text)
        _hints(target) = hint

    End Sub

    Public Sub Remove(target As Control)

        If _hints.ContainsKey(target) Then
            _hints.Remove(target)
        End If

    End Sub

    Public Sub Clear()
        _hints.Clear()
    End Sub

End Class
