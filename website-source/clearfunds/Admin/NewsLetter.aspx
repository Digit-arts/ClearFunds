<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="NewsLetter.aspx.vb" Inherits="Admin_NewsLetter" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
 
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
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <h2>News letter</h2>
    <table class="con_text2">
   <tr>
           
            <td>

                <asp:Label ID="Label3" runat="server" Text="Being Sent to :"></asp:Label>
            </td>
            <td>

                <asp:DropDownList ID="cmbsentuser" runat="server" OnSelectedIndexChanged="cmbsentuser_Changed" AutoPostBack="true"  Height ="35px" Width="335px" style="margin:0 0 0 8px;">
                 <asp:ListItem Text="Select" />
                   <asp:ListItem Text="One user" />
                   <asp:ListItem Text="All user" />
                   <asp:ListItem Text="All users which have made deposit" />
                   <asp:ListItem Text="All users which doesn't made deposit" />
                </asp:DropDownList>
            </td>
        </tr>
         
          <tr>
            <td>

                <asp:Label ID="Label5" runat="server" Text="UserName :"></asp:Label>
            </td>
            <td>


                <asp:TextBox ID="txtToMembers" runat="server"    Width="317" Height="110" TextMode="MultiLine"
                   CssClass="validate[required] inputbox smallbox" style="margin:0 0 0 8px;"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>

                <asp:Label ID="Label6" runat="server" Text="Subject :"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="txtDescription" runat="server"  style="margin:0 0 0 8px;" CssClass ="inputbox smallbox"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td>

                <asp:Label ID="Label1" runat="server" Text="Text Messsge :"></asp:Label>
            </td>
            <td>
             <cc1:Editor ID="Editor1"  Height="300" Width="800" runat="server" />
                
            </td>
        </tr>
   <tr>
            <td>
                </td>
            <td>

                <asp:Button ID="cmdSendBonus" runat="server" Text="Send NewsLetter"  style="margin:0 0 0 8px;" OnClick="SendEmail" CssClass ="btnalt"/>
                <asp:Label ID="lblmessage"    Visible="false" ForeColor="Green" runat="server" Text="Mail Has Been Sent SuccessFully"></asp:Label>
            </td>
            
     
        </tr>
</table>

</asp:Content>