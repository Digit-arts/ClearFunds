Imports System.Data

Partial Class Admin_AutoWithDrawHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        str = ("select UserName,CONVERT (varchar, WithDrawl_Date,106) as Date, WithDrawl_Amount as Amount from CF_WithDrawl a Join aspnet_Users b on b.UserId=a.WithDrawl_UserId where a.WithDrawl_Status='true' and a.Auto_WithDrawl='true'")
        Total = obj.Returnsinglevalue("select SUM( WithDrawl_Amount) as Amount from CF_WithDrawl a Join aspnet_Users b on b.UserId=a.WithDrawl_UserId  where a.WithDrawl_Status='true' and a.Auto_WithDrawl='true'")
        lblAmt.Text = Val(Total)
        dt = obj.returndatatable(str, dt)
        GVPaymentDetails.DataSource = dt
        GVPaymentDetails.DataBind()

    End Sub
End Class
