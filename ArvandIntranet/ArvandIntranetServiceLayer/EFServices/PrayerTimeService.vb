Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class PrayerTimeService
        Implements IPrayerTimeService

        Private _uow As IUnitOfWork
        Private _prayerTime As IDbSet(Of PrayerTime)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _prayerTime = _uow.Set(Of PrayerTime)()
        End Sub

        Public Function GetPrayerTimes(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of PrayerTime) Implements IPrayerTimeService.GetPrayerTimes
            If sortexpression = String.Empty Then
                sortexpression = "SiteId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim prayerTime = _prayerTime.AsQueryable
            Select Case SortColumnName
                Case "CityId"
                    prayerTime = IIf(SortDirection.ToLower = "asc", prayerTime.OrderBy(Function(a) a.CityId), prayerTime.OrderByDescending(Function(a) a.CityId))
                Case "Remark"
                    prayerTime = IIf(SortDirection.ToLower = "asc", prayerTime.OrderBy(Function(a) a.Remark), prayerTime.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim CityList = prayerTime.Skip(startIndex).Take(PageSize).ToList
            Return CityList
        End Function

        Public Function SearchPrayerTimes(Optional ByVal PrayerDate As String = Nothing) As IList(Of PrayerTime) Implements IPrayerTimeService.SearchPrayerTimes
            Dim prayerTime = _prayerTime.AsQueryable

            If PrayerDate IsNot Nothing Then
                prayerTime.Where(Function(a) a.PrayerDate = PrayerDate)
            End If
            Return prayerTime.ToList()
        End Function

        Public Function GetOnePrayerTimes(ByVal CityId As Integer, ByVal PrayerDate As String) As PrayerTime Implements IPrayerTimeService.GetOnePrayerTimes
            Return _prayerTime.Include(Function(a) a.City).FirstOrDefault(Function(a) a.PrayerDate = PrayerDate And a.CityId = CityId)
        End Function

    End Class

End Namespace