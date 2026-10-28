Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports Danesh.ArvandIntranet.CommonLibrary

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class NewsService
        Implements INewsService

        Private _uow As IUnitOfWork
        Private _news As IDbSet(Of News)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _news = _uow.Set(Of News)()
        End Sub

        Public Function GetNews(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News) Implements INewsService.GetNews
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim City = _news.Where(Function(a) a.Active And a.NewsGroup = 1)
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

        Public Function GetOneNews(ByVal NewsId As Integer) As News Implements INewsService.GetOneNews
            Return _news.FirstOrDefault(Function(a) a.NewsId = NewsId)
        End Function

        Public Function GetAllNews() As IList(Of News) Implements INewsService.GetAllNews
            Return _news.Where(Function(a) a.NewsGroup = 1).OrderByDescending(Function(a) a.NewsDate).ToList()
        End Function

        Public Function GetTopPersianNews(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News) Implements INewsService.GetTopPersianNews
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim City = _news.Where(Function(a) a.Active And a.NewsGroup = 1 And (a.ShowStatus = 0 Or a.ShowStatus = 1))
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

        Public Function GetTopPersianNews(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String, ByVal divisionId As Integer) As IList(Of News) Implements INewsService.GetTopPersianNews
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim City = _news.Where(Function(a) a.Active And a.NewsGroup = 1 And (a.ShowStatus = 0 Or a.ShowStatus = 1) And a.DivisionId = divisionId)
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

        Public Function GetTopLatinNews(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News) Implements INewsService.GetTopLatinNews
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim City = _news.Where(Function(a) a.Active And a.NewsGroup = 1 And (a.ShowStatus = 0 Or a.ShowStatus = 2))
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

        Public Function GetTopLatinNews(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String, ByVal divisionId As Integer) As IList(Of News) Implements INewsService.GetTopLatinNews
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim City = _news.Where(Function(a) a.Active And a.NewsGroup = 1 And (a.ShowStatus = 0 Or a.ShowStatus = 2) And a.DivisionId = divisionId)
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

        Public Function GetNewsBySearchPersian(ByVal SearchParameter As String) As IList(Of News) Implements INewsService.GetNewsBySearchPersian
            Dim NewsList As New List(Of News)

            If SearchParameter <> "" Then
                Dim SearchedNews = _news.Where(Function(a) a.Active And (a.NewsGroup = 1 Or a.NewsGroup = 2))
                SearchedNews = SearchedNews.Where(Function(a) a.TitlePersian.Contains(SearchParameter) Or a.SummaryPersian.Contains(SearchParameter) Or a.ContentPersian.Contains(SearchParameter) Or a.HtmlContentPersian.Contains(SearchParameter))
                Dim list = SearchedNews.ToList()

                For Each item In list
                    If item.HtmlContentPersian.StripHTML.ToLower().Contains(SearchParameter.ToLower()) Or item.ContentPersian.ToLower().Contains(SearchParameter.ToLower()) Or item.SummaryPersian.ToLower().Contains(SearchParameter.ToLower()) Or item.TitlePersian.ToLower().Contains(SearchParameter.ToLower()) Then
                        NewsList.Add(item)
                    End If
                Next
            End If

            Return NewsList
        End Function

        Public Function GetNewsBySearchLatin(ByVal SearchParameter As String) As IList(Of News) Implements INewsService.GetNewsBySearchLatin
            Dim NewsList As New List(Of News)

            If SearchParameter <> "" Then
                Dim SearchedNews = _news.Where(Function(a) a.Active And (a.NewsGroup = 1 Or a.NewsGroup = 2))
                SearchedNews = SearchedNews.Where(Function(a) a.TitleLatin.Contains(SearchParameter) Or a.SummaryLatin.Contains(SearchParameter) Or a.ContentLatin.Contains(SearchParameter) Or a.HtmlContentLatin.Contains(SearchParameter))
                Dim list = SearchedNews.ToList()

                For Each item In list
                    If item.HtmlContentLatin.StripHTML.ToLower().Contains(SearchParameter.ToLower()) Or item.ContentLatin.ToLower().Contains(SearchParameter.ToLower()) Or item.SummaryLatin.ToLower().Contains(SearchParameter.ToLower()) Or item.TitleLatin.ToLower().Contains(SearchParameter.ToLower()) Then
                        NewsList.Add(item)
                    End If
                Next
            End If

            Return NewsList
        End Function

    End Class

End Namespace