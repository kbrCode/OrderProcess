<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemClass
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
      Me.lblShortID = New System.Windows.Forms.Label
      Me.lblDescription = New System.Windows.Forms.Label
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOK = New System.Windows.Forms.Button
      Me.tbShortID = New System.Windows.Forms.TextBox
      Me.tbDescription = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'lblShortID
      '
      Me.lblShortID.AutoSize = True
      Me.lblShortID.Location = New System.Drawing.Point(12, 15)
      Me.lblShortID.Name = "lblShortID"
      Me.lblShortID.Size = New System.Drawing.Size(43, 13)
      Me.lblShortID.TabIndex = 0
      Me.lblShortID.Text = "ShortID"
      '
      'lblDescription
      '
      Me.lblDescription.AutoSize = True
      Me.lblDescription.Location = New System.Drawing.Point(12, 41)
      Me.lblDescription.Name = "lblDescription"
      Me.lblDescription.Size = New System.Drawing.Size(60, 13)
      Me.lblDescription.TabIndex = 1
      Me.lblDescription.Text = "Description"
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(248, 76)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 2
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(167, 76)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 3
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'tbShortID
      '
      Me.tbShortID.Location = New System.Drawing.Point(78, 12)
      Me.tbShortID.Name = "tbShortID"
      Me.tbShortID.Size = New System.Drawing.Size(104, 20)
      Me.tbShortID.TabIndex = 4
      '
      'tbDescription
      '
      Me.tbDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbDescription.Location = New System.Drawing.Point(78, 38)
      Me.tbDescription.Name = "tbDescription"
      Me.tbDescription.Size = New System.Drawing.Size(245, 20)
      Me.tbDescription.TabIndex = 5
      '
      'frmItemClass
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(335, 111)
      Me.Controls.Add(Me.tbDescription)
      Me.Controls.Add(Me.tbShortID)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.lblDescription)
      Me.Controls.Add(Me.lblShortID)
      Me.Name = "frmItemClass"
      Me.Text = "New ItemClass"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblShortID As System.Windows.Forms.Label
   Friend WithEvents lblDescription As System.Windows.Forms.Label
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents tbShortID As System.Windows.Forms.TextBox
   Friend WithEvents tbDescription As System.Windows.Forms.TextBox
End Class
