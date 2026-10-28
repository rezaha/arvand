
Partial Class UserControls_NewsContentWUC
    Inherits BaseUserControl

    Public Property newsService As INewsService

    Protected Function NewsDateConvert(ByVal NewsDate As String) As String
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

    Public Sub ShowNews(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortExpersion As String)
        Dim newsList As List(Of News)
        If SiteLanguage = "fa" Then
            newsList = newsService.GetTopPersianNews(startIndex, pageSize, sortExpersion, PlantDivisions.DivisionId)
        ElseIf SiteLanguage = "en" Then
            newsList = newsService.GetTopLatinNews(startIndex, pageSize, sortExpersion, PlantDivisions.DivisionId)
        End If

        If newsList Is Nothing Then
            newsList = New List(Of News)
        End If

        Repeater1.DataSource = newsList
        Repeater1.DataBind()
    End Sub


    Public Function SetNewsTitle(ByVal Item As Danesh.ArvandIntranet.DomainClasses.Models.News) As String
        If SiteLanguage.ToLower = "en" Then
            Return Item.TitleLatin
        Else
            Return Item.TitlePersian
        End If
    End Function

    Public Function SetNewsSummary(ByVal Item As Danesh.ArvandIntranet.DomainClasses.Models.News) As String
        If SiteLanguage.ToLower = "en" Then
            Return Item.SummaryLatin
        Else
            Return Item.SummaryPersian
        End If
    End Function

    Protected Function SetNewsUrl(ByVal DataItem As News) As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "ShowNews", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitlePersian.Trim.ToFriendlyUrl())
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "ShowNews", .id = DataItem.NewsId}) & "/" & Server.HtmlDecode(DataItem.TitleLatin.Trim.ToFriendlyUrl())
        End If
        Return url
    End Function


End Class
