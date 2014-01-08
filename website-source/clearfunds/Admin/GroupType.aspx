<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupType.aspx.vb"  MasterPageFile ="~/newmember.master" Inherits ="Account_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="MainDiv" runat="server">
    
            <br />
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
                            Text="Create" Width="86px" />&nbsp
                       <%-- <asp:Button ID="btn_cancel" runat="server" onclick="btn_Cancel_Click" 
                            Text="Cancel" Width="88px" />--%>
                    </td>
                </tr>
            </table>
             <asp:GridView ID="gvgroupname" AutoGenerateColumns="False"   runat="server">
       <Columns >
       <%--<asp:boundfield datafield="Category_Name" headertext="Groupname"/>--%>

         <asp:TemplateField  Visible="false" HeaderText ="Category_Id">
       <ItemTemplate >
           <asp:Label ID="lblid" runat="server" Text='<%#Eval("Category_id")%>'></asp:Label>
       </ItemTemplate>
       </asp:TemplateField>
         <asp:TemplateField  HeaderText ="CategoryName">
       <ItemTemplate >
      <%#Eval("Category_Name")%>
       </ItemTemplate>
       </asp:TemplateField>
       
        <asp:TemplateField  HeaderText ="Action">
       <ItemTemplate >
       <asp:ImageButton ID="delete" OnClientClick="return confirm('Are you sure want to delete.');" OnClick="Delete_Click" runat ="server" Width="20px" Height ="20px" ImageUrl="~/Admin/Images/delete-icon.png" />
       </ItemTemplate>
       </asp:TemplateField>
       </Columns>
           </asp:GridView>
        </asp:Panel>
    </div>
    </asp:Content>