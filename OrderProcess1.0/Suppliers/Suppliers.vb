Public Class Suppliers
   Dim locSuppliersList As List(Of Supplier)
   Dim locdb As OrderProcessDB
   Dim locRootNode As TreeNode

   Public Sub New(ByVal DB As OrderProcessDB, ByRef RootNode As TreeNode)
      locDB = DB
      locRootNode = RootNode
      Dim SupplierQuery = From sup In DB.Suppliers Order By sup.sShortID Select sup
      locSuppliersList = SupplierQuery.ToList
   End Sub

   Public Property Rootnode() As TreeNode
      Get
         Return locRootNode
      End Get
      Set(ByVal value As TreeNode)
         locRootNode = value
      End Set
   End Property

   Public Property List() As List(Of Supplier)
      Get
         Return locSuppliersList
      End Get
      Set(ByVal value As List(Of Supplier))
         locSuppliersList = value
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
      For Each sup As Supplier In locSuppliersList
         If sup.ID = ID Then
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
      For Each sup As Supplier In locSuppliersList
         Dim nd As New TreeNode(sup.ShortID)
         nd.Tag = sup.ID
         nd.Name = sup.ShortID
         RootNode.Nodes.Add(nd)
      Next
   End Sub

   Public Function NewSupplier() As DialogResult
      Dim retVal As DialogResult
      Dim objNewSupplier As New Supplier
      Dim frmEditSupplier As New frmSupplier(objNewSupplier)
      retVal = frmEditSupplier.ShowDialog
      If retVal = Windows.Forms.DialogResult.OK Then
         locdb.Suppliers.InsertOnSubmit(objNewSupplier)
         locdb.Submit()
         Dim SupplierQuery = From sup In locdb.Suppliers Order By sup.sShortID Select sup
         locSuppliersList = SupplierQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
   Public Function EditSupplier(ByRef Supplier As Supplier) As DialogResult
      Dim retVal As DialogResult
      Dim frmEditSupplier As New frmSupplier(Supplier)
      frmEditSupplier.Text = "Supplier " & Supplier.ShortID
      retVal = frmEditSupplier.ShowDialog
      If retVal = Windows.Forms.DialogResult.OK Then
         locdb.Submit()
         Dim SupplierQuery = From sup In locdb.Suppliers Order By sup.sShortID Select sup
         locSuppliersList = SupplierQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
   Public Function RemoveSupplier(ByRef Supplier As Supplier) As DialogResult
      Dim retVal As DialogResult
      retVal = MessageBox.Show("Delete Supplier " & Supplier.ShortID & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
      If retVal = Windows.Forms.DialogResult.OK Then
         locdb.Suppliers.DeleteOnSubmit(Supplier)
         locdb.Submit()
         Dim SupplierQuery = From sup In locdb.Suppliers Order By sup.sShortID Select sup
         locSuppliersList = SupplierQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
End Class

<Table(Name:="dbo.tblSuppliers")> _
Public Class Supplier
   <Column(IsPrimaryKey:=True, IsDBGenerated:=True)> Public ID As Integer
   <Column(Name:="sShortID")> Public sShortID As String
   <Column(Name:="sDescription")> Public sDescription As String
   <Column(Name:="sAddress")> Public sAddress As String
   <Column(Name:="sMailAddress")> Public sMailAddress As String

   Public Property ShortID() As String
      Get
         Return sShortID
      End Get
      Set(ByVal value As String)
         sShortID = value
      End Set
   End Property
   Public Property Description() As String
      Get
         Return sDescription
      End Get
      Set(ByVal value As String)
         sDescription = value
      End Set
   End Property
   Public Property Address() As String
      Get
         Return sAddress
      End Get
      Set(ByVal value As String)
         sAddress = value
      End Set
   End Property
   Public Property MailAddress() As String
      Get
         Return sMailAddress
      End Get
      Set(ByVal value As String)
         sMailAddress = value
      End Set
   End Property
End Class
