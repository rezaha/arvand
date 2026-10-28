Imports DaneshArvandSiteDomainClasses.Models

Partial Class NewsArchive
    Inherits BasePage
    Public Property NewsItems As INewsService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Repeater1.DataSource = NewsItems.GetAllNews()
            Repeater1.DataBind()
            menuTitle.InnerText = GetGlobalResourceObject("SharedResource", "menuTitle")
            homeLink.InnerText = GetGlobalResourceObject("SharedResource", "homeLink")
            lblPageTitle.InnerText = GetGlobalResourceObject("SharedResource", "pageName_newsArchive")

            If SiteLanguage.ToLower = "en" Then
                For i As Integer = 1 To 32
                    drpDay.Items.Add(New ListItem(i, i))
                Next
                For i As Integer = 1 To 10
                    drpYear.Items.Add(New ListItem((1390 + i), (1390 + i)))
                Next
                drpMonth.Items.Add(New ListItem("January", 1))
                drpMonth.Items.Add(New ListItem("February", 2))
                drpMonth.Items.Add(New ListItem("March", 3))
                drpMonth.Items.Add(New ListItem("April", 4))
                drpMonth.Items.Add(New ListItem("May", 5))
                drpMonth.Items.Add(New ListItem("June", 6))
                drpMonth.Items.Add(New ListItem("July", 7))
                drpMonth.Items.Add(New ListItem("August", 8))
                drpMonth.Items.Add(New ListItem("September", 9))
                drpMonth.Items.Add(New ListItem("October", 10))
                drpMonth.Items.Add(New ListItem("November", 11))
                drpMonth.Items.Add(New ListItem("December", 12))
            Else
                For i As Integer = 1 To 32
                    drpDay.Items.Add(New ListItem(i, i))
                Next
                For i As Integer = 1 To 10
                    drpYear.Items.Add(New ListItem((1390 + i), (1390 + i)))
                Next
                drpMonth.Items.Add(New ListItem("فروردین", 1))
                drpMonth.Items.Add(New ListItem("اردیبهشت", 2))
                drpMonth.Items.Add(New ListItem("خرداد", 3))
                drpMonth.Items.Add(New ListItem("تیر", 4))
                drpMonth.Items.Add(New ListItem("مرداد", 5))
                drpMonth.Items.Add(New ListItem("شهریور", 6))
                drpMonth.Items.Add(New ListItem("مهر", 7))
                drpMonth.Items.Add(New ListItem("آبان", 8))
                drpMonth.Items.Add(New ListItem("آذر", 9))
                drpMonth.Items.Add(New ListItem("دی", 10))
                drpMonth.Items.Add(New ListItem("بهمن", 11))
                drpMonth.Items.Add(New ListItem("اسفند", 12))
            End If
        End If
    End Sub

    Public Function SetHomePageUrl() As String
        Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "default"})
        Return url
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

    Function SetNewTitle(ByVal DataItem As News) As String
        If SiteLanguage.ToLower = "en" Then
            Return DataItem.TitleLatin
        Else
            Return DataItem.TitlePersian
        End If
    End Function

    Function SetNewsSummary(ByVal DataItem As News) As String
        If SiteLanguage.ToLower = "en" Then
            Return DataItem.SummaryLatin
        Else
            Return DataItem.SummaryPersian
        End If
    End Function

End Class
