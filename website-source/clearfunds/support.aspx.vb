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

        Label12.Text = "Support"
        Label12.CssClass = "innerptitl"

        Dim contentid As String = "7"
        Dim dt1 As New DataTable()
        dt1 = obj.returndatatable("select * from [CF_contents] where [contents_id]='" & contentid & "'", dt1)
        Label1.Text = dt1.Rows(0)("contents_content").ToString()
        Label1.CssClass = "pho_sr"
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



        If Not IsPostBack Then

            Dim i As Integer = 0
            dt = obj.returndatatable("select * from cf_cms_support where CMS_Support_ChkActive='true'  ", dt)
            For Each Count In dt.Rows

                If dt.Rows.Count > 0 Then
                   
                    Dim imgsupport As New Image
                    imgsupport.ID = "imgsupport"
                    imgsupport.Width = 740
                    imgsupport.Height = 250
                    imgsupport.ImageUrl = "~/Handlers/ImageHandler.ashx?id=" & dt.Rows(i).Item("cms_support_id").ToString()
                    divsupport1.Controls.Add(imgsupport)
                    Dim br3 As New HtmlGenericControl("br")
                    divsupport1.Controls.Add(br3)

                    Dim lblDescription As New Label
                    lblDescription.ID = "lblDescription"
                    lblDescription.Text = dt.Rows(i).Item("cms_support_Description").ToString()
                    divsupport1.Controls.Add(lblDescription)
                    Dim br4 As New HtmlGenericControl("br")
                    divsupport1.Controls.Add(br4)


                End If
                i = i + 1
            Next


        End If
    End Sub
End Class
