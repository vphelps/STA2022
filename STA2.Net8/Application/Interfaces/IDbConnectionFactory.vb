
Imports Microsoft.Data.SqlClient

Public Interface IDbConnectionFactory

    Function CreateConnection() As SqlConnection

End Interface