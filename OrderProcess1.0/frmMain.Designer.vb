<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
      Me.components = New System.ComponentModel.Container
      Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orders")
      Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("AccountingUnits", -2, -2)
      Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ItemClasses", -2, -2)
      Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Suppliers", -2, -2)
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
      Me.dgvMain = New System.Windows.Forms.DataGridView
      Me.cmdgvMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.cmdgvMainNew = New System.Windows.Forms.ToolStripMenuItem
      Me.cmdgvMainEdit = New System.Windows.Forms.ToolStripMenuItem
      Me.cmdgvMainRemove = New System.Windows.Forms.ToolStripMenuItem
      Me.cmdgvMainSepDelivery = New System.Windows.Forms.ToolStripSeparator
      Me.cmdgvMainDelivery = New System.Windows.Forms.ToolStripMenuItem
      Me.mMain = New System.Windows.Forms.MenuStrip
      Me.mmOrder = New System.Windows.Forms.ToolStripMenuItem
      Me.mmOrderNew = New System.Windows.Forms.ToolStripMenuItem
      Me.mmOrderConfirmedItems = New System.Windows.Forms.ToolStripMenuItem
      Me.mmExit = New System.Windows.Forms.ToolStripMenuItem
      Me.mmAccountingUnit = New System.Windows.Forms.ToolStripMenuItem
      Me.mmAccountingUnitNew = New System.Windows.Forms.ToolStripMenuItem
      Me.mmItemClass = New System.Windows.Forms.ToolStripMenuItem
      Me.mmItemClassNew = New System.Windows.Forms.ToolStripMenuItem
      Me.mmDelivery = New System.Windows.Forms.ToolStripMenuItem
      Me.mmDeliveryNew = New System.Windows.Forms.ToolStripMenuItem
      Me.scMain = New System.Windows.Forms.SplitContainer
      Me.tvMain = New System.Windows.Forms.TreeView
      Me.cmtvMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.cmtvMainNew = New System.Windows.Forms.ToolStripMenuItem
      Me.cmtvMainEdit = New System.Windows.Forms.ToolStripMenuItem
      Me.cmtvMainRemove = New System.Windows.Forms.ToolStripMenuItem
      Me.cmtvMainSepDelivery = New System.Windows.Forms.ToolStripSeparator
      Me.cmtvMainSendMail = New System.Windows.Forms.ToolStripMenuItem
      Me.cmtvMainNewDelivery = New System.Windows.Forms.ToolStripMenuItem
      Me.iltvMain = New System.Windows.Forms.ImageList(Me.components)
      Me.mmOrderOrderedItems = New System.Windows.Forms.ToolStripMenuItem
      Me.ssMain = New System.Windows.Forms.StatusStrip
      Me.ssMainLabel = New System.Windows.Forms.ToolStripStatusLabel
      CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.cmdgvMain.SuspendLayout()
      Me.mMain.SuspendLayout()
      Me.scMain.Panel1.SuspendLayout()
      Me.scMain.Panel2.SuspendLayout()
      Me.scMain.SuspendLayout()
      Me.cmtvMain.SuspendLayout()
      Me.ssMain.SuspendLayout()
      Me.SuspendLayout()
      '
      'dgvMain
      '
      Me.dgvMain.AllowDrop = True
      Me.dgvMain.AllowUserToAddRows = False
      Me.dgvMain.AllowUserToDeleteRows = False
      Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvMain.ContextMenuStrip = Me.cmdgvMain
      Me.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvMain.Location = New System.Drawing.Point(0, 0)
      Me.dgvMain.Name = "dgvMain"
      Me.dgvMain.RowHeadersVisible = False
      Me.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvMain.Size = New System.Drawing.Size(492, 357)
      Me.dgvMain.TabIndex = 0
      '
      'cmdgvMain
      '
      Me.cmdgvMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdgvMainNew, Me.cmdgvMainEdit, Me.cmdgvMainRemove, Me.cmdgvMainSepDelivery, Me.cmdgvMainDelivery})
      Me.cmdgvMain.Name = "cmdgvMain"
      Me.cmdgvMain.Size = New System.Drawing.Size(161, 98)
      '
      'cmdgvMainNew
      '
      Me.cmdgvMainNew.Name = "cmdgvMainNew"
      Me.cmdgvMainNew.Size = New System.Drawing.Size(160, 22)
      Me.cmdgvMainNew.Text = "New..."
      '
      'cmdgvMainEdit
      '
      Me.cmdgvMainEdit.Name = "cmdgvMainEdit"
      Me.cmdgvMainEdit.Size = New System.Drawing.Size(160, 22)
      Me.cmdgvMainEdit.Text = "Edit..."
      '
      'cmdgvMainRemove
      '
      Me.cmdgvMainRemove.Name = "cmdgvMainRemove"
      Me.cmdgvMainRemove.Size = New System.Drawing.Size(160, 22)
      Me.cmdgvMainRemove.Text = "Remove..."
      '
      'cmdgvMainSepDelivery
      '
      Me.cmdgvMainSepDelivery.Name = "cmdgvMainSepDelivery"
      Me.cmdgvMainSepDelivery.Size = New System.Drawing.Size(157, 6)
      '
      'cmdgvMainDelivery
      '
      Me.cmdgvMainDelivery.Name = "cmdgvMainDelivery"
      Me.cmdgvMainDelivery.Size = New System.Drawing.Size(160, 22)
      Me.cmdgvMainDelivery.Text = "New Delivery..."
      '
      'mMain
      '
      Me.mMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmOrder, Me.mmAccountingUnit, Me.mmItemClass, Me.mmDelivery})
      Me.mMain.Location = New System.Drawing.Point(0, 0)
      Me.mMain.Name = "mMain"
      Me.mMain.Size = New System.Drawing.Size(743, 24)
      Me.mMain.TabIndex = 1
      Me.mMain.Text = "MenuStrip1"
      '
      'mmOrder
      '
      Me.mmOrder.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmOrderNew, Me.mmOrderConfirmedItems, Me.mmOrderOrderedItems, Me.mmExit})
      Me.mmOrder.Name = "mmOrder"
      Me.mmOrder.Size = New System.Drawing.Size(47, 20)
      Me.mmOrder.Text = "Order"
      '
      'mmOrderNew
      '
      Me.mmOrderNew.Name = "mmOrderNew"
      Me.mmOrderNew.Size = New System.Drawing.Size(173, 22)
      Me.mmOrderNew.Text = "New..."
      '
      'mmOrderConfirmedItems
      '
      Me.mmOrderConfirmedItems.Name = "mmOrderConfirmedItems"
      Me.mmOrderConfirmedItems.Size = New System.Drawing.Size(173, 22)
      Me.mmOrderConfirmedItems.Text = "ConfirmedItems..."
      '
      'mmExit
      '
      Me.mmExit.Name = "mmExit"
      Me.mmExit.Size = New System.Drawing.Size(173, 22)
      Me.mmExit.Text = "Exit"
      '
      'mmAccountingUnit
      '
      Me.mmAccountingUnit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmAccountingUnitNew})
      Me.mmAccountingUnit.Name = "mmAccountingUnit"
      Me.mmAccountingUnit.Size = New System.Drawing.Size(91, 20)
      Me.mmAccountingUnit.Text = "AccountingUnit"
      '
      'mmAccountingUnitNew
      '
      Me.mmAccountingUnitNew.Name = "mmAccountingUnitNew"
      Me.mmAccountingUnitNew.Size = New System.Drawing.Size(118, 22)
      Me.mmAccountingUnitNew.Text = "New..."
      '
      'mmItemClass
      '
      Me.mmItemClass.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmItemClassNew})
      Me.mmItemClass.Name = "mmItemClass"
      Me.mmItemClass.Size = New System.Drawing.Size(66, 20)
      Me.mmItemClass.Text = "ItemClass"
      '
      'mmItemClassNew
      '
      Me.mmItemClassNew.Name = "mmItemClassNew"
      Me.mmItemClassNew.Size = New System.Drawing.Size(118, 22)
      Me.mmItemClassNew.Text = "New..."
      '
      'mmDelivery
      '
      Me.mmDelivery.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmDeliveryNew})
      Me.mmDelivery.Name = "mmDelivery"
      Me.mmDelivery.Size = New System.Drawing.Size(58, 20)
      Me.mmDelivery.Text = "Delivery"
      '
      'mmDeliveryNew
      '
      Me.mmDeliveryNew.Enabled = False
      Me.mmDeliveryNew.Name = "mmDeliveryNew"
      Me.mmDeliveryNew.Size = New System.Drawing.Size(118, 22)
      Me.mmDeliveryNew.Text = "New..."
      '
      'scMain
      '
      Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.scMain.Location = New System.Drawing.Point(0, 24)
      Me.scMain.Name = "scMain"
      '
      'scMain.Panel1
      '
      Me.scMain.Panel1.Controls.Add(Me.tvMain)
      '
      'scMain.Panel2
      '
      Me.scMain.Panel2.Controls.Add(Me.dgvMain)
      Me.scMain.Size = New System.Drawing.Size(743, 357)
      Me.scMain.SplitterDistance = 247
      Me.scMain.TabIndex = 2
      '
      'tvMain
      '
      Me.tvMain.ContextMenuStrip = Me.cmtvMain
      Me.tvMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tvMain.ImageIndex = 0
      Me.tvMain.ImageList = Me.iltvMain
      Me.tvMain.Location = New System.Drawing.Point(0, 0)
      Me.tvMain.Name = "tvMain"
      TreeNode5.Name = "ndOrders"
      TreeNode5.Text = "Orders"
      TreeNode6.ImageIndex = -2
      TreeNode6.Name = "ndAccountingUnits"
      TreeNode6.SelectedImageIndex = -2
      TreeNode6.Text = "AccountingUnits"
      TreeNode7.ImageIndex = -2
      TreeNode7.Name = "ndItemClasses"
      TreeNode7.SelectedImageIndex = -2
      TreeNode7.Text = "ItemClasses"
      TreeNode8.ImageIndex = -2
      TreeNode8.Name = "ndSuppliers"
      TreeNode8.SelectedImageIndex = -2
      TreeNode8.Text = "Suppliers"
      Me.tvMain.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6, TreeNode7, TreeNode8})
      Me.tvMain.SelectedImageIndex = 0
      Me.tvMain.Size = New System.Drawing.Size(247, 357)
      Me.tvMain.TabIndex = 0
      '
      'cmtvMain
      '
      Me.cmtvMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmtvMainNew, Me.cmtvMainEdit, Me.cmtvMainRemove, Me.cmtvMainSepDelivery, Me.cmtvMainSendMail, Me.cmtvMainNewDelivery})
      Me.cmtvMain.Name = "cmtvMain"
      Me.cmtvMain.Size = New System.Drawing.Size(161, 120)
      '
      'cmtvMainNew
      '
      Me.cmtvMainNew.Name = "cmtvMainNew"
      Me.cmtvMainNew.Size = New System.Drawing.Size(160, 22)
      Me.cmtvMainNew.Text = "New..."
      '
      'cmtvMainEdit
      '
      Me.cmtvMainEdit.Name = "cmtvMainEdit"
      Me.cmtvMainEdit.Size = New System.Drawing.Size(160, 22)
      Me.cmtvMainEdit.Text = "Edit..."
      '
      'cmtvMainRemove
      '
      Me.cmtvMainRemove.Name = "cmtvMainRemove"
      Me.cmtvMainRemove.Size = New System.Drawing.Size(160, 22)
      Me.cmtvMainRemove.Text = "Remove..."
      '
      'cmtvMainSepDelivery
      '
      Me.cmtvMainSepDelivery.Name = "cmtvMainSepDelivery"
      Me.cmtvMainSepDelivery.Size = New System.Drawing.Size(157, 6)
      '
      'cmtvMainSendMail
      '
      Me.cmtvMainSendMail.Name = "cmtvMainSendMail"
      Me.cmtvMainSendMail.Size = New System.Drawing.Size(160, 22)
      Me.cmtvMainSendMail.Text = "Send Mail..."
      '
      'cmtvMainNewDelivery
      '
      Me.cmtvMainNewDelivery.Name = "cmtvMainNewDelivery"
      Me.cmtvMainNewDelivery.Size = New System.Drawing.Size(160, 22)
      Me.cmtvMainNewDelivery.Text = "New Delivery..."
      '
      'iltvMain
      '
      Me.iltvMain.ImageStream = CType(resources.GetObject("iltvMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.iltvMain.TransparentColor = System.Drawing.Color.Transparent
      Me.iltvMain.Images.SetKeyName(0, "Order")
      Me.iltvMain.Images.SetKeyName(1, "Order_red")
      Me.iltvMain.Images.SetKeyName(2, "Order_yellow")
      Me.iltvMain.Images.SetKeyName(3, "Order_green")
      Me.iltvMain.Images.SetKeyName(4, "OrderMail")
      Me.iltvMain.Images.SetKeyName(5, "OrderMail_red")
      Me.iltvMain.Images.SetKeyName(6, "OrderMail_yellow")
      Me.iltvMain.Images.SetKeyName(7, "OrderMail_green")
      Me.iltvMain.Images.SetKeyName(8, "HW")
      Me.iltvMain.Images.SetKeyName(9, "HW_red")
      Me.iltvMain.Images.SetKeyName(10, "HW_yellow")
      Me.iltvMain.Images.SetKeyName(11, "HW_green")
      Me.iltvMain.Images.SetKeyName(12, "SW")
      Me.iltvMain.Images.SetKeyName(13, "SW_red")
      Me.iltvMain.Images.SetKeyName(14, "SW_yellow")
      Me.iltvMain.Images.SetKeyName(15, "SW_green")
      Me.iltvMain.Images.SetKeyName(16, "NonIT")
      Me.iltvMain.Images.SetKeyName(17, "NonIT_red")
      Me.iltvMain.Images.SetKeyName(18, "NonIT_yellow")
      Me.iltvMain.Images.SetKeyName(19, "NonIT_green")
      Me.iltvMain.Images.SetKeyName(20, "Order_yellow")
      Me.iltvMain.Images.SetKeyName(21, "Order_green")
      Me.iltvMain.Images.SetKeyName(22, "Order_green.ico")
      Me.iltvMain.Images.SetKeyName(23, "Order_red.ico")
      '
      'mmOrderOrderedItems
      '
      Me.mmOrderOrderedItems.Name = "mmOrderOrderedItems"
      Me.mmOrderOrderedItems.Size = New System.Drawing.Size(173, 22)
      Me.mmOrderOrderedItems.Text = "OrderedItems..."
      '
      'ssMain
      '
      Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssMainLabel})
      Me.ssMain.Location = New System.Drawing.Point(0, 381)
      Me.ssMain.Name = "ssMain"
      Me.ssMain.Size = New System.Drawing.Size(743, 22)
      Me.ssMain.TabIndex = 3
      '
      'ssMainLabel
      '
      Me.ssMainLabel.AutoSize = False
      Me.ssMainLabel.Name = "ssMainLabel"
      Me.ssMainLabel.Size = New System.Drawing.Size(300, 17)
      '
      'frmMain
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(743, 403)
      Me.Controls.Add(Me.scMain)
      Me.Controls.Add(Me.mMain)
      Me.Controls.Add(Me.ssMain)
      Me.MainMenuStrip = Me.mMain
      Me.Name = "frmMain"
      Me.Text = "Order Process"
      CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
      Me.cmdgvMain.ResumeLayout(False)
      Me.mMain.ResumeLayout(False)
      Me.mMain.PerformLayout()
      Me.scMain.Panel1.ResumeLayout(False)
      Me.scMain.Panel2.ResumeLayout(False)
      Me.scMain.ResumeLayout(False)
      Me.cmtvMain.ResumeLayout(False)
      Me.ssMain.ResumeLayout(False)
      Me.ssMain.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dgvMain As System.Windows.Forms.DataGridView
   Friend WithEvents mMain As System.Windows.Forms.MenuStrip
   Friend WithEvents mmOrder As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmOrderNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmExit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmdgvMain As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents cmdgvMainEdit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents scMain As System.Windows.Forms.SplitContainer
   Friend WithEvents tvMain As System.Windows.Forms.TreeView
   Friend WithEvents cmdgvMainNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmdgvMainRemove As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmItemClass As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmItemClassNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMain As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents cmtvMainNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainEdit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainRemove As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmdgvMainDelivery As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmAccountingUnit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmAccountingUnitNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmDelivery As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmDeliveryNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainSepDelivery As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmtvMainNewDelivery As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmdgvMainSepDelivery As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmtvMainSendMail As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents iltvMain As System.Windows.Forms.ImageList
   Friend WithEvents mmOrderConfirmedItems As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmOrderOrderedItems As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ssMain As System.Windows.Forms.StatusStrip
   Friend WithEvents ssMainLabel As System.Windows.Forms.ToolStripStatusLabel
End Class
