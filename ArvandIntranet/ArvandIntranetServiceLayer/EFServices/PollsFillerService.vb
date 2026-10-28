Imports System.Data.Entity
Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class PollsFillerService
        Implements IPollsFillerService

        Private ReadOnly _uow As IUnitOfWork
        Private ReadOnly _pollsFiller As IDbSet(Of PollsFiller)

        Public Sub New(uow As IUnitOfWork)
            _uow = uow
            _pollsFiller = _uow.Set(Of PollsFiller)()
        End Sub
        ''' <summary>
        ''' اضافه کردن عنصر جدید
        ''' </summary>
        ''' <param name="pollsFiller">عنصر جدید</param>
        ''' <param name="err">مجموعه خطا</param>
        ''' <returns>تعداد سطرهای مورد تغییر</returns>
        Public Function AddPollsFiller(pollsFiller As PollsFiller, err As Dictionary(Of String, String)) As Integer Implements IPollsFillerService.AddPollsFiller
            _pollsFiller.Add(pollsFiller)
            Return _uow.SaveChanges()
        End Function

        ''' <summary>
        ''' ویرایش عنصر
        ''' </summary>
        ''' <param name="pollsFiller">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Public Sub EditPollsFiller(pollsFiller As PollsFiller, err As Dictionary(Of String, String)) Implements IPollsFillerService.EditPollsFiller
            _uow.SaveChanges()
        End Sub

        ''' <summary>
        ''' حذف عنصر
        ''' </summary>
        ''' <param name="pollsFiller">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Public Function RemovePollsFiller(pollsFiller As PollsFiller, err As Dictionary(Of String, String)) As Integer Implements IPollsFillerService.RemovePollsFiller
            _pollsFiller.Remove(pollsFiller)
            Return _uow.SaveChanges()
        End Function

        ''' <summary>
        ''' تعداد عناصر
        ''' </summary>
        ''' <returns>تعداد</returns>
        Public Function PollsFillerCount() As Integer Implements IPollsFillerService.PollsFillerCount
            Return _pollsFiller.Count()
        End Function

        ''' <summary>
        ''' انتخاب یک تکمیل کننده نظر سنجی
        ''' </summary>
        ''' <param name="fillerId">کد تکمیل کننده</param>
        ''' <returns>تکمیل کننده مورد نظر</returns>
        Public Function GetOnePollsFiller(fillerId As Integer) As PollsFiller Implements IPollsFillerService.GetOnePollsFiller
            Return _pollsFiller.Include(Function(a) a.Poll).FirstOrDefault(Function(a) a.FillerId = fillerId)
        End Function

        ''' <summary>
        ''' همه تکمیل کننده ها
        ''' </summary>
        ''' <returns>لیستی از تکمیل کننده ها</returns>
        Public Function AllPollsFiller() As IList(Of PollsFiller) Implements IPollsFillerService.AllPollsFiller
            Return _pollsFiller.Include(Function(a) a.Poll).ToList()
        End Function

        ''' <summary>
        ''' همه بر اساس یک نظر سنجی خاص
        ''' </summary>
        ''' <param name="pollId">کد نظر سنجی</param>
        ''' <returns>لیستس از تکمیل کننده ها</returns>
        Public Function AllPollsFillerByPollId(pollId As Integer) As IList(Of PollsFiller) Implements IPollsFillerService.AllPollsFillerByPollId
            Return _pollsFiller.Include(Function(a) a.Poll).Where(Function(a) a.PollId = pollId).ToList()
        End Function

        Public Function GetOnePollFiller(pollId As Integer, userName As String) As PollsFiller Implements IPollsFillerService.GetOnePollFiller
            Return _pollsFiller.Include(Function(a) a.Poll).FirstOrDefault(Function(a) a.PollId = pollId And a.FillerName = userName)
        End Function

        'INSTANT VB NOTE: This code snippet uses implicit typing. You will need to set 'Option Infer On' in the VB file or set 'Option Infer' at the project level.

        ''' <summary>
        ''' نمایش اطلاعات در گرید تلریک
        ''' </summary>
        ''' <param name="startIndex">اندیس شروع</param>
        ''' <param name="pageSize">تعداد سطر ها</param>
        ''' <param name="sortexpression">معیار مرتب سازی</param>
        ''' <returns>لیستی از عناصر</returns>
        Public Function GetPollsFiller(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of PollsFiller) Implements IPollsFillerService.GetPollsFiller
            If sortexpression = String.Empty Then
                sortexpression = "PollId ASC"
            End If

            Dim sortColumnName As String = sortexpression.Split(" "c)(0)
            Dim sortDirection As String = sortexpression.Split(" "c)(1)
            Dim pollsFillerQuery = _pollsFiller.Include(Function(a) a.Poll).AsQueryable()
            Select Case sortColumnName
                Case "PollId"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.PollId), pollsFillerQuery.OrderByDescending(Function(a) a.PollId)))
                Case "FillerId"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.FillerId), pollsFillerQuery.OrderByDescending(Function(a) a.FillerId)))
                Case "FillerNo"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.FillerNo), pollsFillerQuery.OrderByDescending(Function(a) a.FillerNo)))
                Case "FillerName"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.FillerName), pollsFillerQuery.OrderByDescending(Function(a) a.FillerName)))
                Case "FillerCompany"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.FillerCompany), pollsFillerQuery.OrderByDescending(Function(a) a.FillerCompany)))
                Case "FillerTel"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.FillerTel), pollsFillerQuery.OrderByDescending(Function(a) a.FillerTel)))
                Case "FillerEmail"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.FillerEmail), pollsFillerQuery.OrderByDescending(Function(a) a.FillerEmail)))
                Case "FillDate"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.FillDate), pollsFillerQuery.OrderByDescending(Function(a) a.FillDate)))
                Case "FillTime"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.FillTime), pollsFillerQuery.OrderByDescending(Function(a) a.FillTime)))
                Case "FillerIp"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.FillerIp), pollsFillerQuery.OrderByDescending(Function(a) a.FillerIp)))
                Case "Remark"
                    pollsFillerQuery = (If(sortDirection.ToLower() = "asc", pollsFillerQuery.OrderBy(Function(a) a.Remark), pollsFillerQuery.OrderByDescending(Function(a) a.Remark)))
            End Select
            Return pollsFillerQuery.Skip(startIndex).Take(pageSize).ToList()
        End Function
    End Class

End Namespace




