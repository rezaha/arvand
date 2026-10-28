Imports System.Globalization
Imports ArvandIntranetDomainClasses.Models

Partial Class ShowPoll
    Inherits BasePage

    Public Property PollsQuestionsService As IPollQuestionsService
    Public Property PollsService As IPollService
    Public Property PollsFillerService As IPollsFillerService
    Public Property PollsQuestionsOptionsService As IPollQuestionsOptionsService
    Public Property PollsAnswersService As IPollsAnswersService



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If RouteData.Values("id") IsNot Nothing And RouteData.Values("id").ToString() <> "" Then
                Dim pollId As Integer = Convert.ToInt32(RouteData.Values("id"))
                Dim pollItem = PollsService.GetOnePolls(pollId)
                ViewState.Add("POLL_ID", pollId)
                If pollItem IsNot Nothing Then
                    Title = pollItem.PollName
                    'lblPollName.Text = pollItem.PollName
                    BindLists()
                Else
                    pagePannel.Visible = False
                    Return
                End If
            Else
                pagePannel.Visible = False
                Return
            End If
        End If
    End Sub

    Protected Sub lnkAccept_Click(sender As Object, e As EventArgs) Handles lnkAccept.Click
        Validate()
        If IsValid Then
            If HttpContext.Current.User.Identity.IsAuthenticated Then
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('کاربر ناشناس میباشد.')", True)
                Return
            End If
            'For i As Integer = 0 To Repeater1.Items.Count - 1
            '    Dim Rlist As CheckBoxList = Repeater1.Items(i).FindControl("chkLstQuestionOption")
            '    If Rlist.SelectedIndex < 0 Then
            '        If SiteLanguage.ToLower = "fa" Then
            '            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "SetMessage('لطفا به همه سوالات پاسخ دهید.')", True)
            '        Else
            '            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "SetMessage('Please Answer All Question.')", True)
            '        End If
            '        Return
            '    End If
            'Next

            For i = 0 To Repeater2.Items.Count - 1
                Dim rlist = CType(Repeater2.Items(i).FindControl("rbtnAnswers"), RadioButtonList)
                If rlist.SelectedIndex < 0 Then
                    If SiteLanguage.ToLower = "fa" Then
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('لطفا به همه سوالات چند گزینه ای پاسخ دهید.')", True)
                    Else
                        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('Please Answer All Multi Choose Question.')", True)
                    End If
                    Return
                End If
            Next

            Dim pollFiller = _PollsFillerService.GetOnePollFiller(Convert.ToInt32(ViewState("POLL_ID")), DomainUserService.GetUserName)

            If (pollFiller IsNot Nothing) Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('شما قبلا به این نظر سنجی پاسخ داده اید.')", True)
                Return 
            End If

            Dim item As New PollsFiller
            item.FillDate = GetNowDate()
            item.FillerCompany = ""
            item.FillerEmail = ""
            item.FillerIp = Request.UserHostAddress
            item.FillerName = DomainUserService.GetUserName
            item.FillerNo = 1
            item.FillerTel = ""
            item.FillTime = Now.ToString("HH:mm")
            item.PollId = Convert.ToInt32(ViewState("POLL_ID"))
            '  Item.Remark = txtCMore.Text
            Dim rowEffect As Integer = _PollsFillerService.AddPollsFiller(item, New Dictionary(Of String, String))

            If rowEffect > 0 Then
                Dim fillerId As Integer = item.FillerId

                'For i = 0 To Repeater1.Items.Count - 1
                '    Dim HFQuestionid As HiddenField = Repeater1.Items(i).FindControl("HfQID")
                '    Dim ChklstQoptions As CheckBoxList = Repeater1.Items(i).FindControl("chkLstQuestionOption")

                '    Dim PollAnswerItem As New PollsAnswer
                '    Dim AnswerDescription = ""
                '    For Each OptionItem As ListItem In ChklstQoptions.Items
                '        AnswerDescription &= OptionItem.Value & ":" & IIf(OptionItem.Selected = True, "1", "0") & "|"
                '    Next
                '    PollAnswerItem.AnswerDescription = AnswerDescription
                '    PollAnswerItem.AnswerInt = Nothing
                '    PollAnswerItem.FillerId = FillerId
                '    PollAnswerItem.QuestionId = Convert.ToInt32(HFQuestionid.Value)
                '    PollAnswerItem.Remark = ""
                '    _pollsAnswersService.AddPollsAnswers(PollAnswerItem, New Dictionary(Of String, String))
                'Next

                For i = 0 To Repeater2.Items.Count - 1
                    Dim hfQuestionid = CType(Repeater2.Items(i).FindControl("HfQID"), HiddenField)
                    Dim rbtnAnswers = CType(Repeater2.Items(i).FindControl("rbtnAnswers"), RadioButtonList)
                    Dim pollAnswerItem As New PollsAnswers
                    Dim AnswerDescription = ""
                    pollAnswerItem.AnswerDescription = AnswerDescription
                    pollAnswerItem.AnswerInt = CType(rbtnAnswers.SelectedValue, Integer?)
                    pollAnswerItem.FillerId = fillerId
                    pollAnswerItem.QuestionId = Convert.ToInt32(hfQuestionid.Value)
                    pollAnswerItem.Remark = ""
                    _PollsAnswersService.AddPollsAnswers(pollAnswerItem, New Dictionary(Of String, String))
                Next

                For i = 0 To Repeater3.Items.Count - 1
                    Dim hfQuestionid = CType(Repeater3.Items(i).FindControl("HfQID"), HiddenField)
                    Dim txtAnswerDescription = CType(Repeater3.Items(i).FindControl("txtAnswerDescription"), TextBox)
                    If txtAnswerDescription.Text <> "" Then
                        Dim pollAnswerItem As New PollsAnswers
                        Dim answerDescription As String = txtAnswerDescription.Text
                        pollAnswerItem.AnswerDescription = answerDescription
                        pollAnswerItem.AnswerInt = Nothing
                        pollAnswerItem.FillerId = fillerId
                        pollAnswerItem.QuestionId = Convert.ToInt32(hfQuestionid.Value)
                        pollAnswerItem.Remark = ""
                        _PollsAnswersService.AddPollsAnswers(pollAnswerItem, New Dictionary(Of String, String))
                    End If
                Next
                If SiteLanguage.ToLower = "fa" Then
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('نظرات شما ثبت شد.')", True)
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('Poll Is Submited.')", True)
                End If
                Cleare()
            End If

        Else
            If SiteLanguage.ToLower = "fa" Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('لطفا خطاهای موجود در صفحه را بررسی کنید.')", True)
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('Please Check Error in Page.')", True)
            End If
        End If
    End Sub


    Public Function GetNowDate() As String
        Dim ps As New PersianCalendar()
        Dim curYear = ""
        curYear &= ps.GetYear(Now).ToString().Substring(2)

        If ps.GetMonth(Now).ToString().Length = 1 Then
            curYear &= "/0" & ps.GetMonth(Now).ToString()
        Else
            curYear &= "/" & ps.GetMonth(Now).ToString()
        End If

        If ps.GetDayOfMonth(Now).ToString().Length = 1 Then
            curYear &= "/0" & ps.GetDayOfMonth(Now).ToString()
        Else
            curYear &= "/" & ps.GetDayOfMonth(Now).ToString()
        End If

        Return curYear
    End Function

    Sub BindLists()
        Dim pollId As Integer = Convert.ToInt32(ViewState("POLL_ID"))
        ' Dim repeater1Datasource = PollsQuestionsService.GetByPollIdQuestionType(pollId, 1)
        'Repeater1.DataSource = repeater1Datasource
        'Repeater1.DataBind()

        'For i = 0 To Repeater1.Items.Count - 1
        '    Dim hf = CType(Repeater1.Items(i).FindControl("HfQID"), HiddenField)
        '    Dim rlist = CType(Repeater1.Items(i).FindControl("chkLstQuestionOption"), CheckBoxList)
        '    Dim qOptions = PollsQuestionsOptionsService.AllPollsQuestionsOptionsByQuestion(Integer.Parse(hf.Value)).Where(Function(a) a.Active = True)
        '    For Each item In qOptions
        '        rlist.Items.Add(New ListItem With {.Text = item.OptionText, .Value = CType(item.OptionNo, String)})
        '    Next
        'Next

        Dim repeater2Datasource = PollsQuestionsService.GetByPollIdQuestionType(pollId, 2)
        Repeater2.DataSource = repeater2Datasource
        Repeater2.DataBind()

        For i = 0 To Repeater2.Items.Count - 1
            Dim hf = CType(Repeater2.Items(i).FindControl("HfQID"), HiddenField)
            Dim rlist = CType(Repeater2.Items(i).FindControl("rbtnAnswers"), RadioButtonList)
            Dim qAnswers = PollsQuestionsOptionsService.AllPollsQuestionsOptionsByQuestion(Integer.Parse(hf.Value)).Where(Function(a) a.Active = True)
            For Each item In qAnswers
                rlist.Items.Add(New ListItem With {.Text = item.OptionText, .Value = CType(item.OptionNo, String)})
            Next
        Next

        Dim repeater3Datasource = PollsQuestionsService.GetByPollIdQuestionType(pollId, 3)
        Repeater3.DataSource = repeater3Datasource
        Repeater3.DataBind()
    End Sub

    Public Function SetHomePageUrl() As String
        Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "default"})
        Return url
    End Function


    Protected Sub lnkCleare_Click(sender As Object, e As EventArgs) Handles lnkCleare.Click
        Cleare()
    End Sub

    Sub Cleare()
        BindLists()
    End Sub

End Class
