Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Partial Class VB
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim query As String = "select distinct Deposit_Type from CF_Deposit"
            Dim dt As DataTable = GetData(query)
            ddlCountries.DataSource = dt
            ddlCountries.DataTextField = "Deposit_Type"
            ddlCountries.DataValueField = "Deposit_Type"
            ddlCountries.DataBind()
            ddlCountries.Items.Insert(0, New ListItem("Select", ""))
        End If
    End Sub
    Protected Sub ddlCountries_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim query As String = String.Format("select DATENAME(MM, Deposit_ModifyDate) as Date,sum(Deposit_Amount)as Amount from CF_Deposit where Deposit_Status='true'   group by DATENAME(MM, Deposit_ModifyDate)")
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
        BarChart1.ChartTitle = String.Format("{0} Order Distribution", ddlCountries.SelectedItem.Value)
        If x.Length > 3 Then
            BarChart1.ChartWidth = (x.Length * 100).ToString()
        End If
        BarChart1.Visible = ddlCountries.SelectedItem.Value <> ""
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
