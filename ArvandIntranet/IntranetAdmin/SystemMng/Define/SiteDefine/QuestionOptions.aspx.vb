Imports ArvandIntranetDomainClasses.Models

Partial Class SiteMng_Define_QuestionOptions
    Inherits AdminBasePage

    Public Property PollsQuestionsOptionsService As IPollQuestionsOptionsService
    Public Property PollsQuestionsService As IPollQuestionsService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim questionId As Integer = Convert.ToInt32(Request.QueryString("qid"))
            Dim questionItem = PollsQuestionsService.GetOnePollsQuestions(questionId)
            If questionItem.AnswerType = 3 Then
                ShowMessage(content:="سوال تشریحی می باشد و نمیتوان برای آن گزینه ای تعریف کرد.", titleIcon:=NotifyIcon.Info, contentIcon:=NotifyIcon.Warning)
                btnAdd.Enabled = False
                btnSave.Enabled = False
                btnClear.Enabled = False
                Return
            End If
            ViewState.Add("QUESTION_ID", questionId)
            lblQuestionName.Text = questionItem.Poll.PollName & " - " & questionItem.QuestionDescription
            GridViewDataBind()
            ClearControls()
        End If
    End Sub

    Protected Sub GridViewDataBind()
        Dim questionId As Integer = Convert.ToInt32(ViewState("QUESTION_ID"))
        gridview1.DataSource = PollsQuestionsOptionsService.AllPollsQuestionsOptionsByQuestion(questionId)
        gridview1.DataBind()
    End Sub

    Protected Sub ClearControls()
        ViewState.Remove("OptionId")
        txt_OptionNo.Text = ""
        txt_OptionText.Text = ""
        chk_Active.Checked = True
    End Sub

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

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Page.Validate()
            If IsValid Then

                If(PollsQuestionsOptionsService.ExistQuestionOption(Convert.ToInt32(ViewState("QUESTION_ID")), CType(txt_OptionNo.Text, Integer)))
                    ShowMessage(content:="شماره گزینه تکراری است", titleIcon:=NotifyIcon.Info, contentIcon:=NotifyIcon.Ok)
                    Return
                End If

                Dim item As New PollsQuestionsOptions
                item.QuestionId = Convert.ToInt32(ViewState("QUESTION_ID"))
                item.OptionNo = CType(txt_OptionNo.Text, Integer)
                item.OptionText = txt_OptionText.Text
                item.Active = chk_Active.Checked
                item.Remark = ""
                Dim err As New Dictionary(Of String, String)

                Dim result As Integer = PollsQuestionsOptionsService.AddPollsQuestionsOptions(item, err)
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

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Page.Validate()
            If IsValid Then
                Dim pkeyOptionId As Object = ViewState("OptionId")
                Dim item As PollsQuestionsOptions = PollsQuestionsOptionsService.GetOnePollsQuestionsOptions(CType(pkeyOptionId, Integer))
                item.OptionNo = CType(txt_OptionNo.Text, Integer)
                item.OptionText = txt_OptionText.Text
                item.Active = chk_Active.Checked
                Dim err As New Dictionary(Of String, String)
                PollsQuestionsOptionsService.EditPollsQuestionsOptions(item, err)
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

    Protected Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If IsValid Then
            GridViewDataBind()
            ClearControls()
        End If
    End Sub




    Protected Sub gridview1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles gridview1.ItemCommand
        If e.CommandName = "row-select" Then
            Dim pKeys() As String = e.CommandArgument.ToString().Split(CType("|", Char))
            Dim pkeyOptionId As Integer = CType(pKeys(0), Integer)
            Try
                ViewState("OptionId") = pKeys(0)
                Dim item As PollsQuestionsOptions = PollsQuestionsOptionsService.GetOnePollsQuestionsOptions(pkeyOptionId)
                txt_OptionNo.Text = item.OptionNo.ToString
                txt_OptionText.Text = item.OptionText
                chk_Active.Checked = item.Active
            Catch ex As Exception
                Elmah.ErrorSignal.FromCurrentContext.Raise(ex)
                ShowMessage(content:="خطا در عملیات.", titleIcon:=NotifyIcon.Warning, contentIcon:=NotifyIcon.Warning)
            End Try
        ElseIf e.CommandName = "row-del" Then
            Dim pKeys() As String = e.CommandArgument.ToString().Split(CType("|", Char))
            Dim pkeyOptionId As Integer = CType(pKeys(0), Integer)
            Try
                Dim item As PollsQuestionsOptions = PollsQuestionsOptionsService.GetOnePollsQuestionsOptions(pkeyOptionId)
                Dim err As New Dictionary(Of String, String)
                Dim result As Integer = PollsQuestionsOptionsService.RemovePollsQuestionsOptions(item, err)
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
