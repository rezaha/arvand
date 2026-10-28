Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports Danesh.ArvandIntranet.CommonLibrary

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class PagesService
        Implements IPagesService

        Private _uow As IUnitOfWork
        Private _page As IDbSet(Of Page)

        Public Sub New()

        End Sub

        Public Function DeletePage(ByVal page As Page) As Integer Implements IPagesService.DeletePAge
            Dim rowEffect As Integer = 0
            _page.Remove(page)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function AddPage(ByVal page As Page) As Integer Implements IPagesService.AddPage
            Dim rowEffect As Integer = 0
            _page.Add(page)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function UpdatePage() As Integer Implements IPagesService.UpdatePage
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _page = _uow.Set(Of Page)()
        End Sub

        Public Function GetAllPages(Optional ByVal pageType As PageType? = Nothing) As IList(Of Page) Implements IPagesService.GetAllPages
            If pageType IsNot Nothing Then
                Dim pageTypeId As Integer = pageType.Value
                Dim pages = _page.Where(Function(a) a.PageTypeId = pageTypeId)
                Return pages.ToList
                'Return _page.Where(Function(a) a.PageType = pageType)
            Else
                Return _page.ToList()
            End If
        End Function

        Public Function GetAllPagesByDivisionId(ByVal divisionId As Integer, Optional ByVal pageType As PageType? = Nothing) As IList(Of Page) Implements IPagesService.GetAllPagesByDivisionId
            If pageType IsNot Nothing Then
                Dim pageTypeId As Integer = pageType.Value
                Dim pages = _page.Where(Function(a) a.PageTypeId = pageTypeId And a.DivisionId = divisionId)
                Return pages.ToList
                'Return _page.Where(Function(a) a.PageType = pageType)
            Else
                Return _page.Where(Function(a) a.DivisionId = divisionId).ToList()
            End If
        End Function

        Public Function GetPages(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Page) Implements IPagesService.GetPages
            If sortexpression = String.Empty Then
                sortexpression = "PageId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim page = _page.AsQueryable
            Select Case SortColumnName
                Case "PageId"
                    page = IIf(SortDirection.ToLower = "asc", page.OrderBy(Function(a) a.PageId), page.OrderByDescending(Function(a) a.PageId))
                Case "PageNo"
                    page = IIf(SortDirection.ToLower = "asc", page.OrderBy(Function(a) a.PageNo), page.OrderByDescending(Function(a) a.PageNo))
                Case "Remark"
                    page = IIf(SortDirection.ToLower = "asc", page.OrderBy(Function(a) a.Remark), page.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim pageList = page.Skip(startIndex).Take(PageSize).ToList
            Return pageList
        End Function

        Public Function GetOnePage(ByVal PageId As Integer) As Page Implements IPagesService.GetOnePage
            Return _page.FirstOrDefault(Function(a) a.PageId = PageId)
        End Function

        Public Function GetTopPage(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Page) Implements IPagesService.GetTopPage
            If sortexpression = String.Empty Then
                sortexpression = "PageId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim page = _page.Where(Function(a) a.Active And Not a.PageDelete And a.PageType = PageType.UserDefinePage)
            Select Case SortColumnName
                Case "PageId"
                    page = IIf(SortDirection.ToLower = "asc", page.OrderBy(Function(a) a.PageId), page.OrderByDescending(Function(a) a.PageId))
                Case "PageNo"
                    page = IIf(SortDirection.ToLower = "asc", page.OrderBy(Function(a) a.PageNo), page.OrderByDescending(Function(a) a.PageNo))
                Case "Remark"
                    page = IIf(SortDirection.ToLower = "asc", page.OrderBy(Function(a) a.Remark), page.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim pageList = page.Skip(startIndex).Take(PageSize).ToList
            Return pageList
        End Function

        Public Function GetTopPage(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String, ByVal DivisionId As Integer) As IList(Of Page) Implements IPagesService.GetTopPage
            If sortexpression = String.Empty Then
                sortexpression = "PageId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim page = _page.Where(Function(a) a.Active And Not a.PageDelete And a.PageType = PageType.UserDefinePage And a.DivisionId = DivisionId)
            Select Case SortColumnName
                Case "PageId"
                    page = IIf(SortDirection.ToLower = "asc", page.OrderBy(Function(a) a.PageId), page.OrderByDescending(Function(a) a.PageId))
                Case "PageNo"
                    page = IIf(SortDirection.ToLower = "asc", page.OrderBy(Function(a) a.PageNo), page.OrderByDescending(Function(a) a.PageNo))
                Case "Remark"
                    page = IIf(SortDirection.ToLower = "asc", page.OrderBy(Function(a) a.Remark), page.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim pageList = page.Skip(startIndex).Take(PageSize).ToList
            Return pageList
        End Function

        Public Function GetPageBySearch(ByVal SearchParameter As String) As IList(Of Page) Implements IPagesService.GetPageBySearch
            Dim PageList As New List(Of Page)
            If SearchParameter <> "" Then
                Dim SearchedPage = _page.Where(Function(a) a.Active And a.PageTypeId = 1)
                SearchedPage = SearchedPage.Where(Function(a) a.PageTitle.Contains(SearchParameter) Or a.PageSummary.Contains(SearchParameter) Or a.PageContent.Contains(SearchParameter))
                Dim list = SearchedPage.ToList()

                For Each item In list
                    If item.PageContent.StripHTML.ToLower().Contains(SearchParameter.ToLower()) Or item.PageTitle.ToLower().Contains(SearchParameter.ToLower()) Or item.PageSummary.ToLower().Contains(SearchParameter.ToLower()) Then
                        PageList.Add(item)
                    End If
                Next
            End If
            Return PageList
        End Function

        Public Function GetPageByDivisionAndPageName(ByVal DivisionId As Integer, ByVal PageName As String) As Page Implements IPagesService.GetPageByDivisionAndPageName
            Return _page.FirstOrDefault(Function(a) a.DivisionId = DivisionId And a.PageFileName.ToLower = PageName.ToLower)
        End Function

        Public Function GetLogicalPageByDivision(ByVal DivisionId As Integer) As IList(Of Page) Implements IPagesService.GetLogicalPageByDivision
            Return _page.Where(Function(a) a.DivisionId = DivisionId And a.PageTypeId = 1).ToList
        End Function

    End Class

End Namespace