<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ForumHelp.aspx.vb"  MasterPageFile="~/HelpDesk/Helpmember.master"   Inherits="HelpDesk_ForumHelp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="help_head">
                <h2><asp:Label ID="lblcategories" runat="server"></asp:Label></h2>

</div>
<div class="help_menu">
<ul>
 <li>
   <asp:LinkButton ID="LinkButton1" OnClick="open_Click" runat="server">Open Tickets</asp:LinkButton>

                                 <%--<asp:HyperLink ID="HyperLink3" NavigateUrl="" runat="server" Font-Underline="False" ForeColor="Black">open Tickets</asp:HyperLink> </li>--%>
                                 </li>
                              <li>
                               <asp:LinkButton ID="LinkButton2" OnClick="close_click" runat="server">Closed Tickets</asp:LinkButton>
                               <%--  <asp:HyperLink ID="HyperLink4" NavigateUrl="" runat="server" Font-Underline="False" ForeColor="Black">Close Tickets</asp:HyperLink> </li>--%>
                               </li>
                                <li>
                               <asp:LinkButton ID="LinkButton3" OnClick="All_Click" runat="server">All Tickets</asp:LinkButton></li>
                                 </ul>
                                
          </div>                     

   <%--  <div class="fix">--%>
     <div class="acc_table">
     <asp:GridView ID="gridview1" AutoGenerateColumns="false"  ItemStyle-VerticalAlign="Top"
                GridLines="None" Width="50%" ShowHeader="true" ShowHeaderWhenEmpty="true"   runat="server" ForeColor="#333333"
AlternatingRowStyle-BackColor="#A5A5A5"
                CellPadding="4"  Height="259px" OnRowCommand="GridView1_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <EmptyDataTemplate>
                No records Found
                </EmptyDataTemplate>
                <Columns>
                 <asp:TemplateField  HeaderText="Title">
                     <ItemTemplate >
                         <asp:LinkButton ID="LinkButton4" PostBackUrl='<%#"~/helpDesk/Replypost.aspx?ticketid="+Eval("Tickets_Id")%>' Text='<%#Eval("[Tickets_Problem]") %>' runat="server"></asp:LinkButton>
                     </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="UserName">
                        <ItemTemplate>
                        <asp:Label ID="lblusername" runat="server" Text='<%# Eval("[Tickets_UserName]")%>'></asp:Label><br />
                                                               
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="opened">
                        <ItemTemplate>
                       <asp:Label ID="lblpostdatetime" runat="server" Text='<%# Eval("[Tickets_RegDate]")%>'></asp:Label>                         
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Closed">
                        <ItemTemplate>
                       <asp:Label ID="lblclosed" runat="server" Text='<%# Eval("[Tickets_closed]")%>'></asp:Label>                         
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                      <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                       <asp:Label ID="lblclosed" runat="server" Text='<%# Eval("[category_name]")%>'></asp:Label>                         
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                       <asp:TemplateField HeaderText="Priority" >
                    <ItemTemplate >
                              <asp:Label ID="lblpriority" runat="server" Text='<%# Eval("[Tickets_Priority]")%>'></asp:Label><br />
                              
                                                                                                                                                                                                                                                                                                                                                  
                    </ItemTemplate>
                    </asp:TemplateField> 
                    
                      <asp:TemplateField HeaderText="Status" >
                    <ItemTemplate >
                              
                              <asp:Label ID="lblsa" runat="server" Text='<%# Eval("[Tickets_Status]")%>'></asp:Label><br />
                                                                                                                                                                                                                                                                                                                                                  
                    </ItemTemplate>
                    </asp:TemplateField> 
                      <asp:TemplateField HeaderText="Action" >
                    <ItemTemplate >
                              
                        <asp:LinkButton ID="lnkopen" runat="server" OnClick="openstatus_click" PostBackUrl='<%#"~/helpDesk/ForumHelp.aspx?ticketid="+Eval("Tickets_Id")%>' >Open</asp:LinkButton>&nbsp;
                                  <asp:LinkButton ID="lnkclosed" runat="server" OnClick="Closestatus_click" PostBackUrl='<%#"~/helpDesk/ForumHelp.aspx?ticketid="+Eval("Tickets_Id")%>' >Close</asp:LinkButton>                                                                                                                                                                                                                                                                                                         
                    </ItemTemplate>
                    </asp:TemplateField> 
          
                </Columns>
            </asp:GridView>
    </div>
   
</asp:Content> 