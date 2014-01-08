Imports System.Data
Partial Class login
    Inherits System.Web.UI.MasterPage
    Dim obj As New ClassFunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Session("Admin_Id") = Nothing Then
            Dim dt As New DataTable
            obj.returndatatable("select  AdminTickets_UserName  from Admin_Users where AdminTickets_Id='" + Session("Admin_Id") + "' ", dt)
            If (dt.Rows.Count > 0) Then

                Label1.Text = dt.Rows(0)("AdminTickets_UserName").ToString()

            End If
            Label1.Visible = True
            HyperLink6.Visible = True
           
        Else

            Label1.Visible = False
            HyperLink6.Visible = False

        End If

    End Sub

End Class

