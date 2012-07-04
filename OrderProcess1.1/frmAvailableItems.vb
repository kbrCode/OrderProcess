
Imports System.Runtime.CompilerServices

Module StringExtensions

    <Extension()>
    Public Function Contains(ByRef instance_handler As String, ByVal toCompare As String,
                             ByVal comparison As StringComparison) As Boolean
        Return instance_handler.IndexOf(toCompare, comparison) > -1
    End Function
End Module

Public Class frmAvailableItems
    Dim lstItems As List(Of Item)
    Dim locDB As OrderProcess
    Dim _dbAIMS As AIMSDataContext
    Dim lstDragItems As New List(Of Item)
    Private lvwColumnSorter As ListViewColumnSorter
    Private locIsClosed As Boolean
    Delegate Sub AddListItem()
    Public myDelegate As AddListItem
    Delegate Sub AddListItemEnd()
    Public myDelegateFinish As AddListItemEnd
    Private startListIdx As Integer
    Private endListIdx As Integer
    Private myThread As Thread
    Private loadingListFinished As Boolean
    Dim lstSelID As New List(Of Integer)
    Dim lastDragIndex As Integer = Nothing
    Dim bckColor As System.Windows.Media.SolidColorBrush = System.Windows.SystemColors.HighlightBrush
    Dim sysbackColor As System.Drawing.Color

    Private Sub searchBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles searchBox.TextChanged
        'FindItem()
    End Sub

    Private Sub FindItem()
        ' Call FindItemWithText with the contents of the textbox.
        Dim foundItem As ListViewItem = Nothing
        If (ColumnSearchCombo.SelectedIndex = 0 Or ignoreColumnsCheck.Checked) Then
            foundItem = lvMain.FindItemWithText(searchBox.Text, ignoreColumnsCheck.Checked, 0, True)
        Else
            Try
                Dim colText As String = lvMain.Columns(ColumnSearchCombo.SelectedIndex).Text
                If colText = "Description" Then
                    foundItem = (From it As ListViewItem In lvMain.Items Where
                 (String.IsNullOrEmpty(searchBox.Text) And String.IsNullOrEmpty(it.SubItems(ColumnSearchCombo.SelectedIndex).Text) Or
                                       (Not String.IsNullOrEmpty(searchBox.Text) And it.SubItems(ColumnSearchCombo.SelectedIndex).Text.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase)))
                                   Select it).First()
                Else
                    foundItem = (From it As ListViewItem In lvMain.Items Where
                 (String.IsNullOrEmpty(searchBox.Text) And String.IsNullOrEmpty(it.SubItems(ColumnSearchCombo.SelectedIndex).Text) Or
                                       (Not String.IsNullOrEmpty(searchBox.Text) And it.SubItems(ColumnSearchCombo.SelectedIndex).Text.StartsWith(searchBox.Text, StringComparison.OrdinalIgnoreCase)))
                                   Select it).First()
                End If
            Catch ex As Exception
                'item not found
            End Try

        End If

        lvMain.SelectedItems.Clear()
        If (foundItem IsNot Nothing) Then
            setupColumnsSort(ColumnSearchCombo.SelectedIndex, True)
            Me.lvMain.Sort()
            foundItem.Selected = True
            foundItem.EnsureVisible()
            'lvMain.EnsureVisible(foundItem.Index)
        End If
    End Sub

    Public Enum QUery
        assigned
        available
    End Enum
    Dim currentQuery As QUery

    Public Sub New(ByRef DB As OrderProcess, ByRef AIMS As AIMSDataContext, ByRef ItemList As List(Of Item), ByVal query As QUery)
        currentQuery = query
        locDB = DB
        _dbAIMS = AIMS
        lstItems = ItemList
        InitializeComponent()
        lvwColumnSorter = New ListViewColumnSorter
        lvMain.ListViewItemSorter = lvwColumnSorter
        lvMain.Scrollable = True
        myDelegate = New AddListItem(AddressOf AddListItemMethod)
        myDelegateFinish = New AddListItemEnd(AddressOf AddListItemFinishMethod)
    End Sub

    Public Property IsClosed() As Boolean
        Get
            Return locIsClosed
        End Get
        Set(ByVal value As Boolean)
            locIsClosed = value
        End Set
    End Property

    Private Sub frmAvailableItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadItems(currentQuery)
        ReadWindowState()
        locIsClosed = False
    End Sub

    Public Sub loadItems(ByVal query As QUery)
        Me.Cursor = Cursors.WaitCursor
        lvMain.Clear()
        ColumnSearchCombo.Items.Clear()
        'lvMain.Columns.Add("NO", 100, HorizontalAlignment.Left)

        lvMain.Columns.Add("ItemID", 100, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("ItemID")

        lvMain.Columns.Add("Description", 200, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("Description")

        lvMain.Columns.Add("Order", 60, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("Order")

        If Me.Tag = "AssignedItems" Then
            lvMain.Columns.Add("AssignmentDate", 80, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("AssignmentDate")

            lvMain.Columns.Add("Orderer", 100, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("Orderer")

            lvMain.Columns.Add("Recipient", 100, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("Recipient")

            lvMain.Columns.Add("CostCenter", 100, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("CostCenter")
        Else
            lvMain.Columns.Add("DeliveryDate", 80, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("DeliveryDate")

            lvMain.Columns.Add("Orderer", 100, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("Orderer")
        End If
        lvMain.Columns.Add("Price", 60, HorizontalAlignment.Right)
        ColumnSearchCombo.Items.Add("Price")
        lvMain.Columns.Add("ItemClass", 50, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("ItemClass")
        lvMain.Columns.Add("Category", 80, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("Category")
        If Me.Tag = "AssignedItems" Then
            lvMain.Columns.Add("AccountingUnit", 60, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("AccountingUnit")
        End If

        currentQuery = query
        Dim orderBy As String
        If (lvwColumnSorter.SortMethod Is Nothing) Then
            orderBy = "ItemID"
        Else
            orderBy = lvwColumnSorter.SortMethod
        End If
        lstItems = Nothing
        Dim qryGetAssignedItems As IQueryable(Of Item) = Nothing
        Select Case query
            Case query.assigned
                'qryGetAssignedItems = (From it As Item In locDB.Items Where (it.Accounting IsNot Nothing) Select it Order By orderBy).Skip(1000).Take(500)
                If (lvwColumnSorter.Order = SortOrder.Descending) Then
                    qryGetAssignedItems = (From it As Item In locDB.Items Where (it.Accounting IsNot Nothing) Select it Order By orderBy Descending)
                Else
                    qryGetAssignedItems = (From it As Item In locDB.Items Where (it.Accounting IsNot Nothing) Select it Order By orderBy)
                End If
            Case query.available
                If (lvwColumnSorter.Order = SortOrder.Descending) Then
                    qryGetAssignedItems = (From it As Item In locDB.Items Where (it.Accounting Is Nothing) Select it Order By orderBy Descending)
                Else
                    qryGetAssignedItems = (From it As Item In locDB.Items Where (it.Accounting Is Nothing) Select it Order By orderBy)
                End If
        End Select

        lstItems = qryGetAssignedItems.ToList
        loadingListFinished = False
        Me.Text = Me.Tag & " (" & lstItems.Count & ")"
        'fill first 800 records to satisfy user and buy some time for rest
        startListIdx = 0
        If (lstItems.Count < 800) Then
            endListIdx = lstItems.Count
        Else
            endListIdx = 800
        End If
        lvMain.BeginUpdate()
        AddListItemMethod()
        lvMain.EndUpdate()
        startListIdx = endListIdx
        endListIdx = -1
        If (startListIdx < lstItems.Count) Then
            myThread = New Thread(New ThreadStart(AddressOf ThreadFunction))
            myThread.Start()
        End If
    End Sub
    Private Sub ThreadFunction()
        Dim myThreadClassObject As New MyThreadClass(Me)
        myThreadClassObject.Run()
    End Sub 'ThreadFunction

    Private Sub WriteWindowState()
        Dim regShareKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\OfferProcess\" & Me.Tag, True)
        If regShareKey Is Nothing Then
            regShareKey = Registry.CurrentUser.CreateSubKey("Software\OfferProcess\" & Me.Tag)
        End If
        regShareKey.SetValue("LastWindowState", WindowState.ToString)
        If WindowState = FormWindowState.Maximized Or WindowState = FormWindowState.Minimized Then
            WindowState = FormWindowState.Normal
        End If
        regShareKey.SetValue("LastWidth", Width.ToString)
        regShareKey.SetValue("LastHeight", Height.ToString)
        regShareKey.SetValue("LastXPos", Left.ToString)
        regShareKey.SetValue("LastYPos", Top.ToString)
        If Me.Tag = "AssignedItems" Then
            regShareKey.SetValue("LastSearchAssigned", ColumnSearchCombo.SelectedIndex)
        Else
            regShareKey.SetValue("LastSearchAvailable", ColumnSearchCombo.SelectedIndex)
        End If
        regShareKey.SetValue("IgnoreColumnsCheck", ignoreColumnsCheck.Checked)
        regShareKey.Close()
    End Sub
    Private Sub ReadWindowState()
        Dim regShareKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\OfferProcess\" & Me.Tag, True)
        If Not (regShareKey Is Nothing) Then
            Width = regShareKey.GetValue("LastWidth", 800)
            Height = regShareKey.GetValue("LastHeight", 600)
            Left = regShareKey.GetValue("LastXPos", 0)
            Top = regShareKey.GetValue("LastYPos", 0)
            Dim pt As New Point(Left, Top)
            Dim ScreenBounds As Rectangle = Screen.GetBounds(pt)
            If (Left() < ScreenBounds.Left) Or (Left() > ScreenBounds.Left + ScreenBounds.Width - 50) Then
                Left = ScreenBounds.Left
            End If
            If (Top < ScreenBounds.Top) Or (Top > ScreenBounds.Top + ScreenBounds.Height - 50) Then
                Top = ScreenBounds.Top
            End If
            If regShareKey.GetValue("LastWindowState", "Normal") = "Maximized" Then
                WindowState = FormWindowState.Maximized
            ElseIf (regShareKey.GetValue("LastWindowState", "Normal") = "Minimized") Then
                WindowState = FormWindowState.Minimized
            End If
            If Me.Tag = "AssignedItems" Then
                ColumnSearchCombo.SelectedIndex = regShareKey.GetValue("LastSearchAssigned")
            Else
                ColumnSearchCombo.SelectedIndex = regShareKey.GetValue("LastSearchAvailable")
            End If
            ignoreColumnsCheck.Checked = regShareKey.GetValue("IgnoreColumnsCheck")
            regShareKey.Close()
            Update()
        End If
    End Sub

    Private Sub AddListItemFinishMethod()
        loadingListFinished = True
        restoreSelection()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AddListItemMethod()
        Dim endIdx As Integer

        If (endListIdx = -1) Then
            endIdx = lstItems.Count
        Else
            endIdx = endListIdx
        End If
        Dim thousand As Integer = 600
        Dim items As ArrayList = New ArrayList()

        For index = startListIdx To endIdx - 1
            Dim it = lstItems.Item(index)

            Dim lvit As New ListViewItem(it.ItemID)
            lvit.ImageKey = it.OrderItem.ItemClass.ShortID

            'lvit.SubItems.Add(index + 1)

            lvit.SubItems.Add(it.OrderItem.Description)
            lvit.SubItems.Add(it.OrderItem.Order.Nr)
            If Me.Tag = "AssignedItems" Then
                lvit.SubItems.Add(it.Accounting.ToString)
                If it.ConfirmedItem IsNot Nothing Then lvit.SubItems.Add(it.ConfirmedItem.Orderer) Else lvit.SubItems.Add("")
                lvit.SubItems.Add(it.Recipient)
                If it.ConfirmedItem IsNot Nothing Then lvit.SubItems.Add(it.ConfirmedItem.CostCenter) Else lvit.SubItems.Add("")
            Else
                lvit.SubItems.Add(it.Delivery.ToString)
                lvit.SubItems.Add(it.OrderItem.Order.Orderer.Name)
            End If
            lvit.SubItems.Add(it.Price.ToString("#####0.00"))
            lvit.SubItems.Add(it.OrderItem.OrderableItem.ItemClass.ShortID)
            lvit.SubItems.Add(it.OrderItem.OrderableItem.DeviceCategory)
            If Me.Tag = "AssignedItems" AndAlso it.AccountingUnit IsNot Nothing Then
                lvit.SubItems.Add(it.AccountingUnit.ShortID)
            Else
                lvit.SubItems.Add("")
            End If
            lvit.ToolTipText = it.Delivery.ToString
            lvit.Tag = it.ID

            If endListIdx = -1 Then
                If index > thousand + startListIdx + 600 Then
                    lvMain.Items.AddRange(items.ToArray(GetType(ListViewItem)))
                    lvMain.Update()
                    Me.Cursor = Cursors.WaitCursor
                    Thread.Sleep(500)
                    thousand = index + startListIdx
                    items = New ArrayList()
                Else
                    items.Add(lvit)
                End If
            Else
                lvMain.Items.Add(lvit)
            End If
        Next
        If (items IsNot Nothing And items.Count > 0) Then
            lvMain.Items.AddRange(items.ToArray(GetType(ListViewItem)))
            lvMain.Update()
            Me.Cursor = Cursors.WaitCursor
        End If
    End Sub

    Private Sub RefreshList(ByVal fromIdx As Integer, ByVal toIdx As Integer)

        'lstItems = ItemList
        'lvMain.Clear()
        '        lvMain.Columns.Add("ItemID", 100, HorizontalAlignment.Left)
        'lvMain.Columns.Add("Description", 200, HorizontalAlignment.Left)
        '        lvMain.Columns.Add("Order", 60, HorizontalAlignment.Left)
        '        If Me.Tag = "AssignedItems" Then
        'lvMain.Columns.Add("AssignmentDate", 80, HorizontalAlignment.Left)
        'lvMain.Columns.Add("Orderer", 100, HorizontalAlignment.Left)
        'lvMain.Columns.Add("Recipient", 100, HorizontalAlignment.Left)
        'lvMain.Columns.Add("CostCenter", 100, HorizontalAlignment.Left)
        'Else
        'lvMain.Columns.Add("DeliveryDate", 80, HorizontalAlignment.Left)
        'lvMain.Columns.Add("Orderer", 100, HorizontalAlignment.Left)
        'End If
        'lvMain.Columns.Add("Price", 60, HorizontalAlignment.Right)
        'lvMain.Columns.Add("ItemClass", 50, HorizontalAlignment.Left)
        'lvMain.Columns.Add("Category", 80, HorizontalAlignment.Left)
        'If Me.Tag = "AssignedItems" Then
        'lvMain.Columns.Add("AccountingUnit", 60, HorizontalAlignment.Left)
        'End If
        If (fromIdx = 0) Then
            lvMain.BeginUpdate()
        End If

        If (toIdx = -1) Then
            toIdx = lstItems.Count
        End If

        For index = 1 To 10
            Dim it = lstItems.Item(index)

            Dim lvit As New ListViewItem(it.ItemID)
            lvit.ImageKey = it.OrderItem.ItemClass.ShortID
            lvit.SubItems.Add(it.OrderItem.Description)
            lvit.SubItems.Add(it.OrderItem.Order.Nr)
            If Me.Tag = "AssignedItems" Then
                lvit.SubItems.Add(it.Accounting.ToString)
                If it.ConfirmedItem IsNot Nothing Then lvit.SubItems.Add(it.ConfirmedItem.Orderer) Else lvit.SubItems.Add("")
                lvit.SubItems.Add(it.Recipient)
                If it.ConfirmedItem IsNot Nothing Then lvit.SubItems.Add(it.ConfirmedItem.CostCenter) Else lvit.SubItems.Add("")
            Else
                lvit.SubItems.Add(it.Delivery.ToString)
                lvit.SubItems.Add(it.OrderItem.Order.Orderer.Name)
            End If
            lvit.SubItems.Add(it.Price.ToString("#####0.00"))
            lvit.SubItems.Add(it.OrderItem.OrderableItem.ItemClass.ShortID)
            lvit.SubItems.Add(it.OrderItem.OrderableItem.DeviceCategory)
            If Me.Tag = "AssignedItems" AndAlso it.AccountingUnit IsNot Nothing Then
                lvit.SubItems.Add(it.AccountingUnit.ShortID)
            Else
                lvit.SubItems.Add("")
            End If
            lvit.ToolTipText = it.Delivery.ToString
            lvit.Tag = it.ID
        Next

        'For Each it As Item In lstItems
        '    Dim lvit As New ListViewItem(it.ItemID)
        '    lvit.ImageKey = it.OrderItem.ItemClass.ShortID
        '    lvit.SubItems.Add(it.OrderItem.Description)
        '    lvit.SubItems.Add(it.OrderItem.Order.Nr)
        '    If Me.Tag = "AssignedItems" Then
        '        lvit.SubItems.Add(it.Accounting.ToString)
        '        If it.ConfirmedItem IsNot Nothing Then lvit.SubItems.Add(it.ConfirmedItem.Orderer) Else lvit.SubItems.Add("")
        '        lvit.SubItems.Add(it.Recipient)
        '        If it.ConfirmedItem IsNot Nothing Then lvit.SubItems.Add(it.ConfirmedItem.CostCenter) Else lvit.SubItems.Add("")
        '    Else
        '        lvit.SubItems.Add(it.Delivery.ToString)
        '        lvit.SubItems.Add(it.OrderItem.Order.Orderer.Name)
        '    End If
        '    lvit.SubItems.Add(it.Price.ToString("#####0.00"))
        '    lvit.SubItems.Add(it.OrderItem.OrderableItem.ItemClass.ShortID)
        '    lvit.SubItems.Add(it.OrderItem.OrderableItem.DeviceCategory)
        '    If Me.Tag = "AssignedItems" AndAlso it.AccountingUnit IsNot Nothing Then
        '        lvit.SubItems.Add(it.AccountingUnit.ShortID)
        '    Else
        '        lvit.SubItems.Add("")
        '    End If
        '    lvit.ToolTipText = it.Delivery.ToString
        '    lvit.Tag = it.ID
        '    lvMain.Items.Add(lvit)
        'Next
        If (fromIdx = 0) Then
            lvMain.EndUpdate()
        End If
    End Sub
    Public Class MyThreadClass
        Private myFormControl1 As frmAvailableItems

        Public Sub New(ByVal myForm As frmAvailableItems)
            myFormControl1 = myForm
        End Sub 'New

        Public Sub Run()
            ' Execute the specified delegate on the thread that owns
            ' 'myFormControl1' control's underlying window handle.
            myFormControl1.Invoke(myFormControl1.myDelegate)
            myFormControl1.Invoke(myFormControl1.myDelegateFinish)
        End Sub 'Run

    End Class 'MyThreadClass
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmAvailableItems_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If (myThread IsNot Nothing) Then
            myThread.Abort()
        End If
        WriteWindowState()
        locIsClosed = True
    End Sub

    Private Sub lvMain_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvMain.ItemDrag
        If Me.Tag = "AvailableItems" Or Me.Tag = "AssignedItems" Then
            frmMain.dragWindowName = Me.Tag
            lstDragItems.Clear()
            Dim comparer As New ItemPredicate(CInt(e.Item.Tag))
            Dim addDragItem As Item = lstItems.Find(AddressOf comparer.CompareIDs)
            If Not lstDragItems.Exists(AddressOf comparer.CompareIDs) Then
                If (addDragItem.AimsID IsNot Nothing) Or (addDragItem.OrderItem.OrderableItem.ItemClassID <> 2) Then
                    lstDragItems.Add(lstItems.Find(AddressOf comparer.CompareIDs))
                    frmMain.ssMainLabel.Text = ""
                Else
                    frmMain.ssMainLabel.Text = "This item has not been inventarized. Dragging is not possible."
                End If
            End If
            If lstDragItems.Count > 0 Then
                lvMain.DoDragDrop(lstDragItems, DragDropEffects.Copy)
            End If
        End If
    End Sub

    Private Sub moveItems(ByRef qryGetDroppItems As List(Of Item), ByRef objOrdItem As ConfirmedItem)
        Dim skipItem As Boolean = False
        Dim drgit As Item = Nothing

        For Each drgit In qryGetDroppItems
            moveItem(drgit, objOrdItem)
        Next
    End Sub

    Private Function moveItem(ByRef drgit As Item, ByRef objOrdItem As ConfirmedItem) As Boolean
        Try
            Dim message As String = Nothing
            If Not (objOrdItem Is Nothing) Then
                message = "Are you sure you want to move from " & objOrdItem.OrderableItem.Manufacturer & " item: " & drgit.ItemID &
                               " " & drgit.sDescription & " to available items ?"
            Else
                message = "Are you sure you want to move from " & " item: " & drgit.ItemID &
                               " " & drgit.sDescription & " to available items ?"
            End If

            If MessageBox.Show(message, "Moving elements",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
                Return False
            End If
            Dim objOrderItem As OrderItem = drgit.OrderItem
            Dim objOrder As Order = objOrderItem.Order

            If (drgit.OrderItem.OrderableItem.ItemClassID = 2) Then
                If Not (drgit.AimsID Is Nothing) Then
                    _dbAIMS.UnAssignUser(drgit.AimsID, drgit.Recipient, drgit.AccountingUnit.Besitzer)
                End If
            Else
                MessageBox.Show("ItemClassID:" & drgit.OrderItem.OrderableItem.ItemClassID.ToString, "ItemClassID", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            drgit.Recipient = Nothing
            drgit.Assigner = Nothing
            drgit.AccountingUnit = Nothing
            drgit.Accounting = Nothing

            If (drgit.ConfirmedItemID <> 0) Then
                objOrdItem.QuantityAssigned -= 1
                objOrdItem.QuantityOrdered -= 1
                drgit.ConfirmedItem = Nothing
                objOrdItem.DateOrdered = Nothing
                objOrdItem.DateAssigned = Nothing
            End If
            Return True
        Catch ex As MissingAIMSEntryException
            MessageBox.Show(ex.Message, "Missing AIMS Entry Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function


    Private Sub moveFromConfirmed(ByRef lstDragItems As List(Of Integer))
        For Each drgitID In lstDragItems
            Dim id As Integer = drgitID
            Dim objOrdItem As ConfirmedItem = (From confItem In locDB.ConfirmedItems Where (confItem.ID = id)).First()
            Dim qryGetDroppItems As IQueryable(Of Item) = (From it As Item In locDB.Items Where (it.ConfirmedItemID = objOrdItem.ID) Select it)
            If (qryGetDroppItems.Count() = 0) Then
                MessageBox.Show("Confirmed item:" & objOrdItem.OrderableItem.ManufacturerModel & " has no items to move", "Empty data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                moveItems(qryGetDroppItems.ToList(), objOrdItem)
            End If
        Next
        locDB.SubmitChanges()
        frmMain.RefreshAll()
    End Sub

    Private Sub moveFromAssigned(ByRef lstDragItems As List(Of Item))
        Dim lstDragItemsIDs As New List(Of Integer)
        For Each item As Item In lstDragItems
            moveItem(item, item.ConfirmedItem)
        Next
        locDB.SubmitChanges()
        frmMain.RefreshAll()
    End Sub

    Private Sub lvMain_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvMain.DragDrop, MyBase.DragDrop
        frmMain.dragWindowName = Nothing
        Dim Identity As WindowsIdentity
        Identity = WindowsIdentity.GetCurrent
        Dim dropPoint As New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = lvMain.PointToClient(dropPoint)
        Dim hitTstInfo As ListViewHitTestInfo = lvMain.HitTest(pt.X, pt.Y)
        If hitTstInfo.Location = ListViewHitTestLocations.Label Then
            Dim lvit As ListViewItem = hitTstInfo.Item
            Dim lstDragItemsIDs As List(Of Integer) = e.Data.GetData(GetType(List(Of Integer)))
            If Not lstDragItemsIDs Is Nothing Then
                moveFromConfirmed(lstDragItemsIDs)
            Else
                Dim lstDragItems As List(Of Item) = e.Data.GetData(GetType(List(Of Item)))
                If Not lstDragItems Is Nothing Then
                    moveFromAssigned(lstDragItems)
                End If
            End If
        Else
            MessageBox.Show("Location: " & hitTstInfo.Location.ToString, "HitTestInfo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub lvMain_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvMain.DragOver, MyBase.DragOver
        Dim lstDragItemsID As List(Of Integer) = e.Data.GetData(GetType(List(Of Integer)))
        Dim lstDragItems As List(Of Item) = e.Data.GetData(GetType(List(Of Item)))
        If (Not lstDragItems Is Nothing) Or Not (lstDragItemsID Is Nothing) Then
            If (Not frmMain.dragWindowName = Me.Tag) And (Not Me.Tag = "AssignedItems") Then 'cannot drop into same window but it can be assigned or available
                Dim ptClient As Point = lvMain.PointToClient(New Point(e.X, e.Y))
                Dim hitTest As ListViewHitTestInfo = lvMain.HitTest(ptClient)
                If Not hitTest.Item Is Nothing Then
                    e.Effect = DragDropEffects.Copy
                End If
            End If
        End If
    End Sub



    Private Sub keepSelection()
        lstSelID.Clear()
        Dim selCount As Integer = lvMain.SelectedItems.Count
        If selCount > 0 Then
            For Each slvit As ListViewItem In lvMain.SelectedItems
                lstSelID.Add(CInt(slvit.Tag))
            Next
        End If
    End Sub
    Private Sub restoreSelection()
        If lstSelID.Count > 0 Then
            For Each lvit As ListViewItem In lvMain.Items
                For Each ID As Integer In lstSelID
                    If CInt(lvit.Tag) = ID Then
                        lvit.Selected = True
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub setupColumnsSort(ByVal columnIdx As Integer, Optional ByVal ignoreSortOrder As Boolean = False)
        Dim colText As String = lvMain.Columns(columnIdx).Text
        If colText = "DeliveryDate" Or colText = "AssignmentDate" Then
            lvwColumnSorter.SortMethod = "Date"
        ElseIf colText = "Price" Then
            lvwColumnSorter.SortMethod = "Price"
        Else
            lvwColumnSorter.SortMethod = "Text"
        End If
        If (ignoreSortOrder = False) Then
            If (columnIdx = lvwColumnSorter.SortColumn) Then
                ' Reverse the current sort direction for this column.
                If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                    lvwColumnSorter.Order = SortOrder.Descending
                Else
                    lvwColumnSorter.Order = SortOrder.Ascending
                End If
            Else
                ' Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = columnIdx
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            lvwColumnSorter.SortColumn = columnIdx
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

    End Sub


    Private Sub lvMain_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMain.ColumnClick
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        keepSelection()
        setupColumnsSort(e.Column, True)
        ' Perform the sort with these new sort options.
        If loadingListFinished = True Then
            Me.lvMain.Sort()
            restoreSelection()
        Else
            loadItems(currentQuery)
        End If
    End Sub

    Private Sub cmlvMainCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmlvMainCopy.Click
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 0 To lvMain.Columns.Count - 1
            If i = 0 Then
                sb.Append(lvMain.Columns(i).Text)
            Else
                sb.Append(vbTab & lvMain.Columns(i).Text)
            End If
        Next
        sb.Append(vbCrLf)
        For Each lvit As ListViewItem In lvMain.SelectedItems
            For i As Integer = 0 To lvMain.Columns.Count - 1
                If i = 0 Then
                    sb.Append(lvit.SubItems(i).Text)
                Else
                    sb.Append(vbTab & lvit.SubItems(i).Text)
                End If
            Next
            sb.Append(vbCrLf)
        Next
        Clipboard.SetData(DataFormats.Text, sb.ToString)
    End Sub

    Private Sub lvMain_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMain.DoubleClick
        Dim lstSelectedItems As ListView.SelectedListViewItemCollection = lvMain.SelectedItems
        Dim refresh As Boolean = False
        For Each lvit As ListViewItem In lstSelectedItems
            Dim comparer As New ItemPredicate(CInt(lvit.Tag))
            Dim it As Item = lstItems.Find(AddressOf comparer.CompareIDs)
            If (frmMain.EditItem(it) = True) Then
                refresh = True
            End If
        Next
        If (refresh) Then
            loadItems(currentQuery)
        End If
    End Sub

    Private Sub ignoreColumnsCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ignoreColumnsCheck.CheckedChanged
        ColumnSearchCombo.Enabled = Not ignoreColumnsCheck.Checked
        FindItem()
    End Sub

    Private Sub ColumnSearchCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColumnSearchCombo.SelectedIndexChanged
        'FindItem()
    End Sub

    Private Sub searchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchButton.Click
        FindItem()
    End Sub
End Class