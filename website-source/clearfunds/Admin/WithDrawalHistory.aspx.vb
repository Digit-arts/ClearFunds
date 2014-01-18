Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_WithDrawalHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim dt As DataTable = New DataTable()
    Dim gridSortExpression As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As String = ""
        Dim Total As Double
        If Page.IsPostBack Then
            dt = ViewState("gridSource")
            gridSortExpression = If(ViewState("gridSortExpression") Is Nothing, "", ViewState("gridSortExpression"))
        Else
            str = ("select distinct( Username), WithDrawl_Id, WithDrawl_Status,WithDrawl_Date,WithDrawl_Amount,WithDrawl_SysIp,WithDrawl_CountryName,WithDrawl_Payname from CF_WithDrawl inner join aspnet_Users on UserId=WithDrawl_UserId inner join  CF_Package on Package_Id=WithDrawl_PackageId where  (CF_WithDrawl.WithDrawl_Status <> 'PENDING')")
            Total = obj.Returnsinglevalue("select sum(WithDrawl_Amount)  from CF_WithDrawl inner join aspnet_Users on UserId=WithDrawl_UserId inner join  CF_Package on Package_Id=WithDrawl_PackageId  where  (CF_WithDrawl.WithDrawl_Status <> 'PENDING')")
            lblAmt.Text = Val(Total)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(str, New SqlConnection(obj.ConnectionString))

            adapter.Fill(dt)
            GVWithdrawDetails.DataSource = dt.DefaultView
            GVWithdrawDetails.DataBind()
            ViewState("gridSource") = dt
        End If

    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        Total = obj.Returnsinglevalue("select sum(WithDrawl_Amount)  from CF_WithDrawl inner join aspnet_Users on UserId=WithDrawl_UserId inner join  CF_Package on Package_Id=WithDrawl_PackageId where (CF_WithDrawl.WithDrawl_Status <> 'PENDING') AND ((WithDrawl_Date BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " '))")
        lblAmt.Text = Val(Total)

        str = ("select distinct(Username),WithDrawl_Id, WithDrawl_Status,WithDrawl_Date,WithDrawl_Amount, CF_WithDrawl.WithDrawl_SysIp, CF_WithDrawl.WithDrawl_CountryName, CF_WithDrawl.WithDrawl_PayName from CF_WithDrawl inner join aspnet_Users on UserId=WithDrawl_UserId inner join  CF_Package on Package_Id=WithDrawl_PackageId where (CF_WithDrawl.WithDrawl_Status <> 'PENDING') AND ((WithDrawl_Date BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ')) ")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(str, New SqlConnection(obj.ConnectionString))
        dt = New DataTable()
        adapter.Fill(dt)
        GVWithdrawDetails.DataSource = dt.DefaultView
        GVWithdrawDetails.DataBind()
        ViewState("gridSource") = dt

    End Sub

    Protected Sub GVWithdrawDetails_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVWithdrawDetails.PageIndexChanging
        dt.DefaultView.Sort = gridSortExpression
        GVWithdrawDetails.DataSource = dt.DefaultView
        GVWithdrawDetails.PageIndex = e.NewPageIndex
        GVWithdrawDetails.DataBind()
    End Sub

    Protected Sub GVWithdrawDetails_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GVWithdrawDetails.Sorting
        If (gridSortExpression.Contains(e.SortExpression.ToString())) Then
            If (gridSortExpression.Contains("DESC")) Then
                dt.DefaultView.Sort = e.SortExpression.ToString() & " ASC"
                ViewState("gridSortExpression") = e.SortExpression.ToString() & " ASC"
            Else
                dt.DefaultView.Sort = e.SortExpression.ToString() & " DESC"
                ViewState("gridSortExpression") = e.SortExpression.ToString() & " DESC"
            End If
        Else
            dt.DefaultView.Sort = e.SortExpression.ToString()
            ViewState("gridSortExpression") = e.SortExpression.ToString()
        End If
        GVWithdrawDetails.DataSource = dt.DefaultView
        GVWithdrawDetails.DataBind()
    End Sub

    Protected Sub btnSearchName_Click(sender As Object, e As EventArgs) Handles btnSearchName.Click
        Dim str As String = ""
        Dim Total As Double
        Total = obj.Returnsinglevalue("select sum(WithDrawl_Amount)  from CF_WithDrawl inner join aspnet_Users on UserId=WithDrawl_UserId inner join  CF_Package on Package_Id=WithDrawl_PackageId where (CF_WithDrawl.WithDrawl_Status <> 'PENDING') AND (aspnet_Users.UserName LIKE '%" + txtSearch.Text + "%')")
        lblAmt.Text = Val(Total)

        str = ("select distinct(Username),WithDrawl_Id, WithDrawl_Status,WithDrawl_Date,WithDrawl_Amount, CF_WithDrawl.WithDrawl_SysIp, CF_WithDrawl.WithDrawl_CountryName, CF_WithDrawl.WithDrawl_PayName from CF_WithDrawl inner join aspnet_Users on UserId=WithDrawl_UserId inner join  CF_Package on Package_Id=WithDrawl_PackageId where (CF_WithDrawl.WithDrawl_Status <> 'PENDING') AND (aspnet_Users.UserName LIKE '%" + txtSearch.Text + "%') ")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(Str, New SqlConnection(obj.ConnectionString))
        dt = New DataTable()
        adapter.Fill(dt)
        GVWithdrawDetails.DataSource = dt.DefaultView
        GVWithdrawDetails.DataBind()
        ViewState("gridSource") = dt
    End Sub

    Protected Sub btnSearchRef_Click(sender As Object, e As EventArgs) Handles btnSearchRef.Click
        Dim str As String = ""
        Dim Total As Double
        Total = obj.Returnsinglevalue("select sum(WithDrawl_Amount)  from CF_WithDrawl inner join aspnet_Users on UserId=WithDrawl_UserId inner join  CF_Package on Package_Id=WithDrawl_PackageId where (CF_WithDrawl.WithDrawl_Status <> 'PENDING') AND (CF_WithDrawl.WithDrawl_Id LIKE '%" + txtSearch.Text + "%')")
        lblAmt.Text = Val(Total)

        str = ("select distinct(Username),WithDrawl_Id, WithDrawl_Status,WithDrawl_Date,WithDrawl_Amount, CF_WithDrawl.WithDrawl_SysIp, CF_WithDrawl.WithDrawl_CountryName, CF_WithDrawl.WithDrawl_PayName from CF_WithDrawl inner join aspnet_Users on UserId=WithDrawl_UserId inner join  CF_Package on Package_Id=WithDrawl_PackageId where (CF_WithDrawl.WithDrawl_Status <> 'PENDING') AND (CF_WithDrawl.WithDrawl_Id LIKE '%" + txtSearch.Text + "%') ")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(str, New SqlConnection(obj.ConnectionString))
        dt = New DataTable()
        adapter.Fill(dt)
        GVWithdrawDetails.DataSource = dt.DefaultView
        GVWithdrawDetails.DataBind()
        ViewState("gridSource") = dt
    End Sub
End Class
