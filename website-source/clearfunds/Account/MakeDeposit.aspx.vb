﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.Sql
Imports System.IO
Imports System.Net
Imports System.Web.Security
Partial Class Account_MakeDeposit
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Dim selectedIndexDetIdnew As String = ""
    Dim userid1 As Guid
    Protected WithEvents resultSpan As New Global.System.Web.UI.HtmlControls.HtmlGenericControl



    Protected Sub rbCC_CheckedChanged(sender As Object, e As EventArgs)
        divCC.Visible = DirectCast(sender, RadioButton).Checked
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            Dim userid As String = Session("User_Id").ToString()

            Dim str As String = obj.Returnsinglevalue("select user_Phone from cf_user where [User_Id]='" + userid + "'")
            If str = "0" Then
                Response.Redirect("~/account/editprofile.aspx", True)
            End If

        End If

        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Dim dt2 As New DataTable()
        Dim dt3 As New DataTable()
        If Not Session("User_Id") = Nothing Then
            selectedIndexDetIdnew = Session("User_Id")
            userid1 = Membership.GetUser.ProviderUserKey()
            '  Dim dt As New DataTable()
            Dim Deposit As Double
            Dim Bonus As Double
            Dim WithDrawal As Double
            Dim Penalty As Double
            Dim Balance As Double
            Deposit = obj.Returnsinglevalue("select sum(Deposit_Amount) from CF_Deposit a inner join cf_user b on b.user_userid=a.Deposit_UserId where  user_id='" + selectedIndexDetIdnew + "' and Deposit_Status='True' ")
            Bonus = obj.Returnsinglevalue("select sum(Bonus_Amount) from CF_Bonus a inner join cf_user b on b.user_userid=a.Bonus_Userid where  user_id='" + selectedIndexDetIdnew + "'")
            WithDrawal = obj.Returnsinglevalue("select sum(WithDrawl_Amount) from CF_WithDrawl a inner join cf_user b on b.user_userid=a.WithDrawl_UserId where user_id='" + selectedIndexDetIdnew + "' and  WithDrawl_Status='True'")
            Penalty = obj.Returnsinglevalue("select SUM(Penalty_Amount) from CF_Penalty  a inner join cf_user b on b.user_userid=a.Penalty_Userid where user_id='" + selectedIndexDetIdnew + "'")
            Balance = ((Deposit + Bonus) - (WithDrawal + Penalty))



            dt3 = obj.returndatatable("select CustomProcessing_id, CustomProcessing_Name  from dbo.CF_CustomProcessing", dt3)
            Dim counts As Integer = 0
            Dim i As Integer = 0
            dt = obj.returndatatable("select package_id, Package_name from CF_Package  where  package_id not in ( select  Deposit_PackageId from [CF_Deposit] where Deposit_UserId  in (select User_UserId from cf_user where [User_Id]='" & selectedIndexDetIdnew & "')  and [Deposit_Status]='true')", dt)

            If Not Request.QueryString("packid") = Nothing Then
                For Each Count In dt.Rows
                    If dt.Rows.Count > 0 Then


                        Dim RBDeposit As New RadioButton
                        'RBDeposit.ID = "RBdeposit" + i.ToString()
                        RBDeposit.ID = dt.Rows(counts).Item("package_id").ToString()
                        RBDeposit.Text = dt.Rows(counts).Item("Package_name").ToString()
                        If Request.QueryString("packid") = RBDeposit.ID Then
                            RBDeposit.Checked = True
                            RBDeposit.GroupName = "ADD"
                        Else
                            RBDeposit.Checked = False
                            RBDeposit.GroupName = "ADD"
                        End If


                        divRB.Controls.Add(RBDeposit)

                        Dim br As New HtmlGenericControl("br")
                        divRB.Controls.Add(br)
                        dt1 = obj.returndatatable("select Packagedet_Plan  as plans,Packagedet_MinAmount as [minimum amount],Packagedet_MaxAmount as [maximum amount],Packagedet_Percent as percentage from CF_Packagedet where packagedet_packageid= '" + RBDeposit.ID + "'  and packagedet_plan <>''", dt1)
                        'CreateGridView()
                        Dim gv As New GridView()
                        gv.ID = "GVDeposit" + counts.ToString
                        gv.CssClass = "acc_table"
                        gv.AutoGenerateColumns = True
                        gv.AllowPaging = True
                        gv.EnableViewState = True
                        gv.RowStyle.HorizontalAlign = HorizontalAlign.Right
                        gv.PageSize = 10
                        gv.DataSource = dt1
                        gv.DataBind()
                        divRB.Controls.Add(gv)
                        Dim br1 As New HtmlGenericControl("br")
                        divRB.Controls.Add(br1)

                    End If
                    counts = counts + 1
                Next

                dt2 = obj.returndatatable("select CustomProcessing_id, CustomProcessing_Name  from dbo.CF_CustomProcessing a join CF_User b on a.CustomProcessing_id=b.user_PaymentTypeId where User_UserId='" + userid1.ToString + "' and a.CustomProcessing_Status='True'", dt2)
                ' If Not IsPostBack Then

                For Each Count In dt2.Rows
                    If dt2.Rows.Count > 0 Then
                        Dim RBPayment As New RadioButton
                        RBPayment.ID = dt2.Rows(0).Item("CustomProcessing_id").ToString() + "_" + i.ToString()
                        RBPayment.GroupName = "Pay"
                        If dt2.Rows(0).Item("CustomProcessing_Name").ToString = "CreditCard" Then
                            'AddHandler RBPayment.CheckedChanged, AddressOf rbCC_CheckedChanged
                        End If
                        divpayment.Controls.Add(RBPayment)

                        Dim RBPaymentimg As New Image
                        'RBPaymentimg.ID = "RBPaymentimg" + "_" + i.ToString()
                        RBPaymentimg.Width = "90"
                        RBPaymentimg.Height = "30"
                        RBPaymentimg.ImageUrl = "~/Handlers/makedeposit.ashx?id=" & dt2.Rows(0).Item("CustomProcessing_id").ToString()
                        divpayment.Controls.Add(RBPaymentimg)
                    End If
                    i = i + 1
                Next

            Else



                For Each Count In dt.Rows
                    If dt.Rows.Count > 0 Then


                        Dim RBDeposit As New RadioButton
                        'RBDeposit.ID = "RBdeposit" + i.ToString()
                        RBDeposit.ID = dt.Rows(counts).Item("package_id").ToString()
                        RBDeposit.Text = dt.Rows(counts).Item("Package_name").ToString()
                        ' RBDeposit.Checked = False
                        RBDeposit.GroupName = "ADD"



                        divRB.Controls.Add(RBDeposit)

                        Dim br As New HtmlGenericControl("br")
                        divRB.Controls.Add(br)
                        dt1 = obj.returndatatable("select Packagedet_Plan as plans,Packagedet_MinAmount as [minimum amount],Packagedet_MaxAmount as [maximum amount],Packagedet_Percent as percentage from CF_Packagedet where packagedet_packageid= '" + RBDeposit.ID + "'  and packagedet_plan <>''", dt1)
                        'CreateGridView()
                        Dim gv As New GridView()
                        gv.ID = "GVDeposit" + counts.ToString
                        gv.CssClass = "acc_table"
                        gv.AutoGenerateColumns = True

                        gv.AllowPaging = True
                        gv.EnableViewState = True
                        gv.RowStyle.HorizontalAlign = HorizontalAlign.Right
                        gv.PageSize = 10
                        gv.DataSource = dt1
                        gv.DataBind()
                        divRB.Controls.Add(gv)
                        Dim br1 As New HtmlGenericControl("br")
                        divRB.Controls.Add(br1)

                    End If
                    counts = counts + 1
                Next

                dt2 = obj.returndatatable("select *  from dbo.CF_CustomProcessing  where CustomProcessing_Status='True'", dt2)
                ' If Not IsPostBack Then

                For Each Count In dt2.Rows
                    If dt2.Rows.Count > 0 Then
                        Dim RBPayment As New RadioButton
                        RBPayment.ID = dt2.Rows(i).Item("CustomProcessing_id").ToString() + "_" + i.ToString()
                        'RBPayment.Text = dt2.Rows(0).Item("CustomProcessing_Name").ToString
                        RBPayment.GroupName = "Pay"
                        'RBPayment.Checked = False
                        divpayment.Controls.Add(RBPayment)
                        If dt2.Rows(i).Item("CustomProcessing_Name").ToString = "CreditCard" Then
                            'AddHandler RBPayment.CheckedChanged, AddressOf rbCC_CheckedChanged
                        End If
                        Dim RBPaymentimg As New Image
                        'RBPaymentimg.ID = "RBPaymentimg"
                        RBPayment.GroupName = "SUB"
                        RBPaymentimg.Width = "90"
                        RBPaymentimg.Height = "30"
                        RBPaymentimg.ImageUrl = "~/Handlers/makedeposit.ashx?id=" & dt2.Rows(i).Item("CustomProcessing_id").ToString()
                        divpayment.Controls.Add(RBPaymentimg)
                        If dt2.Rows(i).Item("CustomProcessing_Name").ToString = "CreditCard" Then
                            divcreditcard1.Visible = True
                            divcreditcard2.Visible = True
                            divcreditcard3.Visible = True

                        End If
                    End If
                    i = i + 1
                Next

            End If
            Dim dst As New DataTable()
            Dim uid As Guid = Membership.GetUser.ProviderUserKey()
            Dim uid1 As String = Convert.ToString(uid)
            Dim uname As String = obj.Returnsinglevalue("select username from aspnet_users where userId='" + uid1 + "'")
            Dim bonusamt As String = obj.Returnsinglevalue("select sum(Bonus_Amount) as Bonus from [CF_Bonus] where Bonus_Username='" + uname + "'")
            Dim bonusdeposit As String = obj.Returnsinglevalue("select sum(Deposit_Amount) as deposit from  [CF_Deposit] where Deposit_UserId='" + uid1 + "' and Deposit_Type='Deposit From Bonus' and Deposit_Status='True'")

            lblbonusamt.Text = bonusamt - bonusdeposit
        Else
            Response.Redirect("login.aspx")
            ' End If

        End If

    End Sub



    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

            Dim ID As String = ""
            Dim rbid As String = ""
            Dim rbpid As String = ""
            Dim dt2 As New DataTable()
            Dim dt3 As New DataTable()
            Dim dt As New DataTable()
        Dim paymethod As String = ""
        Dim dtt As New DataTable
        Dim uid As Guid = Membership.GetUser.ProviderUserKey()
        Dim uid1 As String = Convert.ToString(uid)

        Try

            obj.returndatatable("select * from CF_Deposit where Deposit_UserId='" + uid1 + "' and Deposit_Type='Deposit From Bonus' and Deposit_Status='True' order by Deposit_ModifyDate desc", dtt)
            Dim count As Integer = dtt.Rows.Count

            Dim originDate As DateTime = Convert.ToDateTime(DateAndTime.Now.ToString()).ToString("yyyy/MM/dd")
            Dim admincount As DateTime = originDate
            If count <> 0 Then
                admincount = Convert.ToDateTime(dtt.Rows(0)("Deposit_ModifyDate").ToString()).ToString("yyyy/MM/dd")
            End If

            Dim st As String = DateDiff(DateInterval.Day, admincount, originDate)

            Dim value As String = obj.Returnsinglevalue("select Package_duration from CF_Package a inner join CF_Deposit b on  b.Deposit_PackageId=a.Package_Id where Deposit_UserId='" + uid1 + "' and Deposit_Type='Deposit From Bonus' and Deposit_Status='True'")

            If count <> 0 And st < value Then

                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Sorry You Have Already Activate Your Plan');", True)

            Else
                dt3 = obj.returndatatable("select CustomProcessing_id, CustomProcessing_Name  from dbo.CF_CustomProcessing", dt3)
                obj.strMode = "Add"

                dt = obj.returndatatable("select package_id, Package_name from CF_Package", dt)
                If obj.strMode = "" Then
                    'MsgBox("Please click Add or Modify Button to add or modify data", MsgBoxStyle.Information)
                    Exit Sub
                End If
                Select Case obj.strMode
                    Case "Add"


                        ID = obj.getIndexKey()

                    Case "Modify"

                        ID = SelectedIndexId


                    Case "Delete"


                End Select

                dt2 = obj.returndatatable("select CustomProcessing_id, CustomProcessing_Name  from dbo.CF_CustomProcessing a join CF_User b on a.CustomProcessing_id=b.user_PaymentTypeId where a.CustomProcessing_Status='True'", dt2)




                Dim rbtn1 As RadioButton

                Dim i1 As Integer = 0
                For Each curLine In dt2.Rows


                    If dt2.Rows.Count > 0 Then


                        Dim rbtnnam As String = String.Empty

                        Dim ctl1 As Control
                        For Each ctl1 In divpayment.Controls
                            If TypeOf ctl1 Is RadioButton Then
                                rbtn1 = DirectCast(ctl1, RadioButton)

                                If rbtn1.Checked = True Then

                                    Dim ss As String = rbtn1.ID.ToString()
                                    Dim c As Char() = New Char() {"_"}
                                    Dim str As String() = ss.Split(c, StringSplitOptions.RemoveEmptyEntries)
                                    rbpid = str(0)
                                    Exit For


                                End If
                            End If

                        Next
                    End If

                Next

                Dim i As Integer = 0
                For Each curLine2 In dt.Rows
                    If dt.Rows.Count > 0 Then


                        Dim rbtn As RadioButton
                        Dim rbtnName As String = String.Empty

                        Dim ctl As Control
                        For Each ctl In divRB.Controls
                            If TypeOf ctl Is RadioButton Then
                                rbtn = DirectCast(ctl, RadioButton)

                                If rbtn.Checked = True Then
                                    rbid = rbtn.ID.ToString()

                                    Exit For


                                End If
                            End If
                        Next
                    End If
                Next
                Dim packname As String = " "
                Dim strHostName As String
                Dim strIPAddress As String
                strHostName = System.Net.Dns.GetHostName()
                strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
                'Dim strcurip As String = "106.213.122.187"
                Dim ipcurrno As String = getCountry(strIPAddress)
                Dim countryname As String = obj.Returnsinglevalue("select con_name from IP where ipno_from <= '" + ipcurrno + "' and ipno_to>='" + ipcurrno + "'")


                paymethod = obj.Returnsinglevalue("select CustomProcessing_Name from CF_CustomProcessing  where CustomProcessing_id='" + rbpid + "'")

                If RadioButton1.Checked = True Then
                    If txtSpendAmount.Text <= Val(lblbonusamt.Text) Then

                        If Not rbid = "" And Not txtSpendAmount.Text = "" Then
                            Dim con As New SqlConnection
                            con = New SqlConnection(obj.ConnectionString)
                            con.Open()
                            Dim cmd As New SqlCommand
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandText = "SP_CF_BonusDeposit"
                            cmd.Connection = con
                            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                            cmd.Parameters.Add(New SqlParameter("@Deposit_Id", SqlDbType.VarChar, 10)).Value = ID
                            cmd.Parameters.Add(New SqlParameter("@Deposit_UserId", SqlDbType.UniqueIdentifier)).Value = userid1
                            cmd.Parameters.Add(New SqlParameter("@Deposit_PackageId", SqlDbType.VarChar, 10)).Value = rbid
                            cmd.Parameters.Add(New SqlParameter("@Deposit_PackageDetId", SqlDbType.VarChar, 10)).Value = obj.Returnsinglevalue("select a.packagedet_id from cf_packagedet a join CF_Package b on a.Packagedet_PackageId=b.Package_Id where b.Package_Id ='" + rbid.ToString() + "'")
                            cmd.Parameters.Add(New SqlParameter("@Deposit_Amount", SqlDbType.Decimal, 18, 2)).Value = txtSpendAmount.Text
                            cmd.Parameters.Add(New SqlParameter("@Deposit_Status", SqlDbType.VarChar, 10)).Value = "True"
                            cmd.Parameters.Add(New SqlParameter("@Deposit_Type", SqlDbType.VarChar, 50)).Value = "Deposit From Bonus"
                            cmd.Parameters.Add(New SqlParameter("@Deposit_ModifyDate", SqlDbType.DateTime)).Value = Format(obj.GetCurrentDate(), "yyyy/MM/dd")
                            cmd.Parameters.Add(New SqlParameter("@Deposit_SysIp", SqlDbType.VarChar, 10)).Value = strIPAddress
                            cmd.Parameters.Add(New SqlParameter("@Deposit_CountryName", SqlDbType.VarChar, 50)).Value = countryname
                            cmd.Parameters.Add(New SqlParameter("@Deposit_PayName", SqlDbType.VarChar, 50)).Value = paymethod

                            Dim uniqueid As String
                            uniqueid = obj.Returnsinglevalue("select max(Deposit_TrnsId) from CF_Deposit")
                            Dim un1 As Integer
                            Dim un2 As Integer

                            If Not uniqueid = 0 Then
                                un1 = Convert.ToInt32(uniqueid)
                                un2 = un1 + 1


                            Else
                                uniqueid = obj.Returnsinglevalue("select Settings_DepTransno from CF_Settings")
                                un2 = uniqueid
                            End If
                            cmd.Parameters.Add(New SqlParameter("@Deposit_TrnsId", SqlDbType.VarChar, 50)).Value = un2

                            cmd.ExecuteNonQuery()
                            cmd.Parameters.Clear()
                            'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Deposited Successfully');", True)

                            Dim message As String = "Deposited SuccessFully"
                            Dim url As String = "MakeDeposit.aspx"
                            Dim script As String = "window.onload = function(){ alert('"
                            script += message
                            script += "');"
                            script += "window.location = '"
                            script += url
                            script += "'; }"
                            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)

                        ElseIf txtSpendAmount.Text = "" Then
                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('please enter the amount');", True)
                        Else
                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('pls select atleast one package');", True)

                        End If
                    Else
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Please Check Current Bonus Amount');", True)

                    End If

                Else


                    If Not rbid = "" And Not txtSpendAmount.Text = "" Then

                        Dim con As New SqlConnection
                        con = New SqlConnection(obj.ConnectionString)
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "SP_CF_Deposit"
                        cmd.Connection = con
                        cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                        cmd.Parameters.Add(New SqlParameter("@Deposit_Id", SqlDbType.VarChar, 10)).Value = ID
                        cmd.Parameters.Add(New SqlParameter("@Deposit_UserId", SqlDbType.UniqueIdentifier)).Value = userid1
                        cmd.Parameters.Add(New SqlParameter("@Deposit_PackageId", SqlDbType.VarChar, 10)).Value = rbid
                        cmd.Parameters.Add(New SqlParameter("@Deposit_PackageDetId", SqlDbType.VarChar, 10)).Value = obj.Returnsinglevalue("select a.packagedet_id from cf_packagedet a join CF_Package b on a.Packagedet_PackageId=b.Package_Id where b.Package_Id ='" + rbid.ToString() + "'")
                        cmd.Parameters.Add(New SqlParameter("@Deposit_Amount", SqlDbType.Decimal, 18, 2)).Value = txtSpendAmount.Text

                        cmd.Parameters.Add(New SqlParameter("@Deposit_Type", SqlDbType.VarChar, 50)).Value = "Deposit From Payment"
                        cmd.Parameters.Add(New SqlParameter("@Deposit_ModifyDate", SqlDbType.DateTime)).Value = Format(obj.GetCurrentDate(), "yyyy/MM/dd")
                        cmd.Parameters.Add(New SqlParameter("@Deposit_SysIp", SqlDbType.VarChar, 10)).Value = strIPAddress
                        cmd.Parameters.Add(New SqlParameter("@Deposit_CountryName", SqlDbType.VarChar, 50)).Value = countryname
                        cmd.Parameters.Add(New SqlParameter("@Deposit_PayName", SqlDbType.VarChar, 50)).Value = paymethod
                        Dim uniqueid As String
                        uniqueid = obj.Returnsinglevalue("select max(Deposit_TrnsId) from CF_Deposit")
                        Dim un1 As Integer
                        Dim un2 As Integer

                        If Not uniqueid = 0 Then
                            un1 = Convert.ToInt32(uniqueid)
                            un2 = un1 + 1


                        Else
                            uniqueid = obj.Returnsinglevalue("select Settings_DepTransno from CF_Settings")
                            un2 = uniqueid
                        End If
                        cmd.Parameters.Add(New SqlParameter("@Deposit_TrnsId", SqlDbType.VarChar, 50)).Value = un2

                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()




                        obj.strMode = ""
                        ' lblmsg.Visible = True
                        ViewState("Deposit_Id") = ID
                        Session("Deposit_Id") = ID
                        Session("amount") = txtSpendAmount.Text
                        packname = obj.Returnsinglevalue("select package_name from CF_Package a join  CF_Deposit b on a.Package_Id=b.Deposit_PackageId where  b.Deposit_UserId='" + userid1.ToString + "' and Deposit_Id='" + ViewState("Deposit_Id") + "'")
                        Session("itemname") = packname
                        ViewState("Deposit_PackageId") = rbid
                        userid1 = Membership.GetUser.ProviderUserKey

                        If Not rbpid = "" Then

                            If paymethod = "Paypal" Then
                                Response.Redirect("~/PayPal.aspx")
                                ' paymentpaypal()
                            ElseIf paymethod = "Payza" Then
                                'paymentpaysa()
                                Response.Redirect("~/Payza.aspx")
                            ElseIf paymethod = "LibertyReserve" Then
                                'paymentLR()
                                Response.Redirect("~/LR.aspx")
                            ElseIf paymethod = "MoneyBookers" Then
                                paymentMoneyBooker()
                            ElseIf paymethod = "PerfectMoney" Then
                                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Perfect money not registered');", True)
                            ElseIf paymethod = "SolidTrustPay" Then
                                'paymentstp()
                                Response.Redirect("~/stp.aspx")
                            ElseIf paymethod = "CreditCard" Then
                                authorize()

                            End If




                        Else
                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('please choose any payment');", True)

                        End If
                    ElseIf txtSpendAmount.Text = "" Then
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('please enter the amount');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('pls select atleast one package');", True)

                    End If
                End If
            End If
            ' End If
        Catch ex As Exception
            Dim err As String = ex.Message

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('" + err + "');", True)
        Finally

        End Try



    End Sub

    Public Sub paymentpaypal()
        Dim redirecturl As String = ""

        Dim firstname As String = " "
        Dim lastname As String = " "
        Dim email As String = " "
        Dim postal As Integer
        Dim city As String = " "
        Dim packname As String = " "
        Dim sandbox As Boolean = CBool(System.Configuration.ConfigurationManager.AppSettings("UseSandbox"))
        Dim userid As Guid
        userid = Membership.GetUser.ProviderUserKey()
        Dim amount As Decimal = 0
        lastname = obj.Returnsinglevalue("select User_LastName from CF_User where User_UserId='" + userid.ToString + "'")
        email = obj.Returnsinglevalue("select Email from aspnet_Membership where UserId='" + userid.ToString + "'")
        postal = obj.Returnsinglevalue("select User_PostelCode from CF_User where User_UserId='" + userid.ToString + "'")

        amount = obj.Returnsinglevalue("select Deposit_Amount from cf_deposit where Deposit_UserId ='" + userid.ToString + "' and Deposit_Id='" + ViewState("Deposit_Id") + "'")


        firstname = obj.Returnsinglevalue("select User_FirstName from CF_User where User_UserId='" + userid.ToString + "'")
        city = obj.Returnsinglevalue("select User_City from CF_User where User_UserId='" + userid.ToString + "'")
        packname = obj.Returnsinglevalue("select package_name from CF_Package a join  CF_Deposit b on a.Package_Id=b.Deposit_PackageId where  b.Deposit_UserId='" + userid.ToString + "' and Deposit_Id='" + ViewState("Deposit_Id") + "'")

        ' redirecturl += "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + ConfigurationManager.AppSettings("paypalemail").ToString()

        redirecturl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + ConfigurationManager.AppSettings("paypalemail").ToString()
        Dim pe As New DataTable
        Dim payeremail As String = ""
        pe = obj.returndatatable("select * from [UserPaymentDet] where Payment_UserId ='" + userid.ToString + "'", pe)
        If pe.Rows.Count > 0 Then
            For i As Integer = 0 To pe.Rows.Count
                payeremail = pe.Rows(i).Item("UserPaymentAccDet").ToString()

            Next


        End If


        redirecturl += "&first_name=" + firstname
        redirecturl += "&last_name=" + lastname
        redirecturl += "&city=" + city
        redirecturl += "&email=" + email
        redirecturl += "&item_number=" + ViewState("Deposit_Id")
        redirecturl += "&item_name=" + packname
        redirecturl += "&amount=" + amount.ToString
        redirecturl += "&payer_email=" + payeremail
        redirecturl += "&return=" + ConfigurationManager.AppSettings("SuccessURL").ToString()
        redirecturl += "&cancel_return=" + ConfigurationManager.AppSettings("FailedURL").ToString()
        redirecturl += "&notify_url=" & ConfigurationManager.AppSettings("NotifyUrl").ToString
        Response.Redirect(redirecturl, False)
    End Sub
    Public Sub paymentpaysa()
        Dim redirecturl As String = ""


        Dim firstname As String = ""
        Dim userid As Guid
        Dim city As String = ""
        Dim packname As String = ""
        'Dim amount As Decimal = ""

        'amount = obj.Returnsinglevalue("select Deposit_Amount from cf_deposit where userid='" + userid.ToString + "'")

        userid = Membership.GetUser.ProviderUserKey()
        'firstname = obj.Returnsinglevalue("select  User_FirstName from CF_User where User_UserId='" + userid.ToString + "'")
        'city = obj.Returnsinglevalue("select  User_City from CF_User where User_UserId='" + userid.ToString + "'")
        packname = obj.Returnsinglevalue("select package_name from CF_Package a join  CF_Deposit b on a.Package_Id=b.Deposit_PackageId where b.Deposit_UserId='" + userid.ToString + "'")
        redirecturl += "https://sandbox.Payza.com/sandbox/payprocess.aspx?"
        redirecturl += "ap_merchant=" + ConfigurationManager.AppSettings("merchantemail").ToString()
        redirecturl += "&ap_amount=" + txtSpendAmount.Text
        redirecturl += "&ap_currency=USD"
        redirecturl += "&ap_purchasetype=item"
        redirecturl += "&ap_itemname=" + packname
        redirecturl += "&ap_returnurl=" + ConfigurationManager.AppSettings("PayzaSuccessURL").ToString()
        redirecturl += "&ap_cancelurl=" + ConfigurationManager.AppSettings("FailedURL").ToString()
        Response.Redirect(redirecturl, False)
    End Sub
    'Public Sub paymentpaysa()
    '    Dim post_url = ""
    '    post_url = "https://api.payza.com/svc/api.svc/sendmoney"
    '    Dim post_values As New Dictionary(Of String, String)
    '    post_values.Add("USER", "ol039.orangelab@gmail.com")
    '    post_values.Add("PASSWORD", "TGHTRe4zxNzI9gWU")
    '    post_values.Add("AMOUNT", txtSpendAmount.Text)
    '    post_values.Add("CURRENCY", "USD")
    '    post_values.Add("RECEIVEREMAIL", "seller_1_jebinthilak@gmail.com")
    '    post_values.Add("PURCHASETYPE", "3")
    '    post_values.Add("TESTMODE", "1")
    '    Dim post_string As String = ""
    '    For Each field As KeyValuePair(Of String, String) In post_values
    '        post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
    '    Next
    '    post_string = Left(post_string, Len(post_string) - 1)

    '    Dim response As String = String.Empty

    '    Dim myWriter As StreamWriter = Nothing


    '    Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
    '    objRequest.Method = "POST"
    '    objRequest.ContentLength = post_string.Length
    '    objRequest.ContentType = "application/x-www-form-urlencoded"


    '    myWriter = New StreamWriter(objRequest.GetRequestStream())
    '    myWriter.Write(post_string)
    '    myWriter.Close()


    '    Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
    '    Dim sr As New StreamReader(objResponse.GetResponseStream())
    '    Dim result As String = ""
    '    Dim strTemp As String = ""
    '    Dim flag As Boolean = True
    '    While flag
    '        strTemp = sr.ReadLine()
    '        If strTemp IsNot Nothing Then
    '            result += strTemp
    '        Else
    '            flag = False
    '        End If
    '    End While

    '    response = result
    '    ' decode the response string
    '    response = HttpUtility.UrlDecode(response)
    '    Dim arrResult As String() = result.Split("&"c)
    '    Dim htResponse As New Hashtable()
    '    Dim responseItemArray As String()
    '    For Each responseItem As String In arrResult
    '        responseItemArray = responseItem.Split("="c)
    '        htResponse.Add(responseItemArray(0), responseItemArray(1))
    '    Next

    '    ' Dim strAck As String = htResponse("ACK").ToString()
    '    Dim strAck As String = htResponse("RETURNCODE").ToString()
    '    Dim strstatus As String = htResponse("DESCRIPTION").ToString()
    '    Dim str2 As String = strstatus.Replace("%20", " ")
    '    Dim str3 As String = str2.Replace("%2f", "")
    '    Dim str4 As String = str3.Substring(48, 7)

    '    Dim strtest As String = htResponse("TESTMODE").ToString()
    '    If str4 = "success" Then
    '        Dim con As New SqlConnection
    '        con = New SqlConnection(obj.ConnectionString)

    '        Dim cmd As New SqlCommand
    '        Dim query As String
    '        query = "update CF_Deposit set Deposit_Status= 'True' where Deposit_Id='" + ViewState("Deposit_Id") + "'"
    '        con.Open()
    '        cmd = New SqlCommand(query, con)
    '        cmd.ExecuteNonQuery()
    '        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('SUCCESS');", True)
    '        con.Close()
    '        sr.Close()
    '    End If
    'End Sub

    Public Sub paymentMoneyBooker()
        Dim userid As Guid
        Dim value As String = "1"
        Dim desc As String = "Descriptor"
        Dim cn As String = "Samplemerchant wishes you"
        Dim field As String = "field1"
        Dim cur As String = "EUR"
        userid = Membership.GetUser.ProviderUserKey()
        Dim amount As Decimal = 0
        Dim language As String = "EN"
        amount = obj.Returnsinglevalue("select Deposit_Amount from cf_deposit where Deposit_UserId ='" + userid.ToString + "' and Deposit_Id='" + ID + "'")
        Dim redirecturl As String = ""
        redirecturl += "http://www.moneybookers.com/app/payment.pl?"
        redirecturl += "&pay_to_email=" + ConfigurationManager.AppSettings("payto").ToString()
        redirecturl += "&return_url_target=" + value
        redirecturl += "&cancel_url_target=" + value
        redirecturl += "&dynamic_descriptor=" + desc
        redirecturl += "&confirmation_note=" + cn
        redirecturl += "&merchant_fields=" + field
        redirecturl += "&currency=" + cur
        redirecturl += "&language=" + language
        redirecturl += "&return_url=" + ConfigurationManager.AppSettings("SuccessMB").ToString()
        redirecturl += "&cancel_url=" + ConfigurationManager.AppSettings("FailedURL").ToString()
        redirecturl += "&status_url=" + ConfigurationManager.AppSettings("statusurl").ToString()
        redirecturl += "&amount=" + txtSpendAmount.Text
        redirecturl += "&pay_from_email" + ConfigurationManager.AppSettings("MBemail").ToString()
        Response.Redirect(redirecturl, False)
    End Sub
    'Public Sub paymentstp()
    '    Dim redirecturl As String = ""

    '    Dim firstname As String = ""
    '    Dim userid As Guid
    '    Dim city As String = ""
    '    Dim packname As String = ""
    '    'Dim amount As Decimal = ""

    '    'amount = obj.Returnsinglevalue("select Deposit_Amount from cf_deposit where userid='" + userid.ToString + "'")

    '    userid = Membership.GetUser.ProviderUserKey()
    '    firstname = obj.Returnsinglevalue("select  User_FirstName from CF_User where User_UserId='" + userid.ToString + "'")
    '    city = obj.Returnsinglevalue("select  User_City from CF_User where User_UserId='" + userid.ToString + "'")
    '    packname = obj.Returnsinglevalue("select package_name from CF_Package a join  CF_Deposit b on a.Package_Id=b.Deposit_PackageId where b.Deposit_UserId='" + userid.ToString + "'")
    '    redirecturl += "https://solidtrustpay.com/handle_accpay.php?"
    '    redirecturl += "&merchantAccount=" + ConfigurationManager.AppSettings("stpmerchant").ToString()
    '    redirecturl += "&sci_name=SendPayLive"
    '    redirecturl += "&item_id=" + ViewState("Deposit_Id")
    '    redirecturl += "&amount=" + txtSpendAmount.Text
    '    redirecturl += "&currency=USD"
    '    redirecturl += "&testmode=ON"
    '    'redirecturl += "&notify_url=" + ConfigurationManager.AppSettings("STPNotifyURL").ToString() SendPayLive
    '    'redirecturl += "&return_url=" + ConfigurationManager.AppSettings("STPSuccessURL").ToString()
    '    'redirecturl += "&cancel_url=" + ConfigurationManager.AppSettings("STPFailedURL").ToString()
    '    Response.Redirect(redirecturl, False)
    'End Sub
    Public Sub paymentstp()
        Dim post_url = ""
        post_url = "https://solidtrustpay.com/accapi/process.php?"
        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("api_id", "api1")
        post_values.Add("api_pwd", "41933e60e9c19b866b3d68864727afe7")
        post_values.Add("user", "rizwan_ol")
        post_values.Add("amount", txtSpendAmount.Text)
        post_values.Add("item_id", ViewState("Deposit_Id"))
        post_values.Add("currency", "USD")
        post_values.Add("testmode", 0)
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
        Dim alert As String = "alert('" + response + "')"
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", alert, True)
        Dim htResponse As New Hashtable()
        Dim responseItemArray As String()
        For Each responseItem As String In arrResult
            responseItemArray = responseItem.Split("="c)
            htResponse.Add(responseItemArray(0), responseItemArray(1))
        Next

        Dim strAck As String = htResponse("Transaction ID").ToString()

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


    End Sub

    Public Sub paymentLR()


        Dim redirecturl As String = ""
        Dim firstname As String = ""
        Dim userid As Guid
        Dim city As String = ""
        Dim packname As String = "My Test"
        Dim accno As String = "U1997083"
        Dim caccno As String = "U1307460"
        Dim store As String = "My Test"
        Dim usd As String = "LRUSD"
        Dim comm As String = "welcome to lr"
        Dim lsmethod As String = "POST"
        Dim lfmethod = "GET"
        Dim lstmethod As String = "GET"
        userid = Membership.GetUser.ProviderUserKey()
        firstname = obj.Returnsinglevalue("select  User_FirstName from CF_User where User_UserId='" + userid.ToString + "'")
        city = obj.Returnsinglevalue("select  User_City from CF_User where User_UserId='" + userid.ToString + "'")
        packname = obj.Returnsinglevalue("select package_name from CF_Package a join  CF_Deposit b on a.Package_Id=b.Deposit_PackageId where b.Deposit_UserId='" + userid.ToString + "'")
        redirecturl += "https://sci.libertyreserve.com/en?"
        redirecturl += "lr_acc=" + accno
        redirecturl += "&lr_store=" + store
        redirecturl += "&lr_currency=" + usd
        redirecturl += "&lr_comments=" + comm
        redirecturl += "&lr_success_url=" + ConfigurationManager.AppSettings("LibertySuccessURL").ToString()
        redirecturl += "&lr_success_url_method=" + lsmethod
        redirecturl += "&lr_fail_url=" + ConfigurationManager.AppSettings("FailedURL").ToString()
        redirecturl += "&lr_fail_url_method=" + lfmethod
        redirecturl += "&lr_status_url=" + ConfigurationManager.AppSettings("LibertySuccessURL").ToString()
        redirecturl += "&lr_status_url_method=" + lstmethod
        redirecturl += "&lr_acc_from=" + caccno
        redirecturl += "&lr_amnt=" + txtSpendAmount.Text
        Response.Redirect(redirecturl, False)
    End Sub
    'Public Sub paymentLR()

    '    Dim post_url = ""
    '    post_url = "https://api2.libertyreserve.com/nvp/transfer?"
    '    Dim payee As String = ""

    '    Dim post_values As New Dictionary(Of String, String)
    '    post_values.Add("id", ViewState("Deposit_Id"))
    '    post_values.Add("account", "U4934418")
    '    post_values.Add("api", "Rizwanapi")
    '    post_values.Add("token", "8175DC012518BF2A95B96B657C1DEBC16E24F8EEBC17EE45A8525D3D92EF2FDB")
    '    post_values.Add("type", "transfer")
    '    post_values.Add("payee", "U1307460")

    '    post_values.Add("currency", "USD")
    '    post_values.Add("amount", txtSpendAmount.Text)
    '    post_values.Add("memo", "test")
    '    post_values.Add("private", "false")
    '    post_values.Add("purpose", "service")

    '    Dim post_string As String = ""
    '    For Each field As KeyValuePair(Of String, String) In post_values
    '        post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
    '    Next
    '    post_string = Left(post_string, Len(post_string) - 1)

    '    Dim response As String = String.Empty

    '    Dim myWriter As StreamWriter = Nothing


    '    Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
    '    objRequest.Method = "POST"
    '    objRequest.ContentLength = post_string.Length
    '    objRequest.ContentType = "application/x-www-form-urlencoded"


    '    myWriter = New StreamWriter(objRequest.GetRequestStream())
    '    myWriter.Write(post_string)
    '    myWriter.Close()
    '    Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
    '    Dim sr As New StreamReader(objResponse.GetResponseStream())
    '    Dim result As String = ""
    '    Dim strTemp As String = ""
    '    Dim flag As Boolean = True
    '    While flag
    '        strTemp = sr.ReadLine()
    '        If strTemp IsNot Nothing Then
    '            result += strTemp
    '        Else
    '            flag = False
    '        End If
    '    End While

    '    response = result
    '    ' decode the response string
    '    response = HttpUtility.UrlDecode(response)
    '    Dim alert As String = "alert('" + response + "')"
    '    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", alert, True)
    '    'Dim strack As String = response("DESCRIPTION").ToString

    '    sr.Close()
    'End Sub
    Public Sub authorize()
        '    'Dim redirecturl As String = ""
        '    'Dim cardnum As String = "3.1"
        '    'Dim expdt As String = "0115"
        '    'Dim amount As String = "10.25"
        '    'Dim method As String = "CC"
        '    'Dim pf As String = "PAYMENT_FORM"
        '    'Dim loginid As String = "4MBQ4rt7k"
        '    'Dim transkey As String = "3wx6S3jaCd46Vg7S"
        '    'Dim req As String = "true"
        '    'redirecturl += "https://secure.authorize.net/gateway/transact.dll?"
        '    'redirecturl += "x_login=" + loginid
        '    'redirecturl += "&x_tran_key=" + transkey
        '    'redirecturl += "&x_show_form=" + pf
        '    'redirecturl += "&x_version=" + cardnum
        '    'redirecturl += "&x_amount=" + amount
        '    '' redirecturl += "&x_tran_key=" + transkey
        '    'redirecturl += "&x_test_request=true"
        '    'Response.Redirect(redirecturl)

        '    '' posting to: https://secure.authorize.net/gateway/transact.dll
        Dim post_url = ""
        post_url = "https://test.authorize.net/gateway/transact.dll?"


        Dim post_values As New Dictionary(Of String, String)
        Dim cardnumber As String = txtcardnumber.Text
        Dim cardcode As String = txtcardcode.Text
        Dim cardexpiry As String = txtcardexpiry.Text
        'the API Login ID and Transaction Key must be replaced with valid values
        post_values.Add("x_login", "4q2X6Lg9Pb4y")
        post_values.Add("x_tran_key", "4Jn69bSZW6Fhm442")
        post_values.Add("x_version", "3.1")
        post_values.Add("x_delim_data", "TRUE")
        post_values.Add("x_delim_char", "&")
        post_values.Add("x_relay_response", "FALSE")
        post_values.Add("x_cust_id", ViewState("Deposit_Id"))
        post_values.Add("x_type", "AUTH_CAPTURE")
        post_values.Add("x_method", "CC")


        post_values.Add("x_card_num", cardnumber)
        post_values.Add("x_exp_date", cardexpiry)
        post_values.Add("x_card_code", cardcode)

        post_values.Add("x_amount", txtSpendAmount.Text)
        post_values.Add("x_description", "Sample Transaction")

        post_values.Add("x_first_name", "John")
        post_values.Add("x_last_name", "Doe")
        post_values.Add("x_address", "1234 Street")
        post_values.Add("x_state", "WA")
        post_values.Add("x_zip", "98004")
        ' Additional fields can be added here as outlined in the AIM integration
        ' guide at: http://developer.authorize.net 

        ' This section takes the input fields and converts them to the proper format
        ' for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
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
        Dim strAck As String = arrResult(3)
        Dim str2 As String = strAck.Replace(".", "")
        Dim transid As String = arrResult(6)
        Dim tranamt1 As String = arrResult(9)
        Dim dep_id1 As String = arrResult(12)

        If strAck = "This transaction has been approved." Then
            'Dim Script As String = "alert('" + strAck.ToString() + "');"
            'ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Script, True)
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('SUCCESS');", True)
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)

            Dim cmd As New SqlCommand
            Dim query As String

            Dim tranref As String, transtat As String, tranamt As String, trandate As Date, tranuserid As String, output As String, Dep_id As String


            tranref = transid
            transtat = str2
            tranamt = tranamt1
            Dep_id = dep_id1

            trandate = DateAndTime.Now
            tranuserid = Membership.GetUser.ProviderUserKey.ToString
            'insert into table for future reference - Session["user"] is logged in user
            query = "insert into CF_Transaction(TransactionID,TransactionStatus,Amount,DateTransaction,UserID,Trans_DepositId) values('" + tranref + "','true','" + tranamt + "','" + trandate + "','" + tranuserid + "','" + Dep_id + "')"
            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            query = "update CF_Deposit set Deposit_Status='true' where Deposit_Id='" + Dep_id.ToString + "'"
            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()

            selectedIndexDetId = obj.Returnsinglevalue("select User_Id from cf_user where User_UserId='" + tranuserid + "'")
            query = "update CF_Referral set Status='true' where User_Id='" + selectedIndexDetId + "'"
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
            output += "<tr><td height='40'>DepositId<td><td>" + Dep_id.ToString() + "</td>"
            output += "</table>"
            maindiv.Visible = False
            lnkhome.Visible = True
            lbldet.Visible = True
            lbldet.Text = output
        ElseIf strAck = "The credit card number is invalid." Then

            Dim Script As String = "alert('" + strAck.ToString() + "');"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Script, True)
        ElseIf strAck = "The card code is invalid." Then

            Dim Script As String = "alert('" + strAck.ToString() + "');"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Script, True)
        ElseIf strAck = "Credit card expiration date is invalid." Then

            Dim Script As String = "alert('" + strAck.ToString() + "');"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Script, True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Deposit failure');", True)
        End If


        sr.Close()
    End Sub
    'Protected Sub moneybooker_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    '    Dim userid As Guid
    '    Dim value As String = "1"
    '    Dim desc As String = "Descriptor"
    '    Dim cn As String = "Samplemerchant wishes you"
    '    Dim field As String = "field1"
    '    Dim cur As String = "EUR"
    '    userid = Membership.GetUser.ProviderUserKey()
    '    Dim amount As Decimal = 0
    '    Dim language As String = "EN"
    '    amount = obj.Returnsinglevalue("select Deposit_Amount from cf_deposit where Deposit_UserId ='" + userid.ToString + "' and Deposit_Id='" + ID + "'")
    '    Dim redirecturl As String = ""
    '    redirecturl += "http://www.moneybookers.com/app/payment.pl?"
    '    redirecturl += "&pay_to_email=" + ConfigurationManager.AppSettings("payto").ToString()
    '    redirecturl += "&return_url_target=" + value
    '    redirecturl += "&cancel_url_target=" + value
    '    redirecturl += "&dynamic_descriptor=" + desc
    '    redirecturl += "&confirmation_note=" + cn
    '    redirecturl += "&merchant_fields=" + field
    '    redirecturl += "&currency=" + cur
    '    redirecturl += "&language=" + language
    '    redirecturl += "&return_url=" + ConfigurationManager.AppSettings("SuccessMB").ToString()
    '    redirecturl += "&cancel_url=" + ConfigurationManager.AppSettings("FailedURL").ToString()
    '    redirecturl += "&status_url=" + ConfigurationManager.AppSettings("statusurl").ToString()
    '    redirecturl += "&amount=" + txtSpendAmount.Text
    '    'redirecturl += "&pay_from_email" + ConfigurationManager.AppSettings("MBemail").ToString()
    '    Response.Redirect(redirecturl, False)

    'End Sub


    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    '    'Dim redirecturl As String = ""
    '    '    'Dim cardnum As String = "3.1"
    '    '    'Dim expdt As String = "0115"
    '    '    'Dim amount As String = "10.25"
    '    '    'Dim method As String = "CC"
    '    '    'Dim pf As String = "PAYMENT_FORM"
    '    '    'Dim loginid As String = "4MBQ4rt7k"
    '    '    'Dim transkey As String = "3wx6S3jaCd46Vg7S"
    '    '    'Dim req As String = "true"
    '    '    'redirecturl += "https://secure.authorize.net/gateway/transact.dll?"
    '    '    'redirecturl += "x_login=" + loginid
    '    '    'redirecturl += "&x_tran_key=" + transkey
    '    '    'redirecturl += "&x_show_form=" + pf
    '    '    'redirecturl += "&x_version=" + cardnum
    '    '    'redirecturl += "&x_amount=" + amount
    '    '    '' redirecturl += "&x_tran_key=" + transkey
    '    '    'redirecturl += "&x_test_request=true"
    '    '    'Response.Redirect(redirecturl)

    '    '    '' posting to: https://secure.authorize.net/gateway/transact.dll
    '    Dim post_url = ""
    '    post_url = "https://test.authorize.net/gateway/transact.dll?"


    '    Dim post_values As New Dictionary(Of String, String)

    '    'the API Login ID and Transaction Key must be replaced with valid values
    '    post_values.Add("x_login", "4q2X6Lg9Pb4y")
    '    post_values.Add("x_tran_key", "4Jn69bSZW6Fhm442")
    '    post_values.Add("x_version", "3.1")
    '    post_values.Add("x_delim_data", "TRUE")
    '    post_values.Add("x_delim_char", "&")
    '    post_values.Add("x_relay_response", "FALSE")
    '    post_values.Add("x_cust_id", ViewState("Deposit_Id"))
    '    post_values.Add("x_type", "AUTH_CAPTURE")
    '    post_values.Add("x_method", "CC")
    '    post_values.Add("x_card_num", "4111111111111111")
    '    post_values.Add("x_exp_date", "12/14")
    '    post_values.Add("x_card_code", "123")
    '    post_values.Add("x_amount", "20")
    '    post_values.Add("x_description", "Sample Transaction")

    '    post_values.Add("x_first_name", "John")
    '    post_values.Add("x_last_name", "Doe")
    '    post_values.Add("x_address", "1234 Street")
    '    post_values.Add("x_state", "WA")
    '    post_values.Add("x_zip", "98004")
    '    ' Additional fields can be added here as outlined in the AIM integration
    '    ' guide at: http://developer.authorize.net 

    '    ' This section takes the input fields and converts them to the proper format
    '    ' for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
    '    Dim post_string As String = ""
    '    For Each field As KeyValuePair(Of String, String) In post_values
    '        post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
    '    Next
    '    post_string = Left(post_string, Len(post_string) - 1)
    '    Dim responsedata As String = String.Empty
    '    Dim myWriter As StreamWriter = Nothing
    '    Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
    '    objRequest.Method = "POST"
    '    objRequest.ContentLength = post_string.Length
    '    objRequest.ContentType = "application/x-www-form-urlencoded"


    '    myWriter = New StreamWriter(objRequest.GetRequestStream())
    '    myWriter.Write(post_string)
    '    myWriter.Close()


    '    Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
    '    Dim sr As New StreamReader(objResponse.GetResponseStream())
    '    Dim result As String = ""
    '    Dim strTemp As String = ""
    '    Dim flag As Boolean = True
    '    While flag
    '        strTemp = sr.ReadLine()
    '        If strTemp IsNot Nothing Then
    '            result += strTemp
    '        Else
    '            flag = False
    '        End If
    '    End While

    '    responsedata = result
    '    ' decode the response string
    '    responsedata = HttpUtility.UrlDecode(responsedata)
    '    Dim arrResult As String() = result.Split("&"c)
    '    Dim htResponse As New Hashtable()
    '    Dim strAck As String = arrResult(3)
    '    Dim dep_id As String = arrResult(13)
    '    Dim Script As String = "alert('" + strAck.ToString() + "');"
    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), Script, True)




    '    sr.Close()
    'End Sub

    'Protected Sub paysa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    Dim redirecturl As String = ""


    '    Dim firstname As String = ""
    '    Dim userid As Guid
    '    Dim city As String = ""
    '    Dim packname As String = ""
    '    'Dim amount As Decimal = ""

    '    'amount = obj.Returnsinglevalue("select Deposit_Amount from cf_deposit where userid='" + userid.ToString + "'")

    '    userid = Membership.GetUser.ProviderUserKey()
    '    'firstname = obj.Returnsinglevalue("select  User_FirstName from CF_User where User_UserId='" + userid.ToString + "'")
    '    'city = obj.Returnsinglevalue("select  User_City from CF_User where User_UserId='" + userid.ToString + "'")
    '    packname = obj.Returnsinglevalue("select package_name from CF_Package a join  CF_Deposit b on a.Package_Id=b.Deposit_PackageId where b.Deposit_UserId='" + userid.ToString + "'")
    '    redirecturl += "https://sandbox.Payza.com/sandbox/payprocess.aspx?"
    '    redirecturl += "ap_merchant=" + ConfigurationManager.AppSettings("merchantemail").ToString()
    '    redirecturl += "&ap_amount=" + txtSpendAmount.Text
    '    redirecturl += "&ap_currency=USD"
    '    redirecturl += "&ap_purchasetype=item"
    '    redirecturl += "&ap_itemname=" + packname
    '    redirecturl += "&ap_returnurl=" + ConfigurationManager.AppSettings("PayzaSuccessURL").ToString()
    '    redirecturl += "&ap_cancelurl=" + ConfigurationManager.AppSettings("PayzaFailedURL").ToString()
    '    Response.Redirect(redirecturl, False)
    'End Sub




    'Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    Dim redirecturl As String = ""

    '    Dim firstname As String = ""
    '    Dim userid As Guid
    '    Dim city As String = ""
    '    Dim packname As String = ""
    '    'Dim amount As Decimal = ""

    '    'amount = obj.Returnsinglevalue("select Deposit_Amount from cf_deposit where userid='" + userid.ToString + "'")

    '    userid = Membership.GetUser.ProviderUserKey()
    '    firstname = obj.Returnsinglevalue("select  User_FirstName from CF_User where User_UserId='" + userid.ToString + "'")
    '    city = obj.Returnsinglevalue("select  User_City from CF_User where User_UserId='" + userid.ToString + "'")
    '    packname = obj.Returnsinglevalue("select package_name from CF_Package a join  CF_Deposit b on a.Package_Id=b.Deposit_PackageId where b.Deposit_UserId='" + userid.ToString + "'")
    '    redirecturl += "https://solidtrustpay.com/handle_accpay.php?"
    '    redirecturl += "&merchantAccount=" + ConfigurationManager.AppSettings("stpmerchant").ToString()
    '    redirecturl += "&sci_name=sendpay1"
    '    redirecturl += "&item_id=" + packname
    '    redirecturl += "&amount=" + txtSpendAmount.Text
    '    redirecturl += "&currency=USD"
    '    redirecturl += "&testmode=ON"
    '    'redirecturl += "&notify_url=" + ConfigurationManager.AppSettings("STPNotifyURL").ToString()
    '    'redirecturl += "&return_url=" + ConfigurationManager.AppSettings("STPSuccessURL").ToString()
    '    'redirecturl += "&cancel_url=" + ConfigurationManager.AppSettings("STPFailedURL").ToString()
    '    Response.Redirect(redirecturl, False)
    'End Sub

    'Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    Dim redirecturl As String = ""
    '    Dim firstname As String = ""
    '    Dim userid As Guid
    '    Dim city As String = ""
    '    Dim packname As String = "My Test"
    '    Dim accno As String = "U1997083"
    '    Dim caccno As String = "U1307460"
    '    Dim store As String = "My Test"
    '    Dim usd As String = "LRUSD"
    '    Dim comm As String = "welcome to lr"
    '    Dim lsmethod As String = "POST"
    '    Dim lfmethod = "GET"
    '    Dim lstmethod As String = "GET"
    '    userid = Membership.GetUser.ProviderUserKey()
    '    firstname = obj.Returnsinglevalue("select  User_FirstName from CF_User where User_UserId='" + userid.ToString + "'")
    '    city = obj.Returnsinglevalue("select  User_City from CF_User where User_UserId='" + userid.ToString + "'")
    '    packname = obj.Returnsinglevalue("select package_name from CF_Package a join  CF_Deposit b on a.Package_Id=b.Deposit_PackageId where b.Deposit_UserId='" + userid.ToString + "'")
    '    redirecturl += "https://sci.libertyreserve.com/en?"
    '    redirecturl += "lr_acc=" + accno
    '    redirecturl += "&lr_store=" + store
    '    redirecturl += "&lr_currency=" + usd
    '    redirecturl += "&lr_comments=" + comm
    '    redirecturl += "&lr_success_url=" + ConfigurationManager.AppSettings("SuccessURL").ToString()
    '    redirecturl += "&lr_success_url_method=" + lsmethod
    '    redirecturl += "&lr_fail_url=" + ConfigurationManager.AppSettings("FailedURL").ToString()
    '    redirecturl += "&lr_fail_url_method=" + lfmethod
    '    redirecturl += "&lr_status_url=" + ConfigurationManager.AppSettings("SuccessURL").ToString()
    '    redirecturl += "&lr_status_url_method=" + lstmethod
    '    redirecturl += "&lr_acc_from=" + caccno
    '    redirecturl += "&lr_amnt=" + txtSpendAmount.Text
    '    Response.Redirect(redirecturl)
    'End Sub
    'Class SendMoneyClient
    '    '
    '    '         * The API's response variables
    '    '         

    '    Private m_response As String
    '    Public Property Response() As String
    '        Get
    '            Return m_response
    '        End Get
    '        Set(ByVal value As String)
    '            m_response = value
    '        End Set
    '    End Property

    '    '
    '    '         * The server address of the SendMoney API
    '    '         

    '    Private m_server As String
    '    Public Property Server() As String
    '        Get
    '            Return m_server
    '        End Get
    '        Set(ByVal value As String)
    '            m_server = value
    '        End Set
    '    End Property

    '    '
    '    '         * The exact URL of the SendMoney API
    '    '         

    '    Private m_url As String
    '    Public Property Url() As String
    '        Get
    '            Return m_url
    '        End Get
    '        Set(ByVal value As String)
    '            m_url = value
    '        End Set
    '    End Property

    '    '
    '    '         * Your Payza user name which is your email address
    '    '         

    '    Private m_myUserName As String
    '    Public Property MyUserName() As String
    '        Get
    '            Return m_myUserName
    '        End Get
    '        Set(ByVal value As String)
    '            m_myUserName = value
    '        End Set
    '    End Property

    '    '
    '    '         * Your API password that is generated from your Payza account
    '    '         

    '    Private m_apiPassword As String
    '    Public Property ApiPassword() As String
    '        Get
    '            Return m_apiPassword
    '        End Get
    '        Set(ByVal value As String)
    '            m_apiPassword = value
    '        End Set
    '    End Property

    '    '
    '    '         * The data that will be sent to the SendMoney API
    '    '         

    '    Private m_dataToSend As String
    '    Public Property DataToSend() As String
    '        Get
    '            Return m_dataToSend
    '        End Get
    '        Set(ByVal value As String)
    '            m_dataToSend = value
    '        End Set
    '    End Property

    '    '
    '    '         * constructor
    '    '         * 
    '    '         * Constructs a SendMoneyClient object
    '    '         * 
    '    '         * @param string strUserName Your Payza username
    '    '         * @param string strPassword Your API password
    '    '         

    '    Public Sub New(ByVal strUsername As String, ByVal strPassword As String)
    '        m_myUserName = strUsername
    '        m_apiPassword = strPassword
    '        m_dataToSend = String.Empty
    '    End Sub
    '    Public Function BuildPostVariables(ByVal strAmountPaid As String, ByVal strCurrency As String, ByVal strReceiverEmail As String, ByVal strSenderEmail As String, ByVal strPurchaseType As String, ByVal strNote As String, _
    '     ByVal strTestMode As String) As String
    '        Dim sbDataToSend As New StringBuilder()
    '        sbDataToSend.AppendFormat("USER={0}&PASSWORD={1}&AMOUNT={2}&CURRENCY={3}&RECEIVEREMAIL={4}&SENDEREMAIL={5}&PURCHASETYPE={6}&NOTE={7}&TESTMODE={8}", HttpUtility.UrlEncode(m_myUserName), HttpUtility.UrlEncode(m_apiPassword), HttpUtility.UrlEncode(DirectCast(strAmountPaid, String)), HttpUtility.UrlEncode(DirectCast(strCurrency, String)), HttpUtility.UrlEncode(DirectCast(strReceiverEmail, String)), _
    '         HttpUtility.UrlEncode(DirectCast(strSenderEmail, String)), HttpUtility.UrlEncode(DirectCast(strPurchaseType, String)), HttpUtility.UrlEncode(DirectCast(strNote, String)), HttpUtility.UrlEncode(DirectCast(strTestMode, String)))
    '        m_dataToSend = sbDataToSend.ToString()
    '        Return m_dataToSend
    '    End Function
    '    Public Function PostData() As String
    '        Dim response As String = String.Empty

    '        Dim myWriter As StreamWriter = Nothing
    '        Dim objRequest As HttpWebRequest = Nothing

    '        Try
    '            ' send the post
    '            objRequest = DirectCast(WebRequest.Create(m_server & m_url), HttpWebRequest)
    '            objRequest.Method = "POST"
    '            objRequest.ContentLength = m_dataToSend.Length
    '            objRequest.ContentType = "application/x-www-form-urlencoded"

    '            myWriter = New StreamWriter(objRequest.GetRequestStream())
    '            myWriter.Write(m_dataToSend)
    '            myWriter.Close()

    '            ' read the response
    '            Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
    '            Dim sr As New StreamReader(objResponse.GetResponseStream())
    '            Dim result As String = ""
    '            Dim strTemp As String = ""
    '            Dim flag As Boolean = True
    '            While flag
    '                strTemp = sr.ReadLine()
    '                If strTemp IsNot Nothing Then
    '                    result += strTemp
    '                Else
    '                    flag = False
    '                End If
    '            End While

    '            response = result
    '            ' decode the response string
    '            response = HttpUtility.UrlDecode(response)

    '            sr.Close()

    '        Catch e As UriFormatException

    '        Catch e As Exception
    '        Finally
    '            If myWriter IsNot Nothing Then
    '                myWriter.Close()
    '            End If
    '        End Try

    '        Return response
    '    End Function

    'End Class

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim objSendMoneyClient As New SendMoneyClient("client_1_jebinthilak@gmail.com", "MTCwQhNcQtTbXvCi")
    '    'objSendMoneyClient.Server = "https://api.payza.com"
    '    'objSendMoneyClient.Url = "/svc/api.svc/sendmoney"
    '    objSendMoneyClient.Server = "https://sandbox.payza.com"
    '    objSendMoneyClient.Url = "/api/api.svc/sendmoney"
    '    Dim strPostString As String = objSendMoneyClient.BuildPostVariables("100", "USD", "seller_1_jebinthilak@gmail.com", "client_1_jebinthilak@gmail.com ", "1", "this is a test", "1")
    '    objSendMoneyClient.Response = objSendMoneyClient.PostData()
    'End Sub
    Public Function getCountry(ByVal ip As String) As String

        Dim ip_seg() As String = ip.Split(".")

        Dim w As String = ip_seg(0)
        Dim x As String = ip_seg(1)
        Dim y As String = ip_seg(2)
        Dim z As String = ip_seg(3)
        Dim ipno As String = 16777216 * w + 65536 * x + 256 * y + z

        Return ipno

    End Function

 
    Protected Sub txtSpendAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSpendAmount.TextChanged

        If txtSpendAmount.Text <> "" Then
            If Convert.ToDecimal(txtSpendAmount.Text) > Convert.ToDecimal(0) Then
                'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Please Enter Your Available Balance Only ');", True)
                'txtSpendAmount.Text = ""
                txtSpendAmount.Focus()
            Else
                txtSpendAmount.Focus()
            End If
        End If

    End Sub
End Class