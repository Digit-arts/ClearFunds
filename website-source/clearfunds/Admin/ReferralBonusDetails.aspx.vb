Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_ReferralBonusDetails
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select AddRefBonus_id, AddRefBonus_Name,AddRefBonus_From,AddRefBonus_To,AddRefBonus_Commision  from CF_AddRefBonus "
        ds = obj.ReturnDataSet(str)
        GVReferralbonusDetails.DataSource = ds
        GVReferralbonusDetails.DataBind()
    End Sub

    Protected Sub GVReferralbonusDetails_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GVReferralbonusDetails.PageIndex = e.NewPageIndex
        Binddata()
    End Sub
    Protected Sub Binddata()
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        str = "select AddRefBonus_id, AddRefBonus_Name,AddRefBonus_From,AddRefBonus_To,AddRefBonus_Commision  from CF_AddRefBonus "
        ds = obj.ReturnDataSet(str)
        GVReferralbonusDetails.DataSource = ds
        GVReferralbonusDetails.DataBind()
    End Sub
End Class
