Imports System.Data.Entity
Imports ArvandIntranetDomainClasses.Models
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices
 
    Public Class PollService
        Implements IPollService
       

        Private ReadOnly _uow As IUnitOfWork
        Private ReadOnly _poll As IDbSet(Of Poll)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _poll = _uow.Set(Of Poll)()
        End Sub

        Public Function GetAllPollByDivisionId(ByVal divisionId As Integer) As IList(Of Poll) Implements IPollService.GetAllPollByDivisionId
            Return _poll.Where(Function(a) a.DivisionId = divisionId).ToList
        End Function

        Public Function AddPolls(ByVal polls As Poll, ByVal err As Dictionary(Of String, String)) As Integer Implements IPollService.AddPolls
            _poll.Add(polls)
            Return _uow.SaveChanges()
        End Function


        Public Sub EditPolls(ByVal polls As Poll, ByVal err As Dictionary(Of String, String)) Implements IPollService.EditPolls
            _uow.SaveChanges()
        End Sub

        ''' <summary>
        ''' حذف عنصر
        ''' </summary>
        ''' <param name="polls">عنصر مورد نظر</param>
        ''' <param name="err">مجموعه خطا</param>
        Public Function RemovePolls(ByVal polls As Poll, ByVal err As Dictionary(Of String, String)) As Integer Implements IPollService.RemovePolls
            _poll.Remove(polls)
            Return _uow.SaveChanges()
        End Function

        ''' <summary>
        ''' تعداد عناصر
        ''' </summary>
        ''' <returns>تعداد</returns>
        Public Function PollsCount() As Integer Implements IPollService.PollsCount
            Return _poll.Count()
        End Function

        ''' <summary>
        ''' انتخاب یک عنصر
        ''' </summary>
        ''' <param name="pollId">کد عنصر</param>
        ''' <returns>عنصر مورد نظر</returns>
        Public Function GetOnePolls(ByVal pollId As Integer) As Poll Implements IPollService.GetOnePolls
            Return _poll.FirstOrDefault(Function(a) a.PollId = pollId)
        End Function

        ''' <summary>
        ''' همه عناصر
        ''' </summary>
        ''' <returns>لیستی از عناصر</returns>
        Public Function AllPolls() As IList(Of Poll) Implements IPollService.AllPolls
            Return _poll.ToList()
        End Function

        ''' <summary>
        ''' نمایش اطلاعات در گرید تلریک
        ''' </summary>
        ''' <param name="startIndex">اندیس شروع</param>
        ''' <param name="pageSize">تعداد سطر ها</param>
        ''' <param name="sortexpression">معیار مرتب سازی</param>
        ''' <returns>لیستی از عناصر</returns>
        Public Function GetPolls(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of Poll) Implements IPollService.GetPolls
            If sortexpression = String.Empty Then
                sortexpression = "DivisionId ASC"
            End If

            Dim sortColumnName As String = sortexpression.Split(" "c)(0)
            Dim sortDirection As String = sortexpression.Split(" "c)(1)
            Dim pollsQuery = _poll.AsQueryable()
            Select Case sortColumnName
                Case "PollId"
                    pollsQuery = (If(sortDirection.ToLower() = "asc", pollsQuery.OrderBy(Function(a) a.PollId), pollsQuery.OrderByDescending(Function(a) a.PollId)))
                Case "PollNo"
                    pollsQuery = (If(sortDirection.ToLower() = "asc", pollsQuery.OrderBy(Function(a) a.PollNo), pollsQuery.OrderByDescending(Function(a) a.PollNo)))
                Case "PollName"
                    pollsQuery = (If(sortDirection.ToLower() = "asc", pollsQuery.OrderBy(Function(a) a.PollName), pollsQuery.OrderByDescending(Function(a) a.PollName)))
                Case "PollType"
                    pollsQuery = (If(sortDirection.ToLower() = "asc", pollsQuery.OrderBy(Function(a) a.PollType), pollsQuery.OrderByDescending(Function(a) a.PollType)))
            End Select
            Return pollsQuery.Skip(startIndex).Take(pageSize).ToList()
        End Function

    End Class

End Namespace




