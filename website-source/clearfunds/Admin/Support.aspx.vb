Imports System.Data
Imports System.Data.SqlClient
Partial Class _Support
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select CMS_Support_id ,CMS_Support_Subject from CF_CMS_Support"
        ds = obj.ReturnDataSet(str)
        GVSupportList.DataSource = ds
        GVSupportList.DataBind()


    End Sub

End Class
