Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Member
    Inherits System.Web.UI.MasterPage
    Dim obj As New ClassFunctions


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblstarted.Text = obj.Returnsinglevalue("select CONVERT (varchar,Settings_StartDate, 103) as Settings_StartDate  from CF_Settings")
        lblRunningDays.Text = obj.Returnsinglevalue("SELECT DATEDIFF(DAY, '02/03/2013', GETDATE())")
        lblTotalAccounts.Text = obj.Returnsinglevalue("select COUNT (USER_ID) from CF_User")
        lblActiveAccounts.Text = obj.Returnsinglevalue("select COUNT (USER_ID) from CF_User a inner join CF_Deposit b on b.Deposit_UserId=a.User_UserId where Deposit_Status ='ACCEPTED'")
        lblTotalDeposited.Text = obj.Returnsinglevalue("select SUM (Deposit_Amount) from CF_Deposit where Deposit_Status ='ACCEPTED'")
        lblTotalWithdraw.Text = obj.Returnsinglevalue("select SUM(WithDrawl_Amount) from CF_WithDrawl where WithDrawl_Status='ACCEPTED'")
        lblLastUpdate.Text = obj.Returnsinglevalue("select CONVERT (varchar,Settings_ModifyDate, 103) as Settings_ModifyDate  from CF_Settings")
        If Not Session("User_Id") = Nothing Then
            pnllogin.Visible = False
            SmallLogout1.Visible = True
            Panel1.Visible = True
            HyperLink22.Visible = False
            HyperLink30.Visible = True
          
        Else
            pnllogin.Visible = True
            SmallLogout1.Visible = False

        End If
      
    End Sub


End Class

