<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="ReferralBonusDetails.aspx.vb" Inherits="Admin_ReferralBonusDetails" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<h2>Referral bonus details</h2>

<asp:GridView ID="GVReferralbonusDetails"  AutoGenerateColumns="false" runat="server"
 AllowPaging="true" PageSize="10" OnPageIndexChanging="GVReferralbonusDetails_PageIndexChanging" CssClass="pack_tab">
<Columns>

<asp:TemplateField  Visible="false" HeaderText="AddRefBonus_id" >
    <ItemTemplate>'<%# Eval("AddRefBonus_id")%>'
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Plan Name">
    <ItemTemplate>
   <%# Eval("AddRefBonus_Name")%>
    </ItemTemplate>
     </asp:TemplateField>


     <asp:TemplateField HeaderText="From">
    <ItemTemplate>
   <%# Eval("AddRefBonus_From")%>
    </ItemTemplate>
     </asp:TemplateField>

     
     <asp:TemplateField HeaderText="To">
    <ItemTemplate>
   <%# Eval("AddRefBonus_To")%>
    </ItemTemplate>
     </asp:TemplateField>   

      <asp:TemplateField HeaderText="Bonus(%)">
    <ItemTemplate>
   <%# Eval("AddRefBonus_Commision")%>
    </ItemTemplate>
     </asp:TemplateField>

         <asp:TemplateField HeaderText="Actions">  
    <ItemTemplate>
          <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#"~/admin/AddrefBonus.aspx?Pid="+Eval("AddRefBonus_id")%>'>Edit</asp:LinkButton>
 </ItemTemplate>
 </asp:TemplateField>     
    


</Columns>
</asp:GridView>

   
<div>

  <div class="add_button">
    <a href="AddrefBonus.aspx" title="Add User">
    <img src="Images/add.jpg" alt="New" style="height:20px;" /><span>Add</span></a>
                </div>
 
</div>
</asp:Content>