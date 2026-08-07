Imports System.ComponentModel

Public Class DatabaseViewController

    Private ReadOnly _form As FormMain

    Public Sub New(form As FormMain)
        _form = form
    End Sub

    ' =========================
    ' DB INFO
    ' =========================
    Public Sub RefreshInfo()

        If Variables.OfflineMode Then Return

        If Not (_form.rbDbTableSize.Checked OrElse
                _form.rbDbFragmentation.Checked OrElse
                _form.rbDbSizeByDay.Checked OrElse
                _form.rbDbDeadlocks.Checked) Then
            Return
        End If

        _form.btnDbInfoRefresh.Enabled = False
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim query As String = ""

            If _form.rbDbTableSize.Checked Then
                query = DbInfo.DbSizeByTable

            ElseIf _form.rbDbFragmentation.Checked Then
                query = DbInfo.DbFragmentation

            ElseIf _form.rbDbSizeByDay.Checked Then
                query = String.Format(DbInfo.DbSizeByDay, ConfigValues.Database)

            ElseIf _form.rbDbDeadlocks.Checked Then
                query = DbInfo.DbDeadlocks
            End If

            Dim ds As DataSet = SafeDb.TryQuery(query)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                _form.dgvDbTableSize.DataSource = ds.Tables(0)
            Else
                _form.dgvDbTableSize.DataSource = Nothing
            End If

            _form.dgvDbTableSize.Refresh()

        Catch ex As SafeDb.DatabaseOfflineException
            DatabaseCoordinator.GoOffline("Lost DB connection during DbInfoRefresh")
            _form.dgvDbTableSize.DataSource = Nothing

        Catch ex As Exception

            UIHelpers.TimedInfoPrompt(
                _form,
                $"Failed to refresh database info:{Environment.NewLine}{ex.Message}",
                "Database Error")

            _form.dgvDbTableSize.DataSource = Nothing
        Finally
            Cursor.Current = Cursors.Default
            _form.btnDbInfoRefresh.Enabled = True
        End Try

    End Sub

    ' =========================
    ' DB LOGS
    ' =========================
    Public Sub RefreshLogs()

        If Variables.OfflineMode Then Return

        Try
            If _form.rbWebCloudUpdates.Checked Then

                _form.gpDbLogCount.Text = "Count per table"
                _form.gpDbLogData.Text = "All WebCloudUpdates Entries"

                Dim dsCount As DataSet = SafeDb.TryQuery(LogQueries.WebCloudTotalCount)

                If dsCount IsNot Nothing AndAlso dsCount.Tables.Count > 0 Then
                    _form.dgvDbLogCount.DataSource = dsCount.Tables(0)
                    _form.dgvDbLogCount.Columns(0).Visible = False
                    _form.dgvDbLogCount.Columns(1).HeaderText = "Table"
                    _form.dgvDbLogCount.Columns(2).HeaderText = "Count"
                Else
                    _form.dgvDbLogCount.DataSource = Nothing
                End If

                Dim dsData As DataSet = SafeDb.TryQuery(LogQueries.WebCloudUpdates)

                If dsData IsNot Nothing AndAlso dsData.Tables.Count > 0 Then
                    _form.dgvDbLogData.DataSource = dsData.Tables(0)
                Else
                    _form.dgvDbLogData.DataSource = Nothing
                End If

            ElseIf _form.rbMessageLog.Checked Then

                CodeHelper.MsgLogBuilder(
                    MessageLogFilters.Errors,
                    MessageLogFilters.Limit,
                    MessageLogFilters.DateRange)

                _form.gpDbLogCount.Text = "Errors per day"
                _form.gpDbLogData.Text = "MessageLog"

                Dim dsErrCount As DataSet = SafeDb.TryQuery(LogQueries.MessageLogErrorCount)

                If dsErrCount IsNot Nothing AndAlso dsErrCount.Tables.Count > 0 Then
                    _form.dgvDbLogCount.DataSource = dsErrCount.Tables(0)
                    _form.dgvDbLogCount.Columns(0).Visible = True
                    _form.dgvDbLogCount.Columns(0).HeaderText = "Date"
                    _form.dgvDbLogCount.Columns(1).HeaderText = "Program"
                    _form.dgvDbLogCount.Columns(2).HeaderText = "Count"
                Else
                    _form.dgvDbLogCount.DataSource = Nothing
                End If

                Dim dsLog As DataSet = SafeDb.TryQuery(LogQueries.MessageLog)

                If dsLog IsNot Nothing AndAlso dsLog.Tables.Count > 0 Then
                    _form.dgvDbLogData.DataSource = dsLog.Tables(0)
                    _form.dgvDbLogData.Sort(_form.dgvDbLogData.Columns(0), ListSortDirection.Descending)
                Else
                    _form.dgvDbLogData.DataSource = Nothing
                End If

            Else
                _form.gpDbLogData.Text = ""
                _form.gpDbLogCount.Text = ""
                Return
            End If

            _form.dgvDbLogData.Refresh()

        Catch ex As SafeDb.DatabaseOfflineException
            DatabaseCoordinator.GoOffline("Lost DB connection during DbLogRefresh")
            _form.dgvDbLogCount.DataSource = Nothing
            _form.dgvDbLogData.DataSource = Nothing
        Catch ex As Exception

            UIHelpers.TimedInfoPrompt(
        _form,
        $"Database log refresh failed:{Environment.NewLine}{ex.Message}",
        "Database Error")
        End Try

    End Sub

End Class
