Imports System.Threading

Public Interface IDatabaseService

    Function EvaluateDatabaseAvailabilityAsync(
        ct As CancellationToken
    ) As Task(Of DatabaseHealth)

End Interface