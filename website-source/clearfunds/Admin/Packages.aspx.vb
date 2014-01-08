Imports System.Data
Imports System.Data.SqlClient
Partial Class _Packages
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim dt1 As New DataTable()
        Dim dt2 As New DataTable()
        Dim dt3 As New DataTable()
        Dim i As Integer = 0

        If Not IsPostBack Then

            dt = obj.returndatatable("select package_id, Package_name from CF_Package", dt)

            For Each Count In dt.Rows
                If dt.Rows.Count > 0 Then
                    Dim txtpackname As New Label
                    txtpackname.ID = dt.Rows(i).Item("package_id").ToString()
                    txtpackname.Text = dt.Rows(i).Item("Package_name").ToString()
                    divlblgrid.Controls.Add(txtpackname)
                    Dim breakTag As LiteralControl
                    breakTag = New LiteralControl("&nbsp;")
                    divlblgrid.Controls.Add(breakTag)
                    Dim breakTag1 As LiteralControl
                    breakTag1 = New LiteralControl("&nbsp;")
                    divlblgrid.Controls.Add(breakTag1)
                    dt2 = obj.returndatatable("select convert(varchar(10),MIN(packagedet_minamount))+ ' - ' +convert(varchar(10),Max(packagedet_maxamount)) as deposit from cf_packagedet where Packagedet_PackageId ='" + txtpackname.ID + "' and Packagedet_Active='True'", dt2)
                    Dim txtdeposit As New TextBox
                    txtdeposit.Text = dt2.Rows(0).Item("deposit").ToString()
                    txtdeposit.Enabled = False
                    divlblgrid.Controls.Add(txtdeposit)
                    Dim brk As LiteralControl
                    brk = New LiteralControl("&nbsp;")
                    divlblgrid.Controls.Add(brk)
                    Dim brk1 As LiteralControl
                    brk1 = New LiteralControl("&nbsp;")
                    divlblgrid.Controls.Add(brk1)
                    dt3 = obj.returndatatable("select convert(varchar(10),MIN(Packagedet_Percent))+ ' - ' +convert(varchar(10),Max(Packagedet_Percent)) as Profit from cf_packagedet where Packagedet_PackageId ='" + txtpackname.ID + "' and Packagedet_Active='True'", dt3)
                    Dim txtprofit As New TextBox
                    txtprofit.Text = dt3.Rows(0).Item("Profit").ToString()
                    txtprofit.Enabled=False
                    divlblgrid.Controls.Add(txtprofit)



                    Dim editbutton As New LinkButton
                    editbutton.ID = "edibutton" + i.ToString
                    editbutton.Text = "edit"
                    editbutton.PostBackUrl = "AddPlans.aspx?pid=" + txtpackname.ID
                
                    divlblgrid.Controls.Add(editbutton)
                    Dim br As New HtmlGenericControl("br")
                    divlblgrid.Controls.Add(br)





                    'Dim deletebutton As New LinkButton
                    'deletebutton.ID = "delebutton" + i.ToString
                    'deletebutton.Text = "Delete"
                    'AddHandler deletebutton.Click, AddressOf Me.deletebutton_Click
                    'divlblgrid.Controls.Add(deletebutton)
                    'Dim br1 As New HtmlGenericControl("br")
                    'divlblgrid.Controls.Add(br)


                  


                    dt1 = obj.returndatatable(" select a.Packagedet_Plan as PlanName ,convert(varchar(10),a.Packagedet_MinAmount) +'-'+ convert(varchar(10),a.Packagedet_MaxAmount) as deposit ,Packagedet_Percent as profit from CF_Packagedet a join CF_Package b on a.Packagedet_PackageId=b.Package_Id where package_id='" + txtpackname.ID + "' and Packagedet_Plan <> ''", dt1)
                    Dim GVPackageList As New GridView()
                    GVPackageList.ID = "GVDeposit" + i.ToString
                    GVPackageList.AutoGenerateColumns = True


                    GVPackageList.AllowPaging = True
                    GVPackageList.EnableViewState = True
                    GVPackageList.PageSize = 10
                    'Dim c As New CommandField
                    'c.ShowEditButton = True
                    'GVPackageList.Columns.Add(c)



                    GVPackageList.DataSource = dt1
                    GVPackageList.DataBind()

                    Dim br2 As New HtmlGenericControl("br")
                    divlblgrid.Controls.Add(br)

                    divlblgrid.Controls.Add(GVPackageList)
                    Dim br7 As New HtmlGenericControl("br")
                    divlblgrid.Controls.Add(br)
                    GVPackageList.DataSource = dt1
                    GVPackageList.DataBind()

                    'obj.Fill_DataGridView("select b.Package_Id ,a.Packagedet_Id,b.Package_name,a.Packagedet_Plan ,convert(varchar(10),a.Packagedet_MinAmount) +'-'+ convert(varchar(10),a.Packagedet_MaxAmount) as deposit ,Packagedet_Percent from CF_Packagedet a join CF_Package b on a.Packagedet_PackageId=b.Package_Id", GVPackageList)

                    ' GVPackageList.DataBind()

                End If
                i = i + 1
            Next

        End If


    End Sub

    'Protected Sub deletebutton_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Are you sure want to Delete ');", True)

    '    Dim b As Button = TryCast(sender, Button)
    '    If b IsNot Nothing Then
    '        ' Save the last pressed ID for later
    '        PressedButton.Value = b.ID
    '    End If
    '    If PressedButton.Value IsNot Nothing Then
    '        Dim b1 As Button = DirectCast(divlblgrid.FindControl(DirectCast(PressedButton.Value, String)), Button)
    '        If b1 IsNot Nothing Then
    '            Dim dt4 As New DataTable()
    '            dt4 = obj.returndatatable("", dt4)
    '        End If
    '    End If


    'End Sub

   
End Class
