<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PaymentProcessings.aspx.vb"  MasterPageFile="~/Admin/Site.master" Inherits="Admin_PaymentProcessings" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>payment processing</h2>
<asp:GridView ID="GVPaymentDetails"  AutoGenerateColumns="false" runat="server"
 AllowPaging="true" PageSize="10" OnPageIndexChanging="GVPaymentDetails_PageIndexChanging" CssClass="pack_tab">


<Columns>
    <%--<asp:TemplateField >
    <ItemStyle HorizontalAlign="Center" />
    <ItemTemplate>
   
       
    </ItemTemplate>

    </asp:TemplateField>--%>
    <asp:TemplateField  Visible="false" HeaderText="CustomProcessing_id">
    <ItemTemplate>'<%# Eval("CustomProcessing_id")%>'
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="CustomProcessing_Name">
    <ItemTemplate>
   <%# Eval("CustomProcessing_Name")%>
    </ItemTemplate>    
     </asp:TemplateField>


        <asp:TemplateField  Visible="false" HeaderText="CustomProcessing_Image">
    <ItemTemplate>'<%# Eval("CustomProcessing_Image")%>'
    </ItemTemplate>
    </asp:TemplateField>

     


    <asp:TemplateField HeaderText="Icon">
    <ItemTemplate>
          <asp:Image ID="Image4" runat="server" Height="40px" Width="40px" ImageUrl='<%# "~/Handlers/CustomProcessingHandler.ashx?id=" + Eval("CustomProcessing_id") %>' />
     </ItemTemplate>
   </asp:TemplateField >
     <asp:TemplateField HeaderText="Actions">  
    <ItemTemplate>
          <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#"~/admin/CustomProcessings.aspx?Pid="+Eval("CustomProcessing_id")%>'>Edit</asp:LinkButton>
 </ItemTemplate>
 </asp:TemplateField>     
    
   
    
    </Columns> 
</asp:GridView>
    
<div>

  <div class="add_button">
    <a href="CustomProcessings.aspx" title="Add new CustomProcessings!">
    <img src="Images/add.jpg" alt="New" style="height:20px;" /><span>Add</span></a>
                </div>
 
</div>



</asp:Content>