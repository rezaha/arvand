Imports Danesh.ArvandIntranet.DomainClasses.Models

Partial Class UserControls_AnnouncementsContentWUC
    Inherits BaseUserControl

    Public Property announcementService As IAnnouncementService

    Public Sub ShowAnnouncements(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortExpersion As String)
        Dim announcementList = announcementService.GetTopAnnouncements(startIndex, pageSize, sortExpersion, PlantDivisions.DivisionId)
        Repeater1.DataSource = announcementList
        Repeater1.DataBind()
    End Sub

    Protected Function AnnouncementsDateConvert(ByVal NewsDate As String) As String
        'یکشنبه 12 اردیبهشت 1391
        If SiteLanguage = "fa" Then
            Dim dateTimeHelper As New DateTimeHelper
            Return dateTimeHelper.LongPersianDate("13" & NewsDate, PersianDateTimeFormat.DayOfWeekName_Day_MonthName_Year)
        ElseIf SiteLanguage = "en" Then
            Dim dateTimeHelper As New DateTimeHelper
            Return dateTimeHelper.LongLatinDate("13" & NewsDate, LatinDateTimeFormat.Day_MonthName_Year)
        End If
        Return ""
    End Function

    Protected Function AnnouncementsTitle(ByVal DataItem As News) As String
        If SiteLanguage = "fa" Then
            Return DataItem.TitlePersian
        ElseIf SiteLanguage = "en" Then
            Return DataItem.TitleLatin
        End If
        Return ""
    End Function

    Protected Function AnnouncementsSummary(ByVal DataItem As News) As String
        If SiteLanguage = "fa" Then
            Return DataItem.SummaryPersian
        ElseIf SiteLanguage = "en" Then
            Return DataItem.SummaryLatin
        End If
        Return ""
    End Function

    Protected Function SetAnnoncmentsUrl(ByVal DataItem As News) As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "ShowAnnouncements", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitlePersian.Trim.ToFriendlyUrl())
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "ShowAnnouncements", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitleLatin.Trim.ToFriendlyUrl())
        End If
        Return url
    End Function

End Class
