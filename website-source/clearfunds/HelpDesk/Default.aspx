<%@ Page Title="Log In" Language="VB" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="_Default" %>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">

<head runat="server">
<title>Help Desk Login</title> 
    <link href="Styles/CF_Styles.css" rel="stylesheet" type="text/css" />
</head> 
<body style="height:auto;">
<form runat="server" >
    
  
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
               <div class ="login_header" ><h2 >HelpDesk<a>&nbsp; LogIn</a></h2></div>
                 <%-- <p>Please enter your username and password.
                     <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Register</asp:HyperLink> if you don't have an account.
                     </p>--%>
                <div class ="login_content" >
                <fieldset class="login">
                    
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass ="lable_size" >Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry inputbox smallbox text_size "></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass ="lable_size" >Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry inputbox smallbox text_size  " TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                        ValidationGroup="LoginUserValidationGroup" onclick="LoginButton_Click" CssClass =" btn_style  "/>
                </p>
                </div>

            </div>
        </LayoutTemplate>
    </asp:Login>
    </form> 
</body> 
</html> 