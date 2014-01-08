<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB.aspx.vb" Inherits="VB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:DropDownList ID="ddlCountries" runat="server"  OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged"
        AutoPostBack="true">
    </asp:DropDownList>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>Month</asp:ListItem>
        <asp:ListItem>year</asp:ListItem>
       

    </asp:RadioButtonList>
    <hr />
    <cc1:BarChart ID="BarChart1" runat="server"  ChartHeight="300" ChartWidth = "450"
        ChartType="Column" ChartTitleColor="#0E426C" Visible = "false"
        CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
    </cc1:BarChart>
    </form>
</body>
</html> 
