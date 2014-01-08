Imports System.Data
Imports System.Data.SqlClient

Partial Class Admin_AddVoteus
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("User_Id") = "1"

        If Not (Session("User_Id") Is Nothing) Then
            If Not IsPostBack = True Then


                If Request.QueryString("id") IsNot Nothing Then
                    Dim Header As New HtmlGenericControl("h2")
                    Header.ID = "NewControl"
                    Header.InnerText = "Edit VoteUs"
                    Header.Attributes.Add("class", "head_top")
                    Label5.Controls.Add(Header)
                    'string userid = Session["User_Id"].ToString();

                    Dim selectedIndexId As String = Request.QueryString("id")
                    obj.returndatatable("select * from CF_VoteUs where [VoteUs_id]='" & selectedIndexId & "' ", dt)

                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count
                            lblid.Text = dt.Rows(0)("VoteUs_id").ToString()
                            txtsub.Text = dt.Rows(0)("VoteUs_title").ToString()
                            HtmlEditor.Content = dt.Rows(0)("VoteUs_url").ToString()
                            RadioButtonList1.SelectedValue = dt.Rows(0)("VoteUs_ChkActive").ToString()
                            Image1.ImageUrl = "~/Admin/VoteUsImage.aspx?id=" + dt.Rows(0)("VoteUs_id").ToString()
                            Button1.Text = "update"

                            Session("id") = dt.Rows(0)("VoteUs_id").ToString()
                        Next

                    End If

                End If

            End If
        Else
            Response.Redirect("~/Administrator/Default.aspx")
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)


        Dim SelectedIndexId As String = ""
        Dim filename As String = FileUpload1.PostedFile.FileName
        Dim filelength As Integer = FileUpload1.PostedFile.ContentLength
        Dim imgbyte As Byte() = New Byte(filelength - 1) {}
        FileUpload1.PostedFile.InputStream.Read(imgbyte, 0, filelength)
        Try
            Dim con As New SqlConnection()

            Dim ID As String = ""
            If Request.QueryString("id") = Nothing Then
                obj.strMode = "Add"
            Else
                obj.strMode = "Modify"
            End If

            Select Case obj.strMode
                Case "Add"
                    ID = obj.getIndexKey()

                Case "Modify"
                    SelectedIndexId = Request.QueryString("id").ToString()
                    ID = SelectedIndexId

                Case "Delete"

            End Select







            If Not FileUpload1.PostedFile.ContentLength = Nothing Then




                con = New SqlConnection(obj.ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_VoteUs"
                cmd.Connection = con

                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                cmd.Parameters.Add(New SqlParameter("@VoteUs_id ", SqlDbType.VarChar, 10)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@VoteUs_title", SqlDbType.VarChar, 100)).Value = txtsub.Text

                cmd.Parameters.Add(New SqlParameter("@VoteUs_url", SqlDbType.VarChar, 1000)).Value = HtmlEditor.Content
                cmd.Parameters.Add(New SqlParameter("@VoteUs_Image", SqlDbType.Image)).Value = imgbyte

                cmd.Parameters.Add(New SqlParameter("@VoteUs_UserId ", SqlDbType.VarChar, 10)).Value = 1
                cmd.Parameters.Add(New SqlParameter("@VoteUs_ChkActive", SqlDbType.VarChar, 10)).Value = RadioButtonList1.SelectedValue
                cmd.Parameters.Add(New SqlParameter("@VoteUs_Isdeleted", SqlDbType.VarChar, 100)).Value = 0
                cmd.Parameters.Add(New SqlParameter("@VoteUs_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                Dim message As String = "content Added succssfully"
                Dim url As String = "VoteImageList.aspx"
                Dim script As String = "window.onload = function(){ alert('"
                script += message
                script += "');"
                script += "window.location = '"
                script += url
                script += "'; }"
                ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
            Else
                con = New SqlConnection(obj.ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_VoteUsNoimages"
                cmd.Connection = con

                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                cmd.Parameters.Add(New SqlParameter("@VoteUs_id ", SqlDbType.VarChar, 10)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@VoteUs_title", SqlDbType.VarChar, 100)).Value = txtsub.Text

                cmd.Parameters.Add(New SqlParameter("@VoteUs_url", SqlDbType.VarChar, 1000)).Value = HtmlEditor.Content

                cmd.Parameters.Add(New SqlParameter("@VoteUs_UserId ", SqlDbType.VarChar, 10)).Value = 1
                cmd.Parameters.Add(New SqlParameter("@VoteUs_ChkActive", SqlDbType.VarChar, 10)).Value = RadioButtonList1.SelectedValue
                cmd.Parameters.Add(New SqlParameter("@VoteUs_Isdeleted", SqlDbType.VarChar, 100)).Value = 0
                cmd.Parameters.Add(New SqlParameter("@VoteUs_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                Dim message As String = "content Added succssfully"
                Dim url As String = "VoteImageList.aspx"
                Dim script As String = "window.onload = function(){ alert('"
                script += message
                script += "');"
                script += "window.location = '"
                script += url
                script += "'; }"
                ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
            End If

            Select Case obj.strMode
                Case "Add"
                    '   MsgBox("Data Was Saved.")
                Case "Modify"
                    '  MsgBox("Data Was Modified.")
                Case "Delete"
                    ' MsgBox("Data Was Deleted.")
            End Select

            '  Call clear()





        Catch ex As Exception
            '  MsgBox(ex.Message)
            obj.strMode = "Add"
        Finally
            'Response.Redirect("Categories.aspx")
        End Try




    End Sub
End Class
