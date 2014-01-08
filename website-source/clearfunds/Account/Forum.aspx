<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Forum.aspx.vb" MasterPageFile ="~/AccountMaster.master" Inherits="Account_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="mytickt_nav">

    


    <span style="color:#333333; padding:10px;  "><asp:Label ID="lbltick" runat="server" Text="Label"></asp:Label></span>
        
           <a href="#">
                 <asp:ImageButton ID="ImageButton1" CssClass="tickt"   ImageUrl="~/Admin/Images/Tickets.png" ToolTip="Open Tickets" runat="server" />
                <span> <asp:Label ID="lbopcount" runat="server" Text=""></asp:Label></span>
               
           </a>
           <a href="#">
                 <asp:ImageButton ID="ImageButton2" CssClass="tickt"  ImageUrl="~/Admin/Images/Tickets.png" ToolTip="Closed Tickets" runat="server" />
                <span><asp:Label ID="lbclscount" runat="server" Text=""></asp:Label></span>
           
           </a>
           <a href="#">
                <asp:ImageButton ID="ImageButton3" CssClass="tickt" OnClick="All_Click" ImageUrl="~/Admin/Images/Tickets.png" ToolTip="All Tickets" runat="server" />
                <span><asp:Label ID="lballcount" runat="server" Text=""></asp:Label></span>
           
           </a>

  <div style="float:right; margin:0px !important;">
          <asp:Button ID="Button1" CssClass="tic_btn" PostBackUrl="~/Account/UserEntryTickets.aspx" Text="Create Ticket" runat="server" />
<%-- <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Account/UserEntryTickets.aspx" runat="server" Font-Underline="False" ForeColor="Black"></asp:HyperLink> --%>

   </div>


                              
                            
                            
                              


                                 
                                    
</div>
                                    

   <%--  <div class="fix">--%>
     <div class="acc_table">
     <asp:GridView ID="gridview1" AutoGenerateColumns="false"  ItemStyle-VerticalAlign="Top"
                GridLines="None" Width="100%"  ShowHeader="true" ShowHeaderWhenEmpty="true"   runat="server" ForeColor="#333333"
AlternatingRowStyle-BackColor="#A5A5A5"
                CellPadding="4"   OnRowCommand="GridView1_RowCommand">
                <AlternatingRowStyle BackColor="White" />
               
                <EmptyDataTemplate>
                No records Found
                </EmptyDataTemplate>
                <Columns>
                 <asp:TemplateField  HeaderText="Title">
                     <ItemTemplate >

                         <asp:LinkButton ID="LinkButton4" PostBackUrl='<%#"~/account/ReplyPost.aspx?ticketid="+Eval("Tickets_Id")%>' Text='<%#Eval("[Tickets_Problem]") %>' runat="server"></asp:LinkButton>
                 
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
                       <%--<asp:TemplateField >
                <ItemTemplate >
                            <asp:ImageButton ID="imgreplay" runat="server" Height="30" Width ="30" CommandName="imgreply" ImageUrl ="~/Images/mail_replay.ico" />
                             <asp:Label ID="lblreplycount" runat="server" Text='Messages'></asp:Label>
                             <asp:Label ID="lblupdate" runat="server" Text='Update'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>--%>
                
               
                </Columns>
               <%-- <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
          
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
                <EmptyDataRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="White" />--%>
            </asp:GridView>
    </div>
   
</asp:Content>