Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace PivotGridDrillDownDataExample
	Partial Public Class DrillDownControl
		Inherits UserControl

		Public Sub New()
			InitializeComponent()
			gridView1.BestFitColumns()
		End Sub

		Public Property DataSource() As Object
			Get
				Return gridControl1.DataSource
			End Get
			Set(ByVal value As Object)
				gridControl1.DataSource = value
			End Set
		End Property
	End Class
End Namespace
