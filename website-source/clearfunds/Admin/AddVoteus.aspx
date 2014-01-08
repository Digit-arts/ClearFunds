<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddVoteus.aspx.vb"  MasterPageFile="~/Admin/Site.master" Inherits="Admin_AddVoteus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

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

<asp:Label ID="Label5" runat="server"><h2 class="head_top">Add Voteus Management</h2></asp:Label><br />
<%--<asp:button runat="server" text="Back to Carreer List" PostBackUrl="~/Administrator/Carrersnew.aspx" ID="btnback"   CssClass="bckct_butt" style="margin-left:10px; "/>--%>
<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Add" ShowMessageBox="true" ShowSummary="false" runat="server" />

<asp:HyperLink ID="HyperLink1"  NavigateUrl="~/Admin/VoteImageList.aspx"  runat="server" CssClass="bckct_butt" style="margin-left:10px; " >Back to VoteUs List</asp:HyperLink><br /><br />
   


<table class="style6">

      
  <tr>
<td style="width:120px; vertical-align:top;">
    <asp:Label ID="lblsub" runat="server" Text="Voteus Title"></asp:Label>
</td>
<td colspan="2">
    <asp:TextBox ID="txtsub"  runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtsub" ForeColor="Red" ValidationGroup="Add" runat="server" ErrorMessage="VoteUs Title required">*</asp:RequiredFieldValidator>
</td>

</tr>
  <tr>
<td style="width:120px; vertical-align:top;">
    <asp:Label ID="Label1" runat="server" Text="Voteus Image Url"></asp:Label>
</td>
<td colspan="2">
    <%--<asp:TextBox ID="txturl" TextMode="MultiLine" runat="server"></asp:TextBox>
   --%>
    <cc1:Editor ID="HtmlEditor"   Width="800px" Height="250px"   runat="server" /> 
  
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
        ControlToValidate="HtmlEditor" ForeColor="Red" ValidationGroup="Add" 
        runat="server" ErrorMessage="VoteUs Url required">*</asp:RequiredFieldValidator>
</td>

</tr>
    <tr>
        <td valign="top" style="width:9%; float:left; ">
                 <asp:Label ID="lblimg" runat="server" Text="VoteUs Image"></asp:Label>
            </td>
        <td valign="top" style="width:89%; float:right; ">  
        
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <%--<asp:AjaxFileUpload ID="FileUpload1" runat="server" />--%>
           
            </td>
            <td>
                <asp:Image ID="Image1" Height="155px" Width="155px" runat="server" />
                <%--<asp:ImageButton ID="ImageButton1" runat="server" />--%>
            </td>
    </tr>

   <tr>
        <td style="width:9%; float:left; "> <span style="width:auto; height:auto; float:left; padding-top:12px;">Status:</span></td>
        <td valign="top" style="width:89%; float:right; "> <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal" style="float:left; width:200px; border:0px; ">
     <asp:ListItem Text ="Active" Value ="1" Selected="True" ></asp:ListItem>
     <asp:ListItem Text ="Inactive" Value ="0" ></asp:ListItem>
    </asp:RadioButtonList></td>

    </tr>
    <tr> <td style="width:9%; float:left; "></td><td valign="top" style="width:89%; float:right; "> <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="Add" onclick="Button1_Click" />
    <asp:Label ID="lblid" runat="server" Visible ="false"  ></asp:Label></td></tr>
    
</table>
</asp:Content>