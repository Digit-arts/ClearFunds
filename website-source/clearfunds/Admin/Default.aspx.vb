Imports System.Data.SqlClient
Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))

    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As New DataTable()
        Dim Username As TextBox
        Dim Password As TextBox
        Username = LoginUser.Controls(0).FindControl("UserName")
        Password = LoginUser.Controls(0).FindControl("Password")
        dt = obj.returndatatable("select * from Cf_Admin where admin_username='" + Username.Text + "' and Admin_Password='" + Password.Text + "'", dt)
        If dt.Rows.Count > 0 Then
            obj.g_username = Username.Text
            Session("Admin_UserName") = dt.Rows(0).Item("Admin_UserName")
            Session("Admin_MailId") = dt.Rows(0).Item("Admin_MailId")
            Session("Admin_RoleId") = dt.Rows(0).Item("Admin_RoleId")
            Response.Redirect("dashboard.aspx")
        End If
    End Sub

   
End Class