<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="DepositHistory.aspx.vb" Inherits="Admin_DepositDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h2 style="color: #fff;">Deposit History</h2>
        <table class="con_text1" style="background: none; color: #fff; border: 0px;">
            <tr>
                <td style="width: 230px; float: left;">
                    <asp:Label ID="Label1" runat="server" Text="From" Style="float: left; margin-right: 7px; padding-top: 7px;"></asp:Label>
                    <asp:TextBox ID="txtfrom" runat="server" Width="150" CssClass="inputbox smallbox"></asp:TextBox>
                    <asp:CalendarExtender ID="txtfrom_CalendarExtender" runat="server"
                        TargetControlID="txtfrom">
                    </asp:CalendarExtender>
                </td>


                <td style="width: 200px; float: left;">
                    <asp:Label ID="Label2" runat="server" Text="To" Style="float: left; margin-right: 7px; padding-top: 7px;"></asp:Label>
                    <asp:TextBox ID="txtto" runat="server" Width="150" CssClass="inputbox smallbox"></asp:TextBox>
                    <asp:CalendarExtender ID="txtto_CalendarExtender" runat="server"
                        TargetControlID="txtto">
                    </asp:CalendarExtender>
                </td>


                <td style="width: 100px; float: left;">
                    <asp:Button ID="btngo" runat="server" Text="Go" CssClass="btnalt " />
                </td>

                <td style="width: 200px; float: left;">
                    <asp:Label ID="lblSearch" runat="server" Text="Search for : " Style="float: left; margin-right: 7px; padding-top: 7px;"></asp:Label>
                    <asp:TextBox ID="txtSearch" runat="server" Width="90" CssClass="inputbox smallbox"></asp:TextBox>
                </td>
                <td style="width: 75px; float: left;">
                    <asp:Button ID="btnSearchName" runat="server" Text="By name" CssClass="btnalt " />
                </td>
                <td style="width: 100px; float: left;">
                    <asp:Button ID="btnSearchRef" runat="server" Text="By reference" CssClass="btnalt " />
                </td>
            </tr>
        </table>

    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:TabContainer runat="server" ID="gridsTab">
                <asp:TabPanel runat="server" ID="tabDeposits" HeaderText="Deposits">
                    <ContentTemplate>

                        <asp:GridView ID="GVDepositDetails" AllowSorting="true" PageSize="10" AllowPaging="true" AutoGenerateColumns="False" runat="server"
                            PagerSettings-Mode="Numeric">
                            <Columns>


                                <asp:TemplateField HeaderText="Reference" SortExpression="Deposit_Id">
                                    <ItemTemplate>
                                        <%# Eval("Deposit_Id")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name" SortExpression="Username">
                                    <ItemTemplate>
                                        <%# Eval("UserName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Deposit date" SortExpression="Deposit_ModifyDate">
                                    <ItemTemplate>
                                        <%# Eval("Deposit_ModifyDate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Deposit Amount ($)" SortExpression="Deposit_Amount">
                                    <ItemTemplate>
                                        <%# Eval("Deposit_Amount")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Deposit_Status">
                                    <ItemTemplate>
                                        <%# Eval("Deposit_Status")%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="Deposit_PayName" HeaderText="Deposit Method" SortExpression="Deposit_PayName" />
                                <asp:BoundField DataField="Deposit_SysIp" HeaderText="IP Address" SortExpression="Deposit_SysIp" />
                                <asp:BoundField DataField="Deposit_CountryName" HeaderText="Country Flag" SortExpression="Deposit_CountryName" />






                            </Columns>
                        </asp:GridView>


                        <div class="depos_con2">
                            <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label>
                            <asp:Label ID="lblAmt" runat="server"></asp:Label>
                        </div>

                    </ContentTemplate>
                </asp:TabPanel>

                <asp:TabPanel runat="server" ID="tabBonus" HeaderText="Bonus">
                    <ContentTemplate>
                        <asp:GridView ID="GVPaymentDetails" AutoGenerateColumns="false" runat="server" class="pack_tab">

                            <Columns>




                                <asp:TemplateField HeaderText="UserName">
                                    <ItemTemplate>
                                        <%# Eval("UserName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Bonus Date">
                                    <ItemTemplate>
                                        <%# Eval("Bonus_ModifyDate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Bonus Amount">
                                    <ItemTemplate>
                                        <%# Eval("Bonus_Amount")%>
                                    </ItemTemplate>
                                </asp:TemplateField>





                            </Columns>
                        </asp:GridView>

                        <div class="depos_con2">
                            <asp:Label ID="Label4" runat="server" Text="Total:"></asp:Label>
                            <asp:Label ID="lblAmtBonus" runat="server"></asp:Label>
                        </div>

                    </ContentTemplate>
                </asp:TabPanel>

                <asp:TabPanel runat="server" ID="tabPenalty" HeaderText="Penalty">
                    <ContentTemplate>
                        <asp:GridView ID="GVPenaltyHistory" AutoGenerateColumns="false" runat="server" class="pack_tab">
                            <Columns>

                                <asp:TemplateField HeaderText="UserName">
                                    <ItemTemplate>
                                        <%# Eval("UserName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Penalty Date">
                                    <ItemTemplate>
                                        <%# Eval("Penalty_ModifyDate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Penalty Amount">
                                    <ItemTemplate>
                                        <%# Eval("Penalty_Amount")%>
                                    </ItemTemplate>
                                </asp:TemplateField>





                            </Columns>
                        </asp:GridView>


                        <div class="depos_con2">
                            <asp:Label ID="Label5" runat="server" Text="Total:"></asp:Label>
                            <asp:Label ID="lblAmtPenalty" runat="server"></asp:Label>
                        </div>

                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
