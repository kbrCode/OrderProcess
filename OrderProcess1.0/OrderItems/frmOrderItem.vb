Public Class frmOrderItem
   Private locOrderItem As OrderItem
   Private locItemClasses As ItemClasses
   Private locOrderableItems As OrderableItems
   Private locNrDelivered As Integer
   Private isLoading As Boolean = True

   Sub New(ByVal ItemClasses As ItemClasses, ByRef OrderItem As OrderItem, ByVal OrderableItems As OrderableItems)
      locItemClasses = ItemClasses
      locOrderItem = OrderItem
      locOrderableItems = OrderableItems
      InitializeComponent()
   End Sub

   Private Sub frmOrderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      isLoading = True
      Dim arrOrderableItems As New ArrayList
      For Each ordit As OrderableItem In locOrderableItems.list
         arrOrderableItems.Add(New cbItem(ordit.ManufacturerModel, ordit.ID))
      Next
      Dim ItemClasses As New ArrayList
      For Each ic As ItemClass In locItemClasses.List
         ItemClasses.Add(New cbItem(ic.ShortID, ic.ID))
      Next
      cbClass.DataSource = ItemClasses
      cbClass.DisplayMember = "Name"
      cbClass.ValueMember = "Value"
      cbClass.SelectedValue = locOrderItem.ItemClassID
      cbDescription.DataSource = arrOrderableItems
      cbDescription.DisplayMember = "Name"
      cbDescription.ValueMember = "Value"
      If (locOrderItem.OrderableItemsID Is Nothing) Then
         cbDescription.Text = locOrderItem.Description
      Else
         cbDescription.SelectedValue = locOrderItem.OrderableItemsID
      End If
      mtbNrOrdered.Text = locOrderItem.NrOrdered
      If (locOrderItem.NrOrdered = 0) Then
         cbNrDelivered.Enabled = False
      End If
      Dim DeliveredItems As New ArrayList
      locNrDelivered = locOrderItem.NrDelivered
      For i As Integer = locNrDelivered To locOrderItem.NrOrdered
         DeliveredItems.Add(New cbItem(i.ToString, i))
      Next
      cbNrDelivered.DataSource = DeliveredItems
      cbNrDelivered.DisplayMember = "Name"
      cbNrDelivered.ValueMember = "Value"
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
      locOrderItem.Description = cbDescription.Text
      Dim SelItem As cbItem = cbClass.SelectedItem
      locOrderItem.ItemClassID = SelItem.Value
      locOrderItem.NrOrdered = mtbNrOrdered.Text
      locOrderItem.NrDelivered = CInt(cbNrDelivered.Text)
      If tbCompletionDate.Text <> "" Then
         locOrderItem.CompletionDate = CDate(tbCompletionDate.Text)
      Else
         locOrderItem.dCompletionDate = Nothing
      End If
      If locNrDelivered < CInt(cbNrDelivered.Text) Then

      End If
      Me.Close()
   End Sub

   Private Sub cbDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDescription.SelectedIndexChanged
      If Not isLoading Then
         locOrderItem.OrderableItemsID = cbDescription.SelectedIndex
      End If
   End Sub

   Private Sub cbDescription_TextUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDescription.TextUpdate
      If Not isLoading Then
         Dim selectedIndex As Nullable(Of Integer) = Nothing
         For Each ordit As OrderableItem In locOrderableItems.List
            If ordit.sManufacturerModel = cbDescription.Text Then
               selectedIndex = ordit.ID
               Exit For
            End If
         Next
         locOrderItem.OrderableItemsID = selectedIndex
      End If
   End Sub
End Class

Public Class cbItem
   Public locName As String
   Public locValue As Integer
   Public Sub New(ByVal Name As String, ByVal Value As Integer)
      locName = Name
      locValue = Value
   End Sub
   Public Property Name() As String
      Get
         Return locName
      End Get
      Set(ByVal value As String)
         locName = value
      End Set
   End Property
   Public Property Value() As Integer
      Get
         Return locValue
      End Get
      Set(ByVal value As Integer)
         locValue = value
      End Set
   End Property
   Public Overrides Function ToString() As String
      Return Name
   End Function
End Class