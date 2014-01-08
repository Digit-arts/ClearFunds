<%@ Page Language="VB" AutoEventWireup="false" CodeFile="stp.aspx.vb" Inherits="stp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form  id="payForm" action="<%Response.Write(URL)%>" method="post"/>
    <input type=hidden name="testmode" value="on" />
    <input type=hidden name="merchantAccount" value="<%Response.Write(merchantAccount)%>" />
    <input type=hidden name="amount" value="<%Response.Write(ap_amount)%>"/>
    <input type=hidden name="currency" value="USD" />
    <input type=hidden name="item_id" value="<%Response.Write(ap_itemname)%>" />
    <input type=hidden name="notify_url" value="<%Response.Write(notify_url)%>" />
    <input type=hidden name="return_url" value="<%Response.Write(return_url)%>" />
    <input type=hidden name="cancel_url" value="<%Response.Write(cancel_url)%>" />
   </form>
     <script language="javascript">
         document.forms["payForm"].submit();
    </script>
</body>
</html>
