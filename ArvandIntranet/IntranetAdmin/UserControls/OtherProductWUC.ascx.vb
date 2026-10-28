Imports DaneshArvandSiteDomainClasses.Models

Partial Class UserControls_OtherProductWUC
    Inherits BaseUserControl

    Public Property productService As IProductService

    Public Sub loadOtherProducts(ByVal productId As Integer)
        Dim productList = productService.GetProducts(0, 5, "ProductNo ASC")
        Dim productItem = productList.FirstOrDefault(Function(a) a.ProductId = productId)
        If productItem IsNot Nothing Then
            productList.Remove(productItem)
        End If
        Repeater1.DataSource = productList
        Repeater1.DataBind()
    End Sub

    Protected Function SetProductUrl(ByVal DataItem As Products) As String
        Dim url As String = ""
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "Product", .id = DataItem.ProductId}) & "/" & Server.HtmlDecode(DataItem.NamePersian.Trim.ToFriendlyUrl())
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "Product", .id = DataItem.ProductId}) & "/" & Server.HtmlDecode(DataItem.NameLatin.Trim.ToFriendlyUrl())
        End If
        Return url
    End Function

    Protected Function SetProductTitle(ByVal DataItem As Products) As String
        If SiteLanguage = "fa" Then
            Return DataItem.NamePersian
        ElseIf SiteLanguage = "en" Then
            Return DataItem.NameLatin
        End If
        Return ""
    End Function

    Protected Function SetProductSummary(ByVal DataItem As Products) As String
        If SiteLanguage.ToLower = "fa" Then
            If DataItem.SummaryPersian.Length > 220 Then
                Return DataItem.SummaryPersian.Substring(0, 220) & " ... "
            Else
                Return DataItem.SummaryPersian
            End If
        ElseIf SiteLanguage.ToLower = "en" Then
            If DataItem.SummaryLatin.Length > 220 Then
                Return DataItem.SummaryLatin.Substring(0, 220) & " ... "
            Else
                Return DataItem.SummaryLatin
            End If
        End If
        Return ""
    End Function

End Class
