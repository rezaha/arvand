
Imports System.ServiceModel.Security

Partial Class UserControls_PollListWUC
    Inherits BaseUserControl

    Public Property PollsService As IPollService
    Function SetPollLinks(pollId As Integer) As String
        Return GetRouteUrl("default-rout", New With {.pageName = "ShowPoll", .id = pollId})
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            Dim userName = DomainUserService.GetUserName
            Repeater1.DataSource = PollsService.AllPolls().Where(Function(a) a.Active = True And (Not a.PollsFiller.Any(Function(b) b.FillerName = userName)))
            Repeater1.DataBind()
        Else
        End If
    End Sub

End Class
