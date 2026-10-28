Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices
    Public Class AlbumImagesService
        Implements IAlbumImagesService

        Private _uow As IUnitOfWork
        Private _albumImages As IDbSet(Of AlbumsImages)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _albumImages = _uow.Set(Of AlbumsImages)()
        End Sub

        Public Function AddAlbumImage(ByVal albumImage As AlbumsImages, ByVal err As Dictionary(Of String, String)) As Integer Implements IAlbumImagesService.AddAlbumImage
            Dim rowEffect As Integer = 0
            _albumImages.Add(albumImage)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function EditAlbumImage(ByVal albumImage As AlbumsImages, ByVal err As Dictionary(Of String, String)) As Integer Implements IAlbumImagesService.EditAlbumImage
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function RemoveAlbumImage(ByVal albumImage As AlbumsImages, ByVal err As Dictionary(Of String, String)) As Integer Implements IAlbumImagesService.RemoveAlbumImage
            Dim rowEffect As Integer = 0
            _albumImages.Remove(albumImage)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetAlbumImages(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of AlbumsImages) Implements IAlbumImagesService.GetAlbumImages
            If sortexpression = String.Empty Then
                sortexpression = "ImageId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim albumImages = _albumImages.AsQueryable
            Select Case SortColumnName
                Case "AlbumId"
                    albumImages = IIf(SortDirection.ToLower = "asc", albumImages.OrderBy(Function(a) a.ImageId), albumImages.OrderByDescending(Function(a) a.ImageId))
                Case "AlbumId"
                    albumImages = IIf(SortDirection.ToLower = "asc", albumImages.OrderBy(Function(a) a.AlbumId), albumImages.OrderByDescending(Function(a) a.AlbumId))
                Case "ImageAddress"
                    albumImages = IIf(SortDirection.ToLower = "asc", albumImages.OrderBy(Function(a) a.ImageAddress), albumImages.OrderByDescending(Function(a) a.ImageAddress))
                Case "Remark"
                    albumImages = IIf(SortDirection.ToLower = "asc", albumImages.OrderBy(Function(a) a.Remark), albumImages.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim CityList = albumImages.Skip(startIndex).Take(PageSize).ToList
            Return CityList
        End Function

        Public Function SearchAlbumImages(Optional ByVal AlbumId As Integer? = Nothing) As IList(Of AlbumsImages) Implements IAlbumImagesService.SearchAlbumImages
            Dim albumImages = _albumImages.AsQueryable
            If AlbumId IsNot Nothing Then
                albumImages = albumImages.Where(Function(a) a.AlbumId = AlbumId)
            End If
            Return albumImages.ToList
        End Function

        Public Function GetOneAlbumImages(ByVal ImageId As Integer) As AlbumsImages Implements IAlbumImagesService.GetOneAlbumImages
            Return _albumImages.FirstOrDefault(Function(a) a.ImageId = ImageId)
        End Function

    End Class
End Namespace

