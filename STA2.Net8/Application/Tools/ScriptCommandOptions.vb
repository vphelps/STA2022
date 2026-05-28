Public Class ScriptCommandOptions

    Public Property ScriptPath As String

    ' Existing options
    Public Property OverrideArgs As String
    Public Property FlavorNames As IEnumerable(Of String)

    ' ✅ New structured options
    Public Property UseVersion As Boolean
    Public Property VersionText As String

    ' ✅ Future-friendly examples
    Public Property UseVerbose As Boolean
    Public Property CustomArg As String

End Class
