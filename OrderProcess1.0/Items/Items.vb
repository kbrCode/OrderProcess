Public Class Items
   Dim locItemList As List(Of Item)
   Dim locDB As OrderProcessDB

   Public Sub New(ByVal DB As OrderProcessDB)
      locDB = DB
   End Sub

   Public Property List() As List(Of Item)
      Get
         Return locItemList
      End Get
      Set(ByVal value As List(Of Item))
         locItemList = value
      End Set
   End Property
   Public Function NewItem(ByVal ItemList As List(Of DescrItem)) As DialogResult
      Dim retVal As DialogResult
      Dim frmNewItem As New frmItem(ItemList)
      retVal = frmNewItem.ShowDialog
      If retVal = Windows.Forms.DialogResult.OK Then
         For Each it As Item In ItemList
            locDB.Items.InsertOnSubmit(it)
         Next
         locDB.Submit()
      End If
      Return retVal
   End Function

End Class

<Table(Name:="dbo.tblItems")> _
Public Class Item
   <Column(IsPrimaryKey:=True, IsDBGenerated:=True)> Public ID As Integer
   <Column(Name:="iOrderItemID")> Public iOrderItemID As Integer
   <Column(Name:="sItemID")> Public sItemID As String
   <Column(Name:="dDelivery")> Public dDelivery As DateTime
   <Column(Name:="cPrice")> Public cPrice As Double
   <Column(Name:="sDeliverer")> Public sDeliverer As String
   <Column(Name:="sRecipient")> Public sRecipient As String
   <Column(Name:="iAccountingUnitID")> Public iAccountingUnitID As Nullable(Of Integer)
   <Column(Name:="dAccounting")> Public dAccounting As Nullable(Of DateTime)

   Public Sub New(ByVal iID As Integer, ByVal OrderItemID As Integer, ByVal ItemID As String, ByVal Delivery As DateTime, ByVal Price As Double, ByVal Deliverer As String, ByVal Recipient As String, ByVal AccountingUnitID As Nullable(Of Integer), ByVal Accounting As Nullable(Of DateTime))
      ID = iID
      iOrderItemID = OrderItemID
      sItemID = ItemID
      dDelivery = Delivery
      cPrice = Price
      sDeliverer = Deliverer
      sRecipient = Recipient
      iAccountingUnitID = AccountingUnitID
      dAccounting = Accounting
   End Sub
   Public Sub New(ByVal Item As Item)
      Me.New(Item.ID, Item.iOrderItemID, Item.ItemID, Item.Delivery, Item.Price, Item.Deliverer, Item.Recipient, Item.AccountingUnitID, Item.Accounting)
   End Sub
   Public Sub New()
      'do nothing
   End Sub

   Public Property ItemID() As String
      Get
         Return sItemID
      End Get
      Set(ByVal value As String)
         sItemID = value
      End Set
   End Property
   Public Property Delivery() As DateTime
      Get
         Return dDelivery
      End Get
      Set(ByVal value As DateTime)
         dDelivery = value
      End Set
   End Property
   Public Property Price() As Double
      Get
         Return cPrice
      End Get
      Set(ByVal value As Double)
         cPrice = value
      End Set
   End Property
   Public Property Deliverer() As String
      Get
         Return sDeliverer
      End Get
      Set(ByVal value As String)
         sDeliverer = value
      End Set
   End Property
   Public Property Recipient() As String
      Get
         Return sRecipient
      End Get
      Set(ByVal value As String)
         sRecipient = value
      End Set
   End Property
   Public Property AccountingUnitID() As Nullable(Of Integer)
      Get
         Return iAccountingUnitID
      End Get
      Set(ByVal value As Nullable(Of Integer))
         iAccountingUnitID = value
      End Set
   End Property
   Public Property Accounting() As Nullable(Of DateTime)
      Get
         Return dAccounting
      End Get
      Set(ByVal value As Nullable(Of DateTime))
         dAccounting = value
      End Set
   End Property
End Class

Public Class DescrItem
   Inherits Item
   Private sDescription As String

   Public Sub New(ByVal Item As Item, ByVal Description As String)
      MyBase.New(Item)
      sDescription = Description
   End Sub
   Public Sub New()
      MyBase.New()
   End Sub

   Public Property Description() As String
      Get
         Return sDescription
      End Get
      Set(ByVal value As String)
         sDescription = value
      End Set
   End Property
End Class
