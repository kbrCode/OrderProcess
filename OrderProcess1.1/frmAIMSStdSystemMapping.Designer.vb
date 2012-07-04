<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAIMSStdSystemMapping
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
      Me.lblCategory = New System.Windows.Forms.Label
      Me.lblOrderableItem = New System.Windows.Forms.Label
      Me.tbOPCategory = New System.Windows.Forms.TextBox
      Me.tbOPDescription = New System.Windows.Forms.TextBox
      Me.cbAIMSStdSystems = New System.Windows.Forms.ComboBox
      Me.lblStdSystem = New System.Windows.Forms.Label
      Me.lblOrderProcess = New System.Windows.Forms.Label
      Me.lblAIMS = New System.Windows.Forms.Label
      Me.tbAIMSCategory = New System.Windows.Forms.TextBox
      Me.tbAIMSModelNr = New System.Windows.Forms.TextBox
      Me.tbOPModelNr = New System.Windows.Forms.TextBox
      Me.tbAIMSManufacturer = New System.Windows.Forms.TextBox
      Me.tbOPManufacturer = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.btnOK = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'lblCategory
      '
      Me.lblCategory.AutoSize = True
      Me.lblCategory.Location = New System.Drawing.Point(12, 98)
      Me.lblCategory.Name = "lblCategory"
      Me.lblCategory.Size = New System.Drawing.Size(49, 13)
      Me.lblCategory.TabIndex = 31
      Me.lblCategory.Text = "Category"
      '
      'lblOrderableItem
      '
      Me.lblOrderableItem.AutoSize = True
      Me.lblOrderableItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblOrderableItem.ForeColor = System.Drawing.Color.Black
      Me.lblOrderableItem.Location = New System.Drawing.Point(12, 15)
      Me.lblOrderableItem.Name = "lblOrderableItem"
      Me.lblOrderableItem.Size = New System.Drawing.Size(80, 13)
      Me.lblOrderableItem.TabIndex = 28
      Me.lblOrderableItem.Text = "ItemDescription"
      '
      'tbOPCategory
      '
      Me.tbOPCategory.Enabled = False
      Me.tbOPCategory.Location = New System.Drawing.Point(98, 95)
      Me.tbOPCategory.Name = "tbOPCategory"
      Me.tbOPCategory.Size = New System.Drawing.Size(194, 20)
      Me.tbOPCategory.TabIndex = 33
      '
      'tbOPDescription
      '
      Me.tbOPDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbOPDescription.Enabled = False
      Me.tbOPDescription.Location = New System.Drawing.Point(98, 12)
      Me.tbOPDescription.Name = "tbOPDescription"
      Me.tbOPDescription.Size = New System.Drawing.Size(378, 20)
      Me.tbOPDescription.TabIndex = 34
      '
      'cbAIMSStdSystems
      '
      Me.cbAIMSStdSystems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cbAIMSStdSystems.FormattingEnabled = True
      Me.cbAIMSStdSystems.Location = New System.Drawing.Point(98, 38)
      Me.cbAIMSStdSystems.Name = "cbAIMSStdSystems"
      Me.cbAIMSStdSystems.Size = New System.Drawing.Size(378, 21)
      Me.cbAIMSStdSystems.TabIndex = 35
      '
      'lblStdSystem
      '
      Me.lblStdSystem.AutoSize = True
      Me.lblStdSystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblStdSystem.Location = New System.Drawing.Point(12, 41)
      Me.lblStdSystem.Name = "lblStdSystem"
      Me.lblStdSystem.Size = New System.Drawing.Size(73, 13)
      Me.lblStdSystem.TabIndex = 36
      Me.lblStdSystem.Text = "Std_System"
      '
      'lblOrderProcess
      '
      Me.lblOrderProcess.AutoSize = True
      Me.lblOrderProcess.Location = New System.Drawing.Point(95, 79)
      Me.lblOrderProcess.Name = "lblOrderProcess"
      Me.lblOrderProcess.Size = New System.Drawing.Size(71, 13)
      Me.lblOrderProcess.TabIndex = 37
      Me.lblOrderProcess.Text = "OrderProcess"
      '
      'lblAIMS
      '
      Me.lblAIMS.AutoSize = True
      Me.lblAIMS.Location = New System.Drawing.Point(295, 79)
      Me.lblAIMS.Name = "lblAIMS"
      Me.lblAIMS.Size = New System.Drawing.Size(33, 13)
      Me.lblAIMS.TabIndex = 38
      Me.lblAIMS.Text = "AIMS"
      '
      'tbAIMSCategory
      '
      Me.tbAIMSCategory.Enabled = False
      Me.tbAIMSCategory.Location = New System.Drawing.Point(298, 95)
      Me.tbAIMSCategory.Name = "tbAIMSCategory"
      Me.tbAIMSCategory.Size = New System.Drawing.Size(178, 20)
      Me.tbAIMSCategory.TabIndex = 39
      '
      'tbAIMSModelNr
      '
      Me.tbAIMSModelNr.Enabled = False
      Me.tbAIMSModelNr.Location = New System.Drawing.Point(298, 121)
      Me.tbAIMSModelNr.Name = "tbAIMSModelNr"
      Me.tbAIMSModelNr.Size = New System.Drawing.Size(178, 20)
      Me.tbAIMSModelNr.TabIndex = 41
      '
      'tbOPModelNr
      '
      Me.tbOPModelNr.Enabled = False
      Me.tbOPModelNr.Location = New System.Drawing.Point(98, 121)
      Me.tbOPModelNr.Name = "tbOPModelNr"
      Me.tbOPModelNr.Size = New System.Drawing.Size(194, 20)
      Me.tbOPModelNr.TabIndex = 40
      '
      'tbAIMSManufacturer
      '
      Me.tbAIMSManufacturer.Enabled = False
      Me.tbAIMSManufacturer.Location = New System.Drawing.Point(298, 147)
      Me.tbAIMSManufacturer.Name = "tbAIMSManufacturer"
      Me.tbAIMSManufacturer.Size = New System.Drawing.Size(178, 20)
      Me.tbAIMSManufacturer.TabIndex = 43
      '
      'tbOPManufacturer
      '
      Me.tbOPManufacturer.Enabled = False
      Me.tbOPManufacturer.Location = New System.Drawing.Point(98, 147)
      Me.tbOPManufacturer.Name = "tbOPManufacturer"
      Me.tbOPManufacturer.Size = New System.Drawing.Size(194, 20)
      Me.tbOPManufacturer.TabIndex = 42
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 124)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(47, 13)
      Me.Label1.TabIndex = 44
      Me.Label1.Text = "ModelNr"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 150)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(70, 13)
      Me.Label2.TabIndex = 45
      Me.Label2.Text = "Manufacturer"
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(320, 187)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 46
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(401, 187)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 47
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'frmAIMSStdSystemMapping
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(488, 222)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.tbAIMSManufacturer)
      Me.Controls.Add(Me.tbOPManufacturer)
      Me.Controls.Add(Me.tbAIMSModelNr)
      Me.Controls.Add(Me.tbOPModelNr)
      Me.Controls.Add(Me.tbAIMSCategory)
      Me.Controls.Add(Me.lblAIMS)
      Me.Controls.Add(Me.lblOrderProcess)
      Me.Controls.Add(Me.lblStdSystem)
      Me.Controls.Add(Me.cbAIMSStdSystems)
      Me.Controls.Add(Me.tbOPDescription)
      Me.Controls.Add(Me.tbOPCategory)
      Me.Controls.Add(Me.lblCategory)
      Me.Controls.Add(Me.lblOrderableItem)
      Me.Name = "frmAIMSStdSystemMapping"
      Me.Text = "AIMS Std_Systems Mapping"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblCategory As System.Windows.Forms.Label
   Friend WithEvents lblOrderableItem As System.Windows.Forms.Label
   Friend WithEvents tbOPCategory As System.Windows.Forms.TextBox
   Friend WithEvents tbOPDescription As System.Windows.Forms.TextBox
   Friend WithEvents cbAIMSStdSystems As System.Windows.Forms.ComboBox
   Friend WithEvents lblStdSystem As System.Windows.Forms.Label
   Friend WithEvents lblOrderProcess As System.Windows.Forms.Label
   Friend WithEvents lblAIMS As System.Windows.Forms.Label
   Friend WithEvents tbAIMSCategory As System.Windows.Forms.TextBox
   Friend WithEvents tbAIMSModelNr As System.Windows.Forms.TextBox
   Friend WithEvents tbOPModelNr As System.Windows.Forms.TextBox
   Friend WithEvents tbAIMSManufacturer As System.Windows.Forms.TextBox
   Friend WithEvents tbOPManufacturer As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
