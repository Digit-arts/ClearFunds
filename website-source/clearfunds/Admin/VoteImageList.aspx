<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VoteImageList.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_VoteImageList" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<h2 class="head_top">Vote Us</h2>
<br />
    <asp:GridView ID ="GridView1" runat="server"  RowStyle-Width="10" ShowHeaderWhenEmpty="true"    AllowPaging="true" PageSize="10"
        OnPageIndexChanging="OnPageIndexChanging"   AutoGenerateColumns="False"  style="margin-left:10px;"     >
          <PagerSettings Mode="Numeric" PageButtonCount="6"  
             FirstPageText="First" LastPageText="Last" NextPageText="" PreviousPageText=""/>  
<Columns> 
<asp:TemplateField HeaderText="SNo.">
     <itemtemplate>
          <%#Container.DataItemIndex + 1 %>                                                    
     </itemtemplate>
</asp:TemplateField>
    <asp:TemplateField Visible="false" HeaderText="ID" >
     <ItemTemplate >
         <asp:Label ID="lblid" runat="server" Text='<%#Eval("VoteUs_id")%>'></asp:Label>
      
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="VoteUs title" >
     <ItemTemplate > <%#Eval("VoteUs_title")%></ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="VoteUs title" >
     <ItemTemplate > <%#Eval("VoteUs_url")%></ItemTemplate>
    </asp:TemplateField>


    <asp:TemplateField   HeaderText="VoteUs Image" >
     <ItemTemplate >
      <span style="text-align: center;width:100px ">
      <center>
          <asp:ImageButton ID="ImageButton2" Height="40px" Width="40px" onerror="this.onload = null; this.src='images1/default.png';"  ImageUrl='<%# "VoteUsImageHandler.ashx?id=" + Eval("VoteUs_id") %>'  runat="server" />
        
     </span></center>
         
     </ItemTemplate>
    </asp:TemplateField>

    
 



  
     <asp:TemplateField HeaderText="Action" >

     <ItemTemplate > 
       
      <asp:ImageButton ID="ImageButton1" ToolTip="Edit Voteus here"   ImageUrl="images/edit-icon.png" PostBackUrl ='<%# "AddVoteus.aspx?id=" + Eval("VoteUs_id") %>' runat="server" />&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="ImageButton3" ToolTip="Delete Voteus here"  OnClientClick="return confirm('Are you sure want to delete.');" ImageUrl="images/delete-icon.png" runat="server" onclick="Delete_Click"    />
       
      </ItemTemplate > 
       </asp:TemplateField> 
 
    </Columns>
    <EmptyDataTemplate>
    No records found
    
    
    </EmptyDataTemplate>
    </asp:GridView>
    <fieldset >
<legend >
Add News
</legend>
<div> 
 
 
    
    <asp:Button ID="Button1" runat="server" 
        PostBackUrl="~/Admin/AddVoteus.aspx"  ToolTip="Add new VoteUs"     Text="Add New" 
         />
</div>

</fieldset>
    </asp:Content>