<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditEmail.aspx.vb"  MasterPageFile="~/Admin/Site.master" Inherits="Admin_EditEmail" %>


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
    <style type="text/css">
        .style1
        {
            width: 164px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
<h2>Edit Email</h2>
<div>
    <table class="con_text2">
   <tr>
           
            <td class="style1">

                <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label>
            </td>
            <td>
             <asp:TextBox ID="txttitle" runat="server" 
                   CssClass="validate[required] inputbox smallbox"></asp:TextBox>
               
            </td>
        </tr>

          <tr>
            <td class="style1">

                <asp:Label ID="Label5" runat="server" Text=" Subject"></asp:Label>
            </td>
            <td>


                <asp:TextBox ID="txtsubject" runat="server" 
                   CssClass="validate[required] inputbox smallbox"></asp:TextBox>
            </td>

        </tr>
          <tr>
            <td class="style1">

                <asp:Label ID="Label1" runat="server" Text="Message "></asp:Label>
            </td>
            <td>


            <%--    <asp:TextBox ID="txtmessage" runat="server" 
                   TextMode="MultiLine" CssClass="validate[required] inputbox smallbox" width="460" Height="110"></asp:TextBox>
            --%>
               <cc1:Editor ID="HtmlEditor"   Width="800px" Height="250px"   runat="server" /> 
         
            </td>
        </tr>

              <tr>
            <td class="style1">

                <asp:Label ID="Label2" runat="server" Text="Notes "></asp:Label>
            </td>
            <td>


                <asp:TextBox ID="txtnotes" runat="server" 
                   TextMode="MultiLine" CssClass="inputbox smallbox" width="460" Height="110"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td class="style1"></td>
        <td>
            <asp:Button ID="btnSvedata" runat="server"  OnClick="savedata" Text="Save" CssClass="btnalt" />

        </td>
        </tr>
        <tr>
        <td class="style1">
            <asp:Label ID="lblmsgtemplate" Visible="false" runat="server" Text="Email Template has been saved"></asp:Label>
        
        </td>
        </tr>
        

        </table>


        </div>








</asp:Content>