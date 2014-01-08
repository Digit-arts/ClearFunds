<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PaymentDue.aspx.vb" MasterPageFile="~/AccountMaster.master" Inherits="Account_PaymentDue" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    <h2 style="left:330px;">paymentdue</h2>
    </div>
    <div id="divRB" runat ="server"></div>
      <div id="divbutton" runat="server">
            <asp:HiddenField ID="PressedButton" runat="server" /> 
      </div>
    </asp:Content>

