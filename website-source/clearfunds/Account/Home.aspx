<%@ Page Language="VB" AutoEventWireup="false"   MasterPageFile="~/AccountMaster.master"   CodeFile="Home.aspx.vb" Inherits="Account_Home" %>
 
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
 
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
 
    <style type="text/css">
        .support
        {}
    </style>
 
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">


<h2 style="left:355px;">home</h2>


    <asp:Panel ID="Panel1" runat="server" CssClass="support" 
     Width="750px">
 
        <p><asp:Label ID="Label1" runat="server" Text="Our program is intended for people willing to achieve their financial freedom but unable to do so because they're not financial experts.

fastyfunds.com is a long term high yield private loan program, backed up by Forex market trading and investing in various funds and activities. Profits from these investments are used to enhance our program and increase its stability for the long term.

fastyfunds.com is a long term high yield private loan program, backed up by Forex market trading and investing in various funds and activities. Profits from these investments are used to enhance our program and increase its stability for the long term."></asp:Label></p> 
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>

     <div id="divRB"  runat ="server" >
       
          
            <asp:HiddenField ID="PressedButton" runat="server" /> 
      



            </div>
  

  
  
      </asp:Panel>
     

 
      
    
        
        
        
</asp:Content>