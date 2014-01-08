<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewMessage.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_NewMessage" %>
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

<asp:Label ID="Label5" runat="server"><h2 class="head_top">Add Messages </h2></asp:Label><br />
<%--<asp:button runat="server" text="Back to Carreer List" PostBackUrl="~/Administrator/Carrersnew.aspx" ID="btnback"   CssClass="bckct_butt" style="margin-left:10px; "/>--%>
<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Add" ShowMessageBox="true" ShowSummary="false" runat="server" />

<asp:HyperLink ID="HyperLink1"  NavigateUrl="~/Admin/MessageList.aspx"  runat="server" CssClass="bckct_butt" style="margin-left:10px; " >Back to Message List</asp:HyperLink><br /><br />
   


<table class="style6">
      
  <tr>
<td style="width:120px; vertical-align:top;">
    <asp:Label ID="lblsub" runat="server" Text="Message Title"></asp:Label>
</td>
<td colspan="2">
    <asp:TextBox ID="txtsub" runat="server" CssClass="validate[required] inputbox smallbox"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtsub" ForeColor="Red" ValidationGroup="Add" runat="server" ErrorMessage="Message Title English required">*</asp:RequiredFieldValidator>
</td>

</tr>
<tr>
<td style="width:120px; vertical-align:top;">
    <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
</td>
<td colspan="2">
    <asp:CheckBoxList ID="chkUsers" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="flow" >
    </asp:CheckBoxList>
</td>

</tr>
 <tr>
        <td style="width:120px; vertical-align:top;"> <asp:Label ID="Label1" runat="server" Text="Message Description"></asp:Label>
          </td>
        <td colspan="2" align="left" style="float:left; width:58%;">
              <asp:TextBox ID="mce_editor_0" TextMode="MultiLine" runat="server"  CssClass="mceEditor" ></asp:TextBox>
        </td>
           
    </tr>

    <tr> 
    <td></td><td colspan="2" align="left" style="float:left; width:58%;"> 
    <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="Add" onclick="Button1_Click" CssClass="yellow_btn" />
    <asp:Label ID="lblid" runat="server" Visible ="false"  ></asp:Label>
    </td>
    </tr>  
    
</table>



</asp:Content>