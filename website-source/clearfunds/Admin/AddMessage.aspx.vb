Imports System.Data.SqlClient
Imports System.Data

Partial Class Admin_AddNews
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim cmd As New SqlCommand
    Dim dt As New DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("User_Id") = "1"

        If Not IsPostBack = True Then
            If Not Request.QueryString("id") = Nothing Then
                Dim Header As New HtmlGenericControl("h2")
                Header.ID = "NewControl"
                Header.InnerText = "Edit Message"
                Header.Attributes.Add("class", "head_top")
                Label5.Controls.Add(Header)
                'string userid = Session["User_Id"].ToString();

                Dim selectedIndexId As String = Request.QueryString("id").ToString()
                obj.returndatatable("select * from CF_Message where [Message_id]='" & selectedIndexId & "' ", dt)

                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count
                        lblid.Text = dt.Rows(0)("Message_id").ToString()
                        txtsub.Text = dt.Rows(0)("Message_Subject").ToString()
                        mce_editor_0.Text = dt.Rows(0)("Message_SummaryDescription").ToString()

                        RadioButtonList1.SelectedValue = dt.Rows(0)("Message_ChkActive").ToString()

                        Button1.Text = "update"

                        Session("id") = dt.Rows(0)("Message_id").ToString()
                    Next

                End If

            End If

        End If
      
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)


        If Not Request.QueryString("id") = Nothing Then

            If (txtsub.Text.Trim() <> "") Then
                Dim con As New SqlConnection
                con = New SqlConnection(obj.ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_Message"
                cmd.Connection = con
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "MODIFY"
                cmd.Parameters.Add("@Message_id", SqlDbType.VarChar).Value = Request.QueryString("id").ToString()
                cmd.Parameters.Add("@Message_Subject", SqlDbType.VarChar).Value = txtsub.Text
                cmd.Parameters.Add("@Message_SummaryDescription", SqlDbType.NVarChar).Value = mce_editor_0.Text
                cmd.Parameters.Add("@Message_UserId", SqlDbType.VarChar).Value = 1
                cmd.Parameters.Add("@Message_ChkActive", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
                cmd.Parameters.Add("@Message_Modifydate", SqlDbType.DateTime).Value = DateTime.Now.ToString()

                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                con.Close()

                Dim message As String = "content updated succssfully"
                Dim url As String = "MessageList.aspx"
                Dim script As String = "window.onload = function(){ alert('"
                script += message
                script += "');"
                script += "window.location = '"
                script += url
                script += "'; }"
                ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)

            Else
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Message Title Required');", True)
            End If
        Else
            If (txtsub.Text.Trim() <> "") Then
                Dim con As New SqlConnection
                con = New SqlConnection(obj.ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_Message"
                cmd.Connection = con
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "ADD"
                cmd.Parameters.Add("@Message_id", SqlDbType.VarChar).Value = obj.getIndexKey()
                cmd.Parameters.Add("@Message_Subject", SqlDbType.VarChar).Value = txtsub.Text
                cmd.Parameters.Add("@Message_SummaryDescription", SqlDbType.NVarChar).Value = mce_editor_0.Text
                cmd.Parameters.Add("@Message_UserId", SqlDbType.VarChar).Value = 1
                cmd.Parameters.Add("@Message_ChkActive", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
                cmd.Parameters.Add("@Message_Modifydate", SqlDbType.DateTime).Value = DateTime.Now.ToString()
                cmd.Parameters.Add("@Message_Isdeleted", SqlDbType.VarChar).Value = 0
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                con.Close()

                Dim message As String = "content updated succssfully"
                Dim url As String = "MessageList.aspx"
                Dim script As String = "window.onload = function(){ alert('"
                script += message
                script += "');"
                script += "window.location = '"
                script += url
                script += "'; }"
                ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)

            Else
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Message Title Required');", True)
            End If
        End If


    End Sub
End Class
