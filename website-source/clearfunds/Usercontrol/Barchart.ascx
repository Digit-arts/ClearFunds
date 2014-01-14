<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Barchart.ascx.vb" Inherits="Barchart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
   <%-- <asp:DropDownList ID="ddlCountries" runat="server" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged"
        AutoPostBack="true">
    </asp:DropDownList>--%>
    <hr />
    <cc1:BarChart ID="BarChart1" runat="server"  ChartHeight="300" ChartWidth = "450"
        ChartType="Column" ChartTitleColor="#0E426C" 
        CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
    </cc1:BarChart>