<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DeposistsHistory.aspx.vb" MasterPageFile="~/AccountMaster.master" Inherits="DeposistsHistory" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="acc_cnt">
        <!---acc_cnt start---->
        <div>
            <h2>DEPOSITS</h2>            
            <div class="clear"></div>
            <br />
        </div>

        <div class="fix">
            <asp:UpdatePanel ID="depositPanel" runat="server">
                <ContentTemplate>

                    <asp:TabContainer ID="depositTabs" runat="server">
                        <asp:TabPanel runat="server" ID="pendingTab" CssClass="historyTab">
                            <HeaderTemplate>
                                <span class="historyTabHeader">Pending Deposits</span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:GridView ID="GVDepositPendingHistory" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" runat="server" DataKeyNames="Reference">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Reference" SortExpression="Reference">
                                            <ItemTemplate>
                                                <asp:Label runat="server" CssClass="textmode" ID="lbl_0" Text=<%# Eval("Reference")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment Method" SortExpression="Payment_method">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_1" Text=<%# Eval("Payment_method")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_2" Text=<%# Eval("Date")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Withdrawn Amount" SortExpression="Amount">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_3" Text=<%# Eval("Amount")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment plan" SortExpression="package_name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_4" Text=<%# Eval("package_name")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reason" SortExpression="remarks">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_5" Text=<%# Eval("remarks")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" />
                                </asp:GridView>
                                <br />
                                <div class="export_buttons">
                                    <asp:Button runat="server" Text="Export to CSV" CssClass="acc_btn" ID="btn_CSV_Pending" />
                                    <asp:Button runat="server" Text="Export to PDF" CssClass="acc_btn" ID="btn_PDF_Pending" />
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>

                        <asp:TabPanel runat="server" ID="acceptedTab" CssClass="historyTab">
                            <HeaderTemplate>
                                <span class="historyTabHeader">Accepted Deposits</span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:GridView ID="GVDepositAcceptedHistory" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PagerSettings-Mode="NumericFirstLast" PageSize="10" runat="server" DataKeyNames="Reference">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Reference" SortExpression="Reference">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_0" Text=<%# Eval("Reference")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment Method" SortExpression="Payment_method">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_1" Text=<%# Eval("Payment_method")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_2" Text=<%# Eval("Date")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Withdrawn Amount" SortExpression="Amount">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_3" Text=<%# Eval("Amount")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transaction ID" SortExpression="Transaction_ID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_4" Text=<%# Eval("Transaction_ID")%> />                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment plan" SortExpression="package_name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_5" Text=<%# Eval("package_name")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <div class="export_buttons">
                                    <asp:Button runat="server" Text="Export to CSV" CssClass="acc_btn" ID="btn_CSV_Accepted" />
                                    <asp:Button runat="server" Text="Export to PDF" CssClass="acc_btn" ID="btn_PDF_Accepted" />
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>

                        <asp:TabPanel runat="server" ID="rejectedTab" CssClass="historyTab">
                            <HeaderTemplate>
                                <span class="historyTabHeader">Rejected Deposits</span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:GridView ID="GVDepositRejectedHistory" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PagerSettings-Mode="NumericFirstLast" PageSize="10" runat="server" DataKeyNames="Reference">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Reference" SortExpression="Reference">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_0" Text=<%# Eval("Reference")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment Method" SortExpression="Payment_method">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_1" Text=<%# Eval("Payment_method")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_2" Text=<%# Eval("Date")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Withdrawn Amount" SortExpression="Amount">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_3" Text=<%# Eval("Amount")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment plan" SortExpression="package_name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_4" Text=<%# Eval("package_name")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reason" SortExpression="remarks">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_5" Text=<%# Eval("remarks")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <div class="export_buttons">
                                    <asp:Button runat="server" Text="Export to CSV" CssClass="acc_btn" ID="btn_CSV_Rejected" />
                                    <asp:Button runat="server" Text="Export to PDF" CssClass="acc_btn" ID="btn_PDF_Rejected" />
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>

                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="depositTabs$rejectedTab$btn_CSV_Rejected" />
                    <asp:PostBackTrigger ControlID="depositTabs$acceptedTab$btn_CSV_Accepted" />
                    <asp:PostBackTrigger ControlID="depositTabs$pendingTab$btn_CSV_Pending" />
                    <asp:PostBackTrigger ControlID="depositTabs$rejectedTab$btn_PDF_Rejected" />
                    <asp:PostBackTrigger ControlID="depositTabs$acceptedTab$btn_PDF_Accepted" />
                    <asp:PostBackTrigger ControlID="depositTabs$pendingTab$btn_PDF_Pending" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
