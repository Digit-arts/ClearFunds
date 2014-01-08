<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IpHistory.aspx.vb"  MasterPageFile="~/Admin/Site.master" Inherits="Admin_IpHistory" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Ip History</h2>
 
<asp:GridView ID="GVPaymentDetails" ShowHeaderWhenEmpty="true"  AutoGenerateColumns="false" runat="server" class="pack_tab">

<Columns>




       <asp:TemplateField HeaderText="UserName">
    <ItemTemplate>
   <%# Eval("LogName")%>
    </ItemTemplate>
     </asp:TemplateField>


       <asp:TemplateField HeaderText="Login Time ">
    <ItemTemplate>
   <%# Eval("LoginTime")%>
    </ItemTemplate>
     </asp:TemplateField>

     
       <asp:TemplateField HeaderText="LogOut Time">
    <ItemTemplate>
   <%# Eval("LogoutTime")%>
    </ItemTemplate>
     </asp:TemplateField>
      <asp:TemplateField HeaderText="Ip Name">
    <ItemTemplate>
   <%# Eval("IpName")%>
    </ItemTemplate>
     </asp:TemplateField>

        


    </Columns>
    <EmptyDataTemplate>
    No Records Found
    </EmptyDataTemplate>
</asp:GridView>





</asp:Content>