Imports System.Data

Partial Class Account_Login
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Me.IsPostBack Then
            If Not Session("User_Id") = Nothing Then
                Response.Redirect("~/Default.aspx")


            End If

        End If
        '   RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
    End Sub



    Protected Sub LoginUser_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles LoginUser.Authenticate



        If (Membership.ValidateUser(LoginUser.UserName, LoginUser.Password)) Then
            e.Authenticated = True



            Dim uname As TextBox
            uname = LoginUser.Controls(0).FindControl("Username")
            Dim strHostName As String = ""
            Dim strIPAddress As String = ""
            strHostName = System.Net.Dns.GetHostName()
            strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
            Session("uname") = uname.Text
            If IsPostBack = True Then
                'Dim id As String = ""

                Dim dt As New DataTable
                dt = obj.returndatatable("select * from aspnet_Users a join CF_User c on a.UserId=c.User_UserId  where a.username='" + uname.Text + "' and user_Status='Active'", dt)
                If dt.Rows.Count > 0 Then


                    Session("User_Id") = obj.Returnsinglevalue("select c.User_Id from aspnet_Users a join CF_User c on a.UserId=c.User_UserId  where a.username='" + uname.Text + "'")
                    Dim id As String = obj.getIndexKey()
                    obj.ExecuteQuery("insert into CF_logdet(LogId, LogName,LoginTime,Ipname,servername) values('" + id + "','" + uname.Text + "','" & Format(System.DateTime.Now, "yyyy/MM/dd hh:mm:ss") & "','" + strIPAddress + "','" + strHostName + "')")

               
                    Session("Log_Id") = id.ToString()
                    LoginUser.DestinationPageUrl = "~/Account/Home.aspx"

                End If

            End If

        Else
            LoginUser.DestinationPageUrl = "~/default.aspx"

        End If

    End Sub
End Class
