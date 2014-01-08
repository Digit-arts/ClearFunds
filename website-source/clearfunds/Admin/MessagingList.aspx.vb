Imports System.Data
Imports System.Data.SqlClient

Partial Class Admin_MessagingList
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack = True Then


            If Session("Admin_RoleId") = "Top Administrtor" Then
                drpCat.Visible = True
            End If
            bindgrid()
        End If


    End Sub

    Public Sub bindgrid()

        Dim dt As New DataTable()
        If Session("Admin_RoleId") = "Top Administrtor" Then
            If drpCat.SelectedIndex = 1 Then
                dt = obj.returndatatable("select * from CF_Messaging where Messaging_From='" & Session("Admin_UserName") & "' order by Messaging_CreatedDate desc", dt)
            Else
                dt = obj.returndatatable("select * from CF_Messaging order by Messaging_CreatedDate desc", dt)
            End If
        Else
            dt = obj.returndatatable("select * from CF_Messaging where Messaging_From='" & Session("Admin_UserName") & "' order by Messaging_CreatedDate desc", dt)

        End If


        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub


    Protected Sub Delete_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim con As New SqlConnection(obj.ConnectionString())
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing
        Dim cmd As New SqlCommand()
        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)





        Dim lbldeleteID As Label = DirectCast(gvrow.FindControl("lblid"), Label)
        con.Open()
        cmd = New SqlCommand("Delete from CF_Messaging where Messaging_Id='" + lbldeleteID.Text + "'", con)
        cmd.ExecuteNonQuery()
        cmd.ExecuteNonQuery()
        con.Close()
        bindgrid()

    End Sub

    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub

    Protected Sub drpCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpCat.SelectedIndexChanged
        bindgrid()
    End Sub
End Class
