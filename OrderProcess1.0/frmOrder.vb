Public Class frmOrder
   Public locOrder As Order
   Sub New(ByVal Order As Order)
      locOrder = Order
      InitializeComponent()
   End Sub

   Private Sub frmOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbNr.Text = locOrder.Nr
      If Not (locOrder.OrderDate = Nothing) Then
         dtpOrderDate.Value = locOrder.OrderDate
      End If
      cbOrderer.Text = locOrder.Orderer
      cbSupplier.Text = locOrder.Supplier
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
      locOrder.Supplier = cbSupplier.Text
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