Imports System.Data
Imports System.Net.Mail
Imports System.Configuration
Imports System.IO

Partial Class Admin_NewsLetter
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Protected Sub cmbsentuser_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsentuser.SelectedIndexChanged
        txtToMembers.Text = ""
        If cmbsentuser.SelectedIndex > 1 Then
            dt = obj.returnSPdatatable("SP_CF_GetMembers", dt, cmbsentuser.SelectedIndex)
            txtToMembers.Enabled = False
            If dt.Rows.Count > 0 Then
               
                For i = 0 To dt.Rows.Count - 1
                    If Trim(txtToMembers.Text) = "" Then
                        txtToMembers.Text = dt.Rows(i).Item(0).ToString()
                    Else
                        txtToMembers.Text = txtToMembers.Text & "," & dt.Rows(i).Item(0).ToString()
                    End If
                Next
            End If
                Dim arr() As String
            arr = Split(txtToMembers.Text, ",")
        Else
            txtToMembers.Enabled = True
        End If


    End Sub

    Protected Sub SendEmail(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim body As String = ""

        Dim subject As String = txtDescription.Text
        Dim description As String = Editor1.Content
        body = ("'" + description + "'")

        Me.SendHtmlFormattedEmail("'" + subject + "'", body)

    End Sub
    Private Sub SendHtmlFormattedEmail(ByVal subject As String, ByVal body As String)
        Dim arr() As String
        arr = Split(txtToMembers.Text, ",")
      
        Dim cm1 As New CEmail1
      
        For Each emailrecipientid As String In arr

            Dim uid As Guid = obj.ReturnsingleGuid("select userId from aspnet_users where username='" + emailrecipientid + "'")
            Dim uid1 As String = Convert.ToString(uid)
            Dim email As String = obj.Returnsinglevalue("select email from aspnet_membership where userId='" + uid1 + "'")

            Dim uname As String = ""
            uname = obj.Returnsinglevalue("select c.UserName from aspnet_Membership a join aspnet_Users c on a.UserId=c.UserId where a.Email='" + emailrecipientid + "'")


            Using mailMessage As New MailMessage()
                mailMessage.From = New MailAddress(ConfigurationManager.AppSettings("UserName"))
                mailMessage.Subject = subject
                mailMessage.Body = "Hi " + uname + "<br>" + body
                mailMessage.IsBodyHtml = True
                If Not emailrecipientid = Nothing Then
                    mailMessage.[To].Add(New MailAddress(email))
                End If

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
        Next
        lblmessage.Visible = True
    End Sub
End Class
