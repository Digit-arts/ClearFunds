<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IpDetails.aspx.vb"  MasterPageFile="~/AccountMaster.master"  Inherits="Account_IpDetails" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
  
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">

 <div class="acc_table">
 <h2 style="left:317px;">Ip HISTORY</h2>
 <asp:GridView   ID="GVDepositHistory" runat="server" AutoGenerateColumns="false">

<Columns >


      <asp:TemplateField HeaderText="ServerIp">
    <ItemTemplate>
   <%# Eval("Ipname")%>
    </ItemTemplate>
     </asp:TemplateField>
    
      <asp:TemplateField HeaderText="Server Name">
    <ItemTemplate>
   <%# Eval("serverName")%>
    </ItemTemplate>
     </asp:TemplateField>
     
      <asp:TemplateField HeaderText="Login UserName">
    <ItemTemplate>
   <%# Eval("Loginname")%>
    </ItemTemplate>
     </asp:TemplateField>

       <asp:TemplateField HeaderText="Login password">
    <ItemTemplate>
   <%# Eval("loginpw")%>
    </ItemTemplate>
     </asp:TemplateField>






        


    </Columns>
    
</asp:GridView>
 <div>
 
 <table class="acc-table">
 
 <tr>
 
 <td>
Deposit Credit
 <asp:Label ID="Label3" runat="server" Text="Credit"></asp:Label>
 </td>
  <td>
 <asp:Label ID="lblAmt" runat="server"></asp:Label>
 </td>
 </tr>
 </table>
 </div>
</div>

</asp:Content>