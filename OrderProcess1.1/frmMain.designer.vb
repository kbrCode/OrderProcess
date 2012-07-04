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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
      Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orders")
      Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("AccountingUnits")
      Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ItemClasses")
      Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Orderer")
      Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Suppliers")
      Me.dgvMain = New System.Windows.Forms.DataGridView
      Me.cmdgvMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.cmdgvMainNew = New System.Windows.Forms.ToolStripMenuItem
      Me.cmdgvMainEdit = New System.Windows.Forms.ToolStripMenuItem
      Me.cmdgvMainRemove = New System.Windows.Forms.ToolStripMenuItem
      Me.cmdgvMainSepDelivery = New System.Windows.Forms.ToolStripSeparator
      Me.cmdgvMainDelivery = New System.Windows.Forms.ToolStripMenuItem
      Me.mMain = New System.Windows.Forms.MenuStrip
      Me.mmFile = New System.Windows.Forms.ToolStripMenuItem
      Me.mmFileNewOrder = New System.Windows.Forms.ToolStripMenuItem
      Me.mmFileNewAccountingUnit = New System.Windows.Forms.ToolStripMenuItem
      Me.mmFileNewItemClass = New System.Windows.Forms.ToolStripMenuItem
      Me.mmFileNewOrderer = New System.Windows.Forms.ToolStripMenuItem
      Me.mmFileNewSupplier = New System.Windows.Forms.ToolStripMenuItem
      Me.mmFileExit = New System.Windows.Forms.ToolStripMenuItem
      Me.mmEdit = New System.Windows.Forms.ToolStripMenuItem
      Me.mmDeliveryNew = New System.Windows.Forms.ToolStripMenuItem
      Me.mmEditNewConfirmedItem = New System.Windows.Forms.ToolStripMenuItem
      Me.mmView = New System.Windows.Forms.ToolStripMenuItem
      Me.mmViewAssignedItems = New System.Windows.Forms.ToolStripMenuItem
      Me.mmViewAvailableItems = New System.Windows.Forms.ToolStripMenuItem
      Me.mmViewConfirmedItems = New System.Windows.Forms.ToolStripMenuItem
      Me.mmViewOrderedItems = New System.Windows.Forms.ToolStripMenuItem
      Me.mmViewHideCompletedOrders = New System.Windows.Forms.ToolStripMenuItem
      Me.mmViewRefresh = New System.Windows.Forms.ToolStripMenuItem
      Me.mmReport = New System.Windows.Forms.ToolStripMenuItem
      Me.mmReportNew = New System.Windows.Forms.ToolStripMenuItem
      Me.ExtrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.mmMainDetConfItemIDs = New System.Windows.Forms.ToolStripMenuItem
      Me.mmHelp = New System.Windows.Forms.ToolStripMenuItem
      Me.mmHelpAbout = New System.Windows.Forms.ToolStripMenuItem
      Me.scMain = New System.Windows.Forms.SplitContainer
      Me.tvMain = New System.Windows.Forms.TreeView
      Me.cmtvMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.cmtvMainNew = New System.Windows.Forms.ToolStripMenuItem
      Me.cmtvMainEdit = New System.Windows.Forms.ToolStripMenuItem
      Me.cmtvMainRemove = New System.Windows.Forms.ToolStripMenuItem
      Me.cmtvMainSepDelivery = New System.Windows.Forms.ToolStripSeparator
      Me.cmtvMainSendMail = New System.Windows.Forms.ToolStripMenuItem
      Me.cmtvMainFinalize = New System.Windows.Forms.ToolStripMenuItem
      Me.cmtvMainNewDelivery = New System.Windows.Forms.ToolStripMenuItem
      Me.iltvMain = New System.Windows.Forms.ImageList(Me.components)
      Me.ssMain = New System.Windows.Forms.StatusStrip
      Me.ssMainLabel = New System.Windows.Forms.ToolStripStatusLabel
      Me.niOrderProcess = New System.Windows.Forms.NotifyIcon(Me.components)
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
      Me.dgvMain.AllowUserToOrderColumns = True
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvMain.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvMain.ContextMenuStrip = Me.cmdgvMain
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvMain.DefaultCellStyle = DataGridViewCellStyle2
      Me.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvMain.Location = New System.Drawing.Point(0, 0)
      Me.dgvMain.Name = "dgvMain"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvMain.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
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
      Me.mMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmFile, Me.mmEdit, Me.mmView, Me.mmReport, Me.ExtrasToolStripMenuItem, Me.mmHelp})
      Me.mMain.Location = New System.Drawing.Point(0, 0)
      Me.mMain.Name = "mMain"
      Me.mMain.Size = New System.Drawing.Size(743, 24)
      Me.mMain.TabIndex = 1
      Me.mMain.Text = "MenuStrip1"
      '
      'mmFile
      '
      Me.mmFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmFileNewOrder, Me.mmFileNewAccountingUnit, Me.mmFileNewItemClass, Me.mmFileNewOrderer, Me.mmFileNewSupplier, Me.mmFileExit})
      Me.mmFile.Name = "mmFile"
      Me.mmFile.Size = New System.Drawing.Size(35, 20)
      Me.mmFile.Text = "File"
      '
      'mmFileNewOrder
      '
      Me.mmFileNewOrder.Image = CType(resources.GetObject("mmFileNewOrder.Image"), System.Drawing.Image)
      Me.mmFileNewOrder.Name = "mmFileNewOrder"
      Me.mmFileNewOrder.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
      Me.mmFileNewOrder.Size = New System.Drawing.Size(193, 22)
      Me.mmFileNewOrder.Text = "New Order..."
      '
      'mmFileNewAccountingUnit
      '
      Me.mmFileNewAccountingUnit.Image = CType(resources.GetObject("mmFileNewAccountingUnit.Image"), System.Drawing.Image)
      Me.mmFileNewAccountingUnit.Name = "mmFileNewAccountingUnit"
      Me.mmFileNewAccountingUnit.Size = New System.Drawing.Size(193, 22)
      Me.mmFileNewAccountingUnit.Text = "New AccountingUnit..."
      '
      'mmFileNewItemClass
      '
      Me.mmFileNewItemClass.Image = CType(resources.GetObject("mmFileNewItemClass.Image"), System.Drawing.Image)
      Me.mmFileNewItemClass.Name = "mmFileNewItemClass"
      Me.mmFileNewItemClass.Size = New System.Drawing.Size(193, 22)
      Me.mmFileNewItemClass.Text = "New ItemClass..."
      '
      'mmFileNewOrderer
      '
      Me.mmFileNewOrderer.Image = CType(resources.GetObject("mmFileNewOrderer.Image"), System.Drawing.Image)
      Me.mmFileNewOrderer.Name = "mmFileNewOrderer"
      Me.mmFileNewOrderer.Size = New System.Drawing.Size(193, 22)
      Me.mmFileNewOrderer.Text = "New Orderer..."
      '
      'mmFileNewSupplier
      '
      Me.mmFileNewSupplier.Image = CType(resources.GetObject("mmFileNewSupplier.Image"), System.Drawing.Image)
      Me.mmFileNewSupplier.Name = "mmFileNewSupplier"
      Me.mmFileNewSupplier.Size = New System.Drawing.Size(193, 22)
      Me.mmFileNewSupplier.Text = "New Supplier..."
      '
      'mmFileExit
      '
      Me.mmFileExit.Image = CType(resources.GetObject("mmFileExit.Image"), System.Drawing.Image)
      Me.mmFileExit.Name = "mmFileExit"
      Me.mmFileExit.Size = New System.Drawing.Size(193, 22)
      Me.mmFileExit.Text = "Exit"
      '
      'mmEdit
      '
      Me.mmEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmDeliveryNew, Me.mmEditNewConfirmedItem})
      Me.mmEdit.Name = "mmEdit"
      Me.mmEdit.Size = New System.Drawing.Size(37, 20)
      Me.mmEdit.Text = "Edit"
      '
      'mmDeliveryNew
      '
      Me.mmDeliveryNew.Enabled = False
      Me.mmDeliveryNew.Image = CType(resources.GetObject("mmDeliveryNew.Image"), System.Drawing.Image)
      Me.mmDeliveryNew.Name = "mmDeliveryNew"
      Me.mmDeliveryNew.Size = New System.Drawing.Size(192, 22)
      Me.mmDeliveryNew.Text = "New Delivery..."
      '
      'mmEditNewConfirmedItem
      '
      Me.mmEditNewConfirmedItem.Image = CType(resources.GetObject("mmEditNewConfirmedItem.Image"), System.Drawing.Image)
      Me.mmEditNewConfirmedItem.Name = "mmEditNewConfirmedItem"
      Me.mmEditNewConfirmedItem.Size = New System.Drawing.Size(192, 22)
      Me.mmEditNewConfirmedItem.Text = "New ConfirmedItem..."
      '
      'mmView
      '
      Me.mmView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmViewAssignedItems, Me.mmViewAvailableItems, Me.mmViewConfirmedItems, Me.mmViewOrderedItems, Me.mmViewHideCompletedOrders, Me.mmViewRefresh})
      Me.mmView.Name = "mmView"
      Me.mmView.Size = New System.Drawing.Size(41, 20)
      Me.mmView.Text = "View"
      '
      'mmViewAssignedItems
      '
      Me.mmViewAssignedItems.Image = Global.OrderProcess1_1.My.Resources.Resources.HW
      Me.mmViewAssignedItems.Name = "mmViewAssignedItems"
      Me.mmViewAssignedItems.Size = New System.Drawing.Size(196, 22)
      Me.mmViewAssignedItems.Text = "Assigned Items..."
      '
      'mmViewAvailableItems
      '
      Me.mmViewAvailableItems.Image = CType(resources.GetObject("mmViewAvailableItems.Image"), System.Drawing.Image)
      Me.mmViewAvailableItems.Name = "mmViewAvailableItems"
      Me.mmViewAvailableItems.Size = New System.Drawing.Size(196, 22)
      Me.mmViewAvailableItems.Text = "Available Items..."
      '
      'mmViewConfirmedItems
      '
      Me.mmViewConfirmedItems.Image = CType(resources.GetObject("mmViewConfirmedItems.Image"), System.Drawing.Image)
      Me.mmViewConfirmedItems.Name = "mmViewConfirmedItems"
      Me.mmViewConfirmedItems.Size = New System.Drawing.Size(196, 22)
      Me.mmViewConfirmedItems.Text = "Confirmed Items..."
      '
      'mmViewOrderedItems
      '
      Me.mmViewOrderedItems.Image = CType(resources.GetObject("mmViewOrderedItems.Image"), System.Drawing.Image)
      Me.mmViewOrderedItems.Name = "mmViewOrderedItems"
      Me.mmViewOrderedItems.Size = New System.Drawing.Size(196, 22)
      Me.mmViewOrderedItems.Text = "Ordered Items..."
      '
      'mmViewHideCompletedOrders
      '
      Me.mmViewHideCompletedOrders.CheckOnClick = True
      Me.mmViewHideCompletedOrders.Name = "mmViewHideCompletedOrders"
      Me.mmViewHideCompletedOrders.Size = New System.Drawing.Size(196, 22)
      Me.mmViewHideCompletedOrders.Text = "Hide Completed Orders"
      '
      'mmViewRefresh
      '
      Me.mmViewRefresh.Name = "mmViewRefresh"
      Me.mmViewRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
      Me.mmViewRefresh.Size = New System.Drawing.Size(196, 22)
      Me.mmViewRefresh.Text = "Refresh"
      '
      'mmReport
      '
      Me.mmReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmReportNew})
      Me.mmReport.Name = "mmReport"
      Me.mmReport.Size = New System.Drawing.Size(52, 20)
      Me.mmReport.Text = "Report"
      '
      'mmReportNew
      '
      Me.mmReportNew.Image = CType(resources.GetObject("mmReportNew.Image"), System.Drawing.Image)
      Me.mmReportNew.Name = "mmReportNew"
      Me.mmReportNew.Size = New System.Drawing.Size(118, 22)
      Me.mmReportNew.Text = "New..."
      '
      'ExtrasToolStripMenuItem
      '
      Me.ExtrasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmMainDetConfItemIDs})
      Me.ExtrasToolStripMenuItem.Enabled = False
      Me.ExtrasToolStripMenuItem.Name = "ExtrasToolStripMenuItem"
      Me.ExtrasToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
      Me.ExtrasToolStripMenuItem.Text = "Extras"
      Me.ExtrasToolStripMenuItem.Visible = False
      '
      'mmMainDetConfItemIDs
      '
      Me.mmMainDetConfItemIDs.Name = "mmMainDetConfItemIDs"
      Me.mmMainDetConfItemIDs.Size = New System.Drawing.Size(224, 22)
      Me.mmMainDetConfItemIDs.Text = "Determine ConfirmedItemIDs"
      '
      'mmHelp
      '
      Me.mmHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmHelpAbout})
      Me.mmHelp.Name = "mmHelp"
      Me.mmHelp.Size = New System.Drawing.Size(40, 20)
      Me.mmHelp.Text = "Help"
      '
      'mmHelpAbout
      '
      Me.mmHelpAbout.Name = "mmHelpAbout"
      Me.mmHelpAbout.Size = New System.Drawing.Size(126, 22)
      Me.mmHelpAbout.Text = "About..."
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
      TreeNode1.ImageKey = "OrderNew"
      TreeNode1.Name = "ndOrders"
      TreeNode1.SelectedImageKey = "OrderNew"
      TreeNode1.Text = "Orders"
      TreeNode2.ImageKey = "AccountingUnit"
      TreeNode2.Name = "ndAccountingUnits"
      TreeNode2.SelectedImageKey = "AccountingUnit"
      TreeNode2.Text = "AccountingUnits"
      TreeNode3.ImageKey = "ItemClass"
      TreeNode3.Name = "ndItemClasses"
      TreeNode3.SelectedImageKey = "ItemClass"
      TreeNode3.Text = "ItemClasses"
      TreeNode4.ImageKey = "Orderer"
      TreeNode4.Name = "ndOrderers"
      TreeNode4.SelectedImageKey = "Orderer"
      TreeNode4.Text = "Orderer"
      TreeNode5.ImageKey = "Supplier"
      TreeNode5.Name = "ndSuppliers"
      TreeNode5.SelectedImageKey = "Supplier"
      TreeNode5.Text = "Suppliers"
      Me.tvMain.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5})
      Me.tvMain.SelectedImageIndex = 0
      Me.tvMain.ShowNodeToolTips = True
      Me.tvMain.Size = New System.Drawing.Size(247, 357)
      Me.tvMain.TabIndex = 0
      '
      'cmtvMain
      '
      Me.cmtvMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmtvMainNew, Me.cmtvMainEdit, Me.cmtvMainRemove, Me.cmtvMainSepDelivery, Me.cmtvMainSendMail, Me.cmtvMainFinalize, Me.cmtvMainNewDelivery})
      Me.cmtvMain.Name = "cmtvMain"
      Me.cmtvMain.Size = New System.Drawing.Size(200, 142)
      '
      'cmtvMainNew
      '
      Me.cmtvMainNew.Name = "cmtvMainNew"
      Me.cmtvMainNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
      Me.cmtvMainNew.Size = New System.Drawing.Size(199, 22)
      Me.cmtvMainNew.Text = "New..."
      '
      'cmtvMainEdit
      '
      Me.cmtvMainEdit.Name = "cmtvMainEdit"
      Me.cmtvMainEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
      Me.cmtvMainEdit.Size = New System.Drawing.Size(199, 22)
      Me.cmtvMainEdit.Text = "Edit..."
      '
      'cmtvMainRemove
      '
      Me.cmtvMainRemove.Name = "cmtvMainRemove"
      Me.cmtvMainRemove.ShortcutKeys = System.Windows.Forms.Keys.Delete
      Me.cmtvMainRemove.Size = New System.Drawing.Size(199, 22)
      Me.cmtvMainRemove.Text = "Remove..."
      '
      'cmtvMainSepDelivery
      '
      Me.cmtvMainSepDelivery.Name = "cmtvMainSepDelivery"
      Me.cmtvMainSepDelivery.Size = New System.Drawing.Size(196, 6)
      '
      'cmtvMainSendMail
      '
      Me.cmtvMainSendMail.Name = "cmtvMainSendMail"
      Me.cmtvMainSendMail.Size = New System.Drawing.Size(199, 22)
      Me.cmtvMainSendMail.Text = "Send Mail"
      '
      'cmtvMainFinalize
      '
      Me.cmtvMainFinalize.Name = "cmtvMainFinalize"
      Me.cmtvMainFinalize.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
      Me.cmtvMainFinalize.Size = New System.Drawing.Size(199, 22)
      Me.cmtvMainFinalize.Text = "Finalize..."
      '
      'cmtvMainNewDelivery
      '
      Me.cmtvMainNewDelivery.Name = "cmtvMainNewDelivery"
      Me.cmtvMainNewDelivery.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
      Me.cmtvMainNewDelivery.Size = New System.Drawing.Size(199, 22)
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
      Me.iltvMain.Images.SetKeyName(8, "HW_red")
      Me.iltvMain.Images.SetKeyName(9, "HW_yellow")
      Me.iltvMain.Images.SetKeyName(10, "HW_green")
      Me.iltvMain.Images.SetKeyName(11, "SW")
      Me.iltvMain.Images.SetKeyName(12, "SW_red")
      Me.iltvMain.Images.SetKeyName(13, "SW_yellow")
      Me.iltvMain.Images.SetKeyName(14, "SW_green")
      Me.iltvMain.Images.SetKeyName(15, "NonIT_red")
      Me.iltvMain.Images.SetKeyName(16, "NonIT_yellow")
      Me.iltvMain.Images.SetKeyName(17, "NonIT_green")
      Me.iltvMain.Images.SetKeyName(18, "Order_yellow")
      Me.iltvMain.Images.SetKeyName(19, "Order_green")
      Me.iltvMain.Images.SetKeyName(20, "OrderNew")
      Me.iltvMain.Images.SetKeyName(21, "AccountingUnit")
      Me.iltvMain.Images.SetKeyName(22, "ItemClass")
      Me.iltvMain.Images.SetKeyName(23, "Supplier")
      Me.iltvMain.Images.SetKeyName(24, "NonIT")
      Me.iltvMain.Images.SetKeyName(25, "HW")
      Me.iltvMain.Images.SetKeyName(26, "SW")
      Me.iltvMain.Images.SetKeyName(27, "Order--")
      Me.iltvMain.Images.SetKeyName(28, "Ordern-")
      Me.iltvMain.Images.SetKeyName(29, "Ordery-")
      Me.iltvMain.Images.SetKeyName(30, "Ordery-")
      Me.iltvMain.Images.SetKeyName(31, "Orderyn")
      Me.iltvMain.Images.SetKeyName(32, "Orderyy")
      Me.iltvMain.Images.SetKeyName(33, "HWgreen")
      Me.iltvMain.Images.SetKeyName(34, "Orderer")
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
      Me.ssMainLabel.Name = "ssMainLabel"
      Me.ssMainLabel.Size = New System.Drawing.Size(0, 17)
      '
      'niOrderProcess
      '
      Me.niOrderProcess.Icon = CType(resources.GetObject("niOrderProcess.Icon"), System.Drawing.Icon)
      Me.niOrderProcess.Text = "OrderProcess"
      '
      'frmMain
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(743, 403)
      Me.Controls.Add(Me.scMain)
      Me.Controls.Add(Me.mMain)
      Me.Controls.Add(Me.ssMain)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
   Friend WithEvents mmFile As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmFileNewOrder As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmFileExit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmdgvMain As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents cmdgvMainEdit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents scMain As System.Windows.Forms.SplitContainer
   Friend WithEvents tvMain As System.Windows.Forms.TreeView
   Friend WithEvents cmdgvMainNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmdgvMainRemove As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmView As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMain As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents cmtvMainNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainEdit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainRemove As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmdgvMainDelivery As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmEdit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainSepDelivery As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmtvMainNewDelivery As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmdgvMainSepDelivery As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmtvMainFinalize As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents iltvMain As System.Windows.Forms.ImageList
   Friend WithEvents ssMain As System.Windows.Forms.StatusStrip
   Friend WithEvents ssMainLabel As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents mmReport As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmReportNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmFileNewAccountingUnit As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmFileNewItemClass As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmFileNewOrderer As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmFileNewSupplier As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmDeliveryNew As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmViewAvailableItems As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmViewConfirmedItems As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmViewOrderedItems As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmViewHideCompletedOrders As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmHelp As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmHelpAbout As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents niOrderProcess As System.Windows.Forms.NotifyIcon
   Friend WithEvents mmViewRefresh As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmEditNewConfirmedItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cmtvMainSendMail As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmViewAssignedItems As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ExtrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mmMainDetConfItemIDs As System.Windows.Forms.ToolStripMenuItem
End Class
