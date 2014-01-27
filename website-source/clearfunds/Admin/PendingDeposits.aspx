<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PendingDeposits.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_PendingDeposists" %>

<%--<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="DepositDetails.aspx.vb" Inherits="Admin_DepositDetails" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h2>Deposit Details</h2>
        <table class="con_text1" style="background: none; border: 0px; color: #fff;">
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

            </tr>
        </table>
    </div>

    <asp:GridView ID="GVDepositDetails" AutoGenerateColumns="false" runat="server"
        PagerSettings-Mode="Numeric">
        <Columns>

            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <%# Eval("UserName")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Deposit date">
                <ItemTemplate>
                    <%# Eval("Deposit_ModifyDate")%>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Deposit Amount ($)">
                <ItemTemplate>
                    <%# Eval("Deposit_Amount")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="lkApprove" runat="server" Text="Approve" CommandArgument='<%# Eval("Deposit_Id")%>' OnClick="lkApprove_Click" />
                    <asp:LinkButton ID="lkReject" runat="server" Text="Reject" CommandArgument='<%# Eval("Deposit_Id")%>' OnClick="lkReject_Click" />
                    <asp:LinkButton ID="lkChangeAmount" runat="server"  Text="Edit" CommandArgument='<%# Eval("Deposit_Id")%>' OnClick="lkChangeAmount_Click" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Reasons / New amount">
                <ItemTemplate>
                    <asp:TextBox runat="server"  TextMode="MultiLine" ID="txtReasons" />
                </ItemTemplate>
            </asp:TemplateField>
            

            <asp:BoundField Visible="false" DataField="Deposit_Id" />


        </Columns>
    </asp:GridView>


    <div>
        &nbsp;&nbsp;&nbsp;
 <div class="depos_con">
     <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>

     <asp:Label ID="lblAmt" runat="server"></asp:Label>
 </div>
    </div>


</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1 {
            width: 1116px;
        }
    </style>
</asp:Content>
