Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace PivotGridDrillDownDataExample
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			pivotGridControl1.BestFit()
			AddHandler repositoryItemPopupContainerEdit1.QueryPopUp, AddressOf repositoryItemPopupContainerEdit1_QueryPopUp
			AddHandler repositoryItemPopupContainerEdit1.CloseUp, AddressOf repositoryItemPopupContainerEdit1_CloseUp
			repositoryItemPopupContainerEdit1.PopupControl = CreatePopupControl()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			' TODO: This line of code loads data into the 'nwindDataSet.SalesPerson' table. You can move, or remove it, as needed.
			Me.salesPersonTableAdapter.Fill(Me.nwindDataSet.SalesPerson)

		End Sub

		Private Function CreatePopupControl() As PopupContainerControl
			Dim result As New PopupContainerControl()
			Dim ddc As New DrillDownControl()
			ddc.Name = "DrillDownControl"
			ddc.Dock = DockStyle.Fill
			result.Size = ddc.Size
			result.Controls.Add(ddc)
			Return result
		End Function

		Private Sub repositoryItemPopupContainerEdit1_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs)
			Dim editor As PopupContainerEdit = DirectCast(sender, PopupContainerEdit)
			Dim ddc As DrillDownControl = CType(editor.Properties.PopupControl.Controls("DrillDownControl"), DrillDownControl)
			ddc.DataSource = pivotGridControl1.Cells.GetFocusedCellInfo().CreateDrillDownDataSource()

		End Sub

		Private Sub repositoryItemPopupContainerEdit1_CloseUp(ByVal sender As Object, ByVal e As CloseUpEventArgs)
			Dim editor As PopupContainerEdit = DirectCast(sender, PopupContainerEdit)
			Dim ddc As DrillDownControl = CType(editor.Properties.PopupControl.Controls("DrillDownControl"), DrillDownControl)
			If ddc.DataSource IsNot Nothing Then
				DirectCast(ddc.DataSource, IDisposable).Dispose()
				ddc.DataSource = Nothing
			End If
		End Sub
	End Class
End Namespace
