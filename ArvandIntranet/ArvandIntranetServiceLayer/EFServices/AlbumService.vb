Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class AlbumService
        Implements IAlbumService

        Private _uow As IUnitOfWork
        Private _album As IDbSet(Of Album)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _album = _uow.Set(Of Album)()
        End Sub

        Public Function AddAlbum(ByVal album As Album, ByVal err As Dictionary(Of String, String)) As Integer Implements IAlbumService.AddAlbum
            Dim rowEffect As Integer = 0
            _album.Add(album)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function EditAlbum(ByVal album As Album, ByVal err As Dictionary(Of String, String)) As Integer Implements IAlbumService.EditAlbum
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetAlbumImages(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Album) Implements IAlbumService.GetAlbumImages
            If sortexpression = String.Empty Then
                sortexpression = "ImageId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim albumImages = _album.AsQueryable
            Select Case SortColumnName
                Case "AlbumId"
                    albumImages = IIf(SortDirection.ToLower = "asc", albumImages.OrderBy(Function(a) a.AlbumId), albumImages.OrderByDescending(Function(a) a.AlbumId))
                Case "Remark"
                    albumImages = IIf(SortDirection.ToLower = "asc", albumImages.OrderBy(Function(a) a.Remark), albumImages.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim CityList = albumImages.Skip(startIndex).Take(PageSize).ToList
            Return CityList
        End Function

        Public Function SearchAlbumImages(Optional ByVal AlbumId As Integer? = Nothing) As IList(Of Album) Implements IAlbumService.SearchAlbumImages
            Dim albumImages = _album.AsQueryable
            If AlbumId IsNot Nothing Then
                albumImages = albumImages.Where(Function(a) a.AlbumId = AlbumId)
            End If
            Return albumImages.ToList
        End Function

        Public Function SearchAlbumImagesByType(ByVal AlbumType As Integer, ByVal divisionId As Integer) As Album Implements IAlbumService.SearchAlbumImagesByType
            Return _album.FirstOrDefault(Function(a) a.AlbumType = AlbumType And a.DivisionId = divisionId)
        End Function

        Public Function GetAllAlbumImagesByDivisionId(ByVal divisionId As Integer) As IList(Of Album) Implements IAlbumService.GetAllAlbumImagesByDivisionId
            Return _album.Where(Function(a) a.DivisionId = divisionId).ToList
        End Function

    End Class

End Namespace

