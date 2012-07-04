<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReport))
      Me.dtpFrom = New System.Windows.Forms.DateTimePicker
      Me.dtpTo = New System.Windows.Forms.DateTimePicker
      Me.lblFrom = New System.Windows.Forms.Label
      Me.lblTo = New System.Windows.Forms.Label
      Me.lblAccounting = New System.Windows.Forms.Label
      Me.clbAccountingUnits = New System.Windows.Forms.CheckedListBox
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOK = New System.Windows.Forms.Button
      Me.lblUnit = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'dtpFrom
      '
      Me.dtpFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpFrom.Location = New System.Drawing.Point(89, 12)
      Me.dtpFrom.Name = "dtpFrom"
      Me.dtpFrom.Size = New System.Drawing.Size(197, 20)
      Me.dtpFrom.TabIndex = 0
      '
      'dtpTo
      '
      Me.dtpTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpTo.Location = New System.Drawing.Point(89, 38)
      Me.dtpTo.Name = "dtpTo"
      Me.dtpTo.Size = New System.Drawing.Size(197, 20)
      Me.dtpTo.TabIndex = 1
      '
      'lblFrom
      '
      Me.lblFrom.AutoSize = True
      Me.lblFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblFrom.Location = New System.Drawing.Point(12, 16)
      Me.lblFrom.Name = "lblFrom"
      Me.lblFrom.Size = New System.Drawing.Size(34, 13)
      Me.lblFrom.TabIndex = 2
      Me.lblFrom.Text = "From"
      '
      'lblTo
      '
      Me.lblTo.AutoSize = True
      Me.lblTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTo.Location = New System.Drawing.Point(12, 42)
      Me.lblTo.Name = "lblTo"
      Me.lblTo.Size = New System.Drawing.Size(22, 13)
      Me.lblTo.TabIndex = 3
      Me.lblTo.Text = "To"
      '
      'lblAccounting
      '
      Me.lblAccounting.AutoSize = True
      Me.lblAccounting.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblAccounting.Location = New System.Drawing.Point(12, 67)
      Me.lblAccounting.Name = "lblAccounting"
      Me.lblAccounting.Size = New System.Drawing.Size(71, 13)
      Me.lblAccounting.TabIndex = 4
      Me.lblAccounting.Text = "Accounting"
      '
      'clbAccountingUnits
      '
      Me.clbAccountingUnits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.clbAccountingUnits.CheckOnClick = True
      Me.clbAccountingUnits.ColumnWidth = 70
      Me.clbAccountingUnits.FormattingEnabled = True
      Me.clbAccountingUnits.Location = New System.Drawing.Point(89, 64)
      Me.clbAccountingUnits.MultiColumn = True
      Me.clbAccountingUnits.Name = "clbAccountingUnits"
      Me.clbAccountingUnits.Size = New System.Drawing.Size(197, 154)
      Me.clbAccountingUnits.TabIndex = 5
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(212, 232)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 6
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOK
      '
      Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(131, 232)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 7
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'lblUnit
      '
      Me.lblUnit.AutoSize = True
      Me.lblUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblUnit.Location = New System.Drawing.Point(12, 80)
      Me.lblUnit.Name = "lblUnit"
      Me.lblUnit.Size = New System.Drawing.Size(30, 13)
      Me.lblUnit.TabIndex = 8
      Me.lblUnit.Text = "Unit"
      '
      'frmReport
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(299, 273)
      Me.Controls.Add(Me.lblUnit)
      Me.Controls.Add(Me.btnOK)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.clbAccountingUnits)
      Me.Controls.Add(Me.lblAccounting)
      Me.Controls.Add(Me.lblTo)
      Me.Controls.Add(Me.lblFrom)
      Me.Controls.Add(Me.dtpTo)
      Me.Controls.Add(Me.dtpFrom)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmReport"
      Me.Text = "Reports"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblFrom As System.Windows.Forms.Label
   Friend WithEvents lblTo As System.Windows.Forms.Label
   Friend WithEvents lblAccounting As System.Windows.Forms.Label
   Friend WithEvents clbAccountingUnits As System.Windows.Forms.CheckedListBox
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOK As System.Windows.Forms.Button
   Friend WithEvents lblUnit As System.Windows.Forms.Label
End Class
