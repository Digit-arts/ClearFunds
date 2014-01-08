
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
Partial Class Admin_AddEditRules
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        If Not IsPostBack Then
            If Not Request.QueryString("Pid") = Nothing Then
                obj.strMode = "Modify"
                savebutton.Text = "Update"
                SelectedIndexId = Request.QueryString("Pid").ToString()
                dt = obj.returndatatable("select * from CF_CMS_Rules where CMS_Rules_Id='" + SelectedIndexId + "'", dt)
                If dt.Rows.Count > 0 Then
                  
                    txtsub.Text = dt.Rows(0).Item("CMS_Rules_Subject").ToString()

                    HtmlEditor.Content = dt.Rows(0).Item("CMS_Rules_Description").ToString()
                    If dt.Rows(0).Item("CMS_Rules_ChkActive").ToString() = "True" Then
                        chkActive.Checked = True
                    Else
                        chkActive.Checked = False
                    End If
                End If
            Else
                obj.strMode = "Add"
                savebutton.Text = "Save"
            End If

        End If

    End Sub

    Protected Sub savebutton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles savebutton.Click
        Try


            If savebutton.Text = "Save" Then
                obj.strMode = "Add"
            Else
                obj.strMode = "Modify"
            End If

            Select Case obj.strMode
                Case "Add"
                    ID = obj.getIndexKey()

                Case "Modify"
                    SelectedIndexId = Request.QueryString("Pid").ToString()
                    ID = SelectedIndexId

                Case "Delete"

                    'If status = "C" Then
                    '  MsgBox("This Order Picked invoice So u can't delete.")

            End Select
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            Dim MAX As SqlDbType
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_CMS_Rules"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@CMS_Rules_Id", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@CMS_Rules_Subject", SqlDbType.VarChar, 50)).Value = txtsub.Text
            cmd.Parameters.Add(New SqlParameter("@CMS_Rules_Description", SqlDbType.VarChar, MAX)).Value = HtmlEditor.Content
            cmd.Parameters.Add(New SqlParameter("@CMS_Rules_UserId", SqlDbType.VarChar, 10)).Value = "1"
            cmd.Parameters.Add(New SqlParameter("@CMS_Rules_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.Parameters.Add(New SqlParameter("@CMS_Rules_ChkActive", SqlDbType.VarChar, 10)).Value = chkActive.Checked


            cmd.ExecuteNonQuery()

            cmd.Parameters.Clear()


            Select Case obj.strMode
                Case "Add"
                    'MsgBox("Data Was Saved.")



                Case "Modify"
                    ' MsgBox("Data Was Modified.")
                Case "Delete"
                    ' MsgBox("Data Was Deleted.")
            End Select

        Catch ex As Exception
            '  MsgBox(ex.Message)
            obj.strMode = "Add"

            obj = Nothing
        Finally

            Response.Redirect("rules.aspx")

        End Try

    End Sub
End Class
