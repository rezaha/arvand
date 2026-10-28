Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class SoftwareService
        Implements ISoftwareService

        Private _uow As IUnitOfWork
        Private _software As IDbSet(Of Software)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _software = _uow.Set(Of Software)()
        End Sub

        Public Function GetAllSoftwares(ByVal divisionId As Integer) As IList(Of Software) Implements ISoftwareService.GetAllSoftwares
            Return _software.Where(Function(a) a.DivisionId = divisionId).OrderBy(Function(a) a.SortOrder).ToList
        End Function

        Public Function GetOneSoftwares(ByVal softwareId As Integer) As Software Implements ISoftwareService.GetOneSoftwares
            Return _software.FirstOrDefault(Function(a) a.SoftwareId = softwareId)
        End Function

        Public Function AddSoftware(ByVal software As Software, ByVal err As Dictionary(Of String, String)) As Integer Implements ISoftwareService.AddSoftware
            Dim rowEffect As Integer = 0
            _software.Add(software)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function EditSoftware(ByVal software As Software, ByVal err As Dictionary(Of String, String)) As Integer Implements ISoftwareService.EditSoftware
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function RemoveSoftware(ByVal software As Software, ByVal err As Dictionary(Of String, String)) As Integer Implements ISoftwareService.RemoveSoftware
            Dim rowEffect As Integer = 0
            _software.Remove(software)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

    End Class

End Namespace

