Imports System.IO
Imports System.Globalization
Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports System.Xml
Imports System.Net
Imports System.Data.SqlClient

Partial Class Account_IPNHandlerMB
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSandbox As String = "http://www.moneybookers.com/app/payment.pl"

        Dim req As HttpWebRequest = CType(WebRequest.Create(strSandbox), HttpWebRequest)
        'Set values for the request back
        req.Method = "POST"
        req.ContentType = "application/x-www-form-urlencoded"
        Dim param() As Byte = Request.BinaryRead(HttpContext.Current.Request.ContentLength)
        Dim strRequest As String = Encoding.ASCII.GetString(param)
        strRequest += "&cmd=_notify-validate"
        req.ContentLength = strRequest.Length
        'for proxy
        'WebProxy proxy = new WebProxy(new Uri(“http://url:port#”));
        'req.Proxy = proxy;
        'Send the request to PayPal and get the response
        Dim streamOut As StreamWriter = New StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII)
        streamOut.Write(strRequest)
        streamOut.Close()
        Dim streamIn As StreamReader = New StreamReader(req.GetResponse().GetResponseStream())
        Dim strResponse As String = streamIn.ReadToEnd()
        streamIn.Close()

        Dim con As New SqlConnection
        con = New SqlConnection(obj.ConnectionString)

        Dim cmd As New SqlCommand
        Dim query As String

        Dim tranref As String, transtat As String, tranamt As String, trandate As Date, tranuserid As String, output As String, curr As String
        If Not Page.IsPostBack Then

            tranref = Request("transaction_id").ToString()
            transtat = Request("status").ToString()
            tranamt = Request("mb_amount").ToString()
            curr = Request("mb_currency").ToString()
            trandate = DateAndTime.Now
            tranuserid = Membership.GetUser.ProviderUserKey.ToString
            'insert into table for future reference - Session["user"] is logged in user
            query = "insert into CF_Transaction(TransactionID,TransactionStatus,Amount,DateTransaction,UserID) values('" + tranref + "','" + transtat + "','" + tranamt + "','" + trandate + "','" + tranuserid + "')"
            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()

            'Display transaction details
            output = "<table width='500' align='center' cellpadding='0' cellspacing='0' border='1'>"
            output += "<tr><td colspan='2' height='40' align='center'><b>Transaction Details</b><td></tr>"
            output += "<tr><td height='40'>TransactionId.<td><td>" + tranref + "</td>"
            output += "<tr><td height='40'>Status<td><td>" + transtat + "</td>"
            output += "<tr><td height='40'>TransactionAmount<td><td>" + tranamt + "</td>"
            output += "<tr><td height='40'>TransactionDate<td><td>" + trandate + "</td>"
            output += "<tr><td height='40'>UserID<td><td>" + tranuserid.ToString() + "</td>"
            output += "</table>"

            successLabel.Text = output
        End If
    End Sub

End Class
