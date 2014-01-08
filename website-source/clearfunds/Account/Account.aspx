<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/AccountMaster.master"    CodeFile="Account.aspx.vb" Inherits="Account" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clear:both"></div>

           			
           			
	
    <h2 style="left:343px;">Account</h2>
    
<center>

<asp:Panel ID="pnlaccount" runat="server"  CssClass="accnt_box" >



<table>
<tr>
<td align ="left" >
    <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
    </td>
<td align ="center" width:"30px"><h3>:</h3></td>
<td align ="left" >
    <asp:Label ID="lblusername" runat="server"></asp:Label>
    </td>


</tr>
<tr>
<td align ="left" >
    <asp:Label ID="Label3" runat="server" Text="Registration Date"></asp:Label>
    </td>
<td align ="center" width:"30px"><h3>:</h3></td>
<td align ="left" >
    <asp:Label ID="lblRegDate" runat="server"></asp:Label>
    </td>


</tr>
<tr>
<td align ="left" >
    <asp:Label ID="Label5" runat="server" Text="Last Access"></asp:Label>
    </td>
<td align ="center" width:"30px"><h3>:</h3></td>
<td align ="left" >
    <asp:Label ID="lblLastAccess" runat="server"></asp:Label>
    </td>


</tr>
<tr>
<td align ="left" >
    <asp:Label ID="Label7" runat="server" Text="Account Balance"></asp:Label>
    </td>
<td align ="center" width:"30px"><h3>:</h3></td>
<td align ="left" >
    <asp:Label ID="lblAccountBalance" runat="server"></asp:Label>
    </td>


</tr>
<tr>
<td align ="left" >
    <asp:Label ID="Label9" runat="server" Text="Earned Total"></asp:Label>
    </td>
<td align ="center" width:"30px"><h3>:</h3></td>
<td align ="left" >
    <asp:Label ID="lblEarnedTotal" runat="server"></asp:Label>
    </td>


</tr>
<tr>
<td align ="left" >
    <asp:Label ID="Label11" runat="server" Text="Pending Withdrawal"></asp:Label>
    </td>
<td align ="center" width:"30px"><h3>:</h3></td>
<td align ="left" >
    <asp:Label ID="lblPendingWithdrawal" runat="server"></asp:Label>
    </td>


</tr>
<tr>
<td align ="left" >
    <asp:Label ID="Label13" runat="server" Text="Withdrew Total"></asp:Label>
    </td>
<td align ="center" width:"30px"><h3>:</h3></td>
<td align ="left" >
    <asp:Label ID="lblWithdrewTotal" runat="server"></asp:Label>
    </td>


</tr>
<tr>
<td align ="left" >
    <asp:Label ID="Label15" runat="server" Text="Active Deposit"></asp:Label>
    </td>
<td align ="center" width:"30px"><h3>:</h3></td>
<td align ="left" >
    <asp:Label ID="lblActiveDeposit" runat="server"></asp:Label>
    </td>


</tr>

</table>







</asp:Panel>

    <asp:RoundedCornersExtender ID="pnlaccount_RoundedCornersExtender" 
        runat="server" Enabled="True" TargetControlID="pnlaccount" Corners ="All" Radius ="10">
    </asp:RoundedCornersExtender>

</center>

<br />
<br />
<br />



</asp:Content>