<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WithdrawalsHistory.aspx.vb" MasterPageFile="~/AccountMaster.master" Inherits="Account_WithdrawalsHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="acc_cnt">
        <!---acc_cnt start---->
        <div>
            <h2>WITHDRAWALS </h2>
            <div class="clear"></div>
            <br />
        </div>

        <div class="fix">
            <asp:UpdatePanel ID="withdrawalsPanel" runat="server">
                <ContentTemplate>

                    <asp:TabContainer ID="withdrawalsTabs" runat="server">
                        <asp:TabPanel runat="server" ID="pendingTab" CssClass="historyTab">
                            <HeaderTemplate>
                                <span class="historyTabHeader">Pending Withdrawals</span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:GridView ID="GVWithDrawalPendingHistory" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PagerSettings-Mode="NumericFirstLast" PageSize="10" runat="server" DataKeyNames="Reference">
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
                                        <asp:TemplateField HeaderText="Request status" SortExpression="WithDrawl_Status">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_6" Text=<%# Eval("WithDrawl_Status")%> />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
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
                                <span class="historyTabHeader">Accepted Withdrawals</span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:GridView ID="GVWithDrawalAcceptedHistory" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PagerSettings-Mode="NumericFirstLast" PageSize="10" runat="server" DataKeyNames="Reference">
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
                                <span class="historyTabHeader">Rejected Withdrawals</span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:GridView ID="GVWithDrawalRejectedHistory" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PagerSettings-Mode="NumericFirstLast" PageSize="10" runat="server" DataKeyNames="Reference">
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
                    <asp:PostBackTrigger ControlID="withdrawalsTabs$rejectedTab$btn_CSV_Rejected" />
                    <asp:PostBackTrigger ControlID="withdrawalsTabs$acceptedTab$btn_CSV_Accepted" />
                    <asp:PostBackTrigger ControlID="withdrawalsTabs$pendingTab$btn_CSV_Pending" />
                    <asp:PostBackTrigger ControlID="withdrawalsTabs$rejectedTab$btn_PDF_Rejected" />
                    <asp:PostBackTrigger ControlID="withdrawalsTabs$acceptedTab$btn_PDF_Accepted" />
                    <asp:PostBackTrigger ControlID="withdrawalsTabs$pendingTab$btn_PDF_Pending" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
