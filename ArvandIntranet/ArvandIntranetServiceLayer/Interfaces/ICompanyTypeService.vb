Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface ICompanyTypeService
        Function AddCompanyType(ByVal CompanyType As CompanyTypes, ByVal err As Dictionary(Of String, String)) As Integer
        Function DeleteCompanyType(ByVal CompanyType As CompanyTypes, ByVal err As Dictionary(Of String, String))
        Function GetOne(ByVal CompanyTypeId As Integer) As CompanyTypes
        Function GetAll() As IList(Of CompanyTypes)
        Function MaxCompanyTypeId() As Integer
        Function GetCompanyTypeCount() As Integer
        Function GetCompanyType(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of CompanyTypes)
    End Interface

End Namespace
