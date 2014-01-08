Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Account_editmemberaccount
    Inherits System.Web.UI.Page
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Dim User_Id As String = ""
    Dim obj As New ClassFunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        If Not IsPostBack Then

            If Not Request.QueryString("Uid") = Nothing Then
                User_Id = Request.QueryString("Uid").ToString()
                dt = obj.returndatatable("select * from aspnet_users  where UserId ='" + User_Id + "'", dt)
                If dt.Rows.Count > 0 Then
                    txtname.Text = dt.Rows(0).Item("UserName").ToString
                    dt1 = obj.returndatatable("select * from cf_user where user_userid='" + dt.Rows(0).Item("Userid").ToString + "'", dt1)
                    If dt1.Rows.Count > 0 Then
                        obj.strMode = "Modify"
                        selectedIndexDetId = dt1.Rows(0).Item("User_UserId").ToString()
                        cmbstatus.SelectedValue = dt1.Rows(0).Item("User_Status").ToString()
                        If dt1.Rows(0).Item("User_AutoWD").ToString = "True" Then
                            chkzautoWE.Checked = True

                        Else
                            chkzautoWE.Checked = False
                        End If
                        'chkzautoWE.Checked = dt1.Rows(0).Item("Member_AutoWD").ToString
                        If dt1.Rows(0).Item("User_ECurTransfer").ToString = "True" Then
                            chkecurrencyacc.Checked = True

                        Else
                            chkecurrencyacc.Checked = False
                        End If
                        'chkecurrencyacc.Checked = dt1.Rows(0).Item("Member_ECurTransfer").ToString
                        If dt1.Rows(0).Item("User_ResetSecurity").ToString = "True" Then
                            chkresetsec.Checked = True

                        Else
                            chkresetsec.Checked = False
                        End If
                        ' chkresetsec.Checked = dt1.Rows(0).Item("Member_ResetSecurity").ToString
                        txtadminnote.Text = dt1.Rows(0).Item("User_AdminNote").ToString
                        txtmaxdailywithdraw.Text = dt1.Rows(0).Item("User_MaxDailyWD").ToString
                    Else
                        obj.strMode = "Add"
                    End If
                End If
            End If
        End If
    End Sub
    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            Call savedata()
        Catch ex As Exception

        End Try
    End Sub
    Public Function Validation() As Boolean
        Return False
    End Function
    Private Sub savedata()
        Try
            If Validation() = True Then
            End If

            If cmdSave.Text = "Save Changes" Then
                obj.strMode = "Modify"
            Else
                obj.strMode = "Modify"
            End If

            Select Case obj.strMode
                Case "Add"
                    '  If MsgBox("Do you want to Save Data", MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then

                    ID = obj.getIndexKey()
                    ' Else
                    ' Exit Sub
                    'End If
                Case "Modify"

                    ' ID = selectedIndexDetId
                    SelectedIndexId = Request.QueryString("Uid").ToString()
                    'lblid.Text = SelectedIndexId

                Case "Delete"
                    ' If MsgBox("Do you want to Delete Data", MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                    'If status = "C" Then
                    'MsgBox("This Order Picked invoice So u can't delete.")
                    ' Exit Sub
                    'End If
                    ' Else
                    ' Exit Sub
                    'End If
            End Select
            ' lblid.Text = ID

            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            ' cmd.CommandType = CommandType.StoredProcedure
            Dim strQuery As String
            strQuery = " update CF_User set User_Status ='" & cmbstatus.SelectedValue & "',User_AutoWD='" & chkzautoWE.Checked & "', User_ECurTransfer='" & chkecurrencyacc.Checked & "',User_MaxDailyWD='" & txtmaxdailywithdraw.Text & "',User_AdminNote='" & txtadminnote.Text & "' , User_ResetSecurity='" & chkresetsec.Checked & "' where User_UserId='" & SelectedIndexId & "' "
            cmd.CommandText = strQuery
            cmd.Connection = con
            cmd.ExecuteNonQuery()
           
            cmd.Parameters.Clear()

            Dim ans As String

            ans = obj.Returnsinglevalue("select email from aspnet_membership where userid='" + SelectedIndexId + "'")
            Dim msg As String = "Your Account Has Been" + cmbstatus.SelectedValue + "d"
            Dim cmail As CEmail1
            cmail = New CEmail1
            cmail.EmailSendmsg(ans, msg)

            Dim continueUrl As String
            continueUrl = "Members.aspx"
            Response.Redirect("Members.aspx", False)
        Catch ex As Exception

            obj.strMode = "Add"
        Finally

        End Try
    End Sub


End Class

