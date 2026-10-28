Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IAlbumImagesService

        Function GetOneAlbumImages(ImageId As Integer) As AlbumsImages

        Function RemoveAlbumImage(albumImage As AlbumsImages, err As Dictionary(Of String, String)) As Integer

        Function EditAlbumImage(albumImage As AlbumsImages, err As Dictionary(Of String, String)) As Integer

        Function AddAlbumImage(albumImage As AlbumsImages, err As Dictionary(Of String, String)) As Integer

        Function GetAlbumImages(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of AlbumsImages)
        Function SearchAlbumImages(Optional ByVal AlbumId As Integer? = Nothing) As IList(Of AlbumsImages)
    End Interface

End Namespace