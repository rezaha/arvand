
Partial Class UserControls_LinksWUC
    Inherits BaseUserControl

    Public Property sitesLinkService As ISitesLinkService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If SiteLanguage.ToLower = "en" Then
            Dim sitesLinkList = sitesLinkService.LatinSitesLink(0, 200, "SiteOrder ASC", PlantDivisions.DivisionId)
            Repeater1.DataSource = sitesLinkList
            Repeater1.DataBind()
        Else
            Dim sitesLinkList = sitesLinkService.PersianSitesLink(0, 200, "SiteOrder ASC", PlantDivisions.DivisionId)
            Repeater1.DataSource = sitesLinkList
            Repeater1.DataBind()
        End If
    End Sub

    Public Function SetLogo(ByVal Item As Danesh.ArvandIntranet.DomainClasses.Models.SitesLink) As String
        If SiteLanguage.ToLower = "en" Then
            Return Item.LogoLatin
        Else
            Return Item.LogoPersian
        End If
    End Function

    Public Function SetTitle(ByVal Item As Danesh.ArvandIntranet.DomainClasses.Models.SitesLink) As String
        If SiteLanguage.ToLower = "en" Then
            Return Item.TitleLatin
        Else
            Return Item.TitlePersian
        End If
    End Function

End Class
