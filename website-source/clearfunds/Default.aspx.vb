Imports System
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Session("User_Id") = Nothing Then
        '    'Login1.Visible = False
        '    'HyperLink1.Visible = True
        'Else
        '    'HyperLink1.Visible = False
        'End If
        'Dim obj As New ClassFunctions()
        'Dim dt As New DataTable()
        'dt = obj.returndatatable("select top 2 * from   [CF_CompanyNews] where Company_ChkActive='1' and [Company_Isdeleted]<>1", dt)

        'If dt.Rows.Count > 0 Then
        '    Dim div1 As New HtmlGenericControl("div")
        '    div1.Attributes.Add("class", "c_newsbox1")
        '    'div.Attributes.Add("class", "c_newsone")
        '    divmain.Controls.Add(div1)

        '    Dim count As Integer = dt.Rows.Count - 1
        '    For i As Integer = 0 To count

        '        Dim div As New HtmlGenericControl("div")
        '        div.Attributes.Add("class", "c_newsone1")
        '        'div.Attributes.Add("class", "c_newsone")
        '        div1.Controls.Add(div)
        '        Dim div_new As New HtmlGenericControl("div")
        '        div_new.Attributes.Add("class", "h_img")
        '        div.Controls.Add(div_new)
        '        Dim album As New ImageButton()
        '        'album.ID = "album";
        '        album.Width = 304
        '        album.Height = 200
        '        album.ImageUrl = "~/CompanyNewsHandler.ashx?id=" & dt.Rows(i)("company_Id").ToString()
        '        album.PostBackUrl = "~/Newsfr.aspx?id=" & dt.Rows(i)("company_Id").ToString()

        '        'album.Click += new ImageClickEventHandler(lalbum_click);
        '        div_new.Controls.Add(album)

        '        'HtmlGenericControl br1 = new HtmlGenericControl("br");
        '        'div.Controls.Add(br1);
        '        Dim div_right As New HtmlGenericControl("div")
        '        div_right.Attributes.Add("class", "c_newscnt")

        '        div.Controls.Add(div_right)
        '        Dim lblNameEN As New Label()
        '        ' lblNameEN.ID = "Label1" & i
        '        lblNameEN.CssClass = "img_lbp"
        '        lblNameEN.Text = dt.Rows(i)("company_subject").ToString()
        '        div_right.Controls.Add(lblNameEN)

        '        'HtmlGenericControl br = new HtmlGenericControl("br");
        '        'div.Controls.Add(br);
        '        Dim lblNameDec As New Label()
        '        'lblNameDec.ID = "Label1" & i
        '        lblNameDec.CssClass = "img_lbpt"
        '        lblNameDec.Text = dt.Rows(i)("company_EN_summarydescription").ToString()
        '        div_right.Controls.Add(lblNameDec)
        '        Dim lnkReadmore As New LinkButton()
        '        'lnkReadmore.ID = "Link" & i
        '        lnkReadmore.CssClass = "img_lbpd"
        '        lnkReadmore.Text = "Read more..."
        '        lnkReadmore.PostBackUrl = "~/Newsfr.aspx?id=" & dt.Rows(i)("company_Id").ToString()
        '        div_right.Controls.Add(lnkReadmore)
        '    Next
        'End If

    End Sub
End Class
