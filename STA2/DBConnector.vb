Imports System.Data.SqlClient
Imports System.Threading

Imports STA2.FormMain
Imports STA2.FormError

Public Class DBConnector
    Public Shared Function getValue(Query As String)
        Dim builder As New SqlConnectionStringBuilder
        Dim Ds As New DataSet
        Dim result As Object = Nothing
        Dim strTemp As String = ""
        If Variables.OfflineMode Then Return Nothing

        If Not PCInfo.ValidDatabase Then Return Ds

#Region "Build Connection String"

        builder.Add("Data Source", ConfigValues.Server)
        builder("Integrated Security") = False
        builder.Add("Initial Catalog", ConfigValues.Database)
        builder.Add("UID", ConfigValues.UserID)
        builder.Add("PWD", ConfigValues.Password)
        strTemp = builder.ConnectionString


#End Region
        Try

            Using cn As New SqlConnection(builder.ConnectionString)
                cn.Open()
                Using cmdSQL As New SqlCommand(Query, cn)
                    Dim reader As SqlDataReader = cmdSQL.ExecuteReader()
                    If reader.HasRows Then
                        Do While reader.Read()
                            result = reader.GetValue(0)
                        Loop
                    End If
                End Using
                cn.Close()

            End Using


        Catch ex As SqlException
            If ex.Message.StartsWith("Cannot Open") Then strTemp = "Database Error" Else strTemp = ex.Message
            ErrorHandler.ErrorHandler(strTemp, ex.StackTrace)

        End Try

        Return result

    End Function

    Public Shared Function dbQuery(Query As String)
        Dim builder As New SqlConnectionStringBuilder
        Dim Ds As New DataSet
        Dim result As String = ""
        Dim strTemp As String = ""

        If Variables.OfflineMode Then
            Return New DataSet() ' empty data
        End If
        If Not PCInfo.ValidDatabase Then Return Ds

#Region "Build Connection String"

        builder.Add("Data Source", ConfigValues.Server)
        builder("Integrated Security") = False
        builder.Add("Initial Catalog", ConfigValues.Database)
        builder.Add("UID", ConfigValues.UserID)
        builder.Add("PWD", ConfigValues.Password)
        strTemp = builder.ConnectionString


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
            If ex.Number = 233 Then
                ErrorHandler.WarningHandler("Database Connection Failure")

            ElseIf ex.Message.StartsWith("Cannot Open") Then
                strTemp = "Database Error"
            Else strTemp = String.Format("ErrorCode = {0} | Message = {1}", ex.Number, ex.Message)
                ErrorHandler.ErrorHandler(strTemp, ex.StackTrace)
            End If

        End Try
        Return Ds


    End Function


    '    Public Shared Function CreateCommand(ByVal queryString As String)
    '        Dim builder As New SqlConnectionStringBuilder
    '        Dim result As Integer = 0

    '        If Variables.OfflineMode Then
    '            Return 0
    '        End If

    '#Region "Build Connection String"

    '        builder.Add("Data Source", ConfigValues.Server)
    '        builder("Integrated Security") = False
    '        builder.Add("Initial Catalog", ConfigValues.Database)
    '        builder.Add("UID", ConfigValues.UserID)
    '        builder.Add("PWD", ConfigValues.Password)
    '        'strTemp = builder.ConnectionString


    '#End Region

    '        Using connection As New SqlConnection(builder.ConnectionString)
    '            Dim command As New SqlCommand(queryString, connection)
    '            command.Connection.Open()
    '            result = command.ExecuteNonQuery()
    '            command.Connection.Close()

    '        End Using
    '        Return result
    '    End Function


    Public Shared Function dbExecute(query As String) As Integer


        If Variables.OfflineMode Then
            Return 0
        End If
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
            Dim msg As String
            If ex.Number = 233 Then
                ErrorHandler.WarningHandler("Database Connection Failure")
                msg = "Database Connection Failure"
            ElseIf ex.Message.StartsWith("Cannot Open") Then
                msg = "Database Error"
            Else
                msg = String.Format("ErrorCode = {0} | Message = {1}", ex.Number, ex.Message)
            End If
            ErrorHandler.ErrorHandler(msg, ex.StackTrace)
        Catch ex As Exception
            ErrorHandler.ErrorHandler("dbExecute failed: " & ex.Message, ex.StackTrace)
        End Try

        Return affected
    End Function

End Class
