Imports System.Data.Entity
Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class PollQuestionsOptionsService
        Implements IPollQuestionsOptionsService

        Private ReadOnly _uow As IUnitOfWork
        Private ReadOnly _pollsQuestionsOptions As IDbSet(Of PollsQuestionsOptions)

        Public Sub New(uow As IUnitOfWork)
            _uow = uow
            _pollsQuestionsOptions = _uow.Set(Of PollsQuestionsOptions)()
        End Sub

        ''' <summary>
        ''' اضافه کردن عنصر جدید
        ''' </summary>
        ''' <param name="pollsQuestionsOptions">عنصر جدید</param>
        ''' <param name="err">مجموعه خطا</param>
        ''' <returns>تعداد سطرهای مورد تغییر</returns>
        Public Function AddPollsQuestionsOptions(pollsQuestionsOptions As PollsQuestionsOptions, err As Dictionary(Of String, String)) As Integer Implements IPollQuestionsOptionsService.AddPollsQuestionsOptions
            _pollsQuestionsOptions.Add(pollsQuestionsOptions)
            Return _uow.SaveChanges()
        End Function


        Public Function ExistQuestionOption(questionId As Integer, questionNo As Integer) As Boolean Implements IPollQuestionsOptionsService.ExistQuestionOption
            Return _pollsQuestionsOptions.Any(Function(a) a.QuestionId = questionId And a.OptionNo = questionNo)
        End Function


        ''' <summary>
        ''' ویرایش عنصر
        ''' </summary>
        ''' <param name="pollsQuestionsOptions">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Public Sub EditPollsQuestionsOptions(pollsQuestionsOptions As PollsQuestionsOptions, err As Dictionary(Of String, String)) Implements IPollQuestionsOptionsService.EditPollsQuestionsOptions
            _uow.SaveChanges()
        End Sub

        ''' <summary>
        ''' حذف عنصر
        ''' </summary>
        ''' <param name="pollsQuestionsOptions">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Public Function RemovePollsQuestionsOptions(pollsQuestionsOptions As PollsQuestionsOptions, err As Dictionary(Of String, String)) As Integer Implements IPollQuestionsOptionsService.RemovePollsQuestionsOptions
            _pollsQuestionsOptions.Remove(pollsQuestionsOptions)
            Return _uow.SaveChanges()
        End Function


        ''' <summary>
        ''' تعداد عناصر
        ''' </summary>
        ''' <returns>تعداد</returns>
        Public Function PollsQuestionsOptionsCount() As Integer Implements IPollQuestionsOptionsService.PollsQuestionsOptionsCount
            Return _pollsQuestionsOptions.Count()
        End Function

        ''' <summary>
        ''' انتخاب یک گزینه سوال
        ''' </summary>
        ''' <param name="optionId">شناسه یکتا گزینه</param>
        ''' <returns>گزینه مورد نظر</returns>
        Public Function GetOnePollsQuestionsOptions(optionId As Integer) As PollsQuestionsOptions Implements IPollQuestionsOptionsService.GetOnePollsQuestionsOptions
            Return _pollsQuestionsOptions.Include(Function(a) a.PollsQuestions).FirstOrDefault(Function(a) a.OptionId = optionId)
        End Function

        'INSTANT VB NOTE: This code snippet uses implicit typing. You will need to set 'Option Infer On' in the VB file or set 'Option Infer' at the project level.

        ''' <summary>
        ''' انتخاب یک گزینه بر اساس شماره سوال و کد گزینه
        ''' </summary>
        ''' <param name="questionId">کد سوال</param>
        ''' <param name="optionNo">کد گزینه</param>
        ''' <returns>گزینه مورد نظر</returns>
        Public Function GetOneByQuestionIdOptionNo(questionId As Integer, optionNo As Integer) As PollsQuestionsOptions Implements IPollQuestionsOptionsService.GetOneByQuestionIdOptionNo
            Return _pollsQuestionsOptions.Include(Function(a) a.PollsQuestions).FirstOrDefault(Function(a) a.QuestionId = questionId AndAlso a.OptionNo = optionNo)
        End Function

        ''' <summary>
        ''' همه گزینه ها
        ''' </summary>
        ''' <returns>لیستی از گزینه ها</returns>
        Public Function AllPollsQuestionsOptions() As IList(Of PollsQuestionsOptions) Implements IPollQuestionsOptionsService.AllPollsQuestionsOptions
            Return _pollsQuestionsOptions.Include(Function(a) a.PollsQuestions).ToList()
        End Function

        ''' <summary>
        ''' همه بر اساس سوال خاص
        ''' </summary>
        ''' <param name="questionId">کد سوال</param>
        ''' <returns>لیستی از گزینه های سوال</returns>
        Public Function AllPollsQuestionsOptionsByQuestion(questionId As Integer) As IList(Of PollsQuestionsOptions) Implements IPollQuestionsOptionsService.AllPollsQuestionsOptionsByQuestion
            Return _pollsQuestionsOptions.Include(Function(a) a.PollsQuestions).Where(Function(a) a.QuestionId = questionId).ToList()
        End Function

        ''' <summary>
        ''' نمایش اطلاعات در گرید تلریک
        ''' </summary>
        ''' <param name="startIndex">اندیس شروع</param>
        ''' <param name="pageSize">تعداد سطر ها</param>
        ''' <param name="sortexpression">معیار مرتب سازی</param>
        ''' <returns>لیستی از عناصر</returns>
        Public Function GetPollsQuestionsOptions(startIndex As Integer, pageSize As Integer, sortexpression As String) As IList(Of PollsQuestionsOptions) Implements IPollQuestionsOptionsService.GetPollsQuestionsOptions
            If sortexpression = String.Empty Then
                sortexpression = "QuestionId ASC"
            End If

            Dim sortColumnName As String = sortexpression.Split(" "c)(0)
            Dim sortDirection As String = sortexpression.Split(" "c)(1)
            Dim pollsQuestionsOptionsQuery = _pollsQuestionsOptions.Include(Function(a) a.PollsQuestions).AsQueryable()
            Select Case sortColumnName
                Case "QuestionId"
                    pollsQuestionsOptionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsOptionsQuery.OrderBy(Function(a) a.QuestionId), pollsQuestionsOptionsQuery.OrderByDescending(Function(a) a.QuestionId)))
                Case "OptionId"
                    pollsQuestionsOptionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsOptionsQuery.OrderBy(Function(a) a.OptionId), pollsQuestionsOptionsQuery.OrderByDescending(Function(a) a.OptionId)))
                Case "OptionNo"
                    pollsQuestionsOptionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsOptionsQuery.OrderBy(Function(a) a.OptionNo), pollsQuestionsOptionsQuery.OrderByDescending(Function(a) a.OptionNo)))
                Case "OptionText"
                    pollsQuestionsOptionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsOptionsQuery.OrderBy(Function(a) a.OptionText), pollsQuestionsOptionsQuery.OrderByDescending(Function(a) a.OptionText)))
                Case "Active"
                    pollsQuestionsOptionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsOptionsQuery.OrderBy(Function(a) a.Active), pollsQuestionsOptionsQuery.OrderByDescending(Function(a) a.Active)))
                Case "Remark"
                    pollsQuestionsOptionsQuery = (If(sortDirection.ToLower() = "asc", pollsQuestionsOptionsQuery.OrderBy(Function(a) a.Remark), pollsQuestionsOptionsQuery.OrderByDescending(Function(a) a.Remark)))
            End Select
            Return pollsQuestionsOptionsQuery.Skip(startIndex).Take(pageSize).ToList()
        End Function
    End Class

End Namespace




