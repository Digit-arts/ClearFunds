<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="PenaltyHistory.aspx.vb" Inherits="Admin_PenaltyHistory" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 851px;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Penality history</h2>
    <table>
    <tr>
<td style="width:230px; float:left;">
<asp:Label ID="Label1" runat="server" Text="From" 
        style="float:left; margin-right:7px; padding-top:7px; " Height="16px"></asp:Label>
<asp:TextBox ID="txtfrom" runat="server" Width="150px" CssClass="inputbox smallbox"></asp:TextBox>
    <asp:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" 
        TargetControlID="txtfrom">      
    </asp:CalendarExtender>
</td>


<td style="width:200px; float:left;">
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
<asp:GridView ID="GVPenaltyHistory"  AutoGenerateColumns="false"  runat="server" class="pack_tab">
<Columns>

       <asp:TemplateField HeaderText="UserName">
    <ItemTemplate>
   <%# Eval("UserName")%>
    </ItemTemplate>
     </asp:TemplateField>


       <asp:TemplateField HeaderText="Penalty Date">
    <ItemTemplate>
   <%# Eval("Penalty_ModifyDate")%>
    </ItemTemplate>
     </asp:TemplateField>

     
       <asp:TemplateField HeaderText="Penalty Amount">
    <ItemTemplate>
   <%# Eval("Penalty_Amount")%>
    </ItemTemplate>
     </asp:TemplateField>


      


    </Columns>
</asp:GridView>

   <div>
 &nbsp;&nbsp;&nbsp;
 <div class="depos_con">
 <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label>
 <asp:Label ID="lblAmt" runat="server"></asp:Label>
 </div>
 </div>

</asp:Content>
