<%@ WebHandler Language="VB" Class="CompanyNewsHandler" %>

Imports System
Imports System.Web

Imports System.Data

Public Class CompanyNewsHandler
    Implements IHttpHandler
    Private obj As New ClassFunctions()
    Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim dt As New DataTable()
        Dim str As String = context.Request.QueryString("id").ToString()
        dt = obj.returndatatable("select * from CF_CompanyNews where Company_id='" & str & "'", dt)
        context.Response.BinaryWrite(DirectCast(dt.Rows(0)("Company_Image"), Byte()))
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class