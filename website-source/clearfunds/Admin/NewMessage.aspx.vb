Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Security

Partial Class Admin_NewMessage
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim cmd As New SqlCommand
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'Session("User_Id") = "1"

        If Not IsPostBack = True Then
            Dim con1 As New SqlConnection(obj.ConnectionString())
            Dim cmd1 As New SqlCommand("select Admin_MailId,Admin_UserName from CF_Admin", con1)
            cmd1.Connection.Open()
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            chkUsers.DataSource = dr1
            chkUsers.DataValueField = "Admin_MailId"
            chkUsers.DataTextField = "Admin_UserName"
            chkUsers.DataBind()
            cmd1.Connection.Close()
            cmd1.Connection.Dispose()
            'If Not Request.QueryString("id") = Nothing Then
            '    Dim Header As New HtmlGenericControl("h2")
            '    Header.ID = "NewControl"
            '    Header.InnerText = "Edit Message"
            '    Header.Attributes.Add("class", "head_top")
            '    Label5.Controls.Add(Header)
            '    'string userid = Session["User_Id"].ToString();

            '    Dim selectedIndexId As String = Request.QueryString("id").ToString()
            '    obj.returndatatable("select * from CF_Message where [Message_id]='" & selectedIndexId & "' ", dt)

            '    If dt.Rows.Count > 0 Then
            '        For i As Integer = 0 To dt.Rows.Count
            '            lblid.Text = dt.Rows(0)("Message_id").ToString()
            '            txtsub.Text = dt.Rows(0)("Message_Subject").ToString()
            '            mce_editor_0.Text = dt.Rows(0)("Message_SummaryDescription").ToString()

            '            RadioButtonList1.SelectedValue = dt.Rows(0)("Message_ChkActive").ToString()

            '            Button1.Text = "update"

            '            Session("id") = dt.Rows(0)("Message_id").ToString()
            '        Next

            '    End If

            'End If

        End If

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)


        If Request.QueryString("id") = Nothing Then


            If (txtsub.Text.Trim() <> "") Then
                Dim con As New SqlConnection
                con = New SqlConnection(obj.ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_Messaging"
                cmd.Connection = con
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "ADD"
                cmd.Parameters.Add("@Messaging_id", SqlDbType.VarChar).Value = obj.getIndexKey()
                cmd.Parameters.Add("@Messaging_Subject", SqlDbType.VarChar).Value = txtsub.Text
                cmd.Parameters.Add("@Messaging_Description", SqlDbType.NVarChar).Value = mce_editor_0.Text
                cmd.Parameters.Add("@Messaging_From", SqlDbType.VarChar).Value = Session("Admin_UserName")
                Dim j As Integer = 0
                Dim recipients As String = ""
                Dim recipients_email As String = ""
                For j = 0 To chkUsers.Items.Count - 1
                    If chkUsers.Items(j).Selected Then
                        recipients &= chkUsers.Items(j).Text & ";"
                        recipients_email &= chkUsers.Items(j).Value & ";"
                    End If
                Next
                cmd.Parameters.Add("@Messaging_To", SqlDbType.VarChar).Value = recipients
                cmd.Parameters.Add("@Messaging_CreatedDate", SqlDbType.DateTime).Value = DateTime.Now.ToString()
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                con.Close()

                Dim body As String = mce_editor_0.Text
                Dim recemail As String = recipients_email
                SendEmail(recemail, txtsub.Text, body)


                Dim message As String = "Message sent succssfully"
                Dim url As String = "MessagingList.aspx"
                Dim script As String = "window.onload = function(){ alert('"
                script += message
                script += "');"
                script += "window.location = '"
                script += url
                script += "'; }"
                ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)

            Else
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Message Title Required');", True)
            End If
        End If


    End Sub

    Private Sub SendEmail(ByVal recepientEmail As String, ByVal subject As String, ByVal body As String)
        Using mailMessage As New MailMessage()
            'mailMessage.From = New MailAddress(ConfigurationManager.AppSettings("UserName"))
            mailMessage.From = New MailAddress(Session("Admin_MailId"))
            mailMessage.Subject = subject
            mailMessage.Body = body
            mailMessage.IsBodyHtml = True
            Dim addArgs() As String = recepientEmail.Split(";"c)
            Dim k As Integer = addArgs.Length - 1
            While k > 0
                k = k - 1
                mailMessage.[To].Add(New MailAddress(addArgs(k)))

            End While

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
