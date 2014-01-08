Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class ReferralsHistory
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            Dim userid As String = Session("User_Id").ToString()

            Dim str As String = obj.Returnsinglevalue("select user_Phone from cf_user where [User_Id]='" + userid + "'")
            If str = "0" Then
                Response.Redirect("~/account/editprofile.aspx", True)
            End If

        End If
        If Not Session("User_id") = Nothing Then
            SelectedIndexId = Session("user_id")

            Dim dt As New DataTable
            Dim dt1 As New DataTable
            Dim ds As New DataSet()
            Dim str As String = ""
            Dim Level As Double
            Dim Commision As Double
            '   Dim total As Double
            '  total = obj.Returnsinglevalue("")
            '  total = lblTotal.Text

            str = ("select b. User_FirstName,convert (varchar,EntryDate,103) as Date,Deposit_Amount as Amount from CF_Referral a inner Join CF_User b on b.User_Id=a.User_Id inner join CF_Deposit c on c.Deposit_UserId=b.User_UserId where Status='True' and referenceUser_id='" + SelectedIndexId + "'")

            dt = obj.returndatatable(str, dt)
            dt.Columns.Add("Commision")
            For i = 0 To dt.Rows.Count - 1


                Level = obj.Returnsinglevalue("select AddRefBonus_Commision  from CF_AddRefBonus  where AddRefBonus_From <='' and  AddRefBonus_To >=''")
                Commision = ((dt.Rows(i).Item("Amount").ToString) * (Level)) / 100
                dt.Rows(i).Item("Commision") = Commision


            Next

            '  ds = obj.ReturnDataSet(str)
            GVreferralHistory.DataSource = dt
            GVreferralHistory.DataBind()
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub btngo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngo.Click
        Dim dt As New DataTable
        Dim ds As New DataSet()
        Dim str As String = ""
        str = ("")
        ds = obj.ReturnDataSet(str)
        GVreferralHistory.DataSource = ds
        GVreferralHistory.DataBind()
    End Sub

End Class
