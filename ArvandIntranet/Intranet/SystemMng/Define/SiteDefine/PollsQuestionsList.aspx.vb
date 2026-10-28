
Partial Class SiteMng_Define_PollsQuestionsList
    Inherits AdminBasePage

    Public Property PollsQuestionsService As IPollQuestionsService
    Public Property PollsService As IPollService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim pollId As Integer = Convert.ToInt32(Request.QueryString("pid"))
            ViewState.Add("POLL_ID", pollId)
            lblPoolName.Text = PollsService.GetOnePolls(pollId).PollName
            GridViewDataBind()
        End If
    End Sub

    Protected Sub GridViewDataBind()
        Dim pollId As Integer = Convert.ToInt32(ViewState("POLL_ID"))
        ViewState.Add("POLL_ID", pollId)
        gridview1.DataSource = PollsQuestionsService.GetByPollId(pollId)
        gridview1.DataBind()
    End Sub


    Function GetAnswerTypeText(ByVal answerType As Integer) As String
        Select Case answerType
            Case 1
                Return "چند گزینه ای  چند پاسخه"
            Case 2
                Return "چند گزینه ای تک پاسخه"
            Case 3
                Return "تشریحی"
            Case Else
                Return "نا مشخص"
        End Select
    End Function

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

End Class
