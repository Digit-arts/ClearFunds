<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Site.master" AutoEventWireup="false" CodeFile="dashboard.aspx.vb" Inherits="Admin_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:Panel runat="server" HeaderText="Messages" ID="pnlMessages"  >
<asp:GridView ID="grdmessages"  AllowPaging="true"  AutoGenerateColumns="false" runat="server"  CssClass="pack_tab">
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
    </Columns> 
    </asp:GridView>        
</asp:Panel>
</asp:Content>

