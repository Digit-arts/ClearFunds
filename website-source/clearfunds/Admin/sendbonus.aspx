<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="sendbonus.aspx.vb" Inherits="Admin_sendbonus" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
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
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
<h2>Send Bonus</h2>
    <table class="con_text2">
        <tr>
            <td>
                
                <asp:Label ID="Label1" runat="server" Text="Amount($) :"></asp:Label>
                </td>
            <td>

                <asp:TextBox ID="txtAmount" onkeypress="return numbersonly(event)" runat="server"  CssClass="validate[required] inputbox smallbox"></asp:TextBox>
                    <%--<asp:requiredfieldvalidator id="Requiredfieldvalidator1" 
        controltovalidate="txtAmount" ForeColor="Red"
        errormessage=" Please Enter an Amount ."
           runat="server"/>--%>
            </td>
        </tr>
        <tr>
           
            <td>

                <asp:Label ID="Label3" runat="server" Text="E-currency :"></asp:Label>
            </td>
            <td>

                <asp:DropDownList ID="cmbEcurrency" runat="server" Height ="35px" Width="335px">
                    <asp:ListItem>E-Curency</asp:ListItem>
                </asp:DropDownList>
            
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="Label4" runat="server" Text="Being sent to :"></asp:Label>
            </td>
            <td>

                <asp:DropDownList ID="cmbUserSelection" runat="server" Height ="35px" 
                    Width="335px" AutoPostBack="True" >
                    <asp:ListItem   Text="Select"  ></asp:ListItem>
                   <asp:ListItem>Specified users(enter the usernames below)</asp:ListItem>
                    <asp:ListItem>All users</asp:ListItem>
                    <asp:ListItem>All users Which have made a deposit</asp:ListItem>
                    <asp:ListItem>All users Which haven&#39;t made a deposit</asp:ListItem>
                </asp:DropDownList>
                               

            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="Label5" runat="server" Text="Enter user name :"></asp:Label>
            </td>
            <td>


                <asp:TextBox ID="txtToMembers" Enabled="false" runat="server" 
                    TextMode="MultiLine"  Width="317" Height="110" CssClass="validate[required] inputbox smallbox"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtToMembers" ForeColor="Red"                  
             ErrorMessage="Select One User!"></asp:RequiredFieldValidator>
--%>
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="Label6" runat="server" Text="Description :"></asp:Label>
            </td>
            <td>

             <%--   <asp:TextBox ID="txtDescription" runat="server" CssClass ="inputbox smallbox">Enter the bonus description here</asp:TextBox>--%>

                    <asp:TextBox TabIndex="1" ID="txtDescription" runat="server" Width="317" Height="110" TextMode="MultiLine"  CssClass ="inputbox smallbox" 
                     meta:resourcekey="UserNameResource1" value="Enter the bonus description here" onfocus="javascript: if(this.value == 'Enter the bonus description here'){ this.value = ''; }" onblur="javascript: if(this.value==''){this.value='Enter the bonus description here';} "></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>

                <asp:Button ID="cmdSendBonus" runat="server" Text="Send Bonus"  CssClass ="btnalt"/>
                <asp:Label ID="lblmesg" runat="server" ForeColor="Green" Visible="false" Font-Bold="true" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>

   
    <br />
    <br />
</asp:Content>


