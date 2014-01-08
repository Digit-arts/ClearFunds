<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WithDraw.aspx.vb" MasterPageFile="~/AccountMaster.master" Inherits="Account_WithDraw" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">

        function validateText(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode > 48 && unicode < 57)
                return false;
            else
                return true;
        }

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 9 && unicode != 46) { //if the key isn't the backspace key (which we should allow)
                if (unicode < 48 || unicode > 57) //if not a number
                    return false //disable key press
            }
        }

        function popup(url) {
            mywin = window.open("", "goidiaplaywin", "status=no,width=550,scrollbars=yes,height=360,left=250,top=175");
            mywin.location.href = url;
            mywin.focus();
        }



    </script>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <div class="clear"></div>


    <h2 style="left: 336px;">withdraw</h2>
    <div class="clear"></div>
    <br />
    <div id="errorblock" runat="server" visible="false" class="top-message-block errorblock" enableviewstate="false">
        <asp:Label runat="server" Text="test" ID="txtError" />
    </div>
    <div id="successblock" runat="server" visible="false" class="top-message-block successblock" enableviewstate="false">
        <asp:Label runat="server" Text="test" id="txtSuccess"/>
    </div>
    <asp:Panel ID="Panel2" runat="server" meta:resourcekey="Panel2Resource1" class="content-block">
        <h3>Select your payment plan for withdrawal</h3>
        <br />
        <div id="RbPackage" runat="server">
            <asp:Label ID="Label2" runat="server" Visible="false" Text="Packege Balance : "></asp:Label>
            <asp:Label ID="lblpackbalance" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblerr" runat="server" Visible="false" Text=""></asp:Label>


        </div>
    </asp:Panel>
    <div>
    </div>
    <br />
    <div class="content-block">
        <h3>Please confirm the amount to withdraw</h3>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Amount To WithDraw"></asp:Label>
        <asp:TextBox ID="txtwithdraw" onkeypress="return numbersonly(event)" runat="server" CssClass="inputbox smallbox" Style="background: #fff; margin-left: 5px;"></asp:TextBox>


    </div>

    <div class="clear"></div>
    <br />
    <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel2Resource1" class="content-block">
        <h3>Select your payment method</h3>
        <br />
        <asp:UpdatePanel runat="server" ID="updPaymode" UpdateMode="Always">
            <ContentTemplate>
                <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                    <asp:RadioButton runat="server" ID="rbPP" GroupName="test" AutoPostBack="true" OnCheckedChanged="rbPP_CheckedChanged" /><img style="height: 30px; width: 90px;" src="../Handlers/makedeposit.ashx?id=0000002G">
                    <asp:RadioButton runat="server" ID="rbPZ" GroupName="test" AutoPostBack="true" OnCheckedChanged="rbPZ_CheckedChanged" /><img style="height: 30px; width: 90px;" src="../Handlers/makedeposit.ashx?id=0000002H">
                    <asp:RadioButton runat="server" ID="rbSTP" GroupName="test" AutoPostBack="true" OnCheckedChanged="rbSTP_CheckedChanged" /><img style="height: 30px; width: 90px;" src="../Handlers/makedeposit.ashx?id=0000002J">
                    <asp:RadioButton runat="server" ID="rbPM" GroupName="test" AutoPostBack="true" OnCheckedChanged="rbPM_CheckedChanged" />
                    <img style="height: 30px; width: 90px;" src="../Handlers/makedeposit.ashx?id=0000002L">
                </asp:PlaceHolder>
                <div id="divPaypal" runat="server" visible="false">
                    <br />
                    <div id="divPPID" runat="server" class="cre_card12">
                        <asp:Label ID="lblPPID" runat="server" Text="Paypal ID : " />
                        <asp:TextBox ID="txtPPID" runat="server" />
                    </div>
                    <div id="divPPName" runat="server" class="cre_card12">
                        <asp:Label ID="lblPPName" runat="server" Text="Account holder name : " />
                        <asp:TextBox ID="txtPPName" runat="server" />
                    </div>
                </div>
                <div id="divSolidTrustPay" runat="server" visible="false">
                    <br />
                    <div id="divSTPID" runat="server" class="cre_card12">
                        <asp:Label ID="lblSTPID" runat="server" Text="Username : " />
                        <asp:TextBox ID="txtSTPID" runat="server" />
                    </div>
                    <div id="divSTPName" runat="server" class="cre_card12">
                        <asp:Label ID="lblSTPName" runat="server" Text="Account holder name : " />
                        <asp:TextBox ID="txtSTPName" runat="server" />
                    </div>
                </div>
                <div id="divPayza" runat="server" visible="false">
                    <br />
                    <div id="divPZID" runat="server" class="cre_card12">
                        <asp:Label ID="lblPZID" runat="server" Text="Email address : " />
                        <asp:TextBox ID="txtPZID" runat="server" />
                    </div>
                    <div id="divPZName" runat="server" class="cre_card12">
                        <asp:Label ID="lblPZName" runat="server" Text="Account holder name : " />
                        <asp:TextBox ID="txtPZName" runat="server" />
                    </div>
                </div>
                <div id="divPerfectMoney" runat="server" visible="false">
                    <br />
                    <div id="divPMID" runat="server" class="cre_card12">
                        <asp:Label ID="lblPMID" runat="server" Text="Account number : " />
                        <asp:TextBox ID="txtPMID" runat="server" />
                    </div>
                    <div id="divPMName" runat="server" class="cre_card12">
                        <asp:Label ID="lblPMName" runat="server" Text="Account holder name : " />
                        <asp:TextBox ID="txtPMName" runat="server" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <div class="clear"></div>


    <asp:Button ID="btnwithdraw" runat="server" Text="WithDraw" CssClass="btnalt " Style="float: right; width: auto;" />
    <asp:Label ID="successLabel" ForeColor="Yellow" runat="server"></asp:Label>

</asp:Content>
