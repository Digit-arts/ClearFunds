Imports System.Data
Imports System.Data.SqlClient
Partial Class Payment
    Inherits System.Web.UI.UserControl
    Dim obj As New ClassFunctions()
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        dt = obj.returndatatable("select CustomProcessing_Name,CustomProcessing_Id,CustomProcessing_url from CF_CustomProcessing where CustomProcessing_Status='True'", dt)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim album As New ImageButton()
                'album.ID = "album";
                album.Width = 100
                album.Height = 45
                album.ImageUrl = "~/Handlers/CustomProcessingHandler.ashx?id=" & dt.Rows(i)("CustomProcessing_Id").ToString()
                album.PostBackUrl = dt.Rows(i)("CustomProcessing_url").ToString()
                divpay.Controls.Add(album)
            Next
        End If
    End Sub
End Class
