Public Class ItemClasses
   Dim locItemList As List(Of ItemClass)
   Dim locDB As OrderProcessDB
   Dim locRootNode As TreeNode

   Public Sub New(ByVal DB As OrderProcessDB, ByVal RootNode As TreeNode)
      locDB = DB
      locRootNode = RootNode
      Dim ItemListQuery = From il In DB.ItemClasses Order By il.sShortID Select il
      locItemList = ItemListQuery.ToList
   End Sub

   Public Property Rootnode() As TreeNode
      Get
         Return locRootNode
      End Get
      Set(ByVal value As TreeNode)
         locRootNode = value
      End Set
   End Property

   Public Property List() As List(Of ItemClass)
      Get
         Return locItemList
      End Get
      Set(ByVal value As List(Of ItemClass))
         locItemList = value
      End Set
   End Property

   Function GetIndex(ByVal ID As Integer) As Integer
      Dim index As Integer = 0
      For Each ic As ItemClass In locItemList
         If ic.ID = ID Then
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
      For Each il As ItemClass In locItemList
         Dim nd As New TreeNode(il.ShortID)
         nd.Tag = il.ID
         If il.ShortID = "HW" Then
            nd.ImageKey = "HW"
         ElseIf il.ShortID = "SW" Then
            nd.ImageKey = "SW"
         ElseIf il.ShortID = "Non-IT" Then
            nd.ImageKey = "NonIT"
         End If
         nd.SelectedImageKey = nd.ImageKey
         RootNode.Nodes.Add(nd)
      Next
   End Sub
   Public Function NewItemClass() As DialogResult
      Dim retVal As DialogResult
      Dim objNewItemClass As New ItemClass
      Dim frmEditItemClass As New frmItemClass(objNewItemClass)
      retVal = frmEditItemClass.ShowDialog
      If retVal = Windows.Forms.DialogResult.OK Then
         locDB.ItemClasses.InsertOnSubmit(objNewItemClass)
         locDB.Submit()
         Dim ItemClassQuery = From ic In locDB.ItemClasses Order By ic.sShortID Select ic
         locItemList = ItemClassQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
   Public Function EditItemClass(ByRef ItemClass As ItemClass) As DialogResult
      Dim retVal As DialogResult
      Dim frmEditItemClass As New frmItemClass(ItemClass)
      frmEditItemClass.Text = ItemClass.ShortID
      retVal = frmEditItemClass.ShowDialog
      If retVal = DialogResult.OK Then
         locDB.Submit()
         Dim ItemClassQuery = From ic In locDB.ItemClasses Order By ic.sShortID Select ic
         locItemList = ItemClassQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
   Public Function RemoveItemClass(ByRef ItemClass As ItemClass) As DialogResult
      Dim retVal As DialogResult
      retVal = MessageBox.Show("Delete ItemClass " & ItemClass.ShortID & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
      If retVal = Windows.Forms.DialogResult.OK Then
         locDB.ItemClasses.DeleteOnSubmit(ItemClass)
         locDB.Submit()
         Dim ItemClassQuery = From ic In locDB.ItemClasses Order By ic.sShortID Select ic
         locItemList = ItemClassQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
End Class

<Table(Name:="dbo.tblItemClass")> _
Public Class ItemClass
   <Column(IsPrimaryKey:=True, IsDBGenerated:=True)> Public ID As Integer
   <Column(Name:="sShortID")> Public sShortID As String
   <Column(Name:="sDescription")> Public sDescription As String

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
End Class