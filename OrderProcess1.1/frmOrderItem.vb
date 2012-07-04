Public Class frmOrderItem
   Private locOrderItem As OrderItem
   Private lstItemClasses As List(Of ItemClass)
   Private lstOrderableItems As List(Of OrderableItem)
   Private lstNetOrderableItems As List(Of OrderableItem)
   Private lstSuppliers As List(Of Supplier)
   Private _dbAIMS As AIMSDataContext
   Private lstCategory As List(Of String)
   Private locNrDelivered As Integer
   Private locNrOrdered As Integer
   Private isLoading As Boolean = True

   Sub New(ByRef OrderItem As OrderItem, ByVal ItemClasses As List(Of ItemClass), ByVal OrderableItems As List(Of OrderableItem), ByVal Suppliers As List(Of Supplier), ByRef AIMS As AIMSDataContext)
      locOrderItem = OrderItem
      lstItemClasses = ItemClasses
      lstOrderableItems = OrderableItems
      lstSuppliers = Suppliers
      _dbAIMS = AIMS
      InitializeComponent()
   End Sub

   Private Sub frmOrderItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      isLoading = True
      If cbVisibleToUser.Checked Then
         Dim qryOrderableItems = From ordit As OrderableItem In lstOrderableItems Where (ordit.ItemActive) And (ordit.ItemVisibleToUser) And (ordit.EOL Is Nothing)
         lstNetOrderableItems = qryOrderableItems.ToList
      Else
         lstNetOrderableItems = lstOrderableItems
      End If
      Dim qryCategory = From ordit As OrderableItem In lstNetOrderableItems Select ordit.DeviceCategory Distinct Order By DeviceCategory
      lstCategory = qryCategory.ToList
      lstCategory.Insert(0, "<all>")
      cbCategory.DataSource = lstCategory
      cbClass.DataSource = lstItemClasses
      cbClass.DisplayMember = "ShortID"
      cbClass.ValueMember = "ID"
      cbDescription.DataSource = lstNetOrderableItems
      If cbVisibleToUser.Checked Then
         cbDescription.DisplayMember = "UserfriendlyName"
      Else
         cbDescription.DisplayMember = "ManufacturerModel"
      End If
      cbDescription.ValueMember = "ID"
      cbSuppliers.DataSource = lstSuppliers
      cbSuppliers.DisplayMember = "ShortID"
      cbSuppliers.ValueMember = "ID"
      If locOrderItem.NrOrdered Is Nothing Then
         locNrOrdered = 0
         mtbNrOrdered.Text = ""
      Else
         mtbNrOrdered.Text = locOrderItem.NrOrdered.ToString
         locNrOrdered = locOrderItem.NrOrdered
      End If
      If locOrderItem.FromDragging IsNot Nothing Then
         mtbNrOrdered.Enabled = Not locOrderItem.FromDragging
      Else
         mtbNrOrdered.Enabled = True
      End If
      If (locOrderItem.NrOrdered = 0) Then
         cbNrDelivered.Enabled = False
      End If
      Dim DeliveredItems As New ArrayList
      If locOrderItem.NrDelivered Is Nothing Then
         locNrDelivered = 0
      Else
         locNrDelivered = locOrderItem.NrDelivered
      End If
      If (locOrderItem.OrderableItemsID Is Nothing) Then
         cbDescription.Text = locOrderItem.Description
         cbClass.SelectedItem = locOrderItem.ItemClass
         cbSuppliers.SelectedItem = locOrderItem.Order.Supplier
      Else
         cbDescription.SelectedValue = locOrderItem.OrderableItemsID
         cbClass.SelectedValue = locOrderItem.ItemClassID
         cbSuppliers.SelectedItem = locOrderItem.OrderableItem.Supplier
         If locOrderItem.OrderableItem.SupplierPrice.HasValue Then
            tbPrice.Text = (locNrOrdered - locNrDelivered) * locOrderItem.OrderableItem.SupplierPrice
         End If
      End If
      tbPrice.Enabled = True
      tbFreight.Enabled = True
      If locNrOrdered >= locNrDelivered Then
         For i As Integer = locNrDelivered To locNrOrdered
            DeliveredItems.Add(New cbItem(i.ToString, i))
         Next
         cbNrDelivered.DataSource = DeliveredItems
         cbNrDelivered.DisplayMember = "Name"
         cbNrDelivered.ValueMember = "Value"
      End If
      If locOrderItem.CompletionDate Is Nothing Then
         tbCompletionDate.Text = ""
      Else
         tbCompletionDate.Text = locOrderItem.CompletionDate.Value.ToShortDateString
      End If
      isLoading = False
   End Sub

   Private Sub cbNrDelivered_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNrDelivered.SelectedIndexChanged
      If Not isLoading Then
         If locNrDelivered < CInt(cbNrDelivered.Text) Then
            If locOrderItem.OrderableItem.SupplierPrice.HasValue Then
               tbPrice.Text = (CInt(cbNrDelivered.Text) - locNrDelivered) * locOrderItem.OrderableItem.SupplierPrice
            End If
            tbPrice.Enabled = True
            tbFreight.Enabled = True
            If CInt(cbNrDelivered.Text) = locOrderItem.NrOrdered Then
               tbCompletionDate.Text = Now.ToShortDateString
            Else
               tbCompletionDate.Text = ""
            End If
         Else
            tbPrice.Enabled = False
            tbFreight.Enabled = False
         End If
      End If
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      Dim orditpred As New OrderableItemPredicate(CInt(cbDescription.SelectedValue))
      Dim ordit As OrderableItem = lstOrderableItems.Find(AddressOf orditpred.CompareIDs)
      locOrderItem.OrderableItem = ordit
      locOrderItem.Description = ordit.ManufacturerModel
      locOrderItem.ItemClass = cbClass.SelectedItem
      Dim NrOrdered As Integer = 0
      If Not Integer.TryParse(mtbNrOrdered.Text, NrOrdered) Then
         If MessageBox.Show("Please specify the number of ordered items", "Missing Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Cancel Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
         Else
            mtbNrOrdered.Select()
         End If
      Else
         locOrderItem.NrOrdered = NrOrdered
         If cbNrDelivered.Text = "" Then
            locOrderItem.NrDelivered = 0
         Else
            locOrderItem.NrDelivered = CInt(cbNrDelivered.Text)
         End If
         If tbCompletionDate.Text <> "" Then
            locOrderItem.CompletionDate = CDate(tbCompletionDate.Text)
         Else
            locOrderItem.CompletionDate = Nothing
         End If
         Dim dblPrice As Double = 0
         If tbPrice.Text <> "" Then
            If Not Double.TryParse(tbPrice.Text, dblPrice) Then
               If MessageBox.Show("Price can not be converted to a number." & vbCrLf & "Please enter a correct value", "Incorrect Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
                  Me.DialogResult = Windows.Forms.DialogResult.Cancel
                  Me.Close()
               End If
            End If
         End If
         Dim dblFreight As Double = 0
         If tbFreight.Text <> "" Then
            If Not Double.TryParse(tbFreight.Text, dblFreight) Then
               If MessageBox.Show("Freight can not be converted to a number." & vbCrLf & "Please enter a correct value", "Incorrect Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
                  Me.DialogResult = Windows.Forms.DialogResult.Cancel
                  Me.Close()
               End If
            End If
         End If
         Dim Identity As WindowsIdentity
         Identity = WindowsIdentity.GetCurrent
         Dim itemPrice As Double = (dblPrice + dblFreight) * 1.015 / (locOrderItem.NrDelivered - locNrDelivered)
         Dim lstItems As New List(Of Item)
         Dim netDelivered As Integer = locOrderItem.NrDelivered - locNrDelivered
         For i As Integer = locNrDelivered To locOrderItem.NrDelivered - 1
            Dim newItem As New Item()
            newItem.OrderItem = locOrderItem
            newItem.Delivery = Now
            newItem.Deliverer = Identity.Name
            newItem.Price = CDbl(Format(itemPrice, "######.00"))
            lstItems.Add(newItem)
         Next
         Dim retVal As DialogResult
         If netDelivered > 0 Then
            Dim frmNewItems As New frmItems(lstItems)
            retVal = frmNewItems.ShowDialog
            If retVal = Windows.Forms.DialogResult.OK Then
               For Each descrit As Item In lstItems
                  locOrderItem.Items.Add(descrit)
                  If (locOrderItem.OrderableItem.ItemClassID = 2) And (descrit.ItemID IsNot Nothing) Then
                     Dim urlAIMS As String = _dbAIMS.AddToAims(descrit, WindowsIdentity.GetCurrent.Name)
                     If urlAIMS IsNot Nothing Then
                        System.Diagnostics.Process.Start(urlAIMS)
                     End If
                  End If
               Next
            End If
         Else
            retVal = Windows.Forms.DialogResult.OK
         End If
         Me.DialogResult = retVal
      End If
   End Sub

   Private Sub cbDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDescription.SelectedIndexChanged
      If Not isLoading Then
         Dim ordit As OrderableItem = cbDescription.SelectedItem
         cbClass.SelectedItem = ordit.ItemClass
         cbSuppliers.SelectedItem = ordit.Supplier
         locOrderItem.OrderableItem = ordit
      End If
   End Sub

   Private Sub cbDescription_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDescription.Leave
      Dim ordcomparer As New OrderableItemPredicate(cbDescription.Text)
      Dim ordit As OrderableItem = lstOrderableItems.Find(AddressOf ordcomparer.CompareManufacturerModel)
      locOrderItem.OrderableItem = ordit
   End Sub

   Private Sub cbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCategory.SelectedIndexChanged
      If Not isLoading Then
         Dim lstCatOrdit As List(Of OrderableItem)
         If cbCategory.SelectedItem = "<all>" Then
            lstCatOrdit = lstNetOrderableItems
         Else
            Dim qryOrderableItems = From ordit As OrderableItem In lstNetOrderableItems Where ordit.DeviceCategory = cbCategory.SelectedItem Select ordit
            lstCatOrdit = qryOrderableItems.ToList
         End If
         cbDescription.DataSource = lstCatOrdit
         cbDescription.Refresh()
      End If
   End Sub

   Private Sub cbVisibleToUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVisibleToUser.CheckedChanged
      frmOrderItem_Load(Me, Nothing)
      cbCategory.Refresh()
      cbDescription.Refresh()
   End Sub

End Class
