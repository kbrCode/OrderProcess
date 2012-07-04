Public Class frmConfirmedItems
   Private locConfirmedItems As List(Of JoinConfirmedItem)
   Private locItemType As ItemType
   Private locDB As OrderProcessDB

   Public Sub New(ByVal DB As OrderProcessDB, ByVal ItemList As List(Of JoinConfirmedItem), ByVal ItemType As ItemType)
      locDB = DB
      locConfirmedItems = ItemList
      locItemType = ItemType
      InitializeComponent()
   End Sub

   Public Sub RefreshList(ByVal ItemList As List(Of JoinConfirmedItem))
      locConfirmedItems = ItemList
      dgvMain.DataSource = ItemList
      dgvMain.Refresh()
      Me.Update()
   End Sub

   Private Sub frmConfirmedItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      dgvMain.DataSource = locConfirmedItems
      If locItemType = ItemType.OrderedItems Then
         dgvMain.AllowDrop = True
      End If
   End Sub

   Private Sub dgvMain_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvMain.MouseDown
      Dim info As DataGridView.HitTestInfo = dgvMain.HitTest(e.X, e.Y)
      If (info.RowIndex >= 0) And locItemType = ItemType.ConfirmedItems Then
         dgvMain.DoDragDrop(locConfirmedItems(info.RowIndex), DragDropEffects.Copy)
      End If
   End Sub

   Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
      Me.Close()
   End Sub

   Private Sub dgvMain_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvMain.DragDrop
      Dim dropPoint As New Drawing.Point(e.X, e.Y)
      Dim pt As Drawing.Point = dgvMain.PointToClient(dropPoint)
      Dim hitTstInfo As DataGridView.HitTestInfo = dgvMain.HitTest(pt.X, pt.Y)
      If hitTstInfo.RowIndex >= 0 Then
         Dim dgvr As DataGridViewRow = dgvMain.Rows(hitTstInfo.RowIndex)
         Dim objJoinConfirmedItem As JoinConfirmedItem = dgvr.DataBoundItem
         Dim lstDescrItems As List(Of DescrItem) = e.Data.GetData(GetType(List(Of DescrItem)))
         Dim QuantityMissing As Integer
         If objJoinConfirmedItem.QuantityAssigned.HasValue Then
            QuantityMissing = objJoinConfirmedItem.QuantityOrdered - objJoinConfirmedItem.QuantityAssigned
         Else
            QuantityMissing = objJoinConfirmedItem.QuantityOrdered
         End If
         If QuantityMissing < lstDescrItems.Count Then
            MessageBox.Show("Too many items. Please drag and drop no more than " & QuantityMissing & " items", "Too many items", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Else
            For Each dit As DescrItem In lstDescrItems
               Dim ditID As Integer = dit.ID
               Dim qryItem = From it As Item In locDB.Items Where it.ID = ditID Select it
               For Each it As Item In qryItem
                  it.Recipient = objJoinConfirmedItem.RecipientName
                  it.AccountingUnitID = objJoinConfirmedItem.AccountingUnitID
                  it.Accounting = Now()
                  locDB.SubmitChanges()
                  QuantityMissing = QuantityMissing - 1
               Next
            Next
            Dim ConfItID As Integer = objJoinConfirmedItem.ID
            Dim qryConfirmedItem = From confit As ConfirmedItem In locDB.ConfirmedItems Where confit.ID = ConfItID Select confit
            For Each confit As ConfirmedItem In qryConfirmedItem
               confit.QuantityAssigned = confit.QuantityOrdered - QuantityMissing
               If QuantityMissing = 0 Then
                  confit.DateAssigned = Now
               End If
               locDB.SubmitChanges()
            Next
         End If
      End If
   End Sub

   Private Sub dgvMain_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvMain.DragOver
      If e.Data.GetDataPresent(GetType(List(Of DescrItem))) Then
         e.Effect = DragDropEffects.Copy
      End If
   End Sub
End Class