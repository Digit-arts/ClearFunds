Imports System.IO
Imports System.Globalization
Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports System.Xml
Imports System.Net

Partial Class Account_IPNHandler
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'SECURITY

        'If Request("txn_id") Is Nothing Then Response.Redirect("~/")

    End Sub
    


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strFormValues As String
        Dim URL As String
        Dim strNewValue = Nothing
        Dim business As String
        Dim currency_code As String = AppSettings("CurrencyCode")

        Try
            Dim ci As CultureInfo = New CultureInfo("en-us")
            Dim strSandbox As String = "https://www.sandbox.paypal.com/cgi-bin/webscr"
            strFormValues = Encoding.ASCII.GetString(Request.BinaryRead(Request.ContentLength))
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
            'Dim strResponse As String = streamIn.ReadToEnd()
            streamIn.Close()
            Dim strResponse As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
            Dim IPNResponseStream As Stream = strResponse.GetResponseStream
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            Dim readStream As New StreamReader(IPNResponseStream, encode)


            Dim read(256) As [Char]
            ' Reads 256 characters at a time.
            Dim count As Integer = readStream.Read(read, 0, 256)

            While count > 0
                ' Dumps the 256 characters to a string
                Dim IPNResponse As New [String](read, 0, count)
                count = readStream.Read(read, 0, 256)

                Dim provider As NumberFormatInfo = New NumberFormatInfo()
                provider.NumberDecimalSeparator = "."
                provider.NumberGroupSeparator = ","
                provider.NumberGroupSizes = New Integer() {3}

                ' if the request is verified
                If IPNResponse = "VERIFIED" Then
                    ' check the receiver's e-mail (login is user's identifier in PayPal) and the transaction type
                    If Request("receiver_email") <> business Or Request("txn_type") <> "web_accept" Then
                        Try
                            ' parameters are not correct. Write a response from PayPal and create a record in the Log file.
                            CreatePaymentResponses(Request("txn_id"), Convert.ToDecimal(Request("mc_gross"), provider), _
                            Request("payer_email"), Request("first_name"), Request("last_name"), Request("address_street"), _
                            Request("address_city"), Request("address_state"), Request("address_zip"), Request("address_country"), _
                            Convert.ToInt32(Request("custom")), False, "INVALID paymetn's parameters (receiver_email or txn_type)")

                        Catch ex As Exception

                        End Try
                        readStream.Close()
                        strResponse.Close()
                        Return
                    End If

                    ' check whether this request was performed earlier for its identifier

                    ' the current request is processed. Write a response from PayPal and create a record in the Log file.
                    InsertTransactionPaypal(True)

                    Common.WriteError(New Exception("Error in IPNHandler: Duplicate txn_id found" & " TXN: " & Request("txn_id")))

                    readStream.Close()
                    strResponse.Close()
                    Return

                    'TODO: CHECK MC_GROSS, amount
                    'Request("mc_gross").ToString(ci) <> 0

                    ' the amount of payment, the status of the payment, amd a possible reason of delay
                    ' The fact that Getting txn_type=web_accept or txn_type=subscr_payment are got odes not mean that
                    ' seller will receive the payment.
                    ' That's why we check payment_status=completed. The single exception is when the seller's account in
                    ' not American and pending_reason=intl
                    If Request("mc_currency") <> currency_code Or _
                    (Request("payment_status") <> "Completed" And Request("pending_reason") <> "intl") Then
                        ' parameters are incorrect or the payment was delayed. A response from PayPal should not be
                        ' written to DB of an XML file
                        ' because it may lead to a failure of uniqueness check of the request identifier.
                        ' Create a record in the Log file with information about the request.
                        InsertTransactionPaypal(True)
                        ' objData.P_UpdateTransactionStatus(CDec(ClassLibrary.Common.DecryptInt(Request("custom"))), Common.TRANSACTSTATUS.FAILED)
                        'ClassLibrary.Common.WriteError(New Exception("Error in IPNHandler: INVALID paymetn's parameters. Request: " + strFormValues & " TXN: " & Request("txn_id")))

                        readStream.Close()
                        strResponse.Close()
                        Return
                    End If

                    Try
                        ' write a response from PayPal
                        InsertTransactionPaypal(False)
                        ' objData.P_UpdateTransactionStatus(CDec(ClassLibrary.Common.DecryptInt(Request("custom"))), Common.TRANSACTSTATUS.SUCCESS)

                        Common.WriteError(New Exception("Success in IPNHandler: PaymentResponses created" & " TXN: " & Request("txn_id")))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ' Here we notify the person responsible for goods delivery that 
                        ' the payment was performed and providing him with all needed information about
                        ' the payment. Some flags informing that user paid for a services can be also set here.
                        ' For example, if user paid for registartion on the site, then the flag should be set 
                        ' allowing the user who paid to access the site
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Catch ex As Exception
                        Common.WriteError(New Exception("Error in IPNHandler: " + ex.Message))
                    End Try

                Else
                    'objData.P_UpdateTransactionStatus(CDec(ClassLibrary.Common.DecryptInt(Request("custom"))), Common.TRANSACTSTATUS.FAILED)
                    Common.WriteError(New Exception("Error in IPNHandler. IPNResponse = " & IPNResponse))
                End If
            End While

            readStream.Close()
            strResponse.Close()
        Catch ex As Exception
            'ClassLibrary.Common.WriteError(ex)
            If CBool(System.Configuration.ConfigurationManager.AppSettings("SHOWERRORDEBUG")) Then Throw Else Response.Redirect(Common.PAGEERRORTRAPPED, False)
        Finally


        End Try
    End Sub
    Public Sub CreatePaymentResponses(ByVal txn_id As String, ByVal payment_price As Decimal, ByVal email As String, ByVal first_name As String, ByVal last_name As String, ByVal street As String, ByVal city As String, ByVal state As String, ByVal zip As String, ByVal country As String, ByVal request_id As Integer, ByVal is_success As Boolean, ByVal reason_fault As String)

        Try
            Dim ci As CultureInfo = New CultureInfo("en-us")
            Dim xmlFile As String = Server.MapPath("~/App_Data/PaymentResponses.xml")
            Dim doc As New XmlDocument()
            Dim payment_id As Integer
            Dim reader As XmlTextReader

            If File.Exists(xmlFile) Then
                reader = New XmlTextReader(xmlFile)
                reader.Read()
            Else

                reader = New XmlTextReader(xmlFile)
                reader.Read()
            End If

            doc.Load(reader)
            reader.Close()

            ' getting a unique identifier of the payment_id payment
            Dim nodes As XmlNodeList = doc.GetElementsByTagName("Response")
            If nodes.Count <> 0 Then

            Else
                payment_id = 0
            End If

            ' creating a new element containing information about the payment
            Dim myresponse As XmlElement = doc.CreateElement("Response")
            myresponse.SetAttribute("payment_id", payment_id)
            myresponse.SetAttribute("txn_id", txn_id)
            myresponse.SetAttribute("payment_date", DateTime.Now.ToString(ci))
            myresponse.SetAttribute("payment_price", payment_price.ToString(ci))
            myresponse.SetAttribute("email", email)
            myresponse.SetAttribute("first_name", first_name)
            myresponse.SetAttribute("last_name", last_name)
            myresponse.SetAttribute("street", street)
            myresponse.SetAttribute("city", city)
            myresponse.SetAttribute("state", state)
            myresponse.SetAttribute("zip", zip)
            myresponse.SetAttribute("country", country)
            myresponse.SetAttribute("request_id", request_id)
            myresponse.SetAttribute("is_success", is_success)
            myresponse.SetAttribute("reason_fault", reason_fault)

            doc.DocumentElement.AppendChild(myresponse)

            doc.Save(xmlFile)
        Catch ex As Exception

        End Try

    End Sub
    'Private Sub InsertTransactionPaypal(ByVal failure As Boolean)

    '    Try


    '        If failure Then
    '            obj.P_InsertPaypalTransactionFailures(Request("mc_gross"), Request("protection_eligibility"),
    '                                                                      Request("item_number1"), Request("payer_id"), Request("tax"),
    '                                                                      Request("payment_date"), Request("payment_status"),
    '                                                                      Request("charset"), Request("mc_shipping"),
    '                                                                      Request("mc_handling"), Request("first_name"),
    '                                                                      Request("notify_version"), Common.DecryptInt(Request("custom")),
    '                                                                      Request("payer_status"), Request("num_cart_items"),
    '                                                                      Request("mc_handling1"), Request("verify_sign"),
    '                                                                      Request("payer_email"), Request("mc_shipping1"),
    '                                                                      Request("txn_id"), Request("payment_type"),
    '                                                                      Request("last_name"), Request("item_name1"),
    '                                                                      Request("receiver_email"), Request("quantity1"),
    '                                                                      Request("pending_reason"), Request("txn_type"),
    '                                                                      Request("mc_gross_1"), Request("mc_currency"),
    '                                                                      Request("residence_country"), Request("test_ipn"),
    '                                                                      Request("transaction_subject"), Request("payment_gross"), Request("memo"))

    '        Else
    '            objData.P_InsertPaypalTransactionConfirmation(Request("mc_gross"), Request("protection_eligibility"),
    '                                                                      Request("item_number1"), Request("payer_id"), Request("tax"),
    '                                                                      Request("payment_date"), Request("payment_status"),
    '                                                                      Request("charset"), Request("mc_shipping"),
    '                                                                      Request("mc_handling"), Request("first_name"),
    '                                                                      Request("notify_version"), Common.DecryptInt(Request("custom")),
    '                                                                      Request("payer_status"), Request("num_cart_items"),
    '                                                                      Request("mc_handling1"), Request("verify_sign"),
    '                                                                      Request("payer_email"), Request("mc_shipping1"),
    '                                                                      Request("txn_id"), Request("payment_type"),
    '                                                                      Request("last_name"), Request("item_name1"),
    '                                                                      Request("receiver_email"), Request("quantity1"),
    '                                                                      Request("pending_reason"), Request("txn_type"),
    '                                                                      Request("mc_gross_1"), Request("mc_currency"),
    '                                                                      Request("residence_country"), Request("test_ipn"),
    '                                                                      Request("transaction_subject"), Request("payment_gross"), Request("memo"))
    '        End If


    '    Catch ex As Exception
    '        Common.WriteError(ex)
    '        If CBool(System.Configuration.ConfigurationManager.AppSettings("SHOWERRORDEBUG")) Then Throw Else Response.Redirect(Common.PAGEERRORTRAPPED, False)
    '    Finally


    '    End Try
    'End Sub

    Private Sub InsertTransactionPaypal(ByVal failure As Boolean)

    End Sub

End Class


