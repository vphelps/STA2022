Public Enum ReleaseTrack
    LongTermSupport
    FastTrack
End Enum

Public Class InstallerVersionInfo

    Public Property Version As Version
    Public Property VersionString As String
    Public Property FolderPath As String

    Public Property CreationTime As DateTime
    Public Property SizeBytes As Long

    Public Property Track As ReleaseTrack
    Public Property IsLatest As Boolean

    ' Filled later by safety logic
    Public Property IsInUse As Boolean = False
    Public Property HasLockedFiles As Boolean = False

    Public Property LockReason As VersionLockReason = VersionLockReason.None

    Public ReadOnly Property CanDelete As Boolean
        Get
            Return LockReason = VersionLockReason.None
        End Get
    End Property


End Class