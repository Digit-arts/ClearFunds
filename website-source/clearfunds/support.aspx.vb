Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.Sql
Imports System.IO
Partial Class support
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        If Not IsPostBack Then
            Label12.Text = "Support"
            Label12.CssClass = "innerptitl"

            Dim contentid As String = "16"
            Dim dt1 As New DataTable()
            dt1 = obj.returndatatable("select * from [CF_contents] where [contents_id]='" & contentid & "'", dt1)
            'Page title
            Page.Title = dt1.Rows(0)("contents_metatitle").ToString()
            'Page description
            Dim pagedesc As New HtmlMeta()
            pagedesc.Name = dt1.Rows(0)("contents_metakey").ToString()
            pagedesc.Content = dt1.Rows(0)("contents_metadesc").ToString()
            Header.Controls.Add(pagedesc)
            'page keywords
            Dim pagekeywords As New HtmlMeta()
            pagekeywords.Name = dt1.Rows(0)("contents_metakey").ToString()
            pagekeywords.Content = dt1.Rows(0)("contents_metadesc").ToString()
            Header.Controls.Add(pagekeywords)
        End If
    End Sub
End Class
