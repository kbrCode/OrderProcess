Public Class frmOrder
   Private locOrder As Order
   Private lstOrderers As List(Of Orderer)
   Private lstSuppliers As List(Of Supplier)
   Sub New(ByRef Order As Order, ByVal Orderers As List(Of Orderer), ByVal Suppliers As List(Of Supplier))
      locOrder = Order
      lstOrderers = Orderers
      lstSuppliers = Suppliers
      InitializeComponent()
   End Sub

   Private Sub frmOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbNr.Text = locOrder.Nr
      If Not (locOrder.OrderDate Is Nothing) Then
         dtpOrderDate.Value = locOrder.OrderDate
      End If
      Dim Orderers As New ArrayList
      For Each ordr As Orderer In lstOrderers
         Orderers.Add(New cbItem(ordr.Name, ordr.ID))
      Next
      cbOrderer.DataSource = Orderers
      cbOrderer.DisplayMember = "Name"
      cbOrderer.ValueMember = "Value"
      If Not (locOrder.OrdererID = Nothing) Then
         cbOrderer.SelectedValue = locOrder.OrdererID
      End If
      Dim Suppliers As New ArrayList
      For Each sup As Supplier In lstSuppliers
         Suppliers.Add(New cbItem(sup.ShortID, sup.ID))
      Next
      cbSupplier.DataSource = Suppliers
      cbSupplier.DisplayMember = "Name"
      cbSupplier.ValueMember = "Value"
      If Not (locOrder.SupplierID Is Nothing) Then
         cbSupplier.SelectedValue = locOrder.SupplierID
      End If
      tbRemarks.Text = locOrder.Remarks
      cbEproc.Checked = locOrder.EProc
      If locOrder.EProc Then
         tbEprocOrderNr.Text = locOrder.EProcOrderNr
      End If
      tbEprocOrderNr.Enabled = locOrder.EProc
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      locOrder.Nr = tbNr.Text
      locOrder.OrderDate = dtpOrderDate.Value
      Dim objOrderer As Orderer = Nothing
      For Each ordr As Orderer In lstOrderers
         If cbOrderer.SelectedValue = ordr.ID Then
            objOrderer = ordr
            Exit For
         End If
      Next
      Dim objSupplier As Supplier = Nothing
      For Each sup As Supplier In lstSuppliers
         If cbSupplier.SelectedValue = sup.ID Then
            objSupplier = sup
            Exit For
         End If
      Next
      locOrder.Orderer = objOrderer
      locOrder.Supplier = objSupplier
      locOrder.Remarks = tbRemarks.Text
      locOrder.EProc = cbEproc.Checked
      If locOrder.EProc Then
         locOrder.EProcOrderNr = tbEprocOrderNr.Text
      End If
      Me.Close()
   End Sub

   Private Sub cbEproc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEproc.CheckedChanged
      tbEprocOrderNr.Enabled = cbEproc.Checked
   End Sub
End Class