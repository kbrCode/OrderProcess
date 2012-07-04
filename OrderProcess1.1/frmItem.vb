Public Class frmItem
   Private locItem As Item

   Public Sub New(ByRef Item As Item)
      locItem = Item
      InitializeComponent()
   End Sub

   Private Sub frmItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbItemID.Text = locItem.ItemID
      tbDescription.Text = locItem.OrderItem.Description
      tbItemID.Select()
   End Sub

   Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      locItem.ItemID = tbItemID.Text
   End Sub
End Class