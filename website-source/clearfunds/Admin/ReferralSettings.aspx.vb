Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Admin_ReferralSettings
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim ds As New DataTable

        obj.returndatatable("select  User_FirstName,convert(varchar,a.EntryDate,103) as Date,a.status,a.referenceUser_id,a.User_id from CF_Referral a inner join CF_User b on b.User_Id=a.User_Id where a.status='true'   ", ds)
        ds.Columns.Add("ReferenceName")
        If ds.Rows.Count > 0 Then
            For i As Integer = 0 To ds.Rows.Count - 1
                str2 = obj.Returnsinglevalue("select User_FirstName from  CF_Referral a inner join CF_User b on b.User_id =a.referenceUser_id where a.User_id='" + ds.Rows(i)("User_id").ToString() + "' ")
                ds.Rows(i).Item("ReferenceName") = str2
                GVWDHistory.DataSource = ds
                GVWDHistory.DataBind()
            Next

            GVWDHistory.DataSource = ds
            GVWDHistory.DataBind()
        End If
    End Sub
    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click

        Dim ds As New DataTable
        Dim str As String = " "
        Dim str2 As String = ""

        obj.returndatatable("select User_FirstName,convert(varchar,a.EntryDate,103) as Date,a.status,a.referenceUser_id,a.User_id from  CF_Referral a inner join CF_User b on b.User_Id=a.User_Id where EntryDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ' ", ds)

        ds.Columns.Add("ReferenceName")

        If ds.Rows.Count > 0 Then
            For i As Integer = 0 To ds.Rows.Count - 1
                str2 = obj.Returnsinglevalue("select User_FirstName from  CF_Referral a inner join CF_User b on b.User_id =a.referenceUser_id where a.User_id='" + ds.Rows(i)("User_id").ToString() + "' ")
                ds.Rows(i).Item("ReferenceName") = str2
                GVWDHistory.DataSource = ds
                GVWDHistory.DataBind()
            Next

            GVWDHistory.DataSource = ds
            GVWDHistory.DataBind()
        End If

    End Sub

End Class

