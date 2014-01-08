<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Content.aspx.vb"   MasterPageFile="~/ContentMaster.master"  Inherits="Content" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
<div class="abtus_cnt">
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>

    <asp:Label ID="Label4" ForeColor="Black" Font-Bold="true" runat="server" Text=""></asp:Label></div>
   <div id="divcontent" runat="server" class="inne_ctes">  </div>
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>