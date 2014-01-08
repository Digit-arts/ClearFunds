
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
    'Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    '    'If Not Me.IsPostBack Then
    '    If Session("User_Id") = Nothing Then
    '        Response.Redirect("~/default.aspx")

    '    End If
    '    'End If
    'End Sub
    Dim cmd As New SqlCommand()
    Dim con As New SqlConnection()
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGroup()
        End If
    End Sub
    Protected Sub btn_Create_Click(ByVal sender As Object, ByVal e As EventArgs)
        con = New SqlConnection(obj.ConnectionString())
        If Not (txt_grname.Text.Trim().Length = 0) Then

            obj.returndatatable("select Category_Name from Ticket_Category where Category_Name='" + txt_grname.Text & "' ", dt)

            If dt.Rows.Count > 0 Then

                Response.Write("<script>alert('Group Name Already Exists Please Try Some Other Name')</script>")
            Else
                con.Open()
                cmd = New SqlCommand("insert into Ticket_Category values('" + obj.getIndexKey + "','" + txt_grname.Text + "')", con)

                cmd.ExecuteNonQuery()

                cmd.Parameters.Clear()
                con.Close()
                dt = obj.returndatatable("select Category_Id,Category_Name from Ticket_Category", dt)
                If dt.Rows.Count > 0 Then
                    gvgroupname.DataSource = dt
                    gvgroupname.DataBind()
                    txt_grname.Text = ""
                End If
            End If
        Else

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('groupname can't be empty');", True)
        End If
    End Sub
    Protected Sub BindGroup()
        Dim dt1 As New DataTable()
        dt1 = obj.returndatatable("select Category_Id,Category_Name from Ticket_Category", dt1)
        If dt1.Rows.Count > 0 Then

            gvgroupname.DataSource = dt1
            gvgroupname.DataBind()
        End If
    End Sub
    Protected Sub Delete_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim con As SqlConnection = New SqlConnection(obj.ConnectionString())
        Dim lnk As ImageButton = Nothing
        Dim gvrow As GridViewRow = Nothing

        lnk = TryCast(sender, ImageButton)
        gvrow = TryCast(lnk.NamingContainer, GridViewRow)


        Dim lbldeleteID As Label = CType(gvrow.FindControl("lblid"), Label)
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("delete from  Ticket_Category  where Category_Id='" + lbldeleteID.Text + "'", con)
        cmd.ExecuteNonQuery()
        con.Close()
        BindGroup()
    End Sub

End Class
