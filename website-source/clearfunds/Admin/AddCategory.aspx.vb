Imports System.Data.SqlClient
Imports System.Data

Partial Class Admin_Add_Groups
    Inherits System.Web.UI.Page
    Dim cmd As New SqlCommand()
    Dim con As New SqlConnection()
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Dim dt1 As New DataTable()
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id As String = ""
            If Not Request.QueryString("id") = Nothing Then
                id = Request.QueryString("id").ToString()
                obj.returndatatable("select Category_Name from Ticket_Category where Category_Id='" + id + "' ", dt1)
                If dt1.Rows.Count > 0 Then
                    txt_grname.Text = dt1.Rows(0).Item("Category_Name").ToString()
                End If
            End If
        End If
    End Sub
    Protected Sub btn_Create_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            con = New SqlConnection(obj.ConnectionString())
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
            If Not (txt_grname.Text.Trim().Length = 0) Then

                obj.returndatatable("select Category_Name from Ticket_Category where Category_Name='" + txt_grname.Text & "' ", dt)

                If dt.Rows.Count > 0 Then

                    Response.Write("<script>alert('Group Name Already Exists Please Try Some Other Name')</script>")
                Else
                    Dim con As New SqlConnection
                    con = New SqlConnection(obj.ConnectionString)
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "SP_Category"
                    cmd.Connection = con

                    cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                    cmd.Parameters.Add(New SqlParameter("@Category_Id", SqlDbType.VarChar, 10)).Value = ID
                    cmd.Parameters.Add(New SqlParameter("@Category_Name", SqlDbType.VarChar, 100)).Value = txt_grname.Text
                  
                    cmd.Parameters.Add(New SqlParameter("@Category_Isdeleted", SqlDbType.VarChar, 10)).Value = 0
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

                End If
            Else

                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('groupname can't be empty');", True)
            End If

        Catch ex As Exception
            '  MsgBox(ex.Message)
            obj.strMode = "Add"
        Finally
            Response.Redirect("Categories.aspx")
        End Try



      


    End Sub
End Class