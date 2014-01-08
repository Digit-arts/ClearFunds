Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_PenaltyHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        str = "select b.UserName , Penalty_Amount ,convert(varchar, Penalty_ModifyDate, 106) as  Penalty_ModifyDate from CF_Penalty a inner Join aspnet_users b on b.userid=a.Penalty_Userid"
        Total = obj.Returnsinglevalue(" select  sum(Penalty_Amount)from CF_Penalty a inner Join aspnet_users b on b.userid=a.Penalty_Userid")
        lblAmt.Text = Val(Total)
        ds = obj.ReturnDataSet(str)
        GVPenaltyHistory.DataSource = ds
        GVPenaltyHistory.DataBind()

    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = " "
        Dim Total As Double
        str = ("select  b.UserName , Penalty_Amount ,convert(varchar, Penalty_ModifyDate, 106) as  Penalty_ModifyDate from CF_Penalty a inner Join aspnet_users b on b.userid=a.Penalty_Userid where Penalty_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ' ")
        Total = obj.Returnsinglevalue(" select  sum(Penalty_Amount) from CF_Penalty a inner Join aspnet_users b on b.userid=a.Penalty_Userid  where Penalty_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ' ")
        lblAmt.Text = Val(Total)
        ds = obj.ReturnDataSet(str)
        GVPenaltyHistory.DataSource = ds
        GVPenaltyHistory.DataBind()

    End Sub
   
End Class
