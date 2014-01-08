<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserEntryTickets.aspx.vb" MasterPageFile="~/AccountMaster.master" Inherits="Account_UserEntryTickets" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Content.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

     <h2 class="acc_heading">Create Ticket</h2><br />
    	

    <div class="usrentryfrm">

   <%--   <tr>
        <td width="25%" style="height: 24px">
           CustomerID:</td>
            
            <td class="style1">
         <asp:TextBox ID="txtcustomerid" CssClass="inputbox smallbox" runat="server" ></asp:TextBox>
            </td>
          </tr>--%>
          <%-- <tr>
        <td width="25%" style="height: 24px">
            Sender:</td>
            
            <td class="style1">
         <asp:TextBox ID="txtsender" runat="server"  CssClass="inputbox smallbox"></asp:TextBox>
            </td>
          </tr>
           <tr>--%>
        <%--<td width="25%" style="height: 24px">
            Operator:</td>
            
            <td class="style1">
         <asp:TextBox ID="txtoperator" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
            </td>
          </tr>
           <tr>--%>
           <%--<div class="cntfrm_one">
        <label>Username</label>
            
            <div class="cntfrm_right">
         <asp:TextBox ID="txtusername" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
            </div>
          </div>
           <div class="cntfrm_one">

        <label>Email Address:</label>
            
            <div class="cntfrm_right">
         <asp:TextBox ID="txtemailaddress" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
         
               <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ErrorMessage="invalid email address" ControlToValidate="txtemailaddress" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="a"></asp:RegularExpressionValidator>
            </div>
         </div>--%>

           <%--<tr>
        <td width="25%" style="height: 24px">
            Email cc To:</td>
            
            <td class="style1">
         <asp:TextBox ID="txtemailto" runat="server" CssClass="inputbox smallbox"></asp:TextBox>
         
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="invalid email address" ControlToValidate="txtemailto" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="a"></asp:RegularExpressionValidator>
            </td>
          </tr>--%>
          <div class="cntfrm_one">
        <label>Categories:</label>
            <div class="cntfrm_right">
      <asp:DropDownList ID ="drpcategories" runat="server" style="border: 0 none; border-radius: 4px 4px 4px 4px;height: 25px; padding: 2px;width: 250px; margin-bottom:5px;" ></asp:DropDownList>
                 <asp:RequiredFieldValidator
            ID="RequiredFieldValidator4" runat="server"  ControlToValidate ="drpcategories" ErrorMessage="select your categories"></asp:RequiredFieldValidator>
            </div>
        </div>
             <div class="cntfrm_one">
        <label>Priority:</label>
            <div class="cntfrm_right">
                
         <asp:DropDownList  style="border: 0 none; border-radius: 4px 4px 4px 4px;height: 25px; padding: 2px;width: 250px;" ID ="ddlpriority" runat="server" Width="250px">
             <asp:ListItem Value="High">High</asp:ListItem>
             <asp:ListItem Value="Low">Low</asp:ListItem>
                </asp:DropDownList>
            </div>
          </div>
        <%--<div class="cntfrm_one">
            <label>cntfrm_one</label>
            Due date:
           <div class="cntfrm_right">
       <asp:TextBox ID="txtdatetime" runat="server" Enabled="false" CssClass="due_date" ></asp:TextBox>
            </div>
         </div>--%>
              <div class="cntfrm_one">
        <label>
            *Subject:</label>
           <div class="cntfrm_right">
        <asp:TextBox ID="txtproblem" runat="server" TextMode="SingleLine"  ></asp:TextBox>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" 
                 ControlToValidate="txtproblem"    ErrorMessage="please enter your product problem"></asp:RequiredFieldValidator>
          </div>
         </div>
                      <div class="cntfrm_one">
        <label>
            Details:</label>
            <div class="cntfrm_right">
        <asp:TextBox ID="txtcomment" runat="server" TextMode="MultiLine" Width="469px" 
                    Height="98px"></asp:TextBox>
            </div>
          </div>
     

<div class="cntfrm_one">
        <label>
            *AttachFile:</label>
           <div class="cntfrm_right">
               <asp:FileUpload ID="FileUpload1" runat="server"  />
          </div>
         </div>


            <div class="cntfrm_one">
            <label></label>
        <div class="cntfrm_right">
                <asp:Button ID="btnsubmit" runat="server" Text="submit" CssClass="submitButton input"
                    Width="95px" Height="28px" Style="margin-right:4px;" /> &nbsp;&nbsp; <asp:Button ID="btnreset" runat="server" OnClick="Clear_Click" Text="Cancel" Width="95px"  Height="28px" CssClass="submitButton input"/>
          </div>        
</div>
         </div>
        
        
</asp:Content>