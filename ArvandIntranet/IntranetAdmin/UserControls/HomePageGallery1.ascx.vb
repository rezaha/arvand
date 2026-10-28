
Partial Class UserControls_HomePageGallery1
    Inherits BaseUserControl

    Public Property albumImagesService As IAlbumImagesService
    Public Property _albumService As IAlbumService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim DivisionAlbum = _albumService.GetAllAlbumImagesByDivisionId(PlantDivisions.DivisionId)
        Repeater1.DataSource = albumImagesService.SearchAlbumImages(DivisionAlbum(0).AlbumId)
        Repeater1.DataBind()
    End Sub

    Public Function GetDescription(ByVal item As Danesh.ArvandIntranet.DomainClasses.Models.AlbumsImages) As String
        If SiteLanguage.ToLower = "en" Then
            Return item.LatinDescription
        Else
            Return item.PersianDescription
        End If
    End Function
End Class
