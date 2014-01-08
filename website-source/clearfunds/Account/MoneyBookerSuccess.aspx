<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MoneyBookerSuccess.aspx.vb"  MasterPageFile="~/AccountMaster.master" Inherits="Account_MoneyBookerSuccess" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
 
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <div>
    <font color="red" size="5">Thanks for Order!!!</font><br />
    <asp:Label  ID="Label1" Font-Size="Large"  runat="server" Text=" Payment received successfully!!!"
        ForeColor="Green" Visible="true"></asp:Label><br />
        <%--<h4>
            Payment received successfully!!! We send product to you within 2 to 3 working days!</h4><br />--%>
            
        <asp:Label ID="lblDet" runat="server" Text="Label"></asp:Label>
    </div>
    
    </asp:Content>