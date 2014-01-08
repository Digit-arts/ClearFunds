<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="AddFAQ.aspx.vb" Inherits="Admin_FAQ" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="js/jquery.validationEngine.js" type="text/javascript"></script>
    <script src="../tinymce/jscripts/tiny_mce/tiny_mce.js" type="text/javascript"></script>
    

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="Label5" runat="server"><h2 class="head_top">Add Faq Management</h2></asp:Label><br />
<%--<asp:button runat="server" text="Back to Carreer List" PostBackUrl="~/Administrator/Carrersnew.aspx" ID="btnback"   CssClass="bckct_butt" style="margin-left:10px; "/>--%>
<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Add" ShowMessageBox="true" ShowSummary="false" runat="server" />

<asp:HyperLink ID="HyperLink1"  NavigateUrl="~/Admin/FAQList.aspx"  runat="server" CssClass="bckct_butt" style="margin-left:10px; " >Back to FAQ List</asp:HyperLink><br /><br />
   


<table class="style6">
<tr>
 <td>
  <asp:Label ID="lblcatagories" Text="Choose Your Categories:" runat="server"  ></asp:Label>
 </td>
   <td>
       <asp:DropDownList ID="DropDownList1" AutoPostBack="false" runat="server" >
          
       </asp:DropDownList>
         
   </td>
</tr>

      
  <tr>
<td style="width:150px; vertical-align:top;">
    <asp:Label ID="lblsub" runat="server" Text="FAQ Question"></asp:Label>
</td>
<td colspan="2">
    <asp:TextBox ID="txtsub" TextMode="MultiLine" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtsub" ForeColor="Red" ValidationGroup="Add" runat="server" ErrorMessage="FAQ QUESTION required">*</asp:RequiredFieldValidator>
</td>

</tr>
 <tr>
        <td style="width:150px; vertical-align:top;">
           FAQ Answer</td>
        <td colspan="2" align="left" style="float:left; width:58%;">
              <asp:TextBox ID="mce_editor_0" TextMode="MultiLine" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtsub" ForeColor="Red" ValidationGroup="mce_editor_0" runat="server" ErrorMessage="FAQ Answer required">*</asp:RequiredFieldValidator>
        </td>
           
    </tr>
   <tr>
        <td style="width:150px; vertical-align:top;"> <span style="width:auto; height:auto; float:left; padding-top:12px;">Status:</span></td>
        <td colspan="2" align="left" style="float:left; width:58%;"> <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal" style="float:left; width:200px; border:0px; ">
     <asp:ListItem Text ="Active" Value ="1" Selected="True" ></asp:ListItem>
     <asp:ListItem Text ="Inactive" Value ="0" ></asp:ListItem>
    </asp:RadioButtonList></td>

    </tr>
    <tr> <td style="width:25%; float:left; "></td><td valign="top" style="width:72%; float:left; "> <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="Add" onclick="Button1_Click" CssClass="yellow_btn" />
    <asp:Label ID="lblid" runat="server" Visible ="false"  ></asp:Label></td></tr>
    
</table>

</asp:Content>