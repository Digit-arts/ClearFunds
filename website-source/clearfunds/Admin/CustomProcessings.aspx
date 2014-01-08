<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="CustomProcessings.aspx.vb" Inherits="Admin_CustomProcessings" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
<h2>Custom processing</h2>
<div>

<table class="con_text2">

<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="Status"></asp:Label>
    </td>
<td>
    <asp:CheckBox ID="chkstatus" runat="server" />

</td>
</tr>
<tr>
<td>
<asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtname" runat="server" CssClass="validate[required] inputbox smallbox"></asp:TextBox>

</td>
</tr>
<tr>
<td>
<asp:Label ID="Label5" runat="server" Text=" Payemnt URL"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txturl" runat="server" CssClass="validate[required] inputbox smallbox"></asp:TextBox>

</td>
</tr>
<tr>
<td>
<asp:Label ID="Label3" runat="server" Text="Payment notes:"></asp:Label>
</td>
<td>
 <asp:TextBox ID="txtpaymentnotes" runat="server" CssClass ="inputbox smallbox" TextMode="MultiLine" style="width:390px; height:110px; "></asp:TextBox>
</td>
</tr>
</table>

<table class="con_text2 inncontt">
<tr>
<td>
<asp:Label ID="Label4" runat="server" Text="Information Fields:"></asp:Label>
</td>
</tr>
<tr>
<td>
    <asp:CheckBox ID="chkffield1" runat="server" AutoPostBack="true" Text="Field 1:" />
</td>
<td>
<asp:TextBox ID="txtfield1" runat="server" CssClass ="inputbox smallbox" Enabled="False"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:CheckBox ID="chkffield2" runat="server" AutoPostBack="true" Text="Field 2:"  />
</td>
<td>
&nbsp;<asp:TextBox ID="txtfield2" runat="server" CssClass ="inputbox smallbox" Enabled="False"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:CheckBox ID="chkffield3" runat="server" AutoPostBack="true" Text="Field 3:"  />
</td>
<td>
<asp:TextBox ID="txtfield3" runat="server" CssClass ="inputbox smallbox" Enabled="False"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:CheckBox ID="chkffield4" runat="server" AutoPostBack="true" Text="Field 4:"  />
</td>
<td>
<asp:TextBox ID="txtfield4" runat="server" CssClass ="inputbox smallbox" Enabled="False"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:CheckBox ID="chkffield5" runat="server" AutoPostBack="true" Text="Field 5:"  />
</td>
<td>
<asp:TextBox ID="txtfield5" runat="server" CssClass ="inputbox smallbox" Enabled="False"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:CheckBox ID="chkffield6" runat="server" AutoPostBack="true"  Text="Field 6:" />
</td>
<td>
<asp:TextBox ID="txtfield6" runat="server" CssClass ="inputbox smallbox" Enabled="False"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:CheckBox ID="chkffield7" runat="server"  AutoPostBack="true" Text="Field 7:" />
</td>
<td>
<asp:TextBox ID="txtfield7" runat="server" CssClass ="inputbox smallbox" Enabled="False"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:CheckBox ID="chkffield8" runat="server" AutoPostBack="true" Text="Field 8:"  />
</td>
<td>
<asp:TextBox ID="txtfield8" runat="server" CssClass ="inputbox smallbox" Enabled="False"></asp:TextBox>
</td>
</tr>
</table>

<table class="con_text2 inncontt">
<tr>
<td>

<asp:Label ID="Label13" runat="server" Text="Insert Icon:"></asp:Label>
  </td>
  <td>
    <asp:FileUpload ID="FileUpload1" runat="server" /> 
    

 </td>
 <td >
    <asp:Image ID="Image4" runat="server"   Width ="250px" Height="200px"  />

    </td>
</tr>
<tr>
<td></td>
<td style="margin-left:170px;">
 <asp:Button ID="btnAdd" runat="server" Text="Add Processing" CssClass="btnalt "></asp:Button>
</td>
</tr>

</table>



</div>





</asp:Content>