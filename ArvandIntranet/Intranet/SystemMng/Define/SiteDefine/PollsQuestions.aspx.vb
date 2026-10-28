
Imports ArvandIntranetDomainClasses.Models

Partial Class SiteMng_Define_PollsQuestions
    Inherits AdminBasePage

    Public Property PollsQuestionsService As IPollQuestionsService
    Public Property PollsService As IPollService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim pollId As Integer = Convert.ToInt32(Request.QueryString("pid"))
            ViewState.Add("POLL_ID", pollId)
            lblPoolName.Text = PollsService.GetOnePolls(pollId).PollName
            GridViewDataBind()
            ClearControls()
        End If
    End Sub

    Protected Sub GridViewDataBind()
        Dim pollId As Integer = Convert.ToInt32(ViewState("POLL_ID"))
        ViewState.Add("POLL_ID", pollId)
        gridview1.DataSource = PollsQuestionsService.GetByPollId(pollId)
        gridview1.DataBind()
    End Sub

    Protected Sub ClearControls()
        ViewState.Remove("QuestionId")
        drpAnswerType.SelectedIndex = 0
        txt_QuestionNo.Text = ""
        txt_QuestionDescription.Text = ""
    End Sub

    Function GetAnswerTypeText(ByVal answerType As Integer) As String
        Select Case AnswerType
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
    Optional ByVal titleIcon As NotifyIcon = NotifyIcon.None, Optional ByVal contentIcon As NotifyIcon = NotifyIcon.None,
    Optional autoCloseDelay As Integer = 1000)
        NotifyMessage.Text = content
        NotifyMessage.Title = messageTitle
        NotifyMessage.TitleIcon = titleIcon.ToString
        NotifyMessage.ContentIcon = contentIcon.ToString
        NotifyMessage.AutoCloseDelay = autoCloseDelay
        NotifyMessage.Show()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Page.Validate()
            If IsValid Then
                Dim item As New PollsQuestions
                item.PollId = Convert.ToInt32(ViewState("POLL_ID"))
                item.QuestionNo = CType(txt_QuestionNo.Text, Integer)
                item.QuestionDescription = txt_QuestionDescription.Text
                item.AnswerType = CType(drpAnswerType.SelectedValue, Integer)
                item.QuestionWeight = 1
                item.Remark = ""
                Dim err As New Dictionary(Of String, String)
                Dim result As Integer = PollsQuestionsService.AddPollsQuestions(item, err)
                If result > 0 Then
                    ShowMessage(content:="عملیات اضافه کردن با موفقیت انجام شد", titleIcon:=NotifyIcon.Info, contentIcon:=NotifyIcon.Ok)
                    GridViewDataBind()
                    ClearControls()
                Else
                    Dim errString As String = err.Aggregate(String.Empty, Function(current, errItem) current & (errItem.Value & "<br />"))
                    ShowMessage(content:="خطا در عملیات.لطفا موارد زیر را اصلاح نمایید:<br />" & errString, titleIcon:=NotifyIcon.Info, contentIcon:=NotifyIcon.Warning)
                End If
            End If
        Catch ex As Exception
            Elmah.ErrorSignal.FromCurrentContext.Raise(ex)
            ShowMessage(content:="خطا در عملیات.", titleIcon:=NotifyIcon.Warning, contentIcon:=NotifyIcon.Warning)
        End Try
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Page.Validate()
            If IsValid Then
                Dim pkeyQuestionId As Integer = CType(ViewState("QuestionId"), Integer)
                Dim item As PollsQuestions = PollsQuestionsService.GetOnePollsQuestions(pkeyQuestionId)
                item.QuestionNo = CType(txt_QuestionNo.Text, Integer)
                item.QuestionDescription = txt_QuestionDescription.Text
                item.AnswerType = CType(drpAnswerType.SelectedValue, Integer)
                Dim err As New Dictionary(Of String, String)
                PollsQuestionsService.EditPollsQuestions(item, err)
                If err.Count = 0 Then
                    ShowMessage(content:="عملیات ویرایش با موفقیت انجام شد", titleIcon:=NotifyIcon.Info, contentIcon:=NotifyIcon.Ok)
                    GridViewDataBind()
                    ClearControls()
                Else
                    Dim errString As String = err.Aggregate(String.Empty, Function(current, errItem) current & (errItem.Value & "<br />"))
                    ShowMessage(content:="خطا در عملیات.لطفا موارد زیر را اصلاح نمایید:<br />" & errString, titleIcon:=NotifyIcon.Info, contentIcon:=NotifyIcon.Warning)
                End If
            Else
                ShowMessage(content:="لطفا یک ردیف را انتخاب کنید!", titleIcon:=NotifyIcon.Info, contentIcon:=NotifyIcon.Warning)
            End If
        Catch ex As Exception
            Elmah.ErrorSignal.FromCurrentContext.Raise(ex)
            ShowMessage(content:="خطا در عملیات.", titleIcon:=NotifyIcon.Warning, contentIcon:=NotifyIcon.Warning)
        End Try
    End Sub

    Protected Sub btnReload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        If IsValid Then
            GridViewDataBind()
            ClearControls()
        End If
    End Sub


    Protected Sub gridview1_ItemCommand(ByVal sender As Object, ByVal e As GridCommandEventArgs) Handles gridview1.ItemCommand
        If e.CommandName = "row-select" Then
            Dim pKeys() As String = e.CommandArgument.ToString().Split(CType("|", Char))
            Dim pkeyQuestionId As Integer = CType(pKeys(0), Integer)
            Try
                ViewState("QuestionId") = pKeys(0)
                Dim item As PollsQuestions = PollsQuestionsService.GetOnePollsQuestions(pkeyQuestionId)
                txt_QuestionNo.Text = item.QuestionNo.ToString
                txt_QuestionDescription.Text = item.QuestionDescription
                drpAnswerType.SelectedValue = item.AnswerType.ToString
            Catch ex As Exception
                Elmah.ErrorSignal.FromCurrentContext.Raise(ex)
                ShowMessage(content:="خطا در عملیات.", titleIcon:=NotifyIcon.Warning, contentIcon:=NotifyIcon.Warning)
            End Try
        ElseIf e.CommandName = "row-del" Then
            Dim pKeys() As String = e.CommandArgument.ToString().Split(CType("|", Char))
            Dim pkeyQuestionId As Integer = CType(pKeys(0), Integer)
            Try
                Dim item As PollsQuestions = PollsQuestionsService.GetOnePollsQuestions(pkeyQuestionId)
                Dim err As New Dictionary(Of String, String)
                Dim result As Integer = PollsQuestionsService.RemovePollsQuestions(item, err)
                If result > 0 Then
                    ShowMessage(content:="عملیات حذف کردن با موفقیت انجام شد", titleIcon:=NotifyIcon.Info, contentIcon:=NotifyIcon.Ok)
                    GridViewDataBind()
                    ClearControls()
                Else
                    ShowMessage(content:="به علت وجود رابطه عملیات امکانپذیر نمیباشد.", titleIcon:=NotifyIcon.Warning, contentIcon:=NotifyIcon.Warning)
                End If
            Catch ex As Exception
                Elmah.ErrorSignal.FromCurrentContext.Raise(ex)
                ShowMessage(content:="به علت وجود رابطه عملیات امکانپذیر نمیباشد.", titleIcon:=NotifyIcon.Warning, contentIcon:=NotifyIcon.Warning)
            End Try
        End If
    End Sub



End Class
