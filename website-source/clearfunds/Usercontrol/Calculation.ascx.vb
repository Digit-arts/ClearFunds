Imports System.Data
Partial Class Calculation
    Inherits System.Web.UI.UserControl
    Dim obj As New ClassFunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'lblfrom.Text = DateAndTime.Now.ToShortDateString()
        lblfrom.Text = DateTime.Today.ToString("dd/MM/yyyy")
        'txtTo.Text = "N/A"
        lbldays.Text = "N/A"
        lblpercent.Text = "N/A"
        lblpfofit.Text = "N/A"
        lbldeposit.Text = "N/A"
    End Sub

    Protected Sub btncalculate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncalculate.Click
        Dim total As Double

        If Trim(txtamount.Text) = "" Then
            txtamount.Text = "0"
        End If
        total = obj.Returnsinglevalue("select Packagedet_Percent from CF_Packagedet  where  Packagedet_MinAmount <='" + txtamount.Text + "' and packagedet_maxamount >='" + txtamount.Text + "' and packagedet_plan <>'' ")
        lblpercent.Text = Val(total)
        lblpfofit.Text = (Val(txtamount.Text) * Val(lblpercent.Text)) / 100
        lbldeposit.Text = Val(txtamount.Text)

    End Sub

    Protected Sub txtTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTo.TextChanged
      
        Dim dt2 As DateTime = DateTime.ParseExact(txtTo.Text, "dd/MM/yyyy", Nothing)
        Dim dt1 As DateTime = DateTime.ParseExact(lblfrom.Text, "dd/MM/yyyy", Nothing)
        If dt2 > dt1 Then
         
            Dim ts As TimeSpan = dt2.Subtract(dt1)
            lbldays.Text = ts.Days
        Else
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "alert('Invalid  Date Selection');", True)
            txtTo.Text = ""
        End If
    End Sub
End Class
