Public Class OrderableItems
   Dim locOrderableItemList As List(Of OrderableItem)
   Dim locDB As OrderProcessDB

   Public Sub New(ByVal DB As OrderProcessDB)
      locDB = DB
      Dim qryOrderableItems = From ordableit As OrderableItem In DB.OrderableItems Select ordableit
      locOrderableItemList = qryOrderableItems.ToList
   End Sub

   Public Property List() As List(Of OrderableItem)
      Get
         Return locOrderableItemList
      End Get
      Set(ByVal value As List(Of OrderableItem))
         locOrderableItemList = value
      End Set
   End Property
End Class

<Table(Name:="dbo.tblOrderableItems")> _
Public Class OrderableItem
   <Column(IsPrimaryKey:=True, IsDBGenerated:=True)> Public ID As Integer
   <Column(Name:="iReplacedByID")> Public iReplacedByID As Nullable(Of Integer)
   <Column(Name:="sItemCategory")> Public sItemCategory As String
   <Column(Name:="sSupplier")> Public sSupplier As String
   <Column(Name:="sDeviceCategory")> Public sDeviceCategory As String
   <Column(Name:="sSupplierNo")> Public sSupplierNo As String
   <Column(Name:="cSupplierPrice", DbType:="Money")> Public cSupplierPrice As Nullable(Of Decimal)
   <Column(Name:="sManufacturer")> Public sManufacturer As String
   <Column(Name:="sManufacturerModel")> Public sManufacturerModel As String
   <Column(Name:="sManufacturerNo")> Public sManufacturerNo As String
   <Column(Name:="bItemVisibleToUser")> Public bItemVisibleToUser As Boolean
   <Column(Name:="sUserFriendlyName")> Public sUserFriendlyName As String
   <Column(Name:="cUserFriendlyPrice", DbType:="Money")> Public cUserFriendlyPrice As Nullable(Of Decimal)
   <Column(Name:="sItemAvailInOrg")> Public sItemAvailInOrg As String

   Public Property ReplacedByID() As Nullable(Of Integer)
      Get
         Return iReplacedByID
      End Get
      Set(ByVal value As Nullable(Of Integer))
         iReplacedByID = value
      End Set
   End Property
   Public Property ItemCategory() As String
      Get
         Return sItemCategory
      End Get
      Set(ByVal value As String)
         sItemCategory = value
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
   Public Property DeviceCategory() As String
      Get
         Return sDeviceCategory
      End Get
      Set(ByVal value As String)
         sDeviceCategory = value
      End Set
   End Property
   Public Property SupplierNo() As String
      Get
         Return sSupplierNo
      End Get
      Set(ByVal value As String)
         sSupplierNo = value
      End Set
   End Property
   Public Property SupplierPrice() As Nullable(Of Decimal)
      Get
         Return cSupplierPrice
      End Get
      Set(ByVal value As Nullable(Of Decimal))
         cSupplierPrice = value
      End Set
   End Property
   Public Property Manufacturer() As String
      Get
         Return sManufacturer
      End Get
      Set(ByVal value As String)
         sManufacturer = value
      End Set
   End Property
   Public Property ManufacturerModel() As String
      Get
         Return sManufacturerModel
      End Get
      Set(ByVal value As String)
         sManufacturerModel = value
      End Set
   End Property
   Public Property ManufacturerNo() As String
      Get
         Return sManufacturerNo
      End Get
      Set(ByVal value As String)
         sManufacturerNo = value
      End Set
   End Property
   Public Property ItemVisibleToUser() As Boolean
      Get
         Return bItemVisibleToUser
      End Get
      Set(ByVal value As Boolean)
         bItemVisibleToUser = value
      End Set
   End Property
   Public Property UserFriendlyName() As String
      Get
         Return sUserFriendlyName
      End Get
      Set(ByVal value As String)
         sUserFriendlyName = value
      End Set
   End Property
   Public Property UserFriendlyPrice() As Nullable(Of Decimal)
      Get
         Return cUserFriendlyPrice
      End Get
      Set(ByVal value As Nullable(Of Decimal))
         cUserFriendlyPrice = value
      End Set
   End Property
   Public Property ItemAvailInOrg() As String
      Get
         Return sItemAvailInOrg
      End Get
      Set(ByVal value As String)
         sItemAvailInOrg = value
      End Set
   End Property
End Class

