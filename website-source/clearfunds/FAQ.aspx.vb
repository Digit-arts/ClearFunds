Imports System.Data.SqlClient
Imports System.Data

Partial Class FAQ
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Label12.Text = "FAQ"
        Label12.CssClass = "innerptitl"
        If Not IsPostBack Then
            Dim contentid As String = "12"
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




            PopulateAcrDynamically()
        End If
    End Sub
    Private Sub PopulateAcrDynamically()

        Dim con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString.ToString())
        Dim sql As String = "select * from CF_FAQ"
        Dim cmd As New SqlCommand(sql, con)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim lbTitle As Label
            Dim lbContent As Label
            Dim pn As AjaxControlToolkit.AccordionPane
            Dim i As Integer = 0
            ' This is just to use for assigning pane an id
            For Each dr As DataRow In ds.Tables(0).Rows
                lbTitle = New Label()
                lbContent = New Label()
                lbTitle.Text = dr("FAQ_Question").ToString()
                lbContent.Text = dr("FAQ_Answer").ToString()
                pn = New AjaxControlToolkit.AccordionPane()
                pn.ID = "Pane" & i
                pn.HeaderContainer.Controls.Add(lbTitle)
                pn.ContentContainer.Controls.Add(lbContent)
                acrDynamic.Panes.Add(pn)



                i += 1


            Next
        End If



    End Sub
End Class
