Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip

Public Class DataPumpStorage
    Public Shared DataPumpCredentials As New DataSet
    Public Shared DataPumpDestinations As New DataSet
    Public Shared DataPumps As New DataSet
    Public Shared DataPumpSchema As New DataTable

End Class

Public Class DatapumpQueries
    Public Shared Datapumps As String = "SELECT * FROM DataPumps"
    Public Shared DataPumpCredentials As String = "SELECT * FROM DataPumpCredentials"
    Public Shared DataPumpDestinations As String = "SELECT * FROM DataPumpDestinations"
    Public Shared DataPumpInsert As String = "INSERT INTO DataPumps(DataPumpId, Description, IsStandard, Query, FileName, StartTime, IntervalMinutes, Enabled, DestinationId)
	VALUES(NEWID(),@Description,@IsStandard,@Query, @FileName, @StartTime, @IntervalMinutes, @Enabled, @DestinationId)"
    Public Shared DataPumpDelete As String = "DELETE FROM DataPumps WHERE DataPumpId = '{0}'"
    Public Shared DataPumpMerge As String =
        "MERGE INTO DataPumps AS Dest
USING (
SELECT DataPumpId, Description, IsStandard, Query, FileName, StartTime, IntervalMinutes, Enabled, DestinationId 
FROM DataPumps WHERE DataPumpId = @DataPumpId

) AS Src (DataPumpId, Description, IsStandard, Query, FileName, StartTime, IntervalMinutes, Enabled, DestinationId)
ON @DataPumpID = Dest.DataPumpId

WHEN MATCHED THEN
UPDATE SET
	Description = @Description,
	IsStandard = @IsStandard,
	Query = @Query,
	FileName= @FileName,
	StartTime = @StartTime,
	IntervalMinutes =@IntervalMinutes,
	Enabled = @Enabled,
	DestinationId = @DestinationId
WHEN NOT MATCHED THEN 
	INSERT (DataPumpId, Description, IsStandard, Query, FileName, StartTime, IntervalMinutes, Enabled, DestinationId)
	VALUES (NEWID(),@Description,@IsStandard,@Query, @FileName, @StartTime, @IntervalMinutes, @Enabled, @DestinationId)
;
"

End Class

Public Class DataPump
    Public Shared DataPumpId As Guid

    Public Shared Description As String

    Public Shared IsStandard As Boolean

    Public Shared DestinationId As Integer

    Public Shared Query As String

    Public Shared FileName As String

    Public Shared StartTime As String

    Public Shared Interval As Integer

    Public Shared Enabled As Boolean

    Public Property LastCompletion As Date

    Public Property LastFailure As Date

    Public Property ConsecutiveFailureCount As Integer
End Class


Public Class DataPumpHelpers
    Public Shared Sub LoadDataPumpInformation(ByRef dgvDatapumps As DataGridView)
        Dim time As TimeSpan

        Try
            'Loading Datapumps Table
            DataPumpStorage.DataPumps = DBConnector.dbQuery(DatapumpQueries.Datapumps)
            dgvDatapumps.DataSource = DataPumpStorage.DataPumps.Tables(0)
            If dgvDatapumps.RowCount > 0 Then
                dgvDatapumps.CurrentCell = dgvDatapumps.Rows(0).Cells(0)
                dgvDatapumps.Rows(0).Selected = True
                Dim rowIndex As Integer = 0

                DataPump.DataPumpId = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("DataPumpId").Index).Value
                DataPump.Description = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("Description").Index).Value
                DataPump.IsStandard = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("IsStandard").Index).Value
                DataPump.DestinationId = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("DestinationId").Index).Value
                DataPump.Query = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("Query").Index).Value
                DataPump.FileName = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("FileName").Index).Value
                time = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("StartTime").Index).Value
                DataPump.StartTime = time.ToString
                DataPump.Interval = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("IntervalMinutes").Index).Value
                DataPump.Enabled = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("Enabled").Index).Value


            End If
            'Loading DatapumpCredemtials table
            DataPumpStorage.DataPumpCredentials = DBConnector.dbQuery(DatapumpQueries.DataPumpCredentials)

            'Loading DatapumpCredemtials table
            DataPumpStorage.DataPumpDestinations = DBConnector.dbQuery(DatapumpQueries.DataPumpDestinations)

        Catch ex As Exception

            ErrorHandler.ErrorHandler(ex.Message, ex.StackTrace)
            PCInfo.ValidDatabase = False

        End Try

    End Sub

    Public Shared Sub SaveDataPump(DataPumpId, Description, IsStandard, Query, FileName, StartTime, Interval, Enabled, DestinationId)

        Dim SqlQuery As String
        Dim QueryTemp As String = Query
        QueryTemp = QueryTemp.Replace("'", "''")
        SqlQuery = String.Format(DatapumpQueries.DataPumpMerge, DataPumpId, Description, IsStandard, QueryTemp, FileName, StartTime, Interval, Enabled, DestinationId)
        Dim builder As New SqlConnectionStringBuilder

        If DataPumpId = Nothing Then
            Dim DataPumpInsert As String = "INSERT INTO DataPumps(DataPumpId, Description, IsStandard, Query, FileName, StartTime, IntervalMinutes, Enabled, DestinationId)
	VALUES(NEWID(),@Description,@IsStandard,@Query, @FileName, @StartTime, @IntervalMinutes, @Enabled, @DestinationId)"

            builder.Add("Data Source", My.Settings.Server)
            builder("Integrated Security") = False
            builder.Add("Initial Catalog", My.Settings.Database)
            builder.Add("UID", My.Settings.UserID)
            builder.Add("PWD", My.Settings.Password)
            Dim cn As New SqlConnection(builder.ConnectionString)
            cn.Open()
            If DataPumpId = Nothing Then MsgBox("Nothing")
            Using cmd As New SqlCommand(DatapumpQueries.DataPumpInsert)
                cmd.Connection = cn

                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description
                cmd.Parameters.Add("@IsStandard", SqlDbType.Int).Value = IsStandard
                cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = Query
                cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName
                cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = StartTime
                cmd.Parameters.Add("@IntervalMinutes", SqlDbType.Int).Value = Interval
                cmd.Parameters.Add("@Enabled", SqlDbType.Int).Value = Enabled
                cmd.Parameters.Add("@DestinationId", SqlDbType.Int).Value = DestinationId
                cmd.ExecuteNonQuery()

                cn.Close()
            End Using

        Else

            builder.Add("Data Source", My.Settings.Server)
            builder("Integrated Security") = False
            builder.Add("Initial Catalog", My.Settings.Database)
            builder.Add("UID", My.Settings.UserID)
            builder.Add("PWD", My.Settings.Password)
            Dim cn As New SqlConnection(builder.ConnectionString)
            cn.Open()
            If DataPumpId = Nothing Then MsgBox("Nothing")
            Using cmd As New SqlCommand(DatapumpQueries.DataPumpMerge)
                cmd.Connection = cn

                cmd.Parameters.Add("@DataPumpId", SqlDbType.UniqueIdentifier).Value = If(DataPumpId = Nothing, CObj(DBNull.Value), DataPumpId)
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description
                cmd.Parameters.Add("@IsStandard", SqlDbType.Int).Value = IsStandard
                cmd.Parameters.Add("@Query", SqlDbType.VarChar).Value = Query
                cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName
                cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = StartTime
                cmd.Parameters.Add("@IntervalMinutes", SqlDbType.Int).Value = Interval
                cmd.Parameters.Add("@Enabled", SqlDbType.Int).Value = Enabled
                cmd.Parameters.Add("@DestinationId", SqlDbType.Int).Value = DestinationId
                cmd.ExecuteNonQuery()

                cn.Close()
            End Using
        End If

    End Sub

    Public Shared Sub DeleteDataPump(DataPumpId As Guid)
        Dim builder As New SqlConnectionStringBuilder

        builder.Add("Data Source", My.Settings.Server)
        builder("Integrated Security") = False
            builder.Add("Initial Catalog", My.Settings.Database)
            builder.Add("UID", My.Settings.UserID)
            builder.Add("PWD", My.Settings.Password)
            Dim cn As New SqlConnection(builder.ConnectionString)
            cn.Open()
            If DataPumpId = Nothing Then MsgBox("Nothing")

        Using cmd As New SqlCommand(String.Format(DatapumpQueries.DataPumpDelete, DataPumpId.ToString))
            MsgBox(cmd.CommandText)
            cmd.Connection = cn

            cmd.ExecuteNonQuery()

            cn.Close()
        End Using


    End Sub
End Class