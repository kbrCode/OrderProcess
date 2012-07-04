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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountingUnit))
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.lblShortID = New System.Windows.Forms.Label
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.tbShortID = New System.Windows.Forms.TextBox
      Me.mtbCostCenter = New System.Windows.Forms.MaskedTextBox
      Me.lblITManager = New System.Windows.Forms.Label
      Me.tbITManager = New System.Windows.Forms.TextBox
      Me.tbBesitzer = New System.Windows.Forms.TextBox
      Me.lblBesitzer = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.Enabled = False
      Me.btnOK.Location = New System.Drawing.Point(92, 122)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 3
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(173, 122)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 4
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'lblShortID
      '
      Me.lblShortID.AutoSize = True
      Me.lblShortID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblShortID.Location = New System.Drawing.Point(12, 15)
      Me.lblShortID.Name = "lblShortID"
      Me.lblShortID.Size = New System.Drawing.Size(50, 13)
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
      Me.tbShortID.TabIndex = 0
      '
      'mtbCostCenter
      '
      Me.mtbCostCenter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.mtbCostCenter.Location = New System.Drawing.Point(88, 38)
      Me.mtbCostCenter.Name = "mtbCostCenter"
      Me.mtbCostCenter.Size = New System.Drawing.Size(160, 20)
      Me.mtbCostCenter.TabIndex = 1
      '
      'lblITManager
      '
      Me.lblITManager.AutoSize = True
      Me.lblITManager.Location = New System.Drawing.Point(12, 67)
      Me.lblITManager.Name = "lblITManager"
      Me.lblITManager.Size = New System.Drawing.Size(59, 13)
      Me.lblITManager.TabIndex = 4
      Me.lblITManager.Text = "ITManager"
      '
      'tbITManager
      '
      Me.tbITManager.Location = New System.Drawing.Point(88, 64)
      Me.tbITManager.Name = "tbITManager"
      Me.tbITManager.Size = New System.Drawing.Size(160, 20)
      Me.tbITManager.TabIndex = 2
      '
      'tbBesitzer
      '
      Me.tbBesitzer.Location = New System.Drawing.Point(88, 90)
      Me.tbBesitzer.Name = "tbBesitzer"
      Me.tbBesitzer.Size = New System.Drawing.Size(160, 20)
      Me.tbBesitzer.TabIndex = 5
      '
      'lblBesitzer
      '
      Me.lblBesitzer.AutoSize = True
      Me.lblBesitzer.Location = New System.Drawing.Point(12, 93)
      Me.lblBesitzer.Name = "lblBesitzer"
      Me.lblBesitzer.Size = New System.Drawing.Size(44, 13)
      Me.lblBesitzer.TabIndex = 6
      Me.lblBesitzer.Text = "Besitzer"
      '
      'frmAccountingUnit
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(260, 157)
      Me.Controls.Add(Me.tbBesitzer)
      Me.Controls.Add(Me.lblBesitzer)
      Me.Controls.Add(Me.tbITManager)
      Me.Controls.Add(Me.lblITManager)
      Me.Controls.Add(Me.mtbCostCenter)
      Me.Controls.Add(Me.tbShortID)
      Me.Controls.Add(Me.lblCostCenter)
      Me.Controls.Add(Me.lblShortID)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
   Friend WithEvents lblITManager As System.Windows.Forms.Label
   Friend WithEvents tbITManager As System.Windows.Forms.TextBox
   Friend WithEvents tbBesitzer As System.Windows.Forms.TextBox
   Friend WithEvents lblBesitzer As System.Windows.Forms.Label
End Class
