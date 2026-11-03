Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports Danesh.ArvandIntranet.DomainClasses

Partial Class ShowPage
    Inherits BasePage

    Public Property pageService As IPagesService

    Dim pagetitle As String = ""
    Dim pageItem As Models.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If (Not IsPostBack) Then
        If (Not RouteData.Values("id") Is Nothing) Then
            Dim PageId As Integer = RouteData.Values("id").ToString

            pageItem = pageService.GetOnePage(PageId)
            If pageItem Is Nothing Then
                Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                Exit Sub

            End If
            Dim dateTimeHelper As New DateTimeHelper


            lblNewsSummary.InnerHtml = pageItem.PageSummary
            lblNewsTitle.InnerHtml = pageItem.PageTitle
            lblNewsContent.InnerHtml = pageItem.PageContent
            pagetitle = pageItem.PageTitle


            'menuTitle.InnerText = GetGlobalResourceObject("SharedResource", "menuTitle")
            'homeLink.InnerText = GetGlobalResourceObject("SharedResource", "homeLink")
            'PrintLink.InnerHtml = GetGlobalResourceObject("SharedResource", "PrintLink")
            'TextLink.InnerHtml = GetGlobalResourceObject("SharedResource", "TextLink")
            Page.Title = pagetitle
            AddMetaData()
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
        Dim MetaData As List(Of CLSPagesMetatagsItem) = MetaObj.GetPAGES_METATAGS("NEWS", pageItem.PageId)
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
        url = GetRouteUrl("print-rout", New With {.part = "page", .id = pageItem.PageId, .description = pageItem.PageTitle.ToFriendlyUrl})
        Return url
    End Function

    Public Function SetPrintWordUrl() As String
        Dim url As String = String.Empty
        url = GetRouteUrl("print-word-rout", New With {.part = "page", .id = pageItem.PageId, .description = pageItem.PageTitle.ToFriendlyUrl})
        Return url
    End Function

    Public Function SetTextNewsUrl() As String
        Dim url As String = String.Empty
        url = GetRouteUrl("text-rout", New With {.part = "page", .id = pageItem.PageId, .description = pageItem.PageTitle.ToFriendlyUrl})
        Return url
    End Function

    Public Function SetRssNewsUrl() As String
        Dim url As String = String.Empty
        url = GetRouteUrl("rss-rout", New With {.part = "page", .id = pageItem.PageId, .description = pageItem.PageTitle.ToFriendlyUrl})
        Return url
    End Function

End Class
