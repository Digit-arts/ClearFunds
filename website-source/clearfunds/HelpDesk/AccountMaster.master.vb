Imports System.Data
Imports System.Web.UI
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI.WebControls


Partial Class AccountMaster
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim obj As New ClassFunctions()
        Dim dt As New DataTable
        If Not Session("User_Id") = Nothing Then


            dt = obj.returndatatable("select * from [CF_contents] where [contents_publish]=1 and [contents_fid]=1 and contents_status=1 order by contents_orderno ", dt)
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

                    ElseIf hyp1.ID = "10" Then
                        hyp1.NavigateUrl = "~/News.aspx"

                    ElseIf hyp1.ID = "11" Then
                        hyp1.NavigateUrl = "~/FAQ.aspx"
                    ElseIf hyp1.ID = "12" Then
                        hyp1.NavigateUrl = "~/Voteus.aspx"
                    ElseIf hyp1.ID = "14" Then
                        hyp1.NavigateUrl = "~/Contact.aspx"
                    Else
                        hyp1.NavigateUrl = "~/content.aspx?id=" + dt.Rows(i).Item("contents_id").ToString()
                    End If
                    li.Controls.Add(hyp1)
                Next
            End If

        End If




    End Sub


   

End Class

