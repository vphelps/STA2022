Imports System.Runtime.Serialization

<DataContract>
Public Class AppOptions
    ' Keep this minimal for now; easy to extend later.
    <DataMember>
    Public Property WindowTitle As String = "Technician's Assistant"

    ' Store ProgramEntry Ids for each quick slot (empty string = unassigned)
    <DataMember>
    Public Property QuickLaunchIds As List(Of String) = New List(Of String)(New String() {"", "", "", "", ""}) ' 5 slots by default
End Class