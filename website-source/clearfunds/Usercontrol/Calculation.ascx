<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Calculation.ascx.vb" Inherits="Calculation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="css/Content.css" rel="stylesheet" type="text/css" />
      
    <div class="cal_rt">
    <div class="cal_form">
        <label>From:</label>
        <div class="cal_formrt"><asp:Label ID="lblfrom" runat="server" ></asp:Label></div>
    </div>

    <div class="cal_form">
        <label>To:</label>
        <div class="cal_formrt" >
            <asp:TextBox ID="txtTo" runat="server" AutoPostBack="True"></asp:TextBox>
              <asp:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" 
        TargetControlID="txtTo" Format="dd/MM/yyyy">      
    </asp:CalendarExtender>
        </div>
        
    </div>

        <div class="cal_form">
        <label>Days:</label>
           <div class="cal_formrt"> <asp:Label ID="lbldays" runat="server" ></asp:Label></div>
        
        </div>
        <div class="cal_form" >
          <label>Amount:</label>
          
             <div class="cal_formrt">
              $ <asp:TextBox ID="txtamount" runat="server" CssClass="c_formbtn"></asp:TextBox>
             <asp:Button ID="btncalculate" runat="server" Text="calculate" />
             </div>
        </div>
        <div class="cal_form">
            <label>Percent:</label>
             <div class="cal_formrgt"><asp:Label ID="lblpercent" runat="server"></asp:Label></div>
        
        </div>
        <div class="cal_form">
            <label>Profit $:</label>
            <div class="cal_formrgt"><asp:Label ID="lblpfofit" runat="server" ></asp:Label></div>
       </div>
    <div class="cal_form">
        <label>Deposit $:</label>
         <div class="cal_formrt"> <asp:Label ID="lbldeposit" runat="server" ></asp:Label>
        <asp:Label ID="lblpackageid" runat="server" Text="Label" Visible="False"></asp:Label></div>
    </div>
      
      </div>
      