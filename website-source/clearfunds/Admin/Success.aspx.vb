Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Configuration
Partial Class Success
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)


        Dim con As New SqlConnection
        con = New SqlConnection(obj.ConnectionString)

        Dim cmd As New SqlCommand
        Dim query As String

        Dim tranref As String, transtat As String, tranamt As String, trancur As String, output As String
        If Not Page.IsPostBack Then
            Try
                tranref = Request.QueryString("tx").ToString()
                transtat = Request.QueryString("st").ToString()
                tranamt = Request.QueryString("amt").ToString()
                trancur = Request.QueryString("cc").ToString()

                'insert into table for future reference - Session["user"] is logged in user
                query = "insert into tranSuccess(tranref,transtat,tranamt,trancur,tranusr) values('" + tranref + "','" + transtat + "','" + tranamt + "','" + trancur + "','" + Session("User_Id") + "')"
                con.Open()
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                con.Close()

                'Display transaction details
                output = "<table width='500' align='center' cellpadding='0' cellspacing='0' border='1'>"
                output += "<tr><td colspan='2' height='40' align='center'><b>Transaction Details</b><td></tr>"
                output += "<tr><td height='40'>Reference No.<td><td>" + tranref + "</td>"
                output += "<tr><td height='40'>Status<td><td>" + transtat + "</td>"
                output += "<tr><td height='40'>Amount<td><td>" + tranamt + "</td>"
                output += "<tr><td height='40'>Currency<td><td>" + trancur + "</td>"
                output += "<tr><td height='40'>User<td><td>" + Session("User_Id").ToString() + "</td>"
                output += "</table>"

                lblDet.Text = output
            Catch ex As Exception

            End Try
        End If
    End Sub

End Class
