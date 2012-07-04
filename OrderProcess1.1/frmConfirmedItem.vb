Public Class frmConfirmedItem
   Private objConfirmedItem As ConfirmedItem
   Private lstOrderableItems As List(Of OrderableItem)
   Private lstNetOrderableItems As List(Of OrderableItem)
   Private lstOrderers As List(Of Orderer)
   Private lstAccountingUnits As List(Of AccountingUnit)
   Private lstCategory As List(Of String)
   Private MandatoryFields As Integer = 0
   Private isLoading As Boolean = True

   Public Sub New(ByRef ConfirmedItem As ConfirmedItem, ByVal OrderableItems As List(Of OrderableItem), ByVal AccountingUnits As List(Of AccountingUnit), ByVal Orderers As List(Of Orderer))
      objConfirmedItem = ConfirmedItem
      lstOrderableItems = OrderableItems
      lstAccountingUnits = AccountingUnits
      lstOrderers = Orderers
      InitializeComponent()
   End Sub

   Private Sub frmConfirmedItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      isLoading = True
      If cbVisibleToUser.Checked Then
         Dim qryOrderableItems = From ordit As OrderableItem In lstOrderableItems Where (ordit.ItemActive) And (ordit.ItemVisibleToUser) And (ordit.EOL Is Nothing)
         lstNetOrderableItems = qryOrderableItems.ToList
      Else
         lstNetOrderableItems = lstOrderableItems
      End If
      Dim qryCategory = From ordit As OrderableItem In lstNetOrderableItems Select ordit.DeviceCategory Distinct Order By DeviceCategory
      lstCategory = qryCategory.ToList
      lstCategory.Insert(0, "<all>")
      cbCategory.DataSource = lstCategory
      cbOrderableItems.DataSource = lstNetOrderableItems
      If cbVisibleToUser.Checked Then
         cbOrderableItems.DisplayMember = "UserfriendlyName"
      Else
         cbOrderableItems.DisplayMember = "ManufacturerModel"
      End If
      cbOrderableItems.ValueMember = "ID"
      cbOrderableItems.Refresh()
      cbAccountingUnits.DataSource = lstAccountingUnits
      cbAccountingUnits.DisplayMember = "ShortID"
      cbAccountingUnits.ValueMember = "ID"
      cbAccountingUnits.Refresh()
      cbOrderer.DataSource = lstOrderers
      cbOrderer.DisplayMember = "Name"
      cbOrderer.ValueMember = "ID"
      If Not (objConfirmedItem.OrderableItem Is Nothing) Then
         isLoading = False
         cbCategory.SelectedItem = objConfirmedItem.OrderableItem.DeviceCategory
         isLoading = True
         cbOrderableItems.SelectedItem = objConfirmedItem.OrderableItem
      End If
      isLoading = False
      If Not (objConfirmedItem.AccountingUnit Is Nothing) Then
         cbAccountingUnits.SelectedItem = objConfirmedItem.AccountingUnit
         tbITManager.Text = objConfirmedItem.AccountingUnit.ITManager
      End If
      Dim OrdererFound As Boolean = False
      If Not (objConfirmedItem.Orderer Is Nothing) Then
         For Each ord As Orderer In lstOrderers
            If ord.Name = objConfirmedItem.Orderer Then
               cbOrderer.SelectedItem = ord
               OrdererFound = True
               Exit For
            End If
         Next
         If Not OrdererFound Then
            Dim lstOrderers As New List(Of cbItem)
            lstOrderers.Add(New cbItem(objConfirmedItem.Orderer, 1))
            cbOrderer.DataSource = lstOrderers
         End If
      End If
      If Not (objConfirmedItem.QuantityOrdered = Nothing) Then
         mtbQuantityOrdered.Text = objConfirmedItem.QuantityOrdered.ToString
      End If
      If objConfirmedItem.RecipientName IsNot Nothing Then
         tbRecipient.Text = objConfirmedItem.RecipientName
      End If
      If objConfirmedItem.CostCenter IsNot Nothing Then
         tbCostCenter.Text = objConfirmedItem.CostCenter.Trim
      End If
      If objConfirmedItem.CostCenterResponsible IsNot Nothing Then
         tbCostCenterResponsible.Text = objConfirmedItem.CostCenterResponsible
      End If
      If objConfirmedItem.NotesURL IsNot Nothing Then
         tbNotesURL.Text = objConfirmedItem.NotesURL
      End If
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnApply.Click
      objConfirmedItem.OrderableItem = cbOrderableItems.SelectedItem
      objConfirmedItem.AccountingUnit = cbAccountingUnits.SelectedItem
      objConfirmedItem.QuantityOrdered = CInt(mtbQuantityOrdered.Text)
      objConfirmedItem.Orderer = cbOrderer.Text
      objConfirmedItem.RecipientName = tbRecipient.Text
      objConfirmedItem.CostCenterResponsible = tbCostCenterResponsible.Text
      objConfirmedItem.CostCenter = tbCostCenter.Text
      objConfirmedItem.ITManager = tbITManager.Text
      objConfirmedItem.NotesURL = tbNotesURL.Text
      objConfirmedItem.DateConfirmed = Now
   End Sub

   Private Sub cbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCategory.SelectedIndexChanged
      If Not isLoading Then
         Dim lstCatOrdit As List(Of OrderableItem)
         If cbCategory.SelectedItem = "<all>" Then
            lstCatOrdit = lstNetOrderableItems
         Else
            Dim qryOrderableItems = From ordit As OrderableItem In lstNetOrderableItems Where ordit.DeviceCategory = cbCategory.SelectedItem Select ordit
            lstCatOrdit = qryOrderableItems.ToList
         End If
         cbOrderableItems.DataSource = lstCatOrdit
         cbOrderableItems.Refresh()
      End If
   End Sub

   Private Sub cbOrderableItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOrderableItems.SelectedIndexChanged
      If Not isLoading Then
         MandatoryFields = MandatoryFields Or Mandatory.OrderableItem
         CheckOKButton()
      End If
   End Sub
   Private Sub mtbQuantityOrdered_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtbQuantityOrdered.TextChanged
      If Not isLoading Then
         MandatoryFields = MandatoryFields Or Mandatory.NrOrdered
         CheckOKButton()
      End If
   End Sub
   Private Sub cbOrderer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOrderer.SelectedIndexChanged
   End Sub
   Private Sub tbRecipient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbRecipient.TextChanged
      If Not isLoading Then
         MandatoryFields = MandatoryFields Or Mandatory.Recipient
         CheckOKButton()
      End If
   End Sub
   Private Sub cbAccountingUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAccountingUnits.SelectedIndexChanged
      If Not isLoading Then
         MandatoryFields = MandatoryFields Or Mandatory.AccountingUnit
         CheckOKButton()
         Dim aucomparer As New AccountingUnitPredicate(CInt(cbAccountingUnits.SelectedValue))
         Dim objAccountingUnit As AccountingUnit = lstAccountingUnits.Find(AddressOf aucomparer.CompareIDs)
         tbITManager.Text = objAccountingUnit.ITManager
      End If
   End Sub
   Private Sub tbNotesURL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNotesURL.TextChanged
      If Not isLoading Then
         MandatoryFields = MandatoryFields Or Mandatory.NotesURL
         CheckOKButton()
      End If
   End Sub
   Private Sub CheckOKButton()
      If MandatoryFields = 63 Then
         btnOK.Enabled = True
         btnApply.Enabled = True
      End If
   End Sub
   <Flags()> Private Enum Mandatory
      OrderableItem = 1
      NrOrdered = 2
      Recipient = 4
      AccountingUnit = 8
      NotesURL = 16
      CostCenter = 32
   End Enum

   Private Sub cbVisibleToUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVisibleToUser.CheckedChanged
      frmConfirmedItem_Load(Me, Nothing)
   End Sub

   Private Sub tbCostCenter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCostCenter.TextChanged
      If Not isLoading Then
         MandatoryFields = MandatoryFields Or Mandatory.CostCenter
         CheckOKButton()
      End If
   End Sub
End Class