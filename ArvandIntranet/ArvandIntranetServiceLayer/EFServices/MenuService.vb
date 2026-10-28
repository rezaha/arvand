Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class MenuService
        Implements IMenuService

        Private _uow As IUnitOfWork
        Private _menu As IDbSet(Of Menu)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _menu = _uow.Set(Of Menu)()
        End Sub

        Public Function GetSitesLink(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Menu) Implements IMenuService.GetSitesLink
            If sortexpression = String.Empty Then
                sortexpression = "SiteId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim Menu = _menu.AsQueryable
            Select Case SortColumnName
                Case "MenuId"
                    Menu = IIf(SortDirection.ToLower = "asc", Menu.OrderBy(Function(a) a.MenuId), Menu.OrderByDescending(Function(a) a.MenuId))
                Case "MenuLevel"
                    Menu = IIf(SortDirection.ToLower = "asc", Menu.OrderBy(Function(a) a.MenuLevel), Menu.OrderByDescending(Function(a) a.MenuLevel))
                Case "Remark"
                    Menu = IIf(SortDirection.ToLower = "asc", Menu.OrderBy(Function(a) a.Remark), Menu.OrderByDescending(Function(a) a.Remark))
            End Select

            Dim MenuList = Menu.Skip(startIndex).Take(PageSize).ToList
            Return MenuList
        End Function

        Public Function GetAllLinkByPersian() As IList(Of Menu) Implements IMenuService.GetAllLinkByPersian
            Dim Menu = _menu.Where(Function(a) a.Active = True And a.ShowStatus = 1 Or a.ShowStatus = 0)
            Return Menu.ToList()
        End Function

        Public Function SearchPersianMenus(Optional MenuNo As Integer? = Nothing, Optional ByVal DivisionId As Integer? = Nothing) As IList(Of Menu) Implements IMenuService.SearchPersianMenus
            Dim MenuList = _menu.Where(Function(a) a.ShowStatus = 1 Or a.ShowStatus = 0)
            If MenuNo IsNot Nothing Then
                MenuList = MenuList.Where(Function(a) a.MenuId = MenuNo)
            End If
            If DivisionId IsNot Nothing Then
                MenuList = MenuList.Where(Function(a) a.DivisionId = DivisionId)
            End If
            Return MenuList.ToList
        End Function

        Public Function SearchLatinMenus(Optional MenuNo As Integer? = Nothing, Optional ByVal DivisionId As Integer? = Nothing) As IList(Of Menu) Implements IMenuService.SearchLatinMenus
            Dim MenuList = _menu.Where(Function(a) a.ShowStatus = 2 Or a.ShowStatus = 0)
            If MenuNo IsNot Nothing Then
                MenuList = MenuList.Where(Function(a) a.MenuId = MenuNo)
            End If
            If DivisionId IsNot Nothing Then
                MenuList = MenuList.Where(Function(a) a.DivisionId = DivisionId)
            End If
            Return MenuList.ToList
        End Function

        Public Function GetAllMenuByDivisionId(ByVal divisionId As Integer) As IList(Of Menu) Implements IMenuService.GetAllMenuByDivisionId
            Return _menu.Where(Function(a) a.DivisionId = divisionId).ToList
        End Function

        Public Function GetAllMenuByDivisionIdParentId(ByVal divisionId As Integer, ByVal ParentId As Integer) As IList(Of Menu) Implements IMenuService.GetAllMenuByDivisionIdParentId
            Return _menu.Where(Function(a) a.DivisionId = divisionId And a.MenuParent = ParentId).ToList
        End Function

    End Class

End Namespace

