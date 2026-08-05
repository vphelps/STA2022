Imports System.Threading
Imports Microsoft.Data.SqlClient

Public Class DatabaseService
    Implements IDatabaseService

    Private ReadOnly _connectionFactory As IDbConnectionFactory

    Public Sub New(
        connectionFactory As IDbConnectionFactory
    )

        _connectionFactory = connectionFactory

    End Sub

    Public Async Function EvaluateDatabaseAvailabilityAsync(
    ct As CancellationToken
) As Task(Of DatabaseHealth) _
    Implements IDatabaseService.EvaluateDatabaseAvailabilityAsync

        Dim result As New DatabaseHealth()

        Try

            Using cn =
            _connectionFactory.CreateConnection()

                Await cn.OpenAsync(ct)

                result.IsOnline = True
                result.LastCheckedAt = DateTime.Now

                Using cmd As New SqlCommand(
                "SELECT @@VERSION",
                cn)

                    Dim version =
                    Await cmd.ExecuteScalarAsync(ct)

                    result.ServerVersion =
                    version?.ToString()

                End Using

                result.Environment =
                DetermineEnvironment(cn)

            End Using

        Catch ex As Exception

            result.IsOnline = False
            result.LastCheckedAt = DateTime.Now
            result.Details = ex.Message
            result.Environment = DatabaseEnvironment.Offline

        End Try

        Return result

    End Function
    Private Function DetermineEnvironment(
    cn As SqlConnection
) As DatabaseEnvironment

        Dim dataSource As String =
            cn.DataSource.
                Split("\"c)(0).
                Split(","c)(0).
                Trim()

        If dataSource.Equals(
            Environment.MachineName,
            StringComparison.OrdinalIgnoreCase) Then

            Return DatabaseEnvironment.LocalServer

        End If

        Return DatabaseEnvironment.RemoteServer

    End Function
End Class