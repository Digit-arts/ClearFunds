Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Imports System.Data
Imports System.Data.SqlClient

Imports System.Configuration
Partial Class Failed
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim depositID As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                Dim result = Request("gateway_result").ToString()
                depositID = Request("item_id").ToString()
                CreateTicket(result)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub CreateTicket(returnMessage As String)
        Dim ID As String = ""
        ID = Session("User_Id")

        Try

            obj.strMode = "ADD"
            Dim dt As New DataTable()
            Dim dt2 As New DataTable()


            Dim dt1 As New DataTable
            Dim con As New SqlConnection
            con = New SqlConnection(obj.ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand
            Dim d5 As New DataTable

            Dim uid As Guid = Membership.GetUser.ProviderUserKey()
            Dim uid1 As String = Convert.ToString(uid)
            Dim uname As String = obj.Returnsinglevalue("select username from aspnet_users where userId='" + uid1 + "'")

            Dim email As String = obj.Returnsinglevalue("select email from aspnet_membership where userId='" + uid1 + "'")
            Dim catID As String = obj.Returnsinglevalue("SELECT [Category_Id] FROM [Ticket_Category] where [Category_Name] = 'deposits'")
            Dim admincount As String = obj.Returnsinglevalue("select Settings_TicketDefaulttime from CF_Settings")
            Dim originDate As Date = Date.Parse(DateAndTime.Now)
            Dim daysToAdd As Integer = Integer.Parse(admincount)
            Dim result As Date = originDate.AddDays(daysToAdd)
            ViewState("date") = result
            Dim result1 = result.ToString("dd/MM/yyyy")

            Dim message = "Your deposit request failed : " & returnMessage

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_Tickets"
            cmd.Connection = con
            cmd.Parameters.Add(New SqlParameter("@Mode", SqlDbType.VarChar, 10)).Value = obj.strMode
            cmd.Parameters.Add(New SqlParameter("@Tickets_Id", SqlDbType.VarChar, 50)).Value = obj.getIndexKey()

            cmd.Parameters.Add(New SqlParameter("@Tickets_UserId", SqlDbType.VarChar, 10)).Value = ID
            'cmd.Parameters.Add(New SqlParameter("@Tickets_Sender ", SqlDbType.VarChar, 100)).Value = txtsender.Text.Trim()
            'cmd.Parameters.Add(New SqlParameter("@Tickets_Operator", SqlDbType.VarChar, 100)).Value = txtoperator.Text.Trim()
            cmd.Parameters.Add(New SqlParameter("@Tickets_UserName ", SqlDbType.VarChar, 100)).Value = uname
            cmd.Parameters.Add(New SqlParameter("@Tickets_Email ", SqlDbType.VarChar, 100)).Value = email
            cmd.Parameters.Add(New SqlParameter("@Tickets_Category", SqlDbType.VarChar, 100)).Value = catID
            cmd.Parameters.Add(New SqlParameter("@Tickets_Priority", SqlDbType.VarChar, 100)).Value = "High"
            cmd.Parameters.Add(New SqlParameter("@Tickets_Date", SqlDbType.DateTime)).Value = DateTime.Now
            cmd.Parameters.Add(New SqlParameter("@Tickets_Problem ", SqlDbType.VarChar, 100)).Value = "Deposit request - " & depositID
            cmd.Parameters.Add(New SqlParameter("@Tickets_Comment ", SqlDbType.VarChar, 1000)).Value = message
            cmd.Parameters.Add(New SqlParameter("@Tickets_RegDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.Parameters.Add(New SqlParameter("@Tickets_Status", SqlDbType.VarChar, 10)).Value = "New"
            'cmd.Parameters.Add(New SqlParameter("@Tickets_Filename", SqlDbType.NVarChar, 10)).Value = filename

            'cmd.Parameters.AddWithValue("@Tickets_attachfile", b)

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        Catch ex As Exception

        End Try
    End Sub
End Class
