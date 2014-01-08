Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_rules
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select CMS_Rules_Id ,CMS_Rules_Subject from CF_CMS_Rules"
        ds = obj.ReturnDataSet(str)
        GVSupportList.DataSource = ds
        GVSupportList.DataBind()


    End Sub
End Class
