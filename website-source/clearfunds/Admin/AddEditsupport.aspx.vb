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

Partial Class Admin_support
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        'If fileup.PostedFile IsNot Nothing AndAlso fileup.PostedFile.ContentLength > 0 Then
        '    Session("ImageBytes") = fileup.FileBytes
        '    Imgdb.ImageUrl = "~/Handlers/FileupImageHandler.ashx"
        'End If
        If Not IsPostBack Then
           
            If Not Request.QueryString("Pid") = Nothing Then
                obj.strMode = "Modify"
                savebutton.Text = "Update"
                SelectedIndexId = Request.QueryString("Pid").ToString()
                dt = obj.returndatatable("select * from cf_cms_support where cms_support_Id='" + SelectedIndexId + "'", dt)
                If dt.Rows.Count > 0 Then

                    txtimg.Text = dt.Rows(0).Item("cms_support_Subject").ToString()
                    If dt.Rows(0).Item("cms_support_chkImage").ToString() = "True" Then
                        chkimage.Checked = True
                    Else
                        chkimage.Checked = False
                    End If
                    If dt.Rows(0).Item("CMS_Support_ChkActive").ToString() = "True" Then
                        chkActive.Checked = True
                    Else
                        chkActive.Checked = False
                    End If
                    If chkimage.Checked = True Then
                        fileup.Visible = True
                        fileimgdb.Visible = True
                        ' fileimg.Visible = True
                    Else
                        fileup.Visible = False
                        fileimgdb.Visible = False
                        ' fileimg.Visible = False
                    End If

                    Imgdb.ImageUrl = "~/Handlers/ImageHandler.ashx?id=" & dt.Rows(0).Item("cms_support_id").ToString()
                    HtmlEditor.Content = dt.Rows(0).Item("cms_support_Description").ToString()
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
                    '    MsgBox("This Order Picked invoice So u can't delete.")

            End Select
            Dim imageBytes As Byte()
            If chkimage.Checked = True Then
                Dim fileName As String = fileup.PostedFile.FileName
                Dim fileLength As Integer = fileup.PostedFile.ContentLength

                imageBytes = New Byte(fileLength - 1) {}
                fileup.PostedFile.InputStream.Read(imageBytes, 0, fileLength)
            Else
                imageBytes = New Byte(0) {}
            End If
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            Dim MAX As SqlDbType
            cmd.CommandType = CommandType.StoredProcedure
            If (chkimage.Checked = True And imageBytes.Length = 0) Or chkimage.Checked = False Then
                cmd.CommandText = "SP_CF_CMS_SupportimgNochange"
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_Id", SqlDbType.VarChar, 10)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_Subject ", SqlDbType.VarChar, 50)).Value = txtimg.Text
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_ChkImage", SqlDbType.VarChar, 10)).Value = chkimage.Checked
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_Description ", SqlDbType.VarChar, MAX)).Value = HtmlEditor.Content
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_UserId ", SqlDbType.VarChar, 10)).Value = "1"
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_ChkActive", SqlDbType.VarChar, 10)).Value = chkActive.Checked
            Else
                cmd.CommandText = "SP_CF_CMS_Support"
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_Id", SqlDbType.VarChar, 10)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_Subject ", SqlDbType.VarChar, 50)).Value = txtimg.Text
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_ChkImage", SqlDbType.VarChar, 10)).Value = chkimage.Checked
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_Image", SqlDbType.Image)).Value = imageBytes
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_Description ", SqlDbType.VarChar, MAX)).Value = HtmlEditor.Content
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_UserId ", SqlDbType.VarChar, 10)).Value = "1"
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
                cmd.Parameters.Add(New SqlParameter("@CMS_Support_ChkActive", SqlDbType.VarChar, 10)).Value = chkActive.Checked

            End If


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
            'MsgBox(ex.Message)
            obj.strMode = "Add"

            obj = Nothing
        Finally

            Response.Redirect("support.aspx")

        End Try

    End Sub

    Protected Sub chkimage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkimage.CheckedChanged
        If chkimage.Checked = True Then
            fileup.Visible = True
            ' fileimg.Visible = True
            fileimgdb.Visible = True
        Else
            fileup.Visible = False
            'fileimg.Visible = False
            fileimgdb.Visible = False
        End If
    End Sub
   
End Class
