Imports System.Data.SqlClient
Imports System.Data

Partial Class Admin_AddPlans
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions

    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        If Not IsPostBack Then

            If Not Request.QueryString("Pid") = Nothing Then
                obj.strMode = "Modify"
                btnAddPackage.Text = "Update"
                SelectedIndexId = Request.QueryString("Pid").ToString()
                dt = obj.returndatatable("select * from cf_Package where package_Id='" + SelectedIndexId + "'", dt)
                If dt.Rows.Count > 0 Then
                    txtPackName.Text = dt.Rows(0).Item("Package_name").ToString()
                    txtPackDuration.Text = dt.Rows(0).Item("Package_duration").ToString()
                    chkLimit.Checked = dt.Rows(0).Item("Package_limit").ToString()
                    Description.Text = dt.Rows(0).Item("Package_Description").ToString()
                    cmb1paymentperiod.SelectedValue = dt.Rows(0).Item("Package_PaymentPeriod").ToString()
                    cmb2Status.SelectedValue = dt.Rows(0).Item("Package_Status").ToString()
                    ChkRetPrincipal.Checked = dt.Rows(0).Item("Package_RetPrincipal").ToString()
                    txtRPHolddays.Text = dt.Rows(0).Item("Package_RPHolddays").ToString()
                    ChkCompounding.Checked = dt.Rows(0).Item("Package_Compounding").ToString()
                    CompDepositMinLimit.Text = dt.Rows(0).Item("Package_CompDepositMinLimit").ToString()
                    CompDepositMaxLimit.Text = dt.Rows(0).Item("Package_CompDepositMaxLimit").ToString()
                    CompPercentMinLimit.Text = dt.Rows(0).Item("Package_CompPercentMinLimit").ToString()
                    CompPercentMaxLimit.Text = dt.Rows(0).Item("Package_CompPercentMaxLimit").ToString()
                    chkallowwithdraw.Checked = dt.Rows(0).Item("Package_AllowWD").ToString
                    txtwithdrawFee.Text = dt.Rows(0).Item("Package_WDFee").ToString
                    txtminWDduration.Text = dt.Rows(0).Item("Package_WDMinDuration").ToString
                    txtmaxWDduration.Text = dt.Rows(0).Item("Package_WDMaxDuration").ToString
                    chkAllowEarnings.Checked = dt.Rows(0).Item("Package_AllowEarnings").ToString
                    chkAllowDeposit.Checked = dt.Rows(0).Item("Package_AllowDeposit").ToString
                    cmbDepositPack.SelectedValue = dt.Rows(0).Item("Package_ADPackage").ToString
                    txtHoldEarnings.Text = dt.Rows(0).Item("Package_HoldEarnings").ToString
                    txtDelayEarnings.Text = dt.Rows(0).Item("Package_DelayEarnings").ToString
                End If
                If chkallowwithdraw.Checked = True Then
                    txtwithdrawFee.Enabled = True
                    txtminWDduration.Enabled = True
                    txtmaxWDduration.Enabled = True
                Else
                    txtwithdrawFee.Enabled = False
                    txtminWDduration.Enabled = False
                    txtmaxWDduration.Enabled = False
                End If
                If chkPlan1.Checked = True Then
                    Panel2.Enabled = True
                Else
                    Panel2.Enabled = False
                End If
                If chkPlan2.Checked = True Then
                    Panel3.Enabled = True
                Else
                    Panel3.Enabled = False
                End If
                If chkPlan3.Checked = True Then
                    Panel4.Enabled = True
                Else
                    Panel4.Enabled = False
                End If
                If chkPlan4.Checked = True Then
                    Panel5.Enabled = True
                Else
                    Panel5.Enabled = False
                End If
                If chkPlan5.Checked = True Then
                    Panel6.Enabled = True
                Else
                    Panel6.Enabled = False
                End If
                dt1 = obj.returndatatable("select * from cf_packagedet where Packagedet_PackageId='" + SelectedIndexId + "'", dt1)

                If dt1.Rows.Count > 0 Then

                    If dt1.Rows(0).Item("Packagedet_Active").ToString = "True" Then
                        chkPlan1.Checked = dt1.Rows(0).Item("Packagedet_Active").ToString
                        txtPlan1.Text = dt1.Rows(0).Item("Packagedet_Plan").ToString
                        txtPmin1.Text = dt1.Rows(0).Item("Packagedet_MinAmount").ToString
                        txtPmax1.Text = dt1.Rows(0).Item("Packagedet_MaxAmount").ToString
                        txtPpercent1.Text = dt1.Rows(0).Item("Packagedet_Percent").ToString

                    Else
                        Exit Sub
                    End If




                    If dt1.Rows(1).Item("Packagedet_Active").ToString = "True" Then
                        chkPlan2.Checked = dt1.Rows(1).Item("Packagedet_Active").ToString
                        txtPlan2.Text = dt1.Rows(1).Item("Packagedet_Plan").ToString
                        txtPmin2.Text = dt1.Rows(1).Item("Packagedet_MinAmount").ToString
                        txtPmax2.Text = dt1.Rows(1).Item("Packagedet_MaxAmount").ToString
                        txtPpercent2.Text = dt1.Rows(1).Item("Packagedet_Percent").ToString

                    Else
                        Exit Sub
                    End If

                    If dt1.Rows(2).Item("Packagedet_Active").ToString = "True" Then
                        chkPlan3.Checked = dt1.Rows(2).Item("Packagedet_Active").ToString
                        txtPlan3.Text = dt1.Rows(2).Item("Packagedet_Plan").ToString
                        txtPmin3.Text = dt1.Rows(2).Item("Packagedet_MinAmount").ToString
                        txtPmax3.Text = dt1.Rows(2).Item("Packagedet_MaxAmount").ToString
                        txtPpercent3.Text = dt1.Rows(2).Item("Packagedet_Percent").ToString
                    Else
                        Exit Sub
                    End If



                    If dt1.Rows(3).Item("Packagedet_Active").ToString = "True" Then
                        chkPlan4.Checked = dt1.Rows(3).Item("Packagedet_Active").ToString
                        txtPlan4.Text = dt1.Rows(3).Item("Packagedet_Plan").ToString
                        txtPmin4.Text = dt1.Rows(3).Item("Packagedet_MinAmount").ToString
                        txtPmax4.Text = dt1.Rows(3).Item("Packagedet_MaxAmount").ToString
                        txtPpercent4.Text = dt1.Rows(3).Item("Packagedet_Percent").ToString
                    Else
                        Exit Sub
                    End If



                    If dt1.Rows(4).Item("Packagedet_Active").ToString = "True" Then
                        chkPlan5.Checked = dt1.Rows(4).Item("Packagedet_Active").ToString
                        txtPlan5.Text = dt1.Rows(4).Item("Packagedet_Plan").ToString
                        txtPmin5.Text = dt1.Rows(4).Item("Packagedet_MinAmount").ToString
                        txtPmax5.Text = dt1.Rows(4).Item("Packagedet_MaxAmount").ToString
                        txtPpercent5.Text = dt1.Rows(4).Item("Packagedet_Percent").ToString
                    Else
                        Exit Sub
                    End If

                End If


                Else
                    obj.strMode = "Add"
                    btnAddPackage.Text = "Add Package"
                End If
            End If
    End Sub

    Protected Sub Unnamed6_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkallowwithdraw.CheckedChanged
        If chkallowwithdraw.Checked = True Then
            txtwithdrawFee.Enabled = True
            txtminWDduration.Enabled = True
            txtmaxWDduration.Enabled = True
        Else
            txtwithdrawFee.Enabled = False
            txtminWDduration.Enabled = False
            txtmaxWDduration.Enabled = False
        End If
    End Sub

    Protected Sub btnAddPackage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddPackage.Click
        Try
            Call SaveData()

        Catch ex As Exception

        End Try
    End Sub
    Public Function Validation() As Boolean
        Return False
    End Function
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Not Me.IsPostBack Then
        If Session("User_Id") = Nothing Then
            ' Response.Redirect("~/default.aspx")
        End If
        'End If
    End Sub
    Private Sub SaveData()
        Try
            Dim dt As New DataTable()
            Dim dt2 As New DataTable()
            'Dim i As Integer
            Dim ID As String = ""
            Dim dt1 As New DataTable

          

                If btnAddPackage.Text = "Add Package" Then
                    obj.strMode = "Add"
                Else
                    obj.strMode = "Modify"
                End If


                If Validation() = True Then

                End If

                Select Case obj.strMode
                    Case "Add"
                        ID = obj.getIndexKey()
                    Case "Modify"
                        SelectedIndexId = Request.QueryString("Pid").ToString()
                        ID = SelectedIndexId
                    Case "Delete"
                End Select

                Dim flag As Boolean = False
                Dim str As String = ""
                If obj.strMode = "Add" Then
                    str = obj.Returnsinglevalue("SELECT package_name FROM CF_Package WHERE Package_name='" + txtPackName.Text + "'")
                    If txtPackName.Text = str Then
                        flag = True
                    End If
                End If
                If flag = False Then
                    Dim con As New SqlConnection
                    con = New SqlConnection(obj.ConnectionString)
                    con.Open()
                    Dim cmd As New SqlCommand

                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "SP_CF_Package"
                    cmd.Connection = con
                    cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
                    cmd.Parameters.Add(New SqlParameter("@Package_Id", SqlDbType.VarChar, 10)).Value = ID

                    cmd.Parameters.Add(New SqlParameter("@Package_name", SqlDbType.VarChar, 75)).Value = txtPackName.Text


                cmd.Parameters.Add(New SqlParameter("@Package_duration", SqlDbType.VarChar, 20)).Value = Val(txtPackDuration.Text)
                    cmd.Parameters.Add(New SqlParameter("@Package_limit", SqlDbType.VarChar, 10)).Value = chkLimit.Checked

                    cmd.Parameters.Add(New SqlParameter("@Package_Description", SqlDbType.VarChar, 200)).Value = Description.Text
                    cmd.Parameters.Add(New SqlParameter("@Package_PaymentPeriod", SqlDbType.VarChar, 15)).Value = cmb1paymentperiod.SelectedValue

                    cmd.Parameters.Add(New SqlParameter("@Package_Status", SqlDbType.VarChar, 15)).Value = cmb2Status.SelectedValue
                    cmd.Parameters.Add(New SqlParameter("@Package_RetPrincipal", SqlDbType.VarChar, 10)).Value = ChkRetPrincipal.Checked
                    If ChkRetPrincipal.Checked = True Then
                        cmd.Parameters.Add(New SqlParameter("@Package_RPHolddays", SqlDbType.VarChar, 10)).Value = txtRPHolddays.Text
                    Else
                        cmd.Parameters.Add(New SqlParameter("@Package_RPHolddays", SqlDbType.VarChar, 10)).Value = "0"
                    End If
                    cmd.Parameters.Add(New SqlParameter("@Package_Compounding", SqlDbType.VarChar, 10)).Value = ChkCompounding.Checked
                    If ChkCompounding.Checked = True Then
                        cmd.Parameters.Add(New SqlParameter("@Package_CompDepositMinLimit", SqlDbType.Decimal, 18, 2)).Value = Val(CompDepositMinLimit.Text)
                        cmd.Parameters.Add(New SqlParameter("@Package_CompDepositMaxLimit", SqlDbType.Decimal, 18, 2)).Value = Val(CompDepositMaxLimit.Text)
                        cmd.Parameters.Add(New SqlParameter("@Package_CompPercentMinLimit", SqlDbType.Decimal, 18, 2)).Value = Val(CompPercentMinLimit.Text)
                        cmd.Parameters.Add(New SqlParameter("@Package_CompPercentMaxLimit", SqlDbType.Decimal, 18, 2)).Value = Val(CompPercentMaxLimit.Text)
                    Else
                        cmd.Parameters.Add(New SqlParameter("@Package_CompDepositMinLimit", SqlDbType.Decimal, 18, 2)).Value = 0
                        cmd.Parameters.Add(New SqlParameter("@Package_CompDepositMaxLimit", SqlDbType.Decimal, 18, 2)).Value = 0
                        cmd.Parameters.Add(New SqlParameter("@Package_CompPercentMinLimit", SqlDbType.Decimal, 18, 2)).Value = 0
                        cmd.Parameters.Add(New SqlParameter("@Package_CompPercentMaxLimit", SqlDbType.Decimal, 18, 2)).Value = 0
                    End If
                    cmd.Parameters.Add(New SqlParameter("@Package_AllowWD", SqlDbType.VarChar, 10)).Value = chkallowwithdraw.Checked
                    If chkallowwithdraw.Checked = True Then
                        cmd.Parameters.Add(New SqlParameter("@Package_WDFee", SqlDbType.Decimal, 18, 2)).Value = Val(txtwithdrawFee.Text)
                        cmd.Parameters.Add(New SqlParameter("@Package_WDMinDuration", SqlDbType.Decimal, 18, 0)).Value = Val(txtminWDduration.Text)
                        cmd.Parameters.Add(New SqlParameter("@Package_WDMaxDuration", SqlDbType.Decimal, 18, 0)).Value = Val(txtmaxWDduration.Text)
                    Else
                        cmd.Parameters.Add(New SqlParameter("@Package_WDFee", SqlDbType.Decimal, 18, 2)).Value = 0
                        cmd.Parameters.Add(New SqlParameter("@Package_WDMinDuration", SqlDbType.Decimal, 18, 0)).Value = 0
                        cmd.Parameters.Add(New SqlParameter("@Package_WDMaxDuration", SqlDbType.Decimal, 18, 0)).Value = 0
                    End If
                    cmd.Parameters.Add(New SqlParameter("@Package_AllowEarnings", SqlDbType.VarChar, 10)).Value = chkAllowEarnings.Checked
                    cmd.Parameters.Add(New SqlParameter("@Package_AllowDeposit", SqlDbType.VarChar, 10)).Value = chkAllowDeposit.Checked
                    If chkAllowDeposit.Checked = True Then
                        cmd.Parameters.Add(New SqlParameter("@Package_ADPackage", SqlDbType.VarChar, 50)).Value = cmbDepositPack.SelectedValue
                    Else
                        cmd.Parameters.Add(New SqlParameter("@Package_ADPackage", SqlDbType.VarChar, 50)).Value = ""
                    End If

                    cmd.Parameters.Add(New SqlParameter("@Package_HoldEarnings", SqlDbType.Decimal, 18, 0)).Value = Val(txtHoldEarnings.Text)
                    cmd.Parameters.Add(New SqlParameter("@Package_DelayEarnings", SqlDbType.Decimal, 18, 0)).Value = Val(txtDelayEarnings.Text)

                    cmd.Parameters.Add(New SqlParameter("@Package_Userid", SqlDbType.VarChar, 10)).Value = obj.g_username
                    cmd.Parameters.Add(New SqlParameter("@Package_ModifyDate", SqlDbType.DateTime, 8)).Value = Format(obj.GetCurrentDate(), "yyyy/MM/dd")

                    cmd.ExecuteNonQuery()

                    cmd.Parameters.Clear()

                    cmd.CommandText = "SP_CF_Packagedet"

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
                    If obj.strMode = "Add" Then
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = obj.getIndexKey()
                    Else
                        selectedIndexDetId = obj.Returnsinglevalue("select packagedet_Id from CF_Packagedet where packagedet_packageid='" & ID & "' and packagedet_serial=1")
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = selectedIndexDetId
                    End If


                    cmd.Parameters.Add(New SqlParameter("@Packagedet_PackageId", SqlDbType.VarChar, 18)).Value = ID
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Active", SqlDbType.VarChar, 10)).Value = chkPlan1.Checked
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Serial", SqlDbType.Decimal, 18, 0)).Value = 1
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Plan", SqlDbType.VarChar, 20)).Value = txtPlan1.Text
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MinAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmin1.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MaxAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmax1.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Percent", SqlDbType.Decimal, 18, 2)).Value = Val(txtPpercent1.Text)
                    cmd.ExecuteNonQuery()

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
                    If obj.strMode = "Add" Then
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = obj.getIndexKey()
                    Else
                        selectedIndexDetId = obj.Returnsinglevalue("select packagedet_Id from CF_Packagedet where packagedet_packageid='" & ID & "' and packagedet_serial=2")
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = selectedIndexDetId
                    End If



                    cmd.Parameters.Add(New SqlParameter("@Packagedet_PackageId", SqlDbType.VarChar, 18)).Value = ID

                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Active", SqlDbType.VarChar, 10)).Value = chkPlan2.Checked
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Serial", SqlDbType.Decimal, 18, 0)).Value = 2
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Plan", SqlDbType.VarChar, 20)).Value = txtPlan2.Text
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MinAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmin2.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MaxAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmax2.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Percent", SqlDbType.Decimal, 18, 2)).Value = Val(txtPpercent2.Text)

                    cmd.ExecuteNonQuery()

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
                    If obj.strMode = "Add" Then
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = obj.getIndexKey()
                    Else
                        selectedIndexDetId = obj.Returnsinglevalue("select packagedet_Id from CF_Packagedet where packagedet_packageid='" & ID & "' and packagedet_serial=3")
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = selectedIndexDetId
                    End If
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_PackageId", SqlDbType.VarChar, 18)).Value = ID

                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Active", SqlDbType.VarChar, 10)).Value = chkPlan3.Checked
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Serial", SqlDbType.Decimal, 18, 0)).Value = 3
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Plan", SqlDbType.VarChar, 20)).Value = txtPlan3.Text
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MinAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmin3.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MaxAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmax3.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Percent", SqlDbType.Decimal, 18, 2)).Value = Val(txtPpercent3.Text)

                    cmd.ExecuteNonQuery()


                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
                    If obj.strMode = "Add" Then
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = obj.getIndexKey()
                    Else
                        selectedIndexDetId = obj.Returnsinglevalue("select packagedet_Id from CF_Packagedet where packagedet_packageid='" & ID & "' and packagedet_serial=4")
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = selectedIndexDetId
                    End If
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_PackageId", SqlDbType.VarChar, 18)).Value = ID

                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Active", SqlDbType.VarChar, 10)).Value = chkPlan4.Checked
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Serial", SqlDbType.Decimal, 18, 0)).Value = 4
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Plan", SqlDbType.VarChar, 20)).Value = txtPlan4.Text
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MinAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmin4.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MaxAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmax4.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Percent", SqlDbType.Decimal, 18, 2)).Value = Val(txtPpercent4.Text)

                    cmd.ExecuteNonQuery()

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 20)).Value = obj.strMode
                    If obj.strMode = "Add" Then
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = obj.getIndexKey()
                    Else
                        selectedIndexDetId = obj.Returnsinglevalue("select packagedet_Id from CF_Packagedet where packagedet_packageid='" & ID & "' and packagedet_serial=5")
                        cmd.Parameters.Add(New SqlParameter("@Packagedet_Id", SqlDbType.VarChar, 18)).Value = selectedIndexDetId
                    End If
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_PackageId", SqlDbType.VarChar, 18)).Value = ID

                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Active", SqlDbType.VarChar, 10)).Value = chkPlan5.Checked
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Serial", SqlDbType.Decimal, 18, 0)).Value = 5
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Plan", SqlDbType.VarChar, 20)).Value = txtPlan5.Text
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MinAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmin5.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_MaxAmount", SqlDbType.Decimal, 18, 2)).Value = Val(txtPmax5.Text)
                    cmd.Parameters.Add(New SqlParameter("@Packagedet_Percent", SqlDbType.Decimal, 18, 2)).Value = Val(txtPpercent5.Text)


                    cmd.ExecuteNonQuery()

                    cmd.Parameters.Clear()

                    Select Case obj.strMode
                        Case "Add"

                        Case "Modify"

                        Case "Delete"

                    End Select

                    obj.strMode = ""

                Else
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Already added this Package');", True)
                End If

            Response.Redirect("Packages.aspx")

            obj = Nothing
        Catch ex As Exception

            obj.strMode = "Add"

            obj = Nothing

        Finally
            'Dim continueUrl As String
            'continueUrl = "Packages.aspx"
            '  Response.Redirect("Packages.aspx")
        End Try
    End Sub

  
    Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("Packages.aspx")
    End Sub

    Protected Sub chkPlan1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPlan1.CheckedChanged
        If chkPlan1.Checked = True Then
            Panel2.Enabled = True
        Else
            Panel2.Enabled = False
        End If

    End Sub

    Protected Sub chkPlan2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPlan2.CheckedChanged
        If chkPlan2.Checked = True Then
            Panel3.Enabled = True
        Else
            Panel3.Enabled = False
        End If
    End Sub

    Protected Sub chkPlan3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPlan3.CheckedChanged
        If chkPlan3.Checked = True Then
            Panel4.Enabled = True
        Else
            Panel4.Enabled = False
        End If
    End Sub

    Protected Sub chkPlan4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPlan4.CheckedChanged
        If chkPlan3.Checked = True Then
            Panel4.Enabled = True
        Else
            Panel4.Enabled = False
        End If
        If chkPlan4.Checked = True Then
            Panel5.Enabled = True
        Else
            Panel5.Enabled = False
        End If
        If chkPlan5.Checked = True Then
            Panel6.Enabled = True
        Else
            Panel6.Enabled = False
        End If
    End Sub

    Protected Sub chkPlan5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPlan5.CheckedChanged
        If chkPlan5.Checked = True Then
            Panel6.Enabled = True
        Else
            Panel6.Enabled = False
        End If
    End Sub


    Protected Sub ChkCompounding_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCompounding.CheckedChanged
        If ChkCompounding.Checked = True Then
            CompDepositMinLimit.Enabled = True
            CompDepositMaxLimit.Enabled = True
            CompPercentMinLimit.Enabled = True
            CompPercentMaxLimit.Enabled = True
        Else
            CompDepositMinLimit.Enabled = False
            CompDepositMaxLimit.Enabled = False
            CompPercentMinLimit.Enabled = False
            CompPercentMaxLimit.Enabled = False
        End If
    End Sub
End Class
