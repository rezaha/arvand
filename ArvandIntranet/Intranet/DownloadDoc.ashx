<%@ WebHandler Language="VB" Class="DownloadDoc" %>

Imports System
Imports System.Web
Imports StructureMap
Imports System.IO
Imports Arvand.Common

Public Class DownloadDoc : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If context.Request.QueryString("doc") Then
            Dim doc As Integer = Convert.ToInt32(context.Request.QueryString("doc"))
            Dim _docGrantService As IDocGrantService = ObjectFactory.GetInstance(Of IDocGrantService)()
            Dim _docManagementService As IDocManagementService = ObjectFactory.GetInstance(Of IDocManagementService)()
            Dim _showDoc = _docManagementService.GetOneDocManagement(doc)
            If _showDoc.PublicGrant Then
                Dim fileName As String = "~/" & _showDoc.DocUrl
                context.Response.Clear()
                'context.Response.ContentType = file.FileType
                If _showDoc.DocUrl.Substring(_showDoc.DocUrl.LastIndexOf(".")).ToLower() = ".pdf" Then
                    context.Response.AppendHeader("Content-Disposition", PortalDownloadHeaders.Build(Path.GetFileName(fileName), True))
                    context.Response.ContentType = "application/pdf"
                    context.Response.WriteFile(fileName)
                Else
                    context.Response.AppendHeader("Content-Disposition", PortalDownloadHeaders.Build(Path.GetFileName(fileName), False))
                    context.Response.TransmitFile(fileName)
                End If
                context.Response.End()
            Else
                Try
                    Dim docGrant = _docGrantService.GetDocGrantByDocIdUserName(doc, DomainUserService.GetDomainUserName(context.User.Identity.Name)).FirstOrDefault()
                    If context.User.Identity.IsAuthenticated Then
                        If docGrant.UserDomain.ToLower = DomainUserService.GetDomainUserName(context.User.Identity.Name).ToLower Then
                            Dim fileName As String = "~/" & docGrant.DocManagement.DocUrl
                            context.Response.Clear()
                            'context.Response.ContentType = file.FileType
                            If _showDoc.DocUrl.Substring(_showDoc.DocUrl.LastIndexOf(".")).ToLower() = ".pdf" Then
                                context.Response.AppendHeader("Content-Disposition", PortalDownloadHeaders.Build(Path.GetFileName(fileName), True))
                                context.Response.ContentType = "application/pdf"
                                context.Response.WriteFile(fileName)
                            Else
                                context.Response.AppendHeader("Content-Disposition", PortalDownloadHeaders.Build(Path.GetFileName(fileName), False))
                                context.Response.TransmitFile(fileName)
                            End If
                       
                            context.Response.End()
                        Else
                            context.Response.ContentType = "text/plain"
                            context.Response.Write("شما دسترسی به این قسمت را ندارید")
                        End If
                    Else
                        context.Response.ContentType = "text/plain"
                        context.Response.Write("شما دسترسی به این قسمت را ندارید")
                    End If
                Catch ex As Exception
                    context.Response.ContentType = "text/plain"
                    context.Response.Write(ex.Message)
                End Try
                
            End If
        Else
            context.Response.ContentType = "text/plain"
            context.Response.Write("شما دسترسی به این قسمت را ندارید")
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class
