Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Partial Class Barchart
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Dim query As String = "select distinct Deposit_Type from CF_Deposit"
        'Dim dt As DataTable = GetData(query)
        'ddlCountries.DataSource = dt
        'ddlCountries.DataTextField = "Deposit_Type"
        'ddlCountries.DataValueField = "Deposit_Type"
        'ddlCountries.DataBind()
        'ddlCountries.Items.Insert(0, New ListItem("Select", ""))
        dropdown()

    End Sub
    Public Sub dropdown()
        Dim query As String = String.Format("select DATENAME(MM, Deposit_ModifyDate) as Date,sum(Deposit_Amount)as Amount from CF_Deposit where Deposit_Status ='ACCEPTED'group by DATENAME(MM, Deposit_ModifyDate)")
        Dim dt As DataTable = GetData(query)

        Dim x As String() = New String(dt.Rows.Count - 1) {}
        Dim y As Decimal() = New Decimal(dt.Rows.Count - 1) {}
        For i As Integer = 0 To dt.Rows.Count - 1
            x(i) = dt.Rows(i)(0).ToString()
            y(i) = Convert.ToInt32(dt.Rows(i)(1))
        Next
        BarChart1.Series.Add(New AjaxControlToolkit.BarChartSeries() With { _
         .Data = y _
        })
        BarChart1.CategoriesAxis = String.Join(",", x)
        BarChart1.ChartTitle = String.Format("Profit Rate")
        If x.Length > 0 Then
            BarChart1.ChartWidth = (x.Length * 100).ToString()
        End If
        'BarChart1.Visible = ddlCountries.SelectedItem.Value <> ""
    End Sub

    Private Shared Function GetData(query As String) As DataTable
        Dim dt As New DataTable()
        Dim constr As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt
        End Using
    End Function
End Class