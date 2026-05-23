Imports Microsoft.Data.SqlClient
Imports System.Data
Imports System.Diagnostics

Public Class DBConnector

    '======================================================================
    '  getValue – returns first column of last row (or Nothing)
    '======================================================================
    Public Shared Function getValue(query As String) As Object

        If Variables.OfflineMode OrElse Not PCInfo.ValidDatabase Then
            Return Nothing
        End If

        Try
            Using cn As New SqlConnection(ConfigValues.ConnectionString)
                cn.Open()

                Using cmd As New SqlCommand(query, cn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()

                        Dim result As Object = Nothing

                        While reader.Read()
                            result = reader.GetValue(0)
                        End While

                        Return result
                    End Using
                End Using
            End Using

        Catch ex As SqlException
            HandleDatabaseFailure("SQL ERROR", ex)
            Return Nothing

        Catch ex As Exception
            HandleDatabaseFailure("GENERAL ERROR", ex)
            Return Nothing
        End Try

    End Function


    '======================================================================
    '  dbQuery – returns DataSet or scalar string if single-cell
    '======================================================================
    Public Shared Function dbQuery(query As String) As Object

        If Variables.OfflineMode Then Return New DataSet()
        If Not PCInfo.ValidDatabase Then Return New DataSet()

        Dim ds As New DataSet

        Try
            Using cn As New SqlConnection(ConfigValues.ConnectionString)
                cn.Open()

                Using cmd As New SqlCommand(query, cn)
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(ds)
                    End Using
                End Using
            End Using

            ' ✅ Scalar shortcut (optional, kept from your original logic)
            If ds.Tables.Count > 0 AndAlso
               ds.Tables(0).Rows.Count = 1 AndAlso
               ds.Tables(0).Columns.Count = 1 Then

                Return ds.Tables(0).Rows(0)(0).ToString()
            End If

            Return ds

        Catch ex As SqlException
            HandleDatabaseFailure("SQL ERROR", ex)
            Return New DataSet()

        Catch ex As Exception
            HandleDatabaseFailure("GENERAL ERROR", ex)
            Return New DataSet()
        End Try

    End Function


    '======================================================================
    '  dbExecute – executes INSERT/UPDATE/DELETE
    '======================================================================
    Public Shared Function dbExecute(query As String) As Integer

        If Variables.OfflineMode OrElse Not PCInfo.ValidDatabase Then
            Return 0
        End If

        Try
            Using cn As New SqlConnection(ConfigValues.ConnectionString)
                cn.Open()

                Using cmd As New SqlCommand(query, cn)
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As SqlException
            HandleDatabaseFailure("SQL ERROR", ex)
            Return 0

        Catch ex As Exception
            HandleDatabaseFailure("GENERAL ERROR", ex)
            Return 0
        End Try

    End Function


    '======================================================================
    '  Centralized DB failure handler
    '======================================================================
    Private Shared Sub HandleDatabaseFailure(prefix As String, ex As Exception)

        Debug.WriteLine($"{prefix}: {ex.Message}")

        Variables.OfflineMode = True
        PCInfo.ValidDatabase = False

    End Sub

End Class