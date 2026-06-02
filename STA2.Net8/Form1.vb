Public Class Form1
    Dim test = New AppOptions()
    Dim json = System.Text.Json.JsonSerializer.Serialize(test)
End Class