<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SmallLogOut.ascx.vb" Inherits="Account_SmallLogOut" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
 <!--<link href="c_style.css" rel="stylesheet" type="text/css" />-->
<div>

<div class="mri_loout">
    <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="False">
        <LoggedInTemplate>
            <div>
            <asp:Label ID="lblWelcome" runat="server" Text="Welcome" meta:resourcekey="lblWelcomeResource1" /><b><span>
                <asp:LoginName ID="HeadLoginName" runat="server" meta:resourcekey="HeadLoginNameResource1" />
            </span></b>
            <asp:Label ID="Label1" runat="server" Text="!"></asp:Label>
           
               
                    <asp:LoginStatus Width="57" CssClass="logout_butt" ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" 
                        LogoutText="Log Out" LogoutPageUrl="~/default.aspx" OnLoggedOut="logout" meta:resourcekey="HeadLoginStatusResource1" />
               
              
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</div>
</div>
