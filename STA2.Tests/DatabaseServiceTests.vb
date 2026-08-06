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
    <Fact>
    Public Async Function UsesCachedHealthResult() As Task

        ' Arrange
        Dim factory As New CountingConnectionFactory()

        Dim service As New DatabaseService(factory)

        ' Act
        Dim result1 =
        Await service.EvaluateDatabaseAvailabilityAsync(
            CancellationToken.None)

        Dim result2 =
        Await service.EvaluateDatabaseAvailabilityAsync(
            CancellationToken.None)

        ' Assert
        Assert.Equal(1, factory.CallCount)

    End Function
    <Fact>
    Public Async Function CacheInvalidationForcesNewCheck() As Task

        ' Arrange
        Dim factory As New CountingConnectionFactory()

        Dim service As New DatabaseService(factory)

        Await service.EvaluateDatabaseAvailabilityAsync(
            CancellationToken.None)

        service.InvalidateHealthCache()

        Await service.EvaluateDatabaseAvailabilityAsync(
            CancellationToken.None)

        ' Assert
        Assert.Equal(2, factory.CallCount)

    End Function
End Class