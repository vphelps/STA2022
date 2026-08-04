Public Class SelectInstallerVersionForm
    Public ReadOnly Property SelectedVersion As String
        Get

            If lstVersions.SelectedItem Is Nothing Then
                Return Nothing
            End If

            Return lstVersions.SelectedItem.ToString()

        End Get
    End Property
    Public Sub LoadVersions(
    versions As IEnumerable(Of String)
)

        lstVersions.Items.Clear()

        For Each version In versions
            lstVersions.Items.Add(version)
        Next

        If lstVersions.Items.Count > 0 Then
            lstVersions.SelectedIndex = 0
        End If

    End Sub
    Private Sub SelectInstallerVersionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class