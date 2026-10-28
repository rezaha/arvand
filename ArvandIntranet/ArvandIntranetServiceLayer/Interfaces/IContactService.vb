Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public Interface IContactService
        Function GetAllContactByDivisionId(ByVal divisionId As Integer) As IList(Of Contact)
    End Interface
End Namespace