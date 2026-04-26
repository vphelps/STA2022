Imports System.Drawing

Public Module IconHelpers

    Private _cache As New Dictionary(Of String, Image)(StringComparer.OrdinalIgnoreCase)
    Private _adminShieldIcon As Image

    Public Function GetProgramIcon(entry As ProgramEntry) As Image
        If entry Is Nothing Then Return Nothing

        Dim path = If(Not String.IsNullOrWhiteSpace(entry.IconPath),
                      entry.IconPath,
                      entry.Path)

        If String.IsNullOrWhiteSpace(path) OrElse Not IO.File.Exists(path) Then
            Return SystemIcons.Application.ToBitmap()
        End If

        If Not _cache.ContainsKey(path) Then
            Using ico = Icon.ExtractAssociatedIcon(path)
                _cache(path) = ico.ToBitmap()
            End Using
        End If

        Return _cache(path)
    End Function

    Public Function GetIconWithAdminShield(baseIcon As Image, addShield As Boolean) As Image
        If Not addShield Then Return baseIcon

        If _adminShieldIcon Is Nothing Then
            _adminShieldIcon = SystemIcons.Shield.ToBitmap()
        End If

        Dim size = baseIcon.Width
        Dim result As New Bitmap(size, size)

        Using g = Graphics.FromImage(result)
            g.DrawImage(baseIcon, 0, 0, size, size)
            g.DrawImage(_adminShieldIcon, size \ 2, size \ 2, size \ 2, size \ 2)
        End Using

        Return result
    End Function

End Module
