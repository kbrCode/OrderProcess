Public Class frmOrder
   Private locOrder As Order
   Private locSuppliers As Suppliers
   Sub New(ByRef Order As Order, ByVal Suppliers As Suppliers)
      locOrder = Order
      locSuppliers = Suppliers
      InitializeComponent()
   End Sub

   Private Sub frmOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbNr.Text = locOrder.Nr
      If Not (locOrder.OrderDate = Nothing) Then
         dtpOrderDate.Value = locOrder.OrderDate
      End If
      cbOrderer.Text = locOrder.Orderer
      Dim Suppliers As New ArrayList
      For Each sup As Supplier In locSuppliers.List
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
      locOrder.Orderer = cbOrderer.Text
      locOrder.SupplierID = cbSupplier.SelectedValue
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