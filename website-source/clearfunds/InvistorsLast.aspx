<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InvistorsLast.aspx.vb"  MasterPageFile="~/newmember.master" Inherits="InvistorsLast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="acc_cnt"><!---acc_cnt start---->
    <h2 style="left:318px;">INVISTOR LAST 10 </h2>
    <div class="fix">
<asp:GridView ID="GVLastten" AutoGenerateColumns="false" runat="server"  CssClass="pack_tab" >
<Columns>

<asp:TemplateField HeaderText="Username" >   
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