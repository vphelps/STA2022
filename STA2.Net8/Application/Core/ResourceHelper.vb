Imports System.Reflection
Imports System.IO
Imports System.Drawing

Public Module ResourceHelper

    Public Function LoadImage(resourceName As String) As Image

        Dim asm = Assembly.GetExecutingAssembly()

        ' ✅ Match either with OR without extension (case-insensitive)
        Dim fullName = asm.GetManifestResourceNames().
        FirstOrDefault(Function(n)
                           Return n.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase) OrElse
                                  n.EndsWith(resourceName & ".png", StringComparison.OrdinalIgnoreCase)
                       End Function)

        If fullName Is Nothing Then
            Return Nothing
        End If

        Using stream = asm.GetManifestResourceStream(fullName)
            If stream Is Nothing Then
                Return Nothing
            End If

            Return Image.FromStream(stream)
        End Using

    End Function

End Module