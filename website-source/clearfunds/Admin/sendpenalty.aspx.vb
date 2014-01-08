Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_sendpenalty
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim dt As New DataTable()
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""


    Protected Sub cmbUserSelection_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUserSelection.SelectedIndexChanged
        txtToMembers.Text = ""
        If cmbUserSelection.SelectedIndex > 1 Then
            dt = obj.returnSPdatatable("SP_CF_GetMembers", dt, cmbUserSelection.SelectedIndex)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    If Trim(txtToMembers.Text) = "" Then
                        txtToMembers.Text = dt.Rows(i).Item(0).ToString()
                    Else
                        txtToMembers.Text = txtToMembers.Text & "," & dt.Rows(i).Item(0).ToString()
                    End If
                Next
            End If
            Dim arr() As String
            arr = Split(txtToMembers.Text, ",")
        End If
    End Sub

    Protected Sub cmdSendBonus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSendBonus.Click

        'obj.strMode = "Add"
        'Try
        '    Dim arr() As String
        '    arr = Split(txtToMembers.Text, ",")
        '    For i = 0 To arr.Length - 1
        '        Dim ID As String = ""

        '        Select Case obj.strMode
        '            Case "Add"

        '                ID = obj.getIndexKey()

        '            Case "Modify"

        '                ID = SelectedIndexId

        '            Case "Delete"
        '        End Select

        '        Dim con As New SqlConnection
        '        con = New SqlConnection(obj.ConnectionString)
        '        con.Open()
        '        Dim cmd As New SqlCommand

        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.CommandText = "SP_CF_Penalty"
        '        cmd.Connection = con


        '        cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
        '        cmd.Parameters.Add(New SqlParameter("@Penalty_id", SqlDbType.VarChar, 10)).Value = ID
        '        cmd.Parameters.Add(New SqlParameter("@Penalty_Amount", SqlDbType.Decimal, 18, 2)).Value = txtAmount.Text
        '        cmd.Parameters.Add(New SqlParameter("@Penalty_Ecurrency", SqlDbType.VarChar, 20)).Value = cmbEcurrency.SelectedValue
        '        cmd.Parameters.Add(New SqlParameter("@Penalty_Sentto", SqlDbType.VarChar, 20)).Value = cmbUserSelection.SelectedValue
        '        cmd.Parameters.Add(New SqlParameter("@Penalty_Email", SqlDbType.VarChar, 200)).Value = txtToMembers.Text
        '        cmd.Parameters.Add(New SqlParameter("@Penalty_Desc", SqlDbType.VarChar, 15)).Value = txtDescription.Text
        '        cmd.Parameters.Add(New SqlParameter("@Penalty_Userid", SqlDbType.UniqueIdentifier)).Value = obj.ReturnsingleGuid("select UserId from aspnet_Membership where Email='" + arr(i) + "'")
        '        cmd.Parameters.Add(New SqlParameter("@Penalty_ModifyDate", SqlDbType.DateTime)).Value = Format(obj.GetCurrentDate(), "yyyy/MM/dd")

        '        cmd.ExecuteNonQuery()
        '    Next
        ' cmd.Parameters.Clear()


        obj.strMode = "Add"
        Try
            Dim arr() As String
            arr = Split(txtToMembers.Text, ",")
            For i = 0 To arr.Length - 1
                Dim ID As String = ""

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
                cmd.CommandText = "SP_CF_Penalty"
                cmd.Connection = con
                'Dim arr() As String
                'arr = Split(txtToMembers.Text, ",")
                'For i = 0 To arr.Length - 1
                cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                cmd.Parameters.Add(New SqlParameter("@Penalty_id", SqlDbType.VarChar, 10)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@Penalty_Amount", SqlDbType.Decimal, 18, 2)).Value = Val(txtAmount.Text)
                cmd.Parameters.Add(New SqlParameter("@Penalty_Ecurrency", SqlDbType.VarChar, 20)).Value = cmbEcurrency.SelectedValue
                cmd.Parameters.Add(New SqlParameter("@Penalty_Sentto", SqlDbType.VarChar, 20)).Value = cmbUserSelection.SelectedValue
                cmd.Parameters.Add(New SqlParameter("@Penalty_UserName", SqlDbType.VarChar, 200)).Value = arr(i)
                cmd.Parameters.Add(New SqlParameter("@Penalty_Desc", SqlDbType.VarChar, 15)).Value = txtDescription.Text
                cmd.Parameters.Add(New SqlParameter("@Penalty_Userid", SqlDbType.UniqueIdentifier)).Value = obj.ReturnsingleGuid("select UserId from aspnet_Users where UserName='" + arr(i) + "'")
                cmd.Parameters.Add(New SqlParameter("@Penalty_ModifyDate", SqlDbType.DateTime)).Value = Format(obj.GetCurrentDate(), "yyyy/MM/dd")

                cmd.ExecuteNonQuery()
                lblmesg.Visible = True
                lblmesg.Text = "penality Successfully sent"
                Dim cmail As CEmail1
                cmail = New CEmail1
                Dim answer As Guid = obj.ReturnsingleGuid("select [userId] from aspnet_users where username='" + arr(i) + "'")
                Dim answer1 As String = Convert.ToString(answer)
                Dim stremail As String = obj.Returnsinglevalue("select Email from aspnet_Membership where  userId='" + answer1 + "'")
                cmail.emailSendPenality(stremail, txtAmount.Text)
            Next
            ' cmd.Parameters.Clear()

            Select Case obj.strMode
                Case "Add"
                    '   MsgBox("Data Was Saved.")
                Case "Modify"
                    ' MsgBox("Data Was Modified.")
                Case "Delete"
                    ' MsgBox("Data Was Deleted.")
            End Select
            Call clear()
            'Dim arr() As String
            'arr = Split(txtToMembers.Text, ",")
            'For i = 0 To arr.Length - 1
            '    MsgBox(arr(i))
            'Next

        Catch ex As Exception
            ' MsgBox(ex.Message)
            obj.strMode = "Add"
        End Try
    End Sub
    Protected Sub clear()
        txtAmount.Text = ""
        txtDescription.Text = ""
        txtToMembers.Text = ""
    End Sub
End Class
