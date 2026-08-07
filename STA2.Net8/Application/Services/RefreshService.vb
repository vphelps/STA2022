Public Class RefreshService
    Public Function LoadLicenseData() As LicenseDataResult

        Dim dsLic As DataSet =
        SafeDb.TryQuery(GeneralQueries.LicenseData)

        If dsLic Is Nothing OrElse
       dsLic.Tables.Count = 0 OrElse
       dsLic.Tables(0).Rows.Count = 0 Then

            Throw New Exception(
            "LicenseData returned no rows.")

        End If

        AppData.dbLicData = dsLic

        Dim r = dsLic.Tables(0).Rows(0)

        Return New LicenseDataResult With {
        .LocationName = r("LocName").ToString(),
        .LicenseServer = r("LicenseServer").ToString(),
        .CoreServer = r("CoreServiceServerName").ToString(),
        .DatabaseVersion = r("Version").ToString(),
        .WebEnabled = r("EnableWeb").ToString(),
        .ShiftDate = r("ShiftDate").ToString()
    }

    End Function

End Class