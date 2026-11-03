Imports System.Globalization
Imports System.IO
Imports System.Reflection

Partial Class Text
    Inherits BasePage

    Dim pagetitle As String = ""
    Dim newsItem As Danesh.ArvandIntranet.DomainClasses.Models.News
    Dim announcementItem As Danesh.ArvandIntranet.DomainClasses.Models.News

    Public Property ProductSer As IProductService
    Public Property PageSer As IPagesService
    Public Property newsService As INewsService
    Public Property announcementService As IAnnouncementService
    Dim part As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        part = RouteData.Values("part").ToString().ToLower()
        Dim id As Integer = RouteData.Values("id").ToString().ToLower()

        If part = "news" Then
            newsItem = newsService.GetOneNews(id)
            If newsItem Is Nothing Then
                Response.RedirectToRoute("default-rout", New With {.id = Nothing, .description = Nothing})
            End If
            If Not newsItem.Active Then
                Response.RedirectToRoute("default-rout", New With {.id = Nothing, .description = Nothing})
            End If
            If SiteLanguage = "fa" Then
                If newsItem.ShowStatus = 2 Then
                    Response.RedirectToRoute("default-rout", New With {.id = Nothing, .description = Nothing})
                End If
                lblContent.InnerHtml = newsItem.HtmlContentPersian
                lblDate.InnerText = newsItem.NewsDate
                lblLargeImage.Src = newsItem.LargePictureLink
                lblSummary.InnerText = newsItem.SummaryPersian
                lblTitle.InnerText = newsItem.TitlePersian
                pagetitle = newsItem.TitlePersian
            ElseIf SiteLanguage = "en" Then
                If newsItem.ShowStatus = 1 Then
                    Response.RedirectToRoute("default-rout", New With {.id = Nothing, .description = Nothing})
                End If
                lblContent.InnerHtml = newsItem.HtmlContentLatin
                lblDate.InnerText = newsItem.NewsDate
                lblLargeImage.Src = newsItem.LargePictureLink
                lblSummary.InnerText = newsItem.SummaryLatin
                lblTitle.InnerText = newsItem.TitleLatin
                pagetitle = newsItem.TitleLatin
            End If
        ElseIf part = "announcement" Then
            announcementItem = announcementService.GetOneAnnouncement(id)
            If newsItem Is Nothing Then
                Response.RedirectToRoute("default-rout", New With {.id = Nothing, .description = Nothing})
            End If
            If Not newsItem.Active Then
                Response.RedirectToRoute("default-rout", New With {.id = Nothing, .description = Nothing})
            End If
            If SiteLanguage = "fa" Then
                If newsItem.ShowStatus = 1 Then
                    Response.RedirectToRoute("default-rout", New With {.id = Nothing, .description = Nothing})
                End If
                lblContent.InnerHtml = newsItem.HtmlContentPersian
                lblDate.InnerText = newsItem.NewsDate
                lblLargeImage.Src = newsItem.LargePictureLink
                lblSummary.InnerText = newsItem.SummaryPersian
                lblTitle.InnerText = newsItem.TitlePersian
                pagetitle = newsItem.TitlePersian
            ElseIf SiteLanguage = "en" Then
                If newsItem.ShowStatus = 0 Then
                    Response.RedirectToRoute("default-rout", New With {.id = Nothing, .description = Nothing})
                End If
                lblContent.InnerHtml = newsItem.HtmlContentLatin
                lblDate.InnerText = newsItem.NewsDate
                lblLargeImage.Src = newsItem.LargePictureLink
                lblSummary.InnerText = newsItem.SummaryLatin
                lblTitle.InnerText = newsItem.TitleLatin
                pagetitle = newsItem.TitleLatin
            End If
        ElseIf part = "page" Then
            Dim PageItem = PageSer.GetOnePage(id)
            lblContent.InnerHtml = PageItem.PageContent
            lblLargeImage.Visible = False
            lblSummary.InnerHtml = PageItem.PageSummary
            lblTitle.InnerText = PageItem.PageTitle
            pagetitle = PageItem.PageTitle
        ElseIf part = "product" Then

            If SiteLanguage.ToLower = "fa" Then
                Dim ProtuctItem = ProductSer.GetOneProduct(id)
                lblContent.InnerHtml = ProtuctItem.DescriptionPersian
                lblLargeImage.Visible = False
                lblSummary.InnerHtml = ProtuctItem.SummaryPersian
                lblTitle.InnerText = ProtuctItem.NamePersian
                pagetitle = ProtuctItem.NamePersian
            Else
                Dim ProtuctItem = ProductSer.GetOneProduct(id)
                lblContent.InnerHtml = ProtuctItem.DescriptionLatin
                lblLargeImage.Visible = False
                lblSummary.InnerHtml = ProtuctItem.SummaryLatin
                lblTitle.InnerText = ProtuctItem.NameLatin
                pagetitle = ProtuctItem.NameLatin
            End If

        End If
        Page.Title = pagetitle
        AddMetaData()
    End Sub

    Protected Sub Page_LoadComplete1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Title = pagetitle
        End If
    End Sub

    Protected Sub AddMetaData()
        Dim MetaObj As New CLSPagesMetatags
        Dim MetaData As List(Of CLSPagesMetatagsItem)
        If part = "news" Then
            MetaData = MetaObj.GetPAGES_METATAGS("NEWS", newsItem.NewsId)
        ElseIf part = "announcement" Then
            MetaData = MetaObj.GetPAGES_METATAGS("NEWS", newsItem.NewsId)
        ElseIf part = "product1" Then
            MetaData = MetaObj.GetPAGES_METATAGS("PRODUCT", newsItem.NewsId)
        End If
        If MetaData IsNot Nothing Then

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
        End If

    End Sub

    Public Function SetHomePageUrl() As String
        Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "default"})
        Return url
    End Function

    Public Function SetPrintNewsUrl() As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("print-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitlePersian})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("print-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitleLatin})
        End If
        Return url
    End Function

    Public Function SetTextNewsUrl() As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("text-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitlePersian})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("text-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitleLatin})
        End If
        Return url
    End Function

    Public Function SetRssNewsUrl() As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("rss-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitlePersian})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("rss-rout", New With {.part = "news", .id = newsItem.NewsId, .description = newsItem.TitleLatin})
        End If
        Return url
    End Function

End Class
