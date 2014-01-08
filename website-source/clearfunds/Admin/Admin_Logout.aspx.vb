
Partial Class Admin_Admin_Logout
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.g_username = ""
    End Sub
End Class
