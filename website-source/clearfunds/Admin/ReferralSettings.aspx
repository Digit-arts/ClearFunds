<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReferralSettings.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_ReferralSettings" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  <style type="text/css">
        .style1
        {
            width: 1110px;
        }
    </style>
</asp:Content>

 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div>
    <h2>With Drawal History</h2>
<table class="con_text2">
<tr>
<td style="width:280px; float:left;">
<asp:Label ID="Label1" runat="server" Text="From" 
        style="float:left; margin-right:7px; padding-top:7px; " Height="16px"></asp:Label>
<asp:TextBox ID="txtfrom" runat="server" Width="150px" CssClass="inputbox smallbox"></asp:TextBox>
  
    <asp:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" 
        TargetControlID="txtfrom">
    </asp:CalendarExtender>
  
</td>


<td style="width:250px; float:left;">
<asp:Label ID="Label2" runat="server" Text="To" style="float:left; margin-right:7px; padding-top:7px;"></asp:Label>
<asp:TextBox ID="txtto" runat="server" Width="150px"  CssClass="inputbox smallbox"></asp:TextBox>
  
    <asp:CalendarExtender ID="txtto_CalendarExtender" runat="server" 
        TargetControlID="txtto">
    </asp:CalendarExtender>
  
</td>


    <td style="width:100px; float:left;">
    <asp:Button ID="btngo" runat="server" Text="Go" CssClass="btnalt " />
    </td>
    </tr>
</table>
</div>
<asp:GridView ID="GVWDHistory"  AutoGenerateColumns="false" runat="server">
<Columns>
      <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
        <%#Eval("User_FirstName") %>
    </ItemTemplate>
     </asp:TemplateField>
     <asp:TemplateField HeaderText="ReferenceName">
    <ItemTemplate>
        <%# Eval("ReferenceName")%>
    </ItemTemplate>
     </asp:TemplateField>
       <asp:TemplateField HeaderText="Date">
    <ItemTemplate>
   <%# Eval("Date")%>
    </ItemTemplate>
     </asp:TemplateField>  
       <asp:TemplateField HeaderText="Status">
    <ItemTemplate>
   <%# Eval("status")%>
    </ItemTemplate>
     </asp:TemplateField>
         </Columns>
</asp:GridView>
</asp:Content>
