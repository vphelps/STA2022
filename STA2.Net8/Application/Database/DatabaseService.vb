Imports System.Threading
Imports Microsoft.Data.SqlClient

Public Class DatabaseService
    Implements IDatabaseService

    Private ReadOnly _connectionFactory As IDbConnectionFactory
    Private _cachedHealth As DatabaseHealth

    Private _lastHealthCheck As DateTime?

    Private Shared ReadOnly HealthCacheDuration As TimeSpan =
    TimeSpan.FromSeconds(15)

    Public Sub New(
        connectionFactory As IDbConnectionFactory
    )

        _connectionFactory = connectionFactory

    End Sub
    Public Sub InvalidateHealthCache()

        _cachedHealth = Nothing
        _lastHealthCheck = Nothing

    End Sub

    Public Async Function EvaluateDatabaseAvailabilityAsync(
    ct As CancellationToken
) As Task(Of DatabaseHealth) _
    Implements IDatabaseService.EvaluateDatabaseAvailabilityAsync

        If _cachedHealth IsNot Nothing AndAlso
   _lastHealthCheck.HasValue AndAlso
   DateTime.Now - _lastHealthCheck.Value < HealthCacheDuration Then

            Return _cachedHealth

        End If

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

        _cachedHealth = result
        _lastHealthCheck = DateTime.Now
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