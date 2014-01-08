Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Imports System.IO

Partial Class DeposistsHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim pendingSortExpression As String = ""
    Dim acceptedSortExpression As String = ""
    Dim rejectedSortExpression As String = ""
    Dim pendingTable As DataTable = New DataTable()
    Dim acceptedTable As DataTable = New DataTable()
    Dim rejectedTable As DataTable = New DataTable()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            Dim userid As String = Session("User_Id").ToString()

            Dim str As String = obj.Returnsinglevalue("select user_Phone from cf_user where [User_Id]='" + userid + "'")
            If str = "0" Then
                Response.Redirect("~/account/editprofile.aspx", True)
            End If

        End If
        If Not Session("User_Id") = Nothing Then

            If Page.IsPostBack Then
                pendingTable = ViewState("pendingTable")
                acceptedTable = ViewState("acceptedTable")
                rejectedTable = ViewState("rejectedTable")
                pendingSortExpression = ViewState("pendingSortExpression")
                acceptedSortExpression = ViewState("acceptedSortExpression")
                rejectedSortExpression = ViewState("rejectedSortExpression")
                Return
            End If

            SelectedIndexId = Session("User_Id")
            Dim dt As New DataTable()
            Dim ds As New DataSet()

            Dim str As String = ""

            str = "SELECT Deposit_Id as Reference, Deposit_Payname as 'Payment_method', Deposit_ModifyDate as Date,Deposit_Amount as Amount, Deposit_TrnsId as 'Transaction_ID', package_name " &
                    "FROM CF_Deposit a " &
                    "INNER JOIN CF_User b on b. User_UserId=a.Deposit_UserId  " &
                    "INNER JOIN CF_Package c on c.Package_Id = a.Deposit_PackageId " &
                    "WHERE user_id='" & SelectedIndexId.ToString() & "' and (Deposit_Status='True') " &
                    "ORDER BY Reference ASC"
            acceptedTable = obj.returndatatable(str, acceptedTable)
            GVDepositAcceptedHistory.DataSource = acceptedTable.DefaultView
            GVDepositAcceptedHistory.DataBind()
            ViewState("acceptedTable") = acceptedTable


            str = "SELECT Deposit_Id as Reference, Deposit_Payname as 'Payment_method', Deposit_ModifyDate as Date,Deposit_Amount as Amount, Deposit_Remarks as Remarks, package_name " &
                    "FROM CF_Deposit a " &
                    "INNER JOIN CF_User b on b. User_UserId=a.Deposit_UserId  " &
                    "INNER JOIN CF_Package c on c.Package_Id = a.Deposit_PackageId " &
                    "WHERE user_id='" & SelectedIndexId.ToString() & "' and (Deposit_Status IS NULL) " &
                    "ORDER BY Reference ASC"
            pendingTable = obj.returndatatable(str, pendingTable)
            GVDepositPendingHistory.DataSource = pendingTable.DefaultView
            GVDepositPendingHistory.DataBind()
            ViewState("pendingTable") = pendingTable


            str = "SELECT Deposit_Id as Reference, Deposit_Payname as 'Payment_method', Deposit_ModifyDate as Date,Deposit_Amount as Amount, Deposit_Remarks as Remarks, package_name " &
                    "FROM CF_Deposit a " &
                    "INNER JOIN CF_User b on b. User_UserId=a.Deposit_UserId  " &
                    "INNER JOIN CF_Package c on c.Package_Id = a.Deposit_PackageId " &
                    "WHERE user_id='" & SelectedIndexId.ToString() & "' and (Deposit_Status='False') " &
                    "ORDER BY Reference ASC"
            rejectedTable = obj.returndatatable(str, rejectedTable)
            GVDepositRejectedHistory.DataSource = rejectedTable.DefaultView
            GVDepositRejectedHistory.DataBind()
            ViewState("rejectedTable") = rejectedTable
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub GVDepositPendingHistory_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GVDepositPendingHistory.Sorting

        pendingTable.DefaultView.Sort = e.SortExpression.ToString()
        ViewState("pendingSortExpression") = e.SortExpression.ToString()
        GVDepositPendingHistory.DataSource = pendingTable.DefaultView
        GVDepositPendingHistory.DataBind()
    End Sub

    Protected Sub GVDepositRejectedHistory_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GVDepositRejectedHistory.Sorting

        rejectedTable.DefaultView.Sort = e.SortExpression.ToString()
        ViewState("rejectedSortExpression") = e.SortExpression.ToString()
        GVDepositRejectedHistory.DataSource = rejectedTable.DefaultView
        GVDepositRejectedHistory.DataBind()
    End Sub

    Protected Sub GVDepositAcceptedHistory_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GVDepositAcceptedHistory.Sorting

        acceptedTable.DefaultView.Sort = e.SortExpression.ToString()
        ViewState("acceptedSortExpression") = e.SortExpression.ToString()
        GVDepositAcceptedHistory.DataSource = acceptedTable.DefaultView
        GVDepositAcceptedHistory.DataBind()
    End Sub

    Protected Sub GVDepositPendingHistory_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVDepositPendingHistory.PageIndexChanging
        pendingTable.DefaultView.Sort = pendingSortExpression
        GVDepositPendingHistory.DataSource = pendingTable.DefaultView
        GVDepositPendingHistory.PageIndex = e.NewPageIndex
        GVDepositPendingHistory.DataBind()
    End Sub

    Protected Sub GVDepositRejectedHistory_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVDepositRejectedHistory.PageIndexChanging
        rejectedTable.DefaultView.Sort = rejectedSortExpression
        GVDepositRejectedHistory.DataSource = rejectedTable.DefaultView
        GVDepositRejectedHistory.PageIndex = e.NewPageIndex
        GVDepositRejectedHistory.DataBind()
    End Sub

    Protected Sub GVDepositAcceptedHistory_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVDepositAcceptedHistory.PageIndexChanging
        acceptedTable.DefaultView.Sort = acceptedSortExpression
        GVDepositAcceptedHistory.DataSource = acceptedTable.DefaultView
        GVDepositAcceptedHistory.PageIndex = e.NewPageIndex
        GVDepositAcceptedHistory.DataBind()
    End Sub


    Protected Sub btn_CSV_Pending_Click(sender As Object, e As EventArgs) Handles btn_CSV_Pending.Click

        GenerateCSV(GVDepositPendingHistory, pendingTable)
    End Sub

    Protected Sub btn_CSV_Accepted_Click(sender As Object, e As EventArgs) Handles btn_CSV_Accepted.Click

        GenerateCSV(GVDepositAcceptedHistory, acceptedTable)
    End Sub

    Protected Sub btn_CSV_Rejected_Click(sender As Object, e As EventArgs) Handles btn_CSV_Rejected.Click

        GenerateCSV(GVDepositRejectedHistory, rejectedTable)
    End Sub

    Sub GenerateCSV(grid As GridView, table As DataTable)

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("Content-Disposition", "attachment;filename=data_export.csv")
        Response.Charset = ""
        Response.ContentType = "application/text"
        grid.DataSource = table.DefaultView
        grid.AllowPaging = False
        grid.DataBind()
        Dim sb As New StringBuilder()

        For k As Integer = 0 To grid.Columns.Count - 2
            'add separator
            sb.Append(grid.Columns(k).HeaderText + ";"c)
        Next

        'append new line
        sb.Append(vbCr & vbLf)

        For i As Integer = 0 To grid.Rows.Count - 1

            For k As Integer = 0 To grid.Columns.Count - 1

                'add separator
                sb.Append(DirectCast(grid.Rows(i).FindControl("lbl_" & k), Label).Text + ";"c)

            Next

            'append new line
            sb.Append(vbCr & vbLf)

        Next

        Response.Output.Write(sb.ToString())
        Response.Flush()
        Response.End()
    End Sub

    Protected Sub btn_PDF_Pending_Click(sender As Object, e As EventArgs) Handles btn_PDF_Pending.Click
        GeneratePDF(GVDepositPendingHistory, pendingTable)
    End Sub

    Protected Sub btn_PDF_Accepted_Click(sender As Object, e As EventArgs) Handles btn_PDF_Accepted.Click
        GeneratePDF(GVDepositAcceptedHistory, acceptedTable)
    End Sub

    Protected Sub btn_PDF_Rejected_Click(sender As Object, e As EventArgs) Handles btn_PDF_Rejected.Click
        GeneratePDF(GVDepositRejectedHistory, rejectedTable)
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        Return
    End Sub
    Sub GeneratePDF(grid As GridView, table As DataTable)

        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=data_export.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        grid.DataSource = table.DefaultView
        grid.AllowPaging = False
        grid.DataBind()
        grid.RenderControl(hw)

        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)

        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.End()
    End Sub

End Class
