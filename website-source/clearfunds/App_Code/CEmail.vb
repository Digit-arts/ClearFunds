Imports Microsoft.VisualBasic
Imports System.Net.Mail

Public Class CEmail

#Region "Class Variables and Enums"

#End Region

#Region "Page and controls events"

#End Region

#Region "Custom methods"
    ''' <summary>
    ''' Sub for sending email
    ''' </summary>
    ''' <param name="strEmail"></param>
    ''' <param name="strSubject"></param>
    ''' <param name="strText"></param>
    ''' <remarks></remarks>
    Private Sub SendEmail(ByVal strEmail As String, ByVal strSubject As String, ByVal strText As String)
        Dim mail As New MailMessage()
        Dim emails() As String
        Dim smtp As SmtpClient = Nothing

        Try
            emails = strEmail.Split(";")
            mail.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("EMAILFROM").ToString)

            For Each strE As String In emails
                mail.To.Add(strE)
            Next

            mail.IsBodyHtml = True
            mail.Subject = strSubject
            Dim bod As String = "<img alt=" + Chr(34) + "alt" + Chr(34) + " hspace=" + Chr(34) + "0" + Chr(34) + " src=" + Chr(34) + "cid:imageHeader" + Chr(34) + " align=" + Chr(34) + "baseline" + Chr(34) + " border=" + Chr(34) + "0" + Chr(34) + " ><b>" + strText + "</b><img alt=" + Chr(34) + "alt" + Chr(34) + " hspace=" + Chr(34) + "0" + Chr(34) + " src=" + Chr(34) + "cid:imageFooter" + Chr(34) + " align=" + Chr(34) + "baseline" + Chr(34) + " border=" + Chr(34) + "0" + Chr(34) + " >"
            'No html compatible
            'Dim plainView As AlternateView =
            'AlternateView.CreateAlternateViewFromString(strText + "Plain", Nothing, "text/plain")

            Dim htmlView As AlternateView =
            AlternateView.CreateAlternateViewFromString(bod, Nothing, "text/html")

            'create the AlternateView for embedded image
            Dim imageViewHeader As New AlternateView(System.Web.HttpContext.Current.Server.MapPath("~\Images\head.gif"), System.Net.Mime.MediaTypeNames.Image.Jpeg)
            imageViewHeader.ContentId = "imageHeader"
            imageViewHeader.TransferEncoding = System.Net.Mime.TransferEncoding.Base64

            'create the AlternateView for embedded image
            Dim imageViewFooter As New AlternateView(System.Web.HttpContext.Current.Server.MapPath("~\Images\exportButton.gif"), System.Net.Mime.MediaTypeNames.Image.Gif)
            imageViewFooter.ContentId = "imageFooter"
            imageViewFooter.TransferEncoding = System.Net.Mime.TransferEncoding.Base64

            'add the views
            'mail.AlternateViews.Add(plainView)
            mail.AlternateViews.Add(htmlView)
            mail.AlternateViews.Add(imageViewHeader)
            mail.AlternateViews.Add(imageViewFooter)

            smtp = New SmtpClient(System.Configuration.ConfigurationManager.AppSettings("EMAILSMTP").ToString)
            smtp.Credentials = New System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("EMAILSMTPUSER").ToString, System.Configuration.ConfigurationManager.AppSettings("EMAILSMTPPASSWD").ToString)
            smtp.UseDefaultCredentials = False
            'smtp.EnableSsl = True
            'smtp.Host = "smtp.gmail.com"

            smtp.Port = System.Configuration.ConfigurationManager.AppSettings("EMAILPORT").ToString
            smtp.Send(mail)


            ''create the mail message
            'Dim mail As New MailMessage()

            ''set the addresses
            'mail.From = New MailAddress("from@fromdomain.com", " Display Name")
            'mail.To.Add("to@todomain.com")

            ''set the content
            'mail.Subject = "This is an embedded image mail"

            ''first we create the Plain Text part
            'Dim palinBody As String = "This is my plain text content, viewable by those who dont support html"
            'Dim plainView As AlternateView =
            'AlternateView.CreateAlternateViewFromString(palinBody, Nothing, "text/plain")
            ''then we create the Html part
            ''to embed Images, we need to use the prefix 'cid' in the img src value
            'Dim htmlBody As String = "<b>This is the embedded image file.</b><DIV>&nbsp;</DIV>"
            'htmlBody += "<img alt="""" hspace=0 src=""cid:uniqueId"" align=baseline border = 0 > """
            'htmlBody += "<DIV>&nbsp;</DIV><b>This is the end of Mail...</b>"
            'Dim htmlView As AlternateView =
            ' AlternateView.CreateAlternateViewFromString(htmlBody, Nothing,
            ' "text/html")

            ''create the AlternateView for embedded image
            'Dim imageView As New AlternateView("c:\attachment\image1.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg)
            'imageView.ContentId = "uniqueId"
            'imageView.TransferEncoding = TransferEncoding.Base64

            ''add the views
            'mail.AlternateViews.Add(plainView)
            'mail.AlternateViews.Add(htmlView)
            'mail.AlternateViews.Add(imageView)

            ''send mail
            'SendMail(mail)


        Catch ex As Exception
            '  MsgBox(ex.Message)
        Finally
            If Not mail Is Nothing Then mail.Dispose()
            If Not smtp Is Nothing Then smtp.Dispose()
        End Try
    End Sub

    Public Sub EmailNews(ByVal Title As String, ByVal Description As String, ByVal cdat As Date, ByVal Link As String, ByVal stremail As String)

        Dim txtMessage As String = String.Empty

        txtMessage = Description

        SendEmail(stremail, " " & Title, txtMessage)

    End Sub

    ''' <summary>
    ''' Sub that sends email for new members
    ''' </summary>
    ''' <param name="stremail"></param>
    ''' <remarks></remarks>
    Public Sub EmailNewMember(ByVal stremail As String)

        Dim txtMessage As String = String.Empty

        txtMessage = "Welcome member, please have a look at our new website"

        SendEmail(stremail, "", txtMessage)

    End Sub
    ''' <summary>
    ''' Sub that sends email for new converted pros members 
    ''' </summary>
    ''' <param name="stremail"></param>
    ''' <remarks></remarks>
    Public Sub EmailFromAdminToPro(ByVal stremail As String, ByVal strmessage As String)

       

        SendEmail(stremail, "", strmessage)

    End Sub
    ''' <summary>
    ''' Sub that sends email for new converted pros members 
    ''' </summary>
    ''' <param name="stremail"></param>
    ''' <remarks></remarks>
    Public Sub EmailConvertedPro(ByVal stremail As String, ByVal strUser As String, ByVal strPAsswd As String)

        Dim txtMessage As String = String.Empty

        txtMessage = "Welcome new member, please have a look at our new blabla"
        txtMessage += "Here is your username: " & strUser
        txtMessage += "Here is your password: " & strPAsswd

        SendEmail(stremail, "", txtMessage)

    End Sub

    ''' <summary>
    ''' Sub that sends body error email for admins
    ''' </summary>
    ''' <param name="str"></param>
    ''' <remarks></remarks>
    Public Sub EmailError(ByVal str As String)

        SendEmail(System.Configuration.ConfigurationManager.AppSettings("EMAILADMIN"), "", str)

    End Sub

    ''' <summary>
    ''' Sub that prepare reply comment messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <remarks></remarks>
    Public Sub EmailSubmissionReplyComments(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "A new comment have been post at this submission:"

        If isSendEmail Then
            SendEmail(txtEmails, "subject", txtMessage)
        End If

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare meeting proposed messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <remarks></remarks>
    Public Sub EmailSubmissionMeetingProposed(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "Pro: Client has proposed a new meeting, please follow this link to see meeting: "

        If isSendEmail Then
            SendEmail(txtEmails, "subject", txtMessage)
        End If

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare meeting confirmation messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <remarks></remarks>
    Public Sub EmailSubmissionMeetingConfirmed(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "Pro: Client has confirmed meeting, please follow this link to see meeting: "

        If isSendEmail Then
            SendEmail(txtEmails, "subject", txtMessage)
        End If

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare submission pro to client messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <param name="strLink"></param>
    ''' <remarks></remarks>
    Public Sub EmailSubmissionProToClient(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String, ByVal strLink As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "Pro: Here is your submission by following this link: " & strLink

        If isSendEmail Then
            SendEmail(txtEmails, "subject", txtMessage)
        End If

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare submission to admin to verify messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <param name="strLink"></param>
    ''' <remarks></remarks>
    Public Sub EmailSubmissionToAdmin(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String, ByVal strLink As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "Admin: Please certify this request by following this link: " & strLink

        If isSendEmail Then
            SendEmail(txtEmails, "subject", txtMessage)
        End If

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare admin confirmation to client messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <param name="strLink"></param>
    ''' <remarks></remarks>
    Public Sub EmailSubmissionNotRejectedToClient(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String, ByVal strLink As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "Your request for a submission as been accepted by website administrators, Please follow this link to see status: " & strLink

        If isSendEmail Then
            SendEmail(txtEmails, "subject", txtMessage)
        End If

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare transaction confirmation messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <param name="strLink"></param>
    ''' <remarks></remarks>
    Public Sub EmailTransactionConfirmation(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String, ByVal strLink As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "The transaction has been successfull, please following this link to get started: " & strLink
        SendEmail(txtEmails, "subject", txtMessage)

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare event reminders messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <param name="strLink"></param>
    ''' <remarks></remarks>
    Public Sub EmailEventReminders(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String, ByVal strLink As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "You have an event comming up, please see event by following this link: " & strLink

        If isSendEmail Then
            SendEmail(txtEmails, "subject", txtMessage)
        End If

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare membership renewal reminder messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <param name="strLink"></param>
    ''' <remarks></remarks>
    Public Sub EmailMembershipReminders(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String, ByVal strLink As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "Youre membership is coming overdue, please renew membership by following this link: " & strLink

        If isSendEmail Then
            SendEmail(txtEmails, "subject", txtMessage)
        End If

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare submission rejected to client messsages for sms and email
    ''' </summary>
    ''' <param name="isSendEmail"></param>
    ''' <param name="SendSMS"></param>
    ''' <param name="smsEmail"></param>
    ''' <param name="txtEmails"></param>
    ''' <param name="strLink"></param>
    ''' <remarks></remarks>
    Public Sub EmailSubmissionRejectedToClient(ByVal isSendEmail As Boolean, ByVal SendSMS As Boolean, ByVal smsEmail As String, ByVal txtEmails As String, ByVal strLink As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "Your request for a submission as been refused by website administrators, please see reason by following this link: " & strLink

        If isSendEmail Then
            SendEmail(txtEmails, "subject", txtMessage)
        End If

        If SendSMS Then
            SendEmail(smsEmail, "subject", txtMessage)
        End If
    End Sub

    ''' <summary>
    ''' Sub that prepare submission to pro messsages for sms and email
    ''' </summary>
    ''' <param name="txtEmails"></param>
    ''' <param name="strSms"></param>
    ''' <param name="strLink"></param>
    ''' <remarks></remarks>
    Public Sub EmailSubmissionToPro(ByVal txtEmails As String, ByVal strSms As String, ByVal strLink As String)
        Dim txtMessage As String = String.Empty

        'EMAILS
        txtMessage = "Please make submission for this request by following this link: " & strLink
        SendEmail(txtEmails, "subject", txtMessage)

        'SMS
        txtMessage = "Please make submission for this request by following this link: " & strLink
        SendEmail(strSms, "subject", txtMessage)
    End Sub
    Public Sub EmailToUser(ByVal txtEmails As String)
        Dim txtmessage As String = String.Empty
        txtmessage = "password has been changed successfully"
        SendEmail(txtEmails, "subject", txtmessage)
    End Sub

    ''' <summary>
    ''' Sub that send forgotten passwd to user
    ''' </summary>
    ''' <param name="txtEmails"></param>
    ''' <remarks></remarks>
    Public Sub EmailPasswForgot(ByVal txtEmails As String, ByVal txtpasswd As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "Contact email: " & txtEmails
        txtMessage = "Password: " & txtpasswd

        SendEmail(txtEmails, "subject", txtMessage)
    End Sub

    ''' <summary>
    ''' Sub that prepare webmaster contact messsages for email
    ''' </summary>
    ''' <param name="txtEmails"></param>
    ''' <param name="txtfirstname"></param>
    ''' <param name="txtlastname"></param>
    ''' <param name="txtText"></param>
    ''' <remarks></remarks>
    Public Sub EmailContact(ByVal txtEmails As String, ByVal txtfirstname As String, ByVal txtlastname As String, ByVal txtText As String)
        Dim txtMessage As String = String.Empty

        txtMessage = "Contact email: " & txtEmails
        txtMessage = "FirstName: " & txtfirstname
        txtMessage = "Lastname: " & txtlastname
        txtMessage = "Comment: " & txtText

        SendEmail(txtEmails, "subject", txtMessage)
    End Sub

    ''' <summary>
    ''' Sub that prepare tell a friend messsages for email
    ''' </summary>
    ''' <param name="txtemails"></param>
    ''' <param name="txtMessage"></param>
    ''' <remarks></remarks>
    Public Sub EmailTellAFriend(ByVal txtemails As String, ByVal txtMessage As String, ByVal txtyouremail As String, ByVal txtyourfriendname As String, ByVal txtyourname As String)
        SendEmail(txtemails, "tell a friend", txtMessage)
    End Sub
#End Region
End Class
