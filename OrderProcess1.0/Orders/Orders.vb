Public Class Orders
   Dim locOrderList As List(Of Order)
   Dim locDB As OrderProcessDB
   Dim locRootNode As TreeNode

   Public Sub New(ByVal DB As OrderProcessDB, ByRef RootNode As TreeNode)
      locDB = DB
      locRootNode = RootNode
      Dim OrderQuery = From ord In DB.Orders Order By ord.sNr Select ord
      locOrderList = OrderQuery.ToList
   End Sub

   Public Property Rootnode() As TreeNode
      Get
         Return locRootNode
      End Get
      Set(ByVal value As TreeNode)
         locRootNode = value
      End Set
   End Property

   Public Property List() As List(Of Order)
      Get
         Return locOrderList
      End Get
      Set(ByVal value As List(Of Order))
         locOrderList = value
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

   Function GetIndex(ByVal ID As Integer) As Integer
      Dim index As Integer = 0
      For Each ord As Order In locOrderList
         If ord.ID = ID Then
            Exit For
         End If
         index = index + 1
      Next
      Return index
   End Function
   Public Sub AddNodes()
      AddNodes(locRootNode)
   End Sub
   Public Sub AddNodes(ByRef RootNode As TreeNode)
      RootNode.Nodes.Clear()
      For Each ord As Order In locOrderList
         Dim nd As New TreeNode(ord.Nr)
         Dim ordit As New OrderItems(DB, ord)
         Dim sumOrdered As Integer = 0
         Dim sumDelivered As Integer = 0
         For Each oi As OrderItem In ordit.List
            sumOrdered += oi.NrOrdered
            sumDelivered += oi.NrDelivered
         Next
         If sumOrdered = 0 Then
            If ord.MailSent Then
               nd.ImageKey = "OrderMail"
            End If
         ElseIf sumDelivered = 0 Then
            If ord.MailSent Then
               nd.ImageKey = "OrderMail_red"
            Else
               nd.ImageKey = "Order_red"
            End If
         ElseIf sumDelivered = sumOrdered Then
            If ord.MailSent Then
               nd.ImageKey = "OrderMail_green"
            Else
               nd.ImageKey = "Order_green"
            End If
         Else
            If ord.MailSent Then
               nd.ImageKey = "OrderMail_yellow"
            Else
               nd.ImageKey = "Order_yellow"
            End If
         End If
         nd.SelectedImageKey = nd.ImageKey
         nd.Tag = ord.ID
         nd.Name = ord.Nr
         RootNode.Nodes.Add(nd)
      Next
   End Sub

   Public Function NewOrder(ByRef Suppliers As Suppliers) As DialogResult
      Dim retVal As DialogResult
      Dim objNewOrder As New Order
      Dim frmEditOrder As New frmOrder(objNewOrder, Suppliers)
      retVal = frmEditOrder.ShowDialog
      If retVal = Windows.Forms.DialogResult.OK Then
         locDB.Orders.InsertOnSubmit(objNewOrder)
         locDB.Submit()
         Dim OrderQuery = From ord In locDB.Orders Order By ord.sNr Select ord
         locOrderList = OrderQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
   Public Function EditOrder(ByRef Order As Order, ByRef Suppliers As Suppliers) As DialogResult
      Dim retVal As DialogResult
      Dim frmEditOrder As New frmOrder(Order, Suppliers)
      frmEditOrder.Text = "Order " & Order.Nr
      retVal = frmEditOrder.ShowDialog
      If retVal = Windows.Forms.DialogResult.OK Then
         locDB.Submit()
         Dim OrderQuery = From ord In locDB.Orders Order By ord.sNr Select ord
         locOrderList = OrderQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
   Public Function RemoveOrder(ByRef Order As Order) As DialogResult
      Dim retVal As DialogResult
      retVal = MessageBox.Show("Delete Order " & Order.Nr & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
      If RetVal = Windows.Forms.DialogResult.OK Then
         locDB.Orders.DeleteOnSubmit(Order)
         locDB.Submit()
         Dim OrderQuery = From ord In locDB.Orders Order By ord.sNr Select ord
         locOrderList = OrderQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
   Public Function NewDelivery(ByRef Order As Order, ByVal ItemClasses As ItemClasses, ByVal Suppliers As Suppliers) As DialogResult
      Dim retVal As DialogResult
      Dim objOrderItems As New OrderItems(locDB, Order)
      Dim frmNewDelivery As New frmDelivery(Order, objOrderItems, ItemClasses, Suppliers)
      frmNewDelivery.Text = "New Delivery for Order " & Order.Nr
      retVal = frmNewDelivery.ShowDialog
      If retVal = DialogResult.OK Then
         locDB.SubmitChanges()
      End If
   End Function
End Class

<Table(Name:="dbo.tblOrders")> _
Public Class Order
   <Column(IsPrimaryKey:=True, IsDBGenerated:=True)> Public ID As Integer
   <Column(Name:="sNr")> Public sNr As String
   <Column(Name:="dOrderDate")> Public dOrderDate As DateTime
   <Column(Name:="sOrderer")> Public sOrderer As String
   <Column(Name:="iSupplierID")> Public iSupplierID As Nullable(Of Integer)
   <Column(Name:="sRemarks")> Public sRemarks As String
   <Column(Name:="bEProc")> Public bEProc As Boolean
   <Column(Name:="sEProcOrderNr")> Public sEProcOrderNr As String
   <Column(Name:="bMailSent")> Public bMailSent As Boolean

   Public Property Nr() As String
      Get
         Return sNr
      End Get
      Set(ByVal value As String)
         sNr = value
      End Set
   End Property
   Public Property OrderDate() As DateTime
      Get
         Return dOrderDate
      End Get
      Set(ByVal value As DateTime)
         dOrderDate = value
      End Set
   End Property
   Public Property Orderer() As String
      Get
         Return sOrderer
      End Get
      Set(ByVal value As String)
         sOrderer = value
      End Set
   End Property
   Public Property SupplierID() As Nullable(Of Integer)
      Get
         Return iSupplierID
      End Get
      Set(ByVal value As Nullable(Of Integer))
         iSupplierID = value
      End Set
   End Property
   Public Property Remarks() As String
      Get
         Return sRemarks
      End Get
      Set(ByVal value As String)
         sRemarks = value
      End Set
   End Property
   Public Property EProc() As Boolean
      Get
         Return bEProc
      End Get
      Set(ByVal value As Boolean)
         bEProc = value
      End Set
   End Property
   Public Property EProcOrderNr() As String
      Get
         Return sEProcOrderNr
      End Get
      Set(ByVal value As String)
         sEProcOrderNr = value
      End Set
   End Property
   Public Property MailSent() As Boolean
      Get
         Return bMailSent
      End Get
      Set(ByVal value As Boolean)
         bMailSent = value
      End Set
   End Property

End Class

Public Class JoinOrder
   Private iID As Integer
   Private sNr As String
   Private dOrderDate As DateTime
   Private sOrderer As String
   Private sSupplier As String
   Private sRemarks As String
   Private bEProc As Boolean
   Private sEProcOrderNr As String
   Private bMailSent As Boolean
   Public Sub New(ByVal ID As Integer, ByVal Nr As String, ByVal OrderDate As String, ByVal Orderer As String, ByVal Supplier As String, ByVal Remarks As String, ByVal Eproc As Boolean, ByVal EprocOrderNr As String, ByVal MailSent As Boolean)
      iID = ID
      sNr = Nr
      dOrderDate = OrderDate
      sOrderer = Orderer
      sSupplier = Supplier
      sRemarks = Remarks
      bEProc = Eproc
      sEProcOrderNr = EprocOrderNr
      bMailSent = MailSent
   End Sub

   Public Property Nr() As String
      Get
         Return sNr
      End Get
      Set(ByVal value As String)
         sNr = value
      End Set
   End Property
   Public Property Orderdate() As String
      Get
         Return dOrderDate
      End Get
      Set(ByVal value As String)
         dOrderDate = value
      End Set
   End Property
   Public Property Supplier() As String
      Get
         Return sSupplier
      End Get
      Set(ByVal value As String)
         sSupplier = value
      End Set
   End Property
   Public Property Remarks() As String
      Get
         Return sRemarks
      End Get
      Set(ByVal value As String)
         sRemarks = value
      End Set
   End Property
   Public Property EProc() As Boolean
      Get
         Return bEProc
      End Get
      Set(ByVal value As Boolean)
         bEProc = value
      End Set
   End Property
   Public Property EProcOrderNr() As String
      Get
         Return sEProcOrderNr
      End Get
      Set(ByVal value As String)
         sEProcOrderNr = value
      End Set
   End Property
   Public Property MailSent() As Boolean
      Get
         Return bMailSent
      End Get
      Set(ByVal value As Boolean)
         bMailSent = value
      End Set
   End Property
End Class
