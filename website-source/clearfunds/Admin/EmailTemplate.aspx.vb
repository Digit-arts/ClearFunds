Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_EmailTemplate
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select Email_Templates_Id ,Email_Templates_Title from CF_Email_Templates"
        ds = obj.ReturnDataSet(str)
        GVEditEmail.DataSource = ds
        GVEditEmail.DataBind()


    End Sub
End Class
