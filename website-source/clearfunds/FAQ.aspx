<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/ContentMaster.master"   CodeFile="FAQ.aspx.vb" Inherits="FAQ" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="css/accordion.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:HyperLink ID="HyperLink1" NavigateUrl="~/News.aspx" runat="server" CssClass="backmode"></asp:HyperLink>
<div class="abtus_cnt">
    <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
     <asp:Label ID="Label12" runat="server" Text=""></asp:Label>

</div><div> <asp:Image ID="imgVoteus" runat="server" 
        ImageUrl="~/Images/faq.jpg" /></div>
   <div id="div1" runat="server">
        <asp:Accordion ID="acrDynamic" runat="server" SelectedIndex="0" HeaderCssClass="headerAccordion" ContentCssClass="contentAccordion">
        </asp:Accordion>
    </div>
    
    <div id="div2" runat="server" class="peocontent" >
    </div>
</asp:Content>
