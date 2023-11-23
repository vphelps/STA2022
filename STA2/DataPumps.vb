Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock

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
    Public Shared DataPumpMerge As String =
        "MERGE INTO DataPumps AS Dest
USING (
SELECT [DataPumpId], [Description], [IsStandard], [Query], [FileName], [StartTime], [IntervalMinutes], [Enabled], [LastCompletionDateTime], [LastFailureDateTime], [ConsecutiveFailureCount], [DestinationId] FROM DataPumps

) AS Src ([DataPumpId], [Description], [IsStandard], [Query], [FileName], [StartTime], [IntervalMinutes], [Enabled], [LastCompletionDateTime], [LastFailureDateTime], [ConsecutiveFailureCount], [DestinationId])
ON src.DataPumpId = Dest.DataPumpId

WHEN MATCHED THEN
UPDATE SET
	DataPumpID = '{0}',
	Description = '{1}',
	IsStandard = {2},
	Query = '{3}',
	FileName= '{4}',
	StartTime = '{5}',
	IntervalMinutes ={6},
	Enabled = {7},
	DestinationId = {8}
WHEN NOT MATCHED THEN 
	INSERT ([DataPumpId], [Description], [IsStandard], [Query], [FileName], [StartTime], [IntervalMinutes], [Enabled], [LastCompletionDateTime], [LastFailureDateTime], [ConsecutiveFailureCount], [DestinationId])
	VALUES (NEWID(),'{1}','{2},'{3}', '{4}', '{5}',{6}, {7}, NULL, NULL, 0, {8})
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

    ''' <summary>
    ''' Start time for cycle in UTC time zone
    ''' </summary>
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
                Time = dgvDatapumps.Rows.Item(rowIndex).Cells.Item(dgvDatapumps.Columns("StartTime").Index).Value
                DataPump.StartTime = Time.ToString
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

        Using cmd As New SqlCommand("
MERGE INTO DataPumps AS Dest
USING (
SELECT [DataPumpId], [Description], [IsStandard], [Query], [FileName], [StartTime], [IntervalMinutes], [Enabled], [LastCompletionDateTime], [LastFailureDateTime], [ConsecutiveFailureCount], [DestinationId] FROM DataPumps

) AS Src ([DataPumpId], [Description], [IsStandard], [Query], [FileName], [StartTime], [IntervalMinutes], [Enabled], [LastCompletionDateTime], [LastFailureDateTime], [ConsecutiveFailureCount], [DestinationId])
ON src.DataPumpId = Dest.DataPumpId

WHEN MATCHED THEN
UPDATE SET
	DataPumpID = @DataPumpId,
	Description = @Description,
	IsStandard = 0,
	Query = 'Query',
	FileName= 'FileName',
	StartTime = 'StartTime',
	IntervalMinutes =0,
	Enabled = 0,
	LastCompletionDateTime = 'LastCompletionDateTime',
	LastFailureDateTime ='LastFailureDateTime',
	ConsecutiveFailureCount = 0,
	DestinationId = 0
WHEN NOT MATCHED THEN 
	INSERT ([DataPumpId], [Description], [IsStandard], [Query], [FileName], [StartTime], [IntervalMinutes], [Enabled], [LastCompletionDateTime], [LastFailureDateTime], [ConsecutiveFailureCount], [DestinationId])
	VALUES (NEWID(),'Description','IsStandard','Query', 'FileName', 'StartTime', 'IntervalMinutes', 'Enabled', 'LastCompletionDateTime', 'LastFailureDateTime', 'ConsecutiveFailureCount', 'DestinationId')
;
")
            cmd.Parameters.Add("@DataPumpId", SqlDbType.UniqueIdentifier).Value = DataPumpId
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description

            FormMain.tbMLTest1.Text = cmd.CommandText

        End Using
        'DBConnector.CreateCommand(SqlQuery)

        'MsgBox(SqlQuery)

    End Sub
End Class