﻿Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Security
Partial Class About
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Label12.Text = "CONTACT US"
        Label12.CssClass = "innerptitl"
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con As New SqlConnection
        Dim obj As New ClassFunctions()
        con = New SqlConnection(obj.ConnectionString)
        con.Open()
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_CF_ContactUs"
        cmd.Connection = con
        cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = "ADD"
        cmd.Parameters.Add(New SqlParameter("@Contact_FirstName ", SqlDbType.VarChar, 75)).Value = txtfirstname.Text.Trim()
        cmd.Parameters.Add(New SqlParameter("@Contact_LastName", SqlDbType.VarChar, 75)).Value = txtlastname.Text.Trim()
        cmd.Parameters.Add(New SqlParameter("@Contact_EmailId ", SqlDbType.VarChar, 100)).Value = txtemail.Text.Trim()
        cmd.Parameters.Add(New SqlParameter("@Contact_Comments", SqlDbType.VarChar, 75)).Value = txtcomments.Text.Trim()
        cmd.Parameters.Add(New SqlParameter("@Contact_Date ", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        Dim body As String = (("Name :" + txtfirstname.Text & "<br/>" & "Email :") + txtemail.Text & "<br/>" & "Message :") + txtcomments.Text
        Dim recemail As String = ConfigurationManager.AppSettings("EMAILADMIN")
        SendEmail(recemail, "Enquiry From " + txtfirstname.Text, body)
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Your Request Has Been Successfully Submitted');", True)
        txtcomments.Text = ""
        txtemail.Text = ""
        txtfirstname.Text = ""
        txtlastname.Text = ""
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