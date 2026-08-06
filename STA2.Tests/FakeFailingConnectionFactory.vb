Imports Microsoft.Data.SqlClient
Imports STA2.Net8

Public Class FakeFailingConnectionFactory
    Implements IDbConnectionFactory

    Public Function CreateConnection() As SqlConnection Implements IDbConnectionFactory.CreateConnection

        Throw New Exception("Simulated connection failure")

    End Function

End Class