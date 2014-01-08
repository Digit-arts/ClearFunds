<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Account_Login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/l_style.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    
    <div class="lgn_wrap"><!---lgn_wrap start---->
		<div class="lgn_tp"><!---lgn_tp start---->
            <div class="center"><!---center start---->
        		<p>Sales :039435504495</p>
        	</div><!--- center end--->
		</div><!---- lgn_tp end--->
        <div class="lgn_logo_bg"><!--- lgn_logo_bg start---->
        	<div class="center">
        		
                <div class="acc_logo_img">
               <a href="../Default.aspx"> <img src="../Images/lgn_logo.png" /></a>
                
            </div>
		</div><!--- lgn_logo_bg end--->
	</div><!---lgn_wrap start---->
	<div class="lgn_cnt_wrap"><!--- lgn_cnt_wrap start--->
		<div class="lgn_cnt"><!---lgn_cnt start---->
			<h3>Clearfunds Login</h3>
                <p>Clearfunds is a Server management portal for customers of RapidSwitch to monitor and control their 
dedicated or colocated servers.
				</p>
                 <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText"  runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary"  runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
              <%--  <fieldset class="login">--%>
                     <div class="lgn_cnt_mdl"><!--- lgn_cnt_mdl start---->
                <div class="lgn_cnt_fst">
                   
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name   :</asp:Label>
                        <asp:TextBox ID="UserName" runat="server"  CssClass="validate[required] input_box2 small_box"></asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" CssClass="failureNotification"  ValidationGroup="LoginUserValidationGroup" ErrorMessage="UserName is required" ToolTip="User Name is required." >*</asp:RequiredFieldValidator>
                  
                   </div>
                   <div class="lgn_cnt_fst">
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password   :</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="o_textbox textEntry input_box2 small_box text_size"  TextMode="Password" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                       </div>
                    <div class="clear"></div>
                   <div class="lgn_cnt_fst">
                        <asp:CheckBox ID="RememberMe" runat="server" />
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" style="width:120px;">Keep me logged in   :</asp:Label>
                        </div>
                   <div class="lgn_norton">
                </div>
                     <div class="lgn_cnt_fst">
                    <asp:Button ID="LoginButton" class="submitButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>
               </div>
                <div class="clear"></div>
                </div>
              <%--  </fieldset>--%>
           

                <h4>Not a user?</h4>
                <p style="margin:4px 0px;">If you are not currently registered with Clearfunds <span ><a href="#" style="color:#2a5d95;">   <asp:HyperLink ID="HyperLink1" NavigateUrl="~/register.aspx" runat="server">Register Here</asp:HyperLink> </a></span>. If your company is already registered 
        but you are not, you can get whoever set up the account to add you as a contact, enabling access to 
        Clearfunds.</p>
                <h4>Forgotten Password?</h4>
                <p style="margin:4px 0px;">If you cannot remember your password, you can <span ><a href="#" style="color:#2a5d95;"><asp:HyperLink ID="HyperLink2" NavigateUrl="~/ForgotPassword.aspx" runat="server">Forgot Password</asp:HyperLink>
                </a>
                </span>	</p>
                </div>
			</div><!--- lgn_cnt_mdl end---->
		</div><!----lgn_cnt end--->
	</div><!--- lgn_cnt_wrap end--->  
    
    <div class="acc_nav">
    </div> 
         
            </div>
        </LayoutTemplate>
    </asp:Login>


    </div>
    </form>
</body>
</html>
