Public Class frmDelivery
   Private locOrder As Order
   Private locOrderItems As OrderItems
   Private locItemClasses As ItemClasses
   Private locSuppliers As Suppliers
   Const RowDist As Integer = 25
   Dim arrDescription As TextBox()
   Dim arrItemClass As ComboBox()
   Dim arrNumOrdered As TextBox()
   Dim arrNumDelivered As ComboBox()
   Dim arrPrice As TextBox()

   Public Sub New(ByRef Order As Order, ByRef OrderItems As OrderItems, ByRef ItemClasses As ItemClasses, ByRef Suppliers As Suppliers)
      locOrder = Order
      locOrderItems = OrderItems
      locItemClasses = ItemClasses
      locSuppliers = Suppliers
      InitializeComponent()
      ReDim arrDescription(0)
      ReDim arrItemClass(0)
      ReDim arrNumOrdered(0)
      ReDim arrNumDelivered(0)
      ReDim arrPrice(0)
   End Sub

   Private Sub frmDelivery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbNr.Text = locOrder.Nr
      dtpOrderDate.Value = locOrder.OrderDate
      cbOrderer.Text = locOrder.Orderer
      Dim Suppliers As New ArrayList
      For Each sup As Supplier In locSuppliers.List
         Suppliers.Add(New cbItem(sup.ShortID, sup.ID))
      Next
      cbSupplier.DataSource = Suppliers
      cbSupplier.DisplayMember = "Name"
      cbSupplier.ValueMember = "Value"
      cbSupplier.SelectedValue = locOrder.SupplierID
      Dim numOI As Integer = 0
      For Each oi As OrderItem In locOrderItems.List
         Dim ctrlTop As Integer = 104 + numOI * RowDist
         'Description
         Dim tbDescr As New TextBox
         tbDescr.Left = 15
         tbDescr.Top = ctrlTop
         tbDescr.Width = 325
         tbDescr.Height = 20
         tbDescr.Text = oi.Description
         ReDim Preserve arrDescription(numOI)
         arrDescription(numOI) = tbDescr
         'ItemClass
         Dim cbItemClass As New ComboBox
         Dim ItemClasses As New ArrayList
         For Each ic As ItemClass In locItemClasses.List
            ItemClasses.Add(New cbItem(ic.ShortID, ic.ID))
         Next
         cbItemClass.DataSource = ItemClasses
         cbItemClass.DisplayMember = "Name"
         cbItemClass.ValueMember = "Value"
         cbItemClass.SelectedValue = oi.ItemClassID
         cbItemClass.Left = 346
         cbItemClass.Top = ctrlTop
         cbItemClass.Width = 64
         cbItemClass.Height = 21
         ReDim Preserve arrItemClass(numOI)
         arrItemClass(numOI) = cbItemClass
         'Nr Ordered
         Dim tbNrOrdered As New TextBox
         tbNrOrdered.Left = 416
         tbNrOrdered.Top = ctrlTop
         tbNrOrdered.Width = 60
         tbNrOrdered.Height = 20
         tbNrOrdered.Text = oi.NrOrdered
         ReDim Preserve arrNumOrdered(numOI)
         arrNumOrdered(numOI) = tbNrOrdered
         'Nr Delivered
         Dim cbNrDelivered As New ComboBox
         Dim DeliveredItems As New ArrayList
         Dim locNrDelivered As Integer = oi.NrDelivered
         For i As Integer = locNrDelivered To oi.NrOrdered
            DeliveredItems.Add(New cbItem(i.ToString, i))
         Next
         cbNrDelivered.DataSource = DeliveredItems
         cbNrDelivered.DisplayMember = "Name"
         cbNrDelivered.ValueMember = "Value"
         cbNrDelivered.Left = 482
         cbNrDelivered.Top = ctrlTop
         cbNrDelivered.Width = 66
         cbNrDelivered.Height = 21
         cbNrDelivered.Tag = numOI
         AddHandler cbNrDelivered.SelectedValueChanged, AddressOf cbNrDelivered_SelectedIndexChanged
         ReDim Preserve arrNumDelivered(numOI)
         arrNumDelivered(numOI) = cbNrDelivered
         'Price
         Dim tbPrice As New TextBox
         tbPrice.Text = ""
         tbPrice.Left = 554
         tbPrice.Top = ctrlTop
         tbPrice.Width = 66
         tbPrice.Height = 20
         AddHandler tbPrice.TextChanged, AddressOf tbPrice_TextChanged
         ReDim Preserve arrPrice(numOI)
         arrPrice(numOI) = tbPrice
         numOI += 1
      Next
      Me.Controls.AddRange(arrDescription)
      Me.Controls.AddRange(arrItemClass)
      Me.Controls.AddRange(arrNumOrdered)
      Me.Controls.AddRange(arrNumDelivered)
      Me.Controls.AddRange(arrPrice)
      Me.Height = 183 + RowDist * numOI
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      Dim numOI As Integer = 0
      Dim numDelivered As Integer
      Dim locDescrItems As New List(Of DescrItem)
      Dim DB As OrderProcessDB = locOrderItems.DB
      Dim Identity As WindowsIdentity
      Identity = WindowsIdentity.GetCurrent
      'Dim Principal As New WindowsPrincipal(Identity)
      Dim totPrice As Double = 0
      For i As Integer = 0 To arrPrice.Length - 1
         If Not arrPrice(i).Text = "" Then
            totPrice = totPrice + CDbl(arrPrice(i).Text)
         End If
      Next
      numOI = 0
      For Each oi As OrderItem In locOrderItems.List
         Dim oiID As Integer = oi.ID
         Dim DescrItemQuery = From it In DB.Items Join ordit In DB.OrderItems On it.iOrderItemID Equals ordit.ID Where it.iOrderItemID = oiID Select New DescrItem(it, ordit.Description)
         'locDescrItems = DescrItemQuery.ToList
         If arrDescription(numOI).Text <> oi.Description Then
            oi.Description = arrDescription(numOI).Text
         End If
         If arrItemClass(numOI).SelectedValue <> oi.ItemClassID Then
            oi.ItemClassID = arrItemClass(numOI).SelectedValue
         End If
         If arrNumOrdered(numOI).Text <> oi.NrOrdered Then
            oi.NrOrdered = arrNumOrdered(numOI).Text
         End If
         numDelivered = arrNumDelivered(numOI).SelectedValue - oi.NrDelivered
         If numDelivered > 0 Then
            Dim itemPrice As Double = arrPrice(numOI).Text / numDelivered + (tbFreight.Text * arrPrice(numOI).Text) / (totPrice * numDelivered)
            For i As Integer = oi.NrDelivered To arrNumDelivered(numOI).SelectedValue - 1
               Dim newDescrItem As New DescrItem()
               newDescrItem.iOrderItemID = oi.ID
               newDescrItem.Description = oi.Description
               newDescrItem.Delivery = Now()
               newDescrItem.Deliverer = Identity.Name
               newDescrItem.Price = itemPrice
               locDescrItems.Add(newDescrItem)
            Next
         End If
         numOI += 1
      Next
      Dim frmNewItems As New frmItem(locDescrItems)
      If frmNewItems.ShowDialog = Windows.Forms.DialogResult.OK Then
         numOI = 0
         For Each oi As OrderItem In locOrderItems.List
            oi.NrDelivered = arrNumDelivered(numOI).SelectedValue
            numOI += 1
         Next
         Dim allItems As New Items(DB)
         Dim qryItems = From it In DB.Items Select it
         allItems.List = qryItems.ToList
         For Each dit As DescrItem In locDescrItems
            DB.Items.InsertOnSubmit(New Item(dit.ID, dit.iOrderItemID, dit.ItemID, dit.Delivery, dit.Price, dit.Deliverer, dit.Recipient, dit.AccountingUnitID, dit.Accounting))
         Next
         DB.SubmitChanges()
      End If
   End Sub

   Private Sub cbNrDelivered_SelectedIndexChanged(ByVal sender As ComboBox, ByVal e As EventArgs)
      If sender.SelectedValue <> locOrderItems.List(sender.Tag).NrDelivered Then
         Dim price As Nullable(Of Double) = Nothing
         Try
            price = CDbl(arrPrice(sender.Tag).Text)
         Catch ex As InvalidCastException
            'do nothing
         End Try
         If price Is Nothing Then
            btnOK.Enabled = False
         Else
            btnOK.Enabled = True
         End If
      End If
   End Sub
   Private Sub tbPrice_TextChanged(ByVal sender As TextBox, ByVal e As EventArgs)
      Dim price As Nullable(Of Double) = Nothing
      Try
         price = CDbl(sender.Text)
      Catch ex As InvalidCastException
         'do nothing
      End Try
      If Not (price Is Nothing) And (arrNumDelivered(sender.Tag).SelectedValue <> locOrderItems.List(sender.Tag).NrDelivered) Then
         btnOK.Enabled = True
      Else
         btnOK.Enabled = False
      End If
   End Sub
End Class