<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="EmailTemplate.aspx.vb" Inherits="Admin_EmailTemplate" %>

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

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    <h2>Email Template</h2>
<asp:GridView ID="GVEditEmail"  AutoGenerateColumns="false" runat="server" CssClass="pack_tab">
    <Columns>
 
    <asp:TemplateField  Visible="false" HeaderText=" Email_Templates_Id">
    <ItemTemplate><%# Eval("Email_Templates_Id")%>
    </ItemTemplate>
    </asp:TemplateField>    
    <asp:TemplateField HeaderText="Title">
    <ItemTemplate>
   <%# Eval("Email_Templates_Title")%>
    </ItemTemplate>

    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
    <%--<asp:ImageButton ID="ImageButton1"   OnCommand="GVPackageList_Command"  AlternateText="Edit" CommandName="Edit" ImageUrl="Images/add.jpg" CommandArgument='<%#Eval("package_id") %>'  runat="server" />--%>
     <%--<asp:HyperLink ID="HyperLink1"  Text="Edit" runat="server" ></asp:HyperLink>--%>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#"~/admin/EditEmail.aspx?Eid="+Eval("Email_Templates_Id")%>'>Edit</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField> 
    
    </Columns> 
    
</asp:GridView>

</div>

  <div class="add_button">
    <a href="EditEmail.aspx" title="Add new Package!">
    <img src="Images/add.jpg" alt="New" style="height:20px;" /><span>Add</span></a>
   
    
        
   </div>




</asp:Content>