Imports System.Data.SqlClient
Imports System.Threading

Public Class DBConnector

    '======================================================================
    '  getValue – now uses OFFLINE MODE instead of ErrorHandler
    '======================================================================
    Public Shared Function getValue(Query As String)
        Dim builder As New SqlConnectionStringBuilder
        Dim Ds As New DataSet
        Dim result As Object = Nothing

        If Variables.OfflineMode Then Return Nothing
        If Not PCInfo.ValidDatabase Then Return Ds

        ' Build connection string
        builder.Add("Data Source", ConfigValues.Server)
        builder("Integrated Security") = False
        builder.Add("Initial Catalog", ConfigValues.Database)
        builder.Add("UID", ConfigValues.UserID)
        builder.Add("PWD", ConfigValues.Password)

        Try
            Using cn As New SqlConnection(builder.ConnectionString)
                cn.Open()
                Using cmdSQL As New SqlCommand(Query, cn)
                    Using reader As SqlDataReader = cmdSQL.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read()
                                result = reader.GetValue(0)
                            End While
                        End If
                    End Using
                End Using
                cn.Close()
            End Using

        Catch ex As SqlException
            ' ---- SWITCH TO OFFLINE MODE ----
            Variables.OfflineMode = True
            PCInfo.ValidDatabase = False
            Return Nothing

        Catch ex As Exception
            ' Generic failure: go offline
            Variables.OfflineMode = True
            PCInfo.ValidDatabase = False
            Return Nothing
        End Try

        Return result
    End Function


    '======================================================================
    '  dbQuery – now OFFLINE MODE instead of ErrorHandler
    '======================================================================
    Public Shared Function dbQuery(Query As String)
        Dim builder As New SqlConnectionStringBuilder
        Dim Ds As New DataSet
        Dim result As String = ""

        If Variables.OfflineMode Then Return New DataSet()
        If Not PCInfo.ValidDatabase Then Return Ds

        ' Build connection string
        builder.Add("Data Source", ConfigValues.Server)
        builder("Integrated Security") = False
        builder.Add("Initial Catalog", ConfigValues.Database)
        builder.Add("UID", ConfigValues.UserID)
        builder.Add("PWD", ConfigValues.Password)

        Try
            Using cn As New SqlConnection(builder.ConnectionString)
                cn.Open()
                Using cmdSQL As New SqlCommand(Query, cn)
                    Using daSQL As New SqlDataAdapter(cmdSQL)
                        daSQL.Fill(Ds)
                    End Using
                End Using
                cn.Close()
            End Using

            ' Convert single-cell results into string output
            If Ds.Tables.Count > 0 AndAlso
               Ds.Tables(0).Rows.Count = 1 AndAlso
               Ds.Tables(0).Columns.Count = 1 Then

                result = Ds.Tables(0).Rows(0)(0).ToString()
                Return result
            End If

        Catch ex As SqlException
            ' ---- SWITCH TO OFFLINE MODE ----
            Variables.OfflineMode = True
            PCInfo.ValidDatabase = False
            Return New DataSet()

        Catch ex As Exception
            Variables.OfflineMode = True
            PCInfo.ValidDatabase = False
            Return New DataSet()
        End Try

        Return Ds
    End Function


    '======================================================================
    '  dbExecute – now OFFLINE MODE instead of ErrorHandler
    '======================================================================
    Public Shared Function dbExecute(query As String) As Integer
        If Variables.OfflineMode Then Return 0
        If Not PCInfo.ValidDatabase Then Return 0

        Dim builder As New SqlConnectionStringBuilder()
        builder.Add("Data Source", ConfigValues.Server)
        builder("Integrated Security") = False
        builder.Add("Initial Catalog", ConfigValues.Database)
        builder.Add("UID", ConfigValues.UserID)
        builder.Add("PWD", ConfigValues.Password)

        Dim affected As Integer = 0

        Try
            Using cn As New SqlConnection(builder.ConnectionString)
                cn.Open()
                Using cmd As New SqlCommand(query, cn)
                    affected = cmd.ExecuteNonQuery()
                End Using
                cn.Close()
            End Using

        Catch ex As SqlException
            ' ---- SWITCH TO OFFLINE MODE ----
            Variables.OfflineMode = True
            PCInfo.ValidDatabase = False
            Return 0

        Catch ex As Exception
            Variables.OfflineMode = True
            PCInfo.ValidDatabase = False
            Return 0
        End Try

        Return affected
    End Function

End Class