Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_TransactionHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As New DataTable()
        Dim str As String = ""
        Dim Total As Double

        If Not Me.IsPostBack Then
            str = "select (username),Deposit_Amount as Amount, CONVERT(varchar,Deposit_ModifyDate,106) as Date,a.Deposit_PayName ,a.Deposit_SysIp,a.Deposit_CountryName  from CF_Deposit  a  inner join aspnet_Users b on b.UserId=a.Deposit_UserId "
            Total = obj.Returnsinglevalue("  select sum(Deposit_Amount) as Date from CF_Deposit  a  left join aspnet_Users b on b.UserId=a.Deposit_UserId")
            lblAmt.Text = Val(Total)
            dt = obj.returndatatable(str, dt)
            GVMembersList.DataSource = dt
            GVMembersList.DataBind()

        End If


    End Sub
End Class
