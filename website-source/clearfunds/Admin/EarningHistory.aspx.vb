Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_EarningHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = " "
        str = ("")
        ds = obj.ReturnDataSet(str)
        GVWDHistory.DataSource = ds
        GVWDHistory.DataBind()

    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = " "

        str = ("")
        ds = obj.ReturnDataSet(str)
        GVWDHistory.DataSource = ds
        GVWDHistory.DataBind()

    End Sub
End Class
