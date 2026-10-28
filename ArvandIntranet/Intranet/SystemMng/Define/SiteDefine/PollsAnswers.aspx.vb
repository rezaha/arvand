Partial Class SystemMng_Define_SiteDefine_PollsAnswers
    Inherits AdminBasePage

    Public Property PollsService As IPollService
    Public Property PlantDivisionsService As IPlantDivisionsService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GridViewDataBind()
            AddSystemHistory("مشاهده نتیجه نظرسنجی", 0)
        End If
    End Sub

    Protected Sub GridViewDataBind()
        gridview1.DataSource = PollsService.AllPolls()
        gridview1.DataBind()
    End Sub

    Private Sub ShowMessage(Optional ByVal messageTitle As String = "پیام سیستم", Optional ByVal content As String = "",
    Optional ByVal titleIcon As NotifyIcon = NotifyIcon.none, Optional ByVal contentIcon As NotifyIcon = NotifyIcon.none,
    Optional autoCloseDelay As Integer = 1000)
        NotifyMessage.Text = content
        NotifyMessage.Title = messageTitle
        NotifyMessage.TitleIcon = titleIcon.ToString
        NotifyMessage.ContentIcon = contentIcon.ToString
        NotifyMessage.AutoCloseDelay = autoCloseDelay
        NotifyMessage.Show()
    End Sub

 End  Class
