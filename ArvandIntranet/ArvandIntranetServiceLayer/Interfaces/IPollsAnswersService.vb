Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public interface IPollsAnswersService
        ''' <summary>
        ''' اضافه کردن عنصر جدید
        ''' </summary>
        ''' <param name="pollsAnswers">عنصر جدید</param>
        ''' <param name="err">مجموعه خطا</param>
        ''' <returns>تعداد سطرهای مورد تغییر</returns>
        Function AddPollsAnswers(pollsAnswers As PollsAnswers, err As Dictionary(Of String, String)) As Integer

        ''' <summary>
        ''' ویرایش عنصر
        ''' </summary>
        ''' <param name="pollsAnswers">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        ''' <returns>تعداد عناصر مورد تاثیر</returns>
        Sub EditPollsAnswers(pollsAnswers As PollsAnswers, err As Dictionary(Of String, String))

        ''' <summary>
        ''' حذف عنصر
        ''' </summary>
        ''' <param name="pollsAnswers">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Function RemovePollsAnswers(pollsAnswers As PollsAnswers, err As Dictionary(Of String, String)) As Integer

        ''' <summary>
        ''' تعداد عناصر
        ''' </summary>
        ''' <returns>تعداد</returns>
        Function PollsAnswersCount() As Integer

        ''' <summary>
        ''' انتخاب یک سطر جدول
        ''' </summary>
        ''' <param name="fillerId">کد تکمیل کننده</param>
        ''' <param name="questionId">سوال</param>
        ''' <returns>پاسخ مورد نظر</returns>
        Function GetOnePollsAnswers(fillerId As Integer, questionId As Integer) As PollsAnswers

        ''' <summary>
        ''' همه پاسخ ها
        ''' </summary>
        ''' <returns>لیستی از پاسخ ها</returns>
        Function AllPollsAnswers() As IList(Of PollsAnswers)

        ''' <summary>
        ''' همه پاسخ ها بر اساس تکمیل کننده 
        ''' </summary>
        ''' <param name="fillerId">کد تکمیل کننده</param>
        ''' <returns>لیستی از تکمیل کننده ها</returns>
        Function AllPollsAnswersByPollFiller(fillerId As Integer) As IList(Of PollsAnswers)

        ''' <summary>
        ''' همه پاسخ ها بر اساس سوال خاص
        ''' </summary>
        ''' <param name="questionId">کد سوال</param>
        ''' <returns>لیستی از پاسخ ها</returns>
        Function AllPollsAnswersByPollQuestion(questionId As Integer) As IList(Of PollsAnswers)

        ''' <summary>
        ''' نمایش اطلاعات در گرید تلریک
        ''' </summary>
        ''' <param name="startIndex">اندیس شروع</param>
        ''' <param name="pageSize">تعداد سطر ها</param>
        ''' <param name="sortexpression">معیار مرتب سازی</param>
        ''' <returns>لیستی از عناصر</returns>
        Function GetPollsAnswers(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of PollsAnswers)
    end interface
End NameSpace