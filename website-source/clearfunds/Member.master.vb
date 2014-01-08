Imports System.Data

Partial Class Member
    Inherits System.Web.UI.MasterPage
    Dim obj As New ClassFunctions()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("User_Id") = Nothing Then
            pnllogin.Visible = False
            SmallLogout1.Visible = True
            'HyperLink22.Visible = False
            'HyperLink30.Visible = True
        Else
            pnllogin.Visible = True
            SmallLogout1.Visible = False
        End If

       
    End Sub

End Class

