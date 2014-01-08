Imports System.Data

Partial Class Account_IpDetails
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim obj As New ClassFunctions()
        dt.Columns.Add("Ipname")
        dt.Columns.Add("serverName")
        dt.Columns.Add("Loginname")
        dt.Columns.Add("loginpw")

        Dim strHostName As String = ""
        Dim strIPAddress As String = ""
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

        Dim uid As Guid = Membership.GetUser.ProviderUserKey()
        Dim uid1 As String = Convert.ToString(uid)
        Dim uname As String = obj.Returnsinglevalue("select UserName from aspnet_Users where userId='" + uid1 + "'")
        Dim pw As String = obj.Returnsinglevalue("select password from aspnet_Membership where userId='" + uid1 + "'")

        Dim passwordManager = New NetFourMembershipProvider()

        Dim clearPwd As String = passwordManager.GetClearTextPassword(pw)
        dt.Rows.Add()
        dt.Rows(0).Item("Ipname") = strIPAddress
        dt.Rows(0).Item("serverName") = strHostName
        dt.Rows(0).Item("Loginname") = uname
        dt.Rows(0).Item("loginpw") = clearPwd
        GVDepositHistory.DataSource = dt
        GVDepositHistory.DataBind()

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

End Class
