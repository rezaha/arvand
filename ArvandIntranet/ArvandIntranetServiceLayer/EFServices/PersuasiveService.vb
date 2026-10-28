Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class PersuasiveService
        Implements IPersuasiveService

        Private _uow As IUnitOfWork
        Private _news As IDbSet(Of News)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _news = _uow.Set(Of News)()
        End Sub

        Public Function GetPersuasive(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News) Implements IPersuasiveService.GetPersuasive
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim City = _news.Where(Function(a) a.Active And a.NewsGroup = 3)
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

        Public Function GetTopPersuasive(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News) Implements IPersuasiveService.GetTopPersuasive
            If sortexpression = String.Empty Then
                sortexpression = "NewsId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim City = _news.Where(Function(a) a.Active And a.NewsGroup = 3)
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

        Public Function GetTopPersuasive() As News Implements IPersuasiveService.GetTopPersuasive
            Return _news.Where(Function(a) a.Active And a.NewsGroup = 3).OrderBy(Function(a) a.ShowDate).Take(0).FirstOrDefault
        End Function

    End Class

End Namespace