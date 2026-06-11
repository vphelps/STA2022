<Serializable>
Public Class AppOptions
    ' -------------------------------------------------
    ' AdvUpgrade options
    ' -------------------------------------------------

    Public Property AdvUpgradeQuiet As Boolean = False
    Public Property AdvUpgradeNoBackup As Boolean = False
    Public Property AdvUpgradeNoSetup As Boolean = False


    ' -------------------------------------------------
    ' General UI / application behavior
    ' -------------------------------------------------

    Public Property WindowTitle As String

    ' Persisted toggle: show services that are not installed
    Public Property ShowHiddenServices As Boolean = False


    ' -------------------------------------------------
    ' Repository / paths
    ' -------------------------------------------------

    Public Property RepoFolderPath As String
    Public Property FlavorFolderPath As String
    Public Property BackupPathOverride As String
    Public Property BackupScriptPath As String

    ' -------------------------------------------------
    ' Database / SQL
    ' -------------------------------------------------

    Public Property SqlContainerName As String
    Public Property ConnectionString As String


    ' -------------------------------------------------
    ' Installer / setup defaults
    ' -------------------------------------------------

    Public Property SetupSwitches As String
    Public Property StartDatabaseDefault As String
    Public Property ApplyFlavorDefault As String


    ' -------------------------------------------------
    ' Flavor selection defaults
    ' -------------------------------------------------

    Public Property DefaultFlavorNames As List(Of String)


    ' -------------------------------------------------
    ' Quick Launch
    ' -------------------------------------------------

    ' List length normalized by OptionsManager
    Public Property QuickLaunchIds As List(Of String)

    ' IDs assigned to toolbar / quick buttons
    Public Property QuickLaunchButtonIds As List(Of String)


    ' -------------------------------------------------
    ' Constructor
    ' -------------------------------------------------

    Public Sub New()

        ' Ensure collections are initialized
        DefaultFlavorNames = New List(Of String)
        QuickLaunchIds = Nothing          ' Initialized by OptionsManager
        QuickLaunchButtonIds = New List(Of String)

        ' Sensible string defaults
        WindowTitle = String.Empty
        RepoFolderPath = String.Empty
        FlavorFolderPath = String.Empty
        SetupSwitches = String.Empty
        StartDatabaseDefault = String.Empty
        ApplyFlavorDefault = String.Empty

        ' Feature toggles
        ShowHiddenServices = False

    End Sub

End Class
