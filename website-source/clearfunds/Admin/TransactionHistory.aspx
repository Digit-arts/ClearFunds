<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TransactionHistory.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_TransactionHistory" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 823px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Members</h2>
<div>
<asp:GridView ID="GVMembersList"  AutoGenerateColumns="False" runat="server" 
        CssClass="pack_tab">
    <Columns>
  
    
     
   <%-- <asp:BoundField HeaderText="User Name"  DataField="UserName" />--%>

    <asp:TemplateField HeaderText="User Name">
    <ItemTemplate>
   <%# Eval("UserName")%>
    </ItemTemplate>

    </asp:TemplateField>
    <asp:TemplateField HeaderText="Date">
    <ItemTemplate>

    <%# Eval("Date")%>
    </ItemTemplate>
    

    </asp:TemplateField>
  
  
     
  
    <asp:TemplateField  HeaderText="Amount">
  <ItemTemplate>
  
  <%# Eval("Amount")%>
  </ItemTemplate>
     
   </asp:TemplateField>
   
    
      
      <asp:BoundField DataField="Deposit_PayName" HeaderText="Deposit Method" />
      <asp:BoundField DataField="Deposit_SysIp" HeaderText="IP Address" />
      <asp:BoundField DataField="Deposit_CountryName" HeaderText="Country Flag" />

 

       
    </Columns> 
    
</asp:GridView>

</div>
    
    <div>
<div class="depos_con">
 <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>
 
 <asp:Label ID="lblAmt" runat="server"></asp:Label>
 </div>
 </div>

  
</asp:Content>
