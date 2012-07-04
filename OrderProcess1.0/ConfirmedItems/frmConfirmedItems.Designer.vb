<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmedItems
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
      Me.btnClose = New System.Windows.Forms.Button
      Me.dgvMain = New System.Windows.Forms.DataGridView
      CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnClose
      '
      Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnClose.Location = New System.Drawing.Point(499, 268)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(75, 23)
      Me.btnClose.TabIndex = 0
      Me.btnClose.Text = "Close"
      Me.btnClose.UseVisualStyleBackColor = True
      '
      'dgvMain
      '
      Me.dgvMain.AllowUserToAddRows = False
      Me.dgvMain.AllowUserToDeleteRows = False
      Me.dgvMain.AllowUserToOrderColumns = True
      Me.dgvMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvMain.Location = New System.Drawing.Point(12, 12)
      Me.dgvMain.MultiSelect = False
      Me.dgvMain.Name = "dgvMain"
      Me.dgvMain.ReadOnly = True
      Me.dgvMain.RowHeadersVisible = False
      Me.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvMain.Size = New System.Drawing.Size(562, 250)
      Me.dgvMain.TabIndex = 2
      '
      'frmConfirmedItems
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(586, 303)
      Me.Controls.Add(Me.dgvMain)
      Me.Controls.Add(Me.btnClose)
      Me.Name = "frmConfirmedItems"
      Me.Text = "Confirmed Items"
      CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents btnClose As System.Windows.Forms.Button
   Friend WithEvents dgvMain As System.Windows.Forms.DataGridView
End Class
