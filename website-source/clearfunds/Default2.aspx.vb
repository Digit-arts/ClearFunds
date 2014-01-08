
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CommitTransaction
        Response.Redirect("Account.aspx")

    End Sub

  
End Class
