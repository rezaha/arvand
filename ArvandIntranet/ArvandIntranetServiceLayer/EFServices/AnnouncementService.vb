Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class AnnouncementService
        Implements IAnnouncementService

        Private _uow As IUnitOfWork
        Private _announcement As IDbSet(Of News)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _announcement = _uow.Set(Of News)()
        End Sub

        Public Function GetAnnouncements(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News) Implements IAnnouncementService.GetAnnouncements
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim City = _announcement.Where(Function(a) a.Active And a.NewsGroup = 2)
            Select Case SortColumnName
                Case "ShowDate"
                    City = IIf(SortDirection.ToLower = "asc", City.OrderBy(Function(a) a.ShowDate), City.OrderByDescending(Function(a) a.ShowDate))
                Case "NewsDate"
                    City = IIf(SortDirection.ToLower = "asc", City.OrderBy(Function(a) a.NewsDate), City.OrderByDescending(Function(a) a.NewsDate))
                Case "Remark"
                    City = IIf(SortDirection.ToLower = "asc", City.OrderBy(Function(a) a.Remark), City.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim CityList = City.Skip(startIndex).Take(PageSize).ToList
            Return CityList
        End Function

        Public Function GetOneAnnouncement(Optional ByVal AnnouncementId As Integer? = Nothing) As News Implements IAnnouncementService.GetOneAnnouncement
            Return _announcement.FirstOrDefault(Function(a) a.NewsId = AnnouncementId)
        End Function

        Public Function GetTopAnnouncements(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News) Implements IAnnouncementService.GetTopAnnouncements
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim announcement = _announcement.Where(Function(a) a.Active And a.NewsGroup = 2)
            Select Case SortColumnName
                Case "ShowDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.ShowDate), announcement.OrderByDescending(Function(a) a.ShowDate))
                Case "NewsDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.NewsDate), announcement.OrderByDescending(Function(a) a.NewsDate))
                Case "Remark"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.Remark), announcement.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim announcementList = announcement.Skip(startIndex).Take(PageSize).ToList
            Return announcementList
        End Function

        Public Function GetTopAnnouncements(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String, ByVal DivisionId As Integer) As IList(Of News) Implements IAnnouncementService.GetTopAnnouncements
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim announcement = _announcement.Where(Function(a) a.Active And a.NewsGroup = 2 And a.DivisionId = DivisionId)
            Select Case SortColumnName
                Case "ShowDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.ShowDate), announcement.OrderByDescending(Function(a) a.ShowDate))
                Case "NewsDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.NewsDate), announcement.OrderByDescending(Function(a) a.NewsDate))
                Case "Remark"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.Remark), announcement.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim announcementList = announcement.Skip(startIndex).Take(PageSize).ToList
            Return announcementList
        End Function

        Public Function GetPersianAnnouncements(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News) Implements IAnnouncementService.GetPersianAnnouncements
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim announcement = _announcement.Where(Function(a) a.Active And a.NewsGroup = 2 And (a.ShowStatus = 0 Or a.ShowStatus = 1))
            Select Case SortColumnName
                Case "ShowDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.ShowDate), announcement.OrderByDescending(Function(a) a.ShowDate))
                Case "NewsDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.NewsDate), announcement.OrderByDescending(Function(a) a.NewsDate))
                Case "Remark"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.Remark), announcement.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim announcementList = announcement.Skip(startIndex).Take(PageSize).ToList
            Return announcementList
        End Function

        Public Function GetPersianAnnouncements(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String, ByVal DivisionId As Integer) As IList(Of News) Implements IAnnouncementService.GetPersianAnnouncements
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim announcement = _announcement.Where(Function(a) a.Active And a.NewsGroup = 2 And (a.ShowStatus = 0 Or a.ShowStatus = 1) And a.DivisionId = DivisionId)
            Select Case SortColumnName
                Case "ShowDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.ShowDate), announcement.OrderByDescending(Function(a) a.ShowDate))
                Case "NewsDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.NewsDate), announcement.OrderByDescending(Function(a) a.NewsDate))
                Case "Remark"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.Remark), announcement.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim announcementList = announcement.Skip(startIndex).Take(PageSize).ToList
            Return announcementList
        End Function

        Public Function GetLatinAnnouncements(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News) Implements IAnnouncementService.GetLatinAnnouncements
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim announcement = _announcement.Where(Function(a) a.Active And a.NewsGroup = 2 And (a.ShowStatus = 0 Or a.ShowStatus = 2))
            Select Case SortColumnName
                Case "ShowDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.ShowDate), announcement.OrderByDescending(Function(a) a.ShowDate))
                Case "NewsDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.NewsDate), announcement.OrderByDescending(Function(a) a.NewsDate))
                Case "Remark"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.Remark), announcement.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim announcementList = announcement.Skip(startIndex).Take(PageSize).ToList
            Return announcementList
        End Function

        Public Function GetLatinAnnouncements(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String, ByVal DivisionId As Integer) As IList(Of News) Implements IAnnouncementService.GetLatinAnnouncements
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim announcement = _announcement.Where(Function(a) a.Active And a.NewsGroup = 2 And (a.ShowStatus = 0 Or a.ShowStatus = 2) And a.DivisionId = DivisionId)
            Select Case SortColumnName
                Case "ShowDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.ShowDate), announcement.OrderByDescending(Function(a) a.ShowDate))
                Case "NewsDate"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.NewsDate), announcement.OrderByDescending(Function(a) a.NewsDate))
                Case "Remark"
                    announcement = IIf(SortDirection.ToLower = "asc", announcement.OrderBy(Function(a) a.Remark), announcement.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim announcementList = announcement.Skip(startIndex).Take(PageSize).ToList
            Return announcementList
        End Function


    End Class

End Namespace

