Public Class GeneralQueries

    Public Shared UnlockAdminAccount As String = "UPDATE AppOptions SET OptionValue = CONVERT(VARCHAR(24), DATEADD(DAY, 1, GETDATE()),120) + 'Z' WHERE OptionName = 'AdminUnlockedUntil'"
    Public Shared LicenseData As String = "SELECT LocName, LicenseServer, EnableWeb, ShiftDate, (SELECT OptionValue FROM AppOptions WHERE OptionName = 'CoreServiceServerName') AS CoreServiceServerName, (SELECT TOP 1 Version FROM VersionInfo ORDER BY KeyID DESC) AS Version FROM ApplicationInfo"
End Class

Public Class DbInfo
    Public Shared DbSizeByTable As String = "-- List of database table sizes sorted by table name alphabetically
SELECT 
    t.NAME AS TableName,
    s.Name AS SchemaName,
    p.rows AS RowCounts,
    SUM(a.total_pages) * 8 AS TotalSpaceKB, 
    SUM(a.used_pages) * 8 AS UsedSpaceKB, 
    (SUM(a.total_pages) - SUM(a.used_pages)) * 8 AS UnusedSpaceKB
FROM 
    sys.tables t
INNER JOIN      
    sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN 
    sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
INNER JOIN 
    sys.allocation_units a ON p.partition_id = a.container_id
LEFT OUTER JOIN 
    sys.schemas s ON t.schema_id = s.schema_id
WHERE 
    t.NAME NOT LIKE 'dt%' 
    AND t.is_ms_shipped = 0
    AND i.OBJECT_ID > 255 
GROUP BY 
    t.Name, s.Name, p.Rows
ORDER BY 
    --TableName
    --SchemaName
    --RowCounts
    --TotalSpaceKB
    UsedSpaceKB
    --UnusedSpaceKB
DESC
"
    Public Shared DbFragmentation As String = "SELECT S.name as 'Schema',
T.name as 'Table',
I.name as 'Index',
DDIPS.avg_fragmentation_in_percent,
DDIPS.page_count
FROM sys.dm_db_index_physical_stats (DB_ID(), NULL, NULL, NULL, NULL) AS DDIPS
INNER JOIN sys.tables T on T.object_id = DDIPS.object_id
INNER JOIN sys.schemas S on T.schema_id = S.schema_id
INNER JOIN sys.indexes I ON I.object_id = DDIPS.object_id
AND DDIPS.index_id = I.index_id
WHERE DDIPS.database_id = DB_ID()
and I.name is not null
AND DDIPS.avg_fragmentation_in_percent > 0
ORDER BY DDIPS.avg_fragmentation_in_percent desc"
    Public Shared DbSizeByDay As String = "--Grouped by day:
DECLARE @dbname NVARCHAR(1024), @days INT;      

SET @dbname = '{0}';
SET @days = 365;

WITH TempTable(Row,database_name,backup_start_date,Mb) AS (
	SELECT ROW_NUMBER() OVER(ORDER BY backup_start_date) AS Row, database_name, backup_start_date, CAST(backup_size/1024/1024 AS decimal(10,2)) Mb 
	FROM msdb..backupset
	WHERE TYPE = 'D' AND database_name=@dbname AND backup_start_date > GETDATE() - @days
)
SELECT CAST(A.backup_start_date AS DATE) AS 'Date', SUM(A.Mb - B.Mb) AS increment_mb
FROM TempTable A LEFT JOIN TempTable B ON A.Row = B.Row + 1
GROUP BY CAST(A.backup_start_date AS DATE)
ORDER BY CAST(A.backup_start_date AS DATE) DESC
"
    Public Shared DbDeadlocks As String = "SELECT  L.request_session_id AS SPID, 
        DB_NAME(L.resource_database_id) AS DatabaseName,
        O.Name AS LockedObjectName, 
        P.object_id AS LockedObjectId, 
        L.resource_type AS LockedResource, 
        L.request_mode AS LockType,
        ST.text AS SqlStatementText,        
        ES.login_name AS LoginName,
        ES.host_name AS HostName,
        TST.is_user_transaction as IsUserTransaction,
        AT.name as TransactionName,
        CN.auth_scheme as AuthenticationMethod
FROM    sys.dm_tran_locks L
        JOIN sys.partitions P ON P.hobt_id = L.resource_associated_entity_id
        JOIN sys.objects O ON O.object_id = P.object_id
        JOIN sys.dm_exec_sessions ES ON ES.session_id = L.request_session_id
        JOIN sys.dm_tran_session_transactions TST ON ES.session_id = TST.session_id
        JOIN sys.dm_tran_active_transactions AT ON TST.transaction_id = AT.transaction_id
        JOIN sys.dm_exec_connections CN ON CN.session_id = ES.session_id
        CROSS APPLY sys.dm_exec_sql_text(CN.most_recent_sql_handle) AS ST
WHERE   resource_database_id = db_id()
ORDER BY L.request_session_id "

End Class

Public Class LogQueries
    Public Shared WebCloudTotalCount As String = "SELECT -1, 'Total_CloudUpdates', COUNT(TableNo) AS 'Total_CloudUpdates' FROM WebCloudUpdates
UNION ALL
SELECT 0, 'Failed Transmits', COUNT(LastAttempt) FROM WebCloudUpdates WHERE LastAttempt IS NOT NULL
UNION ALL

SELECT 	WebCloudUpdates.TableNo,
TableName, 
	COUNT(DataID) AS 'Records Left to Transmit'
FROM WebCloudUpdates
JOIN WebUpdateTables ON WebCloudUpdates.TableNo = WebUpdateTables.TableNo
GROUP BY TableName, WebCloudUpdates.TableNo
ORDER BY 1;
"
    Public Shared WebCloudUpdates As String = "SELECT 
	wcu.TableNo, 
	wcu.datakey,  
	wut.TableName, 
	wcu.DataID, 
	wcu.Deleted, 
	wcu.LastAttempt 
FROM WebcloudUpdates AS wcu 
INNER JOIN WebUpdateTables AS wut ON wcu.tableno = wut.TableNo;

"
    Public Shared MessageLog As String = "SELECT TOP 100 [MsgDateTime], [StationNo], [ProgramName], [EmpNo], [MessageText], [StackTrace], [Error], [MsgID] FROM MessageLog ORDER by MsgDateTime DESC;"
    Public Shared MessageLogErrorCount As String = "SELECT TOP 100 CONVERT(DATE,MsgDateTime), ProgramName, COUNT(ProgramName) FROM MessageLog WHERE Error = 1 GROUP BY CONVERT(DATE,MsgDateTime),ProgramName ORDER BY 1 DESC"

End Class

Public Class MessageLogFilters
    Public Shared Errors As String = "0"
    Public Shared Limit As String = 100
    Public Shared DateRange As String = ""

    Public Shared MessageLog As String = "SELECT TOP {1} [MsgDateTime], [StationNo], [ProgramName], [EmpNo], [MessageText], [StackTrace], [Error], [MsgID] FROM MessageLog WHERE Error >= {0} {2} ORDER by MsgDateTime DESC;"
    Public Shared MessageLogErrorCount As String = "SELECT TOP {0} CONVERT(DATE,MsgDateTime), ProgramName, COUNT(ProgramName) FROM MessageLog WHERE Error = 1 {1} GROUP BY CONVERT(DATE,MsgDateTime),ProgramName ORDER BY 1 DESC"



End Class