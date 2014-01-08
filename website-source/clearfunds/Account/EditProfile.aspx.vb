Imports System.Data
Imports System.Data.SqlClient
Partial Class Account_Profile
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Not Me.IsPostBack Then
        If Session("User_Id") = Nothing Then
            Response.Redirect("~/default.aspx")
        End If
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As New DataTable()
        Dim dt1 As New DataTable()



        If Not Session("User_Id") = Nothing Then


            If IsPostBack = False Then
                obj.Fill_DropDown("select  Country_Name,Country_Id from CF_Country", cmbcountry)
                obj.Fill_DropDown("select CustomProcessing_Name,CustomProcessing_Id from CF_CustomProcessing where CustomProcessing_Status='True'", cmbPaymentType)
                obj.Fill_DropDown("select Occupation_Name,Occupation_Id from CF_Occupation", cmbOccupation)

                SelectedIndexId = Session("User_Id")

                dt = obj.returndatatable("select c.User_Saluation,c.User_FirstName,c.User_LastName, c.User_State,b.UserName,c.User_Addr1,c.User_Addr2,c.User_City,c.User_Region,c.User_PostelCode,cc.Country_Name,c.User_Phone,convert (varchar,c.User_DOB,101)as User_DOB,cf.CustomProcessing_Name,c.user_AccountEmail,co.Occupation_Name,c.user_ThirdParty,a.Email from CF_User c left join aspnet_Membership a  on a.UserId=c.User_UserId left join aspnet_Users b on a.UserId=b.UserId left join CF_Country cc on c.User_CountryId=cc.Country_Id left join CF_CustomProcessing cf on c.user_PaymentTypeId=cf.CustomProcessing_Id left join CF_Occupation co on c.User_Occupation=co.Occupation_Id  where c.User_Id='" + SelectedIndexId + "'", dt)
                If dt.Rows.Count > 0 Then
                    cmbsaluation.Text = dt.Rows(0).Item("User_Saluation").ToString()
                    txtFirstName.Text = dt.Rows(0).Item("User_FirstName").ToString()
                    txtLastName.Text = dt.Rows(0).Item("User_LastName").ToString()
                    UserName.Text = dt.Rows(0).Item("UserName").ToString()
                    txtAddressLine1.Text = dt.Rows(0).Item("User_Addr1").ToString()
                    txtAddressLine2.Text = dt.Rows(0).Item("User_Addr2").ToString()
                    txtCity.Text = dt.Rows(0).Item("User_City").ToString()
                    txtRegion.Text = dt.Rows(0).Item("User_Region").ToString()
                    txtPostelCode.Text = dt.Rows(0).Item("User_PostelCode").ToString()
                    txtstate.Text = dt.Rows(0).Item("User_State").ToString()
                    For i = 0 To cmbcountry.Items.Count - 1
                        If cmbcountry.Items(i).Text = dt.Rows(0).Item("Country_Name").ToString Then
                            cmbcountry.SelectedIndex = i
                        End If
                    Next
                    txtHomephoneCode.Text = obj.Returnsinglevalue("select country_TelCode from cf_country where country_Id='" + dt.Rows(0).Item("Country_Name").ToString + "'")
                    'cmbcountry.DataTextField = dt.Rows(0).Item("Country_Name").ToString
                    txtHomePhone.Text = dt.Rows(0).Item("User_Phone").ToString()
                    txtdob.Text = dt.Rows(0).Item("User_DOB").ToString()
                    'cmbPaymentType.DataTextField = dt.Rows(0).Item("Payment_Type").ToString()
                    For i = 0 To cmbPaymentType.Items.Count - 1
                        If cmbPaymentType.Items(i).Text = dt.Rows(0).Item("CustomProcessing_Name").ToString Then
                            cmbPaymentType.SelectedIndex = i
                        End If
                    Next

                    'txtAccEmailId.Text = dt.Rows(0).Item("user_AccountEmail").ToString()
                    'cmbOccupation.SelectedValue = dt.Rows(0).Item("Occupation_Name").ToString()
                    For i = 0 To cmbOccupation.Items.Count - 1
                        If cmbOccupation.Items(i).Text = dt.Rows(0).Item("Occupation_Name").ToString Then
                            cmbOccupation.SelectedIndex = i
                        End If
                    Next
                    RadioButtonList1.SelectedValue = dt.Rows(0).Item("user_ThirdParty").ToString



                    Email.Text = dt.Rows(0).Item("Email").ToString()
                Else


                End If




                'End If
            Else
                'Response.Redirect("login.aspx")
            End If



            dt = obj.returndatatable("select * from [cf_CustomProcessingFields] where CustomProcessing_pid='" + cmbPaymentType.SelectedValue + "' and [CustomProcessing_chkfields]='True'", dt)
            dt1 = obj.returndatatable("select * from [UserPaymentDet] where [Payment_UserId] ='" + Session("User_Id").ToString() + "' and [Payment_procceesingId]='" + cmbPaymentType.SelectedValue + "'", dt1)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim tbl As New Table()
                    divtb.Controls.Add(tbl)
                    Dim tr As New TableRow()
                    tbl.Controls.Add(tr)
                    Dim tc As New TableCell()
                    tr.Controls.Add(tc)
                    Dim tc1 As New TableCell()
                    tr.Controls.Add(tc1)

                    Dim tb As New TextBox

                    tb.ID = "txtvalue_" + i.ToString()
                    'tb.Text = dt1.Rows(i).Item("UserPaymentAccDet").ToString()
                    Dim lb As New Label
                    lb.Text = dt.Rows(i).Item("CustomProcessing_fields").ToString()
                    'divtb.Attributes.Add("class", "pro_one")
                    tc.Controls.Add(lb)

                    If dt1.Rows.Count > 0 Then
                        tb.Text = dt1.Rows(i).Item("UserPaymentAccDet").ToString()


                    Else
                        tb.Text = ""
                        lblprofile.Visible = True
                    End If

                    tc1.Controls.Add(tb)

                    Dim RequiredFieldValidator1 As New RequiredFieldValidator()
                    'RequiredFieldValidator1.Enabled = True
                    RequiredFieldValidator1.ErrorMessage = "* required"
                    RequiredFieldValidator1.Display = ValidatorDisplay.Dynamic
                    RequiredFieldValidator1.ControlToValidate = "txtvalue_" + i.ToString()
                    RequiredFieldValidator1.EnableViewState = True
                    RequiredFieldValidator1.SetFocusOnError = True
                    RequiredFieldValidator1.Text = "*"
                    RequiredFieldValidator1.ValidationGroup = "RegisterUserValidationGroup"
                    RequiredFieldValidator1.ForeColor = Drawing.Color.Red

                    tc1.Controls.Add(RequiredFieldValidator1)
                    RequiredFieldValidator1.Validate()

                    Dim br2 As New HtmlGenericControl("br")
                    tc1.Controls.Add(br2)


                Next


            End If


            If cmbPaymentType.SelectedItem.Text = "Paypal" Then
                Dim RegularExpressionValidator1 As New RegularExpressionValidator()
                RegularExpressionValidator1.ValidationExpression = "\w+([-+.]\w+)*@\w+([-.]w+)*\.\w+([-.]\w+)*"
                RegularExpressionValidator1.Enabled = True
                RegularExpressionValidator1.ErrorMessage = "Invald Account Mail Id"
                RegularExpressionValidator1.Display = ValidatorDisplay.Dynamic
                RegularExpressionValidator1.ControlToValidate = "txtvalue_0"
                RegularExpressionValidator1.SetFocusOnError = True
                RegularExpressionValidator1.ValidationGroup = "RegisterUserValidationGroup"
                divtb.Controls.Add(RegularExpressionValidator1)
                RegularExpressionValidator1.Validate()

            End If

        Else
            Response.Redirect("login.aspx")

        End If



    End Sub

    Protected Sub Modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ID As String = ""
        ID = Session("User_Id")

        Try
            Dim coun As String = obj.Returnsinglevalue("select [user_AccModifyCount] from CF_User where user_Id='" + ID + "'")
            Dim admincount As String = obj.Returnsinglevalue("select [Settings_MaxAccInfo] from CF_Settings")




            lblmsg.Visible = False
            obj.strMode = "Modify"
            Dim dt As New DataTable()
            Dim dt2 As New DataTable()


            Dim dt1 As New DataTable


            'If radioyes.Checked = True Then
            '    active = "Yes"
            'Else
            '    active = "No"
            'End If

            Select Case obj.strMode

                Case "Modify"

                    ID = Session("User_Id")

                Case "Delete"

            End Select
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            Dim d5 As New DataTable
            Dim dat1 As String = txtdob.Text



            lblprofile.Visible = False


            Dim status As Boolean = False
            d5 = obj.returndatatable("select c.User_Saluation,c.User_FirstName,c.User_State,c.User_LastName,b.UserName,c.User_Addr1,c.User_Addr2,c.User_City,c.User_Region,c.User_PostelCode,cc.Country_Name,c.User_Phone,convert (varchar,c.User_DOB,101)as User_DOB,cf.CustomProcessing_Name,c.user_AccountEmail,co.Occupation_Name,c.user_ThirdParty,a.Email from CF_User c left join aspnet_Membership a  on a.UserId=c.User_UserId left join aspnet_Users b on a.UserId=b.UserId left join CF_Country cc on c.User_CountryId=cc.Country_Id left join CF_CustomProcessing cf on c.user_PaymentTypeId=cf.CustomProcessing_Id left join CF_Occupation co on c.User_Occupation=co.Occupation_Id  where c.User_Id='" + ID + "'", d5)
            If Not d5.Rows(0).Item("User_Saluation").ToString = cmbsaluation.SelectedValue Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_FirstName").ToString = txtFirstName.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_LastName").ToString = txtLastName.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_Addr1").ToString = txtAddressLine1.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_Addr2").ToString = txtAddressLine2.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_City").ToString = txtCity.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_State").ToString = txtCity.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_Region").ToString = txtRegion.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_PostelCode").ToString = txtPostelCode.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("Country_Name").ToString = cmbcountry.SelectedItem.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_Phone").ToString = txtHomePhone.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("User_DOB").ToString = dat1 Then
                status = True
            ElseIf Not d5.Rows(0).Item("Occupation_Name").ToString = cmbOccupation.SelectedItem.Text Then
                status = True
            ElseIf Not d5.Rows(0).Item("user_ThirdParty").ToString = RadioButtonList1.SelectedValue Then
                status = True
            ElseIf Not d5.Rows(0).Item("Email").ToString = Email.Text Then
                status = True
            End If


            If status = True Then
                If coun >= admincount Then
                    'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Your Profile information Updation Exceeds the maximum number of account Change Please contact Your Admin For More Information');", True)
                    Dim message1 As String = "Your Profile information Updation Exceeds the maximum number of account Change Please contact Your Admin For More Information"
                    Dim url1 As String = "profile.aspx"
                    Dim script1 As String = "window.onload = function(){ alert('"
                    script1 += message1
                    script1 += "');"
                    script1 += "window.location = '"
                    script1 += url1
                    script1 += "'; }"
                    ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script1, True)
                   
                    GoTo A

                Else

                    Dim count As String = obj.Returnsinglevalue("select user_AccModifyCount from Cf_User where User_Id='" + ID + "'")
                    Dim count1 As String = count + 1
                    cmd = New SqlCommand("update CF_User set user_AccModifyCount='" + count1 + "' where User_Id='" + ID + "'", con)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            End If

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_UserUpdate"
            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@User_Id", SqlDbType.VarChar, 10)).Value = ID

            cmd.Parameters.Add(New SqlParameter("@User_Saluation", SqlDbType.VarChar, 10)).Value = cmbsaluation.SelectedValue

            cmd.Parameters.Add(New SqlParameter("@User_FirstName ", SqlDbType.VarChar, 75)).Value = txtFirstName.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@User_LastName", SqlDbType.VarChar, 75)).Value = txtLastName.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@User_Addr1 ", SqlDbType.VarChar, 100)).Value = txtAddressLine1.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@User_Addr2 ", SqlDbType.VarChar, 100)).Value = txtAddressLine2.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@User_City", SqlDbType.VarChar, 50)).Value = txtCity.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@User_Region", SqlDbType.VarChar, 50)).Value = txtRegion.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@User_PostelCode", SqlDbType.VarChar, 10)).Value = txtPostelCode.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@User_CountryId ", SqlDbType.VarChar, 10)).Value = cmbcountry.SelectedItem.Value
            cmd.Parameters.Add(New SqlParameter("@User_Phone ", SqlDbType.Decimal, 18, 0)).Value = Val(txtHomePhone.Text)
            cmd.Parameters.Add(New SqlParameter("@User_State ", SqlDbType.VarChar, 50)).Value = txtstate.Text
            cmd.Parameters.Add(New SqlParameter("@User_Occupation", SqlDbType.VarChar, 10)).Value = cmbOccupation.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@User_DOB", SqlDbType.DateTime)).Value = Convert.ToDateTime(txtdob.Text, System.Globalization.CultureInfo.InvariantCulture)
            cmd.Parameters.Add(New SqlParameter("@user_PaymentTypeId", SqlDbType.VarChar, 10)).Value = cmbPaymentType.SelectedValue


            cmd.Parameters.Add(New SqlParameter("@User_ThirdParty", SqlDbType.VarChar, 50)).Value = RadioButtonList1.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@User_RegDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.Parameters.Add(New SqlParameter("@User_IDDetails", SqlDbType.VarChar, 50)).Value = Environment.MachineName()
            cmd.Parameters.Add(New SqlParameter("@User_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('saved Successfully');", True)
            Dim message As String = "saved Successfully"
            Dim url As String = "profile.aspx"
            Dim script As String = "window.onload = function(){ alert('"
            script += message
            script += "');"
            script += "window.location = '"
            script += url
            script += "'; }"
            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
            lblmsg.Visible = True
            Dim struserid As Guid
            struserid = Membership.GetUser.ProviderUserKey

            cmd = New SqlCommand("update aspnet_membership set Email=@email where UserId=@User_Id", con)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@User_Id", SqlDbType.UniqueIdentifier)).Value = struserid
            cmd.Parameters.Add(New SqlParameter("@email", SqlDbType.NVarChar, 256)).Value = Email.Text.Trim()

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

A:
            Dim d6 As New DataTable
            d6 = obj.returndatatable("select * from UserPaymentDet where Payment_UserId ='" + ID + "'", d6)
            Dim coun1 As String = obj.Returnsinglevalue("select [user_PayModifyCount] from CF_User where user_Id='" + ID + "'")
            Dim admincount1 As String = obj.Returnsinglevalue("select [Settings_MaxPayInfo] from CF_Settings")
            For i As Integer = 0 To d6.Rows.Count - 1
                If Not d6.Rows(i).Item("UserPaymentAccDet") = DirectCast(divtb.FindControl("txtvalue_" + i.ToString), TextBox).Text Then
                    If coun1 >= admincount1 Then
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Your Payment Information Updation Exceeds the maximum number of account Change Please contact Your Admin For More Information');", True)
                        Exit Sub
                    Else
                        Dim count As String = obj.Returnsinglevalue("select user_PayModifyCount from Cf_User where User_Id='" + ID + "'")
                        Dim count1 As String = count + 1
                        cmd = New SqlCommand("update CF_User set user_PayModifyCount='" + count1 + "' where User_Id='" + ID + "'", con)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                        Exit For

                    End If
                End If
            Next



            dt = obj.returndatatable("select * from [cf_CustomProcessingFields] where CustomProcessing_pid='" + cmbPaymentType.SelectedValue + "' and [CustomProcessing_chkfields]='True'", dt)

            cmd = New SqlCommand("delete from UserPaymentDet  where Payment_UserId=@Payment_UserId", con)
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Payment_UserId", SqlDbType.VarChar, 10)).Value = Session("User_Id")
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1


                    'Dim ReqFieldVal As New RequiredFieldValidator

                    'ReqFieldVal.ControlToValidate = "txtvalue_" + i.ToString()

                    'ReqFieldVal.ErrorMessage = "Required"
                    'ReqFieldVal.SetFocusOnError = True
                    'divtb.Controls.Add(ReqFieldVal)
                    '

                    'dt2 = obj.returndatatable("select * from UserPaymentDet where Payment_UserId='" + Session("User_Id") + "'", dt2)

                    'If dt2.Rows.Count > 0 Then
                    '    obj.strMode = "MODIFY"
                    'Else
                    '    obj.strMode = "ADD"

                    'End If

                    'Dim rbtn1 As TextBox
                    'Dim rbpid As String = ""
                    'Dim ctl1 As Control
                    'For Each ctl1 In divtb.Controls
                    '    If TypeOf ctl1 Is TextBox Then
                    '        rbtn1 = DirectCast(ctl1, TextBox)


                    '        rbpid = rbtn1.Text







                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "SP_CF_UserAccDet"
                    cmd.Connection = con

                    cmd.Connection = con
                    'cmd.Parameters.Add(New SqlParameter("@mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                    cmd.Parameters.Add(New SqlParameter("@UserPaymentdet_Id", SqlDbType.VarChar, 10)).Value = obj.getIndexKey
                    cmd.Parameters.Add(New SqlParameter("@Payment_UserId", SqlDbType.VarChar, 10)).Value = Session("User_Id")

                    cmd.Parameters.Add(New SqlParameter("@Payment_procceesingId", SqlDbType.VarChar, 10)).Value = cmbPaymentType.SelectedValue

                    cmd.Parameters.Add(New SqlParameter("@UserPaymentAccDet", SqlDbType.VarChar, 100)).Value = DirectCast(divtb.FindControl("txtvalue_" + i.ToString), TextBox).Text
                    cmd.Parameters.Add(New SqlParameter("@UserPaymentAccDetName", SqlDbType.VarChar, 100)).Value = dt.Rows(i).Item("CustomProcessing_Fields").ToString()
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    lblmsg.Visible = True

                    lblprofile.Visible = False
                    'Exit For

                    'End If

                    'Next





                Next



                'lblmsg.Visible = True
            End If
            'End If
            Select Case obj.strMode

                Case "Modify"

                Case "Delete"

            End Select
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub cmbcountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.SelectedIndexChanged
        txtHomephoneCode.Text = obj.Returnsinglevalue("select country_TelCode from cf_country where country_Id='" + cmbcountry.Text + "'")
    End Sub

    Protected Sub cmbpaymentTypeChanged(sender As Object, e As System.EventArgs) Handles cmbPaymentType.SelectedIndexChanged
        Dim dt As New DataTable
        Dim dt1 As New DataTable

        dt = obj.returndatatable("select * from [cf_CustomProcessingFields] where CustomProcessing_pid='" + cmbPaymentType.SelectedValue + "' and [CustomProcessing_chkfields]='True'", dt)
        dt1 = obj.returndatatable("select * from [UserPaymentDet] where [Payment_UserId] ='" + Session("User_Id").ToString() + "' and [Payment_procceesingId]='" + cmbPaymentType.SelectedValue + "'", dt1)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1


                If dt1.Rows.Count > 0 Then


                    Response.Redirect("Editprofile.aspx")




                Else
                    Dim rbtn1 As TextBox
                    Dim rbpid As String = ""
                    Dim ctl1 As Control
                    For Each ctl1 In divtb.Controls
                        If TypeOf ctl1 Is TextBox Then
                            rbtn1 = DirectCast(ctl1, TextBox)
                            rbtn1.Text = ""
                            rbpid = rbtn1.Text

                        End If
                    Next
                End If
            Next
        End If









    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

    End Sub
End Class
