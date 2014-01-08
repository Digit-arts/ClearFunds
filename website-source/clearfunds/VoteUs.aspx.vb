Imports System.Data

Partial Class VoteUs
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Label12.Text = "VOTE US"
            Label12.CssClass = "innerptitl"
            Dim SelectedIndexId As String = ""


            dt = obj.returndatatable("select * from   [CF_VoteUs]", dt)

            If dt.Rows.Count > 0 Then
                Dim count As Integer = dt.Rows.Count - 1
                For i As Integer = 0 To count
                    Dim div As New HtmlGenericControl("div")
                    div.Attributes.Add("class", "voteus_img")
                    pnlpeople.Controls.Add(div)
                    Dim album As New ImageButton()
                    'album.ID = "album" + i.ToString()
                    album.Width = 200
                    album.Height = 200
                    album.AlternateText = dt.Rows(i)("VoteUs_title").ToString()
                    album.ImageUrl = "ImageHandlerVoteUs.ashx?id=" & dt.Rows(i)("VoteUs_id").ToString()
                    album.PostBackUrl = dt.Rows(i)("VoteUs_url").ToString()
                    div.Controls.Add(album)
                    Dim br As New HtmlGenericControl("br")
                    div.Controls.Add(br)






                Next
            End If
        End If
    End Sub
End Class
