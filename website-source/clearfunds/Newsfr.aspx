<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Newsfr.aspx.vb"  MasterPageFile="~/ContentMaster.master"    Inherits="Newsfr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:HyperLink ID="HyperLink1" NavigateUrl="~/News.aspx" runat="server" CssClass="backmode"></asp:HyperLink>
   <div id="div1" runat="server" class="peocontent">




    </div>

    <div id="div2" runat="server" class="peocontent" >
    </div>
</asp:Content>