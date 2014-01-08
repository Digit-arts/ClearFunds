<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LR.aspx.vb" Inherits="LR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="payForm" method="post" action="<%Response.Write(URL)%>" >
    
       <input type="hidden" name="lr_acc" value="<%Response.Write(accno)%>"/>
       <input type="hidden" name="lr_store" value="My Test"/>
        <input type="hidden" name="lr_acc_from" value="<%Response.Write(caccno)%>"/>
       <input type="hidden" name="lr_amnt" value="<%Response.Write(ap_amount)%>"/>
       <input type="hidden" name="lr_currency" value="LRUSD"/>
        <input type="hidden" name="lr_comments" value="payment for mp3 player"/>
  
   <input type="hidden" name="lr_success_url" value="<%Response.Write(return_url)%>"/>
       <input type="hidden" name="lr_success_url_method" value="<%Response.Write(lsmethod)%>"/>
        <input type="hidden" name="lr_fail_url" value="<%Response.Write(cancel_url)%>"/>
        <input type="hidden" name="lr_fail_url_method" value="<%Response.Write(lfmethod)%>"/>
       <input type="hidden" name="lr_status_url" value="<%Response.Write(notify_url)%>"/>
        <input type="hidden" name="lr_status_url_method" value="<%Response.Write(lstmethod)%>"/>
    </form>
    <script language="javascript">
        document.forms["payForm"].submit();
    </script>
</body>
</html>
