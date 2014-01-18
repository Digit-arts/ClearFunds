Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Imports System.Data
Imports System.Data.SqlClient

Imports System.Configuration
Partial Class Success
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim SelectedIndexId As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        Dim con As New SqlConnection
        con = New SqlConnection(obj.ConnectionString)

        Dim cmd As New SqlCommand
        Dim query As String

        Dim tranref As String, transtat As String, tranamt As String, trandate As Date, tranuserid As String, output As String, Dep_id As String, Payeracc As String
        If Not Page.IsPostBack Then
            Try
                tranref = Request("tr_id").ToString()
                transtat = Request("status").ToString()
                tranamt = Request("amount").ToString()
                Dep_id = Request("item_id").ToString()
                Payeracc = Request("payerAccount").ToString()
                trandate = DateTime.Now
                tranuserid = Membership.GetUser.ProviderUserKey.ToString
                'insert into table for future reference - Session["user"] is logged in user
                query = "insert into CF_Transaction(TransactionID,TransactionStatus,Amount,DateTransaction,UserID,Trans_DepositId) values('" + tranref + "','true','" + tranamt + "','" + trandate + "','" + tranuserid + "','" + Dep_id + "')"
                con.Open()
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                con.Close()


                query = "update CF_Deposit set Deposit_Status= 'ACCEPTED' where Deposit_Id='" + Dep_id.ToString + "'"
                con.Open()
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                con.Close()



                SelectedIndexId = obj.Returnsinglevalue("select User_Id from cf_user where User_UserId='" + tranuserid + "'")
                query = "update CF_Referral set Status='true' where User_Id='" + SelectedIndexId + "'"
                con.Open()
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                con.Close()

                'Display transaction details  
                output = "<table width='500' align='center' cellpadding='0' cellspacing='0' border='1'>"
                output += "<tr><td colspan='2' height='40' align='center'><b>Transaction Details</b><td></tr>"
                output += "<tr><td height='40'>TransactionId.<td><td>" + tranref + "</td>"
                output += "<tr><td height='40'>Status<td><td>" + transtat + "</td>"
                output += "<tr><td height='40'>TransactionAmount<td><td>" + tranamt + "</td>"
                output += "<tr><td height='40'>TransactionDate<td><td>" + trandate + "</td>"
                output += "<tr><td height='40'>UserID<td><td>" + tranuserid.ToString() + "</td>"
                output += "<tr><td height='40'>DepositId<td><td>" + Dep_id.ToString() + "</td>"
                output += "<tr><td height='40'>PayerAccount<td><td>" + Payeracc.ToString() + "</td>"
                output += "</table>"

                lblDet.Text = output
            Catch ex As Exception

            End Try
        End If
    End Sub

End Class
