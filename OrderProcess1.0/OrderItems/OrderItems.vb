Public Class OrderItems
   Dim locOrderItemList As List(Of OrderItem)
   Dim locDB As OrderProcessDB
   Dim locRootNode As TreeNode

   Public Sub New(ByVal DB As OrderProcessDB, ByVal Order As Order)
      locDB = DB
      locRootNode = RootNode
      Dim OrderItemQuery = From ordit In DB.OrderItems Where ordit.iOrderID = Order.ID Select ordit
      locOrderItemList = OrderItemQuery.ToList
   End Sub

   Public Property Rootnode() As TreeNode
      Get
         Return locRootNode
      End Get
      Set(ByVal value As TreeNode)
         locRootNode = value
      End Set
   End Property

   Public Property List() As List(Of OrderItem)
      Get
         Return locOrderItemList
      End Get
      Set(ByVal value As List(Of OrderItem))
         locOrderItemList = value
      End Set
   End Property
   Public Property DB() As OrderProcessDB
      Get
         Return locDB
      End Get
      Set(ByVal value As OrderProcessDB)
         locDB = value
      End Set
   End Property

   Public Sub AddNodes()
      AddNodes(locRootNode)
   End Sub
   Public Sub AddNodes(ByRef RootNode As TreeNode)
      RootNode.Nodes.Clear()
      For Each ordit As OrderItem In locOrderItemList
         Dim nd As New TreeNode(ordit.Description)
         If ordit.ItemClassID = 2 Then
            If ordit.NrDelivered = 0 Then
               nd.ImageKey = "HW_red"
            ElseIf ordit.NrDelivered = ordit.NrOrdered Then
               nd.ImageKey = "HW_green"
            Else
               nd.ImageKey = "HW_yellow"
            End If
         ElseIf ordit.ItemClassID = 3 Then
            If ordit.NrDelivered = 0 Then
               nd.ImageKey = "SW_red"
            ElseIf ordit.NrDelivered = ordit.NrOrdered Then
               nd.ImageKey = "SW_green"
            Else
               nd.ImageKey = "SW_yellow"
            End If
         ElseIf ordit.ItemClassID = 4 Then
            If ordit.NrDelivered = 0 Then
               nd.ImageKey = "NonIT_red"
            ElseIf ordit.NrDelivered = ordit.NrOrdered Then
               nd.ImageKey = "NonIT_green"
            Else
               nd.ImageKey = "NonIT_yellow"
            End If
         End If
         nd.SelectedImageKey = nd.ImageKey
         nd.Tag = ordit.ID
         RootNode.Nodes.Add(nd)
      Next
   End Sub

   Public Function NewOrderItem(ByVal Order As Order, ByVal ItemClasses As ItemClasses, ByVal OrderableItems As OrderableItems) As DialogResult
      Dim retVal As DialogResult
      Dim objNewOrderItem As New OrderItem
      objNewOrderItem.CompletionDate = Nothing
      Dim frmEditOrderItem As New frmOrderItem(ItemClasses, objNewOrderItem, OrderableItems)
      frmEditOrderItem.Text = "Order Item " & Order.Nr
      retVal = frmEditOrderItem.ShowDialog
      If retVal = Windows.Forms.DialogResult.OK Then
         objNewOrderItem.iOrderID = Order.ID
         locDB.OrderItems.InsertOnSubmit(objNewOrderItem)
         locDB.Submit()
         Dim OrderItemQuery = From ordit In locDB.OrderItems Where ordit.iOrderID = Order.ID Select ordit
         locOrderItemList = OrderItemQuery.ToList
         'AddNodes()
      End If
      Return retVal
   End Function
   Public Function EditOrderItem(ByVal Order As Order, ByVal ItemClasses As ItemClasses, ByRef OrderItem As OrderItem, ByVal OrderableItems As OrderableItems) As DialogResult
      Dim retVal As DialogResult
      Dim frmEditOrderItem As New frmOrderItem(ItemClasses, OrderItem, OrderableItems)
      frmEditOrderItem.Text = "Order Item " & Order.Nr
      retVal = frmEditOrderItem.ShowDialog
      If retVal = Windows.Forms.DialogResult.OK Then
         locDB.Submit()
         Dim OrderItemQuery = From ordit In locDB.OrderItems Where ordit.iOrderID = Order.ID Select ordit
         locOrderItemList = OrderItemQuery.ToList
         'AddNodes()
      End If
      Return retVal
   End Function
   Public Function RemoveOrderItem(ByRef OrderItem As OrderItem) As DialogResult
      Dim retVal As DialogResult
      Dim OrderID As Integer = OrderItem.iOrderID
      retVal = MessageBox.Show("Delete Order Item " & OrderItem.Description & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
      If retVal = Windows.Forms.DialogResult.OK Then
         locDB.OrderItems.DeleteOnSubmit(OrderItem)
         locDB.Submit()
         Dim OrderItemQuery = From ordit In locDB.OrderItems Where ordit.iOrderID = OrderID Select ordit
         locOrderItemList = OrderItemQuery.ToList
         'AddNodes()
      End If
      Return retVal
   End Function
End Class

<Table(Name:="dbo.tblOrderItems")> _
Public Class OrderItem
   <Column(IsPrimaryKey:=True, IsDBGenerated:=True)> Public ID As Integer
   <Column(Name:="iOrderID")> Public iOrderID As Integer
   <Column(Name:="sDescription")> Public sDescription As String
   <Column(Name:="iItemClassID")> Public iItemClassID As Integer
   <Column(Name:="iNrOrdered")> Public iNrOrdered As Integer
   <Column(Name:="iNrDelivered")> Public iNrDelivered As Integer
   <Column(Name:="dCompletionDate")> Public dCompletionDate As Nullable(Of DateTime)
   <Column(Name:="iOrderableItemsID")> Public iOrderableItemsID As Nullable(Of Integer)

   Public Property Description() As String
      Get
         Return sDescription
      End Get
      Set(ByVal value As String)
         sDescription = value
      End Set
   End Property
   Public Property ItemClassID() As Integer
      Get
         Return iItemClassID.ToString
      End Get
      Set(ByVal value As Integer)
         iItemClassID = value
      End Set
   End Property
   Public Property NrOrdered() As Integer
      Get
         Return iNrOrdered
      End Get
      Set(ByVal value As Integer)
         iNrOrdered = value
      End Set
   End Property
   Public Property NrDelivered() As Integer
      Get
         Return iNrDelivered
      End Get
      Set(ByVal value As Integer)
         iNrDelivered = value
      End Set
   End Property
   Public Property CompletionDate() As Nullable(Of DateTime)
      Get
         Return dCompletionDate
      End Get
      Set(ByVal value As Nullable(Of DateTime))
         dCompletionDate = value
      End Set
   End Property
   Public Property OrderableItemsID() As Nullable(Of Integer)
      Get
         Return iOrderableItemsID
      End Get
      Set(ByVal value As Nullable(Of Integer))
         iOrderableItemsID = value
      End Set
   End Property
End Class

Public Class JoinOrderItem
   Private sDescription As String
   Private sItemClass As String
   Private iNrOrdered As Integer
   Private iNrDelivered As Integer

   Public Sub New(ByVal Description As String, ByVal ItemClass As String, ByVal NrOrdered As Integer, ByVal NrDelivered As Integer)
      sDescription = Description
      sItemClass = ItemClass
      iNrOrdered = NrOrdered
      iNrDelivered = NrDelivered
   End Sub

   Public Property Description() As String
      Get
         Return sDescription
      End Get
      Set(ByVal value As String)
         sDescription = value
      End Set
   End Property
   Public Property ItemClass() As String
      Get
         Return sItemClass
      End Get
      Set(ByVal value As String)
         sItemClass = value
      End Set
   End Property
   Public Property NrOrdered() As Integer
      Get
         Return iNrOrdered
      End Get
      Set(ByVal value As Integer)
         iNrOrdered = value
      End Set
   End Property
   Public Property NrDelivered() As Integer
      Get
         Return iNrDelivered
      End Get
      Set(ByVal value As Integer)
         iNrDelivered = value
      End Set
   End Property
End Class