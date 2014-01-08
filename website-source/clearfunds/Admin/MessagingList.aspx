<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MessagingList.aspx.vb"   MasterPageFile="~/Admin/Site.master"  Inherits="Admin_MessagingList" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<h2 class="head_top">Message List</h2>
    <asp:DropDownList ID="drpCat" runat="server" Visible="false" AutoPostBack=true>
    <asp:ListItem Text="All" Selected></asp:ListItem>
    <asp:ListItem Text="My messages"></asp:ListItem>
    </asp:DropDownList>
<br />
    <asp:GridView ID ="GridView1" runat="server"  RowStyle-Width="10" ShowHeaderWhenEmpty="true"    AllowPaging="true" PageSize="10"
        OnPageIndexChanging="OnPageIndexChanging"   AutoGenerateColumns="False"  style="margin-left:10px;"     >
          <PagerSettings Mode="Numeric" PageButtonCount="6"  
             FirstPageText="First" LastPageText="Last" NextPageText="" PreviousPageText=""/>  
<Columns> 

    <asp:TemplateField Visible="false" HeaderText="ID" >
     <ItemTemplate >
         <asp:Label ID="lblid" runat="server" Text='<%#Eval("Messaging_id")%>'></asp:Label>
      
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Subject"  >
     <ItemTemplate> <%# Eval("Messaging_Subject")%> </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField   HeaderText="Date" >
     <ItemTemplate >
     <%# Eval("Messaging_CreatedDate")%>
     </ItemTemplate>
    </asp:TemplateField>

        <asp:TemplateField   HeaderText="Sender" >
     <ItemTemplate >
     <%# Eval("Messaging_From")%>
     </ItemTemplate>
    </asp:TemplateField>

       <asp:TemplateField HeaderText="Action" >

     <ItemTemplate > 
       
       <asp:ImageButton ID="ImageButton3" ToolTip="Delete Message here"  OnClientClick="return confirm('Are you sure want to delete.');" ImageUrl="images/delete-icon.png" runat="server" onclick="Delete_Click"    />
       
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
        PostBackUrl="~/Admin/NewMessage.aspx"  ToolTip="Add new Message"     Text="Add New" 
         />
</div>

</fieldset>
    </asp:Content>
