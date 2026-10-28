
Partial Class About
    Inherits BasePage

    Public Property PlantDivisionService As IPlantDivisionsService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim PlantDivision = PlantDivisionService.GetOnePlantDivisions(PlantDivisions.DivisionId)
            lblNewsContent.InnerHtml = PlantDivision.HtmlContactusPersian
            lblNewsSummary.InnerHtml = PlantDivision.HtmlContactusPersianSummary
            lblNewsTitle.InnerText = "پیغام فوری"

        End If
    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If SiteLanguage = "fa" Then
            Title = "پیغام فوری"
        Else
            Title = "پیغام فوری"
        End If
    End Sub

    Public Function SetHomePageUrl() As String
        Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "default"})
        Return url
    End Function

End Class
