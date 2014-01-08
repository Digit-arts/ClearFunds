Imports System.Data.SqlClient

Partial Class Admin_VoteUsImage
    Inherits System.Web.UI.Page
    Private sqlcon As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString.ToString())
    Private SqlCmd As New SqlCommand()
    Private reader As SqlDataReader
    Private ad As New SqlDataAdapter()
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        sqlcon.Open()
        Dim imid As String = Request.QueryString("id")
        'Dim num As Integer = Integer.Parse(imid)
        SqlCmd = New SqlCommand("select VoteUs_Image from CF_VoteUs where VoteUs_id='" & imid & "'", sqlcon)
        reader = SqlCmd.ExecuteReader()
        If reader.Read() Then
            If reader("VoteUs_Image") IsNot Nothing Then
                Dim bytes As [Byte]() = DirectCast(reader("VoteUs_Image"), [Byte]())
                Context.Response.ContentType = "image/jpeg"
                Context.Response.BinaryWrite(bytes)
            End If
        End If
    End Sub
End Class
