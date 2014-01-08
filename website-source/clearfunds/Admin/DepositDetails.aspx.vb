Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_DepositDetails
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        str = ("select distinct( Username), CONVERT(VARCHAR(11), Deposit_ModifyDate, 106) as Deposit_ModifyDate,Packagedet_Plan,Package_duration,Packagedet_Percent,Deposit_Amount,Deposit_SysIp,Deposit_CountryName,Deposit_PayName from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId inner join CF_Packagedet on Package_Id=Packagedet_PackageId  and Packagedet_Plan <>''  and Deposit_Amount between Packagedet_MinAmount and Packagedet_MaxAmount")
        Total = obj.Returnsinglevalue("select sum(Deposit_Amount)  from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId  inner join CF_Packagedet on Package_Id=Packagedet_PackageId  and Packagedet_Plan <>''  and Deposit_Amount between Packagedet_MinAmount and Packagedet_MaxAmount")
        lblAmt.Text = Val(Total)
        ds = obj.ReturnDataSet(str)
        GVDepositDetails.DataSource = ds
        GVDepositDetails.DataBind()
    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        str = ("select distinct(Username),CONVERT(VARCHAR(11), Deposit_ModifyDate, 106) as Deposit_ModifyDate,Packagedet_Plan,Package_duration,Packagedet_Percent,Deposit_Amount from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId inner join CF_Packagedet on Package_Id=Packagedet_PackageId  and Packagedet_Plan <>''  and Deposit_Amount between Packagedet_MinAmount and Packagedet_MaxAmount where((Deposit_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ')) ")
        Total = obj.Returnsinglevalue("select sum(Deposit_Amount)  from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId  inner join CF_Packagedet on Package_Id=Packagedet_PackageId  and Packagedet_Plan <>''  and Deposit_Amount between Packagedet_MinAmount and Packagedet_MaxAmount where((Deposit_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " '))")
        lblAmt.Text = Val(Total)
        ds = obj.ReturnDataSet(str)
            GVDepositDetails.DataSource = ds
            GVDepositDetails.DataBind()

    End Sub
End Class
