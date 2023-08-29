Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class DataPumpStorage
    Public Shared DataPumpCredentials As New DataSet
    Public Shared DataPumpDestinations As New DataSet
    Public Shared DataPumps As New DataSet

End Class

Public Class DatapumpQueries
    Public Shared Datapumps As String = "SELECT * FROM DataPumps"
    Public Shared DataPumpCredentials As String = "SELECT * FROM DataPumpCredentials"
    Public Shared DataPumpDestinations As String = "SELECT * FROM DataPumpDestinations"

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
    Public Shared StartTime As TimeSpan

    Public Shared Interval As Integer

    Public Shared Enabled As Boolean

    Public Property LastCompletion As Date

    Public Property LastFailure As Date

    Public Property ConsecutiveFailureCount As Integer
End Class


Public Class DataPumpHelpers
    Public Shared Sub ConnectBindingSource()

    End Sub
End Class