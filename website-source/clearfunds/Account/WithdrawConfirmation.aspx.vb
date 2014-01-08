Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.Sql
Imports System.IO
Imports System.Net.Mail
Imports System.Web.Security
Partial Class Account_WithdrawConfirmation
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim dt As DataTable

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then

            obj.returndatatable("select * from CF_Message where Message_ChkActive<>0 and Message_Isdeleted<>1 and Message_id='000000BZ'", dt)
            Dim lbl As New Label
            msg.Controls.Add(lbl)
            If dt.Rows.Count > 0 Then
            
                lbl.Text = dt.Rows(0)("Message_SummaryDescription").ToString()
            Else
                lbl.Text = "Empty Text Found"
            End If

        End If
    End Sub



   

End Class
