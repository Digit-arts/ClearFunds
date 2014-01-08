<%@ Page Language="VB" AutoEventWireup="false"   CodeFile="ReferralsDetails.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="ReferralsHistory" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    <h2>REFERRALS HISTOYR</h2>
<table class="con_text1">
<tr>
<%--<td style="width:auto; float:left;">

    <asp:DropDownList ID="dtbDebositdetails" runat="server">   </asp:DropDownList>
</td>--%>

<td style="width:280px; float:left;">
<asp:Label ID="Label1" runat="server" Text="From" style="float:left; margin-right:7px; padding-top:7px; "></asp:Label>
<asp:TextBox ID="txtfrom" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
    <asp:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" 
        TargetControlID="txtfrom">      
    </asp:CalendarExtender>
</td>


<td style="width:250px; float:left;">
<asp:Label ID="Label2" runat="server" Text="To" style="float:left; margin-right:7px; padding-top:7px;"></asp:Label>
<asp:TextBox ID="txtto" runat="server"  CssClass="inputbox smallbox"></asp:TextBox>
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
<asp:GridView ID="GVreferralHistory"  AutoGenerateColumns="false" runat="server">
<Columns>



      <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
   <%# Eval("User_FirstName")%>
    </ItemTemplate>
     </asp:TemplateField>


     
     
       <%--<asp:TemplateField HeaderText="Amount">
    <ItemTemplate>
   <%# Eval("Amount")%>
    </ItemTemplate>
     </asp:TemplateField>--%>



       <asp:TemplateField HeaderText=" date">
    <ItemTemplate>
   <%# Eval("Date")%>
    </ItemTemplate>
     </asp:TemplateField>


<%--
       <asp:TemplateField HeaderText="Commision">
    <ItemTemplate>
   <%# Eval("Commision")%>
    </ItemTemplate>
     </asp:TemplateField>

--%>

        


    </Columns>
</asp:GridView>



</asp:Content>




