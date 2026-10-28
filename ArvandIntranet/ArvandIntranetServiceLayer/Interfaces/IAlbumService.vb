Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IAlbumService

        Function SearchAlbumImagesByType(AlbumType As Integer, divisionId As Integer) As Album

        Function EditAlbum(album As Album, err As Dictionary(Of String, String)) As Integer

        Function AddAlbum(album As Album, err As Dictionary(Of String, String)) As Integer

        Function GetAllAlbumImagesByDivisionId(divisionId As Integer) As IList(Of Album)

        Function GetAlbumImages(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Album)
        Function SearchAlbumImages(Optional ByVal AlbumId As Integer? = Nothing) As IList(Of Album)
    End Interface

End Namespace
