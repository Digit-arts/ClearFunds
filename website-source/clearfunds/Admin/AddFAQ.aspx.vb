Imports System.Data
Imports System.Data.SqlClient

Partial Class Admin_FAQ
    Inherits System.Web.UI.Page


    Dim cmd As New SqlCommand()

    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Dim dt1 As New DataTable()
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim dt As New DataTable()
        DropDownList1.DataSource = obj.returndatatable("select Category_Name,Category_Id from Ticket_Category", dt)
        DropDownList1.DataTextField = "Category_Name"
        DropDownList1.DataValueField = "Category_Id"
        DropDownList1.DataBind()
        If Not IsPostBack Then
            Dim id As String = ""
            If Not Request.QueryString("id") = Nothing Then
                Dim Header As New HtmlGenericControl("h2")
                Header.ID = "NewControl"
                Header.InnerText = "Edit FAQ"
                Header.Attributes.Add("class", "head_top")
                Label5.Controls.Add(Header)
                id = Request.QueryString("id").ToString()
                obj.returndatatable("select * from CF_FAQ where FAQ_id='" + id + "' ", dt1)
                If dt1.Rows.Count > 0 Then
                    txtsub.Text = dt1.Rows(0).Item("FAQ_Question").ToString()
                    mce_editor_0.Text = dt1.Rows(0).Item("FAQ_Answer").ToString()
                    RadioButtonList1.SelectedValue = dt1.Rows(0).Item("FAQ_ChkActive").ToString()
                    DropDownList1.SelectedValue = dt1.Rows(0).Item("FAQ_group").ToString()
                End If
            End If
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
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





            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_FAQ"
            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@FAQ_id", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@FAQ_group", SqlDbType.VarChar, 100)).Value = DropDownList1.SelectedItem.Text

            cmd.Parameters.Add(New SqlParameter("@FAQ_Question", SqlDbType.VarChar, 1000)).Value = txtsub.Text
            cmd.Parameters.Add(New SqlParameter("@FAQ_Answer", SqlDbType.VarChar, 1000)).Value = mce_editor_0.Text

            cmd.Parameters.Add(New SqlParameter("@FAQ_UserId", SqlDbType.VarChar, 10)).Value = 1
            cmd.Parameters.Add(New SqlParameter("@FAQ_ChkActive", SqlDbType.VarChar, 10)).Value = RadioButtonList1.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@FAQ_Isdeleted", SqlDbType.VarChar, 100)).Value = 0
            cmd.Parameters.Add(New SqlParameter("@FAQ_ModifyDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            Dim message As String = "content Added succssfully"
            Dim url As String = "FAQList.aspx"
            Dim script As String = "window.onload = function(){ alert('"
            script += message
            script += "');"
            script += "window.location = '"
            script += url
            script += "'; }"
            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
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
