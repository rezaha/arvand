Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IPageWebPartService

        Function GetPageWebPartsByWebpartId(WebPartId As Integer) As List(Of PageWebPart)

        Function GetOnePageWebPart(ByVal webpartId As Integer) As PageWebPart
        Function GetPageWebParts(ByVal divisionId As Integer, ByVal pageName As String) As List(Of PageWebPart)
        Function AddPageWebPart(ByVal pageWebPart As PageWebPart) As Integer
        Function DeletePageWebPart(ByVal pageWebPart As PageWebPart) As Integer
    End Interface

End Namespace
