<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/Admin/Site.master" CodeFile="AddPlans.aspx.vb" Inherits="Admin_AddPlans" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress">
                <br />
                <asp:Image AlternateText="Loading progress" ImageUrl="~/Admin/Images/spinner3-bluey.gif"
                    ID="Image5" runat="server" />
                <asp:Label ID="Label543" runat="server" Text="Please Wait..."></asp:Label><br />
                <br />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <div class="plan_con">
      <h2>Add/Edit Packages</h2>
          <table style="width:100%;">
              <tr>
                  <td>
                      <asp:Label ID="Label1" runat="server" Text="Add a New  Invesment Package :"></asp:Label>
                  </td>
              </tr>
          </table>
           
       
      <br />
      <table class="pack_top1">
          <tr>
              <td>

                  <asp:Label ID="Label2" runat="server" Text="Package Name"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtPackName" runat="server" CssClass="validate[required] inputbox smallbox"></asp:TextBox>
                  
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label3" runat="server" Text="Package Duration" ></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtPackDuration" runat="server" CssClass="validate[required] inputbox smallbox"></asp:TextBox>
                  Days/Hours<asp:CheckBox ID="chkLimit" runat="server" Text="No Limit"  CssClass ="input, textarea " />
              </td>
          </tr>
      </table>
      <br />
      <table class="pack_top1">
          <tr>
              <td>
                  <asp:Label ID="Label4" runat="server" Text="Specify the Rates:"></asp:Label>
              </td>
          </tr>
      </table>

      
        <table class="pack_top4"><tr>
        <td align ="center" ><asp:Label ID="Label5" runat="server" Text="#" ></asp:Label></td> 
        <td><asp:Panel ID="Panel1" runat="server">
        <table><tr>
                  <td align ="center"><asp:Label ID="Label6" runat="server" Text="Name" CssClass="label_size"></asp:Label></td> 
                  <td><asp:Label ID="Label7" runat="server" Text="Min Amount" CssClass="label_size"></asp:Label></td> 

                  <td><asp:Label ID="Label8" runat="server" Text="Max Amount" CssClass="label_size"></asp:Label></td>
                  <td><asp:Label ID="Label9" runat="server" Text="Percent" CssClass="label_size"></asp:Label></td> 
         </tr></table> 
         </asp:Panel></td> 
         </tr></table>
         <table class="pack_top4"><tr>
        <td><asp:CheckBox runat="server" Text="1" TextAlign="Left" ID="chkPlan1" AutoPostBack="True" CssClass="validate[required] " /></td> 
        <td><asp:Panel ID="Panel2" runat="server" Enabled="false" >
        <table><tr>
                  <td><asp:TextBox ID="txtPlan1" runat="server" CssClass =" inputbox smallbox"></asp:TextBox>
                  <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlan1" ErrorMessage="Plan is required" >Plan is required</asp:RequiredFieldValidator> </td> 
                
                  <td><asp:TextBox ID="txtPmin1" runat="server" onkeypress="return numbersonly(event)" CssClass ="inputbox smallbox"></asp:TextBox><asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPmin1" ErrorMessage="Min Amount is required ">Min Amount is required </asp:RequiredFieldValidator></td> 
                 
                  <td><asp:TextBox ID="txtPmax1" runat="server" onkeypress="return numbersonly(event)" CssClass ="inputbox smallbox"></asp:TextBox><asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPmax1" ErrorMessage="Max Amountl is required" >Max Amountl is required</asp:RequiredFieldValidator></td>
                
                  <td><asp:TextBox ID="txtPpercent1" runat="server" onkeypress="return numbersonly(event)" CssClass ="inputbox smallbox"></asp:TextBox><asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPpercent1" ErrorMessage="Percent is required" >Percent is required</asp:RequiredFieldValidator></td> 
                </tr></table> 
         </asp:Panel></td> 
         </tr></table>
        
        <table class="pack_top4"><tr>
        <td> <asp:CheckBox runat="server" Text="2" TextAlign="Left" ID="chkPlan2" AutoPostBack="True"  CssClass ="input, textarea "/></td> 
        <td><asp:Panel ID="Panel3" runat="server" Enabled="false">
        <table><tr>
                  <td><asp:TextBox ID="txtPlan2" runat="server"  CssClass ="inputbox smallbox"></asp:TextBox></td> 
                  <td><asp:TextBox ID="txtPmin2" runat="server"   onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td> 
                  <td><asp:TextBox ID="txtPmax2" runat="server"  onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtPpercent2" runat="server"  onkeypress="return numbersonly(event)"   CssClass ="inputbox smallbox"></asp:TextBox></td> 
         </tr></table> 
         </asp:Panel></td> 
         </tr></table>

        <table class="pack_top4"><tr>
        <td> <asp:CheckBox runat="server" Text="3" TextAlign="Left" ID="chkPlan3" AutoPostBack="True" CssClass ="input, textarea " /></td> 
        <td><asp:Panel ID="Panel4" runat="server" Enabled="false">
        <table><tr>
                  <td><asp:TextBox ID="txtPlan3" runat="server" CssClass ="inputbox smallbox"></asp:TextBox></td> 
                  <td><asp:TextBox ID="txtPmin3" runat="server"  onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td> 
                  <td><asp:TextBox ID="txtPmax3" runat="server"   onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtPpercent3" runat="server"  onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td> 
         </tr></table> 
         </asp:Panel></td> 
         </tr></table>

        <table class="pack_top4"><tr>
        <td><asp:CheckBox runat="server" Text="4" TextAlign="Left" ID="chkPlan4" AutoPostBack="True" CssClass ="input, textarea " /></td> 
        <td><asp:Panel ID="Panel5" runat="server" Enabled="false">
        <table><tr>
                  <td><asp:TextBox ID="txtPlan4" runat="server" CssClass ="inputbox smallbox"></asp:TextBox></td> 
                  <td><asp:TextBox ID="txtPmin4" runat="server"  onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td> 
                  <td><asp:TextBox ID="txtPmax4" runat="server"  onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtPpercent4" runat="server"  onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td> 
         </tr></table> 
         </asp:Panel></td> 
         </tr></table>

        <table class="pack_top4"><tr>
        <td><asp:CheckBox runat="server" Text="5" TextAlign="Left" ID="chkPlan5" AutoPostBack="True"  CssClass ="input, textarea "/></td> 
        <td><asp:Panel ID="Panel6" Enabled="false" runat="server">
        <table><tr>
                  <td> <asp:TextBox ID="txtPlan5" runat="server" CssClass ="inputbox smallbox"></asp:TextBox></td> 
                  <td><asp:TextBox ID="txtPmin5" runat="server"  onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td> 
                  <td><asp:TextBox ID="txtPmax5" runat="server"  onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td>
                  <td><asp:TextBox ID="txtPpercent5" runat="server"  onkeypress="return numbersonly(event)"  CssClass ="inputbox smallbox"></asp:TextBox></td> 
         </tr></table> 
         </asp:Panel></td> 
         </tr></table>
                  
      <br />
      <table class="pack_top4">
          <tr>
              <td>
                  <asp:Label ID="Label10" runat="server" Text="Description:"></asp:Label>
              </td>
          </tr>
          <tr><td> <asp:TextBox ID="Description" runat="server" Height="166px" TextMode="MultiLine" 
                      Width="600px" CssClass ="adp_textarea " ></asp:TextBox>
             
                  *</td></tr>
      </table>
      <br />
     
      <br />
      <table  class="pack_top1">
          <tr>
              <td>

                  <asp:Label ID="Label11" runat="server" Text="Payment period:"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="cmb1paymentperiod"   runat="server">
                    
                      <asp:ListItem>Daily</asp:ListItem>
                      <asp:ListItem>Weekly</asp:ListItem>
                       <asp:ListItem>Bi-Weekly</asp:ListItem>
                       <asp:ListItem>Monthly</asp:ListItem>
                         <asp:ListItem>Every 2 Month</asp:ListItem>
                            <asp:ListItem>Every 3 Month</asp:ListItem>
                               <asp:ListItem>Every 6 Month</asp:ListItem>
                                  <asp:ListItem>Yearly</asp:ListItem>
                                     <asp:ListItem>Hourly</asp:ListItem>
                                        <asp:ListItem>After the specified period</asp:ListItem>
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td>
                  
                  <asp:Label ID="Label12" runat="server" Text="Status"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="cmb2Status" runat="server" >
                      <asp:ListItem>Active</asp:ListItem>
                      <asp:ListItem>InActive</asp:ListItem>
                  </asp:DropDownList>
              </td>
          </tr>
      </table>
      <br />
      <table  class="pack_top4">
          <tr><td>
                  <asp:CheckBox ID="ChkRetPrincipal" runat="server" Text="1" TextAlign="Left" 
                      AutoPostBack="True"  CssClass ="input, textarea "/>
                  <asp:Label ID="Label13" runat="server" 
                      Text="Return principal after the plan completion. And earn_hold_days"></asp:Label>
             <asp:TextBox ID="txtRPHolddays" runat="server" Width="37px" CssClass ="inputbox minbox"></asp:TextBox>
                  <asp:Label ID="Label14" runat="server" Text="%"></asp:Label></td></tr>
           
      </table>
      <br />
       <table  class="pack_top4">
             <tr><td>
                               <asp:CheckBox ID="ChkCompounding" runat="server" Text="1" TextAlign="Left" 
                      AutoPostBack="True" CssClass ="input, textarea " />
                  <asp:Label ID="Label15" runat="server" Text="Use compounding"></asp:Label></td></tr>
             
      </table>
      <br />
      <table  class="pack_top1">
         <tr><td>                  <asp:Label ID="Label16" runat="server" 
                      Text=" Compounding deposit amount limits:"></asp:Label>
             
                  <asp:Label ID="Label17" runat="server" Text="min:  "></asp:Label>
              
                  <asp:TextBox ID="CompDepositMinLimit" runat="server" Width="37px" 
                 CssClass ="inputbox minbox " Enabled="False">0</asp:TextBox>

                  <asp:Label ID="Label18" runat="server" Text="max:  "></asp:Label>
                  <asp:TextBox ID="CompDepositMaxLimit" runat="server" Width="37px" 
                 CssClass ="inputbox minbox " Enabled="False">0</asp:TextBox>
                  <br />

                  <asp:Label ID="Label19" runat="server" Text="set 0 as max to skip limitation"></asp:Label>
            </td></tr>
      </table>
      <br />
      <table  class="pack_top1">
         
         <tr><td>
                  <asp:Label ID="Label20" runat="server" Text="  Compounding percent limits:"></asp:Label>
              
                  <asp:Label ID="Label21" runat="server" Text="min:  "></asp:Label>
             
                  <asp:TextBox ID="CompPercentMinLimit" runat="server" Width="37px" 
                      CssClass ="inputbox minbox" Enabled="False">0</asp:TextBox>

                  <asp:Label ID="Label22" runat="server" Text="max:  "></asp:Label>
                  <asp:TextBox ID="CompPercentMaxLimit" runat="server" Width="37px" 
                      CssClass ="inputbox minbox" Enabled="False">100</asp:TextBox>
                  </td>
             </tr>
     </table>
      <br />
       <table  class="pack_top1">
         <tr><td>
                  <asp:CheckBox runat="server" TextAlign="Left" ID="chkallowwithdraw" 
                      AutoPostBack="True" oncheckedchanged="Unnamed6_CheckedChanged"  CssClass ="input, textarea " />
                  <asp:Label ID="Label23" runat="server" Text="Allow principal withdrawal."></asp:Label>
     </td>   </tr>
     </table>
      <br />
      <table class="pack_top1" >
          <tr>
              <td>
                  <asp:Label ID="Label24" runat="server" Text=" The principal withdrawal fee:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtwithdrawFee" runat="server" Width="212px" Enabled="False" CssClass ="inputbox smallbox">10.00</asp:TextBox>
                  <asp:Label ID="Label27" runat="server" Text="%"></asp:Label>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label25" runat="server" 
                      Text="  Enter the minimal deposit withdrawal duration:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtminWDduration" runat="server" Width="210px" Enabled="False" CssClass ="inputbox smallbox">20</asp:TextBox>
                  <asp:Label ID="Label28" runat="server" Text="%"></asp:Label>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label26" runat="server" 
                      Text="  Enter the maximal deposit withdrawal duration:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtmaxWDduration" runat="server" Width="213px" Enabled="False" CssClass ="inputbox smallbox">0</asp:TextBox>
                  <asp:Label ID="Label29" runat="server" Text="%"></asp:Label>
                  <br />
                  <asp:Label ID="Label30" runat="server" Text="set 0 as max to skip limitation"></asp:Label>
              </td>
          </tr>
      </table>
      <br />
     <table class="pack_top1" >
          <tr><td>
                  <asp:CheckBox ID="chkAllowEarnings" runat="server" TextAlign="Left" 
                      AutoPostBack="True" CssClass ="input, textarea " />
                  <asp:Label ID="Label31" runat="server" Text=" Earnings only on mon-fri"></asp:Label></td>
           </tr>
     </table>
      <br />
      <table class="pack_top1" >
          <tr><td>
                  <asp:CheckBox ID="chkAllowDeposit" runat="server" TextAlign="Left" 
                      AutoPostBack="True" CssClass ="input, textarea " />
                  <asp:Label ID="Label32" runat="server" 
                      Text="Allow depositing only after the user has deposited to the following package: "></asp:Label>
             
                  <asp:DropDownList ID="cmbDepositPack" AutoPostBack="true" runat="server" 
                       Width="111px">
                      <asp:ListItem>Select</asp:ListItem>
                      <asp:ListItem>1 Year 2.4% daily</asp:ListItem>
                      <asp:ListItem>100 days 3.4% daily </asp:ListItem>
                      <asp:ListItem>30 days deposit.150%</asp:ListItem>
                  </asp:DropDownList></td>
             </tr>
      </table>
      <br />
      <br />
       <table class="pack_top1" >
          <tr>
                  <td><asp:Label ID="Label33" runat="server" Text="Hold earnings at account forx"></asp:Label>
           <asp:TextBox ID="txtHoldEarnings" runat="server" Width="37px" CssClass ="inputbox minbox  ">0</asp:TextBox>
                  <asp:Label ID="Label34" runat="server" 
                      Text="days after payout (set 0 for disable this feature)"></asp:Label></td>
             </tr>
    </table>
      <br />
      <br />
       <table class="pack_top1" >
          <tr><td>
                            <asp:Label ID="Label35" runat="server" Text="Delay earning for"></asp:Label>
              <asp:TextBox ID="txtDelayEarnings" runat="server" Width="37px" CssClass ="inputbox minbox ">0</asp:TextBox>
                  <asp:Label ID="Label36" runat="server" 
                      Text="days since deposit (set 0 for disable this feature)"></asp:Label></td></tr>
            
    </table>
      <br />
      
      <br />
      <br />
      <table class="pack_top4">
      <tr>
     
  
      <td></td>
      <td>
            <asp:Button ID="btnAddPackage" runat="server" Text="Add Package"  CssClass =" btnalt " />
               <%-- <asp:LinkButton ID="LinkButton1" OnClick="cmdCancel_Click"  runat="server">Cancel</asp:LinkButton>--%>
           <%--  <asp:Button ID="cmdCancel" runat="server" Text="Cancel"  OnClick="cmdCancel_Click" CssClass =" btnalt "  />--%>
          <asp:HyperLink ID="HyperLink1" NavigateUrl="Packages.aspx"  CssClass =" btnalt " runat="server">Cancel</asp:HyperLink>
             <asp:Label ID="lblid" runat="server" Visible="false" Text="Label"></asp:Label>
            </td> 
           
            </tr> 
            </table> 
             </div>
      <br />
      </ContentTemplate>
     </asp:UpdatePanel> 
     </asp:Content>