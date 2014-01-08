Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.Sql
Imports System.IO
Partial Class Stats
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
         Dim ds As New DataSet()
        Dim str As String = ""
        str = "select distinct(username),Deposit_Amount as Deposit ,WithDrawl_Amount as Withdraw from aspnet_Users a  inner Join  CF_Deposit b on b.Deposit_UserId=a.UserId inner Join  CF_WithDrawl c on c.WithDrawl_UserId=a.UserId"
        ds = obj.ReturnDataSet(str)
        GVStats.DataSource = ds
        GVStats.DataBind()

    End Sub

    'Protected Sub GVStats_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    '    GVStats.PageIndex = e.NewPageIndex
    '    bindGridView()

    'End Sub
    'Protected Sub bindGridView()
    '    Dim dt As New DataTable()
    '    Dim ds As New DataSet()
    '    Dim str As String = ""
    '    str = "select distinct(username),Deposit_Amount as Deposit ,WithDrawl_Amount as Withdraw from aspnet_Users a  inner Join  CF_Deposit b on b.Deposit_UserId=a.UserId inner Join  CF_WithDrawl c on c.WithDrawl_UserId=a.UserId"
    '    ds = obj.ReturnDataSet(str)
    '    GVStats.DataSource = ds
    '    GVStats.DataBind()
    'End Sub
    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GVStats.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub
    Private Sub bindgrid()

        Dim con As New SqlConnection(obj.ConnectionString())
        Dim da As New SqlDataAdapter("select distinct(username),Deposit_Amount as Deposit ,WithDrawl_Amount as Withdraw from aspnet_Users a  inner Join  CF_Deposit b on b.Deposit_UserId=a.UserId inner Join  CF_WithDrawl c on c.WithDrawl_UserId=a.UserId ", con)
        Dim ds As New DataSet()
        da.Fill(ds)
        GVStats.DataSource = ds
        GVStats.DataBind()



    End Sub
End Class
