<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WithDrawalHistory.aspx.vb" MasterPageFile="~/Admin/Site.master" Inherits="Admin_WithDrawalHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h2 style="color: #fff;">With Drawal History</h2>
        <table style="background: none; color: #fff; border: 0px;">
            <tr>
                <td style="width: 230px; float: left;">
                    <asp:Label ID="Label1" runat="server" Text="From"
                        Style="float: left; margin-right: 7px; padding-top: 7px;" Height="16px"></asp:Label>
                    <asp:TextBox ID="txtfrom" runat="server" Width="150px" CssClass="inputbox smallbox"></asp:TextBox>
                    <asp:CalendarExtender ID="txtfrom_CalendarExtender" runat="server"
                        TargetControlID="txtfrom">
                    </asp:CalendarExtender>
                </td>


                <td style="width: 200px; float: left;">
                    <asp:Label ID="Label2" runat="server" Text="To" Style="float: left; margin-right: 7px; padding-top: 7px;"></asp:Label>
                    <asp:TextBox ID="txtto" runat="server" Width="150px" CssClass="inputbox smallbox"></asp:TextBox>
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
            <asp:GridView ID="GVWithdrawDetails" AllowSorting="true" PageSize="10" AllowPaging="true" AutoGenerateColumns="False" runat="server"
                PagerSettings-Mode="Numeric">
                <Columns>
                    <asp:TemplateField HeaderText="Reference" SortExpression="WithDrawl_Id">
                        <ItemTemplate>
                            <%# Eval("WithDrawl_Id")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" SortExpression="Username">
                        <ItemTemplate>
                            <%# Eval("UserName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Withdraw date" SortExpression="WithDrawl_Date">
                        <ItemTemplate>
                            <%# Eval("WithDrawl_Date")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Withdraw Amount ($)" SortExpression="WithDrawl_Amount">
                        <ItemTemplate>
                            <%# Eval("WithDrawl_Amount")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" SortExpression="WithDrawl_Status">
                        <ItemTemplate>
                            <%# Eval("WithDrawl_Status")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="WithDrawl_Payname" HeaderText="Withdraw Method" SortExpression="WithDrawl_Payname" />
                    <asp:BoundField DataField="WithDrawl_SysIp" HeaderText="IP Address" SortExpression="WithDrawl_SysIp" />
                    <asp:BoundField DataField="WithDrawl_CountryName" HeaderText="Country Flag" SortExpression="WithDrawl_CountryName" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div>
        &nbsp;&nbsp;&nbsp;
 <div class="depos_con">
     <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label>

     <asp:Label ID="lblAmt" runat="server"></asp:Label>

 </div>
    </div>



</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1 {
            width: 950px;
        }
    </style>
</asp:Content>

