<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItem
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
      Me.lblItemID = New System.Windows.Forms.Label
      Me.tbItemID = New System.Windows.Forms.TextBox
      Me.tbDescription = New System.Windows.Forms.TextBox
      Me.lblDescription = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(167, 72)
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
      Me.btnCancel.Location = New System.Drawing.Point(248, 72)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'lblItemID
      '
      Me.lblItemID.AutoSize = True
      Me.lblItemID.Location = New System.Drawing.Point(12, 15)
      Me.lblItemID.Name = "lblItemID"
      Me.lblItemID.Size = New System.Drawing.Size(38, 13)
      Me.lblItemID.TabIndex = 2
      Me.lblItemID.Text = "ItemID"
      '
      'tbItemID
      '
      Me.tbItemID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbItemID.Location = New System.Drawing.Point(78, 12)
      Me.tbItemID.Name = "tbItemID"
      Me.tbItemID.Size = New System.Drawing.Size(245, 20)
      Me.tbItemID.TabIndex = 3
      '
      'tbDescription
      '
      Me.tbDescription.BackColor = System.Drawing.SystemColors.Window
      Me.tbDescription.Enabled = False
      Me.tbDescription.Location = New System.Drawing.Point(78, 38)
      Me.tbDescription.Name = "tbDescription"
      Me.tbDescription.Size = New System.Drawing.Size(245, 20)
      Me.tbDescription.TabIndex = 4
      '
      'lblDescription
      '
      Me.lblDescription.AutoSize = True
      Me.lblDescription.Location = New System.Drawing.Point(12, 41)
      Me.lblDescription.Name = "lblDescription"
      Me.lblDescription.Size = New System.Drawing.Size(60, 13)
      Me.lblDescription.TabIndex = 5
      Me.lblDescription.Text = "Description"
      '
      'frmItem
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(335, 107)
      Me.Controls.Add(Me.lblDescription)
      Me.Controls.Add(Me.tbDescription)
      Me.Controls.Add(Me.tbItemID)
      Me.Controls.Add(Me.lblItemID)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Name = "frmItem"
      Me.Text = "Item"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents lblItemID As System.Windows.Forms.Label
   Friend WithEvents tbItemID As System.Windows.Forms.TextBox
   Friend WithEvents tbDescription As System.Windows.Forms.TextBox
   Friend WithEvents lblDescription As System.Windows.Forms.Label
End Class
