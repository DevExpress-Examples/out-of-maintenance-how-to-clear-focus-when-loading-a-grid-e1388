#Region "usings"
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows
Imports DevExpress.Xpf.Grid
#End Region

Namespace ClearFocusedRow
	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()

'			#Region "Initialize the grid."
			Dim list As IList(Of TestData) = New BindingList(Of TestData)()
			For i As Integer = 0 To 9
				list.Add(New TestData() With {
					.Text = String.Format("Row{0}", i),
					.Number = i
				})
			Next i

			grid.ItemsSource = list
'			#End Region

			AddHandler grid.Loaded, AddressOf grid_Loaded
		End Sub

		Private Sub grid_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim view As TableView = TryCast(grid.View, TableView)
			view.FocusedRowHandle = GridControl.InvalidRowHandle
		End Sub
	End Class

	#Region "Test class to populate the grid."
	Public Class TestData
		Public Property Number() As Integer
		Public Property Text() As String
	End Class
	#End Region
End Namespace
