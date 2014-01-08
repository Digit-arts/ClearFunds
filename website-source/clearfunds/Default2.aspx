<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel runat="server" HeaderText="Account" ID="TabPanel1" OnClientClick ="Search" >
            
               
           
        </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
        </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
        </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
        </asp:TabPanel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
        </asp:TabPanel>
&nbsp;&nbsp;&nbsp; </asp:TabContainer>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
