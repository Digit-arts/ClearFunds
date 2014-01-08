Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_BonusHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        str = ("select b.UserName , bonus_Amount ,convert(varchar, Bonus_ModifyDate, 106) as Bonus_ModifyDate from CF_Bonus a inner Join  aspnet_users b on b.userid=a.Bonus_Userid")
        Total = obj.Returnsinglevalue("select SUM( bonus_Amount)from CF_Bonus a inner Join  aspnet_users b on b.userid=a.Bonus_Userid")
        lblAmt.Text = Val(Total)
        ds = obj.ReturnDataSet(str)
        GVPaymentDetails.DataSource = ds
        GVPaymentDetails.DataBind()

    End Sub
    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        str = ("select b.UserName,bonus_Amount ,convert(varchar, Bonus_ModifyDate, 106) as Bonus_ModifyDate from CF_Bonus a inner Join  aspnet_users b on b.userid=a.Bonus_Userid where Bonus_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ' ")
        Total = obj.Returnsinglevalue("select SUM( bonus_Amount)from CF_Bonus a inner Join  aspnet_users b on b.userid=a.Bonus_Userid  where Bonus_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ' ")
        lblAmt.Text = Val(Total)
        ds = obj.ReturnDataSet(str)
        GVPaymentDetails.DataSource = ds
        GVPaymentDetails.DataBind()

    End Sub


End Class
