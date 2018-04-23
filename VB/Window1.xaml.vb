Imports Microsoft.VisualBasic
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
				list.Add(New TestData() With {.Text = String.Format("Row{0}", i), .Number = i})
			Next i

			grid.DataSource = list
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
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
	End Class
	#End Region
End Namespace
