SELECT tblAccountingUnits.sShortID, tblItemClass.sShortID, SUM(cPrice) FROM tblItems 
JOIN tblOrderItems ON tblItems.iOrderItemID = tblOrderItems.ID
JOIN tblAccountingUnits ON tblItems.iAccountingUnitID = tblAccountingUnits.ID
JOIN tblItemClass ON tblOrderItems.iItemClassID = tblItemClass.ID
WHERE dAccounting > '01-01-2009' AND dAccounting < '01-30-2009'
GROUP BY tblAccountingUnits.sShortID, tblItemClass.sShortID