<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Site.master" AutoEventWireup="false" CodeFile="CopyRight.aspx.vb" Inherits="Admin_CopyRight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
    <h2>Copy Right</h2>
    <table  class="con_text2">
<tr>
 <td>

  <asp:Label ID="Label1" runat="server" Text="Copy Right Title:" CssClass="c_label"   ></asp:Label>
 </td>
   <td>
      <asp:TextBox ID="txtCopy" runat="server"  CssClass="validate[required] inputbox smallbox"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCopy"   ForeColor="Red" ValidationGroup="Add" runat="server" ErrorMessage="Copy Right  Required"    Text="*"></asp:RequiredFieldValidator>

   </td>
</tr>

<tr>
 <td>
  <asp:Label ID="lblname" Text="CopyRight URL" runat="server"  ></asp:Label>
 </td>
   <td>
      
          
            <asp:TextBox ID="txturl" runat="server"  CssClass="validate[required] inputbox smallbox" ></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txturl" 
                ForeColor="Red" ValidationGroup="Add" runat="server" 
                ErrorMessage="Copy Right url Required" 
                 Text="*"></asp:RequiredFieldValidator>
       
   </td>
</tr>
<tr>
<td>
 <asp:Label ID="Label2" runat="server" Text="Position" CssClass="c_label"   ></asp:Label>
 </td>
 <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="334px">
             <asp:ListItem Value="0">Select</asp:ListItem>
        <asp:ListItem Value="LEFT">LEFT</asp:ListItem>
        <asp:ListItem  Value="RIGHT">RIGHT</asp:ListItem>
            </asp:DropDownList>   
</td>
</tr>
 <tr>
        <td style="width:150px; vertical-align:top;"> <span style="width:auto; height:auto; float:left; padding-top:12px;">Status:</span></td>
        <td colspan="2" align="left" style="float:left; width:58%;"> <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal" style="float:left; width:200px; border:0px; ">
     <asp:ListItem Text ="Active" Value ="1" Selected="True" ></asp:ListItem>
     <asp:ListItem Text ="Inactive" Value ="0" ></asp:ListItem>
    </asp:RadioButtonList></td>

    </tr>
<tr>
 <td>
 </td>
   <td>
       <asp:Button ID="Button1"   ValidationGroup ="Add" runat="server" Text="Save" 
           Width="60px" onclick="Button1_Click1" CssClass="yellow_btn" />&nbsp
              
       <asp:Button ID="Button2" runat="server" Text="Cancel"  Width="60px" 
           onclick="Button2_Click" CssClass="yellow_btn" />
   </td>
</tr>

</table> 

    </div>
</asp:Content>

