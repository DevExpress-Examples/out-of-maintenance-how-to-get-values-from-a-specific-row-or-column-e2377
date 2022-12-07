using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxPivotGrid;
using System.Text;
using DevExpress.XtraPivotGrid;
using System.Collections.Generic;
using System.Data.OleDb;
using DevExpress.Web;
using DevExpress.Data.PivotGrid;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e) {
        populatePivot();
        GridView1.DataSource = CreateSummaryTable(ASPxPivotGrid1, ASPxPivotGrid1.Fields["TYPE"], ASPxPivotGrid1.Fields["CODE"], ASPxPivotGrid1.Fields["COUNT"], "Third");
        GridView1.DataBind();
    }

    private DataTable CreateSummaryTable(ASPxPivotGrid pivotGrid, PivotGridField sourceField, PivotGridField targetField, PivotGridField valueField, object sourceFieldValue)
    {
        PivotSummaryDataSource ds = ASPxPivotGrid1.CreateSummaryDataSource();
        DataTable dt = new DataTable();
        dt.Columns.Add("SourceField", typeof(string));
        dt.Columns.Add("TargetField",typeof(string));
        dt.Columns.Add("Value",typeof(decimal));
        for (int i = 0; i < ds.RowCount; i++)
        {
            if (ds.GetValue(i, sourceField) == sourceFieldValue)
                dt.Rows.Add(new object[] { ds.GetValue(i, sourceField), ds.GetValue(i, targetField), ds.GetValue(i, valueField)} );
        }
        return dt;
    }

    private void populatePivot() {
        ASPxPivotGrid1.DataSource = get_DataTable();
    }

    public object get_DataTable() {
        DataTable table = new DataTable();
        table.Columns.Add("CODE", typeof(string));
        table.Columns.Add("TYPE", typeof(string));
        table.Columns.Add("COUNT", typeof(Int32));



        table.Rows.Add("AAA", "First", 34);
        table.Rows.Add("AAA", "Second", 22);
        table.Rows.Add("AAA", "Third", 2);
        table.Rows.Add("BBB", "First", 87);
        table.Rows.Add("BBB", "Second", 5);
        table.Rows.Add("BBB", "Third", 5);
        table.Rows.Add("CCC", "First", 3);
        table.Rows.Add("CCC", "Second", 2);
        table.Rows.Add("CCC", "Third", 3);
        
        return table.DefaultView;
    }
}