<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EarningHistory.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_EarningHistory" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


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
   <%# Eval("UserName")%>
    </ItemTemplate>
     </asp:TemplateField>




       <asp:TemplateField HeaderText="Date">
    <ItemTemplate>
   <%# Eval("Date")%>
    </ItemTemplate>
     </asp:TemplateField>

      <asp:TemplateField HeaderText="Profit">
    <ItemTemplate>
   <%# Eval("Profit")%>
    </ItemTemplate>
     </asp:TemplateField>


     <asp:TemplateField HeaderText="Referral Profit">
    <ItemTemplate>
   <%# Eval("Referral")%>
    </ItemTemplate>
     </asp:TemplateField>

      
         
       <asp:TemplateField HeaderText="Total Profit ($)">
    <ItemTemplate>
   <%# Eval("Total")%>
    </ItemTemplate>
     </asp:TemplateField>
         </Columns>
</asp:GridView>

<div>
 &nbsp;&nbsp;&nbsp;
 <table>
 <tr>
 <td class="style1">
 <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>
 </td>
  <td>
 <asp:Label ID="lblAmt" runat="server"></asp:Label>
 </td>
 </tr>
 </table>
 </div>

</div>

</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 1110px;
        }
    </style>
</asp:Content>

