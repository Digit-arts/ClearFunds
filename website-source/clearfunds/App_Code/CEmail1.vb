Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Linq
Imports System.Web
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Security
Imports System.Data.SqlClient

Public Class CEmail1
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

    Private Sub EmailNews(ByVal Title As String, ByVal Description As String, ByVal cdat As DateTime, ByVal Link As String, ByVal stremail As String)
        Dim txtMessage As String = [String].Empty
        txtMessage = Description
        SendEmail(stremail, (" " & Title), txtMessage)
    End Sub


    Public Sub EmailNewMember(ByVal stremail As String)
        Dim txtMessage As String = [String].Empty
        txtMessage = "Welcome member, please have a look at our new website http://clearfunds.acopies.com"
        SendEmail(stremail, "", txtMessage)
    End Sub
    Public Sub EmailSendmsg(ByVal txtEmails As String, ByVal msg As String)


        SendEmail(txtEmails, "Message From Clearfunds", msg)
    End Sub
    Public Sub EmailToUser(ByVal txtEmails As String)
        Dim txtmessage As String = [String].Empty
        txtmessage = "password has been changed successfully"
        SendEmail(txtEmails, "subject", txtmessage)
    End Sub

    Public Sub EmailToyahooUser(ByVal txtEmails As String)
        Dim txtmessage As String = [String].Empty
        txtmessage = "http://clearfunds.acopies.com"
        SendEmail(txtEmails, "subject", txtmessage)
    End Sub

    Public Sub Emailacceptfriend(ByVal txtEmails As String)
        Dim txtmessage As String = [String].Empty
        txtmessage = "friend request accepted"
        SendEmail(txtEmails, "subject", txtmessage)
    End Sub

    Public Sub EmailRejectfriend(ByVal txtEmails As String)
        Dim txtmessage As String = [String].Empty
        txtmessage = "friend request Rejected"
        SendEmail(txtEmails, "subject", txtmessage)
    End Sub

    Public Sub EmailsendfriendRequest(ByVal txtEmails As String)
        Dim txtmessage As String = [String].Empty
        txtmessage = "friend request has been recieved"
        SendEmail(txtEmails, "subject", txtmessage)
    End Sub
    Public Sub EmailPasswForgot(ByVal txtEmails As String, ByVal txtpasswd As String)
        Dim txtMessage As String = [String].Empty
        txtMessage = ("Contact email: " & txtEmails)
        txtMessage = ("Password: " & txtpasswd)
        SendEmail(txtEmails, "Forgot PassWord", txtMessage)
    End Sub


    Public Sub EmailPost(ByVal txtEmails As String)
        Dim txtmessage As String = [String].Empty
        txtmessage = " new post has been recieved"
        SendEmail(txtEmails, "subject", txtmessage)
    End Sub

    Public Sub EmailSendbonus(ByVal txtEmails As String, ByVal amount As Decimal)
        Dim txtMessage As String = [String].Empty
        'txtMessage = ("Contact email: " & txtEmails)
        'txtMessage = ("Bonus: " & amount)
        Dim dst As New DataSet
        dst = ReturnTemplate("sendbouns")
        Dim mainbody As String

        mainbody = dst.Tables(0).Rows(0).Item("Email_Templates_Message")
        mainbody.Replace("[Bonus_Amount]", amount)
        SendEmail(txtEmails, dst.Tables(0).Rows(0).Item("Email_Templates_Subject"), mainbody)
    End Sub
    Public Sub emailSendPenality(ByVal txtEmails As String, ByVal amount As Decimal)
        Dim txtMessage As String = [String].Empty
        txtMessage = ("Contact email: " & txtEmails)
        txtMessage = ("Penality: " & amount)
        SendEmail(txtEmails, "Bonus From http://clearfunds.acopies.com", txtMessage)
    End Sub

    Public Function ReturnTemplate(ByVal Templates_Title As String) As DataSet
        Dim sqlcon As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ApplicationServices").ToString)
        Dim SqlCmd As New SqlCommand()
        Dim Ds As New DataSet
        Dim SqlAda As New SqlDataAdapter
        ReturnTemplate = Nothing
        Try
            sqlcon.Open()
            SqlCmd.Connection = sqlcon
            SqlCmd.CommandText = "select Email_Templates_Subject, Email_Templates_Message from CF_Email_Templates where Email_Templates_Title='" & Templates_Title & "'"
            SqlCmd.CommandType = CommandType.Text
            SqlAda.SelectCommand = SqlCmd
            SqlAda.Fill(Ds, "TableName")
            Return Ds
        Catch ex As Exception
        Finally
            If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
            SqlCmd.Dispose()
            sqlcon.Dispose()
            SqlCmd = Nothing
            sqlcon = Nothing
        End Try
    End Function
End Class


