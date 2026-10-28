Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

        Public Interface IVisitorService

        Function GetAllVisitorByDivisionId(divisionId As Integer) As IList(Of Visitor)

        Function AddVisitor(ByVal visitor As Visitor, ByVal err As Dictionary(Of String, String)) As Integer
        End Interface

End Namespace
