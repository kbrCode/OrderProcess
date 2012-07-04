Public Class frmOrderer
   Private _Orderer As Orderer
   Private _Orderers As List(Of Orderer)
   Private isNew As Boolean

   Public Sub New(ByRef Orderer As Orderer, ByVal Orderers As List(Of Orderer))
      _Orderer = Orderer
      _Orderers = Orderers
      InitializeComponent()
      If _Orderer Is Nothing Then
         isNew = True
      Else
         isNew = False
      End If
   End Sub

   Private Sub frmOrderer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbName.Text = _Orderer.Name
      tbEMailAddress.Text = _Orderer.EMailAddress
      tbName.Select()
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      If tbName.Text = "" Then
         If MessageBox.Show("Please enter a value as Name", "Missing Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
         Else
            tbName.Select()
            Exit Sub
         End If
      ElseIf isNew Then
         For Each ordr As Orderer In _Orderers
            If ordr.Name = tbName.Text Then
               If MessageBox.Show("This Name already exists. Please change its value.", "Duplicate Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
                  Me.DialogResult = Windows.Forms.DialogResult.Cancel
                  Me.Close()
               Else
                  tbName.Text = ""
                  Exit Sub
               End If
            End If
         Next
      End If
      _Orderer.Name = tbName.Text
      _Orderer.EMailAddress = tbEMailAddress.Text
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub
End Class