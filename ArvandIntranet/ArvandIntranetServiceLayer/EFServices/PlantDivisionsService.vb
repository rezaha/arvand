Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class PlantDivisionsService
        Implements IPlantDivisionsService

        Private _uow As IUnitOfWork
        Private _PlantDivisions As IDbSet(Of PlantDivisions)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _PlantDivisions = _uow.Set(Of PlantDivisions)()
        End Sub


        Public Function DeletePlantDivision(ByVal PlantDivision As PlantDivisions) As Integer Implements IPlantDivisionsService.DeletePlantDivision
            Dim rowEffect As Integer = 0
            _PlantDivisions.Remove(PlantDivision)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function AddPlantDivision(ByVal PlantDivision As PlantDivisions) As Integer Implements IPlantDivisionsService.AddPlantDivision
            Dim rowEffect As Integer = 0
            _PlantDivisions.Add(PlantDivision)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function


        Public Function UpdatePlantDivisions(ByVal PlantDivision As PlantDivisions) As Integer Implements IPlantDivisionsService.UpdatePlantDivisions
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetOnePlantDivisions(Optional ByVal PlantDivisionsId As Integer? = Nothing) As PlantDivisions Implements IPlantDivisionsService.GetOnePlantDivisions
            Return _PlantDivisions.FirstOrDefault(Function(a) a.DivisionId = PlantDivisionsId)
        End Function

        Public Function GetPlantDivisions(ByVal plantDivisionsAbbr As String) As PlantDivisions Implements IPlantDivisionsService.GetPlantDivisions
            Return _PlantDivisions.Include(Function(a) a.Theme).FirstOrDefault(Function(a) a.DivisionAbbr.ToLower = plantDivisionsAbbr.ToLower)
        End Function

        Public Function AllPlantDivision() As IList(Of PlantDivisions) Implements IPlantDivisionsService.AllPlantDivision
            Return _PlantDivisions.ToList()
        End Function

        Public Function AnyChild(ByVal divisionId As Integer) As Boolean Implements IPlantDivisionsService.AnyChild
            Return _PlantDivisions.Any(Function(a) a.ParentDivisionId.HasValue And a.ParentDivisionId = divisionId)
        End Function

    End Class

End Namespace