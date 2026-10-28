Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class CompanyTypeService
        Implements ICompanyTypeService

        Private _uow As IUnitOfWork
        Private _companyType As IDbSet(Of CompanyTypes)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _companyType = _uow.Set(Of CompanyTypes)()
        End Sub

        Public Function AddCompanyType(ByVal CompanyType As CompanyTypes, ByVal err As Dictionary(Of String, String)) As Integer Implements ICompanyTypeService.AddCompanyType
            Dim rowEffect As Integer = 0
            _companyType.Add(CompanyType)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        'Public Function UpdateCompanyType(ByVal CompanyType As COMPANY_TYPES, ByVal err As Dictionary(Of String, String)) As Integer
        '    Dim rowEffect As Integer = 0
        '    If CompanyType.IsValidate(err) Then
        '        repository.Update(CompanyType)
        '        rowEffect = repository.UnitOfWork.SaveChanges()
        '    End If
        '    Return rowEffect
        'End Function

        Public Function DeleteCompanyType(ByVal CompanyType As CompanyTypes, ByVal err As Dictionary(Of String, String)) Implements ICompanyTypeService.DeleteCompanyType
            Dim rowEffect As Integer = 0
            _companyType.Remove(CompanyType)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetOne(ByVal CompanyTypeId As Integer) As CompanyTypes Implements ICompanyTypeService.GetOne
            Return _companyType.FirstOrDefault(Function(a) a.CoTypeId = CompanyTypeId)
        End Function

        Public Function GetAll() As IList(Of CompanyTypes) Implements ICompanyTypeService.GetAll
            Return _companyType.OrderBy(Function(a) a.CoTypeDes).ToList
        End Function

        Public Function MaxCompanyTypeId() As Integer Implements ICompanyTypeService.MaxCompanyTypeId
            Return _companyType.Max(Function(a) a.CoTypeId)
        End Function

        Public Function GetCompanyTypeCount() As Integer Implements ICompanyTypeService.GetCompanyTypeCount
            Return _companyType.Count
        End Function

        Public Function GetCompanyType(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of CompanyTypes) Implements ICompanyTypeService.GetCompanyType
            If sortexpression = String.Empty Then
                sortexpression = "CoTypeId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim CompanyTypes As IQueryable(Of CompanyTypes) = _companyType.AsQueryable
            Select Case SortColumnName
                Case "CoTypeId"
                    CompanyTypes = IIf(SortDirection.ToLower = "asc", CompanyTypes.OrderBy(Function(a) a.CoTypeId), CompanyTypes.OrderByDescending(Function(a) a.CoTypeId))
                Case "CoTypeDes"
                    CompanyTypes = IIf(SortDirection.ToLower = "asc", CompanyTypes.OrderBy(Function(a) a.CoTypeDes), CompanyTypes.OrderByDescending(Function(a) a.CoTypeDes))
            End Select

            Dim CompanyTypesList = CompanyTypes.Skip(startIndex).Take(PageSize).ToList
            Return CompanyTypesList
        End Function

    End Class

End Namespace

