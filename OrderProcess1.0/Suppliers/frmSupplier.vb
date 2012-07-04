Public Class frmSupplier
   Private locSupplier As Supplier
   Sub New(ByRef Supplier As Supplier)
      locSupplier = Supplier
      InitializeComponent()
   End Sub

   Private Sub frmSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbShortID.Text = locSupplier.ShortID
      tbDescription.Text = locSupplier.Description
      tbAddress.Text = locSupplier.Address
      tbMailAddress.Text = locSupplier.MailAddress
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      locSupplier.ShortID = tbShortID.Text
      locSupplier.Description = tbDescription.Text
      locSupplier.Address = tbAddress.Text
      locSupplier.MailAddress = tbMailAddress.Text
   End Sub
End Class