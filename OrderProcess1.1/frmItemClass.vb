Public Class frmItemClass
   Private locItemClass As ItemClass

   Public Sub New(ByRef ItemClass As ItemClass)
      locItemClass = ItemClass
      InitializeComponent()
   End Sub

   Private Sub frmItemClass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbShortID.Text = locItemClass.ShortID
      tbDescription.Text = locItemClass.Description
      tbShortID.Select()
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      locItemClass.ShortID = tbShortID.Text
      locItemClass.Description = tbDescription.Text
      Me.Close()
   End Sub
End Class