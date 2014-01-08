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
        Dim str As String = Nothing
        Username = LoginUser.Controls(0).FindControl("UserName")
        Password = LoginUser.Controls(0).FindControl("Password")
        obj.returndatatable("select * from Admin_Users where AdminTickets_username='" + Username.Text + "' and AdminTickets_Password='" + Password.Text + "'", dt)
        If dt.Rows.Count > 0 Then
            obj.g_username = Username.Text
            str = dt.Rows(0)("AdminTickets_Id").ToString()
            Session("Admin_Id") = str
            Response.Redirect("ForumHelp.aspx")
        End If
    End Sub

   
End Class