
Partial Class UserControls_DivisionWUC
    Inherits BaseUserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim sitesLinkList = _plantDivisionsService.AllPlantDivision().Where(Function(a) a.DivisionId > 0 And Not a.ParentDivisionId.HasValue).OrderBy(Function(a) a.DivisionOrder)
        Repeater1.DataSource = sitesLinkList
        Repeater1.DataBind()

    End Sub

    Public Function SetTitle(ByVal Item As Danesh.ArvandIntranet.DomainClasses.Models.PlantDivisions) As String

        If SiteLanguage.ToLower = "en" Then
            Return Item.NameLatin
        Else
            Return Item.NamePersian
        End If
    End Function

    Public Function SetIconUrl(ByVal Item As Danesh.ArvandIntranet.DomainClasses.Models.PlantDivisions) As String
        If Item.DivisionIconLink <> "" Then
            If System.IO.File.Exists(Server.MapPath("~" & Item.DivisionIconLink)) Then
                Return Item.DivisionIconLink
            End If
            Return "../../images/section_item.png"
        Else
            Return "../../images/section_item.png"
        End If
    End Function

    Public Function SetDivisionLink(ByVal Item As Danesh.ArvandIntranet.DomainClasses.Models.PlantDivisions) As String
        Return GetRouteUrl("default-rout", New With {.pageName = "default", .divisionAbbr = Item.DivisionAbbr})
    End Function


End Class
