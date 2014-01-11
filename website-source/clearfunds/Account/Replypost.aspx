<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Replypost.aspx.vb" MasterPageFile ="~/AccountMaster.master" Inherits="Account_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link href="../css/l_style.css" type="text/css" rel="Stylesheet" />
    <style type="text/css" >
.alertclose
{
    width:98%; height:24px; float:left; background:#F6BD08; padding:5px;
}
.alert_txt
{
    width:auto; height:24px; float:left; overflow:hidden; padding-left:20px;
}
</style>
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
    <label>Commnents:</label>
     <div class="helpfrm_right"><asp:Label ID="lblComments" runat="server" Text=""></asp:Label></div>
 </div>
 <div class="alertclose" runat="server" id="alert1" visible="false" >

 <img src="../images/1382198980_messagebox_info.png" />
    <label >
        <asp:Label ID="lblalert1" runat="server" Text=""></asp:Label></label>
    </div>

    <div class="helpfrm_one">
        <div class="helpfrm_right">
         <asp:Button ID="Button5"  OnClick="Button5_Click" runat="server" Text="REPLY" />&nbsp;
         <asp:Button ID="Button6"  OnClick="Button6_Click" runat="server" Text="CLOSE" ToolTip="Close The Ticket" />
           
        </div>
    </div>
     <div id="div1" runat="server" >
          <div id="div2" runat="server" >
    </div>

    </div>
     <div class="alertclose" runat="server" id="alert" visible="false" >
       <img src="../images/1382198980_messagebox_info.png" />
    <label >
        <asp:Label ID="lblalert" runat="server" Text=""></asp:Label></label>
    </div>
         <div class="helpfrm_one">
        <div class="helpfrm_right">
         <asp:Button ID="Button1" Visible="false"   OnClick="Button1_Click" runat="server" Text="REPLY" />&nbsp;
         <asp:Button ID="Button3" Visible="false"   OnClick="Button3_Click" runat="server" Text="CLOSE" ToolTip="Close The Ticket" />
           
        </div>
    </div>
        <div id="post" visible="false" runat="server">
         <asp:TextBox ID="txtpost" runat="server" Height="100" Width="500" TextMode="MultiLine"></asp:TextBox><br />
       
           <label>AttachFile:</label>   <asp:FileUpload ID="FileUpload1" runat="server"  />
        
             
         
        <div class="helpfrm_right">
          <asp:Button ID="Button2"  OnClick="Button2_Click" runat="server" Text="POST" />&nbsp;
           <asp:Button ID="Button4"  OnClick="Button4_Click" runat="server" Text="CANCEL" />
           </div>
             </div>
 
</asp:Content>  

