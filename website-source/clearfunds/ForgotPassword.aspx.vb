Imports System.Data.SqlClient

Partial Class Account_PasswordRecovery
    Inherits System.Web.UI.Page

    Protected Sub RBEmail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RBEmail As RadioButton = PasswordRecovery1.Controls(0).FindControl("RBEmail")
        Dim RBUserName As RadioButton = PasswordRecovery1.Controls(0).FindControl("RBUsername")
        Dim lblemail As Label = PasswordRecovery1.Controls(0).FindControl("lblEmail")
        Dim email As TextBox = PasswordRecovery1.Controls(0).FindControl("Email")
        Dim lblUsername As Label = PasswordRecovery1.Controls(0).FindControl("lblUsername")
        Dim Username As TextBox = PasswordRecovery1.Controls(0).FindControl("username")
        Dim Submit As Button = PasswordRecovery1.Controls(0).FindControl("Submit")
        Dim Submit1 As Button = PasswordRecovery1.Controls(0).FindControl("Submit1")
        Dim failtext As Label = PasswordRecovery1.Controls(0).FindControl("failtext")
        Dim lblumsg As Literal = PasswordRecovery1.QuestionTemplateContainer.FindControl("FailureText")
        If RBEmail.Checked = True Then
            lblemail.Visible = True
            email.Visible = True
            Submit1.Visible = True
            lblUsername.Visible = False
            Username.Visible = False
            Submit.Visible = False
            Submit1.Visible = True
            failtext.Visible = False

            lblumsg.Visible = False
        End If
    End Sub

    Protected Sub RBUsename_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim lblmsg As Label = PasswordRecovery1.Controls(0).FindControl("lblmsg")
        Dim RBEmail As RadioButton = PasswordRecovery1.Controls(0).FindControl("RBEmail")
        Dim RBUserName As RadioButton = PasswordRecovery1.Controls(0).FindControl("RBUsername")
        Dim lblemail As Label = PasswordRecovery1.Controls(0).FindControl("lblEmail")
        Dim email As TextBox = PasswordRecovery1.Controls(0).FindControl("Email")
        Dim lblUsername As Label = PasswordRecovery1.Controls(0).FindControl("lblUsername")
        Dim Username As TextBox = PasswordRecovery1.Controls(0).FindControl("username")
        Dim Submit As Button = PasswordRecovery1.Controls(0).FindControl("Submit")
        Dim Submit1 As Button = PasswordRecovery1.Controls(0).FindControl("Submit1")
        If RBUserName.Checked = True Then
            lblemail.Visible = False
            email.Visible = False
            Submit1.Visible = False
            lblUsername.Visible = True
            Username.Visible = True
            Submit.Visible = True
            Submit1.Visible = False
            lblmsg.Visible = False

        End If
    End Sub

    Public Class NetFourMembershipProvider
        Inherits SqlMembershipProvider
        Public Function GetClearTextPassword(ByVal encryptedPwd As String) As String
            Dim encodedPassword As Byte() = Convert.FromBase64String(encryptedPwd)
            Dim bytes As Byte() = Me.DecryptPassword(encodedPassword)
            If bytes Is Nothing Then
                Return Nothing
            End If
            'Return Encoding.Unicode.GetString(bytes, &H10, bytes.Length - &H20)
            Return Encoding.Unicode.GetString(bytes, &H10, bytes.Length - &H10)
        End Function
    End Class
    Protected Sub Submit1_Click(ByVal sender As Object, ByVal e As System.EventArgs)


        Dim lblmsg As Label = PasswordRecovery1.Controls(0).FindControl("lblmsg")
        Dim cemail As New CEmail1
        Dim constr As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString.ToString()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim ad As New SqlDataAdapter
        con = New SqlConnection(constr)
        con.Open()
        cmd.Connection = con
        Dim email As TextBox = PasswordRecovery1.Controls(0).FindControl("Email")
        Dim strselect As String = "select password from aspnet_Membership where email='" + email.Text + "'"
        cmd = New SqlCommand(strselect, con)
        Dim ans As String = cmd.ExecuteScalar()
        Dim passwordManager = New NetFourMembershipProvider()
        If Not ans Is Nothing Then
            Dim clearPwd = "USER=" & passwordManager.GetClearTextPassword(ans)

            Dim cmail As CEmail1
            cmail = New CEmail1

            Dim email1 As TextBox = PasswordRecovery1.Controls(0).FindControl("Email")
            cemail.EmailPasswForgot(email1.Text, clearPwd)
            lblmsg.ForeColor = Drawing.Color.Green
            lblmsg.Visible = True
            lblmsg.Text = "password has been sent to ur email"
        Else
            lblmsg.Visible = True
            lblmsg.Text = "Email is invalid"

        End If

    End Sub
    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim obj As New ClassFunctions

        Dim lblmsg As Label = PasswordRecovery1.Controls(0).FindControl("lblmsg")
        Dim lblumsg As Literal = PasswordRecovery1.QuestionTemplateContainer.FindControl("FailureText")
        Dim cemail As New CEmail1
        Dim constr As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString.ToString()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim ad As New SqlDataAdapter
        con = New SqlConnection(constr)
        con.Open()
        cmd.Connection = con

        Dim email As TextBox = PasswordRecovery1.Controls(0).FindControl("Email")
        Dim username As TextBox = PasswordRecovery1.Controls(0).FindControl("UserName")
        Dim ansertext As TextBox = PasswordRecovery1.QuestionTemplateContainer.FindControl("Answer")
        Dim ans2 As String = ansertext.Text
        Dim answer As Guid = obj.ReturnsingleGuid("select [userId] from aspnet_users where username='" + username.Text + "'")
        Dim answer1 As String = Convert.ToString(answer)
        'cmd = New SqlCommand(answer, con)
        Dim ans1 As String = obj.Returnsinglevalue("select [PasswordAnswer] from aspnet_membership where userId='" + answer1 + "'")
        Dim passwordManager1 = New NetFourMembershipProvider()

        Dim clearPwd1 = passwordManager1.GetClearTextPassword(ans1)

        If ans2 = clearPwd1 Then

            Dim strselect As String = "select password from aspnet_Membership where userId='" + answer1 + "'"
            cmd = New SqlCommand(strselect, con)
            Dim ans As String = cmd.ExecuteScalar()
            Dim passwordManager = New NetFourMembershipProvider()

            Dim clearPwd = "USER=" & passwordManager.GetClearTextPassword(ans)

            Dim cmail As CEmail1
            cmail = New CEmail1
            Dim stremail As String = obj.Returnsinglevalue("select Email from aspnet_Membership where  userId='" + answer1 + "'")
            'Dim email1 As TextBox = PasswordRecovery1.Controls(0).FindControl("Email")
            cemail.EmailPasswForgot(stremail, clearPwd)
            lblumsg.Visible = True
            lblumsg.Text = "password has been sent to ur email"
            'Response.Redirect("~/account/forgotpasssuccess.aspx")
        Else
            lblumsg.Visible = True
            lblumsg.Text = "Invalid Answer"

        End If
    End Sub
End Class
