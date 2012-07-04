Public Class frmDelivery
   Private locOrder As Order
   Private locItemClasses As List(Of ItemClass)
   Private locSuppliers As List(Of Supplier)
   Private _dbAIMS As AIMSDataContext
   Const RowDist As Integer = 25
   Dim arrDescription As TextBox()
   Dim arrItemClass As ComboBox()
   Dim arrNumOrdered As TextBox()
   Dim arrNumDelivered As ComboBox()
   Dim arrPrice As TextBox()

   Public Sub New(ByRef Order As Order, ByRef ItemClasses As List(Of ItemClass), ByRef Suppliers As List(Of Supplier), ByRef AIMS As AIMSDataContext)
      locOrder = Order
      locItemClasses = ItemClasses
      locSuppliers = Suppliers
      _dbAIMS = AIMS
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
      cbOrderer.Text = locOrder.Orderer.Name
      Dim Suppliers As New ArrayList
      For Each sup As Supplier In locSuppliers
         Suppliers.Add(New cbItem(sup.ShortID, sup.ID))
      Next
      cbSupplier.DataSource = Suppliers
      cbSupplier.DisplayMember = "Name"
      cbSupplier.ValueMember = "Value"
      cbSupplier.SelectedValue = locOrder.SupplierID
      Dim numOI As Integer = 0
      For Each oi As OrderItem In locOrder.OrderItems.ToList
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
         cbItemClass.DataSource = locItemClasses
         cbItemClass.DisplayMember = "ShortID"
         cbItemClass.ValueMember = "ID"
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
         If oi.FromDragging IsNot Nothing Then
            tbNrOrdered.Enabled = Not oi.FromDragging
         Else
            tbNrOrdered.Enabled = True
         End If
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
      Dim totDelivered As Integer = 0
      Dim lstItems As New List(Of Item)
      Dim Identity As WindowsIdentity
      Identity = WindowsIdentity.GetCurrent
      'Dim Principal As New WindowsPrincipal(Identity)
      Dim totPrice As Double = 0
      Dim Freight As Double = 0
      For i As Integer = 0 To arrPrice.Length - 1
         If Not arrPrice(i).Text = "" Then
            totPrice = totPrice + CDbl(arrPrice(i).Text)
         End If
      Next
      If tbFreight.Text <> "" Then
         If Not Double.TryParse(tbFreight.Text, Freight) Then
            Freight = 0
         End If
      End If
      numOI = 0
      For Each oi As OrderItem In locOrder.OrderItems.ToList
         Dim oiID As Integer = oi.ID
         If arrDescription(numOI).Text <> oi.Description Then
            oi.Description = arrDescription(numOI).Text
         End If
         If arrItemClass(numOI).SelectedValue <> oi.ItemClassID Then
            oi.ItemClass = arrItemClass(numOI).SelectedItem
         End If
         If arrNumOrdered(numOI).Text <> oi.NrOrdered Then
            oi.NrOrdered = arrNumOrdered(numOI).Text
         End If
         numDelivered = arrNumDelivered(numOI).SelectedValue - oi.NrDelivered
         totDelivered = totDelivered + numDelivered
         If numDelivered > 0 Then
            Dim itemPrice As Double = arrPrice(numOI).Text * 1.015 / numDelivered + (Freight * arrPrice(numOI).Text) / (totPrice * numDelivered)
            For i As Integer = oi.NrDelivered To arrNumDelivered(numOI).SelectedValue - 1
               Dim newItem As New Item
               newItem.OrderItem = oi
               newItem.Delivery = Now()
               newItem.Deliverer = Identity.Name
               newItem.Price = CDbl(Format(itemPrice, "######.00"))
               lstItems.Add(newItem)
            Next
         End If
         numOI += 1
      Next
      Dim retVal As DialogResult
      If totDelivered > 0 Then
         Dim frmNewItems As New frmItems(lstItems)
         retVal = frmNewItems.ShowDialog
         If retVal = Windows.Forms.DialogResult.OK Then
            numOI = 0
            For Each oi As OrderItem In locOrder.OrderItems
               oi.NrDelivered = arrNumDelivered(numOI).SelectedValue
               numOI += 1
               For Each descrit As Item In lstItems
                  If oi.ID = descrit.OrderItemID Then
                     oi.Items.Add(descrit)
                     If (oi.OrderableItem.ItemClassID = 2) And (descrit.ItemID IsNot Nothing) Then
                        Dim urlAims As String = _dbAIMS.AddToAims(descrit, WindowsIdentity.GetCurrent.Name)
                        If urlAims IsNot Nothing Then
                           System.Diagnostics.Process.Start(urlAims)
                        End If
                     End If
                  End If
               Next
            Next
         End If
      Else
         retVal = Windows.Forms.DialogResult.OK
      End If
      Me.DialogResult = retVal
   End Sub

   Private Sub cbNrDelivered_SelectedIndexChanged(ByVal sender As ComboBox, ByVal e As EventArgs)
      Dim actOrderItem As OrderItem = locOrder.OrderItems(sender.Tag)
      If sender.SelectedValue <> actOrderItem.NrDelivered Then
         Dim price As Nullable(Of Double) = Nothing
         If Not (actOrderItem.OrderableItem Is Nothing) AndAlso actOrderItem.OrderableItem.SupplierPrice.HasValue Then
            price = CDbl(Format((sender.SelectedValue - actOrderItem.NrDelivered) * actOrderItem.OrderableItem.SupplierPrice, "######.00"))
         Else
            Try
               price = CDbl(arrPrice(sender.Tag).Text)
            Catch ex As InvalidCastException
               'do nothing
            End Try
         End If
         If price Is Nothing Then
            btnOK.Enabled = False
         Else
            arrPrice(sender.Tag).Text = price.ToString
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
      If Not (price Is Nothing) And (arrNumDelivered(sender.Tag).SelectedValue <> locOrder.OrderItems(sender.Tag).NrDelivered) Then
         btnOK.Enabled = True
      Else
         btnOK.Enabled = False
      End If
   End Sub
End Class