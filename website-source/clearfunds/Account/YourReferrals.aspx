<%@ Page Language="VB" AutoEventWireup="false" CodeFile="YourReferrals.aspx.vb"  MasterPageFile="~/AccountMaster.master"   Inherits="Account_YourReferrals" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    
<h2 style="left:315px;">YOUR REFERRALS</h2>

<div style="width:750px; height:auto; border:1px solid #ccc; border-radius:3px; padding:5px; margin-top:5px;">
<div  ID="pnlaccount" runat="server" class="acc_ur">
 

</div>

</div>
<%--<asp:Panel ID="pnlaccount" runat="server">

<table>

<tr>
<td>
<asp:Label ID="Label1" runat="server" Text="Referrals : "></asp:Label>
</td>
<td>
<asp:Label ID="lblReferrals" runat="server" ></asp:Label>
</td>
</tr>


<tr>
<td>
<asp:Label ID="Label3" runat="server" Text="Active referrals :"></asp:Label>
</td>
<td>
<asp:Label ID="lblActiverefe" runat="server" ></asp:Label>
</td>
</tr>

<tr>
<td>
<asp:Label ID="Label5" runat="server" Text="Total referral commission: "></asp:Label>
</td>
<td>
<asp:Label ID="lbltotalref" runat="server" ></asp:Label>
</td>
</tr>



</table>

</asp:Panel>--%>

</asp:Content>