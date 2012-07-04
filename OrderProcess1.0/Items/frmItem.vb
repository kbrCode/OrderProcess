Public Class frmItem
   Private locItemList As List(Of DescrItem)

   Sub New(ByVal ItemList As List(Of DescrItem))
      locItemList = ItemList
      InitializeComponent()
   End Sub

   Private Sub frmItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      dgvItems.DataSource = locItemList
   End Sub
End Class