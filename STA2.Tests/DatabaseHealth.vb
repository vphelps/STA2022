Imports STA2.Net8
Imports Xunit

Public Class DatabaseHealthTests

    <Fact>
    Public Sub NewDatabaseHealth_IsOfflineByDefault()

        Dim health As New DatabaseHealth()

        Assert.False(health.IsOnline)

    End Sub

End Class