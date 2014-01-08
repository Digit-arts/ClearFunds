<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Site.master" AutoEventWireup="false" CodeFile="AddEditRules.aspx.vb" Inherits="Admin_AddEditRules" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h2>Add/Edit Advertisementt Rules</h2>
    <div>
<table class="con_text2">
<tr>
 <td>
  <asp:Label ID="lblsub" Text="subjects" runat="server"  ></asp:Label>
 </td>
   <td>
       <asp:TextBox ID="txtsub" runat="server" CssClass="validate[required] inputbox smallbox"></asp:TextBox>
   </td>
 
</tr>
 
<tr>
<td>
    <asp:Label ID="Desc" runat="server" Text="Description"></asp:Label>
</td>
<td colspan="3" >
    <cc1:Editor ID="HtmlEditor"   Width="800px" Height="250px"  runat="server" /> 
         
    
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblactive" runat="server" Text="Active"></asp:Label>
    <asp:CheckBox ID="chkActive"  runat="server" />
</td>
</tr>
 
<tr>
<td>
</td>
<td colspan="3">
    <asp:Button ID="savebutton" CssClass ="btnalt" runat="server" Text="Save" />
 </td>
</tr>
</table>
</div>

</asp:Content>

