
Partial Class Payza
    Inherits System.Web.UI.Page
    Protected cmd As String = "_xclick"
    Protected business As String = ConfigurationManager.AppSettings("paypalemail").ToString()

    Protected ap_amount As String
    Protected return_url As String
    Protected notify_url As String
    Protected cancel_url As String
    Protected currency_code As String
    Protected no_shipping As String = "1"
    Protected URL As String
    Protected request_id As String
    Protected rm As String
    Protected ap_itemname As String
    Protected ap_merchant As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        return_url = ConfigurationManager.AppSettings("PayzaSuccessURL").ToString()
        notify_url = ConfigurationManager.AppSettings("NotifyUrl").ToString
        cancel_url = ConfigurationManager.AppSettings("FailedURL").ToString()
        currency_code = ConfigurationManager.AppSettings("CurrencyCode")
        ap_itemname = Session("itemname")
        ap_merchant = ConfigurationManager.AppSettings("merchantemail").ToString()
        ' determining the URL to work with depending on whether sandbox or a real PayPal account should be used
        If ConfigurationManager.AppSettings("UseSandbox").ToString = "True" Then
            URL = "https://sandbox.Payza.com/sandbox/payprocess.aspx"
        Else
            URL = "https://secure.Payza.com/sandbox/payprocess.aspx"
        End If

        'This parameter determines the was information about successfull transaction will be passed to the script
        ' specified in the return_url parameter.
        ' "1" - no parameters will be passed.
        ' "2" - the POST method will be used.
        ' "0" - the GET method will be used. 
        ' The parameter is "0" by deault.
        If ConfigurationManager.AppSettings("SendToReturnURL").ToString() = "true" Then
            rm = "2"
        Else
            rm = "1"
        End If

        ' the total cost of the cart
        ap_amount = Session("amount")
        ' the identifier of the payment request
        request_id = Session("Deposit_Id")

    End Sub
End Class
