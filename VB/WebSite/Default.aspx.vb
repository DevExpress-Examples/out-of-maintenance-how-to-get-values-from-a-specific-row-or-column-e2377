Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxPivotGrid
Imports System.Text
Imports DevExpress.XtraPivotGrid
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Data.PivotGrid

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		populatePivot()
		GridView1.DataSource = CreateSummaryTable(ASPxPivotGrid1, ASPxPivotGrid1.Fields("TYPE"), ASPxPivotGrid1.Fields("CODE"), ASPxPivotGrid1.Fields("COUNT"), "Third")
		GridView1.DataBind()
	End Sub

	Private Function CreateSummaryTable(ByVal pivotGrid As ASPxPivotGrid, ByVal sourceField As PivotGridField, ByVal targetField As PivotGridField, ByVal valueField As PivotGridField, ByVal sourceFieldValue As Object) As DataTable
		Dim ds As PivotSummaryDataSource = ASPxPivotGrid1.CreateSummaryDataSource()
		Dim dt As New DataTable()
		dt.Columns.Add("SourceField", GetType(String))
		dt.Columns.Add("TargetField",GetType(String))
		dt.Columns.Add("Value",GetType(Decimal))
		For i As Integer = 0 To ds.RowCount - 1
			If ds.GetValue(i, sourceField) Is sourceFieldValue Then
				dt.Rows.Add(New Object() { ds.GetValue(i, sourceField), ds.GetValue(i, targetField), ds.GetValue(i, valueField)})
			End If
		Next i
		Return dt
	End Function

	Private Sub populatePivot()
		ASPxPivotGrid1.DataSource = get_DataTable()
	End Sub

	Public Function get_DataTable() As Object
		Dim table As New DataTable()
		table.Columns.Add("CODE", GetType(String))
		table.Columns.Add("TYPE", GetType(String))
		table.Columns.Add("COUNT", GetType(Int32))



		table.Rows.Add("AAA", "First", 34)
		table.Rows.Add("AAA", "Second", 22)
		table.Rows.Add("AAA", "Third", 2)
		table.Rows.Add("BBB", "First", 87)
		table.Rows.Add("BBB", "Second", 5)
		table.Rows.Add("BBB", "Third", 5)
		table.Rows.Add("CCC", "First", 3)
		table.Rows.Add("CCC", "Second", 2)
		table.Rows.Add("CCC", "Third", 3)

		Return table.DefaultView
	End Function
End Class