Imports Microsoft.Data.SqlClient

Public Class DbConnectionFactory
    Implements IDbConnectionFactory

    Public Function CreateConnection() As SqlConnection _
        Implements IDbConnectionFactory.CreateConnection

        Return New SqlConnection(
            ConfigValues.ConnectionString)

    End Function

End Class