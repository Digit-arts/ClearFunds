<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Admin/Site.master" AutoEventWireup="false"
    CodeFile="Members.aspx.vb" Inherits="_Members" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>Members</h2>

    <div>
<asp:GridView ID="GVMembersList"  AutoGenerateColumns="false" runat="server" 
            CssClass="pack_tab" BorderStyle="Outset">
    <Columns>
   
    <asp:TemplateField  Visible="false" HeaderText="pask_id">
    <ItemTemplate>'<%# Eval("UserId")%>'
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField HeaderText="Member Name"  DataField="UserName" />

    <asp:TemplateField HeaderText="Registered Date">
    <ItemTemplate>
    <%# Eval("RegisteredDate")%>
    </ItemTemplate>
    

    </asp:TemplateField>
   <asp:TemplateField HeaderText="Status">
   <ItemTemplate>
                <%# Eval("User_Status")%>
    </ItemTemplate>
              
  

   </asp:TemplateField>
   <asp:TemplateField  HeaderText="	Account">
  <ItemTemplate>
  
  <asp:Label ID="lblaccount" runat="server"  ></asp:Label>
  </ItemTemplate>
     
   </asp:TemplateField>
    <asp:TemplateField  HeaderText="Deposit">
  <ItemTemplate>
  
  <asp:Label ID="lbldeposit" runat="server" ></asp:Label>
  </ItemTemplate>
     
   </asp:TemplateField>
    <asp:TemplateField  HeaderText="Earned">
  <ItemTemplate>
  
  <asp:Label ID="lblEarned" runat="server" ></asp:Label>
  </ItemTemplate>
     
   </asp:TemplateField>
    <asp:TemplateField  HeaderText="WithDraw">
  <ItemTemplate>
  
  <asp:Label ID="lblwithdrew" runat="server" ></asp:Label>
  </ItemTemplate>
     
   </asp:TemplateField>
   <asp:TemplateField HeaderText="Actions">

    
    <ItemTemplate>
         <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#"~/Admin/EditMembers.aspx?Uid="+Eval("UserId")%>'>Edit</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField> 
    
    </Columns> 
    
    <FooterStyle BackColor="Black" />
    
</asp:GridView>
</div> 
    </asp:Content>