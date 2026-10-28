
Partial Class UserControls_TopNewsTickerWUC
    Inherits BaseUserControl

    Public Property announcementService As IAnnouncementService
    Public Property newsService As INewsService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim newsList As List(Of Danesh.ArvandIntranet.DomainClasses.Models.News)
        Dim announcementList As List(Of Danesh.ArvandIntranet.DomainClasses.Models.News)
        If SiteLanguage = "fa" Then
            newsList = newsService.GetTopPersianNews(0, 2, "NewsDate ASC", PlantDivisions.DivisionId)
            announcementList = announcementService.GetPersianAnnouncements(0, 2, "NewsDate ASC", PlantDivisions.DivisionId)
        Else
            newsList = newsService.GetTopLatinNews(0, 2, "NewsDate ASC", PlantDivisions.DivisionId)
            announcementList = announcementService.GetLatinAnnouncements(0, 2, "NewsDate ASC", PlantDivisions.DivisionId)
        End If

        Repeater1.DataSource = newsList
        Repeater1.DataBind()

        Repeater2.DataSource = announcementList
        Repeater2.DataBind()
    End Sub

    Protected Function NewsTickerTitle(ByVal DataItem As News) As String
        If SiteLanguage = "fa" Then
            Return DataItem.TitlePersian
        ElseIf SiteLanguage = "en" Then
            Return DataItem.TitleLatin
        End If
        Return ""
    End Function

    Protected Function SetNewsTickerUrl(ByVal DataItem As News, ByVal type As String) As String
        Dim url As String = String.Empty
        If Type = "news" Then
            If SiteLanguage = "fa" Then
                url = GetRouteUrl("default-rout", New With {.pageName = "ShowNews", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitlePersian.Trim.ToFriendlyUrl())
            ElseIf SiteLanguage = "en" Then
                url = GetRouteUrl("default-rout", New With {.pageName = "ShowNews", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitleLatin.Trim.ToFriendlyUrl())
            End If
        ElseIf type = "announcement" Then
            If SiteLanguage = "fa" Then
                url = GetRouteUrl("default-rout", New With {.pageName = "ShowAnnouncements", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitlePersian.Trim.ToFriendlyUrl())
            ElseIf SiteLanguage = "en" Then
                url = GetRouteUrl("default-rout", New With {.pageName = "ShowAnnouncements", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitleLatin.Trim.ToFriendlyUrl())
            End If
        End If
        Return url
    End Function

End Class
