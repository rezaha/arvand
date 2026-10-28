Imports System.Data.Entity
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class HouseCooperativeService
        Implements IHouseCooperativeService

        Private _uow As IUnitOfWork
        Private _houseCooperative As IDbSet(Of HouseCooperative)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _houseCooperative = _uow.Set(Of HouseCooperative)()
        End Sub

        Public Function AddHouseCooperative(ByVal houseCooperative As HouseCooperative, ByVal err As Dictionary(Of String, String)) As Integer Implements IHouseCooperativeService.AddHouseCooperative
            Dim rowEffect As Integer = 0
            _houseCooperative.Add(houseCooperative)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function EditHouseCooperative(ByVal houseCooperative As HouseCooperative, ByVal err As Dictionary(Of String, String)) As Integer Implements IHouseCooperativeService.EditHouseCooperative
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeleteHouseCooperative(ByVal houseCooperative As HouseCooperative, ByVal err As Dictionary(Of String, String)) As Integer Implements IHouseCooperativeService.DeleteHouseCooperative
            Dim rowEffect As Integer = 0
            _houseCooperative.Remove(HouseCooperative)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetOne(ByVal houseCooperativeId As Integer) As HouseCooperative Implements IHouseCooperativeService.GetOne
            Return _houseCooperative.FirstOrDefault(Function(a) a.Id = houseCooperativeId)
        End Function

        Public Function GetOneByNationalId(ByVal nationalId As String) As HouseCooperative Implements IHouseCooperativeService.GetOneByNationalId
            Return _houseCooperative.FirstOrDefault(Function(a) a.NationalId = nationalId)
        End Function

        Public Function GetAllHouseCooperatives() As IList(Of HouseCooperative) Implements IHouseCooperativeService.GetAllHouseCooperatives
            Return _houseCooperative.OrderBy(Function(a) a.RegisterTime).ToList
        End Function

        Public Function GetHouseCooperativeCount() As Integer Implements IHouseCooperativeService.GetHouseCooperativeCount
            Return _houseCooperative.Count
        End Function

        Public Function GetHouseCooperative(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of HouseCooperative) Implements IHouseCooperativeService.GetHouseCooperative
            If sortexpression = String.Empty Then
                sortexpression = "LastName ASC"
            End If

            Dim sortColumnName As String = sortexpression.Split(" ")(0)
            Dim sortDirection As String = sortexpression.Split(" ")(1)

            Dim houseCooperative = _houseCooperative
            Select Case sortColumnName
                Case "NationalId"
                    houseCooperative = IIf(sortDirection.ToLower = "asc", houseCooperative.OrderBy(Function(a) a.NationalId), houseCooperative.OrderByDescending(Function(a) a.NationalId))
                Case "FirstName"
                    houseCooperative = IIf(sortDirection.ToLower = "asc", houseCooperative.OrderBy(Function(a) a.FirstName), houseCooperative.OrderByDescending(Function(a) a.FirstName))
                Case "LastName"
                    houseCooperative = IIf(sortDirection.ToLower = "asc", houseCooperative.OrderBy(Function(a) a.LastName), houseCooperative.OrderByDescending(Function(a) a.LastName))
                Case "EmpType"
                    houseCooperative = IIf(sortDirection.ToLower = "asc", houseCooperative.OrderBy(Function(a) a.EmpType), houseCooperative.OrderByDescending(Function(a) a.EmpType))
            End Select
            Dim houseCooperativeList = houseCooperative.Skip(startIndex).Take(pageSize).ToList
            Return houseCooperativeList
        End Function
    End Class

End Namespace

