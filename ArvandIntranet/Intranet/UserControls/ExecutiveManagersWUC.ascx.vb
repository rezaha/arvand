
Partial Class UserControls_ExecutiveManagersWUC
    Inherits BaseUserControl

    Public Property _executiveManagerService As IExecutiveManagerService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim list As List(Of Danesh.ArvandIntranet.DomainClasses.Models.ExecutiveManagers) = _executiveManagerService.GetAllManagers(PlantDivisions.DivisionId)
            Repeater1.DataSource = list
            Repeater1.DataBind()
        End If
    End Sub

    Public Function SetPicture(ByVal item As Danesh.ArvandIntranet.DomainClasses.Models.ExecutiveManagers) As String
        If item.ManagerPicture = "" Then
            Return "~/Images/excutive_manager_thumbnail.png"
        Else
            Return "~/" & item.ManagerPicture
        End If
    End Function


End Class
