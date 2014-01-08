<%@ WebHandler Language="VB" Class="UserNewsHandler" %>

Imports System.Web
Imports System.Data

Public Class UserNewsHandler
    Implements IHttpHandler

    Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim obj As New ClassFunctions()
        Dim dt As New DataTable()
        Dim str As String = context.Request.QueryString("Id").ToString()
        dt = obj.returndatatable("select Company_Image from [CF_CompanyNews] where [Company_id]='" & str & "'", dt)
        If dt.Rows.Count > 0 Then
            context.Response.BinaryWrite(DirectCast(dt.Rows(0)("Company_Image"), Byte()))
        End If
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class