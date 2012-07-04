<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDelivery
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
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.cbSupplier = New System.Windows.Forms.ComboBox
      Me.cbOrderer = New System.Windows.Forms.ComboBox
      Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker
      Me.tbNr = New System.Windows.Forms.TextBox
      Me.lblSupplier = New System.Windows.Forms.Label
      Me.lblOrderer = New System.Windows.Forms.Label
      Me.lblOrderDate = New System.Windows.Forms.Label
      Me.lblNr = New System.Windows.Forms.Label
      Me.tbFreight = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.lblItemClass = New System.Windows.Forms.Label
      Me.lblItemDescription = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Enabled = False
      Me.btnOK.Location = New System.Drawing.Point(465, 157)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 0
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(546, 157)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'cbSupplier
      '
      Me.cbSupplier.FormattingEnabled = True
      Me.cbSupplier.Location = New System.Drawing.Point(296, 39)
      Me.cbSupplier.Name = "cbSupplier"
      Me.cbSupplier.Size = New System.Drawing.Size(151, 21)
      Me.cbSupplier.TabIndex = 21
      '
      'cbOrderer
      '
      Me.cbOrderer.FormattingEnabled = True
      Me.cbOrderer.Location = New System.Drawing.Point(296, 12)
      Me.cbOrderer.Name = "cbOrderer"
      Me.cbOrderer.Size = New System.Drawing.Size(151, 21)
      Me.cbOrderer.TabIndex = 20
      '
      'dtpOrderDate
      '
      Me.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpOrderDate.Location = New System.Drawing.Point(92, 38)
      Me.dtpOrderDate.Name = "dtpOrderDate"
      Me.dtpOrderDate.Size = New System.Drawing.Size(97, 20)
      Me.dtpOrderDate.TabIndex = 19
      '
      'tbNr
      '
      Me.tbNr.Location = New System.Drawing.Point(92, 12)
      Me.tbNr.Name = "tbNr"
      Me.tbNr.ReadOnly = True
      Me.tbNr.Size = New System.Drawing.Size(97, 20)
      Me.tbNr.TabIndex = 18
      '
      'lblSupplier
      '
      Me.lblSupplier.AutoSize = True
      Me.lblSupplier.Location = New System.Drawing.Point(216, 42)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(45, 13)
      Me.lblSupplier.TabIndex = 17
      Me.lblSupplier.Text = "Supplier"
      '
      'lblOrderer
      '
      Me.lblOrderer.AutoSize = True
      Me.lblOrderer.Location = New System.Drawing.Point(216, 15)
      Me.lblOrderer.Name = "lblOrderer"
      Me.lblOrderer.Size = New System.Drawing.Size(42, 13)
      Me.lblOrderer.TabIndex = 16
      Me.lblOrderer.Text = "Orderer"
      '
      'lblOrderDate
      '
      Me.lblOrderDate.AutoSize = True
      Me.lblOrderDate.Location = New System.Drawing.Point(12, 42)
      Me.lblOrderDate.Name = "lblOrderDate"
      Me.lblOrderDate.Size = New System.Drawing.Size(56, 13)
      Me.lblOrderDate.TabIndex = 15
      Me.lblOrderDate.Text = "OrderDate"
      '
      'lblNr
      '
      Me.lblNr.AutoSize = True
      Me.lblNr.Location = New System.Drawing.Point(12, 15)
      Me.lblNr.Name = "lblNr"
      Me.lblNr.Size = New System.Drawing.Size(18, 13)
      Me.lblNr.TabIndex = 14
      Me.lblNr.Text = "Nr"
      '
      'tbFreight
      '
      Me.tbFreight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbFreight.Location = New System.Drawing.Point(92, 157)
      Me.tbFreight.Name = "tbFreight"
      Me.tbFreight.Size = New System.Drawing.Size(97, 20)
      Me.tbFreight.TabIndex = 33
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 162)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(39, 13)
      Me.Label2.TabIndex = 31
      Me.Label2.Text = "Freight"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(554, 88)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(51, 13)
      Me.Label1.TabIndex = 30
      Me.Label1.Text = "Net Price"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(479, 88)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(66, 13)
      Me.Label4.TabIndex = 25
      Me.Label4.Text = "Nr Delivered"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(413, 88)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(59, 13)
      Me.Label3.TabIndex = 24
      Me.Label3.Text = "Nr Ordered"
      '
      'lblItemClass
      '
      Me.lblItemClass.AutoSize = True
      Me.lblItemClass.Location = New System.Drawing.Point(343, 88)
      Me.lblItemClass.Name = "lblItemClass"
      Me.lblItemClass.Size = New System.Drawing.Size(52, 13)
      Me.lblItemClass.TabIndex = 23
      Me.lblItemClass.Text = "ItemClass"
      '
      'lblItemDescription
      '
      Me.lblItemDescription.AutoSize = True
      Me.lblItemDescription.Location = New System.Drawing.Point(12, 88)
      Me.lblItemDescription.Name = "lblItemDescription"
      Me.lblItemDescription.Size = New System.Drawing.Size(80, 13)
      Me.lblItemDescription.TabIndex = 22
      Me.lblItemDescription.Text = "ItemDescription"
      '
      'frmDelivery
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(633, 192)
      Me.Controls.Add(Me.tbFreight)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.lblItemClass)
      Me.Controls.Add(Me.lblItemDescription)
      Me.Controls.Add(Me.cbSupplier)
      Me.Controls.Add(Me.cbOrderer)
      Me.Controls.Add(Me.dtpOrderDate)
      Me.Controls.Add(Me.tbNr)
      Me.Controls.Add(Me.lblSupplier)
      Me.Controls.Add(Me.lblOrderer)
      Me.Controls.Add(Me.lblOrderDate)
      Me.Controls.Add(Me.lblNr)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Name = "frmDelivery"
      Me.Text = "Delivery Details"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents cbSupplier As System.Windows.Forms.ComboBox
   Friend WithEvents cbOrderer As System.Windows.Forms.ComboBox
   Friend WithEvents dtpOrderDate As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbNr As System.Windows.Forms.TextBox
   Friend WithEvents lblSupplier As System.Windows.Forms.Label
   Friend WithEvents lblOrderer As System.Windows.Forms.Label
   Friend WithEvents lblOrderDate As System.Windows.Forms.Label
   Friend WithEvents lblNr As System.Windows.Forms.Label
   Friend WithEvents tbFreight As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents lblItemClass As System.Windows.Forms.Label
   Friend WithEvents lblItemDescription As System.Windows.Forms.Label
End Class
