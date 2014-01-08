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
Partial Class Admin_AddEditAdvertisement
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
                dt = obj.returndatatable("select * from cf_Extras_advertisement where Extras_advertisement_Id='" + SelectedIndexId + "'", dt)
                If dt.Rows.Count > 0 Then

                    txtimg.Text = dt.Rows(0).Item("Extras_advertisement_subject").ToString()
                    If dt.Rows(0).Item("Extras_Advertisement_ChkActive").ToString() = "True" Then
                        chkActive.Checked = True
                    Else
                        chkActive.Checked = False
                    End If
                 
                    Imgdb.ImageUrl = "~/Handlers/AdvertisementImageHandler.ashx?id=" & dt.Rows(0).Item("Extras_advertisement_id").ToString()
                    HtmlEditor.Content = dt.Rows(0).Item("Extras_Advertisement_Description").ToString()
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
                    ' MsgBox("This Order Picked invoice So u can't delete.")

            End Select
     
            Dim fileName As String = fileup.PostedFile.FileName
            Dim fileLength As Integer = fileup.PostedFile.ContentLength

            Dim imageBytes As Byte() = New Byte(fileLength - 1) {}
            fileup.PostedFile.InputStream.Read(imageBytes, 0, fileLength)


            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            Dim MAX As SqlDbType
            cmd.CommandType = CommandType.StoredProcedure
            If fileName = "" Then
                cmd.CommandText = "SP_CF_Extras_AdvertisementimgNochange"
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_Id", SqlDbType.VarChar, 10)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_Subject", SqlDbType.VarChar, 50)).Value = txtimg.Text
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_Description", SqlDbType.VarChar, MAX)).Value = HtmlEditor.Content
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_UserId ", SqlDbType.VarChar, 10)).Value = "1"
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_ChkActive", SqlDbType.VarChar, 10)).Value = chkActive.Checked
            Else
                cmd.CommandText = "SP_CF_Extras_Advertisement"
                cmd.Connection = con
                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_Id", SqlDbType.VarChar, 10)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_Subject ", SqlDbType.VarChar, 50)).Value = txtimg.Text
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_Image", SqlDbType.Image)).Value = imageBytes
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_Description ", SqlDbType.VarChar, MAX)).Value = HtmlEditor.Content
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_UserId ", SqlDbType.VarChar, 10)).Value = "1"
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
                cmd.Parameters.Add(New SqlParameter("@Extras_Advertisement_ChkActive", SqlDbType.VarChar, 10)).Value = chkActive.Checked

            End If


            cmd.ExecuteNonQuery()

            cmd.Parameters.Clear()


            Select Case obj.strMode
                Case "Add"
                Case "Modify"

                Case "Delete"

            End Select

        Catch ex As Exception

            obj.strMode = "Add"

            obj = Nothing
        Finally

            Response.Redirect("Advertisement.aspx")

        End Try

    End Sub

 
End Class
