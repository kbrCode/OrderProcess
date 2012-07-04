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
        Me.components = New System.ComponentModel.Container()
        Dim cmtvMain As System.Windows.Forms.ContextMenuStrip
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfirmedItems))
        Me.cmtvMainOpenNotesOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmtvMainNewConfirmedItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmtvMainEditConfirmedItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmtvMainRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmtvMainCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lvMain = New System.Windows.Forms.ListView()
        Me.ilMain = New System.Windows.Forms.ImageList(Me.components)
        Me.ttlvMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.ignoreColumnsCheck = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColumnSearchCombo = New System.Windows.Forms.ComboBox()
        Me.searchBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.searchButton = New System.Windows.Forms.Button()
        cmtvMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        cmtvMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmtvMain
        '
        cmtvMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmtvMainOpenNotesOrder, Me.cmtvMainNewConfirmedItem, Me.cmtvMainEditConfirmedItem, Me.cmtvMainRemove, Me.cmtvMainCopy})
        cmtvMain.Name = "cmtvMain"
        cmtvMain.Size = New System.Drawing.Size(193, 136)
        '
        'cmtvMainOpenNotesOrder
        '
        Me.cmtvMainOpenNotesOrder.Image = Global.OrderProcess1_1.My.Resources.Resources.notes
        Me.cmtvMainOpenNotesOrder.Name = "cmtvMainOpenNotesOrder"
        Me.cmtvMainOpenNotesOrder.Size = New System.Drawing.Size(192, 22)
        Me.cmtvMainOpenNotesOrder.Text = "OpenNotesOrder"
        '
        'cmtvMainNewConfirmedItem
        '
        Me.cmtvMainNewConfirmedItem.Image = Global.OrderProcess1_1.My.Resources.Resources.HW
        Me.cmtvMainNewConfirmedItem.Name = "cmtvMainNewConfirmedItem"
        Me.cmtvMainNewConfirmedItem.Size = New System.Drawing.Size(192, 22)
        Me.cmtvMainNewConfirmedItem.Text = "New ConfirmedItem..."
        '
        'cmtvMainEditConfirmedItem
        '
        Me.cmtvMainEditConfirmedItem.Image = Global.OrderProcess1_1.My.Resources.Resources.HW
        Me.cmtvMainEditConfirmedItem.Name = "cmtvMainEditConfirmedItem"
        Me.cmtvMainEditConfirmedItem.Size = New System.Drawing.Size(192, 22)
        Me.cmtvMainEditConfirmedItem.Text = "Edit ConfirmedItem..."
        '
        'cmtvMainRemove
        '
        Me.cmtvMainRemove.Image = Global.OrderProcess1_1.My.Resources.Resources.Close
        Me.cmtvMainRemove.Name = "cmtvMainRemove"
        Me.cmtvMainRemove.Size = New System.Drawing.Size(192, 22)
        Me.cmtvMainRemove.Text = "Remove"
        '
        'cmtvMainCopy
        '
        Me.cmtvMainCopy.Image = Global.OrderProcess1_1.My.Resources.Resources.Copy1
        Me.cmtvMainCopy.Name = "cmtvMainCopy"
        Me.cmtvMainCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.cmtvMainCopy.Size = New System.Drawing.Size(192, 22)
        Me.cmtvMainCopy.Text = "Copy"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Location = New System.Drawing.Point(597, 451)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lvMain
        '
        Me.lvMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMain.FullRowSelect = True
        Me.lvMain.HideSelection = False
        Me.lvMain.Location = New System.Drawing.Point(12, 30)
        Me.lvMain.Name = "lvMain"
        Me.lvMain.ShowItemToolTips = True
        Me.lvMain.Size = New System.Drawing.Size(660, 415)
        Me.lvMain.TabIndex = 2
        Me.lvMain.UseCompatibleStateImageBehavior = False
        Me.lvMain.View = System.Windows.Forms.View.Details
        '
        'ilMain
        '
        Me.ilMain.ImageStream = CType(resources.GetObject("ilMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilMain.TransparentColor = System.Drawing.Color.Transparent
        Me.ilMain.Images.SetKeyName(0, "HW")
        Me.ilMain.Images.SetKeyName(1, "NonIT")
        Me.ilMain.Images.SetKeyName(2, "SW")
        '
        'ignoreColumnsCheck
        '
        Me.ignoreColumnsCheck.AutoSize = True
        Me.ignoreColumnsCheck.Location = New System.Drawing.Point(546, 8)
        Me.ignoreColumnsCheck.Name = "ignoreColumnsCheck"
        Me.ignoreColumnsCheck.Size = New System.Drawing.Size(126, 17)
        Me.ignoreColumnsCheck.TabIndex = 13
        Me.ignoreColumnsCheck.Text = "Search in all columns"
        Me.ignoreColumnsCheck.UseVisualStyleBackColor = True
        Me.ignoreColumnsCheck.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Search:"
        '
        'ColumnSearchCombo
        '
        Me.ColumnSearchCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ColumnSearchCombo.FormattingEnabled = True
        Me.ColumnSearchCombo.Location = New System.Drawing.Point(419, 5)
        Me.ColumnSearchCombo.Name = "ColumnSearchCombo"
        Me.ColumnSearchCombo.Size = New System.Drawing.Size(122, 21)
        Me.ColumnSearchCombo.TabIndex = 11
        '
        'searchBox
        '
        Me.searchBox.Location = New System.Drawing.Point(62, 6)
        Me.searchBox.Name = "searchBox"
        Me.searchBox.Size = New System.Drawing.Size(300, 20)
        Me.searchBox.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(368, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Column:"
        '
        'searchButton
        '
        Me.searchButton.Location = New System.Drawing.Point(546, 5)
        Me.searchButton.Name = "searchButton"
        Me.searchButton.Size = New System.Drawing.Size(125, 20)
        Me.searchButton.TabIndex = 15
        Me.searchButton.Text = "Search"
        Me.searchButton.UseVisualStyleBackColor = True
        '
        'frmConfirmedItems
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 484)
        Me.ContextMenuStrip = cmtvMain
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.searchButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ColumnSearchCombo)
        Me.Controls.Add(Me.searchBox)
        Me.Controls.Add(Me.lvMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ignoreColumnsCheck)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfirmedItems"
        Me.Tag = ""
        Me.Text = "frmConfirmedItems"
        cmtvMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Friend WithEvents btnClose As System.Windows.Forms.Button
   Friend WithEvents lvMain As System.Windows.Forms.ListView
   Friend WithEvents ilMain As System.Windows.Forms.ImageList
   Friend WithEvents cmtvMainOpenNotesOrder As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainNewConfirmedItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainRemove As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainCopy As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ttlvMain As System.Windows.Forms.ToolTip
    Friend WithEvents cmtvMainEditConfirmedItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ignoreColumnsCheck As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnSearchCombo As System.Windows.Forms.ComboBox
    Friend WithEvents searchBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents searchButton As System.Windows.Forms.Button
End Class
