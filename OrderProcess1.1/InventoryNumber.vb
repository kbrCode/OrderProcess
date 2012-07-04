Public Class InventoryNumbers
   Implements ICollection(Of InventoryNumber)

   Public Event ItemAdded(ByVal Sender As Object, ByVal e As EventArgs)
   Public Event ItemModified(ByVal Sender As Object, ByVal e As EventArgs)
   Public Event ItemRemoved(ByVal Sender As Object, ByVal e As EventArgs)
   Private locNumItems As Integer = 0
   Private locLastItemAdded As Integer = 0
   Private locItems As InventoryNumber() = Nothing
   Private locVersion As Integer

   Public Sub New()
      locVersion = 0
      Clear()
   End Sub
   Public Sub Add(ByVal item As InventoryNumber) Implements System.Collections.Generic.ICollection(Of InventoryNumber).Add
      If item IsNot Nothing Then
         Dim Index As Integer = Find(item)
         If Index = -1 Then
            InsertTo(item, locNumItems)
         Else
            ModifyAt(item, Index)
         End If
      End If
   End Sub
   Public Sub Append(ByVal Item As InventoryNumber)
      InsertTo(Item, locNumItems)
   End Sub
   Public Sub Clear() Implements System.Collections.Generic.ICollection(Of InventoryNumber).Clear
      locNumItems = 0
      ReDim locItems(locNumItems)
      locItems = Nothing
      locVersion = locVersion + 1
   End Sub
   Public Function Contains(ByVal item As InventoryNumber) As Boolean Implements System.Collections.Generic.ICollection(Of InventoryNumber).Contains
      Dim bolContains As Boolean = False
      For Each it As InventoryNumber In locItems
         If IsEqual(it, item) Then
            bolContains = True
            Exit For
         End If
      Next
      Return bolContains
   End Function
   Public Sub CopyTo(ByVal array() As InventoryNumber, ByVal Index As Integer) Implements System.Collections.Generic.ICollection(Of InventoryNumber).CopyTo
      If (Index > locNumItems) Then
         Index = locNumItems
      End If
      For indNew As Integer = 0 To array.Length - 1
         InsertTo(array(indNew), Index + indNew)
      Next
   End Sub
   Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of InventoryNumber).Count
      Get
         Return locNumItems
      End Get
   End Property
   Public Function Find(ByVal Item As InventoryNumber) As Integer
      Dim findIndex As Integer = -1
      For i As Integer = 0 To locNumItems - 1
         If IsEqual(locItems(i), Item) Then
            findIndex = i
            Exit For
         End If
      Next
      Return findIndex
   End Function
   Public Function FindType(ByVal Item As InventoryNumber) As Integer
      Dim findIndex As Integer = -1
      For i As Integer = 0 To locNumItems - 1
         If IsEqualType(locItems(i), Item) Then
            findIndex = i
            Exit For
         End If
      Next
      Return findIndex
   End Function
   Default Public Property GetItem(ByVal Index As Integer) As InventoryNumber
      Get
         Return locItems(Index)
      End Get
      Set(ByVal value As InventoryNumber)
         locItems(Index) = value
      End Set
   End Property
   Public Sub InsertTo(ByVal item As InventoryNumber, ByVal Index As Integer)
      ReDim Preserve locItems(locNumItems)
      For indOld As Integer = locNumItems - 1 To Index Step -1
         locItems(indOld + 1) = locItems(indOld)
      Next
      locNumItems = locNumItems + 1
      locItems(Index) = item
      locLastItemAdded = Index
      locVersion = locVersion + 1
      RaiseEvent ItemAdded(Me, Nothing)
   End Sub
   Public Function IsEqual(ByVal Item1 As InventoryNumber, ByVal Item2 As InventoryNumber) As Boolean
      If Item1 Is Nothing And Item2 Is Nothing Then
         Return True
      ElseIf Item1 Is Nothing And Item2 IsNot Nothing Then
         Return False
      ElseIf Item1 IsNot Nothing And Item2 Is Nothing Then
         Return False
      ElseIf Item1.Inv_Nr = Item2.Inv_Nr Then
         Return True
      Else
         Return False
      End If
   End Function
   Public Function IsEqualType(ByVal Item1 As InventoryNumber, ByVal Item2 As InventoryNumber) As Boolean
      If Item1 Is Nothing And Item2 Is Nothing Then
         Return True
      ElseIf Item1 Is Nothing And Item2 IsNot Nothing Then
         Return False
      ElseIf Item1 IsNot Nothing And Item2 Is Nothing Then
         Return False
      ElseIf (Item1.PreFix = Item2.PreFix) And (Item1.PostFix = Item2.PostFix) Then
         Return True
      Else
         Return False
      End If
   End Function

   Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of InventoryNumber).IsReadOnly
      Get
         Return False
      End Get
   End Property
   Public ReadOnly Property LastItemAdded() As Integer
      Get
         Return locLastItemAdded
      End Get
   End Property
   Public Sub Modify(ByVal Item As InventoryNumber)
      Dim findIndex As Integer = Find(Item)
      If findIndex = -1 Then
         Add(Item)
      Else
         ModifyAt(Item, findIndex)
      End If
   End Sub
   Public Sub ModifyAt(ByVal Item As InventoryNumber, ByVal Index As Integer)
      locItems(Index) = Item
      locVersion = locVersion + 1
      RaiseEvent ItemModified(Me, Nothing)
   End Sub
   Public Function Remove(ByVal item As InventoryNumber) As Boolean Implements System.Collections.Generic.ICollection(Of InventoryNumber).Remove
      Dim remIndex As Integer = Find(item)
      If remIndex = -1 Then
         Return False
      Else
         Return RemoveAt(remIndex)
      End If
   End Function
   Public Function RemoveAt(ByVal Index As Integer) As Boolean
      Dim bolReturn As Boolean = False
      If Index < locNumItems Then
         Dim it As InventoryNumber = locItems(Index)
         For i As Integer = Index To locNumItems - 2
            locItems(i) = locItems(i + 1)
         Next
         locItems(locNumItems - 1) = Nothing
         locNumItems = locNumItems - 1
         ReDim Preserve locItems(locNumItems - 1)
         locVersion = locVersion + 1
      End If
      RaiseEvent ItemRemoved(Me, Nothing)
      Return bolReturn
   End Function

   Public Function GetEnumerator1() As System.Collections.Generic.IEnumerator(Of InventoryNumber) Implements System.Collections.Generic.IEnumerable(Of InventoryNumber).GetEnumerator
      Return New ItemEumerator(Of InventoryNumber)(locItems)
   End Function
   Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
      Return New ItemEumerator(Of InventoryNumber)(locItems)
   End Function
End Class

Public Class ItemEumerator(Of InventoryNumber)
   Implements IEnumerator

   Private locItems() As InventoryNumber
   Private Cursor As Integer
   Sub New(ByVal Items() As InventoryNumber)
      Me.locItems = Items
      Cursor = -1
   End Sub
   Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
      Get
         If (Cursor < 0) Or (Cursor = locItems.Length) Then
            Throw New InvalidOperationException()
         Else
            Return locItems(Cursor)
         End If
      End Get
   End Property
   Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
      If locItems Is Nothing Then
         Return False
      Else
         If Cursor < locItems.Length Then
            Cursor = Cursor + 1
         End If
         If Cursor = locItems.Length Then
            Return False
         Else
            Return True
         End If
      End If
   End Function
   Public Sub Reset() Implements System.Collections.IEnumerator.Reset
      Cursor = -1
   End Sub
End Class

Public Class InventoryNumber
   Implements IComparable(Of InventoryNumber)

   Private _PreFix As String
   Private _Number As Integer
   Private _PostFix As String

   Public Sub New(ByVal Inv_Nr As String)
      ConvertString(Inv_Nr)
   End Sub
   Public Sub New(ByVal PreFix As String, ByVal Number As Integer, ByVal PostFix As String)
      _PreFix = PreFix
      _Number = Number
      _PostFix = PostFix
   End Sub

   Private Sub ConvertString(ByVal Inv_Nr As String)
      If Inv_Nr.Length = 7 Then
         _PreFix = Inv_Nr.Substring(0, 2)
         If Not Integer.TryParse(Inv_Nr.Substring(2, 4), _Number) Then
            _Number = 0
         End If
         _PostFix = Inv_Nr.Substring(6, 1)
      ElseIf Inv_Nr.Length = 8 Then
         _PreFix = Inv_Nr.Substring(0, 3)
         If Not Integer.TryParse(Inv_Nr.Substring(3, 4), _Number) Then
            _Number = 0
         End If
         _PostFix = Inv_Nr.Substring(7, 1)
      End If
   End Sub

   Public Property Inv_Nr() As String
      Get
         Return PreFix & String.Format("{0:D4}", _Number) & PostFix
      End Get
      Set(ByVal value As String)
         ConvertString(value)
      End Set
   End Property

   Public Property PreFix() As String
      Get
         Return _PreFix
      End Get
      Set(ByVal value As String)
         _PreFix = value
      End Set
   End Property

   Public Property Number() As Integer
      Get
         Return _Number
      End Get
      Set(ByVal value As Integer)
         _Number = value
      End Set
   End Property

   Public Property PostFix() As String
      Get
         Return _PostFix
      End Get
      Set(ByVal value As String)
         _PostFix = value
      End Set
   End Property

   Public Function CompareTo(ByVal other As InventoryNumber) As Integer Implements System.IComparable(Of InventoryNumber).CompareTo
      If _PreFix > other.PreFix Then
         Return 1
      ElseIf _PreFix < other.PreFix Then
         Return -1
      Else
         If _PostFix > other.PostFix Then
            Return 1
         ElseIf _PostFix < other.PostFix Then
            Return -1
         Else
            If _Number > other.Number Then
               Return 1
            ElseIf _Number < other.Number Then
               Return -1
            Else
               Return 0
            End If
         End If
      End If
   End Function
End Class

Public Class InvNrComparer
   Implements IComparer(Of InventoryNumber)

   Public Function Compare(ByVal x As InventoryNumber, ByVal y As InventoryNumber) As Integer Implements System.Collections.Generic.IComparer(Of InventoryNumber).Compare
      If x.PreFix > y.PreFix Then
         Return 1
      ElseIf x.PreFix < y.PreFix Then
         Return -1
      Else
         If x.PostFix > y.PostFix Then
            Return 1
         ElseIf x.PostFix < y.PostFix Then
            Return -1
         Else
            If x.Number > y.Number Then
               Return 1
            ElseIf x.Number < y.Number Then
               Return -1
            Else
               Return 0
            End If
         End If
      End If
   End Function
End Class
