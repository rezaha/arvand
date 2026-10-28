Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IPrayerTimeService
        Function GetPrayerTimes(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of PrayerTime)
        Function SearchPrayerTimes(Optional ByVal PrayerDate As String = Nothing) As IList(Of PrayerTime)
        Function GetOnePrayerTimes(ByVal CityId As Integer, ByVal PrayerDate As String) As PrayerTime
    End Interface

End Namespace