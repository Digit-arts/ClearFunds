<%@ Page Title="ClearFunds" Language="VB" MasterPageFile="ContentMaster.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

    <%@ Register Src="~/Login1.ascx" TagName="Login1" TagPrefix="uc1" %>

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
                    <li><a href="#"><img src="Images/Slide_1.jpg" class="cubeRandom" /></a></li>
                    <li><a href="#"><img src="Images/Slide_2.jpg" class="cubeRandom" /></a></li>
				
					<li><a href="#"><img src="Images/Slide_3.jpg" class="block" /></a></li>
					<li><a href="#"><img src="Images/Slide_4.jpg" class="cubeStop" /></a></li>
					<li><a href="#"><img src="Images/Slide_5.jpg" class="cubeHide" /></a></li>
                   
				</ul>
			</div>
		</div>
	</div>
            </div><!---end img_choll-->
         </div><!---end img_content-->

        <div class="mainpage_center">


            <div class="mainpage_left">
                <h2>Welcome to Clearfunds</h2>
               <div class="h_left">              
                    <div class="hompg_img">
                        <img src="Images/homepag_img.png" />
                    
                        </div>   
                        <p>Malaysian INC today operates in several fields. Our business lines in our core markets of Malaysia, Indonesia, Singapore and Thailand are organized primarily across the following areas: short-term lending market, trading on a stock exchange, equity trade, dividends reinvestment and note brokerage.

Our company is a leading financial services provider taking care of the needs of consumers, investors, entrepreneurs, commercial organizations and corporations. We focus on capturing growth opportunities while taking a proactive and conservative approach to capital management by continuing to establish our presence in high growth markets.

Our strong track record of financial performance and high credit ratings allow us to keep our momentum and continue with robust performance even amidst the current environment. Our priority is long-term cooperation with investors, so we make all efforts to gain a good reputation and confidence of their investments.

Our international operations capture value from new investments and continue to pursue organic expansion by delivering innovation and superior customer value. In the domestic market we aim to achieve leadership in key and profitable segments.

Since February 2013, we are open to investors from around the world. Now anyone can increase their capital by placing funds to be managed by our company.

Therefore, only Malaysian INC can provide stable and reliable source of income for each of you for many years. </p>    
                </div>  
            
            
            </div>
            <div id="divmain" runat="server" class="mainpage_right">    
               <%--  <h2>Latest News</h2>
                 <div id="divrht" runat="server" class="h_right">
                        <div class="h_ritimg "><img src="Images/lat_news.png" /></div>
                     <asp:Label ID="Label1" runat="server" Text="27/05/2013"></asp:Label><br />
                     <asp:HyperLink ID="HyperLink1" Text="Liberty Reserve is unavailable" NavigateUrl="https://en.bitcoin.it/wiki/Liberty_Reserve" runat="server"></asp:HyperLink>
                       <div style="font:12px arial; line-height:21px; text-align:justify;">  <asp:Label ID="Label2" runat="server" Text="Dear investors. How many of you have noticed, Liberty Reserve is unavailable. There is no official information released yet…"></asp:Label><br /></div>
                       <asp:HyperLink ID="HyperLink2" NavigateUrl="~/News.aspx" Text="Read More.." runat="server"></asp:HyperLink>


                 </div>

                  <div class="h_right">
                        <div class="h_ritimg "><img src="Images/celebrat.png" /></div>
                     <asp:Label ID="Label3" runat="server" Text="04/06/2013"></asp:Label><br />
                     <asp:HyperLink ID="HyperLink3" Text=" Paypal is Now Great"  NavigateUrl="https://www.paypal.com" runat="server"></asp:HyperLink>
                       <div style="font:12px arial; line-height:21px; text-align:justify;">  <asp:Label ID="Label4" runat="server" Text="Dear investors. How many of you have noticed, Liberty Reserve is unavailable. There is no official information released yet…"></asp:Label><br /></div>
                       <asp:HyperLink ID="HyperLink4" Text="Read More.." NavigateUrl="~/News.aspx" runat="server"></asp:HyperLink>


                 </div>
                 <div class="h_right ">
                  <h2>Online Support</h2>
                 <div class="h_ritimg "><img src="Images/contact.png" /></div>
                 </div>--%>
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
