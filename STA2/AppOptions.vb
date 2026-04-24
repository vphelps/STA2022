Imports System.IO
Imports System.Runtime.Serialization

<DataContract>
Public Class AppOptions

    <DataMember>
    Public Property WindowTitle As String = "Technician's Assistant"

    <DataMember>
    Public Property RepoFolderPath As String

    <DataMember>
    Public Property SetupSwitches As String

    <DataMember>
    Public Property QuickLaunchIds As List(Of String)

    <DataMember>
    Public Property DefaultFlavorNames As List(Of String)

    <IgnoreDataMember>
    Public ReadOnly Property FlavorFolderPath As String
        Get
            If String.IsNullOrWhiteSpace(RepoFolderPath) Then
                Return Nothing
            End If

            Return Path.Combine(RepoFolderPath, "tests", "flavors")
        End Get
    End Property

End Class
