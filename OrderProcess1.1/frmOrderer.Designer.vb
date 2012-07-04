<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderer
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrderer))
      Me.lblName = New System.Windows.Forms.Label
      Me.lblEMailAddress = New System.Windows.Forms.Label
      Me.tbName = New System.Windows.Forms.TextBox
      Me.tbEMailAddress = New System.Windows.Forms.TextBox
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'lblName
      '
      Me.lblName.AutoSize = True
      Me.lblName.Location = New System.Drawing.Point(12, 9)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(35, 13)
      Me.lblName.TabIndex = 0
      Me.lblName.Text = "Name"
      '
      'lblEMailAddress
      '
      Me.lblEMailAddress.AutoSize = True
      Me.lblEMailAddress.Location = New System.Drawing.Point(12, 50)
      Me.lblEMailAddress.Name = "lblEMailAddress"
      Me.lblEMailAddress.Size = New System.Drawing.Size(77, 13)
      Me.lblEMailAddress.TabIndex = 1
      Me.lblEMailAddress.Text = "E-Mail Address"
      '
      'tbName
      '
      Me.tbName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbName.Location = New System.Drawing.Point(12, 25)
      Me.tbName.Name = "tbName"
      Me.tbName.Size = New System.Drawing.Size(223, 20)
      Me.tbName.TabIndex = 2
      '
      'tbEMailAddress
      '
      Me.tbEMailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbEMailAddress.Location = New System.Drawing.Point(12, 66)
      Me.tbEMailAddress.Name = "tbEMailAddress"
      Me.tbEMailAddress.Size = New System.Drawing.Size(223, 20)
      Me.tbEMailAddress.TabIndex = 3
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.Location = New System.Drawing.Point(79, 105)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 4
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(160, 105)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 5
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'frmOrderer
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(247, 140)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.tbEMailAddress)
      Me.Controls.Add(Me.tbName)
      Me.Controls.Add(Me.lblEMailAddress)
      Me.Controls.Add(Me.lblName)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmOrderer"
      Me.Text = "New Orderer"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblName As System.Windows.Forms.Label
   Friend WithEvents lblEMailAddress As System.Windows.Forms.Label
   Friend WithEvents tbName As System.Windows.Forms.TextBox
   Friend WithEvents tbEMailAddress As System.Windows.Forms.TextBox
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
