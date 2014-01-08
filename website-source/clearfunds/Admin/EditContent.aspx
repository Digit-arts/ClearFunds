<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditContent.aspx.vb" MasterPageFile="~/Admin/Site.master" Debug="true"Inherits="Admin_EditContent" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../css/template.css" rel="stylesheet" type="text/css" />
<link href="../css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.min.js" type="text/javascript"></script>
    <script src="js/jquery.validationEngine-en.js" type="text/javascript"></script>
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
     

<%--<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery("#form1").validationEngine();
    });
</script>--%>

    <style type="text/css">
.accordionContent {
border-color: -moz-use-text-color #2F4F4F #2F4F4F;
border-right: 1px dashed #2F4F4F;
border-style: none dashed dashed;
border-width: medium 1px 1px;
padding: 10px 5px 5px;
width:98%;
}
.accordionHeaderSelected {
background-color: #DE0F0F;
border: 1px solid #2F4F4F;
color: white;
cursor: pointer;
font-family: Arial,Sans-Serif;
font-size: 12px;
font-weight: bold;
margin-top: 5px;
padding: 5px;
width:98%;
}
.accordionHeader {
background-color: #484848;
border: 1px solid #2F4F4F;
color: white;
cursor: pointer;
font-family: Arial,Sans-Serif;
font-size: 12px;
font-weight: bold;
margin-top: 5px;
padding: 5px;
width:98%;
}
.href
{
color:White;  
font-weight:bold;
text-decoration:none;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server"><h2 class="head_top">Add Content Management System</h2></asp:Label>
<asp:button runat="server" text="Back to Content List" PostBackUrl="contentmanage.aspx" ID="btnback" CssClass="bckct_butt" />


<table>
   


<tr>
<td class="style1" style="width:90px;">Page Level:</td>

<td width="800px" colspan="2">
    <asp:dropdownlist runat="server" Width="137px" ID="cmbpagelevel" style="width:140px; float:left; padding:3px; border:1px solid #c3c3c3;"></asp:dropdownlist>


</td>
</tr>


</table>
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Add" ShowMessageBox="true" ShowSummary="false" runat="server" />

 
<asp:Panel ID="UserReg" runat="server">
<table>
<tr>
<td class="style1" style="vertical-align:top;">Header Title</td>
<td>

    <asp:textbox runat="server"  ID="txtheadertitleEN"  ></asp:textbox>
  
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtheadertitleEN" ValidationGroup="Add" ForeColor="Red" runat="server" ErrorMessage="HeaderTitle English required">*</asp:RequiredFieldValidator>
    <br />
 <asp:checkbox runat="server" text=" Publish to the navigation system" 
        ID="chkheadertitle" CssClass="check_tbox"></asp:checkbox>
<br />

</td>
</tr>

    



<tr>
<td class="style1" style= "vertical-align:top">Meta Title</td>
<td colspan="2">
<asp:textbox runat="server" ID="txtmetatitle"></asp:textbox>
</td>
</tr>
<tr>
<td class="style1" style="vertical-align:top">Meta Keyword</td>
<td colspan="2">
<asp:textbox runat="server" ID="txtmetakeyword"></asp:textbox>
</td>
</tr>
<tr>
<td style="vertical-align:top;" class="style1">Meta Description</td>
<td colspan="2" valign="top">
 
<asp:textbox runat="server"  ID="txtmetadescription"  TextMode="MultiLine"  style="width:316px; height:95px;"></asp:textbox>
 
</td>
</tr>



<tr>
<td class="style1" style="vertical-align:top;">Website Content English:</td>
<td  colspan="2">

          


        <asp:TextBox ID="mce_editor_0" runat="server" TextMode = "MultiLine"  CssClass="mceEditor" ></asp:TextBox><br />
        </td>
        </tr>
        <tr>
            <td></td>
        
        
        </tr>
  </table>
  <div style="width:850px; height:auto;">

  <div style="width:372px; height:400px; float:left;"></div>
    <div style="width:400px; height:400px; float:left;">
        <table class="adm_tab">
        <tr>
            <td style="width:120px; float:left;"> Upload Image </td>
            <td style="width:300px; float:left;"> <asp:FileUpload ID="FileUpload1"  style="width:181px; margin:0px 25px 0px 22px;"  runat="server" /></td>
            <td style="width:40px; float:left;"> <asp:Button ID="btnUpload"  runat="server" OnClick="btnUpload_Click" Text="Upload"/></td>
        
        
        
        </tr>
        <tr>
            <td style="width:60px; float:left;"> Height </td>
            <td  style="width:120px; float:left;"><asp:TextBox ID="txtheight" style="width:90px; margin:0px 12px 0px 13px; " runat="server"></asp:TextBox></td>
           
        <td  style="width:60px; float:left; "> width</td>
             <td  style="width:90px; float:left;"><asp:TextBox ID="txtwidth" style="width:90px; "  runat="server"></asp:TextBox></td>
     
        </tr>
        <tr>
            <td style="width:207px; float:left;"><asp:Label ID="Label3" runat="server" Text="Status" style="width:auto; height:auto; float:left; padding-top:7px;"></asp:Label></td>
            <td style="width:120px; float:left;"><asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal" style="float:right;">
     <asp:ListItem Text ="Active" Value ="1" Selected="True" ></asp:ListItem>
     <asp:ListItem Text ="Inactive" Value ="0" ></asp:ListItem>
    </asp:RadioButtonList></td>
        
        </tr>
        <tr>
            <td style="width:138px; float:left;"></td>
            <td style="width:120px; float:left;"><asp:Button runat="server" Text="Save" OnClick="btnsave_Click" ID="btnsave" ValidationGroup="Add" ></asp:Button></td>
        </tr>
        </table>
        
        </div>
        </div>

        <div class="button_full">

    
    <div class="browse">
    
       
        </div>
         <asp:Label ID="lblDisplay" runat="server" Text="" Visible = "false" ></asp:Label>
         </div>









</asp:Panel>


<div style="width:100%;height:auto; float:left; padding-top: 4px; padding-left: 15px; ">




<%--<asp:Button runat="server" Text="Cancel" ID="btncancel" onclick="btncancel_Click"></asp:Button>--%>
    <asp:Label ID="lblmsg" runat="server"  ></asp:Label>
    <asp:Label ID="Lblrow" runat="server" Visible="false" Text=""></asp:Label>
</div>

<div>


</div>

</asp:Content>