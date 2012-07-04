<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmedItem
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfirmedItem))
      Me.lblOrderableItem = New System.Windows.Forms.Label
      Me.cbOrderableItems = New System.Windows.Forms.ComboBox
      Me.lblNrOrdered = New System.Windows.Forms.Label
      Me.mtbQuantityOrdered = New System.Windows.Forms.MaskedTextBox
      Me.lblOrderer = New System.Windows.Forms.Label
      Me.tbRecipient = New System.Windows.Forms.TextBox
      Me.lblRecipient = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.tbCostCenterResponsible = New System.Windows.Forms.TextBox
      Me.tbITManager = New System.Windows.Forms.TextBox
      Me.lblITManager = New System.Windows.Forms.Label
      Me.cbAccountingUnits = New System.Windows.Forms.ComboBox
      Me.lblAccountingUnit = New System.Windows.Forms.Label
      Me.tbNotesURL = New System.Windows.Forms.TextBox
      Me.lblNotesURL = New System.Windows.Forms.Label
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.cbCategory = New System.Windows.Forms.ComboBox
      Me.lblCategory = New System.Windows.Forms.Label
      Me.cbVisibleToUser = New System.Windows.Forms.CheckBox
      Me.cbOrderer = New System.Windows.Forms.ComboBox
      Me.btnApply = New System.Windows.Forms.Button
      Me.tbCostCenter = New System.Windows.Forms.TextBox
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'lblOrderableItem
      '
      Me.lblOrderableItem.AutoSize = True
      Me.lblOrderableItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblOrderableItem.ForeColor = System.Drawing.Color.Black
      Me.lblOrderableItem.Location = New System.Drawing.Point(12, 42)
      Me.lblOrderableItem.Name = "lblOrderableItem"
      Me.lblOrderableItem.Size = New System.Drawing.Size(95, 13)
      Me.lblOrderableItem.TabIndex = 0
      Me.lblOrderableItem.Text = "ItemDescription"
      '
      'cbOrderableItems
      '
      Me.cbOrderableItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cbOrderableItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbOrderableItems.FormattingEnabled = True
      Me.cbOrderableItems.Location = New System.Drawing.Point(113, 39)
      Me.cbOrderableItems.Name = "cbOrderableItems"
      Me.cbOrderableItems.Size = New System.Drawing.Size(256, 21)
      Me.cbOrderableItems.TabIndex = 1
      '
      'lblNrOrdered
      '
      Me.lblNrOrdered.AutoSize = True
      Me.lblNrOrdered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblNrOrdered.ForeColor = System.Drawing.Color.Black
      Me.lblNrOrdered.Location = New System.Drawing.Point(12, 69)
      Me.lblNrOrdered.Name = "lblNrOrdered"
      Me.lblNrOrdered.Size = New System.Drawing.Size(69, 13)
      Me.lblNrOrdered.TabIndex = 2
      Me.lblNrOrdered.Text = "Nr Ordered"
      '
      'mtbQuantityOrdered
      '
      Me.mtbQuantityOrdered.Location = New System.Drawing.Point(113, 66)
      Me.mtbQuantityOrdered.Mask = "####"
      Me.mtbQuantityOrdered.Name = "mtbQuantityOrdered"
      Me.mtbQuantityOrdered.Size = New System.Drawing.Size(62, 20)
      Me.mtbQuantityOrdered.TabIndex = 3
      '
      'lblOrderer
      '
      Me.lblOrderer.AutoSize = True
      Me.lblOrderer.Location = New System.Drawing.Point(12, 95)
      Me.lblOrderer.Name = "lblOrderer"
      Me.lblOrderer.Size = New System.Drawing.Size(42, 13)
      Me.lblOrderer.TabIndex = 4
      Me.lblOrderer.Text = "Orderer"
      '
      'tbRecipient
      '
      Me.tbRecipient.Location = New System.Drawing.Point(113, 118)
      Me.tbRecipient.Name = "tbRecipient"
      Me.tbRecipient.Size = New System.Drawing.Size(156, 20)
      Me.tbRecipient.TabIndex = 6
      '
      'lblRecipient
      '
      Me.lblRecipient.AutoSize = True
      Me.lblRecipient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblRecipient.ForeColor = System.Drawing.Color.Black
      Me.lblRecipient.Location = New System.Drawing.Point(12, 121)
      Me.lblRecipient.Name = "lblRecipient"
      Me.lblRecipient.Size = New System.Drawing.Size(61, 13)
      Me.lblRecipient.TabIndex = 7
      Me.lblRecipient.Text = "Recipient"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 147)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(84, 13)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "CostCenterResp"
      '
      'tbCostCenterResponsible
      '
      Me.tbCostCenterResponsible.Location = New System.Drawing.Point(113, 144)
      Me.tbCostCenterResponsible.Name = "tbCostCenterResponsible"
      Me.tbCostCenterResponsible.Size = New System.Drawing.Size(156, 20)
      Me.tbCostCenterResponsible.TabIndex = 9
      '
      'tbITManager
      '
      Me.tbITManager.Location = New System.Drawing.Point(113, 196)
      Me.tbITManager.Name = "tbITManager"
      Me.tbITManager.Size = New System.Drawing.Size(156, 20)
      Me.tbITManager.TabIndex = 11
      '
      'lblITManager
      '
      Me.lblITManager.AutoSize = True
      Me.lblITManager.Location = New System.Drawing.Point(12, 199)
      Me.lblITManager.Name = "lblITManager"
      Me.lblITManager.Size = New System.Drawing.Size(59, 13)
      Me.lblITManager.TabIndex = 10
      Me.lblITManager.Text = "ITManager"
      '
      'cbAccountingUnits
      '
      Me.cbAccountingUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbAccountingUnits.FormattingEnabled = True
      Me.cbAccountingUnits.Location = New System.Drawing.Point(113, 222)
      Me.cbAccountingUnits.Name = "cbAccountingUnits"
      Me.cbAccountingUnits.Size = New System.Drawing.Size(62, 21)
      Me.cbAccountingUnits.TabIndex = 13
      '
      'lblAccountingUnit
      '
      Me.lblAccountingUnit.AutoSize = True
      Me.lblAccountingUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblAccountingUnit.ForeColor = System.Drawing.Color.Black
      Me.lblAccountingUnit.Location = New System.Drawing.Point(12, 225)
      Me.lblAccountingUnit.Name = "lblAccountingUnit"
      Me.lblAccountingUnit.Size = New System.Drawing.Size(94, 13)
      Me.lblAccountingUnit.TabIndex = 12
      Me.lblAccountingUnit.Text = "AccountingUnit"
      '
      'tbNotesURL
      '
      Me.tbNotesURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbNotesURL.Location = New System.Drawing.Point(113, 249)
      Me.tbNotesURL.Name = "tbNotesURL"
      Me.tbNotesURL.Size = New System.Drawing.Size(256, 20)
      Me.tbNotesURL.TabIndex = 15
      '
      'lblNotesURL
      '
      Me.lblNotesURL.AutoSize = True
      Me.lblNotesURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblNotesURL.ForeColor = System.Drawing.Color.Black
      Me.lblNotesURL.Location = New System.Drawing.Point(12, 252)
      Me.lblNotesURL.Name = "lblNotesURL"
      Me.lblNotesURL.Size = New System.Drawing.Size(65, 13)
      Me.lblNotesURL.TabIndex = 14
      Me.lblNotesURL.Text = "NotesURL"
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Enabled = False
      Me.btnOK.Location = New System.Drawing.Point(132, 288)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 16
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(294, 288)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 17
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'cbCategory
      '
      Me.cbCategory.FormattingEnabled = True
      Me.cbCategory.Location = New System.Drawing.Point(113, 12)
      Me.cbCategory.Name = "cbCategory"
      Me.cbCategory.Size = New System.Drawing.Size(121, 21)
      Me.cbCategory.TabIndex = 26
      '
      'lblCategory
      '
      Me.lblCategory.AutoSize = True
      Me.lblCategory.Location = New System.Drawing.Point(12, 15)
      Me.lblCategory.Name = "lblCategory"
      Me.lblCategory.Size = New System.Drawing.Size(49, 13)
      Me.lblCategory.TabIndex = 25
      Me.lblCategory.Text = "Category"
      '
      'cbVisibleToUser
      '
      Me.cbVisibleToUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cbVisibleToUser.AutoSize = True
      Me.cbVisibleToUser.Checked = True
      Me.cbVisibleToUser.CheckState = System.Windows.Forms.CheckState.Checked
      Me.cbVisibleToUser.Location = New System.Drawing.Point(256, 14)
      Me.cbVisibleToUser.Name = "cbVisibleToUser"
      Me.cbVisibleToUser.Size = New System.Drawing.Size(113, 17)
      Me.cbVisibleToUser.TabIndex = 27
      Me.cbVisibleToUser.Text = "VisibleToUser only"
      Me.cbVisibleToUser.UseVisualStyleBackColor = True
      '
      'cbOrderer
      '
      Me.cbOrderer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbOrderer.FormattingEnabled = True
      Me.cbOrderer.Location = New System.Drawing.Point(113, 91)
      Me.cbOrderer.Name = "cbOrderer"
      Me.cbOrderer.Size = New System.Drawing.Size(156, 21)
      Me.cbOrderer.TabIndex = 28
      '
      'btnApply
      '
      Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnApply.DialogResult = System.Windows.Forms.DialogResult.Retry
      Me.btnApply.Enabled = False
      Me.btnApply.Location = New System.Drawing.Point(213, 288)
      Me.btnApply.Name = "btnApply"
      Me.btnApply.Size = New System.Drawing.Size(75, 23)
      Me.btnApply.TabIndex = 29
      Me.btnApply.Text = "Apply"
      Me.btnApply.UseVisualStyleBackColor = True
      '
      'tbCostCenter
      '
      Me.tbCostCenter.Location = New System.Drawing.Point(113, 170)
      Me.tbCostCenter.Name = "tbCostCenter"
      Me.tbCostCenter.Size = New System.Drawing.Size(156, 20)
      Me.tbCostCenter.TabIndex = 30
      '
      'lblCostCenter
      '
      Me.lblCostCenter.AutoSize = True
      Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCostCenter.Location = New System.Drawing.Point(12, 173)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(69, 13)
      Me.lblCostCenter.TabIndex = 31
      Me.lblCostCenter.Text = "CostCenter"
      '
      'frmConfirmedItem
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(381, 323)
      Me.Controls.Add(Me.lblCostCenter)
      Me.Controls.Add(Me.tbCostCenter)
      Me.Controls.Add(Me.btnApply)
      Me.Controls.Add(Me.cbOrderer)
      Me.Controls.Add(Me.cbVisibleToUser)
      Me.Controls.Add(Me.cbCategory)
      Me.Controls.Add(Me.lblCategory)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.tbNotesURL)
      Me.Controls.Add(Me.lblNotesURL)
      Me.Controls.Add(Me.cbAccountingUnits)
      Me.Controls.Add(Me.lblAccountingUnit)
      Me.Controls.Add(Me.tbITManager)
      Me.Controls.Add(Me.lblITManager)
      Me.Controls.Add(Me.tbCostCenterResponsible)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblRecipient)
      Me.Controls.Add(Me.tbRecipient)
      Me.Controls.Add(Me.lblOrderer)
      Me.Controls.Add(Me.mtbQuantityOrdered)
      Me.Controls.Add(Me.lblNrOrdered)
      Me.Controls.Add(Me.cbOrderableItems)
      Me.Controls.Add(Me.lblOrderableItem)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmConfirmedItem"
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
      Me.Text = "frmConfirmedItem"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblOrderableItem As System.Windows.Forms.Label
   Friend WithEvents cbOrderableItems As System.Windows.Forms.ComboBox
   Friend WithEvents lblNrOrdered As System.Windows.Forms.Label
   Friend WithEvents mtbQuantityOrdered As System.Windows.Forms.MaskedTextBox
   Friend WithEvents lblOrderer As System.Windows.Forms.Label
   Friend WithEvents tbRecipient As System.Windows.Forms.TextBox
   Friend WithEvents lblRecipient As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbCostCenterResponsible As System.Windows.Forms.TextBox
   Friend WithEvents tbITManager As System.Windows.Forms.TextBox
   Friend WithEvents lblITManager As System.Windows.Forms.Label
   Friend WithEvents cbAccountingUnits As System.Windows.Forms.ComboBox
   Friend WithEvents lblAccountingUnit As System.Windows.Forms.Label
   Friend WithEvents tbNotesURL As System.Windows.Forms.TextBox
   Friend WithEvents lblNotesURL As System.Windows.Forms.Label
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
   Friend WithEvents lblCategory As System.Windows.Forms.Label
   Friend WithEvents cbVisibleToUser As System.Windows.Forms.CheckBox
   Friend WithEvents cbOrderer As System.Windows.Forms.ComboBox
   Friend WithEvents btnApply As System.Windows.Forms.Button
   Friend WithEvents tbCostCenter As System.Windows.Forms.TextBox
   Friend WithEvents lblCostCenter As System.Windows.Forms.Label
End Class
