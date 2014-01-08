﻿Imports System.Data
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


Partial Class Account_Default
    Inherits System.Web.UI.Page
    Dim dt1 As New DataTable()
    Dim obj As New ClassFunctions
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt1 As New DataTable()
        Dim obj As New ClassFunctions
        Dim id As String
        If Not Request.QueryString("ticketid") = Nothing Then
            id = Request.QueryString("ticketid").ToString()
            If Not Session("Admin_id") = Nothing Then

                obj.returndatatable("select c.Tickets_Id,c.Tickets_Filename,c.Tickets_UserName,b.Category_Id,c.Tickets_Priority,c.Tickets_Date,c.Tickets_Problem,c.Tickets_Comment,c.[Tickets_RegDate],c.[Tickets_Status]  from Tickets c left join Ticket_Category b  on c.Tickets_CategoryId=b.Category_Id   where c.Tickets_Id ='" + id + "' ", dt1)
                dt1.Columns.Add("Category_name")
                Dim catname As String = obj.Returnsinglevalue("select category_name from ticket_Category where category_Id='" + dt1.Rows(0).Item("Category_Id").ToString + "'")
                dt1.Rows(0)("category_name") = catname
                lblopen.Text = dt1.Rows(0).Item("Tickets_Date").ToString()
                lblCategory.Text = dt1.Rows(0).Item("category_name").ToString()
                lblStatus.Text = dt1.Rows(0).Item("Tickets_Status").ToString()
                lblTitle.Text = dt1.Rows(0).Item("Tickets_Problem").ToString()
                LinkButton1.Text = dt1.Rows(0)("Tickets_Filename").ToString()
                Dim dt2 As New DataTable()
                'Dim div As New HtmlGenericControl("div")

                'Panel1.Controls.Add(div)
                dt2 = obj.returndatatable("select * from Ticket_Post where post_TicketId='" + id + "'", dt2)
                If dt2.Rows.Count > 0 Then
                    For i As Integer = 0 To dt2.Rows.Count - 1
                        'Dim uid As String = dt2.Rows(i)("post_Userid").ToString()
                        'Dim uid1 As Guid = obj.ReturnsingleGuid("select User_UserId from CF_User where User_Id='" + uid + "'")
                        'Dim uid2 As String = Convert.ToString(uid1)
                        Dim lblusername As New Label()
                        Dim uid As String = dt2.Rows(i)("post_Userid").ToString()

                        Dim uid1 As Guid = obj.ReturnsingleGuid("select User_UserId from CF_User where User_Id='" + uid + "'")
                        Dim uname As String = ""
                        If Not uid1 = Nothing Then


                            Dim uid2 As String = Convert.ToString(uid1)

                            uname = obj.Returnsinglevalue("select username from aspnet_users where UserId='" + uid2 + "'")



                        Else

                            uname = obj.Returnsinglevalue("select admintickets_username from admin_Users where admintickets_Id='" + uid + "'")


                        End If


                        Dim div_new As New HtmlGenericControl("div")
                        div_new.Attributes.Add("class", "postone")
                        div1.Controls.Add(div_new)

                        Dim div_subtop As New HtmlGenericControl("div")

                        div_subtop.Attributes.Add("Class", "postone_head")
                        div_new.Controls.Add(div_subtop)

                        Dim div_subdown As New HtmlGenericControl("div")

                        div_subdown.Attributes.Add("Class", "postone_comments")

                        'div2.Controls.Add(div_new)

                        div_new.Controls.Add(div_subdown)
                        lblusername.CssClass = "person_name"
                        lblusername.Text = uname
                        lblusername.ForeColor = Drawing.Color.Blue
                        div_subtop.Controls.Add(lblusername)
                        

                        Dim lblupdatedate As New Label()

                        lblupdatedate.Text = dt2.Rows(i)("Post_Modifydate").ToString()

                        lblupdatedate.CssClass = "post_date"

                        lblupdatedate.ForeColor = Drawing.Color.BlueViolet
                        div_subtop.Controls.Add(lblupdatedate)
                        div_subtop.Controls.Add(New LiteralControl("&nbsp;"))
                        Dim lblpriority As New Label()

                        lblpriority.Text = dt2.Rows(i)("Post_Description").ToString()
                        lblpriority.ForeColor = Drawing.Color.Brown
                        div_subdown.Controls.Add(lblpriority)

                        Dim lnk As LinkButton = New LinkButton
                        lnk.ID = dt2.Rows(i)("Post_id").ToString
                        lnk.Text = dt2.Rows(i)("Post_Filename").ToString
                        AddHandler lnk.Click, AddressOf Me.LinkButtonpost_Click
                        div_new.Controls.Add(lnk)
                      

                    Next


                End If
                'Dim Reply As New Button()
                ''Reply.ID = dt1.Rows(i)("Tickets_Id").ToString()
                'Reply.Text = "Reply"

                'AddHandler Reply.Click, AddressOf Me.Button1_Click
                'Reply.ForeColor = Drawing.Color.DimGray
                'div.Controls.Add(Reply)

                'Dim text As New TextBox()
                'text.ID = "txtpost"
                'text.Text = ""
                'text.TextMode = TextBoxMode.MultiLine


                'div.Controls.Add(text)
            End If
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim SelectedIndexId As String = Nothing
        Dim dt1 As New DataTable
        Dim con As New SqlConnection
        con = New SqlConnection(obj.ConnectionString)
        con.Open()
        Dim cmd As New SqlCommand
        ID = Request.QueryString("ticketid").ToString()
        If Not Session("Admin_id") = Nothing Then

            obj.returndatatable("select * from Tickets where Tickets_Id='" + ID + "' ", dt1)
            If dt1.Rows.Count > 0 Then


                For i As Integer = 0 To dt1.Rows.Count - 1

                    SelectedIndexId = Session("Admin_id").ToString()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "SP_TS_Post"
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@post_TicketId", SqlDbType.VarChar, 10)).Value = ID
                    cmd.Parameters.Add(New SqlParameter("@post_Userid", SqlDbType.VarChar, 10)).Value = SelectedIndexId
                    cmd.Parameters.Add(New SqlParameter("@Post_Description", SqlDbType.VarChar, 250)).Value = txtpost.Text
                    cmd.Parameters.Add(New SqlParameter("@Post_Modifydate", SqlDbType.DateTime, 100)).Value = DateTime.Now.ToString()
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    Response.Redirect("ReplyPost.aspx?ticketid=" + ID)

                Next
            End If
        End If

    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        post.Visible = True
        Button1.Visible = False
    End Sub
    Protected Sub LinkButtonpost_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim dt As DataTable = New DataTable
        Dim lnk As LinkButton = CType(sender, LinkButton)

        If (Not (lnk.ID) Is Nothing) Then
            ID = lnk.ID
            obj.returndatatable(("select * from Ticket_Post where Post_id='" + ID + "'"), dt)
            If (Not (dt) Is Nothing) Then
                Dim bytes() As Byte = CType(dt.Rows(0)("Post_attachfile"), Byte())
                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.ContentType = Path.GetExtension(dt.Rows(0)("Post_filename")).ToString.ToLower
                Response.AppendHeader("Content-Disposition", ("attachment; filename=" + dt.Rows(0)("Post_filename").ToString))
                Response.BinaryWrite(bytes)
                Response.Flush()
                Response.End()
            End If
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim dt As DataTable = New DataTable
        If (Not (Request.QueryString("ticketid")) Is Nothing) Then
            ID = Request.QueryString("ticketid").ToString
            obj.returndatatable(("select * from Ticket_Post where Post_TicketId='" + ID + "'"), dt)
            If (Not (dt) Is Nothing) Then
                Dim bytes() As Byte = CType(dt.Rows(0)("Post_attachfile"), Byte())
                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.ContentType = Path.GetExtension(dt.Rows(0)("Post_filename")).Remove(0, 1).ToString.ToLower
                Response.AppendHeader("Content-Disposition", ("attachment; filename=" + dt.Rows(0)("Post_filename").ToString))
                Response.BinaryWrite(bytes)
                Response.Flush()
                Response.End()
            End If
        End If
       
 
    End Sub
End Class