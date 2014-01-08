<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Admin/Site.master" CodeFile="sendpenalty.aspx.vb" Inherits="Admin_sendpenalty" %>

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
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
<h2>Send penalty</h2>
<table class="con_text2" align="center">
        <tr>
            <td>
                
                <asp:Label ID="Label1" runat="server" Text="Amount($) :"></asp:Label>
                </td>
            <td>

                <asp:TextBox ID="txtAmount" runat="server"  Width="282px" Height="27px" CssClass="validate[required] inputbox smallbox" style="padding:3px;"></asp:TextBox>
                    <%--<asp:requiredfieldvalidator id="Requiredfieldvalidator1" 
        controltovalidate="txtAmount"
        errormessage=" Please Enter an Amount ." ForeColor="Red"
           runat="server"/>--%>
            </td>
        </tr>
        <tr>
           
            <td>

                <asp:Label ID="Label3" runat="server" Text="E-currency :"></asp:Label>
            </td>
            <td>

                <asp:DropDownList ID="cmbEcurrency" runat="server"  Height ="35px" 
                    Width="290px">
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
                    Width="290px" AutoPostBack="True">
                     <asp:ListItem Text="Select"  ></asp:ListItem>
                    <asp:ListItem>One user (enter the username below)</asp:ListItem>
                    <asp:ListItem>All users</asp:ListItem>
                    <asp:ListItem>All users Which have made a deposit</asp:ListItem>
                    <asp:ListItem>All users Which haven&#39;t made a deposite</asp:ListItem>
                </asp:DropDownList>
               
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="Label5" runat="server" Text="Enter user mail :"></asp:Label>
            </td>
            <td>


                <asp:TextBox ID="txtToMembers" runat="server" 
                    TextMode="MultiLine"  Width="270" Height="110"  CssClass="validate[required] inputbox smallbox"></asp:TextBox>
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtToMembers"  ForeColor="Red"                  
             ErrorMessage="Select One User!"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="Label6" runat="server" Text="Description :"></asp:Label>
            </td>
            <td>

                <%--<asp:TextBox ID="txtDescription" runat="server" Height="26px" Width="221px" 
                    CssClass ="inputbox smallbox">Enter the partly description here</asp:TextBox>--%>
                    <asp:TextBox TabIndex="1" ID="txtDescription" runat="server"  CssClass ="inputbox smallbox"  TextMode="MultiLine"  Width="270" Height="110" 
                     meta:resourcekey="UserNameResource1" value="Enter the penalty description here" onfocus="javascript: if(this.value == 'Enter the penalty description here'){ this.value = ''; }" onblur="javascript: if(this.value==''){this.value='Enter the penalty description here';} "></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               </td>
            <td style="font-weight: 700">

                <asp:Button ID="cmdSendBonus" runat="server" Height="29px" Text="Submit" 
                    Width="106px"  CssClass =" btnalt "/>
               <asp:Label ID="lblmesg" runat="server" ForeColor="Green" Visible="false" Font-Bold="true" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>


