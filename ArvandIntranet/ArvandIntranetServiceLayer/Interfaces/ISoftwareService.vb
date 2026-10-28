Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public Interface ISoftwareService

        Function RemoveSoftware(software As Software, err As Dictionary(Of String, String)) As Integer

        Function EditSoftware(software As Software, err As Dictionary(Of String, String)) As Integer

        Function AddSoftware(software As Software, err As Dictionary(Of String, String)) As Integer

        Function GetOneSoftwares(softwareId As Integer) As Software

        Function GetAllSoftwares(ByVal divisionId As Integer) As IList(Of Software)
    End Interface
End Namespace