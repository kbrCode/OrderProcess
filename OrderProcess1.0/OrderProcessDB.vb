Partial Public Class OrderProcessDB
   Inherits DataContext
   Public Orders As Table(Of Order)
   Public OrderItems As Table(Of OrderItem)
   Public Items As Table(Of Item)
   Public AccountingUnits As Table(Of AccountingUnit)
   Public ItemClasses As Table(Of ItemClass)
   Public Suppliers As Table(Of Supplier)
   Public OrderableItems As Table(Of OrderableItem)
   Public ConfirmedItems As Table(Of ConfirmedItem)

   Public Sub New(ByVal connection As String)
      MyBase.New(connection)
   End Sub
   Public Sub Submit()
      Try
         Me.SubmitChanges()
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Problem while Submitting Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
End Class
