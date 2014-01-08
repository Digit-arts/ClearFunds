<%@ Page Language="VB" AutoEventWireup="false"   MasterPageFile="~/AccountMaster.master"   CodeFile="Profile.aspx.vb" Inherits="Profile" %>
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

  
   

  
</asp:Content>

     <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     
         <h2 style="left:355px;"> PROFILE</h2>
        
   <asp:UpdatePanel ID ="UpdatePanel" runat ="server" >
   <ContentTemplate >
    <span class="failureNotification"><asp:Literal ID="ErrorMessage" runat="server"></asp:Literal></span>
    

        
        
         <div class="acc_table">            
            
            <h3 class="acc_heading"><span class="cap">Account Info:</span></h3>
            <div class="ac_cont_tab">
               
                   <div class="ediprof_one">
                   
                        <label class="style4"><asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label></label>
                       <div class="pinfo_rit  "><asp:Label ID="UserName" runat="server"></asp:Label></div>
                   </div>

                   <div class="ediprof_one">
                        <label class="style4"><asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></label>
                       <div class="pinfo_rit  "><asp:Label ID="Email" runat="server"></asp:Label></div>
                   </div>
                   <div class="ediprof_one">
                        <label class="style4"><asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label></label>
                       <div class="pinfo_rit" style="background:none;" ><asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Account/ChangePassword.aspx">ResetPassword</asp:LinkButton></div>
                   </div>
             
               </div>
         
                <div class="ac_cont_tab">
                    <div class="act_tab_table">
                      <h4 class="acc_heading"><span  class="cap">Personal Info:</span></h4>
                        <div class="ediprof_one"><label class="style4"><asp:Label ID="Label2" runat="server" Text="Full Name"></asp:Label></label>
                            <div class="pinfo_rit"><asp:Label ID="cmbsaluation" runat="server"></asp:Label>
                                <asp:Label ID="txtFirstName" runat="server"></asp:Label>
                                <asp:Label ID="txtLastName" runat="server"></asp:Label>
                                </div> 
                        </div>
                                <div class="ediprof_one">
                                <label class="style4"><asp:Label ID="lbldob" runat="server" Text="Date Of Birth"></asp:Label></label>
                            <div class="pinfo_rit  "><asp:Label ID="txtdob" runat="server"></asp:Label></div>
                        </div>
                        <div class="ediprof_one">
                            <label  style="vertical-align:top;" class="style4"><asp:Label ID="lblAddressLine1" runat="server" Text="Address"></asp:Label></label>
                            <div class="pinfo_rit  "><asp:Label ID="txtAddressLine1" runat="server"></asp:Label>
                                <asp:Label ID="txtAddressLine2" runat="server"></asp:Label>
                           
                            </div>
                            </div>
                             <div class="ediprof_one">
                                 <label  style="vertical-align:top;" class="style4"><asp:Label ID="Label5" runat="server" Text="Region"></asp:Label></label>
                                 <div class="pinfo_rit  "><asp:Label ID="txtRegion" runat="server"></asp:Label></div>
                      
                            </div>

                        <div class="ediprof_one">
                        <label  style="vertical-align:top;" class="style4"><asp:Label ID="Label4" runat="server" Text="Country"></asp:Label></label>
                        <div class="pinfo_rit  "> <asp:Label ID="cmbcountry" runat="server"></asp:Label></div>
                      
                      </div>
                       <div class="ediprof_one">
                       <label  style="vertical-align:top;" class="style4"><asp:Label ID="Label6" runat="server" Text="State"></asp:Label></label>
                       <div class="pinfo_rit  ">    <asp:Label ID="txtstate" runat="server"></asp:Label></div>
                      
                      </div>
                        
                      <div class="ediprof_one">
                      <label  style="vertical-align:top;" class="style4"><asp:Label ID="Label1" runat="server" Text="City"></asp:Label></label>
                       <div class="pinfo_rit  ">  <asp:Label ID="txtCity" runat="server"></asp:Label></div>
                      
                     </div>
                       <div class="ediprof_one"> 
                       <label  style="vertical-align:top;" class="style4"><asp:Label ID="Label3" runat="server" Text="Zip"></asp:Label></label>
                       <div class="pinfo_rit  ">     <asp:Label ID="txtPostelCode" runat="server"> </asp:Label></td>
                      
                      </div>
                       <div class="ediprof_one">
                            <label class="style4"><asp:Label ID="lblHomePhone" runat="server"  Text="Home Phone"></asp:Label></label>
                            <div class="pinfo_rit  "><asp:Label ID="txtHomephoneCode" runat="server"></asp:Label>
                                <asp:Label ID="txtHomePhone" runat="server"></asp:Label>
                            </div>
                            <div class="ediprof_one">
                                <label class="style4">
                                    <asp:Label ID="lblOccupation" runat="server" Text="Occupation"></asp:Label>
                                </label>
                                <div class="pinfo_rit  ">
                                    <asp:Label ID="cmbOccupation" runat="server"></asp:Label>
                                </div>
                            </div>
                       </div>
                        
                    </div>
                    </div>
                
               
                <div class="ac_cont_tab">
                    <div class="acc_table">
                     <h5 class="acc_heading"><span  class="cap">Payment Info:</span> </h5>
                          <div class="ediprof_one">  
                                <label><asp:Label ID="lblAccountType" runat="server"  Text="Account Type"></asp:Label></label>
                                <div class="pinfo_rit  "><asp:Label ID="cmbPaymentType" runat="server"></asp:Label></div>
                          </div>
                         <%-- <tr>  <td class="style9"  style="float:left;"><asp:Label ID="lblAccountEmailId" runat="server" Text="AccountEmailId"></asp:Label></td>
                                <td  style="float:left;"><asp:Label ID="txtAccEmailId" runat="server"></asp:Label></td>
                          </tr>--%>
                           <div class="ediprof_one">   
                                <label><asp:Label ID="lblThirdParty" runat="server" Text="Third Party" 
                                    Visible="False"></asp:Label></label>
                                <div class="pinfo_rit  "><asp:RadioButton ID="radioyes"   GroupName="ThirdParty"  
                                        Text="Yes" runat="server" Checked="true"  CssClass="prof_radio" 
                                        Visible="False"/>
                                <asp:RadioButton ID="radioNo" Text="No" GroupName="ThirdParty"   runat="server" 
                                        Visible="False" /></div>
                          </div>
                    </div>
                    <div class="acc_table">
                    <div id="divtb"  runat="server">
                    
                    
                    </div>
                    </div>
                    </div >
                      <div class="submitButton"><asp:Button ID="CmdEdit" class="cntbtn" runat="server" OnClick="Modify_Click" Text="Edit" /></div>
                  <div class="clear" style="padding:0px; "></div>
                </div>
           
           
            
       
         </div>   
           </ContentTemplate>
   </asp:UpdatePanel>
       
</asp:Content>
 