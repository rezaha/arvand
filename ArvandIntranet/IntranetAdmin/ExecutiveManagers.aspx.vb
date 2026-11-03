
Partial Class ExecutiveManagers
    Inherits BasePage

    Dim ExecutiveManagersObj As New CLSExecutiveManagers
    Public Property _executiveManagerService As IExecutiveManagerService

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not IsPostBack Then
            Dim PageObj As New CLSPages
            Dim pageName As String = "ExecutiveManagers.aspx"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim list As List(Of Danesh.ArvandIntranet.DomainClasses.Models.ExecutiveManagers) = _executiveManagerService.GetAllManagers(PlantDivisions.DivisionId)
            Repeater1.DataSource = list
            Repeater1.DataBind()
            OtherNewsWUC.loadOtherNews(0)
            OtherAnnouncementsWUC.loadOtherAnnouncements(0)
            'DataList1.DataSource = list
            'DataList1.DataBind()
        End If
    End Sub

    Public Function SetPicture(ByVal item As Danesh.ArvandIntranet.DomainClasses.Models.ExecutiveManagers) As String
        If item.ManagerPicture = "" Then
            Return "~/Images/excutive_manager_thumbnail.png"
        Else
            Return item.ManagerPicture
        End If
    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'If pageCls.Page_title <> "" Then
        '    Title = pageCls.Page_title
        'End If
    End Sub

End Class
