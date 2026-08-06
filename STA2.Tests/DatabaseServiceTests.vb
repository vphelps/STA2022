Imports System.Threading
Imports STA2.Net8
Imports Xunit

Public Class DatabaseServiceTests

    <Fact>
    Public Async Function ReturnsOffline_WhenConnectionFails() As Task

        ' Arrange
        Dim factory As New FakeFailingConnectionFactory()

        Dim service As New DatabaseService(factory)

        ' Act
        Dim result =
            Await service.EvaluateDatabaseAvailabilityAsync(
                CancellationToken.None)

        ' Assert
        Assert.False(result.IsOnline)

    End Function

End Class