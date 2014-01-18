Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_DepositDetails
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim dt As DataTable = New DataTable()
    Dim dtBonus As DataTable = New DataTable()
    Dim dtPenalty As DataTable = New DataTable()
    Dim gridSortExpression As String = ""
    Dim gridBonusSortExpression As String = ""
    Dim gridPenaltySortExpression As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As String = ""
        Dim Total As Double
        If Page.IsPostBack Then
            dt = ViewState("gridSource")
            dtBonus = ViewState("gridBonusSource")
            dtPenalty = ViewState("gridPenaltySource")
            gridSortExpression = If(ViewState("gridSortExpression") Is Nothing, "", ViewState("gridSortExpression"))
            gridBonusSortExpression = If(ViewState("gridBonusSortExpression") Is Nothing, "", ViewState("gridBonusSortExpression"))
            gridPenaltySortExpression = If(ViewState("gridPenaltySortExpression") Is Nothing, "", ViewState("gridPenaltySortExpression"))
        Else
            str = ("select distinct( Username), Deposit_Id, Deposit_Status,Deposit_ModifyDate as Deposit_ModifyDate,Deposit_Amount,Deposit_SysIp,Deposit_CountryName,Deposit_PayName from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId where  (CF_Deposit.Deposit_Status <> 'PENDING')")
            Total = obj.Returnsinglevalue("select sum(Deposit_Amount)  from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId  where  (CF_Deposit.Deposit_Status <> 'PENDING')")
            lblAmt.Text = Val(Total)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(str, New SqlConnection(obj.ConnectionString))

            adapter.Fill(dt)
            GVDepositDetails.DataSource = dt.DefaultView
            GVDepositDetails.DataBind()
            ViewState("gridSource") = dt

            str = ("select b.UserName , bonus_Amount ,convert(varchar, Bonus_ModifyDate, 106) as Bonus_ModifyDate from CF_Bonus a inner Join  aspnet_users b on b.userid=a.Bonus_Userid")
            Total = obj.Returnsinglevalue("select SUM( bonus_Amount)from CF_Bonus a inner Join  aspnet_users b on b.userid=a.Bonus_Userid")
            lblAmtBonus.Text = Val(Total)
            adapter = New SqlDataAdapter(str, New SqlConnection(obj.ConnectionString))

            adapter.Fill(dtBonus)
            GVPaymentDetails.DataSource = dtBonus.DefaultView
            GVPaymentDetails.DataBind()
            ViewState("gridBonusSource") = dtBonus

            str = ("select b.UserName , Penalty_Amount ,convert(varchar, Penalty_ModifyDate, 106) as  Penalty_ModifyDate from CF_Penalty a inner Join aspnet_users b on b.userid=a.Penalty_Userid")
            Total = obj.Returnsinglevalue("select  sum(Penalty_Amount)from CF_Penalty a inner Join aspnet_users b on b.userid=a.Penalty_Userid")
            lblAmtPenalty.Text = Val(Total)
            adapter = New SqlDataAdapter(str, New SqlConnection(obj.ConnectionString))

            adapter.Fill(dtPenalty)
            GVPenaltyHistory.DataSource = dtPenalty.DefaultView
            GVPenaltyHistory.DataBind()
            ViewState("gridPenaltySource") = dtPenalty
        End If

    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        Total = obj.Returnsinglevalue("select sum(Deposit_Amount)  from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId  where (CF_Deposit.Deposit_Status <> 'PENDING') AND ((Deposit_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " '))")
        lblAmt.Text = Val(Total)

        str = ("select distinct(Username),Deposit_Id, Deposit_Status,Deposit_ModifyDate,Deposit_Amount, CF_Deposit.Deposit_SysIp, CF_Deposit.Deposit_CountryName, CF_Deposit.Deposit_PayName from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId where (CF_Deposit.Deposit_Status <> 'PENDING') AND ((Deposit_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ')) ")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(str, New SqlConnection(obj.ConnectionString))
        dt = New DataTable()
        adapter.Fill(dt)
        GVDepositDetails.DataSource = dt.DefaultView
        GVDepositDetails.DataBind()
        ViewState("gridSource") = dt

    End Sub

    Protected Sub GVDepositDetails_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVDepositDetails.PageIndexChanging
        dt.DefaultView.Sort = gridSortExpression
        GVDepositDetails.DataSource = dt.DefaultView
        GVDepositDetails.PageIndex = e.NewPageIndex
        GVDepositDetails.DataBind()
    End Sub

    Protected Sub GVDepositDetails_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GVDepositDetails.Sorting
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
        GVDepositDetails.DataSource = dt.DefaultView
        GVDepositDetails.DataBind()
    End Sub

    Protected Sub btnSearchName_Click(sender As Object, e As EventArgs) Handles btnSearchName.Click
        Dim str As String = ""
        Dim Total As Double
        Total = obj.Returnsinglevalue("select sum(Deposit_Amount)  from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId  where (CF_Deposit.Deposit_Status <> 'PENDING') AND (aspnet_Users.UserName LIKE '%" + txtSearch.Text + "%')")
        lblAmt.Text = Val(Total)

        str = ("select distinct(Username),Deposit_Id, Deposit_Status,Deposit_ModifyDate,Deposit_Amount, CF_Deposit.Deposit_SysIp, CF_Deposit.Deposit_CountryName, CF_Deposit.Deposit_PayName from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId where (CF_Deposit.Deposit_Status <> 'PENDING') AND (aspnet_Users.UserName LIKE '%" + txtSearch.Text + "%') ")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(Str, New SqlConnection(obj.ConnectionString))
        dt = New DataTable()
        adapter.Fill(dt)
        GVDepositDetails.DataSource = dt.DefaultView
        GVDepositDetails.DataBind()
        ViewState("gridSource") = dt
    End Sub

    Protected Sub btnSearchRef_Click(sender As Object, e As EventArgs) Handles btnSearchRef.Click
        Dim str As String = ""
        Dim Total As Double
        Total = obj.Returnsinglevalue("select sum(Deposit_Amount)  from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId  where (CF_Deposit.Deposit_Status <> 'PENDING') AND (CF_Deposit.Deposit_Id LIKE '%" + txtSearch.Text + "%')")
        lblAmt.Text = Val(Total)

        str = ("select distinct(Username),Deposit_Id, Deposit_Status,Deposit_ModifyDate,Deposit_Amount, CF_Deposit.Deposit_SysIp, CF_Deposit.Deposit_CountryName, CF_Deposit.Deposit_PayName from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId where (CF_Deposit.Deposit_Status <> 'PENDING') AND (CF_Deposit.Deposit_Id LIKE '%" + txtSearch.Text + "%') ")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(str, New SqlConnection(obj.ConnectionString))
        dt = New DataTable()
        adapter.Fill(dt)
        GVDepositDetails.DataSource = dt.DefaultView
        GVDepositDetails.DataBind()
        ViewState("gridSource") = dt
    End Sub
End Class
