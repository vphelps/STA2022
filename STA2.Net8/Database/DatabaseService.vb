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

                Using cmd As New SqlCommand(
                    "SELECT @@VERSION",
                    cn)

                    Dim version =
                        Await cmd.ExecuteScalarAsync(ct)

                    result.ServerVersion =
                        version?.ToString()

                End Using

                result.IsOnline = True
                result.LastCheckedAt = DateTime.Now

            End Using

        Catch ex As Exception

            result.IsOnline = False
            result.LastCheckedAt = DateTime.Now
            result.Details = ex.Message

        End Try

        Return result

    End Function

End Class