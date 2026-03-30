' ===============================================================
' SafeDb.vb
' Lightweight wrapper around DBConnector.dbQuery
' Converts all DB connection failures into DatabaseOfflineException
' Used for runtime Offline Mode (Option A in FormMain)
' ===============================================================

Imports System.Data

Public Module SafeDb

    ''' <summary>
    ''' Executes a DB query using DBConnector.dbQuery but wraps
    ''' *any* exception (SQL timeout, network failure, server down,
    ''' docker container stopped, etc.) into DatabaseOfflineException.
    ''' This prevents STA from crashing and allows FormMain to enter
    ''' Offline Mode safely.
    ''' </summary>
    Public Function TryQuery(sql As String) As DataSet
        Debug.WriteLine("[SafeDb] Query called: " & sql)
        Try
            Dim result As Object = DBConnector.dbQuery(sql)
            Return TryCast(result, DataSet)

        Catch ex As Exception
            Debug.WriteLine("[SafeDb] Exception caught: " & ex.Message)
            Throw New DatabaseOfflineException("Database connection lost.", ex)
        End Try
    End Function


    ''' <summary>
    ''' Custom exception type used by SafeDb.
    ''' FormMain catches this specific type to switch into Offline Mode.
    ''' </summary>
    Public Class DatabaseOfflineException
        Inherits Exception

        Public Sub New(message As String, inner As Exception)
            MyBase.New(message, inner)
        End Sub

    End Class

End Module