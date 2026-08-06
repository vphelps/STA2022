Imports System.Data
Imports System.Threading
Imports System.Threading.Tasks

Public Module SafeDb

    ''' <summary>
    ''' Executes a DB query safely.
    ''' Guarantees returning a DataSet (never Nothing).
    ''' Converts connection failures into DatabaseOfflineException.
    ''' </summary>
    Public Function TryQuery(sql As String) As DataSet

        Try
            Dim result As Object = ReliableSql.Query(sql)

            Return ConvertToDataSet(result)

        Catch ex As Exception
            ' ✅ Only true failures reach here
            Throw New DatabaseOfflineException("Database connection lost.", ex)
        End Try

    End Function

    Public Async Function TryQueryAsync(
    sql As String,
    Optional ct As CancellationToken = Nothing
) As Task(Of DataSet)

        Try

            Dim result As Object =
            Await ReliableSql.QueryAsync(
                sql,
                ct)

            Return ConvertToDataSet(result)

        Catch ex As Exception

            Throw New DatabaseOfflineException(
            "Database connection lost.",
            ex)

        End Try

    End Function
    Friend Function ConvertToDataSet(
    result As Object
) As DataSet

        If TypeOf result Is DataSet Then
            Return DirectCast(result, DataSet)
        End If

        Dim ds As New DataSet()

        Dim table As New DataTable("Result")

        table.Columns.Add("Value")

        Dim row = table.NewRow()

        row("Value") =
        If(result Is Nothing,
           DBNull.Value,
           result)

        table.Rows.Add(row)

        ds.Tables.Add(table)

        Return ds

    End Function

    Public Class DatabaseOfflineException
        Inherits Exception

        Public Sub New(message As String, inner As Exception)
            MyBase.New(message, inner)
        End Sub

    End Class

End Module