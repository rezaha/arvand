Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IPagesService

        Function GetLogicalPageByDivision(DivisionId As Integer) As IList(Of Page)

        Function GetAllPagesByDivisionId(ByVal divisionId As Integer, Optional ByVal pageType As PageType? = Nothing) As IList(Of Page)

        Function GetPageByDivisionAndPageName(DivisionId As Integer, PageName As String) As Page

        Function GetTopPage(startIndex As Integer, PageSize As Integer, sortexpression As String, DivisionId As Integer) As IList(Of Page)

        Function GetPageBySearch(SearchParameter As String) As IList(Of Page)

        Function DeletePage(ByVal page As Page) As Integer

        Function GetAllPages(Optional PageType As PageType? = Nothing) As IList(Of Page)

        Function UpdatePage() As Integer

        Function AddPage(page As Page) As Integer

        Function GetPages(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Page)
        Function GetOnePage(ByVal PageId As Integer) As Page
        Function GetTopPage(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Page)
    End Interface

End Namespace
