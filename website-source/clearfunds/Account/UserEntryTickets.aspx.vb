Imports System.Data
Imports System.Data.SqlClient

Partial Class Account_UserEntryTickets
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions()
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Dim result1 As String = ""
    Dim filename As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As New DataTable()
        Dim dt1 As New DataTable()

     
        If Not Session("User_Id") = Nothing Then
            obj.Fill_DropDown("select category_name,category_Id from Ticket_Category", drpcategories)
            'Dim admincount As String = obj.Returnsinglevalue("select Settings_TicketDefaulttime from CF_Settings")
            'Dim originDate As Date = Date.Parse(DateAndTime.Now)
            'Dim daysToAdd As Integer = Integer.Parse(admincount)
            'Dim result As Date = originDate.AddDays(daysToAdd)
            'ViewState("date") = result
            'result1 = result.ToString("dd/MM/yyyy")
            'txtdatetime.Text = result1
            Dim uid As Guid = Membership.GetUser.ProviderUserKey()
            Dim uid1 As String = Convert.ToString(uid)
            'Dim uname As String = obj.Returnsinglevalue("select username from aspnet_users where userId='" + uid1 + "'")
            'txtusername.Text = uname
            'Dim email As String = obj.Returnsinglevalue("select email from aspnet_membership where userId='" + uid1 + "'")
            'txtemailaddress.Text = email
            '    If IsPostBack = False Then

            '        SelectedIndexId = Session("User_Id")

            '        dt = obj.returndatatable("select c.Tickets_Id, c.Tickets_Sender,c.Tickets_Operator,b.Tickets_UserName,b.Tickets_CategoryId,c.Tickets_Priority,c.Tickets_Date,c.Tickets_Problem,c.Tickets_Comment  from Tickets c left join Ticket_Category b  on c.Tickets_CategoryId=b.Category_Id   where c.TicketsUserId='" + SelectedIndexId + "'", dt)
            '        If dt.Rows.Count > 0 Then
            '            txtcustomerid.Text = dt.Rows(0).Item("User_Saluation").ToString()
            '            txtsender.Text = dt.Rows(0).Item("User_FirstName").ToString()
            '            txtoperator.Text = dt.Rows(0).Item("User_LastName").ToString()
            '            txtusername.Text = dt.Rows(0).Item("UserName").ToString()
            '            txtemailaddress.Text = dt.Rows(0).Item("User_Addr1").ToString()
            '            txtdatetime.Text = dt.Rows(0).Item("User_Addr2").ToString()
            '            txtproblem.Text = dt.Rows(0).Item("User_City").ToString()
            '            txtcomment.Text = dt.Rows(0).Item("User_Region").ToString()




            '            For i = 0 To drpcategories.Items.Count - 1
            '                If drpcategories.Items(i).Text = dt.Rows(0).Item("CustomProcessing_Name").ToString Then
            '                    drpcategories.SelectedIndex = i
            '                End If
            '            Next


            '            For i = 0 To ddlpriority.Items.Count - 1
            '                If ddlpriority.Items(i).Text = dt.Rows(0).Item("CustomProcessing_Name").ToString Then
            '                    ddlpriority.SelectedIndex = i
            '                End If
            '            Next






            '        Else


            '        End If




            '        'End If
            '    Else
            '        'Response.Redirect("login.aspx")
            '    End If






        Else
            Response.Redirect("login.aspx")

        End If



    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
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

            filename = FileUpload1.PostedFile.FileName
            Dim filelength As Int64 = FileUpload1.PostedFile.ContentLength
            Dim b As Byte() = New Byte(filelength - 1) {}
            FileUpload1.PostedFile.InputStream.Read(b, 0, filelength)
            Dim uid As Guid = Membership.GetUser.ProviderUserKey()
            Dim uid1 As String = Convert.ToString(uid)
            Dim uname As String = obj.Returnsinglevalue("select username from aspnet_users where userId='" + uid1 + "'")

            Dim email As String = obj.Returnsinglevalue("select email from aspnet_membership where userId='" + uid1 + "'")
            Dim admincount As String = obj.Returnsinglevalue("select Settings_TicketDefaulttime from CF_Settings")
            Dim originDate As Date = Date.Parse(DateAndTime.Now)
            Dim daysToAdd As Integer = Integer.Parse(admincount)
            Dim result As Date = originDate.AddDays(daysToAdd)
            ViewState("date") = result
            result1 = result.ToString("dd/MM/yyyy")



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
            cmd.Parameters.Add(New SqlParameter("@Tickets_Category", SqlDbType.VarChar, 100)).Value = drpcategories.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@Tickets_Priority", SqlDbType.VarChar, 100)).Value = ddlpriority.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@Tickets_Date", SqlDbType.DateTime)).Value = DateTime.ParseExact(result1, "dd/MM/yyyy", Nothing)
            cmd.Parameters.Add(New SqlParameter("@Tickets_Problem ", SqlDbType.VarChar, 100)).Value = txtproblem.Text
            cmd.Parameters.Add(New SqlParameter("@Tickets_Comment ", SqlDbType.VarChar, 1000)).Value = txtcomment.Text
            cmd.Parameters.Add(New SqlParameter("@Tickets_RegDate", SqlDbType.DateTime)).Value = obj.GetCurrentDate()
            cmd.Parameters.Add(New SqlParameter("@Tickets_Status", SqlDbType.VarChar, 10)).Value = "New"
            cmd.Parameters.Add(New SqlParameter("@Tickets_Filename", SqlDbType.NVarChar, 10)).Value = filename

            cmd.Parameters.AddWithValue("@Tickets_attachfile", b)

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('saved Successfully');", True)
            Response.Redirect("Forum.aspx")

            'txtusername.Text = ""
            'txtemailaddress.Text = ""
            'txtdatetime.Text = ""
            txtproblem.Text = ""
            txtcomment.Text = ""


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreset.Click
        'txtusername.Text = ""
        'txtemailaddress.Text = ""
        'txtdatetime.Text = ""
        'txtproblem.Text = ""
        'txtcomment.Text = ""
        Response.Redirect("Forum.aspx")
    End Sub
End Class
