' LauncherConfig.vb
Imports System.Runtime.Serialization

<DataContract>
Public Class LauncherConfig
    <DataMember> Public Property Version As Integer = 1
    <DataMember> Public Property Programs As List(Of ProgramEntry) = New List(Of ProgramEntry)()
End Class