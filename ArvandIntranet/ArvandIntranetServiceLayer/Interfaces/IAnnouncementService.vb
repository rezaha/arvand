Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IAnnouncementService

        Function GetTopAnnouncements(startIndex As Integer, PageSize As Integer, sortexpression As String, DivisionId As Integer) As IList(Of News)

        Function GetLatinAnnouncements(startIndex As Integer, PageSize As Integer, sortexpression As String, DivisionId As Integer) As IList(Of News)

        Function GetPersianAnnouncements(startIndex As Integer, PageSize As Integer, sortexpression As String, DivisionId As Integer) As IList(Of News)

        Function GetLatinAnnouncements(startIndex As Integer, PageSize As Integer, sortexpression As String) As IList(Of News)

        Function GetPersianAnnouncements(startIndex As Integer, PageSize As Integer, sortexpression As String) As IList(Of News)

        Function GetOneAnnouncement(Optional AnnouncementId As Integer? = Nothing) As News

        Function GetAnnouncements(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News)
        Function GetTopAnnouncements(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News)
    End Interface

End Namespace