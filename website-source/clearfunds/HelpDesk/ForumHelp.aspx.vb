Imports System.Data
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
Partial Class HelpDesk_ForumHelp
    Inherits System.Web.UI.Page

    Dim obj As New ClassFunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt1 As New DataTable()
        Dim obj As New ClassFunctions
        Dim str As String = Nothing
        Dim dt As New DataTable()
        If Not Session("Admin_Id") = Nothing Then

            If Not IsPostBack = True Then
                str = Session("Admin_id").ToString()
                obj.returndatatable("select * from Admin_Users where AdminTickets_Id='" + str + "' ", dt)
                If (dt.Rows.Count > 0) Then
                    lblcategories.Text = dt.Rows(0)("AdminTickets_Categories").ToString()
                    FillDataGrid()
                End If
            End If
        Else
            Response.Redirect("~/HelpDesk/HelpLogin.aspx")
        End If
    End Sub

    Private Sub FillDataGrid()

        Dim str As String = ""
        Dim obj As New ClassFunctions
        Dim dt1 As New DataTable
        Dim catid As String = obj.Returnsinglevalue("select category_Id from ticket_Category where category_Name='" + lblcategories.Text + "'")
        obj.returndatatable("select c.Tickets_Id,c.Tickets_UserName,b.Category_Id,c.Tickets_Priority,c.Tickets_Date,c.Tickets_Problem,c.Tickets_Comment,c.[Tickets_RegDate],c.[Tickets_Status]  from Tickets c left join Ticket_Category b  on c.Tickets_CategoryId=b.Category_Id   where c.Tickets_CategoryId ='" + catid + "' ", dt1)
        dt1.Columns.Add("Category_name")
        If dt1.Rows.Count > 0 Then
            For i As Integer = 0 To dt1.Rows.Count - 1
                Dim catname As String = obj.Returnsinglevalue("select category_name from ticket_Category where category_Id='" + dt1.Rows(i).Item("Category_Id").ToString + "'")
                dt1.Rows(i)("category_name") = catname
            Next
            gridview1.DataSource = dt1
            gridview1.DataBind()

            'For Each gvr In gridview1.Rows
            '    Dim lblStatusValue As Label = CType(gvr.FindControl("lblsa"), Label)

            '    Dim lnkopen As LinkButton = CType(gvr.FindControl("lnkopen"), LinkButton)
            '    Dim lnkclose As LinkButton = CType(gvr.FindControl("lnkclosed"), LinkButton)

            '    If lblStatusValue.Text = "open" Then
            '        lnkclose.Visible = True
            '        lnkopen.Visible = False
            '    ElseIf lblStatusValue.Text = "New" Then
            '        lnkclose.Visible = True
            '        lnkopen.Visible = True
            '    ElseIf lblStatusValue.Text = "Close" Then
            '        lnkclose.Visible = False
            '        lnkopen.Visible = True
            '    End If


            'Next
        End If

    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand

        If e.CommandName = "imgreply" Then
            Dim uid As String
            uid = Session("User_Id").ToString()
            Response.Redirect("~/Account/Replypost.aspx?id=" + uid)
        End If

    End Sub
    Protected Sub Open_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim str As String = ""
        Dim obj As New ClassFunctions
        Dim dt1 As New DataTable
        Dim catid As String = obj.Returnsinglevalue("select category_Id from ticket_Category where category_Name='" + lblcategories.Text + "'")
        obj.returndatatable("select c.Tickets_Id,c.Tickets_UserName,b.Category_Id,c.Tickets_Priority,c.Tickets_Date,c.Tickets_Problem,c.Tickets_Comment,c.[Tickets_RegDate],c.[Tickets_Status]  from Tickets c left join Ticket_Category b  on c.Tickets_CategoryId=b.Category_Id   where c.Tickets_CategoryId ='" + catid + "' and Tickets_Status='Open' ", dt1)
        dt1.Columns.Add("Category_name")
        If dt1.Rows.Count > 0 Then
            For i As Integer = 0 To dt1.Rows.Count - 1
                Dim catname As String = obj.Returnsinglevalue("select category_name from ticket_Category where category_Id='" + dt1.Rows(i).Item("Category_Id").ToString + "'")
                dt1.Rows(i)("category_name") = catname

                gridview1.DataSource = dt1
                gridview1.DataBind()

            Next

        End If
        gridview1.DataSource = dt1
        gridview1.DataBind()
    End Sub
    Protected Sub Close_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim str As String = ""
        Dim obj As New ClassFunctions
        Dim dt1 As New DataTable
        Dim catid As String = obj.Returnsinglevalue("select category_Id from ticket_Category where category_Name='" + lblcategories.Text + "'")
        obj.returndatatable("select c.Tickets_Id,c.Tickets_UserName,b.Category_Id,c.Tickets_Priority,c.Tickets_Date,c.Tickets_Problem,c.Tickets_Comment,c.[Tickets_RegDate],c.[Tickets_Status]  from Tickets c left join Ticket_Category b  on c.Tickets_CategoryId=b.Category_Id   where c.Tickets_CategoryId ='" + catid + "' and Tickets_Status='Close' ", dt1)
        dt1.Columns.Add("Category_name")
        If dt1.Rows.Count > 0 Then
            For i As Integer = 0 To dt1.Rows.Count - 1
                Dim catname As String = obj.Returnsinglevalue("select category_name from ticket_Category where category_Id='" + dt1.Rows(i).Item("Category_Id").ToString + "'")
                dt1.Rows(i)("category_name") = catname

                gridview1.DataSource = dt1
                gridview1.DataBind()

               
            Next

        End If
        gridview1.DataSource = dt1
        gridview1.DataBind()
    End Sub
    Protected Sub All_Click(ByVal sender As Object, ByVal e As EventArgs)
        FillDataGrid()
    End Sub
    Protected Sub Closestatus_click(ByVal sender As Object, ByVal e As EventArgs)
     ID = Request.QueryString("ticketid").ToString()
        obj.ExecuteQuery("update Tickets set Tickets_Status='Close' where Tickets_Id='" + ID + "'")
        FillDataGrid()
    End Sub
    Protected Sub openstatus_click(ByVal sender As Object, ByVal e As EventArgs)

        ID = Request.QueryString("ticketid").ToString()
        obj.ExecuteQuery("update Tickets set Tickets_Status='Open' where Tickets_Id='" + ID + "'")
        FillDataGrid()

    End Sub
 

End Class
