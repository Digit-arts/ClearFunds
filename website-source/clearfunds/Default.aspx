<%@ Page Title="ClearFunds" Language="VB" MasterPageFile="ContentMaster.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

    <%@ Register Src="Usercontrol/Login1.ascx" TagName="Login1" TagPrefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 
    <link href="css/skitter.styles.css" type="text/css" media="all" rel="stylesheet" />	
    
	<script src="js/jquery-1.6.3.min.js"></script>
	<script src="js/jquery.easing.1.3.js"></script>
	<script src="js/jquery.skitter.min.js"></script>  
	<script>
	    $(document).ready(function () {
	        $('.box_skitter_large').skitter({ label: false, numbers: false });
	    });
	</script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="img_content"><!---start img_content-->
         	<div class="img_choll"><!---start img_choll-->
            	<div id="content">
		<div class="border_box">
			<div class="box_skitter box_skitter_large">
				<ul>
                    <li><a href="#"><img src="Images/Slide_1.jpg" class="cubeRandom" alt="" width="980px" height="px" /></a></li>
                    <li><a href="#"><img src="Images/Slide_2.jpg" class="cubeRandom" alt="" height="350px" width="980px" /></a></li>
					<li><a href="#"><img src="Images/Slide_3.jpg" class="block" alt="" width="980px" height="350px" /></a></li>
					<li><a href="#"><img src="Images/Slide_4.jpg" class="cubeStop" alt="" height="350px" width="980px" /></a></li>
					<li><a href="#"><img src="Images/Slide_5.jpg" class="cubeHide" alt="" height="350px" width="980px" /></a></li>
                   
				</ul>
			</div>
		</div>
	</div>
            </div><!---end img_choll-->
         </div><!---end img_content-->

        <div class="mainpage_center">
         <div class="planTitle">Reasons to choose Clear Funds</div>
       
                
                <div class="feat_plan1">
                    <div class="feat_pic"><img alt="" src="Images/picInterest.jpg" align="middle" 
                            height="172px" width="257px" /></div>
                    <div class="feat_plan_title">Interest</div>
                    <div class="plan_content_txt">
                    The interest that we pay to our investors depends on the results of trading activity of our company for the last business day and is set automatically at midnight... 
                    &nbsp;&nbsp;<asp:HyperLink ID="hlnkfeat_plan1" runat="server" ImageUrl="Images/picMore.jpg" NavigateUrl="~//content.aspx?id=8"></asp:HyperLink>
                    </div>
                </div>
                    
                
                <div class="feat_plan2">
                    <div class="feat_pic"><img alt="" src="Images/picCompounding.jpg" align="middle" 
                            height="172px" width="257px" /></div>
                    <div class="feat_plan_title">Principal</div>
                    <div class="plan_content_txt">
                    The principal will be returned to your account balance at the end of the investment period...
                    &nbsp;&nbsp;<asp:HyperLink ID="hlnkfeat_plan2" runat="server" ImageUrl="Images/picMore.jpg" NavigateUrl="~//content.aspx?id=8"></asp:HyperLink>
                    </div>
                 </div>

                <div class="feat_plan3">
                    <div class="feat_pic"><img alt="" src="Images/picPrincipal.jpg" align="middle" 
                            height="172px" width="257px" /></div>
                    <div class="feat_plan_title">Compounding</div>
                    <div class="plan_content_txt">
                    Compounding is available up to 100% for all investment plans. Compounding rate can be set either during the initial deposit and change at any time...
                    &nbsp;&nbsp;<asp:HyperLink ID="hlnkfeat_plan3" runat="server" ImageUrl="Images/picMore.jpg" NavigateUrl="~//content.aspx?id=8"></asp:HyperLink>
                    </div>
                </div>
         

        
        
        </div>
        
         
          

          
 
      <%--  <div class=" payment_method"><!---payment_method div start-->
        	
          <div class="payment_right"><!---payment_right div start-->
          	<div class="payment_rtop"><!---payment_rtop div start-->
            	&nbsp;Follow Us
            </div><!---payment_rtop div end-->
            <div class=" payment_rbottom"><!---payment_rbottom div start-->
            	<ul>
                	<li><a href="http://www.linkedin.com/"><img src="images/in.png" /></a></li>
                    <li><a href="https://www.facebook.com/"><img src="images/bg_face.png" /> </a></li>
                    <li><a href="https://twitter.com/"><img src="images/twitter.png" /></a></li>
                    <li><a href="http://www.flickr.com/"><img src="images/bg_dot.png" /></a></li>
                    <li><a href="https://www.gmail.com/"><img  src="images/bg_gmail.png" /></a></li>
                    
                 </ul>
            </div><!---payment_rbottom div end-->
          </div><!---payment>_right div end-->	 	
   
              </div><!---payment_method div end-->
           --%>
            
            
                  
            

</asp:Content>    
