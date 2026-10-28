Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface ICompanyService
        Function AddCompany(ByVal Company As Company, ByVal err As Dictionary(Of String, String)) As Integer
        Function DeleteCompany(ByVal Company As Company, ByVal err As Dictionary(Of String, String)) As Integer
        Function GetOne(ByVal CompanyId As Integer) As Company
        Function GetAllCompanies() As IList(Of Company)
        Function GetCompanyCount() As Integer
        Function GetCompany(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Company)
    End Interface

End Namespace

