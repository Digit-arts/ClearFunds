Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_Advertisement
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select Extras_Advertisement_Id ,Extras_Advertisement_Subject from CF_Extras_Advertisement"
        ds = obj.ReturnDataSet(str)
        GVSupportList.DataSource = ds
        GVSupportList.DataBind()


    End Sub

End Class
