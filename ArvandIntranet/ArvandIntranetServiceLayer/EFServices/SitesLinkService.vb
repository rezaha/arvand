Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class SitesLinkService
        Implements ISitesLinkService

        Private _uow As IUnitOfWork
        Private _sitesLink As IDbSet(Of SitesLink)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _sitesLink = _uow.Set(Of SitesLink)()
        End Sub

        Public Function GetSitesLink(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of SitesLink) Implements ISitesLinkService.GetSitesLink
            If sortexpression = String.Empty Then
                sortexpression = "SiteId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim City = _sitesLink.AsQueryable
            Select Case SortColumnName
                Case "SiteId"
                    City = IIf(SortDirection.ToLower = "asc", City.OrderBy(Function(a) a.SiteId), City.OrderByDescending(Function(a) a.SiteId))
                Case "SiteOrder"
                    City = IIf(SortDirection.ToLower = "asc", City.OrderBy(Function(a) a.SiteOrder), City.OrderByDescending(Function(a) a.SiteOrder))
                Case "Remark"
                    City = IIf(SortDirection.ToLower = "asc", City.OrderBy(Function(a) a.Remark), City.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim CityList = City.Skip(startIndex).Take(PageSize).ToList
            Return CityList
        End Function

        Public Function PersianSitesLink(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of SitesLink) Implements ISitesLinkService.PersianSitesLink
            If sortexpression = String.Empty Then
                sortexpression = "SiteId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim sitesLink = _sitesLink.Where(Function(a) a.ShowStatus = 2 Or a.ShowStatus = 0)
            Select Case SortColumnName
                Case "SiteId"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.SiteId), sitesLink.OrderByDescending(Function(a) a.SiteId))
                Case "SiteOrder"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.SiteOrder), sitesLink.OrderByDescending(Function(a) a.SiteOrder))
                Case "Remark"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.Remark), sitesLink.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim sitesLinkList = sitesLink.Skip(startIndex).Take(PageSize).OrderBy(Function(a) a.SiteOrder).ToList
            Return sitesLinkList
        End Function

        Public Function PersianSitesLink(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String, ByVal DivisionId As Integer) As IList(Of SitesLink) Implements ISitesLinkService.PersianSitesLink
            If sortexpression = String.Empty Then
                sortexpression = "SiteId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim sitesLink = _sitesLink.Where(Function(a) (a.ShowStatus = 2 Or a.ShowStatus = 0) And a.DivisionId = DivisionId)
            Select Case SortColumnName
                Case "SiteId"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.SiteId), sitesLink.OrderByDescending(Function(a) a.SiteId))
                Case "SiteOrder"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.SiteOrder), sitesLink.OrderByDescending(Function(a) a.SiteOrder))
                Case "Remark"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.Remark), sitesLink.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim sitesLinkList = sitesLink.Skip(startIndex).Take(PageSize).OrderBy(Function(a) a.SiteOrder).ToList
            Return sitesLinkList
        End Function

        Public Function LatinSitesLink(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of SitesLink) Implements ISitesLinkService.LatinSitesLink
            If sortexpression = String.Empty Then
                sortexpression = "SiteId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim sitesLink = _sitesLink.Where(Function(a) a.ShowStatus = 1 Or a.ShowStatus = 0)
            Select Case SortColumnName
                Case "SiteId"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.SiteId), sitesLink.OrderByDescending(Function(a) a.SiteId))
                Case "SiteOrder"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.SiteOrder), sitesLink.OrderByDescending(Function(a) a.SiteOrder))
                Case "Remark"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.Remark), sitesLink.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim sitesLinkList = sitesLink.Skip(startIndex).Take(PageSize).OrderBy(Function(a) a.SiteOrder).ToList
            Return sitesLinkList
        End Function

        Public Function LatinSitesLink(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String, ByVal DivisionId As Integer) As IList(Of SitesLink) Implements ISitesLinkService.LatinSitesLink
            If sortexpression = String.Empty Then
                sortexpression = "SiteId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim sitesLink = _sitesLink.Where(Function(a) (a.ShowStatus = 1 Or a.ShowStatus = 0) And a.DivisionId = DivisionId)
            Select Case SortColumnName
                Case "SiteId"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.SiteId), sitesLink.OrderByDescending(Function(a) a.SiteId))
                Case "SiteOrder"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.SiteOrder), sitesLink.OrderByDescending(Function(a) a.SiteOrder))
                Case "Remark"
                    sitesLink = IIf(SortDirection.ToLower = "asc", sitesLink.OrderBy(Function(a) a.Remark), sitesLink.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim sitesLinkList = sitesLink.Skip(startIndex).Take(PageSize).OrderBy(Function(a) a.SiteOrder).ToList
            Return sitesLinkList
        End Function

        Public Function GetAllSiteLinkByDivisionId(ByVal divisionId As Integer) As IList(Of SitesLink) Implements ISitesLinkService.GetAllSiteLinkByDivisionId
            Return _sitesLink.Where(Function(a) a.DivisionId = divisionId).ToList
        End Function

    End Class

End Namespace