Public Class InstallerCleanupResult
    Public Property Deleted As New List(Of InstallerVersionInfo)
    Public Property Failed As New Dictionary(Of InstallerVersionInfo, Exception)
    Public Property Skipped As New List(Of InstallerVersionInfo)

    Public ReadOnly Property FreedBytes As Long
        Get
            Return Deleted.Sum(Function(v) v.SizeBytes)
        End Get
    End Property
End Class