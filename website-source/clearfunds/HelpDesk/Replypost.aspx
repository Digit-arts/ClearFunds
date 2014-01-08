<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Replypost.aspx.vb" MasterPageFile="~/HelpDesk/Helpmember.master" Inherits="Account_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../css/l_style.css" type="text/css" rel="Stylesheet" />

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


    <div class="helpfrm_one">
        <label>Ticket:</label>
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
 </div>
<div class="helpfrm_one">

 <label>Opened Date:</label>
      <div class="helpfrm_right"><asp:Label ID="lblopen" runat="server" Text=""></asp:Label></div>
 </div>
 <div class="helpfrm_one">
    <label>Status:</label>
     <div class="helpfrm_right"><asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></div>
 
 </div>
 <div class="helpfrm_one">
    <label>Category:</label>
     <div class="helpfrm_right"><asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label></div>
 </div>
 
  <div class="helpfrm_one">
    <label>AttachFile:</label>
     <div class="helpfrm_right">
         <asp:LinkButton ID="LinkButton1" runat="server" ></asp:LinkButton></div>
 </div>


       
         
          <div id="div1" runat="server" >
          <div id="div2" runat="server" >
    </div>

    </div>
    
    <div class="helpfrm_one">
        <div class="helpfrm_right">
         <asp:Button ID="Button1"  OnClick="Button2_Click" runat="server" Text="REPLY" />
           
        </div>
    </div>
        <div id="post" visible="false" runat="server"  class="helpfrm_right">
         <asp:TextBox ID="txtpost" runat="server" Height="100" Width="500" TextMode="MultiLine"></asp:TextBox> <br />
          <asp:Button ID="Button2"  OnClick="Button1_Click" runat="server" Text="Post" />
           
   

</div>      
</asp:Content>  

