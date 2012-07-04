Public Class frmIDEntry
   Private lstEntries As List(Of MaxNummer)
   Private _RetVal As String

   Public Sub New(ByVal EntryList As List(Of MaxNummer))
      lstEntries = EntryList
      InitializeComponent()
   End Sub

   Private Sub frmIDEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      If lstEntries IsNot Nothing Then
         cbAvailableIDs.DataSource = lstEntries
         cbAvailableIDs.DisplayMember = "NeuNummer"
         cbAvailableIDs.ValueMember = "NeuNummer"
      End If
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      _RetVal = cbAvailableIDs.Text
   End Sub

   Public ReadOnly Property RetVal() As String
      Get
         Return _RetVal
      End Get
   End Property

   Private Sub cbAvailableIDs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAvailableIDs.SelectedIndexChanged
      If String.IsNullOrEmpty(cbAvailableIDs.Text) Then
         btnOK.Enabled = False
      Else
         btnOK.Enabled = True
      End If
   End Sub

   Private Sub cbAvailableIDs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAvailableIDs.TextChanged
      If String.IsNullOrEmpty(cbAvailableIDs.Text) Then
         btnOK.Enabled = False
      Else
         btnOK.Enabled = True
      End If
   End Sub
End Class