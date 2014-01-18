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
Partial Class Account
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Not Me.IsPostBack Then
        If Session("User_Id") = Nothing Then
            Response.Redirect("~/default.aspx")
        End If


        'End If
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not Session("User_Id") = Nothing Then
    '        SelectedIndexId = Session("User_Id")
    '        Dim dt As New DataTable()
    '        Dim dt1 As New DataTable()


    '        '  dt = obj.returndatatable("select (User_FirstName+ '- ' + User_LastName) as username,convert (varchar, User_RegDate,103) as RegistrationDate, user_modifydate as LastAccessDate ,(Deposit_Amount + Bonus_Amount - WithDrawl_Amount - Penalty_Amount - WithDrawl_Amount) as TotalAmount,WithDrawl_Amount as WithdrewTotal  from CF_User a Left Join CF_WithDrawl b on b.WithDrawl_UserId=a.User_UserId Left Join CF_Deposit c on c.Deposit_UserId=a.User_UserId Left Join CF_Penalty d on d.Penalty_Userid=a.User_UserId Left Join CF_Bonus e on e.Bonus_Userid=a.User_UserId", dt)
    '        dt = obj.returndatatable("select distinct(username) as username,convert (varchar, User_RegDate,103) as RegistrationDate, user_modifydate as LastAccessDate ,(Deposit_Amount + Bonus_Amount - WithDrawl_Amount - Penalty_Amount - WithDrawl_Amount) as TotalAmount,WithDrawl_Amount as WithdrewTotal from aspnet_Users a Left Join CF_WithDrawl b on b.WithDrawl_UserId=a.UserId Left Join CF_Deposit c on c.Deposit_UserId=a.UserId   Left Join CF_Penalty d on d.Penalty_Userid=a.UserId Left Join CF_Bonus e on e.Bonus_Userid=a.UserId   left join CF_User f on f.User_UserId=a.UserId where f.User_Id='" + SelectedIndexId + "'", dt)
    '        If dt.Rows.Count > 0 Then
    '            lblusername.Text = dt.Rows(0).Item("username").ToString()
    '            lblRegDate.Text = dt.Rows(0).Item("RegistrationDate").ToString()
    '            lblLastAccess.Text = dt.Rows(0).Item("LastAccessDate").ToString()
    '            lblAccountBalance.Text = dt.Rows(0).Item("TotalAmount").ToString()
    '            ' lblEarnedTotal.Text = dt.Rows(0).Item("").ToString()
    '            ' lblPendingWithdrawal.Text = dt.Rows(0).Item("").ToString()
    '            lblWithdrewTotal.Text = dt.Rows(0).Item("WithdrewTotal").ToString()
    '            'lblActiveDeposit.Text = dt.Rows(0).Item("").ToString()

    '        End If
    '    End If
    'End Sub



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
            Dim dt1 As New DataTable()

            dt = obj.returndatatable("select username,convert (varchar, User_RegDate,103) as RegistrationDate,user_modifydate as LastAccessDate from aspnet_Users a inner Join cf_user b on b.user_userid=a.UserId where b.User_Id='" + SelectedIndexId + "' ", dt)
            'dt = obj.returndatatable("select distinct(username) as username,convert (varchar, User_RegDate,103) as RegistrationDate, user_modifydate as LastAccessDate ,(Deposit_Amount + Bonus_Amount - WithDrawl_Amount - Penalty_Amount - WithDrawl_Amount) as TotalAmount,WithDrawl_Amount as WithdrewTotal from aspnet_Users a Left Join CF_WithDrawl b on b.WithDrawl_UserId=a.UserId Left Join CF_Deposit c on c.Deposit_UserId=a.UserId   Left Join CF_Penalty d on d.Penalty_Userid=a.UserId Left Join CF_Bonus e on e.Bonus_Userid=a.UserId   left join CF_User f on f.User_UserId=a.UserId where f.User_Id='" + SelectedIndexId + "'", dt)
            If dt.Rows.Count > 0 Then
                lblusername.Text = dt.Rows(0).Item("username").ToString()
                lblRegDate.Text = dt.Rows(0).Item("RegistrationDate").ToString()
                lblLastAccess.Text = dt.Rows(0).Item("LastAccessDate").ToString()

                For i = 0 To dt.Rows.Count - 1
                    Dim Deposit As Double
                    Dim Bonus As Double
                    Dim WithDrawal As Double
                    Dim Penalty As Double
                    Dim Balance As Double
                    Dim BendingWithdrawal As Double
                    Dim EarnedTotal As Double
                    Deposit = obj.Returnsinglevalue("select sum(Deposit_Amount) from CF_Deposit a inner join cf_user b on b.user_userid=a.Deposit_UserId where  user_id='" + SelectedIndexId + "' and Deposit_Status='ACCEPTED' ")
                    Bonus = obj.Returnsinglevalue("select sum(Bonus_Amount) from CF_Bonus a inner join cf_user b on b.user_userid=a.Bonus_Userid where  user_id='" + SelectedIndexId + "' ")
                    WithDrawal = obj.Returnsinglevalue("select sum(WithDrawl_Amount) from CF_WithDrawl a inner join cf_user b on b.user_userid=a.WithDrawl_UserId where user_id='" + SelectedIndexId + "' and WithDrawl_Status='ACCEPTED'")
                    BendingWithdrawal = obj.Returnsinglevalue("select sum(WithDrawl_Amount) from CF_WithDrawl a inner join cf_user b on b.user_userid=a.WithDrawl_UserId where user_id='" + SelectedIndexId + "' and WithDrawl_Status='PENDING' ")
                    Penalty = obj.Returnsinglevalue("select SUM(Penalty_Amount) from CF_Penalty  a inner join cf_user b on b.user_userid=a.Penalty_Userid where user_id='" + SelectedIndexId + "' ")
                    Balance = Val((Deposit + Bonus) - (WithDrawal + Penalty))
                    EarnedTotal = Val(Bonus)
                    lblEarnedTotal.Text = Val(EarnedTotal)
                    lblAccountBalance.Text = Val(Balance)
                    lblPendingWithdrawal.Text = Val(BendingWithdrawal)
                    lblWithdrewTotal.Text = Val(WithDrawal)
                Next
            End If
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

End Class
