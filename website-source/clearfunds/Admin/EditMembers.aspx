<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="EditMembers.aspx.vb" Inherits="Account_editmemberaccount" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 129px;
        }
    </style>
    <link href="css/template.css" rel="stylesheet" type="text/css" />
<link href="css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-1.6.min.js" type="text/javascript"></script>
<script src="js/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
<script src="js/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery("#form1").validationEngine();
    });
</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <h2>add/edit Member</h2>
    <div class="plan_con" style="width:41% !important;">
<table>
<tr>
<td class="style1">
    <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtname" runat="server" CssClass =" inputbox smallbox "></asp:TextBox>
        </td>
  </tr>
  
  <tr>
  <td class="style1">
      <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cmbstatus" runat="server" Height ="35px" Width="217px" CssClass="inputbox smallbox ">
              <asp:ListItem Selected="True">Active</asp:ListItem>
             <asp:ListItem>Non Active</asp:ListItem>
              <asp:ListItem>Disabled</asp:ListItem>
                <asp:ListItem>Suspended</asp:ListItem>
                <asp:ListItem> Not confirmed</asp:ListItem>
            </asp:DropDownList>
                    </td>

          </tr>
          </table>
          <table class="tablcon" style="margin:0px; ">
          <tr>
          <td>
              <asp:CheckBox ID="chkzautoWE" runat="server"  CssClass ="input, textarea "/>
              <asp:Label ID="Label1" runat="server" Text="Auto-withdrawal enabled"></asp:Label>
                </td>
          </tr>
        <tr>
             <td>
              <asp:CheckBox ID="chkecurrencyacc" runat="server" CssClass ="input, textarea " />
                     <asp:Label ID="Label2" runat="server" Text="Transfer earnings directly to the user's e-currency account"></asp:Label> 
               </td>
     </tr>
     </table>
     <table>

     <tr>
     <td class="style1">
         <asp:Label ID="Label3" runat="server" Text="Max daily withdraw:"></asp:Label>
      </td>
      <td>
          <asp:TextBox ID="txtmaxdailywithdraw"  runat="server" CssClass="validate[required] inputbox smallbox"></asp:TextBox>
           <asp:Label ID="Label4" runat="server" Text="set 0 to skip limits"></asp:Label>
      </td>
     </tr>
     </table>
       <table  class="tablcon" style="margin:0px; ">
     <tr>
    <td>
              <asp:CheckBox ID="chkresetsec" runat="server" CssClass ="input, textarea " />
               <asp:Label ID="Label5" runat="server" Text=" Reset security settings (check it if user does not receive login pin and cannot login for this reason)"></asp:Label> 
               </td>
     </tr>
  </table>
  <table>
     <tr>
   <td class="style1" style="width:130px; float:left">
      <asp:Label ID="Label6" runat="server" Text="Admin Note:"></asp:Label>
     </td>
  <td style="float:left;">
         <asp:TextBox ID="txtadminnote" runat="server" Height="110" Width="380" 
             TextMode="MultiLine" CssClass ="inputbox smallbox  "></asp:TextBox>
         
  </td>
     </tr>
     <tr>
     <td style="width:130px; float:left;"><asp:Label ID="lblid" runat="server"  Visible="False"></asp:Label>
         </td>
     <td class="style1" style="float:left;">
      <asp:Button ID="cmdSave" runat="server" Text="Save Changes"  CssClass ="btnalt "/>
  </td>
  </tr>
  </table>
</div>
</asp:Content>