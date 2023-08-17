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