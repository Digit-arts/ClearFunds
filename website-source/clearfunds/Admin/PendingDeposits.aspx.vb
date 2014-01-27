Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_PendingDeposists
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        If Not Me.IsPostBack Then
            str = ("select distinct( Username),Deposit_Id, Deposit_ModifyDate,Deposit_Amount from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId WHERE Deposit_Status='PENDING'")
            Total = obj.Returnsinglevalue("select sum(Deposit_Amount)  from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId WHERE Deposit_Status='PENDING'")
            lblAmt.Text = Val(Total)
            ds = obj.ReturnDataSet(str)
            GVDepositDetails.DataSource = ds
            GVDepositDetails.DataBind()
        End If
    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        Dim Total As Double
        str = ("select distinct(Username),CONVERT(VARCHAR(11), bDeposit_ModifyDate, 106) as Deposit_ModifyDate,Packagedet_Plan,Package_duration,Packagedet_Percent,Deposit_Amount from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId inner join CF_Packagedet on Package_Id=Packagedet_PackageId  and Packagedet_Plan <>''  and Deposit_Amount between Packagedet_MinAmount and Packagedet_MaxAmount and Deposit_Status='PENDING' where((Deposit_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " ')) ")
        Total = obj.Returnsinglevalue("select sum(Deposit_Amount)  from CF_Deposit inner join aspnet_Users on UserId=Deposit_UserId inner join  CF_Package on Package_Id=Deposit_PackageId  inner join CF_Packagedet on Package_Id=Packagedet_PackageId  and Packagedet_Plan <>''  and Deposit_Amount between Packagedet_MinAmount and Packagedet_MaxAmount  and Deposit_Status='PENDING'where((Deposit_ModifyDate BETWEEN ' " + txtfrom.Text + " ' AND ' " + txtto.Text + " '))")
        lblAmt.Text = Val(Total)
        ds = obj.ReturnDataSet(str)
        GVDepositDetails.DataSource = ds
        GVDepositDetails.DataBind()

    End Sub

    Protected Sub lkApprove_Click(sender As Object, e As EventArgs)
        Dim lkApp As LinkButton = DirectCast(sender, LinkButton)
        Dim str As String = ""
        Dim id As String = lkApp.CommandArgument
        str = " UPDATE [CF_Deposit] SET [Deposit_Status] = 'ACCEPTED' WHERE [Deposit_Id] = '" & id & "'"
        obj.ExecuteQuery(str)
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub lkReject_Click(sender As Object, e As EventArgs)
        Dim lkApp As LinkButton = DirectCast(sender, LinkButton)
        Dim grv As GridViewRow = TryCast(lkApp.NamingContainer, GridViewRow)
        If grv IsNot Nothing Then
            Dim tb As TextBox = DirectCast(grv.FindControl("txtReasons"), TextBox)
            Dim value As String = tb.Text
            If Not value = Nothing Then
                Dim str As String = ""
                Dim id As String = lkApp.CommandArgument
                str = " UPDATE [CF_Deposit] SET [Deposit_Status] = 'REJECTED', [Deposit_Remarks] = '" & value & "' WHERE [Deposit_Id] = '" & id & "'"
                obj.ExecuteQuery(str)
                Response.Redirect(Request.RawUrl)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Please make sure to input a reason');", True)
            End If
        End If
    End Sub

    Protected Sub lkChangeAmount_Click(sender As Object, e As EventArgs)

    End Sub
End Class
