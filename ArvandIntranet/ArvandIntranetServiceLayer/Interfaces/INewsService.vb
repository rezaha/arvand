Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface INewsService

        Function GetTopLatinNews(startIndex As Integer, PageSize As Integer, sortexpression As String, divisionId As Integer) As IList(Of News)

        Function GetTopPersianNews(startIndex As Integer, PageSize As Integer, sortexpression As String, divisionId As Integer) As IList(Of News)

        Function GetNewsBySearchLatin(SearchParameter As String) As IList(Of News)

        Function GetNewsBySearchPersian(SearchParameter As String) As IList(Of News)

        Function GetAllNews() As IList(Of News)

        Function GetTopLatinNews(startIndex As Integer, PageSize As Integer, sortexpression As String) As IList(Of News)
        Function GetTopPersianNews(startIndex As Integer, PageSize As Integer, sortexpression As String) As IList(Of News)
        Function GetOneNews(ByVal NewsId As Integer) As News
        Function GetNews(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News)

    End Interface

End Namespace