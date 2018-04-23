<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v10.1, Version=10.1.5.0, Culture=neutral, PublicKeyToken=B88D1754D700E49A"
	Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dxwpg:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientInstanceName="ASPxPivotGrid1" >
				<Fields>
					<dxwpg:PivotGridField ID="fieldTYPE" Area="RowArea" AreaIndex="0" FieldName="TYPE">
					</dxwpg:PivotGridField>
					<dxwpg:PivotGridField ID="fieldUDCCODE" Area="ColumnArea" AreaIndex="0" FieldName="CODE" >
					</dxwpg:PivotGridField>
					<dxwpg:PivotGridField ID="fieldCOUNT" Area="DataArea" AreaIndex="0" FieldName="COUNT">
					</dxwpg:PivotGridField>
				</Fields>
				<OptionsDataField />
			</dxwpg:ASPxPivotGrid>
		</div>
		<asp:GridView ID="GridView1" runat="server">
		</asp:GridView>
	</form>
</body>
</html>