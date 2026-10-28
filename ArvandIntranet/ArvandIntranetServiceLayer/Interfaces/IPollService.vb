Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public Interface IPollService

Function GetAllPollByDivisionId(divisionId As Integer) As IList(Of Poll) 

           Function AddPolls(ByVal polls As Poll, ByVal err As Dictionary(Of String, String)) As Integer
        Sub EditPolls(ByVal polls As Poll, ByVal err As Dictionary(Of String, String))

        ''' <summary>
        ''' حذف عنصر
        ''' </summary>
        ''' <param name="polls">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Function RemovePolls(ByVal polls As Poll, ByVal err As Dictionary(Of String, String)) As Integer

        ''' <summary>
        ''' تعداد عناصر
        ''' </summary>
        ''' <returns>تعداد</returns>
        Function PollsCount() As Integer

        ''' <summary>
        ''' انتخاب یک عنصر
        ''' </summary>
        ''' <param name="pollId">کد عنصر</param>
        ''' <returns>عنصر مورد نظر</returns>
        Function GetOnePolls(ByVal pollId As Integer) As Poll

        ''' <summary>
        ''' همه عناصر
        ''' </summary>
        ''' <returns>لیستی از عناصر</returns>
        Function AllPolls() As IList(Of Poll)

        ''' <summary>
        ''' نمایش اطلاعات در گرید تلریک
        ''' </summary>
        ''' <param name="startIndex">اندیس شروع</param>
        ''' <param name="pageSize">تعداد سطر ها</param>
        ''' <param name="sortexpression">معیار مرتب سازی</param>
        ''' <returns>لیستی از عناصر</returns>
        Function GetPolls(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of Poll)
    End Interface
End Namespace