Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports Danesh.ArvandIntranet.DomainClasses.ViewModel

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public Interface IPollQuestionsService

Function GetQuestionAnswerText(questionId As Integer) As List(Of String) 

        Function GetQuestionChart(questionId As Integer) As List(Of QuestionAnswerChartModel)

        ''' <summary>
        ''' جستجو بر اساس کلید
        ''' </summary>
        ''' <param name="questionId"></param>
        ''' <returns>سوال نظر سنجی</returns>
        Function SearchByUnique(ByVal questionId As Integer) As PollsQuestions

        ''' <summary>
        ''' اضافه کردن عنصر جدید
        ''' </summary>
        ''' <param name="pollsQuestions">عنصر جدید</param>
        ''' <param name="err">مجموعه خطا</param>
        ''' <returns>تعداد سطرهای مورد تغییر</returns>
        Function AddPollsQuestions(ByVal pollsQuestions As PollsQuestions, ByVal err As Dictionary(Of String, String)) As Integer

        ''' <summary>
        ''' ویرایش عنصر
        ''' </summary>
        ''' <param name="pollsQuestions">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Sub EditPollsQuestions(ByVal pollsQuestions As PollsQuestions, ByVal err As Dictionary(Of String, String))

        ''' <summary>
        ''' حذف عنصر
        ''' </summary>
        ''' <param name="pollsQuestions">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Function RemovePollsQuestions(ByVal pollsQuestions As PollsQuestions, ByVal err As Dictionary(Of String, String)) As Integer

        ''' <summary>
        ''' تعداد سطر ها
        ''' </summary>
        ''' <returns>تعداد</returns>
        Function PollsQuestionsCount() As Integer

        ''' <summary>
        ''' انتخاب یک سوال نظر سنجی
        ''' </summary>
        ''' <param name="questionId">کد یکتای سوال</param>
        ''' <returns>سوال نظر سنجی مورد نظر</returns>
        Function GetOnePollsQuestions(ByVal questionId As Integer) As PollsQuestions

        ''' <summary>
        ''' همه سوالات
        ''' </summary>
        ''' <returns>لیستی از سوالات</returns>
        Function AllPollsQuestions() As IList(Of PollsQuestions)

        ''' <summary>
        ''' انتخاب بر اساس کد نظر سنجی
        ''' </summary>
        ''' <param name="pollId">کد نظر سنجی</param>
        ''' <returns>لیستی از سوالات</returns>
        Function GetByPollId(ByVal pollId As Integer) As IList(Of PollsQuestions)

        ''' <summary>
        ''' انتخاب سوال بر اساس نوع پاسخ نظر سنجی
        ''' </summary>
        ''' <param name="pollId">نظر سنجی مورد نظر</param>
        ''' <param name="answerType">نوع پاسخ</param>
        ''' <returns>لیستی از سوالات</returns>
        Function GetByPollIdQuestionType(ByVal pollId As Integer, ByVal answerType As Integer) As IList(Of PollsQuestions)

        ''' <summary>
        ''' نمایش اطلاعات در گرید تلریک
        ''' </summary>
        ''' <param name="startIndex">اندیس شروع</param>
        ''' <param name="pageSize">تعداد سطر ها</param>
        ''' <param name="sortexpression">معیار مرتب سازی</param>
        ''' <returns>لیستی از عناصر</returns>
        Function GetPollsQuestions(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of PollsQuestions)
    End Interface
End Namespace