<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Categories.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_Groups" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<h2 class="head_top">Group  Management </h2>

<div class="paginatio_ct">
<asp:GridView ID ="gvgroupname" runat="server" AllowPaging="true" PageSize="10"
         OnPageIndexChanging="OnPageIndexChanging"   AutoGenerateColumns="False" 
        style="margin-left:10px;">
         
          <PagerSettings Mode="Numeric" PageButtonCount="6"  
             FirstPageText="First" LastPageText="Last" NextPageText="" PreviousPageText="" /> 


<Columns> 
<asp:TemplateField HeaderText="SNo.">
     <itemtemplate>
          <%#Container.DataItemIndex + 1 %>                                                    
     </itemtemplate>
</asp:TemplateField>
    <asp:TemplateField  Visible="false" HeaderText="ID" >
     <ItemTemplate>
        
     <asp:Label ID="lblid" runat="server" Text='<%#Eval("Category_id")%>'></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Category Name" >
     <ItemTemplate> <%#Eval("Category_name")%></ItemTemplate>
    </asp:TemplateField>

   
    
   

     <asp:TemplateField HeaderText="Action" >

     <ItemTemplate > 
     

      <asp:ImageButton ID="ImageButton1" ToolTip="Edit Content" ImageUrl="images/edit-icon.png"   OnClick="Edit_Click" runat="server" />
       <asp:ImageButton ID="ImageButton3" ToolTip="Delete Content" ImageUrl="images/delete-icon.png"  OnClientClick="return confirm('Are you sure want to delete.');" runat="server"   onclick="Delete_Click"    />
       
      </ItemTemplate > 
       </asp:TemplateField> 
 
    </Columns>
    <EmptyDataTemplate>
    No records found
    
    
    </EmptyDataTemplate>
    </asp:GridView>


    </div>



<div style="float:left;color:#fff;">
<fieldset >
<legend >
Add new Category
</legend>
<div> 
 
 
     
   
    <asp:Button ID="Button1" ToolTip="Add new Group" runat="server"  OnClick="Button1_Click"
           Text="Add New" 
         />
</div>

</fieldset>
</div>




 

</asp:Content>