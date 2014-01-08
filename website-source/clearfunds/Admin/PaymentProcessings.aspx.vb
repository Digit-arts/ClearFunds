Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Admin_PaymentProcessings
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select CustomProcessing_id,CustomProcessing_Name,CustomProcessing_Image from CF_CustomProcessing"
        ds = obj.ReturnDataSet(str)
        GVPaymentDetails.DataSource = ds
        GVPaymentDetails.DataBind()

    End Sub
    Protected Sub GVPaymentDetails_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GVPaymentDetails.PageIndex = e.NewPageIndex
        Binddata()
    End Sub
    Protected Sub Binddata()
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select CustomProcessing_id,CustomProcessing_Name,CustomProcessing_Image from CF_CustomProcessing"
        ds = obj.ReturnDataSet(str)
        GVPaymentDetails.DataSource = ds
        GVPaymentDetails.DataBind()
    End Sub
End Class
