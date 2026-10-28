Imports System.Data.Entity
Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices
 
    Public Class PollsAnswersService
        Implements IPollsAnswersService

        Private ReadOnly _uow As IUnitOfWork
        Private ReadOnly _pollsAnswers As IDbSet(Of PollsAnswers)

        Public Sub New(uow As IUnitOfWork)
            _uow = uow
            _pollsAnswers = _uow.Set(Of PollsAnswers)()
        End Sub

      	''' <summary>
		''' اضافه کردن عنصر جدید
		''' </summary>
		''' <param name="pollsAnswers">عنصر جدید</param>
		''' <param name="err">مجموعه خطا</param>
		''' <returns>تعداد سطرهای مورد تغییر</returns>
		Public Function AddPollsAnswers(pollsAnswers As PollsAnswers, err As Dictionary(Of String, String)) As Integer Implements IPollsAnswersService.AddPollsAnswers
			_pollsAnswers.Add(pollsAnswers)
			Return _uow.SaveChanges()
		End Function

		''' <summary>
		''' ویرایش عنصر
		''' </summary>
		''' <param name="pollsAnswers">عنصر مورد نظر</param>
		''' <param name="err">مجموعه خطا</param>
		Public Sub EditPollsAnswers(pollsAnswers As PollsAnswers, err As Dictionary(Of String, String)) Implements IPollsAnswersService.EditPollsAnswers
			_uow.SaveChanges()
		End Sub

		''' <summary>
		''' حذف عنصر
		''' </summary>
		''' <param name="pollsAnswers">عنصر مورد نظر</param>
		''' <param name="err">مجموعه خطا</param>
		Public Function RemovePollsAnswers(pollsAnswers As PollsAnswers, err As Dictionary(Of String, String)) As Integer Implements IPollsAnswersService.RemovePollsAnswers
			_pollsAnswers.Remove(pollsAnswers)
			Return _uow.SaveChanges()
		End Function

		''' <summary>
		''' تعداد عناصر
		''' </summary>
		''' <returns>تعداد</returns>
		Public Function PollsAnswersCount() As Integer Implements IPollsAnswersService.PollsAnswersCount
			Return _pollsAnswers.Count()
		End Function

		''' <summary>
		''' انتخاب یک سطر جدول
		''' </summary>
		''' <param name="fillerId">کد تکمیل کننده</param>
		''' <param name="questionId">سوال</param>
		''' <returns>پاسخ مورد نظر</returns>
		Public Function GetOnePollsAnswers(fillerId As Integer, questionId As Integer) As PollsAnswers Implements IPollsAnswersService.GetOnePollsAnswers
			Return _pollsAnswers.Include(Function(a) a.PollsFiller).Include(Function(a) a.PollsQuestion).FirstOrDefault(Function(a) a.FillerId = fillerId AndAlso a.QuestionId = questionId)
		End Function

		''' <summary>
		''' همه پاسخ ها
		''' </summary>
		''' <returns>لیستی از پاسخ ها</returns>
		Public Function AllPollsAnswers() As IList(Of PollsAnswers) Implements IPollsAnswersService.AllPollsAnswers
			Return _pollsAnswers.Include(Function(a) a.PollsFiller).Include(Function(a) a.PollsQuestion).ToList()
		End Function

		''' <summary>
		''' همه پاسخ ها بر اساس تکمیل کننده 
		''' </summary>
		''' <param name="fillerId">کد تکمیل کننده</param>
		''' <returns>لیستی از تکمیل کننده ها</returns>
		Public Function AllPollsAnswersByPollFiller(fillerId As Integer) As IList(Of PollsAnswers) Implements IPollsAnswersService.AllPollsAnswersByPollFiller
			Return _pollsAnswers.Include(Function(a) a.PollsFiller).Include(Function(a) a.PollsQuestion).Where(Function(a) a.FillerId = fillerId).ToList()
		End Function

		''' <summary>
		''' همه پاسخ ها بر اساس سوال خاص
		''' </summary>
		''' <param name="questionId">کد سوال</param>
		''' <returns>لیستی از پاسخ ها</returns>
		Public Function AllPollsAnswersByPollQuestion(questionId As Integer) As IList(Of PollsAnswers) Implements IPollsAnswersService.AllPollsAnswersByPollQuestion
			Return _pollsAnswers.Include(Function(a) a.PollsFiller).Include(Function(a) a.PollsQuestion).Where(Function(a) a.QuestionId = questionId).ToList()
		End Function

        'INSTANT VB NOTE: This code snippet uses implicit typing. You will need to set 'Option Infer On' in the VB file or set 'Option Infer' at the project level.

  ''' <summary>
		''' نمایش اطلاعات در گرید تلریک
		''' </summary>
		''' <param name="startIndex">اندیس شروع</param>
		''' <param name="pageSize">تعداد سطر ها</param>
		''' <param name="sortexpression">معیار مرتب سازی</param>
		''' <returns>لیستی از عناصر</returns>
		Public Function GetPollsAnswers(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of PollsAnswers) Implements IPollsAnswersService.GetPollsAnswers
			If sortexpression = String.Empty Then
				sortexpression = "FillerId ASC"
			End If

			Dim sortColumnName As String = sortexpression.Split(" "c)(0)
			Dim sortDirection As String = sortexpression.Split(" "c)(1)
			Dim pollsAnswersQuery = _pollsAnswers.Include(Function(a) a.PollsFiller).Include(Function(a) a.PollsQuestion).AsQueryable()
			Select Case sortColumnName
				Case "FillerId"
					pollsAnswersQuery = (If(sortDirection.ToLower() = "asc", pollsAnswersQuery.OrderBy(Function(a) a.FillerId), pollsAnswersQuery.OrderByDescending(Function(a) a.FillerId)))
				Case "QuestionId"
					pollsAnswersQuery = (If(sortDirection.ToLower() = "asc", pollsAnswersQuery.OrderBy(Function(a) a.QuestionId), pollsAnswersQuery.OrderByDescending(Function(a) a.QuestionId)))
				Case "AnswerInt"
					pollsAnswersQuery = (If(sortDirection.ToLower() = "asc", pollsAnswersQuery.OrderBy(Function(a) a.AnswerInt), pollsAnswersQuery.OrderByDescending(Function(a) a.AnswerInt)))
				Case "AnswerDescription"
					pollsAnswersQuery = (If(sortDirection.ToLower() = "asc", pollsAnswersQuery.OrderBy(Function(a) a.AnswerDescription), pollsAnswersQuery.OrderByDescending(Function(a) a.AnswerDescription)))
				Case "Remark"
					pollsAnswersQuery = (If(sortDirection.ToLower() = "asc", pollsAnswersQuery.OrderBy(Function(a) a.Remark), pollsAnswersQuery.OrderByDescending(Function(a) a.Remark)))
			End Select
			Return pollsAnswersQuery.Skip(startIndex).Take(pageSize).ToList()
		End Function
    End Class

End Namespace




