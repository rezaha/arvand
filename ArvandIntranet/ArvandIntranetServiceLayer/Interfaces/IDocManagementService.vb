Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public Interface IDocManagementService

        Function GetDocManagementBySearch(SearchParameter As String) As IList(Of DocManagement)

        Function DeleteDocManagementByWebPartId(webPartId As Integer) As Integer

        Function AddDocManagements(docManagement As List(Of DocManagement)) As Integer

        Function DeleteDocManagement(docManagement As DocManagement) As Integer

        Function EditDocManagement(docManagement As DocManagement) As Integer

        Function AddDocManagement(docManagement As DocManagement) As Integer

        Function GetDocManagementsForDivision(divisionId As Integer) As List(Of DocManagement)

        Function GetOneDocManagement(docId As Integer) As DocManagement

        Function GetDocManagementsForWebpart(webpartId As Integer) As List(Of DocManagement)


    End Interface
End Namespace