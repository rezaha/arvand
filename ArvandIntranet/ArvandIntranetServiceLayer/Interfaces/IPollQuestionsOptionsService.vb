Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public interface IPollQuestionsOptionsService

Function ExistQuestionOption(questionId As Integer, questionNo As Integer) As Boolean 

        ''' <summary>
        ''' اضافه کردن عنصر جدید
        ''' </summary>
        ''' <param name="pollsQuestionsOptions">عنصر جدید</param>
        ''' <param name="err">مجموعه خطا</param>
        ''' <returns>تعداد سطرهای مورد تغییر</returns>
        Function AddPollsQuestionsOptions(pollsQuestionsOptions As PollsQuestionsOptions, err As Dictionary(Of String, String)) As Integer

        ''' <summary>
        ''' ویرایش عنصر
        ''' </summary>
        ''' <param name="pollsQuestionsOptions">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Sub EditPollsQuestionsOptions(pollsQuestionsOptions As PollsQuestionsOptions, err As Dictionary(Of String, String))

        ''' <summary>
        ''' حذف عنصر
        ''' </summary>
        ''' <param name="pollsQuestionsOptions">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Function RemovePollsQuestionsOptions(pollsQuestionsOptions As PollsQuestionsOptions, err As Dictionary(Of String, String)) As Integer

        ''' <summary>
        ''' تعداد عناصر
        ''' </summary>
        ''' <returns>تعداد</returns>
        Function PollsQuestionsOptionsCount() As Integer

        ''' <summary>
        ''' انتخاب یک گزینه سوال
        ''' </summary>
        ''' <param name="optionId">شناسه یکتا گزینه</param>
        ''' <returns>گزینه مورد نظر</returns>
        Function GetOnePollsQuestionsOptions(optionId As Integer) As PollsQuestionsOptions

        ''' <summary>
        ''' انتخاب یک گزینه بر اساس شماره سوال و کد گزینه
        ''' </summary>
        ''' <param name="questionId">کد سوال</param>
        ''' <param name="optionNo">کد گزینه</param>
        ''' <returns>گزینه مورد نظر</returns>
        Function GetOneByQuestionIdOptionNo(questionId As Integer, optionNo As Integer) As PollsQuestionsOptions

        ''' <summary>
        ''' همه گزینه ها
        ''' </summary>
        ''' <returns>لیستی از گزینه ها</returns>
        Function AllPollsQuestionsOptions() As IList(Of PollsQuestionsOptions)

        ''' <summary>
        ''' همه بر اساس سوال خاص
        ''' </summary>
        ''' <param name="questionId">کد سوال</param>
        ''' <returns>لیستی از گزینه های سوال</returns>
        Function AllPollsQuestionsOptionsByQuestion(questionId As Integer) As IList(Of PollsQuestionsOptions)

        ''' <summary>
        ''' نمایش اطلاعات در گرید تلریک
        ''' </summary>
        ''' <param name="startIndex">اندیس شروع</param>
        ''' <param name="pageSize">تعداد سطر ها</param>
        ''' <param name="sortexpression">معیار مرتب سازی</param>
        ''' <returns>لیستی از عناصر</returns>
        Function GetPollsQuestionsOptions(startIndex As Integer, pageSize As Integer, sortexpression As String) As IList(Of PollsQuestionsOptions)
    end interface
End NameSpace