SELECT tblItemClass.sShortID, tblOrderItems.sDescription,COUNT(*) AS Number, SUM(cPrice) as Total FROM tblItems 
 JOIN  tblOrderItems
 ON tblItems.iOrderItemID = tblOrderItems.ID JOIN tblItemClass
 ON tblOrderItems.iItemClassID = tblItemClass.ID
 WHERE dAccounting > '11-01-2008' AND dAccounting < '12-31-2008' 
 AND tblItems.iAccountingUnitID = 1
 GROUP BY tblOrderItems.sDescription, tblItemClass.sShortID
 