Public Class frmAccountingUnit
   Private locAccountingUnit As AccountingUnit
   Public Sub New(ByRef AccountingUnit As AccountingUnit)
      locAccountingUnit = AccountingUnit
      InitializeComponent()
   End Sub

   Private Sub frmAccountingUnit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbShortID.Text = locAccountingUnit.ShortID
      mtbCostCenter.Text = locAccountingUnit.CostCenter.ToString
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      locAccountingUnit.ShortID = tbShortID.Text
      locAccountingUnit.CostCenter = CInt(mtbCostCenter.Text)
      Me.Close()
   End Sub
End Class