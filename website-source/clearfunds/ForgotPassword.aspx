<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Member2.master" CodeFile="ForgotPassword.aspx.vb" Inherits="Account_PasswordRecovery" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">


</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 <h2 style="top:-33px;">
        Forget Your <br />Password?</h2>
         <asp:ValidationSummary ValidationGroup="ADDPRO1" DisplayMode="BulletList" ID="ValidationSummary1"
        runat="server" />
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
     
          
                    
              
              
        <QuestionTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Identity Confirmation</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    Answer the following question to receive your password.</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    User Name:</td>
                                <td>
                                    <asp:Literal ID="UserName" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Question:</td>
                                <td>
                                    <asp:Literal ID="Question" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Answer:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server" CssClass="input_box small_box text_size"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                        ControlToValidate="Answer" ErrorMessage="Answer is required." 
                                        ToolTip="Answer is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>

                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="SubmitButton" runat="server"  onclick="Submit_Click" Text="Submit" 
                                        ValidationGroup="PasswordRecovery1" />
                                                  <asp:Label  ForeColor="red" ID="lblumsg" Visible="false"  runat="server" ></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </QuestionTemplate>
        <UserNameTemplate>
        <div class="accountInfo">
        <div>
         <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                    <asp:RadioButton ID="RBEmail" runat="server" Checked="false" 
                        AutoPostBack="True" oncheckedchanged="RBEmail_CheckedChanged" GroupName="Select" />
               <asp:Label ID="Label10" runat="server" Text="User Name"></asp:Label>
                    <asp:RadioButton ID="RBUsername" runat="server" Checked="true" 
                        AutoPostBack="True" oncheckedchanged="RBUsename_CheckedChanged" GroupName="Select" />
              
                 
                        
                      </div>
                   
     <%--     <p>   Enter your User Name to receive your password.</p>--%>
             <fieldset class="login" style="margin-left:200px;">
           
                           
                            
                 <asp:Label ID="lblUsername" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                  <asp:TextBox ID="UserName" runat="server" CssClass="input_box2 small_box" style="width:180px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                         <asp:Label ID="lblemail" Visible="False" runat="server" Text="Email*"></asp:Label>
                  
                            <asp:TextBox ID="Email" Visible="false"  CssClass="input_box2 small_box" style="width:180px;" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email"
                            ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="ADDPRO1">*</asp:RequiredFieldValidator>
                                          <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                          <asp:Button ID="Submit" runat="server" CommandName="Submit" Text="Submit" 
                                        ValidationGroup="PasswordRecovery1" style="margin-left:200px;" />
                                         <asp:Button CssClass="submit_butt" BorderStyle="None" style="margin-right:22px;" 
                            ID="Submit1" runat="server"
                            ValidationGroup="ADDPRO1" Text="Submit" onclick="Submit1_Click" Visible="false" /><br />
                            <asp:Label ForeColor="red" ID="failtext" runat="server" Text=""></asp:Label>
                            <asp:Label ForeColor="green" ID="SuccessText" runat="server" Text=""></asp:Label>
                             <asp:Label  ForeColor="red" ID="lblmsg" runat="server" ></asp:Label>
                    


             </fieldset>
           </div>
        </UserNameTemplate>
    
    </asp:PasswordRecovery>
</asp:Content>