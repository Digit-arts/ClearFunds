<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Admin/Site.master" AutoEventWireup="false"
    CodeFile="Support.aspx.vb" Inherits="_Support" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>Support</h2>
    <div>
<asp:GridView ID="GVSupportList"  AutoGenerateColumns="false" runat="server"  CssClass="pack_tab">
    <Columns>
    <%--<asp:TemplateField >
    <ItemStyle HorizontalAlign="Center" />
    <ItemTemplate>
   
       
    </ItemTemplate>

    </asp:TemplateField>--%>
    <asp:TemplateField  Visible="false" HeaderText="pask_id">
    <ItemTemplate>'<%# Eval("CMS_Support_id")%>'
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="packagename">
    <ItemTemplate>
   <%# Eval("CMS_Support_Subject")%>
    </ItemTemplate>

    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
    <%--<asp:ImageButton ID="ImageButton1"   OnCommand="GVPackageList_Command"  AlternateText="Edit" CommandName="Edit" ImageUrl="Images/add.jpg" CommandArgument='<%#Eval("package_id") %>'  runat="server" />--%>
     <%--<asp:HyperLink ID="HyperLink1"  Text="Edit" runat="server" ></asp:HyperLink>--%>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#"~/admin/AddEditSupport.aspx?Pid="+Eval("CMS_Support_id")%>'>Edit</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField> 
    
    </Columns> 
    
</asp:GridView>
</div> 

  <div class="add_button">
    <a href="AddEditSupport.aspx" title="Add new Support Content!">
    <img src="Images/add.jpg" alt="New" style="height:20px;" /><span>Add</span></a>
   
    
        
   </div>

     

    <%-- <a href='<%# String.Format("~/addplans.aspx?package_id={0}", Eval("package_id")) %>' title="Edit Package!">
    <img src="Images/add.jpg" alt="Edit" style="height:20px;" />Edit</a> --%>
</asp:Content>