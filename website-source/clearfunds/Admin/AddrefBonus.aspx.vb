Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_AddrefBonus
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions

    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        If Not IsPostBack Then
            If Not Request.QueryString("Pid") = Nothing Then
                obj.strMode = "Modify"
                btnsubmit.Text = "Submit"
                SelectedIndexId = Request.QueryString("Pid").ToString()
                dt = obj.returndatatable("select * from CF_AddRefBonus where AddRefBonus_id='" + SelectedIndexId + "'", dt)
                If dt.Rows.Count > 0 Then
                    txtName.Text = dt.Rows(0).Item("AddRefBonus_Name").ToString()
                    txtfrom.Text = dt.Rows(0).Item("AddRefBonus_From").ToString()
                    txtto.Text = dt.Rows(0).Item("AddRefBonus_To").ToString()
                    txtcommision.Text = dt.Rows(0).Item("AddRefBonus_Commision").ToString()
                   
                End If
            Else
                obj.strMode = "Add"
                btnsubmit.Text = " Submit"
            End If
        End If
    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            Dim ID As String = ""
            If btnsubmit.Text = " Submit" Then
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

            End Select

          

            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_AddRefBonus"
            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@AddRefBonus_id", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@AddRefBonus_Name", SqlDbType.VarChar, 10)).Value = txtName.Text
            cmd.Parameters.Add(New SqlParameter("@AddRefBonus_From ", SqlDbType.VarChar, 50)).Value = txtfrom.Text
            cmd.Parameters.Add(New SqlParameter("@AddRefBonus_To ", SqlDbType.VarChar, 250)).Value = txtto.Text
            cmd.Parameters.Add(New SqlParameter("@AddRefBonus_Commision ", SqlDbType.VarChar, 10)).Value = txtcommision.Text
            cmd.Parameters.Add(New SqlParameter("@AddRefBonus_Userid", SqlDbType.VarChar, 10)).Value = "1"
            cmd.Parameters.Add(New SqlParameter("@AddRefBonus_ModifyDate ", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
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
            Response.Redirect("ReferralBonusDetails.aspx")
        End Try
    End Sub
    Private Sub clear()
        txtName.Text = ""
        txtfrom.Text = ""
        txtto.Text = ""
        txtcommision.Text = ""
    End Sub
End Class
