<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Logout1.ascx.vb" Inherits="Logout1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div>
    <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="False">
        <LoggedInTemplate>
            <div>
            <b><span>
                <%--<asp:LoginName ID="HeadLoginName" runat="server" meta:resourcekey="HeadLoginNameResource1" />--%>
            </span></b>
         
           
                <div>
                    <asp:LoginStatus Width="57" CssClass="logout_butt" ID="HeadLoginStatus" runat="server" LogoutAction="Redirect"
                        LogoutText="Log Out" LogoutPageUrl="~/default.aspx" OnLoggedOut="logout" meta:resourcekey="HeadLoginStatusResource1" ForeColor="Black" Font-Underline="False" />
                </div>
              
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</div>
