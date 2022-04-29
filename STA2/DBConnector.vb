Imports System.Data.SqlClient
Imports STA2.FormMain
Imports STA2.FormError

Public Class DBConnector
    Public Shared Function dbQuery(Query As String)
        Dim builder As New SqlConnectionStringBuilder
        Dim Ds As New DataSet
        Dim result As String = ""

#Region "Build Connection String"

        builder.Add("Data Source", My.Settings.Server)
        builder("Integrated Security") = False
        builder.Add("Initial Catalog", My.Settings.Database)
        builder.Add("UID", My.Settings.UserID)
        builder.Add("PWD", My.Settings.Password)
        'strTemp = builder.ConnectionString


#End Region
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

            If Ds.Tables(0).Rows.Count = 1 And Ds.Tables(0).Columns.Count = 1 Then
                result = Ds.Tables(0).Rows.Item(0).Item(0)
                Return result

            End If
        Catch ex As SqlException
            ErrorHandler.ErrorHandler(ex.Message, ex.StackTrace)
        End Try
        Return Ds


    End Function
    Public Shared Sub CreateCommand(ByVal queryString As String)
        Dim builder As New SqlConnectionStringBuilder

#Region "Build Connection String"

        builder.Add("Data Source", My.Settings.Server)
        builder("Integrated Security") = False
        builder.Add("Initial Catalog", My.Settings.Database)
        builder.Add("UID", My.Settings.UserID)
        builder.Add("PWD", My.Settings.Password)
        'strTemp = builder.ConnectionString


#End Region

        Using connection As New SqlConnection(builder.ConnectionString)
            Dim command As New SqlCommand(queryString, connection)
            command.Connection.Open()
            command.ExecuteNonQuery()
            command.Connection.Close()

        End Using
    End Sub
End Class
