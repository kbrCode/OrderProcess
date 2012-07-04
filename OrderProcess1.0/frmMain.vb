Public Class frmMain
   Dim db As OrderProcessDB
   Dim objOrders As Orders
   Dim objOrderItems As OrderItems
   Dim objItems As Items
   Dim objAccountingUnits As AccountingUnits
   Dim objItemClasses As ItemClasses
   Dim objSuppliers As Suppliers
   Dim objOrderableItems As OrderableItems
   Dim objConfirmedItems As ConfirmedItems
   Dim dsType As dsTypes = Nothing
   Dim dsID As Nullable(Of Integer) = Nothing
   Dim IsStarting As Boolean = True
   Dim frmAllConfirmedItems As frmConfirmedItems
   Dim frmAllOrderedItems As frmConfirmedItems
   Dim dragData As Object

   Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      db = New OrderProcessDB("Server=marcm001\sqlexpress;Database=OrderProcess;Trusted_Connection=True;")
      objOrders = New Orders(db, tvMain.Nodes("ndOrders"))
      objOrders.AddNodes()
      For Each ord As Order In objOrders.List
         Dim ordit As New OrderItems(db, ord)
         ordit.AddNodes(tvMain.Nodes("ndOrders").Nodes(ord.Nr))
      Next
      objItems = New Items(db)
      objAccountingUnits = New AccountingUnits(db, tvMain.Nodes("ndAccountingUnits"))
      objAccountingUnits.AddNodes()
      objItemClasses = New ItemClasses(db, tvMain.Nodes("ndItemClasses"))
      objItemClasses.AddNodes()
      objSuppliers = New Suppliers(db, tvMain.Nodes("ndSuppliers"))
      objSuppliers.AddNodes()
      objOrderableItems = New OrderableItems(db)
      objConfirmedItems = New ConfirmedItems(db)
      dgvMain.DataSource = objOrders.List
      dsType = dsTypes.Orders
      dsID = Nothing
      ReadWindowState()
   End Sub
   Private Sub WriteWindowState()
      Dim regShareKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\OfferProcess", True)
      If regShareKey Is Nothing Then
         regShareKey = Registry.CurrentUser.CreateSubKey("Software\OfferProcess")
      End If
      regShareKey.SetValue("LastWindowState", WindowState.ToString)
      If WindowState = FormWindowState.Maximized Or WindowState = FormWindowState.Minimized Then
         WindowState = FormWindowState.Normal
      End If
      regShareKey.SetValue("LastWidth", Width.ToString)
      regShareKey.SetValue("LastHeight", Height.ToString)
      regShareKey.SetValue("LastXPos", Left.ToString)
      regShareKey.SetValue("LastYPos", Top.ToString)
      regShareKey.SetValue("LastSplitterDistance", scMain.SplitterDistance)
      regShareKey.Close()
   End Sub
   Private Sub ReadWindowState()
      Dim regShareKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\OfferProcess", True)
      If Not (regShareKey Is Nothing) Then
         Width = regShareKey.GetValue("LastWidth", 800)
         Height = regShareKey.GetValue("LastHeight", 600)
         Left = regShareKey.GetValue("LastXPos", 0)
         Top = regShareKey.GetValue("LastYPos", 0)
         Dim pt As New Point(Left, Top)
         Dim ScreenBounds As Rectangle = Screen.GetBounds(pt)
         If (Left < ScreenBounds.Left) Or (Left > ScreenBounds.Left + ScreenBounds.Width - 50) Then
            Left = ScreenBounds.Left
         End If
         If (Top < ScreenBounds.Top) Or (Top > ScreenBounds.Top + ScreenBounds.Height - 50) Then
            Top = ScreenBounds.Top
         End If
         scMain.SplitterDistance = regShareKey.GetValue("LastSplitterDistance", 264)
         If regShareKey.GetValue("LastWindowState", "Normal") = "Maximized" Then
            WindowState = FormWindowState.Maximized
         ElseIf (regShareKey.GetValue("LastWindowState", "Normal") = "Minimized") Then
            WindowState = FormWindowState.Minimized
         End If
         regShareKey.Close()
         Update()
      End If
   End Sub

   Private Sub mmOrderNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmOrderNew.Click
      If objOrders.NewOrder(objSuppliers) = Windows.Forms.DialogResult.OK Then
         dgvMain.DataSource = objOrders.List
         dsType = dsTypes.Orders
      End If
   End Sub
   Private Sub mmItemClassNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmItemClassNew.Click
      If objItemClasses.NewItemClass() = Windows.Forms.DialogResult.OK Then
         dgvMain.DataSource = objItemClasses.List
         dsType = dsTypes.ItemClasses
      End If
   End Sub
   Private Sub mmExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmExit.Click
      Me.Close()
   End Sub

#Region "dgvMain"
   Private Sub dgvMain_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles dgvMain.MouseDown
      If e.Button = Windows.Forms.MouseButtons.Right Then
         Dim hit As DataGridView.HitTestInfo = dgvMain.HitTest(e.X, e.Y)
         If (hit.Type = DataGridViewHitTestType.Cell) Then
            cmdgvMainEdit.Visible = True
            cmdgvMainRemove.Visible = True
         Else
            cmdgvMainEdit.Visible = False
            cmdgvMainRemove.Visible = False
         End If
         If hit.Type = DataGridViewHitTestType.Cell Then
            dgvMain.Rows(hit.RowIndex).Selected = True
         End If
         If dsType = dsTypes.Orders Then
            cmdgvMainSepDelivery.Visible = True
            cmdgvMainDelivery.Visible = True
         Else
            cmdgvMainSepDelivery.Visible = False
            cmdgvMainDelivery.Visible = False
         End If
      ElseIf dsType = dsTypes.Items Then
         Dim lstItems As List(Of DescrItem) = dgvMain.DataSource
         Dim selItems As New List(Of DescrItem)
         For Each dgvr As DataGridViewRow In dgvMain.SelectedRows
            selItems.Add(dgvr.DataBoundItem)
         Next
         dragData = selItems
         dgvMain.DoDragDrop(selItems, DragDropEffects.Copy)
      End If
   End Sub
   Private Sub cmdgvMainNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgvMainNew.Click
      If dsType = dsTypes.Orders Then
         objOrders.NewOrder(objSuppliers)
      ElseIf dsType = dsTypes.OrderItems Then
         Dim Order As New Order
         Order.ID = CInt(tvMain.SelectedNode.Tag)
         Order.Nr = tvMain.SelectedNode.Text
         objOrderItems.NewOrderItem(Order, objItemClasses, objOrderableItems)
      ElseIf dsType = dsTypes.AccountingUnits Then
         objAccountingUnits.NewAccountingUnit()
      ElseIf dsType = dsTypes.ItemClasses Then
         objItemClasses.NewItemClass()
      End If
      dgvMain.Refresh()
   End Sub
   Private Sub cmdgvMainEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgvMainEdit.Click
      If dsType = dsTypes.Orders Then
         objOrders.EditOrder(objOrders.List(dgvMain.SelectedRows(0).Index), objSuppliers)
      ElseIf dsType = dsTypes.OrderItems Then
         objOrderItems.EditOrderItem(objOrders.List(tvMain.SelectedNode.Index), objItemClasses, objOrderItems.List(dgvMain.SelectedRows(0).Index), objOrderableItems)
         Dim qryOrderItems = From ordit In objOrderItems.List Join ic In objItemClasses.List On ordit.iItemClassID Equals ic.ID Select New JoinOrderItem(ordit.Description, ic.ShortID, ordit.NrOrdered, ordit.NrDelivered)
         Dim lstJoinOrderItems As List(Of JoinOrderItem) = qryOrderItems.ToList
         dgvMain.DataSource = lstJoinOrderItems
      ElseIf dsType = dsTypes.AccountingUnits Then
         objAccountingUnits.EditAccountingUnit(objAccountingUnits.List(dgvMain.SelectedRows(0).Index))
      ElseIf dsType = dsTypes.ItemClasses Then
         objItemClasses.EditItemClass(objItemClasses.List(dgvMain.SelectedRows(0).Index))
      ElseIf dsType = dsTypes.Suppliers Then
         objSuppliers.editSupplier(objSuppliers.List(dgvMain.SelectedRows(0).Index))
      End If
      dgvMain.Refresh()
   End Sub
   Private Sub cmdgvMainRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgvMainRemove.Click
      If dsType = dsTypes.Orders Then
         Dim DelOrder As Order = objOrders.List(dgvMain.SelectedRows(0).Index)
         If objOrders.RemoveOrder(DelOrder) = Windows.Forms.DialogResult.OK Then
            dgvMain.Refresh()
         End If
      ElseIf dsType = dsTypes.OrderItems Then
         Dim DelOrderItem As OrderItem = objOrderItems.List(dgvMain.SelectedRows(0).Index)
         If objOrderItems.RemoveOrderItem(DelOrderItem) = Windows.Forms.DialogResult.OK Then
            dgvMain.Refresh()
         End If
      ElseIf dsType = dsTypes.AccountingUnits Then
         Dim DelAccountingUnit As AccountingUnit = objAccountingUnits.List(dgvMain.SelectedRows(0).Index)
         If objAccountingUnits.RemoveAccountingUnit(DelAccountingUnit) = Windows.Forms.DialogResult.OK Then
            dgvMain.Refresh()
         End If
      ElseIf dsType = dsTypes.ItemClasses Then
         Dim DelItemClass As ItemClass = objItemClasses.List(dgvMain.SelectedRows(0).Index)
         If objItemClasses.RemoveItemClass(DelItemClass) = Windows.Forms.DialogResult.OK Then
            dgvMain.Refresh()
         End If
      End If
   End Sub
   Private Sub dgvMain_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvMain.DragOver
      If e.Data.GetDataPresent(GetType(JoinConfirmedItem)) And dsType = dsTypes.OrderItems Then
         Dim objOrder As Order = objOrders.List(objOrders.GetIndex(dsID))
         If Not objOrder.MailSent Then
            e.Effect = DragDropEffects.Copy
         End If
      End If
   End Sub
   Private Sub dgvMain_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvMain.DragDrop
      If e.Data.GetDataPresent(GetType(JoinConfirmedItem)) Then
         Dim MergeOrderItems As Boolean = False
         Dim objJoinConfItem As JoinConfirmedItem = e.Data.GetData(GetType(JoinConfirmedItem))
         Dim objOrder As Order = objOrders.List(objOrders.GetIndex(dsID))
         Dim objOrdItem As OrderItem = Nothing
         'Check for existing OrderItems with the same OrderableItemID
         Dim qryOrderItems = From ordit As OrderItem In objOrderItems.List Where ordit.iOrderID = objOrder.ID
         Dim lstOrderItems As List(Of OrderItem) = qryOrderItems.ToList
         For Each ordit As OrderItem In lstOrderItems
            If ordit.OrderableItemsID = objJoinConfItem.OrderableItemID Then
               If MessageBox.Show("There is already an order for " & ordit.Description & "." & vbCrLf & "Merge orders?", "Double Entries", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  objOrdItem = ordit
                  objOrdItem.NrOrdered = objOrdItem.NrOrdered + objJoinConfItem.QuantityOrdered
                  MergeOrderItems = True
               End If
               Exit For
            End If
         Next
         If objOrdItem Is Nothing Then
            objOrdItem = New OrderItem
            objOrdItem.NrOrdered = objJoinConfItem.QuantityOrdered
            objOrdItem.OrderableItemsID = objJoinConfItem.OrderableItemID
            objOrdItem.iOrderID = objOrder.ID
            Dim ItemClassID As Nullable(Of Integer) = Nothing
            For Each ic As ItemClass In objItemClasses.List
               If ic.ShortID = objJoinConfItem.ItemClass Then
                  ItemClassID = ic.ID
                  Exit For
               End If
            Next
            If Not ItemClassID Is Nothing Then
               objOrdItem.ItemClassID = ItemClassID
            End If
         End If
         objOrdItem.CompletionDate = Nothing
         Dim frmEditOrderItem As New frmOrderItem(objItemClasses, objOrdItem, objOrderableItems)
         frmEditOrderItem.Text = "Order Item " & objOrder.Nr
         If frmEditOrderItem.ShowDialog = Windows.Forms.DialogResult.OK Then
            If MergeOrderItems Then
               db.SubmitChanges()
            Else
               db.OrderItems.InsertOnSubmit(objOrdItem)
               db.Submit()
            End If
            lstOrderItems = qryOrderItems.ToList
            dgvMain.DataSource = lstOrderItems
            dgvMain.Refresh()
            Dim objOrderItems As New OrderItems(db, objOrder)
            objOrderItems.AddNodes(tvMain.Nodes("ndOrders").Nodes(objOrder.Nr))
            'Update ConfirmedItems
            Dim objConfItem As ConfirmedItem = objConfirmedItems.List(objConfirmedItems.GetIndex(objJoinConfItem.ID))
            objConfItem.DateOrdered = Now()
            db.SubmitChanges()
            objConfirmedItems = New ConfirmedItems(db)
            Dim lstJoinConfirmedItems As New List(Of JoinConfirmedItem)
            Dim qryConfirmedItems = From confit As ConfirmedItem In objConfirmedItems.List Join ordit As OrderableItem In objOrderableItems.List On confit.OrderableItemsID Equals ordit.ID Join acu As AccountingUnit In objAccountingUnits.List On confit.iAccountingUnitID Equals acu.ID Select New JoinConfirmedItem(confit.ID, ordit.sManufacturerModel, confit.QuantityOrdered, confit.Orderer, confit.RecipientName, confit.CostCenterResponsible, confit.ITManager, acu.ShortID, confit.DateConfirmed, confit.OrderableItemsID, ordit.ItemCategory, confit.QuantityAssigned, confit.AccountingUnitID)
            lstJoinConfirmedItems = qryConfirmedItems.ToList
            frmAllConfirmedItems.RefreshList(lstJoinConfirmedItems)
         End If
      End If
   End Sub

#End Region
#Region "tvMain"
   Private Sub tvMain_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvMain.MouseDown
      If e.Button = Windows.Forms.MouseButtons.Right Then
         tvMain.SelectedNode = tvMain.GetNodeAt(e.X, e.Y)
      End If
   End Sub
   Private Sub tvMain_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMain.AfterSelect
      cmtvMainNew.Enabled = True
      cmtvMainEdit.Enabled = False
      cmtvMainRemove.Enabled = False
      cmtvMainSepDelivery.Visible = False
      cmtvMainSendMail.Visible = False
      cmtvMainNewDelivery.Visible = False
      mmDeliveryNew.Enabled = False
      If tvMain.SelectedNode.Level = 0 Then
         If tvMain.SelectedNode.Name = "ndOrders" Then
            Dim qryOrders = From ord In objOrders.List Join sup In objSuppliers.List On ord.SupplierID Equals sup.ID Select New JoinOrder(ord.ID, ord.Nr, ord.OrderDate, ord.Orderer, sup.ShortID, ord.Remarks, ord.EProc, ord.EProcOrderNr, ord.MailSent)
            Dim lstJoinOrders As List(Of JoinOrder) = qryOrders.ToList
            dgvMain.DataSource = lstJoinOrders
            dsType = dsTypes.Orders
         ElseIf tvMain.SelectedNode.Name = "ndAccountingUnits" Then
            dgvMain.DataSource = objAccountingUnits.List
            dsType = dsTypes.AccountingUnits
         ElseIf tvMain.SelectedNode.Name = "ndItemClasses" Then
            dgvMain.DataSource = objItemClasses.List
            dsType = dsTypes.ItemClasses
         ElseIf tvMain.SelectedNode.Name = "ndSuppliers" Then
            dgvMain.DataSource = objSuppliers.List
            dsType = dsTypes.Suppliers
         End If
         dsID = Nothing
      ElseIf tvMain.SelectedNode.Level = 1 Then
         cmtvMainNew.Enabled = False
         cmtvMainEdit.Enabled = True
         cmtvMainRemove.Enabled = True
         cmtvMainSepDelivery.Visible = False
         cmtvMainSendMail.Visible = False
         cmtvMainNewDelivery.Visible = False
         mmDeliveryNew.Enabled = False
         If tvMain.SelectedNode.Parent.Name = "ndOrders" Then
            cmtvMainSepDelivery.Visible = True
            cmtvMainSendMail.Visible = True
            cmtvMainNewDelivery.Visible = True
            mmDeliveryNew.Enabled = True
            Dim ActOrder As Order = objOrders.List(objOrders.GetIndex(CInt(tvMain.SelectedNode.Tag)))
            cmtvMainSendMail.Enabled = Not (ActOrder.MailSent)
            objOrderItems = New OrderItems(db, ActOrder)
            Dim qryOrderItems = From ordit In objOrderItems.List Join ic In objItemClasses.List On ordit.iItemClassID Equals ic.ID Select New JoinOrderItem(ordit.Description, ic.ShortID, ordit.NrOrdered, ordit.NrDelivered)
            Dim lstJoinOrderItems As List(Of JoinOrderItem) = qryOrderItems.ToList
            If lstJoinOrderItems.Count = 0 Then
               cmtvMainNewDelivery.Enabled = False
               mmDeliveryNew.Enabled = False
            Else
               cmtvMainNewDelivery.Enabled = True
               mmDeliveryNew.Enabled = True
            End If
            dgvMain.DataSource = lstJoinOrderItems
            dsType = dsTypes.OrderItems
            dsID = CInt(tvMain.SelectedNode.Tag)
            IsStarting = False
         ElseIf tvMain.SelectedNode.Parent.Name = "ndAccountingUnits" Then
            dsType = dsTypes.AccountingUnits
            dsID = CInt(tvMain.SelectedNode.Tag)
         ElseIf tvMain.SelectedNode.Parent.Name = "ndItemClasses" Then
            dsType = dsTypes.ItemClasses
            dsID = CInt(tvMain.SelectedNode.Tag)
         ElseIf tvMain.SelectedNode.Parent.Name = "ndSuppliers" Then
            dsType = dsTypes.Suppliers
            dsID = CInt(tvMain.SelectedNode.Tag)
         End If
      ElseIf tvMain.SelectedNode.Level = 2 Then
         If tvMain.SelectedNode.Parent.Parent.Name = "ndOrders" Then
            Dim OrderItemsID As Integer = CInt(tvMain.SelectedNode.Tag)
            Dim DescrItemsList As New List(Of DescrItem)
            Dim qryItems = From it As Item In db.Items Join ordit As OrderItem In db.OrderItems On it.iOrderItemID Equals ordit.ID Where it.iOrderItemID = OrderItemsID Select New DescrItem(it, ordit.sDescription)
            DescrItemsList = qryItems.ToList
            dsType = dsTypes.Items
            dsID = OrderItemsID
            dgvMain.DataSource = DescrItemsList
            dgvMain.Refresh()
         End If
      End If
   End Sub
   Private Sub cmtvMainNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainNew.Click
      If tvMain.SelectedNode.Name = "ndOrders" Then
         objOrders.NewOrder(objSuppliers)
      ElseIf tvMain.SelectedNode.Name = "ndAccountingUnits" Then
         objAccountingUnits.NewAccountingUnit()
      ElseIf tvMain.SelectedNode.Name = "ndItemClasses" Then
         objItemClasses.NewItemClass()
      ElseIf tvMain.SelectedNode.Name = "ndSuppliers" Then
         objSuppliers.NewSupplier()
      End If
      dgvMain.Refresh()
   End Sub
   Private Sub cmtvMainEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainEdit.Click
      If tvMain.SelectedNode.Parent.Name = "ndOrders" Then
         objOrders.EditOrder(objOrders.List(objOrders.GetIndex(CInt(tvMain.SelectedNode.Tag))), objSuppliers)
      ElseIf tvMain.SelectedNode.Parent.Name = "ndAccountingUnits" Then
         objAccountingUnits.EditAccountingUnit(objAccountingUnits.List(objAccountingUnits.GetIndex(CInt(tvMain.SelectedNode.Tag))))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndItemClasses" Then
         objItemClasses.EditItemClass(objItemClasses.List(objItemClasses.GetIndex(CInt(tvMain.SelectedNode.Tag))))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndSuppliers" Then
         objSuppliers.EditSupplier(objSuppliers.List(objSuppliers.GetIndex(CInt(tvMain.SelectedNode.Tag))))
      End If
      dgvMain.Refresh()
   End Sub
   Private Sub cmtvMainRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainRemove.Click
      If tvMain.SelectedNode.Parent.Name = "ndOrders" Then
         'do nothing
      ElseIf tvMain.SelectedNode.Parent.Name = "ndAccountingUnits" Then
         'do nothing
      ElseIf tvMain.SelectedNode.Parent.Name = "ndItemClasses" Then
         'do nothing
      ElseIf tvMain.SelectedNode.Parent.Name = "ndSuppliers" Then
         objSuppliers.RemoveSupplier(objSuppliers.List(objSuppliers.GetIndex(CInt(tvMain.SelectedNode.Tag))))
      End If
   End Sub
#End Region

   Private Sub dgvMain_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMain.CellDoubleClick
      cmdgvMainEdit_Click(sender, e)
   End Sub

   Private Sub frmMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
      WriteWindowState()
   End Sub

   Private Sub cmtvMainNewDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainNewDelivery.Click
      objOrders.NewDelivery(objOrders.List(objOrders.GetIndex(CInt(tvMain.SelectedNode.Tag))), objItemClasses, objSuppliers)
      Dim qryOrderItems = From ordit In objOrderItems.List Join ic In objItemClasses.List On ordit.iItemClassID Equals ic.ID Select New JoinOrderItem(ordit.Description, ic.ShortID, ordit.NrOrdered, ordit.NrDelivered)
      Dim lstJoinOrderItems As List(Of JoinOrderItem) = qryOrderItems.ToList
      dgvMain.DataSource = lstJoinOrderItems
      dsType = dsTypes.OrderItems
      'dgvMain.Refresh()
   End Sub

   Private Sub cmtvMainSendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainSendMail.Click
      Dim Order As Order = objOrders.List(objOrders.GetIndex(CInt(tvMain.SelectedNode.Tag)))
      Dim Supplier As Supplier = objSuppliers.List(objSuppliers.GetIndex(Order.SupplierID))
      Dim objOrderItems As New OrderItems(db, Order)
      Dim txtItems As String = "Beschreibung" & vbTab & "Anzahl" & vbCrLf & _
                               "------------" & vbTab & "------"
      For Each oi As OrderItem In objOrderItems.List
         txtItems = txtItems & vbCrLf & oi.Description & vbTab & Format(oi.NrOrdered, "######")
      Next
      Dim locMailClient As New SmtpClient("smtp.eu.schindler.com")
      Dim locMailMessage As New MailMessage("Testaccount@donotreply.schindler.com", Supplier.MailAddress)
      locMailMessage.Subject = "Bestellung " & Order.Nr
      locMailMessage.Body = "Sehr geehrte Damen und Herren" & vbCrLf & vbCrLf & _
      "Wir bestellen hiermit folgende Artikel bei Ihnen:" & vbCrLf & vbCrLf & _
      txtItems & vbCrLf & vbCrLf & _
      "Mit freundlichen Grüssen" & vbCrLf & _
      Order.Orderer
      locMailClient.Send(locMailMessage)
      Order.MailSent = True
      db.SubmitChanges()
   End Sub

   Private Sub mmOrderConfirmedItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmOrderConfirmedItems.Click
      Dim lstJoinConfirmedItems As New List(Of JoinConfirmedItem)
      Dim qryConfirmedItems = From confit As ConfirmedItem In objConfirmedItems.List Join ordit As OrderableItem In objOrderableItems.List On confit.OrderableItemsID Equals ordit.ID Join acu As AccountingUnit In objAccountingUnits.List On confit.AccountingUnitID Equals acu.ID Where confit.DateOrdered Is Nothing Select New JoinConfirmedItem(confit.ID, ordit.sManufacturerModel, confit.QuantityOrdered, confit.Orderer, confit.RecipientName, confit.CostCenterResponsible, confit.ITManager, acu.ShortID, confit.DateConfirmed, confit.OrderableItemsID, ordit.ItemCategory, confit.QuantityAssigned, confit.AccountingUnitID)
      lstJoinConfirmedItems = qryConfirmedItems.ToList
      frmAllConfirmedItems = New frmConfirmedItems(db, lstJoinConfirmedItems, ItemType.ConfirmedItems)
      frmAllConfirmedItems.Show()
   End Sub

   Private Sub mmOrderOrderedItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmOrderOrderedItems.Click
      Dim lstJoinOrderedItems As New List(Of JoinConfirmedItem)
      Dim qryOrderedItems = From confit As ConfirmedItem In objConfirmedItems.List Join ordit As OrderableItem In objOrderableItems.List On confit.OrderableItemsID Equals ordit.ID Join acu As AccountingUnit In objAccountingUnits.List On confit.AccountingUnitID Equals acu.ID Where (confit.DateOrdered IsNot Nothing And confit.DateAssigned Is Nothing) Select New JoinConfirmedItem(confit.ID, ordit.sManufacturerModel, confit.QuantityOrdered, confit.Orderer, confit.RecipientName, confit.CostCenterResponsible, confit.ITManager, acu.ShortID, confit.DateConfirmed, confit.OrderableItemsID, ordit.ItemCategory, confit.QuantityAssigned, confit.AccountingUnitID)
      lstJoinOrderedItems = qryOrderedItems.ToList
      frmAllOrderedItems = New frmConfirmedItems(db, lstJoinOrderedItems, ItemType.OrderedItems)
      frmAllOrderedItems.Text = "Ordered Items"
      frmallOrderedItems.show()
   End Sub

   Private Sub dgvMain_QueryContinueDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles dgvMain.QueryContinueDrag
      If dragData.GetType Is GetType(List(Of DescrItem)) Then
         ssMainLabel.Text = ""
         Dim selItems As List(Of DescrItem) = dragData
         For Each dit As DescrItem In selItems
            If Not (dit.Accounting Is Nothing) Then
               ssMainLabel.Text = "Dragging of already assigned items is not possible."
               e.Action = DragAction.Cancel
               Exit For
            End If
         Next
      End If
   End Sub
End Class

Public Enum dsTypes
   Orders = 1
   OrderItems = 2
   Items = 3
   ItemClasses = 4
   AccountingUnits = 5
   Suppliers = 6
End Enum

Public Enum ItemType
   ConfirmedItems = 1
   OrderedItems = 2
End Enum






