<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PaidOut.aspx.vb" MasterPageFile="~/Member2.master" Inherits="PaidOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h2 style="left:348px;"> Paid Out </h2>
<div>
 <div class="fix">
<asp:GridView ID="GVpaidout"  AutoGenerateColumns="false" runat="server" CssClass="pack_tab">
<Columns>

<asp:TemplateField HeaderText="Username">
<ItemTemplate>
<%# Eval("Username")%>
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Date">
<ItemTemplate>
<%# Eval("Date")%>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Amount">
<ItemTemplate>
<%# Eval("Amount")%>
</ItemTemplate>
</asp:TemplateField>


</Columns>
</asp:GridView>
</div>
</div>
</asp:Content>

