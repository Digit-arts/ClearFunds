Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization


Partial Class Account_Register
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Dim ipno As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            Response.Redirect("~/Default.aspx")

         

        End If
        Dim ipaddress As String

        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")

        If ipaddress = "" Or ipaddress Is Nothing Then

            ipaddress = Request.ServerVariables("REMOTE_ADDR")

        End If
    End Sub



    Protected Sub RegisterUser_CreatedUser(ByVal sender As Object, ByVal e As EventArgs) Handles RegisterUser.CreatedUser
        Try


            obj.strMode = "Add"
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, False)
            Dim dt As New DataTable()
            Dim dt2 As New DataTable()
            'Dim i As Integer
            Dim ID As String = ""
            Dim dt1 As New DataTable

            Dim cmbsaluation As DropDownList
            Dim txtFirstName As TextBox
            Dim txtLastName As TextBox
            Dim UserName As TextBox
            Dim lblmessage As Label

            Dim Email As TextBox
            Dim Password As TextBox
            Dim ConfirmPassword As TextBox
            Dim txtCaptcha As TextBox
            cmbsaluation = RegisterUserWizardStep.Controls(0).FindControl("cmbsaluation")
            txtFirstName = RegisterUserWizardStep.Controls(0).FindControl("txtFirstName")
            txtLastName = RegisterUserWizardStep.Controls(0).FindControl("txtLastName")
            UserName = RegisterUserWizardStep.Controls(0).FindControl("UserName")

            Email = RegisterUserWizardStep.Controls(0).FindControl("Email")
            Password = RegisterUserWizardStep.Controls(0).FindControl("Password")
            ConfirmPassword = RegisterUserWizardStep.Controls(0).FindControl("ConfirmPassword")
            txtCaptcha = RegisterUserWizardStep.Controls(0).FindControl("txtCaptcha")
            lblmessage = RegisterUserWizardStep.Controls(0).FindControl("lblmessage")
            'Dim thirdparty As RadioButton
            'Dim active As String
            'thirdparty = RegisterUserWizardStep.Controls(0).FindControl("radioyes")
            'If thirdparty.Checked = True Then
            '    active = "Yes"
            'Else
            '    active = "No"
            'End If

            Select Case obj.strMode
                Case "Add"
                    ID = obj.getIndexKey()
                    
                Case "Modify"

                    ID = SelectedIndexId
                    
                Case "Delete"

                    'If status = "C" Then
                    'MsgBox("This Order Picked invoice So u can't delete.")
                    
            End Select
            Dim strHostName As String
            Dim strIPAddress As String
            strHostName = System.Net.Dns.GetHostName()
            strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()




            'Dim strcurip As String = "106.213.122.187"
            Dim ipcurrno As String = getCountry(strIPAddress)

            Dim countryname As String = obj.Returnsinglevalue("select con_name from IP where ipno_from <= '" + ipcurrno + "' and ipno_to>='" + ipcurrno + "'")

            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_User"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@User_Id", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@User_UserId", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(obj.Returnsinglevalue("select convert(varchar(50),userid) as userid from aspnet_Users where username = '" + UserName.Text + "'"))
            cmd.Parameters.Add(New SqlParameter("@User_Saluation", SqlDbType.VarChar, 10)).Value = cmbsaluation.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@User_FirstName ", SqlDbType.VarChar, 75)).Value = txtFirstName.Text
            cmd.Parameters.Add(New SqlParameter("@User_LastName", SqlDbType.VarChar, 75)).Value = txtLastName.Text
            'cmd.Parameters.Add(New SqlParameter("@User_ThirdParty", SqlDbType.VarChar, 10)).Value = active.ToString()
            cmd.Parameters.Add(New SqlParameter("@User_RegDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.Parameters.Add(New SqlParameter("@User_IDDetails", SqlDbType.VarChar, 50)).Value = Environment.MachineName()

            cmd.Parameters.Add(New SqlParameter("@user_SysIp", SqlDbType.VarChar, 50)).Value = strIPAddress

            cmd.Parameters.Add(New SqlParameter("@user_CountryName", SqlDbType.VarChar, 100)).Value = countryname

            If countryname = "India" Then
                cmd.Parameters.Add(New SqlParameter("@user_Status", SqlDbType.VarChar, 10)).Value = "Active"
            Else
                cmd.Parameters.Add(New SqlParameter("@user_Status", SqlDbType.VarChar, 10)).Value = "Suspended"
            End If
            cmd.ExecuteNonQuery()

            cmd.Parameters.Clear()

            Session("User_Id") = ID
            SelectedIndexId = Session("User_Id")
            If Not Request.QueryString("UserName") = Nothing Then
                'If obj.strMode = "Add" Then

                Dim referId As Guid = obj.ReturnsingleGuid("select UserId from aspnet_Users where UserName='" + Request.QueryString("UserName") + "'")
                Dim rfstr As String = Convert.ToString(referId)
                Dim referId1 As String = obj.Returnsinglevalue("select User_Id from CF_User where User_UserId='" + rfstr + "'")
                cmd.CommandText = "SP_CF_Referral"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode

                cmd.Parameters.Add(New SqlParameter("@referral_id", SqlDbType.VarChar, 18)).Value = obj.getIndexKey()
                cmd.Parameters.Add(New SqlParameter("@referenceUser_id", SqlDbType.VarChar, 18)).Value = referId1
                cmd.Parameters.Add(New SqlParameter("@User_Id", SqlDbType.VarChar, 18)).Value = SelectedIndexId
                cmd.Parameters.Add(New SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
                cmd.ExecuteNonQuery()

                cmd.Parameters.Clear()

            End If

            Dim cmail As CEmail1
            cmail = New CEmail1
            cmail.EmailNewMember(Email.Text)
            lblmessage.Visible = True

            Select Case obj.strMode
                Case "Add"
                    'MsgBox("Data Was Saved.")


                Case "Modify"
                    'MsgBox("Data Was Modified.")
                Case "Delete"
                    ' MsgBox("Data Was Deleted.")
            End Select

        Catch ex As Exception
            'MsgBox(ex.Message)
            obj.strMode = "Add"

            obj = Nothing
        Finally


            Dim continueUrl As String = RegisterUser.ContinueDestinationPageUrl
            If String.IsNullOrEmpty(continueUrl) Then
                continueUrl = "~/Account/profile.aspx"
            End If

            Response.Redirect(continueUrl)

        End Try

       
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
End Class
