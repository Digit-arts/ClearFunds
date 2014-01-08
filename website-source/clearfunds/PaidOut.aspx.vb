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
Partial Class PaidOut
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        Dim ds As New DataSet()
        Dim str As String = ""
        str = " select username,CONVERT (varchar, WithDrawl_Date,103) as Date,WithDrawl_Amount as Amount from aspnet_Users a inner join CF_WithDrawl b on b.WithDrawl_UserId=a.userid"
        ds = obj.ReturnDataSet(str)
        GVpaidout.DataSource = ds
        GVpaidout.DataBind()
    End Sub
    
End Class
