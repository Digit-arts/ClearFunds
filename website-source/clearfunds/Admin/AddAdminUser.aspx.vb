Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Security
Partial Class Admin_AddAdminUser

    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Dim con As New SqlConnection

    Dim cmd As New SqlCommand()
    Dim adminid As String = Nothing


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load



        If Not IsPostBack Then
            Dim con1 As New SqlConnection(obj.ConnectionString())
            Dim cmd1 As New SqlCommand("select RoleName,Role_Id from CF_Roles", con1)
            cmd1.Connection.Open()
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            DropDownList1.DataSource = dr1
            DropDownList1.DataValueField = "Role_Id"
            DropDownList1.DataTextField = "RoleName"
            DropDownList1.DataBind()
            cmd1.Connection.Close()
            cmd1.Connection.Dispose()
            If Not (Request.QueryString("id") = Nothing) Then

                adminid = Request.QueryString("id").ToString()
                con = New SqlConnection(obj.ConnectionString)
                con.Open()
                obj.returndatatable("select * from CF_Admin where Admin_id='" + adminid + "'", dt)
                If (dt.Rows.Count > 0) Then
                    Button1.Text = "Update"
                    'txtconfirmpassword.Visible = False
                    'txtpassword.Visible = False
                    RequiredFieldValidator2.Visible = False
                    'lblconfirmpassword.Visible = False
                    'lblpassowrd.Visible = False
                    txtusername.Enabled = False
                    Dim con As New SqlConnection(obj.ConnectionString())
                    Dim cmd As New SqlCommand("select RoleName,Role_Id from CF_Roles", con)
                    cmd.Connection.Open()
                    Dim dr As SqlDataReader
                    dr = cmd.ExecuteReader()
                    DropDownList1.DataSource = dr
                    DropDownList1.DataValueField = "Role_Id"
                    DropDownList1.DataTextField = "RoleName"
                    DropDownList1.DataBind()
                    cmd.Connection.Close()
                    cmd.Connection.Dispose()
                    DropDownList1.SelectedItem.Text = dt.Rows(0).Item("Admin_RoleId").ToString()
                    txtemail.Text = dt.Rows(0).Item("Admin_MailId").ToString()
                    txtusername.Text = dt.Rows(0).Item("Admin_username").ToString()
                    txtname.Text = dt.Rows(0).Item("Admin_Name").ToString()
                    txtpassword.Text = dt.Rows(0).Item("Admin_password").ToString()

                End If

            End If
        End If

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Not (Request.QueryString("id") = Nothing) Then
            obj.strMode = "MODIFY"
        Else
            obj.strMode = "ADD"
        End If
        If (Button1.Text = "Save") Then
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_Admin"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@Admin_id", SqlDbType.VarChar, 10)).Value = obj.getIndexKey
            cmd.Parameters.Add(New SqlParameter("@Admin_Name", SqlDbType.VarChar, 100)).Value = txtname.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@Admin_username ", SqlDbType.VarChar, 20)).Value = txtusername.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@Admin_password", SqlDbType.VarChar, 20)).Value = txtpassword.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@Admin_RoleId", SqlDbType.VarChar, 100)).Value = DropDownList1.SelectedItem.Text
            cmd.Parameters.Add(New SqlParameter("@Admin_MailId", SqlDbType.VarChar, 100)).Value = txtemail.Text.Trim()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            Dim body As String = (("UserName :" + txtusername.Text & "<br/>" & "Password :") + txtpassword.Text & "<br/>" & "Message :") + ", please click on the link  http://localhost:3729/Clearfundslive10062013/HelpDesk" & "<br/>" & "Thanks" & "<br/>" & "http://clearfunds.acopies.com/"
            Dim recemail As String = txtemail.Text
            SendEmail(recemail, "Welcome our clearfunds website", body)


            Dim message As String = "Saved SuccessFully"
            Dim url As String = "AdminUsers.aspx"
            Dim script As String = "window.onload = function(){ alert('"
            script += message
            script += "');"
            script += "window.location = '"
            script += url
            script += "'; }"
            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
            con.Close()
            Call clear()

        End If
        If (Button1.Text = "Update") Then
            adminid = Request.QueryString("id").ToString()
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_Admin"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@Admin_id", SqlDbType.VarChar, 10)).Value = adminid
            cmd.Parameters.Add(New SqlParameter("@Admin_Name", SqlDbType.VarChar, 100)).Value = txtname.Text
            cmd.Parameters.Add(New SqlParameter("@Admin_username ", SqlDbType.VarChar, 20)).Value = txtusername.Text
            cmd.Parameters.Add(New SqlParameter("@Admin_password", SqlDbType.VarChar, 20)).Value = txtpassword.Text
            cmd.Parameters.Add(New SqlParameter("@Admin_RoleId", SqlDbType.VarChar, 100)).Value = DropDownList1.SelectedItem.Text
            cmd.Parameters.Add(New SqlParameter("@Admin_MailId", SqlDbType.VarChar, 100)).Value = txtemail.Text

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            Dim message As String = "Updated SuccessFully"
            Dim url As String = "AdminUsers.aspx"
            Dim script As String = "window.onload = function(){ alert('"
            script += message
            script += "');"
            script += "window.location = '"
            script += url
            script += "'; }"
            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)

            con.Close()
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call clear()
    End Sub
    Public Sub clear()
        txtusername.Text = ""
        txtemail.Text = ""

        txtpassword.Text = ""
        txtconfirmpassword.Text = ""
        txtname.Text = " "

    End Sub
    Private Sub SendEmail(ByVal recepientEmail As String, ByVal subject As String, ByVal body As String)
        Using mailMessage As New MailMessage()
            mailMessage.From = New MailAddress(ConfigurationManager.AppSettings("UserName"))
            mailMessage.Subject = subject
            mailMessage.Body = body
            mailMessage.IsBodyHtml = True
            mailMessage.[To].Add(New MailAddress(recepientEmail))
            Dim smtp As New SmtpClient()
            smtp.Host = ConfigurationManager.AppSettings("Host")
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings("EnableSsl"))
            Dim NetworkCred As New System.Net.NetworkCredential()
            NetworkCred.UserName = ConfigurationManager.AppSettings("UserName")
            NetworkCred.Password = ConfigurationManager.AppSettings("Password")
            smtp.UseDefaultCredentials = False
            smtp.Credentials = NetworkCred
            smtp.Port = Integer.Parse(ConfigurationManager.AppSettings("Port"))
            smtp.Send(mailMessage)
        End Using
    End Sub
End Class
