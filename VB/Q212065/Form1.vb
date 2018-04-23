Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Namespace Q212065
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			repositoryItemPopupContainerEdit1.PopupControl = CreatePopupControl()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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

		Private Sub repositoryItemPopupContainerEdit1_QueryPopUp(ByVal sender As Object, ByVal e As CancelEventArgs) Handles repositoryItemPopupContainerEdit1.QueryPopUp
			Dim editor As PopupContainerEdit = CType(sender, PopupContainerEdit)
			Dim ddc As DrillDownControl = CType(editor.Properties.PopupControl.Controls("DrillDownControl"), DrillDownControl)
			ddc.DataSource = pivotGridControl1.Cells.GetFocusedCellInfo().CreateDrillDownDataSource()
		End Sub

		Private Sub repositoryItemPopupContainerEdit1_CloseUp(ByVal sender As Object, ByVal e As CloseUpEventArgs) Handles repositoryItemPopupContainerEdit1.CloseUp
			Dim editor As PopupContainerEdit = CType(sender, PopupContainerEdit)
			Dim ddc As DrillDownControl = CType(editor.Properties.PopupControl.Controls("DrillDownControl"), DrillDownControl)
			If ddc.DataSource IsNot Nothing Then
				CType(ddc.DataSource, IDisposable).Dispose()
				ddc.DataSource = Nothing
			End If
		End Sub
	End Class
End Namespace