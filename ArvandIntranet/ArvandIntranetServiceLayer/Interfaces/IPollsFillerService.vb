Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public interface IPollsFillerService

Function GetOnePollFiller(pollId As Integer, userName As String) As PollsFiller 

        ''' <summary>
        ''' اضافه کردن عنصر جدید
        ''' </summary>
        ''' <param name="pollsFiller">عنصر جدید</param>
        ''' <param name="err">مجموعه خطا</param>
        ''' <returns>تعداد سطرهای مورد تغییر</returns>
        Function AddPollsFiller(pollsFiller As PollsFiller, err As Dictionary(Of String, String)) As Integer

        ''' <summary>
        ''' ویرایش عنصر
        ''' </summary>
        ''' <param name="pollsFiller">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Sub EditPollsFiller(pollsFiller As PollsFiller, err As Dictionary(Of String, String))

        ''' <summary>
        ''' حذف عنصر
        ''' </summary>
        ''' <param name="pollsFiller">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Function RemovePollsFiller(pollsFiller As PollsFiller, err As Dictionary(Of String, String)) As Integer

        ''' <summary>
        ''' تعداد عناصر
        ''' </summary>
        ''' <returns>تعداد</returns>
        Function PollsFillerCount() As Integer

        ''' <summary>
        ''' انتخاب یک تکمیل کننده نظر سنجی
        ''' </summary>
        ''' <param name="fillerId">کد تکمیل کننده</param>
        ''' <returns>تکمیل کننده مورد نظر</returns>
        Function GetOnePollsFiller(fillerId As Integer) As PollsFiller

        ''' <summary>
        ''' همه تکمیل کننده ها
        ''' </summary>
        ''' <returns>لیستی از تکمیل کننده ها</returns>
        Function AllPollsFiller() As IList(Of PollsFiller)

        ''' <summary>
        ''' همه بر اساس یک نظر سنجی خاص
        ''' </summary>
        ''' <param name="pollId">کد نظر سنجی</param>
        ''' <returns>لیستس از تکمیل کننده ها</returns>
        Function AllPollsFillerByPollId(pollId As Integer) As IList(Of PollsFiller)

        ''' <summary>
        ''' نمایش اطلاعات در گرید تلریک
        ''' </summary>
        ''' <param name="startIndex">اندیس شروع</param>
        ''' <param name="pageSize">تعداد سطر ها</param>
        ''' <param name="sortexpression">معیار مرتب سازی</param>
        ''' <returns>لیستی از عناصر</returns>
        Function GetPollsFiller(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of PollsFiller)
    end interface
End NameSpace