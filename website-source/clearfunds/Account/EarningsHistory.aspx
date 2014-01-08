<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EarningsHistory.aspx.vb"  MasterPageFile="~/AccountMaster.master"  Inherits="Account_EarningsHistory" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    <h2 style="left:311px;">EARNINGS HISTORY</h2>
     <h3 style="font-size:12px; padding-left:7px;" >EARNINGS HISTORY</h3>
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
<div class="fix">
<asp:GridView ID="GVEarning" AutoGenerateColumns="false" runat="server" >
<Columns>

<asp:TemplateField HeaderText="Type">
<ItemTemplate>
<%# Eval("type")%>
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

<asp:TemplateField HeaderText="Profit Amount">
<ItemTemplate>
<%# Eval("ProfitAmount")%>
</ItemTemplate>
</asp:TemplateField>

</Columns>
 </asp:GridView>
 </div>
 </div>



  <table class="earning_his">
 <tr>
 <td class="style1">
    <b> <asp:Label ID="Label5" runat="server" Text="Total ( Deposit Earnings )"></asp:Label></b>
 </td>
 <td>:</td>
  <td>
 <asp:Label ID="lblDeposit" runat="server"></asp:Label>
 </td>
  </tr>

  <tr>
  <td class="style1">
<b> <asp:Label ID="Label6" runat="server" Text="Bonus "></asp:Label></b>
 </td>
 <td>:</td>
  <td>
 <asp:Label ID="lblBonus" runat="server"></asp:Label>
 </td>
 </tr>


 <tr>
  <td class="style1">
 <b><asp:Label ID="Label8" runat="server" Text="Penalty"></asp:Label></b>
 </td>
 <td>:</td>
  <td>
 <asp:Label ID="lblPenalty" runat="server"></asp:Label>
 </td>
 </tr>

 <tr>
  <td class="style1">
 <b><asp:Label ID="Label10" runat="server" Text="Total Amount "></asp:Label></b>
 </td>
 <td>:</td>
  <td>
 <asp:Label ID="lblTotal" runat="server"></asp:Label>
 </td>
 </tr>

 </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />


<hr />

 <div>
 <h3 style="font-size:12px; padding-left:7px;">REFERRALS COMMISION  </h3>

 <table class="con_text2" style="width:63%">
<tr>
<%--<td style="width:auto; float:left;">

    <asp:DropDownList ID="dtbDebositdetails" runat="server">   </asp:DropDownList>
</td>--%>

<td>
<asp:Label ID="Label3" runat="server" Text="From" style="float:left; margin-right:7px; padding-top:7px; font-size:12px; padding-left:5px;"></asp:Label>
<asp:TextBox ID="txtfrom1" runat="server" CssClass="inputbox smallbox" style="width:100px; background:#fff;"></asp:TextBox>
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
        TargetControlID="txtfrom">      
    </asp:CalendarExtender>
</td>


<td>
<asp:Label ID="Label4" runat="server" Text="To" style="float:left; margin-right:7px; padding-top:7px; font-size:12px;"></asp:Label>
<asp:TextBox ID="txtto1" runat="server"  CssClass="inputbox smallbox" style="width:100px; background:#fff;"></asp:TextBox>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
        TargetControlID="txtto">
    </asp:CalendarExtender>
</td>


    <td style="width:100px; float:left;">
    <asp:Button ID="btnGO1" runat="server" Text="Go" CssClass="btnalt " Height="27px" />
    </td>

</tr>
</table>

<asp:GridView ID="GVReferral" AutoGenerateColumns="false" runat="server" >
<Columns>

<asp:TemplateField HeaderText="Type">
<ItemTemplate>
<%# Eval("type")%>
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

<asp:TemplateField HeaderText="Commision">
<ItemTemplate>
<%# Eval("Commision")%>
</ItemTemplate>
</asp:TemplateField>



</Columns>
 </asp:GridView>
  </div>

   <table class="earning_his">
 <tr>
 <td class="style1">
 <b><asp:Label ID="Label7" runat="server" Text="Total Earnings"></asp:Label></b>
 </td>
 <td>:</td>
  <td>
 <asp:Label ID="lblEarning" runat="server"></asp:Label>
 </td>
  </tr>
  </table>

  </asp:Content>