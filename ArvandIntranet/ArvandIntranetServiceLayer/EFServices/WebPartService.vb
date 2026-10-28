Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class WebPartService
        Implements IWebPartService

        Private _uow As IUnitOfWork
        Private _webpart As IDbSet(Of Webpart)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _webpart = _uow.Set(Of Webpart)()
        End Sub

        Public Function GetOneWebPart(ByVal webpartId As Integer) As Webpart Implements IWebPartService.GetOneWebPart
            Return _webpart.Find(webpartId)
        End Function

        Public Function GetWebParts(ByVal divisionId As Integer) As List(Of Webpart) Implements IWebPartService.GetWebParts
            Return _webpart.Where(Function(a) a.DivisionId = divisionId And a.Active = True).ToList
        End Function

        Public Function GetMaxWebpartId() As Integer Implements IWebPartService.GetMaxWebpartId
            Return _webpart.Max(Function(a) a.WebpartId)
        End Function

        Public Function GetWebPartsByType(ByVal divisionId As Integer, ByVal TypeId As Integer) As List(Of Webpart) Implements IWebPartService.GetWebPartsByType
            Return _webpart.Where(Function(a) a.DivisionId = divisionId And a.WebpartType = TypeId).ToList
        End Function

        Public Function AddWebPart(ByVal WebPart As Webpart) As Integer Implements IWebPartService.AddWebPart
            Dim rowEffect As Integer = 0
            _webpart.Add(WebPart)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeleteWebPart(ByVal WebPart As Webpart) As Integer Implements IWebPartService.DeleteWebPart
            Dim rowEffect As Integer = 0
            _webpart.Remove(WebPart)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function EditWebPart(ByVal WebPart As Webpart) As Integer Implements IWebPartService.EditWebPart
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

    End Class

End Namespace