<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="AddrefBonus.aspx.vb" Inherits="Admin_AddrefBonus" %>

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
<script type="text/javascript" >

    function validateText(e) {
        var unicode = e.charCode ? e.charCode : e.keyCode
        if (unicode > 48 && unicode < 57)
            return false;
        else
            return true;
    }

    function numbersonly(e) {
        var unicode = e.charCode ? e.charCode : e.keyCode
        if (unicode != 8 && unicode != 9 && unicode != 46) { //if the key isn't the backspace key (which we should allow)
            if (unicode < 48 || unicode > 57) //if not a number
                return false //disable key press
        }
    }
    // Now the Ajax CAPTCHA validation checkcode(document.myform.code.value); return false;
  

    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>Add/Edit Addref Bonus</h2>
<div>
<table class="con_text2">

<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtName" runat="server"   CssClass="validate[required] inputbox smallbox"></asp:TextBox>
    </td>
</tr>


<tr>
<td>
    <asp:Label ID="Label2" runat="server" Text="From:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtfrom" onkeypress="return numbersonly(event)" runat="server"  CssClass="validate[required] inputbox smallbox"></asp:TextBox>
    </td>
</tr>


<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="To:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtto" runat="server" onkeypress="return numbersonly(event)"  CssClass="validate[required] inputbox smallbox"></asp:TextBox>
    </td>
</tr>

<tr>
<td>
    <asp:Label ID="Label4" runat="server" Text="Commision (%):"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtcommision" runat="server" onkeypress="return numbersonly(event)" CssClass="validate[required] inputbox smallbox"></asp:TextBox>
    </td>
</tr>

<tr>
<td></td>
<td>
    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnalt" />

</td>
</tr>

</table>

    ip9u9p</div>

</asp:Content>