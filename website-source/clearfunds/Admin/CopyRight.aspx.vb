Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Security

Partial Class Admin_CopyRight
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Dim con As New SqlConnection

    Dim cmd As New SqlCommand()
    Dim adminid As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            obj.returndatatable("select * from CF_CopyRight", dt)
            If dt.Rows.Count > 0 Then
                Button1.Text = "Update"
                ViewState("id") = dt.Rows(0)("CopyRight_Id").ToString()
                txtCopy.Text = dt.Rows(0)("CopyRight_Title").ToString()
                txturl.Text = dt.Rows(0)("CopyRight_url").ToString()
                RadioButtonList1.SelectedValue = dt.Rows(0)("CopyRight_ChkActive").ToString()
                DropDownList1.SelectedValue = dt.Rows(0)("CopyRight_Position").ToString()

            End If

        End If
    End Sub
    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        If (txtCopy.Text.Trim() <> "") Then

            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_CopyRight"
            cmd.Connection = con

            If ViewState("id") <> "" Then
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "Modify"
            Else
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "Add"
            End If

            cmd.Parameters.Add("@CopyRight_Title", SqlDbType.VarChar).Value = txtCopy.Text
            cmd.Parameters.Add("@CopyRight_Position", SqlDbType.VarChar).Value = DropDownList1.SelectedValue
            cmd.Parameters.Add("@CopyRight_ChkActive", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
            cmd.Parameters.Add("@CopyRight_url", SqlDbType.VarChar).Value = txturl.Text
            cmd.Parameters.Add("@CopyRight_ModifyDate", SqlDbType.DateTime).Value = DateTime.Now.ToString()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            con.Close()
            Dim message As String = "Copy Right Added succssfully"
            Dim url As String = "CopyRight.aspx"
            Dim script As String = "window.onload = function(){ alert('"
            script += message
            script += "');"
            script += "window.location = '"
            script += url
            script += "'; }"
            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('CopyRight title Required');", True)
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("Packages.aspx")
    End Sub
End Class
