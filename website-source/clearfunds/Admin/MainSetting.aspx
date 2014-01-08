<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="MainSetting.aspx.vb" Inherits="Admin_MainSetting" %>
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
    <h2><asp:Label ID="Label6" runat="server" Text="Main settings"></asp:Label></h2>
    <div class="plan_con inner">
  
    <div>
    <table>
    <tr>
    <td style="width:25%; float:left;">
    <asp:Label ID="Label1" runat="server" Text="Site Name:"></asp:Label>
    </td>
    <td style="float:left;">
    <asp:TextBox ID="txtsitename" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td style="width:25%; float:left;">
    <asp:Label ID="Label2" runat="server" Text="Site Url:"></asp:Label>
    </td>
    <td style="float:left;">
    <asp:TextBox ID="txtsiteurl" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td style="width:25%; float:left;">
    <asp:Label ID="Label3" runat="server" Text="Site day:"></asp:Label>
    </td>
    <td style="float:left;">
    <asp:TextBox ID="txtsiteday" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
        <asp:CalendarExtender ID="txtsiteday_CalendarExtender" runat="server" 
            TargetControlID="txtsiteday">
        </asp:CalendarExtender>
    </td>
    </tr>
    </table>
    </div>
     <b><asp:Label ID="Label5" runat="server" Text="Administrator login settings:"></asp:Label></b>
   
   
    <div>
    <table>
    <tr>
    <td style="width:25%; float:left;">
    <asp:Label ID="Label4" runat="server" Text="Login"></asp:Label>
    </td>
    <td style="float:left;">
     <asp:TextBox ID="txtlogin" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
    </td>
    </tr>
       
          <tr>
    <td style="width:25%; float:left;">
    <asp:Label ID="Label8" runat="server" Text="Password:"></asp:Label>
    </td>
    <td style="float:left;">
     <asp:TextBox ID="txtpwd" TextMode="Password" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td style="width:25%; float:left;">
    <asp:Label ID="Label9" runat="server" Text="Retype password:"></asp:Label>
    </td>
    <td style="float:left;">
     <asp:TextBox ID="txtrepwd" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
    </td>
    </tr>

      <tr>
    <td style="width:25%; float:left;">
    <asp:Label ID="Label10" runat="server" Text="Administrator e-mail:"></asp:Label>
    </td>
    <td style="float:left;">
     <asp:TextBox ID="txtemail" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"  ControlToValidate="txtemail" ErrorMessage="InvalidEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]w+)*\.\w+([-.]\w+)*"  >*</asp:RegularExpressionValidator>
    </td>
    </tr>
    </table>
      </div>
    <b><asp:Label ID="Label11" runat="server" Text="Deposit Settings:"></asp:Label>     </b>
  <div>
  <table>
    <tr>
    <td style="width:25%; float:left;">
      <asp:Label ID="Label12" runat="server" Text="Allow Deposit to Account:"></asp:Label>   
        </td>
    <td style="float:left;">
      <asp:DropDownList ID="dtballowdeptoacc" runat="server" Width="195px">
      <asp:ListItem>Yes</asp:ListItem>
       <asp:ListItem>No</asp:ListItem>
                              </asp:DropDownList>
    </td>
    </tr>

    <tr>
    <td  style="width:25%; float:left;">
        <asp:Label ID="lbldepno" runat="server" Text="Deposit TransNo"></asp:Label>
    </td>
    <td style="float:left;" >
        <asp:TextBox ID="txtdepno" runat="server" onkeypress="return numbersonly(event)"   CssClass="inputbox smallbox"></asp:TextBox>
    
    </td>
    </tr>
    </table>
      </div>
         <b><asp:Label ID="Label13" runat="server" Text="Withdrawal Settings:"></asp:Label>   </b>
      <div>
      <table>
      <tr>
      <td style="width:25%; float:left;">
         <asp:Label ID="Label14" runat="server" Text="Withdrawal Fee (%):"></asp:Label>   
      </td>
     <td style="float:left;">
      <asp:TextBox ID="txtwdfee" onkeypress="return numbersonly(event)"  runat="server" CssClass="inputbox smallbox"></asp:TextBox>
     </td>
      </tr>

       <tr>
      <td style="width:25%; float:left;">
         <asp:Label ID="Label15" runat="server" Text="Minimal Withdrawal Fee ($):"></asp:Label>   
      </td>
     <td style="float:left;">
      <asp:TextBox ID="txtminwdfee" onkeypress="return numbersonly(event)"  runat="server" CssClass="inputbox smallbox"></asp:TextBox>
     </td>
      </tr>

       <tr>
      <td style="width:25%; float:left;">
         <asp:Label ID="Label16" runat="server" Text="Minimal Withdrawal Amount ($):"></asp:Label>   
      </td>
     <td style="float:left;">
      <asp:TextBox ID="txtminwdamt" onkeypress="return numbersonly(event)"  runat="server" CssClass="inputbox smallbox"></asp:TextBox>
     </td>
      </tr>

       <tr>
      <td style="width:25%; float:left;">
         <asp:Label ID="Label17" runat="server" Text="Max daily withdraw ($):"></asp:Label>   
      </td>
     <td style="float:left">
      <asp:TextBox ID="txtmaxdwd" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
       <asp:Label ID="Label18" onkeypress="return numbersonly(event)"  runat="server" Text="(set 0 to skip limits)" Width="150"></asp:Label>   
     </td>
      </tr>

        <tr>
      <td style="width:25%; float:left;">
         <asp:Label ID="Label19" runat="server" Text="Limit Widthdraw Period:"></asp:Label>   
      </td>
     <td style="float:left;">
      <asp:TextBox ID="txtlimwdperiod" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
       <asp:Label ID="Label20" runat="server" Text="per"></asp:Label>   
       <asp:DropDownList runat="server" ID="dtplimper">
           <asp:ListItem>None</asp:ListItem>
           <asp:ListItem>Day</asp:ListItem>
           <asp:ListItem>Week</asp:ListItem>
           <asp:ListItem>Month</asp:ListItem>
           <asp:ListItem>Year</asp:ListItem>
         </asp:DropDownList>

          </td>
      </tr>
      <tr>
    <td style="width:25%; float:left;">
        <asp:Label ID="lbltrnsno" runat="server" Text="WithdrwalTransNo"></asp:Label>
    </td>
    <td style="float:left;">
        <asp:TextBox ID="txttransno"  onkeypress="return numbersonly(event)"  CssClass="inputbox smallbox" runat="server"></asp:TextBox>
    
    </td>
    </tr>

      </table>
      </div>
       <b><asp:Label ID="Label21" runat="server" Text="User settings:"></asp:Label>   </b>
       <table>
       <tr>
       <td style="width:25%; float:left;">
        <asp:Label ID="Label22" runat="server"  Text="Minimal user password length:"></asp:Label>   
       </td>
       <td style="float:left;">
        <asp:TextBox ID="txtminupwdlen" runat="server" onkeypress="return numbersonly(event)"  CssClass="inputbox smallbox"></asp:TextBox>
       </td>
        </tr>

        <tr>
        <td style="width:25%; float:left;">
            <asp:Label ID="lblMacc" runat="server" Text="Maxinum Account Info Changeble"></asp:Label>
        </td>
        <td style="float:left;">
            <asp:TextBox ID="txtmacc" runat="server" onkeypress="return numbersonly(event)"  CssClass="inputbox smallbox"></asp:TextBox>
        </td>
        </tr>
          <tr>
        <td style="width:25%; float:left;">
            <asp:Label ID="lblpacc" runat="server" Text="Maxinum Payment Info Changeble"></asp:Label>
        </td>
        <td style="float:left;">
            <asp:TextBox ID="txtpacc" runat="server" onkeypress="return numbersonly(event)"  CssClass="inputbox smallbox"></asp:TextBox>
        </td>

        </tr>
        <tr>
        
        <td style="width:25%; float:left;">
            <asp:Label ID="Label7" runat="server" Text="Response time For User Ticket"></asp:Label>
        </td>
        
        
        <td style="float:left;">
            <asp:TextBox ID="txttime" runat="server" onkeypress="return numbersonly(event)"   CssClass="inputbox smallbox" ></asp:TextBox>
        
        </td>
        </tr>
       <tr>
       <td style="width:25%; float:left;"></td>
        <td style="float:left;">
        <asp:Button ID="btnsave" runat="server" Text="Change settings"  CssClass="btnalt" />
         <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label> 
         </td>  
         </tr>
    </table>
    </div>
</asp:Content>
