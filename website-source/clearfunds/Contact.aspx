<%@ Page Title="About Us" Language="VB"  MasterPageFile="~/ContentMaster.master"   AutoEventWireup="false"
    CodeFile="Contact.aspx.vb" Inherits="About" %>

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

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 <div class="abtus_cnt">
   
     <asp:Label ID="Label12" runat="server" Text=""></asp:Label>

</div>

<div class="cntfrm_main">
    
    <div class="cntfrm_one">
        <label>Firstname </label>
        <div class="cntfrm_right">
              <asp:TextBox ID="txtfirstname" runat="server"  
                     CssClass="validate[required] inputbox smallbox" style="background:#fff;"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                     ErrorMessage="Name Required" ControlToValidate="txtfirstname" 
                     ValidationGroup="a"></asp:RequiredFieldValidator>
        
        
        </div>
    
    </div>
    <div class="cntfrm_one">
        <label>Lastname</label>
        <div class="cntfrm_right">
                 <asp:TextBox ID="txtlastname" runat="server"  
                     CssClass="validate[required] inputbox smallbox" style="background:#fff;"></asp:TextBox>
            
        </div>
    </div>

    <div class="cntfrm_one">
        <label>Email address</label>
        <div class="cntfrm_right">
             <asp:TextBox ID="txtemail" runat="server"  
                    CssClass="validate[required] inputbox smallbox" style="background:#fff;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Email Required" ControlToValidate="txtemail" 
                    ValidationGroup="a"></asp:RequiredFieldValidator>
        
        
        </div>

    </div>
    <div class="cntfrm_one" style="margin-bottom:8px;">
        <label>Comments or Questions</label>
        <div class="cntfrm_right">
             <asp:TextBox ID="txtcomments" runat="server"  
                     CssClass="validate[required] inputbox smallbox" TextMode="MultiLine" 
                     style="width:265px; height:55px; background:#fff;"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                     ErrorMessage="Enter your message" ControlToValidate="txtcomments" 
                     ValidationGroup="a"></asp:RequiredFieldValidator>
        
        
        </div>
    
    </div>
    <div class="cntfrm_one">
        <label></label>
          <asp:Button ID="Button1" runat="server" CssClass="yellow_btn"   Text="submit" 
                ValidationGroup="a" />
    
    </div>
</div>












  
  
       
          
         
       
    
  
</asp:Content>