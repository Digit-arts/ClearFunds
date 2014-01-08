Imports System.Data
Imports System.Data.SqlClient
Partial Class Profile
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


        If Not Session("User_Id") = Nothing Then


            If IsPostBack = False Then
                SelectedIndexId = Session("User_Id")

                dt = obj.returndatatable("select c.User_Saluation,c.User_FirstName,c.User_LastName,b.UserName,c.User_State,c.User_Addr1,c.User_Addr2,c.User_City,c.User_Region,c.User_PostelCode,cc.Country_Name,c.User_Phone, CONVERT (varchar, c.User_DOB,106) as User_DOB,cf.CustomProcessing_Name,c.user_AccountEmail,co.Occupation_Name,c.user_ThirdParty,a.Email from CF_User c left join aspnet_Membership a  on a.UserId=c.User_UserId left join aspnet_Users b on a.UserId=b.UserId left join CF_Country cc on c.User_CountryId=cc.Country_Id left join CF_CustomProcessing cf on c.user_PaymentTypeId=cf.CustomProcessing_Id left join CF_Occupation co on c.User_Occupation=co.Occupation_Id  where c.User_Id='" + SelectedIndexId + "'", dt)
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
                    cmbcountry.Text = dt.Rows(0).Item("Country_Name").ToString
                    txtHomephoneCode.Text = obj.Returnsinglevalue("select country_TelCode from cf_country where country_name='" + dt.Rows(0).Item("country_name").ToString + "'")
                    txtHomePhone.Text = dt.Rows(0).Item("User_Phone").ToString()
                    txtstate.Text = dt.Rows(0).Item("User_State").ToString()
                    txtdob.Text = dt.Rows(0).Item("User_DOB").ToString()
                    cmbPaymentType.Text = dt.Rows(0).Item("CustomProcessing_Name").ToString()
                    
                    'txtAccEmailId.Text = dt.Rows(0).Item("user_AccountEmail").ToString()
                    cmbOccupation.Text = dt.Rows(0).Item("Occupation_Name").ToString()
                    If dt.Rows(0).Item("user_ThirdParty").ToString = "Yes" Then
                        radioyes.Checked = True

                    Else
                        radioNo.Checked = True
                    End If
                    Email.Text = dt.Rows(0).Item("Email").ToString()

                End If

            Else
                'Response.Redirect("login.aspx")
            End If
            Dim dt1 As New DataTable
            Dim dt3 As New DataTable
            Dim cmb As String = obj.Returnsinglevalue("select [CustomProcessing_id] from [CF_CustomProcessing] where [CustomProcessing_Name]='" + cmbPaymentType.Text + "'")
            dt3 = obj.returndatatable("select * from [cf_CustomProcessingFields] where CustomProcessing_pid='" + cmb + "' and [CustomProcessing_chkfields]='True'", dt3)
            dt1 = obj.returndatatable("select * from [UserPaymentDet] where [Payment_UserId] ='" + Session("User_Id").ToString() + "' and [Payment_procceesingId]='" + cmb + "'", dt1)
            If dt3.Rows.Count > 0 Then
                For i As Integer = 0 To dt3.Rows.Count - 1

                    Dim tbl As New Table()
                    divtb.Controls.Add(tbl)
                    Dim tr As New TableRow()
                    tbl.Controls.Add(tr)
                    Dim tc As New TableCell()
                    tr.Controls.Add(tc)
                    Dim tc1 As New TableCell()
                    tr.Controls.Add(tc1)
                    Dim lb As New Label
                    lb.Text = dt3.Rows(i).Item("CustomProcessing_fields").ToString()


                    tc.Controls.Add(lb)




                    Dim tb As New Label

                    tb.ID = "txtvalue_" + i.ToString()
                    'tb.Text = dt1.Rows(i).Item("UserPaymentAccDet").ToString()

                    If dt1.Rows.Count > 0 Then
                        tb.Text = dt1.Rows(i).Item("UserPaymentAccDet").ToString()
                        'tb.Enabled = False

                    Else
                        tb.Text = ""
                        'tb.Enabled = False
                    End If

                    tc1.Controls.Add(tb)
                    Dim br2 As New HtmlGenericControl("br")
                    divtb.Controls.Add(br2)


                Next


            End If
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

   
   
    Protected Sub Modify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        Response.Redirect("editprofile.aspx")
    End Sub
End Class
