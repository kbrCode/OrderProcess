<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderItem
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
      Me.lblItemDescription = New System.Windows.Forms.Label
      Me.lblItemClass = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.cbClass = New System.Windows.Forms.ComboBox
      Me.mtbNrOrdered = New System.Windows.Forms.MaskedTextBox
      Me.cbNrDelivered = New System.Windows.Forms.ComboBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.tbPrice = New System.Windows.Forms.TextBox
      Me.tbFreight = New System.Windows.Forms.TextBox
      Me.lblCompletionDate = New System.Windows.Forms.Label
      Me.tbCompletionDate = New System.Windows.Forms.TextBox
      Me.cbDescription = New System.Windows.Forms.ComboBox
      Me.lblSupplier = New System.Windows.Forms.Label
      Me.cbSuppliers = New System.Windows.Forms.ComboBox
      Me.Label5 = New System.Windows.Forms.Label
      Me.cbCategory = New System.Windows.Forms.ComboBox
      Me.cbVisibleToUser = New System.Windows.Forms.CheckBox
      Me.SuspendLayout()
      '
      'lblItemDescription
      '
      Me.lblItemDescription.AutoSize = True
      Me.lblItemDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblItemDescription.Location = New System.Drawing.Point(12, 42)
      Me.lblItemDescription.Name = "lblItemDescription"
      Me.lblItemDescription.Size = New System.Drawing.Size(95, 13)
      Me.lblItemDescription.TabIndex = 0
      Me.lblItemDescription.Text = "ItemDescription"
      '
      'lblItemClass
      '
      Me.lblItemClass.AutoSize = True
      Me.lblItemClass.Location = New System.Drawing.Point(12, 70)
      Me.lblItemClass.Name = "lblItemClass"
      Me.lblItemClass.Size = New System.Drawing.Size(52, 13)
      Me.lblItemClass.TabIndex = 1
      Me.lblItemClass.Text = "ItemClass"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.Location = New System.Drawing.Point(12, 97)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(69, 13)
      Me.Label3.TabIndex = 2
      Me.Label3.Text = "Nr Ordered"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(235, 97)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(66, 13)
      Me.Label4.TabIndex = 3
      Me.Label4.Text = "Nr Delivered"
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.Location = New System.Drawing.Point(272, 158)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 5
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(353, 158)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 6
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'cbClass
      '
      Me.cbClass.FormattingEnabled = True
      Me.cbClass.Location = New System.Drawing.Point(113, 67)
      Me.cbClass.Name = "cbClass"
      Me.cbClass.Size = New System.Drawing.Size(111, 21)
      Me.cbClass.TabIndex = 8
      '
      'mtbNrOrdered
      '
      Me.mtbNrOrdered.Location = New System.Drawing.Point(113, 94)
      Me.mtbNrOrdered.Name = "mtbNrOrdered"
      Me.mtbNrOrdered.Size = New System.Drawing.Size(111, 20)
      Me.mtbNrOrdered.TabIndex = 9
      '
      'cbNrDelivered
      '
      Me.cbNrDelivered.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cbNrDelivered.FormattingEnabled = True
      Me.cbNrDelivered.Location = New System.Drawing.Point(307, 93)
      Me.cbNrDelivered.Name = "cbNrDelivered"
      Me.cbNrDelivered.Size = New System.Drawing.Size(121, 21)
      Me.cbNrDelivered.TabIndex = 12
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 123)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(51, 13)
      Me.Label1.TabIndex = 13
      Me.Label1.Text = "Net Price"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(235, 123)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(39, 13)
      Me.Label2.TabIndex = 15
      Me.Label2.Text = "Freight"
      '
      'tbPrice
      '
      Me.tbPrice.Enabled = False
      Me.tbPrice.Location = New System.Drawing.Point(113, 120)
      Me.tbPrice.Name = "tbPrice"
      Me.tbPrice.Size = New System.Drawing.Size(111, 20)
      Me.tbPrice.TabIndex = 16
      '
      'tbFreight
      '
      Me.tbFreight.Enabled = False
      Me.tbFreight.Location = New System.Drawing.Point(307, 120)
      Me.tbFreight.Name = "tbFreight"
      Me.tbFreight.Size = New System.Drawing.Size(121, 20)
      Me.tbFreight.TabIndex = 17
      '
      'lblCompletionDate
      '
      Me.lblCompletionDate.AutoSize = True
      Me.lblCompletionDate.Location = New System.Drawing.Point(12, 149)
      Me.lblCompletionDate.Name = "lblCompletionDate"
      Me.lblCompletionDate.Size = New System.Drawing.Size(85, 13)
      Me.lblCompletionDate.TabIndex = 18
      Me.lblCompletionDate.Text = "Completion Date"
      '
      'tbCompletionDate
      '
      Me.tbCompletionDate.Enabled = False
      Me.tbCompletionDate.Location = New System.Drawing.Point(113, 146)
      Me.tbCompletionDate.Name = "tbCompletionDate"
      Me.tbCompletionDate.Size = New System.Drawing.Size(111, 20)
      Me.tbCompletionDate.TabIndex = 19
      '
      'cbDescription
      '
      Me.cbDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cbDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbDescription.FormattingEnabled = True
      Me.cbDescription.Location = New System.Drawing.Point(113, 39)
      Me.cbDescription.Name = "cbDescription"
      Me.cbDescription.Size = New System.Drawing.Size(315, 21)
      Me.cbDescription.TabIndex = 20
      '
      'lblSupplier
      '
      Me.lblSupplier.AutoSize = True
      Me.lblSupplier.Location = New System.Drawing.Point(235, 70)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(45, 13)
      Me.lblSupplier.TabIndex = 21
      Me.lblSupplier.Text = "Supplier"
      '
      'cbSuppliers
      '
      Me.cbSuppliers.FormattingEnabled = True
      Me.cbSuppliers.Location = New System.Drawing.Point(307, 67)
      Me.cbSuppliers.Name = "cbSuppliers"
      Me.cbSuppliers.Size = New System.Drawing.Size(121, 21)
      Me.cbSuppliers.TabIndex = 22
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(12, 15)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(49, 13)
      Me.Label5.TabIndex = 23
      Me.Label5.Text = "Category"
      '
      'cbCategory
      '
      Me.cbCategory.FormattingEnabled = True
      Me.cbCategory.Location = New System.Drawing.Point(113, 12)
      Me.cbCategory.Name = "cbCategory"
      Me.cbCategory.Size = New System.Drawing.Size(111, 21)
      Me.cbCategory.TabIndex = 24
      '
      'cbVisibleToUser
      '
      Me.cbVisibleToUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cbVisibleToUser.AutoSize = True
      Me.cbVisibleToUser.Checked = True
      Me.cbVisibleToUser.CheckState = System.Windows.Forms.CheckState.Checked
      Me.cbVisibleToUser.Location = New System.Drawing.Point(238, 14)
      Me.cbVisibleToUser.Name = "cbVisibleToUser"
      Me.cbVisibleToUser.Size = New System.Drawing.Size(113, 17)
      Me.cbVisibleToUser.TabIndex = 28
      Me.cbVisibleToUser.Text = "VisibleToUser only"
      Me.cbVisibleToUser.UseVisualStyleBackColor = True
      '
      'frmOrderItem
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(440, 193)
      Me.Controls.Add(Me.cbVisibleToUser)
      Me.Controls.Add(Me.cbCategory)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.cbSuppliers)
      Me.Controls.Add(Me.lblSupplier)
      Me.Controls.Add(Me.cbDescription)
      Me.Controls.Add(Me.tbCompletionDate)
      Me.Controls.Add(Me.lblCompletionDate)
      Me.Controls.Add(Me.tbFreight)
      Me.Controls.Add(Me.tbPrice)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cbNrDelivered)
      Me.Controls.Add(Me.mtbNrOrdered)
      Me.Controls.Add(Me.cbClass)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.lblItemClass)
      Me.Controls.Add(Me.lblItemDescription)
      Me.Name = "frmOrderItem"
      Me.Text = "Order List"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblItemDescription As System.Windows.Forms.Label
   Friend WithEvents lblItemClass As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents cbClass As System.Windows.Forms.ComboBox
   Friend WithEvents mtbNrOrdered As System.Windows.Forms.MaskedTextBox
   Friend WithEvents cbNrDelivered As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbPrice As System.Windows.Forms.TextBox
   Friend WithEvents tbFreight As System.Windows.Forms.TextBox
   Friend WithEvents lblCompletionDate As System.Windows.Forms.Label
   Friend WithEvents tbCompletionDate As System.Windows.Forms.TextBox
   Friend WithEvents cbDescription As System.Windows.Forms.ComboBox
   Friend WithEvents lblSupplier As System.Windows.Forms.Label
   Friend WithEvents cbSuppliers As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
   Friend WithEvents cbVisibleToUser As System.Windows.Forms.CheckBox
End Class
