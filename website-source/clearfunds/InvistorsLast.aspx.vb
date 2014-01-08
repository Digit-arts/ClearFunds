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
Partial Class InvistorsLast
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select top 10  username,CONVERT (varchar, WithDrawl_Date,103) as Date,WithDrawl_Amount as amount from CF_WithDrawl a inner Join   aspnet_Users b on b.UserId=a.WithDrawl_UserId order by WithDrawl_Amount asc"
        ds = obj.ReturnDataSet(str)
        GVLastten.DataSource = ds
        GVLastten.DataBind()

    End Sub
    Protected Sub bindGridView()
        Dim dt As New DataTable()
        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select top 10  username,CONVERT (varchar, WithDrawl_Date,103) as Date,WithDrawl_Amount as amount from CF_WithDrawl a inner Join   aspnet_Users b on b.UserId=a.WithDrawl_UserId order by WithDrawl_Amount asc"
        ds = obj.ReturnDataSet(str)
        GVLastten.DataSource = ds
        GVLastten.DataBind()

    End Sub
    Protected Sub GVLastten_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GVLastten.PageIndex = e.NewPageIndex
        bindGridView()
    End Sub
End Class
