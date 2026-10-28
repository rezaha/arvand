

Partial Class UserControls_OtherPagesWUC
    Inherits BaseUserControl

    Public Property pageService As IPagesService

    Public Sub loadOtherPages(ByVal PageId As Integer)
        Dim pageList = pageService.GetTopPage(0, 5, "PageName ASC", PlantDivisions.DivisionId)
        Dim pageItem = pageList.FirstOrDefault(Function(a) a.PageId = PageId)
        If pageItem IsNot Nothing Then
            pageList.Remove(pageItem)
        End If
        Repeater1.DataSource = pageList
        Repeater1.DataBind()
    End Sub

    Protected Function SetPageUrl(ByVal DataItem As Danesh.ArvandIntranet.DomainClasses.Models.Page) As String
        Dim url As String = ""
        'If SiteLang = "fa" Then
        url = GetRouteUrl("default-rout", New With {.pageName = "ShowPage", .id = DataItem.PageId}) & "/" & Server.HtmlDecode(DataItem.PageTitle.Trim.ToFriendlyUrl())
        'ElseIf SiteLang = "en" Then
        'url = GetRouteUrl("default-rout", New With {.pageName = "ShowPage", .id = DataItem.NewsId}) & "/" & DataItem.TitleLatin
        'End If
        Return url
    End Function

    Protected Function SetPageTitle(ByVal DataItem As Danesh.ArvandIntranet.DomainClasses.Models.Page) As String
        'If SiteLang = "fa" Then
        '    Return DataItem.TitlePersian
        'ElseIf SiteLang = "en" Then
        Return DataItem.PageTitle
        'End If
        'Return ""
    End Function

    Protected Function SetPageSummary(ByVal DataItem As Danesh.ArvandIntranet.DomainClasses.Models.Page) As String
        'If SiteLang = "fa" Then
        '    Return DataItem.PageSummary
        'ElseIf SiteLang = "en" Then
        Return DataItem.PageSummary
        'End If
        'Return ""
    End Function

End Class
