Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IPlantDivisionsService


        Function AddPlantDivision(PlantDivision As PlantDivisions) As Integer

        Function DeletePlantDivision(PlantDivision As PlantDivisions) As Integer

        Function AllPlantDivision() As IList(Of PlantDivisions)

        Function UpdatePlantDivisions(ByVal PlantDivision As PlantDivisions) As Integer
        Function GetOnePlantDivisions(Optional ByVal PlantDivisionsId As Integer? = Nothing) As PlantDivisions
        Function GetPlantDivisions(ByVal plantDivisionsAbbr As String) As PlantDivisions
        Function AnyChild(ByVal divisionId As Integer) As Boolean
    End Interface

End Namespace