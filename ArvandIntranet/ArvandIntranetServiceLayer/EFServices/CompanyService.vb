Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class CompanyService
        Implements ICompanyService

        Private _uow As IUnitOfWork
        Private _company As IDbSet(Of Company)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _company = _uow.Set(Of Company)()
        End Sub

        Public Function AddCompan(ByVal Company As Company, ByVal err As Dictionary(Of String, String)) As Integer Implements ICompanyService.AddCompany
            Dim rowEffect As Integer = 0
            Company.CoOrder = MaxOrder() + 1
            _company.Add(Company)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        'Public Function UpdateCompany(ByVal Company As COMPANIES, ByVal err As Dictionary(Of String, String)) As Integer
        '    Dim rowEffect As Integer = 0
        '    _products.(Company)
        '    Return rowEffect
        'End Function

        Public Function DeleteCompany(ByVal Company As Company, ByVal err As Dictionary(Of String, String)) As Integer Implements ICompanyService.DeleteCompany
            Dim rowEffect As Integer = 0
            _company.Remove(Company)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetOne(ByVal CompanyId As Integer) As Company Implements ICompanyService.GetOne
            Return _company.FirstOrDefault(Function(a) a.CoId = CompanyId)
        End Function

        Public Function GetAllCompanies() As IList(Of Company) Implements ICompanyService.GetAllCompanies
            Return _company.Include(Function(a) a.CompanyTypes).OrderBy(Function(a) a.CoId).ToList
        End Function

        Private Function MaxOrder() As Integer
            Return _company.Max(Function(a) a.CoOrder)
        End Function

        Public Function GetCompanyCount() As Integer Implements ICompanyService.GetCompanyCount
            Return _company.Count
        End Function

        Public Function GetCompany(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Company) Implements ICompanyService.GetCompany
            If sortexpression = String.Empty Then
                sortexpression = "CO_NAME ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim Company = _company.Include(Function(a) a.CompanyTypes)
            Select Case SortColumnName
                Case "CO_ID"
                    Company = IIf(SortDirection.ToLower = "asc", Company.OrderBy(Function(a) a.CoId), Company.OrderByDescending(Function(a) a.CoId))
                Case "CO_NAME"
                    Company = IIf(SortDirection.ToLower = "asc", Company.OrderBy(Function(a) a.NamePersian), Company.OrderByDescending(Function(a) a.NamePersian))
                Case "CO_ABBR"
                    Company = IIf(SortDirection.ToLower = "asc", Company.OrderBy(Function(a) a.CoAbbr), Company.OrderByDescending(Function(a) a.CoAbbr))
                Case "CO_TYPE"
                    Company = IIf(SortDirection.ToLower = "asc", Company.OrderBy(Function(a) a.CoType), Company.OrderByDescending(Function(a) a.CoType))
            End Select

            Dim CompanyList = Company.Skip(startIndex).Take(PageSize).ToList
            Return CompanyList
        End Function

    End Class

End Namespace

