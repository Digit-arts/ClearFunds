<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Login1.ascx.vb" Inherits="Login1" %>

<%--<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">--%>
   <%-- <h2 style="left:345px;">
        Log In
    </h2>--%>
  <%--  <p class="login_con">
        Please enter your username and password.
        <asp:HyperLink ID="RegisterHyperLink" NavigateUrl="~/Register.aspx" runat="server" EnableViewState="false">Register</asp:HyperLink> if you don't have an account.
    </p>--%>


    <asp:Login ID="LoginUser"  runat="server" EnableViewState="false" RenderOuterTable="false"   meta:resourcekey="LoginUserResource1">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <%--<asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>--%>
            <div class="middle_img_h5">
            <div class="o_infobot"> <div class="o_login"> Login Now </div></div>
            <div class="oinfocenter3">
               
             
                      <div class="o_textbox">

                      <asp:TextBox  ID="UserName" runat="server"  CssClass="o_textbox textEntry input_box2 small_box text_size" Width="178px"
                     meta:resourcekey="UserNameResource1" value="Username" onfocus="javascript: if(this.value == 'Username'){ this.value = ''; }" onblur="javascript: if(this.value==''){this.value='Username';} "></asp:TextBox>
                    
                      <%--<input type="text" id="Text1" name="password" value="Password" onClick="changeType()" />--%>
                 <%--    meta:resourcekey="UserNameResource1" value="Username " onfocus="javascript: if(this.value == 'Username'){ this.value = ''; }" onblur="javascript: if(this.value==''){this.value='Username ';} "></asp:TextBox>--%>

                        <%--<asp:TextBox ID="UserName" runat="server" CssClass="o_textbox textEntry input_box2 small_box text_size" Width="178px" Text="UserName"></asp:TextBox>--%>
                        <%--<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>--%></div>
                   
                    <div class="o_textbox">
                        <%--<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>--%>
                        <asp:TextBox ID="Password" runat="server" CssClass="o_textbox textEntry input_box2 small_box text_size" Width="178px" TextMode="Password" Text="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator></div>
                  <div class="o_radio_btn">
                        <asp:CheckBox ID="RememberMe" runat="server" style="float:left;"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline" style="width:115px; margin-top:2px; margin-left:5px; ">RememberMe</asp:Label>
                        </div>
           <%--             <asp:HyperLink ID="HyperLink1" NavigateUrl="Account/ForgotPassword.aspx" runat="server">Forgot Password</asp:HyperLink>--%>
                     <%--   <asp:HyperLink ID="HyperLink1" NavigateUrl="~/ForgotPassword.aspx" runat="server">Forgot Password</asp:HyperLink>--%>
                        
                    
                    
                    <div class="submitButton" style="margin-left:0px; ">
                    <asp:Button ID="LoginButton" runat="server"  CommandName="Login" Text="Sign in" ValidationGroup="LoginUserValidationGroup"/>
                </div>
              

                </div>
                <div class="o_infobottom"> <asp:Image ID="Image15" BorderWidth="0" AlternateText="ClearFunds"
                            ImageUrl="~/images/o_infobottom.png" runat="server" /></div>
                
            </div>
        </LayoutTemplate>
    </asp:Login>
       
<%--</asp:Content>--%>