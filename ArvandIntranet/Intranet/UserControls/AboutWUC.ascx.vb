
Partial Class UserControls_AboutWUC
    Inherits BaseUserControl

    Public Property PlantDivisionService As IPlantDivisionsService

    Public Sub SetAbout()
        Dim PlantDivision = PlantDivisionService.GetOnePlantDivisions(PlantDivisions.DivisionId)
        lblAboutSummary.InnerHtml = PlantDivision.HtmlContactusPersianSummary
        If Regex.Replace(PlantDivision.HtmlContactusPersian, "<.*?>", String.Empty) <> "" Then
            moreLnk.Visible = True
        Else
            moreLnk.Visible = False
        End If
    End Sub


    Public Function SetAboutUrl() As String
        Dim url As String = String.Empty
        url = GetRouteUrl("default-rout", New With {.pageName = "about", .id = Nothing})
        Return url
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        DataBind()
    End Sub
End Class
