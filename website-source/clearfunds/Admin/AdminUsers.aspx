<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AdminUsers.aspx.vb" MasterPageFile="~/Admin/Site.master"  Inherits="Admin_AdminUsers" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>Manage User</h2>
    <div>
<asp:GridView ID="gvmanageuser"  AllowPaging="true"  AutoGenerateColumns="false" runat="server"  CssClass="pack_tab">
    <Columns>

<asp:TemplateField HeaderText="UserName">
    <ItemTemplate>
    <%# Eval("Admin_UserName")%>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField Visible="false"  HeaderText="Id">
    <ItemTemplate>
    <asp:Label ID="lblid" runat="server" Text='<%# Eval("Admin_id")%> '></asp:Label>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Title">
    <ItemTemplate>
    <%# Eval("Admin_RoleId")%>
    </ItemTemplate>
</asp:TemplateField>
     <asp:TemplateField HeaderText="Action" >
     <ItemTemplate > 
      <asp:ImageButton ID="ImageButton1" ToolTip="Edit Content" ImageUrl="images/edit-icon.png" OnClick="Edit_Click"  runat="server" />
       <asp:ImageButton ID="ImageButton3" ToolTip="Delete Content" ImageUrl="images/delete-icon.png"   runat="server" OnClientClick="return confirm('Are you sure want to delete.');"  onclick="Delete_Click"       />
      </ItemTemplate > 
       </asp:TemplateField> 
    </Columns> 
    </asp:GridView> 
          
   </div>
 <div class="add_button">
    <a href="AddAdminUser.aspx" title="Add new Support Content!">
    <img src="Images/add.jpg" alt="New" style="height:20px;" /><span>Add</span></a>
   
    
        
   </div>
</asp:Content>
