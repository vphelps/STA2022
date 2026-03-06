Imports System.Runtime.Serialization

<DataContract>
Public Class AppOptions
    ' Keep this minimal for now; easy to extend later.
    <DataMember>
    Public Property WindowTitle As String = "My Application"
End Class