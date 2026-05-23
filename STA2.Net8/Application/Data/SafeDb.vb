Imports System.Data

Public Module SafeDb

    ''' <summary>
    ''' Executes a DB query safely.
    ''' Guarantees returning a DataSet (never Nothing).
    ''' Converts connection failures into DatabaseOfflineException.
    ''' </summary>
    Public Function TryQuery(sql As String) As DataSet

        Try
            Dim result As Object = DBConnector.dbQuery(sql)

            ' ✅ Case 1: already a DataSet
            If TypeOf result Is DataSet Then
                Return DirectCast(result, DataSet)
            End If

            ' ✅ Case 2: scalar result → wrap into DataSet
            Dim ds As New DataSet()
            Dim table As New DataTable("Result")
            table.Columns.Add("Value")

            Dim row = table.NewRow()
            row("Value") = If(result Is Nothing, DBNull.Value, result)
            table.Rows.Add(row)

            ds.Tables.Add(table)

            Return ds

        Catch ex As Exception
            ' ✅ Only true failures reach here
            Throw New DatabaseOfflineException("Database connection lost.", ex)
        End Try

    End Function


    ''' <summary>
    ''' Custom exception type used by SafeDb.
    ''' FormMain catches this to switch into Offline Mode.
    ''' </summary>
    Public Class DatabaseOfflineException
        Inherits Exception

        Public Sub New(message As String, inner As Exception)
            MyBase.New(message, inner)
        End Sub

    End Class

End Module