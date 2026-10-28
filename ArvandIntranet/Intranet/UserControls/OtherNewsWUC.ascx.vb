
Partial Class UserControls_OtherNewsWUC
    Inherits BaseUserControl

    Public Property newsService As INewsService

    Public Sub loadOtherNews(ByVal newsId As Integer)
        Dim newsList = newsService.GetTopPersianNews(0, 5, "NewsDate DESC", PlantDivisions.DivisionId)
        Dim newsItem = newsList.FirstOrDefault(Function(a) a.NewsId = newsId)
        If newsItem IsNot Nothing Then
            newsList.Remove(newsItem)
        End If
        Repeater1.DataSource = newsList
        Repeater1.DataBind()
    End Sub

    Protected Function SetNewsUrl(ByVal DataItem As News) As String
        Dim url As String = ""
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "ShowNews", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitlePersian.Trim.ToFriendlyUrl())
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "ShowNews", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitleLatin.Trim.ToFriendlyUrl())
        End If
        Return url
    End Function

    Protected Function SetNewsTitle(ByVal DataItem As News) As String
        If SiteLanguage = "fa" Then
            Return DataItem.TitlePersian
        ElseIf SiteLanguage = "en" Then
            Return DataItem.TitleLatin
        End If
        Return ""
    End Function

    Protected Function SetNewsSummary(ByVal DataItem As News) As String
        If SiteLanguage = "fa" Then
            Return DataItem.SummaryPersian
        ElseIf SiteLanguage = "en" Then
            Return DataItem.SummaryLatin
        End If
        Return ""
    End Function

End Class
