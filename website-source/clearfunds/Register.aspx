<%@ Page Title="Register" Language="VB" MasterPageFile="~/ContentMaster.master" AutoEventWireup="false"
    CodeFile="Register.aspx.vb" Inherits="Account_Register"  %>
 
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <script type="text/javascript" >

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

        function checking() {
            if (document.getElementById("check1").checked == false) {
                alert("Accept terms and agreement");
                return false;
            }
            return true;
        }
  
     </script>
  
<link href="css/template.css" rel="stylesheet" type="text/css" />
<link href="css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-1.6.min.js" type="text/javascript"></script>
<script src="js/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
<script src="js/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery("#form1").validationEngine();
    });
</script>


</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <ContentTemplate>   
    <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false">
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                    <h2 style="left:347px;">Sign up</h2>
                    <p>Use the form below to create a new account.</p>
                    <p>Passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.</p>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                         <div   class="accountInfo">
                            <fieldset    class="register">
                               <%-- <legend ><h3>Account Information</h3></legend>--%>
                                       <div class="regs_con1">
                                                 <div class="cntfrm_one">
                                                        <label style="padding-top:7px;"><asp:Label ID="Label2" runat="server" Text="Salutation *"></asp:Label></label>
                                                        <div class="cntfrm_right"><asp:DropDownList ID="cmbsaluation" runat="server" CssClass="validate[required] input_box2 select" style="width:180px; border:1px solid #999;">
                                                            <asp:ListItem Value="" Selected="True" text="Choose Salutation" />
                                                            <asp:ListItem Value="Mr"  Text="Mr" />
                                                            <asp:ListItem Value="Mrs" Text="Mrs" />
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="cmbsaluationRequired" ControlToValidate="cmbsaluation" runat="server" ValidationGroup="RegisterUserValidationGroup"  ErrorMessage="Saluation is required" ToolTip="Saluation Name is required.">*</asp:RequiredFieldValidator>--%>
                                                        </div> 
                                                   </div>
                                                    <div class="cntfrm_one">
                                                    <label><asp:Label ID="lblFirstName" runat="server" Text="First Name *"></asp:Label></label>
                                                        <div class="cntfrm_right"><asp:TextBox ID="txtFirstName" runat="server" CssClass="validate[required] input_box2 small_box" onkeypress="return validateText(event)"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="txtfirstnameRequired" runat="server" ControlToValidate="txtFirstName"  ValidationGroup="RegisterUserValidationGroup"  ErrorMessage="FirstName is required"   ToolTip="First Name is required.">*</asp:RequiredFieldValidator>--%>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="txtFirstName" runat="server"  ValidationExpression="^[a-zA-Z]{2,128}$" ValidationGroup="RegisterUserValidationGroup" ErrorMessage="Invalid Name">*</asp:RegularExpressionValidator>--%> 
                                                        </div>
                                                    </div>
                                                    <div class="cntfrm_one">
                                                    <label><asp:Label ID="lblLastName" runat="server" Text="Last Name *"></asp:Label></label>
                                                        <div class="cntfrm_right"><asp:TextBox ID="txtLastName" runat="server" CssClass="validate[required] input_box2 small_box" onkeypress="return validateText(event)" ></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="txtlastnameRequired" ControlToValidate="txtLastName"  ValidationGroup="RegisterUserValidationGroup"  ErrorMessage="LastName is required" ToolTip="Last Name is required." runat="server" >*</asp:RequiredFieldValidator>--%>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="InavlaidName" ValidationExpression="^[a-zA-Z]{2,128}$" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>--%>
                                                        </div>
                                                     </div>
                                                      <div class="cntfrm_one">
                                                      <label><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name *</asp:Label></label>
                                                        <div class="cntfrm_right"><asp:TextBox ID="UserName" runat="server"  CssClass="validate[required] input_box2 small_box"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" CssClass="failureNotification"  ValidationGroup="RegisterUserValidationGroup" ErrorMessage="UserName is required" ToolTip="User Name is required." >*</asp:RequiredFieldValidator>--%>
                                                        </div>
                                                     </div>
                                                    <div class="cntfrm_one">
                                                    <label><asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail *</asp:Label></label>
                                                         <div class="cntfrm_right"><asp:TextBox ID="Email" runat="server"  CssClass="validate[required,custom[email] input_box2 small_box"></asp:TextBox>
                                                             <%--<asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" CssClass="failureNotification"  Display="Dynamic" ErrorMessage="Email is required" ToolTip="E-mail is required." ValidationGroup="RegisterUserValidationGroup" >*</asp:RequiredFieldValidator>--%>
                                                             <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"  ControlToValidate="Email" ErrorMessage="InvalidEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]w+)*\.\w+([-.]\w+)*" ValidationGroup="RegisterUserValidationGroup" >*</asp:RegularExpressionValidator>--%>
                                                         </div>
                                                    </div>
                                                    <div class="cntfrm_one">
                                                        <label><asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password *</asp:Label></label>
                                                         <div class="cntfrm_right"><asp:TextBox ID="Password" runat="server"  CssClass="validate[required] input_box2 small_box" TextMode="Password"></asp:TextBox>
                                                             <%--<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>--%>
                                                         </div>
                                                  </div>
                                                      <div class="cntfrm_one">
                                                        <label><asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password *</asp:Label></label>
                                                         <div class="cntfrm_right"><asp:TextBox ID="ConfirmPassword" runat="server"  CssClass="validate[required] input_box2 small_box" TextMode="Password"></asp:TextBox>
                                                            <%-- <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                                             <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>--%>
                                                        </div>
                                                     </div>
                                                      <div class="cntfrm_one">
                                                        <label><asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question *</asp:Label></label>
                                                         <div class="cntfrm_right"><asp:DropDownList ID="Question" runat="server" CssClass="validate[required] input_box2 select" style="min-width:254px; border:1px solid #999;">
                                                                <asp:ListItem>What is your mother&#39;s maiden name?</asp:ListItem>
                                                                <asp:ListItem>In what city were you born?</asp:ListItem>
                                                                <asp:ListItem>What is your favorite sport?</asp:ListItem>
                                                                <asp:ListItem>How much wood could a woodchuck chuck if a woodchuck could chuck wood?</asp:ListItem>
                                                             </asp:DropDownList> 
                                                             <%--<asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ErrorMessage="Security question is required." ToolTip="Security question is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>--%>
                                                         </div>
                                                     </div>
                                                     <div class="cntfrm_one">
                                                     <label><asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer *</asp:Label></label>
                                                         <div class="cntfrm_right"><asp:TextBox ID="Answer" runat="server" CssClass="validate[required] input_box2 small_box"></asp:TextBox>
                                                             <%--<asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ErrorMessage="Security answer is required." ToolTip="Security answer is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>--%>
                                                         </div>
                                                     </div>
                                                      
                                            </div> 
                                            
                                            <div class="regs_con1">
                                            
                                                      <div >
                                                      
                                                      <p><input type="checkbox" name="check1" id="check1" value="1"/>Do you accept with the terms and agreement  <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Orange" NavigateUrl="javascript:popup('Agreement.aspx')"> here </asp:HyperLink></p>
                                                      </div>
                                                    
                                            
                                            </div> 

                                           
                                           <div class="cntfrm_one">
                                            <asp:Button ID="CreateUserButton" OnClientClick="return checking();"  runat="server" CommandName="MoveNext" Text="Create User" ValidationGroup="RegisterUserValidationGroup" CssClass="creat_user"/>
                                            </div> 
                                              
                                        </fieldset>
                                    </div> 
                              </ContentTemplate>
                            <CustomNavigationTemplate>
                        </CustomNavigationTemplate>
                    </asp:CreateUserWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </ContentTemplate> 
  
   
</asp:Content>
 