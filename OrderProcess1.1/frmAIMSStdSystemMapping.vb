Public Class frmAIMSStdSystemMapping
   Private lstAIMSStdSystems As List(Of StdSystem)
   Private objItem As Item
   Private locStdSystemID As Integer = Nothing

   Public Sub New(ByVal Item As Item, ByVal AIMSStdSystems As List(Of StdSystem))
      objItem = Item
      lstAIMSStdSystems = AIMSStdSystems
      InitializeComponent()
   End Sub
   Public Property StdSystemID() As Integer
      Get
         Return locStdSystemID
      End Get
      Set(ByVal value As Integer)
         locStdSystemID = value
      End Set
   End Property

   Private Sub frmAIMSStdSystemMapping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      tbOPDescription.Text = objItem.OrderItem.Description
      tbOPCategory.Text = objItem.OrderItem.OrderableItem.DeviceCategory
      tbOPModelNr.Text = objItem.OrderItem.OrderableItem.ManufacturerNo
      tbOPManufacturer.Text = objItem.OrderItem.OrderableItem.Manufacturer
      cbAIMSStdSystems.DataSource = lstAIMSStdSystems
      cbAIMSStdSystems.DisplayMember = "Geraet"
      cbAIMSStdSystems.ValueMember = "ID"
   End Sub

   Private Sub cbAIMSStdSystems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAIMSStdSystems.SelectedIndexChanged
      Dim selStdSystem As StdSystem = cbAIMSStdSystems.SelectedItem
      tbAIMSCategory.Text = selStdSystem.Kategorie
      tbAIMSModelNr.Text = selStdSystem.Typ_Nr
      tbAIMSManufacturer.Text = selStdSystem.Hersteller
   End Sub

   Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      locStdSystemID = CInt(cbAIMSStdSystems.SelectedValue)
   End Sub
End Class