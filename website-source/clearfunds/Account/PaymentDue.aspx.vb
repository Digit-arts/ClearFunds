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
Imports System.Net
Imports System.Web.Security
Partial Class Account_PaymentDue
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Dim selectedIndexDetIdnew As String = ""
    Dim userid1 As Guid
    Protected WithEvents resultSpan As New Global.System.Web.UI.HtmlControls.HtmlGenericControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Dim counts As Integer = 0
        SelectedIndexId = Session("user_id")
        dt = obj.returndatatable("select package_id, Package_name from CF_Package", dt)
        For Each Count In dt.Rows
            If dt.Rows.Count > 0 Then
                Dim RBDeposit As New RadioButton
                'RBDeposit.ID = "RBdeposit" + i.ToString()
                RBDeposit.ID = dt.Rows(counts).Item("package_id").ToString()
                RBDeposit.Text = dt.Rows(counts).Item("Package_name").ToString()
                ' RBDeposit.Checked = False
                RBDeposit.GroupName = "ADD"
                divRB.Controls.Add(RBDeposit)



                Dim br As New HtmlGenericControl("br")
                divRB.Controls.Add(br)
                dt1 = obj.returndatatable("select Package_PaymentPeriod,Deposit_Amount from CF_Package a inner join CF_Deposit b on b.Deposit_PackageId=a.Package_Id inner join CF_User c on c. User_UserId=b.Deposit_UserId where user_id='" + SelectedIndexId + "'", dt1)
                'CreateGridView()
                Dim gv As New GridView()
                gv.ID = "GVDeposit" + counts.ToString
                gv.AutoGenerateColumns = True
                gv.AllowPaging = True
                gv.EnableViewState = True
                gv.PageSize = 10
                gv.DataSource = dt1
                gv.DataBind()
                divRB.Controls.Add(gv)
                Dim br1 As New HtmlGenericControl("br")
                divRB.Controls.Add(br1)

                Dim makedeposit As New Button
                makedeposit.ID = dt.Rows(counts).Item("package_id").ToString()
                makedeposit.Text = "MaKe Deposite"
                AddHandler makedeposit.Click, AddressOf Me.makedeposit_Click
                divRB.Controls.Add(makedeposit)

            End If
            counts = counts + 1

        Next




    End Sub
    Private Sub makedeposit_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim b As Button = TryCast(sender, Button)
        If b IsNot Nothing Then
            ' Save the last pressed ID for later
            PressedButton.Value = b.ID
        End If
        If PressedButton.Value IsNot Nothing Then
            Dim b1 As Button = DirectCast(divRB.FindControl(DirectCast(PressedButton.Value, String)), Button)
            If b1 IsNot Nothing Then
                Response.Redirect("MakeDeposit.aspx?packid=" + b1.ID)

            End If
        End If



    End Sub
End Class
