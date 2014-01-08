Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports System.IO

Partial Class Account_WithDraw
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim SelectedIndexId As String = ""
    Dim userid As Guid
    Dim withdrawID As String = ""


    Protected Sub Page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            Dim userid As String = Session("User_Id").ToString()

            Dim str As String = obj.Returnsinglevalue("select user_Phone from cf_user where [User_Id]='" + userid + "'")
            If str = "0" Then
                Response.Redirect("~/account/editprofile.aspx", True)
            End If

        End If
        If Not Session("User_Id") = Nothing Then
            Dim userId As Guid = Membership.GetUser.ProviderUserKey()
            Dim uids As String = Convert.ToString(userId)
            Dim d4 As New DataTable
            Dim Deposit As Double
            Dim Bonus As Double
            Dim WithDrawal As Double
            Dim Penalty As Double
            Dim Balance As Double

            d4 = obj.returndatatable("select distinct(Deposit_PackageId) from  CF_Deposit where Deposit_UserId='" + uids + "' and Deposit_Status='True' ", d4)


            If d4.Rows.Count > 0 Then
                For i As Integer = 0 To d4.Rows.Count - 1
                    Dim RBPayment As New RadioButton
                    Dim amount As String = obj.Returnsinglevalue("select sum(Deposit_Amount) from CF_Deposit Where Deposit_UserId='" + uids + "' and Deposit_PackageId='" + d4.Rows(i).Item("Deposit_PackageId").ToString() + "' and  Deposit_Status='True' ")
                    RBPayment.ID = d4.Rows(i).Item("Deposit_PackageId").ToString()
                    'RBPayment.AutoPostBack = True
                    RBPayment.Text = obj.Returnsinglevalue("select Package_name from CF_Package where Package_Id='" + d4.Rows(i).Item("Deposit_PackageId").ToString() + "'")
                    RBPayment.CssClass = "pack_name_check"
                    RBPayment.GroupName = "Pay"
                    'RBPayment.Checked = False

                    RbPackage.Controls.Add(RBPayment)
                    Dim br2 As New HtmlGenericControl("br")
                    RbPackage.Controls.Add(br2)

                    Dim lb2 As New Label

                    lb2.Text = "Package Balance : "
                    lb2.CssClass = "txt_small_package_balance"
                    'AddHandler RBPayment.CheckedChanged, AddressOf RBPayment_CheckedChanged
                    RbPackage.Controls.Add(lb2)

                    Dim lb1 As New Label
                    lb1.ID = "txtvalue_" + i.ToString

                    Deposit = obj.Returnsinglevalue("select sum(Deposit_Amount) from CF_Deposit a inner join cf_user b on b.user_userid=a.Deposit_UserId where  b.user_userid='" + uids + "'and  Deposit_PackageId='" + d4.Rows(i).Item("Deposit_PackageId").ToString() + "' and Deposit_Status='True' ")
                    'Bonus = obj.Returnsinglevalue("select sum(Bonus_Amount) from CF_Bonus a inner join cf_user b on b.user_userid=a.Bonus_Userid where  user_id='" + uids + "'")
                    WithDrawal = obj.Returnsinglevalue("select sum(WithDrawl_Amount) from CF_WithDrawl a inner join cf_user b on b.user_userid=a.WithDrawl_UserId where b.user_userid='" + uids + "' and withdrawl_PackageId='" + d4.Rows(i).Item("Deposit_PackageId").ToString() + "' and  WithDrawl_Status='True'")
                    'Penalty = obj.Returnsinglevalue("select SUM(Penalty_Amount) from CF_Penalty  a inner join cf_user b on b.user_userid=a.Penalty_Userid where user_id='" + uids + "'")
                    Balance = ((Deposit + Bonus) - (WithDrawal + Penalty))
                    lb1.Text = Val(Balance)
                    lb1.CssClass = "txt_small_package_balance"
                    'AddHandler RBPayment.CheckedChanged, AddressOf RBPayment_CheckedChanged
                    RbPackage.Controls.Add(lb1)
                    Dim br1 As New HtmlGenericControl("br")
                    RbPackage.Controls.Add(br1)
                Next

                

            Else
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Dont have Any Package');", True)
            End If
            SelectedIndexId = Session("User_Id")
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub btnwithdraw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnwithdraw.Click
        userid = Membership.GetUser.ProviderUserKey()
        Dim rbpid As String = ""
        'Dim rpackid() As String
        Dim rbid As String = ""
        Dim rbamt As String = ""
        Dim Deposit As Double
        Dim Bonus As Double
        Dim WithDrawal As Double
        Dim Penalty As Double
        Dim Balance As Double
        'If txtwithdraw.Text.Trim <= Val(lblcurrbalance.Text) Then
        Try
            obj.strMode = "Add"


            If obj.strMode = "" Then

                Exit Sub
            End If
            Select Case obj.strMode
                Case "Add"


                    withdrawID = obj.getIndexKey()

                Case "Modify"

                    withdrawID = SelectedIndexId

                Case "Delete"



            End Select
            Dim userId As Guid = Membership.GetUser.ProviderUserKey()
            Dim uids As String = Convert.ToString(userId)

            Dim d4 As New DataTable
            d4 = obj.returndatatable("select distinct(Deposit_PackageId) from   CF_Deposit where  Deposit_UserId='" + uids + "' and Deposit_Status='True'", d4)

            Dim rbtn1 As RadioButton

            'Dim i1 As Integer = 0
            For Each Count In d4.Rows


                If d4.Rows.Count > 0 Then


                    Dim rbtnnam As String = String.Empty

                    Dim ctl1 As Control
                    For Each ctl1 In RbPackage.Controls
                        If TypeOf ctl1 Is RadioButton Then
                            rbtn1 = DirectCast(ctl1, RadioButton)

                            If rbtn1.Checked = True Then
                                rbpid = rbtn1.ID.ToString()
                                'rpackid = rbpid.Split("_")
                                'rbid = rpackid(0)
                                Deposit = obj.Returnsinglevalue("select sum(Deposit_Amount) from CF_Deposit a inner join cf_user b on b.user_userid=a.Deposit_UserId where  b.user_userid='" + uids + "'and  Deposit_PackageId='" + rbpid + "' and Deposit_Status='True' ")
                                'Bonus = obj.Returnsinglevalue("select sum(Bonus_Amount) from CF_Bonus a inner join cf_user b on b.user_userid=a.Bonus_Userid where  user_id='" + uids + "'")
                                WithDrawal = obj.Returnsinglevalue("select sum(WithDrawl_Amount) from CF_WithDrawl a inner join cf_user b on b.user_userid=a.WithDrawl_UserId where b.user_userid='" + uids + "' and withdrawl_PackageId='" + rbpid + "' and  WithDrawl_Status='True'")
                                'Penalty = obj.Returnsinglevalue("select SUM(Penalty_Amount) from CF_Penalty  a inner join cf_user b on b.user_userid=a.Penalty_Userid where user_id='" + uids + "'")
                                Balance = ((Deposit + Bonus) - (WithDrawal + Penalty))
                                'lb1.Text = Val(Balance)
                                rbamt = Val(Balance)
                                Exit For


                            End If
                        End If

                    Next
                End If

            Next
            'check if payment method is selected
            Dim paymethod As String = ""
            If (rbPM.Checked) Then
                If (txtPMID.Text <> "" And txtPMName.Text <> "") Then
                    paymethod = "PerfectMoney"
                End If
            ElseIf (rbPP.Checked) Then
                If (txtPPID.Text <> "" And txtPPName.Text <> "") Then
                    paymethod = "Paypal"
                End If
            ElseIf (rbPZ.Checked) Then
                If (txtPZID.Text <> "" And txtPZName.Text <> "") Then
                    paymethod = "Payza"
                End If
            ElseIf (rbSTP.Checked) Then
                If (txtSTPID.Text <> "" And txtSTPName.Text <> "") Then
                    paymethod = "SolidTrustPay"
                End If
            End If

            If Not rbpid = "" And Not txtwithdraw.Text = "" And Not paymethod = "" Then
                Dim percent As String = obj.Returnsinglevalue("select Package_WDFee from CF_Package where Package_Id='" + rbpid + "'")
                Dim perfectamt As Double = rbamt * percent / 100
                If txtwithdraw.Text <= Val(perfectamt) Then
                    Dim userid1 As String = Session("User_Id").ToString()
                    Dim d3 As New DataTable
                    d3 = obj.returndatatable("select * from CF_User where User_Id='" + userid1 + "'", d3)
                    If d3.Rows.Count > 0 Then
                        If d3.Rows(0).Item("user_AutoWD").ToString = "True" Then

                            Dim status As String = "PENDING"
                            Dim strHostName As String
                            Dim strIPAddress As String
                            strHostName = System.Net.Dns.GetHostName()
                            strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
                            Dim ipcurrno As String = getCountry(strIPAddress)
                            Dim countryname As String = obj.Returnsinglevalue("select con_name from IP where ipno_from <= '" + ipcurrno + "' and ipno_to>='" + ipcurrno + "'")
                            Dim con As New SqlConnection
                            con = New SqlConnection(obj.ConnectionString)
                            con.Open()
                            Dim cmd As New SqlCommand
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandText = "SP_CF_AutoWithDrawl"
                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                            cmd.Parameters.Add(New SqlParameter("@WithDrawl_Id", SqlDbType.VarChar, 10)).Value = ID
                            cmd.Parameters.Add(New SqlParameter("@WithDrawl_UserId", SqlDbType.UniqueIdentifier)).Value = userId
                            cmd.Parameters.Add(New SqlParameter("@WithDrawl_Amount", SqlDbType.Decimal, 18, 2)).Value = txtwithdraw.Text
                            cmd.Parameters.Add(New SqlParameter("@WithDrawl_Date", SqlDbType.DateTime)).Value = DateAndTime.Now
                            cmd.Parameters.Add(New SqlParameter("@WithDrawl_Status", SqlDbType.VarChar, 10)).Value = status
                            cmd.Parameters.Add(New SqlParameter("@WithDrawl_SysIp", SqlDbType.VarChar, 100)).Value = strIPAddress
                            cmd.Parameters.Add(New SqlParameter("@withdrawl_CountryName", SqlDbType.VarChar, 100)).Value = countryname
                            cmd.Parameters.Add(New SqlParameter("@withDrawl_PackageId", SqlDbType.VarChar, 100)).Value = rbpid
                            cmd.Parameters.Add(New SqlParameter("@withDrawl_PayName", SqlDbType.VarChar, 100)).Value = paymethod
                            cmd.Parameters.Add(New SqlParameter("@Auto_WithDrawl", SqlDbType.VarChar, 10)).Value = "instant"
                            cmd.Parameters.Add(New SqlParameter("@withdrawl_TrnsId", SqlDbType.VarChar, 100)).Value = ""


                            'Dim uniqueid As String
                            'uniqueid = obj.Returnsinglevalue("select max( withdrawl_TrnsId) from CF_WithDrawl")
                            'Dim un1 As Integer
                            'Dim un2 As Integer

                            'If Not uniqueid = 0 Then
                            '    un1 = Convert.ToInt32(uniqueid)
                            '    un2 = un1 + 1


                            'Else
                            '    uniqueid = obj.Returnsinglevalue("select Settings_WithdrawTrnsno from CF_Settings")
                            '    un2 = uniqueid
                            'End If
                            'cmd.Parameters.Add(New SqlParameter("@withdrawl_TrnsId", SqlDbType.VarChar, 100)).Value = un2
                            cmd.ExecuteNonQuery()
                            cmd.Parameters.Clear()

                            ViewState("Wd_Id") = ID




                            paymethod = obj.Returnsinglevalue("select b.CustomProcessing_Name from CF_User a join CF_CustomProcessing b on a.user_PaymentTypeId=b.CustomProcessing_id where a.User_Id='" + userid1 + "'")
                            'Dim paymehodid As String = obj.Returnsinglevalue("select b.CustomProcessing_Id from CF_User a join CF_CustomProcessing b on a.user_PaymentTypeId=b.CustomProcessing_id where a.User_Id='" + userid1 + "'")

                            If paymethod = "Paypal" Then
                                paypaladp()
                            ElseIf paymethod = "Payza" Then
                                payza()
                            ElseIf paymethod = "LibertyReserve" Then
                                LR()
                            ElseIf paymethod = "MoneyBookers" Then
                                moneybooker()
                            ElseIf paymethod = "PerfectMoney" Then
                                PM()
                            ElseIf paymethod = "SolidTrustPay" Then
                                Stp()
                            End If


                        Else
                            Dim status As String = "PENDING"
                            Dim strHostName As String
                            Dim strIPAddress As String
                            strHostName = System.Net.Dns.GetHostName()
                            strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
                            Dim ipcurrno As String = getCountry(strIPAddress)
                            Dim countryname As String = obj.Returnsinglevalue("select con_name from IP where ipno_from <= '" + ipcurrno + "' and ipno_to>='" + ipcurrno + "'")
                            Using con As New SqlConnection(obj.ConnectionString)
                                con.Open()
                                Dim cmd As New SqlCommand
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.CommandText = "SP_CF_WithDrawl"
                                cmd.Connection = con
                                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                                cmd.Parameters.Add(New SqlParameter("@WithDrawl_Id", SqlDbType.VarChar, 10)).Value = withdrawID

                                cmd.Parameters.Add(New SqlParameter("@WithDrawl_UserId", SqlDbType.UniqueIdentifier)).Value = userId
                                cmd.Parameters.Add(New SqlParameter("@WithDrawl_Amount", SqlDbType.Decimal, 18, 2)).Value = txtwithdraw.Text
                                cmd.Parameters.Add(New SqlParameter("@WithDrawl_Date", SqlDbType.DateTime)).Value = DateAndTime.Now
                                cmd.Parameters.Add(New SqlParameter("@WithDrawl_Status", SqlDbType.VarChar, 10)).Value = status
                                cmd.Parameters.Add(New SqlParameter("@WithDrawl_SysIp", SqlDbType.VarChar, 100)).Value = strIPAddress
                                cmd.Parameters.Add(New SqlParameter("@withdrawl_CountryName", SqlDbType.VarChar, 100)).Value = countryname
                                cmd.Parameters.Add(New SqlParameter("@withDrawl_PackageId", SqlDbType.VarChar, 100)).Value = rbpid
                                cmd.Parameters.Add(New SqlParameter("@withDrawl_Payname", SqlDbType.VarChar, 100)).Value = paymethod
                                cmd.Parameters.Add(New SqlParameter("@Auto_WithDrawl", SqlDbType.VarChar, 10)).Value = "manual"
                                cmd.Parameters.Add(New SqlParameter("@withdrawl_TrnsId", SqlDbType.VarChar, 100)).Value = ""

                                'Dim uniqueid As String
                                'uniqueid = obj.Returnsinglevalue("select max( withdrawl_TrnsId) from CF_WithDrawl")
                                'Dim un1 As Integer
                                'Dim un2 As Integer

                                'If Not uniqueid = 0 Then
                                '    un1 = Convert.ToInt32(uniqueid)
                                '    un2 = un1 + 1


                                'Else
                                '    uniqueid = obj.Returnsinglevalue("select Settings_WithdrawTrnsno from CF_Settings")
                                '    un2 = uniqueid
                                'End If
                                'cmd.Parameters.Add(New SqlParameter("@withdrawl_TrnsId", SqlDbType.VarChar, 100)).Value = un2
                                cmd.ExecuteNonQuery()
                                cmd.Parameters.Clear()

                                Try
                                    If paymethod = "Paypal" Then
                                        paypaladp()
                                    ElseIf paymethod = "Payza" Then
                                        payza()
                                    ElseIf paymethod = "LibertyReserve" Then
                                        LR()
                                    ElseIf paymethod = "MoneyBookers" Then
                                        moneybooker()
                                    ElseIf paymethod = "PerfectMoney" Then
                                        PM()
                                    ElseIf paymethod = "SolidTrustPay" Then
                                        Stp()
                                    End If
                                Catch ex As Exception
                                    errorblock.Visible = True
                                    txtError.Text = "The withdraw request has been registered but the payment failed. " + ex.Message
                                    Dim errQuery = "update CF_WithDrawl set WithDrawl_Remarks= '" + ex.Message + "' where WithDrawl_Id='" + withdrawID + "'"
                                    cmd = New SqlCommand(errQuery, con)
                                    cmd.ExecuteNonQuery()
                                End Try

                            End Using
                        End If
                    End If
                Else
                    errorblock.Visible = True
                    txtError.Text = "The given amount exceeds the available amount for the selected package (fees included)"
                    GoTo A

                End If
            ElseIf txtwithdraw.Text = "" Then
                errorblock.Visible = True
                txtError.Text = "Please enter a valid amount"
                GoTo A
            ElseIf paymethod = "" Then
                successblock.Visible = True
                txtError.Text = "Please select a payment method and fill the necessary information"
                GoTo A
            Else
                errorblock.Visible = True
                txtError.Text = "Plese Choose atleast one Package"
                GoTo A
            End If

            Dim uid As Guid = Membership.GetUser.ProviderUserKey()
            Dim uid1 As String = Convert.ToString(uid)

            ClearForm()
A:
        Catch ex As Exception
            errorblock.Visible = True
            txtError.Text = "The withdraw request has been registered but the payment failed. " + ex.Message
        End Try

    End Sub

    'Private Sub RBPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MsgBox("rb")

    'End Sub
    Public Sub moneybooker()
        Dim post_url = ""
        post_url = "https://www.moneybookers.com/app/pay.pl"

        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("action", "prepare")
        post_values.Add("email", "ol039.orangelab@gmail.com")
        post_values.Add("password", "7e0eec2a0042449f2f099b044a3aead2")
        post_values.Add("amount", txtwithdraw.Text)
        post_values.Add("currency", "USD")
        post_values.Add("language", "EN")

        post_values.Add("bnf_email", "ol018.orangelab@gmail.com")
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
        Dim dtp As New DataTable()

        Dim payeraccname As String = ""

        'dtp = obj.returndatatable("select * from [UserPaymentDet] where Payment_UserId ='" + userid.ToString + "'", dtp)
        Dim payeremail As String = ""
        payeremail = txtPZID.Text
        payeraccname = txtPZName.Text
        If dtp.Rows.Count > 0 Then
            For i As Integer = 0 To dtp.Rows.Count
                'payeremail = dtp.Rows(i).Item("UserPaymentAccDet")
                'payeraccname = dtp.Rows(i).Item("UserPaymentAccDetName")

            Next


        End If
        Dim post_url = ""
        post_url = "https://api.payza.com/svc/api.svc/sendmoney"
        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("USER", "ol039.orangelab@gmail.com")
        post_values.Add("PASSWORD", "TGHTRe4zxNzI9gWU")
        post_values.Add("AMOUNT", txtwithdraw.Text)
        post_values.Add("CURRENCY", "USD")
        post_values.Add("RECEIVEREMAIL", payeremail)
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

            successblock.Visible = True
            txtSuccess.Text = "Your withdrawal request has been successfully created. Your Payza account (" & txtPZID.Text & ") will be sent the money within 24h"

            'Dim con As New SqlConnection
            'con = New SqlConnection(obj.ConnectionString)

            'Dim cmd As New SqlCommand
            'Dim query As String


            'query = "update CF_WithDrawl set WithDrawl_Status= 'True' where WithDrawl_Id='" + ViewState("Wd_Id") + "'"
            'con.Open()
            'cmd = New SqlCommand(query, con)
            'cmd.ExecuteNonQuery()
            'con.Close()
            sr.Close()
        Else
            errorblock.Visible = True
            txtError.Text = "The withdraw request has been registered but the payment failed. Please contact the system administrator"
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            Dim cmd As New SqlCommand
            Dim errQuery = "update CF_WithDrawl set WithDrawl_Remarks= '" & result & "' where WithDrawl_Id='" + withdrawID + "'"
            con.Open()
            cmd = New SqlCommand(errQuery, con)
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Public Sub paypaladp()
        Dim dtp As New DataTable()

        Dim payeraccname As String = ""

        dtp = obj.returndatatable("select * from [UserPaymentDet] where Payment_UserId ='" + userid.ToString + "'", dtp)
        Dim payeremail As String = ""
        payeremail = txtPPID.Text
        payeraccname = txtPPName.Text
        If dtp.Rows.Count > 0 Then
            For i As Integer = 0 To dtp.Rows.Count
                'payeremail = dtp.Rows(i).Item("UserPaymentAccDet")
                'payeraccname = dtp.Rows(i).Item("UserPaymentAccDetName")
            Next


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
        post_values.Add("L_EMAIL0", payeremail)
        post_values.Add("L_AMT0", txtwithdraw.Text)
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
            successblock.Visible = True
            txtSuccess.Text = "Your withdrawal request has been successfully created. Your Paypal account (" & txtPPID.Text & ") will be sent the money within 24h"
            sr.Close()
        Else
            errorblock.Visible = True
            txtError.Text = "The withdraw request has been registered but the payment failed. Please contact the system administrator"
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            Dim cmd As New SqlCommand
            Dim errQuery = "update CF_WithDrawl set WithDrawl_Remarks= '" & result & "' where WithDrawl_Id='" + withdrawID + "'"
            con.Open()
            cmd = New SqlCommand(errQuery, con)
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub
    Public Sub LR()
        Dim dtp As New DataTable()

        Dim payeraccname As String = ""

        dtp = obj.returndatatable("select * from [UserPaymentDet] where Payment_UserId ='" + userid.ToString + "'", dtp)
        Dim payeremail() As Array
        If dtp.Rows.Count > 0 Then
            For i As Integer = 0 To dtp.Rows.Count

                payeremail = dtp.Rows(i).Item("UserPaymentAccDet")
                payeraccname = dtp.Rows(i).Item("UserPaymentAccDetName")

            Next


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
        post_values.Add("payee", dtp.Rows(0).Item("UserPaymentAccDet"))

        post_values.Add("currency", "USD")
        post_values.Add("amount", txtwithdraw.Text)
        post_values.Add("memo", "test")
        post_values.Add("private", "false")
        post_values.Add("purpose", "service")

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
        successLabel.Text = response.ToString
        'Dim strack As String = response("DESCRIPTION").ToString

        sr.Close()
    End Sub

    Public Sub Stp()
        Dim dtp As New DataTable()

        Dim payeraccname As String = ""

        dtp = obj.returndatatable("select * from [UserPaymentDet] where Payment_UserId ='" + userid.ToString + "'", dtp)
        Dim payeremail As String = ""
        payeremail = txtSTPID.Text
        payeraccname = txtSTPName.Text
        If dtp.Rows.Count > 0 Then
            For i As Integer = 0 To dtp.Rows.Count

                'payeremail = dtp.Rows(i).Item("UserPaymentAccDet")
                'payeraccname = dtp.Rows(i).Item("UserPaymentAccDetName")

            Next


        End If
        Dim post_url = ""
        post_url = "https://solidtrustpay.com/accapi/process.php?"
        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("api_id", "rizwan")
        post_values.Add("api_pwd", "81dc9bdb52d04dc20036dbd8313ed055")
        post_values.Add("user", payeremail)
        post_values.Add("amount", txtwithdraw.Text)
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
        Dim arrResult As String() = result.Split("&"c)
        Dim htResponse As New Hashtable()
        Dim responseItemArray As String()
        For Each responseItem As String In arrResult
            responseItemArray = responseItem.Split("="c)
            If (responseItemArray.Count > 1) Then
                htResponse.Add(responseItemArray(0), responseItemArray(1))
            End If
        Next

        Dim strAck As String = ""
        If (htResponse.ContainsKey("Transaction ID")) Then
            htResponse("Transaction ID ").ToString()
        End If

        Dim strAck1 As String = ""
        If (strAck.Length > 31) Then
            strAck1 = strAck.Substring(24, 8)
        End If
        If strAck1 = "ACCEPTED" Then
            'Dim con As New SqlConnection
            'con = New SqlConnection(obj.ConnectionString)

            'Dim cmd As New SqlCommand
            'Dim query As String
            'query = "update CF_WithDrawl set WithDrawl_Status= 'True' where WithDrawl_Id='" + ViewState("Wd_Id") + "'"
            'con.Open()
            'cmd = New SqlCommand(query, con)
            'cmd.ExecuteNonQuery()
            'con.Close()
            successblock.Visible = True
            txtSuccess.Text = "Your withdrawal request has been successfully created. Your SolidTrustPay account (" & txtSTPID.Text & ") will be sent the money within 24h"
            sr.Close()
        Else
            errorblock.Visible = True
            txtError.Text = "The withdraw request has been registered but the payment failed. Please contact the system administrator"
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            Dim cmd As New SqlCommand
            Dim errQuery = "update CF_WithDrawl set WithDrawl_Remarks= '" & result & "' where WithDrawl_Id='" + withdrawID + "'"
            con.Open()
            cmd = New SqlCommand(errQuery, con)
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub
    Private Sub PM()
        Throw New Exception("PerfectMoney is not implemented yet")
    End Sub
    Public Function getCountry(ByVal ip As String) As String

        Dim ip_seg() As String = ip.Split(".")

        Dim w As String = ip_seg(0)
        Dim x As String = ip_seg(1)
        Dim y As String = ip_seg(2)
        Dim z As String = ip_seg(3)
        Dim ipno As String = 16777216 * w + 65536 * x + 256 * y + z

        Return ipno

    End Function

    Protected Sub rbPP_CheckedChanged(sender As Object, e As EventArgs)
        divPaypal.Visible = DirectCast(sender, RadioButton).Checked
        divSolidTrustPay.Visible = False
        divPerfectMoney.Visible = False
        divPayza.Visible = False
    End Sub
    Protected Sub rbPZ_CheckedChanged(sender As Object, e As EventArgs)
        divPayza.Visible = DirectCast(sender, RadioButton).Checked
        divSolidTrustPay.Visible = False
        divPerfectMoney.Visible = False
        divPaypal.Visible = False
    End Sub
    Protected Sub rbPM_CheckedChanged(sender As Object, e As EventArgs)
        divPerfectMoney.Visible = DirectCast(sender, RadioButton).Checked
        divSolidTrustPay.Visible = False
        divPayza.Visible = False
        divPaypal.Visible = False
    End Sub
    Protected Sub rbSTP_CheckedChanged(sender As Object, e As EventArgs)
        divSolidTrustPay.Visible = DirectCast(sender, RadioButton).Checked
        divPaypal.Visible = False
        divPerfectMoney.Visible = False
        divPayza.Visible = False
    End Sub

    Private Sub ClearForm()
        txtwithdraw.Text = ""
        rbPP.Checked = False
        rbPZ.Checked = False
        rbPM.Checked = False
        rbSTP.Checked = False
        divPaypal.Visible = False
        divPayza.Visible = False
        divPerfectMoney.Visible = False
        divSolidTrustPay.Visible = False
        txtPMID.Text = ""
        txtPMName.Text = ""
        txtPPID.Text = ""
        txtPPName.Text = ""
        txtPZID.Text = ""
        txtPZName.Text = ""
        txtSTPID.Text = ""
        txtSTPName.Text = ""

        For Each ctl1 In RbPackage.Controls
            If TypeOf ctl1 Is RadioButton Then
                Dim rbtn1 = DirectCast(ctl1, RadioButton)
                rbtn1.Checked = False
            End If
        Next
    End Sub


End Class
