
Imports System.Data
Imports System.Net.Mail
Imports System.Data.SqlClient
Partial Class Account_ChangePassword
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()



    Protected Sub ChangePasswordPushButton_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ans As String
        Dim struserid As String
        struserid = Membership.GetUser.ProviderUserKey.ToString()
        ans = obj.Returnsinglevalue("select email from aspnet_membership where userid='" + struserid + "'")

        Dim cmail As CEmail1
        cmail = New CEmail1
        cmail.EmailToUser(ans)
    End Sub
End Class
