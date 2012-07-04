<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplier
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSupplier))
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOK = New System.Windows.Forms.Button
      Me.lblShortID = New System.Windows.Forms.Label
      Me.tbShortID = New System.Windows.Forms.TextBox
      Me.lblDescription = New System.Windows.Forms.Label
      Me.tbDescription = New System.Windows.Forms.TextBox
      Me.lblAddress = New System.Windows.Forms.Label
      Me.tbAddress = New System.Windows.Forms.TextBox
      Me.lblMailAddress = New System.Windows.Forms.Label
      Me.tbMailAddress = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(181, 246)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 0
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(100, 246)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 1
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'lblShortID
      '
      Me.lblShortID.AutoSize = True
      Me.lblShortID.Location = New System.Drawing.Point(12, 9)
      Me.lblShortID.Name = "lblShortID"
      Me.lblShortID.Size = New System.Drawing.Size(43, 13)
      Me.lblShortID.TabIndex = 2
      Me.lblShortID.Text = "ShortID"
      '
      'tbShortID
      '
      Me.tbShortID.Location = New System.Drawing.Point(12, 25)
      Me.tbShortID.Name = "tbShortID"
      Me.tbShortID.Size = New System.Drawing.Size(171, 20)
      Me.tbShortID.TabIndex = 3
      '
      'lblDescription
      '
      Me.lblDescription.AutoSize = True
      Me.lblDescription.Location = New System.Drawing.Point(12, 54)
      Me.lblDescription.Name = "lblDescription"
      Me.lblDescription.Size = New System.Drawing.Size(60, 13)
      Me.lblDescription.TabIndex = 4
      Me.lblDescription.Text = "Description"
      '
      'tbDescription
      '
      Me.tbDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbDescription.Location = New System.Drawing.Point(12, 70)
      Me.tbDescription.Name = "tbDescription"
      Me.tbDescription.Size = New System.Drawing.Size(244, 20)
      Me.tbDescription.TabIndex = 5
      '
      'lblAddress
      '
      Me.lblAddress.AutoSize = True
      Me.lblAddress.Location = New System.Drawing.Point(12, 100)
      Me.lblAddress.Name = "lblAddress"
      Me.lblAddress.Size = New System.Drawing.Size(45, 13)
      Me.lblAddress.TabIndex = 6
      Me.lblAddress.Text = "Address"
      '
      'tbAddress
      '
      Me.tbAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbAddress.Location = New System.Drawing.Point(12, 116)
      Me.tbAddress.Multiline = True
      Me.tbAddress.Name = "tbAddress"
      Me.tbAddress.Size = New System.Drawing.Size(244, 63)
      Me.tbAddress.TabIndex = 7
      '
      'lblMailAddress
      '
      Me.lblMailAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblMailAddress.AutoSize = True
      Me.lblMailAddress.Location = New System.Drawing.Point(12, 188)
      Me.lblMailAddress.Name = "lblMailAddress"
      Me.lblMailAddress.Size = New System.Drawing.Size(64, 13)
      Me.lblMailAddress.TabIndex = 8
      Me.lblMailAddress.Text = "MailAddress"
      '
      'tbMailAddress
      '
      Me.tbMailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbMailAddress.Location = New System.Drawing.Point(12, 204)
      Me.tbMailAddress.Name = "tbMailAddress"
      Me.tbMailAddress.Size = New System.Drawing.Size(244, 20)
      Me.tbMailAddress.TabIndex = 9
      '
      'frmSupplier
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(268, 281)
      Me.Controls.Add(Me.tbMailAddress)
      Me.Controls.Add(Me.lblMailAddress)
      Me.Controls.Add(Me.tbAddress)
      Me.Controls.Add(Me.lblAddress)
      Me.Controls.Add(Me.tbDescription)
      Me.Controls.Add(Me.lblDescription)
      Me.Controls.Add(Me.tbShortID)
      Me.Controls.Add(Me.lblShortID)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmSupplier"
      Me.Text = "Supplier"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents lblShortID As System.Windows.Forms.Label
   Friend WithEvents tbShortID As System.Windows.Forms.TextBox
   Friend WithEvents lblDescription As System.Windows.Forms.Label
   Friend WithEvents tbDescription As System.Windows.Forms.TextBox
   Friend WithEvents lblAddress As System.Windows.Forms.Label
   Friend WithEvents tbAddress As System.Windows.Forms.TextBox
   Friend WithEvents lblMailAddress As System.Windows.Forms.Label
   Friend WithEvents tbMailAddress As System.Windows.Forms.TextBox
End Class
