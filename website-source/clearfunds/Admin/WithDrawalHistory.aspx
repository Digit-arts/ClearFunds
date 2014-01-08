<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WithDrawalHistory.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_WithDrawalHistory" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    <h2>With Drawal History</h2>
<table class="con_text2" style="background:none; color:#fff; border:0px;">
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

  <%--    <asp:TemplateField HeaderText="Balance">
    <ItemTemplate>
   <%# Eval("Balance")%>
    </ItemTemplate>
     </asp:TemplateField>
--%>

     
       <asp:TemplateField HeaderText="Amount">
    <ItemTemplate>
   <%# Eval("Amount")%>
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
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 950px;
        }
    </style>
</asp:Content>

