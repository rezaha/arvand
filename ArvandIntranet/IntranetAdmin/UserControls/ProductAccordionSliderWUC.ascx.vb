Imports DaneshArvandSiteDomainClasses.Models

Partial Class UserControls_ProductAccordionSliderWUC
    Inherits BaseUserControl

    Public Property productService As IProductService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Repeater1.DataSource = productService.AllProducts("ProductNo ASC")
        Repeater1.DataBind()
    End Sub

    Protected Function SetProductSummary(ByVal DataItem As Products) As String
        'Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "news", .id = DataItem.NewsId}) & "/" & DataItem.TitlePersian
        'Return url
        If SiteLanguage.ToLower = "fa" Then
            If DataItem.SummaryPersian.Length > 180 Then
                Return DataItem.SummaryPersian.Substring(0, 180) & " ... "
            Else
                Return DataItem.SummaryPersian
            End If
        ElseIf SiteLanguage.ToLower = "en" Then
            If DataItem.SummaryLatin.Length > 180 Then
                Return DataItem.SummaryLatin.Substring(0, 180) & " ... "
            Else
                Return DataItem.SummaryLatin
            End If
        End If
        Return ""
    End Function

    Protected Function SetProductName(ByVal DataItem As Products) As String
        'Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "news", .id = DataItem.NewsId}) & "/" & DataItem.TitlePersian
        'Return url
        If SiteLanguage.ToLower = "fa" Then
            Return DataItem.NamePersian
        ElseIf SiteLanguage.ToLower = "en" Then
            Return DataItem.NameLatin
        End If
        Return ""
    End Function

    Protected Function SetReadMoreUrl(ByVal product As Products) As String
        Dim url As String = ""
        If SiteLanguage.ToLower = "fa" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "product", .id = product.ProductId}) & "/" & Server.HtmlDecode(product.NamePersian.Trim.ToFriendlyUrl())
        ElseIf SiteLanguage.ToLower = "en" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "product", .id = product.ProductId}) & "/" & Server.HtmlDecode(product.NameLatin.Trim.ToFriendlyUrl())
        End If
        Return url
    End Function

End Class
