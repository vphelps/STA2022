Imports System.IO

Public Class ConnectionProfilesForm
    Public Property ConnectionChanged As Boolean

    Private Sub LoadProfiles()

        lstProfiles.Items.Clear()

        lstProfiles.Items.AddRange(
        ConnectionProfileManager.
            GetProfiles().
            Cast(Of Object)().
            ToArray())

    End Sub
    Private Sub RefreshCurrentConnection()

        Dim info =
        ConnectionProfileManager.GetActiveConnectionInfo()

        lblServer.Text = info.DataSource

        lblDatabase.Text = info.Catalog

    End Sub
    Private Sub ConnectionProfilesForm_Load(
    sender As Object,
    e As EventArgs
) Handles MyBase.Load

        LoadProfiles()

        RefreshCurrentConnection()

        SelectActiveProfile()

    End Sub
    Private Sub btnLaunchConfig_Click(sender As Object, e As EventArgs) Handles btnLaunchConfig.Click

        Dim executable As String = "AdvConfig"

        Dim version As Integer = CodeHelper.AdvExeCheck(executable)

        If version = FormMain.AppInstallState.InstalledX86 Then
            executable = $"{AppData.CEPath86}{executable}.exe"
        ElseIf version = FormMain.AppInstallState.InstalledX64 Then
            executable = $"{AppData.CEPath64}{executable}.exe"
        End If

        If Not IO.File.Exists(executable) Then
            MessageBox.Show(
            $"Unable to locate:{Environment.NewLine}{executable}",
            "Application Not Found",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Process.Start(executable)

    End Sub
    Private Sub btnSaveCurrentAs_Click(
    sender As Object,
    e As EventArgs
) Handles btnSaveCurrentAs.Click

        Dim profileName As String =
            InputBox(
                "Enter a profile name.",
                "Save Connection Profile")

        If String.IsNullOrWhiteSpace(profileName) Then
            Return
        End If

        Try

            ConnectionProfileManager.
                SaveCurrentProfile(profileName)

            LoadProfiles()

            MessageBox.Show(
                $"Profile '{profileName}' created successfully.",
                "Profile Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As IOException

            MessageBox.Show(
                $"A profile named '{profileName}' already exists.",
                "Duplicate Profile",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Unable to Save Profile",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub btnActivate_Click(
    sender As Object,
    e As EventArgs
) Handles btnApply.Click

        If lstProfiles.SelectedItem Is Nothing Then

            MessageBox.Show(
                "Please select a profile.",
                "No Profile Selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Return

        End If

        Dim profileName =
            lstProfiles.SelectedItem.ToString

        Try

            ConnectionProfileManager.ActivateProfile(profileName)

            RefreshCurrentConnection()
            SelectActiveProfile()
            ConnectionChanged = True

            MessageBox.Show(
                $"Profile '{profileName}' activated successfully." &
                Environment.NewLine &
                Environment.NewLine &
                "Applications may need to be restarted for changes to take effect.",
                "Profile Activated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Activation Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub btnDelete_Click(
    sender As Object,
    e As EventArgs
) Handles btnDelete.Click

        If lstProfiles.SelectedItem Is Nothing Then

            MessageBox.Show(
                "Please select a profile to delete.",
                "No Profile Selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Return

        End If

        Dim profileName As String =
            lstProfiles.SelectedItem.ToString()
        Dim activeProfileName =
    ConnectionProfileManager.GetActiveProfileName()

        If String.Equals(
    profileName,
    activeProfileName,
    StringComparison.OrdinalIgnoreCase) Then

            MessageBox.Show(
        "The active connection profile cannot be deleted." &
        Environment.NewLine &
        Environment.NewLine &
        "Activate another profile first.",
        "Profile In Use",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information)

            Return

        End If

        Dim result =
            MessageBox.Show(
                $"Delete profile '{profileName}'?" &
                Environment.NewLine &
                Environment.NewLine &
                "This will not affect the active PFSConnect.ini file.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2)

        If result <> DialogResult.Yes Then
            Return
        End If

        Try

            ConnectionProfileManager.DeleteProfile(profileName)

            LoadProfiles()
            If lstProfiles.Items.Count > 0 Then
                lstProfiles.SelectedIndex = 0
            End If
            MessageBox.Show(
                $"Profile '{profileName}' was deleted.",
                "Profile Deleted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Delete Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub btnRefresh_Click(
    sender As Object,
    e As EventArgs
) Handles btnRefresh.Click

        Try

            LoadProfiles()

            RefreshCurrentConnection()

            If lstProfiles.Items.Count > 0 Then
                lstProfiles.SelectedIndex = 0
            End If

        Catch ex As Exception

            MessageBox.Show(
            ex.Message,
            "Refresh Failed",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub lstProfiles_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
) Handles lstProfiles.SelectedIndexChanged

        RefreshSelectedProfileInfo()

    End Sub
    Private Sub RefreshSelectedProfileInfo()

        If lstProfiles.SelectedItem Is Nothing Then

            lblSelectedServer.Text = ""
            lblSelectedDatabase.Text = ""

            Return

        End If

        Dim profileName As String =
            lstProfiles.SelectedItem.ToString()

        Dim profilePath =
            Path.Combine(
                ConnectionProfileManager.ProfilesFolder,
                $"{profileName}.ini")

        Dim info =
            ConnectionProfileManager.ReadConnectionInfo(profilePath)

        lblSelectedServer.Text = info.DataSource

        lblSelectedDatabase.Text = info.Catalog

    End Sub
    Private Sub SelectActiveProfile()

        Dim activeInfo =
            ConnectionProfileManager.GetActiveConnectionInfo()

        If activeInfo Is Nothing Then Return

        For i As Integer = 0 To lstProfiles.Items.Count - 1

            Dim profileName As String =
                lstProfiles.Items(i).ToString()

            Dim profilePath As String =
                Path.Combine(
                    ConnectionProfileManager.ProfilesFolder,
                    $"{profileName}.ini")

            Dim profileInfo =
                ConnectionProfileManager.ReadConnectionInfo(profilePath)

            If String.Equals(
                activeInfo.DataSource,
                profileInfo.DataSource,
                StringComparison.OrdinalIgnoreCase) AndAlso
               String.Equals(
                activeInfo.Catalog,
                profileInfo.Catalog,
                StringComparison.OrdinalIgnoreCase) Then

                lstProfiles.SelectedIndex = i

                Exit For

            End If

        Next

    End Sub
    Private Sub btnRename_Click(
    sender As Object,
    e As EventArgs
) Handles btnRename.Click

        If lstProfiles.SelectedItem Is Nothing Then

            MessageBox.Show(
                "Please select a profile to rename.",
                "No Profile Selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Return

        End If

        Dim oldName As String =
            lstProfiles.SelectedItem.ToString()

        Dim newName As String =
            InputBox(
                "Enter a new profile name.",
                "Rename Profile",
                oldName)

        If String.IsNullOrWhiteSpace(newName) Then
            Return
        End If

        If String.Equals(
            oldName,
            newName,
            StringComparison.OrdinalIgnoreCase) Then

            Return

        End If

        Try

            ConnectionProfileManager.RenameProfile(
                oldName,
                newName)

            LoadProfiles()

            For i As Integer = 0 To lstProfiles.Items.Count - 1

                If String.Equals(
                    lstProfiles.Items(i).ToString(),
                    newName,
                    StringComparison.OrdinalIgnoreCase) Then

                    lstProfiles.SelectedIndex = i

                    Exit For

                End If

            Next

            RefreshSelectedProfileInfo()

            MessageBox.Show(
                $"Profile renamed from '{oldName}' to '{newName}'.",
                "Profile Renamed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Rename Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub
End Class