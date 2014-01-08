Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Partial Class Admin_AdminUsers
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindgrid()
        End If
    End Sub
    Protected Sub Edit_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim con As SqlConnection = New SqlConnection(obj.ConnectionString())
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)


        Dim lbldeleteID As Label = CType(gvrow.FindControl("lblid"), Label)
        Response.Redirect("AddAdminUser.aspx?id=" + lbldeleteID.Text)
    End Sub

    Protected Sub Delete_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim con As SqlConnection = New SqlConnection(obj.ConnectionString())
        Dim cmd As New SqlCommand()
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)


        Dim lbldeleteID As Label = CType(gvrow.FindControl("lblid"), Label)

        con = New SqlConnection(obj.ConnectionString)
        con.Open()
        cmd = New SqlCommand("Delete from CF_Admin where Admin_Id='" + lbldeleteID.Text + "'", con)
        cmd.ExecuteNonQuery()
        cmd.ExecuteNonQuery()
        con.Close()
        bindgrid()
    End Sub
    Private Sub bindgrid()
        obj.returndatatable("select * from CF_Admin", dt)
        If (dt.Rows.Count > 0) Then
            gvmanageuser.DataSource = dt
            gvmanageuser.DataBind()
        End If
    End Sub
End Class
