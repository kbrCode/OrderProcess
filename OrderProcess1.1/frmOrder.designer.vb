<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrder
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrder))
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.lblNr = New System.Windows.Forms.Label
      Me.lblOrderDate = New System.Windows.Forms.Label
      Me.lblOrderer = New System.Windows.Forms.Label
      Me.lblSupplier = New System.Windows.Forms.Label
      Me.lblRemarks = New System.Windows.Forms.Label
      Me.lblEproc = New System.Windows.Forms.Label
      Me.lblEprocOrderNr = New System.Windows.Forms.Label
      Me.tbNr = New System.Windows.Forms.TextBox
      Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker
      Me.cbOrderer = New System.Windows.Forms.ComboBox
      Me.cbSupplier = New System.Windows.Forms.ComboBox
      Me.tbRemarks = New System.Windows.Forms.TextBox
      Me.cbEproc = New System.Windows.Forms.CheckBox
      Me.tbEprocOrderNr = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(202, 221)
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
      Me.btnCancel.Location = New System.Drawing.Point(283, 221)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'lblNr
      '
      Me.lblNr.AutoSize = True
      Me.lblNr.Location = New System.Drawing.Point(12, 15)
      Me.lblNr.Name = "lblNr"
      Me.lblNr.Size = New System.Drawing.Size(18, 13)
      Me.lblNr.TabIndex = 2
      Me.lblNr.Text = "Nr"
      '
      'lblOrderDate
      '
      Me.lblOrderDate.AutoSize = True
      Me.lblOrderDate.Location = New System.Drawing.Point(12, 41)
      Me.lblOrderDate.Name = "lblOrderDate"
      Me.lblOrderDate.Size = New System.Drawing.Size(56, 13)
      Me.lblOrderDate.TabIndex = 3
      Me.lblOrderDate.Text = "OrderDate"
      '
      'lblOrderer
      '
      Me.lblOrderer.AutoSize = True
      Me.lblOrderer.Location = New System.Drawing.Point(12, 70)
      Me.lblOrderer.Name = "lblOrderer"
      Me.lblOrderer.Size = New System.Drawing.Size(42, 13)
      Me.lblOrderer.TabIndex = 4
      Me.lblOrderer.Text = "Orderer"
      '
      'lblSupplier
      '
      Me.lblSupplier.AutoSize = True
      Me.lblSupplier.Location = New System.Drawing.Point(12, 97)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(45, 13)
      Me.lblSupplier.TabIndex = 5
      Me.lblSupplier.Text = "Supplier"
      '
      'lblRemarks
      '
      Me.lblRemarks.AutoSize = True
      Me.lblRemarks.Location = New System.Drawing.Point(12, 124)
      Me.lblRemarks.Name = "lblRemarks"
      Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
      Me.lblRemarks.TabIndex = 6
      Me.lblRemarks.Text = "Remarks"
      '
      'lblEproc
      '
      Me.lblEproc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblEproc.AutoSize = True
      Me.lblEproc.Location = New System.Drawing.Point(12, 184)
      Me.lblEproc.Name = "lblEproc"
      Me.lblEproc.Size = New System.Drawing.Size(74, 13)
      Me.lblEproc.TabIndex = 7
      Me.lblEproc.Text = "EProcurement"
      '
      'lblEprocOrderNr
      '
      Me.lblEprocOrderNr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblEprocOrderNr.AutoSize = True
      Me.lblEprocOrderNr.Location = New System.Drawing.Point(113, 184)
      Me.lblEprocOrderNr.Name = "lblEprocOrderNr"
      Me.lblEprocOrderNr.Size = New System.Drawing.Size(82, 13)
      Me.lblEprocOrderNr.TabIndex = 8
      Me.lblEprocOrderNr.Text = "EProc Order Nr."
      '
      'tbNr
      '
      Me.tbNr.Location = New System.Drawing.Point(92, 12)
      Me.tbNr.Name = "tbNr"
      Me.tbNr.Size = New System.Drawing.Size(97, 20)
      Me.tbNr.TabIndex = 9
      '
      'dtpOrderDate
      '
      Me.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpOrderDate.Location = New System.Drawing.Point(92, 41)
      Me.dtpOrderDate.Name = "dtpOrderDate"
      Me.dtpOrderDate.Size = New System.Drawing.Size(97, 20)
      Me.dtpOrderDate.TabIndex = 11
      '
      'cbOrderer
      '
      Me.cbOrderer.FormattingEnabled = True
      Me.cbOrderer.Location = New System.Drawing.Point(92, 67)
      Me.cbOrderer.Name = "cbOrderer"
      Me.cbOrderer.Size = New System.Drawing.Size(151, 21)
      Me.cbOrderer.TabIndex = 12
      '
      'cbSupplier
      '
      Me.cbSupplier.FormattingEnabled = True
      Me.cbSupplier.Location = New System.Drawing.Point(92, 94)
      Me.cbSupplier.Name = "cbSupplier"
      Me.cbSupplier.Size = New System.Drawing.Size(151, 21)
      Me.cbSupplier.TabIndex = 13
      '
      'tbRemarks
      '
      Me.tbRemarks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbRemarks.Location = New System.Drawing.Point(92, 121)
      Me.tbRemarks.Multiline = True
      Me.tbRemarks.Name = "tbRemarks"
      Me.tbRemarks.Size = New System.Drawing.Size(266, 54)
      Me.tbRemarks.TabIndex = 14
      '
      'cbEproc
      '
      Me.cbEproc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cbEproc.AutoSize = True
      Me.cbEproc.Location = New System.Drawing.Point(92, 184)
      Me.cbEproc.Name = "cbEproc"
      Me.cbEproc.Size = New System.Drawing.Size(15, 14)
      Me.cbEproc.TabIndex = 15
      Me.cbEproc.UseVisualStyleBackColor = True
      '
      'tbEprocOrderNr
      '
      Me.tbEprocOrderNr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbEprocOrderNr.Location = New System.Drawing.Point(201, 181)
      Me.tbEprocOrderNr.Name = "tbEprocOrderNr"
      Me.tbEprocOrderNr.Size = New System.Drawing.Size(157, 20)
      Me.tbEprocOrderNr.TabIndex = 16
      '
      'frmOrder
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(370, 256)
      Me.Controls.Add(Me.tbEprocOrderNr)
      Me.Controls.Add(Me.cbEproc)
      Me.Controls.Add(Me.tbRemarks)
      Me.Controls.Add(Me.cbSupplier)
      Me.Controls.Add(Me.cbOrderer)
      Me.Controls.Add(Me.dtpOrderDate)
      Me.Controls.Add(Me.tbNr)
      Me.Controls.Add(Me.lblEprocOrderNr)
      Me.Controls.Add(Me.lblEproc)
      Me.Controls.Add(Me.lblRemarks)
      Me.Controls.Add(Me.lblSupplier)
      Me.Controls.Add(Me.lblOrderer)
      Me.Controls.Add(Me.lblOrderDate)
      Me.Controls.Add(Me.lblNr)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmOrder"
      Me.Text = "New Order"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents lblNr As System.Windows.Forms.Label
   Friend WithEvents lblOrderDate As System.Windows.Forms.Label
   Friend WithEvents lblOrderer As System.Windows.Forms.Label
   Friend WithEvents lblSupplier As System.Windows.Forms.Label
   Friend WithEvents lblRemarks As System.Windows.Forms.Label
   Friend WithEvents lblEproc As System.Windows.Forms.Label
   Friend WithEvents lblEprocOrderNr As System.Windows.Forms.Label
   Friend WithEvents tbNr As System.Windows.Forms.TextBox
   Friend WithEvents dtpOrderDate As System.Windows.Forms.DateTimePicker
   Friend WithEvents cbOrderer As System.Windows.Forms.ComboBox
   Friend WithEvents cbSupplier As System.Windows.Forms.ComboBox
   Friend WithEvents tbRemarks As System.Windows.Forms.TextBox
   Friend WithEvents cbEproc As System.Windows.Forms.CheckBox
   Friend WithEvents tbEprocOrderNr As System.Windows.Forms.TextBox
End Class
