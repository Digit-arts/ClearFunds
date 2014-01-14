<%@ Page Title="" Language="VB"  MasterPageFile="ContentMaster.master" AutoEventWireup="false" CodeFile="rules.aspx.vb" Inherits="rules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class ="ContentPadding ">
        <div class="abtus_cnt"><asp:Label ID="Label12" runat="server" Text=""></asp:Label> </div>
        <div class="picrules"><asp:Image ID="imgrules" runat="server" ImageUrl="~/Images/rules.jpg" class="picrules"/></div>
        <div id="divcontent" runat="server" class="inne_ctes"></div>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </div>
 

<div class="support_txtbx"></div> 
<div id="divrules1" class="rules" runat ="server"></div>
 


</asp:Content>

