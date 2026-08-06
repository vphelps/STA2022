Imports System.Data
Imports STA2.Net8
Imports Xunit

Public Class SafeDbTests
    <Fact>
    Public Sub ConvertToDataSet_ReturnsOriginalDataSet()

        Dim ds As New DataSet()

        Dim result = SafeDb.ConvertToDataSet(ds)

        Assert.Same(ds, result)

    End Sub
    <Fact>
    Public Sub ConvertToDataSet_ConvertsInteger()

        Dim result = SafeDb.ConvertToDataSet(123)

        Assert.Single(result.Tables)

        Assert.Equal(
            123,
            result.Tables(0).Rows(0)("Value"))

    End Sub
    <Fact>
    Public Sub ConvertToDataSet_ConvertsString()

        Dim result = SafeDb.ConvertToDataSet("Hello")

        Assert.Equal(
            "Hello",
            result.Tables(0).Rows(0)("Value"))

    End Sub
    <Fact>
    Public Sub ConvertToDataSet_ConvertsNothingToDBNull()

        Dim result = SafeDb.ConvertToDataSet(Nothing)

        Assert.Equal(
            DBNull.Value,
            result.Tables(0).Rows(0)("Value"))

    End Sub
End Class
