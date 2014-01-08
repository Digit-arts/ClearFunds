<%@ Page Language="VB" AutoEventWireup="false"    MasterPageFile="~/AccountMaster.master"   CodeFile="EditProfile.aspx.vb" Inherits="Account_Profile" %>
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
    // Now the Ajax CAPTCHA validation checkcode(document.myform.code.value); return false;
  

    </script>
      <link href="../css/template.css" rel="stylesheet" type="text/css" />
<link href="../css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery-1.6.3.min.js" type="text/javascript"></script>
<script src="../js/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
<script src="../js/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery("#form1").validationEngine();
    });
</script>
  
</asp:Content>
    <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h2>Edit profile</h2>
   
        

    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
    <asp:ValidationSummary ID="RegisterUserValidationSummary"   ShowSummary="false" ShowMessageBox="true" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
        <asp:Label ID="lblprofile" runat="server"  ForeColor="Red" Visible="false" Text="please complete your profile"></asp:Label>
    <div class="cen_cont ed_prote">
    <h3><span class="cap">Account Info:</span></h3>
    <div class="acc_table">
    
  
        <div class="editprof_main">
      
            <div class="ediprof_one">
             
                <label class="style2">
                    <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                    </label>
                
                    <div class="ediprof_right ">
                    <asp:TextBox ID="UserName" Enabled="false" Width="300" runat="server"  CssClass="o_textbox textEntry input_box2 small_box text_size" ></asp:TextBox>
                   </div>
                    
            </div>
               <div class="ediprof_one">
                <label class="style2">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></label>
                <div class="ediprof_right ">
                    <asp:TextBox ID="Email" runat="server" 
                        CssClass="validate[required,custom[email] input_box2 small_box  " 
                        Width="300px"></asp:TextBox>
                </div>
                  
            </div>
             <div class="ediprof_one">
                <label class="style2">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label></label>
                <div class="ediprof_right">
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        PostBackUrl="~/Account/ChangePassword.aspx" Font-Size="Medium">ResetPassword</asp:LinkButton></div>
            </div>
        

            </div>

           
           
        
            
               <h3><span class="cap"> Personal Info:</span></h3>
         
            <div class="editprof_main">             
            <div class="ediprof_one">
                    <label>
                          <asp:Label ID="Label2" runat="server" Text="Salutation"></asp:Label>
                          
                            <asp:Label ID="Label15" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                    </label>                          
                     <div class="ediprof_right ">
                            <asp:DropDownList ID="cmbsaluation" runat="server" Width="70px" Height="35px" CssClass="validate[required] radio input_box2 small_box "  style="padding:5px;">
                            <asp:ListItem Value="" Selected="True" text="Choose Saluation"/>
                            <asp:ListItem Value="Mr"  Text="Mr" />
                            <asp:ListItem Value="Mrs" Text="Mrs" />
                                       
                             </asp:DropDownList>
                             <%--<asp:RequiredFieldValidator ID="cmbsaluationRequired" ControlToValidate="cmbsaluation" runat="server" ValidationGroup="RegisterUserValidationGroup"  ErrorMessage="Saluation is required" ToolTip="Saluation Name is required.">*</asp:RequiredFieldValidator>--%>
                                       
                       </div>
                       </div>

                            <div class="ediprof_one">
                           <label>
                               <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>    
                               
                            <asp:Label ID="Label14" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                           </label>
                           <div class="ediprof_right ">
                                     <asp:TextBox ID="txtFirstName" runat="server" onkeypress="return validateText(event)" Width="300px" CssClass="validate[required] o_textbox textEntry input_box2 small_box text_size "></asp:TextBox>
                                     
                                      <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="txtFirstName" runat="server"  ValidationExpression="^[a-zA-Z]{2,128}$" ValidationGroup="RegisterUserValidationGroup" ErrorMessage="Invalid Name">*</asp:RegularExpressionValidator>--%> 
                         </div>
                           </div>

                              <div class="ediprof_one">
                              <label>
                                         <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                                         
                            <asp:Label ID="Label13" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                              </label>
                              <div class="ediprof_right ">
                                          <asp:TextBox ID="txtLastName" runat="server"  onkeypress="return validateText(event)" Width="300px"  CssClass="validate[required] o_textbox textEntry input_box2 small_box text_size "></asp:TextBox>
                                    
                                     <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="InavlaidName" ValidationExpression="^[a-zA-Z]{2,128}$" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>--%>
                               </div>

                               </div>



                       <div class="ediprof_one">
                        <label>
                                  <asp:Label ID="lblRegion" runat="server" Text="Region"></asp:Label>
                                  
                            <asp:Label ID="Label12" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                        </label>
                                  <div class="ediprof_right ">
                                  <asp:TextBox ID="txtRegion"  onkeypress="return validateText(event)" runat="server" Width="300px"  CssClass="validate[required] o_textbox textEntry input_box2 small_box text_size "></asp:TextBox>
                                      <%--<asp:RequiredFieldValidator ID="regionrequired" ControlToValidate="txtRegion"  ValidationGroup="RegisterUserValidationGroup"  ToolTip="Region is required." Display="Dynamic" ErrorMessage="Region is required"  runat="server" >*</asp:RequiredFieldValidator>--%>
                                  </div>

                      
                </div>
            
                           <div class="ediprof_one">
                                 <label>
                                      <asp:Label ID="lblPostelCode" runat="server" Text="Postal Code"></asp:Label>
                                  
                                        <asp:Label ID="Label11" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                                 </label>
                                  <div class="ediprof_right ">
                                  <asp:TextBox ID="txtPostelCode" onkeypress="return numbersonly(event)" runat="server" Width="300px" CssClass="validate[required] o_textbox textEntry input_box2 small_box text_size "></asp:TextBox>
                                      <%--<asp:RequiredFieldValidator ID="postalcoderequired"  ControlToValidate="txtPostelCode" ValidationGroup="RegisterUserValidationGroup"  ToolTip="PostelCode is required." Display="Dynamic" ErrorMessage="PostalCode is required"  runat="server" >*</asp:RequiredFieldValidator>--%>
                                      <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  ControlToValidate="txtPostelCode" ErrorMessage="Allows 6 digit pin code" ValidationExpression="^(\d{6})$" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>--%>
                                  </div>
                                 


                  </div>

                
                               <div class="ediprof_one">
                                <label>
                                  <asp:Label ID="lblCountry" runat="server"  Text="Country"></asp:Label>
                                  
                            <asp:Label ID="Label10" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                                  </label>
                                  <div class="ediprof_right ">
                                      <asp:DropDownList ID="cmbcountry"    Width="300px" Height="35px" runat="server" AutoPostBack="true"  CssClass="validate[required] radio  input_box2 small_box"  style="padding:5px;">
                                       </asp:DropDownList>   
                             
                                      <%--<asp:RequiredFieldValidator ID="countryRequired" ControlToValidate="cmbcountry" runat="server" ValidationGroup="RegisterUserValidationGroup"  ToolTip="Country is required." Display="Dynamic" ErrorMessage="Country is required" >*</asp:RequiredFieldValidator>--%>
                                  </div>


                     </div>
                <caption>
                   
                    <div class="ediprof_one">
                         <label>
                            <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone"></asp:Label>
                            
                            <asp:Label ID="Label9" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                      </label>
                        <div class="ediprof_right ">
                            <%--<asp:DropDownList Width="70px" ID="cmbHomePhone" runat="server">
                                   </asp:DropDownList>--%>
                            <asp:TextBox ID="txtHomephoneCode" runat="server" 
                                CssClass="validate[required] input_box2 small_box " Enabled="False" 
                                Width="38px"></asp:TextBox>
                            <asp:TextBox ID="txtHomePhone" runat="server" 
                                CssClass=" validate[required] o_textbox textEntry input_box2 small_box text_size" 
                                onkeypress="return numbersonly(event)" Width="250px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="txtHomePhoneRequired"  ValidationGroup="RegisterUserValidationGroup"  ToolTip="HomePhone is required." Display="Dynamic" ErrorMessage="HomePhone is required" ControlToValidate="txtHomePhone" runat="server" >*</asp:RequiredFieldValidator>--%>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtHomePhone" ErrorMessage="Allows phone number of the format: NPA = [2-9][0-8][0-9] Nxx = [2-9][0-9][0-9] Station = [0-9][0-9][0-9][0-9]" ValidationExpression="^[0-9-)(\.,\s]{2,128}$" ValidationGroup="RegisterUserValidationGroup">*</asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div class="ediprof_one">
                        <label>
                            <asp:Label ID="lblAddressLine1" runat="server" Text="Address Line 1"></asp:Label>
                            
                            <asp:Label ID="Label8" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                      </label>
                        <div class="ediprof_right ">
                            <asp:TextBox ID="txtAddressLine1" runat="server" 
                                CssClass="validate[required] o_textbox textEntry input_box2 small_box text_size" 
                                Width="300"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="txtAddressline1Required"   ControlToValidate="txtAddressLine1" runat="server"  ValidationGroup="RegisterUserValidationGroup"  ToolTip="Address is required." Display="Dynamic" ErrorMessage="Address is required" >*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="ediprof_one">
                         <label>
                            <asp:Label ID="lblAddressLine2" runat="server" Text="Address Line 2"></asp:Label>
                         </label>
                        <div class="ediprof_right ">
                            <asp:TextBox ID="txtAddressLine2" runat="server" 
                                CssClass="o_textbox textEntry input_box2 small_box text_size" Width="300px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="ediprof_one">
                         <label>
                            <asp:Label ID="lblOccupation" runat="server" Text="Occupation"></asp:Label>
                            <asp:Label ID="Label7" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                         </label>
                        <div class="ediprof_right ">
                            <asp:DropDownList ID="cmbOccupation" runat="server" 
                                CssClass="validate[required] radio input_box2 small_box " Height="35px" 
                                style="padding:5px;" Width="300px">
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="cmbOccupation" runat="server"   ToolTip="Occupation is required." 
                                     ValidationGroup="RegisterUserValidationGroup" Display="Dynamic" ErrorMessage="Occupation is required">*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="ediprof_one">
                         <label>
                            <asp:Label ID="Label1" runat="server" Text="State"></asp:Label>
                            <asp:Label ID="Label6" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                         </label>
                        <div class="ediprof_right ">
                            <asp:TextBox ID="txtstate" runat="server" 
                                CssClass="validate[required] o_textbox textEntry input_box2 small_box text_size " 
                                onkeypress="return validateText(event)" Width="300px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="txtcityRequired" ControlToValidate="txtCity"  ValidationGroup="RegisterUserValidationGroup"  ToolTip="City is required." Display="Dynamic" ErrorMessage="City is required"  runat="server" >*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>

                    <div class="ediprof_one">
                         <label>
                            <asp:Label ID="lblcity" runat="server" Text="City"></asp:Label>
                            <asp:Label ID="Label5" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                         </label>
                        <div class="ediprof_right ">
                            <asp:TextBox ID="txtCity" runat="server" 
                                CssClass="validate[required] o_textbox textEntry input_box2 small_box text_size " 
                                onkeypress="return validateText(event)" Width="300px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="txtcityRequired" ControlToValidate="txtCity"  ValidationGroup="RegisterUserValidationGroup"  ToolTip="City is required." Display="Dynamic" ErrorMessage="City is required"  runat="server" >*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="ediprof_one">
                         <label>
                            <asp:Label ID="lbldob" runat="server" Text="Date Of Birth"></asp:Label>
                            <asp:Label ID="Label4" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                         </label>
                        <div class="ediprof_right ">
                            <asp:TextBox ID="txtdob" runat="server" 
                                CssClass="validate[required] o_textbox textEntry input_box2 small_box text_size  "></asp:TextBox>
                         <asp:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="txtdob" >
    </asp:CalendarExtender>
                            <%--<asp:RequiredFieldValidator ID="dobRequired" runat="server"   ControlToValidate="txtdob" ErrorMessage="DateOfBirth is Required" ToolTip="DateOfBirth is required."  ValidationGroup="RegisterUserValidationGroup"  CssClass="failureNotification"  Display="Dynamic">*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </caption>
                          </div>
                        
                     
                         <br />
                          <h3><span class="cap">Payment Info:</h3></span>
                          
                          
                          <div class="editprof_main">
                          
                          <div class="ediprof_one">
                          <label>
                               
                              <asp:Label ID="lblAccountType" runat="server"  Text="Account Type"></asp:Label>
                          <asp:Label ID="Label3" runat="server"  Text="*" Font-Size="Large" ForeColor="Red"  ></asp:Label> 
                          </label>
                          <div class="ediprof_right ">
                              <asp:DropDownList ID="cmbPaymentType" Width="300px" Height="35px" runat="server" AutoPostBack="true"  CssClass="validate[required] radio input_box2 small_box " style="padding:5px;">
                              
                              </asp:DropDownList>
                         
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"    
                                  ValidationGroup="RegisterUserValidationGroup" 
                                  ControlToValidate="cmbPaymentType" ErrorMessage="PaymentType is Required" 
                                  ToolTip="PaymentType is required."   CssClass="failureNotification"  
                                  Display="Dynamic"></asp:RequiredFieldValidator>
                          
                          </div>
                          
                          </div>
                             
                        <%--  <div class="ediprof_one">
                          <td>
                              <asp:Label ID="lblAccountEmailId" runat="server" Text="AccountEmailId"></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="txtAccEmailId" runat="server" CssClass="validate[required,custom[email] o_textbox textEntry input_box2 small_box text_size "></asp:TextBox>
                              <asp:RequiredFieldValidator ID="accemailidrequired" runat="server" ControlToValidate="txtAccEmailId" 
                                     CssClass="failureNotification"  Display="Dynamic" ErrorMessage="Email is required" ToolTip="E-mail is required." 
                                     ValidationGroup="RegisterUserValidationGroup" >*</asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"  ControlToValidate="txtAccEmailId" ErrorMessage="InvalidEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]w+)*\.\w+([-.]\w+)*" ValidationGroup="RegisterUserValidationGroup" >*</asp:RegularExpressionValidator>
                          
                          </td>
                          </div>--%>
                              
                         
                          
                          </div>

                          <div  id="divtb" runat="server">
                          
                       
                          </div>

     </div>
     
                       <table width="100%">
                       <div class="ediprof_one"><td>
                              <asp:Label ID="lblThirdParty" runat="server" Text="Third Party" Visible="False"></asp:Label>
                              </td>
                              <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server"  
                                      RepeatDirection="Horizontal" Visible="False" >
                                
                                 <asp:ListItem Text ="Yes" Value ="1" Selected="True" ></asp:ListItem>
                               
                                <asp:ListItem Text ="No" Value ="0" ></asp:ListItem>
                               
    </asp:RadioButtonList></td> </div> </table> 
                          
                        <%--
                              <asp:RadioButton ID="radioyes"   GroupName="ThirdParty"  Text="Yes" runat="server" Checked="true" />
                   &nbsp;&nbsp;<asp:RadioButton ID="radioNo" Text="No" GroupName="ThirdParty"   runat="server" />--%>
                           
              
                             <div class="submitButton"> <asp:Button ID="Button1" runat="server"   ValidationGroup="RegisterUserValidationGroup" Text="Update"  style="font-size:12px !important; padding-bottom:2px; "/></div>
                               <asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="Green" Text="Updated SuccessFully"></asp:Label>
    
    
     
     <div class="clear"></div>
        </div>
   
   

   
    
</asp:Content>
 