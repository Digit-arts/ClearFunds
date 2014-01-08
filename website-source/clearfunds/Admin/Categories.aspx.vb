Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Partial Class Admin_Groups
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGroup()
          
        End If
    End Sub
   
    Protected Sub BindGroup()
        Dim dt1 As New DataTable()
        dt1 = obj.returndatatable("select Category_Id,Category_Name from Ticket_Category where Category_Isdeleted<>'1'", dt1)
        If dt1.Rows.Count > 0 Then

            gvgroupname.DataSource = dt1
            gvgroupname.DataBind()
        End If
    End Sub
    Protected Sub Delete_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim con As SqlConnection = New SqlConnection(obj.ConnectionString())
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)


        Dim lbldeleteID As Label = CType(gvrow.FindControl("lblid"), Label)
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("update Ticket_Category set  Category_Isdeleted='1'  where Category_Id='" + lbldeleteID.Text + "'", con)
        cmd.ExecuteNonQuery()
        con.Close()
        BindGroup()
    End Sub
    Protected Sub Edit_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim con As SqlConnection = New SqlConnection(obj.ConnectionString())
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)


        Dim lbldeleteID As Label = CType(gvrow.FindControl("lblid"), Label)
        Response.Redirect("AddCategory.aspx?id=" + lbldeleteID.Text)


    End Sub
    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        gvgroupname.PageIndex = e.NewPageIndex
        BindGroup()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)



        Response.Redirect("AddCategory.aspx")
    End Sub
End Class
