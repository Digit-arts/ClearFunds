﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Site.master" AutoEventWireup="false" CodeFile="Banner.aspx.vb" Inherits="Admin_Banner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h2>Banner</h2>
    <div>
<asp:GridView ID="GVSupportList"  AutoGenerateColumns="false" runat="server" CssClass="pack_tab">
    <Columns>
    <%--<asp:TemplateField >
    <ItemStyle HorizontalAlign="Center" />
    <ItemTemplate>
   
       
    </ItemTemplate>

    </asp:TemplateField>--%>
    <asp:TemplateField  Visible="false" HeaderText="pask_id">
    <ItemTemplate>'<%# Eval("Extras_Banner_Id")%>'
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="packagename">
    <ItemTemplate>
   <%# Eval("Extras_Banner_Subject")%>
    </ItemTemplate>

    </asp:TemplateField>
    <asp:TemplateField>
    <ItemTemplate>
    <%--<asp:ImageButton ID="ImageButton1"   OnCommand="GVPackageList_Command"  AlternateText="Edit" CommandName="Edit" ImageUrl="Images/add.jpg" CommandArgument='<%#Eval("package_id") %>'  runat="server" />--%>
     <%--<asp:HyperLink ID="HyperLink1"  Text="Edit" runat="server" ></asp:HyperLink>--%>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#"~/admin/AddEditBanner.aspx?Pid="+Eval("Extras_Banner_Id")%>'>Edit</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField> 
    
    </Columns> 
    
</asp:GridView>
</div> 

  <div class="add_button">
    <a href="AddEditBanner.aspx" title="Add new Support Content!">
    <img src="Images/add.jpg" alt="New" style="height:20px;" /><span>Add</span></a>
   
    
        
   </div>

     

    <%-- <a href='<%# String.Format("~/addplans.aspx?package_id={0}", Eval("package_id")) %>' title="Edit Package!">
    <img src="Images/add.jpg" alt="Edit" style="height:20px;" />Edit</a> --%>
</asp:Content>

