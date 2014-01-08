<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/ContentMaster.master" CodeFile="Calculation.aspx.vb"  Inherits="Account_Calculation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Content.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="calculation_tot">
        <div class="cal_calendar">
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                Width="200px" Visible="False">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        
    </div>

    <div class="calc_main">
        <div class="cal_form">
            <label>From:</label>
            <asp:Label ID="lblfrom" runat="server" ></asp:Label>
        </div>
        <div class="cal_form">
            <label>To:</label>
            <asp:TextBox ID="txtto" runat="server"  AutoPostBack="True"></asp:TextBox>
             <asp:CalendarExtender ID="txtto_CalendarExtender" runat="server" 
        TargetControlID="txtTo" Format="dd/MM/yyyy">      
    </asp:CalendarExtender>
        </div>
        <div class="cal_form">
            <label>Days:</label>
            <asp:Label ID="lbldays" runat="server" ></asp:Label>
        
        </div>
       <div class="cal_form">
            <label>Amount:</label>
           $ <asp:TextBox ID="txtamount" runat="server" CssClass="c_formbtn"></asp:TextBox>
            <asp:Button ID="btncalculate" runat="server" Text="calculate" />
        </div>
       <div class="cal_form">
            <label>Percent:</label>
            <asp:Label ID="lblpercent" runat="server"></asp:Label>
        
        </div>
       <div class="cal_form">
        <label>Profit $:</label>
        <asp:Label ID="lblpfofit" runat="server" ></asp:Label>
    </div>
   <div class="cal_form">
        <label>Deposit $:</label>
        <asp:Label ID="lbldeposit" runat="server" ></asp:Label>
        <asp:Label ID="lblpackageid" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>


    </div>
    </div>

    </asp:Content> 