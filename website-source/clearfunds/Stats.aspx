<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="ContentMaster.master" CodeFile="Stats.aspx.vb" Inherits="Stats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="css/l_style.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class ="ContentPadding ">
    <h2 style="left:353px; color:#CA7F03; text-transform:capitalize ; font:bold 25px calibri; ">Status</h2>
  
     <div class="acc_table">
<asp:GridView ID="GVStats"  AutoGenerateColumns="false"  AllowPaging="true" PageSize="10"
        OnPageIndexChanging="OnPageIndexChanging" runat="server" >
 <PagerSettings Mode="Numeric" PageButtonCount="6"  
             FirstPageText="First" LastPageText="Last" NextPageText="" PreviousPageText="" /> 
    <Columns>
 
    <asp:TemplateField HeaderText="username">
    <ItemTemplate>
   <%# Eval("username")%>
    </ItemTemplate>
        </asp:TemplateField>
        
                  <asp:TemplateField HeaderText="Deposit">
            <ItemTemplate>
        <%# Eval("Deposit")%>
        </ItemTemplate>
        </asp:TemplateField>

            <asp:TemplateField HeaderText="Withdraw">
        <ItemTemplate>
        <%# Eval("Withdraw")%>
        </ItemTemplate>
                </asp:TemplateField>



    
    </Columns> 
    
</asp:GridView>
<br />
<br />
<br />
</div> 
</div>
 

</asp:Content>