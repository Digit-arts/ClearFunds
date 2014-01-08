Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Partial Class Admin_ContentManage
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim con As New SqlConnection(obj.ConnectionString())
            Dim cmd As New SqlCommand("select * from CF_contents where contents_status<>2 ", con)
            cmd.Connection.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            DropDownList1.DataSource = dr
            DropDownList1.DataTextField = "contents_title"
            DropDownList1.DataValueField = "contents_id"
            DropDownList1.DataBind()
            cmd.Connection.Close()

            Dim con1 As New SqlConnection(obj.ConnectionString())
            Dim cmd1 As New SqlCommand("select * from CF_contents where contents_status<>2 ", con1)
            con1.Open()
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()

            DropDownList2.DataSource = dr1
            DropDownList2.DataValueField = "contents_id"
            DropDownList2.DataTextField = "contents_title"
            DropDownList2.DataBind()
            bindgrid()
            Dim dt1 As New DataTable()

            dt1 = obj.returndatatable("select contents_id,contents_title from CF_contents where [contents_header_title]='" + DropDownList1.SelectedItem.Text + "' and contents_status<> 2  order by contents_Orderno", dt1)
            GridView1.DataSource = dt1
            GridView1.DataBind()
        End If
    End Sub
    Private Sub bindgrid()

        Dim con As New SqlConnection(obj.ConnectionString())
        Dim da As New SqlDataAdapter("select contents_id,contents_title  from CF_contents where [contents_header_title]='" + DropDownList1.SelectedItem.Text + "' and contents_status<> 2  order by contents_Orderno ", con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()



    End Sub


    Protected Sub Delete_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim con As SqlConnection = New SqlConnection(obj.ConnectionString())
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)


        Dim lbldeleteID As Label = CType(gvrow.FindControl("lblid"), Label)
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("update CF_Contents set contents_status='2' where contents_id=" + lbldeleteID.Text + "", con)
        cmd.ExecuteNonQuery()
        con.Close()
        bindgrid()

    End Sub

    Protected Sub Edit_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim con As SqlConnection = New SqlConnection(obj.ConnectionString())
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)


        Dim lbldeleteID As Label = CType(gvrow.FindControl("lblid"), Label)
        Response.Redirect("editcontent.aspx?id=" + lbldeleteID.Text)
      

    End Sub

    Protected Sub dropdownview(ByVal sender As Object, ByVal e As EventArgs)

        Dim dt As DataTable = New DataTable()
        dt = obj.returndatatable("select * from CF_contents where [contents_header_title]='" + DropDownList1.SelectedItem.Text + "' and contents_status<> 2  order by contents_Orderno", dt)
        GridView1.DataSource = dt
        GridView1.DataBind()



    End Sub
    Protected Sub Imageup_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim con As SqlConnection = New SqlConnection(obj.ConnectionString())
        Dim cmd As SqlCommand = New SqlCommand()
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)



        Dim lbldeleteID As Label = CType(gvrow.FindControl("lblid"), Label)


        Dim lblid1 As Integer = Convert.ToInt32(lbldeleteID.Text)
        Dim currow As String = obj.Returnsinglevalue("select contents_Orderno from CF_contents where contents_id='" + lbldeleteID.Text + "'")
        Dim s As Integer = GridView1.Rows.Count - 1
        Dim s1 As String = Convert.ToString(s)
        Dim s2 As String = gvrow.RowIndex.ToString()
        If Not (s2 = "0") Then

            Dim cur As Integer = Convert.ToInt32(currow)
            Dim currow1 As String = (cur - 1)
            Dim prevrow As String = currow1 + 1

            Dim previd As String = obj.Returnsinglevalue("select contents_id from CF_contents where contents_Orderno='" + currow1 + "'")

            con = New SqlConnection(obj.ConnectionString())
            con.Open()


            Dim Query As String = "Update CF_contents set contents_Orderno='" + currow1 + "' where contents_id='" + lbldeleteID.Text + "'"
            cmd = New SqlCommand(Query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            cmd.Parameters.Clear()
            con.Open()
            Dim Query1 As String = "Update CF_contents set contents_Orderno='" + prevrow + "' where contents_id='" + previd + "'"
            cmd = New SqlCommand(Query1, con)
            cmd.ExecuteNonQuery()
            con.Close()


            Dim dt1 As DataTable = New DataTable()
            dt1 = obj.returndatatable("select * from CF_contents where [contents_header_title]='" + DropDownList1.SelectedItem.Text + "' and  contents_status<> 2   order by contents_Orderno", dt1)
            GridView1.DataSource = dt1
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub Imagedown_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim con As SqlConnection = New SqlConnection(obj.ConnectionString())
        Dim cmd As SqlCommand = New SqlCommand()
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)


        Dim lbldeleteID As Label = CType(gvrow.FindControl("lblid"), Label)

        Dim lblid1 As Integer = Convert.ToInt32(lbldeleteID.Text)
        Dim currow As String = obj.Returnsinglevalue("select contents_Orderno from CF_contents where contents_id='" + lbldeleteID.Text + "' and [contents_header_title]='" + DropDownList1.SelectedItem.Text + "' ")
        Dim s As Integer = GridView1.Rows.Count - 1
        Dim s1 As String = Convert.ToString(s)
        Dim s2 As String = gvrow.RowIndex.ToString()
        If Not (s1 = s2) Then
            Dim cur As Integer = Convert.ToInt32(currow)
            Dim currow1 As String = cur + 1
            Dim prevrow As String = currow1 - 1

            Dim previd As String = obj.Returnsinglevalue("select contents_id from CF_contents where contents_orderno='" + currow1 + "'")
            con = New SqlConnection(obj.ConnectionString())
            con.Open()


            Dim Query As String = "Update CF_contents set contents_Orderno='" + currow1 + "' where contents_id='" + lbldeleteID.Text + "'"
            cmd = New SqlCommand(Query, con)
            cmd.ExecuteNonQuery()
            con.Close()
            con.Open()


            Dim Query1 As String = "Update CF_Contents set contents_Orderno='" + prevrow + "' where contents_id='" + previd + "'"
            cmd = New SqlCommand(Query1, con)
            cmd.ExecuteNonQuery()
            con.Close()


            Dim dt1 As DataTable = New DataTable()
            dt1 = obj.returndatatable("select * from CF_Contents where contents_header_title='" + DropDownList1.SelectedItem.Text + "' and contents_status<> 2  order by contents_Orderno", dt1)
            GridView1.DataSource = dt1
            GridView1.DataBind()
        End If


    End Sub
    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim id As String = DropDownList2.SelectedValue


        Response.Redirect("EditContent.aspx?cmbid=" + id)
    End Sub

    '----------------------------------------------------------------
    ' Converted from C# to VB .NET using CSharpToVBConverter(1.2).
    ' Developed by: Kamal Patel (http://www.KamalPatel.net) 
    '----------------------------------------------------------------

End Class
