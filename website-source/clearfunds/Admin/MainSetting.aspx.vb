Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_MainSetting
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""


    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
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
                    ' If MsgBox("Do you want to Delete Data", MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                    'If status = "C" Then
                    ' MsgBox("This Order Picked invoice So u can't delete.")
                    'Exit Sub
                    'End If
                    ' Else
                    'Exit Sub
                    '  End If
            End Select

            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_CF_Settings"
            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@Settings_Id", SqlDbType.VarChar, 10)).Value = ID
            cmd.Parameters.Add(New SqlParameter("@Settings_SiteName", SqlDbType.VarChar, 50)).Value = txtsitename.Text
            cmd.Parameters.Add(New SqlParameter("@Settings_URL", SqlDbType.VarChar, 75)).Value = txtsiteurl.Text
            cmd.Parameters.Add(New SqlParameter("@Settings_StartDate ", SqlDbType.DateTime)).Value = txtsiteday.Text
            cmd.Parameters.Add(New SqlParameter("@Settings_AllowDeposit ", SqlDbType.VarChar, 10)).Value = dtballowdeptoacc.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@Settings_WDFee ", SqlDbType.Decimal, 18, 2)).Value = Val(txtwdfee.Text)
            cmd.Parameters.Add(New SqlParameter("@Settings_MinWDFee", SqlDbType.Decimal, 18, 2)).Value = Val(txtminwdfee.Text)
            cmd.Parameters.Add(New SqlParameter("@Settings_MinWDAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtminwdamt.Text)
            cmd.Parameters.Add(New SqlParameter("@Settings_MaxDailyWD", SqlDbType.Decimal, 18, 2)).Value = Val(txtmaxdwd.Text)
            cmd.Parameters.Add(New SqlParameter("@Settings_LimitWDPeriod ", SqlDbType.Decimal, 18, 0)).Value = Val(txtlimwdperiod.Text)
            cmd.Parameters.Add(New SqlParameter("@Settings_LimitPeriod ", SqlDbType.VarChar, 20)).Value = dtplimper.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@Settings_MinPwdLength", SqlDbType.Decimal, 18, 0)).Value = Val(txtminupwdlen.Text)

            cmd.Parameters.Add(New SqlParameter("@Settings_MaxPayInfo", SqlDbType.VarChar, 50)).Value = txtpacc.Text
            cmd.Parameters.Add(New SqlParameter("@Settings_MaxAccInfo", SqlDbType.VarChar, 50)).Value = txtmacc.Text
            cmd.Parameters.Add(New SqlParameter("@Settings_TicketDefaulttime", SqlDbType.VarChar, 10)).Value = txttime.Text
            cmd.Parameters.Add(New SqlParameter("@Settings_ModifyDate ", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.Parameters.Add(New SqlParameter("@Settings_UserId", SqlDbType.VarChar, 10)).Value = "1"
            cmd.Parameters.Add(New SqlParameter("@Settings_DepTransno", SqlDbType.VarChar, 100)).Value = txtdepno.Text
            cmd.Parameters.Add(New SqlParameter("@Settings_WithdrawTrnsno", SqlDbType.VarChar, 100)).Value = txttransno.Text
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('saved Successfully');", True)
            Select Case obj.strMode
                Case "Add"
                    '   MsgBox("Data Was Saved.")
                Case "Modify"
                    '  MsgBox("Data Was Modified.")
                Case "Delete"
                    ' MsgBox("Data Was Deleted.")
            End Select
        Catch ex As Exception
            ' MsgBox(ex.Message)
            obj.strMode = "Add"
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        If lblid.Text = "" Then
            obj.strMode = "Modify"


            dt = obj.returndatatable("select Settings_Id,Settings_SiteName,Settings_URL, CONVERT(VARCHAR(11), Settings_StartDate, 106) as Settings_StartDate ,Settings_AllowDeposit ,Settings_WDFee ,Settings_MinWDFee, Settings_MinWDAmount,Settings_MaxDailyWD,Settings_LimitWDPeriod, Settings_LimitPeriod,Settings_MinPwdLength, Settings_MaxPayInfo, Settings_WithdrawTrnsno , Settings_MaxAccInfo,Settings_DepTransno ,Settings_TicketDefaulttime  from CF_Settings", dt)
            If dt.Rows.Count > 0 Then
                lblid.Text = dt.Rows(0).Item("Settings_Id").ToString()
                txtsitename.Text = dt.Rows(0).Item("Settings_SiteName").ToString()
                txtsiteurl.Text = dt.Rows(0).Item("Settings_URL").ToString()
                txtsiteday.Text = dt.Rows(0).Item("Settings_StartDate").ToString()
                dtballowdeptoacc.SelectedValue = dt.Rows(0).Item("Settings_AllowDeposit").ToString()
                txtwdfee.Text = dt.Rows(0).Item("Settings_WDFee").ToString()
                txtminwdfee.Text = dt.Rows(0).Item("Settings_MinWDFee").ToString()
                txtminwdamt.Text = dt.Rows(0).Item("Settings_MinWDAmount").ToString()
                txtmaxdwd.Text = dt.Rows(0).Item("Settings_MaxDailyWD").ToString()
                txtlimwdperiod.Text = dt.Rows(0).Item("Settings_LimitWDPeriod").ToString()
                dtplimper.SelectedValue = dt.Rows(0).Item("Settings_LimitPeriod").ToString()
                txtminupwdlen.Text = dt.Rows(0).Item("Settings_MinPwdLength").ToString()
                txtpacc.Text = dt.Rows(0).Item("Settings_MaxPayInfo").ToString()
                txtmacc.Text = dt.Rows(0).Item("Settings_MaxAccInfo").ToString()
                txttransno.Text = dt.Rows(0).Item("Settings_DepTransno").ToString()
                txtdepno.Text = dt.Rows(0).Item("Settings_WithdrawTrnsno").ToString()
                txttime.Text = dt.Rows(0).Item("Settings_TicketDefaulttime").ToString()
            End If
            dt1 = obj.returndatatable("  select Admin_UserName,Admin_MailId from CF_Admin", dt1)
            If dt1.Rows.Count > 0 Then
                txtlogin.Text = dt1.Rows(0).Item("Admin_UserName").ToString()
                txtemail.Text = dt1.Rows(0).Item("Admin_MailId").ToString()



            End If
        End If
    End Sub

    Protected Sub txtsiteday_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsiteday.TextChanged

    End Sub
End Class
