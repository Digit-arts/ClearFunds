Imports System.Data
Imports System.Web.UI
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI.WebControls


Partial Class AccountMaster
    Inherits System.Web.UI.MasterPage


    Dim obj As New ClassFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim obj As New ClassFunctions()
        Dim dt As New DataTable
        If Not Session("User_Id") = Nothing Then

            LoadPackagePlan()
            LoadSideBarData()

            dt = obj.returndatatable("select * from [CF_contents] where [contents_publish]=1 and [contents_fid]=1 and contents_status=1 order by contents_orderno ", dt)
            If dt.Rows.Count > 0 Then

                Dim div As New HtmlGenericControl("div")
                divmenu.Controls.Add(div)
                Dim ul As New HtmlGenericControl("ul")
                divmenu.Controls.Add(ul)

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim li As New HtmlGenericControl("li")
                    ul.Controls.Add(li)

                    Dim hyp1 As New HyperLink
                    hyp1.ID = dt.Rows(i).Item("contents_id").ToString()
                    hyp1.Text = dt.Rows(i).Item("contents_title").ToString()
                    If hyp1.ID = "6" Then
                        hyp1.NavigateUrl = "~/default.aspx"

                    ElseIf hyp1.ID = "11" Then
                        hyp1.NavigateUrl = "~/News.aspx"

                    ElseIf hyp1.ID = "12" Then
                        hyp1.NavigateUrl = "~/FAQ.aspx"
                    ElseIf hyp1.ID = "9" Then
                        hyp1.NavigateUrl = "~/Voteus.aspx"
                    ElseIf hyp1.ID = "13" Then
                        hyp1.NavigateUrl = "~/Contact.aspx"
                    Else
                        hyp1.NavigateUrl = "~/content.aspx?id=" + dt.Rows(i).Item("contents_id").ToString()
                    End If
                    li.Controls.Add(hyp1)
                Next
            End If

        End If

    End Sub

    Sub LoadPackagePlan()

        Dim userid1 = Membership.GetUser.ProviderUserKey.ToString()
        Dim uid1 As String = Convert.ToString(userid1)
        Dim Str2 As String
        Dim ds As New DataSet()

        Str2 = "SELECT DISTINCT c.PackageDet_Plan AS [Plan], b.Package_name AS Package,Packagedet_Active AS Status , b.Package_PaymentPeriod AS Period, Packagedet_Percent AS Profit  " &
                "FROM CF_Deposit a  " &
                "INNER JOIN CF_Package b ON b.Package_Id =a.Deposit_PackageId   " &
                "INNER JOIN CF_Packagedet c ON c.Packagedet_Id=a.Deposit_PackageDetId  " &
                "WHERE a.Deposit_UserId = '" + userid1 + "' AND Deposit_Status ='True' "

        ds = obj.ReturnDataSet(Str2)
        If ds.Tables(0).Rows.Count > 0 Then

            lbl_package_name.Text = ds.Tables(0).Rows(0)("Package").ToString()
            lbl_plan_name.Text = ds.Tables(0).Rows(0)("Plan").ToString()
            lbl_payment_period.Text = ds.Tables(0).Rows(0)("Period").ToString()
            lbl_profit.Text = ds.Tables(0).Rows(0)("Profit").ToString()
            lbl_plan_status.Text = ds.Tables(0).Rows(0)("Status").ToString()

        End If
    End Sub

    Sub LoadSideBarData()
        Dim selectedIndexDetIdnew = Session("User_Id")
        '  Dim dt As New DataTable()
        Dim Deposit As Double
        Dim Bonus As Double
        Dim WithDrawal As Double
        Dim Penalty As Double
        Dim Balance As Double
        Deposit = obj.Returnsinglevalue("select sum(Deposit_Amount) from CF_Deposit a inner join cf_user b on b.user_userid=a.Deposit_UserId where  user_id='" + selectedIndexDetIdnew + "' and Deposit_Status='True' ")
        Bonus = obj.Returnsinglevalue("select sum(Bonus_Amount) from CF_Bonus a inner join cf_user b on b.user_userid=a.Bonus_Userid where  user_id='" + selectedIndexDetIdnew + "'")
        WithDrawal = obj.Returnsinglevalue("select sum(WithDrawl_Amount) from CF_WithDrawl a inner join cf_user b on b.user_userid=a.WithDrawl_UserId where user_id='" + selectedIndexDetIdnew + "' and  WithDrawl_Status='True'")
        Penalty = obj.Returnsinglevalue("select SUM(Penalty_Amount) from CF_Penalty  a inner join cf_user b on b.user_userid=a.Penalty_Userid where user_id='" + selectedIndexDetIdnew + "'")
        Balance = ((Deposit + Bonus) - (WithDrawal + Penalty))

        lblSideBalance.Text = Val(Balance)
    End Sub


   

End Class

