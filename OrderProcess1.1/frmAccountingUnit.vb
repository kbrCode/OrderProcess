Public Class frmAccountingUnit
   Private locAccountingUnit As AccountingUnit
   Private lstAccountingUnits As List(Of AccountingUnit)
   Private isNew As Boolean
   Public Sub New(ByRef AccountingUnit As AccountingUnit, ByVal AccountingUnits As List(Of AccountingUnit))
      If AccountingUnit Is Nothing Then
         isNew = True
      Else
         isNew = False
      End If
      locAccountingUnit = AccountingUnit
      lstAccountingUnits = AccountingUnits
      InitializeComponent()
   End Sub

   Private Sub frmAccountingUnit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbShortID.Text = locAccountingUnit.ShortID
      If locAccountingUnit.CostCenter.HasValue Then
         mtbCostCenter.Text = locAccountingUnit.CostCenter.ToString
      Else
         mtbCostCenter.Text = ""
      End If
      If String.IsNullOrEmpty(locAccountingUnit.ITManager) Then
         tbITManager.Text = ""
      Else
         tbITManager.Text = locAccountingUnit.ITManager
      End If
      If String.IsNullOrEmpty(locAccountingUnit.Besitzer) Then
         tbBesitzer.Text = ""
      Else
         tbBesitzer.Text = locAccountingUnit.Besitzer
      End If
      tbShortID.Select()
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      Dim lngCostCenter As Long
      If tbShortID.Text = "" Then
         If MessageBox.Show("Please enter a value as ShortID", "Missing Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
         Else
            tbShortID.Select()
            Exit Sub
         End If
      ElseIf isNew Then
         For Each acu As AccountingUnit In lstAccountingUnits
            If acu.ShortID = tbShortID.Text Then
               If MessageBox.Show("This ShortID already exists. Please change its value.", "Duplicate Entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
                  Me.DialogResult = Windows.Forms.DialogResult.Cancel
                  Me.Close()
               Else
                  tbShortID.Text = ""
                  Exit Sub
               End If
            End If
         Next
      End If
      locAccountingUnit.ShortID = tbShortID.Text
      If Long.TryParse(mtbCostCenter.Text, lngCostCenter) Then
         locAccountingUnit.CostCenter = lngCostCenter
      Else
         locAccountingUnit.CostCenter = Nothing
      End If
      locAccountingUnit.ITManager = tbITManager.Text
      locAccountingUnit.Besitzer = tbBesitzer.Text
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub tbShortID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbShortID.TextChanged
      If tbShortID.Text <> "" Then
         btnOK.Enabled = True
      End If
   End Sub
End Class