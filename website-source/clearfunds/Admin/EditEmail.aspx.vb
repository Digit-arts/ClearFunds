Imports System.Data.SqlClient
Imports System.Data
Partial Class Admin_EditEmail
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        If Not Request.QueryString("Eid") = Nothing Then
            obj.strMode = "Modify"
            SelectedIndexId = Request.QueryString("Eid").ToString()
            If IsPostBack = False Then
                btnSvedata.Text = "Update"

                dt = obj.returndatatable("select * from CF_Email_Templates where Email_Templates_Id='" + SelectedIndexId + "'", dt)
                If dt.Rows.Count > 0 Then
                    txttitle.Text = dt.Rows(0).Item("Email_Templates_Title").ToString()
                    txtsubject.Text = dt.Rows(0).Item("Email_Templates_Subject").ToString()
                    HtmlEditor.Content = dt.Rows(0).Item("Email_Templates_Message").ToString()
                    txtnotes.Text = dt.Rows(0).Item("Email_Templates_Note").ToString()
                End If
            End If
        Else
            obj.strMode = "Add"
            btnSvedata.Text = "Save"
        End If
    End Sub
    Protected Sub savedata(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSvedata.Click
        Try
            'obj.strMode = "Add"
            Dim dt As New DataTable()
            Dim dt2 As New DataTable()
            'Dim i As Integer
            Dim ID As String = ""
            Dim dt1 As New DataTable

            If obj.strMode = "" Then

                Exit Sub
            End If

          

            Select Case obj.strMode
                Case "Add"
                    ID = obj.getIndexKey()
                   
                Case "Modify"
                    ID = SelectedIndexId
                    
                Case "Delete"
                  
            End Select

            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_Email_Templates"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@Email_Templates_Id", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@Email_Templates_Title", SqlDbType.VarChar, 50)).Value = txttitle.Text
            cmd.Parameters.Add(New SqlParameter("@Email_Templates_Subject", SqlDbType.VarChar, 75)).Value = txtsubject.Text
            cmd.Parameters.Add(New SqlParameter("@Email_Templates_Message", SqlDbType.VarChar, 5000)).Value = HtmlEditor.Content
            cmd.Parameters.Add(New SqlParameter("@Email_Templates_Note", SqlDbType.VarChar, 2000)).Value = txtnotes.Text
            cmd.Parameters.Add(New SqlParameter("@Email_Templates_ModifyDate ", SqlDbType.DateTime, 8)).Value = Format(obj.GetCurrentDate(), "yyyy/MM/dd")
            cmd.Parameters.Add(New SqlParameter("@Email_Templates_UserId ", SqlDbType.VarChar, 10)).Value = "1"
            cmd.ExecuteNonQuery()

            cmd.Parameters.Clear()

            Select Case obj.strMode
                Case "Add"
                    'MsgBox("Data Was Saved.")
                Case "Modify"
                    'MsgBox("Data Was Modified.")
                Case "Delete"
                    ' MsgBox("Data Was Deleted.")
            End Select

            'Response.Redirect("Emailtemplate.aspx")

            obj = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            obj.strMode = "Add"

            obj = Nothing
        Finally
            Dim continueUrl As String
            continueUrl = "Emailtemplate.aspx"
            Response.Redirect(continueUrl)
        End Try
    End Sub
End Class
