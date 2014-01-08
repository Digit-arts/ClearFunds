<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WithDarwlRequest.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_WithDarwlRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 450px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


    <h2>WithDrawl Request</h2>
    <div class="mytickt_nav">
    <ul>
   <li>
                               <asp:LinkButton ID="LinkButton3" OnClick="All_click" runat="server">All</asp:LinkButton>
                             </li>
    <li>
   
        <asp:LinkButton ID="LinkButton1" OnClick="open_Click" runat="server">Hold</asp:LinkButton>
                                 <%--<asp:HyperLink ID="HyperLink3" NavigateUrl="" runat="server" Font-Underline="False" ForeColor="Black">open Tickets</asp:HyperLink> </li>--%>
                                 </li>
                              <li>
                               <asp:LinkButton ID="LinkButton2" OnClick="close_click" runat="server">Reject</asp:LinkButton>
                             </li> 
                           
                                    </ul>
</div>

<div>
<asp:GridView ID="GVMembersList" ShowHeaderWhenEmpty="true"  AutoGenerateColumns="False"
    AllowPaging="true" PageSize="10"
        OnPageIndexChanging="OnPageIndexChanging" runat="server" CssClass="pack_tab">
<PagerSettings Mode="Numeric" PageButtonCount="6"  
             FirstPageText="First" LastPageText="Last" NextPageText="" PreviousPageText="" />  

       
    <Columns>
    <asp:TemplateField HeaderText="Select">
   <ItemTemplate>
    <asp:CheckBox ID="chkselect" runat="server" />
   </ItemTemplate>
   </asp:TemplateField>
    <asp:TemplateField   Visible="false" HeaderText="WithDraw_id">
    <ItemTemplate>
        <asp:Label ID="lblid1" runat="server" Text= '<%# Eval("WithDrawl_Id")%>'></asp:Label>
    
    '<%# Eval("WithDrawl_Id")%>'
    </ItemTemplate>
    </asp:TemplateField>
      <asp:TemplateField   Visible="false" HeaderText="WithDrawUser_id">
    <ItemTemplate>
        <asp:Label ID="lbluser" runat="server" Text= '<%# Eval("UserId")%>'></asp:Label>
    
    '<%# Eval("UserId")%>'
    </ItemTemplate>
    </asp:TemplateField>

   <%-- <asp:BoundField HeaderText="User Name"  DataField="UserName" />--%>

    <asp:TemplateField HeaderText="User Name">
    <ItemTemplate>
   <%# Eval("UserName")%>
    </ItemTemplate>

    </asp:TemplateField>
    <asp:TemplateField HeaderText="Date">
    <ItemTemplate>

    <%# Eval("WithDrawl_Date")%>
    </ItemTemplate>
    

    </asp:TemplateField>
  
  
     
  
    <asp:TemplateField  HeaderText="Amount">
  <ItemTemplate>
  
  <%# Eval("WithDrawl_Amount")%>
  </ItemTemplate>
    
     
   </asp:TemplateField>
    <asp:TemplateField HeaderText="Status">
    <ItemTemplate>

    <%# Eval("WithDrawl_Status")%>
    </ItemTemplate>
    

    </asp:TemplateField>
    
       <asp:TemplateField  HeaderText="REMARKS">
      
  <ItemTemplate>
     
      <asp:TextBox ID="txtremarks" TextMode="MultiLine" Text='<%# Eval("WithDrawl_Remarks")%>'  runat="server"></asp:TextBox>
 
         
  </ItemTemplate>
           
          
   </asp:TemplateField>
       
   <asp:TemplateField  HeaderText="ACTIONS">
  <ItemTemplate>
     <asp:LinkButton ID="lnkhold"  OnClick="lnkhold_Click" CommandArgument='<%# Eval( "WithDrawl_Id") %>' runat="server">Hold</asp:LinkButton>
        <asp:LinkButton ID="lnkReject" OnClick="lnkReject_Click"   runat="server">Reject</asp:LinkButton>
      <%--  <asp:LinkButton ID="lnkApproved" OnClick="lnkApproved_Click" runat="server">Approved</asp:LinkButton>--%>
 <%--<asp:Button ID="btnhold" CommandArgument="Button2" runat="server" Text="Hold" />
    <asp:Button ID="btnreject" runat="server" Text="Reject" />
    <asp:Button ID="btnapproved" runat="server" Text="Approved" />--%>
  </ItemTemplate>
     
   </asp:TemplateField>
       
    </Columns> 
    <EmptyDataTemplate>
    no records found
    </EmptyDataTemplate>
    
</asp:GridView>

</div>
    
    <div>
 &nbsp;&nbsp;&nbsp;
 <div class="depos_con">
 <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label>
 
 <asp:Label ID="lblAmt" runat="server"></asp:Label>

 </div>
 </div>
 <div style="width:100%; float:left;">
    <asp:Button ID="MassPay" runat="server"  Text="MASS PAY" CssClass="btnalt " style="margin:7px 13px 7px 7px; float:right; "/></div>
   <%--<asp:Button ID="paysa" OnClick="paysa_Click" runat="server" Text="paysa" />
     <asp:Button ID="paypal" runat="server" OnClick="paypal_Click" Text="paypal" />
    <asp:Button ID="paypaladp" runat="server" OnClick="paypaladp_Click" Text="paypaladp" />
   
    <asp:Button ID="LR" runat="server"  OnClick="LR_Click" Text="LR" />
    <asp:Button ID="STP" runat="server"  OnClick="Stp_Click" Text="Stp" />--%>
     <asp:Label ID="successLabel" ForeColor="Yellow" runat="server" ></asp:Label>
    <asp:Label ID="errLabel" runat="server"></asp:Label>
    <asp:Label ID="errcodeLabel" runat="server" ></asp:Label>


<div>
</div>
</asp:Content>
