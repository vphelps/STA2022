Imports System.Runtime.Serialization

<DataContract>
Public Class AppOptions
    ' Keep this minimal; make OptionsManager the single source of truth.
    <DataMember>
    Public Property WindowTitle As String = "Technician's Assistant"
    <DataMember>
    Public Property RepoFolderPath As String


    <DataMember>
    Public Property SetupSwitches As String


    ' Do NOT initialize here; let OptionsManager initialize/normalize.
    <DataMember>
    Public Property QuickLaunchIds As List(Of String)
End Class