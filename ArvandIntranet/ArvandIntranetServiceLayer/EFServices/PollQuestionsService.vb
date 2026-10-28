Imports System.Data.Entity
Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.ViewModel

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class PollQuestionsService
        Implements IPollQuestionsService

        Private ReadOnly _uow As IUnitOfWork
        Private ReadOnly _pollsQuestions As IDbSet(Of PollsQuestions)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _pollsQuestions = _uow.Set(Of PollsQuestions)()
        End Sub

        ''' <summary>
        ''' جستجو بر اساس کلید
        ''' </summary>
        ''' <param name="questionId"></param>
        ''' <returns>سوال نظر سنجی</returns>
        Public Function SearchByUnique(ByVal questionId As Integer) As PollsQuestions Implements IPollQuestionsService.SearchByUnique
            Return _pollsQuestions.FirstOrDefault(Function(a) a.QuestionId = questionId)
        End Function

        ''' <summary>
        ''' اضافه کردن عنصر جدید
        ''' </summary>
        ''' <param name="pollsQuestions">عنصر جدید</param>
        ''' <param name="err">مجموعه خطا</param>
        ''' <returns>تعداد سطرهای مورد تغییر</returns>
        Public Function AddPollsQuestions(ByVal pollsQuestions As PollsQuestions, ByVal err As Dictionary(Of String, String)) As Integer Implements IPollQuestionsService.AddPollsQuestions
            _pollsQuestions.Add(pollsQuestions)
            Return _uow.SaveChanges()
        End Function

        ''' <summary>
        ''' ویرایش عنصر
        ''' </summary>
        ''' <param name="pollsQuestions">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Public Sub EditPollsQuestions(ByVal pollsQuestions As PollsQuestions, ByVal err As Dictionary(Of String, String)) Implements IPollQuestionsService.EditPollsQuestions
            _uow.SaveChanges()
        End Sub

        Public Function GetQuestionChart(ByVal questionId As Integer) As List(Of QuestionAnswerChartModel) Implements IPollQuestionsService.GetQuestionChart
            Dim questionCharts = New List(Of QuestionAnswerChartModel)
            Dim question = _pollsQuestions.Include("PollsQuestionsOptions").Include("PollsAnswers").FirstOrDefault(Function(a) a.QuestionId = questionId)
            Dim questionAnswer = question.PollsAnswers
            If (question IsNot Nothing) Then
                Dim guestionOptions = question.PollsQuestionsOptions.ToList()
                For Each item In guestionOptions
                    Dim questionChart = New QuestionAnswerChartModel()
                    questionChart.OptionText = item.OptionText
                    questionChart.AnswerCount = questionAnswer.Where(Function(a) a.AnswerInt = item.OptionNo).Count()
                    questionCharts.Add(questionChart)
                Next
            End If
            Return questionCharts
        End Function

        Public Function GetQuestionAnswerText(ByVal questionId As Integer) As List(Of String) Implements IPollQuestionsService.GetQuestionAnswerText
            Dim questionResult = New List(Of String)
            Dim question = _pollsQuestions.Include("PollsQuestionsOptions").Include("PollsAnswers").FirstOrDefault(Function(a) a.QuestionId = questionId)
            Dim questionAnswer = question.PollsAnswers
            If (question IsNot Nothing) Then
                questionResult.AddRange(From item In questionAnswer Select item.AnswerDescription)
            End If
            Return questionResult
        End Function


        ''' <summary>
        ''' حذف عنصر
        ''' </summary>
        ''' <param name="pollsQuestions">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Public Function RemovePollsQuestions(ByVal pollsQuestions As PollsQuestions, ByVal err As Dictionary(Of String, String)) As Integer Implements IPollQuestionsService.RemovePollsQuestions
            _pollsQuestions.Remove(pollsQuestions)
            Return _uow.SaveChanges()
        End Function

        ''' <summary>
        ''' تعداد سطر ها
        ''' </summary>
        ''' <returns>تعداد</returns>
        Public Function PollsQuestionsCount() As Integer Implements IPollQuestionsService.PollsQuestionsCount
            Return _pollsQuestions.Count()
        End Function

        'INSTANT VB NOTE: This code snippet uses implicit typing. You will need to set 'Option Infer On' in the VB file or set 'Option Infer' at the project level.

        ''' <summary>
        ''' انتخاب یک سوال نظر سنجی
        ''' </summary>
        ''' <param name="questionId">کد یکتای سوال</param>
        ''' <returns>سوال نظر سنجی مورد نظر</returns>
        Public Function GetOnePollsQuestions(ByVal questionId As Integer) As PollsQuestions Implements IPollQuestionsService.GetOnePollsQuestions
            Return _pollsQuestions.FirstOrDefault(Function(a) a.QuestionId = questionId)
        End Function

        ''' <summary>
        ''' همه سوالات
        ''' </summary>
        ''' <returns>لیستی از سوالات</returns>
        Public Function AllPollsQuestions() As IList(Of PollsQuestions) Implements IPollQuestionsService.AllPollsQuestions
            Return _pollsQuestions.ToList()
        End Function

        ''' <summary>
        ''' انتخاب بر اساس کد نظر سنجی
        ''' </summary>
        ''' <param name="pollId">کد نظر سنجی</param>
        ''' <returns>لیستی از سوالات</returns>
        Public Function GetByPollId(ByVal pollId As Integer) As IList(Of PollsQuestions) Implements IPollQuestionsService.GetByPollId
            Return _pollsQuestions.Where(Function(a) a.PollId = pollId).ToList()
        End Function

        ''' <summary>
        ''' انتخاب سوال بر اساس نوع پاسخ نظر سنجی
        ''' </summary>
        ''' <param name="pollId">نظر سنجی مورد نظر</param>
        ''' <param name="answerType">نوع پاسخ</param>
        ''' <returns>لیستی از سوالات</returns>
        Public Function GetByPollIdQuestionType(ByVal pollId As Integer, ByVal answerType As Integer) As IList(Of PollsQuestions) Implements IPollQuestionsService.GetByPollIdQuestionType
            Return _pollsQuestions.Where(Function(a) a.PollId = pollId AndAlso a.AnswerType = answerType).ToList()
        End Function

        ''' <summary>
        ''' نمایش اطلاعات در گرید تلریک
        ''' </summary>
        ''' <param name="startIndex">اندیس شروع</param>
        ''' <param name="pageSize">تعداد سطر ها</param>
        ''' <param name="sortexpression">معیار مرتب سازی</param>
        ''' <returns>لیستی از عناصر</returns>
        Public Function GetPollsQuestions(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of PollsQuestions) Implements IPollQuestionsService.GetPollsQuestions
            If sortexpression = String.Empty Then
                sortexpression = "PollId ASC"
            End If

            Dim sortColumnName As String = sortexpression.Split(" "c)(0)
            Dim sortDirection As String = sortexpression.Split(" "c)(1)
            Dim pollsQuestionsQuery = _pollsQuestions.AsQueryable()
            Select Case sortColumnName
                Case "PollId"
                    pollsQuestionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsQuery.OrderBy(Function(a) a.PollId), pollsQuestionsQuery.OrderByDescending(Function(a) a.PollId)))
                Case "QuestionId"
                    pollsQuestionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsQuery.OrderBy(Function(a) a.QuestionId), pollsQuestionsQuery.OrderByDescending(Function(a) a.QuestionId)))
                Case "QuestionNo"
                    pollsQuestionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsQuery.OrderBy(Function(a) a.QuestionNo), pollsQuestionsQuery.OrderByDescending(Function(a) a.QuestionNo)))
                Case "QuestionDescription"
                    pollsQuestionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsQuery.OrderBy(Function(a) a.QuestionDescription), pollsQuestionsQuery.OrderByDescending(Function(a) a.QuestionDescription)))
                Case "AnswerType"
                    pollsQuestionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsQuery.OrderBy(Function(a) a.AnswerType), pollsQuestionsQuery.OrderByDescending(Function(a) a.AnswerType)))
                Case "QuestionWeight"
                    pollsQuestionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsQuery.OrderBy(Function(a) a.QuestionWeight), pollsQuestionsQuery.OrderByDescending(Function(a) a.QuestionWeight)))
                Case "Remark"
                    pollsQuestionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsQuery.OrderBy(Function(a) a.Remark), pollsQuestionsQuery.OrderByDescending(Function(a) a.Remark)))
            End Select
            Return pollsQuestionsQuery.Skip(startIndex).Take(pageSize).ToList()
        End Function
    End Class

End Namespace




