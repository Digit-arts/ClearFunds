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
Partial Class Account_Default
    Inherits System.Web.UI.Page
     Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Not Me.IsPostBack Then
        If Session("User_Id") = Nothing Then
            Response.Redirect("~/default.aspx")

        End If

        'End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt1 As New DataTable()
        Dim obj As New ClassFunctions

        If Not Session("User_Id") = Nothing Then
            If Not IsPostBack = True Then
                lbopcount.Text = obj.Returnsinglevalue("select count(*) from Tickets where Tickets_Status='Open' and Tickets_UserId='" + Session("User_Id").ToString() + "'")
                lbclscount.Text = obj.Returnsinglevalue("select count(*) from Tickets where Tickets_Status='Close' and Tickets_UserId='" + Session("User_Id").ToString() + "'")
                lballcount.Text = obj.Returnsinglevalue("select count(*) from Tickets where Tickets_UserId='" + Session("User_Id").ToString() + "'")
                Call FillDataGrid()
            End If
        End If
    End Sub

    Private Sub FillDataGrid()

        Dim str As String = ""
        Dim obj As New ClassFunctions
        Dim dt1 As New DataTable

        obj.returndatatable("select c.Tickets_Id,c.Tickets_UserName,b.Category_Id,c.Tickets_Priority,c.Tickets_Date,c.Tickets_Problem,c.Tickets_Comment,c.[Tickets_RegDate],c.[Tickets_Status]  from Tickets c left join Ticket_Category b  on c.Tickets_CategoryId=b.Category_Id   where c.Tickets_UserId ='" + Session("User_Id") + "' ", dt1)
        dt1.Columns.Add("Category_name")
        If dt1.Rows.Count > 0 Then
            For i As Integer = 0 To dt1.Rows.Count - 1
                Dim catname As String = obj.Returnsinglevalue("select category_name from ticket_Category where category_Id='" + dt1.Rows(i).Item("Category_Id").ToString + "'")
                dt1.Rows(i)("category_name") = catname
            Next
            gridview1.DataSource = dt1
            gridview1.DataBind()
        End If
        lbltick.Text = "All Tickets"
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand

        If e.CommandName = "imgreply" Then
            Dim uid As String
            uid = Session("User_Id").ToString()
            Response.Redirect("~/Account/Replypost.aspx?id=" + uid)
        End If

    End Sub
    Protected Sub Open_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles ImageButton1.Click
        Dim str As String = ""
        Dim obj As New ClassFunctions
        Dim dt1 As New DataTable
        lbltick.Text = "Open Tickets"
        obj.returndatatable("select c.Tickets_Id,c.Tickets_UserName,b.Category_Id,c.Tickets_Priority,c.Tickets_Date,c.Tickets_Problem,c.Tickets_Comment,c.[Tickets_RegDate],c.[Tickets_Status]  from Tickets c left join Ticket_Category b  on c.Tickets_CategoryId=b.Category_Id   where c.Tickets_UserId ='" + Session("User_Id") + "' and c.Tickets_Status='Open' ", dt1)
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
    Protected Sub Close_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles ImageButton2.Click

        Dim str As String = ""
        Dim obj As New ClassFunctions
        Dim dt1 As New DataTable
        lbltick.Text = "Closed Tickets"
        obj.returndatatable("select c.Tickets_Id,c.Tickets_UserName,b.Category_Id,c.Tickets_Priority,c.Tickets_Date,c.Tickets_Problem,c.Tickets_Comment,c.[Tickets_RegDate],c.[Tickets_Status]  from Tickets c left join Ticket_Category b  on c.Tickets_CategoryId=b.Category_Id   where c.Tickets_UserId ='" + Session("User_Id") + "' and c.Tickets_Status='Close' ", dt1)
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
        lbltick.Text = "All Tickets"
        FillDataGrid()
    End Sub

  
End Class
