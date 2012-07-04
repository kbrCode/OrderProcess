SELECT tblAccountingUnits.sShortID, tblItemClass.sShortID, SUM(cPrice) FROM tblItems JOIN tblAccountingUnits
 ON tblItems.iAccountingUnitID = tblAccountingUnits.ID JOIN  tblOrderItems
 ON tblItems.iOrderItemID = tblOrderItems.ID JOIN tblItemClass
 ON tblOrderItems.iItemClassID = tblItemClass.ID
 WHERE dAccounting > '11-01-2008' AND dAccounting < '12-31-2008'
 GROUP BY tblAccountingUnits.sShortID, tblItemClass.sShortID