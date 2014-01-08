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
Partial Class Account_Home
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Dim userid1 As String
    Dim userid2 As String()
    Dim userid As String
    Dim str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            userid = Session("User_Id").ToString()

            Str = obj.Returnsinglevalue("select user_Phone from cf_user where [User_Id]='" + userid + "'")
            If str = "0" Then
                Response.Redirect("~/account/editprofile.aspx", True)
            End If

        End If
        userid1 = Membership.GetUser.ProviderUserKey.ToString()
        'userid2(0) = userid1

        Dim uid1 As String = Convert.ToString(userid1)
        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Dim dt2 As New DataTable()
        Dim dt3 As New DataTable()
        Dim dt4 As New DataTable()
        Dim dt5 As New DataTable()
        Dim counts As Integer = 0
        Dim Str2 As String
        Dim DT6 As New DataTable()

        Dim ds As New DataSet()
        'DT6 = obj.returndatatable("select  Deposit_UserId from CF_Deposit ", DT6)        

        Str2 = "select distinct c.PackageDet_Plan ,b.Package_name,b.Package_duration ,b.Package_PaymentPeriod , convert (varchar,Deposit_ModifyDate,103) as Date  from CF_Deposit a  inner join CF_Package b on b.Package_Id =a.Deposit_PackageId   inner join CF_Packagedet  c  on c.Packagedet_Id=a.Deposit_PackageDetId  where a.Deposit_UserId = '" + userid1 + "' and Deposit_Status ='True' "

        ds = obj.ReturnDataSet(Str2)
        If ds.Tables(0).Rows.Count = 0 Then

            Dim strPackage As String
            dt = obj.returndatatable("select package_id, Package_name,package_duration from CF_Package", dt)


            For Each Count In dt.Rows
                If dt.Rows.Count > 0 Then
                    strPackage = dt.Rows(counts).Item("package_id").ToString()

                    Dim brk2 As New HtmlGenericControl("br")
                    divRB.Controls.Add(brk2)
                    Dim lblpack As New Label
                    'RBDeposit.ID = "RBdeposit" + i.ToString()
                    lblpack.ID = "lblpack" + dt.Rows(counts).Item("package_id").ToString()
                    'lblpack.CssClass = "g_label"
                    Dim str As String = lblpack.ID
                    str = str.Substring(7, 8)
                    lblpack.Text = dt.Rows(counts).Item("Package_name").ToString()
                    lblpack.Visible = True
                    divRB.Controls.Add(lblpack)

                    divRB.Controls.Add(New LiteralControl("&nbsp;"))

                    Dim lbldays As New Label
                    lbldays.ID = "lbldays"
                    lbldays.Text = "Days"

                    Dim lblpackduration As New Label

                    lblpackduration.ID = dt.Rows(counts).Item("package_id").ToString() + counts.ToString
                    lblpackduration.Text = dt.Rows(counts).Item("package_duration").ToString() + "Days"
                    divRB.Controls.Add(lblpackduration)


                    divRB.Controls.Add(New LiteralControl("&nbsp;"))


                    Dim lbldaily As New Label
                    lbldaily.ID = "lbldaily"
                    lbldaily.Text = "Daily"

                    Dim lblmaxlimit As New Label
                    dt4 = obj.returndatatable(" select  [Packagedet_Percent]   from [CF_Packagedet] where  packagedet_packageid= '" + str + "'", dt4)
                    lblmaxlimit.Text = dt4.Rows(counts).Item("Packagedet_Percent").ToString() + "%Daily"
                    divRB.Controls.Add(lblmaxlimit)

                    Dim br As New HtmlGenericControl("br")
                    divRB.Controls.Add(br)
                    dt1 = obj.returndatatable("select Packagedet_Plan as Plans,Packagedet_MinAmount as [Minimum Amount],Packagedet_MaxAmount as [Maximum Amount],Packagedet_Percent as Percentage from CF_Packagedet where packagedet_packageid= '" + str + "'  and packagedet_plan <>''", dt1)
                    'CreateGridView()       
                    Dim gv As New GridView()
                    gv.ID = "GVDeposit" + counts.ToString
                    gv.CssClass = "acc_table"
                    gv.AutoGenerateColumns = True
                    gv.AllowPaging = True
                    gv.EnableViewState = True
                    gv.RowStyle.HorizontalAlign = HorizontalAlign.Right
                    gv.PageSize = 10
                    gv.DataSource = dt1
                    gv.DataBind()
                    divRB.Controls.Add(gv)
                    'Dim br1 As New HtmlGenericControl("br")
                    'divRB.Controls.Add(br1)

                    'Dim brk As New HtmlGenericControl("br")
                    'divRB.Controls.Add(brk)
                    Dim calprofit As New Button

                    AddHandler calprofit.Click, AddressOf Me.calprofit_Click
                    calprofit.ID = "btncal" + counts.ToString
                    calprofit.Text = "Calculate Profit"
                    divRB.Controls.Add(calprofit)
                    divRB.Controls.Add(New LiteralControl("&nbsp;"))
                    Dim makedeposit As New Button
                    makedeposit.ID = dt.Rows(counts).Item("package_id").ToString()
                    makedeposit.Text = "Make Deposit"
                    AddHandler makedeposit.Click, AddressOf Me.makedeposit_Click
                    divRB.Controls.Add(makedeposit)
                    Dim br11 As New HtmlGenericControl("br")
                    divRB.Controls.Add(br11)
                End If
                counts = counts + 1
            Next

        End If



    End Sub

   

    Private Sub calprofit_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim qs As String = "calculation.aspx"
        Dim newwin As String = "window.open('" & qs & "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newwin, True)
    End Sub

    'Private Sub makedeposit_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim dt As New DataTable()
    ' dt = obj.returndatatable("select package_id, Package_name,package_duration from CF_Package", dt)
    '    Dim packageid As String = ""

    '    For Each Count In dt.Rows
    '        Dim makedeposit As Button

    '        Response.Redirect("~/Account/MakeDeposit.aspx?packid=" + packageid.ToString)
    '    Next
    'End Sub
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
