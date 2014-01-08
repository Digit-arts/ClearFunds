<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddCategory.aspx.vb" MasterPageFile="~/Admin/Site.master"  Inherits="Admin_Add_Groups" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  
    <asp:Panel ID="AddNewGroup" runat="server">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="NEW GROUP"></asp:Label>
            
            <table class="style1">
                <tr>
                    <td class="style3">
                        <asp:Label ID="lbl_gname" runat="server" Text="Enter the Group Name:"></asp:Label>
                    </td>
                    
                        <td align="left" class="GreenBorder" valign="top">
                            <asp:TextBox ID="txt_grname" runat="server" Width="183px"></asp:TextBox>
                        </td>
                       
                        <td align="left" class="GreenBorder" valign="top">
                            &nbsp;</td> 
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btn_Create" runat="server" onclick="btn_Create_Click" 
                            Text="Submit" Width="86px" />&nbsp
                       <%-- <asp:Button ID="btn_cancel" runat="server" onclick="btn_Cancel_Click" 
                            Text="Cancel" Width="88px" />--%>
                    </td>
                </tr>
            </table>
            </asp:Panel>
           </asp:Content>
    
