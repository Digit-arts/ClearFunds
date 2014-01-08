<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="Custompage.aspx.vb" Inherits="Admin_Custompage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <h2>custom pages</h2>
    <table style="width:98.5%" class="con_text2">
  
         
          <tr>
            <td>

                <asp:Label ID="Label5" runat="server" Text="Page Name :"></asp:Label>
            </td>
            <td>


                <asp:TextBox ID="txtpagename" runat="server" 
                   CssClass="validate[required] inputbox smallbox"></asp:TextBox>
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
    <asp:Label ID="lblactive" runat="server" Text="Active"></asp:Label>
    <asp:CheckBox ID="chkActive"  runat="server" />
</td>
</tr>
   <tr>
            <td>
                </td>
            <td>

                <asp:Button ID="cmdSave" runat="server" Text="Save"
                    CssClass ="btnalt"/>
                <asp:Label ID="lblmessage"    Visible="false" ForeColor="Green" runat="server" Text="Saved"></asp:Label>
         <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label> 
            </td>
            
     
        </tr>
</table>

</asp:Content>