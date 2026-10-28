Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IMenuService

        Function GetAllMenuByDivisionIdParentId(divisionId As Integer, ByVal ParentId As Integer) As IList(Of Menu)

        Function GetAllMenuByDivisionId(divisionId As Integer) As IList(Of Menu)

        Function GetAllLinkByPersian() As IList(Of Menu)

        Function GetSitesLink(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Menu)
        Function SearchPersianMenus(Optional MenuNo As Integer? = Nothing, Optional ByVal DivisionId As Integer? = Nothing) As IList(Of Menu)
        Function SearchLatinMenus(Optional MenuNo As Integer? = Nothing, Optional ByVal DivisionId As Integer? = Nothing) As IList(Of Menu)
    End Interface

End Namespace
