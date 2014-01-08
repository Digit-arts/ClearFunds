Imports System.Data.SqlClient

Partial Class Admin_CompanyNewsImage
    Inherits System.Web.UI.Page
    Private sqlcon As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString.ToString())
    Private SqlCmd As New SqlCommand()
    Private reader As SqlDataReader
    Private ad As New SqlDataAdapter()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        sqlcon.Open()
        Dim imid As String = Request.QueryString("id")

        SqlCmd = New SqlCommand("select Company_Image from CF_CompanyNews where Company_id='" & imid & "'", sqlcon)
        reader = SqlCmd.ExecuteReader()
        If reader.Read() Then
            If reader("Company_Image") IsNot Nothing Then
                Dim bytes As [Byte]() = DirectCast(reader("Company_Image"), [Byte]())
                Context.Response.ContentType = "image/jpeg"
                Context.Response.BinaryWrite(bytes)
            End If
        End If
    End Sub
End Class
