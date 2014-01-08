<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/AccountMaster.master"  CodeFile="CurrentPlan.aspx.vb" Inherits="Account_CurrentPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">





    <h2 style="left:320px;"> Current plan </h2>
 <div class="acc_table">
<asp:GridView ID="GVCurrentplan"   ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" runat="server" >
<Columns>
<asp:TemplateField Visible="false" HeaderText="Plan Name">
<ItemTemplate>
<%# Eval("Type")%>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Plan Name">
<ItemTemplate>
<%# Eval("name")%>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="StartDate">
<ItemTemplate>
<%# Eval("StartDate")%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EndDate">
<ItemTemplate>
<%# Eval("EndDate")%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Earned Amount">
<ItemTemplate>
<%# Eval("Amount")%>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Plan Status">
<ItemTemplate>
<%# Eval("PackStatus")%>
</ItemTemplate>
</asp:TemplateField>


</Columns>

<EmptyDataTemplate>
No records found
</EmptyDataTemplate>
 </asp:GridView>
 <div style="width:500px;">
 <table class="tot_botext">
 <tr>
 <td class="style1" style="float:left; text-align:right; width:506px; text-transform:uppercase; color:#000;">
 <asp:Label ID="Label1" runat="server" Text="Total:"></asp:Label>
 </td>
  <td style="width:138px; float:left; text-align:left; ">
 <asp:Label ID="lblAmt" runat="server"></asp:Label>
 </td>
 </tr>
 </table>
 </div>
 </div>

</asp:Content>