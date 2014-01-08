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
Partial Class Account_CurrentPlan
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Not Me.IsPostBack Then
        If Session("User_Id") = Nothing Then
            '   Response.Redirect("~/default.aspx")
        End If
        'End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            Dim userid As String = Session("User_Id").ToString()

            Dim str As String = obj.Returnsinglevalue("select user_Phone from cf_user where [User_Id]='" + userid + "'")
            If str = "0" Then
                Response.Redirect("~/account/editprofile.aspx", True)
            End If

        End If
        If Not Session("User_Id") = Nothing Then
            SelectedIndexId = Session("User_Id")

            Dim dt As New DataTable()
            Dim ds As New DataTable
            Dim str As String = ""
            Dim Amt As Double
            Amt = obj.Returnsinglevalue("select sum(Deposit_Amount) from CF_Deposit a inner join CF_User b on b.User_UserId=a.Deposit_UserId where b.User_Id='" + SelectedIndexId + "' and Deposit_Status='true' ")
            lblAmt.Text = Val(Amt)
            str = "select Package_name as name, Package_duration as type, convert(varchar,Deposit_ModifyDate,103) as StartDate , Deposit_Amount  as Amount,Package_Status as PackStatus from CF_Package a inner join CF_Deposit b on b.Deposit_PackageId=a.Package_Id left join CF_user c on c.User_UserId=b.Deposit_UserId  where c.User_Id='" + SelectedIndexId + "' and Deposit_Status='true' "
            ds = obj.returndatatable(str, ds)
            ds.Columns.Add("EndDate")
            If ds.Rows.Count > 0 Then
                For i As Integer = 0 To ds.Rows.Count - 1
                    Dim originDate As Date = Date.Parse(ds.Rows(i).Item("StartDate").ToString())
                    Dim daysToAdd As Integer = Integer.Parse(ds.Rows(i).Item("type").ToString)
                    Dim result As Date = originDate.AddDays(daysToAdd)
                    Dim result1 As String = result.ToString("dd/MM/yyyy")

                    ds.Rows(i).Item("EndDate") = result1
                    GVCurrentplan.DataSource = ds
                    GVCurrentplan.DataBind()
                Next
            End If
            GVCurrentplan.DataSource = ds
            GVCurrentplan.DataBind()
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub
End Class
