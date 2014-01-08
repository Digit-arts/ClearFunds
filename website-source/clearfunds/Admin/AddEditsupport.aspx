﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Site.master" AutoEventWireup="false" CodeFile="AddEditsupport.aspx.vb" Inherits="Admin_support" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
<%--    <script  language="javascript" type="text/javascript"  >
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();               
                reader.onload = function (e) {
                    $('#img')
                    .attr('src', e.target.result)
                    .width(250)
                    .height(200);
                    
                };

                reader.readAsDataURL(input.files[0]);
            }
        }

</script>--%>

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
    <div>
    <h2>Add/Edit support</h2>
<table  class="con_text2">
<tr>
 <td>
  <asp:Label ID="lblsub" Text="subjects" runat="server"  ></asp:Label>
 </td>
   <td>
       <asp:TextBox ID="txtimg" runat="server" CssClass="validate[required] inputbox smallbox"></asp:TextBox>
   </td>
 
</tr>
<tr>
<td>
    <asp:Label ID="lblimg" runat="server" Text="Image"></asp:Label>
    <asp:CheckBox ID="chkimage" AutoPostBack ="true" runat="server" />
</td>

<td> 
  <%--<input runat="server" id ="fileup"    type='file' visible ="false"  onchange="readURL(this);"   /> --%>
   <asp:FileUpload ID="fileup"  visible ="false"   runat="server"   />
 </td>
<%--<td>
 <div id ="fileimg" visible ="false"  runat="server" >
      <img    id="img" src="#" alt="Selected new image"   />
           
 </div>
 </td>--%>
 <td>
 <div  id ="fileimgdb"  visible ="false"   runat="server">
  <asp:Image ID="Imgdb"     runat="server" Height="200px" Width="250px"  />
 </div>
</td>


</tr> 
<tr>
<td>
    <asp:Label ID="Desc" runat="server" Text="Description"></asp:Label>
</td>
<td colspan="3" >
    <cc1:Editor ID="HtmlEditor"   Width="800px" Height="250px"   runat="server" /> 
         
    
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

 