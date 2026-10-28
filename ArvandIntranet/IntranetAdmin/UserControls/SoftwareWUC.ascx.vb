
Partial Class UserControls_SoftwareWUC
    Inherits BaseUserControl

    Public Property _softwareService As ISoftwareService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Repeater1.DataSource = _softwareService.GetAllSoftwares(PlantDivisions.DivisionId).OrderBy(Function(a) a.SortOrder)
        Repeater1.DataBind()
    End Sub

    Public Function SetLargImage(ByVal Item As Danesh.ArvandIntranet.DomainClasses.Models.Software) As String
        Return "../../" & Item.SoftwareLargIcon
    End Function

End Class
