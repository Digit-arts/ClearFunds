Imports System.Data

Partial Class News
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label12.Text = "COMPANY NEWS"
        Label12.CssClass = "innerptitl"
        If Not IsPostBack Then



            Dim contentid As String = "10"
            Dim dt1 As New DataTable()
            dt1 = obj.returndatatable("select * from [CF_contents] where [contents_id]='" & contentid & "'", dt1)
            'Label1.Text = dt1.Rows(0)("contents_content").ToString()
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

            dt = obj.returndatatable("select * from   [CF_CompanyNews] where Company_ChkActive='1' and [Company_Isdeleted]<>1", dt)

            If dt.Rows.Count > 0 Then
                Dim div1 As New HtmlGenericControl("div")
                div1.Attributes.Add("class", "c_newsbox")
                'div.Attributes.Add("class", "c_newsone")
                pnlpeople.Controls.Add(div1)

                Dim count As Integer = dt.Rows.Count - 1
                For i As Integer = 0 To count

                    Dim div As New HtmlGenericControl("div")
                    div.Attributes.Add("class", "c_newsone")
                    'div.Attributes.Add("class", "c_newsone")
                    div1.Controls.Add(div)
                    Dim div_new As New HtmlGenericControl("div")
                    div_new.Attributes.Add("class", "c_newsimg")
                    div.Controls.Add(div_new)
                    Dim album As New ImageButton()
                    'album.ID = "album";
                    album.Width = 200
                    album.Height = 200
                    album.ImageUrl = "~/CompanyNewsHandler.ashx?id=" & dt.Rows(i)("company_Id").ToString()
                    album.PostBackUrl = "~/Newsfr.aspx?id=" & dt.Rows(i)("company_Id").ToString()

                    'album.Click += new ImageClickEventHandler(lalbum_click);
                    div_new.Controls.Add(album)

                    'HtmlGenericControl br1 = new HtmlGenericControl("br");
                    'div.Controls.Add(br1);
                    Dim div_right As New HtmlGenericControl("div")
                    div_right.Attributes.Add("class", "c_newscnt")

                    div.Controls.Add(div_right)
                    Dim lblNameEN As New Label()
                    lblNameEN.ID = "Label1" & i
                    lblNameEN.CssClass = "img_lbp"
                    lblNameEN.Text = dt.Rows(i)("company_subject").ToString()
                    div_right.Controls.Add(lblNameEN)

                    'HtmlGenericControl br = new HtmlGenericControl("br");
                    'div.Controls.Add(br);
                    Dim lblNameDec As New Label()
                    lblNameDec.ID = "Label1" & i
                    lblNameDec.CssClass = "img_lbpt"
                    lblNameDec.Text = dt.Rows(i)("company_EN_summarydescription").ToString()
                    div_right.Controls.Add(lblNameDec)
                    Dim lnkReadmore As New LinkButton()
                    lnkReadmore.ID = "Link" & i
                    lnkReadmore.CssClass = "img_lbpd"
                    lnkReadmore.Text = "Read more..."
                    lnkReadmore.PostBackUrl = "~/Newsfr.aspx?id=" & dt.Rows(i)("company_Id").ToString()
                    div_right.Controls.Add(lnkReadmore)
                Next
            End If
        End If
    End Sub
End Class
