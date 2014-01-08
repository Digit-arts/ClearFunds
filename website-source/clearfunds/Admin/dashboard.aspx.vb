Imports System.Data
Partial Class Admin_dashboard
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindgrid()
        End If
    End Sub
    Private Sub bindgrid()
        obj.returndatatable("select top 5 * from CF_messaging where Messaging_From='" & Session("Admin_UserName") & "' order by Messaging_CreatedDate desc", dt)
        If (dt.Rows.Count > 0) Then
            grdMessages.DataSource = dt
            grdMessages.DataBind()
        End If
    End Sub
End Class
