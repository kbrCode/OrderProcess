<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountingUnit
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
      Me.lblShortID = New System.Windows.Forms.Label
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.tbShortID = New System.Windows.Forms.TextBox
      Me.mtbCostCenter = New System.Windows.Forms.MaskedTextBox
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(92, 82)
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
      Me.btnCancel.Location = New System.Drawing.Point(173, 82)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'lblShortID
      '
      Me.lblShortID.AutoSize = True
      Me.lblShortID.Location = New System.Drawing.Point(12, 15)
      Me.lblShortID.Name = "lblShortID"
      Me.lblShortID.Size = New System.Drawing.Size(43, 13)
      Me.lblShortID.TabIndex = 2
      Me.lblShortID.Text = "ShortID"
      '
      'lblCostCenter
      '
      Me.lblCostCenter.AutoSize = True
      Me.lblCostCenter.Location = New System.Drawing.Point(12, 41)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(59, 13)
      Me.lblCostCenter.TabIndex = 3
      Me.lblCostCenter.Text = "CostCenter"
      '
      'tbShortID
      '
      Me.tbShortID.Location = New System.Drawing.Point(88, 12)
      Me.tbShortID.Name = "tbShortID"
      Me.tbShortID.Size = New System.Drawing.Size(100, 20)
      Me.tbShortID.TabIndex = 4
      '
      'mtbCostCenter
      '
      Me.mtbCostCenter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.mtbCostCenter.Location = New System.Drawing.Point(88, 38)
      Me.mtbCostCenter.Name = "mtbCostCenter"
      Me.mtbCostCenter.Size = New System.Drawing.Size(160, 20)
      Me.mtbCostCenter.TabIndex = 5
      '
      'frmAccountingUnit
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(260, 117)
      Me.Controls.Add(Me.mtbCostCenter)
      Me.Controls.Add(Me.tbShortID)
      Me.Controls.Add(Me.lblCostCenter)
      Me.Controls.Add(Me.lblShortID)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Name = "frmAccountingUnit"
      Me.Text = "New Accounting Unit"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents lblShortID As System.Windows.Forms.Label
   Friend WithEvents lblCostCenter As System.Windows.Forms.Label
   Friend WithEvents tbShortID As System.Windows.Forms.TextBox
   Friend WithEvents mtbCostCenter As System.Windows.Forms.MaskedTextBox
End Class
