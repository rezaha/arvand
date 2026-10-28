Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public Interface IExecutiveManagerService

        Function GetOneManager(managerId As Integer) As ExecutiveManagers

        Function RemoveManager(executiveManager As ExecutiveManagers, err As Dictionary(Of String, String)) As Integer

        Function EditManager(executiveManager As ExecutiveManagers, err As Dictionary(Of String, String)) As Integer

        Function AddManager(executiveManager As ExecutiveManagers, err As Dictionary(Of String, String)) As Integer

        Function GetAllManagers(ByVal divisionId As Integer) As IList(Of ExecutiveManagers)
    End Interface
End Namespace