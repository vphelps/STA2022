Imports Microsoft.Data.SqlClient
Imports STA2.Net8

Public Class CountingConnectionFactory
    Implements IDbConnectionFactory

    Public Property CallCount As Integer = 0

    Public Function CreateConnection() As SqlConnection _
        Implements IDbConnectionFactory.CreateConnection

        CallCount += 1

        Throw New Exception("Simulated connection failure")

    End Function

End Class