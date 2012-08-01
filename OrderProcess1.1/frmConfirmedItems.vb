Public Class frmConfirmedItems
   Dim lstItems As List(Of ConfirmedItem) = Nothing
   Dim _dbOrderProcess As OrderProcess
   Dim _dbAIMS As AIMSDataContext
    Dim lstDragItems As New List(Of Integer)
    'Dim lstDragItems As New List(Of Item)
   Dim firstMouseDown As Boolean = True
   Private lvwColumnSorter As ListViewColumnSorter
   Dim locIsClosed As Boolean
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
        If (ignoreColumnsCheck.Checked) Then
            foundItem = lvMain.FindItemWithText(searchBox.Text, ignoreColumnsCheck.Checked, 0, True)
        Else
            Try
                Dim colText As String = lvMain.Columns(ColumnSearchCombo.SelectedIndex).Text
                If colText = "Description" Or colText = "ManufacturerModel" Then
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
        End If
    End Sub

   Public Sub New(ByRef DB As OrderProcess, ByRef AIMS As AIMSDataContext, ByRef ItemList As List(Of ConfirmedItem))
      _dbOrderProcess = DB
      _dbAIMS = AIMS
      lstItems = ItemList
      InitializeComponent()
      lvwColumnSorter = New ListViewColumnSorter()
      lvMain.ListViewItemSorter = lvwColumnSorter
        sysbackColor = Color.FromArgb(bckColor.Color.A, bckColor.Color.R, bckColor.Color.G, bckColor.Color.B)
    End Sub

   Public Property IsClosed() As Boolean
      Get
         Return locIsClosed
      End Get
      Set(ByVal value As Boolean)
         locIsClosed = value
      End Set
   End Property

   Private Sub frmOrderedItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      RefreshList(lstItems)
      ReadWindowState()
      cmtvMainNewConfirmedItem.Visible = False
      cmtvMainOpenNotesOrder.Visible = False
      locIsClosed = False
   End Sub

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
        ElseIf Me.Tag = "ConfirmedItems" Then
            regShareKey.SetValue("LastSearchConfirmed", ColumnSearchCombo.SelectedIndex)
        Else
            regShareKey.SetValue("LastSearchOrdered", ColumnSearchCombo.SelectedIndex)
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
         If (Left < ScreenBounds.Left) Or (Left > ScreenBounds.Left + ScreenBounds.Width - 50) Then
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
            ElseIf Me.Tag = "ConfirmedItems" Then
                ColumnSearchCombo.SelectedIndex = regShareKey.GetValue("LastSearchConfirmed")
            Else
                ColumnSearchCombo.SelectedIndex = regShareKey.GetValue("LastSearchOrdered")
            End If

            ignoreColumnsCheck.Checked = regShareKey.GetValue("IgnoreColumnsCheck")
            regShareKey.Close()
            Update()
        End If
   End Sub

   Public Sub RefreshList(ByVal ItemList As List(Of ConfirmedItem))
      lstItems = ItemList
        lvMain.Clear()
        ColumnSearchCombo.Items.Clear()

        'lvMain.Columns.Add("itemID", 150)
        'ColumnSearchCombo.Items.Add("itemID")

        lvMain.Columns.Add("ManufacturerModel", 150)
        ColumnSearchCombo.Items.Add("ManufacturerModel")
      If Me.Tag = "OrderedItems" Then
            lvMain.Columns.Add("Order", 60, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("Order")
      ElseIf Me.Tag = "ConfirmedItems" Then
            lvMain.Columns.Add("Supplier", 60, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("Supplier")
      ElseIf Me.Tag = "AssignedItems" Then
            lvMain.Columns.Add("Assigned", 70, HorizontalAlignment.Left)
            ColumnSearchCombo.Items.Add("Assigned")
      End If
        lvMain.Columns.Add("Quantity", 50, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("Quantity")
        lvMain.Columns.Add("Orderer", 100, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("Orderer")
        lvMain.Columns.Add("Recipient", 100, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("Recipient")
        lvMain.Columns.Add("AccountingUnit", 40, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("AccountingUnit")
        lvMain.Columns.Add("CostCenter", 50, HorizontalAlignment.Left)
        ColumnSearchCombo.Items.Add("CostCenter")
      lvMain.BeginUpdate()
        For Each confit As ConfirmedItem In lstItems

            'Dim lvit As New ListViewItem(confit.ID)
            'lvit.SubItems.Add(confit.OrderableItem.ManufacturerModel)

            Dim lvit As New ListViewItem(confit.OrderableItem.ManufacturerModel)
            lvit.ImageKey = confit.OrderableItem.ItemClass.ShortID
            lvit.ToolTipText = confit.DateConfirmed.ToString
            If Me.Tag = "OrderedItems" Then
                lvit.SubItems.Add(confit.OrderItem.Order.Nr)
                lvit.ToolTipText = confit.DateOrdered.ToString
            ElseIf Me.Tag = "ConfirmedItems" Then
                lvit.SubItems.Add(confit.OrderableItem.Supplier.ShortID)
                lvit.ToolTipText = confit.DateConfirmed.ToString
            ElseIf Me.Tag = "AssignedItems" Then
                lvit.SubItems.Add(confit.DateAssigned)
                lvit.ToolTipText = confit.DateAssigned.ToString
            End If
            If Me.Tag = "AssignedItems" Then
                lvit.SubItems.Add(confit.QuantityAssigned.ToString)
            Else
                If confit.QuantityAssigned.HasValue Then
                    lvit.SubItems.Add((confit.QuantityOrdered - confit.QuantityAssigned).ToString)
                Else
                    lvit.SubItems.Add(confit.QuantityOrdered.ToString)
                End If
            End If
            lvit.SubItems.Add(TrimName(confit.Orderer))
            lvit.SubItems.Add(TrimName(confit.RecipientName))
            lvit.SubItems.Add(confit.AccountingUnit.ShortID)
            lvit.SubItems.Add(confit.CostCenter)
            lvit.Tag = confit.ID
            lvMain.Items.Add(lvit)
        Next
      lvMain.EndUpdate()
      Me.Text = Me.Tag & " (" & lstItems.Count.ToString & ")"
   End Sub

   Private Function TrimName(ByVal Name As String) As String
      If Name Is Nothing Then
         Return ""
      ElseIf Name.IndexOf("/") < 0 Then
         Return Name
      Else
         Return Name.Substring(0, Name.IndexOf("/"))
      End If
    End Function

    Private Sub lvMain_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvMain.ItemDrag
        If Me.Tag = "ConfirmedItems" Then
            lstDragItems.Clear()
            frmMain.dragWindowName = Me.Tag
            For Each it As ListViewItem In lvMain.SelectedItems
                Dim comparer As New ListItemPredicate(CInt(it.Tag))
                If Not lstDragItems.Exists(AddressOf comparer.CompareTag) Then
                    lstDragItems.Add(it.Tag)
                End If
            Next
            lvMain.DoDragDrop(lstDragItems, DragDropEffects.Copy)
        End If
    End Sub


    Private Sub lvMain_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvMain.DragDrop, MyBase.DragDrop
        Dim Identity As WindowsIdentity
        Identity = WindowsIdentity.GetCurrent
        Dim dropPoint As New Drawing.Point(e.X, e.Y)
        Dim pt As Drawing.Point = lvMain.PointToClient(dropPoint)
        Dim hitTstInfo As ListViewHitTestInfo = lvMain.HitTest(pt.X, pt.Y)
        If hitTstInfo.Location = ListViewHitTestLocations.Label Then
            Dim lvit As ListViewItem = hitTstInfo.Item
            Dim cicomparer As New ConfirmedItemPredicate(CInt(lvit.Tag))
            Dim objOrdItem As ConfirmedItem = lstItems.Find(AddressOf cicomparer.CompareIDs)
            Dim lstDragItems As List(Of Item) = e.Data.GetData(GetType(List(Of Item)))
            Dim QuantityMissing As Integer
            If objOrdItem.QuantityAssigned.HasValue Then
                QuantityMissing = objOrdItem.QuantityOrdered - objOrdItem.QuantityAssigned
            Else
                QuantityMissing = objOrdItem.QuantityOrdered
            End If
            If QuantityMissing < lstDragItems.Count Then
                MessageBox.Show("Too many items. Please drag and drop no more than " & QuantityMissing & " items", "Too many items", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                For Each drgit As Item In lstDragItems
                    Try
                        Dim skipItem As Boolean = False
                        If Not (objOrdItem.OrderableItemsID = drgit.OrderItem.OrderableItemsID) Then
                            If MessageBox.Show("The IDs of " & objOrdItem.OrderableItem.ManufacturerModel & " and " & drgit.OrderItem.Description & " do not match" & vbCrLf & "Assign anyway?", "ID Mismatch", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
                                skipItem = True
                            End If
                        End If
                        If Not skipItem Then
                            Dim objOrderItem As OrderItem = drgit.OrderItem
                            Dim objOrder As Order = objOrderItem.Order
                            drgit.Recipient = objOrdItem.RecipientName
                            drgit.Assigner = Identity.Name
                            drgit.AccountingUnit = objOrdItem.AccountingUnit
                            If Not drgit.ConfirmedItem Is Nothing Then
                                drgit.ConfirmedItem.QuantityAssigned -= 1
                                drgit.ConfirmedItem.DateAssigned = Nothing
                            End If
                            drgit.ConfirmedItem = objOrdItem
                            drgit.Accounting = Now()
                            QuantityMissing = QuantityMissing - 1
                            'Update AIMS with User Info
                            If (drgit.OrderItem.OrderableItem.ItemClassID = 2) Then
                                Dim urlAIMS As String = _dbAIMS.AssignUser(drgit.AimsID, drgit.Recipient, drgit.AccountingUnit.Besitzer)
                                System.Diagnostics.Process.Start(urlAIMS)
                            Else
                                MessageBox.Show("ItemClassID:" & drgit.OrderItem.OrderableItem.ItemClassID.ToString, "ItemClassID", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If


                            '=============================================== Mail support 
                            Dim MailRecipient As String
                            Dim Domain As String = Identity.Name.Substring(0, Identity.Name.IndexOf("\")).ToLower
                            Dim UserName As String = Identity.Name.Substring(Identity.Name.IndexOf("\") + 1).ToLower
                            Dim strLDAPQueryFormat As String = "LDAP://" & Domain & ".schindler.com/DC=" & Domain & ",DC=schindler,DC=com"
                            Dim strQueryFilterFormat As String = "(&(samAccountName=" & UserName & ")(objectCategory=person)(objectClass=user))"
                            Dim result As SearchResult = Nothing
                            Using root As DirectoryEntry = New DirectoryEntry(strLDAPQueryFormat)
                                Using searcher As DirectorySearcher = New DirectorySearcher(root)
                                    searcher.Filter = strQueryFilterFormat
                                    Dim results As SearchResultCollection = searcher.FindAll
                                    If results.Count > 0 Then
                                        result = results(0)
                                    Else
                                        result = Nothing
                                    End If
                                End Using
                            End Using
                            If result IsNot Nothing AndAlso result.Properties("mail")(0) IsNot Nothing Then
                                MailRecipient = result.Properties("mail")(0)
                            Else
                                MailRecipient = "marcel.zehnder@ch.schindler.com"
                            End If
                            Try
                                Dim locMailMessage As New MailMessage("orderprocess@donotreply.schindler.com", MailRecipient)
                                locMailMessage.Subject = "Order " & objOrder.Nr
                                locMailMessage.Body = "NotesOrder " & objOrdItem.NotesURL & vbCrLf & vbCrLf & _
                                                      "Please deliver item " & drgit.ItemID & " (" & objOrderItem.Description & " " & drgit.sAimsUrl & ") to " & objOrdItem.RecipientName & vbCrLf & vbCrLf & _
                                                      "Assigned by " & Identity.Name & " on " & Now.ToShortDateString & "," & Now.ToShortTimeString
                                Dim locMailClient As New SmtpClient("smtp.eu.schindler.com")
                                locMailClient.Send(locMailMessage)
                            Catch ex As SmtpException
                                If MessageBox.Show("Error sending mail to " & MailRecipient & ". Perform assignment anyway?", "Mail error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Cancel Then
                                    drgit.Recipient = Nothing
                                    drgit.AccountingUnit = Nothing
                                    drgit.Accounting = Nothing
                                    QuantityMissing = QuantityMissing + 1
                                End If
                            End Try
                            '==================== End of Mail support
                        End If
                    Catch ex As MissingAIMSEntryException
                        MessageBox.Show(ex.Message, "Missing AIMS Entry Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        drgit.Recipient = Nothing
                        drgit.Assigner = Nothing
                        drgit.AccountingUnit = Nothing
                        drgit.ConfirmedItemID = Nothing
                        drgit.Accounting = Nothing
                        QuantityMissing = QuantityMissing + 1
                        drgit.AimsID = Nothing
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
                objOrdItem.QuantityAssigned = objOrdItem.QuantityOrdered - QuantityMissing
                If QuantityMissing = 0 Then
                    objOrdItem.DateAssigned = Now()
                End If
                _dbOrderProcess.SubmitChanges()
                frmMain.RefreshAll()
            End If
        Else
            MessageBox.Show("Location: " & hitTstInfo.Location.ToString, "HitTestInfo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

   Private Sub lvMain_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvMain.DragOver, MyBase.DragOver
      Dim lstDragItems As List(Of Item) = e.Data.GetData(GetType(List(Of Item)))
        If Not (lstDragItems Is Nothing And frmMain.dragWindowName = Me.Tag) Then
            Dim ptClient As Point = lvMain.PointToClient(New Point(e.X, e.Y))
            Dim hitTest As ListViewHitTestInfo = lvMain.HitTest(ptClient)
            If Not hitTest.Item Is Nothing Then
                lvMain.Items(hitTest.Item.Index).BackColor = sysbackColor
                lvMain.Items(hitTest.Item.Index).ForeColor = Color.White
                If (lstDragItems IsNot Nothing) AndAlso (lastDragIndex <> hitTest.Item.Index) Then
                    lvMain.Items(lastDragIndex).BackColor = Color.White
                    lvMain.Items(lastDragIndex).ForeColor = Color.Black
                End If
                lastDragIndex = hitTest.Item.Index
                e.Effect = DragDropEffects.Copy
            ElseIf Not (lastDragIndex = Nothing) Then
                lvMain.Items(lastDragIndex).BackColor = Color.White
                lvMain.Items(lastDragIndex).ForeColor = Color.Black
            End If
        End If
   End Sub

   Private Sub lvMain_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvMain.MouseDown
      Dim hitTest As ListViewHitTestInfo = lvMain.HitTest(e.Location)
      If Not hitTest.Item Is Nothing Then
         cmtvMainOpenNotesOrder.Visible = True
         cmtvMainRemove.Visible = True
         cmtvMainEditConfirmedItem.Visible = True
         cmtvMainNewConfirmedItem.Visible = False
      Else
         If Me.Tag = "ConfirmedItems" Then
            cmtvMainNewConfirmedItem.Visible = True
         Else
            cmtvMainNewConfirmedItem.Visible = False
         End If
      cmtvMainRemove.Visible = False
      cmtvMainOpenNotesOrder.Visible = False
      End If
   End Sub

   Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
      Me.Close()
   End Sub

   Private Sub frmConfirmedItems_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
      WriteWindowState()
      locIsClosed = True
   End Sub

   Private Sub cmtvMainOpenNotesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainOpenNotesOrder.Click
      Dim selItem As ConfirmedItem = Nothing
      Dim selItemTag As String = Nothing
      For Each lvit As ListViewItem In lvMain.SelectedItems
         selItemTag = lvit.Tag
      Next
      For Each confit As ConfirmedItem In lstItems
         If confit.ID = CInt(selItemTag) Then
            selItem = confit
            Exit For
         End If
      Next
      If Not (selItem Is Nothing) Then
         Try
            System.Diagnostics.Process.Start(selItem.NotesURL)
         Catch ex As Exception
            MessageBox.Show(ex.Message, "Problem Opening Notes", MessageBoxButtons.OK)
         End Try
      End If
   End Sub

   Private Sub cmtvMainNewConfirmedItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainNewConfirmedItem.Click
      frmMain.NewConfirmedItem(Nothing)
   End Sub
   Private Sub cmtvMainEditConfirmedItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainEditConfirmedItem.Click
      Dim comparer As New ConfirmedItemPredicate(CInt(lvMain.SelectedItems(0).Tag))
      Dim selcit As ConfirmedItem = lstItems.Find(AddressOf comparer.CompareIDs)
      frmMain.EditConfirmedItem(selcit)
   End Sub


   Private Sub frmConfirmedItems_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
      If Me.Tag = "ConfirmedItems" Then
         cmtvMainNewConfirmedItem.Visible = True
      Else
         cmtvMainNewConfirmedItem.Visible = False
      End If
   End Sub

   Private Sub cmtvMainRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainRemove.Click
      Dim selItem As ConfirmedItem = Nothing
      Dim selItemTag As String = Nothing
      For Each lvit As ListViewItem In lvMain.SelectedItems
         selItemTag = lvit.Tag
      Next
      For Each confit As ConfirmedItem In lstItems
         If confit.ID = CInt(selItemTag) Then
            selItem = confit
            Exit For
         End If
      Next
      If Not selItem Is Nothing Then
         If MessageBox.Show("Delete " & Me.Tag.substring(0, Me.Tag.length - 1) & " " & selItem.OrderableItem.ManufacturerModel & "?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
            frmMain.RemoveConfirmedItem(selItem)
         End If
      End If
   End Sub

    Private Sub setupColumnsSort(ByVal columnIdx As Integer, Optional ByVal ignoreSortOrder As Boolean = False)
        Dim colText As String = lvMain.Columns(columnIdx).Text
        If colText = "Assigned" Then
            lvwColumnSorter.SortMethod = "Date"
        ElseIf colText = "Price" Then
            lvwColumnSorter.SortMethod = "Price"
        Else
            lvwColumnSorter.SortMethod = "Text"
        End If
        If ignoreSortOrder = False Then
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
      Dim selCount As Integer = lvMain.SelectedItems.Count
      Dim lstSelID As New List(Of Integer)
      If selCount > 0 Then
         For Each slvit As ListViewItem In lvMain.SelectedItems
            lstSelID.Add(CInt(slvit.Tag))
         Next
        End If
        setupColumnsSort(e.Column)

      ' Perform the sort with these new sort options.
      lvMain.Sort()
      If selCount > 0 Then
         For Each lvit As ListViewItem In lvMain.Items
            For Each ID As Integer In lstSelID
               If CInt(lvit.Tag) = ID Then
                  lvit.Selected = True
               End If
            Next
         Next
      End If
   End Sub

   Private Sub cmtvMainCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmtvMainCopy.Click
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

Public Class ListItemPredicate
   Private _Index As Integer

   Public Sub New(ByVal Index As Integer)
      _Index = Index
   End Sub

   Public Function CompareTag(ByVal obj As Integer) As Boolean
      Return (_Index = obj)
    End Function
End Class