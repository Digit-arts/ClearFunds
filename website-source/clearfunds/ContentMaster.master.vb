Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports System.Web
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Security

Partial Class ContentMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            'Login1.Visible = False
            'HyperLink1.Visible = True
        Else
            'HyperLink1.Visible = False
        End If


        If Not Session("User_Id") = Nothing Then

            SmallLogout1.Visible = True
            'Menu.Visible = True
            HyperLink1.Visible = True
            'Menuleft.Visible = True
            Panel1.Visible = False
        Else
            'Menu.Visible = False
            HyperLink1.Visible = False
            Panel1.Visible = True
            SmallLogout1.Visible = False
            'Menuleft.Visible = False
        End If
        Dim obj As New ClassFunctions()

        'If Not IsPostBack = True Then


        Dim dt1 As New DataTable()
        dt1 = obj.returndatatable("select top 10 UserName,CONVERT (varchar, WithDrawl_Date,106) as Date, WithDrawl_Amount as Amount,withdrawl_PackageId,Auto_WithDrawl,WithDrawl_PayName from CF_WithDrawl a Join aspnet_Users b on b.UserId=a.WithDrawl_UserId order by WithDrawl_Date desc", dt1)
        'GVWDHistory.DataSource = dt1
        'GVWDHistory.DataBind()
        Dim dt As New DataTable
        dt = obj.returndatatable("select * from [CF_contents] where [contents_publish]=1 and [contents_fid]=1 and contents_status=1 order by contents_orderno ", dt)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim div As New HtmlGenericControl("div")
                menu.Controls.Add(div)
                Dim ul As New HtmlGenericControl("ul")
                div.Controls.Add(ul)
                Dim li As New HtmlGenericControl("li")
                ul.Controls.Add(li)

                Dim hyp1 As New HyperLink
                hyp1.ID = dt.Rows(i).Item("contents_id").ToString()
                hyp1.Text = dt.Rows(i).Item("contents_title").ToString()

                If hyp1.ID = "6" Then
                    hyp1.NavigateUrl = "~/default.aspx"

                ElseIf hyp1.ID = "11" Then
                    hyp1.NavigateUrl = "~/News.aspx"

                ElseIf hyp1.ID = "12" Then
                    hyp1.NavigateUrl = "~/FAQ.aspx"
                ElseIf hyp1.ID = "9" Then
                    hyp1.NavigateUrl = "~/Voteus.aspx"
                ElseIf hyp1.ID = "13" Then
                    hyp1.NavigateUrl = "~/Contact.aspx"
                Else
                    hyp1.NavigateUrl = "~/content.aspx?id=" + dt.Rows(i).Item("contents_id").ToString()
                End If
                li.Controls.Add(hyp1)
            Next
        End If
        'End If
    End Sub

    Protected Sub btnsubscribe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubscribe.Click
      
        Dim con As New SqlConnection
        Dim obj As New ClassFunctions()
        con = New SqlConnection(obj.ConnectionString)
        con.Open()
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_CF_Subscription"
        cmd.Connection = con
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = "ADD"
        cmd.Parameters.Add(New SqlParameter("@subscirbe_Emailid ", SqlDbType.VarChar, 75)).Value = txtemail.Text.Trim()
        cmd.Parameters.Add(New SqlParameter("@subscirbe_Date ", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
        cmd.Parameters.Add(New SqlParameter("@subscirbe_ipaddress", SqlDbType.VarChar, 75)).Value = strIPAddress
        Dim dt As DataTable
        obj.returndatatable("select subscirbe_Emailid from CF_Subscription where  subscirbe_Emailid='" + txtemail.Text + "'", dt)
        If (dt.Rows.Count > 0) Then
            lblmsg.Text = "Your Emailid already Subscribed"
        Else
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            Dim body As String = (("Email :") + txtemail.Text & "<br/>" & "Message :") + "welcome to  clearfunds website your subsciption alert activated successfully"
            Dim recemail As String = txtemail.Text
            SendEmail(recemail, "clearfunds subscription alert message ", body)
            lblmsg.Text = "Your Request Has Been Successfully Submitted"
            txtemail.Text = ""
        End If

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

