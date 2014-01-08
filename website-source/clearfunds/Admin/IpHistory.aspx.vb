Imports System.Data

Partial Class Admin_IpHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""

        str = ("select * from CF_logdet")
       
        dt = obj.returndatatable(str, dt)
        If dt.Rows.Count > 0 Then


            GVPaymentDetails.DataSource = dt
            GVPaymentDetails.DataBind()
        End If

    End Sub
End Class
