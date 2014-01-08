<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LibertySuccess.aspx.vb"   MasterPageFile="~/AccountMaster.master"    Inherits="Success" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
 
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <div>
  
    <asp:Label  ID="Label1" Font-Size="Large"  runat="server" Text=" Payment received successfully!!!"
        ForeColor="Green" Visible="true"></asp:Label><br />
       
            
        <asp:Label ID="lblDet" runat="server" Text="Label"></asp:Label>
    </div>
    
    </asp:Content>