Public Class ConfirmedItems
   Dim locConfirmedItemList As List(Of ConfirmedItem)
   Dim _dbOrderProcess As OrderProcessDB

   Public Sub New(ByRef DB As OrderProcessDB)
      _dbOrderProcess = DB
      Dim qryConfirmedItems = From confit As ConfirmedItem In DB.ConfirmedItems Select confit
      locConfirmedItemList = qryConfirmedItems.ToList
   End Sub

   Function GetIndex(ByVal ID As Integer) As Integer
      Dim index As Integer = 0
      For Each confit As ConfirmedItem In locConfirmedItemList
         If confit.ID = ID Then
            Exit For
         End If
         index = index + 1
      Next
      Return index
   End Function

   Public Property List() As List(Of ConfirmedItem)
      Get
         Return locConfirmedItemList
      End Get
      Set(ByVal value As List(Of ConfirmedItem))
         locConfirmedItemList = value
      End Set
   End Property
End Class

<Table(Name:="dbo.tblConfirmedItems")> _
Public Class ConfirmedItem
   <Column(IsPrimaryKey:=True, IsDBGenerated:=True)> Public ID As Integer
   <Column(Name:="iOrderableItemsID")> Public iOrderableItemsID As Integer
   <Column(Name:="iQuantityOrdered")> Public iQuantityOrdered As Integer
   <Column(Name:="sOrderer")> Public sOrderer As String
   <Column(Name:="sRecipientName")> Public sRecipientName As String
   <Column(Name:="sCostCenterResponsible")> Public sCostCenterResponsible As String
   <Column(Name:="sItManager")> Public sItManager As String
   <Column(Name:="iAccountingUnitID")> Public iAccountingUnitID As Integer
   <Column(Name:="dDateConfirmed")> Public dDateConfirmed As Nullable(Of DateTime)
   <Column(Name:="dDateOrdered")> Public dDateOrdered As Nullable(Of DateTime)
   <Column(Name:="iQuantityAssigned")> Public iQuanityAssigned As Nullable(Of Integer)
   <Column(Name:="dDateAssigned")> Public dDateAssigned As Nullable(Of DateTime)

   Public Property OrderableItemsID() As Integer
      Get
         Return iOrderableItemsID
      End Get
      Set(ByVal value As Integer)
         iOrderableItemsID = value
      End Set
   End Property
   Public Property QuantityOrdered() As Integer
      Get
         Return iQuantityOrdered
      End Get
      Set(ByVal value As Integer)
         iQuantityOrdered = value
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
   Public Property RecipientName() As String
      Get
         Return sRecipientName
      End Get
      Set(ByVal value As String)
         sRecipientName = value
      End Set
   End Property
   Public Property CostCenterResponsible() As String
      Get
         Return sCostCenterResponsible
      End Get
      Set(ByVal value As String)
         sCostCenterResponsible = value
      End Set
   End Property
   Public Property ITManager() As String
      Get
         Return sItManager
      End Get
      Set(ByVal value As String)
         sItManager = value
      End Set
   End Property
   Public Property AccountingUnitID() As Integer
      Get
         Return iAccountingUnitID
      End Get
      Set(ByVal value As Integer)
         iAccountingUnitID = value
      End Set
   End Property
   Public Property DateConfirmed() As Nullable(Of DateTime)
      Get
         Return dDateConfirmed
      End Get
      Set(ByVal value As Nullable(Of DateTime))
         dDateConfirmed = value
      End Set
   End Property
   Public Property DateOrdered() As Nullable(Of DateTime)
      Get
         Return dDateOrdered
      End Get
      Set(ByVal value As Nullable(Of DateTime))
         dDateOrdered = value
      End Set
   End Property
   Public Property QuantityAssigned() As Nullable(Of Integer)
      Get
         Return iQuanityAssigned
      End Get
      Set(ByVal value As Nullable(Of Integer))
         iQuanityAssigned = value
      End Set
   End Property
   Public Property DateAssigned() As Nullable(Of DateTime)
      Get
         Return dDateAssigned
      End Get
      Set(ByVal value As Nullable(Of DateTime))
         dDateAssigned = value
      End Set
   End Property
End Class

Public Class JoinConfirmedItem
   Private iID As Integer
   Private sOrderableItem As String
   Private iQuantityOrdered As Integer
   Private sOrderer As String
   Private sRecipientName As String
   Private sCostCenterResponsible As String
   Private sItManager As String
   Private sAccountingUnit As String
   Private dDateConfirmed As DateTime
   Private iOrderableItemID As Integer
   Private sItemClass As String
   Private iQuantityAssigned As Nullable(Of Integer)
   Private iAccountingUnitID As Integer

   Public Sub New(ByVal ID As Integer, ByVal OrderableItem As String, ByVal QuantityOrdered As Integer, ByVal Orderer As String, ByVal RecipientName As String, ByVal CostCenterResponsible As String, ByVal ITManager As String, ByVal AccountingUnit As String, ByVal DateConfirmed As DateTime, ByVal OrderableItemID As Integer, ByVal ItemClass As String, ByVal QuantityAssigned As Nullable(Of Integer), ByVal AccountingUnitID As Integer)
      iID = ID
      sOrderableItem = OrderableItem
      iQuantityOrdered = QuantityOrdered
      sOrderer = Orderer
      sRecipientName = RecipientName
      sCostCenterResponsible = CostCenterResponsible
      sItManager = ITManager
      sAccountingUnit = AccountingUnit
      dDateConfirmed = DateConfirmed
      iOrderableItemID = OrderableItemID
      sItemClass = ItemClass
      iQuantityAssigned = QuantityAssigned
      iAccountingUnitID = AccountingUnitID
   End Sub

   Public Property ID() As Integer
      Get
         Return iID
      End Get
      Set(ByVal value As Integer)
         iID = value
      End Set
   End Property

   Public Property OrderableItem() As String
      Get
         Return sOrderableItem
      End Get
      Set(ByVal value As String)
         sOrderableItem = value
      End Set
   End Property
   Public Property QuantityOrdered() As Integer
      Get
         Return iQuantityOrdered
      End Get
      Set(ByVal value As Integer)
         iQuantityOrdered = value
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
   Public Property RecipientName() As String
      Get
         Return sRecipientName
      End Get
      Set(ByVal value As String)
         sRecipientName = value
      End Set
   End Property
   Public Property CostCenterResponsible() As String
      Get
         Return sCostCenterResponsible
      End Get
      Set(ByVal value As String)
         sCostCenterResponsible = value
      End Set
   End Property
   Public Property ITManager() As String
      Get
         Return sItManager
      End Get
      Set(ByVal value As String)
         sItManager = value
      End Set
   End Property
   Public Property AccountingUnit() As String
      Get
         Return sAccountingUnit
      End Get
      Set(ByVal value As String)
         sAccountingUnit = value
      End Set
   End Property
   Public Property DateConfirmed() As DateTime
      Get
         Return dDateConfirmed
      End Get
      Set(ByVal value As DateTime)
         dDateConfirmed = value
      End Set
   End Property
   Public Property OrderableItemID() As Integer
      Get
         Return iOrderableItemID
      End Get
      Set(ByVal value As Integer)
         iOrderableItemID = value
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
   Public Property QuantityAssigned() As Nullable(Of Integer)
      Get
         Return iQuantityAssigned
      End Get
      Set(ByVal value As Nullable(Of Integer))
         iQuantityAssigned = value
      End Set
   End Property
   Public Property AccountingUnitID() As Integer
      Get
         Return iAccountingUnitID
      End Get
      Set(ByVal value As Integer)
         iAccountingUnitID = value
      End Set
   End Property
End Class

