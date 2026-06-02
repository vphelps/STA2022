Public Class ScriptArgument

    Public Property Name As String
    Public Property Value As String
    Public Property HasValue As Boolean = True

    Public Sub New(name As String)
        Me.Name = name
        Me.HasValue = False
    End Sub

    Public Sub New(name As String, value As String)
        Me.Name = name
        Me.Value = value
        Me.HasValue = True
    End Sub

    Public Overrides Function ToString() As String
        If Not HasValue Then
            Return Name
        End If

        If String.IsNullOrWhiteSpace(Value) Then
            Return Name
        End If

        ' ✅ Auto-quote values safely
        Return $"{Name} ""{Value}"""
    End Function

End Class
