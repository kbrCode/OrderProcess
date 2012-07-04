Public Class frmItems
   Private lstDescrItems As List(Of Item)

   Sub New(ByVal DescrItems As List(Of Item))
      lstDescrItems = DescrItems
      InitializeComponent()
   End Sub

   Private Sub frmItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      dgvItems.DataSource = lstDescrItems
      frmMain.FixItemView(dgvItems)
   End Sub
End Class