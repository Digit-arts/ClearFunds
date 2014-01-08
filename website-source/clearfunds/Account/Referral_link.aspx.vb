Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.Sql
Imports System.IO
Partial Class Account_Referral_link
    Inherits System.Web.UI.Page
    Dim obj As New ClassFunctions
    Dim SelectedIndexId As String = ""
    Dim selectedIndexDetId As String = ""
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Not Me.IsPostBack Then
        If Session("User_Id") = Nothing Then
            Response.Redirect("~/default.aspx")
        End If
        'End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            Dim userid As String = Session("User_Id").ToString()

            Dim str As String = obj.Returnsinglevalue("select user_Phone from cf_user where [User_Id]='" + userid + "'")
            If str = "0" Then
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('please complete the profile');", True)
                Response.Redirect("~/account/editprofile.aspx", False)
            End If

        End If
        If Not Session("User_Id") = Nothing Then
            'SelectedIndexId = Session("User_Id")

            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim str As String = ""
            Dim uid As Guid = Membership.GetUser.ProviderUserKey()
            Dim uid1 As String = Convert.ToString(uid)
            Dim lblsub As New Label
            lblsub.ID = "lblsub"
            lblsub.Text = "clearfunds.com. Easy. Safe. No risk."
            divreferral.Controls.Add(lblsub)

            Dim breakTag1 As LiteralControl
            breakTag1 = New LiteralControl("&nbsp;")
            divreferral.Controls.Add(breakTag1)
            Dim breakTag2 As LiteralControl
            breakTag2 = New LiteralControl("&nbsp;")
            divreferral.Controls.Add(breakTag2)
            Dim breakTag3 As LiteralControl
            breakTag3 = New LiteralControl("&nbsp;")
            divreferral.Controls.Add(breakTag3)
            Dim lba As New Label
            lba.Text = "URL"
            divreferral.Controls.Add(lba)
            Dim breakTag As LiteralControl
            breakTag = New LiteralControl("&nbsp;")
            divreferral.Controls.Add(breakTag)
            Dim eqlqal As LiteralControl
            eqlqal = New LiteralControl("=")
            divreferral.Controls.Add(eqlqal)
            Dim txtreferrallink As New Label
            txtreferrallink.ID = "txtreferrallink"


            txtreferrallink.Text = obj.Returnsinglevalue("select '<a href=http://clearfunds.acopies.com/Register.aspx?UserName=' + UserName +'>'+UserName+'</a>' from aspnet_users where userid='" + uid1 + "'")
            divreferral.Controls.Add(txtreferrallink)
        Else
            Response.Redirect("login.aspx")

        End If
    End Sub
End Class
