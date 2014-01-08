<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ContentManage.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_ContentManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2 class="head_top">Content Management System</h2>


    <div>
<fieldset >

<%--<div style="float:left  " >
    <asp:Label ID="Label3" runat="server" Text="Page Title:"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="btnedit" runat="server" ForeColor="White" BackColor="Red" Text="Edit" />
</div>--%>


<div style="float:right "  >
    <asp:Label ID="Label1" ForeColor="White" runat="server" Text="View Sub Pages:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" AutoPostBack="true"  OnSelectedIndexChanged="dropdownview"   runat="server" > 
       
      
    </asp:DropDownList>
    </div>
</fieldset>
</div>




<div class="paginatio_ct">

  <asp:GridView ID ="GridView1" runat="server" AllowPaging="true" PageSize="10"
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
        
     <asp:Label ID="lblid" runat="server" Text='<%#Eval("contents_id")%>'></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Header Title" >
     <ItemTemplate> <%#Eval("contents_title")%></ItemTemplate>
    </asp:TemplateField>

   <%-- <asp:TemplateField HeaderText="Page URL" >
     <ItemTemplate > <%#Eval("contents_permalink")%></ItemTemplate>
    </asp:TemplateField>--%>

    <asp:TemplateField HeaderText="Sorting" >
        

    <ItemTemplate>   
     <asp:ImageButton ID="ImageButton4" ImageUrl="Images/up.png"  OnClick="Imageup_Click"   runat="server">
        </asp:ImageButton>   
         <asp:ImageButton ID="ImageButton5" ImageUrl="Images/down.png"   OnClick="Imagedown_Click"  runat="server">
        </asp:ImageButton>  
        
        </ItemTemplate>
       
   
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





<div style="float:left; color:#fff;">
<fieldset >
<legend >
Add Content
</legend>
<div> 
 
  <asp:Label ID="Label2" runat="server" Text="Select Page Level :"></asp:Label>
    <asp:DropDownList ID="DropDownList2"  ForeColor="Black" AutoPostBack="true"  runat="server" >
      
     
    </asp:DropDownList>
    <asp:Button ID="Button1" ToolTip="Add new Content" runat="server"  OnClick="Button1_Click"
           Text="Add New" 
         />
</div>

</fieldset>
</div>


</asp:Content>
