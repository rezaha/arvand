Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IPersuasiveService

        Function GetTopPersuasive() As News

        Function GetPersuasive(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News)
        Function GetTopPersuasive(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of News)
    End Interface

End Namespace