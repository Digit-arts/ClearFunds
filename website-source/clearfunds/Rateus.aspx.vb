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
Partial Class Rateus
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()

        If Not IsPostBack Then
            Dim i As Integer = 0
            dt = obj.returndatatable("select * from CF_CustomPage where Custompage_ChkActive='true' ", dt)
            For Each Count In dt.Rows

                If dt.Rows.Count > 0 Then
                    Dim br2 As New HtmlGenericControl("br")
                    divrateus1.Controls.Add(br2)
                    Dim lblDescription As New Label
                    lblDescription.ID = "lblDescription"
                    lblDescription.Text = dt.Rows(i).Item("Custompage_Edittext").ToString()
                    divrateus1.Controls.Add(lblDescription)


                End If
                i = i + 1
            Next
        End If
    End Sub
End Class
