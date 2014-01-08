Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_CustomProcessings
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        If Not IsPostBack Then
            If Not Request.QueryString("Pid") = Nothing Then
                obj.strMode = "Modify"
                btnAdd.Text = "Update Processing"
                SelectedIndexId = Request.QueryString("Pid").ToString()
                dt = obj.returndatatable("select * from CF_customprocessing where CustomProcessing_id='" + SelectedIndexId + "'", dt)
                If dt.Rows.Count > 0 Then
                    chkstatus.Checked = dt.Rows(0).Item("CustomProcessing_Status").ToString()
                    txtname.Text = dt.Rows(0).Item("CustomProcessing_Name").ToString()
                    txtpaymentnotes.Text = dt.Rows(0).Item("CustomProcessing_Paymentnote").ToString()
                    txturl.Text = dt.Rows(0).Item("CustomProcessing_url").ToString()
                  
                    Image4.ImageUrl = "~/Handlers/CustomProcessingHandler.ashx?id=" & dt.Rows(0).Item("CustomProcessing_id").ToString()
                   
                    Dim dt1 As New DataTable()
                    dt1 = obj.returndatatable("select * from CF_CustomProcessingFields where CustomProcessing_pid='" + SelectedIndexId + "'", dt1)
                    If dt1.Rows.Count > 0 Then


                        chkffield1.Checked = dt1.Rows(0).Item("CustomProcessing_chkfields").ToString
                        txtfield1.Text = dt1.Rows(0).Item("CustomProcessing_fields").ToString()

                        chkffield2.Checked = dt1.Rows(1).Item("CustomProcessing_chkfields").ToString
                        txtfield2.Text = dt1.Rows(1).Item("CustomProcessing_fields").ToString
                        chkffield3.Checked = dt1.Rows(2).Item("CustomProcessing_chkfields").ToString()
                        txtfield3.Text = dt1.Rows(2).Item("CustomProcessing_fields").ToString()
                        chkffield4.Checked = dt1.Rows(3).Item("CustomProcessing_chkfields").ToString()
                        txtfield4.Text = dt1.Rows(3).Item("CustomProcessing_fields").ToString()
                        chkffield5.Checked = dt1.Rows(4).Item("CustomProcessing_chkfields").ToString()
                        txtfield5.Text = dt1.Rows(4).Item("CustomProcessing_fields").ToString()
                        chkffield6.Checked = dt1.Rows(5).Item("CustomProcessing_chkfields").ToString()
                        txtfield6.Text = dt1.Rows(5).Item("CustomProcessing_fields").ToString()
                        chkffield7.Checked = dt1.Rows(6).Item("CustomProcessing_chkfields").ToString()
                        txtfield7.Text = dt1.Rows(6).Item("CustomProcessing_fields").ToString()
                        chkffield8.Checked = dt1.Rows(7).Item("CustomProcessing_chkfields").ToString()
                        txtfield8.Text = dt1.Rows(7).Item("CustomProcessing_fields").ToString()
                    End If

                Else
                    Exit Sub
                End If
                If chkffield1.Checked = True Then
                    txtfield1.Enabled = True
                Else
                    txtfield1.Enabled = False
                End If
                If chkffield2.Checked = True Then
                    txtfield2.Enabled = True
                Else
                    txtfield2.Enabled = False
                End If
                If chkffield3.Checked = True Then
                    txtfield3.Enabled = True
                Else
                    txtfield3.Enabled = False
                End If
                If chkffield4.Checked = True Then
                    txtfield4.Enabled = True
                Else
                    txtfield4.Enabled = False
                End If
                If chkffield5.Checked = True Then
                    txtfield5.Enabled = True
                Else
                    txtfield5.Enabled = False
                End If
                If chkffield6.Checked = True Then
                    txtfield6.Enabled = True
                Else
                    txtfield6.Enabled = False
                End If
                If chkffield7.Checked = True Then
                    txtfield7.Enabled = True
                Else
                    txtfield7.Enabled = False
                End If
                If chkffield8.Checked = True Then
                    txtfield8.Enabled = True
                Else
                    txtfield8.Enabled = False
                End If

            Else
                obj.strMode = "Add"
                btnAdd.Text = "Add Processing"
            End If
        End If
    End Sub


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim ID As String = ""
            'obj.strMode = "Add"
           
            If btnAdd.Text = "Add Processing" Then
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
                    '  MsgBox("This Order Picked invoice So u can't delete.")
            End Select

            Dim fileName As String = FileUpload1.PostedFile.FileName
            Dim fileLength As Integer = FileUpload1.PostedFile.ContentLength

            Dim imageBytes As Byte() = New Byte(fileLength - 1) {}
            FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, fileLength)


            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            If imageBytes.Length = 0 Then
                cmd = New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_CustomProcessingimgNochange"
                cmd.Connection = con

                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode

                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_id", SqlDbType.VarChar, 10)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_Status", SqlDbType.VarChar, 10)).Value = chkstatus.Checked
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_Name ", SqlDbType.VarChar, 50)).Value = txtname.Text
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_Paymentnote ", SqlDbType.VarChar, 250)).Value = txtpaymentnotes.Text
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_url ", SqlDbType.VarChar, 50)).Value = txturl.Text
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_Userid", SqlDbType.VarChar, 10)).Value = "1"
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_ModifyDate ", SqlDbType.DateTime)).Value = obj.GetCurrentDate()


                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                'cmd = New SqlCommand()
                'cmd.CommandType = CommandType.StoredProcedure
                'cmd.CommandText = "SP_CF_CustomProcessingwithoutimagefields"
                'cmd.Connection = con
                'cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode

                'cmd.Parameters.Add(New SqlParameter("@CustomProcessing_id", SqlDbType.VarChar, 10)).Value = ID
                'cmd.Parameters.Add(New SqlParameter("@CustomProcessing_field1 ", SqlDbType.VarChar, 50)).Value = txtfield1.Text
                'cmd.Parameters.Add(New SqlParameter("@CustomProcessing_field2 ", SqlDbType.VarChar, 50)).Value = txtfield2.Text
                'cmd.Parameters.Add(New SqlParameter("@CustomProcessing_field3 ", SqlDbType.VarChar, 50)).Value = txtfield3.Text


                'cmd.ExecuteNonQuery()
                'cmd.Parameters.Clear()


            Else
                cmd = New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_CF_CustomProcessing"
                cmd.Connection = con

                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_id", SqlDbType.VarChar, 10)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_Status", SqlDbType.VarChar, 10)).Value = chkstatus.Checked
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_Name ", SqlDbType.VarChar, 50)).Value = txtname.Text
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_Paymentnote ", SqlDbType.VarChar, 250)).Value = txtpaymentnotes.Text
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_Userid", SqlDbType.VarChar, 10)).Value = "1"
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_url", SqlDbType.VarChar, 50)).Value = txturl.Text
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_ModifyDate ", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_image ", SqlDbType.Image)).Value = imageBytes
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
            End If

            cmd = New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Clear()
            cmd.CommandText = "SP_CF_CustomProcessingfields"
            cmd.Connection = con
            Dim dt1 As New DataTable
            dt1 = obj.returndatatable("select CustomProcessing_fid from CF_CustomProcessingFields where CustomProcessing_pid='" + ID + "'", dt1)
            If dt1.Rows.Count > 0 Then
                obj.strMode = "Modify"
            Else
                obj.strMode = "Add"
            End If

            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            If obj.strMode = "Add" Then
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = obj.getIndexKey()
            Else


                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = dt1.Rows(0).Item("CustomProcessing_fid").ToString()
            End If
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_pid", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fields", SqlDbType.VarChar, 50)).Value = txtfield1.Text
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_chkfields ", SqlDbType.VarChar, 10)).Value = chkffield1.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
            If obj.strMode = "Add" Then
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = obj.getIndexKey()
            Else
                selectedIndexDetId = obj.Returnsinglevalue("select CustomProcessing_fid from CF_CustomProcessingFields where CustomProcessing_pid='" + ID + "'")
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = dt1.Rows(1).Item("CustomProcessing_fid").ToString()
            End If
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_pid", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fields", SqlDbType.VarChar, 50)).Value = txtfield2.Text
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_chkfields", SqlDbType.VarChar, 10)).Value = chkffield2.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
            If obj.strMode = "Add" Then
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = obj.getIndexKey()
            Else
                selectedIndexDetId = obj.Returnsinglevalue("select CustomProcessing_fid from CF_CustomProcessingFields where CustomProcessing_pid='" + ID + "'")
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = dt1.Rows(2).Item("CustomProcessing_fid").ToString()
            End If
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_pid", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fields", SqlDbType.VarChar, 50)).Value = txtfield3.Text
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_chkfields", SqlDbType.VarChar, 10)).Value = chkffield3.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
            If obj.strMode = "Add" Then
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = obj.getIndexKey()
            Else
                selectedIndexDetId = obj.Returnsinglevalue("select CustomProcessing_fid from CF_CustomProcessingFields where CustomProcessing_pid='" + ID + "'")
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = dt1.Rows(3).Item("CustomProcessing_fid").ToString()
            End If
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_pid", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fields", SqlDbType.VarChar, 50)).Value = txtfield4.Text
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_chkfields", SqlDbType.VarChar, 10)).Value = chkffield4.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
            If obj.strMode = "Add" Then
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = obj.getIndexKey()
            Else
                selectedIndexDetId = obj.Returnsinglevalue("select CustomProcessing_fid from CF_CustomProcessingfields where CustomProcessing_pid='" + ID + "'")
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = dt1.Rows(4).Item("CustomProcessing_fid").ToString()
            End If
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_pid", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fields", SqlDbType.VarChar, 50)).Value = txtfield5.Text
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_chkfields", SqlDbType.VarChar, 10)).Value = chkffield5.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
            If obj.strMode = "Add" Then
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = obj.getIndexKey()
            Else
                selectedIndexDetId = obj.Returnsinglevalue("select CustomProcessing_fid from CF_CustomProcessingfields where CustomProcessing_pid='" + ID + "'")
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = dt1.Rows(5).Item("CustomProcessing_fid").ToString()
            End If
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_pid", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fields", SqlDbType.VarChar, 50)).Value = txtfield6.Text
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_chkfields", SqlDbType.VarChar, 10)).Value = chkffield6.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
            If obj.strMode = "Add" Then
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = obj.getIndexKey()
            Else
                selectedIndexDetId = obj.Returnsinglevalue("select CustomProcessing_fid from CF_CustomProcessingfields where CustomProcessing_pid='" + ID + "'")
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = dt1.Rows(6).Item("CustomProcessing_fid").ToString()
            End If
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_pid", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fields", SqlDbType.VarChar, 50)).Value = txtfield7.Text
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_chkfields", SqlDbType.VarChar, 10)).Value = chkffield7.Checked

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
            If obj.strMode = "Add" Then
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = obj.getIndexKey()
            Else
                selectedIndexDetId = obj.Returnsinglevalue("select CustomProcessing_fid from CF_CustomProcessingfields where CustomProcessing_pid='" + ID + "'")
                cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fid", SqlDbType.VarChar, 10)).Value = dt1.Rows(7).Item("CustomProcessing_fid").ToString()
            End If
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_pid", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_fields ", SqlDbType.VarChar, 50)).Value = txtfield8.Text
            cmd.Parameters.Add(New SqlParameter("@CustomProcessing_chkfields ", SqlDbType.VarChar, 10)).Value = chkffield8.Checked
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()


            Select Case obj.strMode
                Case "Add"
                    ' MsgBox("Data Was Saved.")
                Case "Modify"
                    '  MsgBox("Data Was Modified.")
                Case "Delete"
                    ' MsgBox("Data Was Deleted.")
            End Select

            ' Call clear()

        Catch ex As Exception
            ' MsgBox(ex.Message)
            obj.strMode = "Add"
        Finally
            Dim message As String = "Saved SuccessFully"
            Dim url As String = "PaymentProcessings.aspx"
            Dim script As String = "window.onload = function(){ alert('"
            script += message
            script += "');"
            script += "window.location = '"
            script += url
            script += "'; }"
            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
            'Response.Redirect("PaymentProcessings.aspx")

        End Try

    End Sub
    Protected Sub chkffield1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkffield1.CheckedChanged
        If chkffield1.Checked = True Then
            txtfield1.Enabled = True
        Else
            txtfield1.Enabled = False
        End If
    End Sub

    Protected Sub chkffield2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkffield2.CheckedChanged
        If chkffield2.Checked = True Then
            txtfield2.Enabled = True
        Else
            txtfield2.Enabled = False
        End If
    End Sub



    Protected Sub chkffield3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkffield3.CheckedChanged
        If chkffield3.Checked = True Then
            txtfield3.Enabled = True
        Else
            txtfield3.Enabled = False
        End If
    End Sub

    Protected Sub chkffield4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkffield4.CheckedChanged
        If chkffield4.Checked = True Then
            txtfield4.Enabled = True
        Else
            txtfield4.Enabled = False
        End If
    End Sub

    Protected Sub chkffield5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkffield5.CheckedChanged
        If chkffield5.Checked = True Then
            txtfield5.Enabled = True
        Else
            txtfield5.Enabled = False
        End If
    End Sub

    Protected Sub chkffield6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkffield6.CheckedChanged
        If chkffield6.Checked = True Then
            txtfield6.Enabled = True
        Else
            txtfield6.Enabled = False
        End If
    End Sub

    Protected Sub chkffield7_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkffield7.CheckedChanged
        If chkffield7.Checked = True Then
            txtfield7.Enabled = True
        Else
            txtfield7.Enabled = False
        End If
    End Sub

    Protected Sub chkffield8_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkffield8.CheckedChanged
        If chkffield8.Checked = True Then
            txtfield8.Enabled = True
        Else
            txtfield8.Enabled = False
        End If
    End Sub
    Protected Sub clear()
        txtname.Text = ""
        txtfield1.Text = ""
        txtfield2.Text = ""
        txtfield3.Text = ""
        txtfield4.Text = ""
        txtfield5.Text = ""
        txtfield6.Text = ""
        txtfield7.Text = ""
        txtfield8.Text = ""
        txtpaymentnotes.Text = ""
        chkffield1.Checked = False
        chkffield2.Checked = False
        chkffield3.Checked = False
        chkffield4.Checked = False
        chkffield5.Checked = False
        chkffield6.Checked = False
        chkffield7.Checked = False
        chkffield8.Checked = False

    End Sub

End Class
