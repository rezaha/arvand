Imports System.Globalization
Imports System.IO
Imports System.Reflection

Partial Class ShowNews
    Inherits BasePage

    Public Property newsService As INewsService
    Dim pagetitle As String = ""
    Dim newsItem As Danesh.ArvandIntranet.DomainClasses.Models.News

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If (Not IsPostBack) Then
        If (Not RouteData.Values("id") Is Nothing) Then
            Dim newsId As Integer = RouteData.Values("id").ToString
            If SiteLanguage = "fa" Then
                newsItem = newsService.GetOneNews(newsId)
                If newsItem Is Nothing Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                    Exit Sub
                ElseIf newsItem.ShowStatus = 2 Or Not newsItem.Active Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                    Exit Sub
                End If
                Dim dateTimeHelper As New DateTimeHelper
                lblNewsDate.InnerText = dateTimeHelper.LongPersianDate("13" & newsItem.NewsDate, PersianDateTimeFormat.DayOfWeekName_Day_MonthName_Year)
                lblNewsLargeImage.Src = newsItem.LargePictureLink
                lblNewsSummary.InnerHtml = newsItem.SummaryPersian
                lblNewsTitle.InnerHtml = newsItem.TitlePersian
                lblNewsContent.InnerHtml = newsItem.HtmlContentPersian
                pagetitle = newsItem.TitlePersian
            ElseIf SiteLanguage = "en" Then
                newsItem = newsService.GetOneNews(newsId)
                If newsItem Is Nothing Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                    Exit Sub
                ElseIf newsItem.ShowStatus = 2 Or Not newsItem.Active Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                    Exit Sub
                End If
                Dim dateTimeHelper As New DateTimeHelper
                lblNewsDate.InnerText = dateTimeHelper.LongPersianDate("13" & newsItem.NewsDate, LatinDateTimeFormat.DayOfWeekName_Day_MonthName_Year)
                lblNewsLargeImage.Src = newsItem.LargePictureLink
                lblNewsSummary.InnerHtml = newsItem.SummaryLatin
                lblNewsTitle.InnerHtml = newsItem.TitleLatin
                lblNewsContent.InnerHtml = newsItem.HtmlContentLatin
                pagetitle = newsItem.TitleLatin
            End If
            NewsLabelsWUC.Reload(newsItem.NewsId)
            NewsCommentWUC.Reload(newsItem.NewsId)
            'menuTitle.InnerText = GetGlobalResourceObject("SharedResource", "menuTitle")
            'homeLink.InnerText = GetGlobalResourceObject("SharedResource", "homeLink")
            'PrintLink.InnerHtml = GetGlobalResourceObject("SharedResource", "PrintLink")
            'TextLink.InnerHtml = GetGlobalResourceObject("SharedResource", "TextLink")
            Page.Title = pagetitle
            AddMetaData()
            OtherNewsWUC.loadOtherNews(newsId)
        Else
            Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
        End If
        Page.DataBind()
        'End If
    End Sub

    Protected Sub Page_LoadComplete1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'ShowCommentWUC1.Reload()
        If Not IsPostBack Then
            Title = pagetitle
        End If
    End Sub

    Protected Sub AddMetaData()
        Dim MetaObj As New CLSPagesMetatags
        Dim MetaData As List(Of CLSPagesMetatagsItem) = MetaObj.GetPAGES_METATAGS("NEWS", newsItem.NewsId)
        For Each Metatags In MetaData
            Dim Meta As New HtmlMeta
            Meta.Name = Metatags.Meta_name
            Meta.ID = Metatags.Meta_id
            Meta.Content = Metatags.Meta_content
            Meta.HttpEquiv = Metatags.Meta_httpequiv
            Meta.Scheme = Metatags.Meta_scheme
            If Metatags.Meta_lang <> "" Then
                Meta.Attributes.Add("lang", Metatags.Meta_lang)
            End If
            If Metatags.Meta_dir <> "" Then
                Meta.Attributes.Add("dir", Metatags.Meta_dir)
            End If
            If Metatags.Meta_xmllang <> "" Then
                Meta.Attributes.Add("xmllang", Metatags.Meta_xmllang)
            End If
            Page.Header.Controls.Add(Meta)
        Next
    End Sub

    Public Function SetHomePageUrl() As String
        Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "default"})
        Return url
    End Function

    Public Function SetPrintNewsUrl() As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("print-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitlePersian.ToFriendlyUrl})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("print-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitleLatin.ToFriendlyUrl})
        End If
        Return url
    End Function

    Public Function SetTextNewsUrl() As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("text-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitlePersian.ToFriendlyUrl})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("text-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitleLatin.ToFriendlyUrl})
        End If
        Return url
    End Function

    Public Function SetRssNewsUrl() As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("rss-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitlePersian.ToFriendlyUrl})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("rss-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitleLatin.ToFriendlyUrl})
        End If
        Return url
    End Function


End Class
