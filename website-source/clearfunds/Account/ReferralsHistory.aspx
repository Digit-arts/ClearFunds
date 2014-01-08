<%@ Page Language="VB" AutoEventWireup="false"   CodeFile="ReferralsHistory.aspx.vb"  MasterPageFile="~/AccountMaster.master"   Inherits="ReferralsHistory" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="acc_cnt"><!---acc_cnt start---->
    <div>
    <h2 style="left:315px; font:bold 12.4px  Arial, Helvetica, sans-serif !important;">REFERRALS HISTORY</h2>

<table class="con_text2" style="width:63%;">
<tr>
<%--<td style="width:auto; float:left;">

    <asp:DropDownList ID="dtbDebositdetails" runat="server">   </asp:DropDownList>
</td>--%>

<td>
<asp:Label ID="Label1" runat="server" Text="From" style="float:left; margin-right:7px; padding-top:7px; "></asp:Label>
<asp:TextBox ID="txtfrom" runat="server" CssClass="inputbox smallbox" style="width:100px; background:#fff;"></asp:TextBox>
    <asp:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" 
        TargetControlID="txtfrom">      
    </asp:CalendarExtender>
</td>


<td>
<asp:Label ID="Label2" runat="server" Text="To" style="float:left; margin-right:7px; padding-top:7px;"></asp:Label>
<asp:TextBox ID="txtto" runat="server"  CssClass="inputbox smallbox" style="width:100px; background:#fff;"></asp:TextBox>
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
<div class="fix">
<asp:GridView ID="GVreferralHistory"  AutoGenerateColumns="false" runat="server">
<Columns>



      <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
   <%# Eval("User_FirstName")%>
    </ItemTemplate>
     </asp:TemplateField>


     
     
       <asp:TemplateField HeaderText="Amount">
    <ItemTemplate>
   <%# Eval("Amount")%>
    </ItemTemplate>
     </asp:TemplateField>



       <asp:TemplateField HeaderText=" date">
    <ItemTemplate>
   <%# Eval("Date")%>
    </ItemTemplate>
     </asp:TemplateField>



       <asp:TemplateField HeaderText="Commission">
    <ItemTemplate>
   <%# Eval("Commision")%>
    </ItemTemplate>
     </asp:TemplateField>



        


    </Columns>
</asp:GridView>
</div>
<div>

<table class="tot_botext">
 <tr>
 <td class="style1" style="float:left; text-align:right; width:90%; text-transform:uppercase; color:#000;">
 <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label>
 </td>
  <td style="width:8%; float:left; text-align:left; ">
 <asp:Label ID="lblAmt" runat="server"></asp:Label>
 </td>
 </tr>
 </table>
</div>


</div>
</asp:Content>




