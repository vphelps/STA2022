Public Class DeferredRevenue
    Public Shared pcDeferred As Double

End Class

Public Class DeferredRevenueQueries
    Public Shared InventoryItem As String = "SELECT Inventory.InvNo, InvMaster.MasterInvNo, Inventory.Description ,InvMaster.CatNo, InvMaster.SubCatNo, Categories.Description, SubCategories.Description FROM Inventory 
INNER JOIN InvMaster ON Inventory.MasterInvNo = InvMaster.MasterInvNo
INNER JOIN Categories ON InvMaster.CatNo = Categories.CatNo
INNER JOIN SubCategories ON InvMaster.CatNo = SubCategories.CatNo AND InvMaster.SubCatNo = SubCategories.SubCatNo
WHERE Inventory.InvNo = {0}"
    Public Shared pcDRValues = "SELECT SUM(AmountPaid1 + AmountPaid2 + AmountPaid3 + AmountPaid4 + AmountPaid5) from PlayerCardExpValues"
    Public Shared SubCatSalesUpdate = "UPDATE SubCatSales SET TotalSales= TotalSales+ {0} WHERE ShiftDate= '{1}' AND CatNo = {2} AND SubCatno = {3}"
    Public Shared SaleInsert = "INSERT INTO Sales([ShiftDate], [SessionNumber], [DivNo], [InvNo], [QtySold], [AmtSold], [CostSold], [Qtyreturned], [Amtreturned], [CostReturned], [NumberTickets], [QtyWasted], [CostWasted], [Discounts], [CatNo], [SubCatNo]) VALUES ('{0}', 0,  1, {1}, 1, {2}, 0, 0, 0, 0, 0, 0, 0, 0, {3}, {4})"
    Public Shared pcCardValues = "UPDATE PlayerCardExpValues set AmountPaid1 = 0, AmountPaid2 = 0, AmountPaid3 = 0, AmountPaid4 = 0, AmountPaid5 = 0"
    Public Shared SalesCount = "SELECT COUNT(*) FROM Sales WHERE ShiftDate= '{0}' AND InvNo = {1}"
    Public Shared DRUpdate = "INSERT INTO DeferredRevenue(ShiftDate,InAmount,OutAmount) VALUES ('{0}', 0, {1})"
    Public Shared pcDRswitch = "UPDATE ApplicationInfo SET DeferValuePlayerCards = 0"
End Class

Public Structure InventoryItem
    Public Shared InvNo As Integer
    Public Shared MasterInvNo As Integer
    Public Shared CatNo As Integer
    Public Shared SubCatNo As Integer
    Public Shared CatName As String
    Public Shared SubCatName As String
    Public Shared InvName As String

End Structure