Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface ISitesLinkService

        Function GetAllSiteLinkByDivisionId(divisionId As Integer) As IList(Of SitesLink)
        Function LatinSitesLink(startIndex As Integer, PageSize As Integer, sortexpression As String, DivisionId As Integer) As IList(Of SitesLink)
        Function PersianSitesLink(startIndex As Integer, PageSize As Integer, sortexpression As String, DivisionId As Integer) As IList(Of SitesLink)
        Function LatinSitesLink(startIndex As Integer, PageSize As Integer, sortexpression As String) As IList(Of SitesLink)
        Function PersianSitesLink(startIndex As Integer, PageSize As Integer, sortexpression As String) As IList(Of SitesLink)
        Function GetSitesLink(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of SitesLink)
    End Interface

End Namespace