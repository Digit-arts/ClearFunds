Imports System.Data

Partial Class Newsfr
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         If Not IsPostBack Then
        Dim SelectedIndexId As String = ""
        HyperLink1.Text = "Back to News"
        HyperLink1.CssClass = "backmode"
        SelectedIndexId = Request.QueryString("id").ToString()
            dt = obj.returndatatable("select * from   [CF_CompanyNews] where Company_Id='" & SelectedIndexId & "'", dt)

        If dt.Rows.Count > 0 Then
            Dim count As Integer = dt.Rows.Count - 1
                For i As Integer = 0 To count
                    Dim div_new As New HtmlGenericControl("div")
                    div_new.Attributes.Add("class", "news_imag")
                    div1.Controls.Add(div_new)
                    Dim album As New Image()
                    album.ID = "album"
                    album.Width = 200
                    album.Height = 200
                    album.ImageUrl = "~/CompanyNewsHandler.ashx?id=" & dt.Rows(i)("company_Id").ToString()
                    div_new.Controls.Add(album)
                    Dim breakTag1 As LiteralControl = Nothing
                    breakTag1 = New LiteralControl("&nbsp;")
                    div1.Controls.Add(breakTag1)


                    Dim div_sub As New HtmlGenericControl("div")
                    div_sub.Attributes.Add("Class", "lat_newsrit")
                    div1.Controls.Add(div_sub)
                    Dim lblname As New Label()
                    lblname.ID = "lblname"
                    lblname.CssClass = "label_text"
                    lblname.Text = dt.Rows(0)("Company_subject").ToString()
                    div_sub.Controls.Add(lblname)

                    Dim br As New HtmlGenericControl("br")
                    div1.Controls.Add(br)

                    Dim div_sum As New HtmlGenericControl("div")
                    div_sum.Attributes.Add("class", "latnews_summary")
                    div1.Controls.Add(div_sum)

                    Dim lbldesc As New Label()
                    lbldesc.ID = "lbldesc"
                    lbldesc.CssClass = "label_text"
                    lbldesc.Text = dt.Rows(0)("Company_EN_SummaryDescription").ToString()
                    div_sum.Controls.Add(lbldesc)

                    Dim div_des As New HtmlGenericControl("div")
                    div_des.Attributes.Add("class", "latnews_exp")
                    div1.Controls.Add(div_des)

                    Dim lblNameDec As New Label()
                    lblNameDec.ID = "Label1"
                    lblNameDec.CssClass = "pe_ctext"
                    lblNameDec.Text = dt.Rows(0)("Company_EN_Detaileddescription").ToString()
                    div_des.Controls.Add(lblNameDec)
                Next
            End If
        End If
    End Sub
End Class
