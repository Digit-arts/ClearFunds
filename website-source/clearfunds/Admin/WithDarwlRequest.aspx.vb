Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.IO

Partial Class Admin_WithDarwlRequest
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim userid As Guid
    Protected WithEvents resultSpan As New Global.System.Web.UI.HtmlControls.HtmlGenericControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     
        Dim dt As New DataTable()
        Dim str As String = ""
        Dim Total As Double
       
        If Not Me.IsPostBack Then
            str = " select a.WithDrawl_Id,b.UserId, b.UserName, CONVERT(varchar,a.WithDrawl_Date,106) as WithDrawl_date,a.WithDrawl_Amount,a.WithDrawl_Status,a.WithDrawl_Remarks from CF_WithDrawl a join aspnet_Users b on a.WithDrawl_UserId=b.UserId  where  WithDrawl_Status='Request' "
            Total = obj.Returnsinglevalue(" select SUM( a.WithDrawl_Amount) from CF_WithDrawl a   join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status<>'true'")
            lblAmt.Text = Val(Total)
            dt = obj.returndatatable(str, dt)
            GVMembersList.DataSource = dt
            GVMembersList.DataBind()

        End If


    End Sub


    Protected Sub lnkhold_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim status As String = "HOLD"
        Dim LnkSeletedRow As LinkButton = TryCast(sender, LinkButton)
        'For Each grv1 As GridViewRow In GVMembersList.Rows

        '    Dim tb As TextBox = DirectCast(grv1.FindControl("txtremarks"), TextBox)

        '    Dim value1 As String = tb.Text


        'Next

        If LnkSeletedRow IsNot Nothing Then
            Dim grv As GridViewRow = TryCast(LnkSeletedRow.NamingContainer, GridViewRow)
            If grv IsNot Nothing Then
                Dim lb As Label = DirectCast(grv.FindControl("lblid1"), Label)
                Dim value1 As String = lb.Text
                Dim tb As TextBox = DirectCast(grv.FindControl("txtremarks"), TextBox)

                Dim value As String = tb.Text
                If Not value = Nothing Then


                    Dim con As New SqlConnection
                    con = New SqlConnection(obj.ConnectionString)
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "SP_CF_UpdateWithDrawl"
                    cmd.Connection = con

                    cmd.Parameters.Add(New SqlParameter("@WithDrawl_Id", SqlDbType.VarChar, 10)).Value = value1
                    cmd.Parameters.Add(New SqlParameter("@WithDrawl_Status", SqlDbType.VarChar, 10)).Value = status
                    cmd.Parameters.Add(New SqlParameter("@WithDrawl_Remarks", SqlDbType.VarChar, 1000)).Value = value
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    Dim dt As New DataTable()
                    dt = obj.returndatatable("select a.WithDrawl_Id,b.UserId, b.UserName,a.WithDrawl_Date,a.WithDrawl_Status,a.WithDrawl_Amount,a.WithDrawl_Remarks from CF_WithDrawl a join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status='Request' ", dt)
                    GVMembersList.DataSource = dt
                    GVMembersList.DataBind()
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Reason shoul be filled Out');", True)
                End If
            End If
        End If


    End Sub

    Protected Sub lnkReject_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim status As String = "REJECTED"
        Dim LnkSeletedRow As LinkButton = TryCast(sender, LinkButton)
        For Each grv1 As GridViewRow In GVMembersList.Rows

            Dim tb As TextBox = DirectCast(grv1.FindControl("txtremarks"), TextBox)

            Dim value1 As String = tb.Text


        Next
        If LnkSeletedRow IsNot Nothing Then
            Dim grv As GridViewRow = TryCast(LnkSeletedRow.NamingContainer, GridViewRow)
            If grv IsNot Nothing Then
                Dim lb As Label = DirectCast(grv.FindControl("lblid1"), Label)
                Dim value1 As String = lb.Text
                Dim tb As TextBox = DirectCast(grv.FindControl("txtremarks"), TextBox)
                Dim value As String = tb.Text
                If Not value = Nothing Then
                    Dim con As New SqlConnection
                    con = New SqlConnection(obj.ConnectionString)
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "SP_CF_UpdateWithDrawl"
                    cmd.Connection = con

                    cmd.Parameters.Add(New SqlParameter("@WithDrawl_Id", SqlDbType.VarChar, 10)).Value = value1
                    cmd.Parameters.Add(New SqlParameter("@WithDrawl_Status", SqlDbType.VarChar, 10)).Value = status
                    cmd.Parameters.Add(New SqlParameter("@WithDrawl_Remarks", SqlDbType.VarChar, 1000)).Value = value
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    Dim dt As New DataTable()
                    dt = obj.returndatatable("select a.WithDrawl_Id, b.UserId,b.UserName,a.WithDrawl_Date,a.WithDrawl_Status,a.WithDrawl_Amount,a.WithDrawl_Remarks from CF_WithDrawl a join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status='Request' ", dt)
                    GVMembersList.DataSource = dt
                    GVMembersList.DataBind()
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Reason shoul be filled Out');", True)

                End If
            End If
        End If



    End Sub


    'Protected Sub lnkApproved_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim status As String = "APPROVED"
    '    Dim LnkSeletedRow As LinkButton = TryCast(sender, LinkButton)

    '    For Each grv1 As GridViewRow In GVMembersList.Rows
    '        Dim tb As TextBox = DirectCast(grv1.FindControl("txtremarks"), TextBox)
    '        Dim value1 As String = tb.Text
    '    Next
    '    If LnkSeletedRow IsNot Nothing Then
    '        Dim grv As GridViewRow = TryCast(LnkSeletedRow.NamingContainer, GridViewRow)
    '        If grv IsNot Nothing Then
    '            Dim lb As Label = DirectCast(grv.FindControl("lblid1"), Label)
    '            Dim value1 As String = lb.Text
    '            Dim tb As TextBox = DirectCast(grv.FindControl("txtremarks"), TextBox)

    '            Dim value As String = tb.Text
    '            Dim con As New SqlConnection
    '            con = New SqlConnection(obj.ConnectionString)
    '            con.Open()
    '            Dim cmd As New SqlCommand
    '            cmd.CommandType = CommandType.StoredProcedure
    '            cmd.CommandText = "SP_CF_UpdateWithDrawl"
    '            cmd.Connection = con

    '            cmd.Parameters.Add(New SqlParameter("@WithDrawl_Id", SqlDbType.VarChar, 10)).Value = value1
    '            cmd.Parameters.Add(New SqlParameter("@WithDrawl_Status", SqlDbType.VarChar, 10)).Value = status
    '            cmd.Parameters.Add(New SqlParameter("@WithDrawl_Remarks", SqlDbType.VarChar, 1000)).Value = value
    '            cmd.ExecuteNonQuery()
    '            cmd.Parameters.Clear()
    '            Dim dt As New DataTable()
    '            dt = obj.returndatatable("select a.WithDrawl_Id,b.UserId ,b.UserName,a.WithDrawl_Date,a.WithDrawl_Amount,a.WithDrawl_Remarks from CF_WithDrawl a join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status='Request' ", dt)
    '            GVMembersList.DataSource = dt
    '            GVMembersList.DataBind()
    '        End If
    '    End If

    'End Sub



    Protected Sub MassPay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MassPay.Click
        If Not Me.IsPostBack = Nothing Then
            Dim dt As New DataTable()
            dt = obj.returndatatable("select a.WithDrawl_Id, b.UserId,b.UserName,a.WithDrawl_Date,a.WithDrawl_Status,a.WithDrawl_Amount,a.WithDrawl_Remarks from CF_WithDrawl a join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status='Request' ", dt)
            'For Each count In dt.Rows
            '    If dt.Rows.Count > 0 Then


            For Each grv1 As GridViewRow In GVMembersList.Rows



                Dim chk As CheckBox = DirectCast(grv1.FindControl("chkselect"), CheckBox)

                If chk.Checked = True Then

                    Dim lb As Label = DirectCast(grv1.FindControl("lblid1"), Label)
                    Dim value1 As String = lb.Text
                    ViewState("Wd_Id") = value1
                    'MsgBox(value1)
                    Dim lb1 As Label = DirectCast(grv1.FindControl("lbluser"), Label)
                    Dim value2 As String = lb1.Text
                    ViewState("value1") = value1
                    Dim paymethod As String = obj.Returnsinglevalue("select b.CustomProcessing_Name from CF_User a join CF_CustomProcessing b on a.user_PaymentTypeId=b.CustomProcessing_id where a.user_UserId='" + value2 + "'")
                    Dim dtp As New DataTable()

                    Dim payeraccname As String = ""
                    Dim user As String = obj.Returnsinglevalue("select [User_Id] from CF_User where [User_UserId]='" + value2 + "'")

                    dtp = obj.returndatatable("select * from [UserPaymentDet] where Payment_UserId ='" + user + "'", dtp)
                    Dim payeremail As New ArrayList()
                    If dtp.Rows.Count > 0 Then
                        For i As Integer = 0 To dtp.Rows.Count
                            'For Each row As DataRow In dtp.Rows
                            payeremail.Add(dtp.Rows(0).Item("UserPaymentAccDet"))

                            'payeremail = dtp.Rows(0).Item("UserPaymentAccDet")
                            'payeraccname = dtp.Rows(0).Item("UserPaymentAccDetName")
                        Next
                        'Next
                        'ViewState("payeremail") = dtp.Rows(0).Item("UserPaymentAccDet")
                        ViewState("payeremail") = payeremail(0)
                    End If

                    If paymethod = "Paypal" Then
                        paypaladp()
                    ElseIf paymethod = "Payza" Then
                        payza()
                    ElseIf paymethod = "LibertyReserve" Then
                        LR()
                    ElseIf paymethod = "MoneyBookers" Then
                        moneybooker()
                    ElseIf paymethod = "PerfectMoney" Then
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Perfect money not registered');", True)
                    ElseIf paymethod = "SolidTrustPay" Then
                        Stp()
                    End If
                End If
            Next
            dt = obj.returndatatable("select a.WithDrawl_Id,a.WithDrawl_Status ,b.UserId,b.UserName,a.WithDrawl_Date,a.WithDrawl_Amount,a.WithDrawl_Remarks from CF_WithDrawl a join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status='Request' ", dt)
            If dt.Rows.Count > 0 Then


                GVMembersList.DataSource = dt
                GVMembersList.DataBind()
            End If
        End If
    End Sub

    Public Sub moneybooker()
        Dim amt As Double
        Dim dt As New DataTable
        dt = obj.returndatatable("select * from cf_withdrawl where withdrawl_Id='" + ViewState("Wd_Id") + "'", dt)
        If dt.Rows.Count > 0 Then
            amt = dt.Rows(0).Item("WithDrawl_Amount").ToString()
        End If

        Dim post_url = ""
        post_url = "https://www.moneybookers.com/app/pay.pl"

        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("action", "prepare")
        post_values.Add("email", "ol039.orangelab@gmail.com")
        post_values.Add("password", "7e0eec2a0042449f2f099b044a3aead2")
        post_values.Add("amount", amt)
        post_values.Add("currency", "USD")
        post_values.Add("language", "EN")

        post_values.Add("bnf_email", ViewState("payeremail"))
        post_values.Add("subject", "Ready")
        post_values.Add("note", "Success")
        Dim post_string As String = ""
        For Each field As KeyValuePair(Of String, String) In post_values
            post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
        Next
        post_string = Left(post_string, Len(post_string) - 1)

        Dim response As String = String.Empty

        Dim myWriter As StreamWriter = Nothing


        Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
        objRequest.Method = "POST"
        objRequest.ContentLength = post_string.Length
        objRequest.ContentType = "application/x-www-form-urlencoded"


        myWriter = New StreamWriter(objRequest.GetRequestStream())
        myWriter.Write(post_string)
        myWriter.Close()


        Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
        Dim sr As New StreamReader(objResponse.GetResponseStream())
        Dim result As String = ""
        Dim strTemp As String = ""
        Dim flag As Boolean = True
        While flag
            strTemp = sr.ReadLine()
            If strTemp IsNot Nothing Then
                result += strTemp
            Else
                flag = False
            End If
        End While

        response = result
        ' decode the response string
        response = HttpUtility.UrlDecode(response)
        successLabel.Text = response.ToString
        sr.Close()


    End Sub

    Public Sub payza()

        Dim amt As Double
        Dim dt As New DataTable
        dt = obj.returndatatable("select * from cf_withdrawl where withdrawl_Id='" + ViewState("Wd_Id") + "'", dt)
        If dt.Rows.Count > 0 Then
            amt = dt.Rows(0).Item("WithDrawl_Amount").ToString()
        End If
        Dim post_url = ""
        post_url = "https://api.payza.com/svc/api.svc/sendmoney"
        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("USER", "ol039.orangelab@gmail.com")
        post_values.Add("PASSWORD", "TGHTRe4zxNzI9gWU")
        post_values.Add("AMOUNT", amt)
        post_values.Add("CURRENCY", "USD")
        post_values.Add("RECEIVEREMAIL", ViewState("payeremail"))
        post_values.Add("PURCHASETYPE", "3")
        post_values.Add("TESTMODE", "1")
        Dim post_string As String = ""
        For Each field As KeyValuePair(Of String, String) In post_values
            post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
        Next
        post_string = Left(post_string, Len(post_string) - 1)

        Dim response As String = String.Empty

        Dim myWriter As StreamWriter = Nothing


        Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
        objRequest.Method = "POST"
        objRequest.ContentLength = post_string.Length
        objRequest.ContentType = "application/x-www-form-urlencoded"


        myWriter = New StreamWriter(objRequest.GetRequestStream())
        myWriter.Write(post_string)
        myWriter.Close()


        Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
        Dim sr As New StreamReader(objResponse.GetResponseStream())
        Dim result As String = ""
        Dim strTemp As String = ""
        Dim flag As Boolean = True
        While flag
            strTemp = sr.ReadLine()
            If strTemp IsNot Nothing Then
                result += strTemp
            Else
                flag = False
            End If
        End While

        response = result
        ' decode the response string
        response = HttpUtility.UrlDecode(response)
        Dim arrResult As String() = result.Split("&"c)
        Dim htResponse As New Hashtable()
        Dim responseItemArray As String()
        For Each responseItem As String In arrResult
            responseItemArray = responseItem.Split("="c)
            htResponse.Add(responseItemArray(0), responseItemArray(1))
        Next

        ' Dim strAck As String = htResponse("ACK").ToString()
        Dim strAck As String = htResponse("RETURNCODE").ToString()
        Dim strstatus As String = htResponse("DESCRIPTION").ToString()
        Dim str2 As String = strstatus.Replace("%20", " ")
        Dim str3 As String = str2.Replace("%2f", "")
        Dim str4 As String = str3.Substring(48, 7)

        Dim strtest As String = htResponse("TESTMODE").ToString()
        If str4 = "success" Then
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)

            Dim cmd As New SqlCommand
            Dim query As String
            query = "update CF_WithDrawl set WithDrawl_Status= 'True' where WithDrawl_Id='" + ViewState("Wd_Id") + "'"
            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('SUCCESS');", True)
            con.Close()
            sr.Close()
        End If
    End Sub
  
    Public Sub paypaladp()
        Dim amt As Double
        Dim dt As New DataTable
        dt = obj.returndatatable("select * from cf_withdrawl where withdrawl_Id='" + ViewState("Wd_Id") + "'", dt)
        If dt.Rows.Count > 0 Then
            amt = dt.Rows(0).Item("WithDrawl_Amount").ToString()
        End If
        Dim post_url = ""
        post_url = "https://api-3t.sandbox.paypal.com/nvp"
        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("USER", "ol039._1362122228_biz_api1.gmail.com")
        post_values.Add("PWD", "1362122253")
        post_values.Add("SIGNATURE", "AplaCboJ3lGmK6FPfdsnphIHhlaSAk5wWor7W-6ybUlu3B3kNlPL6hlr")
        post_values.Add("VERSION", "2.3")
        post_values.Add("METHOD", "MassPay")
        post_values.Add("RECEIVERTYPE", "EmailAddress")
        post_values.Add("L_EMAIL0", ViewState("payeremail"))
        post_values.Add("L_AMT0", amt)
        post_values.Add("CURRENCYCODE", "USD")

        Dim post_string As String = ""
        For Each field As KeyValuePair(Of String, String) In post_values
            post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
        Next
        post_string = Left(post_string, Len(post_string) - 1)
        Dim responsedata As String = String.Empty
        Dim myWriter As StreamWriter = Nothing
        Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
        objRequest.Method = "POST"
        objRequest.ContentLength = post_string.Length
        objRequest.ContentType = "application/x-www-form-urlencoded"


        myWriter = New StreamWriter(objRequest.GetRequestStream())
        myWriter.Write(post_string)
        myWriter.Close()


        Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
        Dim sr As New StreamReader(objResponse.GetResponseStream())
        Dim result As String = ""
        Dim strTemp As String = ""
        Dim flag As Boolean = True
        While flag
            strTemp = sr.ReadLine()
            If strTemp IsNot Nothing Then
                result += strTemp
            Else
                flag = False
            End If
        End While

        responsedata = result
        ' decode the response string
        responsedata = HttpUtility.UrlDecode(responsedata)
        Dim arrResult As String() = result.Split("&"c)
        Dim htResponse As New Hashtable()
        Dim responseItemArray As String()
        For Each responseItem As String In arrResult
            responseItemArray = responseItem.Split("="c)
            htResponse.Add(responseItemArray(0), responseItemArray(1))
        Next

        Dim strAck As String = htResponse("ACK").ToString()


        If strAck = "Success" Then
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)

            Dim cmd As New SqlCommand
            Dim query As String

            query = "update CF_WithDrawl set WithDrawl_Status= 'True' where WithDrawl_Id='" + ViewState("Wd_Id") + "'"
            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('SUCCESS');", True)
            'successLabel.Text = strAck.ToString
            'Dim Script As String = "alert('" + strAck.ToString() + "');"
            'ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Script, True)

            sr.Close()
        Else
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Payment failure');", True)
        End If
    End Sub
    Public Sub LR()
        Dim amt As Double
        Dim dt As New DataTable
        dt = obj.returndatatable("select * from cf_withdrawl where withdrawl_Id='" + ViewState("Wd_Id") + "'", dt)
        If dt.Rows.Count > 0 Then
            amt = dt.Rows(0).Item("WithDrawl_Amount").ToString()
        End If

        Dim post_url = ""
        post_url = "https://api2.libertyreserve.com/nvp/transfer?"
        Dim payee As String = ""

        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("id", ViewState("value1"))
        post_values.Add("account", "U4934418")
        post_values.Add("api", "Rizwanapi")
        post_values.Add("token", "8175DC012518BF2A95B96B657C1DEBC16E24F8EEBC17EE45A8525D3D92EF2FDB")
        post_values.Add("type", "transfer")
        post_values.Add("payee", ViewState("payeremail"))

        post_values.Add("currency", "usd")
        post_values.Add("amount", amt)
        post_values.Add("memo", "test")
        post_values.Add("private", "true")
        post_values.Add("purpose", "salary ")

        Dim post_string As String = ""
        For Each field As KeyValuePair(Of String, String) In post_values
            post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
        Next
        post_string = Left(post_string, Len(post_string) - 1)

        Dim response As String = String.Empty

        Dim myWriter As StreamWriter = Nothing


        Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
        objRequest.Method = "POST"
        objRequest.ContentLength = post_string.Length
        objRequest.ContentType = "application/x-www-form-urlencoded"


        myWriter = New StreamWriter(objRequest.GetRequestStream())
        myWriter.Write(post_string)
        myWriter.Close()
        Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
        Dim sr As New StreamReader(objResponse.GetResponseStream())
        Dim result As String = ""
        Dim strTemp As String = ""
        Dim flag As Boolean = True
        While flag
            strTemp = sr.ReadLine()
            If strTemp IsNot Nothing Then
                result += strTemp
            Else
                flag = False
            End If
        End While

        response = result
        ' decode the response string
        response = HttpUtility.UrlDecode(response)
        successLabel.Text = response.ToString
        Dim alert As String = "alert('" + response + "')"
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", alert, True)
        'Dim strack As String = response("DESCRIPTION").ToString

        sr.Close()
    End Sub

    Public Sub Stp()
        Dim amt As Double
        Dim dt As New DataTable
        dt = obj.returndatatable("select * from cf_withdrawl where withdrawl_Id='" + ViewState("Wd_Id") + "'", dt)
        If dt.Rows.Count > 0 Then
            amt = dt.Rows(0).Item("WithDrawl_Amount").ToString()
        End If
        Dim post_url = ""
        post_url = "https://solidtrustpay.com/accapi/process.php?"
        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("api_id", "rizwan")
        post_values.Add("api_pwd", "81dc9bdb52d04dc20036dbd8313ed055")
        post_values.Add("user", ViewState("payeremail"))
        post_values.Add("amount", amt)
        post_values.Add("item_id", ViewState("Wd_Id"))
        post_values.Add("currency", "USD")
        post_values.Add("testmode", "1")
        Dim post_string As String = ""
        For Each field As KeyValuePair(Of String, String) In post_values
            post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
        Next
        post_string = Left(post_string, Len(post_string) - 1)
        Dim response As String = String.Empty
        Dim myWriter As StreamWriter = Nothing
        Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
        objRequest.Method = "POST"
        objRequest.ContentLength = post_string.Length
        objRequest.ContentType = "application/x-www-form-urlencoded"
        myWriter = New StreamWriter(objRequest.GetRequestStream())
        myWriter.Write(post_string)
        myWriter.Close()
        Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
        Dim sr As New StreamReader(objResponse.GetResponseStream())
        Dim result As String = ""
        Dim strTemp As String = ""
        Dim flag As Boolean = True
        While flag
            strTemp = sr.ReadLine()
            If strTemp IsNot Nothing Then
                result += strTemp
            Else
                flag = False
            End If
        End While

        response = result
        ' decode the response string
        response = HttpUtility.UrlDecode(response)
        Dim alert As String = "alert('" + response + "')"
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", alert, True)
        Dim arrResult As String() = result.Split("&"c)
        If Not arrResult(0) = "success" Then
            Dim htResponse As New Hashtable()
            Dim responseItemArray As String()
            For Each responseItem As String In arrResult
                responseItemArray = responseItem.Split("="c)
                htResponse.Add(responseItemArray(0), responseItemArray(1))
            Next

            Dim strAck As String = htResponse("Transaction ID ").ToString()

            Dim strAck1 As String = strAck.Substring(24, 8)
            If strAck1 = "ACCEPTED" Then
                Dim con As New SqlConnection
                con = New SqlConnection(obj.ConnectionString)

                Dim cmd As New SqlCommand
                Dim query As String
                query = "update CF_WithDrawl set WithDrawl_Status= 'True' where WithDrawl_Id='" + ViewState("Wd_Id") + "'"
                con.Open()
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                con.Close()
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('SUCCESS');", True)
                'successLabel.Text = response.ToString
                sr.Close()
            Else
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Payment failure');", True)
            End If
        End If
    End Sub
    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GVMembersList.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub
    Private Sub bindgrid()

        Dim con As New SqlConnection(obj.ConnectionString())
        Dim da As New SqlDataAdapter("select a.WithDrawl_Id,b.UserId,a.WithDrawl_Status, b.UserName,a.WithDrawl_Date,a.WithDrawl_Amount,a.WithDrawl_Remarks from CF_WithDrawl a join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status='Request'  ", con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GVMembersList.DataSource = ds
        GVMembersList.DataBind()
    End Sub
    Protected Sub Open_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim str As String = ""
        Dim obj As New ClassFunctions
        Dim dt1 As New DataTable
        dt1 = obj.returndatatable("select a.WithDrawl_Id,b.UserId,a.WithDrawl_Status, b.UserName,a.WithDrawl_Date,a.WithDrawl_Amount,a.WithDrawl_Remarks from CF_WithDrawl a  join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status='HOLD' ", dt1)
        If dt1.Rows.Count > 0 Then
                GVMembersList.DataSource = dt1
            GVMembersList.DataBind()
        Else
            GVMembersList.DataSource = dt1
            GVMembersList.DataBind()

        End If
      
    End Sub
    Protected Sub Close_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim str As String = ""
        Dim obj As New ClassFunctions
        Dim dt As New DataTable
        dt = obj.returndatatable("select a.WithDrawl_Id,b.UserId, b.UserName,a.WithDrawl_Date,a.WithDrawl_Status,a.WithDrawl_Amount,a.WithDrawl_Remarks from CF_WithDrawl a  join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status='REJECTED' ", dt)

        If dt.Rows.Count > 0 Then
            GVMembersList.DataSource = dt
            GVMembersList.DataBind()
        Else
            GVMembersList.DataSource = dt
            GVMembersList.DataBind()

        End If
        
    End Sub
    Protected Sub All_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim str As String = ""
        Dim obj As New ClassFunctions
        Dim dt As New DataTable
        dt = obj.returndatatable("select a.WithDrawl_Id,b.UserId, b.UserName,a.WithDrawl_Date,a.WithDrawl_Status,a.WithDrawl_Amount,a.WithDrawl_Remarks from CF_WithDrawl a  join aspnet_Users b on a.WithDrawl_UserId=b.UserId and WithDrawl_Status<>'true'  ", dt)

        If dt.Rows.Count > 0 Then
            GVMembersList.DataSource = dt
            GVMembersList.DataBind()
        Else
            GVMembersList.DataSource = dt
            GVMembersList.DataBind()

        End If

    End Sub
End Class
