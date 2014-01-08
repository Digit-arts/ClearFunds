Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Account_YourReferrals
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            Dim userid As String = Session("User_Id").ToString()

            Dim str As String = obj.Returnsinglevalue("select user_Phone from cf_user where [User_Id]='" + userid + "'")
            If str = "0" Then
                Response.Redirect("~/account/editprofile.aspx", True)
            End If

        End If
        If Not Session("User_id") = Nothing Then
            SelectedIndexId = Session("User_id")
            '    Dim dt As New DataTable
            '    dt = obj.returndatatable("", dt)
            '    If dt.Rows.Count > 0 Then
            '        lblReferrals.Text = dt.Rows(0).Item("").ToString
            '        lblActiverefe.Text = dt.Rows(0).Item("").ToString
            '        lbltotalref.Text = dt.Rows(0).Item("").ToString
            '    End If 
            ' Label1.Text=dt.Rows(i).Item("cms_support_Description").ToString()
            'lblReferrals.Text = obj.Returnsinglevalue("select  count(referenceUser_id) from CF_Referral where referenceUser_id='" + SelectedIndexId + "'") 
            ' lblActiverefe.Text = obj.Returnsinglevalue("select  count(referenceUser_id) from CF_Referral where referenceUser_id='" + SelectedIndexId + "' and Status='true'")
            Dim dt As New DataTable()
            If Not IsPostBack Then

                Dim i As Integer = 0
                dt = obj.returndatatable("select  * from CF_AddRefBonus", dt)

                For Each Count In dt.Rows

                    If dt.Rows.Count > 0 Then
                        Dim Label1 As New Label
                        Label1.ID = "Label1"
                        Label1.CssClass = "level_one"

                        Label1.Text = dt.Rows(i).Item("AddRefBonus_Name").ToString()
                        pnlaccount.Controls.Add(Label1)
                        Dim breakTag As LiteralControl
                        breakTag = New LiteralControl("<br />")
                        pnlaccount.Controls.Add(breakTag)



                        'Dim Label6 As New Label
                        'Label6.ID = "Label6"
                        'Label6.Text = dt.Rows(i).Item("AddRefBonus_Commision").ToString()
                        'pnlaccount.Controls.Add(Label6)

                        Dim breakTag1 As LiteralControl
                        breakTag1 = New LiteralControl("<br />")
                        pnlaccount.Controls.Add(breakTag1)

                        Dim Label52 As New Label
                        Label52.ID = "Label52"
                        Label52.Text = "Your Referrals :"
                        Label52.CssClass = "ref_one"

                        pnlaccount.Controls.Add(Label52)

                        Dim Label3 As New Label
                        Label3.ID = "Label3"
                        Label3.CssClass = "refone_txt"
                        Label3.Text = obj.Returnsinglevalue("select  count(referenceUser_id) from CF_Referral where referenceUser_id='" + SelectedIndexId + "'")
                        pnlaccount.Controls.Add(Label3)

                        Dim breakTag2 As LiteralControl
                        breakTag2 = New LiteralControl("<br />")
                        pnlaccount.Controls.Add(breakTag2)

                        Dim Label4 As New Label
                        Label4.ID = "Label4"

                        Label4.Text = "Your Active referrals :"
                        Label4.CssClass = "ref_one"

                        pnlaccount.Controls.Add(Label4)

                        Dim Label5 As New Label
                        Label5.ID = "Label5"
                        Label5.CssClass = "refone_txt"
                        Label5.Text = obj.Returnsinglevalue("select  count(referenceUser_id) from CF_Referral where referenceUser_id='" + SelectedIndexId + "' and Status='true'")
                        pnlaccount.Controls.Add(Label5)

                        Dim breakTag3 As LiteralControl
                        breakTag3 = New LiteralControl("<br />")
                        pnlaccount.Controls.Add(breakTag3)


                        Dim Label7 As New Label
                        Label7.ID = "Label7"
                        Label7.Text = "Total Referral Commission :"
                        Label7.CssClass = "ref_one"
                        pnlaccount.Controls.Add(Label7)

                        Dim Label8 As New Label
                        Label8.ID = "Label8"
                        Label8.CssClass = "refone_txt"
                        Label8.Text = ""
                        pnlaccount.Controls.Add(Label8)

                        Dim br3 As New HtmlGenericControl("br")
                        pnlaccount.Controls.Add(br3)





                    End If
                    i = i + 1
                Next


            End If
        Else
            Response.Redirect("login.aspx")
        End If

    End Sub
End Class
