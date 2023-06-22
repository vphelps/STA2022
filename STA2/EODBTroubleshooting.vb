Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Public Class EODBTroubleshooting
    Public Shared sqlDate As String
    Public Shared normDate As String
    Public Shared filePath As String

    Public Shared excelWorkbook As Microsoft.Office.Interop.Excel.Workbook

    Public Shared Sub releaseObject(ByVal obj As Object)

        Try

            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)

            obj = Nothing

        Catch ex As Exception

            obj = Nothing

        Finally

            GC.Collect()

        End Try

    End Sub

    Public Shared Function CreateSheet(ByRef dbResult As DataSet, ByRef xlWorkBook As Workbook)
        xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        Dim xlActiveSheet As Worksheet = xlWorkBook.ActiveSheet
        xlActiveSheet.Name = String.Format("{0:00}", xlWorkBook.Sheets.Count - 1)
        Dim Col1 As Integer
        Dim Row1 As Integer
        Try

            For Col = 0 To dbResult.Tables(0).Columns.Count - 1
                For Row = 0 To dbResult.Tables(0).Rows.Count - 1
                    Col1 = Col
                    Row1 = Row

                    xlActiveSheet.Cells(1, Col + 1) = dbResult.Tables(0).Columns(Col).ColumnName
                    xlActiveSheet.Cells(Row + 2, Col + 1) = dbResult.Tables(0).Rows(Row).Item(Col).ToString

                Next
            Next
        Catch ex As Exception
            ErrorHandler.WarningHandler(ex.Message)
        End Try




        Return xlActiveSheet

    End Function
    Public Shared Sub InsertHeader(ByRef xlWorksheet As Worksheet, strTemp1 As String)

        xlWorksheet.Rows(1).Insert()
        xlWorksheet.Cells(1, 1) = strTemp1

        xlWorksheet.Range("A1:M1").Merge()
        xlWorksheet.Range("A1").VerticalAlignment = Excel.Constants.xlCenter
        xlWorksheet.Range("A1").HorizontalAlignment = Excel.Constants.xlCenter

    End Sub

    Public Shared Sub SheetFormatting(ByRef xlWorksheet As Worksheet)
        If xlWorksheet.UsedRange.Cells.Count > 1 Then
            xlWorksheet.UsedRange.AutoFilter(Field:=1)
            xlWorksheet.Cells.EntireColumn.AutoFit()

        End If
    End Sub

    Public Shared Function CreateSheetFromXml(dbResult As DataSet, ByRef xlWorkBook As Workbook)
        Dim textString As String = ""

        Console.WriteLine("Entered CreateSheetFromXml")
        xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        Dim xlActiveSheet As Worksheet = xlWorkBook.ActiveSheet
        xlActiveSheet.Name = String.Format("{0:00}", xlWorkBook.Sheets.Count - 1)
        Dim Col1 As Integer
        Dim Row1 As Integer
        Dim row As Integer = dbResult.Tables(0).Rows.Count

        Dim Header1 As String
        Dim Header2 As String
        Dim Header3 As String
        Console.WriteLine("Sheet = " & xlActiveSheet.Name)
        Console.WriteLine("Reading Headers")
        Header1 = dbResult.Tables(0).Rows(dbResult.Tables(0).Rows.Count - 1)(0)
        Header2 = dbResult.Tables(0).Rows(dbResult.Tables(0).Rows.Count - 2)(0)
        Header3 = dbResult.Tables(0).Rows(dbResult.Tables(0).Rows.Count - 3)(0)
        If dbResult.Tables(0).Rows.Count > 2 Then
            dbResult.Tables(0).Rows.RemoveAt(dbResult.Tables(0).Rows.Count - 1)
            dbResult.Tables(0).Rows.RemoveAt(dbResult.Tables(0).Rows.Count - 1)
            dbResult.Tables(0).Rows.RemoveAt(dbResult.Tables(0).Rows.Count - 1)
        End If

        Try

            For Col = 0 To dbResult.Tables(0).Columns.Count - 1
                For row = 0 To dbResult.Tables(0).Rows.Count - 1
                    Col1 = Col
                    Row1 = row
                    Console.WriteLine(String.Format("Reading Data Col = {0} Row = {1}", Col1, Row1))
                    textString = "Sheet = " & xlActiveSheet.Name & vbCrLf & (String.Format("Reading Data Col = {0} Row = {1}", Col1, Row1))
                    FormMain.tbEodbProgress.Text = textString
                    xlActiveSheet.Cells(1, Col + 1) = dbResult.Tables(0).Columns(Col).ColumnName
                    xlActiveSheet.Cells(row + 2, Col + 1) = dbResult.Tables(0).Rows(row).Item(Col).ToString

                Next
            Next
        Catch ex As Exception

        End Try


        Console.Write("Inserting Headers")
        SheetFormatting(xlActiveSheet)
        InsertHeader(xlActiveSheet, Header1)
        InsertHeader(xlActiveSheet, Header2)
        InsertHeader(xlActiveSheet, Header3)



        Console.WriteLine("Exiting CreateSheetFromXml")
        Return xlActiveSheet


    End Function
End Class

Public Class EODBQueries
    'Verify the currency on the eod balance (remember to add/subtract over/short amounts)
    'Note: Generally not worried about Coupon, Discounts, or Player Card
    Public Shared EODBCurrency As String = "SELECT 'Verify the currency on the eod balance' AS Query,tillcodes.Description AS TillCodeDescription, sum(RecMoney.amount) AS Amount FROM RecMoney 
INNER JOIN tillcodes ON TillCodes.TillCode = RecMoney.TillCode 
INNER JOIN receipt ON receipt.RecID = RecMoney.RecID 
WHERE receipt.ShiftDate = '{0}' 
GROUP BY tillcodes.Description"

    'Sum reclines by item
    'Looking for amounts that might match the imbalance.
    Public Shared RecLinesByItem As String = "SELECT 'Sum reclines by item' AS Query,  invno, sum(amount) AS Amount FROM RecLines WHERE ShiftDate = '{0}'
GROUP BY invno
ORDER BY 2"

    'Look at line items sold for target date
    'Looking for detail for Sum reclines by item query.
    Public Shared LineItemsByDate As String = "SELECT 'Look at line items sold for target date' AS Query,  reclines.RecID, reclines.InvNo, Inventory.Description AS Description, reclines.Amount, RecLines.DiscAmt, RecLines.Qty
FROM RecLines
LEFT OUTER JOIN Inventory ON Inventory.InvNo = reclines.InvNo
WHERE ShiftDate = '{0}'
ORDER BY 2"

    'Look for sales allocations and non-sales
    'Looking for amounts that might match the imbalance. Also, should match the total for Sum reclines by item query.
    Public Shared SalesAllocationsNonSales As String = "SELECT 'Look for sales allocations and non-sales' AS Query,  sum(RecLineAllocations.Amount) AS Amount FROM RecLineAllocations
INNER JOIN RecLines ON RecLines.RecID = RecLineAllocations.RecID and reclines.LineItemNo = RecLineAllocations.LineItemNo
and shiftdate = '{0}'"

    'Look at player cards that were discounted
    'Should match Player Card Discounts Used total.
    Public Shared PlayerCardDiscounts As String = "SELECT 'Look at player cards that were discounted' AS Query,  * FROM PlayerCardDiscountsUsed
WHERE shiftdate = '{0}'"

'Look at the player cards added/used
'Should match Player Card Value Added and Player Card Value Used.
Public shared PlayerCardsAddUse As String = "SELECT 'Look at the player cards added/used' AS Query,  transtypes.Description AS Description, sum(amount) AS Amount, sum(dollaramount) AS DollarAmount FROM PlayerCardTrans
LEFT OUTER JOIN TransTypes ON TransTypes.TransType = PlayerCardTrans.TransType
WHERE TransDateTime >= '{0}' and TransDateTime < DATEADD(DAY,-1, '{0}') and amount <> DollarAmount
GROUP BY transtypes.Description"

    'Look at sales
    'Total of sales which should match the Sales Total 
    Public Shared Sales As String = "Select 'Look at sales' AS Query,  sum(AmtSold) as AmtSold, sum(Amtreturned) as AmtReturned, sum(amtsold - amtreturned) as NetAmt FROM sales WHERE shiftdate = '{0}'"

    'Total by Category and Subcategory
    'which should match the sales for Cat and Subcat
    Public Shared TotalCategorySubCategory As String = "SELECT 'Total by Category and Subcategory' AS Query, Categories.Description AS CategoryDescription, SubCategories.Description AS SubCategoryDescription, sum(amtsold - amtreturned) as NetAmt
FROM sales
INNER JOIN Inventory ON inventory.invno = sales.InvNo
INNER JOIN invmaster ON invmaster.MasterInvNo = inventory.MasterInvNo
INNER JOIN Categories ON Categories.catno = invmaster.CatNo
INNER JOIN SubCategories ON SubCategories.catno = InvMaster.CatNo and SubCategories.SubCatNo = InvMaster.SubCatNo
WHERE shiftdate = '{0}'
GROUP BY Categories.description, SubCategories.Description
ORDER BY Categories.description, SubCategories.Description"

    'Total Sales Tax
    Public Shared TotalSalesTax As String = "SELECT 'Total Sales Tax' AS Query,  TaxCode, sum(amount) as TotalAmt FROM SalesTaxes WHERE shiftdate = '{0}' GROUP BY TaxCode"

    'Total Deposits Received and Redeemed
    Public Shared TotalDeposits As String = "SELECT 'TotalDepositsReceived' AS Query,  birthdayevent, sum(amount) as TotalDepositsReceived FROM DepositsReceived WHERE ShiftDate = '{0}' GROUP BY BirthdayEvent
UNION ALL
SELECT 'TotalDepositsRedeemed' AS Query,  birthdayevent, sum(amount) as TotalDepositsRedeemed FROM DepositsRedeemed WHERE ShiftDate = '{0}' GROUP BY BirthdayEvent"

    'Deposits Received 
    Public Shared DepositsReceived As String = "SELECT 'Look at deposit received' AS Query,  ShiftDate, Amount, Description , TillCodeDescription AS TillCodeDescription, TillCode, TranCode, RefNo, BirthdayEvent FROM DepositsReceived WHERE ShiftDate = '{0}'"

    'Deposits Redeemed
    Public Shared DepositsRedeemed As String = "SELECT 'Look at deposit redeemed' AS Query,  ShiftDate, RefNo, Description , Amount, BirthdayEvent FROM DepositsRedeemed WHERE ShiftDate = '{0}'"

    'Show Receipts that are refunds
    Public Shared RefundReceipts As String = "SELECT 'Show Receipts that are refunds' AS Query,  * FROM Receipt WHERE shiftdate = '{0}' and RefundRecId is not null"

    'Show Receipts that have been refunded(Receipt Table)
    Public Shared ReceiptsRefunded As String = "SELECT 'Show Receipts that have been refunded(Receipt Table)' AS Query,  * FROM Receipt WHERE recid IN (SELECT RefundRecId FROM Receipt WHERE shiftdate = '{0}' and RefundRecId is not null)"

    'Show Receipts that have been refunded(RecLines Table)
    Public Shared RecLinesRefunded As String = "SELECT 'Show Receipts that have been refunded(RecLines Table)' AS Query,  * FROM RecLines WHERE recid IN (SELECT RefundRecId FROM Receipt WHERE shiftdate = '{0}' and RefundRecId is not null)"

    'Look for returned items
    Public Shared ReturnedItems As String = "SELECT 'Look for returned items' AS Query,  * FROM reclines WHERE ShiftDate = '{0}' and Qty < 0"

    'Run this to see info on items FROM returned RecLines
    Public Shared ReturnedInventory As String = "SELECT 'Run this to see info on items FROM returned RecLines' AS Query,  * FROM Inventory WHERE invno in (SELECT InvNo FROM reclines WHERE ShiftDate = '{0}' and Qty < 0)"

    'Look for taxable player cards
    Public shared TaxablePlayerCards As String ="SELECT 'Look for taxable player cards' AS Query,  * FROM InvSnapShot
LEFT OUTER JOIN inventory ON inventory.InvID = InvSnapShot.InvID
LEFT OUTER JOIN invmaster ON invmaster.MasterInvno = inventory.MasterInvNo
WHERE (itemtype = 3 or itemtype = 8 or ItemType = 19) and InvSnapShot.Taxable <> 0 AND ShiftDate = '{0}'"


    'Look for package items that are not referencing a inventory item
    Public shared PackagesEmpty As String = " SELECT 'Look for package items that are not referencing a inventory item' AS Query,  * FROM Packages
LEFT OUTER JOIN InvMaster ON invmaster.MasterInvNo = packages.MasterInvNo
LEFT OUTER JOIN inventory ON inventory.invno = packages.PackInvNo
WHERE invmaster.MasterInvNo is null or inventory.InvNo is null"

End Class