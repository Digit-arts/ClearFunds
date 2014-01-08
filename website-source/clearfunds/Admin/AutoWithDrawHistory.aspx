<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AutoWithDrawHistory.aspx.vb" MasterPageFile="~/Admin/Site.master"  Inherits="Admin_AutoWithDrawHistory" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>AutoWithDrawl History</h2>
 
<asp:GridView ID="GVPaymentDetails" ShowHeaderWhenEmpty="true"  AutoGenerateColumns="false" runat="server" class="pack_tab">

<Columns>




       <asp:TemplateField HeaderText="UserName">
    <ItemTemplate>
   <%# Eval("UserName")%>
    </ItemTemplate>
     </asp:TemplateField>


       <asp:TemplateField HeaderText="WithDrawl Date ">
    <ItemTemplate>
   <%# Eval("Date")%>
    </ItemTemplate>
     </asp:TemplateField>

     
       <asp:TemplateField HeaderText="WithDrawl Amount">
    <ItemTemplate>
   <%# Eval("Amount")%>
    </ItemTemplate>
     </asp:TemplateField>
      

        


    </Columns>
    <EmptyDataTemplate>
    No Records Found
    </EmptyDataTemplate>
</asp:GridView>


<div>
 &nbsp;&nbsp;&nbsp;
 <div class="depos_con">
 <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label>
 
 <asp:Label ID="lblAmt" runat="server"></asp:Label>

 </div>
 </div>


</asp:Content>