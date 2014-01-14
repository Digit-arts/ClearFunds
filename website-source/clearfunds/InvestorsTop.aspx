﻿<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="ContentMaster.master" CodeFile="InvestorsTop.aspx.vb" Inherits="InvestorsTop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="css/l_style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class ="ContentPadding ">
        
 <div class="abtus_cnt"><asp:Label ID="Label10" runat="server" Text="Top Ten"></asp:Label></div>        
 <div class="acc_table">
<asp:GridView ID="GVInvestorsTop"  AutoGenerateColumns="false" runat="server"  >
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

