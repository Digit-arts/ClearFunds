Imports System.Data
Partial Class login
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then

            SmallLogout1.Visible = True
            menu.Visible = True
            Menuleft.Visible = True
            pnllogin.Visible = False
        Else
            menu.Visible = False
            pnllogin.Visible = True
            SmallLogout1.Visible = False
            Menuleft.Visible = False
        End If
        Dim obj As New ClassFunctions()
        Dim dt As New DataTable
        dt = obj.returndatatable("select * from [CF_contents] where [contents_publish]=1 and [contents_fid]=1 and contents_status=1 order by contents_orderno", dt)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim div As New HtmlGenericControl("div")
                divmenu.Controls.Add(div)
                Dim ul As New HtmlGenericControl("ul")
                divmenu.Controls.Add(ul)
                Dim li As New HtmlGenericControl("li")
                ul.Controls.Add(li)

                Dim hyp1 As New HyperLink
                hyp1.ID = dt.Rows(i).Item("contents_id").ToString()
                hyp1.Text = dt.Rows(i).Item("contents_title").ToString()

                If hyp1.ID = "6" Then
                    hyp1.NavigateUrl = "~/default.aspx"
                ElseIf hyp1.ID = "7" Then
                    hyp1.NavigateUrl = "~/support.aspx"
                ElseIf hyp1.ID = "8" Then
                    hyp1.NavigateUrl = "~/stats.aspx"
                ElseIf hyp1.ID = "12" Then
                    hyp1.NavigateUrl = "~/Rateus.aspx"
                ElseIf hyp1.ID = "9" Then
                    hyp1.NavigateUrl = "~/Rules.aspx"
                ElseIf hyp1.ID = "10" Then

                    hyp1.NavigateUrl = "~/InvestorsTop.aspx"
                ElseIf hyp1.ID = "11" Then
                    hyp1.NavigateUrl = "~/Contact.aspx"

                Else
                    hyp1.NavigateUrl = "~/content.aspx?id=" + dt.Rows(i).Item("contents_id").ToString()
                End If
                li.Controls.Add(hyp1)
            Next
        End If
    End Sub
End Class

