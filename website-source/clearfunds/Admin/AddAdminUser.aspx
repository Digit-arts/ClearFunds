<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddAdminUser.aspx.vb" MasterPageFile ="~/Admin/Site.master"  Inherits="Admin_AddAdminUser" %>

<asp:Content ID="Headercontent" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Bodycontent" ContentPlaceHolderID="MainContent" runat="Server">
 <div>
    <h2>Create New User</h2>
    <table  class="con_text2">
<tr>
 <td>
  <asp:Label ID="lblcatagories" Text="Choose The Department:" runat="server"  ></asp:Label>
 </td>
   <td>
       <asp:DropDownList ID="DropDownList1" AutoPostBack="false" runat="server" >
          
       </asp:DropDownList>
         
   </td>
</tr>

<tr>
 <td>
  <asp:Label ID="lblname" Text="Name" runat="server"  ></asp:Label>
 </td>
   <td>
       <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
           ValidationGroup ="Add" ErrorMessage="Name Must" ControlToValidate="txtname"></asp:RequiredFieldValidator>
       
   </td>
</tr>

<tr>
 <td>
  <asp:Label ID="lblemail" Text="Email" runat="server"  ></asp:Label>
 </td>
   <td>
       <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
           ErrorMessage="enter the correct email format"  ValidationGroup ="Add"  ControlToValidate="txtemail" 
           ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
   </td>
</tr>


<tr>
 <td>
  <asp:Label ID="lblusername" Text="Username" runat="server"  ></asp:Label>
 </td>
   <td>
       <asp:TextBox ID="txtusername"   runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
           ValidationGroup ="Add" ErrorMessage="Username must" 
           ControlToValidate="txtusername"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
 <td>
  <asp:Label ID="lblpassowrd" Text="Password" runat="server"  ></asp:Label>
 </td>
   <td>
       <asp:TextBox ID="txtpassword" runat="server" ValidationGroup="Add" TextMode="Password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
           ValidationGroup ="Add" ErrorMessage="Password must" 
           ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
   </td>
</tr>
<tr>
 <td>
  <asp:Label ID="lblconfirmpassword" Text="Confirm Password" runat="server"  ></asp:Label>
 </td>
   <td>
       <asp:TextBox ID="txtconfirmpassword" runat="server" TextMode="Password"></asp:TextBox>
       <asp:CompareValidator ID="CompareValidator1" runat="server" 
           ErrorMessage="password not match"   ValidationGroup ="Add" ControlToCompare="txtpassword" 
           ControlToValidate="txtconfirmpassword"></asp:CompareValidator>
   </td>
</tr>




<tr>
 <td>
 </td>
   <td>
       <asp:Button ID="Button1"   ValidationGroup ="Add" runat="server" Text="Save" Width="60px" />&nbsp
       <asp:Button ID="Button2" runat="server" Text="Clear"  Width="60px" />
   </td>
</tr>

</table> 
    </div>
</asp:Content>