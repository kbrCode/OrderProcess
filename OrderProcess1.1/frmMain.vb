Friend Delegate Sub UpdateUIDBChecked(ByVal Sender As Object, ByVal args As Boolean)
Public Class frmMain
   Dim dbOrderProcess As OrderProcess
   Dim dbAIMS As AIMSDataContext
   Dim lstOrders As List(Of Order)
   Dim lstOrderItems As List(Of OrderItem)
   Dim lstItems As List(Of Item)
   Dim lstAccountingUnits As List(Of AccountingUnit)
   Dim lstItemClasses As List(Of ItemClass)
   Dim lstSuppliers As List(Of Supplier)
   Dim lstOrderers As List(Of Orderer)
   Dim lstOrderableItems As List(Of OrderableItem)
   Dim lstConfirmedItems As List(Of ConfirmedItem)
   Dim dsType As dsTypes = Nothing
   Dim dsID As Nullable(Of Integer) = Nothing
   Dim IsStarting As Boolean = True
   Dim frmGetConfirmedItems As frmConfirmedItems
   Dim frmGetOrderedItems As frmConfirmedItems
   Dim frmGetAvailableItems As frmAvailableItems
   Dim frmGetAssignedItems As frmAvailableItems
   Dim dragData As Object
   Dim isloading As Boolean = True
   Dim runChecker As Boolean = False
   Dim objDBChecker As DBChecker
   Dim Identity As WindowsIdentity
    Dim DBCheckThread As Thread
    Public Shared dragWindowName As String

   Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      isloading = True
        Identity = WindowsIdentity.GetCurrent
        Dim Principal As New WindowsPrincipal(Identity)
        If Not Principal.IsInRole("INF\LR_INF_ORDERPROCESS") Then
            MessageBox.Show("You are not authorized to use this software." & vbCrLf & "If you think you recieved this message by mistake, please contact the CSC (Tel. +41 41 445 5555)", "Not in Group LR_INF_ORDERPROCESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If Not DBCheckThread Is Nothing Then
                If DBCheckThread.IsAlive Then
                    DBCheckThread.Abort()
                End If
            End If
            Me.Close()
        End If

        'dbOrderProcess = New OrderProcess(My.Settings.OrderProcessConnectionString1)
        'dbAIMS = New AIMSDataContext(My.Settings.InventarAIMSConnectionString1)

        dbOrderProcess = New OrderProcess(My.Settings.OrderProcessConnectionString)
        dbAIMS = New AIMSDataContext(My.Settings.inventarAIMSConnectionString)

      ssMainLabel.Text = My.Settings.OrderProcessConnectionString
      lstOrderableItems = dbOrderProcess.OrderableItems.ToList
      lstConfirmedItems = dbOrderProcess.ConfirmedItems.ToList
      ReadWindowState()
      LoadOrders()
      LoadAccountingUnits()
      LoadItemClasses()
      LoadSuppliers()
      LoadOrderers()
      dgvMain.DataSource = lstOrders
      dsType = dsTypes.Orders
      dsID = Nothing
      isloading = False
      If runChecker Then
         objDBChecker = New DBChecker(My.Settings.OrderProcessConnectionString)
         Dim locThreadStart As ThreadStart
         locThreadStart = New ThreadStart(AddressOf objDBChecker.StartChecker)
         AddHandler objDBChecker.DBChecked, AddressOf OnDBChecked
         DBCheckThread = New Thread(locThreadStart)
         DBCheckThread.Name = "CheckDB"
         DBCheckThread.Start()
      End If
   End Sub
   Private Sub OnDBChecked(ByVal Sender As Object, ByVal e As Boolean)
      If Me.InvokeRequired Then
         Dim args() As Object = {Me, e}
         Invoke(New UpdateUIDBChecked(AddressOf UpdateUIDBChecked), args)
      Else
         UpdateUIDBChecked(Me, e)
      End If
   End Sub
   Private Sub UpdateUIDBChecked(ByVal Sender As Object, ByVal e As Boolean)
      Dim newConfirmedItem As Boolean = e
      If newConfirmedItem Then
         If MessageBox.Show("New ConfirmedItem found. Update OrderProcess?", "Database Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
            RefreshAll()
         End If
      End If
   End Sub

   Private Sub WriteWindowState()
      Dim ownedForms As Form() = Me.OwnedForms
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
      regShareKey.SetValue("AssignedItems", False)
      regShareKey.SetValue("ConfirmedItems", False)
      regShareKey.SetValue("OrderedItems", False)
      regShareKey.SetValue("AvailableItems", False)
      regShareKey.SetValue("HideCompletedOrders", mmViewHideCompletedOrders.Checked)
      For Each frm As Form In ownedForms
         regShareKey.SetValue(frm.Tag, True)
      Next
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
         If regShareKey.GetValue("AssignedItems", False) Then
            OpenAssignedItems()
         End If
         If regShareKey.GetValue("ConfirmedItems", False) Then
            OpenConfirmedItems()
         End If
         If regShareKey.GetValue("OrderedItems", False) Then
            OpenOrderedItems()
         End If
         If regShareKey.GetValue("AvailableItems", False) Then
            OpenAvailableItems()
         End If
         mmViewHideCompletedOrders.Checked = regShareKey.GetValue("HideCompletedOrders", False)
         regShareKey.Close()
         Update()
      End If
   End Sub

#Region "Orders"
   Private Sub LoadOrders()
      If mmViewHideCompletedOrders.Checked Then
         Dim qryOrders = From ord As Order In dbOrderProcess.Orders Where (Not ord.Finalized) Or (ord.OrderItems.Sum(Function(ordit) ordit.NrOrdered) > ord.OrderItems.Sum(Function(ordit) ordit.NrDelivered)) Select ord
         lstOrders = qryOrders.ToList
      Else
         lstOrders = dbOrderProcess.Orders.ToList
      End If
      tvMain.Nodes("ndOrders").Nodes.Clear()
      For Each ord As Order In lstOrders
         Dim ordtn As TreeNode = ord.TreeNode
         For Each ordit In ord.OrderItems
            ordtn.Nodes.Add(ordit.TreeNode)
         Next
         tvMain.Nodes("ndOrders").Nodes.Add(ordtn)
      Next
   End Sub
   Private Sub LoadOrders(ByVal Order As Order)
      LoadOrders()
      For Each tn As TreeNode In tvMain.Nodes("ndOrders").Nodes
         If CInt(tn.Tag) = Order.ID Then
            tvMain.SelectedNode = tn
            Exit For
         End If
      Next
   End Sub
   Private Sub NewOrder()
      Dim NewOrder As New Order
      NewOrder.Nr = GetNextOrderNr()
      Dim frmEditOrder As New frmOrder(NewOrder, lstOrderers, lstSuppliers)
      If frmEditOrder.ShowDialog = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.Orders.InsertOnSubmit(NewOrder)
         dbOrderProcess.SubmitChanges()
         LoadOrders()
         dgvMain.DataSource = lstOrders
         dsType = dsTypes.Orders
      End If
   End Sub
   Private Sub EditOrder(ByVal ID As Integer)
      Dim comparer As New OrderPredicate(ID)
      Dim Order As Order = lstOrders.Find(AddressOf comparer.CompareIDs)
      Dim frmEditOrder As New frmOrder(Order, lstOrderers, lstSuppliers)
      frmEditOrder.Text = "Order " & Order.Nr
      If frmEditOrder.ShowDialog = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.SubmitChanges()
         LoadOrders()
      End If
   End Sub
   Private Sub RemoveOrder(ByVal ID As Integer)
      Dim comparer As New OrderPredicate(ID)
      Dim DelOrder As Order = lstOrders.Find(AddressOf comparer.CompareIDs)
      If MessageBox.Show("Delete Order " & DelOrder.Nr & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.Orders.DeleteOnSubmit(DelOrder)
         dbOrderProcess.SubmitChanges()
         LoadOrders()
         dgvMain.DataSource = lstOrders
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub mmFileNewOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmFileNewOrder.Click
      NewOrder()
   End Sub
   Private Sub NewDelivery(ByVal ID As Integer)
      Dim comparer As New OrderPredicate(ID)
      Dim objOrder As Order = lstOrders.Find(AddressOf comparer.CompareIDs)
      Dim frmNewDelivery As New frmDelivery(objOrder, lstItemClasses, lstSuppliers, dbAIMS)
      frmNewDelivery.Text = "New Delivery for Order " & objOrder.Nr
      If frmNewDelivery.ShowDialog = DialogResult.OK Then
         dbOrderProcess.SubmitChanges()
      End If
      RefreshAll()
      For Each tn As TreeNode In tvMain.Nodes("ndOrders").Nodes
         If CInt(tn.Tag) = ID Then
            tvMain.SelectedNode = tn
            Exit For
         End If
      Next
   End Sub
   Private Sub mmDeliveryNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmDeliveryNew.Click
      NewDelivery(CInt(tvMain.SelectedNode.Tag))
   End Sub
   Private Sub cmtvMainNewDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainNewDelivery.Click
      NewDelivery(CInt(tvMain.SelectedNode.Tag))
   End Sub
   Private Sub cmdgvMainDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgvMainDelivery.Click
      NewDelivery(dsID)
      'dgvMain.Refresh()
   End Sub
   Private Sub cmtvMainFinalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainFinalize.Click
      Dim comparer As New OrderPredicate(CInt(tvMain.SelectedNode.Tag))
      Dim objOrder As Order = lstOrders.Find(AddressOf comparer.CompareIDs)
      If Not (objOrder.EProc) Then
         If MessageBox.Show("There is no E-Procurement made for this order." & vbCrLf & "Finalize anyway?", "Missing E-Procurement", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
         End If
      End If
      objOrder.Finalized = True
      dbOrderProcess.SubmitChanges()
   End Sub
   Private Sub cmtvMainSendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainSendMail.Click
      Dim comparer As New OrderPredicate(CInt(tvMain.SelectedNode.Tag))
      Dim objOrder As Order = lstOrders.Find(AddressOf comparer.CompareIDs)
      Dim maxDescr As Integer = 12
      Dim maxSuppNr As Integer = 9
      Dim totPrice As Double = 0.0
      For Each oi As OrderItem In objOrder.OrderItems
         If oi.Description.Count > maxDescr Then
            maxDescr = oi.Description.Count
         End If
         If oi.OrderableItem.SupplierNo.Count > maxSuppNr Then
            maxSuppNr = oi.OrderableItem.SupplierNo.Count
         End If
      Next
      Dim objOrderer As Orderer = objOrder.Orderer
      Dim txtItems As String = "Beschreibung".PadRight(maxDescr, " ") & " Bestellnr".PadRight(maxSuppNr + 1, " ") & " Anzahl" & "     Preis" & vbCrLf & _
                               "------------".PadRight(maxDescr, "-") & " ---------".PadRight(maxSuppNr + 1, "-") & " ------" & " ---------"
      For Each oi As OrderItem In objOrder.OrderItems
         txtItems = txtItems & vbCrLf & oi.Description.PadRight(maxDescr) & " " & oi.OrderableItem.SupplierNo.PadRight(maxSuppNr) & Format(oi.NrOrdered, "#####0").PadLeft(7) & Format(oi.OrderableItem.SupplierPrice * oi.NrOrdered, "#####0.00").PadLeft(10)
         totPrice = totPrice + oi.OrderableItem.SupplierPrice * oi.NrOrdered
      Next
      Dim totItems As String = "".PadRight(maxDescr + maxSuppNr + 8) & " ---------" & vbCrLf & _
                               "Total".PadRight(maxDescr + maxSuppNr + 8) & Format(totPrice, "#####0.00").PadLeft(10)
      Dim locMailClient As New SmtpClient("smtp.eu.schindler.com")
      Dim locMailMessage As New MailMessage("Testaccount@donotreply.schindler.com", objOrderer.EMailAddress)
      locMailMessage.Subject = "Bestellung " & objOrder.Nr
      locMailMessage.Body = "Bitte folgende Artikel im E-Procurement bestellen:" & vbCrLf & vbCrLf & txtItems & vbCrLf & totItems
      locMailClient.Send(locMailMessage)
   End Sub
   Public Sub FixOrderView(ByVal DataGridView As DataGridView)
      DataGridView.Columns("ID").Visible = False
      DataGridView.Columns("ID").DisplayIndex = 8
      DataGridView.Columns("Nr").Width = 60
      DataGridView.Columns("Nr").HeaderText = "Nr"
      DataGridView.Columns("Nr").DisplayIndex = 0
      DataGridView.Columns("OrderDate").Width = 100
      DataGridView.Columns("OrderDate").HeaderText = "Date"
      DataGridView.Columns("OrderDate").DisplayIndex = 1
      DataGridView.Columns("sOrderer").Width = 120
      DataGridView.Columns("sOrderer").HeaderText = "Orderer"
      DataGridView.Columns("sOrderer").DisplayIndex = 2
      DataGridView.Columns("SupplierID").Visible = False
      DataGridView.Columns("SupplierID").DisplayIndex = 9
      DataGridView.Columns("Remarks").Width = 180
      DataGridView.Columns("Remarks").HeaderText = "Remarks"
      DataGridView.Columns("Remarks").DisplayIndex = 4
      DataGridView.Columns("EProc").Width = 50
      DataGridView.Columns("EProc").HeaderText = "EProc"
      DataGridView.Columns("EProc").DisplayIndex = 5
      DataGridView.Columns("EProcOrderNr").Width = 100
      DataGridView.Columns("EProcOrderNr").HeaderText = "EProcOrderNr"
      DataGridView.Columns("EProcOrderNr").DisplayIndex = 6
      DataGridView.Columns("Finalized").Width = 50
      DataGridView.Columns("Finalized").HeaderText = "Finalized"
      DataGridView.Columns("Finalized").DisplayIndex = 7
      DataGridView.Columns("Supplier").Visible = False
      DataGridView.Columns("Supplier").DisplayIndex = 10
      DataGridView.Columns("sSupplier").Width = 120
      DataGridView.Columns("sSupplier").HeaderText = "Supplier"
      DataGridView.Columns("sSupplier").DisplayIndex = 3
      DataGridView.Columns("TreeNode").Visible = False
      DataGridView.Columns("TreeNode").DisplayIndex = 11
      DataGridView.Columns("OrdererID").Visible = False
      DataGridView.Columns("OrdererID").DisplayIndex = 12
      DataGridView.Columns("Orderer").Visible = False
      DataGridView.Columns("Orderer").DisplayIndex = 13
      For Each gr As DataGridViewRow In DataGridView.Rows
         If gr.Cells("Finalized").Value = True Then
            gr.DefaultCellStyle.BackColor = Color.LightGray
         End If
      Next
   End Sub
   Private Function GetNextOrderNr() As String
      Dim OrderNr As String = Nothing
      Dim strYear As String = Now.Year.ToString.Substring(2)
      Dim maxNr As Integer = 0
      For Each ord As Order In lstOrders
         Dim actNr As Integer = 0
         If Integer.TryParse(ord.Nr.Substring(ord.Nr.IndexOf("-") + 1), actNr) And (ord.Nr.Substring(1, 2) = strYear) Then
            If actNr > maxNr Then
               maxNr = actNr
            End If
         End If
      Next
      If maxNr > 0 Then
         OrderNr = "G" & strYear & "-" & Format(maxNr + 1, "000")
      End If
      Return OrderNr
   End Function
#End Region
#Region "OrderItems"
   Private Sub NewOrderItem()
      Dim comparer As New OrderPredicate(CInt(tvMain.SelectedNode.Tag))
      Dim Order As Order = lstOrders.Find(AddressOf comparer.CompareIDs)
      Dim objNewOrderItem As New OrderItem
      objNewOrderItem.Order = Order
      objNewOrderItem.CompletionDate = Nothing
      objNewOrderItem.FromDragging = False
      Dim frmEditOrderItem As New frmOrderItem(objNewOrderItem, lstItemClasses, lstOrderableItems, lstSuppliers, dbAIMS)
      frmEditOrderItem.Text = "Order Item " & Order.Nr
      If frmEditOrderItem.ShowDialog = Windows.Forms.DialogResult.OK Then
         objNewOrderItem.Order = Order
         dbOrderProcess.SubmitChanges()
      Else
         objNewOrderItem.Order = Nothing
      End If
      LoadOrders(Order)
      dgvMain.Refresh()
   End Sub
   Private Sub EditOrderItem(ByVal OrderID As Integer, ByVal OrderItemID As Integer)
      Dim ordcomparer As New OrderPredicate(OrderID)
      Dim Order As Order = lstOrders.Find(AddressOf ordcomparer.CompareIDs)
      Dim oicomparer As New OrderItemPredicate(OrderItemID)
      Dim lstOrderItems As List(Of OrderItem) = Order.OrderItems.ToList
      Dim OrderItem As OrderItem = lstOrderItems.Find(AddressOf oicomparer.CompareIDs)
      Dim frmEditOrderItem As New frmOrderItem(OrderItem, lstItemClasses, lstOrderableItems, lstSuppliers, dbAIMS)
      frmEditOrderItem.Text = "Order Item " & Order.Nr
      If frmEditOrderItem.ShowDialog = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.SubmitChanges()
      End If
      LoadOrders(Order)
      dgvMain.DataSource = lstOrderItems
   End Sub
   Private Sub RemoveOrderItem(ByVal ID As Integer)
      Dim comparer As New OrderItemPredicate(ID)
      Dim DelOrderItem As OrderItem = lstOrderItems.Find(AddressOf comparer.CompareIDs)
      Dim Order As Order = DelOrderItem.Order
      If MessageBox.Show("Delete OrderItem " & DelOrderItem.Description & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
         dgvMain.DataSource = Nothing
         Dim cicomparer As New ConfirmedItemPredicate(ID)
         Dim delConfirmedItems As List(Of ConfirmedItem) = lstConfirmedItems.FindAll(AddressOf cicomparer.CompareOrderItemIDs)
         For Each ci As ConfirmedItem In delConfirmedItems
            ci.OrderItem = Nothing
            ci.DateOrdered = Nothing
         Next
         dbOrderProcess.OrderItems.DeleteOnSubmit(DelOrderItem)
         dbOrderProcess.SubmitChanges()
         LoadOrders(Order)
         dgvMain.Refresh()
      End If
   End Sub
   Public Sub FixOrderItemView(ByVal DataGridView As DataGridView)
      DataGridView.Columns("OrderID").Visible = False
      DataGridView.Columns("OrderID").DisplayIndex = 5
      DataGridView.Columns("Description").Width = 170
      DataGridView.Columns("Description").HeaderText = "Description"
      DataGridView.Columns("Description").DisplayIndex = 0
      DataGridView.Columns("ItemClassID").Visible = False
      DataGridView.Columns("ItemClassID").DisplayIndex = 6
      DataGridView.Columns("NrOrdered").Width = 60
      DataGridView.Columns("NrOrdered").HeaderText = "NrOrdered"
      DataGridView.Columns("NrOrdered").DisplayIndex = 2
      DataGridView.Columns("NrDelivered").Width = 60
      DataGridView.Columns("NrDelivered").HeaderText = "NrDelivered"
      DataGridView.Columns("NrDelivered").DisplayIndex = 3
      DataGridView.Columns("CompletionDate").Width = 100
      DataGridView.Columns("CompletionDate").HeaderText = "CompletionDate"
      DataGridView.Columns("CompletionDate").DisplayIndex = 4
      DataGridView.Columns("OrderableItemsID").Visible = False
      DataGridView.Columns("OrderableItemsID").DisplayIndex = 7
      DataGridView.Columns("ItemClass").Visible = False
      DataGridView.Columns("ItemClass").DisplayIndex = 8
      DataGridView.Columns("Order").Visible = False
      DataGridView.Columns("Order").DisplayIndex = 9
      DataGridView.Columns("OrderableItem").Visible = False
      DataGridView.Columns("OrderableItem").DisplayIndex = 10
      DataGridView.Columns("sItemClass").Width = 100
      DataGridView.Columns("sItemClass").HeaderText = "ItemClass"
      DataGridView.Columns("sItemClass").DisplayIndex = 1
      DataGridView.Columns("TreeNode").Visible = False
      DataGridView.Columns("TreeNode").DisplayIndex = 11
      For Each gr As DataGridViewRow In DataGridView.Rows
         If gr.Cells("NrOrdered").Value = gr.Cells("NrDelivered").Value Then
            gr.DefaultCellStyle.BackColor = Color.LightGreen
         End If
      Next
   End Sub
#End Region
#Region "Items"
    Public Function EditItem(ByVal Item As Item) As Boolean
        Dim retVal As Boolean
        Dim frmEditItem As New frmItem(Item)
        frmEditItem.Text = "Item " & Item.OrderItem.Description
        If frmEditItem.ShowDialog = Windows.Forms.DialogResult.OK Then
            If ((Item.OrderItem.OrderableItem.ItemClassID = 2) And (Item.ItemID IsNot Nothing)) Then
                'AddToAIMS(Item)
                Dim urlAIMS As String = dbAIMS.AddToAims(Item, Identity.Name)
                If urlAIMS IsNot Nothing Then
                    System.Diagnostics.Process.Start(urlAIMS)
                End If
            End If
            dbOrderProcess.SubmitChanges()
            retVal = True
        Else
            retVal = False
        End If
        Return retVal
    End Function
   'Public Sub AddToAIMS(ByVal Item As Item)
   '   Dim lstStdSystems As List(Of Std_System) = dbAIMS.Std_Systems.ToList
   '   If Item.OrderItem.OrderableItem.AimsStdSystemsID Is Nothing Then
   '      Dim frmNewAIMSStdSystemMapping As New frmAIMSStdSystemMapping(Item, lstStdSystems)
   '      If frmNewAIMSStdSystemMapping.ShowDialog = Windows.Forms.DialogResult.OK Then
   '         Item.OrderItem.OrderableItem.AimsStdSystemsID = frmNewAIMSStdSystemMapping.StdSystemID
   '      Else
   '         Exit Sub
   '      End If
   '   End If
   '   Dim comparer As New StdSystemPredicate(CInt(Item.OrderItem.OrderableItem.AimsStdSystemsID))
   '   Dim objStdSystem As Std_System = lstStdSystems.Find(AddressOf comparer.CompareIDs)
   '   If objStdSystem.Typ = "G" Then
   '      Dim tblGeraete As Table(Of Geraet) = dbAIMS.Geraets
   '      If Item.AimsID Is Nothing Then
   '         Dim newGeraet As New Geraet()
   '         newGeraet.AdminWkst = objStdSystem.adminwkst
   '         newGeraet.Assettag = objStdSystem.assettag
   '         If Not (Item.AccountingUnit Is Nothing) Then
   '            newGeraet.Besitzer = Item.AccountingUnit.ShortID
   '         Else
   '            newGeraet.Besitzer = "POOL"
   '         End If
   '         newGeraet.Best_Nr = Item.OrderItem.Order.EProcOrderNr
   '         newGeraet.Betriebssystem = objStdSystem.Betriebssystem
   '         newGeraet.CPU_Frequenz = objStdSystem.CPU_Frequenz
   '         newGeraet.CPU_Typ = objStdSystem.CPU_Typ
   '         newGeraet.Garantietyp = objStdSystem.Garantietyp
   '         newGeraet.Garantiezeit = objStdSystem.Garantiezeit
   '         newGeraet.Geraet = objStdSystem.Geraet
   '         newGeraet.Graphikkarte = objStdSystem.Graphikkarte
   '         newGeraet.HD_Disk = objStdSystem.HD_Disk
   '         newGeraet.Hersteller = objStdSystem.Hersteller
   '         newGeraet.Kategorie = objStdSystem.Kategorie
   '         newGeraet.Kauf_Date = Item.Delivery
   '         newGeraet.Lieferant = Item.OrderItem.OrderableItem.Supplier.ShortID
   '         newGeraet.Memory = objStdSystem.Memory
   '         newGeraet.Netzkarte = objStdSystem.Netzkarte
   '         newGeraet.Opid = objStdSystem.Betriebssystem
   '         newGeraet.Soundkarte = objStdSystem.Soundkarte
   '         newGeraet.Serie_Nr = Item.ItemID
   '         newGeraet.Status = 1
   '         newGeraet.Status_Date = Now()
   '         newGeraet.Typ_Nr = objStdSystem.Typ_Nr
   '         newGeraet.Umstelldatum = Now()
   '         newGeraet.Umsteller = Identity.Name
   '         tblGeraete.InsertOnSubmit(newGeraet)
   '         Dim lstLastCHNr As List(Of LastCHNr) = dbAIMS.LastCHNrs.ToList
   '         Dim LastCHNr = lstLastCHNr(0).LastCHNr
   '         newGeraet.CH_Nr = LastCHNr + 1
   '         dbAIMS.SubmitChanges()
   '         dbAIMS.ExecuteCommand("UPDATE dbo.LastCHNr SET LastCHNr = " & (LastCHNr + 1).ToString & " WHERE lastCHNr = " & LastCHNr)
   '         Item.AimsID = newGeraet.ID
   '      Else
   '         Dim qryGeraet = From ger In tblGeraete Where ger.ID = Item.AimsID Select ger
   '         Dim lstGeraete As List(Of Geraet) = qryGeraet.ToList
   '         Dim Geraet As Geraet = lstGeraete(0)
   '         Geraet.Serie_Nr = Item.ItemID
   '         dbAIMS.SubmitChanges()
   '      End If
   '      System.Diagnostics.Process.Start(My.Settings.AIMSurl & "aims.asp?trt=showitem&trv1=Computer&trv2=" & Item.AimsID.ToString)
   '   ElseIf objStdSystem.Typ = "Z" Then
   '      Dim lstZubehoer As Table(Of Zubehoer) = dbAIMS.Zubehoers
   '      If Item.AimsID Is Nothing Then
   '         Dim newZubehoer As New Zubehoer
   '         If Not (Item.AccountingUnit Is Nothing) Then
   '            newZubehoer.Besitzer = Item.AccountingUnit.ShortID
   '         Else
   '            newZubehoer.Besitzer = "POOL"
   '         End If
   '         newZubehoer.Best_Nr = Item.OrderItem.Order.EProcOrderNr
   '         newZubehoer.Garantietyp = objStdSystem.Garantietyp
   '         newZubehoer.Garantiezeit = objStdSystem.Garantiezeit
   '         newZubehoer.Geraet = objStdSystem.Geraet
   '         newZubehoer.Hersteller = objStdSystem.Hersteller
   '         newZubehoer.Kategorie = objStdSystem.Kategorie
   '         newZubehoer.Kauf_Date = Item.Delivery
   '         newZubehoer.Lieferant = Item.OrderItem.OrderableItem.Supplier.ShortID
   '         newZubehoer.Serie_Nr = Item.ItemID
   '         newZubehoer.Status = 1
   '         newZubehoer.Status_date = Now()
   '         newZubehoer.Typ_Nr = objStdSystem.Typ_Nr
   '         newZubehoer.Umsteller = Identity.Name
   '         lstZubehoer.InsertOnSubmit(newZubehoer)
   '         dbAIMS.SubmitChanges()
   '         Item.AimsID = newZubehoer.ID
   '      Else
   '         Dim qryZubehoer = From zub In lstZubehoer Where zub.ID = Item.AimsID Select zub
   '         Dim Zubehoere As List(Of Zubehoer) = qryZubehoer.ToList
   '         Dim Zubehoer As Zubehoer = Zubehoere(0)
   '         Zubehoer.Serie_Nr = Item.ItemID
   '         dbAIMS.SubmitChanges()
   '      End If
   '      System.Diagnostics.Process.Start(My.Settings.AIMSurl & "aims.asp?trt=showitem&trv1=Zubehoer&trv2=" & Item.AimsID.ToString)
   '   End If
   'End Sub
   Private Sub RemoveItem(ByVal Item As Item)
      If MessageBox.Show("Delete Item " & Item.OrderItem.Description & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
         lstOrderItems = dbOrderProcess.OrderItems.ToList
         dgvMain.DataSource = Nothing
         Dim oicomparer As New OrderItemPredicate(CInt(dsID))
         Dim objOrderItem As OrderItem = lstOrderItems.Find(AddressOf oicomparer.CompareIDs)
         objOrderItem.NrDelivered = objOrderItem.NrDelivered - 1
         dbOrderProcess.Items.DeleteOnSubmit(Item)
         dbOrderProcess.SubmitChanges()
         lstItems = objOrderItem.Items.ToList
         dgvMain.DataSource = lstItems
         If Not (lstItems Is Nothing) Then
            FixItemView(dgvMain)
         End If
         dgvMain.Refresh()
      End If
   End Sub
   Public Sub FixItemView(ByVal DataGridView As DataGridView)
      DataGridView.Columns("ID").Visible = False
      DataGridView.Columns("ID").DisplayIndex = 8
      DataGridView.Columns("OrderItemID").Visible = False
      DataGridView.Columns("OrderItemID").DisplayIndex = 9
      DataGridView.Columns("ItemID").Width = 120
      DataGridView.Columns("ItemID").HeaderText = "ItemID"
      DataGridView.Columns("ItemID").DisplayIndex = 0
      DataGridView.Columns("Delivery").Width = 100
      DataGridView.Columns("Delivery").HeaderText = "DeliveryDate"
      DataGridView.Columns("Delivery").DisplayIndex = 4
      DataGridView.Columns("Price").Width = 60
      DataGridView.Columns("Price").HeaderText = "Price"
      DataGridView.Columns("Price").DisplayIndex = 2
      DataGridView.Columns("Deliverer").Width = 100
      DataGridView.Columns("Deliverer").HeaderText = "Deliverer"
      DataGridView.Columns("Deliverer").DisplayIndex = 3
      DataGridView.Columns("Recipient").Width = 100
      DataGridView.Columns("Recipient").HeaderText = "Recipient"
      DataGridView.Columns("Recipient").DisplayIndex = 5
      DataGridView.Columns("AccountingUnitID").Visible = False
      DataGridView.Columns("AccountingUnitID").DisplayIndex = 10
      DataGridView.Columns("Accounting").Width = 100
      DataGridView.Columns("Accounting").HeaderText = "AccountingDate"
      DataGridView.Columns("Accounting").DisplayIndex = 7
      DataGridView.Columns("AccountingUnit").Visible = False
      DataGridView.Columns("AccountingUnit").DisplayIndex = 11
      DataGridView.Columns("OrderItem").Visible = False
      DataGridView.Columns("OrderItem").DisplayIndex = 12
      DataGridView.Columns("sDescription").Width = 120
      DataGridView.Columns("sDescription").HeaderText = "Description"
      DataGridView.Columns("sDescription").DisplayIndex = 1
      DataGridView.Columns("sAccountingUnit").Width = 60
      DataGridView.Columns("sAccountingUnit").HeaderText = "AccountingUnit"
      DataGridView.Columns("sAccountingUnit").DisplayIndex = 6
      For Each gr As DataGridViewRow In DataGridView.Rows
         If (gr.Cells("Accounting").Value Is Nothing) Then
            gr.DefaultCellStyle.BackColor = Color.LightGreen
         End If
      Next
   End Sub
#End Region
#Region "AccountingUnits"
   Private Sub LoadAccountingUnits()
      lstAccountingUnits = dbOrderProcess.AccountingUnits.ToList
      lstAccountingUnits.Sort(New ACUComparer)
      tvMain.Nodes("ndAccountingUnits").Nodes.Clear()
      For Each acu As AccountingUnit In lstAccountingUnits
         tvMain.Nodes("ndAccountingUnits").Nodes.Add(acu.TreeNode)
      Next
   End Sub
   Private Sub NewAccountingUnit()
      Dim objNewAccountingUnit As New AccountingUnit
      Dim frmEditAccountingUnit As New frmAccountingUnit(objNewAccountingUnit, lstAccountingUnits)
      frmEditAccountingUnit.Text = "New AccountingUnit"
      If frmEditAccountingUnit.ShowDialog = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.AccountingUnits.InsertOnSubmit(objNewAccountingUnit)
         dbOrderProcess.SubmitChanges()
         LoadAccountingUnits()
         dgvMain.DataSource = lstAccountingUnits
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub EditAccountingUnit(ByVal ID As Integer)
      Dim comparer As New AccountingUnitPredicate(ID)
      Dim EditAccountingUnit As AccountingUnit = lstAccountingUnits.Find(AddressOf comparer.CompareIDs)
      Dim frmEditAccountingUnit As New frmAccountingUnit(EditAccountingUnit, lstAccountingUnits)
      frmEditAccountingUnit.Text = "AccountingUnit " & EditAccountingUnit.ShortID
      If frmEditAccountingUnit.ShowDialog = DialogResult.OK Then
         dbOrderProcess.SubmitChanges()
         LoadAccountingUnits()
         dgvMain.DataSource = lstAccountingUnits
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub RemoveAccountingUnit(ByVal ID As Integer)
      Dim comparer As New AccountingUnitPredicate(ID)
      Dim DelAccountingUnit As AccountingUnit = lstAccountingUnits.Find(AddressOf comparer.CompareIDs)
      If MessageBox.Show("Delete AccountingUnit " & DelAccountingUnit.ShortID & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.AccountingUnits.DeleteOnSubmit(DelAccountingUnit)
         dbOrderProcess.SubmitChanges()
         LoadAccountingUnits()
         dgvMain.DataSource = lstAccountingUnits
         dgvMain.Refresh()
      End If
   End Sub
   Public Sub FixAccountingUnitView(ByVal DataGridView As DataGridView)
      DataGridView.Columns("ShortID").Width = 80
      DataGridView.Columns("ShortID").HeaderText = "ShortID"
      DataGridView.Columns("ShortID").DisplayIndex = 0
      DataGridView.Columns("CostCenter").Width = 100
      DataGridView.Columns("CostCenter").HeaderText = "CostCenter"
      DataGridView.Columns("CostCenter").DisplayIndex = 1
   End Sub
   Private Sub mmFileNewAccountingUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmFileNewAccountingUnit.Click
      NewAccountingUnit()
   End Sub
#End Region
#Region "ItemClasses"
   Private Sub LoadItemClasses()
      lstItemClasses = dbOrderProcess.ItemClasses.ToList
      tvMain.Nodes("ndItemClasses").Nodes.Clear()
      For Each ic As ItemClass In lstItemClasses
         tvMain.Nodes("ndItemClasses").Nodes.Add(ic.TreeNode)
      Next
      Dim qrytest = From it As Item In dbOrderProcess.Items Where it.AccountingUnit.ShortID = "tst"
      Dim lstanswer As List(Of Item) = qrytest.ToList
   End Sub
   Private Sub NewItemClass()
      Dim NewItemClass As New ItemClass
      Dim frmEditItemClass As New frmItemClass(NewItemClass)
      If frmEditItemClass.ShowDialog = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.ItemClasses.InsertOnSubmit(NewItemClass)
         dbOrderProcess.SubmitChanges()
         LoadItemClasses()
         dgvMain.DataSource = lstItemClasses
         dgvMain.Refresh()
         dsType = dsTypes.ItemClasses
      End If
   End Sub
   Private Sub EditItemClass(ByVal ID As Integer)
      Dim comparer As New ItemClassPredicate(ID)
      Dim EditItemClass As ItemClass = lstItemClasses.Find(AddressOf comparer.CompareIDs)
      Dim frmEditItemClass As New frmItemClass(EditItemClass)
      frmEditItemClass.Text = EditItemClass.ShortID
      If frmEditItemClass.ShowDialog = DialogResult.OK Then
         dbOrderProcess.SubmitChanges()
         LoadItemClasses()
         dgvMain.DataSource = lstItemClasses
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub RemoveItemClass(ByVal ID As Integer)
      Dim comparer As New ItemClassPredicate(ID)
      Dim DelItemClass As ItemClass = lstItemClasses.Find(AddressOf comparer.CompareIDs)
      If MessageBox.Show("Delete ItemClass " & DelItemClass.ShortID & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.ItemClasses.DeleteOnSubmit(DelItemClass)
         dbOrderProcess.SubmitChanges()
         LoadItemClasses()
         dgvMain.DataSource = lstItemClasses
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub mmFileNewItemClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmFileNewItemClass.Click
      NewItemClass()
   End Sub
   Public Sub FixItemClassView(ByVal DataGridView As DataGridView)
      DataGridView.Columns("ShortID").Width = 80
      DataGridView.Columns("ShortID").HeaderText = "ShortID"
      DataGridView.Columns("ShortID").DisplayIndex = 0
      DataGridView.Columns("Description").Width = 150
      DataGridView.Columns("Description").HeaderText = "Description"
      DataGridView.Columns("Description").DisplayIndex = 1
   End Sub
#End Region
#Region "Orderers"
   Private Sub LoadOrderers()
      lstOrderers = dbOrderProcess.Orderers.ToList
      tvMain.Nodes("ndOrderers").Nodes.Clear()
      For Each ordr As Orderer In lstOrderers
         tvMain.Nodes("ndOrderers").Nodes.Add(ordr.TreeNode)
      Next
   End Sub
   Private Sub NewOrderer()
      Dim NewOrderer As New Orderer
      Dim frmEditOrderer As New frmOrderer(NewOrderer, lstOrderers)
      If frmEditOrderer.ShowDialog = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.Orderers.InsertOnSubmit(NewOrderer)
         dbOrderProcess.SubmitChanges()
         LoadOrderers()
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub EditOrderer(ByVal ID As Integer)
      Dim comparer As New OrdererPredicate(ID)
      Dim EditOrderer As Orderer = lstOrderers.Find(AddressOf comparer.CompareIDs)
      Dim frmEditOrderer As New frmOrderer(EditOrderer, lstOrderers)
      frmEditOrderer.Text = "Orderer " & EditOrderer.Name
      If frmEditOrderer.ShowDialog = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.SubmitChanges()
         LoadOrderers()
         dgvMain.DataSource = lstOrderers
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub RemoveOrderer(ByVal ID As Integer)
      Dim comparer As New OrdererPredicate(ID)
      Dim DelOrderer As Orderer = lstOrderers.Find(AddressOf comparer.CompareIDs)
      If MessageBox.Show("Delete Orderer " & DelOrderer.Name & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.Orderers.DeleteOnSubmit(DelOrderer)
         dbOrderProcess.SubmitChanges()
         LoadOrderers()
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub mmFileNewOrderer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmFileNewOrderer.Click
      NewOrderer()
   End Sub
   Public Sub FixOrdererView(ByVal DataGridView As DataGridView)
      DataGridView.Columns("Name").Width = 120
      DataGridView.Columns("Name").HeaderText = "Name"
      DataGridView.Columns("Name").DisplayIndex = 0
      DataGridView.Columns("EMailAddress").Width = 190
      DataGridView.Columns("EMailAddress").HeaderText = "E-Mail"
      DataGridView.Columns("EMailAddress").DisplayIndex = 1
   End Sub
#End Region
#Region "Suppliers"
   Private Sub LoadSuppliers()
      lstSuppliers = dbOrderProcess.Suppliers.ToList
      tvMain.Nodes("ndSuppliers").Nodes.Clear()
      For Each sup As Supplier In lstSuppliers
         tvMain.Nodes("ndSuppliers").Nodes.Add(sup.TreeNode)
      Next
   End Sub
   Private Sub NewSupplier()
      Dim NewSupplier As New Supplier
      Dim frmEditSupplier As New frmSupplier(NewSupplier)
      If frmEditSupplier.ShowDialog = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.Suppliers.InsertOnSubmit(NewSupplier)
         dbOrderProcess.SubmitChanges()
         LoadSuppliers()
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub EditSupplier(ByVal ID As Integer)
      Dim comparer As New SupplierPredicate(ID)
      Dim EditSupplier As Supplier = lstSuppliers.Find(AddressOf comparer.CompareIDs)
      Dim frmEditSupplier As New frmSupplier(EditSupplier)
      frmEditSupplier.Text = "Supplier " & EditSupplier.ShortID
      If frmEditSupplier.ShowDialog = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.SubmitChanges()
         LoadSuppliers()
         dgvMain.DataSource = lstSuppliers
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub RemoveSupplier(ByVal ID As Integer)
      Dim comparer As New SupplierPredicate(ID)
      Dim DelSupplier As Supplier = lstSuppliers.Find(AddressOf comparer.CompareIDs)
      If MessageBox.Show("Delete Supplier " & DelSupplier.ShortID & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.Suppliers.DeleteOnSubmit(DelSupplier)
         dbOrderProcess.SubmitChanges()
         LoadSuppliers()
         dgvMain.Refresh()
      End If
   End Sub
   Private Sub mmFileNewSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmFileNewSupplier.Click
      NewSupplier()
   End Sub
   Public Sub FixSupplierView(ByVal DataGridView As DataGridView)
      DataGridView.Columns("ShortID").Width = 80
      DataGridView.Columns("ShortID").HeaderText = "ShortID"
      DataGridView.Columns("ShortID").DisplayIndex = 0
      DataGridView.Columns("Description").Width = 100
      DataGridView.Columns("Description").HeaderText = "Description"
      DataGridView.Columns("Description").DisplayIndex = 1
      DataGridView.Columns("Address").Width = 170
      DataGridView.Columns("Address").HeaderText = "Address"
      DataGridView.Columns("Address").DisplayIndex = 2
      DataGridView.Columns("MailAddress").Width = 100
      DataGridView.Columns("MailAddress").HeaderText = "E-Mail"
      DataGridView.Columns("MailAddress").DisplayIndex = 3
   End Sub
#End Region
#Region "ConfirmedItems"
   Private Sub OpenAssignedItems()
      If frmGetAssignedItems Is Nothing OrElse frmGetAssignedItems.IsClosed Then
         'Dim lstGetAssignedItems As New List(Of ConfirmedItem)
         Dim lstGetAssignedItems As New List(Of Item)
         'Dim qryGetAssignedItems = From confit As ConfirmedItem In lstConfirmedItems Where (confit.DateAssigned IsNot Nothing)
            '   Dim qryGetAssignedItems = From it As Item In dbOrderProcess.Items Where (it.Accounting IsNot Nothing) Select it Take 3000 Skip 1000
            '  lstGetAssignedItems = qryGetAssignedItems.ToList
         'frmGetAssignedItems = New frmConfirmedItems(dbOrderProcess, dbAIMS, lstGetAssignedItems)
            frmGetAssignedItems = New frmAvailableItems(dbOrderProcess, dbAIMS, lstGetAssignedItems, frmAvailableItems.QUery.assigned)
         frmGetAssignedItems.Text = "Assigned Items"
         frmGetAssignedItems.Tag = "AssignedItems"
         frmGetAssignedItems.Show(Me)
      Else
         frmGetAssignedItems.Close()
         frmGetAssignedItems = Nothing
      End If
   End Sub
   Private Sub OpenAvailableItems()
      If frmGetAvailableItems Is Nothing OrElse frmGetAvailableItems.IsClosed Then
         Dim lstGetAvailableItems As New List(Of Item)
         Dim qryGetAvailableItems = From it As Item In dbOrderProcess.Items Where (it.Accounting Is Nothing) Select it
         lstGetAvailableItems = qryGetAvailableItems.ToList
            frmGetAvailableItems = New frmAvailableItems(dbOrderProcess, dbAIMS, lstGetAvailableItems, frmAvailableItems.QUery.available)
         frmGetAvailableItems.Text = "Available Items"
         frmGetAvailableItems.Tag = "AvailableItems"
         frmGetAvailableItems.Show(Me)
      Else
         frmGetAvailableItems.Close()
         frmGetAvailableItems = Nothing
      End If
   End Sub
   Private Sub OpenConfirmedItems()
      If frmGetConfirmedItems Is Nothing OrElse frmGetConfirmedItems.IsClosed Then
         Dim lstGetConfirmedItems As New List(Of ConfirmedItem)
         lstGetConfirmedItems = Nothing
         Dim qryGetConfirmedItems = From confit As ConfirmedItem In lstConfirmedItems Where (confit.DateOrdered Is Nothing And confit.DateAssigned Is Nothing And confit.OrderAction <> "Pool") Select confit
         lstGetConfirmedItems = qryGetConfirmedItems.ToList
         frmGetConfirmedItems = New frmConfirmedItems(dbOrderProcess, dbAIMS, lstGetConfirmedItems)
         frmGetConfirmedItems.Text = "Confirmed Items"
         frmGetConfirmedItems.Tag = "ConfirmedItems"
         frmGetConfirmedItems.Show(Me)
      Else
         frmGetConfirmedItems.Close()
         frmGetConfirmedItems = Nothing
      End If
   End Sub
   Private Sub OpenOrderedItems()
      If frmGetOrderedItems Is Nothing OrElse frmGetOrderedItems.IsClosed Then
         Dim lstGetOrderedItems As New List(Of ConfirmedItem)
         Dim qryGetOrderedItems = From confit As ConfirmedItem In lstConfirmedItems Where (confit.DateOrdered IsNot Nothing And confit.DateAssigned Is Nothing) Select confit
         lstGetOrderedItems = qryGetOrderedItems.ToList
         frmGetOrderedItems = New frmConfirmedItems(dbOrderProcess, dbAIMS, lstGetOrderedItems)
         frmGetOrderedItems.Text = "Ordered Items"
         frmGetOrderedItems.Tag = "OrderedItems"
         frmGetOrderedItems.Show(Me)
      Else
         frmGetOrderedItems.Close()
         frmGetOrderedItems = Nothing
      End If
   End Sub
   Public Sub NewConfirmedItem(ByVal ConfirmedItem As ConfirmedItem)
      Dim objConfirmedItem As New ConfirmedItem
      If Not (ConfirmedItem Is Nothing) Then
         objConfirmedItem.AccountingUnit = ConfirmedItem.AccountingUnit
         objConfirmedItem.Orderer = ConfirmedItem.Orderer
         objConfirmedItem.OrderableItem = ConfirmedItem.OrderableItem
      End If
      Dim frmNewConfirmedItem As New frmConfirmedItem(objConfirmedItem, lstOrderableItems, lstAccountingUnits, lstOrderers)
      frmNewConfirmedItem.Text = "New ConfirmedItem"
      Dim dlgResult As DialogResult = frmNewConfirmedItem.ShowDialog
      If dlgResult = Windows.Forms.DialogResult.OK Or dlgResult = Windows.Forms.DialogResult.Retry Then
         dbOrderProcess.ConfirmedItems.InsertOnSubmit(objConfirmedItem)
         dbOrderProcess.SubmitChanges()
         lstConfirmedItems = dbOrderProcess.ConfirmedItems.ToList
         Dim lstGetConfirmedItems As New List(Of ConfirmedItem)
         Dim qryGetConfirmedItems = From confit As ConfirmedItem In lstConfirmedItems Where (confit.DateOrdered Is Nothing And confit.DateAssigned Is Nothing) Order By confit.DateConfirmed Select confit
         lstGetConfirmedItems = qryGetConfirmedItems.ToList
         If frmGetConfirmedItems Is Nothing Then
            frmGetConfirmedItems = New frmConfirmedItems(dbOrderProcess, dbAIMS, lstGetConfirmedItems)
            frmGetConfirmedItems.Text = "Confirmed Items"
            frmGetConfirmedItems.Tag = "ConfirmedItems"
            frmGetConfirmedItems.Show(Me)
         Else
            frmGetConfirmedItems.RefreshList(lstGetConfirmedItems)
         End If
         If dlgResult = Windows.Forms.DialogResult.Retry Then
            NewConfirmedItem(objConfirmedItem)
         End If
      End If
   End Sub
   Public Sub EditConfirmedItem(ByVal ConfirmedItem As ConfirmedItem)
      Dim frmEditConfirmedItem As New frmConfirmedItem(ConfirmedItem, lstOrderableItems, lstAccountingUnits, lstOrderers)
      frmEditConfirmedItem.Text = "Edit ConfirmedItem"
      Dim dlgResult As DialogResult = frmEditConfirmedItem.ShowDialog
      If dlgResult = Windows.Forms.DialogResult.OK Then
         dbOrderProcess.SubmitChanges()
         RefreshAll()
      End If
   End Sub
   Public Sub RemoveConfirmedItem(ByRef ConfirmedItem As ConfirmedItem)
      dbOrderProcess.ConfirmedItems.DeleteOnSubmit(ConfirmedItem)
      dbOrderProcess.SubmitChanges()
      RefreshAll()
   End Sub
   Private Sub mmEditNewConfirmedItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmEditNewConfirmedItem.Click
      NewConfirmedItem(Nothing)
   End Sub
#End Region
#Region "dgvMain"
   Private Sub dgvMain_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles dgvMain.MouseDown
      If e.Button = Windows.Forms.MouseButtons.Right Then
         Dim hit As DataGridView.HitTestInfo = dgvMain.HitTest(e.X, e.Y)
         cmdgvMainNew.Enabled = True
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
         ElseIf dsType = dsTypes.OrderItems Then
            Dim comparer As New OrderPredicate(CInt(dsID))
            Dim actOrder As Order = lstOrders.Find(AddressOf comparer.CompareIDs)
            If actOrder.Finalized Then
               cmdgvMainNew.Enabled = False
            End If
            Dim sumOrdered As Integer = 0
            Dim sumDelivered As Integer = 0
            For Each ordit As OrderItem In actOrder.OrderItems
               sumOrdered = sumOrdered + ordit.NrOrdered
               If ordit.NrDelivered.HasValue Then
                  sumDelivered = sumDelivered + ordit.NrDelivered
               End If
            Next
            If sumDelivered = sumOrdered Then
               cmdgvMainDelivery.Enabled = False
            Else
               cmdgvMainDelivery.Enabled = True
            End If
         ElseIf dsType = dsTypes.Items Then
            cmdgvMainNew.Enabled = False
            cmdgvMainSepDelivery.Visible = False
            cmdgvMainDelivery.Visible = False
         Else
            cmdgvMainSepDelivery.Visible = False
            cmdgvMainDelivery.Visible = False
         End If
      ElseIf dsType = dsTypes.Items Then
         Dim lstItems As List(Of Item) = dgvMain.DataSource
         Dim selItems As New List(Of Item)
         For Each dgvr As DataGridViewRow In dgvMain.SelectedRows
            selItems.Add(dgvr.DataBoundItem)
         Next
         dragData = selItems
         dgvMain.DoDragDrop(selItems, DragDropEffects.Copy)
      End If
   End Sub
   Private Sub dgvMain_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMain.CellDoubleClick
      cmdgvMainEdit_Click(sender, e)
   End Sub
   Private Sub cmdgvMainNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgvMainNew.Click
      If dsType = dsTypes.Orders Then
         NewOrder()
      ElseIf dsType = dsTypes.OrderItems Then
         NewOrderItem()
      ElseIf dsType = dsTypes.AccountingUnits Then
         NewAccountingUnit()
      ElseIf dsType = dsTypes.ItemClasses Then
         NewItemClass()
      ElseIf dsType = dsTypes.Suppliers Then
         NewSupplier()
      ElseIf dsType = dsTypes.Orderers Then
         NewOrderer()
      End If
      dgvMain.Refresh()
   End Sub
   Private Sub cmdgvMainEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgvMainEdit.Click
      If dsType = dsTypes.Orders AndAlso Not (dgvMain.SelectedRows(0).Cells("Finalized").Value) Then
         EditOrder(CInt(dgvMain.SelectedRows(0).Cells("ID").Value))
      ElseIf dsType = dsTypes.OrderItems Then
         EditOrderItem(CInt(tvMain.SelectedNode.Tag), CInt(dgvMain.SelectedRows(0).Cells("ID").Value))
      ElseIf dsType = dsTypes.Items Then
         For Each dgvr As DataGridViewRow In dgvMain.SelectedRows
            EditItem(dgvr.DataBoundItem)
         Next
      ElseIf dsType = dsTypes.AccountingUnits Then
         EditAccountingUnit(dgvMain.SelectedRows(0).Cells("ID").Value)
      ElseIf dsType = dsTypes.ItemClasses Then
         EditItemClass(dgvMain.SelectedRows(0).Cells("ID").Value)
      ElseIf dsType = dsTypes.Suppliers Then
         EditSupplier(dgvMain.SelectedRows(0).Cells("ID").Value)
      ElseIf dsType = dsTypes.Orderers Then
         EditOrderer(dgvMain.SelectedRows(0).Cells("ID").Value)
      End If
      dgvMain.Refresh()
   End Sub
   Private Sub cmdgvMainRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgvMainRemove.Click
      If dsType = dsTypes.Orders Then
         RemoveOrder(dgvMain.SelectedRows(0).Cells("ID").Value)
      ElseIf dsType = dsTypes.OrderItems Then
         RemoveOrderItem(dgvMain.SelectedRows(0).Cells("ID").Value)
      ElseIf dsType = dsTypes.Items Then
         For Each dgvr As DataGridViewRow In dgvMain.SelectedRows
            RemoveItem(dgvr.DataBoundItem)
         Next
      ElseIf dsType = dsTypes.AccountingUnits Then
         RemoveAccountingUnit(dgvMain.SelectedRows(0).Cells("ID").Value)
      ElseIf dsType = dsTypes.ItemClasses Then
         RemoveItemClass(dgvMain.SelectedRows(0).Cells("ID").Value)
      ElseIf dsType = dsTypes.Suppliers Then
         RemoveSupplier(dgvMain.SelectedRows(0).Cells("ID").Value)
      ElseIf dsType = dsTypes.Orderers Then
         RemoveOrderer(dgvMain.SelectedRows(0).Cells("ID").Value)
      End If
   End Sub
   Private Sub dgvMain_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvMain.DragOver
      If e.Data.GetDataPresent(GetType(List(Of Integer))) And dsType = dsTypes.OrderItems Then
         Dim comparer As New OrderPredicate(CInt(dsID))
         Dim objOrder As Order = lstOrders.Find(AddressOf comparer.CompareIDs)
         If Not objOrder.Finalized Then
            e.Effect = DragDropEffects.Copy
         End If
      End If
   End Sub
   Private Sub dgvMain_QueryContinueDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles dgvMain.QueryContinueDrag
      If dragData.GetType Is GetType(List(Of Item)) Then
         ssMainLabel.Text = ""
         Dim selItems As List(Of Item) = dragData
         For Each dit As Item In selItems
            If Not (dit.Accounting Is Nothing) Then
               ssMainLabel.Text = "Dragging of already assigned items is not possible."
               e.Action = DragAction.Cancel
               Exit For
            ElseIf (dit.AimsID Is Nothing) And (dit.OrderItem.OrderableItem.ItemClassID = 2) Then
               ssMainLabel.Text = "This " & dit.OrderItem.ItemClass.ShortID & " Item has not been inventarized, Assignment is not possible"
               e.Action = DragAction.Cancel
               Exit For
            End If
         Next
      End If
   End Sub
   Private Sub dgvMain_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvMain.DragDrop
      If e.Data.GetDataPresent(GetType(List(Of Integer))) Then
         Dim MergeOrderItems As Boolean = False
         Dim lstDraggedItems As New List(Of ConfirmedItem)
         Dim lstIDs As List(Of Integer) = e.Data.GetData(GetType(List(Of Integer)))
         For Each ID As Integer In lstIDs
            Dim comparer As New ConfirmedItemPredicate(ID)
            Dim objConfItem As ConfirmedItem = lstConfirmedItems.Find(AddressOf comparer.CompareIDs)
            lstDraggedItems.Add(objConfItem)
         Next
         For Each objConfirmedItem As ConfirmedItem In lstDraggedItems
            Dim abort As Boolean = False
            Dim objOrdItem As OrderItem = Nothing
            'Check for existing OrderItems with the same OrderableItemID
            Dim ordcomparer As New OrderPredicate(CInt(dsID))
            Dim objOrder As Order = lstOrders.Find(AddressOf ordcomparer.CompareIDs)
            If objOrder.SupplierID <> objConfirmedItem.OrderableItem.SupplierID Then
               If MessageBox.Show("Supplier does not match. Order anyway?", "Supplier Mismatch", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
                  abort = True
               End If
            End If
            If Not abort Then
               For Each ordit As OrderItem In objOrder.OrderItems
                  If ordit.OrderableItemsID = objConfirmedItem.OrderableItemsID Then
                     If MessageBox.Show("There is already an order for " & ordit.Description & "." & vbCrLf & "Merge orders?", "Double Entries", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        objOrdItem = ordit
                        objOrdItem.NrOrdered = objOrdItem.NrOrdered + objConfirmedItem.QuantityOrdered
                        MergeOrderItems = True
                     End If
                     Exit For
                  End If
               Next
               If objOrdItem Is Nothing Then
                  objOrdItem = New OrderItem
                  objOrdItem.NrOrdered = objConfirmedItem.QuantityOrdered
                  objOrdItem.OrderableItem = objConfirmedItem.OrderableItem
                  objOrdItem.ItemClass = objConfirmedItem.OrderableItem.ItemClass
                  objOrdItem.FromDragging = True
               End If
               objOrdItem.CompletionDate = Nothing
               Dim frmEditOrderItem As New frmOrderItem(objOrdItem, lstItemClasses, lstOrderableItems, lstSuppliers, dbAIMS)
               frmEditOrderItem.Text = "Order Item " & objOrder.Nr
               If frmEditOrderItem.ShowDialog = Windows.Forms.DialogResult.OK Then
                  objOrdItem.Order = objOrder
                  If MergeOrderItems Then
                     dbOrderProcess.SubmitChanges()
                  Else
                     dbOrderProcess.OrderItems.InsertOnSubmit(objOrdItem)
                     dbOrderProcess.SubmitChanges()
                  End If
                  LoadOrders(objOrder)
                  'Update ConfirmedItems
                  Dim cicomparer As New ConfirmedItemPredicate(objConfirmedItem.ID)
                  Dim objConfItem As ConfirmedItem = lstConfirmedItems.Find(AddressOf cicomparer.CompareIDs)
                  objConfItem.OrderItem = objOrdItem
                  objConfItem.DateOrdered = Now()
                  dbOrderProcess.SubmitChanges()
                  Dim lstGetConfirmedItems As New List(Of ConfirmedItem)
                  Dim qryGetConfirmedItems = From confit As ConfirmedItem In lstConfirmedItems Where (confit.DateOrdered Is Nothing And confit.DateAssigned Is Nothing) Select confit
                  lstGetConfirmedItems = qryGetConfirmedItems.ToList
                  frmGetConfirmedItems.RefreshList(lstGetConfirmedItems)
                  If Not frmGetOrderedItems Is Nothing Then
                     Dim lstGetOrderedItems As New List(Of ConfirmedItem)
                     Dim qryGetOrderedItems = From confit As ConfirmedItem In lstConfirmedItems Where (confit.DateOrdered IsNot Nothing And confit.DateAssigned Is Nothing) Select confit
                     lstGetOrderedItems = qryGetOrderedItems.ToList
                     frmGetOrderedItems.RefreshList(lstGetOrderedItems)
                  End If
               Else
                  If MergeOrderItems Then
                     objOrdItem.NrOrdered = objOrdItem.NrOrdered - objConfirmedItem.QuantityOrdered
                  End If
               End If
            End If
            RefreshAll()
         Next
      End If
   End Sub
   Private Sub dgvMain_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMain.RowEnter
      If dsType = dsTypes.Items Then
         If e.ColumnIndex = 2 Then
            For Each dgvr As DataGridViewRow In dgvMain.SelectedRows
               EditItem(dgvr.DataBoundItem)
            Next
         End If
      End If
   End Sub
#End Region
#Region "tvMain"
   Private Sub tvMain_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvMain.MouseDown
      If e.Button = Windows.Forms.MouseButtons.Right Then
         tvMain.SelectedNode = tvMain.GetNodeAt(e.X, e.Y)
         tvMain_AfterSelect(sender, New TreeViewEventArgs(tvMain.SelectedNode))
      End If
   End Sub
   Private Sub tvMain_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMain.AfterSelect
      cmtvMainNew.Enabled = True
      cmtvMainEdit.Enabled = False
      cmtvMainRemove.Enabled = False
      cmtvMainSepDelivery.Visible = False
      cmtvMainFinalize.Visible = False
      cmtvMainNewDelivery.Visible = False
      mmDeliveryNew.Enabled = False
      If tvMain.SelectedNode.Level = 0 Then
         If tvMain.SelectedNode.Name = "ndOrders" Then
            dgvMain.DataSource = lstOrders
            If Not (lstOrders Is Nothing) Then
               FixOrderView(dgvMain)
            End If
            dsType = dsTypes.Orders
         ElseIf tvMain.SelectedNode.Name = "ndAccountingUnits" Then
            dgvMain.DataSource = lstAccountingUnits
            If Not (lstAccountingUnits Is Nothing) Then
               FixAccountingUnitView(dgvMain)
            End If
            dsType = dsTypes.AccountingUnits
         ElseIf tvMain.SelectedNode.Name = "ndItemClasses" Then
            dgvMain.DataSource = lstItemClasses
            If Not (lstItemClasses Is Nothing) Then
               FixItemClassView(dgvMain)
            End If
            dsType = dsTypes.ItemClasses
         ElseIf tvMain.SelectedNode.Name = "ndSuppliers" Then
            dgvMain.DataSource = lstSuppliers
            If Not (lstSuppliers Is Nothing) Then
               FixSupplierView(dgvMain)
            End If
            dsType = dsTypes.Suppliers
         ElseIf tvMain.SelectedNode.Name = "ndOrderers" Then
            dgvMain.DataSource = lstOrderers
            If Not (lstOrderers Is Nothing) Then
               FixOrdererView(dgvMain)
            End If
            dsType = dsTypes.Orderers
         End If
         dsID = Nothing
      ElseIf tvMain.SelectedNode.Level = 1 Then
         cmtvMainNew.Enabled = False
         cmtvMainEdit.Enabled = True
         cmtvMainRemove.Enabled = True
         cmtvMainSepDelivery.Visible = False
         cmtvMainFinalize.Visible = False
         cmtvMainNewDelivery.Visible = False
         mmDeliveryNew.Enabled = False
         If tvMain.SelectedNode.Parent.Name = "ndOrders" Then
            cmtvMainSepDelivery.Visible = True
            cmtvMainSendMail.Visible = True
            cmtvMainFinalize.Visible = True
            cmtvMainNewDelivery.Visible = True
            mmDeliveryNew.Enabled = True
            Dim ordcomparer As New OrderPredicate(CInt(tvMain.SelectedNode.Tag))
            Dim ActOrder As Order = lstOrders.Find(AddressOf ordcomparer.CompareIDs)
            If ActOrder.Finalized Then
               cmtvMainFinalize.Enabled = False
               cmtvMainRemove.Enabled = False
               cmtvMainEdit.Enabled = False
            Else
               cmtvMainFinalize.Enabled = True
            End If
            lstOrderItems = ActOrder.OrderItems.ToList
            If lstOrderItems.Count = 0 Then
               cmtvMainNewDelivery.Enabled = False
               mmDeliveryNew.Enabled = False
            Else
               cmtvMainNewDelivery.Enabled = True
               mmDeliveryNew.Enabled = True
            End If
            dgvMain.DataSource = lstOrderItems
            If Not (lstOrderItems Is Nothing) Then
               FixOrderItemView(dgvMain)
            End If
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
         ElseIf tvMain.SelectedNode.Parent.Name = "ndOrderers" Then
            dsType = dsTypes.Orderers
            dsID = CInt(tvMain.SelectedNode.Tag)
         End If
      ElseIf tvMain.SelectedNode.Level = 2 Then
         If tvMain.SelectedNode.Parent.Parent.Name = "ndOrders" Then
            Dim ordcomparer As New OrderPredicate(CInt(tvMain.SelectedNode.Parent.Tag))
            Dim Order As Order = lstOrders.Find(AddressOf ordcomparer.CompareIDs)
            Dim OrderItemsID As Integer = CInt(tvMain.SelectedNode.Tag)
            Dim oicomparer As New OrderItemPredicate(CInt(tvMain.SelectedNode.Tag))
            Dim lstOrderItems As List(Of OrderItem) = Order.OrderItems.ToList
            Dim ActOrderItem As OrderItem = lstOrderItems.Find(AddressOf oicomparer.CompareIDs)
            lstItems = ActOrderItem.Items.ToList
            If Order.Finalized Then
               cmtvMainNew.Enabled = False
               cmtvMainEdit.Enabled = False
               cmtvMainRemove.Enabled = False
            Else
               cmtvMainNew.Enabled = False
               cmtvMainEdit.Enabled = True
               If lstItems.Count = 0 Then
                  cmtvMainRemove.Enabled = True
               Else
                  cmtvMainRemove.Enabled = False
               End If
            End If
            dsType = dsTypes.Items
            dsID = OrderItemsID
            dgvMain.DataSource = lstItems
            If Not (lstItems Is Nothing) Then
               FixItemView(dgvMain)
            End If
            dgvMain.Refresh()
         End If
      End If
   End Sub
   Private Sub tvMain_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tvMain.DoubleClick
      Dim SelNode As TreeNode = tvMain.SelectedNode
      If SelNode.Level = 0 Then
      ElseIf SelNode.Level = 1 Then
         If SelNode.Parent.Name = "ndOrders" Then
         ElseIf SelNode.Parent.Name = "ndItemClasses" Then
            EditItemClass(CInt(SelNode.Tag))
         ElseIf SelNode.Parent.Name = "ndAccountingUnits" Then
            EditAccountingUnit(CInt(SelNode.Tag))
         ElseIf SelNode.Parent.Name = "ndOrderers" Then
            EditOrderer(CInt(SelNode.Tag))
         ElseIf SelNode.Parent.Name = "ndSuppliers" Then
            EditSupplier(CInt(SelNode.Tag))
         End If
      End If
   End Sub
   Private Sub cmtvMainNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainNew.Click
      If tvMain.SelectedNode.Name = "ndOrders" Then
         NewOrder()
      ElseIf tvMain.SelectedNode.Name = "ndAccountingUnits" Then
         NewAccountingUnit()
      ElseIf tvMain.SelectedNode.Name = "ndItemClasses" Then
         NewItemClass()
      ElseIf tvMain.SelectedNode.Name = "ndSuppliers" Then
         NewSupplier()
      ElseIf tvMain.SelectedNode.Name = "ndOrderers" Then
         NewOrderer()
      End If
      dgvMain.Refresh()
   End Sub
   Private Sub cmtvMainEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainEdit.Click
      If tvMain.SelectedNode.Parent.Name = "ndOrders" Then
         EditOrder(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndAccountingUnits" Then
         EditAccountingUnit(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndItemClasses" Then
         EditItemClass(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndSuppliers" Then
         EditSupplier(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndOrderers" Then
         EditOrderer(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Parent.Name = "ndOrders" Then
         EditOrderItem(CInt(tvMain.SelectedNode.Parent.Tag), CInt(tvMain.SelectedNode.Tag))
      End If
      dgvMain.Refresh()
   End Sub
   Private Sub cmtvMainRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainRemove.Click
      If tvMain.SelectedNode.Parent.Name = "ndOrders" Then
         RemoveOrder(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Parent.Name = "ndOrders" Then
         RemoveOrderItem(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndAccountingUnits" Then
         RemoveAccountingUnit(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndItemClasses" Then
         RemoveItemClass(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndSuppliers" Then
         RemoveSupplier(CInt(tvMain.SelectedNode.Tag))
      ElseIf tvMain.SelectedNode.Parent.Name = "ndOrderers" Then
         RemoveOrderer(CInt(tvMain.SelectedNode.Tag))
      End If
   End Sub
#End Region

   Private Sub mmFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmFileExit.Click
      If Not DBCheckThread Is Nothing Then
         If DBCheckThread.IsAlive Then
            DBCheckThread.Abort()
         End If
      End If
      Me.Close()
   End Sub

   Private Sub frmMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
      If Not DBCheckThread Is Nothing Then
         If DBCheckThread.IsAlive Then
            DBCheckThread.Abort()
         End If
      End If
        WriteWindowState()
        If (dbOrderProcess IsNot Nothing) Then
            dbOrderProcess.Dispose()
        End If
        If (dbAIMS IsNot Nothing) Then
            dbAIMS.Dispose()
        End If
    End Sub

   Private Sub mmViewAssignedItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmViewAssignedItems.Click
      OpenAssignedItems()
   End Sub
   Private Sub mmViewAvailableItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmViewAvailableItems.Click
      OpenAvailableItems()
   End Sub
   Private Sub mmViewConfirmedItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmViewConfirmedItems.Click
      OpenConfirmedItems()
   End Sub
   Private Sub mmViewOrderedItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmViewOrderedItems.Click
      OpenOrderedItems()
   End Sub

   Private Sub mmReportNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmReportNew.Click
      Dim ItemPairs As New List(Of ItemPair)
      Dim StartDate, EndDate As DateTime
      For Each acu As AccountingUnit In lstAccountingUnits
         ItemPairs.Add(New ItemPair(acu.ShortID, acu.ID))
      Next
      Dim frmNewReport As New frmReport(ItemPairs, StartDate, EndDate)
      If frmNewReport.ShowDialog = Windows.Forms.DialogResult.OK Then
         StartDate = frmNewReport.StartDate
         EndDate = frmNewReport.EndDate
         For Each ip As ItemPair In ItemPairs
            If ip.Checked Then
               AccountingUnitReport(ip, StartDate, EndDate)
            End If
         Next
         OverviewReport(StartDate, EndDate)
      End If
   End Sub

   Private Sub AccountingUnitReport(ByVal ItemPair As ItemPair, ByVal StartDate As DateTime, ByVal EndDate As DateTime)
      Dim WordApp As New Word.Application
      Dim aDoc As Word.Document = WordApp.Documents.Open(Application.StartupPath & "\Memo.doc")
      Dim i As Integer = 0
      Dim sqlStartDate As String = StartDate.Month.ToString & "-" & StartDate.Day.ToString & "-" & StartDate.Year.ToString & " 00:00:00"
      Dim sqlEndDate As String = EndDate.Month.ToString & "-" & EndDate.Day.ToString & "-" & EndDate.Year.ToString & " 23:59:59"
      'Dim qryItemSums = From it As Item In dbOrderProcess.Items Where (it.Accounting > StartDate) And (it.Accounting < EndDate) And it.AccountingUnitID = ItemPair.ID Group By Description = it.OrderItem.Description, ShortID = it.OrderItem.ItemClass.ShortID Into Number = Count(), Total = Sum(it.Price) Select (New ItemSum(ShortID, Description, Number, Total))
      Dim qryItemSums = From it As Item In dbOrderProcess.Items Where (it.Accounting > StartDate) And (it.Accounting <= EndDate) And it.AccountingUnitID = ItemPair.ID Group By Description = it.OrderItem.Description, ShortID = it.OrderItem.OrderableItem.ItemClass.ShortID Into Number = Count(), Total = Sum(it.Price) Select (New ItemSum(ShortID, Description, Number, Total))
      Dim lstItemSums As List(Of ItemSum) = qryItemSums.ToList
      Dim index As Integer = 0
      For Each fld As Word.Field In aDoc.Fields
         fld.Select()
         Dim rng As Word.Range = aDoc.ActiveWindow.Selection.Range
         rng.Font.Name = "Arial"
         rng.Font.Size = 11
         index = index + 1
         If index = 1 Then
            rng.Text = ItemPair.Name
         ElseIf index = 2 Then
            rng.Text = Now.ToShortDateString
         ElseIf index = 3 Then
            rng.Text = "Orders Delivered to " & ItemPair.Name & " Between " & StartDate.ToShortDateString & " and " & EndDate.ToShortDateString
         ElseIf index = 4 Then
            Dim strTable As String = ""
            Dim dblTotal As Double = 0.0
            Dim numItems As Integer = 0
            strTable = "ItemClass" & vbTab & "Description" & vbTab & "Number" & vbTab & "Price"
            rng.Font.Bold = True
            rng.Text = strTable
            Dim tbl As Word.Table = rng.ConvertToTable(vbTab)
            tbl.Cell(tbl.Rows.Count, 1).Width = WordApp.CentimetersToPoints(2.5)
            tbl.Cell(tbl.Rows.Count, 1).Height = WordApp.CentimetersToPoints(0.66)
            tbl.Cell(tbl.Rows.Count, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            tbl.Cell(tbl.Rows.Count, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            tbl.Cell(tbl.Rows.Count, 1).Borders.Enable = True
            tbl.Cell(tbl.Rows.Count, 2).Width = WordApp.CentimetersToPoints(9.75)
            tbl.Cell(tbl.Rows.Count, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            tbl.Cell(tbl.Rows.Count, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            tbl.Cell(tbl.Rows.Count, 2).Borders.Enable = True
            tbl.Cell(tbl.Rows.Count, 3).Width = WordApp.CentimetersToPoints(1.75)
            tbl.Cell(tbl.Rows.Count, 3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            tbl.Cell(tbl.Rows.Count, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            tbl.Cell(tbl.Rows.Count, 3).Borders.Enable = True
            tbl.Cell(tbl.Rows.Count, 4).Width = WordApp.CentimetersToPoints(2.25)
            tbl.Cell(tbl.Rows.Count, 4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            tbl.Cell(tbl.Rows.Count, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            tbl.Cell(tbl.Rows.Count, 4).Borders.Enable = True
            For Each itsum As ItemSum In lstItemSums
               tbl.Rows.Add()
               numItems = numItems + 1
               tbl.Cell(tbl.Rows.Count, 1).Height = WordApp.CentimetersToPoints(0.66)
               tbl.Cell(tbl.Rows.Count, 1).Range.Text = itsum.ShortID
               tbl.Cell(tbl.Rows.Count, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
               tbl.Cell(tbl.Rows.Count, 1).Range.Font.Bold = False
               tbl.Cell(tbl.Rows.Count, 2).Range.Text = itsum.Description
               tbl.Cell(tbl.Rows.Count, 2).Range.Font.Bold = False
               tbl.Cell(tbl.Rows.Count, 3).Range.Text = itsum.Number.ToString
               tbl.Cell(tbl.Rows.Count, 3).Range.Font.Bold = False
               tbl.Cell(tbl.Rows.Count, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
               tbl.Cell(tbl.Rows.Count, 4).Range.Text = Format(itsum.Total, "#,0.00")
               tbl.Cell(tbl.Rows.Count, 4).Range.Font.Bold = False
               tbl.Cell(tbl.Rows.Count, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
               dblTotal = dblTotal + itsum.Total
            Next
            tbl.Rows.Add()
            tbl.Cell(tbl.Rows.Count, 1).Range.Text = "Total"
            tbl.Cell(tbl.Rows.Count, 1).Range.Font.Bold = True
            tbl.Cell(tbl.Rows.Count, 4).Range.Text = Format(dblTotal, "#,0.00")
            tbl.Cell(tbl.Rows.Count, 4).Range.Font.Bold = True
            tbl.Cell(tbl.Rows.Count, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
         End If
      Next
      aDoc.SaveAs(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Orders_" & ItemPair.Name & "_" & StartDate.ToShortDateString & "_" & EndDate.ToShortDateString & ".doc")
      aDoc.Close()
      WordApp.Quit()
   End Sub
   Private Sub OverviewReport(ByVal StartDate As DateTime, ByVal EndDate As DateTime)
      Dim WordApp As New Word.Application
      Dim aDoc As Word.Document = WordApp.Documents.Open(Application.StartupPath & "\Memo.doc")
      Dim i As Integer = 0
      Dim sqlStartDate As String = StartDate.Month.ToString & "-" & StartDate.Day.ToString & "-" & StartDate.Year.ToString & " 00:00:00"
      Dim sqlEndDate As String = EndDate.Month.ToString & "-" & EndDate.Day.ToString & "-" & EndDate.Year.ToString & " 23:59:59"
      Dim qryItemSums = From it As Item In dbOrderProcess.Items Where (it.Accounting > StartDate) And (it.Accounting < EndDate) Group By AccountingUnit = it.AccountingUnit.ShortID, ShortID = it.OrderItem.OrderableItem.ItemClass.ShortID Into Number = Count(), Total = Sum(it.Price) Order By AccountingUnit Select (New ItemSum(AccountingUnit, ShortID, Number, Total))
      Dim lstItemSums As List(Of ItemSum) = qryItemSums.ToList
      Dim index As Integer = 0
      For Each fld As Word.Field In aDoc.Fields
         fld.Select()
         Dim rng As Word.Range = aDoc.ActiveWindow.Selection.Range
         rng.Font.Name = "Arial"
         rng.Font.Size = 11
         index = index + 1
         If index = 1 Then
            rng.Text = "INF"
         ElseIf index = 2 Then
            rng.Text = Now.ToShortDateString
         ElseIf index = 3 Then
            rng.Text = "Orders Delivered to All Accounting Units Between " & StartDate.ToShortDateString & " and " & EndDate.ToShortDateString
         ElseIf index = 4 Then
            Dim strTable As String = ""
            Dim dblTotal As Double = 0.0
            Dim numItems As Integer = 0
            strTable = "AccountingUnit" & vbTab & "ItemClass" & vbTab & "Number" & vbTab & "Price"
            rng.Font.Bold = True
            rng.Text = strTable
            Dim prevItem As String = ""
            Dim tbl As Word.Table = rng.ConvertToTable(vbTab)
            tbl.Cell(tbl.Rows.Count, 1).Width = WordApp.CentimetersToPoints(3.5)
            tbl.Cell(tbl.Rows.Count, 1).Height = WordApp.CentimetersToPoints(0.66)
            tbl.Cell(tbl.Rows.Count, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            tbl.Cell(tbl.Rows.Count, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            tbl.Cell(tbl.Rows.Count, 1).Borders.Enable = True
            tbl.Cell(tbl.Rows.Count, 2).Width = WordApp.CentimetersToPoints(3.0)
            tbl.Cell(tbl.Rows.Count, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            tbl.Cell(tbl.Rows.Count, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            tbl.Cell(tbl.Rows.Count, 2).Borders.Enable = True
            tbl.Cell(tbl.Rows.Count, 3).Width = WordApp.CentimetersToPoints(2.25)
            tbl.Cell(tbl.Rows.Count, 3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            tbl.Cell(tbl.Rows.Count, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            tbl.Cell(tbl.Rows.Count, 3).Borders.Enable = True
            tbl.Cell(tbl.Rows.Count, 4).Width = WordApp.CentimetersToPoints(3.0)
            tbl.Cell(tbl.Rows.Count, 4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            tbl.Cell(tbl.Rows.Count, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            tbl.Cell(tbl.Rows.Count, 4).Borders.Enable = True
            For Each itsum As ItemSum In lstItemSums
               tbl.Rows.Add()
               numItems = numItems + 1
               tbl.Cell(tbl.Rows.Count, 1).Height = WordApp.CentimetersToPoints(0.66)
               If itsum.ShortID <> prevItem Then
                  tbl.Cell(tbl.Rows.Count, 1).Range.Text = itsum.ShortID
               End If
               prevItem = itsum.ShortID
               tbl.Cell(tbl.Rows.Count, 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
               tbl.Cell(tbl.Rows.Count, 1).Range.Font.Bold = False
               tbl.Cell(tbl.Rows.Count, 2).Range.Text = itsum.Description
               tbl.Cell(tbl.Rows.Count, 2).Range.Font.Bold = False
               tbl.Cell(tbl.Rows.Count, 3).Range.Text = itsum.Number.ToString
               tbl.Cell(tbl.Rows.Count, 3).Range.Font.Bold = False
               tbl.Cell(tbl.Rows.Count, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
               tbl.Cell(tbl.Rows.Count, 4).Range.Text = Format(itsum.Total, "#,0.00")
               tbl.Cell(tbl.Rows.Count, 4).Range.Font.Bold = False
               tbl.Cell(tbl.Rows.Count, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
               dblTotal = dblTotal + itsum.Total
            Next
            tbl.Rows.Add()
            tbl.Cell(tbl.Rows.Count, 1).Range.Text = "Total"
            tbl.Cell(tbl.Rows.Count, 1).Range.Font.Bold = True
            tbl.Cell(tbl.Rows.Count, 4).Range.Text = Format(dblTotal, "#,0.00")
            tbl.Cell(tbl.Rows.Count, 4).Range.Font.Bold = True
            tbl.Cell(tbl.Rows.Count, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
         End If
         'strTable = "ItemClass" & vbTab & "Description" & vbTab & "Number" & vbTab & "Price"
         'For Each itsum As ItemSum In lstItemSums
         '   strTable = strTable & vbCr & itsum.ShortID & vbTab & itsum.Description & vbTab & itsum.Number.ToString & vbTab & Format(itsum.Total, "#,0.00")
         '   dblTotal = dblTotal + itsum.Total
         '   numItems += 1
         'Next
         'strTable = strTable & vbCr & "Total" & vbTab & vbTab & vbTab & Format(dblTotal, "#,0.00")
         'rng.Text = strTable
         'Dim tbl As Word.Table = rng.ConvertToTable(vbTab)
         'tbl.Cell(0, 1).Select()
         'WordApp.Selection.Font.Bold = True
         'tbl.Cell(0, 2).Select()
         'WordApp.Selection.Font.Bold = True
         'tbl.Cell(0, 3).Select()
         'WordApp.Selection.Font.Bold = True
         'tbl.Cell(0, 4).Select()
         'WordApp.Selection.Font.Bold = True
         'Try
         '   tbl.Cell(numItems * 4, 1).Select()
         '   WordApp.Selection.Font.Bold = True
         '   tbl.Cell(numItems * 4, 4).Select()
         '   WordApp.Selection.Font.Bold = True
         'Catch ex As Exception
         '   'do nothing
         'End Try
         'End If
      Next
      aDoc.SaveAs(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Orders_Overview" & "_" & StartDate.ToShortDateString & "_" & EndDate.ToShortDateString & ".doc")
      aDoc.Close()
      WordApp.Quit()
   End Sub

   Private Sub mmViewHideCompletedOrders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmViewHideCompletedOrders.CheckedChanged
      LoadOrders()
      tvMain.SelectedNode = tvMain.Nodes("ndOrders")
      dgvMain.DataSource = lstOrders
      dgvMain.Refresh()
      dsType = dsTypes.Orders
      dsID = Nothing
   End Sub

   Private Sub frmMain_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      If Not isloading Then
         If WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            niOrderProcess.Visible = True
         Else
            'Me.Visible = True
            niOrderProcess.Visible = False
         End If
      End If
   End Sub

   Private Sub niOrderProcess_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles niOrderProcess.DoubleClick
      If Not isloading Then
         Me.Visible = True
         WindowState = FormWindowState.Normal
      End If
   End Sub

   Private Sub mmViewRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmViewRefresh.Click
      RefreshAll()
   End Sub
   Public Sub RefreshAll()
      'dbOrderProcess.Dispose()
      'db = New OrderProcess(strDBConnection)
      dbOrderProcess.Refresh(RefreshMode.OverwriteCurrentValues)
      LoadOrders()
      LoadAccountingUnits()
      LoadItemClasses()
      LoadSuppliers()
      LoadOrderers()
      lstOrderableItems = dbOrderProcess.OrderableItems.ToList
      lstConfirmedItems = dbOrderProcess.ConfirmedItems.ToList
      If Not frmGetAvailableItems Is Nothing Then
            frmGetAvailableItems.loadItems(frmAvailableItems.QUery.available)
      End If
      If Not frmGetAssignedItems Is Nothing Then
            frmGetAssignedItems.loadItems(frmAvailableItems.QUery.assigned)
      End If
      If Not frmGetConfirmedItems Is Nothing Then
         Dim lstGetConfirmedItems As New List(Of ConfirmedItem)
         Dim qryGetConfirmedItems = From confit As ConfirmedItem In lstConfirmedItems Where (confit.DateOrdered Is Nothing And confit.DateAssigned Is Nothing And confit.OrderAction <> "Pool") Select confit
         lstGetConfirmedItems = qryGetConfirmedItems.ToList
         frmGetConfirmedItems.RefreshList(lstGetConfirmedItems)
      End If
      If Not frmGetOrderedItems Is Nothing Then
         Dim lstGetOrderedItems As New List(Of ConfirmedItem)
         Dim qryGetOrderedItems = From confit As ConfirmedItem In lstConfirmedItems Where (confit.DateOrdered IsNot Nothing And confit.DateAssigned Is Nothing) Select confit
         lstGetOrderedItems = qryGetOrderedItems.ToList
         frmGetOrderedItems.RefreshList(lstGetOrderedItems)
      End If
   End Sub

   Private Sub mmHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmHelpAbout.Click
      frmAbout.ShowDialog()
   End Sub

   Private Sub mmMainDetConfItemIDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmMainDetConfItemIDs.Click
      Dim tblItems As Table(Of Item) = dbOrderProcess.Items
      For Each it As Item In tblItems
         For Each confit As ConfirmedItem In lstConfirmedItems
            If it.Accounting.HasValue And confit.DateAssigned.HasValue Then
               Dim TimeDiff As Long = DateDiff("s", CDate(it.Accounting), CDate(confit.DateAssigned))
               If Math.Abs(TimeDiff) < 3 Then
                  If it.OrderItem.OrderableItemsID = confit.OrderableItemsID Then
                     it.ConfirmedItem = confit
                     Exit For
                  Else
                     Console.WriteLine("Item.ID:" & it.ID.ToString & ", Item.OrderableItemsID:" & it.OrderItem.OrderableItemsID.ToString & ", ConfirmedItem.OrderableItemsID: " & confit.OrderableItemsID.ToString)
                  End If
               End If
            End If
         Next
      Next
      dbOrderProcess.SubmitChanges()
   End Sub
End Class

Public Class DBChecker
   Public Event DBChecked(ByVal Sender As Object, ByVal e As Boolean)
   Private WithEvents DBCheckTimer As Timers.Timer
   Private locDBConnection As String
   Private db As OrderProcess
   Dim locFinished As Boolean = False
   Dim FirstRun As Boolean
   Dim prevConfirmedItem As New ConfirmedItem

   Public Sub New(ByVal DBConnection As String)
      locDBConnection = DBConnection
      FirstRun = True
   End Sub

   Public Sub StartChecker()
      CheckDB()
      FirstRun = False
      While Not locFinished
         Threading.Thread.Sleep(30000)
         CheckDB()
      End While
   End Sub

   Private Sub CheckDB()
      db = New OrderProcess(locDBConnection)
      Dim qryConfirmedItems = From confit As ConfirmedItem In db.ConfirmedItems Order By confit.DateConfirmed Select confit
      Dim lstConfirmedItems As List(Of ConfirmedItem) = qryConfirmedItems.ToList
      Dim lastConfirmedItem As New ConfirmedItem
      If lstConfirmedItems.Count = 0 Then
         'do nothing
      Else
         lastConfirmedItem = lstConfirmedItems(lstConfirmedItems.Count - 1)
         If Not FirstRun Then
            If prevConfirmedItem.DateConfirmed < lastConfirmedItem.DateConfirmed Then
               RaiseEvent DBChecked(Me, True)
            End If
         End If
         db.Dispose()
         prevConfirmedItem = lastConfirmedItem
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
   Orderers = 7
End Enum

Public Enum ItemType
   ConfirmedItems = 1
   OrderedItems = 2
End Enum






