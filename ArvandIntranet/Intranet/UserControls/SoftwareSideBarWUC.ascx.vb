
Partial Class UserControls_SoftwareSideBarWUC
    Inherits BaseUserControl

    Public Property _softwareService As ISoftwareService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Repeater1.DataSource = _softwareService.GetAllSoftwares(PlantDivisions.DivisionId)
        Repeater1.DataBind()
    End Sub

    Public Function SetSmallImage(ByVal Item As Danesh.ArvandIntranet.DomainClasses.Models.Software) As String
        Return "~/" & Item.SoftwareSmallIcon
    End Function

End Class
