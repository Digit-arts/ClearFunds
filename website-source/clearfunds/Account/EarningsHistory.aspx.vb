Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Account_EarningsHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

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
            Dim ds As New DataSet()


            Dim str As String = ""
            Dim Bonus As Double
            Dim Penalty As Double
            Dim TotalAmount As Double
            Dim DepositEarnings As Double
            Dim ReferralBonus As Double
            Dim Profit As Double
            Dim total As Double
            Dim totalpercentage As String = ""
            str = ("select distinct(Package_name + ' - ' + Packagedet_Plan) as type , convert (varchar,Deposit_ModifyDate,103) as Date,  Deposit_Amount as Amount from  CF_Packagedet  a inner Join   CF_Package b on b.Package_Id=a.Packagedet_PackageId inner Join   CF_Deposit c on c.Deposit_PackageId=b.Package_Id inner join CF_User d on d.User_UserId=c.Deposit_UserId  where user_id='" + SelectedIndexId + "' and  Deposit_Status='ACCEPTED'  and Deposit_Amount between Packagedet_MinAmount and Packagedet_MaxAmount")

            dt = obj.returndatatable(str, dt)

            dt.Columns.Add("ProfitAmount")
            total = 0
            For i = 0 To dt.Rows.Count - 1

                Dim percentage As Double

                percentage = obj.Returnsinglevalue("select Packagedet_Percent from CF_Packagedet  where  Packagedet_MinAmount <='" + dt.Rows(i).Item("Amount").ToString + "' and packagedet_maxamount >='" + dt.Rows(i).Item("Amount").ToString + "' and packagedet_plan <>'' ")
                Profit = ((dt.Rows(i).Item("Amount").ToString) * (percentage)) / 100
                dt.Rows(i).Item("ProfitAmount") = Profit
                total = total + Profit
            Next

            GVEarning.DataSource = dt
            GVEarning.DataBind()
            DepositEarnings = total
            ' ReferralBonus=
            Bonus = obj.Returnsinglevalue("select sum(Bonus_Amount) from CF_Bonus a inner join cf_user b on b.user_userid=a.Bonus_Userid where  user_id='" + SelectedIndexId + "'")
            Penalty = obj.Returnsinglevalue("select SUM(Penalty_Amount) from CF_Penalty  a inner join cf_user b on b.user_userid=a.Penalty_Userid where user_id='" + SelectedIndexId + "'")
            TotalAmount = (Bonus + DepositEarnings - (Penalty))
            lblDeposit.Text = DepositEarnings
            lblBonus.Text = Bonus
            lblPenalty.Text = Penalty

            lblTotal.Text = Val(TotalAmount)
            lblEarning.Text = TotalAmount + ReferralBonus
        Else
            Response.Redirect("login.aspx")
        End If

    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        SelectedIndexId = Session("User_Id")
        Dim dt As New DataTable()
        Dim ds As New DataSet()


        Dim str As String = ""
        Dim Profit As Double
        Dim total As Double

        str = ("select distinct(Package_name + ' - ' + Packagedet_Plan) as type , convert (varchar,Deposit_ModifyDate,103) as Date,  Deposit_Amount as Amount from  CF_Packagedet  a inner Join   CF_Package b on b.Package_Id=a.Packagedet_PackageId inner Join   CF_Deposit c on c.Deposit_PackageId=b.Package_Id inner join CF_User d on d.User_UserId=c.Deposit_UserId  where (Deposit_ModifyDate  BETWEEN '" + txtfrom.Text + "' AND '" + txtto.Text + "') and user_id='" + SelectedIndexId + "' and  Deposit_Status='ACCEPTED'  and Deposit_Amount between Packagedet_MinAmount and Packagedet_MaxAmount")

        dt = obj.returndatatable(str, dt)

        dt.Columns.Add("ProfitAmount")
        total = 0
        For i = 0 To dt.Rows.Count - 1

            Dim percentage As Double

            percentage = obj.Returnsinglevalue("select Packagedet_Percent from CF_Packagedet  where  Packagedet_MinAmount <='" + dt.Rows(i).Item("Amount").ToString + "' and packagedet_maxamount >='" + dt.Rows(i).Item("Amount").ToString + "' and packagedet_plan <>'' ")
            Profit = ((dt.Rows(i).Item("Amount").ToString) * (percentage)) / 100
            dt.Rows(i).Item("ProfitAmount") = Profit
            total = total + Profit
        Next

        GVEarning.DataSource = dt
        GVEarning.DataBind()
    End Sub
End Class
