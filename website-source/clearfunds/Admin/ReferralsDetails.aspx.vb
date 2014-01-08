Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class ReferralsHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim dt1 As String = ""
        '  dt1 = obj.Returnsinglevalue(" select User_FirstName,convert(varchar,a.EntryDate,103) as Date from CF_Referral a inner join CF_User b on b.User_Id=a.referenceUser_id")
        '  str = ("select (User_FirstName + ' ' + User_LastName) as Name,Deposit_ModifyDate,Packagedet_Plan,Package_duration,Packagedet_Percent,Deposit_Amount from CF_Deposit inner join CF_User on User_UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId inner join CF_Packagedet on Package_Id=Packagedet_PackageId ")
        str = (" select User_FirstName,convert(varchar,a.EntryDate,106) as Date from CF_Referral a inner join CF_User b on b.User_Id=a.User_Id ")
        ds = obj.ReturnDataSet(str)
        GVreferralHistory.DataSource = ds
        GVreferralHistory.DataBind()

    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        str = ("")
        ds = obj.ReturnDataSet(str)
        GVreferralHistory.DataSource = ds
        GVreferralHistory.DataBind()
    End Sub

End Class
