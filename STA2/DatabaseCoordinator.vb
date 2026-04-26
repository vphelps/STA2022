Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Module DatabaseCoordinator

    ' ============================================================
    ' Connectivity
    ' ============================================================
    Public Function TestConnection(connectionString As String) As Boolean
        Try
            Using cn As New SqlConnection(connectionString)
                cn.Open()
                Return (cn.State = ConnectionState.Open)
            End Using
        Catch
            Return False
        End Try
    End Function


    ' ============================================================
    ' State transitions
    ' ============================================================
    Public Sub GoOffline(form As FormMain, reason As String)

        Variables.OfflineMode = True
        PCInfo.ValidDatabase = False

        DisableDatabaseSections(form)

        ' Status indicator
        If form.tslblDbState IsNot Nothing Then
            form.tslblDbState.Text = "OFFLINE"
            form.tslblDbState.ForeColor = Color.White
            form.tslblDbState.BackColor = Color.Firebrick
        End If

    End Sub


    Public Sub GoOnline(form As FormMain)

        Variables.OfflineMode = False
        PCInfo.ValidDatabase = True

        EnableDatabaseSections(form)

        ' Refresh application state
        CodeHelper.GetPcInfo()
        CodeHelper.FirstLoad()
        CodeHelper.Refresher()

        ' Status indicator
        If form.tslblDbState IsNot Nothing Then
            form.tslblDbState.Text = "ONLINE"
            form.tslblDbState.ForeColor = Color.WhiteSmoke
            form.tslblDbState.BackColor = Color.DarkGreen
        End If

    End Sub


    ' ============================================================
    ' UI helpers (FormMain‑aware by design)
    ' ============================================================
    Public Sub DisableDatabaseSections(form As FormMain)

        form.tbPcDbSize.Text = "Offline"
        form.tbPcSqlVersion.Text = "Offline"
        form.dgvAppOptions.DataSource = Nothing

        form.tpAdvData.Enabled = False
        form.tpDbLogs.Enabled = False
        form.pnlDbData.Enabled = False
        form.pnlDbInfoButtons.Enabled = False

    End Sub


    Public Sub EnableDatabaseSections(form As FormMain)

        form.tpAdvData.Enabled = True
        form.tpDbLogs.Enabled = True
        form.pnlDbData.Enabled = True
        form.pnlDbInfoButtons.Enabled = True

        form.tbPcDbSize.Text = ""
        form.tbPcSqlVersion.Text = ""

    End Sub

End Module
