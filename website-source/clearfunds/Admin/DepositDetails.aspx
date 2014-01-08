<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="DepositDetails.aspx.vb" Inherits="Admin_DepositDetails" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    <h2>Deposit Details</h2>
<table class="con_text1" style="background:none; color:#fff; border:0px;">
<tr>
<td style="width:230px; float:left;">
<asp:Label ID="Label1" runat="server" Text="From" style="float:left; margin-right:7px; padding-top:7px; "></asp:Label>
<asp:TextBox ID="txtfrom" runat="server" Width="150"  CssClass="inputbox smallbox"></asp:TextBox>
    <asp:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" 
        TargetControlID="txtfrom">      
    </asp:CalendarExtender>
</td>


<td style="width:200px; float:left;">
<asp:Label ID="Label2" runat="server" Text="To" style="float:left; margin-right:7px; padding-top:7px;"></asp:Label>
<asp:TextBox ID="txtto" runat="server" Width="150"  CssClass="inputbox smallbox"></asp:TextBox>
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

<asp:GridView ID="GVDepositDetails"  AutoGenerateColumns="False" runat="server" 
 PagerSettings-Mode="Numeric">
<Columns>



      <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
   <%# Eval("UserName")%>
    </ItemTemplate>
     </asp:TemplateField>




       <asp:TemplateField HeaderText="Deposit date">
    <ItemTemplate>
   <%# Eval("Deposit_ModifyDate")%>
    </ItemTemplate>
     </asp:TemplateField>


     
       <asp:TemplateField HeaderText="Plan">
    <ItemTemplate>
   <%# Eval("Packagedet_Plan")%>
    </ItemTemplate>
     </asp:TemplateField>

     
       <asp:TemplateField HeaderText="Validity (Days)">
    <ItemTemplate>
   <%# Eval("Package_duration")%>
    </ItemTemplate>
     </asp:TemplateField>

         <asp:TemplateField HeaderText="Profit (%)">
    <ItemTemplate>
   <%# Eval("Packagedet_Percent")%>
    </ItemTemplate>
     </asp:TemplateField>
     
     
       <asp:TemplateField HeaderText="Deposit Amount ($)">
    <ItemTemplate>
   <%# Eval("Deposit_Amount")%>
    </ItemTemplate>
     </asp:TemplateField>

     
      <asp:BoundField DataField="Deposit_PayName" HeaderText="Deposit Method" />
      <asp:BoundField DataField="Deposit_SysIp" HeaderText="IP Address" />
      <asp:BoundField DataField="Deposit_CountryName" HeaderText="Country Flag" />


        

        

    </Columns>
</asp:GridView >


<div>
 &nbsp;&nbsp;&nbsp;
 <div class="depos_con">
 
 <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label>
 
 <asp:Label ID="lblAmt" runat="server"></asp:Label>
 
 </div>
 </div>


</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
