Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_WithDrawalHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = " "
        Dim Total As Double
        str = ("select UserName,CONVERT (varchar, WithDrawl_Date,106) as Date, WithDrawl_Amount as Amount from CF_WithDrawl a Join aspnet_Users b on b.UserId=a.WithDrawl_UserId")
        Total = obj.Returnsinglevalue("select SUM( WithDrawl_Amount) as Amount from CF_WithDrawl a Join aspnet_Users b on b.UserId=a.WithDrawl_UserId")
        lblAmt.Text = Val(Total)
        ds = obj.ReturnDataSet(str)
        GVWDHistory.DataSource = ds
        GVWDHistory.DataBind()


    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = " "
        Dim Total As Double
        str = ("select UserName,CONVERT (varchar, WithDrawl_Date,106) as Date, WithDrawl_Amount as Amount from CF_WithDrawl a join aspnet_Users b on b.UserId=a.WithDrawl_UserId where WithDrawl_Date BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ' ")
        Total = obj.Returnsinglevalue("select SUM( WithDrawl_Amount) as Amount from CF_WithDrawl a Join aspnet_Users b on b.UserId=a.WithDrawl_UserId   where WithDrawl_Date BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ' ")
        lblAmt.Text = Val(Total)
        ds = obj.ReturnDataSet(str)
        GVWDHistory.DataSource = ds
        GVWDHistory.DataBind()

    End Sub

End Class
