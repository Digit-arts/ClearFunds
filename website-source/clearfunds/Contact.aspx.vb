Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Security
Partial Class About
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Label12.Text = "CONTACT US"
            Label12.CssClass = "innerptitl"

            Dim contentid As String = "13"
            Dim dt1 As New DataTable()
            dt1 = obj.returndatatable("select * from [CF_contents] where [contents_id]='" & contentid & "'", dt1)
            'Page title
            Page.Title = dt1.Rows(0)("contents_metatitle").ToString()
            'Page description
            Dim pagedesc As New HtmlMeta()
            pagedesc.Name = dt1.Rows(0)("contents_metakey").ToString()
            pagedesc.Content = dt1.Rows(0)("contents_metadesc").ToString()
            Header.Controls.Add(pagedesc)
            'page keywords
            Dim pagekeywords As New HtmlMeta()
            pagekeywords.Name = dt1.Rows(0)("contents_metakey").ToString()
            pagekeywords.Content = dt1.Rows(0)("contents_metadesc").ToString()
            Header.Controls.Add(pagekeywords)
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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Button1.Click
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
End Class
