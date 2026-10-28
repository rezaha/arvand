
Partial Class UserControls_OtherAnnouncementsWUC
    Inherits BaseUserControl

    Public Property announcementService As IAnnouncementService

    Public Sub loadOtherAnnouncements(ByVal newsId As Integer)
        Dim announcementList = announcementService.GetTopAnnouncements(0, 5, "NewsDate ASC", PlantDivisions.DivisionId)
        Dim announcementItem = announcementList.FirstOrDefault(Function(a) a.NewsId = newsId)
        If announcementItem IsNot Nothing Then
            announcementList.Remove(announcementItem)
        End If
        Repeater1.DataSource = announcementList
        Repeater1.DataBind()
    End Sub

    Protected Function SetAnnouncementUrl(ByVal DataItem As News) As String
        Dim url As String = ""
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "ShowAnnouncements", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitlePersian.Trim.ToFriendlyUrl())
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "ShowAnnouncements", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitleLatin.Trim.ToFriendlyUrl())
        End If
        Return url
    End Function

    Protected Function SetAnnouncementTitle(ByVal DataItem As News) As String
        If SiteLanguage = "fa" Then
            Return DataItem.TitlePersian
        ElseIf SiteLanguage = "en" Then
            Return DataItem.TitleLatin
        End If
        Return ""
    End Function

    Protected Function SetAnnouncementSummary(ByVal DataItem As News) As String
        If SiteLanguage = "fa" Then
            Return DataItem.SummaryPersian
        ElseIf SiteLanguage = "en" Then
            Return DataItem.SummaryLatin
        End If
        Return ""
    End Function

End Class
