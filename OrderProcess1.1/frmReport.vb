Public Class frmReport
   Private lstItems As List(Of ItemPair)
   Private locStartDate As DateTime
   Private locEndDate As DateTime

   Public Sub New(ByRef ItemPairs As List(Of ItemPair), ByRef StartDate As DateTime, ByRef EndDate As DateTime)
      lstItems = ItemPairs
      locStartDate = StartDate
      locEndDate = EndDate
      InitializeComponent()
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      locStartDate = dtpFrom.Value
      Dim strEndDate As String = dtpTo.Value.ToString
      strEndDate = strEndDate.Substring(0, strEndDate.IndexOf(" ")) & " 23:59:59"
      locEndDate = CDate(strEndDate)
      Dim checkedItems As CheckedListBox.CheckedIndexCollection = clbAccountingUnits.CheckedIndices
      For Each ip As Integer In checkedItems
         lstItems(ip).Checked = True
      Next
   End Sub

   Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      For Each ip As ItemPair In lstItems
         clbAccountingUnits.Items.Add(ip.Name)
      Next
      Dim actDate As Date = Now()
      If Date.TryParse("01/" & actDate.Month.ToString & "/" & actDate.Year.ToString, actDate) Then
         dtpFrom.Value = actDate
      End If
   End Sub

   Public Property StartDate() As DateTime
      Get
         Return locStartDate
      End Get
      Set(ByVal value As DateTime)
         locStartDate = value
      End Set
   End Property
   Public Property EndDate() As DateTime
      Get
         Return locEndDate
      End Get
      Set(ByVal value As DateTime)
         locEndDate = value
      End Set
   End Property
End Class

Public Class ItemPair
   Private _Name As String
   Private _ID As Integer
   Private _Checked As Boolean

   Public Sub New(ByVal Name As String, ByVal ID As Integer)
      _Name = Name
      _ID = ID
      _Checked = False
   End Sub

   Public Property Name() As String
      Get
         Return _Name
      End Get
      Set(ByVal value As String)
         _Name = value
      End Set
   End Property
   Public Property ID() As Integer
      Get
         Return _ID
      End Get
      Set(ByVal value As Integer)
         _ID = value
      End Set
   End Property
   Public Property Checked() As Boolean
      Get
         Return _Checked
      End Get
      Set(ByVal value As Boolean)
         _Checked = value
      End Set
   End Property
End Class