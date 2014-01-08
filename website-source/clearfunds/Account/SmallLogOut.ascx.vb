
Partial Class Account_SmallLogOut
    Inherits System.Web.UI.UserControl
    Dim obj As New ClassFunctions()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub
    Protected Sub logout(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Session("User_Id") = Nothing Then
            obj.ExecuteQuery("Update CF_logdet set logouttime = '" & Format(System.DateTime.Now, "yyyy/MM/dd hh:mm:ss") & "' where logid = '" & Session("Log_Id") & "'  ")


            Session.Abandon()

        End If
        Session("User_Id") = Nothing
    End Sub

End Class
