Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_Banner
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select Extras_Banner_Id ,Extras_Banner_Subject from CF_Extras_Banner"
        ds = obj.ReturnDataSet(str)
        GVSupportList.DataSource = ds
        GVSupportList.DataBind()


    End Sub
End Class
