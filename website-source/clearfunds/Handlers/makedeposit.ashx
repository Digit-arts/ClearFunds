<%@ WebHandler Language="VB" Class="customprocessing" %>

Imports System
Imports System.Web
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data

Public Class customprocessing : Implements IHttpHandler
    Dim obj As New ClassFunctions()
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim dt As New DataTable()
        Dim str As String = context.Request.QueryString("id").ToString()
        dt = obj.returndatatable("select * from CF_CustomProcessing where CustomProcessing_id='" + str + "'", dt)
        context.Response.BinaryWrite(DirectCast(dt.Rows(0).Item("CustomProcessing_Image"), Byte()))
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class