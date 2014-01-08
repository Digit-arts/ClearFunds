
Partial Class Logout1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub logout(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Session("User_Id") = Nothing Then
            Session.Abandon()
        End If
        Session("User_Id") = Nothing

    End Sub

End Class
