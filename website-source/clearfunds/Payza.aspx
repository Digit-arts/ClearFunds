<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Payza.aspx.vb" Inherits="Payza" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     
   
    <form id="payForm" method="post" action="<%Response.Write(URL)%>" >
    
    <input type="hidden" name="ap_merchant" value="<%Response.Write(ap_merchant)%>"/>
    <input type="hidden" name="ap_purchasetype" value="item-goods"/>
    <input type="hidden" name="ap_itemname" value="<%Response.Write(ap_itemname)%>"/>
    <input type="hidden" name="ap_amount" value="<%Response.Write(ap_amount)%>"/>
    <input type="hidden" name="ap_currency" value="USD"/>
    <input type="hidden" name="ap_lname" value="Doe" />
    <input type="hidden" name="ap_contactemail" value="samson.niyahtech@gmail.com" />
    <input type="hidden" name="ap_contactphone" value="5555555555" />
    <input type="hidden" name="ap_addressline1" value="123 Test Street" />
    <input type="hidden" name="ap_addressline2" value="Apt #101" />
    <input type="hidden" name="ap_city" value="Montreal" />
    <input type="hidden" name="ap_returnurl" value="<%Response.Write(return_url)%>" />
    <input type="hidden" name="ap_cancelurl" value="<%Response.Write(cancel_url)%>" />
    <input type="hidden" name="ap_country" value="CAN" />
    
   
    </form>
    <script language="javascript">
        document.forms["payForm"].submit();
    </script>
</body>
</html>
