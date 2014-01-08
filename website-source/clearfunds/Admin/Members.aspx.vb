Imports System.Data
Imports System.Data.SqlClient
Partial Class _Members
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds As New DataSet()
        Dim str As String = ""
        '  str = " select convert(varchar(50),a.UserId) as UserId ,UserName,b.CreateDate as RegisteredDate from aspnet_Users a join aspnet_Membership b on a.UserId=b.UserId"
        'str = " select convert(varchar(50),a.UserId) as UserId ,UserName,b.CreateDate as RegisteredDate,c.Member_Status from aspnet_Users a  inner join aspnet_Membership b on a.UserId=b.UserId inner join CF_Member c on c.Member_UserId=a.UserId"
        str = " select convert(varchar(50),a.UserId) as UserId ,UserName, CONVERT(VARCHAR(11), b.CreateDate, 106) as RegisteredDate,c.User_Status from aspnet_Users a   inner join aspnet_Membership b on a.UserId=b.UserId inner join CF_User c on c.User_UserId=a.UserId"
        ds = obj.ReturnDataSet(str)
        GVMembersList.DataSource = ds
        GVMembersList.DataBind()

    End Sub
   
End Class
