Imports System.Data
Imports System.Data.SqlClient

Partial Class Admin_NewsList
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack = True Then



            bindgrid()
        End If


    End Sub

    Public Sub bindgrid()

        Dim dt As New DataTable()
        dt = obj.returndatatable("select * from CF_CompanyNews  where   Company_Isdeleted<>'1'", dt)
        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub


    Protected Sub Delete_Click(sender As Object, e As ImageClickEventArgs)
        Dim con As New SqlConnection(obj.ConnectionString())
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)





        Dim lbldeleteID As Label = DirectCast(gvrow.FindControl("lblid"), Label)
        con.Open()
        Dim cmd As New SqlCommand("update [CF_CompanyNews] set [Company_Isdeleted]='1' where [Company_id]='" + lbldeleteID.Text + "'", con)
        cmd.ExecuteNonQuery()
        con.Close()
        bindgrid()


    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub
End Class
