<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAvailableItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAvailableItems))
        Me.lvMain = New System.Windows.Forms.ListView()
        Me.cmlvMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmlvMainCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ilMain = New System.Windows.Forms.ImageList(Me.components)
        Me.searchBox = New System.Windows.Forms.TextBox()
        Me.ColumnSearchCombo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ignoreColumnsCheck = New System.Windows.Forms.CheckBox()
        Me.searchButton = New System.Windows.Forms.Button()
        Me.cmlvMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvMain
        '
        Me.lvMain.AllowColumnReorder = True
        Me.lvMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMain.ContextMenuStrip = Me.cmlvMain
        Me.lvMain.FullRowSelect = True
        Me.lvMain.HideSelection = False
        Me.lvMain.Location = New System.Drawing.Point(12, 30)
        Me.lvMain.Name = "lvMain"
        Me.lvMain.ShowItemToolTips = True
        Me.lvMain.Size = New System.Drawing.Size(675, 409)
        Me.lvMain.TabIndex = 3
        Me.lvMain.UseCompatibleStateImageBehavior = False
        Me.lvMain.View = System.Windows.Forms.View.Details
        '
        'cmlvMain
        '
        Me.cmlvMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmlvMainCopy})
        Me.cmlvMain.Name = "cmlvMain"
        Me.cmlvMain.Size = New System.Drawing.Size(142, 26)
        '
        'cmlvMainCopy
        '
        Me.cmlvMainCopy.Image = Global.OrderProcess1_1.My.Resources.Resources.Copy1
        Me.cmlvMainCopy.Name = "cmlvMainCopy"
        Me.cmlvMainCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.cmlvMainCopy.Size = New System.Drawing.Size(141, 22)
        Me.cmlvMainCopy.Text = "Copy"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Location = New System.Drawing.Point(612, 445)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ilMain
        '
        Me.ilMain.ImageStream = CType(resources.GetObject("ilMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilMain.TransparentColor = System.Drawing.Color.Transparent
        Me.ilMain.Images.SetKeyName(0, "HW")
        Me.ilMain.Images.SetKeyName(1, "NonIT")
        Me.ilMain.Images.SetKeyName(2, "SW")
        '
        'searchBox
        '
        Me.searchBox.Location = New System.Drawing.Point(62, 4)
        Me.searchBox.Name = "searchBox"
        Me.searchBox.Size = New System.Drawing.Size(300, 20)
        Me.searchBox.TabIndex = 5
        '
        'ColumnSearchCombo
        '
        Me.ColumnSearchCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ColumnSearchCombo.FormattingEnabled = True
        Me.ColumnSearchCombo.Location = New System.Drawing.Point(419, 3)
        Me.ColumnSearchCombo.Name = "ColumnSearchCombo"
        Me.ColumnSearchCombo.Size = New System.Drawing.Size(122, 21)
        Me.ColumnSearchCombo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Search:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(368, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Column:"
        '
        'ignoreColumnsCheck
        '
        Me.ignoreColumnsCheck.AutoSize = True
        Me.ignoreColumnsCheck.Location = New System.Drawing.Point(548, 6)
        Me.ignoreColumnsCheck.Name = "ignoreColumnsCheck"
        Me.ignoreColumnsCheck.Size = New System.Drawing.Size(126, 17)
        Me.ignoreColumnsCheck.TabIndex = 9
        Me.ignoreColumnsCheck.Text = "Search in all columns"
        Me.ignoreColumnsCheck.UseVisualStyleBackColor = True
        Me.ignoreColumnsCheck.Visible = False
        '
        'searchButton
        '
        Me.searchButton.Location = New System.Drawing.Point(548, 3)
        Me.searchButton.Name = "searchButton"
        Me.searchButton.Size = New System.Drawing.Size(139, 21)
        Me.searchButton.TabIndex = 10
        Me.searchButton.Text = "Search"
        Me.searchButton.UseVisualStyleBackColor = True
        '
        'frmAvailableItems
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 480)
        Me.Controls.Add(Me.searchButton)
        Me.Controls.Add(Me.ignoreColumnsCheck)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ColumnSearchCombo)
        Me.Controls.Add(Me.searchBox)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lvMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAvailableItems"
        Me.Tag = "AvailableItems"
        Me.Text = "Available Items"
        Me.cmlvMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvMain As System.Windows.Forms.ListView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ilMain As System.Windows.Forms.ImageList
    Friend WithEvents cmlvMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmlvMainCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents searchBox As System.Windows.Forms.TextBox
    Friend WithEvents ColumnSearchCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ignoreColumnsCheck As System.Windows.Forms.CheckBox
    Friend WithEvents searchButton As System.Windows.Forms.Button
End Class
