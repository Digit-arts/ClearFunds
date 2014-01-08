Imports System.Data

Partial Class Content
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Request.QueryString("id") Is Nothing) Then
            Dim contentid As String = Request.QueryString("id").ToString()
            Dim obj As New ClassFunctions()
            Dim dt As New DataTable()
            obj.returndatatable("select * from [CF_contents] where [contents_id]='" & contentid & "'", dt)
            If dt.Rows.Count > 0 Then
                If Not (dt.Rows(0)("contents_content").ToString() = "") Then
                    Label5.Text = dt.Rows(0)("contents_title").ToString()
                    Label5.CssClass = "innerptitl"
                    Label3.Text = dt.Rows(0)("contents_content").ToString()
            
                    Page.Title = dt.Rows(0)("contents_metatitle").ToString()
                    'Page description
                    Dim pagedesc As New HtmlMeta()
                    pagedesc.Name = dt.Rows(0)("contents_metakey").ToString()
                    pagedesc.Content = dt.Rows(0)("contents_metadesc").ToString()
                    Header.Controls.Add(pagedesc)
                    'page keywords
                    Dim pagekeywords As New HtmlMeta()
                    pagekeywords.Name = dt.Rows(0)("contents_metakey").ToString()
                    pagekeywords.Content = dt.Rows(0)("contents_metadesc").ToString()
                    Header.Controls.Add(pagekeywords)
                    'Label1.Text = dt.Rows[0]["contents_content"].ToString();
                    'Response.Write(dt.Rows[0]["contents_content"].ToString());

                Else

                    Label4.Text = "No Records Found"

                End If
            End If
        End If
    End Sub
End Class
