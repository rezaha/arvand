Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class PageWebPartService
        Implements IPageWebPartService

        Private _uow As IUnitOfWork
        Private _pageWebPart As IDbSet(Of PageWebPart)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _pageWebPart = _uow.Set(Of PageWebPart)()
        End Sub

        Public Function GetOnePageWebPart(ByVal webpartId As Integer) As PageWebPart Implements IPageWebPartService.GetOnePageWebPart
            Return _pageWebPart.Find(webpartId)
        End Function

        Public Function GetPageWebPartsByWebpartId(ByVal WebPartId As Integer) As List(Of PageWebPart) Implements IPageWebPartService.GetPageWebPartsByWebpartId
            Return _pageWebPart.Include(Function(a) a.Webpart).Include(Function(a) a.Page).Where(Function(a) a.WebpartId = WebPartId).ToList
        End Function

        Public Function GetPageWebParts(ByVal divisionId As Integer, ByVal pageName As String) As List(Of PageWebPart) Implements IPageWebPartService.GetPageWebParts
            Return _pageWebPart.Include(Function(a) a.Webpart).Include(Function(a) a.Page).Where(Function(a) a.Page.DivisionId = divisionId And a.Page.PageFileName.ToLower = pageName.ToLower).ToList
        End Function

        Public Function AddPageWebPart(ByVal pageWebPart As PageWebPart) As Integer Implements IPageWebPartService.AddPageWebPart
            Dim rowEffect As Integer = 0
            _pageWebPart.Add(pageWebPart)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeletePageWebPart(ByVal pageWebPart As PageWebPart) As Integer Implements IPageWebPartService.DeletePageWebPart
            Dim rowEffect As Integer = 0
            _pageWebPart.Remove(pageWebPart)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

    End Class

End Namespace