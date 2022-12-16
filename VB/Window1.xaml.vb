'#Region "usings"
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows
Imports DevExpress.Xpf.Grid

'#End Region
Namespace ClearFocusedRow

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
'#Region "Initialize the grid."
            Dim list As IList(Of TestData) = New BindingList(Of TestData)()
            For i As Integer = 0 To 10 - 1
                list.Add(New TestData() With {.Text = String.Format("Row{0}", i), .Number = i})
            Next

            Me.grid.ItemsSource = list
'#End Region
            AddHandler Me.grid.Loaded, AddressOf Me.grid_Loaded
        End Sub

        Private Sub grid_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim view As TableView = TryCast(Me.grid.View, TableView)
            view.FocusedRowHandle = DataControlBase.InvalidRowHandle
        End Sub
    End Class

'#Region "Test class to populate the grid."
    Public Class TestData

        Public Property Number As Integer

        Public Property Text As String
    End Class
'#End Region
End Namespace
