Imports System.Globalization
Imports System.IO
Imports System.Reflection

Partial Class ShowAnnouncements
    Inherits BasePage

    Public Property announcementService As IAnnouncementService

    Dim Ptitle As String = ""
    Dim announcementItem As Danesh.ArvandIntranet.DomainClasses.Models.News

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If (Not IsPostBack) Then
        If (Not RouteData.Values("id") Is Nothing) Then
            Dim announcementId As Integer = RouteData.Values("id").ToString
            If SiteLanguage = "fa" Then
                announcementItem = announcementService.GetOneAnnouncement(announcementId)
                If announcementItem Is Nothing Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                    Exit Sub
                ElseIf announcementItem.ShowStatus = 2 Or Not announcementItem.Active Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                    Exit Sub
                End If
                Dim dateTimeHelper As New DateTimeHelper
                lblAnnouncementDate.InnerText = dateTimeHelper.LongPersianDate("13" & announcementItem.NewsDate, PersianDateTimeFormat.DayOfWeekName_Day_MonthName_Year)
                lblNewsLargeImage.Src = announcementItem.LargePictureLink
                lblAnnouncementSummary.InnerHtml = announcementItem.SummaryPersian
                lblAnnouncementTitle.InnerHtml = announcementItem.TitlePersian
                lblAnnouncementContent.InnerHtml = announcementItem.HtmlContentPersian
                Ptitle = announcementItem.TitlePersian
            ElseIf SiteLanguage = "en" Then
                announcementItem = announcementService.GetOneAnnouncement(announcementId)
                If announcementItem Is Nothing Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                    Exit Sub
                ElseIf announcementItem.ShowStatus = 2 Or Not announcementItem.Active Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                    Exit Sub
                End If
                Dim dateTimeHelper As New DateTimeHelper
                lblAnnouncementDate.InnerText = dateTimeHelper.LongPersianDate("13" & announcementItem.NewsDate, PersianDateTimeFormat.DayOfWeekName_Day_MonthName_Year)
                lblNewsLargeImage.Src = announcementItem.LargePictureLink
                lblAnnouncementSummary.InnerHtml = announcementItem.SummaryLatin
                lblAnnouncementTitle.InnerHtml = announcementItem.TitleLatin
                lblAnnouncementContent.InnerHtml = announcementItem.HtmlContentLatin
                Ptitle = announcementItem.TitleLatin
            End If
            AddMetaData()
            OtherAnnouncementsWUC.loadOtherAnnouncements(announcementId)

            'menuTitle.InnerText = GetGlobalResourceObject("SharedResource", "menuTitle")
            'homeLink.InnerText = GetGlobalResourceObject("SharedResource", "homeLink")
            'PrintLink.InnerHtml = GetGlobalResourceObject("SharedResource", "PrintLink")
            'TextLink.InnerHtml = GetGlobalResourceObject("SharedResource", "TextLink")


        Else
            Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
        End If
        Page.DataBind()
        'End If
    End Sub

    Protected Sub Page_LoadComplete1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Title = Ptitle
        End If
    End Sub

    Protected Sub AddMetaData()
        Dim MetaObj As New CLSPagesMetatags
        Dim MetaData As List(Of CLSPagesMetatagsItem) = MetaObj.GetPAGES_METATAGS("NEWS", announcementItem.NewsId)
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

    Public Function SetPrintAnnouncementUrl() As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("print-rout", New With {.part = "announcement", .id = announcementItem.NewsId, .description = announcementItem.TitlePersian.ToFriendlyUrl})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("print-rout", New With {.part = "announcement", .id = announcementItem.NewsId, .description = announcementItem.TitleLatin.ToFriendlyUrl})
        End If
        Return url
    End Function

    Public Function SetTextAnnouncementUrl() As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("text-rout", New With {.part = "announcement", .id = announcementItem.NewsId, .description = announcementItem.TitlePersian.ToFriendlyUrl})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("text-rout", New With {.part = "announcement", .id = announcementItem.NewsId, .description = announcementItem.TitleLatin.ToFriendlyUrl})
        End If
        Return url
    End Function

    Public Function SetRssAnnouncementUrl() As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("rss-rout", New With {.part = "announcement", .id = announcementItem.NewsId, .description = announcementItem.TitlePersian.ToFriendlyUrl})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("rss-rout", New With {.part = "announcement", .id = announcementItem.NewsId, .description = announcementItem.TitleLatin.ToFriendlyUrl})
        End If
        Return url
    End Function

End Class
