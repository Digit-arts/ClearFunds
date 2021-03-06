﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddNews.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_AddNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">


    <script src="js/jquery.validationEngine.js" type="text/javascript"></script>
    <script src="../tinymce/jscripts/tiny_mce/tiny_mce.js" type="text/javascript"></script>
    
 <script type="text/javascript">
     tinyMCE.init({
         mode: "textareas",
         theme: "advanced",
         editor_selector: "mceEditor",
         plugins: "safari,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,imagemanager,filemanager",
         theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
         theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
         theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
         theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
         theme_advanced_toolbar_location: "top",
         theme_advanced_toolbar_align: "left",
         theme_advanced_statusbar_location: "bottom",
         theme_advanced_resizing: false,
         template_external_list_url: "js/template_list.js",
         external_link_list_url: "js/link_list.js",
         external_image_list_url: "js/image_list.js",
         media_external_list_url: "js/media_list.js",
         height: 300
     });
</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<asp:Label ID="Label5" runat="server"><h2 class="head_top">Add News Management</h2></asp:Label><br />
<%--<asp:button runat="server" text="Back to Carreer List" PostBackUrl="~/Administrator/Carrersnew.aspx" ID="btnback"   CssClass="bckct_butt" style="margin-left:10px; "/>--%>
<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Add" ShowMessageBox="true" ShowSummary="false" runat="server" />

<asp:HyperLink ID="HyperLink1"  NavigateUrl="~/Admin/NewsList.aspx"  runat="server" CssClass="bckct_butt" style="margin-left:10px; " >Back to news List</asp:HyperLink><br /><br />
   


<table class="style6">
      
  <tr>
<td style="width:120px; vertical-align:top;">
    <asp:Label ID="lblsub" runat="server" Text="Company News Title"></asp:Label>
</td>
<td colspan="2">
    <asp:TextBox ID="txtsub" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtsub" ForeColor="Red" ValidationGroup="Add" runat="server" ErrorMessage="Comapany Title English required">*</asp:RequiredFieldValidator>
</td>

</tr>
 <tr>
        <td style="width:120px; vertical-align:top;">
           Summary Description</td>
        <td colspan="2" align="left" style="float:left; width:58%;">
              <asp:TextBox ID="mce_editor_0" TextMode="MultiLine" runat="server"  CssClass="mceEditor"></asp:TextBox>
        </td>
           
    </tr>
     <tr>
        <td  style="width:120px; vertical-align:top;">
           Detailed Description</td>
        <td colspan="2" align="left" style="float:left; width:58%;">
            <asp:TextBox ID="mce_editor_1" TextMode="MultiLine" runat="server"  CssClass="mceEditor"></asp:TextBox>
        </td>
           
    </tr>
    
</table>


<table style="width:90%;">
    <tr>
        <td valign="top" style="width:9%; float:left; ">
                 <asp:Label ID="lblimg" runat="server" Text="Image"></asp:Label>
            </td>
        <td valign="top" style="width:89%; float:right; ">    <asp:FileUpload ID="FileUpload1" runat="server" style="float:left; " />
            
           
            </td>

    </tr>
    <tr><td valign="top" style="width:9%; float:left; "></td><td valign="top" style="width:89%; float:right; ">  <asp:Image ID="Image1"  Height="155px" Width="155px" ImageUrl="~/images/index.jpg" runat="server" style="margin:0px 5px; " /></td></tr>

    <tr>
        <td style="width:150px; vertical-align:top;"> <span style="width:auto; height:auto; float:left; padding-top:12px;">Status:</span></td>
        <td vcolspan="2" align="left" style="float:left; width:58%;"> <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal" style="float:left; width:200px; border:0px; ">
     <asp:ListItem Text ="Active" Value ="1" Selected="True" ></asp:ListItem>
     <asp:ListItem Text ="Inactive" Value ="0" ></asp:ListItem>
    </asp:RadioButtonList></td>

    </tr>
    <tr> <td style="width:9%; float:left; "></td><td valign="top" style="width:89%; float:right; "> <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="Add" onclick="Button1_Click" CssClass="yellow_btn" />
    <asp:Label ID="lblid" runat="server" Visible ="false"  ></asp:Label></td></tr>


</table>
</asp:Content>