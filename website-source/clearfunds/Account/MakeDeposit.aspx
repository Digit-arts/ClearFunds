<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/AccountMaster.master" CodeFile="MakeDeposit.aspx.vb" Inherits="Account_MakeDeposit" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <%--  <script type="text/javascript" >
    
            function validateText(e)
     {
        var unicode = e.charCode ? e.charCode : e.keyCode
        if (unicode > 48 && unicode < 57)
            return false;
        else
            return true;
    }
    </script>--%>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">




    <h2 style="left: 330px;">Make deposit</h2>
    <div class="clear"></div>
    <br />
    <div id="errorblock" runat="server" visible="false" class="top-message-block errorblock" enableviewstate="false">
        <asp:Label runat="server" Text="test" ID="txtError" />
    </div>
    <div id="successblock" runat="server" visible="false" class="top-message-block successblock" enableviewstate="false">
        <asp:Label runat="server" Text="test" ID="txtSuccess" />
    </div>
    <div id="maindiv" runat="server">
        <asp:Panel ID="Panel1" runat="server" class="content-block" meta:resourcekey="Panel1Resource1">
            <h3>Select a payment plan</h3>
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <div id="divRB" runat="server"></div>
            </asp:PlaceHolder>
        </asp:Panel>

        <div class="clear"></div>
        <br />
        <asp:Panel ID="Panel3" runat="server" class="content-block" meta:resourcekey="Panel1Resource1">
            <h3>Confirm the deposit amount</h3>
            <br />

            <div>
                <asp:Label ID="Label2" runat="server" Text="Amount To Spend($):" meta:resourcekey="Label2Resource1"></asp:Label>
                <asp:TextBox ID="txtSpendAmount" runat="server" CssClass="input_box2 small_box" Style="margin-left: 27px;" meta:resourcekey="txtSpendAmountResource1" AutoPostBack="True"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtSpendAmount" runat="server" FilterType="Numbers">
                </asp:FilteredTextBoxExtender>
                <%--  onkeypress="return validateText(event)"--%>
            </div>
        </asp:Panel>

        <div class="clear"></div>
        <br />
        <asp:Panel ID="Panel2" runat="server" meta:resourcekey="Panel2Resource1" class="content-block">
            <h3>Select your payment method</h3>
            <br />
            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                <div id="divpayment" runat="server">
                </div>

                <div id="divCC" runat="server" visible="true">
                    <br />
                    <div id="divcreditcard1" visible="false" runat="server" class="cre_card12">
                        <asp:Label ID="lblcardnum" runat="server" Text="Card Number" meta:resourcekey="lblcardnumResource1"></asp:Label>
                        <asp:TextBox ID="txtcardnumber" runat="server" meta:resourcekey="txtcardnumberResource1"></asp:TextBox>
                    </div>
                    <div id="divcreditcard2" visible="false" runat="server" class="cre_card12">
                        <asp:Label ID="lblcardcode" runat="server" Text="Card Code" meta:resourcekey="lblcardcodeResource1"></asp:Label>
                        <asp:TextBox ID="txtcardcode" runat="server" meta:resourcekey="txtcardcodeResource1"></asp:TextBox>
                    </div>
                    <div id="divcreditcard3" visible="false" runat="server" class="cre_card12">
                        <asp:Label ID="lblcardexp" runat="server" Text="Card Expiry" meta:resourcekey="lblcardexpResource1"></asp:Label>
                        <asp:TextBox ID="txtcardexpiry" runat="server" meta:resourcekey="txtcardexpiryResource1"></asp:TextBox>
                    </div>
                </div>
            </asp:PlaceHolder>
            <div class="clear"></div>
            <br />
            <h3>Or deposit from your bonus (current bonus :
                <asp:Label ID="lblbonusamt" runat="server" Text="Label" meta:resourcekey="lblbonusamtResource1" />)</h3>
            <br />
            <div>
                <asp:RadioButton ID="RadioButton1" GroupName="SUB" runat="server" Text="Deposit From Bonus" meta:resourcekey="RadioButton1Resource1" />
            </div>



        </asp:Panel>

        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="yellow_btn" meta:resourcekey="btnSubmitResource1" />
            <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Visible="False" Text="Data successfully saved" meta:resourcekey="lblmsgResource1"></asp:Label>

            <%--<asp:Button ID="Button2" runat="server"   Text="authorizenet" />--%>
        </div>

    </div>
    <div>
        <asp:Label ID="lbldet" Visible="False" runat="server" meta:resourcekey="lbldetResource1"></asp:Label>
    </div>
    <div align='center'>
        <asp:HyperLink ID="lnkhome" Visible="False" NavigateUrl="~/Account/Home.aspx" runat="server" meta:resourcekey="lnkhomeResource1">GO TO HOME PAGE</asp:HyperLink>
    </div>
</asp:Content>
