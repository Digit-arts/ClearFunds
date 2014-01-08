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
                Header.InnerText = "Edit News"
                Header.Attributes.Add("class", "head_top")
                Label5.Controls.Add(Header)
                'string userid = Session["User_Id"].ToString();

                Dim selectedIndexId As String = Request.QueryString("id").ToString()
                obj.returndatatable("select * from CF_CompanyNews where [Company_id]='" & selectedIndexId & "' ", dt)

                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count
                        lblid.Text = dt.Rows(0)("Company_id").ToString()
                        txtsub.Text = dt.Rows(0)("Company_Subject").ToString()
                        mce_editor_0.Text = dt.Rows(0)("Company_EN_SummaryDescription").ToString()
                        mce_editor_1.Text = dt.Rows(0)("Company_EN_DetailedDescription").ToString()
                        RadioButtonList1.SelectedValue = dt.Rows(0)("Company_ChkActive").ToString()
                        Image1.ImageUrl = "~/Admin/CompanyNewsImage.aspx?id=" + dt.Rows(0)("Company_id").ToString()
                        Button1.Text = "update"

                        Session("id") = dt.Rows(0)("Company_id").ToString()
                    Next

                End If

            End If

        End If
      
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)



        Dim filename As String = FileUpload1.PostedFile.FileName
        Dim filelength As Integer = FileUpload1.PostedFile.ContentLength
        Dim imgbyte As Byte() = New Byte(filelength - 1) {}
        FileUpload1.PostedFile.InputStream.Read(imgbyte, 0, filelength)



        If Request.QueryString("id") Is Nothing Then
            If Not FileUpload1.PostedFile.ContentLength = Nothing Then
                If (txtsub.Text.Trim() <> "") Then
                    Dim con As New SqlConnection
                    con = New SqlConnection(obj.ConnectionString)
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "SP_CF_Company"
                    cmd.Connection = con

                    cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "add"
                    cmd.Parameters.Add("@Company_id", SqlDbType.VarChar).Value = obj.getIndexKey()
                    cmd.Parameters.Add("@Company_Subject", SqlDbType.VarChar).Value = txtsub.Text
                    cmd.Parameters.Add("@Company_EN_SummaryDescription", SqlDbType.VarChar).Value = mce_editor_0.Text
                    cmd.Parameters.Add("@Company_EN_DetailedDescription", SqlDbType.VarChar).Value = mce_editor_1.Text
                    cmd.Parameters.Add("@Company_UserId", SqlDbType.VarChar).Value = 1
                    cmd.Parameters.Add("@Company_ChkActive", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
                    cmd.Parameters.Add("@Company_Isdeleted", SqlDbType.VarChar).Value = 0
                    cmd.Parameters.AddWithValue("@Company_Image", imgbyte)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    con.Close()
                    Dim message As String = "content Added succssfully"
                    Dim url As String = "NewsList.aspx"
                    Dim script As String = "window.onload = function(){ alert('"
                    script += message
                    script += "');"
                    script += "window.location = '"
                    script += url
                    script += "'; }"
                    ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Company News Required');", True)
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Please select atleast one image');", True)
            End If

        ElseIf FileUpload1.PostedFile.ContentLength > 0 Then
            If (txtsub.Text.Trim() <> "") Then
                Dim con As New SqlConnection
                con = New SqlConnection(obj.ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_Company"
                cmd.Connection = con
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "MODIFY"
                cmd.Parameters.Add("@Company_id", SqlDbType.VarChar).Value = Request.QueryString("id").ToString()
                cmd.Parameters.Add("@Company_Subject", SqlDbType.VarChar).Value = txtsub.Text

                'cmd.Parameters.Add("@Company_Description1", SqlDbType.VarChar).Value = Editordesc1.Content;
                cmd.Parameters.Add("@Company_EN_SummaryDescription", SqlDbType.NVarChar).Value = mce_editor_0.Text


                cmd.Parameters.Add("@Company_EN_DetailedDescription", SqlDbType.NVarChar).Value = mce_editor_1.Text

                cmd.Parameters.Add("@Company_UserId", SqlDbType.VarChar).Value = 1
                cmd.Parameters.Add("@Company_ChkActive", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
                cmd.Parameters.AddWithValue("@Company_Image", imgbyte)
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                con.Close()

                Dim message As String = "content updated succssfully"
                Dim url As String = "NewsList.aspx"
                Dim script As String = "window.onload = function(){ alert('"
                script += message
                script += "');"
                script += "window.location = '"
                script += url
                script += "'; }"
                ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Company News Required');", True)
            End If
        Else
            If (txtsub.Text.Trim() <> "") Then
                Dim con As New SqlConnection
                con = New SqlConnection(obj.ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_Company_Noimages"
                cmd.Connection = con
                cmd.Parameters.Add("@mode", SqlDbType.VarChar).Value = "MODIFY"
                cmd.Parameters.Add("@Company_id", SqlDbType.VarChar).Value = Request.QueryString("id").ToString()
                cmd.Parameters.Add("@Company_Subject", SqlDbType.VarChar).Value = txtsub.Text


                cmd.Parameters.Add("@Company_EN_SummaryDescription", SqlDbType.NVarChar).Value = mce_editor_0.Text

                cmd.Parameters.Add("@Company_EN_DetailedDescription", SqlDbType.NVarChar).Value = mce_editor_1.Text

                cmd.Parameters.Add("@Company_UserId", SqlDbType.VarChar).Value = 1
                cmd.Parameters.Add("@Company_ChkActive", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                con.Close()

                Dim message As String = "content updated succssfully"
                Dim url As String = "NewsList.aspx"
                Dim script As String = "window.onload = function(){ alert('"
                script += message
                script += "');"
                script += "window.location = '"
                script += url
                script += "'; }"
                ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)

            Else
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Company News Required');", True)
            End If

        End If
      
    End Sub
End Class
