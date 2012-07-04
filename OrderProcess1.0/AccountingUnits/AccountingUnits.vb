Public Class AccountingUnits
   Dim locItemList As List(Of AccountingUnit)
   Dim _dbOrderProcess As OrderProcessDB
   Dim locRootNode As TreeNode

   Public Sub New(ByRef DB As OrderProcessDB, ByVal RootNode As TreeNode)
      _dbOrderProcess = DB
      locRootNode = RootNode
      Dim AccountingUnitsQuery = From acu In _dbOrderProcess.AccountingUnits Order By acu.sShortID Select acu
      locItemList = AccountingUnitsQuery.ToList
   End Sub

   Public Property Rootnode() As TreeNode
      Get
         Return locRootNode
      End Get
      Set(ByVal value As TreeNode)
         locRootNode = value
      End Set
   End Property

   Public Property List() As List(Of AccountingUnit)
      Get
         Return locItemList
      End Get
      Set(ByVal value As List(Of AccountingUnit))
         locItemList = value
      End Set
   End Property

   Function GetIndex(ByVal ID As Integer) As Integer
      Dim index As Integer = 0
      For Each acu As AccountingUnit In locItemList
         If acu.ID = ID Then
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
      For Each acu As AccountingUnit In locItemList
         Dim nd As New TreeNode(acu.ShortID)
         nd.Tag = acu.ID
         RootNode.Nodes.Add(nd)
      Next
   End Sub
   Public Function NewAccountingUnit() As DialogResult
      Dim retVal As DialogResult
      Dim objNewAccountingUnit As New AccountingUnit
      Dim frmEditAccountingUnit As New frmAccountingUnit(objNewAccountingUnit)
      retVal = frmEditAccountingUnit.ShowDialog
      If retVal = Windows.Forms.DialogResult.OK Then
         _dbOrderProcess.AccountingUnits.InsertOnSubmit(objNewAccountingUnit)
         _dbOrderProcess.Submit()
         Dim AccountingUnitQuery = From acu In _dbOrderProcess.AccountingUnits Order By acu.sShortID Select acu
         locItemList = AccountingUnitQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
   Public Function EditAccountingUnit(ByRef AccountingUnit As AccountingUnit) As DialogResult
      Dim retVal As DialogResult
      Dim frmEditAccountingUnit As New frmAccountingUnit(AccountingUnit)
      frmEditAccountingUnit.Text = AccountingUnit.ShortID
      retVal = frmEditAccountingUnit.ShowDialog
      If retVal = DialogResult.OK Then
         _dbOrderProcess.Submit()
         Dim AccountingUnitQuery = From acu In _dbOrderProcess.AccountingUnits Order By acu.sShortID Select acu
         locItemList = AccountingUnitQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function
   Public Function RemoveAccountingUnit(ByRef AccountingUnit As AccountingUnit) As DialogResult
      Dim retVal As DialogResult
      retVal = MessageBox.Show("Delete AccountingUnit " & AccountingUnit.ShortID & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
      If retVal = Windows.Forms.DialogResult.OK Then
         _dbOrderProcess.AccountingUnits.DeleteOnSubmit(AccountingUnit)
         _dbOrderProcess.Submit()
         Dim AccountingUnitQuery = From acu In _dbOrderProcess.AccountingUnits Order By acu.sShortID Select acu
         locItemList = AccountingUnitQuery.ToList
         AddNodes()
      End If
      Return retVal
   End Function

End Class

<Table(Name:="dbo.tblAccountingUnits")> _
Public Class AccountingUnit
   <Column(IsPrimaryKey:=True, IsDBGenerated:=True)> Public ID As Integer
   <Column(Name:="sShortID")> Public sShortID As String
   <Column(Name:="iCostCenter")> Public iCostCenter As Int64

   Public Property ShortID() As String
      Get
         Return sShortID
      End Get
      Set(ByVal value As String)
         sShortID = value
      End Set
   End Property
   Public Property CostCenter() As Int64
      Get
         Return iCostCenter
      End Get
      Set(ByVal value As Int64)
         iCostCenter = value
      End Set
   End Property
End Class
