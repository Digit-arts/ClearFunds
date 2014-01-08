<%@ WebHandler Language="VB" Class="FileHandler" %>


Imports System
Imports System.Web
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data

Public Class FileHandler : Implements IHttpHandler
    Dim obj As New ClassFunctions()
    'Private con As New SqlConnection("Data Source=OLITSLAP;User ID=sa;pwd=orangelab;Initial Catalog=ClearFunds")
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim dt As New DataTable()
        Dim str As String = context.Request.QueryString("id").ToString()
        dt = obj.returndatatable("select * from cf_cms_support where CMS_Support_Id='" + str + "'", dt)
        context.Response.BinaryWrite(DirectCast(dt.Rows(0).Item("CMS_Support_Image"), Byte()))
        'Dim cmd As New SqlCommand("select * from cf_cms_support where CMS_Support_Id='" + str + "'", con)
        'con.Open()
        'Dim dr As SqlDataReader = cmd.ExecuteReader()
        'dr.Read()
        'context.Response.BinaryWrite(DirectCast(dr("CMS_Support_Image"), Byte()))
        
        ' con.Close()
    End Sub
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class