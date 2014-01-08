Imports System.Data
Imports System.Net.Mail
Imports System.Configuration
Imports System.Data.SqlClient
Partial Class Admin_Custompage
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

    Protected Sub Save(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            Dim ID As String = ""
            If lblid.Text = "" Then
                obj.strMode = "Add"
            Else
                obj.strMode = "Modify"
            End If

            Select Case obj.strMode
                Case "Add"
                    ID = obj.getIndexKey()
                Case "Modify"
                    ID = lblid.Text
                Case "Delete"

            End Select

            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            Dim MAX As SqlDbType
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_CustomPage"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@CustomPage_CustomId", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@Custopmpage_Name", SqlDbType.VarChar, 250)).Value = txtpagename.Text
            cmd.Parameters.Add(New SqlParameter("@Custompage_Edittext ", SqlDbType.VarChar, MAX)).Value = Editor1.Content
            cmd.Parameters.Add(New SqlParameter("@Custompage_UserId", SqlDbType.VarChar, 10)).Value = "1"
            cmd.Parameters.Add(New SqlParameter("@Custompage_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.Parameters.Add(New SqlParameter("@Custompage_ChkActive", SqlDbType.VarChar, 10)).Value = chkActive.Checked


            cmd.ExecuteNonQuery()

            Select Case obj.strMode
                Case "Add"
                Case "Modify"
                Case "Delete"
            End Select

        Catch ex As Exception

        End Try

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()

        If lblid.Text = "" Then
            obj.strMode = "Modify"
            dt = obj.returndatatable("select  * from CF_CustomPage", dt)
            If dt.Rows.Count > 0 Then
                lblid.Text = dt.Rows(0).Item("CustomPage_CustomId").ToString()
                txtpagename.Text = dt.Rows(0).Item("Custopmpage_Name").ToString()
                Editor1.Content = dt.Rows(0).Item("Custompage_Edittext").ToString
                If dt.Rows(0).Item("Custompage_ChkActive").ToString() = "True" Then
                    chkActive.Checked = True
                Else
                    chkActive.Checked = False
                End If
            End If
        End If
    End Sub
End Class
